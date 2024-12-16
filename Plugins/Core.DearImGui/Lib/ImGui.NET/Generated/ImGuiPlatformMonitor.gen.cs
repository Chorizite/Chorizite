using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiPlatformMonitor
    {
        public Vector2 MainPos;
        public Vector2 MainSize;
        public Vector2 WorkPos;
        public Vector2 WorkSize;
        public float DpiScale;
        public void* PlatformHandle;
    }
    public unsafe partial struct ImGuiPlatformMonitorPtr
    {
        public ImGuiPlatformMonitor* NativePtr { get; }
        public ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => NativePtr = nativePtr;
        public ImGuiPlatformMonitorPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformMonitor*)nativePtr;
        public static implicit operator ImGuiPlatformMonitorPtr(ImGuiPlatformMonitor* nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);
        public static implicit operator ImGuiPlatformMonitor* (ImGuiPlatformMonitorPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiPlatformMonitorPtr(IntPtr nativePtr) => new ImGuiPlatformMonitorPtr(nativePtr);
        public Vector2 MainPos { get { return NativePtr->MainPos; } set { NativePtr->MainPos = value; } }
        public Vector2 MainSize { get { return NativePtr->MainSize; } set { NativePtr->MainSize = value; } }
        public Vector2 WorkPos { get { return NativePtr->WorkPos; } set { NativePtr->WorkPos = value; } }
        public Vector2 WorkSize { get { return NativePtr->WorkSize; } set { NativePtr->WorkSize = value; } }
        public float DpiScale { get { return NativePtr->DpiScale; } set { NativePtr->DpiScale = value; } }
        public IntPtr PlatformHandle { get => (IntPtr)NativePtr->PlatformHandle; set => NativePtr->PlatformHandle = (void*)value; }
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformMonitor_destroy((ImGuiPlatformMonitor*)(NativePtr));
        }
    }
}
