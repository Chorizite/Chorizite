using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImDrawData
    {
        public byte Valid;
        public int CmdListsCount;
        public int TotalIdxCount;
        public int TotalVtxCount;
        public ImDrawList** CmdLists;
        public Vector2 DisplayPos;
        public Vector2 DisplaySize;
        public Vector2 FramebufferScale;
        public ImGuiViewport* OwnerViewport;
    }
    public unsafe partial struct ImDrawDataPtr
    {
        public ImDrawData* NativePtr { get; }
        public ImDrawDataPtr(ImDrawData* nativePtr) => NativePtr = nativePtr;
        public ImDrawDataPtr(IntPtr nativePtr) => NativePtr = (ImDrawData*)nativePtr;
        public static implicit operator ImDrawDataPtr(ImDrawData* nativePtr) => new ImDrawDataPtr(nativePtr);
        public static implicit operator ImDrawData* (ImDrawDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImDrawDataPtr(IntPtr nativePtr) => new ImDrawDataPtr(nativePtr);
        public bool Valid { get { return NativePtr->Valid == 1; } set { NativePtr->Valid = value ? (byte)1 : (byte)0; } }
        public int CmdListsCount { get { return NativePtr->CmdListsCount; } set { NativePtr->CmdListsCount = value; } }
        public int TotalIdxCount { get { return NativePtr->TotalIdxCount; } set { NativePtr->TotalIdxCount = value; } }
        public int TotalVtxCount { get { return NativePtr->TotalVtxCount; } set { NativePtr->TotalVtxCount = value; } }
        public IntPtr CmdLists { get => (IntPtr)NativePtr->CmdLists; set => NativePtr->CmdLists = (ImDrawList**)value; }
        public Vector2 DisplayPos { get { return NativePtr->DisplayPos; } set { NativePtr->DisplayPos = value; } }
        public Vector2 DisplaySize { get { return NativePtr->DisplaySize; } set { NativePtr->DisplaySize = value; } }
        public Vector2 FramebufferScale { get { return NativePtr->FramebufferScale; } set { NativePtr->FramebufferScale = value; } }
        public ImGuiViewportPtr OwnerViewport => new ImGuiViewportPtr(NativePtr->OwnerViewport);
        public void Clear()
        {
            ImGuiNative.ImDrawData_Clear((ImDrawData*)(NativePtr));
        }
        public void DeIndexAllBuffers()
        {
            ImGuiNative.ImDrawData_DeIndexAllBuffers((ImDrawData*)(NativePtr));
        }
        public void Destroy()
        {
            ImGuiNative.ImDrawData_destroy((ImDrawData*)(NativePtr));
        }
        public void ScaleClipRects(Vector2 fb_scale)
        {
            ImGuiNative.ImDrawData_ScaleClipRects((ImDrawData*)(NativePtr), fb_scale);
        }
    }
}
