using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.ACProtocol.Messages.S2C.Events;
using Chorizite.ACProtocol.Types;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Net;
using Core.AC.API.WorldObjects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Core.AC.API {
    /// <summary>
    /// Information about the world around your character
    /// </summary>
    public class World : IDisposable {
        private readonly ILogger _log;
        private readonly NetworkParser _net;
        private ConcurrentDictionary<uint, WorldObject> _weenies = new();

        /// <summary>
        /// A list of all weenies that the client knows about.
        /// </summary>
        public virtual IList<WorldObject> AllWeenies => _weenies.Values.ToList();

        /// <summary>
        /// The container that is currently open, if any
        /// </summary>
        public Container? OpenContainer { get; set; }

        /// <summary>
        /// Fired when a new world object is created
        /// </summary>
        public event EventHandler<ObjectCreatedEventArgs> OnWeenieCreated {
            add => _OnWeenieCreated.Subscribe(value);
            remove => _OnWeenieCreated.Unsubscribe(value);
        }
        private WeakEvent<ObjectCreatedEventArgs> _OnWeenieCreated = new();

        /// <summary>
        /// Fired when a new world object is released from the games memory
        /// </summary>
        public event EventHandler<ObjectReleasedEventArgs> OnWeenieReleased {
            add => _OnWeenieReleased.Subscribe(value);
            remove => _OnWeenieReleased.Unsubscribe(value);
        }
        private WeakEvent<ObjectReleasedEventArgs> _OnWeenieReleased = new();

        /// <summary>
        /// Fired when a container is opened and its contents are available
        /// </summary>
        public event EventHandler<ContainerOpenedEventArgs> OnContainerOpened {
            add => _OnContainerOpened.Subscribe(value);
            remove => _OnContainerOpened.Unsubscribe(value);
        }
        private WeakEvent<ContainerOpenedEventArgs> _OnContainerOpened = new();

        /// <summary>
        /// Fired when a container is closed
        /// </summary>
        public event EventHandler<ContainerClosedEventArgs> OnContainerClosed {
            add => _OnContainerClosed.Subscribe(value);
            remove => _OnContainerClosed.Unsubscribe(value);
        }
        private WeakEvent<ContainerClosedEventArgs> _OnContainerClosed = new();

        public World() {
            _log = CoreACPlugin.Log;
            _net = CoreACPlugin.Instance.Net;

            _net.S2C.OnItem_CreateObject += OnItem_CreateObject;
            _net.S2C.OnItem_DeleteObject += OnItem_DeleteObject;
            _net.S2C.OnItem_ObjDescEvent += OnItem_ObjDescEvent;
            _net.S2C.OnItem_ParentEvent += OnItem_ParentEvent;
            _net.S2C.OnItem_ServerSaysContainId += OnItem_ServerSaysContainId;
            _net.S2C.OnItem_ServerSaysMoveItem += OnItem_ServerSaysMoveItem;
            _net.S2C.OnItem_ServerSaysRemove += OnItem_ServerSaysRemove;
            _net.S2C.OnInventory_PickupEvent += OnInventory_PickupEvent;

            _net.S2C.OnItem_OnViewContents += OnItem_OnViewContents;
            _net.S2C.OnItem_StopViewingObjectContents += OnItem_StopViewingObjectContents;
        }

        #region public API
        public WorldObject? Get(uint objectId) {
            if (_weenies.TryGetValue(objectId, out WorldObject? weenie)) {
                return weenie;
            }

            return null;
        }
        #endregion // public API

        #region Event Handlers
        private void OnItem_CreateObject(object? sender, Item_CreateObject e) {
            WorldObject? weenie = null;

            if (e.ObjectId == CoreACPlugin.Instance.Game.Character.Id) {
                weenie = CoreACPlugin.Instance.Game.Character;
            }
            else {
                weenie = GetOrCreateWorldObject(e.ObjectId, e.ObjectDescription, e.PhysicsDescription, e.WeenieDescription);
            }

            weenie.UpdateObjDesc(e.ObjectDescription);
            weenie.UpdatePhysicsDesc(e.PhysicsDescription);
            weenie.UpdateWeenieDesc(e.WeenieDescription);

            _OnWeenieCreated?.Invoke(this, new ObjectCreatedEventArgs(weenie));
        }

        private void OnItem_DeleteObject(object? sender, Item_DeleteObject e) {
            RemoveWeenie(e.ObjectId);
        }

        private void OnItem_ObjDescEvent(object? sender, Item_ObjDescEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to update Item_ObjDescEvent");
                return;
            }

            weenie.UpdateObjDesc(e.ObjectDescription);
        }

        private void OnItem_OnViewContents(object? sender, Item_OnViewContents e) {
            if (Get(e.ContainerId) is not Container container) {
                _log.LogWarning($"Could not find container 0x{e.ContainerId:X8} to update Item_OnViewContents ({Get(e.ContainerId)})");
                return;
            }

            var weeniesToWatchFor = new List<uint>();

            foreach (var contentProfile in e.Items) {
                var weenie = Get(contentProfile.ObjectId);
                if (weenie is null) {
                    _log.LogWarning($"Could not find weenie 0x{contentProfile.ObjectId:X8} to update Item_OnViewContents ({container})");
                    continue;
                }
                if (weenie is Container childContainer) {
                    childContainer.ContainerType = contentProfile.ContainerType;
                    childContainer.AddOrUpdateValue(PropertyInstanceId.Container, e.ContainerId);
                }
                weeniesToWatchFor.Add(weenie.Id);
            }

            if (container.ParentContainer?.Id != CoreACPlugin.Instance.Game.Character.Id) {
                OpenContainer = container;

                if (weeniesToWatchFor.Count == 0) {
                    _OnContainerOpened?.Invoke(this, new ContainerOpenedEventArgs(container));
                }
                else {
                    // wait until we get a weenie description for each of the container children before firing onContainerOpened
                    EventHandler<Item_CreateObject> handleCreateObject = null;
                    handleCreateObject = (s, m) => {
                        if (weeniesToWatchFor.Contains(m.ObjectId)) {
                            weeniesToWatchFor.Remove(m.ObjectId);

                            if (weeniesToWatchFor.Count == 0) {
                                _net.S2C.OnItem_CreateObject -= handleCreateObject;
                                _OnContainerOpened?.Invoke(this, new ContainerOpenedEventArgs(container));
                            }
                        }
                    };

                    _net.S2C.OnItem_CreateObject += handleCreateObject;
                }
            }
        }

        private void OnItem_StopViewingObjectContents(object? sender, Item_StopViewingObjectContents e) {
            var container = Get(e.ObjectId) as Container;
            if (container is null) {
                _log.LogWarning($"Could not find container 0x{e.ObjectId:X8} to update Item_StopViewingObjectContents ({Get(e.ObjectId)})");
                return;
            }

            OpenContainer = null;
            _OnContainerClosed?.Invoke(this, new ContainerClosedEventArgs(container));
        }

        private void OnItem_ParentEvent(object? sender, Item_ParentEvent e) {
            var weenie = Get(e.ChildId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ChildId:X8} to update Item_ParentEvent");
                return;
            }
            weenie.AddOrUpdateValue(PropertyInstanceId.Wielder, e.ParentId);
        }

        private void OnItem_ServerSaysContainId(object? sender, Item_ServerSaysContainId e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to update Item_ServerSaysContainId");
                return;
            }

            var newParent = Get(e.ContainerId) as Container;
            if (newParent is null) {
                _log.LogWarning($"Could not find parent container 0x{e.ContainerId:X8} ({Get(e.ContainerId)}) to update Item_ServerSaysContainId");
                return;
            }

            MoveWeenie(weenie, newParent, (int)e.SlotIndex);
        }

        private void OnItem_ServerSaysMoveItem(object? sender, Item_ServerSaysMoveItem e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to update Item_ServerSaysMoveItem");
                return;
            }
            MoveWeenie(weenie, null, 0);
        }

        private void OnItem_ServerSaysRemove(object? sender, Item_ServerSaysRemove e) {
            RemoveWeenie(e.ObjectId);
        }

        private void OnInventory_PickupEvent(object? sender, Inventory_PickupEvent e) {
            _log.LogError($"Inventory_PickupEvent: 0x{e.ObjectId:X8} ({Get(e.ObjectId)})");
        }
        #endregion // Event Handlers

        private WorldObject GetOrCreateWorldObject(uint objectId, ObjDesc objectDescription, PhysicsDesc physicsDescription, PublicWeenieDesc weenieDescription) {
            if (_weenies.TryGetValue(objectId, out WorldObject? weenie)) {
                weenie.LastAccessTime = DateTime.UtcNow;
            }

            weenie ??= CreateWorldObject(objectId, weenieDescription);

            _weenies.TryAdd(objectId, weenie);

            return weenie;
        }

        private WorldObject CreateWorldObject(uint objectId, PublicWeenieDesc weenieDescription) {
            var objectClass = WorldObject.GetObjectClass(weenieDescription.Type, weenieDescription.Behavior, weenieDescription.Header);
            WorldObject? wobject = null;

            switch (objectClass) {
                case ObjectClass.Player:
                    wobject = new Player();
                    break;
                default:
                    wobject = new WorldObject();
                    break;
            }

            wobject.Id = objectId;
            wobject.LastAccessTime = DateTime.UtcNow;
            wobject.CreatedAt = DateTime.UtcNow;

            return wobject;
        }

        private void MoveWeenie(WorldObject weenie, Container? newParent, int slot) {
            if (weenie is Container childContainer) {
                weenie.ParentContainer?.Containers.Remove(childContainer);
                if (newParent is not null) {
                    weenie.AddOrUpdateValue(PropertyInstanceId.Container, newParent.Id);
                    weenie.ParentContainer?.Containers.Insert(slot, childContainer);
                }
            }
            else {
                weenie.ParentContainer?.Items.Remove(weenie);
                if (newParent is not null) {
                    weenie.AddOrUpdateValue(PropertyInstanceId.Container, newParent.Id);
                    weenie.ParentContainer?.Items.Insert(slot, weenie);
                }
            }
        }

        private void RemoveWeenie(uint weenieId) {
            if (weenieId == CoreACPlugin.Instance.Game.Character.Id)
                return;

            if (_weenies.TryRemove(weenieId, out WorldObject weenieToRemove)) {
                // try update containers of parent
                if (weenieToRemove.ParentContainer is not null) {
                    _log.LogTrace($"Scripts_RemoveWeenie: {weenieToRemove} ({weenieToRemove.ParentContainer.ContainerType}) // from {weenieToRemove.ParentContainer}");

                    if (weenieToRemove is Container containerToRemove) {
                        weenieToRemove.ParentContainer.Containers.Remove(containerToRemove);
                    }
                    else {
                        weenieToRemove.ParentContainer.Items.Remove(weenieToRemove);
                    }
                }

                // remove container children
                if (weenieToRemove is Container container) {
                    foreach (var child in container.Items.ToArray()) {
                        RemoveWeenie(child.Id);
                    }
                }

                // remove equipment from wielder
                if (weenieToRemove is Equipment equipment) {
                    equipment.Wielder?.Equipment.Remove(equipment);
                }

                var eventArgs = new ObjectReleasedEventArgs(weenieToRemove);
                _OnWeenieReleased?.Invoke(this, eventArgs);
            }
        }

        public void Dispose() {

        }
    }
}