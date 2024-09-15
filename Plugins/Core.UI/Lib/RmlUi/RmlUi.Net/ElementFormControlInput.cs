using System;

namespace RmlUiNet
{
    public class ElementFormControlInput : Element<ElementFormControlInput>
    {
        #region Methods

        protected ElementFormControlInput(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementFormControlInput? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementFormControlInput(ptr, false));
        }

        #endregion
    }
}
