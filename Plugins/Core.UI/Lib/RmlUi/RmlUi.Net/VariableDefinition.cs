using Microsoft.Extensions.Logging;
using System;
using System.Text;

namespace RmlUiNet {
    public abstract class VariableDefinition : RmlBase<VariableDefinition> {
        private Native.VariableDefinition.OnGet _onGet;
        private Native.VariableDefinition.OnSet _onSet;
        private Native.VariableDefinition.OnSize _onSize;
        private Native.VariableDefinition.OnChild _onChild;

        public VariableDefinition(DataVariableType type) : base(IntPtr.Zero) {
            _onGet = OnGet;
            _onSet = OnSet;
            _onSize = OnSize;
            _onChild = OnChild;

            NativePtr = Native.VariableDefinition.Create(
                type,
                _onGet,
                _onSet,
                _onSize,
                _onChild
            );

            ManuallyRegisterCache(NativePtr, this);
        }

        private bool OnGet(IntPtr ptr, ref IntPtr variantPtr) {
            try {
                var res = Get(ptr, out var variant);
                variantPtr = variant.NativePtr;
                return res;
            }
            catch (Exception ex) {
                Core.UI.CoreUIPlugin.Log.LogError(ex, "VariableDefinition.OnGet()");
            }
            return false;
        }

        private bool OnSet(IntPtr ptr, IntPtr variantPtr) {
            try {
                var variant = new Variant(variantPtr);
                return Set(ptr, variant);
            }
            catch (Exception ex) {
                Core.UI.CoreUIPlugin.Log.LogError(ex, "VariableDefinition.OnSet()");
            }
            return false;
        }

        private int OnSize(IntPtr ptr) {
            try {
                return Size(ptr);
            }
            catch (Exception ex) {
                Core.UI.CoreUIPlugin.Log.LogError(ex, "VariableDefinition.OnSize()");
            }
            return 0;
        }

        private IntPtr OnChild(IntPtr ptr, string name, int index) {
            try {
                return Child(ptr, name, index).NativePtr;
            }
            catch (Exception ex) {
                Core.UI.CoreUIPlugin.Log.LogError(ex, "VariableDefinition.OnChild()");
            }
            return IntPtr.Zero;
        }

        internal abstract DataVariable Child(IntPtr ptr, string name, int index);
        internal abstract int Size(IntPtr ptr);
        internal abstract bool Set(IntPtr ptr, Variant variant);
        internal abstract bool Get(IntPtr ptr, out Variant variant);
    }

    public enum DataVariableType : int {
        Scalar = 0,
        Array,
        Struct
    }
}
