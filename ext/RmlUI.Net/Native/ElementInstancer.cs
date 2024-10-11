using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {

    internal static class ElementInstancer {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_ElementInstancer_New")]
        public static extern IntPtr Create(string tag, OnInstanceElement onInstanceElement, OnReleaseElement onReleaseElement);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr OnInstanceElement(IntPtr parentElement, string tag, IntPtr xmlAttributes);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnReleaseElement(IntPtr element);
    }
}
