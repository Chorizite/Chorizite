using AcClient;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend;
using Chorizite.Loader.Standalone.Hooks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Chorizite.Loader.Standalone {
    internal unsafe class ACClientUIBackend : IClientUIBackend {
        public bool IsUILocked {
            get {
                if (CPlayerSystem.s_pPlayerSystem is null || CPlayerSystem.s_pPlayerSystem[0] is null) return false;
                return CPlayerSystem.s_pPlayerSystem[0]->playerModule.PlayerModule.LockUI() != 0;
            }
        }

        internal readonly WeakEvent<EventArgs> _OnScreenChanged = new WeakEvent<EventArgs>();
        public event EventHandler<EventArgs> OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }

        private readonly WeakEvent<GameObjectDragDropEventArgs> _OnGameObjectDragStart = new WeakEvent<GameObjectDragDropEventArgs>();
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragStart {
            add { _OnGameObjectDragStart.Subscribe(value); }
            remove { _OnGameObjectDragStart.Unsubscribe(value); }
        }

        private readonly WeakEvent<GameObjectDragDropEventArgs> _OnGameObjectDragEnd = new WeakEvent<GameObjectDragDropEventArgs>();
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragEnd {
            add { _OnGameObjectDragEnd.Subscribe(value); }
            remove { _OnGameObjectDragEnd.Unsubscribe(value); }
        }

        private readonly WeakEvent<ShowTooltipEventArgs> _OnShowTooltip = new WeakEvent<ShowTooltipEventArgs>();
        public event EventHandler<ShowTooltipEventArgs> OnShowTooltip {
            add { _OnShowTooltip.Subscribe(value); }
            remove { _OnShowTooltip.Unsubscribe(value); }
        }

        private readonly WeakEvent<EventArgs> _OnHideTooltip = new();
        public event EventHandler<EventArgs> OnHideTooltip {
            add { _OnHideTooltip.Subscribe(value); }
            remove { _OnHideTooltip.Unsubscribe(value); }
        }

        private readonly WeakEvent<ToggleElementVisibleEventArgs> _OnShowRootElement = new();
        public event EventHandler<ToggleElementVisibleEventArgs> OnShowRootElement {
            add { _OnShowRootElement.Subscribe(value); }
            remove { _OnShowRootElement.Unsubscribe(value); }
        }

        private readonly WeakEvent<ToggleElementVisibleEventArgs> _OnHideRootElement = new();
        public event EventHandler<ToggleElementVisibleEventArgs> OnHideRootElement {
            add { _OnHideRootElement.Subscribe(value); }
            remove { _OnHideRootElement.Unsubscribe(value); }
        }

        private readonly WeakEvent<UILockedEventArgs> _OnUILockChanged = new();
        public event EventHandler<UILockedEventArgs> OnUILockChanged {
            add { _OnUILockChanged.Subscribe(value); }
            remove { _OnUILockChanged.Unsubscribe(value); }
        }

        public void ClearDragandDrop() {
            if (UIElementManager.s_pInstance is not null) {
                UIElementManager.s_pInstance->StopDragandDrop();
            }
        }

        public void ToggleRootElement(RootElementId rootElementId) {
            if (UIElementManager.s_pInstance is not null) {
                switch (rootElementId) {
                    case RootElementId.LogOut:
                        UIElementManager.s_pInstance->DoVisibilityToggleAction((uint)ClientAction.LOGOUT);
                        break;
                    //case RootElementId.MiniGame:
                    //    UIElementManager.s_pInstance->DoVisibilityToggleAction((uint)ClientAction.ToggleMiniGamePanel);
                    //    break;
                    default:
                        var el = UIElementManager.s_pInstance->GetElement((UIElementId)rootElementId);
                        if (el is not null) {
                            el->SetVisible((byte)(el->IsVisible() == 1 ? 0 : 1));
                        }
                        break;
                }
            }
        }

        public System.Numerics.Vector4 GetUIElementPosition(uint uiElementId) {
            var el = UIElementManager.s_pInstance->GetElement((UIElementId)uiElementId);
            if (el is null) return new System.Numerics.Vector4();

            int zlevel = 0;
            var position = new Box2D();

            el->GetCurrentPosition(&position, &zlevel);

            return new System.Numerics.Vector4(position.m_x0, position.m_y0, position.m_x1, position.m_y1);
        }

        internal void HandleGameObjectDragStart(GameObjectDragDropEventArgs eventArgs) {
            try {
                _OnGameObjectDragStart?.Invoke(this, eventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnGameObjectDragStart event handler");
            }
        }

        internal void HandleGameObjectDragEnd(GameObjectDragDropEventArgs eventArgs) {
            try {
                _OnGameObjectDragEnd?.Invoke(this, eventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnGameObjectDragEnd event handler");
            }
        }

        internal void HandleShowTooltip(ShowTooltipEventArgs showTooltipEventArgs) {
            try {
                _OnShowTooltip?.Invoke(this, showTooltipEventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnShowTooltip event handler");
            }
        }

        internal void HandleHideTooltip(EventArgs empty) {
            try {
                _OnHideTooltip?.Invoke(this, empty);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnHideTooltip event handler");
            }
        }

        internal void HandleHideRootElement(ToggleElementVisibleEventArgs args) {
            try {
                _OnHideRootElement?.Invoke(this, args);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnHideRootElement event handler");
            }
        }

        internal void HandleShowRootElement(ToggleElementVisibleEventArgs args) {
            try {
                _OnShowRootElement?.Invoke(this, args);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnShowRootElement event handler");
            }
        }

        internal void HandleLockUI(UILockedEventArgs args) {
            try {
                _OnUILockChanged?.Invoke(this, args);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnUILockChanged event handler");
            }
        }
    }
}