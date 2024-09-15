using System;

namespace RmlUiNet
{
    public class ElementTabSet : Element<ElementTabSet>
    {
        #region Methods

        protected ElementTabSet(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementTabSet? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementTabSet(ptr, false));
        }

        #endregion
    }
}
