using Chorizite.Common.Enums;
using System;
using System.Numerics;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Interface for the Client UI backend
    /// </summary>
    public interface IClientUIBackend {
        /// <summary>
        /// Called when the screen size has changed
        /// </summary>
        public event EventHandler<EventArgs> OnScreenChanged;

        /// <summary>
        /// Called when a game object is done being dragged
        /// </summary>
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragEnd;

        /// <summary>
        /// Called when a game object is starting to be dragged
        /// </summary>
        public event EventHandler<GameObjectDragDropEventArgs> OnGameObjectDragStart;

        /// <summary>
        /// Called when the tooltip is hidden
        /// </summary>
        public event EventHandler<EventArgs> OnHideTooltip;

        /// <summary>
        /// Called when the tooltip is shown
        /// </summary>
        public event EventHandler<ShowTooltipEventArgs> OnShowTooltip;

        /// <summary>
        /// Called when the root element is shown
        /// </summary>
        public event EventHandler<ToggleElementVisibleEventArgs> OnShowRootElement;

        /// <summary>
        /// Called when the root element is hidden
        /// </summary>
        public event EventHandler<ToggleElementVisibleEventArgs> OnHideRootElement;

        /// <summary>
        /// Called when the UI is locked / unlocked
        /// </summary>
        public event EventHandler<UILockedEventArgs> OnUILockChanged;

        /// <summary>
        /// Get the position / size of a client UI element
        /// </summary>
        /// <param name="uiElementId"></param>
        /// <returns></returns>
        Vector4 GetUIElementPosition(uint uiElementId);

        /// <summary>
        /// Clear the drag and drop
        /// </summary>
        void ClearDragandDrop();

        /// <summary>
        /// Toggle the visibility of a root element
        /// </summary>
        /// <param name="rootElementId"></param>
        void ToggleRootElement(RootElementId rootElementId);
    }
}