using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {
    internal static class Variant {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetType")]
        public static extern int GetType(IntPtr variant);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsDouble")]
        public static extern double GetAsDouble(IntPtr variant, double defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsString")]
        public static extern IntPtr GetAsString(IntPtr variant, string defaultValue);
    }
}
