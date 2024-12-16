using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiInputTextCallbackData
    {
        public IntPtr Ctx;
        public ImGuiInputTextFlags EventFlag;
        public ImGuiInputTextFlags Flags;
        public void* UserData;
        public ushort EventChar;
        public ImGuiKey EventKey;
        public byte* Buf;
        public int BufTextLen;
        public int BufSize;
        public byte BufDirty;
        public int CursorPos;
        public int SelectionStart;
        public int SelectionEnd;
    }
    public unsafe partial struct ImGuiInputTextCallbackDataPtr
    {
        public ImGuiInputTextCallbackData* NativePtr { get; }
        public ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => NativePtr = nativePtr;
        public ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => NativePtr = (ImGuiInputTextCallbackData*)nativePtr;
        public static implicit operator ImGuiInputTextCallbackDataPtr(ImGuiInputTextCallbackData* nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);
        public static implicit operator ImGuiInputTextCallbackData* (ImGuiInputTextCallbackDataPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiInputTextCallbackDataPtr(IntPtr nativePtr) => new ImGuiInputTextCallbackDataPtr(nativePtr);
        public IntPtr Ctx { get { return NativePtr->Ctx; } set { NativePtr->Ctx = value; } }
        public ImGuiInputTextFlags EventFlag { get { return NativePtr->EventFlag; } set { NativePtr->EventFlag = value; } }
        public ImGuiInputTextFlags Flags { get { return NativePtr->Flags; } set { NativePtr->Flags = value; } }
        public IntPtr UserData { get => (IntPtr)NativePtr->UserData; set => NativePtr->UserData = (void*)value; }
        public ushort EventChar { get { return NativePtr->EventChar; } set { NativePtr->EventChar = value; } }
        public ImGuiKey EventKey { get { return NativePtr->EventKey; } set { NativePtr->EventKey = value; } }
        public IntPtr Buf { get => (IntPtr)NativePtr->Buf; set => NativePtr->Buf = (byte*)value; }
        public int BufTextLen { get { return NativePtr->BufTextLen; } set { NativePtr->BufTextLen = value; } }
        public int BufSize { get { return NativePtr->BufSize; } set { NativePtr->BufSize = value; } }
        public bool BufDirty { get { return NativePtr->BufDirty == 1; } set { NativePtr->BufDirty = value ? (byte)1 : (byte)0; } }
        public int CursorPos { get { return NativePtr->CursorPos; } set { NativePtr->CursorPos = value; } }
        public int SelectionStart { get { return NativePtr->SelectionStart; } set { NativePtr->SelectionStart = value; } }
        public int SelectionEnd { get { return NativePtr->SelectionEnd; } set { NativePtr->SelectionEnd = value; } }
        public void ClearSelection()
        {
            ImGuiNative.ImGuiInputTextCallbackData_ClearSelection((ImGuiInputTextCallbackData*)(NativePtr));
        }
        public void DeleteChars(int pos, int bytes_count)
        {
            ImGuiNative.ImGuiInputTextCallbackData_DeleteChars((ImGuiInputTextCallbackData*)(NativePtr), pos, bytes_count);
        }
        public void Destroy()
        {
            ImGuiNative.ImGuiInputTextCallbackData_destroy((ImGuiInputTextCallbackData*)(NativePtr));
        }
        public bool HasSelection()
        {
            byte ret = ImGuiNative.ImGuiInputTextCallbackData_HasSelection((ImGuiInputTextCallbackData*)(NativePtr));
            return ret != 0;
        }
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP2_1_OR_GREATER
        public void InsertChars(int pos, ReadOnlySpan<char> text)
#else
        public void InsertChars(int pos, string text)
#endif
        {
            byte* native_text;
            int text_byteCount = 0;
            if (text != null)
            {
                text_byteCount = Encoding.UTF8.GetByteCount(text);
                if (text_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_text = Util.Allocate(text_byteCount + 1);
                }
                else
                {
                    byte* native_text_stackBytes = stackalloc byte[text_byteCount + 1];
                    native_text = native_text_stackBytes;
                }
                int native_text_offset = Util.GetUtf8(text, native_text, text_byteCount);
                native_text[native_text_offset] = 0;
            }
            else { native_text = null; }
            byte* native_text_end = null;
            ImGuiNative.ImGuiInputTextCallbackData_InsertChars((ImGuiInputTextCallbackData*)(NativePtr), pos, native_text, native_text_end);
            if (text_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_text);
            }
        }
        public void SelectAll()
        {
            ImGuiNative.ImGuiInputTextCallbackData_SelectAll((ImGuiInputTextCallbackData*)(NativePtr));
        }
    }
}
