using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.ACProtocol.Messages.S2C.Events;
using Chorizite.ACProtocol.Types;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Net;
using Core.AC.API.WorldObjects;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.AC.API {
    /// <summary>
    /// Information about the world around your character
    /// </summary>
    public class World : IDisposable {
        private readonly ILogger _log;
        private readonly NetworkParser _net;

        /// <summary>
        /// The weenies that are currently in the world
        /// </summary>
        public Dictionary<uint, WorldObject> Weenies { get; set; } = [];

        /// <summary>
        /// The container that is currently open, if any
        /// </summary>
        public Container? OpenContainer { get; set; }

        /// <summary>
        /// The currently selected world object, if any
        /// </summary>
        [JsonIgnore]
        public WorldObject? Selected => CoreACPlugin.Instance.Game.World.Get(CoreACPlugin.Instance.ClientBackend.SelectedObjectId);

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

        /// <summary>
        /// Fired when the selected world object changes
        /// </summary>
        public event EventHandler<WorldObjectSelectedEventArgs> OnSelectionChanged {
            add => _OnSelectionChanged.Subscribe(value);
            remove => _OnSelectionChanged.Unsubscribe(value);
        }
        private WeakEvent<WorldObjectSelectedEventArgs> _OnSelectionChanged = new();


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

            _net.S2C.OnLogin_PlayerDescription += OnLogin_PlayerDescription;

            _net.S2C.OnItem_SetAppraiseInfo += OnItem_SetAppraiseInfo;
            _net.S2C.OnItem_SetState += OnItem_SetState;
            _net.S2C.OnItem_UpdateObject += OnItem_UpdateObject;
            _net.S2C.OnItem_UpdateStackSize += OnItem_UpdateStackSize;
            _net.S2C.OnItem_WearItem += OnItem_WearItem;
            _net.S2C.OnItem_QueryItemManaResponse += OnItem_QueryItemManaResponse;

            _net.S2C.OnQualities_RemoveBoolEvent += OnQualities_RemoveBoolEvent;
            _net.S2C.OnQualities_RemoveDataIdEvent += OnQualities_RemoveDataIDEvent_S2C;
            _net.S2C.OnQualities_RemoveFloatEvent += OnQualities_RemoveFloatEvent_S2C;
            _net.S2C.OnQualities_RemoveInstanceIdEvent += OnQualities_RemoveInstanceIDEvent_S2C;
            _net.S2C.OnQualities_RemoveInt64Event += OnQualities_RemoveInt64Event_S2C;
            _net.S2C.OnQualities_RemoveIntEvent += OnQualities_RemoveIntEvent_S2C;
            _net.S2C.OnQualities_RemovePositionEvent += OnQualities_RemovePositionEvent_S2C;
            _net.S2C.OnQualities_RemoveStringEvent += OnQualities_RemoveStringEvent_S2C;
            _net.S2C.OnQualities_UpdateAttribute2ndLevel += OnQualities_UpdateAttribute2ndLevel_S2C;
            _net.S2C.OnQualities_UpdateAttribute2nd += OnQualities_UpdateAttribute2nd_S2C;
            _net.S2C.OnQualities_UpdateAttributeLevel += OnQualities_UpdateAttributeLevel_S2C;
            _net.S2C.OnQualities_UpdateAttribute += OnQualities_UpdateAttribute_S2C;
            _net.S2C.OnQualities_UpdateBool += OnQualities_UpdateBool_S2C;
            _net.S2C.OnQualities_UpdateDataId += OnQualities_UpdateDataID_S2C;
            _net.S2C.OnQualities_UpdateFloat += OnQualities_UpdateFloat_S2C;
            _net.S2C.OnQualities_UpdateInstanceId += OnQualities_UpdateInstanceID_S2C;
            _net.S2C.OnQualities_UpdateInt64 += OnQualities_UpdateInt64_S2C;
            _net.S2C.OnQualities_UpdateInt += OnQualities_UpdateInt_S2C;
            _net.S2C.OnQualities_UpdatePosition += OnQualities_UpdatePosition_S2C;
            _net.S2C.OnQualities_UpdateSkillAC += OnQualities_UpdateSkillAC_S2C;
            _net.S2C.OnQualities_UpdateSkillLevel += OnQualities_UpdateSkillLevel_S2C;
            _net.S2C.OnQualities_UpdateSkill += OnQualities_UpdateSkill_S2C;
            _net.S2C.OnQualities_UpdateString += OnQualities_UpdateString_S2C;

            CoreACPlugin.Instance.ClientBackend.OnObjectSelected += OnObjectSelected;
        }

        #region public API
        /// <summary>
        /// Try to get a world object by id
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public WorldObject? this[uint objectId] {
            get => Get(objectId);
        }

        /// <summary>
        /// Try to get a world object by id
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public WorldObject? Get(uint objectId) {
            if (Weenies.TryGetValue(objectId, out WorldObject? weenie)) {
                return weenie;
            }

            return null;
        }

        /// <summary>
        /// Check if a world object exists
        /// </summary>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public bool Exists(uint objectId) => Weenies.ContainsKey(objectId);
        #endregion // public API

        #region Event Handlers
        private void OnObjectSelected(object? sender, ObjectSelectedEventArgs e) {
            var eventArgs = new WorldObjectSelectedEventArgs(Get(e.ObjectId));

            _OnSelectionChanged.Invoke(this, eventArgs);
            e.Eat = e.Eat || eventArgs.Eat;
        }

        private void OnItem_CreateObject(object? sender, Item_CreateObject e) {
            WorldObject? weenie = null;

            if (e.ObjectId == CoreACPlugin.Instance.Game.Character.Id) {
                weenie = CoreACPlugin.Instance.Game.Character;
                Weenies.TryAdd(e.ObjectId, weenie);
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
            if (weenie is null || weenie is not Item item) {
                _log.LogWarning($"Could not find Item weenie 0x{e.ObjectId:X8} ({weenie}) to OnItem_ServerSaysContainId");
                return;
            }

            var newParent = Get(e.ContainerId) as Container;
            if (newParent is null) {
                _log.LogWarning($"Could not find parent container 0x{e.ContainerId:X8} ({Get(e.ContainerId)}) to update Item_ServerSaysContainId");
                return;
            }

            MoveWeenie(item, newParent, (int)e.SlotIndex);
        }

        private void OnItem_ServerSaysMoveItem(object? sender, Item_ServerSaysMoveItem e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Item item) {
                _log.LogWarning($"Could not find Item weenie 0x{e.ObjectId:X8} ({weenie}) to OnItem_ServerSaysMoveItem");
                return;
            }
            MoveWeenie(item, null, 0);
        }

        private void OnItem_ServerSaysRemove(object? sender, Item_ServerSaysRemove e) {
            RemoveWeenie(e.ObjectId);
        }

        private void OnInventory_PickupEvent(object? sender, Inventory_PickupEvent e) {
            _log.LogError($"Inventory_PickupEvent: 0x{e.ObjectId:X8} ({Get(e.ObjectId)})");
        }

        private void OnLogin_PlayerDescription(object? sender, Login_PlayerDescription e) {
            foreach (var profile in e.ContentProfile) {
                if (profile.ContainerType == ContainerProperties.None) {
                    continue;
                }
                var container = CreateContainer(profile.ObjectId, profile.ContainerType);
                container.AddOrUpdateValue(PropertyInstanceId.Container, CoreACPlugin.Instance.Game.Character.Id);
                CoreACPlugin.Instance.Game.Character.Containers.Add(container);
            }
        }

        private void OnItem_SetAppraiseInfo(object? sender, Item_SetAppraiseInfo e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to Item_SetAppraiseInfo");
                return;
            }
            weenie.UpdateStatsTable(e.BoolProperties);
            weenie.UpdateStatsTable(e.FloatProperties);
            weenie.UpdateStatsTable(e.Int64Properties);
            weenie.UpdateStatsTable(e.IntProperties);
            weenie.UpdateStatsTable(e.StringProperties);
            weenie.UpdateStatsTable(e.DataIdProperties);
            if (weenie is Item item) {
                item.UpdateSpells(e.SpellBook);
            }
            weenie.LastAppraisalTime = DateTime.Now;
            weenie.HasAppraisalData = true;
        }

        private void OnItem_SetState(object? sender, Item_SetState e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to Item_SetState");
                return;
            }

            weenie.AddOrUpdateValue(PropertyInt.PhysicsState, (int)e.NewState);
        }

        private void OnItem_UpdateObject(object? sender, Item_UpdateObject e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to Item_UpdateObject");
                return;
            }
            weenie.UpdateWeenieDesc(e.WeenieDesc);
            weenie.UpdateObjDesc(e.ObjectDesc);
            weenie.UpdatePhysicsDesc(e.PhysicsDesc);
            weenie.LastAccessTime = DateTime.Now;
        }

        private void OnItem_UpdateStackSize(object? sender, Item_UpdateStackSize e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to Item_UpdateStackSize");
                return;
            }
            weenie.AddOrUpdateValue(PropertyInt.StackSize, (int)e.Amount);
            weenie.AddOrUpdateValue(PropertyInt.Value, (int)e.NewValue);
        }

        private void OnItem_WearItem(object? sender, Item_WearItem e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Item item) {
                _log.LogWarning($"Could not find Item weenie 0x{e.ObjectId:X8} ({weenie}) to Item_WearItem");
                return;
            }

            MoveWeenie(item, null, 0);
            CoreACPlugin.Instance.Game.Character.SetWielded(weenie, e.Slot);
        }

        private void OnItem_QueryItemManaResponse(object? sender, Item_QueryItemManaResponse e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to Item_QueryItemManaResponse");
                return;
            }
            weenie.LastAccessTime = DateTime.Now;
        }

        private void OnQualities_RemoveBoolEvent(object? sender, Qualities_RemoveBoolEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveBoolEvent");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveDataIDEvent_S2C(object? sender, Qualities_RemoveDataIdEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveDataIDEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveFloatEvent_S2C(object? sender, Qualities_RemoveFloatEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveFloatEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveInstanceIDEvent_S2C(object? sender, Qualities_RemoveInstanceIdEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveInstanceIDEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveInt64Event_S2C(object? sender, Qualities_RemoveInt64Event e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveInt64Event_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveIntEvent_S2C(object? sender, Qualities_RemoveIntEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveIntEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemovePositionEvent_S2C(object? sender, Qualities_RemovePositionEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemovePositionEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_RemoveStringEvent_S2C(object? sender, Qualities_RemoveStringEvent e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_RemoveStringEvent_S2C");
                return;
            }
            weenie.RemoveValue(e.Type);
        }

        private void OnQualities_UpdateAttribute2ndLevel_S2C(object? sender, Qualities_UpdateAttribute2ndLevel e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character characater) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateAttribute2ndLevel_S2C");
                return;
            }
            characater.UpdateVitalCurrent((VitalId)e.Key, e.Value);
        }

        private void OnQualities_UpdateAttribute2nd_S2C(object? sender, Qualities_UpdateAttribute2nd e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character characater) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateAttribute2nd_S2C");
                return;
            }
            characater.UpdateVital(e.Key, e.Value);
        }

        private void OnQualities_UpdateAttributeLevel_S2C(object? sender, Qualities_UpdateAttributeLevel e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character characater) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateAttributeLevel_S2C");
                return;
            }
            characater.UpdateAttributePointsRaised(e.Key, e.Value);
        }

        private void OnQualities_UpdateAttribute_S2C(object? sender, Qualities_UpdateAttribute e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character characater) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateAttribute_S2C");
                return;
            }
            characater.UpdateAttribute(e.Key, e.Value);
        }

        private void OnQualities_UpdateBool_S2C(object? sender, Qualities_UpdateBool e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateBool_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateDataID_S2C(object? sender, Qualities_UpdateDataId e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateDataID_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateFloat_S2C(object? sender, Qualities_UpdateFloat e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateFloat_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateInstanceID_S2C(object? sender, Qualities_UpdateInstanceId e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateInstanceID_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateInt64_S2C(object? sender, Qualities_UpdateInt64 e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateInt64_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateInt_S2C(object? sender, Qualities_UpdateInt e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateInt_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdatePosition_S2C(object? sender, Qualities_UpdatePosition e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdatePosition_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateString_S2C(object? sender, Qualities_UpdateString e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null) {
                _log.LogWarning($"Could not find weenie 0x{e.ObjectId:X8} to OnQualities_UpdateString_S2C");
                return;
            }
            weenie.AddOrUpdateValue(e.Key, e.Value);
        }

        private void OnQualities_UpdateSkillAC_S2C(object? sender, Qualities_UpdateSkillAC e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character character) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateSkillAC_S2C");
                return;
            }
            character.UpdateSkillTraining(e.Key, e.Value);
        }

        private void OnQualities_UpdateSkillLevel_S2C(object? sender, Qualities_UpdateSkillLevel e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character character) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateSkillLevel_S2C");
                return;
            }
            character.UpdateSkillPointsRaised(e.Key, e.Value);
        }

        private void OnQualities_UpdateSkill_S2C(object? sender, Qualities_UpdateSkill e) {
            var weenie = Get(e.ObjectId);
            if (weenie is null || weenie is not Character character) {
                _log.LogWarning($"Could not find character weenie 0x{e.ObjectId:X8} ({weenie}) to OnQualities_UpdateSkillLevel_S2C");
                return;
            }
            character.UpdateSkill(e.Key, e.Value);
        }
        #endregion // Event Handlers

        internal WorldObject GetOrCreateWorldObject(uint objectId, ObjDesc objectDescription, PhysicsDesc physicsDescription, PublicWeenieDesc weenieDescription) {
            if (Weenies.TryGetValue(objectId, out WorldObject? weenie)) {
                weenie.LastAccessTime = DateTime.Now;
            }

            if (weenie is null) {
                weenie = CreateWorldObject(objectId, weenieDescription);
            }

            return weenie;
        }

        internal Container CreateContainer(uint objectId, ContainerProperties containerProperties) {
            var container = new Container();
            container.Id = objectId;
            container.ContainerType = containerProperties;
            container.LastAccessTime = DateTime.Now;
            container.CreatedAt = DateTime.Now;
            Weenies.TryAdd(objectId, container);
            return container;
        }

        internal WorldObject CreateWorldObject(uint objectId, PublicWeenieDesc weenieDescription) {
            var objectClass = WorldObject.GetObjectClass(weenieDescription.Type, weenieDescription.Behavior, weenieDescription.Header);
            WorldObject? wobject = null;

            switch (objectClass) {
                case ObjectClass.Player:
                    wobject = new Player();
                    break;
                case ObjectClass.Door:
                    wobject = new Door();
                    break;
                case ObjectClass.Portal:
                    wobject = new Portal();
                    break;
                case ObjectClass.Gem:
                    wobject = new Gem();
                    break;
                case ObjectClass.Armor:
                    wobject = new Armor();
                    break;
                case ObjectClass.WandStaffOrb:
                    wobject = new Wand();
                    break;
                case ObjectClass.MissileWeapon:
                    wobject = new MissileWeapon();
                    break;
                case ObjectClass.MeleeWeapon:
                    wobject = new MeleeWeapon();
                    break;
                case ObjectClass.Clothing:
                    wobject = new Clothing();
                    break;
                case ObjectClass.Jewelry:
                    wobject = new Jewelry();
                    break;
                case ObjectClass.SpellComponent:
                    wobject = new SpellComponent();
                    break;
                case ObjectClass.Ust:
                    wobject = new Ust();
                    break;
                case ObjectClass.Npc:
                    wobject = new NPC();
                    break;
                case ObjectClass.Vendor:
                    wobject = new Vendor();
                    break;
                case ObjectClass.Monster:
                    wobject = new Monster();
                    break;
                case ObjectClass.Container:
                    wobject = new Container();
                    break;
                case ObjectClass.Food:
                    wobject = new Food();
                    break;
                case ObjectClass.Bindstone:
                    wobject = new Bindstone();
                    break;
                case ObjectClass.Static:
                    wobject = new Static();
                    break;
                case ObjectClass.Key:
                    wobject = new Key();
                    break;
                case ObjectClass.ManaStone:
                    wobject = new ManaStone();
                    break;
                case ObjectClass.Corpse:
                    wobject = new Corpse();
                    break;
                case ObjectClass.Scroll:
                    wobject = new Scroll();
                    break;
                case ObjectClass.TradeNote:
                    wobject = new TradeNote();
                    break;
                case ObjectClass.Foci:
                    wobject = new Foci();
                    break;
                default:
                    if (weenieDescription.Behavior.HasFlag(Chorizite.ACProtocol.Enums.ObjectDescriptionFlag.Stuck)) {
                        wobject = new Static();
                    }
                    else {
                        wobject = new Item();
                    }
                    break;
            }

            wobject.Id = objectId;
            wobject.LastAccessTime = DateTime.Now;
            wobject.CreatedAt = DateTime.Now;

            Weenies.TryAdd(objectId, wobject);

            return wobject;
        }

        private void MoveWeenie(Item weenie, Container? newParent, int slot) {
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

            if (Weenies.Remove(weenieId, out WorldObject? weenieToRemove)) {
                if (!(weenieToRemove is Item itemToRemove)) {
                    _log.LogWarning($"Could not find item weenie 0x{weenieId:X8} ({weenieToRemove}) to RemoveWeenie");
                    return;
                }
                // try update containers of parent
                if (itemToRemove.ParentContainer is not null) {
                    _log.LogTrace($"Scripts_RemoveWeenie: {itemToRemove} ({itemToRemove.ParentContainer.ContainerType}) // from {itemToRemove.ParentContainer}");

                    if (itemToRemove is Container containerToRemove) {
                        itemToRemove.ParentContainer.Containers.Remove(containerToRemove);
                    }
                    else {
                        itemToRemove.ParentContainer.Items.Remove(weenieToRemove);
                    }
                }

                // remove container children
                if (weenieToRemove is Container container) {
                    foreach (var child in container.Items.ToArray()) {
                        RemoveWeenie(child.Id);
                    }
                }

                // remove equipment from wielder
                if (weenieToRemove is Equippable equipment) {
                    equipment.Wielder?.Equipment.Remove(equipment);
                }

                var eventArgs = new ObjectReleasedEventArgs(weenieToRemove);
                _OnWeenieReleased?.Invoke(this, eventArgs);
            }
        }

        public void Dispose() {
            _net.S2C.OnItem_CreateObject -= OnItem_CreateObject;
            _net.S2C.OnItem_DeleteObject -= OnItem_DeleteObject;
            _net.S2C.OnItem_ObjDescEvent -= OnItem_ObjDescEvent;
            _net.S2C.OnItem_ParentEvent -= OnItem_ParentEvent;
            _net.S2C.OnItem_ServerSaysContainId -= OnItem_ServerSaysContainId;
            _net.S2C.OnItem_ServerSaysMoveItem -= OnItem_ServerSaysMoveItem;
            _net.S2C.OnItem_ServerSaysRemove -= OnItem_ServerSaysRemove;
            _net.S2C.OnInventory_PickupEvent -= OnInventory_PickupEvent;

            _net.S2C.OnItem_OnViewContents -= OnItem_OnViewContents;
            _net.S2C.OnItem_StopViewingObjectContents -= OnItem_StopViewingObjectContents;

            _net.S2C.OnLogin_PlayerDescription -= OnLogin_PlayerDescription;

            _net.S2C.OnItem_SetAppraiseInfo -= OnItem_SetAppraiseInfo;
            _net.S2C.OnItem_SetState -= OnItem_SetState;
            _net.S2C.OnItem_UpdateObject -= OnItem_UpdateObject;
            _net.S2C.OnItem_UpdateStackSize -= OnItem_UpdateStackSize;
            _net.S2C.OnItem_WearItem -= OnItem_WearItem;
            _net.S2C.OnItem_QueryItemManaResponse -= OnItem_QueryItemManaResponse;

            _net.S2C.OnQualities_RemoveBoolEvent -= OnQualities_RemoveBoolEvent;
            _net.S2C.OnQualities_RemoveDataIdEvent -= OnQualities_RemoveDataIDEvent_S2C;
            _net.S2C.OnQualities_RemoveFloatEvent -= OnQualities_RemoveFloatEvent_S2C;
            _net.S2C.OnQualities_RemoveInstanceIdEvent -= OnQualities_RemoveInstanceIDEvent_S2C;
            _net.S2C.OnQualities_RemoveInt64Event -= OnQualities_RemoveInt64Event_S2C;
            _net.S2C.OnQualities_RemoveIntEvent -= OnQualities_RemoveIntEvent_S2C;
            _net.S2C.OnQualities_RemovePositionEvent -= OnQualities_RemovePositionEvent_S2C;
            _net.S2C.OnQualities_RemoveStringEvent -= OnQualities_RemoveStringEvent_S2C;
            _net.S2C.OnQualities_UpdateAttribute2ndLevel -= OnQualities_UpdateAttribute2ndLevel_S2C;
            _net.S2C.OnQualities_UpdateAttribute2nd -= OnQualities_UpdateAttribute2nd_S2C;
            _net.S2C.OnQualities_UpdateAttributeLevel -= OnQualities_UpdateAttributeLevel_S2C;
            _net.S2C.OnQualities_UpdateAttribute -= OnQualities_UpdateAttribute_S2C;
            _net.S2C.OnQualities_UpdateBool -= OnQualities_UpdateBool_S2C;
            _net.S2C.OnQualities_UpdateDataId -= OnQualities_UpdateDataID_S2C;
            _net.S2C.OnQualities_UpdateFloat -= OnQualities_UpdateFloat_S2C;
            _net.S2C.OnQualities_UpdateInstanceId -= OnQualities_UpdateInstanceID_S2C;
            _net.S2C.OnQualities_UpdateInt64 -= OnQualities_UpdateInt64_S2C;
            _net.S2C.OnQualities_UpdateInt -= OnQualities_UpdateInt_S2C;
            _net.S2C.OnQualities_UpdatePosition -= OnQualities_UpdatePosition_S2C;
            _net.S2C.OnQualities_UpdateSkillAC -= OnQualities_UpdateSkillAC_S2C;
            _net.S2C.OnQualities_UpdateSkillLevel -= OnQualities_UpdateSkillLevel_S2C;
            _net.S2C.OnQualities_UpdateSkill -= OnQualities_UpdateSkill_S2C;
            _net.S2C.OnQualities_UpdateString -= OnQualities_UpdateString_S2C;

            CoreACPlugin.Instance.ClientBackend.OnObjectSelected -= OnObjectSelected;
        }
    }
}