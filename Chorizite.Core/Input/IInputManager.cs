using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Input {
    public interface IInputManager : IDisposable {
        bool MouseIsOverWindow { get; }
        int MouseX { get; }
        int MouseY { get; }

        public event EventHandler<MouseMoveEventArgs> OnMouseMove;
        public event EventHandler<MouseDownEventArgs> OnMouseDown;
        public event EventHandler<MouseUpEventArgs> OnMouseUp;
        public event EventHandler<KeyPressEventArgs> OnKeyPress;
        public event EventHandler<KeyDownEventArgs> OnKeyDown;
        public event EventHandler<KeyUpEventArgs> OnKeyUp;
        public event EventHandler<EventArgs> OnShutdown;
        event EventHandler<MouseWheelEventArgs>? OnMouseWheel;

        void HandleShutdown();
        bool IsKeyPressed(Key key);
    }
}
