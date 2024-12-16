using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiOnceUponAFrame
    {
        public int RefFrame;
    }
    public unsafe partial struct ImGuiOnceUponAFramePtr
    {
        public ImGuiOnceUponAFrame* NativePtr { get; }
        public ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr) => NativePtr = nativePtr;
        public ImGuiOnceUponAFramePtr(IntPtr nativePtr) => NativePtr = (ImGuiOnceUponAFrame*)nativePtr;
        public static implicit operator ImGuiOnceUponAFramePtr(ImGuiOnceUponAFrame* nativePtr) => new ImGuiOnceUponAFramePtr(nativePtr);
        public static implicit operator ImGuiOnceUponAFrame* (ImGuiOnceUponAFramePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiOnceUponAFramePtr(IntPtr nativePtr) => new ImGuiOnceUponAFramePtr(nativePtr);
        public int RefFrame { get { return NativePtr->RefFrame; } set { NativePtr->RefFrame = value; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiOnceUponAFrame_destroy((ImGuiOnceUponAFrame*)(NativePtr));
        }
    }
}
