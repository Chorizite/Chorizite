using MagicHat.Core.Input;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.InteropServices;

namespace MagicHat.Backends.ACBackend.Input {
    public class Win32InputManager : IInputManager {
        private readonly ILogger _log;

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        public bool MouseIsOverWindow { get; private set; }
        public int MouseX { get; private set; }
        public int MouseY { get; private set; }

        public event EventHandler<MouseMoveEventArgs>? OnMouseMove;
        public event EventHandler<MouseDownEventArgs>? OnMouseDown;
        public event EventHandler<MouseUpEventArgs>? OnMouseUp;
        public event EventHandler<MouseWheelEventArgs>? OnMouseWheel;
        public event EventHandler<EventArgs>? OnShutdown;

        public Win32InputManager(ILogger logger) {
            _log = logger;
        }

        public void HandleShutdown() {
            OnShutdown?.Invoke(this, EventArgs.Empty);
        }

        public bool HandleWindowMessage(int hwnd, WindowMessageType type, int wParam, int lParam) {
            EatableEvent? eatableEvent = null;
            switch (type) {
                case WindowMessageType.MOUSELEAVE:
                    MouseIsOverWindow = false;
                    break;
                case WindowMessageType.MOUSEHOVER:
                    MouseIsOverWindow = true;
                    break;
                case WindowMessageType.LBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Left);
                    OnMouseDown?.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.LBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Left);
                    OnMouseUp?.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Right);
                    OnMouseDown?.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Right);
                    OnMouseUp?.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Middle);
                    OnMouseDown?.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Middle);
                    OnMouseUp?.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.X);
                    OnMouseDown?.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.X);
                    OnMouseUp?.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEWHEEL:
                    eatableEvent = new MouseWheelEventArgs(HIWORD(wParam) / 120);
                    OnMouseWheel?.Invoke(this, (MouseWheelEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEMOVE:
                    MouseX = LOWORD(lParam);
                    MouseY = HIWORD(lParam);
                    eatableEvent = new MouseMoveEventArgs(MouseX, MouseY);
                    OnMouseMove?.Invoke(this, (MouseMoveEventArgs)eatableEvent);
                    break;
            }

            return MouseIsOverWindow && (eatableEvent is not null && eatableEvent.Eat);
        }

        private short LOWORD(int n) => (short)(n & 0xffff);
        private short HIWORD(int n) => (short)(n >> 16 & 0xffff);

        public void Dispose() {

        }
    }
}
