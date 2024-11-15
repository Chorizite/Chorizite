using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet
{

    public class StyleSheetContainer : RmlBase<StyleSheetContainer>
    {
        public StyleSheetContainer(IntPtr ptr, bool automaticallyRegisterInCache = false) : base(ptr, automaticallyRegisterInCache)
        {

        }

        public StyleSheetContainer(string filename) : base(IntPtr.Zero, false) {
            NativePtr = Native.StyleSheetContainer.Create();
            Native.StyleSheetContainer.LoadStyleSheetContainer(NativePtr, filename);
        }

        public void LoadStyleSheetContainer(string filename)
        {
            Native.StyleSheetContainer.LoadStyleSheetContainer(NativePtr, filename);
        }

        public override void Dispose()
        {
            Native.StyleSheetContainer.Free(NativePtr);
            base.Dispose();
        }
    }
}
