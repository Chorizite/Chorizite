using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static RmlUiNet.Native.SystemInterface;

namespace RmlUiNet
{
    public unsafe class PropertyDefinition : RmlBase<PropertyDefinition>, IDisposable
    {
        public VariableDefinition Definition { get; protected set; }

        public PropertyDefinition(IntPtr nativePtr) : base(nativePtr)
        {
        }

        public PropertyDefinition AddParser(string name, string parserParams) {
            Native.PropertyDefinition.AddParser(NativePtr, name, parserParams);
            return this;
        }

        public int GetId() {
            return Native.PropertyDefinition.GetId(NativePtr);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
