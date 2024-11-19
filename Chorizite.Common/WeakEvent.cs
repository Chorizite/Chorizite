using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chorizite.Common {
    public class WeakEvent<TEventArgs> {
        private readonly List<WeakReference<EventHandler<TEventArgs>>> _listeners = [];

        // Keep the delegates alive with their target. This prevent anonymous delegates from being garbage collected prematurely.
        private readonly ConditionalWeakTable<object, List<object>> _delegateKeepAlive = new();

        public static ILogger? Log { get; set; }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Subscribe(EventHandler<TEventArgs> handler) {
            if (handler == null)
                return;

            var weakReference = new WeakReference<EventHandler<TEventArgs>>(handler);
            _listeners.Add(weakReference);
            if (handler.Target != null) {
                _delegateKeepAlive.GetOrCreateValue(handler.Target).Add(handler);
            }
        }

        public void Unsubscribe(EventHandler<TEventArgs> handler) {
            if (handler == null)
                return;

            // Remove the handler and all handlers that have been garbage collected
            _listeners.RemoveAll(wr => !wr.TryGetTarget(out var target) || handler.Equals(target));
            if (handler.Target != null && _delegateKeepAlive.TryGetValue(handler.Target, out var weakReference)) {
                weakReference.Remove(handler);
            }
        }

        public void Invoke(object? sender, TEventArgs args) {
            var listeners = _listeners.ToArray();
            foreach (var listener in listeners) {
                if (listener.TryGetTarget(out var target)) {
                    try {
                        target.Invoke(sender, args);
                    }
                    catch (Exception ex) {
                        Log?.LogError(ex, "Error invoking event handler");
                    }
                }
                else {
                    // Remove the listener if the target has been garbage collected
                    _listeners.Remove(listener);
                }
            }
        }
    }
}
