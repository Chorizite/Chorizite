using MagicHat.Backends.ACBackend.Input;
using MagicHat.Loader.Injected.Lib;
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
using System.Windows.Forms;

namespace MagicHat.Loader.Injected.Hooks {
    internal class DirectXHooks : HookBase {
        private static IHook<EndScene> _endSceneHook;
        private static IHook<CreateDevice> _createDeviceHook;
        private static IHook<WndProc> _windowProcHook;

        private static IVirtualFunctionTable Direct3D9VTable { get; set; }
        private static IVirtualFunctionTable DeviceVTable { get; set; }

        private static int _unmanagedD3DPtr;

        public static Device D3Ddevice { get; private set; }

        private static nint _hwnd;

        [Function(CallingConventions.Stdcall)]
        private delegate nint WndProc(nint a, uint b, nint c, nint d);

        [Function(CallingConventions.Stdcall)]
        private delegate nint CreateDevice(nint a, uint b, DeviceType c, nint d, CreateFlags e, nint f, nint g);

        [FunctionHookOptions(PreferRelativeJump = true)]
        [Function(CallingConventions.Stdcall)]
        private delegate nint EndScene(nint a);

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint EndSceneImpl(nint a) {
            try {
                InjectedLoader.Render?.Render2D();
            }
            catch (Exception ex) {
                InjectedLoader.Log.LogError(ex, $"EndScene Error: {ex.Message}");
            }
            return _endSceneHook.OriginalFunction.Invoke(a);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private unsafe static nint CreateDeviceImpl(nint a, uint b, DeviceType c, nint hwnd, CreateFlags e, nint f, nint d3dPtr) {
            var devicePtr = _createDeviceHook.OriginalFunction.Invoke(a, b, c, hwnd, e, f, d3dPtr);
            _unmanagedD3DPtr = *(int*)d3dPtr;
            D3Ddevice = new Device(_unmanagedD3DPtr);
            _hwnd = hwnd;

            var windowProc = (int)Native.GetWindowLong(hwnd, Native.GWL.GWL_WNDPROC);
            _windowProcHook = CreateHook<WndProc>(typeof(DirectXHooks), nameof(WndProcImpl), windowProc);

            InjectedLoader.Startup(_unmanagedD3DPtr);

            return devicePtr;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private static nint WndProcImpl(nint hwnd, uint uMsg, nint wParam, nint lParam) {
            if (InjectedLoader.Input.HandleWindowMessage((int)hwnd, (WindowMessageType)uMsg, (int)wParam, (int)lParam)) {
                return nint.Zero;
            }
            return _windowProcHook.OriginalFunction.Invoke(hwnd, uMsg, wParam, lParam);
        }

        public static int Init(nint a, int b) {
            using var direct3D = new Direct3D();
            using var renderForm = new Form();
            using var device = new Device(direct3D, 0, DeviceType.Hardware, nint.Zero, CreateFlags.HardwareVertexProcessing, GetParameters(direct3D, renderForm.Handle));

            Direct3D9VTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(direct3D.NativePointer, Enum.GetNames(typeof(IDirect3D9)).Length);
            DeviceVTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(device.NativePointer, Enum.GetNames(typeof(IDirect3DDevice9)).Length);

            var createDevicePtr = (int)Direct3D9VTable[(int)IDirect3D9.CreateDevice].FunctionPointer;
            _createDeviceHook = CreateHook<CreateDevice>(typeof(DirectXHooks), nameof(CreateDeviceImpl), createDevicePtr);

            var endScenePtr = (int)DeviceVTable[(int)IDirect3DDevice9.EndScene].FunctionPointer;
            _endSceneHook = CreateHook<EndScene>(typeof(DirectXHooks), nameof(EndSceneImpl), endScenePtr);

            return 0;
        }

        private static PresentParameters GetParameters(Direct3D d3d, nint windowHandle) {
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
