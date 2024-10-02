using ACUI.Lib;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {

    public class Variant : RmlBase<Event> {
        /// <summary>
        /// The variant data type
        /// </summary>
        public VariantType Type => (VariantType)Native.Variant.GetType(NativePtr);

        /// <summary>
        /// The variant data
        /// </summary>
        public object? Value {
            get {
                switch (Type) {
                    case VariantType.DOUBLE:
                        return Native.Variant.GetAsDouble(NativePtr, 0);
                    case VariantType.STRING:
                        var strPtr = Native.Variant.GetAsString(NativePtr, "default");
                        var strValue = Marshal.PtrToStringAnsi(strPtr);
                        Marshal.FreeHGlobal(strPtr);
                        return strValue;
                    default:
                        return null;
                }
            }
        }

        public Variant(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache) {

        }
    }
}
