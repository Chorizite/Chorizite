using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet {
    public abstract class ElementInstancer : RmlBase<ElementInstancer> {
        private Native.ElementInstancer.OnInstanceElement _onInstanceElement;
        private Native.ElementInstancer.OnReleaseElement _onReleaseElement;

        public ElementInstancer(string tag) : base(IntPtr.Zero) {
            _onInstanceElement = OnInstanceElementInternal;
            _onReleaseElement = OnReleaseElementInternal;

            NativePtr = Native.ElementInstancer.Create(tag, _onInstanceElement, _onReleaseElement);

            ManuallyRegisterCache(NativePtr, this);
        }

        public abstract IntPtr OnInstanceElement(Element parent, string tag, XMLAttributes attributes);

        public abstract void OnReleaseElement(Element element);

        internal virtual IntPtr OnInstanceElementInternal(IntPtr parentElement, string tag, IntPtr xmlAttributes) {
            var el = OnInstanceElement(new ElementGeneric(parentElement, false), tag, new XMLAttributes(xmlAttributes, false));
            return el;
        }

        internal virtual void OnReleaseElementInternal(IntPtr elementPtr) {
            OnReleaseElement(new ElementGeneric(elementPtr, false));
        }
    }
}
