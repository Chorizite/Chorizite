using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class PropertyDefinition
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_PropertyDefinition_AddParser")]
        public static extern IntPtr AddParser(IntPtr propertyDefinition, string parserName, string parserParams);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_PropertyDefinition_GetId")]
        public static extern int GetId(IntPtr propertyDefinition);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_PropertyDefinition_GetValueString")]
        public static extern string GetValueString(IntPtr propertyDefinition, IntPtr property, string defaultValue);
    }
}
