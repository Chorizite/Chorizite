using RmlUiNet;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet
{
    public class Property : RmlBase<Property>
    {
        internal Property(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        public Variant Get() {
            return new Variant(Native.Property.Get(NativePtr));
        }

        public virtual string GetString(string defaultValue = "")
        {
            var strPtr = Native.Property.GetString(NativePtr, defaultValue);
            if (strPtr == IntPtr.Zero) return defaultValue;

            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? defaultValue;
        }
    }
}
