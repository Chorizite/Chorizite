using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImFontConfig
    {
        public void* FontData;
        public int FontDataSize;
        public byte FontDataOwnedByAtlas;
        public int FontNo;
        public float SizePixels;
        public int OversampleH;
        public int OversampleV;
        public byte PixelSnapH;
        public Vector2 GlyphExtraSpacing;
        public Vector2 GlyphOffset;
        public ushort* GlyphRanges;
        public float GlyphMinAdvanceX;
        public float GlyphMaxAdvanceX;
        public byte MergeMode;
        public uint FontBuilderFlags;
        public float RasterizerMultiply;
        public ushort EllipsisChar;
        public fixed byte Name[40];
        public ImFont* DstFont;
    }
    public unsafe partial struct ImFontConfigPtr
    {
        public ImFontConfig* NativePtr { get; }
        public ImFontConfigPtr(ImFontConfig* nativePtr) => NativePtr = nativePtr;
        public ImFontConfigPtr(IntPtr nativePtr) => NativePtr = (ImFontConfig*)nativePtr;
        public static implicit operator ImFontConfigPtr(ImFontConfig* nativePtr) => new ImFontConfigPtr(nativePtr);
        public static implicit operator ImFontConfig* (ImFontConfigPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontConfigPtr(IntPtr nativePtr) => new ImFontConfigPtr(nativePtr);
        public IntPtr FontData { get => (IntPtr)NativePtr->FontData; set => NativePtr->FontData = (void*)value; }
        public int FontDataSize { get { return NativePtr->FontDataSize; } set { NativePtr->FontDataSize = value; } }
        public bool FontDataOwnedByAtlas { get { return NativePtr->FontDataOwnedByAtlas == 1; } set { NativePtr->FontDataOwnedByAtlas = value ? (byte)1 : (byte)0; } }
        public int FontNo { get { return NativePtr->FontNo; } set { NativePtr->FontNo = value; } }
        public float SizePixels { get { return NativePtr->SizePixels; } set { NativePtr->SizePixels = value; } }
        public int OversampleH { get { return NativePtr->OversampleH; } set { NativePtr->OversampleH = value; } }
        public int OversampleV { get { return NativePtr->OversampleV; } set { NativePtr->OversampleV = value; } }
        public bool PixelSnapH { get { return NativePtr->PixelSnapH == 1; } set { NativePtr->PixelSnapH = value ? (byte)1 : (byte)0; } }
        public Vector2 GlyphExtraSpacing { get { return NativePtr->GlyphExtraSpacing; } set { NativePtr->GlyphExtraSpacing = value; } }
        public Vector2 GlyphOffset { get { return NativePtr->GlyphOffset; } set { NativePtr->GlyphOffset = value; } }
        public IntPtr GlyphRanges { get => (IntPtr)NativePtr->GlyphRanges; set => NativePtr->GlyphRanges = (ushort*)value; }
        public float GlyphMinAdvanceX { get { return NativePtr->GlyphMinAdvanceX; } set { NativePtr->GlyphMinAdvanceX = value; } }
        public float GlyphMaxAdvanceX { get { return NativePtr->GlyphMaxAdvanceX; } set { NativePtr->GlyphMaxAdvanceX = value; } }
        public bool MergeMode { get { return NativePtr->MergeMode == 1; } set { NativePtr->MergeMode = value ? (byte)1 : (byte)0; } }
        public uint FontBuilderFlags { get { return NativePtr->FontBuilderFlags; } set { NativePtr->FontBuilderFlags = value; } }
        public float RasterizerMultiply { get { return NativePtr->RasterizerMultiply; } set { NativePtr->RasterizerMultiply = value; } }
        public ushort EllipsisChar { get { return NativePtr->EllipsisChar; } set { NativePtr->EllipsisChar = value; } }
        public RangeAccessor<byte> Name => new RangeAccessor<byte>(NativePtr->Name, 40);
        public ImFontPtr DstFont => new ImFontPtr(NativePtr->DstFont);
        public void Destroy()
        {
            ImGuiNative.ImFontConfig_destroy((ImFontConfig*)(NativePtr));
        }
    }
}
