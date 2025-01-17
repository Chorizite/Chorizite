using Chorizite.Common.Enums;
using System;
using System.Numerics;

namespace Chorizite.Core.Backend.Client {
    public interface IClientUIBackend {
        public event EventHandler<EventArgs> OnScreenChanged;
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragEnd;
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragStart;
        public event EventHandler<EventArgs> OnHideTooltip;
        public event EventHandler<ShowTooltipEventArgs> OnShowTooltip;
        public event EventHandler<ToggleElementVisibleEventArgs> OnShowRootElement;
        public event EventHandler<ToggleElementVisibleEventArgs> OnHideRootElement;
        public event EventHandler<UILockedEventArgs> OnUILockChanged;

        Vector4 GetUIElementPosition(uint uiElementId);
        void ClearDragandDrop();
        void ToggleRootElement(RootElementId rootElementId);
    }
}