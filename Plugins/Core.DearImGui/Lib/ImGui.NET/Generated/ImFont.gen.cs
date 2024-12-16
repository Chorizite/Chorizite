using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImFont
    {
        public ImVector IndexAdvanceX;
        public float FallbackAdvanceX;
        public float FontSize;
        public ImVector IndexLookup;
        public ImVector Glyphs;
        public ImFontGlyph* FallbackGlyph;
        public ImFontAtlas* ContainerAtlas;
        public ImFontConfig* ConfigData;
        public short ConfigDataCount;
        public ushort FallbackChar;
        public ushort EllipsisChar;
        public short EllipsisCharCount;
        public float EllipsisWidth;
        public float EllipsisCharStep;
        public byte DirtyLookupTables;
        public float Scale;
        public float Ascent;
        public float Descent;
        public int MetricsTotalSurface;
        public fixed byte Used4kPagesMap[2];
    }
    public unsafe partial struct ImFontPtr
    {
        public ImFont* NativePtr { get; }
        public ImFontPtr(ImFont* nativePtr) => NativePtr = nativePtr;
        public ImFontPtr(IntPtr nativePtr) => NativePtr = (ImFont*)nativePtr;
        public static implicit operator ImFontPtr(ImFont* nativePtr) => new ImFontPtr(nativePtr);
        public static implicit operator ImFont* (ImFontPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImFontPtr(IntPtr nativePtr) => new ImFontPtr(nativePtr);
        public ImVector<float> IndexAdvanceX => new ImVector<float>(NativePtr->IndexAdvanceX);
        public float FallbackAdvanceX { get { return NativePtr->FallbackAdvanceX; } set { NativePtr->FallbackAdvanceX = value; } }
        public float FontSize { get { return NativePtr->FontSize; } set { NativePtr->FontSize = value; } }
        public ImVector<ushort> IndexLookup => new ImVector<ushort>(NativePtr->IndexLookup);
        public ImPtrVector<ImFontGlyphPtr> Glyphs => new ImPtrVector<ImFontGlyphPtr>(NativePtr->Glyphs, Unsafe.SizeOf<ImFontGlyph>());
        public ImFontGlyphPtr FallbackGlyph => new ImFontGlyphPtr(NativePtr->FallbackGlyph);
        public ImFontAtlasPtr ContainerAtlas => new ImFontAtlasPtr(NativePtr->ContainerAtlas);
        public ImFontConfigPtr ConfigData => new ImFontConfigPtr(NativePtr->ConfigData);
        public short ConfigDataCount { get { return NativePtr->ConfigDataCount; } set { NativePtr->ConfigDataCount = value; } }
        public ushort FallbackChar { get { return NativePtr->FallbackChar; } set { NativePtr->FallbackChar = value; } }
        public ushort EllipsisChar { get { return NativePtr->EllipsisChar; } set { NativePtr->EllipsisChar = value; } }
        public short EllipsisCharCount { get { return NativePtr->EllipsisCharCount; } set { NativePtr->EllipsisCharCount = value; } }
        public float EllipsisWidth { get { return NativePtr->EllipsisWidth; } set { NativePtr->EllipsisWidth = value; } }
        public float EllipsisCharStep { get { return NativePtr->EllipsisCharStep; } set { NativePtr->EllipsisCharStep = value; } }
        public bool DirtyLookupTables { get { return NativePtr->DirtyLookupTables == 1; } set { NativePtr->DirtyLookupTables = value ? (byte)1 : (byte)0; } }
        public float Scale { get { return NativePtr->Scale; } set { NativePtr->Scale = value; } }
        public float Ascent { get { return NativePtr->Ascent; } set { NativePtr->Ascent = value; } }
        public float Descent { get { return NativePtr->Descent; } set { NativePtr->Descent = value; } }
        public int MetricsTotalSurface { get { return NativePtr->MetricsTotalSurface; } set { NativePtr->MetricsTotalSurface = value; } }
        public RangeAccessor<byte> Used4kPagesMap => new RangeAccessor<byte>(NativePtr->Used4kPagesMap, 2);
        public void AddGlyph(ImFontConfigPtr src_cfg, ushort c, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, float advance_x)
        {
            ImFontConfig* native_src_cfg = src_cfg.NativePtr;
            ImGuiNative.ImFont_AddGlyph((ImFont*)(NativePtr), native_src_cfg, c, x0, y0, x1, y1, u0, v0, u1, v1, advance_x);
        }
        public void AddRemapChar(ushort dst, ushort src)
        {
            byte overwrite_dst = 1;
            ImGuiNative.ImFont_AddRemapChar((ImFont*)(NativePtr), dst, src, overwrite_dst);
        }
        public void AddRemapChar(ushort dst, ushort src, bool overwrite_dst)
        {
            byte native_overwrite_dst = overwrite_dst ? (byte)1 : (byte)0;
            ImGuiNative.ImFont_AddRemapChar((ImFont*)(NativePtr), dst, src, native_overwrite_dst);
        }
        public void BuildLookupTable()
        {
            ImGuiNative.ImFont_BuildLookupTable((ImFont*)(NativePtr));
        }
        public void ClearOutputData()
        {
            ImGuiNative.ImFont_ClearOutputData((ImFont*)(NativePtr));
        }
        public void Destroy()
        {
            ImGuiNative.ImFont_destroy((ImFont*)(NativePtr));
        }
        public ImFontGlyphPtr FindGlyph(ushort c)
        {
            ImFontGlyph* ret = ImGuiNative.ImFont_FindGlyph((ImFont*)(NativePtr), c);
            return new ImFontGlyphPtr(ret);
        }
        public ImFontGlyphPtr FindGlyphNoFallback(ushort c)
        {
            ImFontGlyph* ret = ImGuiNative.ImFont_FindGlyphNoFallback((ImFont*)(NativePtr), c);
            return new ImFontGlyphPtr(ret);
        }
        public float GetCharAdvance(ushort c)
        {
            float ret = ImGuiNative.ImFont_GetCharAdvance((ImFont*)(NativePtr), c);
            return ret;
        }
        public string GetDebugName()
        {
            byte* ret = ImGuiNative.ImFont_GetDebugName((ImFont*)(NativePtr));
            return Util.StringFromPtr(ret);
        }
        public void GrowIndex(int new_size)
        {
            ImGuiNative.ImFont_GrowIndex((ImFont*)(NativePtr), new_size);
        }
        public bool IsLoaded()
        {
            byte ret = ImGuiNative.ImFont_IsLoaded((ImFont*)(NativePtr));
            return ret != 0;
        }
        public void RenderChar(ImDrawListPtr draw_list, float size, Vector2 pos, uint col, ushort c)
        {
            ImDrawList* native_draw_list = draw_list.NativePtr;
            ImGuiNative.ImFont_RenderChar((ImFont*)(NativePtr), native_draw_list, size, pos, col, c);
        }
        public void SetGlyphVisible(ushort c, bool visible)
        {
            byte native_visible = visible ? (byte)1 : (byte)0;
            ImGuiNative.ImFont_SetGlyphVisible((ImFont*)(NativePtr), c, native_visible);
        }
    }
}
