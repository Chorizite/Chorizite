using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native {
    internal static class ElementCustom {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementCustom_New")]
        public static extern IntPtr Create(string tagName, OnRender? onRender);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementCustom_Free")]
        public static extern IntPtr Free(IntPtr element);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnRender();
    }
}
