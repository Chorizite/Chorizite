using System;

namespace RmlUiNet
{
    public class ElementFormControlSelect : Element<ElementFormControlSelect>
    {
        #region Methods

        protected ElementFormControlSelect(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementFormControlSelect? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementFormControlSelect(ptr, false));
        }

        #endregion
    }
}
