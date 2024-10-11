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

        private bool OnGet(IntPtr ptr, ref IntPtr variantPtr)
        {
            var res = Get(ptr, out var variant);
            variantPtr = variant.NativePtr;
            return res;
        }

        private bool OnSet(IntPtr ptr, IntPtr variantPtr)
        {
            var variant = new Variant(variantPtr);
            return Set(ptr, variant);
        }

        private int OnSize(IntPtr ptr)
        {
            return Size(ptr);
            return 0;
        }

        private IntPtr OnChild(IntPtr ptr, string name, int index)
        {
            return Child(ptr, name, index).NativePtr;
            return IntPtr.Zero;
        }

        public abstract DataVariable Child(IntPtr ptr, string name, int index);
        public abstract int Size(IntPtr ptr);
        public abstract bool Set(IntPtr ptr, Variant variant);
        public abstract bool Get(IntPtr ptr, out Variant variant);
    }

    public enum DataVariableType : int {
        Scalar = 0,
        Array,
        Struct
    }
}
