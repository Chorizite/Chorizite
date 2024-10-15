using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Loader.Standalone.Lib {
    internal static class Native {
        unsafe public static void WriteProtected<T>(IntPtr address, T value) where T : unmanaged {
            Native.VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (uint)sizeof(T), 0x40, out int b);
            *(T*)address = value;
            Native.VirtualProtectEx(Process.GetCurrentProcess().Handle, address, (uint)sizeof(T), b, out b);
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        public enum GWL {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12)
        }
        [DllImport("kernel32.dll")]
        public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, int flNewProtect, out int lpflOldProtect);

        [DllImport("user32.dll")]
        private static extern bool IsWindowUnicode(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
        private static extern IntPtr GetWindowLongPtr32W(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
        private static extern IntPtr GetWindowLongPtr64W(IntPtr hWnd, int nIndex);

        public static IntPtr GetWindowLong(IntPtr hWnd, GWL nIndex) {
            if (IsWindowUnicode(hWnd))
                return GetWindowLongW(hWnd, nIndex);

            return GetWindowLongA(hWnd, nIndex);
        }

        public static IntPtr GetWindowLongA(IntPtr hWnd, GWL nIndex) {
            var is64Bit = Environment.Is64BitProcess;
            return is64Bit ? GetWindowLongPtr64(hWnd, (int)nIndex) : GetWindowLongPtr32(hWnd, (int)nIndex);
        }

        public static IntPtr GetWindowLongW(IntPtr hWnd, GWL nIndex) {
            var is64Bit = Environment.Is64BitProcess;
            return is64Bit ? GetWindowLongPtr64W(hWnd, (int)nIndex) : GetWindowLongPtr32W(hWnd, (int)nIndex);
        }
    }
}
