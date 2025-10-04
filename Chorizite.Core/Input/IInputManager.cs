using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Interface for the input manager
    /// </summary>
    public interface IInputManager : IDisposable {
        /// <summary>
        /// Whether the mouse is over the window
        /// </summary>
        bool MouseIsOverWindow { get; }

        /// <summary>
        /// The current mouse X position relative to the window.
        /// </summary>
        int MouseX { get; }

        /// <summary>
        /// The current mouse Y position relative to the window
        /// </summary>
        int MouseY { get; }

        /// <summary>
        /// Fired when the mouse moves
        /// </summary>
        public event EventHandler<MouseMoveEventArgs> OnMouseMove;

        /// <summary>
        /// Fired when a mouse button is pressed
        /// </summary>
        public event EventHandler<MouseDownEventArgs> OnMouseDown;

        /// <summary>
        /// Fired when a mouse button is released
        /// </summary>
        public event EventHandler<MouseUpEventArgs> OnMouseUp;

        /// <summary>
        /// Fired when a key is pressed
        /// </summary>
        public event EventHandler<KeyPressEventArgs> OnKeyPress;

        /// <summary>
        /// Fired when a key is released
        /// </summary>
        public event EventHandler<KeyDownEventArgs> OnKeyDown;

        /// <summary>
        /// Fired when a key is released
        /// </summary>
        public event EventHandler<KeyUpEventArgs> OnKeyUp;

        /// <summary>
        /// Fired when the window is closed
        /// </summary>
        public event EventHandler<EventArgs> OnShutdown;

        /// <summary>
        /// Fired when the mouse wheel is scrolled
        /// </summary>
        public event EventHandler<MouseWheelEventArgs> OnMouseWheel;

        /// <summary>
        /// Fired when the window is resized
        /// </summary>
        public event EventHandler<WindowResizedEventArgs>? OnWindowResized;

        /// <summary>
        /// Handles the client shutdown
        /// </summary>
        void HandleShutdown();

        /// <summary>
        /// Checks if a key is pressed
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsKeyPressed(Key key);

        /// <summary>
        /// Checks if a mouse button is pressed
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        bool IsMousePressed(MouseButton button);
    }
}
