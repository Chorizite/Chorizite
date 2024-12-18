using Chorizite.Loader.Standalone.Input;
using Chorizite.Loader.Standalone.Lib;
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

namespace Chorizite.Loader.Standalone.Hooks {
    internal unsafe class DirectXHooks : HookBase {
        private static bool _isResetting = false;
        private static IHook<EndScene> _endSceneHook;
        private static IHook<CreateDevice> _createDeviceHook;
        private static IHook<WndProc> _windowProcHook;

        private static IVirtualFunctionTable Direct3D9VTable { get; set; }
        private static IVirtualFunctionTable DeviceVTable { get; set; }

        private static int _unmanagedD3DPtr;

        public static Device D3Ddevice { get; private set; }
        public static int HWND => *(int*)0x008381A4;

        private static IHook<Reset> _resetHook;

        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr WndProc(IntPtr a, uint b, IntPtr c, IntPtr d);

        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr CreateDevice(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g);

        [FunctionHookOptions(PreferRelativeJump = true)]
        [Function(CallingConventions.Stdcall)]
        private delegate IntPtr EndScene(IntPtr a);

        [Function(CallingConventions.Stdcall)]
        private unsafe delegate int Reset(IntPtr a, PresentParameters* b);

        public static int Init(IntPtr a, int b) {
            using var direct3D = new Direct3D();
            using var device = new Device(direct3D, 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, GetParameters(direct3D, 0));

            Direct3D9VTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(direct3D.NativePointer, Enum.GetNames(typeof(IDirect3D9)).Length);
            DeviceVTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(device.NativePointer, Enum.GetNames(typeof(IDirect3DDevice9)).Length);

            var createDevicePtr = (int)Direct3D9VTable[(int)IDirect3D9.CreateDevice].FunctionPointer;
            _createDeviceHook = CreateHook<CreateDevice>(typeof(DirectXHooks), nameof(CreateDeviceImpl), createDevicePtr);

            var endScenePtr = (int)DeviceVTable[(int)IDirect3DDevice9.EndScene].FunctionPointer;
            _endSceneHook = CreateHook<EndScene>(typeof(DirectXHooks), nameof(EndSceneImpl), endScenePtr);

            var resetPtr = (int)DeviceVTable[(int)IDirect3DDevice9.Reset].FunctionPointer;
            _resetHook = CreateHook<Reset>(typeof(DirectXHooks), nameof(ResetImpl), resetPtr);

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private unsafe static int ResetImpl(IntPtr a, PresentParameters* b) {
            var res = _resetHook.OriginalFunction.Invoke(a, b);
            if (res != 0) {
                StandaloneLoader.Render.TriggerGraphicsPreReset(StandaloneLoader.Render, EventArgs.Empty);
                return res;
            }
            StandaloneLoader.Render.TriggerGraphicsPostReset(StandaloneLoader.Render, EventArgs.Empty);
            return res;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static IntPtr EndSceneImpl(IntPtr a) {
            try {
                if (a != _unmanagedD3DPtr) {
                    _unmanagedD3DPtr = (int)a;
                    D3Ddevice = new Device(_unmanagedD3DPtr);
                    StandaloneLoader.Backend.DX9Renderer.SetDevice(D3Ddevice);
                }
                StandaloneLoader.Render?.Render2D();
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, $"EndScene Error: {ex.Message}");
            }
            return _endSceneHook.OriginalFunction.Invoke(a);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private unsafe static IntPtr CreateDeviceImpl(IntPtr a, uint b, DeviceType c, IntPtr hwnd, CreateFlags e, IntPtr f, IntPtr d3dPtr) {
            var devicePtr = _createDeviceHook.OriginalFunction.Invoke(a, b, c, hwnd, e, f, d3dPtr);
            _unmanagedD3DPtr = *(int*)d3dPtr;
            D3Ddevice = new Device(_unmanagedD3DPtr);

            var windowProc = (int)Native.GetWindowLong(hwnd, Native.GWL.GWL_WNDPROC);
            _windowProcHook = CreateHook<WndProc>(typeof(DirectXHooks), nameof(WndProcImpl), windowProc);

            StandaloneLoader.Startup(_unmanagedD3DPtr);

            return devicePtr;
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
            return _windowProcHook.OriginalFunction.Invoke(hwnd, uMsg, wParam, lParam);
        }

        private static PresentParameters GetParameters(Direct3D d3d, IntPtr windowHandle) {
            var mode = d3d.GetAdapterDisplayMode(0);
            return new PresentParameters() {
                BackBufferWidth = mode.Width,
                BackBufferHeight = mode.Height,
                BackBufferFormat = mode.Format,
                DeviceWindowHandle = windowHandle,
                SwapEffect = SwapEffect.Discard,
                Windowed = true,
                PresentationInterval = PresentInterval.Immediate
            };
        }
    }
}
