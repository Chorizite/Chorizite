using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Input {
    public interface IInputManager : IDisposable {
        bool MouseIsOverWindow { get; }
        int MouseX { get; }
        int MouseY { get; }

        event EventHandler<MouseMoveEventArgs>? OnMouseMove;
        event EventHandler<MouseDownEventArgs>? OnMouseDown;
        event EventHandler<MouseUpEventArgs>? OnMouseUp;
        event EventHandler<KeyPressEventArgs>? OnKeyPress;
        event EventHandler<EventArgs>? OnShutdown;
        event EventHandler<KeyDownEventArgs>? OnKeyDown;
        event EventHandler<KeyUpEventArgs>? OnKeyUp;

        void HandleShutdown();
        bool IsKeyPressed(Key key);
    }
}
