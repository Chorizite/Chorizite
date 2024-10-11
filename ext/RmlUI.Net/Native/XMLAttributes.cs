using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {
    internal static class XMLAttributes {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_XMLAttributes_GetString")]
        public static extern IntPtr GetString(IntPtr attributes, string prop, string defaultValue);
    }
}
