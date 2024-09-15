using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class Element
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetTagName")]
        public static extern IntPtr GetTagName(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_AddEventListener")]
        public static extern void AddEventListener(IntPtr element, string name, IntPtr eventListener, bool inCapturePhase);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_RemoveEventListener")]
        public static extern void RemoveEventListener(IntPtr element, string name, IntPtr eventListener, bool inCapturePhase);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetElementByID")]
        public static extern IntPtr GetElementById(IntPtr element, string id, out IntPtr foundElement);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetOwnerDocument")]
        public static extern IntPtr GetOwnerDocument(IntPtr element, out IntPtr foundElement);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_SetInnerRml")]
        public static extern void SetInnerRml(IntPtr element, string rml);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_Focus")]
        public static extern bool Focus(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_Blur")]
        public static extern void Blur(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_Click")]
        public static extern void Click(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetBox")]
        public static extern IntPtr GetBox(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetOffsetTop")]
        public static extern float GetOffsetTop(IntPtr element);
    }
}
