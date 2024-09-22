using Autofac;
using MagicHat.Backends.ACBackend.Input;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Logging;
using MagicHat.Core.Render;
using MagicHat.Loader.Injected.Lib;
using Microsoft.Extensions.Logging;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using SharpDX.Direct3D9;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MagicHat.Loader.Injected {
    public static class InjectedLoader {
        private static IHook<EndScene> _endSceneHook;
        private static IHook<CreateDevice> _createDeviceHook;

        public static IVirtualFunctionTable Direct3D9VTable { get; private set; }
        public static IVirtualFunctionTable DeviceVTable { get; private set; }

        private static int _unmanagedD3DPtr;

        public static Device D3Ddevice { get; private set; }
        public static string AssemblyDirectory => System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(InjectedLoader)).Location);

        public static Core.MagicHat MagicHatInstance { get; private set; }

        private static DX9RenderInterface _render;
        private static Win32InputManager _input;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Stdcall)]
        public delegate IntPtr CreateDevice(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g);

        [FunctionHookOptions(PreferRelativeJump = true)]
        [Function(Reloaded.Hooks.Definitions.X86.CallingConventions.Stdcall)]
        public delegate IntPtr EndScene(IntPtr a);

        public static ILogger _log = new MagicHatLogger("InjectedLoader", AssemblyDirectory);

        public static int Init(IntPtr a, int b) {
            using var direct3D = new Direct3D();
            using var renderForm = new Form();
            using var device = new Device(direct3D, 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, GetParameters(direct3D, renderForm.Handle));

            Direct3D9VTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(direct3D.NativePointer, Enum.GetNames(typeof(IDirect3D9)).Length);
            DeviceVTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(device.NativePointer, Enum.GetNames(typeof(IDirect3DDevice9)).Length);

            var createDevicePtr = (long)Direct3D9VTable[(int)IDirect3D9.CreateDevice].FunctionPointer;
            _createDeviceHook = ReloadedHooks.Instance.CreateHook<CreateDevice>(typeof(InjectedLoader), nameof(CreateDeviceImpl), createDevicePtr).Activate();

            //var endScenePtr = (long)DeviceVTable[(int)IDirect3DDevice9.EndScene].FunctionPointer;
            //_endSceneHook = ReloadedHooks.Instance.CreateHook<EndScene>(typeof(InjectedLoader), nameof(EndSceneImpl), endScenePtr).Activate();

            return 0;
        }

        private static IntPtr EndSceneImpl(IntPtr a) {
            try {
                //_render?.Render2D();
            }
            catch (Exception ex) {
                _log.LogError(ex, $"EndScene Error: {ex.Message}");
            }
            return _endSceneHook.OriginalFunction.Invoke(a);
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private unsafe static IntPtr CreateDeviceImpl(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g) {
            var devicePtr = _createDeviceHook.OriginalFunction.Invoke(a, b, c, d, e, f, g);
            _unmanagedD3DPtr = *((int*)g);
            D3Ddevice = new Device(_unmanagedD3DPtr);
            //MessageBox(0, $"CreateDevice: {D3Ddevice.Viewport.Width},{D3Ddevice.Viewport.Height}", "Hello", 0);

            Startup();

            return devicePtr;
        }

        private static void Startup() {
            try {
                MagicHatInstance = new Core.MagicHat((builder) => {
                    builder.Register(c => new DX9RenderInterface(_unmanagedD3DPtr, c.Resolve<ILogger<DX9RenderInterface>>(), c.Resolve<IDatReaderInterface>()))
                        .As<IRenderInterface>()
                        .SingleInstance();
                    builder.Register(c => new Win32InputManager(c.Resolve<ILogger<Win32InputManager>>()))
                        .As<IInputManager>()
                        .SingleInstance();

                    return new Core.MagicHatConfig(System.IO.Path.Combine(AssemblyDirectory, "plugins"), AssemblyDirectory);
                });

                _render = (MagicHatInstance.Container.Resolve<IRenderInterface>() as DX9RenderInterface)!;
                _input = (MagicHatInstance.Container.Resolve<IInputManager>() as Win32InputManager)!;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Startup: {ex.Message}");
            }
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
