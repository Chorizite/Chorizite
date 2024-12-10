using System;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class Rml
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Initialise")]
        public static extern bool Initialise();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Shutdown")]
        public static extern void Shutdown();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_SetRenderInterface")]
        public static extern void SetRenderInterface(IntPtr renderInterface);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_SetSystemInterface")]
        public static extern void SetSystemInterface(IntPtr systemInterface);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_SetFileInterface")]
        public static extern void SetFileInterface(IntPtr fileInterface);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_LoadFontFace")]
        public static extern bool LoadFontFace(string fileName, bool fallbackFace, FontWeight weight);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_CreateEventListener")]
        public static extern IntPtr CreateEventListener(OnProcessEvent onProcessEvent, OnAttachEvent onAttachEvent, OnDetachEvent onDetachEvent);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ReleaseEventListener")]
        public static extern void ReleaseEventListener(IntPtr eventListener);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_RemoveContext")]
        public static extern bool RemoveContext(string name);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_RegisterPlugin")]
        public static extern void RegisterPlugin(IntPtr pluginPtr);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_GetRenderInterface")]
        public static extern IntPtr GetRenderInterface();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_GetSystemInterface")]
        public static extern IntPtr GetSystemInterface();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_CreateString")]
        public static extern IntPtr CreateString(string str);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Log")]
        public static extern IntPtr Log(LogType type, string str);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_UpdateString")]
        public static extern void UpdateString(IntPtr str, string newContent);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_FreeString")]
        public static extern void FreeString(IntPtr str);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_RegisterEventType")]
        public static extern EventId RegisterEventType(string type, bool interruptible, bool bubbles, DefaultActionPhase default_action_phase);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnProcessEvent(IntPtr eventPtr);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnAttachEvent(IntPtr elementPtr, string elementType);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnDetachEvent(IntPtr elementPtr, string elementType);
    }
}
