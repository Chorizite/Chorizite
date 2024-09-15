using System;

namespace RmlUiNet
{
    public class ElementText : Element<ElementText>
    {
        #region Methods

        protected ElementText(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementText? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementText(ptr, false));
        }

        #endregion
    }
}
