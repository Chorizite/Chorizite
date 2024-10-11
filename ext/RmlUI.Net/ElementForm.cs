using System;

namespace RmlUiNet
{
    public class ElementForm : Element<ElementForm>
    {
        #region Methods

        protected ElementForm(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementForm? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementForm(ptr, false));
        }

        #endregion
    }
}
