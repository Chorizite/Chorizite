using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiTableColumnSortSpecs
    {
        public uint ColumnUserID;
        public short ColumnIndex;
        public short SortOrder;
        public ImGuiSortDirection SortDirection;
    }
    public unsafe partial struct ImGuiTableColumnSortSpecsPtr
    {
        public ImGuiTableColumnSortSpecs* NativePtr { get; }
        public ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => NativePtr = nativePtr;
        public ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => NativePtr = (ImGuiTableColumnSortSpecs*)nativePtr;
        public static implicit operator ImGuiTableColumnSortSpecsPtr(ImGuiTableColumnSortSpecs* nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);
        public static implicit operator ImGuiTableColumnSortSpecs* (ImGuiTableColumnSortSpecsPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiTableColumnSortSpecsPtr(IntPtr nativePtr) => new ImGuiTableColumnSortSpecsPtr(nativePtr);
        public uint ColumnUserID { get { return NativePtr->ColumnUserID; } set { NativePtr->ColumnUserID = value; } }
        public short ColumnIndex { get { return NativePtr->ColumnIndex; } set { NativePtr->ColumnIndex = value; } }
        public short SortOrder { get { return NativePtr->SortOrder; } set { NativePtr->SortOrder = value; } }
        public ImGuiSortDirection SortDirection { get { return NativePtr->SortDirection; } set { NativePtr->SortDirection = value; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiTableColumnSortSpecs_destroy((ImGuiTableColumnSortSpecs*)(NativePtr));
        }
    }
}
