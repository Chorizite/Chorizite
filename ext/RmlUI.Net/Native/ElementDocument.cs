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

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_AddStyleSheetContainer")]
        public static extern void AddStyleSheetContainer(IntPtr document, IntPtr container);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_Close")]
        public static extern void Close(IntPtr document);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_New")]
        public static extern IntPtr Create(OnLoadInlineScript? onLoadInlineScript);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_CreateElement")]
        public static extern IntPtr CreateElement(IntPtr document, string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_CreateTextNode")]
        public static extern IntPtr CreateTextNode(IntPtr document, string text);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_SetTitle")]
        public static extern IntPtr SetTitle(IntPtr document, string title);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_GetTitle")]
        public static extern IntPtr GetTitle(IntPtr document);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_GetSourceURL")]
        public static extern IntPtr GetSourceURL(IntPtr document);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementDocument_Free")]
        public static extern void Free(IntPtr document);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnLoadInlineScript(string context, string source_path, int source_line);
    }
}
