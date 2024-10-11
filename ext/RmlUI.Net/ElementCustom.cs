using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace RmlUiNet {
    public abstract class ElementCustom : Element<ElementCustom> {
        private Native.ElementCustom.OnRender? _onRender;

        public ElementCustom(string tagName) : base(IntPtr.Zero, false) {
            _onRender = IsImplemented(nameof(OnRender)) ? OnRender : null;

            NativePtr = Native.ElementCustom.Create(tagName, _onRender);
        }

        public virtual void OnRender() {

        }

        /// <summary>
        /// check if this method is implemented by the inheriting class
        /// </summary>
        private bool IsImplemented(string methodName) {
            return GetType().GetMethod(methodName).DeclaringType != typeof(ElementCustom);
        }

        public override void Dispose() {
            Native.ElementCustom.Free(NativePtr);
            base.Dispose();
        }
    }
}
