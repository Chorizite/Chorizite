using System;

namespace RmlUiNet
{
    public class ElementFormControlTextArea : Element<ElementFormControlTextArea>
    {
        #region Methods

        protected ElementFormControlTextArea(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementFormControlTextArea? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementFormControlTextArea(ptr, false));
        }

        #endregion
    }
}
