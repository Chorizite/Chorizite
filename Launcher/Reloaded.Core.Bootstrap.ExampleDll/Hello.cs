using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Reloaded.Core.Bootstrap.ExampleDll
{
    public static class Hello
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public static int SayHello(IntPtr stringPtr, int size)
        {
            MessageBox(IntPtr.Zero, $"Hello from NEW PLUGIN Architecture: {GetArchitecture()}, NET Core Version: {GetRuntimeVersion()}", $"Hello", 0);
            return 0;
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
