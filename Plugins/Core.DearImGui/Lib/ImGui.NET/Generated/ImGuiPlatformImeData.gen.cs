using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiPlatformImeData
    {
        public byte WantVisible;
        public Vector2 InputPos;
        public float InputLineHeight;
    }
    public unsafe partial struct ImGuiPlatformImeDataPtr
    {
        public ImGuiPlatformImeData* NativePtr { get; }
        public ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr) => NativePtr = nativePtr;
        public ImGuiPlatformImeDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiPlatformImeData*)nativePtr;
        public static implicit operator ImGuiPlatformImeDataPtr(ImGuiPlatformImeData* nativePtr) => new ImGuiPlatformImeDataPtr(nativePtr);
        public static implicit operator ImGuiPlatformImeData* (ImGuiPlatformImeDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiPlatformImeDataPtr(IntPtr nativePtr) => new ImGuiPlatformImeDataPtr(nativePtr);
        public bool WantVisible { get { return NativePtr->WantVisible == 1; } set { NativePtr->WantVisible = value ? (byte)1 : (byte)0; } }
        public Vector2 InputPos { get { return NativePtr->InputPos; } set { NativePtr->InputPos = value; } }
        public float InputLineHeight { get { return NativePtr->InputLineHeight; } set { NativePtr->InputLineHeight = value; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiPlatformImeData_destroy((ImGuiPlatformImeData*)(NativePtr));
        }
    }
}
