using AcClient;
using Iced.Intel;
using Chorizite.Core.Render;
using Chorizite.Loader.Standalone.Lib;
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

namespace Chorizite.Loader.Standalone.Hooks {
    internal unsafe class ACClientHooks : HookBase {
        private static IHook<Client_Cleanup>? _clientCleanupHook;
        private static IHook<Client_IsAlreadyRunning>? _clientIsAlreadyRunningHook;
        private static IHook<CLBlockAllocator_OpenDataFile>? _clBlockAllocatorOpenDataFileHook;
        private static IHook<UIFlow_UseNewMode>? _uiFlowUseNewModeHook;

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void Client_Cleanup(IntPtr client);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate byte Client_IsAlreadyRunning(IntPtr client);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate uint CLBlockAllocator_OpenDataFile(CLBlockAllocator* allocator, IntPtr pFileInfo, PStringBase<byte>* pFileName, PStringBase<ushort>* pcPathToUse, uint open_flags_l, IntPtr* pTranInfo);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate uint UIFlow_UseNewMode(UIFlow* uiFlow);

        internal static double InactiveTimeBeforeLogout {
            get => *(double*)0x007CEB70;
            set => Native.WriteProtected(0x007CEB70, value);
        }
        unsafe public static void WriteProtected<T>(IntPtr address, T value) where T : unmanaged {
            Native.VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (uint)sizeof(T), 0x40, out int b);
            *(T*)address = value;
            Native.VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (uint)sizeof(T), b, out b);
        }

        internal static void Init() {
            _clientCleanupHook = CreateHook<Client_Cleanup>(typeof(ACClientHooks), nameof(Client_Cleanup_Impl), 0x004118D0);
            _clientIsAlreadyRunningHook = CreateHook<Client_IsAlreadyRunning>(typeof(ACClientHooks), nameof(Client_IsAlreadyRunning_Impl), 0x004122A0);
            _clBlockAllocatorOpenDataFileHook = CreateHook<CLBlockAllocator_OpenDataFile>(typeof(ACClientHooks), nameof(CLBlockAllocator_OpenDataFile_Impl), 0x00675920);
            _uiFlowUseNewModeHook = CreateHook<UIFlow_UseNewMode>(typeof(ACClientHooks), nameof(UIFlow_UseNewMode_Impl), 0x00479AA0);

            InactiveTimeBeforeLogout = double.PositiveInfinity;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvThiscall) })]
        private static void Client_Cleanup_Impl(IntPtr client) {
            StandaloneLoader.Input?.HandleShutdown();
            _clientCleanupHook?.OriginalFunction(client);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static byte Client_IsAlreadyRunning_Impl(IntPtr client) {
            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint CLBlockAllocator_OpenDataFile_Impl(CLBlockAllocator* allocator, IntPtr pFileInfo, PStringBase<byte>* pFileName, PStringBase<ushort>* pcPathToUse, uint open_flags_l, IntPtr* pTranInfo) {
            open_flags_l |= 4;
            return _clBlockAllocatorOpenDataFileHook?.OriginalFunction(allocator, pFileInfo, pFileName, pcPathToUse, open_flags_l, pTranInfo) ?? 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private static uint UIFlow_UseNewMode_Impl(UIFlow* uiFlow) {
            var mode = uiFlow->_nextMode;
            var ret = _uiFlowUseNewModeHook?.OriginalFunction(uiFlow) ?? 0;

            StandaloneLoader.Backend.GameScreen = (int)mode;

            return ret;
        }

        void Destroy() {
            _clientCleanupHook?.Disable();
            _clientIsAlreadyRunningHook?.Disable();
            _clBlockAllocatorOpenDataFileHook?.Disable();
            _uiFlowUseNewModeHook?.Disable();
        }
    }
}