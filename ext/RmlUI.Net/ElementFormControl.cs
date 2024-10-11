using System;

namespace RmlUiNet
{
    public class ElementFormControl : Element<ElementFormControl>
    {
        #region Methods

        protected ElementFormControl(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementFormControl? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementFormControl(ptr, false));
        }

        #endregion
    }
}
