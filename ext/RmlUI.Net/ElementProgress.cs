using System;

namespace RmlUiNet
{
    public class ElementProgress : Element<ElementProgress>
    {
        #region Methods

        protected ElementProgress(IntPtr ptr, bool automaticallyRegisterInCache)
            : base(ptr, automaticallyRegisterInCache)
        {
        }

        internal static ElementProgress? Create(IntPtr ptr)
        {
            return GetOrCreateCache(ptr, ptr => new ElementProgress(ptr, false));
        }

        #endregion
    }
}
