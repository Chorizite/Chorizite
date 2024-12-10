using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native
{
    internal static class Event
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_GetId")]
        public static extern ushort GetId(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_GetPhase")]
        public static extern int GetPhase(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_GetCurrentElement")]
        public static extern IntPtr GetCurrentElement(IntPtr ev, out IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_GetTargetElement")]
        public static extern IntPtr GetTargetElement(IntPtr ev, out IntPtr element);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_StopPropagation")]
        public static extern void StopPropagation(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_StopImmediatePropagation")]
        public static extern void StopImmediatePropagation(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_IsInterruptible")]
        public static extern bool IsInterruptible(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_IsPropagating")]
        public static extern bool IsPropagating(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_IsImmediatePropagating")]
        public static extern bool IsImmediatePropagating(IntPtr ev);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Event_GetParameters")]
        public static extern IntPtr GetParameters(IntPtr element);
    }
}
