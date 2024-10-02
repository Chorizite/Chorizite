using ACUI;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
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

        public UIDataModel(string name, Context ctx, CoreUIPlugin plugin) {
            _modelConstructor = ctx.CreateDataModel(name);

            PropertyChanged += HandlePropertyChanged;
            BuildBindings();

            _modelConstructor.BindEventCallback("exit", (evt, variants) => {
                if (variants.FirstOrDefault()?.Value is string action && action == "OK") {
                    System.Environment.Exit(0);
                }
                else if (variants.FirstOrDefault()?.Value is string action2 && action2 == "Cancel") {
                    plugin.PanelManager.HideModal();
                    return;
                }
                plugin.PanelManager.ShowModalConfirmation("Are you sure you want to exit?", ["OK", "Cancel"], (button) => {
                    CoreUIPlugin.Log.LogDebug($"Clicked {button}");
                    if (button == "OK") {

                    }
                });
            });
        }

        private void BuildBindings() {
            var propsToBind = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in propsToBind) {
                BindProperty(p);
            }
        }

        private void BindProperty(PropertyInfo p) {
            if (p.PropertyType == typeof(string) && p.GetValue(this) is string stringValue) {
                _modelConstructor.BindString(p.Name, stringValue);
            }
            else if (p.PropertyType == typeof(float) && p.GetValue(this) is float floatValue) {
                _modelConstructor.BindFloat(p.Name, floatValue);
            }
            else if (p.PropertyType == typeof(uint) && p.GetValue(this) is uint uintValue) {
                _modelConstructor.BindUInt(p.Name, uintValue);
            }
            else if (p.PropertyType == typeof(int) && p.GetValue(this) is int intValue) {
                _modelConstructor.BindInt(p.Name, intValue);
            }
            else if (p.PropertyType == typeof(bool) && p.GetValue(this) is bool boolValue) {
                _modelConstructor.BindBool(p.Name, boolValue);
            }
            else {
                throw new Exception($"Unsupported bound property type: {p.PropertyType}");
            }
        }

        protected virtual void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e) {
            if (string.IsNullOrEmpty(e.PropertyName)) {
                _modelConstructor.Handle.DirtyAllVariables();
            }
            else {
                var p = GetType().GetProperty(e.PropertyName);
                if (p is null) return;
                BindProperty(p);
                _modelConstructor.Handle.DirtyVariable(e.PropertyName);
            }
        }

        public virtual void Dispose() {
            _modelConstructor?.Dispose();
        }
    }
}