using AcClient;
using Chorizite.NativeClientBootstrapper.Input;
using Chorizite.NativeClientBootstrapper.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DeviceType = SharpDX.Direct3D9.DeviceType;

namespace Chorizite.NativeClientBootstrapper.Hooks {
    internal unsafe class DirectXHooks : HookBase {
        private static IHook<WndProc>? _windowProcHook;
        private static IHook<RenderDeviceD3D_EndScene>? _renderDeviceD3D_EndSceneHook;
        private static IHook<RenderDeviceD3D_OnDeviceDisplayModeChange>? _renderDeviceD3D_OnDeviceDisplayModeChangeHook;

        private static int _unmanagedD3DPtr;

        public static Device? D3Ddevice { get; private set; }
        public static int HWND => *(int*)0x008381A4;


        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr WndProc(IntPtr a, uint b, IntPtr c, IntPtr d);

        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr CreateDevice(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g);

        [FunctionHookOptions(PreferRelativeJump = true)]
        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr EndScene(IntPtr a);

        [Function(CallingConventions.Stdcall)]
        private unsafe delegate int Reset(IntPtr a, PresentParameters* b);

        [FunctionHookOptions(PreferRelativeJump = true)]
        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void RenderDeviceD3D_EndScene(IntPtr a);

        [Function(CallingConventions.MicrosoftThiscall)]
        private delegate void RenderDeviceD3D_OnDeviceDisplayModeChange(IntPtr a);

        private static bool _didInit = false;
        private static uint _count = 0;

        public static int Init(IntPtr a, int b) {
            _renderDeviceD3D_EndSceneHook = CreateHook<RenderDeviceD3D_EndScene>(typeof(DirectXHooks), nameof(RenderDeviceD3D_EndSceneImpl), "## 56 8B F1 8A 86 AC 00 00 00 84 C0 74 16");
            _renderDeviceD3D_OnDeviceDisplayModeChangeHook = CreateHook<RenderDeviceD3D_OnDeviceDisplayModeChange>(typeof(DirectXHooks), nameof(RenderDeviceD3D_OnDeviceDisplayModeChangeImpl), "## 83 EC 10 53 56 57 8B F1 E8 ?? ?? ?? ?? 8B CE");

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private unsafe static void RenderDeviceD3D_EndSceneImpl(IntPtr a) {
            if (_count > 60) {
                StandaloneLoader.Render?.Render2D();
            }
            else {
                _count++;
            }
            _renderDeviceD3D_EndSceneHook!.OriginalFunction.Invoke(a);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvMemberFunction) })]
        private unsafe static void RenderDeviceD3D_OnDeviceDisplayModeChangeImpl(IntPtr a) {
            try {
                _count = 0;
                if (_didInit) {
                    StandaloneLoader.Render?.TriggerGraphicsPreReset(StandaloneLoader.Render, EventArgs.Empty);
                    _renderDeviceD3D_OnDeviceDisplayModeChangeHook!.OriginalFunction.Invoke(a);
                    StandaloneLoader.Render?.TriggerGraphicsPostReset(StandaloneLoader.Render, EventArgs.Empty);
                }
                else {
                    _renderDeviceD3D_OnDeviceDisplayModeChangeHook!.OriginalFunction.Invoke(a);
                }

                if (!_didInit) {
                    _didInit = true;
                    var windowProc = (int)Native.GetWindowLong(HWND, Native.GWL.GWL_WNDPROC);
                    _windowProcHook = CreateHook<WndProc>(typeof(DirectXHooks), nameof(WndProcImpl), windowProc);

                    _unmanagedD3DPtr = *(int*)(a + 1128 /* :) TODO: fix RenderDeviceD3D */);
                    D3Ddevice = new Device(_unmanagedD3DPtr);

                    StandaloneLoader.Log.LogWarning($"Created device 0x{_unmanagedD3DPtr:X8} for window {HWND}");

                    StandaloneLoader.Startup(_unmanagedD3DPtr);
                }
            }
            catch (Exception ex) { StandaloneLoader.Log.LogError(ex, "Failed to reset graphics"); }
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static IntPtr WndProcImpl(IntPtr hwnd, uint uMsg, IntPtr wParam, IntPtr lParam) {
            try {
                if (StandaloneLoader.Input?.HandleWindowMessage((int)hwnd, (WindowMessageType)uMsg, (int)wParam, (int)lParam) == true) {
                    return IntPtr.Zero;
                }
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, $"WndProc Error: {ex.Message}");
            }
            return _windowProcHook!.OriginalFunction.Invoke(hwnd, uMsg, wParam, lParam);
        }
    }
}
