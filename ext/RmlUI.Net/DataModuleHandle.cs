using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {

    public unsafe class DataModelHandle : RmlBase<DataModelConstructor>, IDisposable {
        internal DataModelHandle(IntPtr ptr) : base(ptr) {

        }

        public void DirtyAllVariables() {
            Native.DataModelHandle.DirtyAllVariables(NativePtr);
        }

        public void DirtyVariable(string name) {
            Native.DataModelHandle.DirtyVariable(NativePtr, name);
        }

        public void IsVariableDirty(string name) {
            Native.DataModelHandle.IsVariableDirty(NativePtr, name);
        }

        public override void Dispose() {
            Native.DataModelHandle.Free(NativePtr);
            base.Dispose();
        }
    }
}
