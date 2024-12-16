using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImGuiNET
{
    public unsafe partial struct ImGuiStyle
    {
        public float Alpha;
        public float DisabledAlpha;
        public Vector2 WindowPadding;
        public float WindowRounding;
        public float WindowBorderSize;
        public Vector2 WindowMinSize;
        public Vector2 WindowTitleAlign;
        public ImGuiDir WindowMenuButtonPosition;
        public float ChildRounding;
        public float ChildBorderSize;
        public float PopupRounding;
        public float PopupBorderSize;
        public Vector2 FramePadding;
        public float FrameRounding;
        public float FrameBorderSize;
        public Vector2 ItemSpacing;
        public Vector2 ItemInnerSpacing;
        public Vector2 CellPadding;
        public Vector2 TouchExtraPadding;
        public float IndentSpacing;
        public float ColumnsMinSpacing;
        public float ScrollbarSize;
        public float ScrollbarRounding;
        public float GrabMinSize;
        public float GrabRounding;
        public float LogSliderDeadzone;
        public float TabRounding;
        public float TabBorderSize;
        public float TabMinWidthForCloseButton;
        public ImGuiDir ColorButtonPosition;
        public Vector2 ButtonTextAlign;
        public Vector2 SelectableTextAlign;
        public float SeparatorTextBorderSize;
        public Vector2 SeparatorTextAlign;
        public Vector2 SeparatorTextPadding;
        public Vector2 DisplayWindowPadding;
        public Vector2 DisplaySafeAreaPadding;
        public float MouseCursorScale;
        public byte AntiAliasedLines;
        public byte AntiAliasedLinesUseTex;
        public byte AntiAliasedFill;
        public float CurveTessellationTol;
        public float CircleTessellationMaxError;
        public Vector4 Colors_0;
        public Vector4 Colors_1;
        public Vector4 Colors_2;
        public Vector4 Colors_3;
        public Vector4 Colors_4;
        public Vector4 Colors_5;
        public Vector4 Colors_6;
        public Vector4 Colors_7;
        public Vector4 Colors_8;
        public Vector4 Colors_9;
        public Vector4 Colors_10;
        public Vector4 Colors_11;
        public Vector4 Colors_12;
        public Vector4 Colors_13;
        public Vector4 Colors_14;
        public Vector4 Colors_15;
        public Vector4 Colors_16;
        public Vector4 Colors_17;
        public Vector4 Colors_18;
        public Vector4 Colors_19;
        public Vector4 Colors_20;
        public Vector4 Colors_21;
        public Vector4 Colors_22;
        public Vector4 Colors_23;
        public Vector4 Colors_24;
        public Vector4 Colors_25;
        public Vector4 Colors_26;
        public Vector4 Colors_27;
        public Vector4 Colors_28;
        public Vector4 Colors_29;
        public Vector4 Colors_30;
        public Vector4 Colors_31;
        public Vector4 Colors_32;
        public Vector4 Colors_33;
        public Vector4 Colors_34;
        public Vector4 Colors_35;
        public Vector4 Colors_36;
        public Vector4 Colors_37;
        public Vector4 Colors_38;
        public Vector4 Colors_39;
        public Vector4 Colors_40;
        public Vector4 Colors_41;
        public Vector4 Colors_42;
        public Vector4 Colors_43;
        public Vector4 Colors_44;
        public Vector4 Colors_45;
        public Vector4 Colors_46;
        public Vector4 Colors_47;
        public Vector4 Colors_48;
        public Vector4 Colors_49;
        public Vector4 Colors_50;
        public Vector4 Colors_51;
        public Vector4 Colors_52;
        public Vector4 Colors_53;
        public Vector4 Colors_54;
        public float HoverStationaryDelay;
        public float HoverDelayShort;
        public float HoverDelayNormal;
        public ImGuiHoveredFlags HoverFlagsForTooltipMouse;
        public ImGuiHoveredFlags HoverFlagsForTooltipNav;
    }
    public unsafe partial struct ImGuiStylePtr
    {
        public ImGuiStyle* NativePtr { get; }
        public ImGuiStylePtr(ImGuiStyle* nativePtr) => NativePtr = nativePtr;
        public ImGuiStylePtr(IntPtr nativePtr) => NativePtr = (ImGuiStyle*)nativePtr;
        public static implicit operator ImGuiStylePtr(ImGuiStyle* nativePtr) => new ImGuiStylePtr(nativePtr);
        public static implicit operator ImGuiStyle* (ImGuiStylePtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ImGuiStylePtr(IntPtr nativePtr) => new ImGuiStylePtr(nativePtr);
        public float Alpha { get { return NativePtr->Alpha; } set { NativePtr->Alpha = value; } }
        public float DisabledAlpha { get { return NativePtr->DisabledAlpha; } set { NativePtr->DisabledAlpha = value; } }
        public Vector2 WindowPadding { get { return NativePtr->WindowPadding; } set { NativePtr->WindowPadding = value; } }
        public float WindowRounding { get { return NativePtr->WindowRounding; } set { NativePtr->WindowRounding = value; } }
        public float WindowBorderSize { get { return NativePtr->WindowBorderSize; } set { NativePtr->WindowBorderSize = value; } }
        public Vector2 WindowMinSize { get { return NativePtr->WindowMinSize; } set { NativePtr->WindowMinSize = value; } }
        public Vector2 WindowTitleAlign { get { return NativePtr->WindowTitleAlign; } set { NativePtr->WindowTitleAlign = value; } }
        public ImGuiDir WindowMenuButtonPosition { get { return NativePtr->WindowMenuButtonPosition; } set { NativePtr->WindowMenuButtonPosition = value; } }
        public float ChildRounding { get { return NativePtr->ChildRounding; } set { NativePtr->ChildRounding = value; } }
        public float ChildBorderSize { get { return NativePtr->ChildBorderSize; } set { NativePtr->ChildBorderSize = value; } }
        public float PopupRounding { get { return NativePtr->PopupRounding; } set { NativePtr->PopupRounding = value; } }
        public float PopupBorderSize { get { return NativePtr->PopupBorderSize; } set { NativePtr->PopupBorderSize = value; } }
        public Vector2 FramePadding { get { return NativePtr->FramePadding; } set { NativePtr->FramePadding = value; } }
        public float FrameRounding { get { return NativePtr->FrameRounding; } set { NativePtr->FrameRounding = value; } }
        public float FrameBorderSize { get { return NativePtr->FrameBorderSize; } set { NativePtr->FrameBorderSize = value; } }
        public Vector2 ItemSpacing { get { return NativePtr->ItemSpacing; } set { NativePtr->ItemSpacing = value; } }
        public Vector2 ItemInnerSpacing { get { return NativePtr->ItemInnerSpacing; } set { NativePtr->ItemInnerSpacing = value; } }
        public Vector2 CellPadding { get { return NativePtr->CellPadding; } set { NativePtr->CellPadding = value; } }
        public Vector2 TouchExtraPadding { get { return NativePtr->TouchExtraPadding; } set { NativePtr->TouchExtraPadding = value; } }
        public float IndentSpacing { get { return NativePtr->IndentSpacing; } set { NativePtr->IndentSpacing = value; } }
        public float ColumnsMinSpacing { get { return NativePtr->ColumnsMinSpacing; } set { NativePtr->ColumnsMinSpacing = value; } }
        public float ScrollbarSize { get { return NativePtr->ScrollbarSize; } set { NativePtr->ScrollbarSize = value; } }
        public float ScrollbarRounding { get { return NativePtr->ScrollbarRounding; } set { NativePtr->ScrollbarRounding = value; } }
        public float GrabMinSize { get { return NativePtr->GrabMinSize; } set { NativePtr->GrabMinSize = value; } }
        public float GrabRounding { get { return NativePtr->GrabRounding; } set { NativePtr->GrabRounding = value; } }
        public float LogSliderDeadzone { get { return NativePtr->LogSliderDeadzone; } set { NativePtr->LogSliderDeadzone = value; } }
        public float TabRounding { get { return NativePtr->TabRounding; } set { NativePtr->TabRounding = value; } }
        public float TabBorderSize { get { return NativePtr->TabBorderSize; } set { NativePtr->TabBorderSize = value; } }
        public float TabMinWidthForCloseButton { get { return NativePtr->TabMinWidthForCloseButton; } set { NativePtr->TabMinWidthForCloseButton = value; } }
        public ImGuiDir ColorButtonPosition { get { return NativePtr->ColorButtonPosition; } set { NativePtr->ColorButtonPosition = value; } }
        public Vector2 ButtonTextAlign { get { return NativePtr->ButtonTextAlign; } set { NativePtr->ButtonTextAlign = value; } }
        public Vector2 SelectableTextAlign { get { return NativePtr->SelectableTextAlign; } set { NativePtr->SelectableTextAlign = value; } }
        public float SeparatorTextBorderSize { get { return NativePtr->SeparatorTextBorderSize; } set { NativePtr->SeparatorTextBorderSize = value; } }
        public Vector2 SeparatorTextAlign { get { return NativePtr->SeparatorTextAlign; } set { NativePtr->SeparatorTextAlign = value; } }
        public Vector2 SeparatorTextPadding { get { return NativePtr->SeparatorTextPadding; } set { NativePtr->SeparatorTextPadding = value; } }
        public Vector2 DisplayWindowPadding { get { return NativePtr->DisplayWindowPadding; } set { NativePtr->DisplayWindowPadding = value; } }
        public Vector2 DisplaySafeAreaPadding { get { return NativePtr->DisplaySafeAreaPadding; } set { NativePtr->DisplaySafeAreaPadding = value; } }
        public float MouseCursorScale { get { return NativePtr->MouseCursorScale; } set { NativePtr->MouseCursorScale = value; } }
        public bool AntiAliasedLines { get { return NativePtr->AntiAliasedLines == 1; } set { NativePtr->AntiAliasedLines = value ? (byte)1 : (byte)0; } }
        public bool AntiAliasedLinesUseTex { get { return NativePtr->AntiAliasedLinesUseTex == 1; } set { NativePtr->AntiAliasedLinesUseTex = value ? (byte)1 : (byte)0; } }
        public bool AntiAliasedFill { get { return NativePtr->AntiAliasedFill == 1; } set { NativePtr->AntiAliasedFill = value ? (byte)1 : (byte)0; } }
        public float CurveTessellationTol { get { return NativePtr->CurveTessellationTol; } set { NativePtr->CurveTessellationTol = value; } }
        public float CircleTessellationMaxError { get { return NativePtr->CircleTessellationMaxError; } set { NativePtr->CircleTessellationMaxError = value; } }
        public RangeAccessor<Vector4> Colors => new RangeAccessor<Vector4>(&NativePtr->Colors_0, 55);
        public float HoverStationaryDelay { get { return NativePtr->HoverStationaryDelay; } set { NativePtr->HoverStationaryDelay = value; } }
        public float HoverDelayShort { get { return NativePtr->HoverDelayShort; } set { NativePtr->HoverDelayShort = value; } }
        public float HoverDelayNormal { get { return NativePtr->HoverDelayNormal; } set { NativePtr->HoverDelayNormal = value; } }
        public ImGuiHoveredFlags HoverFlagsForTooltipMouse { get { return NativePtr->HoverFlagsForTooltipMouse; } set { NativePtr->HoverFlagsForTooltipMouse = value; } }
        public ImGuiHoveredFlags HoverFlagsForTooltipNav { get { return NativePtr->HoverFlagsForTooltipNav; } set { NativePtr->HoverFlagsForTooltipNav = value; } }
        public void Destroy()
        {
            ImGuiNative.ImGuiStyle_destroy((ImGuiStyle*)(NativePtr));
        }
        public void ScaleAllSizes(float scale_factor)
        {
            ImGuiNative.ImGuiStyle_ScaleAllSizes((ImGuiStyle*)(NativePtr), scale_factor);
        }
    }
}
