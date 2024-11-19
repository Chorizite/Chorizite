using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet
{
    public abstract class EventListenerInstancer : RmlBase<EventListenerInstancer>
    {
        private Native.EventListenerInstancer.OnEventListenerInstancer _onEventListenerInstancer;
        private List<EventListener> _eventListeners = [];

        public EventListenerInstancer() : base(IntPtr.Zero)
        {
            _onEventListenerInstancer = OnEventListenerInstancerInternal;

            NativePtr = Native.EventListenerInstancer.Create(_onEventListenerInstancer);
            ManuallyRegisterCache(NativePtr, this);
        }

        public abstract EventListener OnInstanceElement(string value, Element element);

        internal virtual IntPtr OnEventListenerInstancerInternal(string value, IntPtr element)
        {
            var listener = OnInstanceElement(value, new ElementGeneric(element, false));
            return listener.NativePtr;
        }

        public override void Dispose()
        {
            foreach (var listener in _eventListeners) {
                listener.Dispose();
            }
            _eventListeners.Clear();
            Native.EventListenerInstancer.Free(NativePtr);
            base.Dispose();
        }
    }
}
