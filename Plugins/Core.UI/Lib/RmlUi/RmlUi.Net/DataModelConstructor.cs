using AcClient;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {

    public unsafe class DataModelConstructor : RmlBase<DataModelConstructor>, IDisposable {
        private Dictionary<string, IntPtr> _bindings = [];

        internal DataModelConstructor(IntPtr ptr) : base(ptr) {

        }

        public bool BindFloat(string name, float value) {
            TryRemoveExistingBinding(name);
            var ptr = Marshal.AllocHGlobal(sizeof(float));
            Buffer.MemoryCopy(&value, (void*)ptr, sizeof(float), sizeof(float));
            RmlUiNet.Native.DataModelConstructor.BindFloat(NativePtr, name, ptr);
            return false;
        }

        public bool BindString(string name, string value) {
            TryRemoveExistingBinding(name);
            var ptr = Marshal.StringToHGlobalAuto(value);
            _bindings.Add(name, ptr);
            return RmlUiNet.Native.DataModelConstructor.BindString(NativePtr, name, value);
        }

        private void TryRemoveExistingBinding(string name) {
            if (_bindings.Remove(name, out var ptr)) {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public override void Dispose() {
            foreach (var ptr in _bindings.Values) {
                Marshal.FreeHGlobal(ptr);
            }
            _bindings.Clear();
            base.Dispose();
        }
    }
}
