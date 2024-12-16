using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiListClipper
    {
        public IntPtr Ctx;
        public int DisplayStart;
        public int DisplayEnd;
        public int ItemsCount;
        public float ItemsHeight;
        public float StartPosY;
        public void* TempData;
    }
    public unsafe partial struct ImGuiListClipperPtr
    {
        public ImGuiListClipper* NativePtr { get; }
        public ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => NativePtr = nativePtr;
        public ImGuiListClipperPtr(IntPtr nativePtr) => NativePtr = (ImGuiListClipper*)nativePtr;
        public static implicit operator ImGuiListClipperPtr(ImGuiListClipper* nativePtr) => new ImGuiListClipperPtr(nativePtr);
        public static implicit operator ImGuiListClipper* (ImGuiListClipperPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiListClipperPtr(IntPtr nativePtr) => new ImGuiListClipperPtr(nativePtr);
        public IntPtr Ctx { get { return NativePtr->Ctx; } set { NativePtr->Ctx = value; } }
        public int DisplayStart { get { return NativePtr->DisplayStart; } set { NativePtr->DisplayStart = value; } }
        public int DisplayEnd { get { return NativePtr->DisplayEnd; } set { NativePtr->DisplayEnd = value; } }
        public int ItemsCount { get { return NativePtr->ItemsCount; } set { NativePtr->ItemsCount = value; } }
        public float ItemsHeight { get { return NativePtr->ItemsHeight; } set { NativePtr->ItemsHeight = value; } }
        public float StartPosY { get { return NativePtr->StartPosY; } set { NativePtr->StartPosY = value; } }
        public IntPtr TempData { get => (IntPtr)NativePtr->TempData; set => NativePtr->TempData = (void*)value; }
        public void Begin(int items_count)
        {
            float items_height = -1.0f;
            ImGuiNative.ImGuiListClipper_Begin((ImGuiListClipper*)(NativePtr), items_count, items_height);
        }
        public void Begin(int items_count, float items_height)
        {
            ImGuiNative.ImGuiListClipper_Begin((ImGuiListClipper*)(NativePtr), items_count, items_height);
        }
        public void Destroy()
        {
            ImGuiNative.ImGuiListClipper_destroy((ImGuiListClipper*)(NativePtr));
        }
        public void End()
        {
            ImGuiNative.ImGuiListClipper_End((ImGuiListClipper*)(NativePtr));
        }
        public bool Step()
        {
            byte ret = ImGuiNative.ImGuiListClipper_Step((ImGuiListClipper*)(NativePtr));
            return ret != 0;
        }
    }
}
