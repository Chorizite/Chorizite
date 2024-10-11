using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static RmlUiNet.Native.SystemInterface;

namespace RmlUiNet {
    public unsafe class DataVariable : RmlBase<DataVariable>, IDisposable {
        public VariableDefinition Definition { get; protected set; }

        public DataVariable() : base(IntPtr.Zero) {
        }

        public DataVariable(VariableDefinition definition, IntPtr data = 0) : base(IntPtr.Zero) {
            Definition = definition;
            NativePtr = Native.DataVariable.Create(Definition.NativePtr, data);
        }

        protected void CreateNative(VariableDefinition definition) {
            Definition = definition;
            NativePtr = Native.DataVariable.Create(Definition.NativePtr, IntPtr.Zero);
        }

        public override void Dispose() {
            Native.DataVariable.Free(NativePtr);
            base.Dispose();
        }
    }
}
