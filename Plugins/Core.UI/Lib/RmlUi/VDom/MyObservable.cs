using Chorizite.Common;
using Cortex.Net;
using Cortex.Net.Api;
using Cortex.Net.Core;
using Cortex.Net.Types;
using System;
using System.Collections.Generic;

namespace Core.UI.Lib.RmlUi.Elements {
    public class MyObservable : IReactiveObject {
        private static uint _nextObservableId = 0;
        private ISharedState _state;
        private MyObservable _parent;

        public string Name { get; }

        private Dictionary<string, MyObservable> _children = [];
        internal ObservableObject Observable;

        public event EventHandler<ObjectCancellableEventArgs> OnChange {
            add => _OnChange.Subscribe(value);
            remove => _OnChange.Unsubscribe(value);
        }
        private WeakEvent<ObjectCancellableEventArgs> _OnChange = new();

        public event EventHandler<ObjectEventArgs> OnChanged {
            add => _OnChanged.Subscribe(value);
            remove => _OnChanged.Unsubscribe(value);
        }
        private WeakEvent<ObjectEventArgs> _OnChanged = new();
        public int Length { get; private set; }

        public ISharedState SharedState => _state;

        public MyObservable(ISharedState state, string name, MyObservable parent = null) {
            _state = state;
            _parent = parent;
            Name = name;
            Observable = _state.Observable(() => new ObservableObject(Name, _state.GetEnhancer(typeof(DeepEnhancer)), _state));

            Observable.Change += (s, e) => {
                _OnChange.Invoke(this, e);
            };
            Observable.Changed += (s, e) => {
                _OnChanged.Invoke(this, e);
            };
        }

        private int n = 0;
        private Dictionary<ObservableObject, MyObservable> _observables = new(); // TODO: remove>
        private void AddObservableProperty<T>(string name, T value) {
            if (Observable.Has(name)) return;

            Length++;
            if (value is MyObservable myObservable) {
                _observables.Remove(myObservable.Observable);
                _observables.Add(myObservable.Observable, myObservable);
                Observable.AddObservableProperty(name, myObservable.Observable);
            }
            else {
                Observable.AddObservableProperty(name, value);
            }
        }

        public void ClearProperty(string name) {
            Length--;
            Observable.Remove(name);
        }

        public void AddObservable(string name, MyObservable myObservable) => AddObservableProperty(name, myObservable);
        public void AddObservableString(string name, string value) => AddObservableProperty(name, value);
        public void AddObservableBool(string name, bool value) => AddObservableProperty(name, value);
        public void AddObservableNumber(string name, double value) => AddObservableProperty(name, value);

        public string ReadString(string name) => Read(name, "");
        public void WriteString(string name, string value) => Write(name, value);

        public bool ReadBool(string name) => Read(name, false);
        public void WriteBool(string name, bool value) => Write(name, value);

        public double ReadNumber(string name) => Read(name, (double)0);
        public void WriteNumber(string name, double value) => Write(name, value);

        internal T Read<T>(string name, T defaultValue = default) {
            if (!Observable.Has(name)) {
                Observable.AddObservableProperty(name, defaultValue);
            }
            return Observable.Read<T>(name);
        }

        internal void Write<T>(string name, T value) {
            if (!Observable.Has(name)) {
                Observable.AddObservableProperty(name, default(T));
            }
            Observable.Write(name, value);
        }

        public MyObservable? ReadObservable(string name) {
            if (Observable.Has(name)) {
                if (_observables.TryGetValue(Observable.Read<ObservableObject>(name), out var observable)) {
                    return observable;
                }
            }
            return null;
        }
    }
}
