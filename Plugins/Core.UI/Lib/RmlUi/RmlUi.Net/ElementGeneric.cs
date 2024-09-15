using System;

namespace RmlUiNet
{
    public class ElementGeneric : Element<ElementGeneric>
    {
        #region Methods

        protected ElementGeneric(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementGeneric? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementGeneric(ptr, false));
        }

        #endregion
    }
}
