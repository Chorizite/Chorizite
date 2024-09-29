using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native {
    internal static class DataModelConstructor {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindFloat")]
        public static extern bool BindFloat(IntPtr instance, string name, IntPtr data);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_DataModelConstructor_BindString")]
        public static extern bool BindString(IntPtr instance, string name, string data);
    }
}
