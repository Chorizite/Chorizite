using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native {
    internal static class Variant {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateInt")]
        public static extern IntPtr CreateInt(int value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateString")]
        public static extern IntPtr CreateString(string value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateUInt")]
        public static extern IntPtr CreateUInt(uint value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateFloat")]
        public static extern IntPtr CreateFloat(float value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateDouble")]
        public static extern IntPtr CreateDouble(double value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_CreateBool")]
        public static extern IntPtr CreateBool(bool value);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetType")]
        public static extern int GetType(IntPtr variant);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsDouble")]
        public static extern double GetAsDouble(IntPtr variant, double defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsInt")]
        public static extern int GetAsInt(IntPtr variant, int defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsString")]
        public static extern IntPtr GetAsString(IntPtr variant, string defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsUInt")]
        public static extern uint GetAsUInt(IntPtr variant, uint defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsFloat")]
        public static extern float GetAsFloat(IntPtr variant, float defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_GetAsBool")]
        public static extern bool GetAsBool(IntPtr variant, bool defaultValue);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Variant_Free")]
        public static extern void Free(IntPtr variant);
    }
}
