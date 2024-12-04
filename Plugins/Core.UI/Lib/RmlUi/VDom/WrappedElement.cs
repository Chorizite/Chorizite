using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi.VDom {
    public class WrappedElement : IDisposable {
        private static readonly Dictionary<IntPtr, WrappedElement> _elementCache = [];
        private readonly Dictionary<string, Action<Event>> _eventCache = [];
        private readonly Dictionary<string, Action<Event>> _myEventCache = [];
        public readonly Element DocEl;

        public WrappedElement(Element element) {
            DocEl = element;
        }

        public static WrappedElement? GetOrCreate(Element element) {
            if (!_elementCache.ContainsKey(element.NativePtr)) {
                _elementCache.Add(element.NativePtr, new WrappedElement(element));
            }
            return _elementCache[element.NativePtr];
        }

        internal void SetEventListener(string eventName, Action<Event> action) {
            if (!_eventCache.Remove(eventName, out var oldEventAction)) {
                Action<Event> listener = (e) => {
                    if (_eventCache.TryGetValue(eventName, out var eventAction)) {
                        eventAction(e);
                    }
                };
                _myEventCache.Add(eventName, listener);
                DocEl.AddEventListener(eventName, listener);
            }
            _eventCache.Add(eventName, action);
        }

        internal void RemoveEventListener(string eventName) {
            _eventCache.Remove(eventName);
            if (_myEventCache.Remove(eventName, out var eventAction)) {
                DocEl.RemoveEventListener(eventName, eventAction);
            }
        }

        public void Dispose() {
            _elementCache.Remove(DocEl.NativePtr);
            foreach (var kvp in _myEventCache) {
                DocEl.RemoveEventListener(kvp.Key, kvp.Value);
            }
            _myEventCache.Clear();
            _eventCache.Clear();
        }
    }
}
