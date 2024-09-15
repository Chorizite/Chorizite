using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {
    internal static class Box {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Box_GetPosition")]
        public static extern IntPtr GetPosition(IntPtr box, int area);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Box_GetSize")]
        public static extern IntPtr GetSize(IntPtr box);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Box_GetSizeBoxArea")]
        public static extern IntPtr GetSize(IntPtr box, int area);
    }
}
