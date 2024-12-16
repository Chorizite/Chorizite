using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct STB_TexteditState
    {
        public int cursor;
        public int select_start;
        public int select_end;
        public byte insert_mode;
        public int row_count_per_page;
        public byte cursor_at_end_of_line;
        public byte initialized;
        public byte has_preferred_x;
        public byte single_line;
        public byte padding1;
        public byte padding2;
        public byte padding3;
        public float preferred_x;
        public StbUndoState undostate;
    }
    public unsafe partial struct STB_TexteditStatePtr
    {
        public STB_TexteditState* NativePtr { get; }
        public STB_TexteditStatePtr(STB_TexteditState* nativePtr) => NativePtr = nativePtr;
        public STB_TexteditStatePtr(IntPtr nativePtr) => NativePtr = (STB_TexteditState*)nativePtr;
        public static implicit operator STB_TexteditStatePtr(STB_TexteditState* nativePtr) => new STB_TexteditStatePtr(nativePtr);
        public static implicit operator STB_TexteditState* (STB_TexteditStatePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator STB_TexteditStatePtr(IntPtr nativePtr) => new STB_TexteditStatePtr(nativePtr);
        public int cursor { get { return NativePtr->cursor; } set { NativePtr->cursor = value; } }
        public int select_start { get { return NativePtr->select_start; } set { NativePtr->select_start = value; } }
        public int select_end { get { return NativePtr->select_end; } set { NativePtr->select_end = value; } }
        public byte insert_mode { get { return NativePtr->insert_mode; } set { NativePtr->insert_mode = value; } }
        public int row_count_per_page { get { return NativePtr->row_count_per_page; } set { NativePtr->row_count_per_page = value; } }
        public byte cursor_at_end_of_line { get { return NativePtr->cursor_at_end_of_line; } set { NativePtr->cursor_at_end_of_line = value; } }
        public byte initialized { get { return NativePtr->initialized; } set { NativePtr->initialized = value; } }
        public byte has_preferred_x { get { return NativePtr->has_preferred_x; } set { NativePtr->has_preferred_x = value; } }
        public byte single_line { get { return NativePtr->single_line; } set { NativePtr->single_line = value; } }
        public byte padding1 { get { return NativePtr->padding1; } set { NativePtr->padding1 = value; } }
        public byte padding2 { get { return NativePtr->padding2; } set { NativePtr->padding2 = value; } }
        public byte padding3 { get { return NativePtr->padding3; } set { NativePtr->padding3 = value; } }
        public float preferred_x { get { return NativePtr->preferred_x; } set { NativePtr->preferred_x = value; } }
        public StbUndoState undostate { get { return NativePtr->undostate; } set { NativePtr->undostate = value; } }
    }
}
