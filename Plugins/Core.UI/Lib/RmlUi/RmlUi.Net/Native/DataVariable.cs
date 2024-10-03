using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native {
    internal static class DataVariable {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataVariable_Create")]
        public static extern IntPtr Create(IntPtr definition, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataVariable_Free")]
        public static extern void Free(IntPtr instance);
    }
}
