using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImFontGlyph
    {
        public uint Colored;
        public uint Visible;
        public uint Codepoint;
        public float AdvanceX;
        public float X0;
        public float Y0;
        public float X1;
        public float Y1;
        public float U0;
        public float V0;
        public float U1;
        public float V1;
    }
    public unsafe partial struct ImFontGlyphPtr
    {
        public ImFontGlyph* NativePtr { get; }
        public ImFontGlyphPtr(ImFontGlyph* nativePtr) => NativePtr = nativePtr;
        public ImFontGlyphPtr(IntPtr nativePtr) => NativePtr = (ImFontGlyph*)nativePtr;
        public static implicit operator ImFontGlyphPtr(ImFontGlyph* nativePtr) => new ImFontGlyphPtr(nativePtr);
        public static implicit operator ImFontGlyph* (ImFontGlyphPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontGlyphPtr(IntPtr nativePtr) => new ImFontGlyphPtr(nativePtr);
        public uint Colored { get { return NativePtr->Colored; } set { NativePtr->Colored = value; } }
        public uint Visible { get { return NativePtr->Visible; } set { NativePtr->Visible = value; } }
        public uint Codepoint { get { return NativePtr->Codepoint; } set { NativePtr->Codepoint = value; } }
        public float AdvanceX { get { return NativePtr->AdvanceX; } set { NativePtr->AdvanceX = value; } }
        public float X0 { get { return NativePtr->X0; } set { NativePtr->X0 = value; } }
        public float Y0 { get { return NativePtr->Y0; } set { NativePtr->Y0 = value; } }
        public float X1 { get { return NativePtr->X1; } set { NativePtr->X1 = value; } }
        public float Y1 { get { return NativePtr->Y1; } set { NativePtr->Y1 = value; } }
        public float U0 { get { return NativePtr->U0; } set { NativePtr->U0 = value; } }
        public float V0 { get { return NativePtr->V0; } set { NativePtr->V0 = value; } }
        public float U1 { get { return NativePtr->U1; } set { NativePtr->U1 = value; } }
        public float V1 { get { return NativePtr->V1; } set { NativePtr->V1 = value; } }
    }
}
