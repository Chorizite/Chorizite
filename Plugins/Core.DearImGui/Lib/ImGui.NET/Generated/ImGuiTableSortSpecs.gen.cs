using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiTableSortSpecs
    {
        public ImGuiTableColumnSortSpecs* Specs;
        public int SpecsCount;
        public byte SpecsDirty;
    }
    public unsafe partial struct ImGuiTableSortSpecsPtr
    {
        public ImGuiTableSortSpecs* NativePtr { get; }
        public ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => NativePtr = nativePtr;
        public ImGuiTableSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableSortSpecs*)nativePtr;
        public static implicit operator ImGuiTableSortSpecsPtr(ImGuiTableSortSpecs* nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);
        public static implicit operator ImGuiTableSortSpecs* (ImGuiTableSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTableSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableSortSpecsPtr(nativePtr);
        public ImGuiTableColumnSortSpecsPtr Specs => new ImGuiTableColumnSortSpecsPtr(NativePtr->Specs);
        public int SpecsCount { get { return NativePtr->SpecsCount; } set { NativePtr->SpecsCount = value; } }
        public bool SpecsDirty { get { return NativePtr->SpecsDirty == 1; } set { NativePtr->SpecsDirty = value ? (byte)1 : (byte)0; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiTableSortSpecs_destroy((ImGuiTableSortSpecs*)(NativePtr));
        }
    }
}
