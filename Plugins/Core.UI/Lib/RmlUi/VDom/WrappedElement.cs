using Core.UI.Lib.RmlUi.Elements;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi.VDom {
    public class WrappedElement : IDisposable {
        internal static readonly Dictionary<IntPtr, Dictionary<IntPtr, WrappedElement>> _elementCache = [];
        private readonly Dictionary<string, Action<Event>> _eventCache = [];
        private readonly Dictionary<string, Action<Event>> _myEventCache = [];
        public readonly Element DocEl;

        public WrappedElement(Element element) {
            DocEl = element;
        }

        internal static WrappedElement? GetOrCreate(ScriptableDocumentElement doc, Element element) {
            if (!_elementCache.ContainsKey(doc.NativePtr)) {
                _elementCache.Add(doc.NativePtr, []);
            }
            var docCache = _elementCache[doc.NativePtr];

            if (!docCache.ContainsKey(element.NativePtr)) {
                docCache.Add(element.NativePtr, new WrappedElement(element));
            }
            return docCache[element.NativePtr];
        }

        internal void SetEventListener(string eventName, Action<Event> action) {
            if (!_eventCache.Remove(eventName, out var oldEventAction)) {
                Action<Event> listener = (e) => {
                    if (_eventCache.TryGetValue(eventName, out var eventAction)) {
                        try {
                            eventAction(e);
                        }
                        catch (Exception ex) {
                            CoreUIPlugin.Log.LogError(ex, ex.Message);
                        }
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
