using Chorizite.Core.Input;
using Microsoft.Extensions.Logging;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Chorizite.Common;
using Chorizite.Core.Lib;

namespace Chorizite.NativeClientBootstrapper.Input {
    public class Win32InputManager : IInputManager {
        private readonly ILogger _log;
        private readonly Dictionary<Key, bool> _keyStates = new();

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        [DllImport("USER32.dll")]
        static extern short VkKeyScanA(byte charCode);

        /// <inheritdoc/>
        public bool MouseIsOverWindow { get; private set; } = true;

        /// <inheritdoc/>
        public int MouseX { get; private set; }

        /// <inheritdoc/>
        public int MouseY { get; private set; }

        /// <inheritdoc/>
        public event EventHandler<MouseMoveEventArgs>? OnMouseMove {
            add { _OnMouseMove.Subscribe(value); }
            remove { _OnMouseMove.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseMoveEventArgs> _OnMouseMove = new();

        /// <inheritdoc/>
        public event EventHandler<MouseDownEventArgs>? OnMouseDown {
            add { _OnMouseDown.Subscribe(value); }
            remove { _OnMouseDown.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseDownEventArgs> _OnMouseDown = new();

        /// <inheritdoc/>
        public event EventHandler<MouseWheelEventArgs>? OnMouseWheel {
            add { _OnMouseWheel.Subscribe(value); }
            remove { _OnMouseWheel.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseWheelEventArgs> _OnMouseWheel = new();

        /// <inheritdoc/>
        public event EventHandler<MouseUpEventArgs>? OnMouseUp {
            add { _OnMouseUp.Subscribe(value); }
            remove { _OnMouseUp.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseUpEventArgs> _OnMouseUp = new();

        /// <inheritdoc/>
        public event EventHandler<KeyPressEventArgs>? OnKeyPress {
            add { _OnKeyPress.Subscribe(value); }
            remove { _OnKeyPress.Unsubscribe(value); }
        }
        private readonly WeakEvent<KeyPressEventArgs> _OnKeyPress = new();

        /// <inheritdoc/>
        public event EventHandler<EventArgs>? OnShutdown {
            add { _OnShutdown.Subscribe(value); }
            remove { _OnShutdown.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnShutdown = new();

        /// <inheritdoc/>
        public event EventHandler<KeyDownEventArgs>? OnKeyDown {
            add { _OnKeyDown.Subscribe(value); }
            remove { _OnKeyDown.Unsubscribe(value); }
        }
        private readonly WeakEvent<KeyDownEventArgs> _OnKeyDown = new();

        /// <inheritdoc/>
        public event EventHandler<KeyUpEventArgs>? OnKeyUp {
            add { _OnKeyUp.Subscribe(value); }
            remove { _OnKeyUp.Unsubscribe(value); }
        }
        private readonly WeakEvent<KeyUpEventArgs> _OnKeyUp = new();

        public event EventHandler<WindowResizedEventArgs>? OnWindowResized;

        public Win32InputManager(ILogger logger) {
            _log = logger;
        }

        public void HandleShutdown() {
            _OnShutdown?.Invoke(this, EventArgs.Empty);
        }

        public bool IsKeyPressed(Key key) {
            var state = GetKeyState((VirtualKeyStates)key);
            switch (key) {
                case Key.NUMLOCK:
                case Key.SCROLL:
                case Key.CAPITAL:
                    return (state & 0xFF) > 0 || (state >> 4 & 0xFF) > 0;
                default:
                    return (state >> 4 & 0xFF) > 0;
            }
        }

        public bool HandleWindowMessage(int hwnd, WindowMessageType type, int wParam, int lParam) {
            EatableEventArgs? eatableEvent = null;

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
                    eatableEvent = new KeyUpEventArgs((Key)wParam);
                    _OnKeyUp.Invoke(this, (KeyUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.KEYDOWN:
                    eatableEvent = new KeyDownEventArgs((Key)wParam);
                    _OnKeyDown.Invoke(this, (KeyDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.CHAR:
                    var key = VkKeyScanA((byte)wParam) & 0xFF;
                    eatableEvent = new KeyPressEventArgs(((char)wParam).ToString());
                    _OnKeyPress.Invoke(this, (KeyPressEventArgs)eatableEvent);
                    break;
            }

            switch (type) {
                case WindowMessageType.LBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Left);
                    _OnMouseDown.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.LBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Left);
                    _OnMouseUp.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Right);
                    _OnMouseDown.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.RBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Right);
                    _OnMouseUp.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.Middle);
                    _OnMouseDown.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.Middle);
                    _OnMouseUp.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONDOWN:
                    eatableEvent = new MouseDownEventArgs(MouseButton.X);
                    _OnMouseDown.Invoke(this, (MouseDownEventArgs)eatableEvent);
                    break;
                case WindowMessageType.XBUTTONUP:
                    eatableEvent = new MouseUpEventArgs(MouseButton.X);
                    _OnMouseUp.Invoke(this, (MouseUpEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEWHEEL:
                    eatableEvent = new MouseWheelEventArgs(LOWORD(wParam) / 120, HIWORD(wParam) / 120);
                    _OnMouseWheel.Invoke(this, (MouseWheelEventArgs)eatableEvent);
                    break;
                case WindowMessageType.MOUSEMOVE:
                    MouseX = LOWORD(lParam);
                    MouseY = HIWORD(lParam);
                    eatableEvent = new MouseMoveEventArgs(MouseX, MouseY);
                    _OnMouseMove.Invoke(this, (MouseMoveEventArgs)eatableEvent);
                    eatableEvent.Eat = false;
                    break;
            }

            return eatableEvent?.Eat == true;
        }

        private short LOWORD(int n) => (short)(n & 0xffff);
        private short HIWORD(int n) => (short)(n >> 16 & 0xffff);

        public void Dispose() {

        }

        public bool IsMousePressed(MouseButton button) {
            throw new NotImplementedException();
        }
    }
}
