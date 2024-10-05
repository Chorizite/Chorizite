using MagicHat.Core.Extensions;
using MagicHat.Core.Input;
using Microsoft.Extensions.Logging;
using SharpDX;
using System;
using System.Runtime.InteropServices;

namespace MagicHat.Backends.ACBackend.Input {
    public class Win32InputManager : IInputManager {
        private readonly ILogger _log;
        private readonly Dictionary<Key, bool> _keyStates = new();

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        [DllImport("USER32.dll")]
        static extern short VkKeyScanA(byte charCode);

        public bool MouseIsOverWindow { get; private set; }
        public int MouseX { get; private set; }
        public int MouseY { get; private set; }

        public event EventHandler<MouseMoveEventArgs>? OnMouseMove;
        public event EventHandler<MouseDownEventArgs>? OnMouseDown;
        public event EventHandler<MouseUpEventArgs>? OnMouseUp;
        public event EventHandler<MouseWheelEventArgs>? OnMouseWheel;
        public event EventHandler<KeyUpEventArgs>? OnKeyUp;
        public event EventHandler<KeyDownEventArgs>? OnKeyDown;
        public event EventHandler<KeyPressEventArgs>? OnKeyPress;
        public event EventHandler<EventArgs>? OnShutdown;

        public Win32InputManager(ILogger logger) {
            _log = logger;
        }

        public void HandleShutdown() {
            OnShutdown?.Invoke(this, EventArgs.Empty);
        }

        public bool IsKeyPressed(Key key) {
            var state = GetKeyState((VirtualKeyStates)key);
            return (state & 0xFF) > 0 || ((state >> 4) & 0xFF) > 0;
        }

        public bool HandleWindowMessage(int hwnd, WindowMessageType type, int wParam, int lParam) {
            switch (type) {
                case WindowMessageType.MOUSEHOVER:
                    MouseIsOverWindow = true;
                    break;
                case WindowMessageType.MOUSELEAVE:
                    MouseIsOverWindow = false;
                    break;
                case WindowMessageType.MOUSEMOVE:
                    var mouseX = LOWORD(lParam);
                    var mouseY = HIWORD(lParam);
                    MouseIsOverWindow = mouseX > 0 && mouseY > 0;
                    break;
                case WindowMessageType.KEYUP:
                    OnKeyUp?.InvokeSafely(this, new KeyUpEventArgs((Key)wParam));
                    break;
                case WindowMessageType.KEYDOWN:
                    OnKeyDown?.InvokeSafely(this, new KeyDownEventArgs((Key)wParam));
                    break;
                case WindowMessageType.CHAR:
                    var key = VkKeyScanA((byte)wParam) & 0xFF;
                    OnKeyPress?.InvokeSafely(this, new KeyPressEventArgs((Key)key, ((char)wParam).ToString()));
                    break;
            }

            if (!MouseIsOverWindow) {
                return false;
            }

            EatableEvent? eatableEvent = null;
            switch (type) {
                case WindowMessageType.LBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Left);
                    OnMouseDown?.InvokeSafely(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.LBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Left);
                    OnMouseUp?.InvokeSafely(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Right);
                    OnMouseDown?.InvokeSafely(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Right);
                    OnMouseUp?.InvokeSafely(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Middle);
                    OnMouseDown?.InvokeSafely(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Middle);
                    OnMouseUp?.InvokeSafely(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.X);
                    OnMouseDown?.InvokeSafely(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.X);
                    OnMouseUp?.InvokeSafely(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEWHEEL:
                    eatableEvent = new MouseWheelEventArgs(HIWORD(wParam) / 120);
                    OnMouseWheel?.InvokeSafely(this, (MouseWheelEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEMOVE:
                    MouseX = LOWORD(lParam);
                    MouseY = HIWORD(lParam);
                    eatableEvent = new MouseMoveEventArgs(MouseX, MouseY);
                    OnMouseMove?.InvokeSafely(this, (MouseMoveEventArgs)eatableEvent);
                    eatableEvent.Eat = false;
                    break;
            }

            return eatableEvent?.Eat == true;
        }

        private short LOWORD(int n) => (short)(n & 0xffff);
        private short HIWORD(int n) => (short)(n >> 16 & 0xffff);

        public void Dispose() {

        }
    }
}
