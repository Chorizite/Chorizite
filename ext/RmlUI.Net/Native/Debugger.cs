using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native
{
    internal static class Debugger
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Debugger_Initialise")]
        public static extern void Initialise(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Debugger_SetContext")]
        public static extern void SetContext(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Debugger_Shutdown")]
        public static extern void Shutdown();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Debugger_IsVisible")]
        public static extern bool IsVisible();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Debugger_SetVisible")]
        public static extern void SetVisible(bool visible);
    }
}
