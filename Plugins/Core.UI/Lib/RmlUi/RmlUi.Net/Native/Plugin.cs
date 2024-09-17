using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {

    internal static class Plugin {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Plugin_New")]
        public static extern IntPtr Create(OnInitialise onInitialise, OnShutdown onShutdown, OnDocumentOpen onDocumentOpen, OnDocumentLoad onDocumentLoad, OnDocumentUnload onDocumentUnload, OnContextCreate onContextCreate, OnContextDestroy onContextDestroy, OnElementCreate onElementCreate, OnElementDestroy onElementDestroy);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnInitialise();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnShutdown();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnDocumentOpen(IntPtr context, string documentPath);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnDocumentLoad(IntPtr document);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnDocumentUnload(IntPtr document);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnContextCreate(IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnContextDestroy(IntPtr context);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnElementCreate(IntPtr element);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnElementDestroy(IntPtr element);
    }
}
