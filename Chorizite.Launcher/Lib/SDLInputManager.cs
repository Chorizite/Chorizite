﻿using Chorizite.Core.Input;
using Microsoft.Extensions.Logging;
using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Chorizite.Common;
using static SDL2.SDL;

namespace LauncherApp.Lib {
    /// <summary>
    /// A SDL2 implementation of <see cref="IInputManager"/>
    /// </summary>
    public class SDLInputManager : IInputManager {
        private readonly ILogger<SDLInputManager> _log;
        private readonly Dictionary<Key, bool> _pressedKeys = [];

        public SDLInputManager(ILogger<SDLInputManager> log) {
            _log = log;
        }

        /// <inheritdoc/>
        public int MouseX { get; private set; }

        /// <inheritdoc/>
        public int MouseY { get; private set; }

        /// <inheritdoc/>
        public bool MouseIsOverWindow => throw new NotImplementedException();

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
        public event EventHandler<MouseUpEventArgs>? OnMouseUp {
            add { _OnMouseUp.Subscribe(value); }
            remove { _OnMouseUp.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseUpEventArgs> _OnMouseUp = new();

        /// <inheritdoc/>
        public event EventHandler<MouseWheelEventArgs>? OnMouseWheel {
            add { _OnMouseWheel.Subscribe(value); }
            remove { _OnMouseWheel.Unsubscribe(value); }
        }
        private readonly WeakEvent<MouseWheelEventArgs> _OnMouseWheel = new();

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

        public bool IsKeyPressed(Key key) {
            return _pressedKeys.TryGetValue(key, out bool value) && value;
        }

        public void HandleShutdown() {
            _OnShutdown?.Invoke(this, EventArgs.Empty);
        }

        public unsafe void Update() {
            SDL_GetMouseState(out int mouseX, out int mouseY);

            if (MouseX != mouseX || MouseY != mouseY) {
                MouseX = mouseX;
                MouseY = mouseY;
                _OnMouseMove?.Invoke(this, new MouseMoveEventArgs(MouseX, MouseY));
            }

            SDL_Event e;

            while (SDL_PollEvent(out e) != 0) {
                IntPtr pObj = Marshal.AllocHGlobal(Marshal.SizeOf<SDL_Event>());
                try {
                    Marshal.StructureToPtr(e, pObj, true);
                }
                finally {
                    if (pObj != IntPtr.Zero) {
                        Marshal.FreeHGlobal(pObj);
                    }
                }

                switch (e.type) {
                    case SDL_EventType.SDL_WINDOWEVENT:
                        switch (e.window.windowEvent) {
                            case SDL_WindowEventID.SDL_WINDOWEVENT_RESIZED:
                                //DatsAllFolksApp.Renderer.Resize(e.window.data1, e.window.data2);
                                break;
                        }
                        break;
                    case SDL_EventType.SDL_DROPFILE:
                        if (e.drop.file != IntPtr.Zero) {
                            //string s = Marshal.PtrToStringUTF8(e.drop.file);
                            //_appContext.Settings.DatDirectory = Directory.Exists(s) ? s : Path.GetDirectoryName(s);
                            //_appContext.App.TryLoadDats();
                        }
                        break;
                    case SDL_EventType.SDL_MOUSEBUTTONDOWN:
                        _OnMouseDown?.Invoke(this, new MouseDownEventArgs(ConvertSDLMouseButton(e.button.button)));
                        break;
                    case SDL_EventType.SDL_MOUSEBUTTONUP:
                        _OnMouseUp?.Invoke(this, new MouseUpEventArgs(ConvertSDLMouseButton(e.button.button)));
                        break;
                    case SDL_EventType.SDL_MOUSEWHEEL:
                        _OnMouseWheel?.Invoke(this, new MouseWheelEventArgs(e.wheel.x, e.wheel.y));
                        break;
                    case SDL_EventType.SDL_KEYDOWN:
                        if (!_pressedKeys.TryAdd(ConvertSDLToKey(e.key.keysym.sym), true)) {
                            _pressedKeys[ConvertSDLToKey(e.key.keysym.sym)] = true;
                        }
                        _OnKeyDown?.Invoke(this, new KeyDownEventArgs(ConvertSDLToKey(e.key.keysym.sym)));
                        break;
                    case SDL_EventType.SDL_KEYUP:
                        if (!_pressedKeys.TryAdd(ConvertSDLToKey(e.key.keysym.sym), false)) {
                            _pressedKeys[ConvertSDLToKey(e.key.keysym.sym)] = false;
                        }
                        _OnKeyUp?.Invoke(this, new KeyUpEventArgs(ConvertSDLToKey(e.key.keysym.sym)));
                        break;
                    case SDL_EventType.SDL_TEXTINPUT:
                        var str = Marshal.PtrToStringAnsi((IntPtr)e.text.text);
                        if (!string.IsNullOrEmpty(str)) {
                            _OnKeyPress?.Invoke(this, new Chorizite.Core.Input.KeyPressEventArgs(str));
                        }
                        break;
                    case SDL_EventType.SDL_QUIT:
                        Program.Exit();
                        break;
                }
            }
        }
        public MouseButton ConvertSDLMouseButton(byte sdlButton) {
            switch (sdlButton) {
                case 1:
                    return MouseButton.Left;
                case 2:
                    return MouseButton.Middle;
                case 3:
                    return MouseButton.Right;
                default:
                    return MouseButton.X;
            }
        }

        private Key ConvertSDLToKey(SDL_Keycode sdlKey) {
            switch (sdlKey) {
                case SDL_Keycode.SDLK_RETURN: return Key.RETURN;
                case SDL_Keycode.SDLK_ESCAPE: return Key.ESCAPE;
                case SDL_Keycode.SDLK_BACKSPACE: return Key.BACK;
                case SDL_Keycode.SDLK_TAB: return Key.TAB;
                case SDL_Keycode.SDLK_SPACE: return Key.SPACE;
                case SDL_Keycode.SDLK_0: return Key.KEY_0;
                case SDL_Keycode.SDLK_1: return Key.KEY_1;
                case SDL_Keycode.SDLK_2: return Key.KEY_2;
                case SDL_Keycode.SDLK_3: return Key.KEY_3;
                case SDL_Keycode.SDLK_4: return Key.KEY_4;
                case SDL_Keycode.SDLK_5: return Key.KEY_5;
                case SDL_Keycode.SDLK_6: return Key.KEY_6;
                case SDL_Keycode.SDLK_7: return Key.KEY_7;
                case SDL_Keycode.SDLK_8: return Key.KEY_8;
                case SDL_Keycode.SDLK_9: return Key.KEY_9;
                case SDL_Keycode.SDLK_a: return Key.KEY_A;
                case SDL_Keycode.SDLK_b: return Key.KEY_B;
                case SDL_Keycode.SDLK_c: return Key.KEY_C;
                case SDL_Keycode.SDLK_d: return Key.KEY_D;
                case SDL_Keycode.SDLK_e: return Key.KEY_E;
                case SDL_Keycode.SDLK_f: return Key.KEY_F;
                case SDL_Keycode.SDLK_g: return Key.KEY_G;
                case SDL_Keycode.SDLK_h: return Key.KEY_H;
                case SDL_Keycode.SDLK_i: return Key.KEY_I;
                case SDL_Keycode.SDLK_j: return Key.KEY_J;
                case SDL_Keycode.SDLK_k: return Key.KEY_K;
                case SDL_Keycode.SDLK_l: return Key.KEY_L;
                case SDL_Keycode.SDLK_m: return Key.KEY_M;
                case SDL_Keycode.SDLK_n: return Key.KEY_N;
                case SDL_Keycode.SDLK_o: return Key.KEY_O;
                case SDL_Keycode.SDLK_p: return Key.KEY_P;
                case SDL_Keycode.SDLK_q: return Key.KEY_Q;
                case SDL_Keycode.SDLK_r: return Key.KEY_R;
                case SDL_Keycode.SDLK_s: return Key.KEY_S;
                case SDL_Keycode.SDLK_t: return Key.KEY_T;
                case SDL_Keycode.SDLK_u: return Key.KEY_U;
                case SDL_Keycode.SDLK_v: return Key.KEY_V;
                case SDL_Keycode.SDLK_w: return Key.KEY_W;
                case SDL_Keycode.SDLK_x: return Key.KEY_X;
                case SDL_Keycode.SDLK_y: return Key.KEY_Y;
                case SDL_Keycode.SDLK_z: return Key.KEY_Z;
                case SDL_Keycode.SDLK_F1: return Key.F1;
                case SDL_Keycode.SDLK_F2: return Key.F2;
                case SDL_Keycode.SDLK_F3: return Key.F3;
                case SDL_Keycode.SDLK_F4: return Key.F4;
                case SDL_Keycode.SDLK_F5: return Key.F5;
                case SDL_Keycode.SDLK_F6: return Key.F6;
                case SDL_Keycode.SDLK_F7: return Key.F7;
                case SDL_Keycode.SDLK_F8: return Key.F8;
                case SDL_Keycode.SDLK_F9: return Key.F9;
                case SDL_Keycode.SDLK_F10: return Key.F10;
                case SDL_Keycode.SDLK_F11: return Key.F11;
                case SDL_Keycode.SDLK_F12: return Key.F12;
                case SDL_Keycode.SDLK_INSERT: return Key.INSERT;
                case SDL_Keycode.SDLK_DELETE: return Key.DELETE;
                case SDL_Keycode.SDLK_HOME: return Key.HOME;
                case SDL_Keycode.SDLK_END: return Key.END;
                case SDL_Keycode.SDLK_PAGEUP: return Key.PRIOR;
                case SDL_Keycode.SDLK_PAGEDOWN: return Key.NEXT;
                case SDL_Keycode.SDLK_RIGHT: return Key.RIGHT;
                case SDL_Keycode.SDLK_LEFT: return Key.LEFT;
                case SDL_Keycode.SDLK_DOWN: return Key.DOWN;
                case SDL_Keycode.SDLK_UP: return Key.UP;
                case SDL_Keycode.SDLK_CAPSLOCK: return Key.CAPITAL;
                case SDL_Keycode.SDLK_SCROLLLOCK: return Key.SCROLL;
                case SDL_Keycode.SDLK_PAUSE: return Key.PAUSE;
                case SDL_Keycode.SDLK_NUMLOCKCLEAR: return Key.NUMLOCK;
                case SDL_Keycode.SDLK_KP_0: return Key.NUMPAD0;
                case SDL_Keycode.SDLK_KP_1: return Key.NUMPAD1;
                case SDL_Keycode.SDLK_KP_2: return Key.NUMPAD2;
                case SDL_Keycode.SDLK_KP_3: return Key.NUMPAD3;
                case SDL_Keycode.SDLK_KP_4: return Key.NUMPAD4;
                case SDL_Keycode.SDLK_KP_5: return Key.NUMPAD5;
                case SDL_Keycode.SDLK_KP_6: return Key.NUMPAD6;
                case SDL_Keycode.SDLK_KP_7: return Key.NUMPAD7;
                case SDL_Keycode.SDLK_KP_8: return Key.NUMPAD8;
                case SDL_Keycode.SDLK_KP_9: return Key.NUMPAD9;
                case SDL_Keycode.SDLK_KP_PLUS: return Key.ADD;
                case SDL_Keycode.SDLK_KP_MINUS: return Key.SUBTRACT;
                case SDL_Keycode.SDLK_KP_DIVIDE: return Key.DIVIDE;
                case SDL_Keycode.SDLK_KP_MULTIPLY: return Key.MULTIPLY;
                case SDL_Keycode.SDLK_LCTRL: return Key.CONTROL;
                case SDL_Keycode.SDLK_RCTRL: return Key.CONTROL;
                case SDL_Keycode.SDLK_LSHIFT: return Key.SHIFT;
                case SDL_Keycode.SDLK_RSHIFT: return Key.SHIFT;
                case SDL_Keycode.SDLK_LALT: return Key.MENU;
                case SDL_Keycode.SDLK_RALT: return Key.MENU;
                case SDL_Keycode.SDLK_LGUI: return Key.LWIN;
                case SDL_Keycode.SDLK_RGUI: return Key.RWIN;
                default: return (Key)0; // Handle default case if no match is found
            }
        }


        public void Dispose() {

        }
    }
}
