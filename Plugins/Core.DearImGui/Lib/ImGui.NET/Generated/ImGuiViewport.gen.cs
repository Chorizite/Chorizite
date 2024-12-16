using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiViewport
    {
        public uint ID;
        public ImGuiViewportFlags Flags;
        public Vector2 Pos;
        public Vector2 Size;
        public Vector2 WorkPos;
        public Vector2 WorkSize;
        public float DpiScale;
        public uint ParentViewportId;
        public ImDrawData* DrawData;
        public void* RendererUserData;
        public void* PlatformUserData;
        public void* PlatformHandle;
        public void* PlatformHandleRaw;
        public byte PlatformWindowCreated;
        public byte PlatformRequestMove;
        public byte PlatformRequestResize;
        public byte PlatformRequestClose;
    }
    public unsafe partial struct ImGuiViewportPtr
    {
        public ImGuiViewport* NativePtr { get; }
        public ImGuiViewportPtr(ImGuiViewport* nativePtr) => NativePtr = nativePtr;
        public ImGuiViewportPtr(IntPtr nativePtr) => NativePtr = (ImGuiViewport*)nativePtr;
        public static implicit operator ImGuiViewportPtr(ImGuiViewport* nativePtr) => new ImGuiViewportPtr(nativePtr);
        public static implicit operator ImGuiViewport* (ImGuiViewportPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiViewportPtr(IntPtr nativePtr) => new ImGuiViewportPtr(nativePtr);
        public uint ID { get { return NativePtr->ID; } set { NativePtr->ID = value; } }
        public ImGuiViewportFlags Flags { get { return NativePtr->Flags; } set { NativePtr->Flags = value; } }
        public Vector2 Pos { get { return NativePtr->Pos; } set { NativePtr->Pos = value; } }
        public Vector2 Size { get { return NativePtr->Size; } set { NativePtr->Size = value; } }
        public Vector2 WorkPos { get { return NativePtr->WorkPos; } set { NativePtr->WorkPos = value; } }
        public Vector2 WorkSize { get { return NativePtr->WorkSize; } set { NativePtr->WorkSize = value; } }
        public float DpiScale { get { return NativePtr->DpiScale; } set { NativePtr->DpiScale = value; } }
        public uint ParentViewportId { get { return NativePtr->ParentViewportId; } set { NativePtr->ParentViewportId = value; } }
        public ImDrawDataPtr DrawData => new ImDrawDataPtr(NativePtr->DrawData);
        public IntPtr RendererUserData { get => (IntPtr)NativePtr->RendererUserData; set => NativePtr->RendererUserData = (void*)value; }
        public IntPtr PlatformUserData { get => (IntPtr)NativePtr->PlatformUserData; set => NativePtr->PlatformUserData = (void*)value; }
        public IntPtr PlatformHandle { get => (IntPtr)NativePtr->PlatformHandle; set => NativePtr->PlatformHandle = (void*)value; }
        public IntPtr PlatformHandleRaw { get => (IntPtr)NativePtr->PlatformHandleRaw; set => NativePtr->PlatformHandleRaw = (void*)value; }
        public bool PlatformWindowCreated { get { return NativePtr->PlatformWindowCreated == 1; } set { NativePtr->PlatformWindowCreated = value ? (byte)1 : (byte)0; } }
        public bool PlatformRequestMove { get { return NativePtr->PlatformRequestMove == 1; } set { NativePtr->PlatformRequestMove = value ? (byte)1 : (byte)0; } }
        public bool PlatformRequestResize { get { return NativePtr->PlatformRequestResize == 1; } set { NativePtr->PlatformRequestResize = value ? (byte)1 : (byte)0; } }
        public bool PlatformRequestClose { get { return NativePtr->PlatformRequestClose == 1; } set { NativePtr->PlatformRequestClose = value ? (byte)1 : (byte)0; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiViewport_destroy((ImGuiViewport*)(NativePtr));
        }
        public Vector2 GetCenter()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetCenter(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
        public Vector2 GetWorkCenter()
        {
            Vector2 __retval;
            ImGuiNative.ImGuiViewport_GetWorkCenter(&__retval, (ImGuiViewport*)(NativePtr));
            return __retval;
        }
    }
}
