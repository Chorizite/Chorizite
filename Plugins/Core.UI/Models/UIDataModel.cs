using ACUI;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.ComponentModel;
using System.Reflection;

namespace Core.UI.Models {
    public abstract class UIDataModel : IDisposable {
        protected readonly DataModelConstructor _modelConstructor;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void InvokePropertyChange([System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
            if (!string.IsNullOrEmpty(memberName)) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
            }
        }

        public UIDataModel(string name, Context ctx) {
            _modelConstructor = ctx.CreateDataModel(name);

            PropertyChanged += HandlePropertyChanged;
            BuildBindings();
        }

        private void BuildBindings() {
            var propsToBind = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in propsToBind) {
                if (p.PropertyType == typeof(string) && p.GetValue(this) is string stringValue) {
                    _modelConstructor.BindString(p.Name, stringValue);
                }
                else if (p.PropertyType == typeof(float) && p.GetValue(this) is float floatValue) {
                    _modelConstructor.BindFloat(p.Name, floatValue);
                }
                else {
                   throw new Exception($"Unsupported bound property type: {p.PropertyType}");
                }
            }
        }

        protected virtual void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) {
                _modelConstructor.Handle.DirtyAllVariables();
            }
            else {
                var p = GetType().GetProperty(e.PropertyName);
                if (p is null) return;

                if (p.PropertyType == typeof(string) && p.GetValue(this) is string stringValue) {
                    _modelConstructor.BindString(p.Name, stringValue);
                }
                else if (p.PropertyType == typeof(float) && p.GetValue(this) is float floatValue) {
                    _modelConstructor.BindFloat(p.Name, floatValue);
                }
                _modelConstructor.Handle.DirtyVariable(e.PropertyName);
            }
        }

        public virtual void Dispose() {
            _modelConstructor?.Dispose();
        }
    }
}