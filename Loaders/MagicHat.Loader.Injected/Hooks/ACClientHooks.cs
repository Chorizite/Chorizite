using MagicHat.Loader.Injected.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MagicHat.Loader.Injected.Hooks {
    internal unsafe class ACClientHooks {
        private static IHook<ClientCleanup> _clientCleanupHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        internal delegate void ClientCleanup(IntPtr client);

        internal static void Init() {
            _clientCleanupHook = ReloadedHooks.Instance.CreateHook<ClientCleanup>(typeof(ACClientHooks), nameof(ClientCleanupImpl), 0x004118D0).Activate();

        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvThiscall) })]
        private static void ClientCleanupImpl(IntPtr client) {
            InjectedLoader.Input.HandleShutdown();
            _clientCleanupHook.OriginalFunction(client);
        }
    }
}