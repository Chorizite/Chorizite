using AcClient;
using MagicHat.Core.Render;
using MagicHat.Loader.Injected.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicHat.Loader.Injected.Hooks {
    internal unsafe class ACClientHooks : HookBase {
        private static IHook<ClientCleanup> _clientCleanupHook;
        private static IHook<UIFlow_UseNewMode> _uiFlowUseNewModeHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        internal delegate uint UIFlow_UseNewMode(UIFlow* uiFlow);

        [Function(CallingConventions.MicrosoftThiscall)]
        internal delegate void ClientCleanup(IntPtr client);

        internal static void Init() {
            _clientCleanupHook = CreateHook<ClientCleanup>(typeof(ACClientHooks), nameof(ClientCleanupImpl), 0x004118D0);
            _uiFlowUseNewModeHook = CreateHook<UIFlow_UseNewMode>(typeof(ACClientHooks), nameof(UIFlow_UseNewModeImpl), 0x00479AA0);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvThiscall) })]
        private static void ClientCleanupImpl(IntPtr client) {
            InjectedLoader.Input.HandleShutdown();
            _clientCleanupHook.OriginalFunction(client);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint UIFlow_UseNewModeImpl(UIFlow* uiFlow) {
            var mode = uiFlow->_nextMode;
            var ret = _uiFlowUseNewModeHook.OriginalFunction(uiFlow);
            InjectedLoader.Render.ShowGameScreen((GameScreen)mode);

            return ret;
        }
    }
}