using Microsoft.DirectX.Direct3D;
using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X86;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Permissions;

namespace Reloaded.Core.Bootstrap.ExampleDll
{
    public static class Hello
    {
        private static IHook<RenderDeviceD3D__Init> RenderDeviceD3D_InitHook;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        [Function(Hooks.Definitions.X86.CallingConventions.MicrosoftThiscall)]
        public delegate void RenderDeviceD3D__Init(IntPtr thisPtr);

        public static int SayHello(IntPtr stringPtr, int size)
        {
            RenderDeviceD3D_InitHook = ReloadedHooks.Instance.CreateHook<RenderDeviceD3D__Init>(RenderDeviceD3D__Init__Impl, 0x005A2BA0).Activate();
            return 0;
        }


        private unsafe static void RenderDeviceD3D__Init__Impl(IntPtr thisPtr)
        {

            RenderDeviceD3D_InitHook.OriginalFunction(thisPtr);
            //var deviceId = *(int*)(thisPtr + 0x468);
            //int* d3dDevicePtr = (int*)((*(int*)0x008F297C) + 0x480);
            //File.AppendAllText(@"D:\projects\ACUI\bin\log.txt", $"deviceId: {(int)thisPtr:X8} {(int)*d3dDevicePtr:X8}\n");
            //var D3Ddevice = new Device((int)d3dDevicePtr);

            //File.AppendAllText(@"D:\projects\ACUI\bin\log.txt", $"RenderDeviceD3D__Init: {D3Ddevice.Viewport.Width},{D3Ddevice.Viewport.Height}\n");


            //return res;
        }

        private static string GetRuntimeVersion()
        {
            string framework = Assembly.GetExecutingAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
            return framework;
        }

        private static string GetArchitecture()
        {
            switch (IntPtr.Size)
            {
                case 4:
                    return "x86";
                case 8:
                    return "x64";
                default:
                    return "The future is now";
            }
        }
    }
}
