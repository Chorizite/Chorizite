using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace RmlUiNet.Native
{
    internal static class FileInterface
    {
        [DllImport("RmlUiNative", CallingConvention = CallingConvention.Cdecl, EntryPoint = "rml_FileInterface_New")]
        public static extern IntPtr Create(
            OnOpen onOpen,
            OnClose onClose,
            OnLoadFile onLoadFile,
            OnRead onRead,
            OnSeek onSeek,
            OnTell onTell,
            OnLength onLength
        );
        
        internal delegate ulong OnOpen(string path);
        
        internal delegate void OnClose(ulong file);
        
        internal unsafe delegate ulong OnRead(
            //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
            byte* buffer,
            ulong size,
            ulong file
        );
        
        internal delegate bool OnSeek(ulong file, long offset, int origin);
        
        internal delegate ulong OnTell(ulong file);
        
        internal delegate ulong OnLength(ulong file);
        
        internal delegate string OnLoadFile(string path);
    }
}
