using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class Context
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_New")]
        public static extern IntPtr Create(string name, Vector2i dimensions, IntPtr renderInterface);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_Delete")]
        public static extern void Delete(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_Update")]
        public static extern void Update(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_Render")]
        public static extern void Render(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_LoadDocument")]
        public static extern IntPtr LoadDocument(IntPtr context, string documentPath);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_LoadDocumentFromMemory")]
        public static extern IntPtr LoadDocumentFromMemory(IntPtr context, string documentRml, string sourceUrl);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_IsMouseInteracting")]
        public static extern bool IsMouseInteracting(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessMouseLeave")]
        public static extern bool ProcessMouseLeave(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessMouseMove")]
        public static extern bool ProcessMouseMove(IntPtr context, int x, int y, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessMouseButtonDown")]
        public static extern bool ProcessMouseButtonDown(IntPtr context, int buttonIndex, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessMouseButtonUp")]
        public static extern bool ProcessMouseButtonUp(IntPtr context, int buttonIndex, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessMouseWheel")]
        public static extern bool ProcessMouseWheel(IntPtr context, Vector2f wheelDelta, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessKeyDown")]
        public static extern bool ProcessKeyDown(IntPtr context, Input.KeyIdentifier identifier, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessKeyUp")]
        public static extern bool ProcessKeyUp(IntPtr context, Input.KeyIdentifier identifier, int keyModifierState);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_ProcessTextInput")]
        public static extern bool ProcessTextInput(IntPtr context, string input);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_AddEventListener")]
        public static extern void AddEventListener(IntPtr context, string name, IntPtr eventListener, bool inCapturePhase);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_RemoveEventListener")]
        public static extern void RemoveEventListener(IntPtr context, string name, IntPtr eventListener, bool inCapturePhase);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_GetName")]
        public static extern IntPtr GetName(IntPtr context);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_CreateDataModel")]
        public static extern IntPtr CreateDataModel(IntPtr context, string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_GetDataModel")]
        public static extern IntPtr GetDataModel(IntPtr context, string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Context_RemoveDataModel")]
        public static extern bool RemoveDataModel(IntPtr context, string name);
    }
}
