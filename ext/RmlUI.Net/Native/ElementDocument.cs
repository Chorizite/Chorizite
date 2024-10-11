using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class ElementDocument
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_Show")]
        public static extern void Show(IntPtr document, ModalFlag modalFlag, FocusFlag focusFlag);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_Hide")]
        public static extern void Hide(IntPtr document);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_Close")]
        public static extern void Close(IntPtr document);
    }
}
