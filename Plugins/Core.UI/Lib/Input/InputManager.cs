using MagicHat.Service.Lib.Events;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Runtime.InteropServices;

namespace ACUI.Lib.Input {
    internal class InputManager {
        private Context _ctx;
        private ILogger? _log;

        public InputManager(Context ctx, ILogger? log) {
            _ctx = ctx;
            _log = log;
        }

        [DllImport("USER32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);

        internal bool HandleWindowMessage(WindowMessageEventArgs e) {
            var res = false;
            switch (e.Msg) {
                case WindowMessageType.LBUTTONDOWN:
                    res = !_ctx.ProcessMouseButtonDown(0, GetKeyModifierState());
                    _log?.LogTrace($"LeftMouseDown({res})");
                    break;
                case WindowMessageType.LBUTTONUP:
                    res = !_ctx.ProcessMouseButtonUp(0, GetKeyModifierState());
                    _log?.LogTrace($"LeftMouseUp({res})");
                    break;
                case WindowMessageType.MOUSEMOVE:
                    res = !_ctx.ProcessMouseMove(LOWORD(e.LParam), HIWORD(e.LParam), GetKeyModifierState());
                    //_log?.LogTrace($"MouseMove({res}): {LOWORD(e.LParam)}, {HIWORD(e.LParam)}");
                    break;
            }

            return false;// res;
        }

        private RmlUiNet.Input.KeyModifier GetKeyModifierState() {
            RmlUiNet.Input.KeyModifier key_modifier_state = 0;

            if ((GetKeyState(VirtualKeyStates.VK_CAPITAL) & 1) != 0)
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_CAPSLOCK;

            if ((GetKeyState(VirtualKeyStates.VK_NUMLOCK) & 1) != 0)
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_NUMLOCK;

            if ((GetKeyState(VirtualKeyStates.VK_SHIFT) & 1) != 0)
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_SHIFT;

            if ((GetKeyState(VirtualKeyStates.VK_CONTROL) & 1) != 0)
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_CTRL;

            if ((GetKeyState(VirtualKeyStates.VK_MENU) & 1) != 0)
                key_modifier_state |= RmlUiNet.Input.KeyModifier.KM_ALT;

            return key_modifier_state;
        }

        internal int LOWORD(int n) => (n & 0xffff);
        internal int HIWORD(int n) => (n >> 16) & 0xffff;
    }
}