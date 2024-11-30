using System;
using System.Runtime.InteropServices;

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

        public string GetValue()
        {
            var strPtr = Native.ElementFormControlInput.GetValue(NativePtr);
            var strValue = Marshal.PtrToStringAnsi(strPtr);
            Marshal.FreeHGlobal(strPtr);
            return strValue ?? "";
        }

        public void SetValue(string value) => Native.ElementFormControlInput.SetValue(NativePtr, value);

        #endregion
    }
}
