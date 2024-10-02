using AcClient;
using Iced.Intel;
using MagicHat.Core.Render;
using MagicHat.Loader.Injected.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicHat.Loader.Injected.Hooks {
    internal unsafe class ACClientHooks : HookBase {
        private static IHook<Client_Cleanup> _clientCleanupHook;
        private static IHook<UIFlow_UseNewMode> _uiFlowUseNewModeHook;
        private static IHook<gmDataPatchUI_Create> _gmDataPatchUICreateHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        internal delegate uint UIFlow_UseNewMode(UIFlow* uiFlow);

        [Function(CallingConventions.MicrosoftThiscall)]
        internal delegate void Client_Cleanup(IntPtr client);

        [Function(CallingConventions.Stdcall)]
        internal delegate gmDataPatchUI* gmDataPatchUI_Create();

        internal static void Init() {
            _clientCleanupHook = CreateHook<Client_Cleanup>(typeof(ACClientHooks), nameof(Client_Cleanup_Impl), 0x004118D0);
            _uiFlowUseNewModeHook = CreateHook<UIFlow_UseNewMode>(typeof(ACClientHooks), nameof(UIFlow_UseNewMode_Impl), 0x00479AA0);
            _gmDataPatchUICreateHook = CreateHook<gmDataPatchUI_Create>(typeof(ACClientHooks), nameof(gmDataPatchUI_Create_Impl), 0x004EF0C0);
        }
        static string AddSpaceEveryTwoChars(string input) {
            if (string.IsNullOrEmpty(input))
                return input;

            StringBuilder spacedString = new StringBuilder();

            for (int i = 0; i < input.Length; i++) {
                spacedString.Append(input[i]);

                // Add a space every 2 characters, but not at the end of the string
                if ((i + 1) % 2 == 0 && i != input.Length - 1) {
                    spacedString.Append(' ');
                }
            }

            return spacedString.ToString();
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvThiscall) })]
        private static void Client_Cleanup_Impl(IntPtr client) {
            InjectedLoader.Input.HandleShutdown();
            _clientCleanupHook.OriginalFunction(client);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint UIFlow_UseNewMode_Impl(UIFlow* uiFlow) {
            var mode = uiFlow->_nextMode;
            var ret = _uiFlowUseNewModeHook.OriginalFunction(uiFlow);
            InjectedLoader.Render.ShowGameScreen((GameScreen)mode);

            return ret;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static gmDataPatchUI* gmDataPatchUI_Create_Impl() {
            var dataPatchUI = _gmDataPatchUICreateHook.OriginalFunction();
            InjectedLoader.Render.SetDataPatchData(dataPatchUI);


            return dataPatchUI;
        }
    }
}