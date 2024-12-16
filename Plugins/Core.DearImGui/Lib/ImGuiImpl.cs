using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.DearImGui.Lib {
    internal static class ImGuiImpl {

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe IntPtr ImGui_ImplWin32_WndProcHandler(void* hwnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ImGui_ImplWin32_Init(IntPtr hwnd);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplWin32_Shutdown();

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplWin32_NewFrame();

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplWin32_EnableDpiAwareness();

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ImGui_ImplWin32_GetDpiScaleForHwnd(IntPtr hwnd);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern float ImGui_ImplWin32_GetDpiScaleForMonitor(IntPtr monitor);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplWin32_EnableAlphaCompositing(IntPtr hwnd);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public unsafe static extern bool ImGui_ImplDX9_Init(IntPtr device);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplDX9_Shutdown();

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplDX9_NewFrame();


        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplDX9_RenderDrawData(IntPtr draw_data);

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ImGui_ImplDX9_CreateDeviceObjects();

        [DllImport("cimgui", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImGui_ImplDX9_InvalidateDeviceObjects();
    }
}
