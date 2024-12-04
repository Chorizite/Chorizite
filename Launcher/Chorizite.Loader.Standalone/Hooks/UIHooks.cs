using AcClient;
using Autofac.Core;
using Chorizite.Core.Backend;
using Chorizite.Core.Plugins;
using DatReaderWriter.Enums;
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

namespace Chorizite.Loader.Standalone.Hooks {
    internal unsafe class UIHooks : HookBase {
        private static bool _showingTooltip;

        private static IHook<Del_UIElementManager_StartDragandDrop>? Hook_UIElementManager_StartDragandDrop;
        private static IHook<Del_UIElementManager_StartTooltip>? Hook_UIElementManager_StartTooltip;
        private static IHook<Del_UIElementManager_ResetTooltip>? Hook_UIElementManager_ResetTooltip;
        private static IHook<Del_UIElementManager_CheckTooltip>? Hook_UIElementManager_CheckTooltip;
        private static IHook<Del_UIElement_CatchDroppedItem>? Hook_UIElement_CatchDroppedItem;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElementManager_StartDragandDrop(UIElementManager* This, UIElement* element, int x, int y);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElementManager_StartTooltip(UIElementManager* This, StringInfo* strInfo, UIElement* el, int a, uint id, int c);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_UIElementManager_ResetTooltip(UIElementManager* This);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Del_UIElementManager_CheckTooltip(UIElementManager* This);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElement_CatchDroppedItem(UIElement* This, DragDropInfo* info);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate int Del_UIElement_SmartBoxWrapper_RecvNotice_SmartBoxObjectFound(UIElement* This, uint objectId);

        internal static void Init() {
            Hook_UIElementManager_StartTooltip = CreateHook<Del_UIElementManager_StartTooltip>(typeof(UIHooks), nameof(UIElementManager_StartTooltip_Impl), 0x0045DF70);
            Hook_UIElementManager_ResetTooltip = CreateHook<Del_UIElementManager_ResetTooltip>(typeof(UIHooks), nameof(UIElementManager_ResetTooltip_Impl), 0x0045C440);
            Hook_UIElementManager_CheckTooltip = CreateHook<Del_UIElementManager_CheckTooltip>(typeof(UIHooks), nameof(UIElementManager_CheckTooltip_Impl), 0x0045B7C0);
            Hook_UIElementManager_StartDragandDrop = CreateHook<Del_UIElementManager_StartDragandDrop>(typeof(UIHooks), nameof(UIElementManager_StartDragandDrop_Impl), 0x0045E120);
            Hook_UIElement_CatchDroppedItem = CreateHook<Del_UIElement_CatchDroppedItem>(typeof(UIHooks), nameof(UIElement_CatchDroppedItem_Impl), 0x00461860);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElementManager_StartDragandDrop_Impl(UIElementManager* This, UIElement* element, int x, int y) {
            uint itemId = 0;
            uint spellId = 0;
            DropItemFlags flags;

            UIElement_ItemList.InqDropIconInfo(element, &itemId, &spellId, &flags);
            GameObjectDragDropEventArgs? eventArgs = null;
            if (itemId != 0) {
                eventArgs = new GameObjectDragDropEventArgs("TODO:ItemName", itemId, (DragDropFlags)flags, false, false);
                StandaloneLoader.Backend.HandleGameObjectDragStart(eventArgs);
            }
            else if (spellId != 0) {
                eventArgs = new GameObjectDragDropEventArgs("TODO:SpellName", spellId, (DragDropFlags)flags, false, true);
                StandaloneLoader.Backend.HandleGameObjectDragStart(eventArgs);
            }

            if (eventArgs is not null && eventArgs.Eat) {
                return 0;
            }

            return Hook_UIElementManager_StartDragandDrop!.OriginalFunction(This, element, x, y);
        }

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
            var objectId = GetHoveredObjectId();
            var physicsObj = CPhysicsObj.GetObjectA(objectId);
            uint iconId = 0;
            if (physicsObj != null) {
                physicsObj->weenie_obj->InqIconID(&iconId);
            }
            var eventArgs = new ShowTooltipEventArgs(strInfo->m_LiteralValue.ToString(), objectId, iconId);
            StandaloneLoader.Backend.HandleShowTooltip(eventArgs);

            _showingTooltip = true;

            var res = Hook_UIElementManager_StartTooltip!.OriginalFunction(This, strInfo, el, a, b, c);

            if (eventArgs.Eat) {
                UIElementManager.s_pInstance->m_pTooltipElement->SetVisible(0);
            }
            return res;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_ResetTooltip_Impl(UIElementManager* This) {
            Hook_UIElementManager_ResetTooltip!.OriginalFunction(This);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static void UIElementManager_CheckTooltip_Impl(UIElementManager* This) {
            Hook_UIElementManager_CheckTooltip!.OriginalFunction(This);
            if (_showingTooltip && UIElementManager.s_pInstance->m_pTooltipElement == null) {
                _showingTooltip = false;
                StandaloneLoader.Backend.HandleHideTooltip(EventArgs.Empty);
            }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static int UIElement_CatchDroppedItem_Impl(UIElement* This, DragDropInfo* info) {
            uint itemId = 0;
            uint spellId = 0;
            DropItemFlags flags;

            UIElement_ItemList.InqDropIconInfo(info->element, &itemId, &spellId, &flags);
            GameObjectDragDropEventArgs? eventArgs = null;
            if (itemId != 0) {
                eventArgs = new GameObjectDragDropEventArgs("TODO:ItemName", itemId, (DragDropFlags)flags, false, false);
                StandaloneLoader.Backend.HandleGameObjectDragStart(eventArgs);
            }
            else if (spellId != 0) {
                eventArgs = new GameObjectDragDropEventArgs("TODO:SpellName", spellId, (DragDropFlags)flags, false, true);
                StandaloneLoader.Backend.HandleGameObjectDragStart(eventArgs);
            }

            if (eventArgs is not null && eventArgs.Eat) {
                return 0;
            }

            return Hook_UIElement_CatchDroppedItem!.OriginalFunction(This, info);
        }
    }
}
