using System;
using System.Collections.Generic;
using System.Text;

namespace RmlUiNet
{
    public static class Debugger
    {
        public static void Initialise(Context context)
        {
            Native.Debugger.Initialise(context.NativePtr);
        }

        public static void SetContext(Context context)
        {
            Native.Debugger.SetContext(context.NativePtr);
        }

        public static bool IsVisible()
        {
            return Native.Debugger.IsVisible();
        }

        public static void SetVisible(bool visible)
        {
            Native.Debugger.SetVisible(visible);
        }

        public static void Shutdown()
        {
            Native.Debugger.Shutdown();
        }
    }
}
