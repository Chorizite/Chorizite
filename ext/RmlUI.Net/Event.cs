using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {

    public class Event : RmlBase<Event> {
        private Dictionary<string, object>? _parameters = null;
        /// <summary>
        /// The event id.
        /// </summary>
        public EventId Id => (EventId)Native.Event.GetId(NativePtr);

        /// <summary>
        /// The current propagation phase.
        /// </summary>
        public EventPhase Phase => (EventPhase)Native.Event.GetPhase(NativePtr);

        /// <summary>
        /// The current element in the propagation.
        /// </summary>
        public Element? CurrentElement {
            get {
                var elementType = Marshal.PtrToStringAnsi(
                    Native.Event.GetCurrentElement(NativePtr, out var elementPtr)
                );

                return Util.GetElementByTypeName(elementPtr, elementType);
            }
        }

        /// <summary>
        /// The target element of this event.
        /// </summary>
        public Element? TargetElement {
            get {
                var elementType = Marshal.PtrToStringAnsi(
                    Native.Event.GetTargetElement(NativePtr, out var elementPtr)
                );

                return Util.GetElementByTypeName(elementPtr, elementType);
            }
        }

        /// <summary>
        /// True if the event can be interrupted, that is, stopped from propagating.
        /// </summary>
        public bool IsInterruptible => Native.Event.IsInterruptible(NativePtr);

        /// <summary>
        /// True if the event is still propagating.
        /// </summary>
        public bool IsPropagating => Native.Event.IsPropagating(NativePtr);

        /// <summary>
        /// True if the event is still immediate propagating.
        /// </summary>
        public bool IsImmediatePropagating => Native.Event.IsImmediatePropagating(NativePtr);

        public Event(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache) {
        }

        public Dictionary<string, object> Parameters {
            get
            {
                if (_parameters is not null) return _parameters;
                _parameters = [];
                var parameters = Native.Event.GetParameters(NativePtr);
                var keys = Native.RmlDictionary.RetrieveKeys(parameters);
                foreach (var key in keys)
                {
                    var variant = new Variant(Native.RmlDictionary.Get(parameters, key));
                    try
                    {
                        if (variant?.Value is not null)
                        {
                            _parameters.TryAdd(key, variant.Value);
                        }
                    }
                    finally
                    {
                        //Native.Variant.Free(variant.NativePtr);
                    }
                }
                return _parameters;
            }
        }

        /// <summary>
        /// Stops propagation of the event if it is interruptible, but finish all listeners on the current element.
        /// </summary>
        public void StopPropagation() {
            Native.Event.StopPropagation(NativePtr);
        }

        /// <summary>
        /// Stops propagation of the event if it is interruptible, including to any other listeners on the current element.
        /// </summary>
        public void StopImmediatePropagation() {
            Native.Event.StopImmediatePropagation(NativePtr);
        }
    }
}
