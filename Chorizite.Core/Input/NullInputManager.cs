using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Input {
    /// <summary>
    /// Represents a null input manager. Doesn't do anything
    /// </summary>
    public class NullInputManager : IInputManager {
        /// <inheritdoc/>
        public bool MouseIsOverWindow => false;

        /// <inheritdoc/>
        public int MouseX => 0;

        /// <inheritdoc/>
        public int MouseY => 0;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        /// <inheritdoc/>
        public event EventHandler<MouseMoveEventArgs> OnMouseMove;
        /// <inheritdoc/>
        public event EventHandler<MouseDownEventArgs> OnMouseDown;
        /// <inheritdoc/>
        public event EventHandler<MouseUpEventArgs> OnMouseUp;
        /// <inheritdoc/>
        public event EventHandler<KeyPressEventArgs> OnKeyPress;
        /// <inheritdoc/>
        public event EventHandler<KeyDownEventArgs> OnKeyDown;
        /// <inheritdoc/>
        public event EventHandler<KeyUpEventArgs> OnKeyUp;
        /// <inheritdoc/>
        public event EventHandler<EventArgs> OnShutdown;
        /// <inheritdoc/>
        public event EventHandler<MouseWheelEventArgs> OnMouseWheel;
        /// <inheritdoc/>
        public event EventHandler<WindowResizedEventArgs>? OnWindowResized;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

        /// <inheritdoc/>
        public void HandleShutdown() {
            
        }

        /// <inheritdoc/>
        public bool IsKeyPressed(Key key) {
            return false;
        }

        /// <inheritdoc/>
        public bool IsMousePressed(MouseButton button) {
            return false;
        }

        /// <inheritdoc/>
        public void Dispose() {

        }
    }
}
