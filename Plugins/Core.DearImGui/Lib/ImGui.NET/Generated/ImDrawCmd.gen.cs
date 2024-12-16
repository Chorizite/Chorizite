using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImDrawCmd
    {
        public Vector4 ClipRect;
        public IntPtr TextureId;
        public uint VtxOffset;
        public uint IdxOffset;
        public uint ElemCount;
        public IntPtr UserCallback;
        public void* UserCallbackData;
    }
    public unsafe partial struct ImDrawCmdPtr
    {
        public ImDrawCmd* NativePtr { get; }
        public ImDrawCmdPtr(ImDrawCmd* nativePtr) => NativePtr = nativePtr;
        public ImDrawCmdPtr(IntPtr nativePtr) => NativePtr = (ImDrawCmd*)nativePtr;
        public static implicit operator ImDrawCmdPtr(ImDrawCmd* nativePtr) => new ImDrawCmdPtr(nativePtr);
        public static implicit operator ImDrawCmd* (ImDrawCmdPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImDrawCmdPtr(IntPtr nativePtr) => new ImDrawCmdPtr(nativePtr);
        public Vector4 ClipRect { get { return NativePtr->ClipRect; } set { NativePtr->ClipRect = value; } }
        public IntPtr TextureId { get { return NativePtr->TextureId; } set { NativePtr->TextureId = value; } }
        public uint VtxOffset { get { return NativePtr->VtxOffset; } set { NativePtr->VtxOffset = value; } }
        public uint IdxOffset { get { return NativePtr->IdxOffset; } set { NativePtr->IdxOffset = value; } }
        public uint ElemCount { get { return NativePtr->ElemCount; } set { NativePtr->ElemCount = value; } }
        public IntPtr UserCallback { get { return NativePtr->UserCallback; } set { NativePtr->UserCallback = value; } }
        public IntPtr UserCallbackData { get => (IntPtr)NativePtr->UserCallbackData; set => NativePtr->UserCallbackData = (void*)value; }
        public void Destroy()
        {
            ImGuiNative.ImDrawCmd_destroy((ImDrawCmd*)(NativePtr));
        }
        public IntPtr GetTexID()
        {
            IntPtr ret = ImGuiNative.ImDrawCmd_GetTexID((ImDrawCmd*)(NativePtr));
            return ret;
        }
    }
}
