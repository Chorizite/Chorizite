using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class ElementFormControlInput
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementFormControlInput_GetValue")]
        public static extern IntPtr GetValue(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementFormControlInput_SetValue")]
        public static extern void SetValue(IntPtr element, string value);
    }
}
