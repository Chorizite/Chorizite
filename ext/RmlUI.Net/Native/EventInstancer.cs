using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RmlUiNet.Native
{

    internal static class EventInstancer
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_EventInstancer_New")]
        public static extern IntPtr Create(OnInstanceEvent onInstanceEvent);

        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_EventInstancer_Free")]
        public static extern IntPtr Free(IntPtr eventListenerInstancer);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnInstanceEvent(IntPtr element, string elementType, EventId eventId, string name, IntPtr parameters, bool interruptible);
    }
}
