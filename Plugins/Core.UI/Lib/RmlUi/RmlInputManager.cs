using Chorizite.Core.Input;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Core.UI.Lib.RmlUi {
    internal class RmlInputManager : IDisposable {
        private readonly Context _ctx;
        private readonly ILogger? _log;
        private readonly IInputManager _input;
        private Key _lastGameKeyDown;
        private Dictionary<Key, bool> _keyStates = [];

        public RmlInputManager(IInputManager inputManager, Context ctx, ILogger? log) {
            _ctx = ctx;
            _log = log;
            _input = inputManager;

            _input.OnMouseMove += InputManager_OnMouseMove;
            _input.OnMouseDown += InputManager_OnMouseDown;
            _input.OnMouseUp += InputManager_OnMouseUp;
            _input.OnMouseWheel += InputManager_OnMouseWheel;
            _input.OnKeyDown += InputManager_OnKeyDown;
            _input.OnKeyUp += InputManager_OnKeyUp;
            _input.OnKeyPress += InputManager_OnKeyPress;
        }

        private void InputManager_OnKeyPress(object? sender, KeyPressEventArgs e) {
            var textParts = e.Text.Select(t => t).Where(c => (c >= 32 || c == '\n') && c != 127);
            foreach (var character in textParts) {
                _ctx.ProcessTextInput(character.ToString());
            }
            e.Eat = CoreUIPlugin.Instance._rmlSystemInterface?.HasKeyboardFocus == true;
        }

        private void InputManager_OnKeyUp(object? sender, KeyUpEventArgs e) {
            var eat = !_ctx.ProcessKeyUp(ConvertKey((int)e.Key), GetKeyModifierState());
            e.Eat = eat || CoreUIPlugin.Instance._rmlSystemInterface?.HasKeyboardFocus == true;
        }

        private void InputManager_OnKeyDown(object? sender, KeyDownEventArgs e) {
            var eat = !_ctx.ProcessKeyDown(ConvertKey((int)e.Key), GetKeyModifierState());
            var tag = _ctx.GetFocusElement()?.TagName;
            e.Eat = eat || CoreUIPlugin.Instance._rmlSystemInterface?.HasKeyboardFocus == true;
        }

        private void InputManager_OnMouseUp(object? sender, MouseUpEventArgs e) {
            var eat = !_ctx.ProcessMouseButtonUp((int)e.Button, GetKeyModifierState());
            if (!IsGhostPanel()) {
                e.Eat = _ctx.IsMouseInteracting;
            }
        }

        private void InputManager_OnMouseDown(object? sender, MouseDownEventArgs e) {
            var eat = !_ctx.ProcessMouseButtonDown((int)e.Button, GetKeyModifierState());
            if (!IsGhostPanel()) {
                e.Eat = _ctx.IsMouseInteracting;
            }
            if (!e.Eat) {
                _ctx.GetFocusElement()?.Blur();
            }
        }

        private void InputManager_OnMouseMove(object? sender, MouseMoveEventArgs e) {
            var eat = !_ctx.ProcessMouseMove(e.X, e.Y, GetKeyModifierState());

            if (!IsGhostPanel()) {
                e.Eat = _ctx.IsMouseInteracting;
            }
        }

        private void InputManager_OnMouseWheel(object? sender, MouseWheelEventArgs e) {
            var eat = !_ctx.ProcessMouseWheel(new Vector2f(-e.DeltaX, -e.DeltaY), GetKeyModifierState());
            if (!IsGhostPanel()) {
                e.Eat = _ctx.IsMouseInteracting;
            }
        }

        private bool IsGhostPanel() {
            if (_ctx.IsMouseInteracting) {
                try {
                    var doc = CoreUIPlugin.RmlContext?.GetHoverElement()?.OwnerDocument;
                    if (doc is not null) {
                        var panel = CoreUIPlugin.Instance?.PanelManager.GetPanelByPtr(doc.NativePtr);
                        if (panel?.IsGhost == true) {
                            return true;
                        }
                    }
                }
                catch { }
            }
            return false;
        }

        private RmlUiNet.Input.KeyModifier GetKeyModifierState() {
            RmlUiNet.Input.KeyModifier key_modifier_state = 0;

            if (_input.IsKeyPressed(Key.CAPITAL))
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_CAPSLOCK;

            if (_input.IsKeyPressed(Key.NUMLOCK))
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_NUMLOCK;

            if (_input.IsKeyPressed(Key.SHIFT))
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_SHIFT;

            if (_input.IsKeyPressed(Key.CONTROL))
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_CTRL;

            if (_input.IsKeyPressed(Key.MENU))
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_ALT;

            return key_modifier_state;
        }

        private RmlUiNet.Input.KeyIdentifier ConvertKey(int win32_key_code) {
            switch (win32_key_code) {
                case 'A': return RmlUiNet.Input.KeyIdentifier.KI_A;
                case 'B': return RmlUiNet.Input.KeyIdentifier.KI_B;
                case 'C': return RmlUiNet.Input.KeyIdentifier.KI_C;
                case 'D': return RmlUiNet.Input.KeyIdentifier.KI_D;
                case 'E': return RmlUiNet.Input.KeyIdentifier.KI_E;
                case 'F': return RmlUiNet.Input.KeyIdentifier.KI_F;
                case 'G': return RmlUiNet.Input.KeyIdentifier.KI_G;
                case 'H': return RmlUiNet.Input.KeyIdentifier.KI_H;
                case 'I': return RmlUiNet.Input.KeyIdentifier.KI_I;
                case 'J': return RmlUiNet.Input.KeyIdentifier.KI_J;
                case 'K': return RmlUiNet.Input.KeyIdentifier.KI_K;
                case 'L': return RmlUiNet.Input.KeyIdentifier.KI_L;
                case 'M': return RmlUiNet.Input.KeyIdentifier.KI_M;
                case 'N': return RmlUiNet.Input.KeyIdentifier.KI_N;
                case 'O': return RmlUiNet.Input.KeyIdentifier.KI_O;
                case 'P': return RmlUiNet.Input.KeyIdentifier.KI_P;
                case 'Q': return RmlUiNet.Input.KeyIdentifier.KI_Q;
                case 'R': return RmlUiNet.Input.KeyIdentifier.KI_R;
                case 'S': return RmlUiNet.Input.KeyIdentifier.KI_S;
                case 'T': return RmlUiNet.Input.KeyIdentifier.KI_T;
                case 'U': return RmlUiNet.Input.KeyIdentifier.KI_U;
                case 'V': return RmlUiNet.Input.KeyIdentifier.KI_V;
                case 'W': return RmlUiNet.Input.KeyIdentifier.KI_W;
                case 'X': return RmlUiNet.Input.KeyIdentifier.KI_X;
                case 'Y': return RmlUiNet.Input.KeyIdentifier.KI_Y;
                case 'Z': return RmlUiNet.Input.KeyIdentifier.KI_Z;

                case '0': return RmlUiNet.Input.KeyIdentifier.KI_0;
                case '1': return RmlUiNet.Input.KeyIdentifier.KI_1;
                case '2': return RmlUiNet.Input.KeyIdentifier.KI_2;
                case '3': return RmlUiNet.Input.KeyIdentifier.KI_3;
                case '4': return RmlUiNet.Input.KeyIdentifier.KI_4;
                case '5': return RmlUiNet.Input.KeyIdentifier.KI_5;
                case '6': return RmlUiNet.Input.KeyIdentifier.KI_6;
                case '7': return RmlUiNet.Input.KeyIdentifier.KI_7;
                case '8': return RmlUiNet.Input.KeyIdentifier.KI_8;
                case '9': return RmlUiNet.Input.KeyIdentifier.KI_9;

                case (int)Key.BACK: return RmlUiNet.Input.KeyIdentifier.KI_BACK;
                case (int)Key.TAB: return RmlUiNet.Input.KeyIdentifier.KI_TAB;

                case (int)Key.CLEAR: return RmlUiNet.Input.KeyIdentifier.KI_CLEAR;
                case (int)Key.RETURN: return RmlUiNet.Input.KeyIdentifier.KI_RETURN;

                case (int)Key.PAUSE: return RmlUiNet.Input.KeyIdentifier.KI_PAUSE;
                case (int)Key.CAPITAL: return RmlUiNet.Input.KeyIdentifier.KI_CAPITAL;

                case (int)Key.KANA: return RmlUiNet.Input.KeyIdentifier.KI_KANA;
                //case (int)Key.HANGUL:              return RmlUiNet.Input.KeyIdentifier.KI_HANGUL; /* overlaps with Key.KANA */
                case (int)Key.JUNJA: return RmlUiNet.Input.KeyIdentifier.KI_JUNJA;
                case (int)Key.FINAL: return RmlUiNet.Input.KeyIdentifier.KI_FINAL;
                case (int)Key.HANJA: return RmlUiNet.Input.KeyIdentifier.KI_HANJA;
                //case (int)Key.KANJI:               return RmlUiNet.Input.KeyIdentifier.KI_KANJI; /* overlaps with Key.HANJA */

                case (int)Key.ESCAPE: return RmlUiNet.Input.KeyIdentifier.KI_ESCAPE;

                case (int)Key.CONVERT: return RmlUiNet.Input.KeyIdentifier.KI_CONVERT;
                case (int)Key.NONCONVERT: return RmlUiNet.Input.KeyIdentifier.KI_NONCONVERT;
                case (int)Key.ACCEPT: return RmlUiNet.Input.KeyIdentifier.KI_ACCEPT;
                case (int)Key.MODECHANGE: return RmlUiNet.Input.KeyIdentifier.KI_MODECHANGE;

                case (int)Key.SPACE: return RmlUiNet.Input.KeyIdentifier.KI_SPACE;
                case (int)Key.PRIOR: return RmlUiNet.Input.KeyIdentifier.KI_PRIOR;
                case (int)Key.NEXT: return RmlUiNet.Input.KeyIdentifier.KI_NEXT;
                case (int)Key.END: return RmlUiNet.Input.KeyIdentifier.KI_END;
                case (int)Key.HOME: return RmlUiNet.Input.KeyIdentifier.KI_HOME;
                case (int)Key.LEFT: return RmlUiNet.Input.KeyIdentifier.KI_LEFT;
                case (int)Key.UP: return RmlUiNet.Input.KeyIdentifier.KI_UP;
                case (int)Key.RIGHT: return RmlUiNet.Input.KeyIdentifier.KI_RIGHT;
                case (int)Key.DOWN: return RmlUiNet.Input.KeyIdentifier.KI_DOWN;
                case (int)Key.SELECT: return RmlUiNet.Input.KeyIdentifier.KI_SELECT;
                case (int)Key.PRINT: return RmlUiNet.Input.KeyIdentifier.KI_PRINT;
                case (int)Key.EXECUTE: return RmlUiNet.Input.KeyIdentifier.KI_EXECUTE;
                case (int)Key.SNAPSHOT: return RmlUiNet.Input.KeyIdentifier.KI_SNAPSHOT;
                case (int)Key.INSERT: return RmlUiNet.Input.KeyIdentifier.KI_INSERT;
                case (int)Key.DELETE: return RmlUiNet.Input.KeyIdentifier.KI_DELETE;
                case (int)Key.HELP: return RmlUiNet.Input.KeyIdentifier.KI_HELP;

                case (int)Key.LWIN: return RmlUiNet.Input.KeyIdentifier.KI_LWIN;
                case (int)Key.RWIN: return RmlUiNet.Input.KeyIdentifier.KI_RWIN;
                case (int)Key.APPS: return RmlUiNet.Input.KeyIdentifier.KI_APPS;

                case (int)Key.SLEEP: return RmlUiNet.Input.KeyIdentifier.KI_SLEEP;

                case (int)Key.NUMPAD0: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD0;
                case (int)Key.NUMPAD1: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD1;
                case (int)Key.NUMPAD2: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD2;
                case (int)Key.NUMPAD3: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD3;
                case (int)Key.NUMPAD4: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD4;
                case (int)Key.NUMPAD5: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD5;
                case (int)Key.NUMPAD6: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD6;
                case (int)Key.NUMPAD7: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD7;
                case (int)Key.NUMPAD8: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD8;
                case (int)Key.NUMPAD9: return RmlUiNet.Input.KeyIdentifier.KI_NUMPAD9;
                case (int)Key.MULTIPLY: return RmlUiNet.Input.KeyIdentifier.KI_MULTIPLY;
                case (int)Key.ADD: return RmlUiNet.Input.KeyIdentifier.KI_ADD;
                case (int)Key.SEPARATOR: return RmlUiNet.Input.KeyIdentifier.KI_SEPARATOR;
                case (int)Key.SUBTRACT: return RmlUiNet.Input.KeyIdentifier.KI_SUBTRACT;
                case (int)Key.DECIMAL: return RmlUiNet.Input.KeyIdentifier.KI_DECIMAL;
                case (int)Key.DIVIDE: return RmlUiNet.Input.KeyIdentifier.KI_DIVIDE;
                case (int)Key.F1: return RmlUiNet.Input.KeyIdentifier.KI_F1;
                case (int)Key.F2: return RmlUiNet.Input.KeyIdentifier.KI_F2;
                case (int)Key.F3: return RmlUiNet.Input.KeyIdentifier.KI_F3;
                case (int)Key.F4: return RmlUiNet.Input.KeyIdentifier.KI_F4;
                case (int)Key.F5: return RmlUiNet.Input.KeyIdentifier.KI_F5;
                case (int)Key.F6: return RmlUiNet.Input.KeyIdentifier.KI_F6;
                case (int)Key.F7: return RmlUiNet.Input.KeyIdentifier.KI_F7;
                case (int)Key.F8: return RmlUiNet.Input.KeyIdentifier.KI_F8;
                case (int)Key.F9: return RmlUiNet.Input.KeyIdentifier.KI_F9;
                case (int)Key.F10: return RmlUiNet.Input.KeyIdentifier.KI_F10;
                case (int)Key.F11: return RmlUiNet.Input.KeyIdentifier.KI_F11;
                case (int)Key.F12: return RmlUiNet.Input.KeyIdentifier.KI_F12;
                case (int)Key.F13: return RmlUiNet.Input.KeyIdentifier.KI_F13;
                case (int)Key.F14: return RmlUiNet.Input.KeyIdentifier.KI_F14;
                case (int)Key.F15: return RmlUiNet.Input.KeyIdentifier.KI_F15;
                case (int)Key.F16: return RmlUiNet.Input.KeyIdentifier.KI_F16;
                case (int)Key.F17: return RmlUiNet.Input.KeyIdentifier.KI_F17;
                case (int)Key.F18: return RmlUiNet.Input.KeyIdentifier.KI_F18;
                case (int)Key.F19: return RmlUiNet.Input.KeyIdentifier.KI_F19;
                case (int)Key.F20: return RmlUiNet.Input.KeyIdentifier.KI_F20;
                case (int)Key.F21: return RmlUiNet.Input.KeyIdentifier.KI_F21;
                case (int)Key.F22: return RmlUiNet.Input.KeyIdentifier.KI_F22;
                case (int)Key.F23: return RmlUiNet.Input.KeyIdentifier.KI_F23;
                case (int)Key.F24: return RmlUiNet.Input.KeyIdentifier.KI_F24;

                case (int)Key.NUMLOCK: return RmlUiNet.Input.KeyIdentifier.KI_NUMLOCK;
                case (int)Key.SCROLL: return RmlUiNet.Input.KeyIdentifier.KI_SCROLL;

                case (int)Key.SHIFT: return RmlUiNet.Input.KeyIdentifier.KI_LSHIFT;
                case (int)Key.CONTROL: return RmlUiNet.Input.KeyIdentifier.KI_LCONTROL;
                case (int)Key.MENU: return RmlUiNet.Input.KeyIdentifier.KI_LMENU;

                case (int)Key.BROWSER_BACK: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_BACK;
                case (int)Key.BROWSER_FORWARD: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_FORWARD;
                case (int)Key.BROWSER_REFRESH: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_REFRESH;
                case (int)Key.BROWSER_STOP: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_STOP;
                case (int)Key.BROWSER_SEARCH: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_SEARCH;
                case (int)Key.BROWSER_FAVORITES: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_FAVORITES;
                case (int)Key.BROWSER_HOME: return RmlUiNet.Input.KeyIdentifier.KI_BROWSER_HOME;

                case (int)Key.VOLUME_MUTE: return RmlUiNet.Input.KeyIdentifier.KI_VOLUME_MUTE;
                case (int)Key.VOLUME_DOWN: return RmlUiNet.Input.KeyIdentifier.KI_VOLUME_DOWN;
                case (int)Key.VOLUME_UP: return RmlUiNet.Input.KeyIdentifier.KI_VOLUME_UP;
                case (int)Key.MEDIA_NEXT_TRACK: return RmlUiNet.Input.KeyIdentifier.KI_MEDIA_NEXT_TRACK;
                case (int)Key.MEDIA_PREV_TRACK: return RmlUiNet.Input.KeyIdentifier.KI_MEDIA_PREV_TRACK;
                case (int)Key.MEDIA_STOP: return RmlUiNet.Input.KeyIdentifier.KI_MEDIA_STOP;
                case (int)Key.MEDIA_PLAY_PAUSE: return RmlUiNet.Input.KeyIdentifier.KI_MEDIA_PLAY_PAUSE;
                case (int)Key.LAUNCH_MAIL: return RmlUiNet.Input.KeyIdentifier.KI_LAUNCH_MAIL;
                case (int)Key.LAUNCH_MEDIA_SELECT: return RmlUiNet.Input.KeyIdentifier.KI_LAUNCH_MEDIA_SELECT;
                case (int)Key.LAUNCH_APP1: return RmlUiNet.Input.KeyIdentifier.KI_LAUNCH_APP1;
                case (int)Key.LAUNCH_APP2: return RmlUiNet.Input.KeyIdentifier.KI_LAUNCH_APP2;

                case (int)Key.OEM_1: return RmlUiNet.Input.KeyIdentifier.KI_OEM_1;
                case (int)Key.OEM_PLUS: return RmlUiNet.Input.KeyIdentifier.KI_OEM_PLUS;
                case (int)Key.OEM_COMMA: return RmlUiNet.Input.KeyIdentifier.KI_OEM_COMMA;
                case (int)Key.OEM_MINUS: return RmlUiNet.Input.KeyIdentifier.KI_OEM_MINUS;
                case (int)Key.OEM_PERIOD: return RmlUiNet.Input.KeyIdentifier.KI_OEM_PERIOD;
                case (int)Key.OEM_2: return RmlUiNet.Input.KeyIdentifier.KI_OEM_2;
                case (int)Key.OEM_3: return RmlUiNet.Input.KeyIdentifier.KI_OEM_3;

                case (int)Key.OEM_4: return RmlUiNet.Input.KeyIdentifier.KI_OEM_4;
                case (int)Key.OEM_5: return RmlUiNet.Input.KeyIdentifier.KI_OEM_5;
                case (int)Key.OEM_6: return RmlUiNet.Input.KeyIdentifier.KI_OEM_6;
                case (int)Key.OEM_7: return RmlUiNet.Input.KeyIdentifier.KI_OEM_7;
                case (int)Key.OEM_8: return RmlUiNet.Input.KeyIdentifier.KI_OEM_8;

                case (int)Key.PROCESSKEY: return RmlUiNet.Input.KeyIdentifier.KI_PROCESSKEY;

                case (int)Key.ATTN: return RmlUiNet.Input.KeyIdentifier.KI_ATTN;
                case (int)Key.CRSEL: return RmlUiNet.Input.KeyIdentifier.KI_CRSEL;
                case (int)Key.EXSEL: return RmlUiNet.Input.KeyIdentifier.KI_EXSEL;
                case (int)Key.EREOF: return RmlUiNet.Input.KeyIdentifier.KI_EREOF;
                case (int)Key.PLAY: return RmlUiNet.Input.KeyIdentifier.KI_PLAY;
                case (int)Key.ZOOM: return RmlUiNet.Input.KeyIdentifier.KI_ZOOM;
                case (int)Key.PA1: return RmlUiNet.Input.KeyIdentifier.KI_PA1;
                case (int)Key.OEM_CLEAR: return RmlUiNet.Input.KeyIdentifier.KI_OEM_CLEAR;
            }

            return RmlUiNet.Input.KeyIdentifier.KI_UNKNOWN;
        }

        public void Dispose() {
            _input.OnMouseMove -= InputManager_OnMouseMove;
            _input.OnMouseDown -= InputManager_OnMouseDown;
            _input.OnMouseUp -= InputManager_OnMouseUp;
            _input.OnMouseWheel -= InputManager_OnMouseWheel;
            _input.OnKeyDown -= InputManager_OnKeyDown;
            _input.OnKeyUp -= InputManager_OnKeyUp;
            _input.OnKeyPress -= InputManager_OnKeyPress;
        }
    }
}