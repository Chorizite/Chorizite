using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RmlUiNet.Native
{
    internal static class SystemInterface
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_SystemInterface_New")]
        public static extern IntPtr Create(OnGetElapsedTime onGetElapsedTime, OnTranslateString onTranslateString, OnLogMessage onLogMessage, OnJoinPath onJoinPath);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate double OnGetElapsedTime();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate string OnTranslateString(ref int changeCount, string input);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool OnLogMessage(LogType type, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate string OnJoinPath(string path, string file);
    }
}
