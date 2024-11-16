using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Bindings.OpenGL;

namespace Launcher.Lib {
    internal struct RECT {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [Flags]
    enum DWM_BB {
        Enable = 1,
        BlurRegion = 2,
        TransitionMaximized = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    struct DWM_BLURBEHIND {
        public DWM_BB dwFlags;
        public bool fEnable;
        public IntPtr hRgnBlur;
        public bool fTransitionOnMaximized;

        public DWM_BLURBEHIND(bool enabled) {
            fEnable = enabled ? true : false;
            hRgnBlur = IntPtr.Zero;
            fTransitionOnMaximized = false;
            dwFlags = DWM_BB.Enable;
        }
    }

    internal static class Native {
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        public enum GWL {
            GWL_WNDPROC = (-4),
            GWL_HINSTANCE = (-6),
            GWL_HWNDPARENT = (-8),
            GWL_STYLE = (-16),
            GWL_EXSTYLE = (-20),
            GWL_USERDATA = (-21),
            GWL_ID = (-12),
            WS_EX_LAYERED = 0x80000,
            WS_EX_TRANSPARENT = 0x00000020
        }

        internal enum AccentState {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        internal enum WindowCompositionAttribute {
            WCA_ACCENT_POLICY = 19
        }

        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        internal static class User32 {
            [DllImport("user32.dll")]
            internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
        }

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        // This helper static method is required because the 32-bit version of user32.dll does not contain this API
        // (on any versions of Windows), so linking the method will fail at run-time. The bridge dispatches the request
        // to the correct function (GetWindowLong in 32-bit mode and GetWindowLongPtr in 64-bit mode)
        public static IntPtr SetWindowLongPtr(HandleRef hWnd, GWL nIndex, IntPtr dwNewLong) {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong32(HandleRef hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        private static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, GWL nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, uint dwNewLong);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongW")]
        private static extern IntPtr GetWindowLongPtr32W(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetWindowLongPtrW")]
        private static extern IntPtr GetWindowLongPtr64W(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool IsWindowUnicode(IntPtr hWnd);

        public static IntPtr GetWindowLong(IntPtr hWnd, GWL nIndex) {
            if (IsWindowUnicode(hWnd))
                return GetWindowLongW(hWnd, nIndex);

            return GetWindowLongA(hWnd, nIndex);
        }

        public static IntPtr GetWindowLongA(IntPtr hWnd, GWL nIndex) {
            var is64Bit = Environment.Is64BitProcess;
            return is64Bit ? GetWindowLongPtr64(hWnd, nIndex) : GetWindowLongPtr32(hWnd, nIndex);
        }

        public static IntPtr GetWindowLongW(IntPtr hWnd, GWL nIndex) {
            var is64Bit = Environment.Is64BitProcess;
            return is64Bit ? GetWindowLongPtr64W(hWnd, nIndex) : GetWindowLongPtr32W(hWnd, nIndex);
        }

        [DllImport("dwmapi.dll")]
        static extern void DwmEnableBlurBehindWindow(IntPtr hwnd, ref DWM_BLURBEHIND blurBehind);
        
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        public static void MakeWindowTransparent(IntPtr hwnd) {
            // color key transarency:
            SetWindowLong(hwnd, GWL.GWL_EXSTYLE, (uint)GetWindowLong(hwnd, GWL.GWL_EXSTYLE) ^ (uint)(GWL.WS_EX_LAYERED));
            SetLayeredWindowAttributes(hwnd, 0x00FF00FF, 255, 0x00000003);

            /*
            var region = CreateRectRgn(0, 0, 410, 350);
            var bb = new DWM_BLURBEHIND(true);
            bb.hRgnBlur = region;
            DwmEnableBlurBehindWindow(hwnd, ref bb);

            var accent = new AccentPolicy { AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND };

            var accentStructSize = Marshal.SizeOf(accent);

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData {
                Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY,
                SizeOfData = accentStructSize,
                Data = accentPtr
            };

            User32.SetWindowCompositionAttribute(hwnd, ref data);
            Marshal.FreeHGlobal(accentPtr);
            */
        }
    }
}
