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

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetAbsoluteLeft")]
        public static extern float GetAbsoluteLeft(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetAbsoluteTop")]
        public static extern float GetAbsoluteTop(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetClientHeight")]
        public static extern float GetClientHeight(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetClientWidth")]
        public static extern float GetClientWidth(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetAttributeString")]
        public static extern IntPtr GetAttributeString(IntPtr element, string attributeName, string defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_SetAttributeString")]
        public static extern IntPtr SetAttributeString(IntPtr element, string attributeName, string value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetPropertyString")]
        public static extern IntPtr GetPropertyString(IntPtr element, string propertyName);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetProperty")]
        public static extern IntPtr GetProperty(IntPtr element, string propertyName);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetPropertyById")]
        public static extern IntPtr GetPropertyById(IntPtr element, int propertyId);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_SetProperty")]
        public static extern IntPtr SetProperty(IntPtr element, string propertyName, string value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_GetElementTypeName")]
        public static extern IntPtr GetElementTypeName(IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_AppendChild")]
        public static extern IntPtr AppendChild(IntPtr element, IntPtr elementToAppend, bool addToDom);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_AppendChildTag")]
        public static extern IntPtr AppendChildTag(IntPtr element, string tagName, bool addToDom);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_ScrollTo")]
        public static extern IntPtr ScrollTo(IntPtr element, float x, float y, int behavior);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Element_SetClass")]
        public static extern IntPtr SetClass(IntPtr element, string className, bool enable);
    }
}
