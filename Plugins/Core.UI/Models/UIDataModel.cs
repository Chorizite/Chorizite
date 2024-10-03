using ACUI;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
            var propsToBind = GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsAssignableTo(typeof(DataVariable)));

            foreach (var p in propsToBind) {
                if (p.GetValue(this) is DataVariable dv) {
                    _modelConstructor.BindVariable(p.Name, dv);
                }
                if (p.GetValue(this) is INotifyPropertyChanged notifyPropertyChanged) {
                    notifyPropertyChanged.PropertyChanged += HandlePropertyChanged;
                }
            }
        }

        protected void TriggerPropertyChange(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if (!string.IsNullOrEmpty(e.PropertyName)) {
                _modelConstructor.Handle.DirtyVariable(e.PropertyName);
            }
            else {
                _modelConstructor.Handle.DirtyAllVariables();
            }
        }

        public virtual void Dispose() {
            _modelConstructor?.Dispose();
        }
    }
}