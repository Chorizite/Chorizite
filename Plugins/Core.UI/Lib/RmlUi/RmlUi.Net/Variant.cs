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
        public VariantType Type {
            get => (VariantType)Native.Variant.GetType(NativePtr);
        }

        /// <summary>
        /// The variant data
        /// </summary>
        public object? Value {
            get {
                switch (Type) {
                    case VariantType.DOUBLE:
                        return Native.Variant.GetAsDouble(NativePtr, 0);
                    case VariantType.INT:
                        return Native.Variant.GetAsInt(NativePtr, 0);
                    case VariantType.FLOAT:
                        return Native.Variant.GetAsFloat(NativePtr, 0f);
                    case VariantType.UINT:
                        return Native.Variant.GetAsUInt(NativePtr, 0u);
                    case VariantType.BOOL:
                        return Native.Variant.GetAsBool(NativePtr, false);
                    case VariantType.STRING:
                        var strPtr = Native.Variant.GetAsString(NativePtr, "");
                        var strValue = Marshal.PtrToStringAnsi(strPtr);
                        Marshal.FreeHGlobal(strPtr);
                        return strValue;
                    default:
                        return null;
                }
            }
        }

        public Variant(int value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateInt(value);
        }

        public Variant(string value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateString(value);
        }

        public Variant(uint value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateUInt(value);
        }

        public Variant(float value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateFloat(value);
        }

        public Variant(double value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateDouble(value);
        }

        public Variant(bool value) : base(IntPtr.Zero, false) {
            NativePtr = Native.Variant.CreateBool(value);
        }

        public Variant(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache) {

        }

        public override string ToString() {
            return $"Variant{{{Type}: {Value}}}";
        }
    }
}
