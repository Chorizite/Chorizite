using System;

namespace RmlUiNet
{
    public class ElementFormControlDataSelect : Element<ElementFormControlDataSelect>
    {
        #region Methods

        protected ElementFormControlDataSelect(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementFormControlDataSelect? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementFormControlDataSelect(ptr, false));
        }

        #endregion
    }
}
