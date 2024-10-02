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
            String,
            UInt,
            Int,
            Bool
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
        private Dictionary<string, Native.DataModelConstructor.DataEventFunc> _eventBindings = [];

        public DataModelHandle Handle { get; }

        internal DataModelConstructor(IntPtr ptr) : base(ptr) {
            Handle = new DataModelHandle(Native.DataModelConstructor.GetModelHandle(NativePtr));
        }

        public bool BindEventCallback(string name, Action<Event, IEnumerable<Variant>> callback) {
            Native.DataModelConstructor.DataEventFunc cb = (instance, evt, variants, numVariants) => {
                var variantInstances = new Variant[numVariants];
                for (int i = 0; i < numVariants; i++) {
                    variantInstances[i] = new Variant(variants[i]);
                }
                callback(new Event(evt), variantInstances);
            };

            if (_eventBindings.ContainsKey(name)) {
                _eventBindings[name] = cb;
            }
            else {
                _eventBindings.Add(name, cb);
            }
            
            Native.DataModelConstructor.BindEventCallback(NativePtr, name, _eventBindings[name]);

            return true;
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

        public bool BindUInt(string name, uint value) {
            if (_bindings.TryGetValue(name, out var binding)) {
                *(uint*)binding.Ptr = value;
                return true;
            }

            var ptr = Marshal.AllocHGlobal(sizeof(uint));
            Buffer.MemoryCopy(&value, (void*)ptr, sizeof(uint), sizeof(uint));
            Native.DataModelConstructor.BindUInt(NativePtr, name, ptr);

            _bindings.Add(name, new(name, ptr, BindingType.UInt));
            return true;
        }

        public bool BindInt(string name, int value) {
            if (_bindings.TryGetValue(name, out var binding)) {
                *(int*)binding.Ptr = value;
                return true;
            }

            var ptr = Marshal.AllocHGlobal(sizeof(int));
            Buffer.MemoryCopy(&value, (void*)ptr, sizeof(int), sizeof(int));
            Native.DataModelConstructor.BindInt(NativePtr, name, ptr);

            _bindings.Add(name, new(name, ptr, BindingType.Int));
            return true;
        }

        public bool BindBool(string name, bool value) {
            if (_bindings.TryGetValue(name, out var binding)) {
                *(bool*)binding.Ptr = value;
                return true;
            }

            var ptr = Marshal.AllocHGlobal(sizeof(bool));
            Buffer.MemoryCopy(&value, (void*)ptr, sizeof(bool), sizeof(bool));
            Native.DataModelConstructor.BindBool(NativePtr, name, ptr);

            _bindings.Add(name, new(name, ptr, BindingType.Bool));
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
                    case BindingType.UInt:
                    case BindingType.Int:
                    case BindingType.Bool:
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
