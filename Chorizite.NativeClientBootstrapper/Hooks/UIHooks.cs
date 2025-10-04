using AcClient;
using Autofac.Core;
using Chorizite.ACProtocol.Types;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Plugins;
using DatReaderWriter.Enums;
using DatReaderWriter.Types;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using StringInfo = AcClient.StringInfo;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    internal unsafe class UIHooks : HookBase {
        private static bool _showingTooltip;

        private static IHook<Del_UIElementManager_StartDragandDrop>? Hook_UIElementManager_StartDragandDrop;
        private static IHook<Del_UIElementManager_StartTooltip>? Hook_UIElementManager_StartTooltip;
        private static IHook<Del_UIElementManager_ResetTooltip>? Hook_UIElementManager_ResetTooltip;
        private static IHook<Del_UIElementManager_CheckTooltip>? Hook_UIElementManager_CheckTooltip;
        private static IHook<Del_UIElementManager_SetCursor>? Hook_UIElementManager_SetCursor;
        private static IHook<Del_UIElement_CatchDroppedItem>? Hook_UIElement_CatchDroppedItem;
        private static IHook<Del_ACCWeenieObject_SetSelectedObject>? Hook_ACCWeenieObject_SetSelectedObject;
        private static IHook<Del_UIElement_SetVisible>? Hook_UIElement_SetVisible;
        private static IHook<Del_gmFloatyIndicatorsUI_UpdateLockedStatus>? Hook_gmFloatyIndicatorsUI_UpdateLockedStatus;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElementManager_StartDragandDrop(UIElementManager* This, UIElement* element, int x, int y);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElementManager_StartTooltip(UIElementManager* This, StringInfo* strInfo, UIElement* el, int a, uint id, int c);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_UIElementManager_ResetTooltip(UIElementManager* This);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_UIElementManager_CheckTooltip(UIElementManager* This);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_UIElementManager_SetCursor(UIElementManager* This, uint cursorDid, int hotX, int hotY, byte makeDefault);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElement_CatchDroppedItem(UIElement* This, DragDropInfo* info);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElement_SetVisible(UIElement* This, byte hidden);

        [Function(CallingConventions.Stdcall)]
        private delegate int Del_ACCWeenieObject_SetSelectedObject(uint objectId, int reselect);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_gmFloatyIndicatorsUI_UpdateLockedStatus(IntPtr thisPtr);

        internal static void Init() {
            Hook_UIElementManager_StartTooltip = CreateHook<Del_UIElementManager_StartTooltip>(typeof(UIHooks), nameof(UIElementManager_StartTooltip_Impl), 0x0045DF70);
            Hook_UIElementManager_ResetTooltip = CreateHook<Del_UIElementManager_ResetTooltip>(typeof(UIHooks), nameof(UIElementManager_ResetTooltip_Impl), 0x0045C440);
            Hook_UIElementManager_CheckTooltip = CreateHook<Del_UIElementManager_CheckTooltip>(typeof(UIHooks), nameof(UIElementManager_CheckTooltip_Impl), 0x0045B7C0);
            Hook_UIElementManager_StartDragandDrop = CreateHook<Del_UIElementManager_StartDragandDrop>(typeof(UIHooks), nameof(UIElementManager_StartDragandDrop_Impl), 0x0045E120);
            Hook_UIElementManager_SetCursor = CreateHook<Del_UIElementManager_SetCursor>(typeof(UIHooks), nameof(UIElementManager_SetCursor_Impl), 0x0045A910);
            Hook_UIElement_CatchDroppedItem = CreateHook<Del_UIElement_CatchDroppedItem>(typeof(UIHooks), nameof(UIElement_CatchDroppedItem_Impl), 0x00461860);
            Hook_UIElement_SetVisible = CreateHook<Del_UIElement_SetVisible>(typeof(UIHooks), nameof(UIElement_SetVisible_Impl), 0x00462390);
            //Hook_ACCWeenieObject_SetSelectedObject = CreateHook<Del_ACCWeenieObject_SetSelectedObject>(typeof(UIHooks), nameof(ACCWeenieObject_SetSelectedObject_Impl), 0x0058D110);
            Hook_gmFloatyIndicatorsUI_UpdateLockedStatus = CreateHook<Del_gmFloatyIndicatorsUI_UpdateLockedStatus>(typeof(UIHooks), nameof(gmFloatyIndicatorsUI_UpdateLockedStatus_Impl), 0x004D3C20);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_SetCursor_Impl(UIElementManager* This, uint cursorDid, int hotX, int hotY, byte makeDefault) {
            try {
                if (CursorDid != 0) {
                    Hook_UIElementManager_SetCursor!.OriginalFunction(This, cursorDid, hotX, hotY, makeDefault);
                }
                else if (cursorDid == 0 && _lastCursorDid != 0) {
                    Hook_UIElementManager_SetCursor!.OriginalFunction(This, _lastCursorDid, _lastHotX, _lastHotY, _lastMakeDefault);
                }
                else {
                    _lastCursorDid = cursorDid;
                    _lastHotX = hotX;
                    _lastHotY = hotY;
                    _lastMakeDefault = makeDefault;
                    Hook_UIElementManager_SetCursor!.OriginalFunction(This, cursorDid, hotX, hotY, makeDefault);
                }
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to set cursor"); }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElementManager_StartDragandDrop_Impl(UIElementManager* This, UIElement* element, int x, int y) {
            try {
                uint itemId = 0;
                uint spellId = 0;
                DropItemFlags flags;

                UIElement_ItemList.InqDropIconInfo(element, &itemId, &spellId, &flags);
                var eventArgs = BuildDragDropEventArgs(false, element, itemId, spellId, flags);

                if (eventArgs is not null) {
                    StandaloneLoader.Backend?.ACUIBackend?.HandleGameObjectDragStart(eventArgs);

                    if (eventArgs.Eat) {
                        return 0;
                    }
                }

                return Hook_UIElementManager_StartDragandDrop!.OriginalFunction(This, element, x, y);
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to set start drag drop"); }
            return 0;
        }

        private static GameObjectDragDropEventArgs BuildDragDropEventArgs(bool isDropping, UIElement* element, uint itemId, uint spellId, DropItemFlags flags) {
            GameObjectDragDropEventArgs? eventArgs = null;
            var iconData = new Core.Backend.Client.IconData();
            if (itemId != 0) {
                var itemName = $"Object[0x{itemId:X8}]";
                try {
                    var physicsObj = CPhysicsObj.GetObjectA(itemId);
                    if (physicsObj != null && physicsObj->weenie_obj != null) {
                        var namePtr = physicsObj->weenie_obj->GetObjectName(NameType.NAME_SINGULAR, 0);
                        var name = Marshal.PtrToStringAnsi((IntPtr)namePtr);
                        if (!string.IsNullOrEmpty(name)) {
                            itemName = name;
                        }
                        var wIconData = physicsObj->weenie_obj->GetIconData();
                        // TODO: read default underlay based on item type from did 0x25000008
                        uint defaultUnderlay = GetDefaultUnderlayFromItemType(wIconData->m_itemType);
                        iconData = new Core.Backend.Client.IconData() {
                            Icon = wIconData->m_idIcon,
                            Underlay = wIconData->m_idCustomUnderlay > 0 ? wIconData->m_idCustomUnderlay : defaultUnderlay,
                            Overlay = wIconData->m_idCustomOverlay,
                            Effects = (UiEffects)wIconData->m_effects
                        };
                    }
                }
                catch (Exception ex) {
                    StandaloneLoader.Log.LogWarning(ex, "Failed to get item name");
                }
                eventArgs = new GameObjectDragDropEventArgs(itemName, itemId, (DragDropFlags)flags, isDropping, false, iconData);
            }
            else if (spellId != 0) {
                var spellName = $"Spell[0x{spellId:X8}]";
                try {
                    if (StandaloneLoader.Backend?.DatReader.Portal.SpellTable?.Spells.TryGetValue(spellId, out var spell) == true) {
                        spellName = spell.Name;
                        var spellFlags = ((SpellFlags)spell.Bitfield);
                        var isSelfSpell = (spellFlags.HasFlag(SpellFlags.SelfTargeted) && spell.MetaSpellType.HasFlag(DatReaderWriter.Enums.SpellType.Enchantment)) || spell.MetaSpellType.HasFlag(DatReaderWriter.Enums.SpellType.PortalSending) || spell.MetaSpellType.HasFlag(DatReaderWriter.Enums.SpellType.PortalRecall);
                        var isFellowSpell = spellFlags.HasFlag(SpellFlags.FellowshipSpell);

                        iconData = new Core.Backend.Client.IconData() {
                            Icon = spell.Icon,
                            Underlay = 0x060013F4u + GetSpellLevel(spell.Components.FirstOrDefault()) - 1,
                            Overlay = isSelfSpell ? 0x060013F3u : (isFellowSpell ? 0x060030D7u : 0),
                            Effects = spellFlags.HasFlag(SpellFlags.Reversed) ? UiEffects.Reversed : UiEffects.None
                        };
                    }
                }
                catch (Exception ex) {
                    StandaloneLoader.Log.LogWarning(ex, "Failed to get spell name");
                }
                eventArgs = new GameObjectDragDropEventArgs(spellName, spellId, (DragDropFlags)flags, isDropping, true, iconData);
            }

            return eventArgs ?? new GameObjectDragDropEventArgs(string.Empty, 0, (DragDropFlags)flags, isDropping, false, new Core.Backend.Client.IconData());
        }

        private static uint GetDefaultUnderlayFromItemType(ITEM_TYPE m_itemType) {
            switch (m_itemType) {
                case ITEM_TYPE.TYPE_MELEE_WEAPON:
                    return 0x060011CBu;
                case ITEM_TYPE.TYPE_ARMOR:
                    return 0x060011CFu;
                case ITEM_TYPE.TYPE_CLOTHING:
                    return 0x060011F3u;
                case ITEM_TYPE.TYPE_JEWELRY:
                    return 0x060011D5u;
                case ITEM_TYPE.TYPE_CREATURE:
                    return 0x060011D1u;
                case ITEM_TYPE.TYPE_FOOD:
                    return 0x060011CCu;
                case ITEM_TYPE.TYPE_MONEY:
                    return 0x060011F4u;
                case ITEM_TYPE.TYPE_MISSILE_WEAPON:
                    return 0x060011D2u;
                case ITEM_TYPE.TYPE_CONTAINER:
                    return 0x060011CEu;
                case ITEM_TYPE.TYPE_USELESS:
                    return 0x060011D0u;
                case ITEM_TYPE.TYPE_GEM:
                    return 0x060011D3u;
                case ITEM_TYPE.TYPE_SPELL_COMPONENTS:
                    return 0x060011CDu;
                case ITEM_TYPE.TYPE_SERVICE:
                    return 0x06005E23u;
                default:
                    return 0x060011D4u;

            }
        }

        private static uint GetSpellLevel(uint firstComponentId) {
            var componentTable = StandaloneLoader.Backend?.DatReader.Portal.SpellComponentTable;
            if (componentTable is null) return 1;

            if (!componentTable.Components.TryGetValue(firstComponentId, out var firstComp) || firstComp.Category == 0) {
                return 1;
            }

            return ScarabLevel[(Scarab)firstComponentId];
        }

        private enum Scarab {
            Lead = 1,
            Iron = 2,
            Copper = 3,
            Silver = 4,
            Gold = 5,
            Pyreal = 6,
            Diamond = 110,
            Platinum = 112,
            Dark = 192,
            Mana = 193
        }

        /// <summary>
        /// A mapping of scarabs => their spell levels
        /// If the first component in a spell is a scarab,
        /// the client uses this to determine the spell level,
        /// for things like the spellbook filters.
        /// </summary>
        private static Dictionary<Scarab, uint> ScarabLevel = new Dictionary<Scarab, uint>()
        {
            { Scarab.Lead,     1 },
            { Scarab.Iron,     2 },
            { Scarab.Copper,   3 },
            { Scarab.Silver,   4 },
            { Scarab.Gold,     5 },
            { Scarab.Pyreal,   6 },
            { Scarab.Diamond,  6 },
            { Scarab.Platinum, 7 },
            { Scarab.Dark,     7 },
            { Scarab.Mana,     8 }
        };
        private static uint _lastCursorDid;
        private static int _lastHotX;
        private static int _lastHotY;
        private static byte _lastMakeDefault;

        public static uint CursorDid { get; internal set; }

        internal static uint GetHoveredObjectId() {
            try {
                var ui = UIElementManager.s_pInstance;
                if (ui == null) return 0;
                var root = *ui->m_pRootElement;

                var first = *(UIElement*)GetFirstChildElement(ref root);
                var smart = (UIElement*)GetFirstChildElement(ref first);
                var w = ((UIElement_SmartBoxWrapper*)smart);
                return w->m_iidSelectedObject;
            }
            catch {
                return 0;
            }
        }

        internal static int GetFirstChildElement(ref UIElement This) => ((delegate* unmanaged[Thiscall]<ref UIElement, int>)0x00464110)(ref This);
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElementManager_StartTooltip_Impl(UIElementManager* This, StringInfo* strInfo, UIElement* el, int a, uint b, int c) {
            try {
                var objectId = GetHoveredObjectId();
                var physicsObj = CPhysicsObj.GetObjectA(objectId);
                uint iconId = 0;
                if (physicsObj != null) {
                    physicsObj->weenie_obj->InqIconID(&iconId);
                }
                var eventArgs = new ShowTooltipEventArgs(strInfo->m_LiteralValue.ToString(), objectId, iconId);
                StandaloneLoader.Backend?.ACUIBackend?.HandleShowTooltip(eventArgs);

                _showingTooltip = true;

                var res = Hook_UIElementManager_StartTooltip!.OriginalFunction(This, strInfo, el, a, b, c);

                if (eventArgs.Eat) {
                    UIElementManager.s_pInstance->m_pTooltipElement->SetVisible(0);
                }
                return res;
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to start tooltip"); }
            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_ResetTooltip_Impl(UIElementManager* This) {
            try {
                Hook_UIElementManager_ResetTooltip!.OriginalFunction(This);
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to reset tooltip"); }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_CheckTooltip_Impl(UIElementManager* This) {
            try {
                Hook_UIElementManager_CheckTooltip!.OriginalFunction(This);
                if (_showingTooltip && UIElementManager.s_pInstance->m_pTooltipElement == null) {
                    _showingTooltip = false;
                    StandaloneLoader.Backend?.ACUIBackend.HandleHideTooltip(EventArgs.Empty);
                }
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to check tooltip"); }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElement_CatchDroppedItem_Impl(UIElement* This, DragDropInfo* info) {
            try {
                uint itemId = 0;
                uint spellId = 0;
                DropItemFlags flags;

                UIElement_ItemList.InqDropIconInfo(info->element, &itemId, &spellId, &flags);
                var eventArgs = BuildDragDropEventArgs(false, info->element, itemId, spellId, flags);

                if (eventArgs is not null) {
                    StandaloneLoader.Backend?.ACUIBackend?.HandleGameObjectDragEnd(eventArgs);

                    if (eventArgs.Eat) {
                        return 0;
                    }
                }

                return Hook_UIElement_CatchDroppedItem!.OriginalFunction(This, info);
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to catch dropped item"); }
            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static int ACCWeenieObject_SetSelectedObject_Impl(uint objectId, int reselect) {
            try {
                var eventArgs = new ObjectSelectedEventArgs(objectId);
                StandaloneLoader.Backend?.HandleObjectSelected(eventArgs);

                if (!eventArgs.Eat) {
                    return Hook_ACCWeenieObject_SetSelectedObject!.OriginalFunction(objectId, reselect);
                }
            }

            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to set selected item"); }

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElement_SetVisible_Impl(UIElement* thisPtr, byte shown) {
            var elId = (RootElementId)thisPtr->m_desc.m_elementID;
            switch (elId) {
                case RootElementId.Indicators:
                    ToggleElementVisibleEventArgs args;
                    if (shown == 1) {
                        args = new ToggleElementVisibleEventArgs(elId, true);
                        StandaloneLoader.Backend?.ACUIBackend?.HandleShowRootElement(args);
                        if (args.Eat) {
                            Hook_UIElement_SetVisible!.OriginalFunction(thisPtr, 0);
                            return 0;
                        }
                    }
                    else {
                        args = new ToggleElementVisibleEventArgs(elId, false);
                        StandaloneLoader.Backend?.ACUIBackend?.HandleHideTooltip(args);
                    }
                    if (args.Eat) {
                        return 0;
                    }
                    break;
            }
            return Hook_UIElement_SetVisible!.OriginalFunction(thisPtr, shown);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void gmFloatyIndicatorsUI_UpdateLockedStatus_Impl(IntPtr thisPtr) {
            StandaloneLoader.Backend?.ACUIBackend?.HandleLockUI(new UILockedEventArgs(StandaloneLoader.Backend.ACUIBackend.IsUILocked));
            Hook_gmFloatyIndicatorsUI_UpdateLockedStatus!.OriginalFunction(thisPtr);
        }
    }
}
