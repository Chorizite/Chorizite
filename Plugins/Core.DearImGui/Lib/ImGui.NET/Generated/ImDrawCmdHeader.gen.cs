using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImDrawCmdHeader
    {
        public Vector4 ClipRect;
        public IntPtr TextureId;
        public uint VtxOffset;
    }
    public unsafe partial struct ImDrawCmdHeaderPtr
    {
        public ImDrawCmdHeader* NativePtr { get; }
        public ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => NativePtr = nativePtr;
        public ImDrawCmdHeaderPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmdHeader*)nativePtr;
        public static implicit operator ImDrawCmdHeaderPtr(ImDrawCmdHeader* nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);
        public static implicit operator ImDrawCmdHeader* (ImDrawCmdHeaderPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImDrawCmdHeaderPtr(IntPtr nativePtr) => new ImDrawCmdHeaderPtr(nativePtr);
        public Vector4 ClipRect { get { return NativePtr->ClipRect; } set { NativePtr->ClipRect = value; } }
        public IntPtr TextureId { get { return NativePtr->TextureId; } set { NativePtr->TextureId = value; } }
        public uint VtxOffset { get { return NativePtr->VtxOffset; } set { NativePtr->VtxOffset = value; } }
    }
}
