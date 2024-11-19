using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class StyleSheetSpecification
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_StyleSheetSpecification_RegisterProperty")]
        public static extern IntPtr RegisterProperty(string name, string defaultValue, bool inherited, bool forcesLayout);
    }
}