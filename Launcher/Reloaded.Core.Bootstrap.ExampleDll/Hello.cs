using Reloaded.Core.Bootstrap.ExampleDll.Lib;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Structs;
using Reloaded.Hooks.Definitions.X86;
using SharpDX.Direct3D9;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace Reloaded.Core.Bootstrap.ExampleDll
{
    public static class Hello
    {
        private static IHook<CreateDevice> _createDeviceHook;

        public static IVirtualFunctionTable Direct3D9VTable { get; private set; }
        public static IVirtualFunctionTable DeviceVTable { get; private set; }
        public static Device D3Ddevice { get; private set; }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [Function(Hooks.Definitions.X86.CallingConventions.Stdcall)]
        public delegate IntPtr CreateDevice(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g);

        public static int SayHello(IntPtr a, int b)
        {
            using var direct3D = new Direct3D();
            using var renderForm = new Form();
            using var device = new Device(direct3D, 0, DeviceType.Hardware, IntPtr.Zero, CreateFlags.HardwareVertexProcessing, GetParameters(direct3D, renderForm.Handle));

            Direct3D9VTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(direct3D.NativePointer, Enum.GetNames(typeof(IDirect3D9)).Length);
            DeviceVTable = ReloadedHooks.Instance.VirtualFunctionTableFromObject(device.NativePointer, Enum.GetNames(typeof(IDirect3DDevice9)).Length);
            
            var createDevicePtr = (long)Direct3D9VTable[(int)IDirect3D9.CreateDevice].FunctionPointer;
            _createDeviceHook = ReloadedHooks.Instance.CreateHook<CreateDevice>(typeof(Hello), nameof(CreateDeviceImpl), createDevicePtr).Activate();

            return 0;
        }

        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvStdcall) })]
        private unsafe static IntPtr CreateDeviceImpl(IntPtr a, uint b, DeviceType c, IntPtr d, CreateFlags e, IntPtr f, IntPtr g)
        {
            var devicePtr = _createDeviceHook.OriginalFunction.Invoke(a, b, c, d, e, f, g);
            D3Ddevice = new Device(*((int*)g));
            //MessageBox(0, $"CreateDevice: {D3Ddevice.Viewport.Width},{D3Ddevice.Viewport.Height}", "Hello", 0);

            return devicePtr;
        }

        private static PresentParameters GetParameters(Direct3D d3d, IntPtr windowHandle)
        {
            var mode = d3d.GetAdapterDisplayMode(0);
            return new PresentParameters()
            {
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
