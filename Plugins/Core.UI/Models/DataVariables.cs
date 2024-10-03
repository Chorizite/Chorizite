using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.UI.Models {
    public class DataVariableList<T> : DataVariable, INotifyCollectionChanged, INotifyPropertyChanged where T : DataVariable {
        public new VariableListDefinition<T> Definition { get; }
        public ObservableCollection<T> Value => Definition.Value;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public DataVariableList(ObservableCollection<T> value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") : base() {
            Definition = new VariableListDefinition<T>(memberName, value);
            Definition.PropertyChanged += (_, e) => PropertyChanged?.Invoke(this, e);
            CreateNative(Definition); 
        }
    }

    public class VariableListDefinition<T> : VariableDefinition, INotifyPropertyChanged, IDisposable where T : DataVariable {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<T> _value;

        public string Name { get; }
        public ObservableCollection<T> Value => _value;

        public VariableListDefinition(string name, ObservableCollection<T> value) : base(DataVariableType.Array) {
            Name = name;
            _value = value;
        }

        internal override bool Get(nint ptr, out Variant variant) {
            variant = null;
            return false;
        }

        internal override bool Set(nint ptr, Variant variant) {
            return false;
        }

        internal override int Size(nint ptr) {
            return Value.Count;
        }

        internal override DataVariable Child(nint ptr, string name, int index) {
            return Value.ElementAt(index);
        }
    }

    public class DataVariable<T> : DataVariable, INotifyPropertyChanged {
        public new VariableDefinition<T> Definition { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public T Value {
            get => Definition.Value;
            set => Definition.Value = value;
        }

        public DataVariable(T value, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") : base() {
            Definition = new VariableDefinition<T>(memberName, value);
            base.Definition = Definition;
            Definition.PropertyChanged += (_, e) => PropertyChanged?.Invoke(this, e);
            CreateNative(Definition);
        }
    }

    public class VariableDefinition<T> : VariableDefinition, INotifyPropertyChanged, IDisposable {
        private T _value;

        public string Name { get; }

        public T Value {
            get => _value;
            set {
                if (value?.Equals( _value) != true) {
                    _value = value;
                    InvokePropertyChange();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public VariableDefinition(string name, T value) : base(DataVariableType.Scalar) {
            Name = name;
            if (typeof(T) == typeof(string)) {
                _value = value;
            }
            else if (typeof(T) == typeof(int)) {
                _value = value;
            }
            else if (typeof(T) == typeof(uint)) {
                _value = value;
            }
            else if (typeof(T) == typeof(float)) {
                _value = value;
            }
            else if (typeof(T) == typeof(double)) {
                _value = value;
            }
            else if (typeof(T) == typeof(bool)) {
                _value = value;
            }
            else if (typeof(T).IsAssignableTo(typeof(DataVariable))) {
                _value = value;
            }
            else {
                Core.UI.CoreUIPlugin.Log.LogError($"!!!!! Unsupported type: {typeof(T)}");
            }
        }

        protected void InvokePropertyChange([System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
            if (!string.IsNullOrEmpty(memberName)) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
            }
        }

        internal override bool Get(nint ptr, out Variant variant) {
            if (typeof(T) == typeof(string)) {
                variant = new Variant((Value as string)!);
            }
            else if (typeof(T) == typeof(int)) {
                variant = new Variant(Convert.ToInt32(Value));
            }
            else if (typeof(T) == typeof(uint)) {
                variant = new Variant(Convert.ToUInt32(Value));
            }
            else if (typeof(T) == typeof(float)) {
                variant = new Variant(Convert.ToSingle(Value));
            }
            else if (typeof(T) == typeof(double)) {
                variant = new Variant(Convert.ToDouble(Value));
            }
            else if (typeof(T) == typeof(bool)) {
                variant = new Variant(Convert.ToBoolean(Value));
            }
            else {
                Core.UI.CoreUIPlugin.Log.LogError($"Unsupported GET type: {typeof(T)}");
                variant = default(Variant);
                return false;
            }

            return true;
        }

        internal override bool Set(nint ptr, Variant variant) {
            if (typeof(T) == typeof(string) && variant.Type == VariantType.STRING) {
                Value = (T)variant.Value!;
            }
            else if (typeof(T) == typeof(int) && variant.Type == VariantType.INT) {
                Value = (T)variant.Value!;
            }
            else if (typeof(T) == typeof(uint)) {
                Value = (T)(object)Convert.ToUInt32(variant.Value);
            }
            else if (typeof(T) == typeof(float) && variant.Type == VariantType.FLOAT) {
                Value = (T)(object)Convert.ToUInt32(variant.Value);
            }
            else if (typeof(T) == typeof(double) && variant.Type == VariantType.DOUBLE) {
                Value = (T)variant.Value!;
            }
            else if (typeof(T) == typeof(bool) && variant.Type == VariantType.BOOL) {
                Value = (T)variant.Value!;
            }
            else {
                Core.UI.CoreUIPlugin.Log.LogError($"Unsupported SET type: {typeof(T)} / {variant.Type}");
                return false;
            }

            return true;
        }

        internal override int Size(nint ptr) {
            if (Value is DataVariable dv) {
                return dv.Definition.Size(ptr);
            }
            Core.UI.CoreUIPlugin.Log.LogError($"Unsupported Size type: {typeof(T)} /  {Value}");
            return 0;
        }

        internal override DataVariable Child(nint ptr, string name, int index) {
            if (Value is UIDataSubModel subModel) {
                if (!string.IsNullOrEmpty(name)) {
                    return Value.GetType().GetProperty(name).GetValue(Value) as DataVariable;
                }
            }
            Core.UI.CoreUIPlugin.Log.LogError($"Unsupported Child 123 type: {typeof(T)} / {name} / {index} {Value}");
            return null;
        }
    }
}
