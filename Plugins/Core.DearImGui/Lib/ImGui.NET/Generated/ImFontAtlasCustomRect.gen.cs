using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImFontAtlasCustomRect
    {
        public ushort Width;
        public ushort Height;
        public ushort X;
        public ushort Y;
        public uint GlyphID;
        public float GlyphAdvanceX;
        public Vector2 GlyphOffset;
        public ImFont* Font;
    }
    public unsafe partial struct ImFontAtlasCustomRectPtr
    {
        public ImFontAtlasCustomRect* NativePtr { get; }
        public ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => NativePtr = nativePtr;
        public ImFontAtlasCustomRectPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlasCustomRect*)nativePtr;
        public static implicit operator ImFontAtlasCustomRectPtr(ImFontAtlasCustomRect* nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);
        public static implicit operator ImFontAtlasCustomRect* (ImFontAtlasCustomRectPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontAtlasCustomRectPtr(IntPtr nativePtr) => new ImFontAtlasCustomRectPtr(nativePtr);
        public ushort Width { get { return NativePtr->Width; } set { NativePtr->Width = value; } }
        public ushort Height { get { return NativePtr->Height; } set { NativePtr->Height = value; } }
        public ushort X { get { return NativePtr->X; } set { NativePtr->X = value; } }
        public ushort Y { get { return NativePtr->Y; } set { NativePtr->Y = value; } }
        public uint GlyphID { get { return NativePtr->GlyphID; } set { NativePtr->GlyphID = value; } }
        public float GlyphAdvanceX { get { return NativePtr->GlyphAdvanceX; } set { NativePtr->GlyphAdvanceX = value; } }
        public Vector2 GlyphOffset { get { return NativePtr->GlyphOffset; } set { NativePtr->GlyphOffset = value; } }
        public ImFontPtr Font => new ImFontPtr(NativePtr->Font);
        public void Destroy()
        {
            ImGuiNative.ImFontAtlasCustomRect_destroy((ImFontAtlasCustomRect*)(NativePtr));
        }
        public bool IsPacked()
        {
            byte ret = ImGuiNative.ImFontAtlasCustomRect_IsPacked((ImFontAtlasCustomRect*)(NativePtr));
            return ret != 0;
        }
    }
}
