using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class Property
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Property_Get")]
        public static extern IntPtr Get(IntPtr property);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Property_GetString")]
        public static extern IntPtr GetString(IntPtr property, string defaultValue);
    }
}
