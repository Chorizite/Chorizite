using System.Runtime.InteropServices;
using System;

namespace Core.DearImGui.Lib {
    internal static class Native {
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibrary(string path);
    }
}