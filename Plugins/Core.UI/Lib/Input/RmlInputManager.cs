using MagicHat.Core.Input;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Runtime.InteropServices;

namespace ACUI.Lib.Input {
    internal class RmlInputManager : IDisposable {
        private readonly Context _ctx;
        private readonly ILogger? _log;
        private readonly IInputManager _input;

        public RmlInputManager(IInputManager inputManager, Context ctx, ILogger? log) {
            _ctx = ctx;
            _log = log;
            _input = inputManager;

            _input.OnMouseMove += InputManager_OnMouseMove;
            _input.OnMouseDown += InputManager_OnMouseDown;
            _input.OnMouseUp += InputManager_OnMouseUp;
        }

        private void InputManager_OnMouseUp(object? sender, MouseUpEventArgs e) {
            var eat = !_ctx.ProcessMouseButtonUp((int)e.Button, 0);
            e.Eat = _ctx.IsMouseInteracting;
        }

        private void InputManager_OnMouseDown(object? sender, MouseDownEventArgs e) {
            var eat = !_ctx.ProcessMouseButtonDown((int)e.Button, 0);
            e.Eat = _ctx.IsMouseInteracting;
        }

        private void InputManager_OnMouseMove(object? sender, MouseMoveEventArgs e) {
            var eat = !_ctx.ProcessMouseMove(e.X, e.Y, 0);
            e.Eat = _ctx.IsMouseInteracting;
        }

        public void Dispose() {
            _input.OnMouseMove -= InputManager_OnMouseMove;
            _input.OnMouseDown -= InputManager_OnMouseDown;
            _input.OnMouseUp -= InputManager_OnMouseUp;
        }

        /*
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
        */

    }
}