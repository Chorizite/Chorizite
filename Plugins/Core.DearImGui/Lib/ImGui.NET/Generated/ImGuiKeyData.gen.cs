using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiKeyData
    {
        public byte Down;
        public float DownDuration;
        public float DownDurationPrev;
        public float AnalogValue;
    }
    public unsafe partial struct ImGuiKeyDataPtr
    {
        public ImGuiKeyData* NativePtr { get; }
        public ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => NativePtr = nativePtr;
        public ImGuiKeyDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiKeyData*)nativePtr;
        public static implicit operator ImGuiKeyDataPtr(ImGuiKeyData* nativePtr) => new ImGuiKeyDataPtr(nativePtr);
        public static implicit operator ImGuiKeyData* (ImGuiKeyDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiKeyDataPtr(IntPtr nativePtr) => new ImGuiKeyDataPtr(nativePtr);
        public bool Down { get { return NativePtr->Down == 1; } set { NativePtr->Down = value ? (byte)1 : (byte)0; } }
        public float DownDuration { get { return NativePtr->DownDuration; } set { NativePtr->DownDuration = value; } }
        public float DownDurationPrev { get { return NativePtr->DownDurationPrev; } set { NativePtr->DownDurationPrev = value; } }
        public float AnalogValue { get { return NativePtr->AnalogValue; } set { NativePtr->AnalogValue = value; } }
    }
}
