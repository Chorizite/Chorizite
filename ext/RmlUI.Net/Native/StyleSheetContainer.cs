using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native
{
    internal static class StyleSheetContainer
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_StyleSheetContainer_New")]
        public static extern IntPtr Create();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_StyleSheetContainer_Free")]
        public static extern void Free(IntPtr container);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_StyleSheetContainer_LoadStyleSheetContainer")]
        public static extern bool LoadStyleSheetContainer(IntPtr container, string path);
    }
}
