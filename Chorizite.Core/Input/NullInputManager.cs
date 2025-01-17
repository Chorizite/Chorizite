using Chorizite.Core.Lua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Input {
    [HideScripting]
    public class NullInputManager : IInputManager {
        public bool MouseIsOverWindow => false;

        public int MouseX => 0;

        public int MouseY => 0;

        public event EventHandler<MouseMoveEventArgs> OnMouseMove;
        public event EventHandler<MouseDownEventArgs> OnMouseDown;
        public event EventHandler<MouseUpEventArgs> OnMouseUp;
        public event EventHandler<KeyPressEventArgs> OnKeyPress;
        public event EventHandler<KeyDownEventArgs> OnKeyDown;
        public event EventHandler<KeyUpEventArgs> OnKeyUp;
        public event EventHandler<EventArgs> OnShutdown;
        public event EventHandler<MouseWheelEventArgs>? OnMouseWheel;

        public void HandleShutdown() {
            
        }

        public bool IsKeyPressed(Key key) {
            return false;
        }

        public void Dispose() {

        }
    }
}
