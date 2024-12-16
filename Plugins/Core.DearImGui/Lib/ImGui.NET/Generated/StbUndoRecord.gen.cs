using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct StbUndoRecord
    {
        public int where;
        public int insert_length;
        public int delete_length;
        public int char_storage;
    }
    public unsafe partial struct StbUndoRecordPtr
    {
        public StbUndoRecord* NativePtr { get; }
        public StbUndoRecordPtr(StbUndoRecord* nativePtr) => NativePtr = nativePtr;
        public StbUndoRecordPtr(IntPtr nativePtr) => NativePtr = (StbUndoRecord*)nativePtr;
        public static implicit operator StbUndoRecordPtr(StbUndoRecord* nativePtr) => new StbUndoRecordPtr(nativePtr);
        public static implicit operator StbUndoRecord* (StbUndoRecordPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator StbUndoRecordPtr(IntPtr nativePtr) => new StbUndoRecordPtr(nativePtr);
        public int where { get { return NativePtr->where; } set { NativePtr->where = value; } }
        public int insert_length { get { return NativePtr->insert_length; } set { NativePtr->insert_length = value; } }
        public int delete_length { get { return NativePtr->delete_length; } set { NativePtr->delete_length = value; } }
        public int char_storage { get { return NativePtr->char_storage; } set { NativePtr->char_storage = value; } }
    }
}
