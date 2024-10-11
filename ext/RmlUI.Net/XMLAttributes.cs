using RmlUiNet;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet {
    public class XMLAttributes : RmlBase<XMLAttributes> {
        internal XMLAttributes(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache) {
        }

        public virtual string GetString(string property, string defaultValue="") {
            var strPtr = RmlUiNet.Native.XMLAttributes.GetString(NativePtr, property, defaultValue);
            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue;
        }
    }
}
