using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native {
    internal unsafe static class DataModelConstructor {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindFloat")]
        public static extern bool BindFloat(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindUInt")]
        public static extern bool BindUInt(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindInt")]
        public static extern bool BindInt(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindBool")]
        public static extern bool BindBool(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindString")]
        public static extern bool BindString(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindStringArray")]
        public static extern bool BindStringArray(IntPtr instance, string name, IntPtr data, int count);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_UnbindStringArray")]
        public static extern bool UnbindStringArray(IntPtr instance, string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_GetModelHandle")]
        public static extern IntPtr GetModelHandle(IntPtr instance);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_RegisterStruct")]
        public static extern IntPtr RegisterStruct(IntPtr instance, string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindVariable")]
        public static extern bool BindVariable(IntPtr instance, string name, IntPtr variable);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelHandle_Free")]
        public static extern void Free(IntPtr instance);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindEventCallback")]
        public static extern bool BindEventCallback(IntPtr instance, string name, DataEventFunc func);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DataEventFunc(IntPtr dataModel, IntPtr evt, nint* variants, int numVariants);
    }
}
