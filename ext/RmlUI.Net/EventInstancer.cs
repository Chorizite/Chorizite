using RmlUiNet;
using RmlUiNet.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet
{
    public abstract class EventInstancer : RmlBase<EventInstancer>
    {
        private Native.EventInstancer.OnInstanceEvent _onInstanceEvent;

        public EventInstancer() : base(IntPtr.Zero)
        {
            _onInstanceEvent = OnInstanceEventInternal;

            NativePtr = Native.EventInstancer.Create(_onInstanceEvent);
            ManuallyRegisterCache(NativePtr, this);
        }

        public abstract void OnInstanceEvent(Element element, EventId id, string name, Dictionary<string, object> parameters, bool interruptible);

        internal virtual void OnInstanceEventInternal(IntPtr element, string elementType, EventId eventId, string name, IntPtr parameters, bool interruptible)
        {
            var _parameters = new Dictionary<string, object>();
            var keys = Native.RmlDictionary.RetrieveKeys(parameters);
            foreach (var key in keys)
            {
                var variant = new Variant(Native.RmlDictionary.Get(parameters, key));
                if (variant?.Value is not null)
                {
                    _parameters.TryAdd(key, variant.Value);
                }
            }
            OnInstanceEvent(new ElementGeneric(element, false), eventId, name, _parameters, interruptible);
            foreach (var key in _parameters.Keys.Except(keys)) {
                var value = _parameters[key];
                var variant = Util.ToVariant(value);
                if (variant is not null) {
                    Native.RmlDictionary.Insert(parameters, key, variant.NativePtr);
                }
            }
        }

        public override void Dispose()
        {
            Native.EventInstancer.Free(NativePtr);
            base.Dispose();
        }
    }
}
