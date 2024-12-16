using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiPlatformIO
    {
        public IntPtr Platform_CreateWindow;
        public IntPtr Platform_DestroyWindow;
        public IntPtr Platform_ShowWindow;
        public IntPtr Platform_SetWindowPos;
        public IntPtr Platform_GetWindowPos;
        public IntPtr Platform_SetWindowSize;
        public IntPtr Platform_GetWindowSize;
        public IntPtr Platform_SetWindowFocus;
        public IntPtr Platform_GetWindowFocus;
        public IntPtr Platform_GetWindowMinimized;
        public IntPtr Platform_SetWindowTitle;
        public IntPtr Platform_SetWindowAlpha;
        public IntPtr Platform_UpdateWindow;
        public IntPtr Platform_RenderWindow;
        public IntPtr Platform_SwapBuffers;
        public IntPtr Platform_GetWindowDpiScale;
        public IntPtr Platform_OnChangedViewport;
        public IntPtr Platform_CreateVkSurface;
        public IntPtr Renderer_CreateWindow;
        public IntPtr Renderer_DestroyWindow;
        public IntPtr Renderer_SetWindowSize;
        public IntPtr Renderer_RenderWindow;
        public IntPtr Renderer_SwapBuffers;
        public ImVector Monitors;
        public ImVector Viewports;
    }
    public unsafe partial struct ImGuiPlatformIOPtr
    {
        public ImGuiPlatformIO* NativePtr { get; }
        public ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => NativePtr = nativePtr;
        public ImGuiPlatformIOPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformIO*)nativePtr;
        public static implicit operator ImGuiPlatformIOPtr(ImGuiPlatformIO* nativePtr) => new ImGuiPlatformIOPtr(nativePtr);
        public static implicit operator ImGuiPlatformIO* (ImGuiPlatformIOPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiPlatformIOPtr(IntPtr nativePtr) => new ImGuiPlatformIOPtr(nativePtr);
        public IntPtr Platform_CreateWindow { get { return NativePtr->Platform_CreateWindow; } set { NativePtr->Platform_CreateWindow = value; } }
        public IntPtr Platform_DestroyWindow { get { return NativePtr->Platform_DestroyWindow; } set { NativePtr->Platform_DestroyWindow = value; } }
        public IntPtr Platform_ShowWindow { get { return NativePtr->Platform_ShowWindow; } set { NativePtr->Platform_ShowWindow = value; } }
        public IntPtr Platform_SetWindowPos { get { return NativePtr->Platform_SetWindowPos; } set { NativePtr->Platform_SetWindowPos = value; } }
        public IntPtr Platform_GetWindowPos { get { return NativePtr->Platform_GetWindowPos; } set { NativePtr->Platform_GetWindowPos = value; } }
        public IntPtr Platform_SetWindowSize { get { return NativePtr->Platform_SetWindowSize; } set { NativePtr->Platform_SetWindowSize = value; } }
        public IntPtr Platform_GetWindowSize { get { return NativePtr->Platform_GetWindowSize; } set { NativePtr->Platform_GetWindowSize = value; } }
        public IntPtr Platform_SetWindowFocus { get { return NativePtr->Platform_SetWindowFocus; } set { NativePtr->Platform_SetWindowFocus = value; } }
        public IntPtr Platform_GetWindowFocus { get { return NativePtr->Platform_GetWindowFocus; } set { NativePtr->Platform_GetWindowFocus = value; } }
        public IntPtr Platform_GetWindowMinimized { get { return NativePtr->Platform_GetWindowMinimized; } set { NativePtr->Platform_GetWindowMinimized = value; } }
        public IntPtr Platform_SetWindowTitle { get { return NativePtr->Platform_SetWindowTitle; } set { NativePtr->Platform_SetWindowTitle = value; } }
        public IntPtr Platform_SetWindowAlpha { get { return NativePtr->Platform_SetWindowAlpha; } set { NativePtr->Platform_SetWindowAlpha = value; } }
        public IntPtr Platform_UpdateWindow { get { return NativePtr->Platform_UpdateWindow; } set { NativePtr->Platform_UpdateWindow = value; } }
        public IntPtr Platform_RenderWindow { get { return NativePtr->Platform_RenderWindow; } set { NativePtr->Platform_RenderWindow = value; } }
        public IntPtr Platform_SwapBuffers { get { return NativePtr->Platform_SwapBuffers; } set { NativePtr->Platform_SwapBuffers = value; } }
        public IntPtr Platform_GetWindowDpiScale { get { return NativePtr->Platform_GetWindowDpiScale; } set { NativePtr->Platform_GetWindowDpiScale = value; } }
        public IntPtr Platform_OnChangedViewport { get { return NativePtr->Platform_OnChangedViewport; } set { NativePtr->Platform_OnChangedViewport = value; } }
        public IntPtr Platform_CreateVkSurface { get { return NativePtr->Platform_CreateVkSurface; } set { NativePtr->Platform_CreateVkSurface = value; } }
        public IntPtr Renderer_CreateWindow { get { return NativePtr->Renderer_CreateWindow; } set { NativePtr->Renderer_CreateWindow = value; } }
        public IntPtr Renderer_DestroyWindow { get { return NativePtr->Renderer_DestroyWindow; } set { NativePtr->Renderer_DestroyWindow = value; } }
        public IntPtr Renderer_SetWindowSize { get { return NativePtr->Renderer_SetWindowSize; } set { NativePtr->Renderer_SetWindowSize = value; } }
        public IntPtr Renderer_RenderWindow { get { return NativePtr->Renderer_RenderWindow; } set { NativePtr->Renderer_RenderWindow = value; } }
        public IntPtr Renderer_SwapBuffers { get { return NativePtr->Renderer_SwapBuffers; } set { NativePtr->Renderer_SwapBuffers = value; } }
        public ImPtrVector<ImGuiPlatformMonitorPtr> Monitors => new ImPtrVector<ImGuiPlatformMonitorPtr>(NativePtr->Monitors, Unsafe.SizeOf<ImGuiPlatformMonitor>());
        public ImVector<ImGuiViewportPtr> Viewports => new ImVector<ImGuiViewportPtr>(NativePtr->Viewports);
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformIO_destroy((ImGuiPlatformIO*)(NativePtr));
        }
    }
}
