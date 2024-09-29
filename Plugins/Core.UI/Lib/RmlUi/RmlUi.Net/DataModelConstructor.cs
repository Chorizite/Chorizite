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
        private enum BindingType {
            Float,
            String
        }

        private struct Binding {
            public IntPtr Ptr;
            public string Name;
            public BindingType Type;

            public Binding(string name, IntPtr ptr, BindingType type) {
                Name = name;
                Ptr = ptr;
                Type = type;
            }
        }

        private Dictionary<string, Binding> _bindings = [];

        public DataModelHandle Handle { get; }

        internal DataModelConstructor(IntPtr ptr) : base(ptr) {
            Handle = new DataModelHandle(Native.DataModelConstructor.GetModelHandle(NativePtr));
        }

        public bool BindFloat(string name, float value) {
            if (_bindings.TryGetValue(name, out var binding)) {
                *(float*)binding.Ptr = value;
                return true;
            }

            var ptr = Marshal.AllocHGlobal(sizeof(float));
            Buffer.MemoryCopy(&value, (void*)ptr, sizeof(float), sizeof(float));
            Native.DataModelConstructor.BindFloat(NativePtr, name, ptr);

            _bindings.Add(name, new(name, ptr, BindingType.Float));
            return true;
        }

        public bool BindString(string name, string value) {
            if (_bindings.TryGetValue(name, out var binding)) {
                Native.Rml.UpdateString(binding.Ptr, value);
                return true;
            }

            var ptr = Native.Rml.CreateString(value);

            _bindings.Add(name, new(name, ptr, BindingType.String));
            return Native.DataModelConstructor.BindString(NativePtr, name, ptr);
        }

        private void TryRemoveExistingBinding(string name) {
            if (_bindings.Remove(name, out var binding)) {
                switch (binding.Type) {
                    case BindingType.Float:
                        Marshal.FreeHGlobal(binding.Ptr);
                        break;
                    case BindingType.String:
                        Native.Rml.FreeString(binding.Ptr);
                        break;
                }
            }
        }

        public override void Dispose() {
        var existingBindings = _bindings.Keys.ToArray();
            foreach (var bindingName in existingBindings) {
                TryRemoveExistingBinding(bindingName);
            }
            _bindings.Clear();
            Native.DataModelConstructor.Free(NativePtr);
            Handle.Dispose();
            base.Dispose();
        }
    }
}
