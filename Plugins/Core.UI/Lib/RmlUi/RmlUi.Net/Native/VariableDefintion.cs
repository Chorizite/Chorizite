using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native {
    internal static class VariableDefinition {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_VariableDefinition_New")]
        public static extern IntPtr Create(DataVariableType type, OnGet onGet, OnSet onSet, OnSize onSize, OnChild onChild);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_VariableDefinition_Free")]
        public static extern void Free(IntPtr instance);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool OnGet(IntPtr ptr, ref IntPtr variant);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool OnSet(IntPtr ptr, IntPtr variant);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int OnSize(IntPtr ptr);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr OnChild(IntPtr ptr, string name, int index);
    }
}
