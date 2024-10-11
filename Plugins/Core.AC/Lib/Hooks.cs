using AcClient;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Core.AC.Lib {
    internal unsafe class Hooks {
        private static IHook<UIFlow_UseNewMode>? _uiFlowUseNewModeHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate uint UIFlow_UseNewMode(UIFlow* uiFlow);

        internal static void Init() {
            _uiFlowUseNewModeHook = CreateHook<UIFlow_UseNewMode>(typeof(Hooks), nameof(UIFlow_UseNewMode_Impl), 0x00479AA0);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint UIFlow_UseNewMode_Impl(UIFlow* uiFlow) {
            var mode = uiFlow->_nextMode;
            var ret = _uiFlowUseNewModeHook?.OriginalFunction(uiFlow) ?? 0;

            CoreACPlugin.Instance.CurrentScreen = (GameScreen)mode;

            return ret;
        }

        internal bool ShowScreen(GameScreen screen) {
            // Todo: check that we are able to switch to this next state...
            if (!((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null)) {
                (*UIFlow.m_instance)->QueueUIMode((UIMode)screen);
                return true;
            }
            return false;
        }

        internal GameScreen GetScreen() {
            try {
                return ((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null) ? GameScreen.None : (GameScreen)(*UIFlow.m_instance)->_curMode;
            }
            catch {
                return GameScreen.None;
            }
        }

        protected static IHook<TFunction> CreateHook<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes)] TFunction>(Type type, string name, int address) {
            return ReloadedHooks.Instance.CreateHook<TFunction>(type, name, address).Activate();
        }

        internal static void Destroy() {
            _uiFlowUseNewModeHook?.Disable();
        }
    }
}