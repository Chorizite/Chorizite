using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native
{
    internal static class RmlDictionary
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_Create")]
        public static extern IntPtr Create();

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_Free")]
        public static extern void Free(IntPtr dict);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_Size")]
        public static extern int Size(IntPtr dict);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_Insert")]
        public static extern void Insert(IntPtr dict, string prop, IntPtr variant);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_Get")]
        public static extern IntPtr Get(IntPtr dict, string prop);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_GetAllKeys")]
        private static extern IntPtr GetAllKeys(IntPtr map, ref int keyCount);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_Dictionary_FreeKeys")]
        private static extern void FreeKeys(IntPtr keys, int keyCount);

        public static string[] RetrieveKeys(IntPtr dict)
        {
            if (dict == IntPtr.Zero)
                return Array.Empty<string>();

            int keyCount = 0;
            IntPtr keysPtr = GetAllKeys(dict, ref keyCount);

            if (keysPtr == IntPtr.Zero || keyCount == 0)
                return Array.Empty<string>();

            try
            {
                string[] keys = new string[keyCount];
                for (int i = 0; i < keyCount; i++)
                {
                    // Read pointer to each string
                    IntPtr stringPtr = Marshal.ReadIntPtr(keysPtr, IntPtr.Size * i);
                    keys[i] = Marshal.PtrToStringAnsi(stringPtr);
                }

                return keys;
            }
            finally
            {
                // Always free the unmanaged memory
                FreeKeys(keysPtr, keyCount);
            }
        }
    }
}
