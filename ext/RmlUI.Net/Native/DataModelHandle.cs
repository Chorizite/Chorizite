using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native {
    internal static class DataModelHandle {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelHandle_DirtyAllVariables")]
        public static extern void DirtyAllVariables(IntPtr instance);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelHandle_DirtyVariable")]
        public static extern void DirtyVariable(IntPtr instance, string variable_name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelHandle_IsVariableDirty")]
        public static extern bool IsVariableDirty(IntPtr instance, string variable_name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelHandle_Free")]
        public static extern void Free(IntPtr instance);
    }
}
