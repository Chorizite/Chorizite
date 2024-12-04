using System;
using System.Runtime.InteropServices;

namespace AcClient {

    // public  () => ((def_)Marshal.GetDelegateForFunctionPointer((IntPtr)0x, typeof(def_)))(This, ); // 
    // [UnmanagedFunctionPointer(CallingConvention.ThisCall)] internal delegate  def_(* This, ); // 

    public unsafe struct UIRegion { // EOR client: 0x1A0
        public UIListener uIListener; // 0x00
        public Box2D m_box; // 0x7C
        public tagPOINT m_ptTilingOffset; // 0x8C
        public Int32 m_zlevel; // 0x94
        public Graphic* m_image; // 0x98
        public Graphic* m_alphaImage; //0x9C
        public Single m_alphaBlendMod; //0xA0
        public UInt32 m_Flags; //0xA4
        /*
            public U__Int32 m_mouseOverTop : 1;
            public U__Int32 m_visible : 1;
            public U__Int32 m_transparent : 1;
            public U__Int32 m_bEraseBackground : 1;
            public U__Int32 m_mouseOver : 1;
            public U__Int32 m_bTooltip : 1;
            public U__Int32 m_bBlockClicks : 1;
            public U__Int32 m_bDrawAfterChildren : 1;
        */
        public BlitMode m_eBlitMode; //0xA8
        public UIRegion* m_parent; //0xAC
        public UIObject* m_object; //0xB0
        public HashList<Int32, Int32> m_children; // 0xB4
        public HashSet<UInt32> m_mouseDownTable; // 0x190
        public override string ToString() => $"UIListener(UIListener):{uIListener}, m_box(Box2D):{m_box}, m_ptTilingOffset(tagPOINT):{m_ptTilingOffset}, m_zlevel:{m_zlevel}, m_image:->(Graphic*)0x{(Int32)m_image:X8}, m_alphaImage:->(Graphic*)0x{(Int32)m_alphaImage:X8}, m_alphaBlendMod:{m_alphaBlendMod:n5}, m_Flags:{m_Flags:X8}, m_eBlitMode(BlitMode):{m_eBlitMode}, m_parent:->(UIRegion*)0x{(Int32)m_parent:X8}, m_object:->(UIObject*)0x{(Int32)m_object:X8}, m_children(HashList<UIRegion*,UIRegion*>):{m_children}, m_mouseDownTable(HashSet<UInt32>):{m_mouseDownTable}";


        // Functions:

        // UIRegion.SetShouldEraseBackground:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> SetShouldEraseBackground = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x00464A80; // .text:00464950 ; void __thiscall UIRegion::SetShouldEraseBackground(UIRegion *this, bool i_bErase) .text:00464950 ?SetShouldEraseBackground@UIRegion@@UAEX_N@Z

        // UIRegion.BringToFront:
        // public static delegate* unmanaged[Thiscall]<UIRegion*> BringToFront = (delegate* unmanaged[Thiscall]<UIRegion*>)0xDEADBEEF; // .text:0069EE20 ; void __thiscall UIRegion::BringToFront(UIRegion *this) .text:0069EE20 ?BringToFront@UIRegion@@QAEXXZ

        // UIRegion.GetSurfaceBox:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*> GetSurfaceBox = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*>)0x0069FDA0; // .text:0069EF20 ; Box2D *__thiscall UIRegion::GetSurfaceBox(UIRegion *this, Box2D *result) .text:0069EF20 ?GetSurfaceBox@UIRegion@@UBE?AVBox2D@@XZ

        // UIRegion.GetWidth:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetWidth = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0x0069FE60; // .text:0069EFE0 ; Int32 __thiscall UIRegion::GetWidth(UIRegion *this) .text:0069EFE0 ?GetWidth@UIRegion@@QBEJXZ

        // UIRegion.PoInt32IsOverRegion:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Int32,Int32, Byte> PoInt32IsOverRegion = (delegate* unmanaged[Thiscall]<UIRegion*,Int32,Int32, Byte>)0xDEADBEEF; // .text:0069EE40 ; bool __thiscall UIRegion::PoInt32IsOverRegion(UIRegion *this, Int32 i_xParent, Int32 i_yParent) .text:0069EE40 ?PoInt32IsOverRegion@UIRegion@@QBE_NJJ@Z

        // UIRegion.GetObjectY0:
        // public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetObjectY0 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0xDEADBEEF; // .text:0069EEF0 ; Int32 __thiscall UIRegion::GetObjectY0(UIRegion *this) .text:0069EEF0 ?GetObjectY0@UIRegion@@QBEJXZ

        // UIRegion.GetObjectBox:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*> GetObjectBox = (delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*>)0xDEADBEEF; // .text:0069F280 ; Box2D *__thiscall UIRegion::GetObjectBox(UIRegion *this, Box2D *result) .text:0069F280 ?GetObjectBox@UIRegion@@QBE?AVBox2D@@XZ

        // UIRegion.GetClipBox:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*> GetClipBox = (delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*>)0xDEADBEEF; // .text:0069F3C0 ; Box2D *__thiscall UIRegion::GetClipBox(UIRegion *this, Box2D *result) .text:0069F3C0 ?GetClipBox@UIRegion@@IBE?AVBox2D@@XZ

        // UIRegion.SetImage:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Graphic*> SetImage = (delegate* unmanaged[Thiscall]<UIRegion*, Graphic*>)0x006A0610; // .text:0069F790 ; void __thiscall UIRegion::SetImage(UIRegion *this, Graphic *_image) .text:0069F790 ?SetImage@UIRegion@@QAEXPAVGraphic@@@Z

        // UIRegion.SetImageByDID:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32> SetImageByDID = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32>)0x006A07E0; // .text:0069F960 ; void __thiscall UIRegion::SetImageByDID(UIRegion *this, IDClass<_tagDataID,32,0> _imageDID, UInt32 _drawMode) .text:0069F960 ?SetImageByDID@UIRegion@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIRegion.DrawSelf:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*> DrawSelf = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*>)0x006A0020; // .text:0069F1A0 ; void __thiscall UIRegion::DrawSelf(UIRegion *this, Box2D *i_rectObjectSelf, Box2D *i_rectObjectClip, SmartArray<Box2D> *i_aObjectBoxes, UISurface *i_pSurface) .text:0069F1A0 ?DrawSelf@UIRegion@@MAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIRegion.__Ctor:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*, Int32, Int32, Int32, Int32> __Ctor = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*, Int32, Int32, Int32, Int32>)0x006A0F70; // .text:006A0150 ; void __thiscall UIRegion::UIRegion(UIRegion *this, UIRegion *_parent, Int32 _x, Int32 _y, Int32 _width, Int32 _height) .text:006A0150 ??0UIRegion@@QAE@PAV0@JJJJ@Z

        // UIRegion.EraseBackground:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, UISurface*> EraseBackground = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, UISurface*>)0x0069FBF0; // .text:0069ED70 ; void __thiscall UIRegion::EraseBackground(UIRegion *this, Box2D *i_boxObject, UISurface *i_pSurface) .text:0069ED70 ?EraseBackground@UIRegion@@MAEXABVBox2D@@PAVUISurface@@@Z

        // UIRegion.SetClampGameViewEdge:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32> SetClampGameViewEdge = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32>)0x0069FC70; // .text:0069EDF0 ; void __thiscall UIRegion::SetClampGameViewEdge(UIRegion *this, UInt32 i_eEdge) .text:0069EDF0 ?SetClampGameViewEdge@UIRegion@@UAEXK@Z

        // UIRegion.GetObjectX0:
        // public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetObjectX0 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0xDEADBEEF; // .text:0069EEC0 ; Int32 __thiscall UIRegion::GetObjectX0(UIRegion *this) .text:0069EEC0 ?GetObjectX0@UIRegion@@QBEJXZ

        // UIRegion.AddChild:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*> AddChild = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*>)0x006A1580; // .text:006A0760 ; void __thiscall UIRegion::AddChild(UIRegion *this, UIRegion *_child) .text:006A0760 ?AddChild@UIRegion@@MAEXPAV1@@Z

        // UIRegion.MouseOverTop:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> MouseOverTop = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x0045F990; // .text:0045F8B0 ; void __thiscall UIRegion::MouseOverTop(UIRegion *this, bool _overTop) .text:0045F8B0 ?MouseOverTop@UIRegion@@UAEX_N@Z

        // UIRegion.GetScreenX0:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetScreenX0 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0x0069FE00; // .text:0069EF80 ; Int32 __thiscall UIRegion::GetScreenX0(UIRegion *this) .text:0069EF80 ?GetScreenX0@UIRegion@@QBEJXZ

        // UIRegion.GetScreenY1:
        // public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetScreenY1 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0xDEADBEEF; // .text:0069F360 ; Int32 __thiscall UIRegion::GetScreenY1(UIRegion *this) .text:0069F360 ?GetScreenY1@UIRegion@@QBEJXZ

        // UIRegion.DrawChildren:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*> DrawChildren = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*>)0x006A0B20; // .text:0069FCA0 ; void __thiscall UIRegion::DrawChildren(UIRegion *this, Box2D *i_rectObjectSelf, Box2D *i_rectObjectClip, SmartArray<Box2D> *i_aObjectBoxes, UISurface *i_pSurface) .text:0069FCA0 ?DrawChildren@UIRegion@@MAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIRegion.SetParent:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*> SetParent = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*>)0x006A04E0; // .text:0069F660 ; void __thiscall UIRegion::SetParent(UIRegion *this, UIRegion *_parent) .text:0069F660 ?SetParent@UIRegion@@UAEXPAV1@@Z

        // UIRegion.DrawHere:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*> DrawHere = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*>)0x006A08B0; // .text:0069FA30 ; void __thiscall UIRegion::DrawHere(UIRegion *this, Box2D *_surfaceBox, Box2D *_clipBox, SmartArray<Box2D> *_boxes, UISurface *_surface) .text:0069FA30 ?DrawHere@UIRegion@@UAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIRegion.GetObjectA:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIObject*> GetObjectA = (delegate* unmanaged[Thiscall]<UIRegion*, UIObject*>)0x004592B0; // .text:00459190 ; UIObject *__thiscall UIRegion::GetObjectA(UIRegion *this) .text:00459190 ?GetObjectA@UIRegion@@QBEPAVUIObject@@XZ

        // UIRegion.MouseOver:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> MouseOver = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x0045F970; // .text:0045F890 ; void __thiscall UIRegion::MouseOver(UIRegion *this, bool _over) .text:0045F890 ?MouseOver@UIRegion@@UAEX_N@Z

        // UIRegion.ClearAlphaImage:
        public static delegate* unmanaged[Thiscall]<UIRegion*> ClearAlphaImage = (delegate* unmanaged[Thiscall]<UIRegion*>)0x0069FBD0; // .text:0069ED50 ; void __thiscall UIRegion::ClearAlphaImage(UIRegion *this) .text:0069ED50 ?ClearAlphaImage@UIRegion@@QAEXXZ

        // UIRegion.SetShouldBlockClicks:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> SetShouldBlockClicks = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x0069FC50; // .text:0069EDD0 ; void __thiscall UIRegion::SetShouldBlockClicks(UIRegion *this, bool i_bBlockClicks) .text:0069EDD0 ?SetShouldBlockClicks@UIRegion@@UAEX_N@Z

        // UIRegion.NotifyMouseTap:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32> NotifyMouseTap = (delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32>)0xDEADBEEF; // .text:0069EEB0 ; void __thiscall UIRegion::NotifyMouseTap(UIRegion *this, UInt32 _x, UInt32 _y, UInt32 _button) .text:0069EEB0 ?NotifyMouseTap@UIRegion@@QAEXKKK@Z

        // UIRegion.SetAlphaBlendMod:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Single> SetAlphaBlendMod = (delegate* unmanaged[Thiscall]<UIRegion*,Single>)0xDEADBEEF; // .text:0069F5E0 ; void __thiscall UIRegion::SetAlphaBlendMod(UIRegion *this, Single _mod) .text:0069F5E0 ?SetAlphaBlendMod@UIRegion@@QAEXM@Z

        // UIRegion.SetVisible:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> SetVisible = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x006A0D50; // .text:0069FED0 ; void __thiscall UIRegion::SetVisible(UIRegion *this, bool _visible) .text:0069FED0 ?SetVisible@UIRegion@@UAEX_N@Z

        // UIRegion.EraseSelf:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*> EraseSelf = (delegate* unmanaged[Thiscall]<UIRegion*, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*>)0x0069FFE0; // .text:0069F160 ; void __thiscall UIRegion::EraseSelf(UIRegion *this, Box2D *i_rectObjectSelf, Box2D *i_rectObjectClip, SmartArray<Box2D> *i_aObjectBoxes, UISurface *i_pSurface) .text:0069F160 ?EraseSelf@UIRegion@@UAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIRegion.SetTooltipOn:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Byte> SetTooltipOn = (delegate* unmanaged[Thiscall]<UIRegion*, Byte>)0x0045F9B0; // .text:0045F8D0 ; void __thiscall UIRegion::SetTooltipOn(UIRegion *this, bool _on) .text:0045F8D0 ?SetTooltipOn@UIRegion@@QAEX_N@Z

        // UIRegion.CompareZLevel:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*, Int32> CompareZLevel = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*, Int32>)0x0069FE80; // .text:0069F000 ; Int32 __thiscall UIRegion::CompareZLevel(UIRegion *this, UIRegion *i_pRegion) .text:0069F000 ?CompareZLevel@UIRegion@@UBEJPBV1@@Z

        // UIRegion.BringToFront:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*> BringToFront = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*>)0x006A1610; // .text:006A07F0 ; void __thiscall UIRegion::BringToFront(UIRegion *this, UIRegion *_child) .text:006A07F0 ?BringToFront@UIRegion@@MAEXPAV1@@Z

        // UIRegion.ClearImage:
        public static delegate* unmanaged[Thiscall]<UIRegion*> ClearImage = (delegate* unmanaged[Thiscall]<UIRegion*>)0x006A0660; // .text:0069F7E0 ; void __thiscall UIRegion::ClearImage(UIRegion *this) .text:0069F7E0 ?ClearImage@UIRegion@@QAEXXZ

        // UIRegion.MouseDown:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32, UInt32> MouseDown = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32, UInt32>)0x006A0EA0; // .text:006A0080 ; void __thiscall UIRegion::MouseDown(UIRegion *this, UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) .text:006A0080 ?MouseDown@UIRegion@@UAEXKKK@Z

        // UIRegion.NotifyMouseMove:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Int32,Int32> NotifyMouseMove = (delegate* unmanaged[Thiscall]<UIRegion*,Int32,Int32>)0xDEADBEEF; // .text:0069EEA0 ; void __thiscall UIRegion::NotifyMouseMove(UIRegion *this, Int32 _xWindow, Int32 _yWindow) .text:0069EEA0 ?NotifyMouseMove@UIRegion@@QAEXJJ@Z

        // UIRegion.GetScreenY0:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetScreenY0 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0x0069FE30; // .text:0069EFB0 ; Int32 __thiscall UIRegion::GetScreenY0(UIRegion *this) .text:0069EFB0 ?GetScreenY0@UIRegion@@QBEJXZ

        // UIRegion.SetAlphaImageByDID:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32> SetAlphaImageByDID = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32>)0x0069FEB0; // .text:0069F030 ; void __thiscall UIRegion::SetAlphaImageByDID(UIRegion *this, IDClass<_tagDataID,32,0> _alphaImageDID) .text:0069F030 ?SetAlphaImageByDID@UIRegion@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // UIRegion.AddDirtyRect:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Box2D*> AddDirtyRect = (delegate* unmanaged[Thiscall]<UIRegion*,Box2D*>)0xDEADBEEF; // .text:0069F080 ; void __thiscall UIRegion::AddDirtyRect(UIRegion *this, Box2D *_rect) .text:0069F080 ?AddDirtyRect@UIRegion@@IAEXABVBox2D@@@Z

        // UIRegion.MakeRootDirtyHere:
        // public static delegate* unmanaged[Thiscall]<UIRegion*> MakeRootDirtyHere = (delegate* unmanaged[Thiscall]<UIRegion*>)0xDEADBEEF; // .text:0069F5B0 ; void __thiscall UIRegion::MakeRootDirtyHere(UIRegion *this) .text:0069F5B0 ?MakeRootDirtyHere@UIRegion@@IAEXXZ

        // UIRegion.NotifyMouseDown:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32> NotifyMouseDown = (delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32>)0xDEADBEEF; // .text:0069FE20 ; void __thiscall UIRegion::NotifyMouseDown(UIRegion *this, UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) .text:0069FE20 ?NotifyMouseDown@UIRegion@@QAEXKKK@Z

        // UIRegion.RemoveChild:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*> RemoveChild = (delegate* unmanaged[Thiscall]<UIRegion*, UIRegion*>)0x006A1150; // .text:006A0330 ; void __thiscall UIRegion::RemoveChild(UIRegion *this, UIRegion *_child) .text:006A0330 ?RemoveChild@UIRegion@@MAEXPAV1@@Z

        // UIRegion.ForceUpdate:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32> ForceUpdate = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32>)0x006A0C10; // .text:0069FD90 ; void __thiscall UIRegion::ForceUpdate(UIRegion *this, UInt32 i_updateFlags) .text:0069FD90 ?ForceUpdate@UIRegion@@QAEXK@Z

        // UIRegion.NotifyMouseUp:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32> NotifyMouseUp = (delegate* unmanaged[Thiscall]<UIRegion*,UInt32,UInt32,UInt32>)0xDEADBEEF; // .text:0069FE80 ; void __thiscall UIRegion::NotifyMouseUp(UIRegion *this, UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) .text:0069FE80 ?NotifyMouseUp@UIRegion@@QAEXKKK@Z

        // UIRegion.GetHeight:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetHeight = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0x0069FE70; // .text:0069EFF0 ; Int32 __thiscall UIRegion::GetHeight(UIRegion *this) .text:0069EFF0 ?GetHeight@UIRegion@@QBEJXZ

        // UIRegion.GetScreenX1:
        // public static delegate* unmanaged[Thiscall]<UIRegion*, Int32> GetScreenX1 = (delegate* unmanaged[Thiscall]<UIRegion*, Int32>)0xDEADBEEF; // .text:0069F310 ; Int32 __thiscall UIRegion::GetScreenX1(UIRegion *this) .text:0069F310 ?GetScreenX1@UIRegion@@QBEJXZ

        // UIRegion.SetTilingOffset:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,tagPOINT*> SetTilingOffset = (delegate* unmanaged[Thiscall]<UIRegion*,tagPOINT*>)0xDEADBEEF; // .text:0069F730 ; void __thiscall UIRegion::SetTilingOffset(UIRegion *this, tagPOINT *i_pt) .text:0069F730 ?SetTilingOffset@UIRegion@@QAEXABUtagPOINT@@@Z

        // UIRegion.ResizeTo:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32, Int32> ResizeTo = (delegate* unmanaged[Thiscall]<UIRegion*, Int32, Int32>)0x006A0740; // .text:0069F8C0 ; void __thiscall UIRegion::ResizeTo(UIRegion *this, const Int32 _width, const Int32 _height) .text:0069F8C0 ?ResizeTo@UIRegion@@UAEXJJ@Z

        // UIRegion.MouseUp:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32, UInt32> MouseUp = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32, UInt32, UInt32>)0x006A0EC0; // .text:006A00A0 ; void __thiscall UIRegion::MouseUp(UIRegion *this, UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) .text:006A00A0 ?MouseUp@UIRegion@@UAEXKKK@Z

        // UIRegion.IsMouseDown:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32, Byte> IsMouseDown = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32, Byte>)0x004637F0; // .text:004636C0 ; bool __thiscall UIRegion::IsMouseDown(UIRegion *this, UInt32 _button) .text:004636C0 ?IsMouseDown@UIRegion@@QBE_NK@Z

        // UIRegion.GetScreenClipBox:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*> GetScreenClipBox = (delegate* unmanaged[Thiscall]<UIRegion*,Box2D*, Box2D*>)0xDEADBEEF; // .text:0069F4C0 ; Box2D *__thiscall UIRegion::GetScreenClipBox(UIRegion *this, Box2D *result) .text:0069F4C0 ?GetScreenClipBox@UIRegion@@IBE?AVBox2D@@XZ

        // UIRegion.SetBlitMode:
        // public static delegate* unmanaged[Thiscall]<UIRegion*,BlitMode> SetBlitMode = (delegate* unmanaged[Thiscall]<UIRegion*,BlitMode>)0xDEADBEEF; // .text:0069F6F0 ; void __thiscall UIRegion::SetBlitMode(UIRegion *this, BlitMode i_eBlitMode) .text:0069F6F0 ?SetBlitMode@UIRegion@@QAEXW4BlitMode@@@Z

        // UIRegion.MoveTo:
        public static delegate* unmanaged[Thiscall]<UIRegion*, Int32, Int32> MoveTo = (delegate* unmanaged[Thiscall]<UIRegion*, Int32, Int32>)0x006A06B0; // .text:0069F830 ; void __thiscall UIRegion::MoveTo(UIRegion *this, const Int32 _x, const Int32 _y) .text:0069F830 ?MoveTo@UIRegion@@UAEXJJ@Z

        // UIRegion.__Dtor:
        public static delegate* unmanaged[Thiscall]<UIRegion*> __Dtor = (delegate* unmanaged[Thiscall]<UIRegion*>)0x006A1070; // .text:006A0250 ; void __thiscall UIRegion::~UIRegion(UIRegion *this) .text:006A0250 ??1UIRegion@@UAE@XZ

        // UIRegion.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<UIRegion*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<UIRegion*, UInt32, void*>)0x006A1340; // .text:006A0520 ; void *__thiscall UIRegion::`vector deleting destructor'(UIRegion *this, UInt32) .text:006A0520 ??_EUIRegion@@UAEPAXI@Z
    };
    public unsafe struct UISurface {
        // Struct:
        public Turbine_RefCount _ref;
        public RenderTexture* m_pLocalTexture;
        public RenderSurface* m_pLocalSurface;
        public RenderTexture* m_pRemoteTexture;
        public RenderVertexBuffer* m_pVertexBuffer;
        public Byte m_bHasAlpha;
        public UInt32 m_nPhysicalWidth;
        public UInt32 m_nPhysicalHeight;
        public Byte m_IsInitialized;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, m_pLocalTexture:->(RenderTexture*)0x{(Int32)m_pLocalTexture:X8}, m_pLocalSurface:->(RenderSurface*)0x{(Int32)m_pLocalSurface:X8}, m_pRemoteTexture:->(RenderTexture*)0x{(Int32)m_pRemoteTexture:X8}, m_pVertexBuffer:->(RenderVertexBuffer*)0x{(Int32)m_pVertexBuffer:X8}, m_bHasAlpha:{m_bHasAlpha:X2}, m_nPhysicalWidth:{m_nPhysicalWidth:X8}, m_nPhysicalHeight:{m_nPhysicalHeight:X8}, m_IsInitialized:{m_IsInitialized:X2}";


        // Functions:

        // UISurface.SetupVertexBuffer:
        public static delegate* unmanaged[Thiscall]<UISurface*, Byte> SetupVertexBuffer = (delegate* unmanaged[Thiscall]<UISurface*, Byte>)0x00440820; // .text:00440680 ; bool __thiscall UISurface::SetupVertexBuffer(UISurface *this) .text:00440680 ?SetupVertexBuffer@UISurface@@IAE_NXZ

        // UISurface.DestroySurface:
        public static delegate* unmanaged[Thiscall]<UISurface*> DestroySurface = (delegate* unmanaged[Thiscall]<UISurface*>)0x00440940; // .text:004407A0 ; void __thiscall UISurface::DestroySurface(UISurface *this) .text:004407A0 ?DestroySurface@UISurface@@QAEXXZ

        // UISurface.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<UISurface*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<UISurface*,UInt32, void*>)0xDEADBEEF; // .text:00440BE0 ; void *__thiscall UISurface::`vector deleting destructor'(UISurface *this, UInt32) .text:00440BE0 ??_EUISurface@@UAEPAXI@Z

        // UISurface.CreateSurface:
        // public static delegate* unmanaged[Thiscall]<UISurface*,UInt32,UInt32,UInt32, Byte> CreateSurface = (delegate* unmanaged[Thiscall]<UISurface*,UInt32,UInt32,UInt32, Byte>)0xDEADBEEF; // .text:00440990 ; bool __thiscall UISurface::CreateSurface(UISurface *this, const UInt32 _nWidth, const UInt32 _nHeight, const UInt32 _Flags) .text:00440990 ?CreateSurface@UISurface@@QAE_NKKK@Z

        // UISurface.PrepareSurface:
        public static delegate* unmanaged[Thiscall]<UISurface*, Byte> PrepareSurface = (delegate* unmanaged[Thiscall]<UISurface*, Byte>)0x00440D20; // .text:00440B80 ; bool __thiscall UISurface::PrepareSurface(UISurface *this) .text:00440B80 ?PrepareSurface@UISurface@@IAE_NXZ

        // UISurface.Resize:
        // public static delegate* unmanaged[Thiscall]<UISurface*,UInt32,UInt32, Byte> Resize = (delegate* unmanaged[Thiscall]<UISurface*,UInt32,UInt32, Byte>)0xDEADBEEF; // .text:00440C10 ; bool __thiscall UISurface::Resize(UISurface *this, const UInt32 _nNewWidth, const UInt32 _nNewHeight) .text:00440C10 ?Resize@UISurface@@QAE_NKK@Z

        // UISurface.RefreshHardware:
        // public static delegate* unmanaged[Thiscall]<UISurface*, Byte> RefreshHardware = (delegate* unmanaged[Thiscall]<UISurface*, Byte>)0xDEADBEEF; // .text:00440CB0 ; bool __thiscall UISurface::RefreshHardware(UISurface *this) .text:00440CB0 ?RefreshHardware@UISurface@@IAE_NXZ

        // UISurface.__Ctor:
        // public static delegate* unmanaged[Thiscall]<UISurface*> __Ctor = (delegate* unmanaged[Thiscall]<UISurface*>)0xDEADBEEF; // .text:00440650 ; void __thiscall UISurface::UISurface(UISurface *this) .text:00440650 ??0UISurface@@QAE@XZ

        // UISurface.GetBestWidthHeight:
        public static delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32*, UInt32*, Byte, Byte> GetBestWidthHeight = (delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32*, UInt32*, Byte, Byte>)0x004409F0; // .text:00440850 ; bool __cdecl UISurface::GetBestWidthHeight(const UInt32 _width, const UInt32 _height, UInt32 *bestWidth, UInt32 *bestHeight, const bool i_bForceCheck) .text:00440850 ?GetBestWidthHeight@UISurface@@KA_NKKAAK0_N@Z

        // UISurface.IsPowerOfTwo:
        // public static delegate* unmanaged[Cdecl]<UInt32,UInt32, Byte> IsPowerOfTwo = (delegate* unmanaged[Cdecl]<UInt32,UInt32, Byte>)0xDEADBEEF; // .text:00440930 ; bool __cdecl UISurface::IsPowerOfTwo(const UInt32 i_nWidth, const UInt32 i_nHeight) .text:00440930 ?IsPowerOfTwo@UISurface@@SA_NKK@Z

        // Globals:
        // public static Int32* s_nBytesConsumed = (Int32*)0xDEADBEEF; // .data:00837CD4 ; Int32 UISurface::s_nBytesConsumed .data:00837CD4 ?s_nBytesConsumed@UISurface@@1JA
    }

    public unsafe struct RenderVertexBuffer {
        // Struct:
        public VertexArray VertexArray;
        public Byte m_UseVirtualArray;
        public VertexFormatInfo m_HardwareVertexFormat;
        public void* m_pVirtualArray;
        public Byte m_IsVirtualArrayLocked;
        public Byte m_NeedRefreshVirtualArray;
        public BBox m_VirtualArrayBoundingBox;
        public Byte m_IsVirtualArrayBoundingBoxValid;
        public override string ToString() => $"VertexArray(VertexArray):{VertexArray}, m_UseVirtualArray:{m_UseVirtualArray:X2}, m_HardwareVertexFormat(VertexFormatInfo):{m_HardwareVertexFormat}, m_pVirtualArray:->(void*)0x{(Int32)m_pVirtualArray:X8}, m_IsVirtualArrayLocked:{m_IsVirtualArrayLocked:X2}, m_NeedRefreshVirtualArray:{m_NeedRefreshVirtualArray:X2}, m_VirtualArrayBoundingBox(BBox):{m_VirtualArrayBoundingBox}, m_IsVirtualArrayBoundingBoxValid:{m_IsVirtualArrayBoundingBoxValid:X2}";


        // Functions:

        // RenderVertexBuffer.RenderIndexedUsingMaterial:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32,UInt32,UInt32,RenderIndexBuffer*,RenderMaterial*,RenderMaterial*,RenderPassType,RGBAColor*,RGBAColor*,Byte,Byte,UInt32*,UInt32*,Byte, Byte> RenderIndexedUsingMaterial = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32,UInt32,UInt32,RenderIndexBuffer*,RenderMaterial*,RenderMaterial*,RenderPassType,RGBAColor*,RGBAColor*,Byte,Byte,UInt32*,UInt32*,Byte, Byte>)0xDEADBEEF; // .text:00447940 ; bool __thiscall RenderVertexBuffer::RenderIndexedUsingMaterial(RenderVertexBuffer *this, PrimType _PrimType, const UInt32 _nFirstIndex, const UInt32 _nNumPrimitives, const UInt32 _nFirstVertexIndex, const UInt32 _nNumVertexIndices, const UInt32 _nVertexOffset, RenderIndexBuffer *_IndexBuffer, RenderMaterial *_ReferenceMaterial, RenderMaterial *_Material, RenderPassType _RenderPass, RGBAColor *_cColor, RGBAColor *_AmbientLightBoost, const bool _ForceTranslucent, const bool _bForceBlend, UInt32 *_pnStreamFrameID, UInt32 *_pnBaseVertexIndex, const bool _UseBaseVertexIndex) .text:00447940 ?RenderIndexedUsingMaterial@RenderVertexBuffer@@QAE_NW4PrimType@@KKKKKAAVRenderIndexBuffer@@ABVRenderMaterial@@2W4RenderPassType@@ABVRGBAColor@@4_N5PAK65@Z

        // RenderVertexBuffer.Startup:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32,UInt32,Byte,Byte,UInt32, Byte> Startup = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32,UInt32,Byte,Byte,UInt32, Byte>)0xDEADBEEF; // .text:004473F0 ; bool __thiscall RenderVertexBuffer::Startup(RenderVertexBuffer *this, const UInt32 _numVertices, const UInt32 _format, const bool _staticVertices, const bool _OnlyWriteOnce, const UInt32 _HardwareFormatMask) .text:004473F0 ?Startup@RenderVertexBuffer@@UAE_NKK_N0K@Z

        // RenderVertexBuffer.Shutdown:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> Shutdown = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:004474C0 ; void __thiscall RenderVertexBuffer::Shutdown(RenderVertexBuffer *this) .text:004474C0 ?Shutdown@RenderVertexBuffer@@UAEXXZ

        // RenderVertexBuffer.RenderIndexedPrimitives:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32,UInt32,UInt32,RenderIndexBuffer*,Byte,UInt32*,UInt32*,Byte, Byte> RenderIndexedPrimitives = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32,UInt32,UInt32,RenderIndexBuffer*,Byte,UInt32*,UInt32*,Byte, Byte>)0xDEADBEEF; // .text:00447C90 ; bool __thiscall RenderVertexBuffer::RenderIndexedPrimitives(RenderVertexBuffer *this, PrimType _PrimType, const UInt32 _nFirstIndex, const UInt32 _nNumPrimitives, const UInt32 _nFirstVertexIndex, const UInt32 _nNumVertexIndices, const UInt32 _nVertexOffset, RenderIndexBuffer *_IndexBuffer, const bool _bForceBlend, UInt32 *_pnStreamFrameID, UInt32 *_pnBaseVertexIndex, const bool _bUseBaseVertexIndex) .text:00447C90 ?RenderIndexedPrimitives@RenderVertexBuffer@@UAE_NW4PrimType@@KKKKKAAVRenderIndexBuffer@@_NPAK32@Z

        // RenderVertexBuffer.RenderPrimitives:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32*,UInt32*, Byte> RenderPrimitives = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,UInt32*,UInt32*, Byte>)0xDEADBEEF; // .text:00447CA0 ; bool __thiscall RenderVertexBuffer::RenderPrimitives(RenderVertexBuffer *this, PrimType _PrimType, const UInt32 _nFirstVertex, const UInt32 _nNumPrimitives, UInt32 *_pnStreamFrameID, UInt32 *_pnBaseVertexIndex) .text:00447CA0 ?RenderPrimitives@RenderVertexBuffer@@UAE_NW4PrimType@@KKPAK1@Z

        // RenderVertexBuffer.LockVirtualArray:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32,UInt32, void*> LockVirtualArray = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32,UInt32, void*>)0xDEADBEEF; // .text:00447D80 ; void *__thiscall RenderVertexBuffer::LockVirtualArray(RenderVertexBuffer *this, const UInt32 firstVertex, const UInt32 numVerts) .text:00447D80 ?LockVirtualArray@RenderVertexBuffer@@UAEPAXKK@Z

        // RenderVertexBuffer.Begin:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> Begin = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:00447380 ; void __thiscall RenderVertexBuffer::Begin(RenderVertexBuffer *this) .text:00447380 ?Begin@RenderVertexBuffer@@AAEXXZ

        // RenderVertexBuffer.End:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> End = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:004473C0 ; void __thiscall RenderVertexBuffer::End(RenderVertexBuffer *this) .text:004473C0 ?End@RenderVertexBuffer@@AAEXXZ

        // RenderVertexBuffer.UnlockVirtualArray:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> UnlockVirtualArray = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:00447520 ; void __thiscall RenderVertexBuffer::UnlockVirtualArray(RenderVertexBuffer *this) .text:00447520 ?UnlockVirtualArray@RenderVertexBuffer@@UAEXXZ

        // RenderVertexBuffer.TransferVertices:
        // public static delegate* unmanaged[Cdecl]<void*,VertexFormatInfo*,void*,VertexFormatInfo*,UInt32,Byte> TransferVertices = (delegate* unmanaged[Cdecl]<void*,VertexFormatInfo*,void*,VertexFormatInfo*,UInt32,Byte>)0xDEADBEEF; // .text:00447570 ; void __cdecl RenderVertexBuffer::TransferVertices(const void *_pSourceData, VertexFormatInfo *_SourceVFI, void *_pDestData, VertexFormatInfo *_DestVFI, const UInt32 _NumVertices, const bool _SwapYAndZ) .text:00447570 ?TransferVertices@RenderVertexBuffer@@SAXPBXABVVertexFormatInfo@@PAX1K_N@Z

        // RenderVertexBuffer.__Ctor:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> __Ctor = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:00447C20 ; void __thiscall RenderVertexBuffer::RenderVertexBuffer(RenderVertexBuffer *this) .text:00447C20 ??0RenderVertexBuffer@@QAE@XZ

        // RenderVertexBuffer.RefreshVirtualArray:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*> RefreshVirtualArray = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*>)0xDEADBEEF; // .text:00447D10 ; void __thiscall RenderVertexBuffer::RefreshVirtualArray(RenderVertexBuffer *this) .text:00447D10 ?RefreshVirtualArray@RenderVertexBuffer@@QAEXXZ

        // RenderVertexBuffer.Unlock:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,Byte,Byte> Unlock = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,Byte,Byte>)0xDEADBEEF; // .text:00447540 ; void __thiscall RenderVertexBuffer::Unlock(RenderVertexBuffer *this, const bool _bRecalcBounds, const bool _bRecalcBoneInfluences) .text:00447540 ?Unlock@RenderVertexBuffer@@UAEX_N0@Z

        // RenderVertexBuffer.RenderUsingMaterial:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,RenderMaterial*,RenderMaterial*,RenderPassType,RGBAColor*,RGBAColor*,UInt32*,UInt32*, Byte> RenderUsingMaterial = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,PrimType,UInt32,UInt32,RenderMaterial*,RenderMaterial*,RenderPassType,RGBAColor*,RGBAColor*,UInt32*,UInt32*, Byte>)0xDEADBEEF; // .text:00447A80 ; bool __thiscall RenderVertexBuffer::RenderUsingMaterial(RenderVertexBuffer *this, PrimType _PrimType, const UInt32 _nFirstVertex, const UInt32 _nNumPrimitives, RenderMaterial *_ReferenceMaterial, RenderMaterial *_Material, RenderPassType _RenderPass, RGBAColor *_cColor, RGBAColor *_AmbientLightBoost, UInt32 *_pnStreamFrameID, UInt32 *_pnBaseVertexIndex) .text:00447A80 ?RenderUsingMaterial@RenderVertexBuffer@@QAE_NW4PrimType@@KKABVRenderMaterial@@1W4RenderPassType@@ABVRGBAColor@@3PAK4@Z

        // RenderVertexBuffer.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<RenderVertexBuffer*,UInt32, void*>)0xDEADBEEF; // .text:00447CB0 ; void *__thiscall RenderVertexBuffer::`scalar deleting destructor'(RenderVertexBuffer *this, UInt32) .text:00447CB0 ??_GRenderVertexBuffer@@UAEPAXI@Z
    }
    public unsafe struct VertexArray {
        // Struct:
        public Turbine_RefCount _ref;
        public VertexFormatInfo vertexFormat;
        public UInt32 numVertices;
        public void* vertices;
        public Byte staticVertices;
        public Byte locked;
        public Byte m_bStripHWExtraTexCoords;
        public Byte m_OnlyWriteOnce;
        public BBox m_BoundingBox;
        public SmartArray<UInt32> m_InfluencedBoneIndexArray;
        public Byte m_IsYAndZSwapped;
        public override string ToString() => $"_ref(Turbine_RefCount):{_ref}, vertexFormat(VertexFormatInfo):{vertexFormat}, numVertices:{numVertices:X8}, vertices:->(void*)0x{(Int32)vertices:X8}, staticVertices:{staticVertices:X2}, locked:{locked:X2}, m_bStripHWExtraTexCoords:{m_bStripHWExtraTexCoords:X2}, m_OnlyWriteOnce:{m_OnlyWriteOnce:X2}, m_BoundingBox(BBox):{m_BoundingBox}, m_InfluencedBoneIndexArray(SmartArray<UInt32,1>):{m_InfluencedBoneIndexArray}, m_IsYAndZSwapped:{m_IsYAndZSwapped:X2}";


        // Functions:

        // VertexArray.__vecDelDtor:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<VertexArray*,UInt32, void*>)0xDEADBEEF; // .text:00447BD0 ; void *__thiscall VertexArray::`vector deleting destructor'(VertexArray *this, UInt32) .text:00447BD0 ??_EVertexArray@@UAEPAXI@Z

        // VertexArray.Lock:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,UInt32,UInt32, void*> Lock = (delegate* unmanaged[Thiscall]<VertexArray*,UInt32,UInt32, void*>)0xDEADBEEF; // .text:005D7310 ; void *__thiscall VertexArray::Lock(VertexArray *this, const UInt32 firstVertex, const UInt32 numVerts) .text:005D7310 ?Lock@VertexArray@@UAEPAXKK@Z

        // VertexArray.Serialize:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,Archive*> Serialize = (delegate* unmanaged[Thiscall]<VertexArray*,Archive*>)0xDEADBEEF; // .text:005D7730 ; void __thiscall VertexArray::Serialize(VertexArray *this, Archive *io_archive) .text:005D7730 ?Serialize@VertexArray@@QAEXAAVArchive@@@Z

        // VertexArray.ComputeInfluencedBoneIndices:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> ComputeInfluencedBoneIndices = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:005D84B0 ; void __thiscall VertexArray::ComputeInfluencedBoneIndices(VertexArray *this) .text:005D84B0 ?ComputeInfluencedBoneIndices@VertexArray@@IAEXXZ

        // VertexArray.Unlock:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,Byte,Byte> Unlock = (delegate* unmanaged[Thiscall]<VertexArray*,Byte,Byte>)0xDEADBEEF; // .text:005D8640 ; void __thiscall VertexArray::Unlock(VertexArray *this, const bool _bRecalcBounds, const bool _bRecalcBoneInfluences) .text:005D8640 ?Unlock@VertexArray@@UAEX_N0@Z

        // VertexArray.Shutdown:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> Shutdown = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:005D7550 ; void __thiscall VertexArray::Shutdown(VertexArray *this) .text:005D7550 ?Shutdown@VertexArray@@UAEXXZ

        // VertexArray.FromFileNode:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,PFileNode*, Byte> FromFileNode = (delegate* unmanaged[Thiscall]<VertexArray*,PFileNode*, Byte>)0xDEADBEEF; // .text:005D8100 ; bool __thiscall VertexArray::FromFileNode(VertexArray *this, PFileNode *_node) .text:005D8100 ?FromFileNode@VertexArray@@QAE_NPBVPFileNode@@@Z

        // VertexArray.__Dtor:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> __Dtor = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:00447B90 ; void __thiscall VertexArray::~VertexArray(VertexArray *this) .text:00447B90 ??1VertexArray@@UAE@XZ

        // VertexArray.RequestStripHWExtraTexCoords:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,Byte, Byte> RequestStripHWExtraTexCoords = (delegate* unmanaged[Thiscall]<VertexArray*,Byte, Byte>)0xDEADBEEF; // .text:005D7290 ; bool __thiscall VertexArray::RequestStripHWExtraTexCoords(VertexArray *this, const bool _b) .text:005D7290 ?RequestStripHWExtraTexCoords@VertexArray@@QAE_N_N@Z

        // VertexArray.Startup:
        // public static delegate* unmanaged[Thiscall]<VertexArray*,UInt32,UInt32,Byte,Byte,UInt32, Byte> Startup = (delegate* unmanaged[Thiscall]<VertexArray*,UInt32,UInt32,Byte,Byte,UInt32, Byte>)0xDEADBEEF; // .text:005D72B0 ; bool __thiscall VertexArray::Startup(VertexArray *this, const UInt32 _numVertices, const UInt32 _format, const bool _staticVertices, const bool _OnlyWriteOnce, const UInt32 _HardwareFormatMask) .text:005D72B0 ?Startup@VertexArray@@UAE_NKK_N0K@Z

        // VertexArray.GenerateBoundingBox:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> GenerateBoundingBox = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:005D7460 ; void __thiscall VertexArray::GenerateBoundingBox(VertexArray *this) .text:005D7460 ?GenerateBoundingBox@VertexArray@@IAEXXZ

        // VertexArray.Begin:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> Begin = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:005D74D0 ; void __thiscall VertexArray::Begin(VertexArray *this) .text:005D74D0 ?Begin@VertexArray@@AAEXXZ

        // VertexArray.End:
        // public static delegate* unmanaged[Thiscall]<VertexArray*> End = (delegate* unmanaged[Thiscall]<VertexArray*>)0xDEADBEEF; // .text:005D7520 ; void __thiscall VertexArray::End(VertexArray *this) .text:005D7520 ?End@VertexArray@@AAEXXZ
    }
    public unsafe struct VertexFormatInfo {
        // Struct:
        public UInt32 format;
        public UInt32 size;
        public Byte bFVFCompatible;
        public UInt32 formatFVF;
        public UInt32 numWeights;
        public UInt32 numTCPairs;
        public UInt32 numMatrices;
        public UInt32 offsetOrigin;
        public UInt32 offsetWeight0;
        public UInt32 offsetWeight1;
        public UInt32 offsetWeight2;
        public UInt32 offsetWeight3;
        public UInt32 offsetWeight4;
        public UInt32 offsetNormal;
        public UInt32 offsetPoInt32Size;
        public UInt32 offsetDiffuse;
        public UInt32 offsetSpecular;
        public fixed UInt32 offsetTCPair[8];
        public UInt32 offsetVectorS;
        public UInt32 offsetVectorT;
        public UInt32 offsetMatrices;
        public UInt32 offsetMWeights;
        public override string ToString() => $"format:{format:X8}, size:{size:X8}, bFVFCompatible:{bFVFCompatible:X2}, formatFVF:{formatFVF:X8}, numWeights:{numWeights:X8}, numTCPairs:{numTCPairs:X8}, numMatrices:{numMatrices:X8}, offsetOrigin:{offsetOrigin:X8}, offsetWeight0:{offsetWeight0:X8}, offsetWeight1:{offsetWeight1:X8}, offsetWeight2:{offsetWeight2:X8}, offsetWeight3:{offsetWeight3:X8}, offsetWeight4:{offsetWeight4:X8}, offsetNormal:{offsetNormal:X8}, offsetPoInt32Size:{offsetPoInt32Size:X8}, offsetDiffuse:{offsetDiffuse:X8}, offsetSpecular:{offsetSpecular:X8}, offsetTCPair[8]:{offsetTCPair[8]:X8}, offsetVectorS:{offsetVectorS:X8}, offsetVectorT:{offsetVectorT:X8}, offsetMatrices:{offsetMatrices:X8}, offsetMWeights:{offsetMWeights:X8}";


        // Functions:

        // VertexFormatInfo.GenerateOffsets:
        // public static delegate* unmanaged[Thiscall]<VertexFormatInfo*> GenerateOffsets = (delegate* unmanaged[Thiscall]<VertexFormatInfo*>)0xDEADBEEF; // .text:005D8670 ; void __thiscall VertexFormatInfo::GenerateOffsets(VertexFormatInfo *this) .text:005D8670 ?GenerateOffsets@VertexFormatInfo@@QAEXXZ
    }




    public unsafe struct Graphic {
        public GraphicVtbl* vfptr;
        public UInt32 m_id;  // IDClass__tagDataID,32,0_
        public RenderSurface* m_image;
    };
    public unsafe struct GraphicVtbl {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void* __vecDelDtor(Graphic* This, UInt32 a2); //  void *(__thiscall____vecDelDtor)(Graphic *this, UInt32);
    };
    public unsafe struct RenderTexture {
        public DBObj dBObj;
        public GraphicsResource graphicsResource;
        public TextureType m_TextureType;
        public UInt32 m_nNumLevels;
        public PixelFormatID m_PixelFormat;
        public UInt32 m_Flags;
        public Byte m_bDropLevelsCalled;
        public UInt32 m_ManagedRefCount;
        public Double m_LastManagedReleaseTime;
        public Byte m_AllowManagement;
        public SmartArray<DBLevelInfo> m_SourceLevels;
        public UInt32 m_nWidth;
        public UInt32 m_nHeight;
        public UInt32 m_nEdgeLength;
    };
    public unsafe struct RenderSurface {
        public DBObj dBObj;
        public GraphicsResource graphicsResource;
        public RenderSurfaceSourceData sourceData;
        public UInt32 width;
        public UInt32 height;
        public UInt32 size;
        public SurfaceWindow window;
        public Byte locked;
        public PixelFormatDesc pfDesc;
        public void* m_pSurfaceBits;
        public UInt32 m_didPalatte;
        public Byte m_IsDirty;
        public Byte m_ReadOnlyLock;
    };
    public unsafe struct SurfaceWindow {
        public _Vtbl* vfptr;
        public RenderSurface* surface;
        public SurfaceWindow* parent;
        public tagRECT rect;
        public UInt32 lockCount;
        public Byte writable;
        public void* data;
        public Int32 pitch;
    };

    public unsafe struct RenderSurfaceSourceData {
        public UInt32 width;
        public UInt32 height;
        public UInt32 imageSize;
        public Char* sourceBits;
        public PixelFormatDesc pfDesc;
    };
    public unsafe struct PixelFormatDesc {
        public PixelFormatID format;
        public UInt32 flags;
        public UInt32 fourCC;
        public Char bitsPerPixel;
        public UInt32 redBitMask;
        public UInt32 greenBitMask;
        public UInt32 blueBitMask;
        public UInt32 alphaBitMask;
        public Char redBitCount;
        public Char greenBitCount;
        public Char blueBitCount;
        public Char alphaBitCount;
        public Char redBitOffset;
        public Char greenBitOffset;
        public Char blueBitOffset;
        public Char alphaBitOffset;
        public UInt32 redMax;
        public UInt32 greenMax;
        public UInt32 blueMax;
        public UInt32 alphaMax;
    };

    public unsafe struct UIListener {
        public IInputActionCallback iInputActionCallback;
        public HashSet<Int32> m_hashElementsRegisteredWith; // UIElement
        public CTimestamp_unsigned_long_0_ m_tsSerialNumberLastListenedTo;
    };
    public unsafe struct CTimestamp_unsigned_long_0_ {
        public UInt32 m_timestamp;
    };

    public unsafe struct CreatureMode {
        public SmartArray<PTR<CPhysicsObj>> creature_mode_objects;
        public SmartArray<PTR<LIGHTINFO>> creature_mode_lights;
        public CEnvCell* creature_cell;
        public Frame creature_view_frame;
        public RGBColor m_clrAmbientLight;
        public Single m_fFOVRadians;
        public Byte m_bUseSmartboxFOV;
        public Byte m_bUseSharpMode;
    };


    public unsafe struct StringInfoData {
        // Struct:
        public StringInfoData.Vtbl* vfptr;
        public UInt16 m_eType;
        public UInt32 m_eVarID;
        public override string ToString() => $"vfptr:->(StringInfoData.Vtbl*)0x{(int)vfptr:X8}, m_eType:{m_eType:X4}, m_eVarID:{m_eVarID:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<StringInfoData*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(StringInfoData *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<StringInfoData*, QualifiedDataIDArray*, void> GetSubDataIDs; // void (__thiscall *GetSubDataIDs)(StringInfoData *this, QualifiedDataIDArray *);
            public static delegate* unmanaged[Thiscall]<StringInfoData*, QualifiedDataIDArray*, UInt32, void> GetSubPrivateIDs; // void (__thiscall *GetSubPrivateIDs)(StringInfoData *this, QualifiedDataIDArray *, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<StringInfoData*, Byte, Byte> IsValid; // bool (__thiscall *IsValid)(StringInfoData *this, bool);
            public static delegate* unmanaged[Thiscall]<StringInfoData*, Archive*, void> Serialize; // void (__thiscall *Serialize)(StringInfoData *this, Archive *);
            public static delegate* unmanaged[Thiscall]<StringInfoData*, PStringBase<UInt16>*, PStringBase<UInt16>*> _ToString; // PStringBase<unsigned short> *(__thiscall *ToString)(StringInfoData *this, PStringBase<unsigned short> *result);
        }

        // Functions:

        // StringInfoData.Create:
        // public static StringInfoData* Create(UInt16 i_eType) => ((delegate* unmanaged[Cdecl]<UInt16, StringInfoData*>)0xDEADBEEF)(i_eType); // .text:0042EB70 ; StringInfoData *__cdecl StringInfoData::Create(unsigned __int16 i_eType) .text:0042EB70 ?Create@StringInfoData@@SAPAV1@G@Z

        // StringInfoData.Compare:
        // public static Byte Compare(StringInfoData* i_pcLhs, StringInfoData* i_pcRhs) => ((delegate* unmanaged[Cdecl]<StringInfoData*, StringInfoData*, Byte>)0xDEADBEEF)(i_pcLhs, i_pcRhs); // .text:0042EE30 ; bool __cdecl StringInfoData::Compare(StringInfoData *i_pcLhs, StringInfoData *i_pcRhs) .text:0042EE30 ?Compare@StringInfoData@@SA_NPBV1@0@Z

        // StringInfoData.Serialize:
        // public void Serialize(Archive* _rArchive) => ((delegate* unmanaged[Thiscall]<ref StringInfoData, Archive*, void>)0xDEADBEEF)(ref this, _rArchive); // .text:0042EEC0 ; void __thiscall StringInfoData::Serialize(StringInfoData *this, Archive *_rArchive) .text:0042EEC0 ?Serialize@StringInfoData@@UAEXAAVArchive@@@Z

        // StringInfoData.Copy:
        // public static StringInfoData* Copy(StringInfoData* i_pcRhs) => ((delegate* unmanaged[Cdecl]<StringInfoData*, StringInfoData*>)0xDEADBEEF)(i_pcRhs); // .text:0042F180 ; StringInfoData *__cdecl StringInfoData::Copy(StringInfoData *i_pcRhs) .text:0042F180 ?Copy@StringInfoData@@SAPAV1@PBV1@@Z
    }

    public unsafe struct LayoutDesc {
        public DBObj dBObj;
        public UInt32 m_displayWidth;
        public UInt32 m_displayHeight;
        public HashTable<UInt32, ElementDesc> m_elements;
        public PStringBase<Char> m_strElementHeader;
        public PStringBase<Char> m_strElementWHeader;
        public PStringBase<Char> m_strStateHeader;
        public PStringBase<Char> m_strStateWHeader;
    };

    public unsafe struct ElementDesc {
        public StateDesc stateDesc;
        public UInt32 m_elementID;
        public UInt32 m_type;
        public UInt32 m_engineType;
        public UInt32 m_baseElement;
        public UInt32 m_baseLayout;  // IDClass__tagDataID,32,0_
        public UInt32 m_defaultState;
        public UInt32 m_leftEdge;
        public UInt32 m_topEdge;
        public UInt32 m_rightEdge;
        public UInt32 m_bottomEdge;
        public HashTable<UInt32, Int32> m_states; // HashTable<UInt32, StateDesc>
        public HashTable<UInt32, Int32> m_children; // HashTable<UInt32, ElementDesc>
        public UInt32 m_uiReadOrder;
        public PStringBase<Char> m_strComments;
        public PStringBase<Char> m_strName;
    };
    public unsafe struct StateDesc {
        // Struct:
        public StateDesc.Vtbl* vfptr;
        public UInt32 m_uiIncorporationFlags;
        public UInt32 m_stateID;
        public Byte m_bIsCode;
        public Byte m_bPassToChildren;
        public int m_x;
        public int m_y;
        public int m_width;
        public int m_height;
        public int m_zLevel;
        public PropertyCollection m_properties;
        public SmartArray<PTR<MediaDesc>> m_media;
        public override string ToString() => $"vfptr:->(StateDesc.Vtbl*)0x{(int)vfptr:X8}, m_uiIncorporationFlags:{m_uiIncorporationFlags:X8}, m_stateID:{m_stateID:X8}, m_bIsCode:{m_bIsCode:X2}, m_bPassToChildren:{m_bPassToChildren:X2}, m_x(int):{m_x}, m_y(int):{m_y}, m_width(int):{m_width}, m_height(int):{m_height}, m_zLevel(int):{m_zLevel}, m_properties(PropertyCollection):{m_properties}, m_media(SmartArray<MediaDesc*,1>):{m_media}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<StateDesc*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(StateDesc *this, unsigned int);
            public fixed int gap4[4];
            public static delegate* unmanaged[Thiscall]<StateDesc*, QualifiedDataIDArray*, void> GetSubDataIDs; // void (__thiscall *GetSubDataIDs)(StateDesc *this, QualifiedDataIDArray *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, PFileNode*, Byte> ToFileNode; // bool (__thiscall *ToFileNode)(StateDesc *this, PFileNode *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, PFileNode*, Byte> FromFileNode; // bool (__thiscall *FromFileNode)(StateDesc *this, PFileNode *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, PFileNode*, Byte> PositionToFileNode; // bool (__thiscall *PositionToFileNode)(StateDesc *this, PFileNode *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, PFileNode*, Byte*, Byte> HandleNode; // bool (__thiscall *HandleNode)(StateDesc *this, PFileNode *, bool *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, PFileNode*, Byte> CheckFFN; // bool (__thiscall *CheckFFN)(StateDesc *this, PFileNode *);
            public static delegate* unmanaged[Thiscall]<StateDesc*, Box2D*, Box2D*, UInt32, UInt32, UInt32, UInt32, void> UpdateSizeAndPosition; // void (__thiscall *UpdateSizeAndPosition)(StateDesc *this, Box2D *, Box2D *, unsigned int, unsigned int, unsigned int, unsigned int);
            public override string ToString() => $"gap4[4](fixed int):{gap4[4]}";
        }
        // Enums:
        public enum INCORPORATIONFLAGS : UInt32 {
            IF_PASSTOCHILDREN = 0x1,
            IF_X = 0x2,
            IF_Y = 0x4,
            IF_WIDTH = 0x8,
            IF_HEIGHT = 0x10,
            IF_ZLEVEL = 0x20,
        };

        // Functions:

        // StateDesc.LoadMedia:
        // public Byte LoadMedia(PFileNode* _node) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte>)0xDEADBEEF)(ref this, _node); // .text:0069C950 ; bool __thiscall StateDesc::LoadMedia(StateDesc *this, PFileNode *_node) .text:0069C950 ?LoadMedia@StateDesc@@IAE_NPBVPFileNode@@@Z

        // StateDesc.Incorporate:
        public Byte Incorporate(StateDesc* _desc) => ((delegate* unmanaged[Thiscall]<ref StateDesc, StateDesc*, Byte>)0x0069DB30)(ref this, _desc); // .text:0069CCA0 ; bool __thiscall StateDesc::Incorporate(StateDesc *this, StateDesc *_desc) .text:0069CCA0 ?Incorporate@StateDesc@@QAE_NABV1@@Z

        // StateDesc.operator_equals:
        public int operator_equals(StateDesc* _rhs) => ((delegate* unmanaged[Thiscall]<ref StateDesc, StateDesc*, int>)0x0069DBB0)(ref this, _rhs); // .text:0069CD20 ; int __thiscall StateDesc::operator=(StateDesc *this, StateDesc *_rhs) .text:0069CD20 ??4StateDesc@@QAEAAV0@ABV0@@Z

        // StateDesc.GetSubDataIDs:
        // public void GetSubDataIDs(QualifiedDataIDArray* _id_array) => ((delegate* unmanaged[Thiscall]<ref StateDesc, QualifiedDataIDArray*, void>)0xDEADBEEF)(ref this, _id_array); // .text:0069BED0 ; void __thiscall StateDesc::GetSubDataIDs(StateDesc *this, QualifiedDataIDArray *_id_array) .text:0069BED0 ?GetSubDataIDs@StateDesc@@UBEXAAVQualifiedDataIDArray@@@Z

        // StateDesc.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref StateDesc, void>)0x0069D010)(ref this); // .text:0069C180 ; void __thiscall StateDesc::StateDesc(StateDesc *this) .text:0069C180 ??0StateDesc@@QAE@XZ

        // StateDesc.CleanupMedia:
        // public void CleanupMedia() => ((delegate* unmanaged[Thiscall]<ref StateDesc, void>)0xDEADBEEF)(ref this); // .text:0069C1E0 ; void __thiscall StateDesc::CleanupMedia(StateDesc *this) .text:0069C1E0 ?CleanupMedia@StateDesc@@IAEXXZ

        // StateDesc.ConcatenateMedia:
        // public void ConcatenateMedia(StateDesc* _rhs) => ((delegate* unmanaged[Thiscall]<ref StateDesc, StateDesc*, void>)0xDEADBEEF)(ref this, _rhs); // .text:0069C9B0 ; void __thiscall StateDesc::ConcatenateMedia(StateDesc *this, StateDesc *_rhs) .text:0069C9B0 ?ConcatenateMedia@StateDesc@@IAEXABV1@@Z

        // StateDesc.__Ctor:
        // public void __Ctor(StateDesc* _rhs) => ((delegate* unmanaged[Thiscall]<ref StateDesc, StateDesc*, void>)0xDEADBEEF)(ref this, _rhs); // .text:0069CD90 ; void __thiscall StateDesc::StateDesc(StateDesc *this, StateDesc *_rhs) .text:0069CD90 ??0StateDesc@@QAE@ABV0@@Z

        // StateDesc.UpdateSizeAndPosition:
        // public void UpdateSizeAndPosition(Box2D* _oldParent, Box2D* _newParent, UInt32 _leftEdge, UInt32 _topEdge, UInt32 _rightEdge, UInt32 _bottomEdge) => ((delegate* unmanaged[Thiscall]<ref StateDesc, Box2D*, Box2D*, UInt32, UInt32, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _oldParent, _newParent, _leftEdge, _topEdge, _rightEdge, _bottomEdge); // .text:0069BF20 ; void __thiscall StateDesc::UpdateSizeAndPosition(StateDesc *this, Box2D *_oldParent, Box2D *_newParent, unsigned int _leftEdge, unsigned int _topEdge, unsigned int _rightEdge, unsigned int _bottomEdge) .text:0069BF20 ?UpdateSizeAndPosition@StateDesc@@UAEXABVBox2D@@0KKKK@Z

        // StateDesc.PositionToFileNode:
        public Byte PositionToFileNode(PFileNode* _file_node) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte>)0x0069D060)(ref this, _file_node); // .text:0069C1D0 ; bool __thiscall StateDesc::PositionToFileNode(StateDesc *this, PFileNode *_file_node) .text:0069C1D0 ?PositionToFileNode@StateDesc@@MBE_NPAVPFileNode@@@Z

        // StateDesc.ToFileNode:
        // public Byte ToFileNode(PFileNode* _file_node) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte>)0xDEADBEEF)(ref this, _file_node); // .text:0069C2D0 ; bool __thiscall StateDesc::ToFileNode(StateDesc *this, PFileNode *_file_node) .text:0069C2D0 ?ToFileNode@StateDesc@@UBE_NPAVPFileNode@@@Z

        // StateDesc.InqProperty:
        // public Byte InqProperty(UInt32 _name, BaseProperty* _property) => ((delegate* unmanaged[Thiscall]<ref StateDesc, UInt32, BaseProperty*, Byte>)0xDEADBEEF)(ref this, _name, _property); // .text:0069C790 ; bool __thiscall StateDesc::InqProperty(StateDesc *this, const unsigned int _name, BaseProperty *_property) .text:0069C790 ?InqProperty@StateDesc@@QBE_NKAAVBaseProperty@@@Z

        // StateDesc.FromFileNode:
        public Byte FromFileNode(PFileNode* _file_node) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte>)0x0069D640)(ref this, _file_node); // .text:0069C7B0 ; bool __thiscall StateDesc::FromFileNode(StateDesc *this, PFileNode *_file_node) .text:0069C7B0 ?FromFileNode@StateDesc@@UAE_NPBVPFileNode@@@Z

        // StateDesc.ContainsProperty:
        public Byte ContainsProperty(UInt32 _property) => ((delegate* unmanaged[Thiscall]<ref StateDesc, UInt32, Byte>)0x0069D8D0)(ref this, _property); // .text:0069CA40 ; bool __thiscall StateDesc::ContainsProperty(StateDesc *this, const unsigned int _property) .text:0069CA40 ?ContainsProperty@StateDesc@@QBE_NK@Z

        // StateDesc.CheckFFN:
        // public Byte CheckFFN(PFileNode* _file_node) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte>)0xDEADBEEF)(ref this, _file_node); // .text:0069C440 ; bool __thiscall StateDesc::CheckFFN(StateDesc *this, PFileNode *_file_node) .text:0069C440 ?CheckFFN@StateDesc@@MAE_NPBVPFileNode@@@Z

        // StateDesc.Serialize:
        // public void Serialize(Archive* _io_archive) => ((delegate* unmanaged[Thiscall]<ref StateDesc, Archive*, void>)0xDEADBEEF)(ref this, _io_archive); // .text:0069C5F0 ; void __thiscall StateDesc::Serialize(StateDesc *this, Archive *_io_archive) .text:0069C5F0 ?Serialize@StateDesc@@UAEXAAVArchive@@@Z

        // StateDesc.SetMediaImage:
        public void SetMediaImage(UInt32 _imageID, UInt32 _drawMode) => ((delegate* unmanaged[Thiscall]<ref StateDesc, UInt32, UInt32, void>)0x0069D8E0)(ref this, _imageID, _drawMode); // .text:0069CA50 ; void __thiscall StateDesc::SetMediaImage(StateDesc *this, IDClass<_tagDataID,32,0> _imageID, unsigned int _drawMode) .text:0069CA50 ?SetMediaImage@StateDesc@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // StateDesc.HandleNode:
        // public Byte HandleNode(PFileNode* _node, Byte* _handled) => ((delegate* unmanaged[Thiscall]<ref StateDesc, PFileNode*, Byte*, Byte>)0xDEADBEEF)(ref this, _node, _handled); // .text:0069CB00 ; bool __thiscall StateDesc::HandleNode(StateDesc *this, PFileNode *_node, bool *_handled) .text:0069CB00 ?HandleNode@StateDesc@@MAE_NPBVPFileNode@@AA_N@Z
    }

    public unsafe struct PFileNode {
        /*
        public Turbine_RefCount _ref;
        public IFileNodeName* m_pcName;
        public UInt16 line_number;
        public UInt16 column_number;
        public PStringBase<Char> comment_string;
        public PStringBase<Char> m_filename;
        public SmartArray<PTR<PFileNode>> sub_nodes;
        public Byte m_bProcessed;
        public IntrusiveSmartPoInt32er_FileNodeFileInfo_ m_fileInfo;
        public PFileNode* m_pcParent;
        public UInt32 user_data;
        */
    };
    public unsafe struct IntrusiveSmartPoInt32er_FileNodeFileInfo_ {
        public FileNodeFileInfo* m_data;
    };
    public unsafe struct FileNodeFileInfo {
        public Turbine_RefCount _ref;
        public PStringBase<Char> m_filename;
        public UInt16 m_errorCount;
        public UInt16 m_warningCount;
        public UInt32 m_compatabilityVersion;
    };
    public unsafe struct IFileNodeName {
        // Struct:
        public IFileNodeName.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(IFileNodeName.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(IFileNodeName *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, NodeNameType> _GetType; // NodeNameType (__thiscall *GetType)(IFileNodeName *this);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, IFileNodeName*> Clone; // IFileNodeName *(__thiscall *Clone)(IFileNodeName *this);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, IFileNodeName*, Byte> operator_is_equal; // bool (__thiscall *operator==)(IFileNodeName *this, IFileNodeName *);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, PStringBase<char>*, Byte> FromPString; // bool (__thiscall *FromPString)(IFileNodeName *this, PStringBase<char> *);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, PStringBase<char>*, PStringBase<char>*> ToPString; // PStringBase<char> *(__thiscall *ToPString)(IFileNodeName *this, PStringBase<char> *result);
            public static delegate* unmanaged[Thiscall]<IFileNodeName*, Archive*, void> Serialize; // void (__thiscall *Serialize)(IFileNodeName *this, Archive *);
        }

        // Functions:

        // IFileNodeName.GetNameType:
        // public static NodeNameType GetNameType(IFileNodeName* i_pcName) => ((delegate* unmanaged[Cdecl]<IFileNodeName*, NodeNameType>)0xDEADBEEF)(i_pcName); // .text:00659F90 ; NodeNameType __cdecl IFileNodeName::GetNameType(IFileNodeName *i_pcName) .text:00659F90 ?GetNameType@IFileNodeName@@SA?AW4NodeNameType@@PAV1@@Z

        // IFileNodeName.CreateFromEnum:
        // public static IFileNodeName* CreateFromEnum(NodeNameType i_enumType) => ((delegate* unmanaged[Cdecl]<NodeNameType, IFileNodeName*>)0xDEADBEEF)(i_enumType); // .text:0065A7C0 ; IFileNodeName *__cdecl IFileNodeName::CreateFromEnum(NodeNameType i_enumType) .text:0065A7C0 ?CreateFromEnum@IFileNodeName@@SAPAV1@W4NodeNameType@@@Z
    }


    public unsafe struct UILocationData {
        public Single m_x0;
        public Single m_y0;
        public Single m_x1;
        public Single m_y1;
        public Byte m_shown;
    };
    public unsafe struct StringInfo {
        public PStringBase<byte> m_strToken;
        public UInt32 m_stringID;
        public UInt32 m_tableID;
        public HashTable<UInt32, StringInfoData> m_variables;
        public PStringBase<UInt16> m_LiteralValue;
        public byte m_Override;
        public PStringBase<byte> m_strEnglish;
        public PStringBase<byte> m_strComment;

        public override string ToString() {
            return $"m_strToken:{m_strToken.ToString()} m_strEnglish:{m_strEnglish.ToString()} m_strComment:{m_strComment.ToString()} m_LiteralValue:{m_LiteralValue.ToString()} m_stringID:{m_stringID:X8} m_tableID:{m_tableID:X8} m_Override:{m_Override}";
        }
    };


    public unsafe struct MediaMachine {
        public UIListener uIListener;
        public UIElement* m_owner;
        public SmartArray<PTR<MediaDesc>> m_array;
        public UInt32 m_curIndex;
    };
    public unsafe struct MediaDesc {
        public MediaDescVtbl* vfptr;
        public UInt32 m_type;
    };
    public unsafe struct MediaDescVtbl {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void* __vecDelDtor(MediaDesc* This, UInt32 a2); //  void *(__thiscall____vecDelDtor)(MediaDesc *this, UInt32);
        public fixed Int32 padding[3];
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Anim* DynamicCast_Anim(MediaDesc* This); // MD_Data_Anim *(__thiscall *DynamicCast_Anim)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Image* DynamicCast_Image(MediaDesc* This); // MD_Data_Image *(__thiscall *DynamicCast_Image)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Alpha* DynamicCast_Alpha(MediaDesc* This); // MD_Data_Alpha *(__thiscall *DynamicCast_Alpha)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Pause* DynamicCast_Pause(MediaDesc* This); // MD_Data_Pause *(__thiscall *DynamicCast_Pause)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Jump* DynamicCast_Jump(MediaDesc* This); // MD_Data_Jump *(__thiscall *DynamicCast_Jump)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Message* DynamicCast_Message(MediaDesc* This); // MD_Data_Message *(__thiscall *DynamicCast_Message)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Sound* DynamicCast_Sound(MediaDesc* This); // MD_Data_Sound *(__thiscall *DynamicCast_Sound)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_State* DynamicCast_State(MediaDesc* This); // MD_Data_State *(__thiscall *DynamicCast_State)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Movie* DynamicCast_Movie(MediaDesc* This); // MD_Data_Movie *(__thiscall *DynamicCast_Movie)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Cursor* DynamicCast_Cursor(MediaDesc* This); // MD_Data_Cursor *(__thiscall *DynamicCast_Cursor)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate MD_Data_Fade* DynamicCast_Fade(MediaDesc* This); // MD_Data_Fade *(__thiscall *DynamicCast_Fade)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate Single GetDuration(MediaDesc* This); // Single(__thiscall *GetDuration)(MediaDesc *this);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate bool ToFileNode(MediaDesc* This); // bool(__thiscall *ToFileNode)(MediaDesc *this, PFileNode *);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate bool FromFileNode(MediaDesc* This); // bool(__thiscall *FromFileNode)(MediaDesc *this, PFileNode *);
    };
    public unsafe struct MD_Data_Anim {
        public MediaDesc mediaDesc;
        public Single m_duration;
        public UInt32 m_drawMode;
        public SmartArray<UInt32> m_frames;
        public Double m_StartTime;
        public Int32 m_displayedFrameNum;
    };
    public unsafe struct MD_Data_Image {
        public MediaDesc mediaDesc;
        public UInt32 m_file;
        public UInt32 m_drawMode;
    };
    public unsafe struct MD_Data_Alpha {
        public MediaDesc mediaDesc;
        public UInt32 m_file;
    };
    public unsafe struct MD_Data_Pause {
        public MediaDesc mediaDesc;
        public Single m_minDuration;
        public Single m_maxDuration;
        public Double m_endTime;
    };
    public unsafe struct MD_Data_Jump {
        public MediaDesc mediaDesc;
        public UInt32 m_jumpItemIndex;
        public Single m_probability;
    };
    public unsafe struct MD_Data_Message {
        public MediaDesc mediaDesc;
        public UInt32 m_messageID;
        public Single m_probability;
    };
    public unsafe struct MD_Data_Sound {
        public MediaDesc mediaDesc;
        public UInt32 m_file;
        public SoundType m_stype;
    };
    public unsafe struct MD_Data_State {
        public MediaDesc mediaDesc;
        public UInt32 m_stateID;
        public Single m_probability;
    };
    public unsafe struct MD_Data_Movie {
        public MediaDesc mediaDesc;
        public PStringBase<Char> m_strFileName;
        public Byte m_StretchToFullScreen;
        public MovieTheatre* m_pMovieTheatre;
    };
    public unsafe struct MD_Data_Cursor {
        public MediaDesc mediaDesc;
        public UInt32 m_file;
        public Int32 m_xHotspot;
        public Int32 m_yHotspot;
    };
    public unsafe struct MD_Data_Fade {
        public MediaDesc mediaDesc;
        public Single m_startAlpha;
        public Single m_endAlpha;
        public Single m_duration;
        public Double m_startTime;
    };

    public unsafe struct MovieTheatre {
        public Turbine_RefCount _ref;
        public UIElement* m_pOwner;
        public UInt32 m_Flags;
        public Byte m_bStopped;
        // public ATL__CComPtr_IGraphBuilder_ m_pGB; // ran out of steam on this rabbit hole.
        // public ATL__CComPtr_IMediaControl_ m_pMC;
        // public ATL__CComPtr_IMediaPosition_ m_pMP;
        // public ATL__CComPtr_IMediaEvent_ m_pME;
        // public ATL__CComPtr_IBaseFilter_ m_pRenderer;
    };

    public unsafe struct ATL__CComPtrBase<T> where T : unmanaged {
        public T* p;
    }
    public unsafe struct ATL__CComPtr<T> where T : unmanaged {
        public ATL__CComPtrBase<T> Base;
    };
    public unsafe struct UIObject {
        public Turbine_RefCount _ref;
        public Byte m_bVisible;
        public Byte m_bTemporary;
        public UInt32 m_eClampGameView;
        public Int32 m_nDepth;
        public Double m_tTouchTime;
        public UInt32 m_nVirtualX;
        public UInt32 m_nVirtualY;
        public UInt32 m_nVirtualWidth;
        public UInt32 m_nVirtualHeight;
        public Vector3 m_vScale;
        public UIRegion* m_pOwner;
        public SmartArray<Box2D> m_dirtyRects;
    };


    public unsafe struct ItemListDragHandler {
        // Struct:
        public ItemListDragHandler.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ItemListDragHandler*, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte> OnItemListDragOver; // bool (__thiscall *OnItemListDragOver)(ItemListDragHandler *this, UIElement_UIItem *, unsigned int, unsigned int, DropItemFlags);
        }

        // Functions:

        // ItemListDragHandler.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref ItemListDragHandler, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004A38F0)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004A3580 ; bool __thiscall ItemListDragHandler::OnItemListDragOver(ItemListDragHandler *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004A3580 ?OnItemListDragOver@ItemListDragHandler@@UAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z
    }


    public unsafe struct FontCharDesc {
        public UInt16 m_Unicode;
        public UInt16 m_OffsetX;
        public UInt16 m_OffsetY;
        public Char m_Width;
        public Char m_Height;
        public Char m_HorizontalOffsetBefore;
        public Char m_HorizontalOffsetAfter;
        public Char m_VerticalOffsetBefore;
    };
    public unsafe struct Font {
        public DBObj dBObj;
        public UInt32 maxCharHeight;
        public UInt32 maxCharWidth;
        public UInt32 numCharacters;
        public FontCharDesc* CharDescs;
        public UInt32 m_NumHorizontalBorderPixels;
        public UInt32 m_NumVerticalBorderPixels;
        public Int32 m_BaselineOffset;
        public PStringBase<Char> m_ForegroundSurfaceFileName;
        public UInt32 m_ForegroundSurfaceDataID; // UInt32
        public RenderSurface* m_pForegroundSurface;
        public PStringBase<Char> m_BackgroundSurfaceFileName;
        public UInt32 m_BackgroundSurfaceDataID; // UInt32
        public RenderSurface* m_pBackgroundSurface;
        public UInt16 minUnicodeChar;
        public UInt16 maxUnicodeChar;
        public UInt32 unicodeRangeLength;
        public UInt16* CharacterMap;
    };



    public unsafe struct StringDownload {
        public AsyncCacheCallback asyncCacheCallback;
        public StringInfo m_info;
        public UInt32 m_fontDIDNum;
        public UInt32 m_fontColorNum;
        public AsyncContext m_prefetchContext;
    };
    public unsafe struct AsyncContext {
        public UInt32 m_id;
    };
    public unsafe struct AsyncCacheCallback {
        public AsyncCacheCallbackVtbl* vfptr;
    };
    public unsafe struct AsyncCacheCallbackVtbl {
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void OnContextFinished(AsyncCacheCallback* This, AsyncContext hContext, AsyncResult Result, UInt32 dwUser1); // void(__thiscall *OnContextFinished)(AsyncCacheCallback *this, AsyncContext, AsyncResult, UInt32);
        [UnmanagedFunctionPointer(CallingConvention.ThisCall)] public delegate void OnTopLevelRequestFinished(AsyncCacheCallback* This, AsyncContext hContext, QualifiedDataID qdid, AsyncResult Result, UInt32 dwUser1, Int32 nTimesFinished, void* hInternal); // void(__thiscall *OnTopLevelRequestFinished)(AsyncCacheCallback *this, AsyncContext, QualifiedDataID, AsyncResult, UInt32, Int32, void *);
    };

    public unsafe struct GlyphList {
        public _Vtbl* vfptr;
        public _List<Glyph> m_glyphList;
        public SmartArray<GlyphLine> m_glyphLines;
        public UInt32 m_nMaxCharacters;
        public Byte m_bTrimFromTop;
        public UInt32 m_cxLastRecalcWidth;
        public UInt32 m_nFirstInvalidPosition;
        public Byte m_bOneLine;
    };

    public unsafe struct Glyph {
        public UInt16 m_data;
        public Int32 m_width;
        public Int32 m_height;
        public RGBAColor m_color;
        public Font* m_font;
        public TextTag* m_tag;
    };
    public unsafe struct GlyphLine {
        public _Vtbl* vfptr;
        public UInt32 m_nIndex;
        public Int32 m_nLineWidth;
        public Int32 m_nLineHeight;
    };

    public unsafe struct TextTag {
        public Turbine_RefCount _ref;
        public UInt32 m_type;
        public UInt32 m_format;
    };


    public unsafe struct UIElementMessageInfo {
        public UInt32 idElement;
        public UIElement* pElement;
        public UInt32 idMessage;
        public UInt32 dwParam1;
        public UInt32 dwParam2;
        public tagPOINT ptWindow;
        public tagPOINT ptElement;
        public CTimestamp_unsigned_long_0_ tsSerialNumber;
    };

    public unsafe struct gmNoticeHandler {
        // Struct:
        public NoticeHandler a0;
        public override string ToString() => $"a0(NoticeHandler):{a0}";
    }
    public unsafe struct NoticeHandler {
        // Struct:
        public NoticeHandler.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(NoticeHandler.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, Byte> IsEngine; // bool (__thiscall *IsEngine)(NoticeHandler *this);
            public fixed byte gap4[8];
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, Byte, UInt32, UInt32, void> RecvNotice_RuntimeDDDStatus; // void (__thiscall *RecvNotice_RuntimeDDDStatus)(NoticeHandler *this, bool, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, void> RecvNotice_ItemAttributesChanged; // void (__thiscall *RecvNotice_ItemAttributesChanged)(NoticeHandler *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, void> RecvNotice_ServerSaysAttemptFailed; // void (__thiscall *RecvNotice_ServerSaysAttemptFailed)(NoticeHandler *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void> RecvNotice_ServerSaysMoveItem; // void (__thiscall *RecvNotice_ServerSaysMoveItem)(NoticeHandler *this, unsigned int, unsigned int, unsigned int, unsigned int, unsigned int, int, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, void> RecvNotice_SetSelectedItem; // void (__thiscall *RecvNotice_SetSelectedItem)(NoticeHandler *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, CharError, void> RecvNotice_CharacterError; // void (__thiscall *RecvNotice_CharacterError)(NoticeHandler *this, charError);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, void> RecvNotice_ServerDied; // void (__thiscall *RecvNotice_ServerDied)(NoticeHandler *this);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, AC1Legacy.PStringBase<char>*, void> RecvNotice_WorldName; // void (__thiscall *RecvNotice_WorldName)(NoticeHandler *this, AC1Legacy::PStringBase<char> *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, CWeenieObject*, void> RecvNotice_BeingDeleted; // void (__thiscall *RecvNotice_BeingDeleted)(NoticeHandler *this, CWeenieObject *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, void> RecvNotice_CreateObject; // void (__thiscall *RecvNotice_CreateObject)(NoticeHandler *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, PropertyCollection*, void> RecvNotice_CloseDialog; // void (__thiscall *RecvNotice_CloseDialog)(NoticeHandler *this, unsigned int, PropertyCollection *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, StringInfo*, StringInfo*, UInt32, void> RecvNotice_DisplayFinalStringInfo; // void (__thiscall *RecvNotice_DisplayFinalStringInfo)(NoticeHandler *this, unsigned int, StringInfo *, StringInfo *, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, StringInfo*, void> RecvNotice_DisplayStringInfo; // void (__thiscall *RecvNotice_DisplayStringInfo)(NoticeHandler *this, unsigned int, StringInfo *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, AC1Legacy.PStringBase<char>*, void> RecvNotice_DisplayWeenieError; // void (__thiscall *RecvNotice_DisplayWeenieError)(NoticeHandler *this, unsigned int, AC1Legacy::PStringBase<char> *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, void> RecvNotice_OpenDialog; // void (__thiscall *RecvNotice_OpenDialog)(NoticeHandler *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, void> RecvNotice_SmartBoxObjectFound; // void (__thiscall *RecvNotice_SmartBoxObjectFound)(NoticeHandler *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, void> RecvNotice_TextTag_DIDClick; // void (__thiscall *RecvNotice_TextTag_DIDClick)(NoticeHandler *this, unsigned int, IDClass<_tagDataID,32,0>);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, void> RecvNotice_TextTag_IIDClick; // void (__thiscall *RecvNotice_TextTag_IIDClick)(NoticeHandler *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, UInt32, void> RecvNotice_TextTag_IIDEnumClick; // void (__thiscall *RecvNotice_TextTag_IIDEnumClick)(NoticeHandler *this, unsigned int, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, PStringBase<UInt16>*, void> RecvNotice_TextTag_IIDStringClick; // void (__thiscall *RecvNotice_TextTag_IIDStringClick)(NoticeHandler *this, unsigned int, unsigned int, PStringBase<unsigned short> *);
            public static delegate* unmanaged[Thiscall]<NoticeHandler*, UInt32, UInt32, UInt32, UInt32, void> RecvNotice_UpdateGameView; // void (__thiscall *RecvNotice_UpdateGameView)(NoticeHandler *this, unsigned int, unsigned int, unsigned int, unsigned int);
        }

        // Functions:

        // NoticeHandler.RecvNotice_DisplayFinalStringInfo:
        public void RecvNotice_DisplayFinalStringInfo(UInt32 i_vendorID, VendorProfile* i_vendorProfile, PackableList<ItemProfile>* i_itemProfileList, ShopMode i_startMode) => ((delegate* unmanaged[Thiscall]<ref NoticeHandler, UInt32, VendorProfile*, PackableList<ItemProfile>*, ShopMode, void>)0x004015F0)(ref this, i_vendorID, i_vendorProfile, i_itemProfileList, i_startMode); // .text:00401630 ; void __thiscall NoticeHandler::RecvNotice_DisplayFinalStringInfo(gmNoticeHandler *this, unsigned int i_vendorID, VendorProfile *i_vendorProfile, PackableList<ItemProfile> *i_itemProfileList, ShopMode i_startMode) .text:00401630 ?RecvNotice_DisplayFinalStringInfo@NoticeHandler@@UAEXKABVStringInfo@@0K@Z

        // NoticeHandler.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 i_itemID, UInt32 i_oldContainer, UInt32 i_oldWielder, UInt32 i_oldLocation, UInt32 i_newContainer, int i_place, UInt32 i_newWielder, UInt32 i_newLocation) => ((delegate* unmanaged[Thiscall]<ref NoticeHandler, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004015E0)(ref this, i_itemID, i_oldContainer, i_oldWielder, i_oldLocation, i_newContainer, i_place, i_newWielder, i_newLocation); // .text:00401620 ; void __thiscall NoticeHandler::RecvNotice_ServerSaysMoveItem(NoticeHandler *this, unsigned int i_itemID, unsigned int i_oldContainer, unsigned int i_oldWielder, unsigned int i_oldLocation, unsigned int i_newContainer, int i_place, unsigned int i_newWielder, unsigned int i_newLocation) .text:00401620 ?RecvNotice_ServerSaysMoveItem@NoticeHandler@@UAEXKKKKKHKK@Z
    }


    public unsafe struct NoticeRegistrar {
        // Struct:
        public Vtbl* vfptr;
        public HashTable<UInt32, PTR<_List<PTR<NoticeHandler>>>>* m_handlers;
        public override string ToString() => $"vfptr:->(NoticeRegistrar::Vtbl*)0x{(int)vfptr:X8}, m_handlers:->(HashTable<UInt32,List<NoticeHandler*>*,0>*)0x{(int)m_handlers:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<NoticeRegistrar*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(NoticeRegistrar *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<NoticeRegistrar*, UInt32, NoticeHandler*, Byte> RegisterNoticeHandler; // bool (__thiscall *RegisterNoticeHandler)(NoticeRegistrar *this, unsigned int, NoticeHandler *);
            public static delegate* unmanaged[Thiscall]<NoticeRegistrar*, UInt32, NoticeHandler*, Byte> UnRegisterNoticeHandler; // bool (__thiscall *UnRegisterNoticeHandler)(NoticeRegistrar *this, unsigned int, NoticeHandler *);
            public static delegate* unmanaged[Thiscall]<NoticeRegistrar*, NoticeHandler*, Byte> UnRegisterAllNoticeHandlers; // bool (__thiscall *UnRegisterAllNoticeHandlers)(NoticeRegistrar *this, NoticeHandler *);
            public static delegate* unmanaged[Thiscall]<NoticeRegistrar*, UInt32, _List<PTR<NoticeHandler>>*> GetNoticeHandlers; // List<NoticeHandler *> *(__thiscall *GetNoticeHandlers)(NoticeRegistrar *this, unsigned int);
        }

        // Functions:

        // NoticeRegistrar.RegisterNoticeHandler:
        public Byte RegisterNoticeHandler(UInt32 i_notice, NoticeHandler* i_pcHandler) => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, UInt32, NoticeHandler*, Byte>)0x0043C870)(ref this, i_notice, i_pcHandler); // .text:0043C870 ; bool __thiscall NoticeRegistrar::RegisterNoticeHandler(NoticeRegistrar *this, unsigned int i_notice, NoticeHandler *i_pcHandler) .text:0043C870 ?RegisterNoticeHandler@NoticeRegistrar@@UAE_NKPAVNoticeHandler@@@Z

        // NoticeRegistrar.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, void>)0x0043C480)(ref this); // .text:0043C480 ; void __thiscall NoticeRegistrar::NoticeRegistrar(NoticeRegistrar *this) .text:0043C480 ??0NoticeRegistrar@@QAE@XZ

        // NoticeRegistrar.DestroyHandlers:
        public void DestroyHandlers() => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, void>)0x0043C500)(ref this); // .text:0043C500 ; void __thiscall NoticeRegistrar::DestroyHandlers(NoticeRegistrar *this) .text:0043C500 ?DestroyHandlers@NoticeRegistrar@@IAEXXZ

        // NoticeRegistrar.UnRegisterNoticeHandler:
        public Byte UnRegisterNoticeHandler(UInt32 i_notice, NoticeHandler* i_pcHandler) => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, UInt32, NoticeHandler*, Byte>)0x0043C660)(ref this, i_notice, i_pcHandler); // .text:0043C660 ; bool __thiscall NoticeRegistrar::UnRegisterNoticeHandler(NoticeRegistrar *this, unsigned int i_notice, NoticeHandler *i_pcHandler) .text:0043C660 ?UnRegisterNoticeHandler@NoticeRegistrar@@UAE_NKPAVNoticeHandler@@@Z

        // NoticeRegistrar.UnRegisterAllNoticeHandlers:
        public Byte UnRegisterAllNoticeHandlers(NoticeHandler* i_pcHandler) => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, NoticeHandler*, Byte>)0x0043C6A0)(ref this, i_pcHandler); // .text:0043C6A0 ; bool __thiscall NoticeRegistrar::UnRegisterAllNoticeHandlers(NoticeRegistrar *this, NoticeHandler *i_pcHandler) .text:0043C6A0 ?UnRegisterAllNoticeHandlers@NoticeRegistrar@@UAE_NPAVNoticeHandler@@@Z

        // NoticeRegistrar.GetNoticeHandlers:
        public _List<PTR<NoticeHandler>>* GetNoticeHandlers(UInt32 i_notice) => ((delegate* unmanaged[Thiscall]<ref NoticeRegistrar, UInt32, _List<PTR<NoticeHandler>>*>)0x0043C730)(ref this, i_notice); // .text:0043C730 ; List<NoticeHandler *> *__thiscall NoticeRegistrar::GetNoticeHandlers(NoticeRegistrar *this, unsigned int i_notice) .text:0043C730 ?GetNoticeHandlers@NoticeRegistrar@@UAEPAV?$List@PAVNoticeHandler@@@@K@Z
    }



    //public static GlobalEventHandler* This = (GlobalEventHandler*)*(Int32*)0x00838374;
    public unsafe struct GlobalEventHandler {
        public NoticeRegistrar a0;
        public override string ToString() => a0.ToString();


        //public HashBaseData64<T>* GetByID(UInt64 id) {
        //    var iter = buckets[table_mask & (id ^ (id >> key_shift))];
        //    while ((Int32)iter != 0 && iter->id != id) {
        //        iter = iter->hash_next;
        //    }
        //    if (iter->id != id)
        //        return null;
        //    return iter;
        //}

        public int ResolveHandler(UInt32 key) {
            // GlobalEventHandler == ;
            IntrusiveHashTable<UInt32, HashTableData<UInt32, PTR<_List<PTR<NoticeHandler>>>>>* tbl = &(a0.m_handlers->m_Int32rusiveTable);
            HashTableData<UInt32, PTR<_List<PTR<NoticeHandler>>>>* iter = (tbl->m_buckets[key % (tbl->m_numBuckets)]);
            if (iter == null) return 0;
            while (iter->m_hashKey != key) {
                iter = iter->m_hashNext;
                if (iter == null) return 0;
            }
            if (iter == null) {
                return 0;
            }
            return *(int*)*(int*)((*(int*)&iter->m_data) + 4) - 1528;
        }
        //public static NoticeHandler* ResolveHandler(UInt32 handlerID) {

        //        Int32 m_handlers = *(Int32*)((*(Int32*)(*P.GlobalEventHandler + 4)) + 8 + ((handlerID % 0x17) << 2));
        //        while (*(Int32*)m_handlers != handlerID) m_handlers = *(Int32*)(m_handlers + 4);
        //        return *(Int32*)*(Int32*)(*(Int32*)(m_handlers + 8) + 4);
        //}

        /*
        UInt32 *__thiscall HashTable<UInt32,void (__cdecl *)(PropertyCollection const &),0>::find(HashTable<UInt32,UInt32,0> *this, const UInt32 *_key)
        {
        HashTableData<UInt32,UInt32> *v2; // eax@1
        UInt32 *result; // eax@4

        v2 = this->m_Int32rusiveTable.m_buckets[*_key % this->m_Int32rusiveTable.m_numBuckets];
        if ( !v2 )
        goto LABEL_4;
        while ( v2->m_hashKey != *_key )
        {
        v2 = v2->m_hashNext;
        if ( !v2 )
        goto LABEL_4;
        }
        if ( v2 )
        result = &v2->m_data;
        else
        LABEL_4:
        result = 0;
        return result;
        }
        */

        // Functions:

        // GlobalEventHandler.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref GlobalEventHandler, void>)0x0043C640)(ref this); // .text:0043C400 ; void __thiscall GlobalEventHandler::GlobalEventHandler(GlobalEventHandler *this) .text:0043C400 ??0GlobalEventHandler@@QAE@XZ

        // GlobalEventHandler.GetGlobalEventHandler:
        public static GlobalEventHandler* GetGlobalEventHandler() => ((delegate* unmanaged[Cdecl]<GlobalEventHandler*>)0x0043C680)(); // .text:0043C440 ; GlobalEventHandler *__cdecl GlobalEventHandler::GetGlobalEventHandler() .text:0043C440 ?GetGlobalEventHandler@GlobalEventHandler@@SAPAV1@XZ

        // Globals:
        public static GlobalEventHandler* geh = *(GlobalEventHandler**)0x00838374; // .data:00837374 ; GlobalEventHandler *GlobalEventHandler::geh .data:00837374 ?geh@GlobalEventHandler@@1PAV1@A
    }

    public unsafe struct gmGlobalEventHandler {
        // Struct:
        public GlobalEventHandler a0;
        public override string ToString() => $"a0(GlobalEventHandler):{a0}";

        // Functions:

        // gmGlobalEventHandler.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref gmGlobalEventHandler, void>)0xDEADBEEF)(ref this); // .text:0047A3F0 ; void __thiscall gmGlobalEventHandler::gmGlobalEventHandler(gmGlobalEventHandler *this) .text:0047A3F0 ??0gmGlobalEventHandler@@QAE@XZ

        // gmGlobalEventHandler.gmGetGlobalEventHandler:
        public static gmGlobalEventHandler* gmGetGlobalEventHandler() => ((delegate* unmanaged[Cdecl]<gmGlobalEventHandler*>)0x0047A810)(); // .text:0047A410 ; gmGlobalEventHandler *__cdecl gmGlobalEventHandler::gmGetGlobalEventHandler() .text:0047A410 ?gmGetGlobalEventHandler@gmGlobalEventHandler@@SAPAV1@XZ
    }




    public unsafe struct DragDropInfo {
        // Struct:
        public Turbine_RefCount a0;
        public UIElement* element;
        public UIElement* owner;
        public UIElement* catcher;
        public Byte success;
        public override string ToString() => $"a0(Turbine_RefCount):{a0}, element:->(UIElement*)0x{(int)element:X8}, owner:->(UIElement*)0x{(int)owner:X8}, catcher:->(UIElement*)0x{(int)catcher:X8}, success:{success:X2}";
    }




    public enum UIElement_SmartBoxWrapper_SearchReason : int {
        sr_None = 0x0,
        sr_MouseOver = 0x1,
        sr_Select = 0x2,
        sr_Examine = 0x3,
        sr_Use = 0x4,
        sr_Drop = 0x5,
        sr_Drag = 0x6,
        sr_TargetedUse = 0x7,
    };

    public unsafe struct UIElement_SmartBoxWrapper {
        public gmNoticeHandler b;
        public UIElement_Field a;
        public uint m_cFlipCount;
        public double m_timeNextFlip;
        public uint m_iidUnderMouse;
        public uint m_iidSelectedObject;
        public UIElement_SmartBoxWrapper_SearchReason m_SearchReason;
        public bool m_fMouseMovementActive;
        public bool m_fMouseMovementInProgress;
        public SECTION_3D m_CurrentSection;
        public uint m_dropItemID;
        public uint m_targetMode;
        public UIElement* m_dragIcon;
    }

    public unsafe struct VividTargetIndicator {
        public gmNoticeHandler gmNoticeHandler;
        public QualityChangeHandler qualityChangeHandler;
        public uint m_idSelectedTarget;
        public RGBAColor m_clrSelectedObjectColor;
        public uint m_vtiCurrent;
        public RGBAColor m_clrOnScreen;
        public RGBAColor m_clrOffScreen;
        public SmartArray<PTR<RenderSurface>> m_rgSourceImages;
        public UIElement* m_pOffScreen;
        public UIElement* m_pOnScreen;
        public SmartArray<PTR<UIElement>> m_rgOnScreenCorners;
        public bool m_bDisplayOn;
        public bool m_bEnabled;
    };

    public unsafe struct gmSmartBoxUI {
        public UIElement_SmartBoxWrapper* m_pSmartBoxWrapper;
        public SmartBox* m_pSmartBox;
        public CPhysicsObj* teleportObj;
        public double gameVDist;
        public TeleportAnimState teleportAnimState;
        public double teleportRotationStartTime;
        public double teleportRotationDuration;
        public double teleportRotationStartAngle;
        public double teleportRotationEndAngle;
        public double teleportTransitionStartTime;
        public double teleportRotationCurAngle;
        public float teleportCurVDist;
        public UIElement_Text* m_pFPSDisplay;
        public UIElement_Viewport* m_pPortalSpace;
        public VividTargetIndicator m_vti;
        public uint m_eWindowID;
        public UIElement* m_pTopBorder;
        public UIElement* m_pLeftBorder;
        public UIElement* m_pBottomBorder;
        public UIElement* m_pRightBorder;
        public UIElement* m_pTopLeftCorner;
        public UIElement* m_pTopRightCorner;
        public UIElement* m_pBottomLeftCorner;
        public UIElement* m_pBottomRightCorner;
    };




    public unsafe struct UIElement {
        // Struct:
        public UIRegion a0;
        public UIElement* m_itemDragged;
        public UIElement* m_pFocusElement;
        public MediaMachine m_mediaMachine;
        public LayoutDesc* m_layout;
        public ElementDesc m_desc;
        public UInt32 m_state;
        public StateDesc* m_curStateDesc;
        public PropertyCollection m_instanceProperties;
        public BorderLocation m_currentBorder;
        public int m_DragStartX;
        public int m_DragStartY;
        public int m_DragStartHeight;
        public int m_DragStartWidth;
        public int m_mouseInitialX;
        public int m_mouseInitialY;
        public static delegate* unmanaged[Cdecl]<UIElement*, UIElement*, Byte> m_dragDropCallback; // bool (__cdecl *m_dragDropCallback)(UIElement *, UIElement *);
        public UILocationData m_defaultLocation;
        public StringInfo m_TTText;
        public sbyte m_bShouldBeMouseVisible;
        public sbyte m_bIsMouseVisible;
        public int m_cursorHotX;
        public int m_cursorHotY;
        public UInt32 m_cursorDID;
        public UInt32 m_nFlags;
        ///*
        //public U__Int32 m_bResizeLine : 1;
        //public U__Int32 m_bDragable : 1;
        //public U__Int32 m_bActivatable : 1;
        //public U__Int32 m_bActivateOnShow : 1;
        //public U__Int32 m_bSaveLocation : 1;
        //public U__Int32 m_bSaveSize : 1;
        //public U__Int32 m_bSaveVisible : 1;
        //public U__Int32 m_bContextMenu : 1;
        //public U__Int32 m_bNotifyOnDraw : 1;
        //public U__Int32 m_bNotifyOnResize : 1;
        //public U__Int32 m_bNotifyOnMove : 1;
        //public U__Int32 m_bNotifyOnParentChange : 1;
        //public U__Int32 m_bNotifyOnCreate : 1;
        //public U__Int32 m_bNotifyOnMouseMove : 1;
        //public U__Int32 m_bShouldOwnObject : 1;
        //public U__Int32 m_bObjectIsTemporary : 1;
        //public U__Int32 m_bDoesOwnObject : 1;
        //public U__Int32 m_bIsInitialized : 1;
        //public U__Int32 m_bIsMoving : 1;S
        //public U__Int32 m_bIsResizing : 1;
        //public U__Int32 m_bIsActive : 1;
        //public U__Int32 m_bIsRootElement : 1;
        //public U__Int32 m_bWantsFocus : 1;
        //public U__Int32 m_bWantsDblClicks : 1;
        //public U__Int32 m_bNotifyOnHover : 1;
        //*/
        public UInt32 m_eClampGameView;
        public Box2D m_surfaceBox;
        public HashSet<PTR<UIListener>> m_hashListeners;
        public HashSetIterator<PTR<UIListener>> m_iterListeners;
        public UInt32 m_idInputMap;
        public override string ToString() => $"a0(UIRegion):{a0}, m_itemDragged:->(UIElement*)0x{(int)m_itemDragged:X8}, m_pFocusElement:->(UIElement*)0x{(int)m_pFocusElement:X8}, m_mediaMachine(MediaMachine):{m_mediaMachine}, m_layout:->(LayoutDesc*)0x{(int)m_layout:X8}, m_desc(ElementDesc):{m_desc}, m_state:{m_state:X8}, m_curStateDesc:->(StateDesc*)0x{(int)m_curStateDesc:X8}, m_instanceProperties(PropertyCollection):{m_instanceProperties}, m_currentBorder(BorderLocation):{m_currentBorder}, m_DragStartX(int):{m_DragStartX}, m_DragStartY(int):{m_DragStartY}, m_DragStartHeight(int):{m_DragStartHeight}, m_DragStartWidth(int):{m_DragStartWidth}, m_mouseInitialX(int):{m_mouseInitialX}, m_mouseInitialY(int):{m_mouseInitialY}, m_defaultLocation(UILocationData):{m_defaultLocation}, m_TTText(StringInfo):{m_TTText}, m_bShouldBeMouseVisible:{m_bShouldBeMouseVisible:X2}, m_bIsMouseVisible:{m_bIsMouseVisible:X2}, m_cursorHotX(int):{m_cursorHotX}, m_cursorHotY(int):{m_cursorHotY}, m_cursorDID:{m_cursorDID:X8}, m_nFlags:{m_nFlags:X8}, m_eClampGameView:{m_eClampGameView:X8}, m_surfaceBox(Box2D):{m_surfaceBox}, m_hashListeners(HashSet<UIListener*>):{m_hashListeners}, m_iterListeners(HashSetIterator<UIListener*>):{m_iterListeners}, m_idInputMap:{m_idInputMap:X8}";
        // Enums:
        public enum FunctionSignatureChanged : UInt32 {
        };
        public enum Intialized_Has_Been_Replaced_With_PostInit : UInt32 {
        };

        // Functions:

        // UIElement.GetRootElement:
        public UIElement* GetRootElement() => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*>)0x0045FB30)(ref this); // .text:0045FA50 ; UIElement *__thiscall UIElement::GetRootElement(UIElement *this) .text:0045FA50 ?GetRootElement@UIElement@@QAEPAV1@XZ

        // UIElement.RegisterElementClass:                                                                                                                                                                                                                                                                                                                                                                                      
        public static void RegisterElementClass(UInt32 _type, delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*> a1) => ((delegate* unmanaged[Cdecl]<UInt32, delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>, void>)0x00460270)(_type, a1); // .text:00460190 ; void __cdecl UIElement::RegisterElementClass(unsigned int _type, UIElement *(__cdecl *_createMethod)(LayoutDesc *, ElementDesc *)) .text:00460190 ?RegisterElementClass@UIElement@@KAXKP6APAV1@ABVLayoutDesc@@ABVElementDesc@@@Z@Z

        // UIElement.GetAttribute_Enum:
        public Byte GetAttribute_Enum(UInt32 _attribute, UInt32* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32*, Byte>)0x00460990)(ref this, _attribute, _val); // .text:004608B0 ; bool __thiscall UIElement::GetAttribute_Enum(UIElement *this, unsigned int _attribute, unsigned int *_val) .text:004608B0 ?GetAttribute_Enum@UIElement@@QBE_NKAAK@Z

        // UIElement.GetAttribute_Float:
        public Byte GetAttribute_Float(UInt32 _attribute, Single* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Single*, Byte>)0x00460BF0)(ref this, _attribute, _val); // .text:00460B10 ; bool __thiscall UIElement::GetAttribute_Float(UIElement *this, unsigned int _attribute, float *_val) .text:00460B10 ?GetAttribute_Float@UIElement@@QBE_NKAAM@Z

        // UIElement.RegisterForElementMessages:
        public void RegisterForElementMessages(UIListener* i_pListener) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIListener*, void>)0x00464AD0)(ref this, i_pListener); // .text:004649A0 ; void __thiscall UIElement::RegisterForElementMessages(UIElement *this, UIListener *i_pListener) .text:004649A0 ?RegisterForElementMessages@UIElement@@QAEXPAVUIListener@@@Z

        // UIElement.SetNotifyOnMove:
        public void SetNotifyOnMove(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FA70)(ref this, _b); // .text:0045F990 ; void __thiscall UIElement::SetNotifyOnMove(UIElement *this, bool _b) .text:0045F990 ?SetNotifyOnMove@UIElement@@QAEX_N@Z

        // UIElement.SetIsRootElement:
        public void SetIsRootElement(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x004601E0)(ref this, _b); // .text:00460100 ; void __thiscall UIElement::SetIsRootElement(UIElement *this, bool _b) .text:00460100 ?SetIsRootElement@UIElement@@QAEX_N@Z

        // UIElement.GetChildRecursive:
        public UIElement* GetChildRecursive(UInt32 _ID) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UIElement*>)0x00463C00)(ref this, _ID); // .text:00463AD0 ; UIElement *__thiscall UIElement::GetChildRecursive(UIElement *this, unsigned int _ID) .text:00463AD0 ?GetChildRecursive@UIElement@@QBEPAV1@K@Z

        // UIElement.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x004639A0)(ref this); // .text:00463870 ; void __thiscall UIElement::PostInit(UIElement *this) .text:00463870 ?PostInit@UIElement@@UAEXXZ

        // UIElement.GetParent:
        public int GetParent() => ((delegate* unmanaged[Thiscall]<ref UIElement, int>)0x005C8120)(ref this); // .text:005C7140 ; int __thiscall UIElement::GetParent(ACCharGenResult *this) .text:005C7140 ?GetParent@UIElement@@UBEPAV1@XZ

        // UIElement.SetContextMenu:
        public void SetContextMenu(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FA90)(ref this, _b); // .text:0045F9B0 ; void __thiscall UIElement::SetContextMenu(UIElement *this, bool _b) .text:0045F9B0 ?SetContextMenu@UIElement@@QAEX_N@Z

        // UIElement.DefElementMessageHandler:
        public Byte DefElementMessageHandler(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElementMessageInfo*, Byte>)0x0045FD10)(ref this, i_rMsg); // .text:0045FC30 ; bool __thiscall UIElement::DefElementMessageHandler(UIElement *this, UIElementMessageInfo *i_rMsg) .text:0045FC30 ?DefElementMessageHandler@UIElement@@MAE_NABUUIElementMessageInfo@@@Z

        // UIElement.InqAvailableProperties:
        public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement, AvailablePropertySet*, Byte>)0x004625B0)(ref this, _set); // .text:004624D0 ; bool __thiscall UIElement::InqAvailableProperties(UIElement *this, AvailablePropertySet *_set) .text:004624D0 ?InqAvailableProperties@UIElement@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement.UnregisterInputMaps:
        public Byte UnregisterInputMaps() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x0045FC50)(ref this); // .text:0045FB70 ; bool __thiscall UIElement::UnregisterInputMaps(UIElement *this) .text:0045FB70 ?UnregisterInputMaps@UIElement@@UAE_NXZ

        // UIElement.RelinquishFocus:
        public Byte RelinquishFocus() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00461EC0)(ref this); // .text:00461DE0 ; bool __thiscall UIElement::RelinquishFocus(UIElement *this) .text:00461DE0 ?RelinquishFocus@UIElement@@UAE_NXZ

        // UIElement.GetSurfaceBox:
        public Box2D* GetSurfaceBox(Box2D* result) => ((delegate* unmanaged[Thiscall]<ref UIElement, Box2D*, Box2D*>)0x00462220)(ref this, result); // .text:00462140 ; Box2D *__thiscall UIElement::GetSurfaceBox(UIElement *this, Box2D *result) .text:00462140 ?GetSurfaceBox@UIElement@@UBE?AVBox2D@@XZ

        // UIElement.GetActivatable:
        public Byte GetActivatable() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00464AA0)(ref this); // .text:00464970 ; bool __thiscall UIElement::GetActivatable(UIElement *this) .text:00464970 ?GetActivatable@UIElement@@UBE_NXZ

        // UIElement.StopResizing:
        public void StopResizing() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x0045FE40)(ref this); // .text:0045FD60 ; void __thiscall UIElement::StopResizing(UIElement *this) .text:0045FD60 ?StopResizing@UIElement@@QAEXXZ

        // UIElement.SetMouseVisible:
        public void SetMouseVisible(Byte i_bShouldBeMouseVisible) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00461F10)(ref this, i_bShouldBeMouseVisible); // .text:00461E30 ; void __thiscall UIElement::SetMouseVisible(UIElement *this, bool i_bShouldBeMouseVisible) .text:00461E30 ?SetMouseVisible@UIElement@@UAEX_N@Z

        // UIElement.InqProperty:
        public Byte InqProperty(UInt32 _name, BaseProperty* _property) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, BaseProperty*, Byte>)0x00463A00)(ref this, _name, _property); // .text:004638D0 ; bool __thiscall UIElement::InqProperty(UIElement *this, const unsigned int _name, BaseProperty *_property) .text:004638D0 ?InqProperty@UIElement@@UBE_NKAAVBaseProperty@@@Z

        // UIElement.DragItem:
        public Byte DragItem(UIElement** _elem) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement**, Byte>)0x004616E0)(ref this, _elem); // .text:00461600 ; bool __thiscall UIElement::DragItem(UIElement *this, UIElement **_elem) .text:00461600 ?DragItem@UIElement@@UAE_NAAPAV1@@Z

        // UIElement.UpdateForScreenPositionChange:
        public void UpdateForScreenPositionChange() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00463FB0)(ref this); // .text:00463E80 ; void __thiscall UIElement::UpdateForScreenPositionChange(UIElement *this) .text:00463E80 ?UpdateForScreenPositionChange@UIElement@@MAEXXZ

        // UIElement.UpdateForParentVisibilityChange:
        public void UpdateForParentVisibilityChange(Byte i_bHeirarchyVisible) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00464090)(ref this, i_bHeirarchyVisible); // .text:00463F60 ; void __thiscall UIElement::UpdateForParentVisibilityChange(UIElement *this, bool i_bHeirarchyVisible) .text:00463F60 ?UpdateForParentVisibilityChange@UIElement@@UAEX_N@Z

        // UIElement.ContainsProperty:
        public Byte ContainsProperty(UInt32 _name) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Byte>)0x00464430)(ref this, _name); // .text:00464300 ; bool __thiscall UIElement::ContainsProperty(UIElement *this, const unsigned int _name) .text:00464300 ?ContainsProperty@UIElement@@UBE_NK@Z

        // UIElement.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref UIElement, InputEvent*, Byte>)0x0045FCA0)(ref this, i_evt); // .text:0045FBC0 ; bool __thiscall UIElement::OnAction(UIElement *this, InputEvent *i_evt) .text:0045FBC0 ?OnAction@UIElement@@UAE_NABVInputEvent@@@Z

        // UIElement.KeyDown:
        public Byte KeyDown(UInt32 _button, Single i_fExtent) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Single, Byte>)0x004611A0)(ref this, _button, i_fExtent); // .text:004610C0 ; bool __thiscall UIElement::KeyDown(UIElement *this, unsigned int _button, float i_fExtent) .text:004610C0 ?KeyDown@UIElement@@UAE_NKM@Z

        // UIElement.SetMediaImageForState:
        public void SetMediaImageForState(UInt32 _imageDID, UInt32 _drawMode, UInt32 _stateID) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, UInt32, void>)0x00463D10)(ref this, _imageDID, _drawMode, _stateID); // .text:00463BE0 ; void __thiscall UIElement::SetMediaImageForState(UIElement *this, IDClass<_tagDataID,32,0> _imageDID, unsigned int _drawMode, unsigned int _stateID) .text:00463BE0 ?SetMediaImageForState@UIElement@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@KK@Z

        // UIElement.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement, BaseProperty*, void>)0x00462E60)(ref this, _attribute); // .text:00462D80 ; void __thiscall UIElement::OnSetAttribute(UIElement *this, BaseProperty *_attribute) .text:00462D80 ?OnSetAttribute@UIElement@@UAEXABVBaseProperty@@@Z

        // UIElement.GetPrevChildElement:
        public UIElement* GetPrevChildElement(UIElement* i_pNextChild) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, UIElement*>)0x004644F0)(ref this, i_pNextChild); // .text:004643C0 ; UIElement *__thiscall UIElement::GetPrevChildElement(UIElement *this, UIElement *i_pNextChild) .text:004643C0 ?GetPrevChildElement@UIElement@@QAEPAV1@PAV1@@Z

        // UIElement.GetHasFocus:
        public Byte GetHasFocus() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00460310)(ref this); // .text:00460230 ; bool __thiscall UIElement::GetHasFocus(UIElement *this) .text:00460230 ?GetHasFocus@UIElement@@QBE_NXZ

        // UIElement.IsVisible:
        public Byte IsVisible() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x004603A0)(ref this); // .text:004602C0 ; bool __thiscall UIElement::IsVisible(UIElement *this) .text:004602C0 ?IsVisible@UIElement@@QBE_NXZ

        // UIElement.Initialize:
        public void Initialize() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00462D70)(ref this); // .text:00462C90 ; void __thiscall UIElement::Initialize(UIElement *this) .text:00462C90 ?Initialize@UIElement@@UAEXXZ

        // UIElement.FindRelative:
        public UIElement* FindRelative(UInt32 _relativeID) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UIElement*>)0x00464690)(ref this, _relativeID); // .text:00464560 ; UIElement *__thiscall UIElement::FindRelative(UIElement *this, unsigned int _relativeID) .text:00464560 ?FindRelative@UIElement@@QBEPAV1@K@Z

        // UIElement.HasCursor:
        public Byte HasCursor() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00464AB0)(ref this); // .text:00464980 ; bool __thiscall UIElement::HasCursor(UIElement *this) .text:00464980 ?HasCursor@UIElement@@UBE_NXZ

        // UIElement.SetActivateOnShow:
        public void SetActivateOnShow(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045F9F0)(ref this, _b); // .text:0045F910 ; void __thiscall UIElement::SetActivateOnShow(UIElement *this, bool _b) .text:0045F910 ?SetActivateOnShow@UIElement@@QAEX_N@Z

        // UIElement.GetObjectScale:
        public Vector3* GetObjectScale(Vector3* result) => ((delegate* unmanaged[Thiscall]<ref UIElement, Vector3*, Vector3*>)0x00462040)(ref this, result); // .text:00461F60 ; Vector3 *__thiscall UIElement::GetObjectScale(UIElement *this, Vector3 *result) .text:00461F60 ?GetObjectScale@UIElement@@QBE?AVVector3@@XZ

        // UIElement.MouseMove:
        public void MouseMove(int _xWindow, int _yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x004633F0)(ref this, _xWindow, _yWindow); // .text:00463310 ; void __thiscall UIElement::MouseMove(UIElement *this, int _xWindow, int _yWindow) .text:00463310 ?MouseMove@UIElement@@UAEXJJ@Z

        // UIElement.DeleteChildren:
        public void DeleteChildren() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00464CD0)(ref this); // .text:00464BA0 ; void __thiscall UIElement::DeleteChildren(UIElement *this) .text:00464BA0 ?DeleteChildren@UIElement@@QAEXXZ

        // UIElement.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement, LayoutDesc*, ElementDesc*, void>)0x00464900)(ref this, _layout, _full_desc); // .text:004647D0 ; void __thiscall UIElement::UIElement(UIElement *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004647D0 ??0UIElement@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement.SetActivatable:
        public void SetActivatable(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x004592D0)(ref this, _b); // .text:004591B0 ; void __thiscall UIElement::SetActivatable(UIElement *this, bool _b) .text:004591B0 ?SetActivatable@UIElement@@QAEX_N@Z

        // UIElement.UpdateSurfaceBox:
        public Byte UpdateSurfaceBox(Byte i_bPositionUpdate) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, Byte>)0x00462270)(ref this, i_bPositionUpdate); // .text:00462190 ; bool __thiscall UIElement::UpdateSurfaceBox(UIElement *this, const bool i_bPositionUpdate) .text:00462190 ?UpdateSurfaceBox@UIElement@@QAE_N_N@Z

        // UIElement.GetFirstChildElement:
        public UIElement* GetFirstChildElement() => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*>)0x00464110)(ref this); // .text:00463FE0 ; UIElement *__thiscall UIElement::GetFirstChildElement(UIElement *this) .text:00463FE0 ?GetFirstChildElement@UIElement@@QAEPAV1@XZ

        // UIElement.MakeUIObject:
        public Byte MakeUIObject(UIObject** o_pcUIObject) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIObject**, Byte>)0x00461920)(ref this, o_pcUIObject); // .text:00461840 ; bool __thiscall UIElement::MakeUIObject(UIElement *this, UIObject **o_pcUIObject) .text:00461840 ?MakeUIObject@UIElement@@MAE_NAAPAVUIObject@@@Z

        // UIElement.GetChild:
        public UIElement* GetChild(UInt32 _ID) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UIElement*>)0x00463BA0)(ref this, _ID); // .text:00463A70 ; UIElement *__thiscall UIElement::GetChild(UIElement *this, unsigned int _ID) .text:00463A70 ?GetChild@UIElement@@QBEPAV1@K@Z

        // UIElement.SetSaveLocation:
        public void SetSaveLocation(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FA10)(ref this, _b); // .text:0045F930 ; void __thiscall UIElement::SetSaveLocation(UIElement *this, bool _b) .text:0045F930 ?SetSaveLocation@UIElement@@QAEX_N@Z

        // UIElement.AddToDeleteQueue:
        public void AddToDeleteQueue() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00460250)(ref this); // .text:00460170 ; void __thiscall UIElement::AddToDeleteQueue(UIElement *this) .text:00460170 ?AddToDeleteQueue@UIElement@@QAEXXZ

        // UIElement.StartTooltipAtMouse:
        public UIElement* StartTooltipAtMouse(Double i_tTooltipDuration) => ((delegate* unmanaged[Thiscall]<ref UIElement, Double, UIElement*>)0x00460E50)(ref this, i_tTooltipDuration); // .text:00460D70 ; UIElement *__thiscall UIElement::StartTooltipAtMouse(UIElement *this, long double i_tTooltipDuration) .text:00460D70 ?StartTooltipAtMouse@UIElement@@QAEPAV1@N@Z

        // UIElement.CenterAt:
        public void CenterAt(int _x, int _y) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x004600D0)(ref this, _x, _y); // .text:0045FFF0 ; void __thiscall UIElement::CenterAt(UIElement *this, const int _x, const int _y) .text:0045FFF0 ?CenterAt@UIElement@@QAEXJJ@Z

        // UIElement.MouseTap:
        public void MouseTap(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, UInt32, void>)0x004610C0)(ref this, _xWindow, _yWindow, _button); // .text:00460FE0 ; void __thiscall UIElement::MouseTap(UIElement *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:00460FE0 ?MouseTap@UIElement@@MAEXKKK@Z

        // UIElement.SetDragable:
        public void SetDragable(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045F9D0)(ref this, _b); // .text:0045F8F0 ; void __thiscall UIElement::SetDragable(UIElement *this, bool _b) .text:0045F8F0 ?SetDragable@UIElement@@QAEX_N@Z

        // UIElement.SetNotifyOnResize:
        public void SetNotifyOnResize(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FA50)(ref this, _b); // .text:0045F970 ; void __thiscall UIElement::SetNotifyOnResize(UIElement *this, bool _b) .text:0045F970 ?SetNotifyOnResize@UIElement@@QAEX_N@Z

        // UIElement.StopMovement:
        public void StopMovement() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x0045FF00)(ref this); // .text:0045FE20 ; void __thiscall UIElement::StopMovement(UIElement *this) .text:0045FE20 ?StopMovement@UIElement@@QAEXXZ

        // UIElement.GetAttribute_DataID:
        public Byte GetAttribute_DataID(UInt32 _attribute, UInt32* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32*, Byte>)0x00460D80)(ref this, _attribute, _val); // .text:00460CA0 ; bool __thiscall UIElement::GetAttribute_DataID(UIElement *this, unsigned int _attribute, IDClass<_tagDataID,32,0> *_val) .text:00460CA0 ?GetAttribute_DataID@UIElement@@QBE_NKAAV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // UIElement.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElementMessageInfo*, UIElementMessageListenResult>)0x00462420)(ref this, i_rMsg); // .text:00462340 ; UIElementMessageListenResult __thiscall UIElement::ListenToElementMessage(UIElement *this, UIElementMessageInfo *i_rMsg) .text:00462340 ?ListenToElementMessage@UIElement@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement.IsAncestorOfMe:
        public Byte IsAncestorOfMe(UIElement* i_pAncestor) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, Byte>)0x0045FBB0)(ref this, i_pAncestor); // .text:0045FAD0 ; bool __thiscall UIElement::IsAncestorOfMe(UIElement *this, UIElement *i_pAncestor) .text:0045FAD0 ?IsAncestorOfMe@UIElement@@QBE_NPBV1@@Z

        // UIElement.MouseDown:
        public void MouseDown(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, UInt32, void>)0x00460FF0)(ref this, _xWindow, _yWindow, _button); // .text:00460F10 ; void __thiscall UIElement::MouseDown(UIElement *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:00460F10 ?MouseDown@UIElement@@UAEXKKK@Z

        // UIElement.SetObjectIsTemporary:
        public void SetObjectIsTemporary(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x004592F0)(ref this, _b); // .text:004591D0 ; void __thiscall UIElement::SetObjectIsTemporary(UIElement *this, bool _b) .text:004591D0 ?SetObjectIsTemporary@UIElement@@QAEX_N@Z

        // UIElement.SetAttribute_StringInfo:
        public Byte SetAttribute_StringInfo(UInt32 _attribute, StringInfo _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, StringInfo, Byte>)0x004605F0)(ref this, _attribute, _val); // .text:00460510 ; bool __thiscall UIElement::SetAttribute_StringInfo(UIElement *this, unsigned int _attribute, StringInfo _val) .text:00460510 ?SetAttribute_StringInfo@UIElement@@QAE_NKVStringInfo@@@Z

        // UIElement.MouseHover:
        public Byte MouseHover(int _xWindow, int _yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, Byte>)0x00462600)(ref this, _xWindow, _yWindow); // .text:00462520 ; bool __thiscall UIElement::MouseHover(UIElement *this, int _xWindow, int _yWindow) .text:00462520 ?MouseHover@UIElement@@UAE_NJJ@Z

        // UIElement.SetMediaImage:
        public void SetMediaImage(UInt32 _imageID, UInt32 _drawMode) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, void>)0x00463C80)(ref this, _imageID, _drawMode); // .text:00463B50 ; void __thiscall UIElement::SetMediaImage(UIElement *this, IDClass<_tagDataID,32,0> _imageID, unsigned int _drawMode) .text:00463B50 ?SetMediaImage@UIElement@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIElement.GetFocusDescendant:
        public UIElement* GetFocusDescendant() => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*>)0x00460330)(ref this); // .text:00460250 ; UIElement *__thiscall UIElement::GetFocusDescendant(UIElement *this) .text:00460250 ?GetFocusDescendant@UIElement@@QAEPAV1@XZ

        // UIElement.SetShouldOwnObject:
        public void SetShouldOwnObject(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00461CB0)(ref this, _b); // .text:00461BD0 ; void __thiscall UIElement::SetShouldOwnObject(UIElement *this, bool _b) .text:00461BD0 ?SetShouldOwnObject@UIElement@@QAEX_N@Z

        // UIElement.UpdateObjectScale:
        public Byte UpdateObjectScale() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x004620C0)(ref this); // .text:00461FE0 ; bool __thiscall UIElement::UpdateObjectScale(UIElement *this) .text:00461FE0 ?UpdateObjectScale@UIElement@@QAE_NXZ

        // UIElement.ForwardElementMessage:
        public UIElementMessageListenResult ForwardElementMessage(UIElementMessageInfo* i_rMsg, UIElementMessageListenResult i_eStatus) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElementMessageInfo*, UIElementMessageListenResult, UIElementMessageListenResult>)0x00462C00)(ref this, i_rMsg, i_eStatus); // .text:00462B20 ; UIElementMessageListenResult __thiscall UIElement::ForwardElementMessage(UIElement *this, UIElementMessageInfo *i_rMsg, UIElementMessageListenResult i_eStatus) .text:00462B20 ?ForwardElementMessage@UIElement@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@W42@@Z

        // UIElement.GetNextChildElement:
        public UIElement* GetNextChildElement(UIElement* i_pPrevChild) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, UIElement*>)0x00464490)(ref this, i_pPrevChild); // .text:00464360 ; UIElement *__thiscall UIElement::GetNextChildElement(UIElement *this, UIElement *i_pPrevChild) .text:00464360 ?GetNextChildElement@UIElement@@QAEPAV1@PAV1@@Z

        // UIElement.GetAncestorByID:
        public UIElement* GetAncestorByID(UInt32 i_ID) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UIElement*>)0x0045FB80)(ref this, i_ID); // .text:0045FAA0 ; UIElement *__thiscall UIElement::GetAncestorByID(UIElement *this, const unsigned int i_ID) .text:0045FAA0 ?GetAncestorByID@UIElement@@UBEPAV1@K@Z

        // UIElement.StartResizing:
        public void StartResizing(BorderLocation _border, int _xInitialMouse, int _yInitialMouse) => ((delegate* unmanaged[Thiscall]<ref UIElement, BorderLocation, int, int, void>)0x0045FD80)(ref this, _border, _xInitialMouse, _yInitialMouse); // .text:0045FCA0 ; void __thiscall UIElement::StartResizing(UIElement *this, BorderLocation _border, int _xInitialMouse, int _yInitialMouse) .text:0045FCA0 ?StartResizing@UIElement@@QAEXW4BorderLocation@@JJ@Z

        // UIElement.GetShouldOwnObject:
        public Byte GetShouldOwnObject() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x004601D0)(ref this); // .text:004600F0 ; bool __thiscall UIElement::GetShouldOwnObject(UIElement *this) .text:004600F0 ?GetShouldOwnObject@UIElement@@QBE_NXZ

        // UIElement.SetAttribute_Enum:
        public Byte SetAttribute_Enum(UInt32 _attribute, UInt32 _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, Byte>)0x00460470)(ref this, _attribute, _val); // .text:00460390 ; bool __thiscall UIElement::SetAttribute_Enum(UIElement *this, unsigned int _attribute, unsigned int _val) .text:00460390 ?SetAttribute_Enum@UIElement@@QAE_NKK@Z

        // UIElement.ResizeTo:
        public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x00463D60)(ref this, _width, _height); // .text:00463C30 ; void __thiscall UIElement::ResizeTo(UIElement *this, const int _width, const int _height) .text:00463C30 ?ResizeTo@UIElement@@UAEXJJ@Z

        // UIElement.SetSaveSize:
        public void SetSaveSize(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FA30)(ref this, _b); // .text:0045F950 ; void __thiscall UIElement::SetSaveSize(UIElement *this, bool _b) .text:0045F950 ?SetSaveSize@UIElement@@QAEX_N@Z

        // UIElement.SetCursor:
        public void SetCursor(UInt32 _cursorDID, int _hotX, int _hotY) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, int, int, void>)0x00460030)(ref this, _cursorDID, _hotX, _hotY); // .text:0045FF50 ; void __thiscall UIElement::SetCursor(UIElement *this, IDClass<_tagDataID,32,0> _cursorDID, int _hotX, int _hotY) .text:0045FF50 ?SetCursor@UIElement@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@JJ@Z

        // UIElement.TakeFocus:
        public Byte TakeFocus() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x004602C0)(ref this); // .text:004601E0 ; bool __thiscall UIElement::TakeFocus(UIElement *this) .text:004601E0 ?TakeFocus@UIElement@@UAE_NXZ

        // UIElement.SetState:
        public Byte SetState(UInt32 _state) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Byte>)0x00464FA0)(ref this, _state); // .text:00464E70 ; bool __thiscall UIElement::SetState(UIElement *this, unsigned int _state) .text:00464E70 ?SetState@UIElement@@UAE_NK@Z

        // UIElement.MatchElement:
        public void MatchElement(UIElement* _elem) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, void>)0x00465330)(ref this, _elem); // .text:00465200 ; void __thiscall UIElement::MatchElement(UIElement *this, UIElement *_elem) .text:00465200 ?MatchElement@UIElement@@UAEXABV1@@Z

        // UIElement.SetAttribute_DataID:
        public Byte SetAttribute_DataID(UInt32 _attribute, UInt32 _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, Byte>)0x004608D0)(ref this, _attribute, _val); // .text:004607F0 ; bool __thiscall UIElement::SetAttribute_DataID(UIElement *this, unsigned int _attribute, IDClass<_tagDataID,32,0> _val) .text:004607F0 ?SetAttribute_DataID@UIElement@@QAE_NKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // UIElement.MouseOverTop:
        public void MouseOverTop(Byte _overTop) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x004616B0)(ref this, _overTop); // .text:004615D0 ; void __thiscall UIElement::MouseOverTop(UIElement *this, bool _overTop) .text:004615D0 ?MouseOverTop@UIElement@@UAEX_N@Z

        // UIElement.SetUIObject:
        public Byte SetUIObject(UIObject* i_pcUIObject) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIObject*, Byte>)0x00461BA0)(ref this, i_pcUIObject); // .text:00461AC0 ; bool __thiscall UIElement::SetUIObject(UIElement *this, UIObject *i_pcUIObject) .text:00461AC0 ?SetUIObject@UIElement@@MAE_NPAVUIObject@@@Z

        // UIElement.GetAttribute_Int:
        public Byte GetAttribute_Int(UInt32 _attribute, int* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, int*, Byte>)0x00460B30)(ref this, _attribute, _val); // .text:00460A50 ; bool __thiscall UIElement::GetAttribute_Int(UIElement *this, unsigned int _attribute, int *_val) .text:00460A50 ?GetAttribute_Int@UIElement@@QBE_NKAAJ@Z

        // UIElement.MouseOver:
        public void MouseOver(Byte _over) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00461680)(ref this, _over); // .text:004615A0 ; void __thiscall UIElement::MouseOver(UIElement *this, bool _over) .text:004615A0 ?MouseOver@UIElement@@UAEX_N@Z

        // UIElement.GetDragAndDropCatcher:
        public UIElement* GetDragAndDropCatcher(UIElement* _elem) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, UIElement*>)0x004617D0)(ref this, _elem); // .text:004616F0 ; UIElement *__thiscall UIElement::GetDragAndDropCatcher(UIElement *this, UIElement *_elem) .text:004616F0 ?GetDragAndDropCatcher@UIElement@@UAEPAV1@PAV1@@Z

        // UIElement.MoveTo:
        public void MoveTo(int _x, int _y) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x004634C0)(ref this, _x, _y); // .text:004633E0 ; void __thiscall UIElement::MoveTo(UIElement *this, const int _x, const int _y) .text:004633E0 ?MoveTo@UIElement@@UAEXJJ@Z

        // UIElement.UnregisterForElementMessages:
        public void UnregisterForElementMessages(UIListener* i_pListener) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIListener*, void>)0x00464B00)(ref this, i_pListener); // .text:004649D0 ; void __thiscall UIElement::UnregisterForElementMessages(UIElement *this, UIListener *i_pListener) .text:004649D0 ?UnregisterForElementMessages@UIElement@@QAEXPAVUIListener@@@Z

        // UIElement.CompareZLevel:
        public int CompareZLevel(UIRegion* i_pRegion) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIRegion*, int>)0x0045FD40)(ref this, i_pRegion); // .text:0045FC60 ; int __thiscall UIElement::CompareZLevel(UIElement *this, UIRegion *i_pRegion) .text:0045FC60 ?CompareZLevel@UIElement@@UBEJPBVUIRegion@@@Z

        // UIElement.GetOriginalPosition:
        public void GetOriginalPosition(Box2D* _position, int* _zlevel) => ((delegate* unmanaged[Thiscall]<ref UIElement, Box2D*, int*, void>)0x00460110)(ref this, _position, _zlevel); // .text:00460030 ; void __thiscall UIElement::GetOriginalPosition(UIElement *this, Box2D *_position, int *_zlevel) .text:00460030 ?GetOriginalPosition@UIElement@@IAEXAAVBox2D@@AAJ@Z

        // UIElement.GetShouldBeMouseVisible:
        public Byte GetShouldBeMouseVisible() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00460290)(ref this); // .text:004601B0 ; bool __thiscall UIElement::GetShouldBeMouseVisible(UIElement *this) .text:004601B0 ?GetShouldBeMouseVisible@UIElement@@MAE_NXZ

        // UIElement.BringChildToTop:
        public void BringChildToTop(UIElement* i_pChild) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, void>)0x00465610)(ref this, i_pChild); // .text:004654E0 ; void __thiscall UIElement::BringChildToTop(UIElement *this, UIElement *i_pChild) .text:004654E0 ?BringChildToTop@UIElement@@QAEXPAV1@@Z

        // UIElement.ClearTooltip:
        public void ClearTooltip() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x004626C0)(ref this); // .text:004625E0 ; void __thiscall UIElement::ClearTooltip(UIElement *this) .text:004625E0 ?ClearTooltip@UIElement@@QAEXXZ

        // UIElement.MouseMoveElement:
        public void MouseMoveElement(int _xWindow, int _yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x0045FF10)(ref this, _xWindow, _yWindow); // .text:0045FE30 ; void __thiscall UIElement::MouseMoveElement(UIElement *this, int _xWindow, int _yWindow) .text:0045FE30 ?MouseMoveElement@UIElement@@IAEXJJ@Z

        // UIElement.UpdateMouseVisibility:
        public void UpdateMouseVisibility() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00460340)(ref this); // .text:00460260 ; void __thiscall UIElement::UpdateMouseVisibility(UIElement *this) .text:00460260 ?UpdateMouseVisibility@UIElement@@QAEXXZ

        // UIElement.SetAttribute_Int:
        public Byte SetAttribute_Int(UInt32 _attribute, int _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, int, Byte>)0x004606B0)(ref this, _attribute, _val); // .text:004605D0 ; bool __thiscall UIElement::SetAttribute_Int(UIElement *this, unsigned int _attribute, int _val) .text:004605D0 ?SetAttribute_Int@UIElement@@QAE_NKJ@Z

        // UIElement.SetProperty:
        public Byte SetProperty(BaseProperty* _property) => ((delegate* unmanaged[Thiscall]<ref UIElement, BaseProperty*, Byte>)0x00464C90)(ref this, _property); // .text:00464B60 ; bool __thiscall UIElement::SetProperty(UIElement *this, BaseProperty *_property) .text:00464B60 ?SetProperty@UIElement@@UAE_NABVBaseProperty@@@Z

        // UIElement.SetAttribute_InstanceID:
        public Byte SetAttribute_InstanceID(UInt32 _attribute, UInt32 _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, Byte>)0x00460530)(ref this, _attribute, _val); // .text:00460450 ; bool __thiscall UIElement::SetAttribute_InstanceID(UIElement *this, unsigned int _attribute, unsigned int _val) .text:00460450 ?SetAttribute_InstanceID@UIElement@@QAE_NKK@Z

        // UIElement.SetTooltip:
        public void SetTooltip(StringInfo* _text) => ((delegate* unmanaged[Thiscall]<ref UIElement, StringInfo*, void>)0x004618A0)(ref this, _text); // .text:004617C0 ; void __thiscall UIElement::SetTooltip(UIElement *this, StringInfo *_text) .text:004617C0 ?SetTooltip@UIElement@@QAEXABVStringInfo@@@Z

        // UIElement.Deactivate:
        public Byte Deactivate() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00461E30)(ref this); // .text:00461D50 ; bool __thiscall UIElement::Deactivate(UIElement *this) .text:00461D50 ?Deactivate@UIElement@@UAE_NXZ

        // UIElement.MouseUp:
        public void MouseUp(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, UInt32, void>)0x00463A70)(ref this, _xWindow, _yWindow, _button); // .text:00463940 ; void __thiscall UIElement::MouseUp(UIElement *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:00463940 ?MouseUp@UIElement@@UAEXKKK@Z

        // UIElement.GetCurrentPosition:
        public void GetCurrentPosition(Box2D* _position, int* _zlevel) => ((delegate* unmanaged[Thiscall]<ref UIElement, Box2D*, int*, void>)0x00460180)(ref this, _position, _zlevel); // .text:004600A0 ; void __thiscall UIElement::GetCurrentPosition(UIElement *this, Box2D *_position, int *_zlevel) .text:004600A0 ?GetCurrentPosition@UIElement@@IAEXAAVBox2D@@AAJ@Z

        // UIElement.SetClampGameViewEdge:
        public void SetClampGameViewEdge(UInt32 i_eEdge) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, void>)0x00460370)(ref this, i_eEdge); // .text:00460290 ; void __thiscall UIElement::SetClampGameViewEdge(UIElement *this, unsigned int i_eEdge) .text:00460290 ?SetClampGameViewEdge@UIElement@@UAEXK@Z

        // UIElement.BroadcastElementMessage:
        public Byte BroadcastElementMessage(UInt32 i_idMessage, UInt32 i_dwParam1, UInt32 i_dwParam2) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32, UInt32, Byte>)0x00460410)(ref this, i_idMessage, i_dwParam1, i_dwParam2); // .text:00460330 ; bool __thiscall UIElement::BroadcastElementMessage(UIElement *this, unsigned int i_idMessage, unsigned int i_dwParam1, unsigned int i_dwParam2) .text:00460330 ?BroadcastElementMessage@UIElement@@QAE_NKKK@Z

        // UIElement.UnSetCursor:
        public void UnSetCursor() => ((delegate* unmanaged[Thiscall]<ref UIElement, void>)0x00460060)(ref this); // .text:0045FF80 ; void __thiscall UIElement::UnSetCursor(UIElement *this) .text:0045FF80 ?UnSetCursor@UIElement@@QAEXXZ

        // UIElement.GetAttribute_Bool:
        public Byte GetAttribute_Bool(UInt32 _attribute, Byte* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Byte*, Byte>)0x00460CC0)(ref this, _attribute, _val); // .text:00460BE0 ; bool __thiscall UIElement::GetAttribute_Bool(UIElement *this, unsigned int _attribute, bool *_val) .text:00460BE0 ?GetAttribute_Bool@UIElement@@QBE_NKAA_N@Z

        // UIElement.GetAttribute_InstanceID:
        public Byte GetAttribute_InstanceID(UInt32 _attribute, UInt32* _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, UInt32*, Byte>)0x00460A60)(ref this, _attribute, _val); // .text:00460980 ; bool __thiscall UIElement::GetAttribute_InstanceID(UIElement *this, unsigned int _attribute, unsigned int *_val) .text:00460980 ?GetAttribute_InstanceID@UIElement@@QBE_NKAAK@Z

        // UIElement.GetLastChildElement:
        public UIElement* GetLastChildElement() => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*>)0x00463690)(ref this); // .text:004635B0 ; UIElement *__thiscall UIElement::GetLastChildElement(UIElement *this) .text:004635B0 ?GetLastChildElement@UIElement@@QAEPAV1@XZ

        // UIElement.SetNotifyOnCreate:
        public void SetNotifyOnCreate(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x0045FAB0)(ref this, _b); // .text:0045F9D0 ; void __thiscall UIElement::SetNotifyOnCreate(UIElement *this, bool _b) .text:0045F9D0 ?SetNotifyOnCreate@UIElement@@QAEX_N@Z

        // UIElement.OnChildAction:
        public Byte OnChildAction(UIElement* i_pChild, InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIElement*, InputEvent*, Byte>)0x0045FCE0)(ref this, i_pChild, i_evt); // .text:0045FC00 ; bool __thiscall UIElement::OnChildAction(UIElement *this, UIElement *i_pChild, InputEvent *i_evt) .text:0045FC00 ?OnChildAction@UIElement@@UAE_NABV1@ABVInputEvent@@@Z

        // UIElement.SetAttribute_Bool:
        public Byte SetAttribute_Bool(UInt32 _attribute, Byte _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Byte, Byte>)0x00460820)(ref this, _attribute, _val); // .text:00460740 ; bool __thiscall UIElement::SetAttribute_Bool(UIElement *this, unsigned int _attribute, bool _val) .text:00460740 ?SetAttribute_Bool@UIElement@@QAE_NK_N@Z

        // UIElement.CatchDroppedItem:
        public Byte CatchDroppedItem(DragDropInfo* i_pcDDI) => ((delegate* unmanaged[Thiscall]<ref UIElement, DragDropInfo*, Byte>)0x00461860)(ref this, i_pcDDI); // .text:00461780 ; bool __thiscall UIElement::CatchDroppedItem(UIElement *this, DragDropInfo *i_pcDDI) .text:00461780 ?CatchDroppedItem@UIElement@@UAE_NPAVDragDropInfo@@@Z

        // UIElement.GetCurrentUIObjectMode:
        public void GetCurrentUIObjectMode(UInt32* i_eMode) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32*, void>)0x00461FB0)(ref this, i_eMode); // .text:00461ED0 ; void __thiscall UIElement::GetCurrentUIObjectMode(UIElement *this, unsigned int *i_eMode) .text:00461ED0 ?GetCurrentUIObjectMode@UIElement@@QBEXAAK@Z

        // UIElement.MouseResizeElement:
        public void MouseResizeElement(int _xWindow, int _yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x00461210)(ref this, _xWindow, _yWindow); // .text:00461130 ; void __thiscall UIElement::MouseResizeElement(UIElement *this, int _xWindow, int _yWindow) .text:00461130 ?MouseResizeElement@UIElement@@IAEXJJ@Z

        // UIElement.DragAndDropComplete:
        public void DragAndDropComplete(DragDropInfo* i_pcDDI) => ((delegate* unmanaged[Thiscall]<ref UIElement, DragDropInfo*, void>)0x00461880)(ref this, i_pcDDI); // .text:004617A0 ; void __thiscall UIElement::DragAndDropComplete(UIElement *this, DragDropInfo *i_pcDDI) .text:004617A0 ?DragAndDropComplete@UIElement@@UAEXPAVDragDropInfo@@@Z

        // UIElement.Activate:
        public Byte Activate() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00461D60)(ref this); // .text:00461C80 ; bool __thiscall UIElement::Activate(UIElement *this) .text:00461C80 ?Activate@UIElement@@UAE_NXZ

        // UIElement.SetVisible:
        public void SetVisible(Byte _visible) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00462390)(ref this, _visible); // .text:004622B0 ; void __thiscall UIElement::SetVisible(UIElement *this, bool _visible) .text:004622B0 ?SetVisible@UIElement@@UAEX_N@Z

        // UIElement.InqImageSize:
        public Byte InqImageSize(int* width, int* height) => ((delegate* unmanaged[Thiscall]<ref UIElement, int*, int*, Byte>)0x00460090)(ref this, width, height); // .text:0045FFB0 ; bool __thiscall UIElement::InqImageSize(UIElement *this, int *width, int *height) .text:0045FFB0 ?InqImageSize@UIElement@@QAE?B_NAAJ0@Z

        // UIElement.SetAttribute_Float:
        public Byte SetAttribute_Float(UInt32 _attribute, Single _val) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Single, Byte>)0x00460760)(ref this, _attribute, _val); // .text:00460680 ; bool __thiscall UIElement::SetAttribute_Float(UIElement *this, unsigned int _attribute, float _val) .text:00460680 ?SetAttribute_Float@UIElement@@QAE_NKM@Z

        // UIElement.KeyUp:
        public Byte KeyUp(UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement, UInt32, Byte>)0x00461140)(ref this, _button); // .text:00461060 ; bool __thiscall UIElement::KeyUp(UIElement *this, unsigned int _button) .text:00461060 ?KeyUp@UIElement@@UAE_NK@Z

        // UIElement.StartMovement:
        public void StartMovement(int _xInitialMouse, int _yInitialMouse) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, int, void>)0x0045FE90)(ref this, _xInitialMouse, _yInitialMouse); // .text:0045FDB0 ; void __thiscall UIElement::StartMovement(UIElement *this, int _xInitialMouse, int _yInitialMouse) .text:0045FDB0 ?StartMovement@UIElement@@QAEXJJ@Z

        // UIElement.UpdateForParentSizeChange:
        public Byte UpdateForParentSizeChange() => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte>)0x00462720)(ref this); // .text:00462640 ; bool __thiscall UIElement::UpdateForParentSizeChange(UIElement *this) .text:00462640 ?UpdateForParentSizeChange@UIElement@@QAE_NXZ

        // UIElement.SetParent:
        public void SetParent(UIRegion* _parent) => ((delegate* unmanaged[Thiscall]<ref UIElement, UIRegion*, void>)0x00462B30)(ref this, _parent); // .text:00462A50 ; void __thiscall UIElement::SetParent(UIElement *this, UIRegion *_parent) .text:00462A50 ?SetParent@UIElement@@UAEXPAVUIRegion@@@Z

        // UIElement.RegisterInputMaps:
        public Byte RegisterInputMaps(int i_nPriority) => ((delegate* unmanaged[Thiscall]<ref UIElement, int, Byte>)0x0045FBE0)(ref this, i_nPriority); // .text:0045FB00 ; bool __thiscall UIElement::RegisterInputMaps(UIElement *this, int i_nPriority) .text:0045FB00 ?RegisterInputMaps@UIElement@@UAE_NJ@Z

        // UIElement.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisibleNow) => ((delegate* unmanaged[Thiscall]<ref UIElement, Byte, void>)0x00463830)(ref this, i_bVisibleNow); // .text:00463700 ; void __thiscall UIElement::OnVisibilityChanged(UIElement *this, bool i_bVisibleNow) .text:00463700 ?OnVisibilityChanged@UIElement@@MAEX_N@Z
    }










    public unsafe struct UIElement_Panel {
        // Struct:
        public UIElement a0;
        public HashTable<UInt32, UInt32> m_TabPageHash;
        public HashTable<UInt32, UInt32> m_PageTabHash;
        public UInt32 m_OpenPageToken;
        public UInt32 m_OpenTabToken;
        public override string ToString() => $"a0(UIElement):{a0}, m_TabPageHash(HashTable<UInt32,UInt32,0>):{m_TabPageHash}, m_PageTabHash(HashTable<UInt32,UInt32,0>):{m_PageTabHash}, m_OpenPageToken:{m_OpenPageToken:X8}, m_OpenTabToken:{m_OpenTabToken:X8}";

        // Functions:

        // UIElement_Panel.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x0046CA90)(); // .text:0046C6B0 ; void __cdecl UIElement_Panel::Register() .text:0046C6B0 ?Register@UIElement_Panel@@SAXXZ

        // UIElement_Panel.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, BaseProperty*, void>)0x0046CAA0)(ref this, _attribute); // .text:0046C6C0 ; void __thiscall UIElement_Panel::OnSetAttribute(UIElement_Panel *this, BaseProperty *_attribute) .text:0046C6C0 ?OnSetAttribute@UIElement_Panel@@UAEXABVBaseProperty@@@Z

        // UIElement_Panel.Update:
        public void Update(UInt32 i_nNewOpenPageID, UInt32 i_nNewOpenTabID) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, UInt32, UInt32, void>)0x0046BFF0)(ref this, i_nNewOpenPageID, i_nNewOpenTabID); // .text:0046BD00 ; void __thiscall UIElement_Panel::Update(UIElement_Panel *this, unsigned int i_nNewOpenPageID, unsigned int i_nNewOpenTabID) .text:0046BD00 ?Update@UIElement_Panel@@IAEXKK@Z

        // UIElement_Panel.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, UInt32, UIElement*>)0x0046C5B0)(ref this, i_eType); // .text:0046C1D0 ; UIElement *__thiscall UIElement_Panel::DynamicCast(UIElement_Panel *this, unsigned int i_eType) .text:0046C1D0 ?DynamicCast@UIElement_Panel@@UAEPAVUIElement@@K@Z

        // UIElement_Panel.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x0046C690)(_layout, _full_desc); // .text:0046C2B0 ; UIElement *__cdecl UIElement_Panel::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046C2B0 ?Create@UIElement_Panel@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Panel.SetupTabPageHash:
        public void SetupTabPageHash() => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, void>)0x0046C6C0)(ref this); // .text:0046C2E0 ; void __thiscall UIElement_Panel::SetupTabPageHash(UIElement_Panel *this) .text:0046C2E0 ?SetupTabPageHash@UIElement_Panel@@IAEXXZ

        // UIElement_Panel.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, LayoutDesc*, ElementDesc*, void>)0x0046C550)(ref this, _layout, _full_desc); // .text:0046C170 ; void __thiscall UIElement_Panel::UIElement_Panel(UIElement_Panel *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046C170 ??0UIElement_Panel@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Panel.InqAvailableProperties:
        public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, AvailablePropertySet*, Byte>)0x0046BF60)(ref this, _set); // .text:0046BCB0 ; bool __thiscall UIElement_Panel::InqAvailableProperties(UIElement_Panel *this, AvailablePropertySet *_set) .text:0046BCB0 ?InqAvailableProperties@UIElement_Panel@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Panel.OpenTab:
        public Byte OpenTab(UInt32 _tabID) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, UInt32, Byte>)0x0046C110)(ref this, _tabID); // .text:0046BE20 ; bool __thiscall UIElement_Panel::OpenTab(UIElement_Panel *this, unsigned int _tabID) .text:0046BE20 ?OpenTab@UIElement_Panel@@QAE_NK@Z

        // UIElement_Panel.InqTabFromPage:
        public Byte InqTabFromPage(UInt32 _pageToken, UInt32* _tabToken) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, UInt32, UInt32*, Byte>)0x0046C1A0)(ref this, _pageToken, _tabToken); // .text:0046BEB0 ; bool __thiscall UIElement_Panel::InqTabFromPage(UIElement_Panel *this, unsigned int _pageToken, unsigned int *_tabToken) .text:0046BEB0 ?InqTabFromPage@UIElement_Panel@@QBE_NKAAK@Z

        // UIElement_Panel.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Panel, UIElementMessageInfo*, UIElementMessageListenResult>)0x0046C370)(ref this, i_rMsg); // .text:0046BF90 ; UIElementMessageListenResult __thiscall UIElement_Panel::ListenToElementMessage(UIElement_Panel *this, UIElementMessageInfo *i_rMsg) .text:0046BF90 ?ListenToElementMessage@UIElement_Panel@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z
    }
    public unsafe struct UIElement_Field {
        // Struct:
        public UIElement a0;
        public sbyte m_rolloverStateChange;
        public UInt32 m_oldState;
        public override string ToString() => $"a0(UIElement):{a0}, m_rolloverStateChange:{m_rolloverStateChange:X2}, m_oldState:{m_oldState:X8}";

        // Functions:

        // UIElement_Field.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:00472310 ; UIElement *__cdecl UIElement_Field::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00472310 ?Create@UIElement_Field@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Field.MouseOverTop:
        public void MouseOverTop(Byte _overTop) => ((delegate* unmanaged[Thiscall]<ref UIElement_Field, Byte, void>)0x00472720)(ref this, _overTop); // .text:00472360 ; void __thiscall UIElement_Field::MouseOverTop(UIElement_Field *this, bool _overTop) .text:00472360 ?MouseOverTop@UIElement_Field@@UAEX_N@Z

        // UIElement_Field.CatchDroppedItem:
        public Byte CatchDroppedItem(DragDropInfo* i_pcDDI) => ((delegate* unmanaged[Thiscall]<ref UIElement_Field, DragDropInfo*, Byte>)0x00472810)(ref this, i_pcDDI); // .text:00472450 ; bool __thiscall UIElement_Field::CatchDroppedItem(UIElement_Field *this, DragDropInfo *i_pcDDI) .text:00472450 ?CatchDroppedItem@UIElement_Field@@UAE_NPAVDragDropInfo@@@Z

        // UIElement_Field.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:004724C0 ; void __cdecl UIElement_Field::Register() .text:004724C0 ?Register@UIElement_Field@@SAXXZ

        // UIElement_Field.InqAvailableProperties:
        public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Field, AvailablePropertySet*, Byte>)0x00472890)(ref this, _set); // .text:004724D0 ; bool __thiscall UIElement_Field::InqAvailableProperties(UIElement_Field *this, AvailablePropertySet *_set) .text:004724D0 ?InqAvailableProperties@UIElement_Field@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Field.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Field, LayoutDesc*, ElementDesc*, void>)0x00472670)(ref this, _layout, _full_desc); // .text:004722B0 ; void __thiscall UIElement_Field::UIElement_Field(UIElement_Field *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004722B0 ??0UIElement_Field@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Field.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Field, UInt32, UIElement*>)0x004726A0)(ref this, i_eType); // .text:004722E0 ; UIElement *__thiscall UIElement_Field::DynamicCast(UIElement_Field *this, unsigned int i_eType) .text:004722E0 ?DynamicCast@UIElement_Field@@UAEPAVUIElement@@K@Z
    }

    public unsafe struct UIElement_UIItem {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public UInt32 itemID;
        public UInt32 spellID;
        public int containerDisplay;
        public ACCWeenieObject* weenObj;
        public UInt32 effects;
        public int waiting;
        public int selected;
        public int isOpenable;
        public int isContainer;
        public int isContainerHolder;
        public int valid;
        public int dragOverState;
        public int unghostable;
        public int isSlot;
        public int shortcutState;
        public int m_sellState;
        public int m_tradeState;
        public Byte m_selectable;
        public int m_shortcutNum;
        public int m_delayedShortcutNum;
        public Byte m_shortcutGhosted;
        public int m_quantity;
        public int openState;
        public Double m_heartbeatInterval;
        public Double m_lastHeartbeat;
        public UIElement* m_elem_Icon;
        public UIElement* m_elem_Icon_Overlays;
        public UIElement* m_elem_Icon_Selected;
        public UIElement* m_elem_Icon_Ghosted;
        public UIElement* m_elem_Icon_ShortcutNum;
        public UIElement* m_elem_Icon_SellState;
        public UIElement* m_elem_Icon_TradeState;
        public UIElement* m_elem_Icon_OpenContainer;
        public UIElement* m_elem_Icon_DragAccept;
        public UIElement_Meter* m_elem_Icon_CapacityBar;
        public UIElement_Meter* m_elem_Icon_StructureBar;
        public UIElement_Text* m_elem_Icon_Quantity;
        public UIElement_Text* m_elem_Text;
        public UIElement* m_dragIcon;
        public UIElement* m_elem_Icon_Cooldown_10;
        public UIElement* m_elem_Icon_Cooldown_20;
        public UIElement* m_elem_Icon_Cooldown_30;
        public UIElement* m_elem_Icon_Cooldown_40;
        public UIElement* m_elem_Icon_Cooldown_50;
        public UIElement* m_elem_Icon_Cooldown_60;
        public UIElement* m_elem_Icon_Cooldown_70;
        public UIElement* m_elem_Icon_Cooldown_80;
        public UIElement* m_elem_Icon_Cooldown_90;
        public UIElement* m_elem_Icon_Cooldown_100;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, itemID:{itemID:X8}, spellID:{spellID:X8}, containerDisplay(int):{containerDisplay}, weenObj:->(ACCWeenieObject*)0x{(int)weenObj:X8}, effects:{effects:X8}, waiting(int):{waiting}, selected(int):{selected}, isOpenable(int):{isOpenable}, isContainer(int):{isContainer}, isContainerHolder(int):{isContainerHolder}, valid(int):{valid}, dragOverState(int):{dragOverState}, unghostable(int):{unghostable}, isSlot(int):{isSlot}, shortcutState(int):{shortcutState}, m_sellState(int):{m_sellState}, m_tradeState(int):{m_tradeState}, m_selectable:{m_selectable:X2}, m_shortcutNum(int):{m_shortcutNum}, m_delayedShortcutNum(int):{m_delayedShortcutNum}, m_shortcutGhosted:{m_shortcutGhosted:X2}, m_quantity(int):{m_quantity}, openState(int):{openState}, m_heartbeatInterval:{m_heartbeatInterval:n5}, m_lastHeartbeat:{m_lastHeartbeat:n5}, m_elem_Icon:->(UIElement*)0x{(int)m_elem_Icon:X8}, m_elem_Icon_Overlays:->(UIElement*)0x{(int)m_elem_Icon_Overlays:X8}, m_elem_Icon_Selected:->(UIElement*)0x{(int)m_elem_Icon_Selected:X8}, m_elem_Icon_Ghosted:->(UIElement*)0x{(int)m_elem_Icon_Ghosted:X8}, m_elem_Icon_ShortcutNum:->(UIElement*)0x{(int)m_elem_Icon_ShortcutNum:X8}, m_elem_Icon_SellState:->(UIElement*)0x{(int)m_elem_Icon_SellState:X8}, m_elem_Icon_TradeState:->(UIElement*)0x{(int)m_elem_Icon_TradeState:X8}, m_elem_Icon_OpenContainer:->(UIElement*)0x{(int)m_elem_Icon_OpenContainer:X8}, m_elem_Icon_DragAccept:->(UIElement*)0x{(int)m_elem_Icon_DragAccept:X8}, m_elem_Icon_CapacityBar:->(UIElement_Meter*)0x{(int)m_elem_Icon_CapacityBar:X8}, m_elem_Icon_StructureBar:->(UIElement_Meter*)0x{(int)m_elem_Icon_StructureBar:X8}, m_elem_Icon_Quantity:->(UIElement_Text*)0x{(int)m_elem_Icon_Quantity:X8}, m_elem_Text:->(UIElement_Text*)0x{(int)m_elem_Text:X8}, m_dragIcon:->(UIElement*)0x{(int)m_dragIcon:X8}, m_elem_Icon_Cooldown_10:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_10:X8}, m_elem_Icon_Cooldown_20:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_20:X8}, m_elem_Icon_Cooldown_30:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_30:X8}, m_elem_Icon_Cooldown_40:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_40:X8}, m_elem_Icon_Cooldown_50:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_50:X8}, m_elem_Icon_Cooldown_60:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_60:X8}, m_elem_Icon_Cooldown_70:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_70:X8}, m_elem_Icon_Cooldown_80:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_80:X8}, m_elem_Icon_Cooldown_90:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_90:X8}, m_elem_Icon_Cooldown_100:->(UIElement*)0x{(int)m_elem_Icon_Cooldown_100:X8}";

        // Functions:

        // UIElement_UIItem.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:004E0F40 ; void __thiscall UIElement_UIItem::UIElement_UIItem(UIElement_UIItem *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004E0F40 ??0UIElement_UIItem@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_UIItem.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:004E10B0 ; UIElement *__thiscall UIElement_UIItem::DynamicCast(UIElement_UIItem *this, unsigned int i_eType) .text:004E10B0 ?DynamicCast@UIElement_UIItem@@UAEPAVUIElement@@K@Z

        // UIElement_UIItem.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:004E10E0 ; UIElement *__cdecl UIElement_UIItem::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004E10E0 ?Create@UIElement_UIItem@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_UIItem.SetWaitingState:
        public void SetWaitingState(int _waiting) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, int, void>)0x004E1E40)(ref this, _waiting); // .text:004E11B0 ; void __thiscall UIElement_UIItem::SetWaitingState(UIElement_UIItem *this, int _waiting) .text:004E11B0 ?SetWaitingState@UIElement_UIItem@@QAEXH@Z

        // UIElement_UIItem.SetDelayedShortcutNum:
        // public void SetDelayedShortcutNum(int _shortcutNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, int, void>)0xDEADBEEF)(ref this, _shortcutNum); // .text:004E1230 ; void __thiscall UIElement_UIItem::SetDelayedShortcutNum(UIElement_UIItem *this, int _shortcutNum) .text:004E1230 ?SetDelayedShortcutNum@UIElement_UIItem@@QAEXH@Z

        // UIElement_UIItem.UpdateCapacityDisplay:
        public void UpdateCapacityDisplay() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2370)(ref this); // .text:004E16E0 ; void __thiscall UIElement_UIItem::UpdateCapacityDisplay(UIElement_UIItem *this) .text:004E16E0 ?UpdateCapacityDisplay@UIElement_UIItem@@IAEXXZ

        // UIElement_UIItem.Init_UIItem_Spell_Shortcut:
        // public void Init_UIItem_Spell_Shortcut(UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, void>)0xDEADBEEF)(ref this, _spellID); // .text:004E1140 ; void __thiscall UIElement_UIItem::Init_UIItem_Spell_Shortcut(UIElement_UIItem *this, unsigned int _spellID) .text:004E1140 ?Init_UIItem_Spell_Shortcut@UIElement_UIItem@@QAEXK@Z

        // UIElement_UIItem.UIItem_GetState:
        // public UInt32 UIItem_GetState() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32>)0xDEADBEEF)(ref this); // .text:004E1190 ; unsigned int __thiscall UIElement_UIItem::UIItem_GetState(UIElement_UIItem *this) .text:004E1190 ?UIItem_GetState@UIElement_UIItem@@QAEKXZ

        // UIElement_UIItem.SetShortcutNum:
        public void SetShortcutNum(int _shortcutNum, Byte _ghosted) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, int, Byte, void>)0x004E2220)(ref this, _shortcutNum, _ghosted); // .text:004E1590 ; void __thiscall UIElement_UIItem::SetShortcutNum(UIElement_UIItem *this, int _shortcutNum, bool _ghosted) .text:004E1590 ?SetShortcutNum@UIElement_UIItem@@QAEXH_N@Z

        // UIElement_UIItem.UpdateTooltip:
        public void UpdateTooltip() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2940)(ref this); // .text:004E1CB0 ; void __thiscall UIElement_UIItem::UpdateTooltip(UIElement_UIItem *this) .text:004E1CB0 ?UpdateTooltip@UIElement_UIItem@@IAEXXZ

        // UIElement_UIItem.SetSelectableState:
        // public void SetSelectableState(Byte _selectable) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, Byte, void>)0xDEADBEEF)(ref this, _selectable); // .text:004E1280 ; void __thiscall UIElement_UIItem::SetSelectableState(UIElement_UIItem *this, bool _selectable) .text:004E1280 ?SetSelectableState@UIElement_UIItem@@QAEX_N@Z

        // UIElement_UIItem.SetQuantity:
        // public void SetQuantity(int _quantity) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, int, void>)0xDEADBEEF)(ref this, _quantity); // .text:004E12C0 ; void __thiscall UIElement_UIItem::SetQuantity(UIElement_UIItem *this, int _quantity) .text:004E12C0 ?SetQuantity@UIElement_UIItem@@QAEXJ@Z

        // UIElement_UIItem.UIItem_SetState:
        public Byte UIItem_SetState(UInt32 _state) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, Byte>)0x004E2190)(ref this, _state); // .text:004E1500 ; bool __thiscall UIElement_UIItem::UIItem_SetState(UIElement_UIItem *this, unsigned int _state) .text:004E1500 ?UIItem_SetState@UIElement_UIItem@@QAE_NK@Z

        // UIElement_UIItem.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:004E1C70 ; bool __thiscall UIElement_UIItem::InqAvailableProperties(UIElement_UIItem *this, AvailablePropertySet *_set) .text:004E1C70 ?InqAvailableProperties@UIElement_UIItem@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_UIItem.Clear_UIItem:
        // public void Clear_UIItem() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0xDEADBEEF)(ref this); // .text:004E1170 ; void __thiscall UIElement_UIItem::Clear_UIItem(UIElement_UIItem *this) .text:004E1170 ?Clear_UIItem@UIElement_UIItem@@QAEXXZ

        // UIElement_UIItem.SetSelectedState:
        // public void SetSelectedState(int _selected) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, int, void>)0xDEADBEEF)(ref this, _selected); // .text:004E1240 ; void __thiscall UIElement_UIItem::SetSelectedState(UIElement_UIItem *this, int _selected) .text:004E1240 ?SetSelectedState@UIElement_UIItem@@QAEXH@Z

        // UIElement_UIItem.ListenToGlobalMessage:
        // public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, int, void>)0xDEADBEEF)(ref this, i_messageID, i_data_int); // .text:004E12D0 ; void __thiscall UIElement_UIItem::ListenToGlobalMessage(UIElement_UIItem *this, unsigned int i_messageID, int i_data_int) .text:004E12D0 ?ListenToGlobalMessage@UIElement_UIItem@@MAEXKJ@Z

        // UIElement_UIItem.PostInit:
        // public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0xDEADBEEF)(ref this); // .text:004E1870 ; void __thiscall UIElement_UIItem::PostInit(UIElement_UIItem *this) .text:004E1870 ?PostInit@UIElement_UIItem@@MAEXXZ

        // UIElement_UIItem.UpdateCooldownDisplay:
        public void UpdateCooldownDisplay() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2AB0)(ref this); // .text:004E1E20 ; void __thiscall UIElement_UIItem::UpdateCooldownDisplay(UIElement_UIItem *this) .text:004E1E20 ?UpdateCooldownDisplay@UIElement_UIItem@@IAEXXZ

        // UIElement_UIItem.UIItem_SetIcon:
        public Byte UIItem_SetIcon() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, Byte>)0x004E2D10)(ref this); // .text:004E2080 ; bool __thiscall UIElement_UIItem::UIItem_SetIcon(UIElement_UIItem *this) .text:004E2080 ?UIItem_SetIcon@UIElement_UIItem@@QAE_NXZ

        // UIElement_UIItem.UIItem_Update:
        public void UIItem_Update() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2E60)(ref this); // .text:004E21D0 ; void __thiscall UIElement_UIItem::UIItem_Update(UIElement_UIItem *this) .text:004E21D0 ?UIItem_Update@UIElement_UIItem@@QAEXXZ

        // UIElement_UIItem.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32>)0xDEADBEEF)(ref this); // .text:004E10D0 ; unsigned int __thiscall UIElement_UIItem::GetUIElementType(UIElement_UIItem *this) .text:004E10D0 ?GetUIElementType@UIElement_UIItem@@UBEKXZ

        // UIElement_UIItem.SetDragAcceptState:
        public void SetDragAcceptState(UInt32 _state) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, void>)0x004E1F20)(ref this, _state); // .text:004E1290 ; void __thiscall UIElement_UIItem::SetDragAcceptState(UIElement_UIItem *this, unsigned int _state) .text:004E1290 ?SetDragAcceptState@UIElement_UIItem@@QAEXK@Z

        // UIElement_UIItem.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004E2000)(); // .text:004E1370 ; void __cdecl UIElement_UIItem::Register() .text:004E1370 ?Register@UIElement_UIItem@@SAXXZ

        // UIElement_UIItem.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:004E1390 ; UIElementMessageListenResult __thiscall UIElement_UIItem::ListenToElementMessage(UIElement_UIItem *this, UIElementMessageInfo *i_rMsg) .text:004E1390 ?ListenToElementMessage@UIElement_UIItem@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_UIItem.SetOpenContainerState:
        // public void SetOpenContainerState(Byte _open) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, Byte, void>)0xDEADBEEF)(ref this, _open); // .text:004E1200 ; void __thiscall UIElement_UIItem::SetOpenContainerState(UIElement_UIItem *this, bool _open) .text:004E1200 ?SetOpenContainerState@UIElement_UIItem@@QAEX_N@Z

        // UIElement_UIItem.UpdateQuantityDisplay:
        public void UpdateQuantityDisplay() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2A30)(ref this); // .text:004E1DA0 ; void __thiscall UIElement_UIItem::UpdateQuantityDisplay(UIElement_UIItem *this) .text:004E1DA0 ?UpdateQuantityDisplay@UIElement_UIItem@@IAEXXZ

        // UIElement_UIItem.Init_UIItem:
        // public void Init_UIItem(UInt32 _itemID, int _containerDisplay) => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, UInt32, int, void>)0xDEADBEEF)(ref this, _itemID, _containerDisplay); // .text:004E1110 ; void __thiscall UIElement_UIItem::Init_UIItem(UIElement_UIItem *this, unsigned int _itemID, int _containerDisplay) .text:004E1110 ?Init_UIItem@UIElement_UIItem@@QAEXKH@Z

        // UIElement_UIItem.UpdateStructureDisplay:
        public void UpdateStructureDisplay() => ((delegate* unmanaged[Thiscall]<ref UIElement_UIItem, void>)0x004E2430)(ref this); // .text:004E17A0 ; void __thiscall UIElement_UIItem::UpdateStructureDisplay(UIElement_UIItem *this) .text:004E17A0 ?UpdateStructureDisplay@UIElement_UIItem@@IAEXXZ
    }
    public unsafe struct UIElement_Meter {
        // Struct:
        public UIElement a0;
        public Byte m_framemeter;
        public Byte m_animating;
        public Double m_animStartTime;
        public Double m_animEndTime;
        public Single m_anim_start_pos;
        public Single m_anim_end_pos;
        public int m_currentFrame;
        public Single m_fOldPosition;
        public UIElement* m_pcChildImage;
        public UInt32 m_eDirection;
        public override string ToString() => $"a0(UIElement):{a0}, m_framemeter:{m_framemeter:X2}, m_animating:{m_animating:X2}, m_animStartTime:{m_animStartTime:n5}, m_animEndTime:{m_animEndTime:n5}, m_anim_start_pos:{m_anim_start_pos:n5}, m_anim_end_pos:{m_anim_end_pos:n5}, m_currentFrame(int):{m_currentFrame}, m_fOldPosition:{m_fOldPosition:n5}, m_pcChildImage:->(UIElement*)0x{(int)m_pcChildImage:X8}, m_eDirection:{m_eDirection:X8}";

        // Functions:

        // UIElement_Meter.RemoveChild:
        // public void RemoveChild(UIRegion* _child) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, UIRegion*, void>)0xDEADBEEF)(ref this, _child); // .text:0046F590 ; void __thiscall UIElement_Meter::RemoveChild(UIElement_Meter *this, UIRegion *_child) .text:0046F590 ?RemoveChild@UIElement_Meter@@UAEXPAVUIRegion@@@Z

        // UIElement_Meter.StartAnimation:
        // public void StartAnimation() => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, void>)0xDEADBEEF)(ref this); // .text:0046F5C0 ; void __thiscall UIElement_Meter::StartAnimation(UIElement_Meter *this) .text:0046F5C0 ?StartAnimation@UIElement_Meter@@QAEXXZ

        // UIElement_Meter.UpdateChild:
        // public void UpdateChild() => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, void>)0xDEADBEEF)(ref this); // .text:0046F660 ; void __thiscall UIElement_Meter::UpdateChild(UIElement_Meter *this) .text:0046F660 ?UpdateChild@UIElement_Meter@@IAEXXZ

        // UIElement_Meter.UpdateFrame:
        // public void UpdateFrame() => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, void>)0xDEADBEEF)(ref this); // .text:0046F940 ; void __thiscall UIElement_Meter::UpdateFrame(UIElement_Meter *this) .text:0046F940 ?UpdateFrame@UIElement_Meter@@IAEXXZ

        // UIElement_Meter.ResizeTo:
        // public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, int, int, void>)0xDEADBEEF)(ref this, _width, _height); // .text:0046FFB0 ; void __thiscall UIElement_Meter::ResizeTo(UIElement_Meter *this, const int _width, const int _height) .text:0046FFB0 ?ResizeTo@UIElement_Meter@@UAEXJJ@Z

        // UIElement_Meter.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:0046F4C0 ; void __thiscall UIElement_Meter::UIElement_Meter(UIElement_Meter *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046F4C0 ??0UIElement_Meter@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Meter.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:0046F560 ; UIElement *__cdecl UIElement_Meter::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046F560 ?Create@UIElement_Meter@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Meter.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:0046F540 ; UIElement *__thiscall UIElement_Meter::DynamicCast(UIElement_Meter *this, unsigned int i_eType) .text:0046F540 ?DynamicCast@UIElement_Meter@@UAEPAVUIElement@@K@Z

        // UIElement_Meter.Initialize:
        // public void Initialize() => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, void>)0xDEADBEEF)(ref this); // .text:0046F7B0 ; void __thiscall UIElement_Meter::Initialize(UIElement_Meter *this) .text:0046F7B0 ?Initialize@UIElement_Meter@@UAEXXZ

        // UIElement_Meter.DrawChildren:
        // public void DrawChildren(Box2D* i_rectObjectSelf, Box2D* i_rectObjectClip, SmartArray<Box2D>* i_aObjectBoxes, UISurface* i_pSurface) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*, void>)0xDEADBEEF)(ref this, i_rectObjectSelf, i_rectObjectClip, i_aObjectBoxes, i_pSurface); // .text:0046FBD0 ; void __thiscall UIElement_Meter::DrawChildren(UIElement_Meter *this, Box2D *i_rectObjectSelf, Box2D *i_rectObjectClip, SmartArray<Box2D,1> *i_aObjectBoxes, UISurface *i_pSurface) .text:0046FBD0 ?DrawChildren@UIElement_Meter@@MAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIElement_Meter.OnSetAttribute:
        // public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, BaseProperty*, void>)0xDEADBEEF)(ref this, _attribute); // .text:0046FE70 ; void __thiscall UIElement_Meter::OnSetAttribute(UIElement_Meter *this, BaseProperty *_attribute) .text:0046FE70 ?OnSetAttribute@UIElement_Meter@@UAEXABVBaseProperty@@@Z

        // UIElement_Meter.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0046F7A0 ; void __cdecl UIElement_Meter::Register() .text:0046F7A0 ?Register@UIElement_Meter@@SAXXZ

        // UIElement_Meter.ListenToGlobalMessage:
        // public void ListenToGlobalMessage(UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, UInt32, int, void>)0xDEADBEEF)(ref this, _messageID, _data_int); // .text:0046F870 ; void __thiscall UIElement_Meter::ListenToGlobalMessage(UIElement_Meter *this, unsigned int _messageID, int _data_int) .text:0046F870 ?ListenToGlobalMessage@UIElement_Meter@@UAEXKJ@Z

        // UIElement_Meter.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Meter, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:0046F8F0 ; bool __thiscall UIElement_Meter::InqAvailableProperties(UIElement_Meter *this, AvailablePropertySet *_set) .text:0046F8F0 ?InqAvailableProperties@UIElement_Meter@@UBE_NAAVAvailablePropertySet@@@Z
    }
    public unsafe struct UIElement_Text {
        // Struct:
        public UIElement_Scrollable a0;
        public CInputHandler a1;
        public GlyphList m_glyphList;
        public UInt32 m_nCursorPos;
        public UInt32 m_nSelectionStart;
        public UInt32 m_nSelectionEnd;
        public GlyphList m_glTruncate;
        public UInt32 m_nTruncationPos;
        public int m_cxTrailer;
        public int m_cyTrailer;
        public UInt32 m_cxAdjustedLineNumber;
        public int m_cxAdjustedLineSize;
        public UInt32 m_bitField;
        public UInt32 m_eHorizontalJustification;
        public UInt32 m_eVerticalJustification;
        public static delegate* unmanaged[Cdecl]<UInt16, Byte> m_filter; // bool (__cdecl *m_filter)(unsigned __int16);
        public RGBAColor m_curFontColor;
        public Font* m_curFontObj;
        public RGBAColor m_curTagFontColor;
        public UInt32 m_curOutlineColor;
        public int m_margU;
        public int m_margD;
        public int m_margL;
        public int m_margR;
        public Double m_lastCursorMoveTime;
        public Double m_lastFlashFlipTime;
        public Box2D m_lastCursor;
        public SmartArray<PTR<StringDownload>> m_downloadQueue;
        public override string ToString() => $"a0(UIElement_Scrollable):{a0}, a1(CInputHandler):{a1}, m_glyphList(GlyphList):{m_glyphList}, m_nCursorPos:{m_nCursorPos:X8}, m_nSelectionStart:{m_nSelectionStart:X8}, m_nSelectionEnd:{m_nSelectionEnd:X8}, m_glTruncate(GlyphList):{m_glTruncate}, m_nTruncationPos:{m_nTruncationPos:X8}, m_cxTrailer(int):{m_cxTrailer}, m_cyTrailer(int):{m_cyTrailer}, m_cxAdjustedLineNumber:{m_cxAdjustedLineNumber:X8}, m_cxAdjustedLineSize(int):{m_cxAdjustedLineSize}, m_bitField:{m_bitField:X8}, m_eHorizontalJustification:{m_eHorizontalJustification:X8}, m_eVerticalJustification:{m_eVerticalJustification:X8}, m_curFontColor(RGBAColor):{m_curFontColor}, m_curFontObj:->(Font*)0x{(int)m_curFontObj:X8}, m_curTagFontColor(RGBAColor):{m_curTagFontColor}, m_curOutlineColor:{m_curOutlineColor:X8}, m_margU(int):{m_margU}, m_margD(int):{m_margD}, m_margL(int):{m_margL}, m_margR(int):{m_margR}, m_lastCursorMoveTime:{m_lastCursorMoveTime:n5}, m_lastFlashFlipTime:{m_lastFlashFlipTime:n5}, m_lastCursor(Box2D):{m_lastCursor}, m_downloadQueue(SmartArray<StringDownload*,1>):{m_downloadQueue}";
        // Enums:
        public enum UIText_InqSize_Flag : UInt32 {
            UITS_MAX_WIDTH = 0x0,
            UITS_CUR_WIDTH = 0x1,
            UITS_CUR_PARENT_WIDTH = 0x2,
            UITS_DESC_WIDTH = 0x3,
        };
        public enum AddTextFlags : UInt32 {
            atf_Default = 0x0,
            atf_PerserveSelection = 0x1,
            atf_AppendText = 0x2,
        };
        public enum CursorMovementFlags : UInt32 {
            ctm_Default = 0x0,
            ctm_SelectText = 0x1,
            ctm_DontSelectText = 0x2,
        };
        public enum UIText_Flag : UInt32 {
            UITF_NONE = 0x0,
            UITF_EDITABLE = 0x1,
            UITF_ONE_LINE = 0x2,
            UITF_SELECTABLE = 0x4,
            UITF_NO_IME = 0x8,
            UITF_OUTLINE = 0x10,
            UITF_DROPSHADOW = 0x20,
            UITF_MOUSE_SELECTING = 0x40,
            UITF_SELECTING = 0x80,
            UITF_DIRTY = 0x100,
            UITF_CURSOR_VISIBLE = 0x200,
            UITF_FIT_TO_TEXT = 0x400,
            UITF_TRUNCATE_TEXT_TO_FIT = 0x800,
            UITF_LOSE_FOCUS_ON_ESCAPE = 0x1000,
            UITF_LOSE_FOCUS_ON_ACCEPT_INPUT = 0x2000,
        };

        // Functions:

        // UIElement_Text.ClearAllText:
        public void ClearAllText() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0x00467AE0)(ref this); // .text:00467850 ; void __thiscall UIElement_Text::ClearAllText(UIElement_Text *this) .text:00467850 ?ClearAllText@UIElement_Text@@QAEXXZ

        // UIElement_Text.ResizeTo:
        public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, int, void>)0x00467CC0)(ref this, _width, _height); // .text:00467A30 ; void __thiscall UIElement_Text::ResizeTo(UIElement_Text *this, const int _width, const int _height) .text:00467A30 ?ResizeTo@UIElement_Text@@UAEXJJ@Z

        // UIElement_Text.SetSelectable:
        // public void SetSelectable(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:004681C0 ; void __thiscall UIElement_Text::SetSelectable(UIElement_Text *this, bool _b) .text:004681C0 ?SetSelectable@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetFontDIDNum:
        // public void SetFontDIDNum(UInt32 _fontDIDNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, void>)0xDEADBEEF)(ref this, _fontDIDNum); // .text:00468290 ; void __thiscall UIElement_Text::SetFontDIDNum(UIElement_Text *this, unsigned int _fontDIDNum) .text:00468290 ?SetFontDIDNum@UIElement_Text@@QAEXK@Z

        // UIElement_Text.DeterminePositionFromXY:
        // public UInt32 DeterminePositionFromXY(int i_x, int i_y) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, int, UInt32>)0xDEADBEEF)(ref this, i_x, i_y); // .text:004688F0 ; unsigned int __thiscall UIElement_Text::DeterminePositionFromXY(UIElement_Text *this, int i_x, int i_y) .text:004688F0 ?DeterminePositionFromXY@UIElement_Text@@IAEKJJ@Z

        // UIElement_Text.InqGlyphs:
        // public Byte InqGlyphs(PStringBase<UInt16>* _text, SmartArray<Glyph>* _glyphs) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, SmartArray<Glyph>*, Byte>)0xDEADBEEF)(ref this, _text, _glyphs); // .text:00468EA0 ; bool __thiscall UIElement_Text::InqGlyphs(UIElement_Text *this, PStringBase<unsigned short> *_text, SmartArray<Glyph,1> *_glyphs) .text:00468EA0 ?InqGlyphs@UIElement_Text@@IAE_NABV?$PStringBase@G@@AAV?$SmartArray@VGlyph@@$00@@@Z

        // UIElement_Text.SetSelectionStart:
        // public Byte SetSelectionStart(UInt32 i_nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte>)0xDEADBEEF)(ref this, i_nPos); // .text:00466E60 ; bool __thiscall UIElement_Text::SetSelectionStart(UIElement_Text *this, unsigned int i_nPos) .text:00466E60 ?SetSelectionStart@UIElement_Text@@QAE_NK@Z

        // UIElement_Text.SetTruncateTextToFit:
        // public void SetTruncateTextToFit(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00467480 ; void __thiscall UIElement_Text::SetTruncateTextToFit(UIElement_Text *this, bool _b) .text:00467480 ?SetTruncateTextToFit@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32>)0x006B1960)(ref this); // .text:006B0A90 ; unsigned int __thiscall UIElement_Text::GetUIElementType(TextureVelocityPartHook *this) .text:006B0A90 ?GetUIElementType@UIElement_Text@@UBEKXZ

        // UIElement_Text.InqSizewMargins:
        // public Byte InqSizewMargins(StringInfo* _info, int* _width, int* _height, UIElement_Text.UIText_InqSize_Flag i_eFlag) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, StringInfo*, int*, int*, UIElement_Text.UIText_InqSize_Flag, Byte>)0xDEADBEEF)(ref this, _info, _width, _height, i_eFlag); // .text:00469660 ; bool __thiscall UIElement_Text::InqSizewMargins(UIElement_Text *this, StringInfo *_info, int *_width, int *_height, UIElement_Text::UIText_InqSize_Flag i_eFlag) .text:00469660 ?InqSizewMargins@UIElement_Text@@QAE_NABVStringInfo@@AAJ1W4UIText_InqSize_Flag@1@@Z

        // UIElement_Text.SetStringInfoWithFont:
        // public void SetStringInfoWithFont(StringInfo* _info, int _fontDIDNum, int _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, StringInfo*, int, int, void>)0xDEADBEEF)(ref this, _info, _fontDIDNum, _fontColorNum); // .text:0046A0E0 ; void __thiscall UIElement_Text::SetStringInfoWithFont(UIElement_Text *this, StringInfo *_info, int _fontDIDNum, int _fontColorNum) .text:0046A0E0 ?SetStringInfoWithFont@UIElement_Text@@QAEXABVStringInfo@@JJ@Z

        // UIElement_Text.CharacterHandler:
        // public void CharacterHandler(wchar_t charToHandle) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, wchar_t, void>)0xDEADBEEF)(ref this, charToHandle); // .text:00469B90 ; void __thiscall UIElement_Text::CharacterHandler(UIElement_Text *this, wchar_t charToHandle) .text:00469B90 ?CharacterHandler@UIElement_Text@@UAEXG@Z

        // UIElement_Text.SetStringInfo:
        public void SetStringInfo(StringInfo* _info) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, StringInfo*, void>)0x0046A350)(ref this, _info); // .text:0046A0C0 ; void __thiscall UIElement_Text::SetStringInfo(UIElement_Text *this, StringInfo *_info) .text:0046A0C0 ?SetStringInfo@UIElement_Text@@QAEXABVStringInfo@@@Z

        // UIElement_Text.CalcJustification:
        // public int CalcJustification(UInt32 i_uiTextSize, Byte i_bHorizontal) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte, int>)0xDEADBEEF)(ref this, i_uiTextSize, i_bHorizontal); // .text:00467260 ; int __thiscall UIElement_Text::CalcJustification(UIElement_Text *this, unsigned int i_uiTextSize, bool i_bHorizontal) .text:00467260 ?CalcJustification@UIElement_Text@@QAEJK_N@Z

        // UIElement_Text.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:004687C0 ; UIElementMessageListenResult __thiscall UIElement_Text::ListenToElementMessage(UIElement_Text *this, UIElementMessageInfo *i_rMsg) .text:004687C0 ?ListenToElementMessage@UIElement_Text@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_Text.SetHorizontalJustification:
        // public Byte SetHorizontalJustification(UInt32 i_eJustification) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte>)0xDEADBEEF)(ref this, i_eJustification); // .text:00467200 ; bool __thiscall UIElement_Text::SetHorizontalJustification(UIElement_Text *this, unsigned int i_eJustification) .text:00467200 ?SetHorizontalJustification@UIElement_Text@@QAE?B_NK@Z

        // UIElement_Text.SetCursorPositionFromXY:
        // public Byte SetCursorPositionFromXY(int i_x, int i_y, UIElement_Text.CursorMovementFlags i_selMode) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, int, UIElement_Text.CursorMovementFlags, Byte>)0xDEADBEEF)(ref this, i_x, i_y, i_selMode); // .text:00468CD0 ; bool __thiscall UIElement_Text::SetCursorPositionFromXY(UIElement_Text *this, int i_x, int i_y, UIElement_Text::CursorMovementFlags i_selMode) .text:00468CD0 ?SetCursorPositionFromXY@UIElement_Text@@IAE_NJJW4CursorMovementFlags@1@@Z

        // UIElement_Text.ScrollPage:
        public void ScrollPage(Byte i_bUp) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0x00466570)(ref this, i_bUp); // .text:00466440 ; void __thiscall UIElement_Text::ScrollPage(UIElement_Text *this, bool i_bUp) .text:00466440 ?ScrollPage@UIElement_Text@@QAEX_N@Z

        // UIElement_Text.MoveBeginEndLine:
        // public Byte MoveBeginEndLine(Byte i_bBegin, UInt32 i_nStart, UInt32* o_nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, UInt32, UInt32*, Byte>)0xDEADBEEF)(ref this, i_bBegin, i_nStart, o_nPos); // .text:00466DB0 ; bool __thiscall UIElement_Text::MoveBeginEndLine(UIElement_Text *this, bool i_bBegin, unsigned int i_nStart, unsigned int *o_nPos) .text:00466DB0 ?MoveBeginEndLine@UIElement_Text@@IAE_N_NKAAK@Z

        // UIElement_Text.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:004677E0 ; UIElement *__thiscall UIElement_Text::DynamicCast(UIElement_Text *this, unsigned int i_eType) .text:004677E0 ?DynamicCast@UIElement_Text@@UAEPAVUIElement@@K@Z

        // UIElement_Text.ClearSelection:
        public Byte ClearSelection() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0x00466540)(ref this); // .text:00466410 ; bool __thiscall UIElement_Text::ClearSelection(UIElement_Text *this) .text:00466410 ?ClearSelection@UIElement_Text@@QAE_NXZ

        // UIElement_Text.GetPreParsedText:
        public PStringBase<UInt16>* GetPreParsedText(PStringBase<UInt16>* result) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x004668A0)(ref this, result); // .text:00466770 ; PStringBase<unsigned short> *__thiscall UIElement_Text::GetPreParsedText(UIElement_Text *this, PStringBase<unsigned short> *result) .text:00466770 ?GetPreParsedText@UIElement_Text@@QBE?AV?$PStringBase@G@@XZ

        // UIElement_Text.MoveCursorToPosition:
        // public void MoveCursorToPosition(int i_nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, void>)0xDEADBEEF)(ref this, i_nPos); // .text:00468E90 ; void __thiscall UIElement_Text::MoveCursorToPosition(UIElement_Text *this, int i_nPos) .text:00468E90 ?MoveCursorToPosition@UIElement_Text@@QAEXJ@Z

        // UIElement_Text.ScrollToPosition:
        public void ScrollToPosition(int i_iPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, void>)0x00469440)(ref this, i_iPos); // .text:004691B0 ; void __thiscall UIElement_Text::ScrollToPosition(UIElement_Text *this, const int i_iPos) .text:004691B0 ?ScrollToPosition@UIElement_Text@@QAEXJ@Z

        // UIElement_Text.BeheadText:
        // public void BeheadText(UInt32 i_cPosition, Byte bKeepCurrentTextInView) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte, void>)0xDEADBEEF)(ref this, i_cPosition, bKeepCurrentTextInView); // .text:00469970 ; void __thiscall UIElement_Text::BeheadText(UIElement_Text *this, unsigned int i_cPosition, bool bKeepCurrentTextInView) .text:00469970 ?BeheadText@UIElement_Text@@QAEXK_N@Z

        // UIElement_Text.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 _messageID, int _data) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, int, void>)0x0046A730)(ref this, _messageID, _data); // .text:0046A4A0 ; void __thiscall UIElement_Text::ListenToGlobalMessage(UIElement_Text *this, unsigned int _messageID, int _data) .text:0046A4A0 ?ListenToGlobalMessage@UIElement_Text@@UAEXKJ@Z

        // UIElement_Text.ChangeExistingTextToNewFont:
        // public void ChangeExistingTextToNewFont(Font* i_pNewFont) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Font*, void>)0xDEADBEEF)(ref this, i_pNewFont); // .text:00466D70 ; void __thiscall UIElement_Text::ChangeExistingTextToNewFont(UIElement_Text *this, Font *i_pNewFont) .text:00466D70 ?ChangeExistingTextToNewFont@UIElement_Text@@QAEXPAVFont@@@Z

        // UIElement_Text.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:00467800 ; bool __thiscall UIElement_Text::InqAvailableProperties(UIElement_Text *this, AvailablePropertySet *_set) .text:00467800 ?InqAvailableProperties@UIElement_Text@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Text.SetFitToText:
        // public void SetFitToText(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00468540 ; void __thiscall UIElement_Text::SetFitToText(UIElement_Text *this, bool _b) .text:00468540 ?SetFitToText@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.InqScrollDelta:
        public int InqScrollDelta(Byte i_bHorizontal, Byte i_bIncrement, Byte i_bPage) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, Byte, Byte, int>)0x00468C40)(ref this, i_bHorizontal, i_bIncrement, i_bPage); // .text:004689B0 ; int __thiscall UIElement_Text::InqScrollDelta(UIElement_Text *this, bool i_bHorizontal, bool i_bIncrement, bool i_bPage) .text:004689B0 ?InqScrollDelta@UIElement_Text@@UAEJ_N00@Z

        // UIElement_Text.MoveCursor:
        // public Byte MoveCursor(TextDefs.Direction _dir) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, TextDefs.Direction, Byte>)0xDEADBEEF)(ref this, _dir); // .text:00468D00 ; bool __thiscall UIElement_Text::MoveCursor(UIElement_Text *this, TextDefs::Direction _dir) .text:00468D00 ?MoveCursor@UIElement_Text@@IAE_NW4Direction@TextDefs@@@Z

        // UIElement_Text.MouseMove:
        public void MouseMove(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, int, void>)0x00469880)(ref this, i_xWindow, i_yWindow); // .text:004695F0 ; void __thiscall UIElement_Text::MouseMove(UIElement_Text *this, int i_xWindow, int i_yWindow) .text:004695F0 ?MouseMove@UIElement_Text@@MAEXJJ@Z

        // UIElement_Text.Paste:
        // public void Paste() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:0046A110 ; void __thiscall UIElement_Text::Paste(UIElement_Text *this) .text:0046A110 ?Paste@UIElement_Text@@AAEXXZ

        // UIElement_Text.DoFontReset:
        // public void DoFontReset() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:0046A560 ; void __thiscall UIElement_Text::DoFontReset(UIElement_Text *this) .text:0046A560 ?DoFontReset@UIElement_Text@@QAEXXZ

        // UIElement_Text.CleanupStringDownloads:
        // public void CleanupStringDownloads() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:004666A0 ; void __thiscall UIElement_Text::CleanupStringDownloads(UIElement_Text *this) .text:004666A0 ?CleanupStringDownloads@UIElement_Text@@IAEXXZ

        // UIElement_Text.Deselect:
        public void Deselect() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0x00467BC0)(ref this); // .text:00467930 ; void __thiscall UIElement_Text::Deselect(UIElement_Text *this) .text:00467930 ?Deselect@UIElement_Text@@QAEXXZ

        // UIElement_Text.DrawStart:
        // (ERR) .text:00468B20 ; public: virtual void __thiscall UIElement_Text::DrawStart(void) .text:00468B20 ?DrawStart@UIElement_Text@@UAEXXZ

        // UIElement_Text.RegisterInputMaps:
        public Byte RegisterInputMaps(int i_nPriority) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int, Byte>)0x004675E0)(ref this, i_nPriority); // .text:00467350 ; bool __thiscall UIElement_Text::RegisterInputMaps(UIElement_Text *this, int i_nPriority) .text:00467350 ?RegisterInputMaps@UIElement_Text@@UAE_NJ@Z

        // UIElement_Text.DrawSelf:
        public void DrawSelf(Box2D* i_rectObjectSelf, Box2D* i_rectObjectClip, SmartArray<Box2D>* i_aObjectBoxes, UISurface* _surface) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Box2D*, Box2D*, SmartArray<Box2D>*, UISurface*, void>)0x00467D30)(ref this, i_rectObjectSelf, i_rectObjectClip, i_aObjectBoxes, _surface); // .text:00467AA0 ; void __thiscall UIElement_Text::DrawSelf(UIElement_Text *this, Box2D *i_rectObjectSelf, Box2D *i_rectObjectClip, SmartArray<Box2D,1> *i_aObjectBoxes, UISurface *_surface) .text:00467AA0 ?DrawSelf@UIElement_Text@@UAEXABVBox2D@@0ABV?$SmartArray@VBox2D@@$00@@PAVUISurface@@@Z

        // UIElement_Text.SetEditable:
        // public void SetEditable(Byte _editable) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _editable); // .text:004680D0 ; void __thiscall UIElement_Text::SetEditable(UIElement_Text *this, bool _editable) .text:004680D0 ?SetEditable@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.AppendTextWithFont:
        public void AppendTextWithFont(PStringBase<UInt16>* _text, int _fontDIDNum, int _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, int, int, void>)0x0046A000)(ref this, _text, _fontDIDNum, _fontColorNum); // .text:00469D70 ; void __thiscall UIElement_Text::AppendTextWithFont(UIElement_Text *this, PStringBase<unsigned short> *_text, int _fontDIDNum, int _fontColorNum) .text:00469D70 ?AppendTextWithFont@UIElement_Text@@QAEXABV?$PStringBase@G@@JJ@Z

        // UIElement_Text.SetDirty:
        // public void SetDirty(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00466850 ; void __thiscall UIElement_Text::SetDirty(UIElement_Text *this, bool _b) .text:00466850 ?SetDirty@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetFontColorHelper:
        // public void SetFontColorHelper(UInt32 _property, RGBAColor* _color, UInt32 _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, RGBAColor*, UInt32, void>)0xDEADBEEF)(ref this, _property, _color, _fontColorNum); // .text:00466AC0 ; void __thiscall UIElement_Text::SetFontColorHelper(UIElement_Text *this, unsigned int _property, RGBAColor *_color, unsigned int _fontColorNum) .text:00466AC0 ?SetFontColorHelper@UIElement_Text@@IAEXKAAVRGBAColor@@K@Z

        // UIElement_Text.GetSelectedText:
        // public PStringBase<UInt16>* GetSelectedText(PStringBase<UInt16>* result) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, PStringBase<UInt16>*>)0xDEADBEEF)(ref this, result); // .text:004679A0 ; PStringBase<unsigned short> *__thiscall UIElement_Text::GetSelectedText(UIElement_Text *this, PStringBase<unsigned short> *result) .text:004679A0 ?GetSelectedText@UIElement_Text@@QBE?AV?$PStringBase@G@@XZ

        // UIElement_Text.IsPositionInView:
        // public Byte IsPositionInView(int* _nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int*, Byte>)0xDEADBEEF)(ref this, _nPos); // .text:00468AA0 ; bool __thiscall UIElement_Text::IsPositionInView(UIElement_Text *this, const int *_nPos) .text:00468AA0 ?IsPositionInView@UIElement_Text@@QAE?B_NABJ@Z

        // UIElement_Text.SetCursorPosition:
        // public Byte SetCursorPosition(UInt32 i_nPos, UIElement_Text.CursorMovementFlags i_selMode) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, UIElement_Text.CursorMovementFlags, Byte>)0xDEADBEEF)(ref this, i_nPos, i_selMode); // .text:00468B90 ; bool __thiscall UIElement_Text::SetCursorPosition(UIElement_Text *this, unsigned int i_nPos, UIElement_Text::CursorMovementFlags i_selMode) .text:00468B90 ?SetCursorPosition@UIElement_Text@@IAE_NKW4CursorMovementFlags@1@@Z

        // UIElement_Text.AddText_Internal:
        // public void AddText_Internal(PStringBase<UInt16> _text, UInt32 i_atfFlags) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>, UInt32, void>)0xDEADBEEF)(ref this, _text, i_atfFlags); // .text:00469A30 ; void __thiscall UIElement_Text::AddText_Internal(UIElement_Text *this, PStringBase<unsigned short> _text, unsigned int i_atfFlags) .text:00469A30 ?AddText_Internal@UIElement_Text@@AAEXV?$PStringBase@G@@K@Z

        // UIElement_Text.SetOutline:
        // public void SetOutline(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00466630 ; void __thiscall UIElement_Text::SetOutline(UIElement_Text *this, bool _b) .text:00466630 ?SetOutline@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetFontDIDWithoutChangingExistingText:
        // public void SetFontDIDWithoutChangingExistingText(UInt32 _did) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, void>)0xDEADBEEF)(ref this, _did); // .text:00466D50 ; void __thiscall UIElement_Text::SetFontDIDWithoutChangingExistingText(UIElement_Text *this, IDClass<_tagDataID,32,0> _did) .text:00466D50 ?SetFontDIDWithoutChangingExistingText@UIElement_Text@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // UIElement_Text.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:00468790 ; UIElement *__cdecl UIElement_Text::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00468790 ?Create@UIElement_Text@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Text.SetNoIme:
        // public void SetNoIme(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00466600 ; void __thiscall UIElement_Text::SetNoIme(UIElement_Text *this, bool _b) .text:00466600 ?SetNoIme@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetLoseFocusOnAcceptInput:
        // public void SetLoseFocusOnAcceptInput(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00467520 ; void __thiscall UIElement_Text::SetLoseFocusOnAcceptInput(UIElement_Text *this, bool _b) .text:00467520 ?SetLoseFocusOnAcceptInput@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetSelecting:
        public void SetSelecting(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0x00466910)(ref this, _b); // .text:004667E0 ; void __thiscall UIElement_Text::SetSelecting(UIElement_Text *this, bool _b) .text:004667E0 ?SetSelecting@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.SetFontDIDHelper:
        // public void SetFontDIDHelper(UInt32 _property, Font** _font, UInt32 _fontDIDNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Font**, UInt32, void>)0xDEADBEEF)(ref this, _property, _font, _fontDIDNum); // .text:00466960 ; void __thiscall UIElement_Text::SetFontDIDHelper(UIElement_Text *this, unsigned int _property, Font **_font, unsigned int _fontDIDNum) .text:00466960 ?SetFontDIDHelper@UIElement_Text@@IAEXKAAPAVFont@@K@Z

        // UIElement_Text.ResizeToPaper:
        // public void ResizeToPaper() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:00467550 ; void __thiscall UIElement_Text::ResizeToPaper(UIElement_Text *this) .text:00467550 ?ResizeToPaper@UIElement_Text@@IAEXXZ

        // UIElement_Text.DeleteChar:
        // public void DeleteChar() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:00469990 ; void __thiscall UIElement_Text::DeleteChar(UIElement_Text *this) .text:00469990 ?DeleteChar@UIElement_Text@@IAEXXZ

        // UIElement_Text.DeleteSelection:
        // public void DeleteSelection() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:004699B0 ; void __thiscall UIElement_Text::DeleteSelection(UIElement_Text *this) .text:004699B0 ?DeleteSelection@UIElement_Text@@IAEXXZ

        // UIElement_Text.SetText:
        public void SetText(PStringBase<UInt16>* _text) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, void>)0x0046A740)(ref this, _text); // .text:0046A4B0 ; void __thiscall UIElement_Text::SetText(UIElement_Text *this, PStringBase<unsigned short> *_text) .text:0046A4B0 ?SetText@UIElement_Text@@QAEXABV?$PStringBase@G@@@Z

        // UIElement_Text.GetSelection:
        // public Byte GetSelection(UInt32* o_nStart, UInt32* o_nEnd) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32*, UInt32*, Byte>)0xDEADBEEF)(ref this, o_nStart, o_nEnd); // .text:00466F20 ; bool __thiscall UIElement_Text::GetSelection(UIElement_Text *this, unsigned int *o_nStart, unsigned int *o_nEnd) .text:00466F20 ?GetSelection@UIElement_Text@@QBE_NAAK0@Z

        // UIElement_Text.GetShouldBeMouseVisible:
        // public Byte GetShouldBeMouseVisible() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0xDEADBEEF)(ref this); // .text:00467460 ; bool __thiscall UIElement_Text::GetShouldBeMouseVisible(UIElement_Text *this) .text:00467460 ?GetShouldBeMouseVisible@UIElement_Text@@MAE_NXZ

        // UIElement_Text.RecalculateTruncation:
        // public void RecalculateTruncation(int* io_iPaperWidth, int* io_iPaperHeight) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, int*, int*, void>)0xDEADBEEF)(ref this, io_iPaperWidth, io_iPaperHeight); // .text:00466F80 ; void __thiscall UIElement_Text::RecalculateTruncation(UIElement_Text *this, int *io_iPaperWidth, int *io_iPaperHeight) .text:00466F80 ?RecalculateTruncation@UIElement_Text@@QAEXAAJ0@Z

        // UIElement_Text.SetOneLine:
        // public void SetOneLine(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00468170 ; void __thiscall UIElement_Text::SetOneLine(UIElement_Text *this, bool _b) .text:00468170 ?SetOneLine@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:00468A90 ; void __cdecl UIElement_Text::Register() .text:00468A90 ?Register@UIElement_Text@@SAXXZ

        // UIElement_Text.MouseDown:
        public void MouseDown(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, UInt32, UInt32, void>)0x00469600)(ref this, _xWindow, _yWindow, _button); // .text:00469370 ; void __thiscall UIElement_Text::MouseDown(UIElement_Text *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:00469370 ?MouseDown@UIElement_Text@@MAEXKKK@Z

        // UIElement_Text.AppendStringInfo:
        // public void AppendStringInfo(StringInfo* _info) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, StringInfo*, void>)0xDEADBEEF)(ref this, _info); // .text:00469D10 ; void __thiscall UIElement_Text::AppendStringInfo(UIElement_Text *this, StringInfo *_info) .text:00469D10 ?AppendStringInfo@UIElement_Text@@QAEXABVStringInfo@@@Z

        // UIElement_Text.Global_Loop:
        // public void Global_Loop() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:00469FC0 ; void __thiscall UIElement_Text::Global_Loop(UIElement_Text *this) .text:00469FC0 ?Global_Loop@UIElement_Text@@IAEXXZ

        // UIElement_Text.GetText:
        public PStringBase<UInt16>* GetText(PStringBase<UInt16>* result) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, PStringBase<UInt16>*>)0x00466830)(ref this, result); // .text:00466700 ; PStringBase<unsigned short> *__thiscall UIElement_Text::GetText(UIElement_Text *this, PStringBase<unsigned short> *result) .text:00466700 ?GetText@UIElement_Text@@QBE?AV?$PStringBase@G@@XZ

        // UIElement_Text.SetSelectionEnd:
        // public Byte SetSelectionEnd(UInt32 i_nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte>)0xDEADBEEF)(ref this, i_nPos); // .text:00466EC0 ; bool __thiscall UIElement_Text::SetSelectionEnd(UIElement_Text *this, unsigned int i_nPos) .text:00466EC0 ?SetSelectionEnd@UIElement_Text@@QAE_NK@Z

        // UIElement_Text.SetTextWithFont:
        public void SetTextWithFont(PStringBase<UInt16>* _text, int _fontDIDNum, int _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, int, int, void>)0x0046A790)(ref this, _text, _fontDIDNum, _fontColorNum); // .text:0046A500 ; void __thiscall UIElement_Text::SetTextWithFont(UIElement_Text *this, PStringBase<unsigned short> *_text, int _fontDIDNum, int _fontColorNum) .text:0046A500 ?SetTextWithFont@UIElement_Text@@QAEXABV?$PStringBase@G@@JJ@Z

        // UIElement_Text.AdjustToScrollableXYChange:
        public void AdjustToScrollableXYChange() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0x004676D0)(ref this); // .text:00467440 ; void __thiscall UIElement_Text::AdjustToScrollableXYChange(UIElement_Text *this) .text:00467440 ?AdjustToScrollableXYChange@UIElement_Text@@UAEXXZ

        // UIElement_Text.SetLoseFocusOnEscape:
        // public void SetLoseFocusOnEscape(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:004674F0 ; void __thiscall UIElement_Text::SetLoseFocusOnEscape(UIElement_Text *this, bool _b) .text:004674F0 ?SetLoseFocusOnEscape@UIElement_Text@@IAEX_N@Z

        // UIElement_Text.Copy:
        // public void Copy() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:004688A0 ; void __thiscall UIElement_Text::Copy(UIElement_Text *this) .text:004688A0 ?Copy@UIElement_Text@@AAEXXZ

        // UIElement_Text.IsAtVerticalEnd:
        public Byte IsAtVerticalEnd() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0x004695E0)(ref this); // .text:00469350 ; bool __thiscall UIElement_Text::IsAtVerticalEnd(UIElement_Text *this) .text:00469350 ?IsAtVerticalEnd@UIElement_Text@@QAE_NXZ

        // UIElement_Text.DeleteSection:
        // public void DeleteSection(UInt32 i_nStart, UInt32 i_nEnd, Byte i_bKeepCurrentTextInView) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, UInt32, Byte, void>)0xDEADBEEF)(ref this, i_nStart, i_nEnd, i_bKeepCurrentTextInView); // .text:00469800 ; void __thiscall UIElement_Text::DeleteSection(UIElement_Text *this, unsigned int i_nStart, unsigned int i_nEnd, bool i_bKeepCurrentTextInView) .text:00469800 ?DeleteSection@UIElement_Text@@IAEXKK_N@Z

        // UIElement_Text.AppendText:
        // public void AppendText(PStringBase<UInt16>* _text) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, PStringBase<UInt16>*, void>)0xDEADBEEF)(ref this, _text); // .text:00469CE0 ; void __thiscall UIElement_Text::AppendText(UIElement_Text *this, PStringBase<unsigned short> *_text) .text:00469CE0 ?AppendText@UIElement_Text@@QAEXABV?$PStringBase@G@@@Z

        // UIElement_Text.SetVerticalJustification:
        // public Byte SetVerticalJustification(UInt32 i_eJustification) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, Byte>)0xDEADBEEF)(ref this, i_eJustification); // .text:00467230 ; bool __thiscall UIElement_Text::SetVerticalJustification(UIElement_Text *this, unsigned int i_eJustification) .text:00467230 ?SetVerticalJustification@UIElement_Text@@QAE?B_NK@Z

        // UIElement_Text.UnregisterInputMaps:
        public Byte UnregisterInputMaps() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0x00467660)(ref this); // .text:004673D0 ; bool __thiscall UIElement_Text::UnregisterInputMaps(UIElement_Text *this) .text:004673D0 ?UnregisterInputMaps@UIElement_Text@@UAE_NXZ

        // UIElement_Text.MoveCursorToEnd:
        public void MoveCursorToEnd() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0x00469100)(ref this); // .text:00468E70 ; void __thiscall UIElement_Text::MoveCursorToEnd(UIElement_Text *this) .text:00468E70 ?MoveCursorToEnd@UIElement_Text@@QAEXXZ

        // UIElement_Text.Cut:
        // public void Cut() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:00469B60 ; void __thiscall UIElement_Text::Cut(UIElement_Text *this) .text:00469B60 ?Cut@UIElement_Text@@AAEXXZ

        // UIElement_Text.CheckStringDownloads:
        // public void CheckStringDownloads() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:00469E70 ; void __thiscall UIElement_Text::CheckStringDownloads(UIElement_Text *this) .text:00469E70 ?CheckStringDownloads@UIElement_Text@@IAEXXZ

        // UIElement_Text.MatchElement:
        public void MatchElement(UIElement* _elem) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UIElement*, void>)0x0046A870)(ref this, _elem); // .text:0046A5E0 ; void __thiscall UIElement_Text::MatchElement(UIElement_Text *this, UIElement *_elem) .text:0046A5E0 ?MatchElement@UIElement_Text@@UAEXABVUIElement@@@Z

        // UIElement_Text.IMETurnOn:
        // public Byte IMETurnOn() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0xDEADBEEF)(ref this); // .text:00466660 ; bool __thiscall UIElement_Text::IMETurnOn(UIElement_Text *this) .text:00466660 ?IMETurnOn@UIElement_Text@@IAE_NXZ

        // UIElement_Text.MoveUpDown:
        // public Byte MoveUpDown(Byte i_bUp, UInt32 i_nStart, UInt32* o_nPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte, UInt32, UInt32*, Byte>)0xDEADBEEF)(ref this, i_bUp, i_nStart, o_nPos); // .text:004682E0 ; bool __thiscall UIElement_Text::MoveUpDown(UIElement_Text *this, bool i_bUp, unsigned int i_nStart, unsigned int *o_nPos) .text:004682E0 ?MoveUpDown@UIElement_Text@@IAE_N_NKAAK@Z

        // UIElement_Text.MouseUp:
        public void MouseUp(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, UInt32, UInt32, void>)0x00469780)(ref this, _xWindow, _yWindow, _button); // .text:004694F0 ; void __thiscall UIElement_Text::MouseUp(UIElement_Text *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:004694F0 ?MouseUp@UIElement_Text@@MAEXKKK@Z

        // UIElement_Text.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, InputEvent*, Byte>)0x0046A4F0)(ref this, i_evt); // .text:0046A260 ; bool __thiscall UIElement_Text::OnAction(UIElement_Text *this, InputEvent *i_evt) .text:0046A260 ?OnAction@UIElement_Text@@UAE_NABVInputEvent@@@Z

        // UIElement_Text.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, BaseProperty*, void>)0x0046A8D0)(ref this, _attribute); // .text:0046A640 ; void __thiscall UIElement_Text::OnSetAttribute(UIElement_Text *this, BaseProperty *_attribute) .text:0046A640 ?OnSetAttribute@UIElement_Text@@UAEXABVBaseProperty@@@Z

        // UIElement_Text.SelectAll:
        // public void SelectAll() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:004678D0 ; void __thiscall UIElement_Text::SelectAll(UIElement_Text *this) .text:004678D0 ?SelectAll@UIElement_Text@@QAEXXZ

        // UIElement_Text.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, LayoutDesc*, ElementDesc*, void>)0x00468800)(ref this, _layout, _full_desc); // .text:00468570 ; void __thiscall UIElement_Text::UIElement_Text(UIElement_Text *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:00468570 ??0UIElement_Text@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Text.SetFontColorNum:
        // public void SetFontColorNum(UInt32 _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, void>)0xDEADBEEF)(ref this, _fontColorNum); // .text:004682B0 ; void __thiscall UIElement_Text::SetFontColorNum(UIElement_Text *this, unsigned int _fontColorNum) .text:004682B0 ?SetFontColorNum@UIElement_Text@@QAEXK@Z

        // UIElement_Text.RecalculateGlyphList:
        // public Byte RecalculateGlyphList() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, Byte>)0xDEADBEEF)(ref this); // .text:00468420 ; bool __thiscall UIElement_Text::RecalculateGlyphList(UIElement_Text *this) .text:00468420 ?RecalculateGlyphList@UIElement_Text@@QAE_NXZ

        // UIElement_Text.AppendStringInfoWithFont:
        public void AppendStringInfoWithFont(StringInfo* _info, int _fontDIDNum, int _fontColorNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, StringInfo*, int, int, void>)0x0046A070)(ref this, _info, _fontDIDNum, _fontColorNum); // .text:00469DE0 ; void __thiscall UIElement_Text::AppendStringInfoWithFont(UIElement_Text *this, StringInfo *_info, int _fontDIDNum, int _fontColorNum) .text:00469DE0 ?AppendStringInfoWithFont@UIElement_Text@@QAEXABVStringInfo@@JJ@Z

        // UIElement_Text.DetermineMarginValues:
        // public void DetermineMarginValues() => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, void>)0xDEADBEEF)(ref this); // .text:004668A0 ; void __thiscall UIElement_Text::DetermineMarginValues(UIElement_Text *this) .text:004668A0 ?DetermineMarginValues@UIElement_Text@@AAEXXZ

        // UIElement_Text.SetFontDID:
        // public void SetFontDID(UInt32 _did) => ((delegate* unmanaged[Thiscall]<ref UIElement_Text, UInt32, void>)0xDEADBEEF)(ref this, _did); // .text:00466BF0 ; void __thiscall UIElement_Text::SetFontDID(UIElement_Text *this, IDClass<_tagDataID,32,0> _did) .text:00466BF0 ?SetFontDID@UIElement_Text@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z
    }
    public unsafe struct UIElement_Scrollbar {
        // Struct:
        public UIElement_Button a0;
        public UIElement* m_pWidget;
        public Double m_tAnimStartTime;
        public Double m_tAnimEndTime;
        public Single m_fAnimStartPos;
        public Single m_fAnimEndPos;
        public int m_nMouseWidgetXOffset;
        public int m_nMouseWidgetYOffset;
        public Double m_nNextPageTime;
        public tagPOINT m_ptDragStart;
        public Single m_fResetPosition;
        public Byte m_bWidgetDragActive;
        public tagRECT m_rectScrollingArea;
        public UInt32 m_eIncrementButtonID;
        public UInt32 m_eDecrementButtonID;
        public UInt32 m_bitField;
        public override string ToString() => $"a0(UIElement_Button):{a0}, m_pWidget:->(UIElement*)0x{(int)m_pWidget:X8}, m_tAnimStartTime:{m_tAnimStartTime:n5}, m_tAnimEndTime:{m_tAnimEndTime:n5}, m_fAnimStartPos:{m_fAnimStartPos:n5}, m_fAnimEndPos:{m_fAnimEndPos:n5}, m_nMouseWidgetXOffset(int):{m_nMouseWidgetXOffset}, m_nMouseWidgetYOffset(int):{m_nMouseWidgetYOffset}, m_nNextPageTime:{m_nNextPageTime:n5}, m_ptDragStart(tagPOINT):{m_ptDragStart}, m_fResetPosition:{m_fResetPosition:n5}, m_bWidgetDragActive:{m_bWidgetDragActive:X2}, m_rectScrollingArea(tagRECT):{m_rectScrollingArea}, m_eIncrementButtonID:{m_eIncrementButtonID:X8}, m_eDecrementButtonID:{m_eDecrementButtonID:X8}, m_bitField:{m_bitField:X8}";
        // Enums:
        public enum UIScrollBar_Flag : UInt32 {
            UISB_NONE = 0x0,
            UISB_HORIZONTAL = 0x1,
            UISB_PROPORTIONAL = 0x2,
            UISB_DISABLED = 0x4,
            UISB_HIDE_DISABLED = 0x8,
            UISB_SMOOTH_MOVEMENT = 0x10,
            UISB_DISALLOW_UPDATING = 0x20,
            UISB_MOVE_TO_TOUCHED = 0x40,
            UISB_BUTTONS_INTERACT = 0x80,
            UISB_HAS_STOP_LOCATIONS = 0x100,
            UISB_MOUSE_PRESSED = 0x8000,
            UISB_OVER_WIDGET = 0x10000,
            UISB_OVER_BAR_LEFT = 0x20000,
            UISB_OVER_BAR_RIGHT = 0x40000,
            UISB_OVER_BAR_TOP = 0x80000,
            UISB_OVER_BAR_BOTTOM = 0x100000,
            UISB_RCV_MOUSEMOVE = 0x200000,
            UISB_ANIMATING = 0x400000,
            UISB_NEED_TO_KIDNAP_BUTTONS = 0x800000,
            UISB_GHOST_WHEN_DISABLED = 0x1000000,
            UISB_FORCEDWORD = 0xFFFFFFFF,
        };

        // Functions:

        // UIElement_Scrollbar.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:0046FFF0 ; void __thiscall UIElement_Scrollbar::UIElement_Scrollbar(UIElement_Scrollbar *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046FFF0 ??0UIElement_Scrollbar@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Scrollbar.ComputeActiveSize:
        // public tagPOINT ComputeActiveSize() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, tagPOINT>)0xDEADBEEF)(ref this); // .text:004702A0 ; tagPOINT __thiscall UIElement_Scrollbar::ComputeActiveSize(UIElement_Scrollbar *this) .text:004702A0 ?ComputeActiveSize@UIElement_Scrollbar@@IAE?AUtagPOINT@@XZ

        // UIElement_Scrollbar.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:004700B0 ; UIElement *__cdecl UIElement_Scrollbar::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004700B0 ?Create@UIElement_Scrollbar@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Scrollbar.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:00470080 ; UIElement *__thiscall UIElement_Scrollbar::DynamicCast(UIElement_Scrollbar *this, unsigned int i_eType) .text:00470080 ?DynamicCast@UIElement_Scrollbar@@UAEPAVUIElement@@K@Z

        // UIElement_Scrollbar.GetButtonPointer_:
        // public UIElement_Button* GetButtonPointer_(Byte i_bIncrement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, UIElement_Button*>)0xDEADBEEF)(ref this, i_bIncrement); // .text:00470620 ; UIElement_Button *__thiscall UIElement_Scrollbar::GetButtonPointer_(UIElement_Scrollbar *this, bool i_bIncrement) .text:00470620 ?GetButtonPointer_@UIElement_Scrollbar@@IAEPAVUIElement_Button@@_N@Z

        // UIElement_Scrollbar.GetScrollbarPositionFromMessage:
        // public tagPOINT GetScrollbarPositionFromMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, tagPOINT>)0xDEADBEEF)(ref this, i_rMsg); // .text:00470260 ; tagPOINT __thiscall UIElement_Scrollbar::GetScrollbarPositionFromMessage(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg) .text:00470260 ?GetScrollbarPositionFromMessage@UIElement_Scrollbar@@IAE?AUtagPOINT@@ABUUIElementMessageInfo@@@Z

        // UIElement_Scrollbar.GetSecondaryCoordinate:
        // public int GetSecondaryCoordinate(tagPOINT* i_pt) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, tagPOINT*, int>)0xDEADBEEF)(ref this, i_pt); // .text:004704F0 ; int __thiscall UIElement_Scrollbar::GetSecondaryCoordinate(UIElement_Scrollbar *this, tagPOINT *i_pt) .text:004704F0 ?GetSecondaryCoordinate@UIElement_Scrollbar@@IAEJABUtagPOINT@@@Z

        // UIElement_Scrollbar.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UInt32>)0x00527480)(ref this); // .text:00526880 ; unsigned int __thiscall UIElement_Scrollbar::GetUIElementType(ImgTex *this) .text:00526880 ?GetUIElementType@UIElement_Scrollbar@@UBEKXZ

        // UIElement_Scrollbar.Global_Loop:
        // public void Global_Loop() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, void>)0xDEADBEEF)(ref this); // .text:00470CA0 ; void __thiscall UIElement_Scrollbar::Global_Loop(UIElement_Scrollbar *this) .text:00470CA0 ?Global_Loop@UIElement_Scrollbar@@IAEXXZ

        // UIElement_Scrollbar.HandleButtonClick:
        // public void HandleButtonClick(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, void>)0xDEADBEEF)(ref this, i_rMsg); // .text:00470E90 ; void __thiscall UIElement_Scrollbar::HandleButtonClick(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg) .text:00470E90 ?HandleButtonClick@UIElement_Scrollbar@@IAEXABUUIElementMessageInfo@@@Z

        // UIElement_Scrollbar.HandleMouseWheel:
        // public void HandleMouseWheel(UInt32 _buttonID) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UInt32, void>)0xDEADBEEF)(ref this, _buttonID); // .text:00471450 ; void __thiscall UIElement_Scrollbar::HandleMouseWheel(UIElement_Scrollbar *this, unsigned int _buttonID) .text:00471450 ?HandleMouseWheel@UIElement_Scrollbar@@QAEXK@Z

        // UIElement_Scrollbar.HandleMoveSteps:
        // public void HandleMoveSteps(UInt32 _attributeID, int _nSteps) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UInt32, int, void>)0xDEADBEEF)(ref this, _attributeID, _nSteps); // .text:00470E30 ; void __thiscall UIElement_Scrollbar::HandleMoveSteps(UIElement_Scrollbar *this, const unsigned int _attributeID, const int _nSteps) .text:00470E30 ?HandleMoveSteps@UIElement_Scrollbar@@IAEXKJ@Z

        // UIElement_Scrollbar.HandlePageClick:
        // public void HandlePageClick(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, void>)0xDEADBEEF)(ref this, i_rMsg); // .text:004706D0 ; void __thiscall UIElement_Scrollbar::HandlePageClick(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg) .text:004706D0 ?HandlePageClick@UIElement_Scrollbar@@IAEXABUUIElementMessageInfo@@@Z

        // UIElement_Scrollbar.Initialize:
        // public void Initialize() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, void>)0xDEADBEEF)(ref this); // .text:00470520 ; void __thiscall UIElement_Scrollbar::Initialize(UIElement_Scrollbar *this) .text:00470520 ?Initialize@UIElement_Scrollbar@@UAEXXZ

        // UIElement_Scrollbar.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:00470C50 ; bool __thiscall UIElement_Scrollbar::InqAvailableProperties(UIElement_Scrollbar *this, AvailablePropertySet *_set) .text:00470C50 ?InqAvailableProperties@UIElement_Scrollbar@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Scrollbar.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, UIElementMessageListenResult>)0x00471C30)(ref this, i_rMsg); // .text:00471870 ; UIElementMessageListenResult __thiscall UIElement_Scrollbar::ListenToElementMessage(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg) .text:00471870 ?ListenToElementMessage@UIElement_Scrollbar@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_Scrollbar.ListenToGlobalMessage:
        // public void ListenToGlobalMessage(UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UInt32, int, void>)0xDEADBEEF)(ref this, _messageID, _data_int); // .text:00470E00 ; void __thiscall UIElement_Scrollbar::ListenToGlobalMessage(UIElement_Scrollbar *this, unsigned int _messageID, int _data_int) .text:00470E00 ?ListenToGlobalMessage@UIElement_Scrollbar@@UAEXKJ@Z

        // UIElement_Scrollbar.OnSetAttribute:
        // public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, BaseProperty*, void>)0xDEADBEEF)(ref this, _attribute); // .text:004714D0 ; void __thiscall UIElement_Scrollbar::OnSetAttribute(UIElement_Scrollbar *this, BaseProperty *_attribute) .text:004714D0 ?OnSetAttribute@UIElement_Scrollbar@@UAEXABVBaseProperty@@@Z

        // UIElement_Scrollbar.PointToPosition:
        // public Single PointToPosition(tagPOINT* i_ptElement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, tagPOINT*, Single>)0xDEADBEEF)(ref this, i_ptElement); // .text:00470890 ; float __thiscall UIElement_Scrollbar::PointToPosition(UIElement_Scrollbar *this, tagPOINT *i_ptElement) .text:00470890 ?PointToPosition@UIElement_Scrollbar@@IAEMABUtagPOINT@@@Z

        // UIElement_Scrollbar.PositionToStop:
        // public int PositionToStop(Single i_fNewPosition) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Single, int>)0xDEADBEEF)(ref this, i_fNewPosition); // .text:004701C0 ; int __thiscall UIElement_Scrollbar::PositionToStop(UIElement_Scrollbar *this, float i_fNewPosition) .text:004701C0 ?PositionToStop@UIElement_Scrollbar@@IAEJM@Z

        // UIElement_Scrollbar.PositionToWidgetX0Y0:
        // public tagPOINT PositionToWidgetX0Y0(Single i_fPosition) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Single, tagPOINT>)0xDEADBEEF)(ref this, i_fPosition); // .text:004709A0 ; tagPOINT __thiscall UIElement_Scrollbar::PositionToWidgetX0Y0(UIElement_Scrollbar *this, float i_fPosition) .text:004709A0 ?PositionToWidgetX0Y0@UIElement_Scrollbar@@IAE?AUtagPOINT@@M@Z

        // UIElement_Scrollbar.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:00470510 ; void __cdecl UIElement_Scrollbar::Register() .text:00470510 ?Register@UIElement_Scrollbar@@SAXXZ

        // UIElement_Scrollbar.RegisterInputMaps:
        // public Byte RegisterInputMaps(int i_nPriority) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, int, Byte>)0xDEADBEEF)(ref this, i_nPriority); // .text:004700E0 ; bool __thiscall UIElement_Scrollbar::RegisterInputMaps(UIElement_Scrollbar *this, int i_nPriority) .text:004700E0 ?RegisterInputMaps@UIElement_Scrollbar@@UAE_NJ@Z

        // UIElement_Scrollbar.ResizeTo:
        // public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, int, int, void>)0xDEADBEEF)(ref this, _width, _height); // .text:00471430 ; void __thiscall UIElement_Scrollbar::ResizeTo(UIElement_Scrollbar *this, const int _width, const int _height) .text:00471430 ?ResizeTo@UIElement_Scrollbar@@UAEXJJ@Z

        // UIElement_Scrollbar.ScrollNPixelsFromReset:
        // public void ScrollNPixelsFromReset(tagPOINT* i_ptDelta, Byte i_bAllowSmoothScrolling) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, tagPOINT*, Byte, void>)0xDEADBEEF)(ref this, i_ptDelta, i_bAllowSmoothScrolling); // .text:00471020 ; void __thiscall UIElement_Scrollbar::ScrollNPixelsFromReset(UIElement_Scrollbar *this, tagPOINT *i_ptDelta, bool i_bAllowSmoothScrolling) .text:00471020 ?ScrollNPixelsFromReset@UIElement_Scrollbar@@IAEXABUtagPOINT@@_N@Z

        // UIElement_Scrollbar.ScrollToPoint:
        // public void ScrollToPoint(UIElementMessageInfo* i_rMsg, Byte i_bAllowSmoothMovement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, Byte, void>)0xDEADBEEF)(ref this, i_rMsg, i_bAllowSmoothMovement); // .text:00470F50 ; void __thiscall UIElement_Scrollbar::ScrollToPoint(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg, bool i_bAllowSmoothMovement) .text:00470F50 ?ScrollToPoint@UIElement_Scrollbar@@IAEXABUUIElementMessageInfo@@_N@Z

        // UIElement_Scrollbar.SetBitMask:
        // public void SetBitMask(Byte i_bVal, UInt32 i_nMask) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, UInt32, void>)0xDEADBEEF)(ref this, i_bVal, i_nMask); // .text:00470330 ; void __thiscall UIElement_Scrollbar::SetBitMask(UIElement_Scrollbar *this, const bool i_bVal, const unsigned int i_nMask) .text:00470330 ?SetBitMask@UIElement_Scrollbar@@IAEX_NK@Z

        // UIElement_Scrollbar.SetDisabled:
        // public void SetDisabled(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:004703D0 ; void __thiscall UIElement_Scrollbar::SetDisabled(UIElement_Scrollbar *this, const bool _b) .text:004703D0 ?SetDisabled@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetDisallowUpdating:
        // public void SetDisallowUpdating(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00470460 ; void __thiscall UIElement_Scrollbar::SetDisallowUpdating(UIElement_Scrollbar *this, const bool _b) .text:00470460 ?SetDisallowUpdating@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetHasStopLocations:
        // public void SetHasStopLocations(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:004704C0 ; void __thiscall UIElement_Scrollbar::SetHasStopLocations(UIElement_Scrollbar *this, const bool _b) .text:004704C0 ?SetHasStopLocations@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetHideDisabled:
        // public void SetHideDisabled(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00470400 ; void __thiscall UIElement_Scrollbar::SetHideDisabled(UIElement_Scrollbar *this, const bool _b) .text:00470400 ?SetHideDisabled@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetHorizontal:
        // public void SetHorizontal(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00470370 ; void __thiscall UIElement_Scrollbar::SetHorizontal(UIElement_Scrollbar *this, const bool _b) .text:00470370 ?SetHorizontal@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetMoveToTouched:
        // public void SetMoveToTouched(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00470490 ; void __thiscall UIElement_Scrollbar::SetMoveToTouched(UIElement_Scrollbar *this, const bool _b) .text:00470490 ?SetMoveToTouched@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetProportional:
        // public void SetProportional(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:004703A0 ; void __thiscall UIElement_Scrollbar::SetProportional(UIElement_Scrollbar *this, const bool _b) .text:004703A0 ?SetProportional@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetScrollbarPosition:
        // public void SetScrollbarPosition(Single i_fNewPosition, Byte i_bAllowSmoothMovement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Single, Byte, void>)0xDEADBEEF)(ref this, i_fNewPosition, i_bAllowSmoothMovement); // .text:00470EC0 ; void __thiscall UIElement_Scrollbar::SetScrollbarPosition(UIElement_Scrollbar *this, float i_fNewPosition, bool i_bAllowSmoothMovement) .text:00470EC0 ?SetScrollbarPosition@UIElement_Scrollbar@@IAEXM_N@Z

        // UIElement_Scrollbar.SetScrollbarStop:
        // public void SetScrollbarStop(int i_nNewStop, Byte i_bAllowSmoothMovement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, int, Byte, void>)0xDEADBEEF)(ref this, i_nNewStop, i_bAllowSmoothMovement); // .text:00470830 ; void __thiscall UIElement_Scrollbar::SetScrollbarStop(UIElement_Scrollbar *this, int i_nNewStop, bool i_bAllowSmoothMovement) .text:00470830 ?SetScrollbarStop@UIElement_Scrollbar@@IAEXJ_N@Z

        // UIElement_Scrollbar.SetSmoothMovement:
        // public void SetSmoothMovement(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, void>)0xDEADBEEF)(ref this, _b); // .text:00470430 ; void __thiscall UIElement_Scrollbar::SetSmoothMovement(UIElement_Scrollbar *this, const bool _b) .text:00470430 ?SetSmoothMovement@UIElement_Scrollbar@@IAEX_N@Z

        // UIElement_Scrollbar.SetupDefaultHotClick:
        // public void SetupDefaultHotClick(UIElement* pElement) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElement*, void>)0xDEADBEEF)(ref this, pElement); // .text:00470150 ; void __thiscall UIElement_Scrollbar::SetupDefaultHotClick(UIElement_Scrollbar *this, UIElement *pElement) .text:00470150 ?SetupDefaultHotClick@UIElement_Scrollbar@@IAEXPAVUIElement@@@Z

        // UIElement_Scrollbar.StartAnimation:
        // public void StartAnimation() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, void>)0xDEADBEEF)(ref this); // .text:00470550 ; void __thiscall UIElement_Scrollbar::StartAnimation(UIElement_Scrollbar *this) .text:00470550 ?StartAnimation@UIElement_Scrollbar@@QAEXXZ

        // UIElement_Scrollbar.StartWidgetDrag:
        // public void StartWidgetDrag(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, UIElementMessageInfo*, void>)0xDEADBEEF)(ref this, i_rMsg); // .text:00470FB0 ; void __thiscall UIElement_Scrollbar::StartWidgetDrag(UIElement_Scrollbar *this, UIElementMessageInfo *i_rMsg) .text:00470FB0 ?StartWidgetDrag@UIElement_Scrollbar@@IAEXABUUIElementMessageInfo@@@Z

        // UIElement_Scrollbar.StopToPosition:
        // public Single StopToPosition(int i_nNewStop) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, int, Single>)0xDEADBEEF)(ref this, i_nNewStop); // .text:00470780 ; float __thiscall UIElement_Scrollbar::StopToPosition(UIElement_Scrollbar *this, int i_nNewStop) .text:00470780 ?StopToPosition@UIElement_Scrollbar@@IAEMJ@Z

        // UIElement_Scrollbar.UnregisterInputMaps:
        // public Byte UnregisterInputMaps() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte>)0xDEADBEEF)(ref this); // .text:00470120 ; bool __thiscall UIElement_Scrollbar::UnregisterInputMaps(UIElement_Scrollbar *this) .text:00470120 ?UnregisterInputMaps@UIElement_Scrollbar@@UAE_NXZ

        // UIElement_Scrollbar.UpdateButtonID_:
        // public void UpdateButtonID_(Byte i_bIncrement, UInt32 i_eNewID) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Byte, UInt32, void>)0xDEADBEEF)(ref this, i_bIncrement, i_eNewID); // .text:00470680 ; void __thiscall UIElement_Scrollbar::UpdateButtonID_(UIElement_Scrollbar *this, bool i_bIncrement, unsigned int i_eNewID) .text:00470680 ?UpdateButtonID_@UIElement_Scrollbar@@IAEX_NK@Z

        // UIElement_Scrollbar.UpdateLayout:
        // public void UpdateLayout() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, void>)0xDEADBEEF)(ref this); // .text:004710D0 ; void __thiscall UIElement_Scrollbar::UpdateLayout(UIElement_Scrollbar *this) .text:004710D0 ?UpdateLayout@UIElement_Scrollbar@@QAEXXZ

        // UIElement_Scrollbar.UpdateScrollingArea:
        // public void UpdateScrollingArea() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, void>)0xDEADBEEF)(ref this); // .text:00470AA0 ; void __thiscall UIElement_Scrollbar::UpdateScrollingArea(UIElement_Scrollbar *this) .text:00470AA0 ?UpdateScrollingArea@UIElement_Scrollbar@@IAEXXZ

        // UIElement_Scrollbar.ValidatePosition:
        // public void ValidatePosition(Single* io_fPosition) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollbar, Single*, void>)0xDEADBEEF)(ref this, io_fPosition); // .text:00470B60 ; void __thiscall UIElement_Scrollbar::ValidatePosition(UIElement_Scrollbar *this, float *io_fPosition) .text:00470B60 ?ValidatePosition@UIElement_Scrollbar@@IAEXAAM@Z
    }

    public unsafe struct UIElement_Menu {
        // Struct:
        public UIElement_Button a0;
        public UIElement* m_popup;
        public UIElement_ListBox* m_listBox;
        public Byte m_open;
        public UInt32 m_uiListBoxXBorder;
        public UInt32 m_uiListBoxYBorder;
        public override string ToString() => $"a0(UIElement_Button):{a0}, m_popup:->(UIElement*)0x{(int)m_popup:X8}, m_listBox:->(UIElement_ListBox*)0x{(int)m_listBox:X8}, m_open:{m_open:X2}, m_uiListBoxXBorder:{m_uiListBoxXBorder:X8}, m_uiListBoxYBorder:{m_uiListBoxYBorder:X8}";

        // Functions:

        // UIElement_Menu.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, LayoutDesc*, ElementDesc*, void>)0x0046CD70)(ref this, _layout, _full_desc); // .text:0046C990 ; void __thiscall UIElement_Menu::UIElement_Menu(UIElement_Menu *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046C990 ??0UIElement_Menu@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Menu.AddTextItem:
        public UIElement_Text* AddTextItem(StringInfo* _text) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, StringInfo*, UIElement_Text*>)0x0046D800)(ref this, _text); // .text:0046D420 ; UIElement_Text *__thiscall UIElement_Menu::AddTextItem(UIElement_Menu *this, StringInfo *_text) .text:0046D420 ?AddTextItem@UIElement_Menu@@QAEPAVUIElement_Text@@ABVStringInfo@@@Z

        // UIElement_Menu.Close:
        public void Close() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046D100)(ref this); // .text:0046CD20 ; void __thiscall UIElement_Menu::Close(UIElement_Menu *this) .text:0046CD20 ?Close@UIElement_Menu@@IAEXXZ

        // UIElement_Menu.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x0046CDF0)(_layout, _full_desc); // .text:0046CA10 ; UIElement *__cdecl UIElement_Menu::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046CA10 ?Create@UIElement_Menu@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Menu.Deactivate:
        public Byte Deactivate() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, Byte>)0x0046D510)(ref this); // .text:0046D130 ; bool __thiscall UIElement_Menu::Deactivate(UIElement_Menu *this) .text:0046D130 ?Deactivate@UIElement_Menu@@UAE_NXZ

        // UIElement_Menu.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UInt32, UIElement*>)0x0046CDC0)(ref this, i_eType); // .text:0046C9E0 ; UIElement *__thiscall UIElement_Menu::DynamicCast(UIElement_Menu *this, unsigned int i_eType) .text:0046C9E0 ?DynamicCast@UIElement_Menu@@UAEPAVUIElement@@K@Z

        // UIElement_Menu.Flush:
        public void Flush() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046CE20)(ref this); // .text:0046CA40 ; void __thiscall UIElement_Menu::Flush(UIElement_Menu *this) .text:0046CA40 ?Flush@UIElement_Menu@@QAEXXZ

        // UIElement_Menu.GetItem:
        public UIElement* GetItem(int _index) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, int, UIElement*>)0x0046CE30)(ref this, _index); // .text:0046CA50 ; UIElement *__thiscall UIElement_Menu::GetItem(UIElement_Menu *this, int _index) .text:0046CA50 ?GetItem@UIElement_Menu@@QBEPAVUIElement@@J@Z

        // UIElement_Menu.GetNumItems:
        public int GetNumItems() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, int>)0x0046CFB0)(ref this); // .text:0046CBD0 ; int __thiscall UIElement_Menu::GetNumItems(UIElement_Menu *this) .text:0046CBD0 ?GetNumItems@UIElement_Menu@@QBEJXZ

        // UIElement_Menu.GetSelectedIndex:
        public int GetSelectedIndex() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, int>)0x0046CFD0)(ref this); // .text:0046CBF0 ; int __thiscall UIElement_Menu::GetSelectedIndex(UIElement_Menu *this) .text:0046CBF0 ?GetSelectedIndex@UIElement_Menu@@QBEJXZ

        // UIElement_Menu.GetSelectedItem:
        public UIElement* GetSelectedItem() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UIElement*>)0x0046CE50)(ref this); // .text:0046CA70 ; UIElement *__thiscall UIElement_Menu::GetSelectedItem(UIElement_Menu *this) .text:0046CA70 ?GetSelectedItem@UIElement_Menu@@QBEPAVUIElement@@XZ

        // UIElement_Menu.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UInt32>)0x00527440)(ref this); // .text:00526840 ; unsigned int __thiscall UIElement_Menu::GetUIElementType(CGfxObj *this) .text:00526840 ?GetUIElementType@UIElement_Menu@@UBEKXZ

        // UIElement_Menu.Initialize:
        public void Initialize() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046D820)(ref this); // .text:0046D440 ; void __thiscall UIElement_Menu::Initialize(UIElement_Menu *this) .text:0046D440 ?Initialize@UIElement_Menu@@UAEXXZ

        // UIElement_Menu.InqAvailableProperties:
        public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, AvailablePropertySet*, Byte>)0x0046D2A0)(ref this, _set); // .text:0046CEC0 ; bool __thiscall UIElement_Menu::InqAvailableProperties(UIElement_Menu *this, AvailablePropertySet *_set) .text:0046CEC0 ?InqAvailableProperties@UIElement_Menu@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Menu.InsertItem:
        public Byte InsertItem(UIElement* _insertThis, int _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UIElement*, int, Byte>)0x0046CE70)(ref this, _insertThis, _here); // .text:0046CA90 ; bool __thiscall UIElement_Menu::InsertItem(UIElement_Menu *this, UIElement *_insertThis, int _here) .text:0046CA90 ?InsertItem@UIElement_Menu@@IAE_NPAVUIElement@@J@Z

        // UIElement_Menu.InsertTextItem:
        public UIElement_Text* InsertTextItem(StringInfo* _text, int _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, StringInfo*, int, UIElement_Text*>)0x0046D2F0)(ref this, _text, _here); // .text:0046CF10 ; UIElement_Text *__thiscall UIElement_Menu::InsertTextItem(UIElement_Menu *this, StringInfo *_text, int _here) .text:0046CF10 ?InsertTextItem@UIElement_Menu@@QAEPAVUIElement_Text@@ABVStringInfo@@J@Z

        // UIElement_Menu.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UIElementMessageInfo*, UIElementMessageListenResult>)0x0046D560)(ref this, i_rMsg); // .text:0046D180 ; UIElementMessageListenResult __thiscall UIElement_Menu::ListenToElementMessage(UIElement_Menu *this, UIElementMessageInfo *i_rMsg) .text:0046D180 ?ListenToElementMessage@UIElement_Menu@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_Menu.MakePopup:
        public void MakePopup() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046D6F0)(ref this); // .text:0046D310 ; void __thiscall UIElement_Menu::MakePopup(UIElement_Menu *this) .text:0046D310 ?MakePopup@UIElement_Menu@@IAEXXZ

        // UIElement_Menu.NewSelection:
        public void NewSelection(Byte _broadcast) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, Byte, void>)0x0046D140)(ref this, _broadcast); // .text:0046CD60 ; void __thiscall UIElement_Menu::NewSelection(UIElement_Menu *this, bool _broadcast) .text:0046CD60 ?NewSelection@UIElement_Menu@@IAEX_N@Z

        // UIElement_Menu.Open:
        public void Open() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046D010)(ref this); // .text:0046CC30 ; void __thiscall UIElement_Menu::Open(UIElement_Menu *this) .text:0046CC30 ?Open@UIElement_Menu@@IAEXXZ

        // UIElement_Menu.RecalculatePopupSize:
        public void RecalculatePopupSize() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046CED0)(ref this); // .text:0046CAF0 ; void __thiscall UIElement_Menu::RecalculatePopupSize(UIElement_Menu *this) .text:0046CAF0 ?RecalculatePopupSize@UIElement_Menu@@IAEXXZ

        // UIElement_Menu.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x0046CFA0)(); // .text:0046CBC0 ; void __cdecl UIElement_Menu::Register() .text:0046CBC0 ?Register@UIElement_Menu@@SAXXZ

        // UIElement_Menu.ReplaceTextItem:
        public UIElement_Text* ReplaceTextItem(StringInfo* _text, int _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, StringInfo*, int, UIElement_Text*>)0x0046D420)(ref this, _text, _here); // .text:0046D040 ; UIElement_Text *__thiscall UIElement_Menu::ReplaceTextItem(UIElement_Menu *this, StringInfo *_text, int _here) .text:0046D040 ?ReplaceTextItem@UIElement_Menu@@QAEPAVUIElement_Text@@ABVStringInfo@@J@Z

        // UIElement_Menu.SetSelectedItem:
        public void SetSelectedItem(UIElement* _select, Byte _broadcast) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, UIElement*, Byte, void>)0x0046D4B0)(ref this, _select, _broadcast); // .text:0046D0D0 ; void __thiscall UIElement_Menu::SetSelectedItem(UIElement_Menu *this, UIElement *_select, bool _broadcast) .text:0046D0D0 ?SetSelectedItem@UIElement_Menu@@QAEXPAVUIElement@@_N@Z

        // UIElement_Menu.SetVisible:
        public void SetVisible(Byte _visible) => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, Byte, void>)0x0046D4E0)(ref this, _visible); // .text:0046D100 ; void __thiscall UIElement_Menu::SetVisible(UIElement_Menu *this, bool _visible) .text:0046D100 ?SetVisible@UIElement_Menu@@UAEX_N@Z

        // UIElement_Menu.UpdateState:
        public void UpdateState() => ((delegate* unmanaged[Thiscall]<ref UIElement_Menu, void>)0x0046CEB0)(ref this); // .text:0046CAD0 ; void __thiscall UIElement_Menu::UpdateState(UIElement_Menu *this) .text:0046CAD0 ?UpdateState@UIElement_Menu@@IAEXXZ
    }

    public unsafe struct UIElement_Button {
        // Struct:
        public UIElement_Text a0;
        public Byte mousePressedOnButton;
        public Byte hotClickingInProgress;
        public Double nextHotClickTime;
        public override string ToString() => $"a0(UIElement_Text):{a0}, mousePressedOnButton:{mousePressedOnButton:X2}, hotClickingInProgress:{hotClickingInProgress:X2}, nextHotClickTime:{nextHotClickTime:n5}";

        // Functions:

        // UIElement_Button.MouseDown:
        public void MouseDown(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UInt32, UInt32, UInt32, void>)0x004723B0)(ref this, _xWindow, _yWindow, _button); // .text:00471FF0 ; void __thiscall UIElement_Button::MouseDown(UIElement_Button *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:00471FF0 ?MouseDown@UIElement_Button@@UAEXKKK@Z

        // UIElement_Button.MouseUp:
        public void MouseUp(UInt32 _xElement, UInt32 _yElement, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UInt32, UInt32, UInt32, void>)0x004724A0)(ref this, _xElement, _yElement, _button); // .text:004720E0 ; void __thiscall UIElement_Button::MouseUp(UIElement_Button *this, unsigned int _xElement, unsigned int _yElement, unsigned int _button) .text:004720E0 ?MouseUp@UIElement_Button@@UAEXKKK@Z

        // UIElement_Button.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UIElementMessageInfo*, UIElementMessageListenResult>)0x004725D0)(ref this, i_rMsg); // .text:00472210 ; UIElementMessageListenResult __thiscall UIElement_Button::ListenToElementMessage(UIElement_Button *this, UIElementMessageInfo *i_rMsg) .text:00472210 ?ListenToElementMessage@UIElement_Button@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_Button.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UInt32, UIElement*>)0x00471F60)(ref this, i_eType); // .text:00471BA0 ; UIElement *__thiscall UIElement_Button::DynamicCast(UIElement_Button *this, unsigned int i_eType) .text:00471BA0 ?DynamicCast@UIElement_Button@@UAEPAVUIElement@@K@Z

        // UIElement_Button.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004722E0)(); // .text:00471F20 ; void __cdecl UIElement_Button::Register() .text:00471F20 ?Register@UIElement_Button@@SAXXZ

        // UIElement_Button.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UInt32, int, void>)0x00472020)(ref this, _messageID, _data_int); // .text:00471C60 ; void __thiscall UIElement_Button::ListenToGlobalMessage(UIElement_Button *this, unsigned int _messageID, int _data_int) .text:00471C60 ?ListenToGlobalMessage@UIElement_Button@@UAEXKJ@Z

        // UIElement_Button.UpdateState_:
        public void UpdateState_() => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, void>)0x004720B0)(ref this); // .text:00471CF0 ; void __thiscall UIElement_Button::UpdateState_(UIElement_Button *this) .text:00471CF0 ?UpdateState_@UIElement_Button@@IAEXXZ

        // UIElement_Button.HandleButtonClick:
        public Byte HandleButtonClick(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UIElementMessageInfo*, Byte>)0x00472210)(ref this, i_rMsg); // .text:00471E50 ; bool __thiscall UIElement_Button::HandleButtonClick(UIElement_Button *this, UIElementMessageInfo *i_rMsg) .text:00471E50 ?HandleButtonClick@UIElement_Button@@IAE?B_NABUUIElementMessageInfo@@@Z

        // UIElement_Button.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, void>)0x004722F0)(ref this); // .text:00471F30 ; void __thiscall UIElement_Button::PostInit(UIElement_Button *this) .text:00471F30 ?PostInit@UIElement_Button@@UAEXXZ

        // UIElement_Button.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, BaseProperty*, void>)0x00472300)(ref this, _attribute); // .text:00471F40 ; void __thiscall UIElement_Button::OnSetAttribute(UIElement_Button *this, BaseProperty *_attribute) .text:00471F40 ?OnSetAttribute@UIElement_Button@@UAEXABVBaseProperty@@@Z

        // UIElement_Button.MouseOverTop:
        public void MouseOverTop(Byte _overTop) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, Byte, void>)0x004725B0)(ref this, _overTop); // .text:004721F0 ; void __thiscall UIElement_Button::MouseOverTop(UIElement_Button *this, bool _overTop) .text:004721F0 ?MouseOverTop@UIElement_Button@@UAEX_N@Z

        // UIElement_Button.InqAvailableProperties:
        public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, AvailablePropertySet*, Byte>)0x00472620)(ref this, _set); // .text:00472260 ; bool __thiscall UIElement_Button::InqAvailableProperties(UIElement_Button *this, AvailablePropertySet *_set) .text:00472260 ?InqAvailableProperties@UIElement_Button@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Button.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, LayoutDesc*, ElementDesc*, void>)0x00471F10)(ref this, _layout, _full_desc); // .text:00471B50 ; void __thiscall UIElement_Button::UIElement_Button(UIElement_Button *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:00471B50 ??0UIElement_Button@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Button.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x00471FC0)(_layout, _full_desc); // .text:00471C00 ; UIElement *__cdecl UIElement_Button::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:00471C00 ?Create@UIElement_Button@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Button.SetState:
        public Byte SetState(UInt32 _state) => ((delegate* unmanaged[Thiscall]<ref UIElement_Button, UInt32, Byte>)0x00472160)(ref this, _state); // .text:00471DA0 ; bool __thiscall UIElement_Button::SetState(UIElement_Button *this, unsigned int _state) .text:00471DA0 ?SetState@UIElement_Button@@UAE_NK@Z
    }
    public unsafe struct UIElement_ItemList {
        // Struct:
        public UIElement_ListBox a0;
        public gmNoticeHandler a1;
        public UInt32 parentContainerID;
        public UInt32 openItemID;
        public UInt32 removedItemID;
        public UIElement_ItemList* childList;
        public UIElement_ItemList* parentList;
        public Byte containerList;
        public Byte vendorItemList;
        public Byte shortcutList;
        public Byte salvageList;
        public UIElement_UIItem* m_pendingItem;
        public int m_cellW;
        public int m_cellH;
        public _List<PTR<UIElement_UIItem>> m_listUIItemCache;
        public ItemListDragHandler* m_dragHandler;
        public Byte m_singleSelection;
        public Byte m_dragScrollItemScrolling;
        public Byte m_dragScrollSpellScrolling;
        public Byte m_dragScrollVertical;
        public Byte m_dragScrollHorizontal;
        public int m_dragScrollMarginWidth;
        public int m_dragScrollMarginHeight;
        public Byte m_inDragScrollRegion;
        public int m_dragScrollJumpDistance;
        public Single m_dragScrollDelay;
        public Double m_nextDragScrollTime;
        public override string ToString() => $"a0(UIElement_ListBox):{a0}, a1(gmNoticeHandler):{a1}, parentContainerID:{parentContainerID:X8}, openItemID:{openItemID:X8}, removedItemID:{removedItemID:X8}, childList:->(UIElement_ItemList*)0x{(int)childList:X8}, parentList:->(UIElement_ItemList*)0x{(int)parentList:X8}, containerList:{containerList:X2}, vendorItemList:{vendorItemList:X2}, shortcutList:{shortcutList:X2}, salvageList:{salvageList:X2}, m_pendingItem:->(UIElement_UIItem*)0x{(int)m_pendingItem:X8}, m_cellW(int):{m_cellW}, m_cellH(int):{m_cellH}, m_listUIItemCache(List<UIElement_UIItem*>):{m_listUIItemCache}, m_dragHandler:->(ItemListDragHandler*)0x{(int)m_dragHandler:X8}, m_singleSelection:{m_singleSelection:X2}, m_dragScrollItemScrolling:{m_dragScrollItemScrolling:X2}, m_dragScrollSpellScrolling:{m_dragScrollSpellScrolling:X2}, m_dragScrollVertical:{m_dragScrollVertical:X2}, m_dragScrollHorizontal:{m_dragScrollHorizontal:X2}, m_dragScrollMarginWidth(int):{m_dragScrollMarginWidth}, m_dragScrollMarginHeight(int):{m_dragScrollMarginHeight}, m_inDragScrollRegion:{m_inDragScrollRegion:X2}, m_dragScrollJumpDistance(int):{m_dragScrollJumpDistance}, m_dragScrollDelay:{m_dragScrollDelay:n5}, m_nextDragScrollTime:{m_nextDragScrollTime:n5}";

        // Functions:

        // UIElement_ItemList.RecvNotice_ServerSaysMoveItem:
        // public void RecvNotice_ServerSaysMoveItem(UInt32 i_itemID, UInt32 i_oldContainer, UInt32 i_oldWielder, UInt32 i_oldLocation, UInt32 i_newContainer, int i_place, UInt32 i_newWielder, UInt32 i_newLocation) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0xDEADBEEF)(ref this, i_itemID, i_oldContainer, i_oldWielder, i_oldLocation, i_newContainer, i_place, i_newWielder, i_newLocation); // .text:004E5110 ; void __thiscall UIElement_ItemList::RecvNotice_ServerSaysMoveItem(UIElement_ItemList *this, unsigned int i_itemID, unsigned int i_oldContainer, unsigned int i_oldWielder, unsigned int i_oldLocation, unsigned int i_newContainer, int i_place, unsigned int i_newWielder, unsigned int i_newLocation) .text:004E5110 ?RecvNotice_ServerSaysMoveItem@UIElement_ItemList@@MAEXKKKKKHKK@Z

        // UIElement_ItemList.ResizeTo:
        // public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, int, int, void>)0xDEADBEEF)(ref this, _width, _height); // .text:004E3D30 ; void __thiscall UIElement_ItemList::ResizeTo(UIElement_ItemList *this, const int _width, const int _height) .text:004E3D30 ?ResizeTo@UIElement_ItemList@@MAEXJJ@Z

        // UIElement_ItemList.AcceptDragObject:
        // public Byte AcceptDragObject(UInt32 i_itemID, Byte i_isContainer) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, Byte, Byte>)0xDEADBEEF)(ref this, i_itemID, i_isContainer); // .text:004E4250 ; bool __thiscall UIElement_ItemList::AcceptDragObject(UIElement_ItemList *this, unsigned int i_itemID, bool i_isContainer) .text:004E4250 ?AcceptDragObject@UIElement_ItemList@@IAE_NK_N@Z

        // UIElement_ItemList.RefreshList:
        // public void RefreshList() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E4C00 ; void __thiscall UIElement_ItemList::RefreshList(UIElement_ItemList *this) .text:004E4C00 ?RefreshList@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.ServerSaysMoveItem:
        // public void ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004E5000 ; void __thiscall UIElement_ItemList::ServerSaysMoveItem(UIElement_ItemList *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004E5000 ?ServerSaysMoveItem@UIElement_ItemList@@IAEXKKKKKHKK@Z

        // UIElement_ItemList.UpdateFixedSlots:
        // public void UpdateFixedSlots() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E3910 ; void __thiscall UIElement_ItemList::UpdateFixedSlots(UIElement_ItemList *this) .text:004E3910 ?UpdateFixedSlots@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:004E3BA0 ; UIElement *__thiscall UIElement_ItemList::DynamicCast(UIElement_ItemList *this, unsigned int i_eType) .text:004E3BA0 ?DynamicCast@UIElement_ItemList@@UAEPAVUIElement@@K@Z

        // UIElement_ItemList.ItemList_InsertSpellShortcut:
        public UIElement_UIItem* ItemList_InsertSpellShortcut(UInt32 _spellID, int _pos) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, UIElement_UIItem*>)0x004E4E40)(ref this, _spellID, _pos); // .text:004E41B0 ; UIElement_UIItem *__thiscall UIElement_ItemList::ItemList_InsertSpellShortcut(UIElement_ItemList *this, unsigned int _spellID, int _pos) .text:004E41B0 ?ItemList_InsertSpellShortcut@UIElement_ItemList@@QAEPAVUIElement_UIItem@@KH@Z

        // UIElement_ItemList.PostInit:
        // public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E4CA0 ; void __thiscall UIElement_ItemList::PostInit(UIElement_ItemList *this) .text:004E4CA0 ?PostInit@UIElement_ItemList@@MAEXXZ

        // UIElement_ItemList.IsAliasList:
        public Byte IsAliasList() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, Byte>)0x004E3130)(ref this); // .text:004E24A0 ; bool __thiscall UIElement_ItemList::IsAliasList(UIElement_ItemList *this) .text:004E24A0 ?IsAliasList@UIElement_ItemList@@IAE_NXZ

        // UIElement_ItemList.ItemList_SetChildList:
        public void ItemList_SetChildList(UIElement_ItemList* _childList) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_ItemList*, void>)0x004E31C0)(ref this, _childList); // .text:004E2530 ; void __thiscall UIElement_ItemList::ItemList_SetChildList(UIElement_ItemList *this, UIElement_ItemList *_childList) .text:004E2530 ?ItemList_SetChildList@UIElement_ItemList@@QAEXPAV1@@Z

        // UIElement_ItemList.SetAsPendingItem:
        public void SetAsPendingItem(UIElement_UIItem* _pendingItem) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*, void>)0x004E3240)(ref this, _pendingItem); // .text:004E25B0 ; void __thiscall UIElement_ItemList::SetAsPendingItem(UIElement_ItemList *this, UIElement_UIItem *_pendingItem) .text:004E25B0 ?SetAsPendingItem@UIElement_ItemList@@QAEXPAVUIElement_UIItem@@@Z

        // UIElement_ItemList.ItemList_IsInList:
        public int ItemList_IsInList(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int>)0x004E3B60)(ref this, _itemID); // .text:004E2ED0 ; int __thiscall UIElement_ItemList::ItemList_IsInList(UIElement_ItemList *this, unsigned int _itemID) .text:004E2ED0 ?ItemList_IsInList@UIElement_ItemList@@QAEHK@Z

        // UIElement_ItemList.GetNumUIItems:
        public int GetNumUIItems() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, int>)0x004E3C10)(ref this); // .text:004E2F80 ; int __thiscall UIElement_ItemList::GetNumUIItems(UIElement_ItemList *this) .text:004E2F80 ?GetNumUIItems@UIElement_ItemList@@QAEHXZ

        // UIElement_ItemList.ItemList_UpdateContainerListSize:
        // public void ItemList_UpdateContainerListSize() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E39E0 ; void __thiscall UIElement_ItemList::ItemList_UpdateContainerListSize(UIElement_ItemList *this) .text:004E39E0 ?ItemList_UpdateContainerListSize@UIElement_ItemList@@IAEXXZ

        // UIElement_ItemList.ItemList_AddItem:
        // public UIElement_UIItem* ItemList_AddItem(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UIElement_UIItem*>)0xDEADBEEF)(ref this, _itemID); // .text:004E3E00 ; UIElement_UIItem *__thiscall UIElement_ItemList::ItemList_AddItem(UIElement_ItemList *this, unsigned int _itemID) .text:004E3E00 ?ItemList_AddItem@UIElement_ItemList@@QAEPAVUIElement_UIItem@@K@Z

        // UIElement_ItemList.ItemList_AddSpellShortcut:
        // public UIElement_UIItem* ItemList_AddSpellShortcut(UInt32 _spellID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UIElement_UIItem*>)0xDEADBEEF)(ref this, _spellID); // .text:004E40A0 ; UIElement_UIItem *__thiscall UIElement_ItemList::ItemList_AddSpellShortcut(UIElement_ItemList *this, unsigned int _spellID) .text:004E40A0 ?ItemList_AddSpellShortcut@UIElement_ItemList@@QAEPAVUIElement_UIItem@@K@Z

        // UIElement_ItemList.WhatDragScrollRegion:
        public int WhatDragScrollRegion(int xPos, int yPos) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, int, int, int>)0x004E3280)(ref this, xPos, yPos); // .text:004E25F0 ; int __thiscall UIElement_ItemList::WhatDragScrollRegion(UIElement_ItemList *this, int xPos, int yPos) .text:004E25F0 ?WhatDragScrollRegion@UIElement_ItemList@@IAEHJJ@Z

        // UIElement_ItemList.InqDropIconInfo:
        public static void InqDropIconInfo(UIElement* _dropIcon, UInt32* _itemID, UInt32* _spellID, DropItemFlags* _flags) => ((delegate* unmanaged[Cdecl]<UIElement*, UInt32*, UInt32*, DropItemFlags*, void>)0x004E3380)(_dropIcon, _itemID, _spellID, _flags); // .text:004E26F0 ; void __cdecl UIElement_ItemList::InqDropIconInfo(UIElement *_dropIcon, unsigned int *_itemID, unsigned int *_spellID, DropItemFlags *_flags) .text:004E26F0 ?InqDropIconInfo@UIElement_ItemList@@SAXPBVUIElement@@AAK1AAW4DropItemFlags@@@Z

        // UIElement_ItemList.TrackDragScrolling:
        // public void TrackDragScrolling() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E30D0 ; void __thiscall UIElement_ItemList::TrackDragScrolling(UIElement_ItemList *this) .text:004E30D0 ?TrackDragScrolling@UIElement_ItemList@@IAEXXZ

        // UIElement_ItemList.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:004E31E0 ; bool __thiscall UIElement_ItemList::InqAvailableProperties(UIElement_ItemList *this, AvailablePropertySet *_set) .text:004E31E0 ?InqAvailableProperties@UIElement_ItemList@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_ItemList.ItemList_SetParentList:
        // public void ItemList_SetParentList(UIElement_ItemList* _newParent) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_ItemList*, void>)0xDEADBEEF)(ref this, _newParent); // .text:004E3650 ; void __thiscall UIElement_ItemList::ItemList_SetParentList(UIElement_ItemList *this, UIElement_ItemList *_newParent) .text:004E3650 ?ItemList_SetParentList@UIElement_ItemList@@QAEXPAV1@@Z

        // UIElement_ItemList.HandleSingleSelection:
        // public void HandleSingleSelection(UIElement_UIItem* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*, void>)0xDEADBEEF)(ref this, _item); // .text:004E3250 ; void __thiscall UIElement_ItemList::HandleSingleSelection(UIElement_ItemList *this, UIElement_UIItem *_item) .text:004E3250 ?HandleSingleSelection@UIElement_ItemList@@IAEXPAVUIElement_UIItem@@@Z

        // UIElement_ItemList.ItemList_SetParentContainer:
        // public void ItemList_SetParentContainer(UInt32 _parentContainerID, int _refresh, int _draw) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, int, void>)0xDEADBEEF)(ref this, _parentContainerID, _refresh, _draw); // .text:004E49D0 ; void __thiscall UIElement_ItemList::ItemList_SetParentContainer(UIElement_ItemList *this, unsigned int _parentContainerID, int _refresh, int _draw) .text:004E49D0 ?ItemList_SetParentContainer@UIElement_ItemList@@QAEXKHH@Z

        // UIElement_ItemList.RecvNotice_ServerSaysAttemptFailed:
        // public void RecvNotice_ServerSaysAttemptFailed(UInt32 i_itemID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, void>)0xDEADBEEF)(ref this, i_itemID); // .text:004E50F0 ; void __thiscall UIElement_ItemList::RecvNotice_ServerSaysAttemptFailed(UIElement_ItemList *this, unsigned int i_itemID) .text:004E50F0 ?RecvNotice_ServerSaysAttemptFailed@UIElement_ItemList@@MAEXK@Z

        // UIElement_ItemList.UnregisterItemListDragHandler:
        public void UnregisterItemListDragHandler() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0x004E3230)(ref this); // .text:004E25A0 ; void __thiscall UIElement_ItemList::UnregisterItemListDragHandler(UIElement_ItemList *this) .text:004E25A0 ?UnregisterItemListDragHandler@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.ItemList_SetSelectedItem:
        // public void ItemList_SetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _oldSelectedID, _selectedID); // .text:004E2FE0 ; void __thiscall UIElement_ItemList::ItemList_SetSelectedItem(UIElement_ItemList *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004E2FE0 ?ItemList_SetSelectedItem@UIElement_ItemList@@IAEXKK@Z

        // UIElement_ItemList.ItemList_InsertItem:
        public UIElement_UIItem* ItemList_InsertItem(UInt32 _itemID, int _pos) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, UIElement_UIItem*>)0x004E4BD0)(ref this, _itemID, _pos); // .text:004E3F40 ; UIElement_UIItem *__thiscall UIElement_ItemList::ItemList_InsertItem(UIElement_ItemList *this, unsigned int _itemID, int _pos) .text:004E3F40 ?ItemList_InsertItem@UIElement_ItemList@@QAEPAVUIElement_UIItem@@KH@Z

        // UIElement_ItemList.HandleTargetedUseLeftClick:
        public void HandleTargetedUseLeftClick(UIElement_UIItem* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*, void>)0x004E3160)(ref this, _item); // .text:004E24D0 ; void __thiscall UIElement_ItemList::HandleTargetedUseLeftClick(UIElement_ItemList *this, UIElement_UIItem *_item) .text:004E24D0 ?HandleTargetedUseLeftClick@UIElement_ItemList@@IAEXPAVUIElement_UIItem@@@Z

        // UIElement_ItemList.ListenToGlobalMessage:
        // public void ListenToGlobalMessage(UInt32 messageID, int data_int) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, void>)0xDEADBEEF)(ref this, messageID, data_int); // .text:004E3220 ; void __thiscall UIElement_ItemList::ListenToGlobalMessage(UIElement_ItemList *this, unsigned int messageID, int data_int) .text:004E3220 ?ListenToGlobalMessage@UIElement_ItemList@@MAEXKJ@Z

        // UIElement_ItemList.InternalCreateItem:
        // public UIElement_UIItem* InternalCreateItem() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*>)0xDEADBEEF)(ref this); // .text:004E3570 ; UIElement_UIItem *__thiscall UIElement_ItemList::InternalCreateItem(UIElement_ItemList *this) .text:004E3570 ?InternalCreateItem@UIElement_ItemList@@IAEPAVUIElement_UIItem@@XZ

        // UIElement_ItemList.UpdateOpenContainerIndicator:
        // public void UpdateOpenContainerIndicator(UInt32 _containerID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, void>)0xDEADBEEF)(ref this, _containerID); // .text:004E3070 ; void __thiscall UIElement_ItemList::UpdateOpenContainerIndicator(UIElement_ItemList *this, unsigned int _containerID) .text:004E3070 ?UpdateOpenContainerIndicator@UIElement_ItemList@@IAEXK@Z

        // UIElement_ItemList.ItemList_DragOver:
        // public void ItemList_DragOver(UIElement* _dragElement, UIElement_UIItem* _catchElement) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement*, UIElement_UIItem*, void>)0xDEADBEEF)(ref this, _dragElement, _catchElement); // .text:004E3400 ; void __thiscall UIElement_ItemList::ItemList_DragOver(UIElement_ItemList *this, UIElement *_dragElement, UIElement_UIItem *_catchElement) .text:004E3400 ?ItemList_DragOver@UIElement_ItemList@@QAEXPAVUIElement@@PAVUIElement_UIItem@@@Z

        // UIElement_ItemList.OnVisibilityChanged:
        // public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, Byte, void>)0xDEADBEEF)(ref this, i_bVisible); // .text:004E3D00 ; void __thiscall UIElement_ItemList::OnVisibilityChanged(UIElement_ItemList *this, bool i_bVisible) .text:004E3D00 ?OnVisibilityChanged@UIElement_ItemList@@MAEX_N@Z

        // UIElement_ItemList.ServerSaysAttemptFailed:
        // public void ServerSaysAttemptFailed(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, void>)0xDEADBEEF)(ref this, _itemID); // .text:004E4C20 ; void __thiscall UIElement_ItemList::ServerSaysAttemptFailed(UIElement_ItemList *this, unsigned int _itemID) .text:004E4C20 ?ServerSaysAttemptFailed@UIElement_ItemList@@IAEXK@Z

        // UIElement_ItemList.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:004E4D50 ; UIElementMessageListenResult __thiscall UIElement_ItemList::ListenToElementMessage(UIElement_ItemList *this, UIElementMessageInfo *i_rMsg) .text:004E4D50 ?ListenToElementMessage@UIElement_ItemList@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_ItemList.RegisterItemListDragHandler:
        public void RegisterItemListDragHandler(ItemListDragHandler* _handler) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, ItemListDragHandler*, void>)0x004E3220)(ref this, _handler); // .text:004E2590 ; void __thiscall UIElement_ItemList::RegisterItemListDragHandler(UIElement_ItemList *this, ItemListDragHandler *_handler) .text:004E2590 ?RegisterItemListDragHandler@UIElement_ItemList@@QAEXPAVItemListDragHandler@@@Z

        // UIElement_ItemList.RecvNotice_SetSelectedItem:
        // public void RecvNotice_SetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _oldSelectedID, _selectedID); // .text:004E3560 ; void __thiscall UIElement_ItemList::RecvNotice_SetSelectedItem(UIElement_ItemList *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004E3560 ?RecvNotice_SetSelectedItem@UIElement_ItemList@@MAEXKK@Z

        // UIElement_ItemList.ItemList_AddEmptySlot:
        // public void ItemList_AddEmptySlot(int _pos) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, int, void>)0xDEADBEEF)(ref this, _pos); // .text:004E36B0 ; void __thiscall UIElement_ItemList::ItemList_AddEmptySlot(UIElement_ItemList *this, int _pos) .text:004E36B0 ?ItemList_AddEmptySlot@UIElement_ItemList@@IAEXH@Z

        // UIElement_ItemList.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32>)0xDEADBEEF)(ref this); // .text:004E3BD0 ; unsigned int __thiscall UIElement_ItemList::GetUIElementType(UIElement_ItemList *this) .text:004E3BD0 ?GetUIElementType@UIElement_ItemList@@UBEKXZ

        // UIElement_ItemList.RecvNotice_ItemAttributesChanged:
        // public void RecvNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, void>)0xDEADBEEF)(ref this, i_target, i_attrib); // .text:004E5100 ; void __thiscall UIElement_ItemList::RecvNotice_ItemAttributesChanged(UIElement_ItemList *this, unsigned int i_target, unsigned int i_attrib) .text:004E5100 ?RecvNotice_ItemAttributesChanged@UIElement_ItemList@@MAEXKK@Z

        // UIElement_ItemList.DeletePendingItem:
        public void DeletePendingItem() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0x004E3250)(ref this); // .text:004E25C0 ; void __thiscall UIElement_ItemList::DeletePendingItem(UIElement_ItemList *this) .text:004E25C0 ?DeletePendingItem@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.ItemList_GetItem:
        public UIElement_UIItem* ItemList_GetItem(UInt32 i_iidItem) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UIElement_UIItem*>)0x004E3BC0)(ref this, i_iidItem); // .text:004E2F30 ; UIElement_UIItem *__thiscall UIElement_ItemList::ItemList_GetItem(UIElement_ItemList *this, unsigned int i_iidItem) .text:004E2F30 ?ItemList_GetItem@UIElement_ItemList@@QAEPAVUIElement_UIItem@@K@Z

        // UIElement_ItemList.UpdateEmptySlots:
        // public void UpdateEmptySlots() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E3700 ; void __thiscall UIElement_ItemList::UpdateEmptySlots(UIElement_ItemList *this) .text:004E3700 ?UpdateEmptySlots@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:004E3AA0 ; void __thiscall UIElement_ItemList::UIElement_ItemList(UIElement_ItemList *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004E3AA0 ??0UIElement_ItemList@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_ItemList.ItemList_DeleteItem:
        public void ItemList_DeleteItem(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, void>)0x004E4C70)(ref this, _itemID); // .text:004E3FE0 ; void __thiscall UIElement_ItemList::ItemList_DeleteItem(UIElement_ItemList *this, unsigned int _itemID) .text:004E3FE0 ?ItemList_DeleteItem@UIElement_ItemList@@QAEXK@Z

        // UIElement_ItemList.PrepareDragIcon:
        // public Byte PrepareDragIcon(UIElement_UIItem* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*, Byte>)0xDEADBEEF)(ref this, _item); // .text:004E2A50 ; bool __thiscall UIElement_ItemList::PrepareDragIcon(UIElement_ItemList *this, UIElement_UIItem *_item) .text:004E2A50 ?PrepareDragIcon@UIElement_ItemList@@IAE_NPAVUIElement_UIItem@@@Z

        // UIElement_ItemList.HandleDropRelease:
        // public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElementMessageInfo*, void>)0xDEADBEEF)(ref this, i_rMsg); // .text:004E4790 ; void __thiscall UIElement_ItemList::HandleDropRelease(UIElement_ItemList *this, UIElementMessageInfo *i_rMsg) .text:004E4790 ?HandleDropRelease@UIElement_ItemList@@IAEXABUUIElementMessageInfo@@@Z

        // UIElement_ItemList.ItemAttributesChanged:
        // public void ItemAttributesChanged(UInt32 _itemID, int _flags) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, void>)0xDEADBEEF)(ref this, _itemID, _flags); // .text:004E4F90 ; void __thiscall UIElement_ItemList::ItemAttributesChanged(UIElement_ItemList *this, unsigned int _itemID, int _flags) .text:004E4F90 ?ItemAttributesChanged@UIElement_ItemList@@IAEXKH@Z

        // UIElement_ItemList.ItemList_OpenFirstContainer:
        // public void ItemList_OpenFirstContainer() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E4B60 ; void __thiscall UIElement_ItemList::ItemList_OpenFirstContainer(UIElement_ItemList *this) .text:004E4B60 ?ItemList_OpenFirstContainer@UIElement_ItemList@@QAEXXZ

        // UIElement_ItemList.InternalDeleteItem:
        // public Byte InternalDeleteItem(UIElement_UIItem* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UIElement_UIItem*, Byte>)0xDEADBEEF)(ref this, _item); // .text:004E3530 ; bool __thiscall UIElement_ItemList::InternalDeleteItem(UIElement_ItemList *this, UIElement_UIItem *_item) .text:004E3530 ?InternalDeleteItem@UIElement_ItemList@@IAE_NPAVUIElement_UIItem@@@Z

        // UIElement_ItemList.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:004E3CD0 ; UIElement *__cdecl UIElement_ItemList::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004E3CD0 ?Create@UIElement_ItemList@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_ItemList.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004E5400)(); // .text:004E4770 ; void __cdecl UIElement_ItemList::Register() .text:004E4770 ?Register@UIElement_ItemList@@SAXXZ

        // UIElement_ItemList.InitItemList:
        // public void InitItemList() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0xDEADBEEF)(ref this); // .text:004E4830 ; void __thiscall UIElement_ItemList::InitItemList(UIElement_ItemList *this) .text:004E4830 ?InitItemList@UIElement_ItemList@@IAEXXZ

        // UIElement_ItemList.ItemList_OpenContainer:
        // public int ItemList_OpenContainer(UInt32 _containerID, int _checkIfInList) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, int, int>)0xDEADBEEF)(ref this, _containerID, _checkIfInList); // .text:004E4AE0 ; int __thiscall UIElement_ItemList::ItemList_OpenContainer(UIElement_ItemList *this, unsigned int _containerID, int _checkIfInList) .text:004E4AE0 ?ItemList_OpenContainer@UIElement_ItemList@@QAEHKH@Z

        // UIElement_ItemList.RecvNotice_BeginDrag:
        public void RecvNotice_BeginDrag(UInt32 i_itemID, UInt32 i_spellID, Byte i_bIsAlias) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, UInt32, UInt32, Byte, void>)0x004E31D0)(ref this, i_itemID, i_spellID, i_bIsAlias); // .text:004E2540 ; void __thiscall UIElement_ItemList::RecvNotice_BeginDrag(UIElement_ItemList *this, unsigned int i_itemID, unsigned int i_spellID, bool i_bIsAlias) .text:004E2540 ?RecvNotice_BeginDrag@UIElement_ItemList@@MAEXKK_N@Z

        // UIElement_ItemList.ItemList_BeginDrag:
        // public void ItemList_BeginDrag(int x, int y) => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, int, int, void>)0xDEADBEEF)(ref this, x, y); // .text:004E32D0 ; void __thiscall UIElement_ItemList::ItemList_BeginDrag(UIElement_ItemList *this, int x, int y) .text:004E32D0 ?ItemList_BeginDrag@UIElement_ItemList@@QAEXHH@Z

        // UIElement_ItemList.ItemList_Flush:
        public void ItemList_Flush() => ((delegate* unmanaged[Thiscall]<ref UIElement_ItemList, void>)0x004E49F0)(ref this); // .text:004E3D60 ; void __thiscall UIElement_ItemList::ItemList_Flush(UIElement_ItemList *this) .text:004E3D60 ?ItemList_Flush@UIElement_ItemList@@QAEXXZ
    }
    public unsafe struct UIElement_ListBox {
        // Struct:
        public UIElement_Scrollable a0;
        public SmartArray<PTR<UIElement>> m_listItems;
        public UIElement* m_pSelectedItem;
        public UIElement* m_dragLastOver;
        public UInt32 m_lastDragOverState;
        public int m_nCols;
        public int m_nRows;
        public SmartArray<UInt32> m_nItemHeights;
        public SmartArray<UInt32> m_nItemWidths;
        public Double m_nAnimStartTime;
        public Double m_nAnimEndTime;
        public int m_nAnimStartX;
        public int m_nAnimStartY;
        public int m_nAnimEndX;
        public int m_nAnimEndY;
        public UInt32 m_bitField;
        public override string ToString() => $"a0(UIElement_Scrollable):{a0}, m_listItems(SmartArray<UIElement*,1>):{m_listItems}, m_pSelectedItem:->(UIElement*)0x{(int)m_pSelectedItem:X8}, m_dragLastOver:->(UIElement*)0x{(int)m_dragLastOver:X8}, m_lastDragOverState:{m_lastDragOverState:X8}, m_nCols(int):{m_nCols}, m_nRows(int):{m_nRows}, m_nItemHeights(SmartArray<UInt32,1>):{m_nItemHeights}, m_nItemWidths(SmartArray<UInt32,1>):{m_nItemWidths}, m_nAnimStartTime:{m_nAnimStartTime:n5}, m_nAnimEndTime:{m_nAnimEndTime:n5}, m_nAnimStartX(int):{m_nAnimStartX}, m_nAnimStartY(int):{m_nAnimStartY}, m_nAnimEndX(int):{m_nAnimEndX}, m_nAnimEndY(int):{m_nAnimEndY}, m_bitField:{m_bitField:X8}";
        // Enums:
        public enum UIListBox_Flag : UInt32 {
            UILB_NONE = 0x0,
            UILB_HORIZONTAL = 0x1,
            UILB_CLICK_SELECT = 0x2,
            UILB_DRAG_SELECT = 0x4,
            UILB_DRAG_ROLLOVER = 0x8,
            UILB_ALLOW_UPDATING = 0x10,
            UILB_SELECTED_ITEM_STATE_CHANGE = 0x20,
            UILB_DRAG_SELECTING = 0x40,
            UILB_SET_VIEW_STOP = 0x80,
            UILB_ROLLING_OVER = 0x100,
            UILB_DIRTY = 0x200,
        };

        // Functions:

        // UIElement_ListBox.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:0046DE50 ; UIElement *__cdecl UIElement_ListBox::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046DE50 ?Create@UIElement_ListBox@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_ListBox.GetItemUnderMouse:
        public UIElement* GetItemUnderMouse() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*>)0x0046E5E0)(ref this); // .text:0046E220 ; UIElement *__thiscall UIElement_ListBox::GetItemUnderMouse(UIElement_ListBox *this) .text:0046E220 ?GetItemUnderMouse@UIElement_ListBox@@QAEPAVUIElement@@XZ

        // UIElement_ListBox.MouseMove:
        // public void MouseMove(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int, void>)0xDEADBEEF)(ref this, i_xWindow, i_yWindow); // .text:0046E410 ; void __thiscall UIElement_ListBox::MouseMove(UIElement_ListBox *this, int i_xWindow, int i_yWindow) .text:0046E410 ?MouseMove@UIElement_ListBox@@MAEXJJ@Z

        // UIElement_ListBox.ScrollToShow:
        // public void ScrollToShow(int i_iItemNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, void>)0xDEADBEEF)(ref this, i_iItemNum); // .text:0046E940 ; void __thiscall UIElement_ListBox::ScrollToShow(UIElement_ListBox *this, int i_iItemNum) .text:0046E940 ?ScrollToShow@UIElement_ListBox@@QAEXJ@Z

        // UIElement_ListBox.AddItemFromTemplateList:
        public UIElement* AddItemFromTemplateList(UInt32 i_itemIndex, int _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, int, UIElement*>)0x0046F770)(ref this, i_itemIndex, _here); // .text:0046F3B0 ; UIElement *__thiscall UIElement_ListBox::AddItemFromTemplateList(UIElement_ListBox *this, unsigned int i_itemIndex, int _here) .text:0046F3B0 ?AddItemFromTemplateList@UIElement_ListBox@@QAEPAVUIElement@@KJ@Z

        // UIElement_ListBox.ResizeTo:
        // public void ResizeTo(int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int, void>)0xDEADBEEF)(ref this, _width, _height); // .text:0046D7B0 ; void __thiscall UIElement_ListBox::ResizeTo(UIElement_ListBox *this, const int _width, const int _height) .text:0046D7B0 ?ResizeTo@UIElement_ListBox@@UAEXJJ@Z

        // UIElement_ListBox.InqScrollDelta:
        // public int InqScrollDelta(Byte i_bHorizontal, Byte i_bIncrement, Byte i_bPage) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, Byte, Byte, int>)0xDEADBEEF)(ref this, i_bHorizontal, i_bIncrement, i_bPage); // .text:0046DC10 ; int __thiscall UIElement_ListBox::InqScrollDelta(UIElement_ListBox *this, bool i_bHorizontal, bool i_bIncrement, bool i_bPage) .text:0046DC10 ?InqScrollDelta@UIElement_ListBox@@UAEJ_N00@Z

        // UIElement_ListBox.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:0046DCB0 ; void __thiscall UIElement_ListBox::UIElement_ListBox(UIElement_ListBox *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046DCB0 ??0UIElement_ListBox@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_ListBox.DeleteItem:
        public Byte DeleteItem(int _itemIndex) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, Byte>)0x0046E430)(ref this, _itemIndex); // .text:0046E070 ; bool __thiscall UIElement_ListBox::DeleteItem(UIElement_ListBox *this, int _itemIndex) .text:0046E070 ?DeleteItem@UIElement_ListBox@@QAE_NJ@Z

        // UIElement_ListBox.StartLeftActive:
        // public Byte StartLeftActive() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte>)0xDEADBEEF)(ref this); // .text:0046EE90 ; bool __thiscall UIElement_ListBox::StartLeftActive(UIElement_ListBox *this) .text:0046EE90 ?StartLeftActive@UIElement_ListBox@@UAE_NXZ

        // UIElement_ListBox.SetSelectedItem:
        public void SetSelectedItem(UIElement* _pNewSelected, Byte _bBroadcast) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, Byte, void>)0x0046DC70)(ref this, _pNewSelected, _bBroadcast); // .text:0046D8B0 ; void __thiscall UIElement_ListBox::SetSelectedItem(UIElement_ListBox *this, UIElement *_pNewSelected, bool _bBroadcast) .text:0046D8B0 ?SetSelectedItem@UIElement_ListBox@@QAEXPAVUIElement@@_N@Z

        // UIElement_ListBox.GetItem:
        public UIElement* GetItem(UInt32 _index) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UIElement*>)0x0046DC50)(ref this, _index); // .text:0046D890 ; UIElement *__thiscall UIElement_ListBox::GetItem(UIElement_ListBox *this, unsigned int _index) .text:0046D890 ?GetItem@UIElement_ListBox@@QAEPAVUIElement@@K@Z

        // UIElement_ListBox.UpdateLayout:
        // public void UpdateLayout() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046E460 ; void __thiscall UIElement_ListBox::UpdateLayout(UIElement_ListBox *this) .text:0046E460 ?UpdateLayout@UIElement_ListBox@@UAEXXZ

        // UIElement_ListBox.SetSelectedIndex:
        // public void SetSelectedIndex(UInt32 _selectedIndex, Byte _bBroadcast) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, Byte, void>)0xDEADBEEF)(ref this, _selectedIndex, _bBroadcast); // .text:0046EBA0 ; void __thiscall UIElement_ListBox::SetSelectedIndex(UIElement_ListBox *this, unsigned int _selectedIndex, bool _bBroadcast) .text:0046EBA0 ?SetSelectedIndex@UIElement_ListBox@@QAEXK_N@Z

        // UIElement_ListBox.ScrollToY:
        public void ScrollToY(int i_iY) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, void>)0x0046D930)(ref this, i_iY); // .text:0046D550 ; void __thiscall UIElement_ListBox::ScrollToY(UIElement_ListBox *this, int i_iY) .text:0046D550 ?ScrollToY@UIElement_ListBox@@QAEXJ@Z

        // UIElement_ListBox.StartActive:
        // public Byte StartActive(int* _nDelta) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int*, Byte>)0xDEADBEEF)(ref this, _nDelta); // .text:0046EC50 ; bool __thiscall UIElement_ListBox::StartActive(UIElement_ListBox *this, const int *_nDelta) .text:0046EC50 ?StartActive@UIElement_ListBox@@IAE?B_NABJ@Z

        // UIElement_ListBox.MouseDown:
        // public void MouseDown(UInt32 _x, UInt32 _y, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _x, _y, _button); // .text:0046E3A0 ; void __thiscall UIElement_ListBox::MouseDown(UIElement_ListBox *this, unsigned int _x, unsigned int _y, unsigned int _button) .text:0046E3A0 ?MouseDown@UIElement_ListBox@@MAEXKKK@Z

        // UIElement_ListBox.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:0046DE80 ; bool __thiscall UIElement_ListBox::InqAvailableProperties(UIElement_ListBox *this, AvailablePropertySet *_set) .text:0046DE80 ?InqAvailableProperties@UIElement_ListBox@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_ListBox.RemoveItem:
        public UIElement* RemoveItem(UIElement* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, UIElement*>)0x0046E3A0)(ref this, _item); // .text:0046DFE0 ; UIElement *__thiscall UIElement_ListBox::RemoveItem(UIElement_ListBox *this, UIElement *_item) .text:0046DFE0 ?RemoveItem@UIElement_ListBox@@QAEPAVUIElement@@PAV2@@Z

        // UIElement_ListBox.Flush:
        public void Flush() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0x0046E460)(ref this); // .text:0046E0A0 ; void __thiscall UIElement_ListBox::Flush(UIElement_ListBox *this) .text:0046E0A0 ?Flush@UIElement_ListBox@@QAEXXZ

        // UIElement_ListBox.SetSelectedItemByID:
        // public void SetSelectedItemByID(UInt32 _itemID, Byte _bBroadcast) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, Byte, void>)0xDEADBEEF)(ref this, _itemID, _bBroadcast); // .text:0046ECE0 ; void __thiscall UIElement_ListBox::SetSelectedItemByID(UIElement_ListBox *this, unsigned int _itemID, bool _bBroadcast) .text:0046ECE0 ?SetSelectedItemByID@UIElement_ListBox@@QAEXK_N@Z

        // UIElement_ListBox.StartUpActive:
        // public Byte StartUpActive() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte>)0xDEADBEEF)(ref this); // .text:0046EE20 ; bool __thiscall UIElement_ListBox::StartUpActive(UIElement_ListBox *this) .text:0046EE20 ?StartUpActive@UIElement_ListBox@@UAE_NXZ

        // UIElement_ListBox.StartRightActive:
        // public Byte StartRightActive() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte>)0xDEADBEEF)(ref this); // .text:0046EED0 ; bool __thiscall UIElement_ListBox::StartRightActive(UIElement_ListBox *this) .text:0046EED0 ?StartRightActive@UIElement_ListBox@@UAE_NXZ

        // UIElement_ListBox.StartDragSelect:
        // public void StartDragSelect() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046DB50 ; void __thiscall UIElement_ListBox::StartDragSelect(UIElement_ListBox *this) .text:0046DB50 ?StartDragSelect@UIElement_ListBox@@QAEXXZ

        // UIElement_ListBox.InitializeWidthHeightArray:
        // public void InitializeWidthHeightArray(Byte i_bWidth) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0xDEADBEEF)(ref this, i_bWidth); // .text:0046E190 ; void __thiscall UIElement_ListBox::InitializeWidthHeightArray(UIElement_ListBox *this, bool i_bWidth) .text:0046E190 ?InitializeWidthHeightArray@UIElement_ListBox@@IAEX_N@Z

        // UIElement_ListBox.ScrollToHome:
        // public void ScrollToHome() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0048B120 ; void __thiscall UIElement_ListBox::ScrollToHome(UIElement_ListBox *this) .text:0048B120 ?ScrollToHome@UIElement_ListBox@@QAEXXZ

        // UIElement_ListBox.SetDragSelect:
        public void SetDragSelect(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0x0046D9D0)(ref this, _b); // .text:0046D610 ; void __thiscall UIElement_ListBox::SetDragSelect(UIElement_ListBox *this, const bool _b) .text:0046D610 ?SetDragSelect@UIElement_ListBox@@IAEX_N@Z

        // UIElement_ListBox.CalculatePaperSize:
        // public int CalculatePaperSize(Byte i_bWidth, int i_iMax) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, int, int>)0xDEADBEEF)(ref this, i_bWidth, i_iMax); // .text:0046D830 ; int __thiscall UIElement_ListBox::CalculatePaperSize(UIElement_ListBox *this, bool i_bWidth, int i_iMax) .text:0046D830 ?CalculatePaperSize@UIElement_ListBox@@IAEJ_NJ@Z

        // UIElement_ListBox.AddItem:
        // public Byte AddItem(UIElement* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, Byte>)0xDEADBEEF)(ref this, _item); // .text:0046ED70 ; bool __thiscall UIElement_ListBox::AddItem(UIElement_ListBox *this, UIElement *_item) .text:0046ED70 ?AddItem@UIElement_ListBox@@QAE_NPAVUIElement@@@Z

        // UIElement_ListBox.DrawStart:
        public void DrawStart() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0x0046D920)(ref this); // .text:0046D540 ; void __thiscall UIElement_ListBox::DrawStart(UIElement_ListBox *this) .text:0046D540 ?DrawStart@UIElement_ListBox@@UAEXXZ

        // UIElement_ListBox.InsertItem:
        public Byte InsertItem(UIElement* _insertThis, int _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, int, Byte>)0x0046EB20)(ref this, _insertThis, _here); // .text:0046E760 ; bool __thiscall UIElement_ListBox::InsertItem(UIElement_ListBox *this, UIElement *_insertThis, int _here) .text:0046E760 ?InsertItem@UIElement_ListBox@@QAE_NPAVUIElement@@J@Z

        // UIElement_ListBox.SetHorizontal:
        public void SetHorizontal(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0x0046D970)(ref this, _b); // .text:0046D5B0 ; void __thiscall UIElement_ListBox::SetHorizontal(UIElement_ListBox *this, const bool _b) .text:0046D5B0 ?SetHorizontal@UIElement_ListBox@@IAEX_N@Z

        // UIElement_ListBox.SetState:
        public Byte SetState(UInt32 _state) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, Byte>)0x0046D8F0)(ref this, _state); // .text:0046D510 ; bool __thiscall UIElement_ListBox::SetState(UIElement_ListBox *this, unsigned int _state) .text:0046D510 ?SetState@UIElement_ListBox@@UAE_NK@Z

        // UIElement_ListBox.MouseUp:
        // public void MouseUp(UInt32 _xWindow, UInt32 _yWindow, UInt32 _button) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _xWindow, _yWindow, _button); // .text:0046DF30 ; void __thiscall UIElement_ListBox::MouseUp(UIElement_ListBox *this, unsigned int _xWindow, unsigned int _yWindow, unsigned int _button) .text:0046DF30 ?MouseUp@UIElement_ListBox@@MAEXKKK@Z

        // UIElement_ListBox.CalculateRow:
        // public int CalculateRow(int _itemIndex) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int>)0xDEADBEEF)(ref this, _itemIndex); // .text:0046E890 ; int __thiscall UIElement_ListBox::CalculateRow(UIElement_ListBox *this, int _itemIndex) .text:0046E890 ?CalculateRow@UIElement_ListBox@@QBEJJ@Z

        // UIElement_ListBox.GetSelectedIndex:
        public int GetSelectedIndex() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int>)0x0046CF60)(ref this); // .text:0046CB80 ; int __thiscall UIElement_ListBox::GetSelectedIndex(UIElement_ListBox *this) .text:0046CB80 ?GetSelectedIndex@UIElement_ListBox@@QBEJXZ

        // UIElement_ListBox.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0046E180 ; void __cdecl UIElement_ListBox::Register() .text:0046E180 ?Register@UIElement_ListBox@@SAXXZ

        // UIElement_ListBox.ScrollToX:
        public void ScrollToX(int i_iX) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, void>)0x0046D950)(ref this, i_iX); // .text:0046D570 ; void __thiscall UIElement_ListBox::ScrollToX(UIElement_ListBox *this, int i_iX) .text:0046D570 ?ScrollToX@UIElement_ListBox@@QAEXJ@Z

        // UIElement_ListBox.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:0046DD60 ; UIElement *__thiscall UIElement_ListBox::DynamicCast(UIElement_ListBox *this, unsigned int i_eType) .text:0046DD60 ?DynamicCast@UIElement_ListBox@@UAEPAVUIElement@@K@Z

        // UIElement_ListBox.DeleteItem:
        public Byte DeleteItem(UIElement* _pItem) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, Byte>)0x0046E3E0)(ref this, _pItem); // .text:0046E020 ; bool __thiscall UIElement_ListBox::DeleteItem(UIElement_ListBox *this, UIElement *_pItem) .text:0046E020 ?DeleteItem@UIElement_ListBox@@QAE_NPAVUIElement@@@Z

        // UIElement_ListBox.Rollover:
        // public void Rollover() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046E290 ; void __thiscall UIElement_ListBox::Rollover(UIElement_ListBox *this) .text:0046E290 ?Rollover@UIElement_ListBox@@IAEXXZ

        // UIElement_ListBox.InsertItem:
        // public Byte InsertItem(UIElement* _insertThis, UIElement* _here) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, UIElement*, Byte>)0xDEADBEEF)(ref this, _insertThis, _here); // .text:0046EC00 ; bool __thiscall UIElement_ListBox::InsertItem(UIElement_ListBox *this, UIElement *_insertThis, UIElement *_here) .text:0046EC00 ?InsertItem@UIElement_ListBox@@QAE_NPAVUIElement@@0@Z

        // UIElement_ListBox.WhatNum:
        public int WhatNum(UIElement* _item) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, int>)0x00480780)(ref this, _item); // .text:004803C0 ; int __thiscall UIElement_ListBox::WhatNum(UIElement_ListBox *this, UIElement *_item) .text:004803C0 ?WhatNum@UIElement_ListBox@@QBE?BJPAVUIElement@@@Z

        // UIElement_ListBox.SetSelectedItemStateChange:
        public void SetSelectedItemStateChange(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0x0046DA30)(ref this, _b); // .text:0046D670 ; void __thiscall UIElement_ListBox::SetSelectedItemStateChange(UIElement_ListBox *this, const bool _b) .text:0046D670 ?SetSelectedItemStateChange@UIElement_ListBox@@IAEX_N@Z

        // UIElement_ListBox.ScrollToView:
        // public void ScrollToView(int i_iItemNum) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, void>)0xDEADBEEF)(ref this, i_iItemNum); // .text:0046E9F0 ; void __thiscall UIElement_ListBox::ScrollToView(UIElement_ListBox *this, int i_iItemNum) .text:0046E9F0 ?ScrollToView@UIElement_ListBox@@QAEXJ@Z

        // UIElement_ListBox.ScrollToShow:
        // public void ScrollToShow(UIElement* i_pcItem) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, void>)0xDEADBEEF)(ref this, i_pcItem); // .text:0046EB60 ; void __thiscall UIElement_ListBox::ScrollToShow(UIElement_ListBox *this, UIElement *i_pcItem) .text:0046EB60 ?ScrollToShow@UIElement_ListBox@@QAEXPAVUIElement@@@Z

        // UIElement_ListBox.AddItemFromTemplateList:
        public UIElement* AddItemFromTemplateList(UInt32 i_itemIndex, UIElement* i_pInsertBefore) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UIElement*, UIElement*>)0x0046F670)(ref this, i_itemIndex, i_pInsertBefore); // .text:0046F2B0 ; UIElement *__thiscall UIElement_ListBox::AddItemFromTemplateList(UIElement_ListBox *this, unsigned int i_itemIndex, UIElement *i_pInsertBefore) .text:0046F2B0 ?AddItemFromTemplateList@UIElement_ListBox@@QAEPAVUIElement@@KPAV2@@Z

        // UIElement_ListBox.UpdateForChildSizeChange:
        // public void UpdateForChildSizeChange(UIElement* i_pcChild) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElement*, void>)0xDEADBEEF)(ref this, i_pcChild); // .text:0046D810 ; void __thiscall UIElement_ListBox::UpdateForChildSizeChange(UIElement_ListBox *this, UIElement *i_pcChild) .text:0046D810 ?UpdateForChildSizeChange@UIElement_ListBox@@UAEXPAVUIElement@@@Z

        // UIElement_ListBox.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, BaseProperty*, void>)0x0046DA60)(ref this, _attribute); // .text:0046D6A0 ; void __thiscall UIElement_ListBox::OnSetAttribute(UIElement_ListBox *this, BaseProperty *_attribute) .text:0046D6A0 ?OnSetAttribute@UIElement_ListBox@@UAEXABVBaseProperty@@@Z

        // UIElement_ListBox.AdjustToScrollableXYChange:
        // public void AdjustToScrollableXYChange() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046DC00 ; void __thiscall UIElement_ListBox::AdjustToScrollableXYChange(UIElement_ListBox *this) .text:0046DC00 ?AdjustToScrollableXYChange@UIElement_ListBox@@UAEXXZ

        // UIElement_ListBox.MouseOverTop:
        // public void MouseOverTop(Byte _bOverTop) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0xDEADBEEF)(ref this, _bOverTop); // .text:0046DED0 ; void __thiscall UIElement_ListBox::MouseOverTop(UIElement_ListBox *this, bool _bOverTop) .text:0046DED0 ?MouseOverTop@UIElement_ListBox@@MAEX_N@Z

        // UIElement_ListBox.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UIElementMessageInfo*, UIElementMessageListenResult>)0x0046E710)(ref this, i_rMsg); // .text:0046E350 ; UIElementMessageListenResult __thiscall UIElement_ListBox::ListenToElementMessage(UIElement_ListBox *this, UIElementMessageInfo *i_rMsg) .text:0046E350 ?ListenToElementMessage@UIElement_ListBox@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_ListBox.AddItem:
        // public UIElement* AddItem(UInt32 didLayout, UInt32 idElement, UIElement* i_pInsertBefore) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UInt32, UIElement*, UIElement*>)0xDEADBEEF)(ref this, didLayout, idElement, i_pInsertBefore); // .text:0046EDC0 ; UIElement *__thiscall UIElement_ListBox::AddItem(UIElement_ListBox *this, IDClass<_tagDataID,32,0> didLayout, unsigned int idElement, UIElement *i_pInsertBefore) .text:0046EDC0 ?AddItem@UIElement_ListBox@@QAEPAVUIElement@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@KPAV2@@Z

        // UIElement_ListBox.StartDownActive:
        // public Byte StartDownActive() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte>)0xDEADBEEF)(ref this); // .text:0046EE60 ; bool __thiscall UIElement_ListBox::StartDownActive(UIElement_ListBox *this) .text:0046EE60 ?StartDownActive@UIElement_ListBox@@UAE_NXZ

        // UIElement_ListBox.SetDragRollover:
        public void SetDragRollover(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0x0046DA00)(ref this, _b); // .text:0046D640 ; void __thiscall UIElement_ListBox::SetDragRollover(UIElement_ListBox *this, const bool _b) .text:0046D640 ?SetDragRollover@UIElement_ListBox@@IAEX_N@Z

        // UIElement_ListBox.EndRollover:
        // public void EndRollover() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046DBB0 ; void __thiscall UIElement_ListBox::EndRollover(UIElement_ListBox *this) .text:0046DBB0 ?EndRollover@UIElement_ListBox@@IAEXXZ

        // UIElement_ListBox.CalculateColumn:
        // public int CalculateColumn(int _itemIndex) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int>)0xDEADBEEF)(ref this, _itemIndex); // .text:0046E7E0 ; int __thiscall UIElement_ListBox::CalculateColumn(UIElement_ListBox *this, int _itemIndex) .text:0046E7E0 ?CalculateColumn@UIElement_ListBox@@QBEJJ@Z

        // UIElement_ListBox.AddItemFromTemplateListByID:
        public UIElement* AddItemFromTemplateListByID(UInt32 i_item, UIElement* i_pInsertBefore) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UIElement*, UIElement*>)0x0046F2C0)(ref this, i_item, i_pInsertBefore); // .text:0046EF00 ; UIElement *__thiscall UIElement_ListBox::AddItemFromTemplateListByID(UIElement_ListBox *this, unsigned int i_item, UIElement *i_pInsertBefore) .text:0046EF00 ?AddItemFromTemplateListByID@UIElement_ListBox@@QAEPAVUIElement@@KPAV2@@Z

        // UIElement_ListBox.AddItem:
        // public UIElement* AddItem(BaseProperty* propEntryStruct, UIElement* i_pInsertBefore) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, BaseProperty*, UIElement*, UIElement*>)0xDEADBEEF)(ref this, propEntryStruct, i_pInsertBefore); // .text:0046F170 ; UIElement *__thiscall UIElement_ListBox::AddItem(UIElement_ListBox *this, BaseProperty *propEntryStruct, UIElement *i_pInsertBefore) .text:0046F170 ?AddItem@UIElement_ListBox@@QAEPAVUIElement@@ABVBaseProperty@@PAV2@@Z

        // UIElement_ListBox.StartRollover:
        // public void StartRollover() => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, void>)0xDEADBEEF)(ref this); // .text:0046DB90 ; void __thiscall UIElement_ListBox::StartRollover(UIElement_ListBox *this) .text:0046DB90 ?StartRollover@UIElement_ListBox@@IAEXXZ

        // UIElement_ListBox.InqItemIndexAtPoint:
        // public Byte InqItemIndexAtPoint(int i_iX, int i_iY, UInt32* o_iIndex) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int, UInt32*, Byte>)0xDEADBEEF)(ref this, i_iX, i_iY, o_iIndex); // .text:0046D9A0 ; bool __thiscall UIElement_ListBox::InqItemIndexAtPoint(UIElement_ListBox *this, int i_iX, int i_iY, unsigned int *o_iIndex) .text:0046D9A0 ?InqItemIndexAtPoint@UIElement_ListBox@@QAE_NJJAAK@Z

        // UIElement_ListBox.RemoveItem:
        public UIElement* RemoveItem(UInt32 _itemIndex) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, UInt32, UIElement*>)0x0046DE80)(ref this, _itemIndex); // .text:0046DAC0 ; UIElement *__thiscall UIElement_ListBox::RemoveItem(UIElement_ListBox *this, unsigned int _itemIndex) .text:0046DAC0 ?RemoveItem@UIElement_ListBox@@QAEPAVUIElement@@K@Z

        // UIElement_ListBox.GetItemAtPoint:
        // public UIElement* GetItemAtPoint(int _scrX, int _scrY) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, int, int, UIElement*>)0xDEADBEEF)(ref this, _scrX, _scrY); // .text:0046DFA0 ; UIElement *__thiscall UIElement_ListBox::GetItemAtPoint(UIElement_ListBox *this, int _scrX, int _scrY) .text:0046DFA0 ?GetItemAtPoint@UIElement_ListBox@@QAEPAVUIElement@@JJ@Z

        // UIElement_ListBox.SetClickSelect:
        public void SetClickSelect(Byte _b) => ((delegate* unmanaged[Thiscall]<ref UIElement_ListBox, Byte, void>)0x0046D9A0)(ref this, _b); // .text:0046D5E0 ; void __thiscall UIElement_ListBox::SetClickSelect(UIElement_ListBox *this, const bool _b) .text:0046D5E0 ?SetClickSelect@UIElement_ListBox@@IAEX_N@Z
    }
    public unsafe struct UIElement_Scrollable {
        // Struct:
        public UIElement a0;
        public UInt32 m_eHorizonalScrollbarID;
        public UInt32 m_eVerticalScrollbarID;
        public int m_iScrollableX;
        public int m_iScrollableY;
        public int m_iScrollableWidth;
        public int m_iScrollableHeight;
        public override string ToString() => $"a0(UIElement):{a0}, m_eHorizonalScrollbarID:{m_eHorizonalScrollbarID:X8}, m_eVerticalScrollbarID:{m_eVerticalScrollbarID:X8}, m_iScrollableX(int):{m_iScrollableX}, m_iScrollableY(int):{m_iScrollableY}, m_iScrollableWidth(int):{m_iScrollableWidth}, m_iScrollableHeight(int):{m_iScrollableHeight}";

        // Functions:

        // UIElement_Scrollable.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:00473DE0 ; UIElement *__thiscall UIElement_Scrollable::DynamicCast(UIElement_Scrollable *this, unsigned int i_eType) .text:00473DE0 ?DynamicCast@UIElement_Scrollable@@UAEPAVUIElement@@K@Z

        // UIElement_Scrollable.HandleScrollbarMessage_:
        // public void HandleScrollbarMessage_(Byte i_bHorizontal, UInt32 i_eMessageID, UIElement_Scrollbar* i_pcScrollbar) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, Byte, UInt32, UIElement_Scrollbar*, void>)0xDEADBEEF)(ref this, i_bHorizontal, i_eMessageID, i_pcScrollbar); // .text:00474370 ; void __thiscall UIElement_Scrollable::HandleScrollbarMessage_(UIElement_Scrollable *this, bool i_bHorizontal, const unsigned int i_eMessageID, UIElement_Scrollbar *i_pcScrollbar) .text:00474370 ?HandleScrollbarMessage_@UIElement_Scrollable@@IAEX_NKPAVUIElement_Scrollbar@@@Z

        // UIElement_Scrollable.MouseDown:
        // public void MouseDown(UInt32 i_xWindow, UInt32 i_yWindow, UInt32 i_eButton) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, UInt32, UInt32, UInt32, void>)0xDEADBEEF)(ref this, i_xWindow, i_yWindow, i_eButton); // .text:00473E00 ; void __thiscall UIElement_Scrollable::MouseDown(UIElement_Scrollable *this, unsigned int i_xWindow, unsigned int i_yWindow, unsigned int i_eButton) .text:00473E00 ?MouseDown@UIElement_Scrollable@@UAEXKKK@Z

        // UIElement_Scrollable.RegisterInputMaps:
        // public Byte RegisterInputMaps(int i_nPriority) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, int, Byte>)0xDEADBEEF)(ref this, i_nPriority); // .text:00473E50 ; bool __thiscall UIElement_Scrollable::RegisterInputMaps(UIElement_Scrollable *this, int i_nPriority) .text:00473E50 ?RegisterInputMaps@UIElement_Scrollable@@UAE_NJ@Z

        // UIElement_Scrollable.UnregisterInputMaps:
        // public Byte UnregisterInputMaps() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, Byte>)0xDEADBEEF)(ref this); // .text:00473E90 ; bool __thiscall UIElement_Scrollable::UnregisterInputMaps(UIElement_Scrollable *this) .text:00473E90 ?UnregisterInputMaps@UIElement_Scrollable@@UAE_NXZ

        // UIElement_Scrollable.GetScrollbarPointer_:
        // public UIElement_Scrollbar* GetScrollbarPointer_(Byte i_bHorizontal) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, Byte, UIElement_Scrollbar*>)0xDEADBEEF)(ref this, i_bHorizontal); // .text:00473EC0 ; UIElement_Scrollbar *__thiscall UIElement_Scrollable::GetScrollbarPointer_(UIElement_Scrollable *this, bool i_bHorizontal) .text:00473EC0 ?GetScrollbarPointer_@UIElement_Scrollable@@IAEPAVUIElement_Scrollbar@@_N@Z

        // UIElement_Scrollable.OnSetAttribute:
        public void OnSetAttribute(BaseProperty* i_rcProperty) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, BaseProperty*, void>)0x004749F0)(ref this, i_rcProperty); // .text:00474630 ; void __thiscall UIElement_Scrollable::OnSetAttribute(UIElement_Scrollable *this, BaseProperty *i_rcProperty) .text:00474630 ?OnSetAttribute@UIElement_Scrollable@@UAEXABVBaseProperty@@@Z

        // UIElement_Scrollable.ResizeTo:
        // public void ResizeTo(int i_iWidth, int i_iHeight) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, int, int, void>)0xDEADBEEF)(ref this, i_iWidth, i_iHeight); // .text:004746C0 ; void __thiscall UIElement_Scrollable::ResizeTo(UIElement_Scrollable *this, const int i_iWidth, const int i_iHeight) .text:004746C0 ?ResizeTo@UIElement_Scrollable@@UAEXJJ@Z

        // UIElement_Scrollable.__Ctor:
        // public void __Ctor(LayoutDesc* i_rcLayout, ElementDesc* i_rcFullDesc) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, i_rcLayout, i_rcFullDesc); // .text:00473D90 ; void __thiscall UIElement_Scrollable::UIElement_Scrollable(UIElement_Scrollable *this, LayoutDesc *i_rcLayout, ElementDesc *i_rcFullDesc) .text:00473D90 ??0UIElement_Scrollable@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Scrollable.UpdateScrollbarPosition_:
        // public void UpdateScrollbarPosition_(Byte i_bHorizontal) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, Byte, void>)0xDEADBEEF)(ref this, i_bHorizontal); // .text:00473F20 ; void __thiscall UIElement_Scrollable::UpdateScrollbarPosition_(UIElement_Scrollable *this, bool i_bHorizontal) .text:00473F20 ?UpdateScrollbarPosition_@UIElement_Scrollable@@IAEX_N@Z

        // UIElement_Scrollable.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, void>)0x00474870)(ref this); // .text:004744B0 ; void __thiscall UIElement_Scrollable::PostInit(UIElement_Scrollable *this) .text:004744B0 ?PostInit@UIElement_Scrollable@@UAEXXZ

        // UIElement_Scrollable.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* o_rcSet) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, o_rcSet); // .text:00474070 ; bool __thiscall UIElement_Scrollable::InqAvailableProperties(UIElement_Scrollable *this, AvailablePropertySet *o_rcSet) .text:00474070 ?InqAvailableProperties@UIElement_Scrollable@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Scrollable.SetScrollableXY:
        public void SetScrollableXY(int i_iX, int i_iY, Byte i_bForce) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, int, int, Byte, void>)0x00474480)(ref this, i_iX, i_iY, i_bForce); // .text:004740C0 ; void __thiscall UIElement_Scrollable::SetScrollableXY(UIElement_Scrollable *this, int i_iX, int i_iY, bool i_bForce) .text:004740C0 ?SetScrollableXY@UIElement_Scrollable@@IAEXJJ_N@Z

        // UIElement_Scrollable.UpdateScrollbarSize_:
        // public void UpdateScrollbarSize_(Byte i_bHorizontal) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, Byte, void>)0xDEADBEEF)(ref this, i_bHorizontal); // .text:004741A0 ; void __thiscall UIElement_Scrollable::UpdateScrollbarSize_(UIElement_Scrollable *this, bool i_bHorizontal) .text:004741A0 ?UpdateScrollbarSize_@UIElement_Scrollable@@IAEX_N@Z

        // UIElement_Scrollable.ListenToElementMessage:
        // public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, UIElementMessageInfo*, UIElementMessageListenResult>)0xDEADBEEF)(ref this, i_rMsg); // .text:00474560 ; UIElementMessageListenResult __thiscall UIElement_Scrollable::ListenToElementMessage(UIElement_Scrollable *this, UIElementMessageInfo *i_rMsg) .text:00474560 ?ListenToElementMessage@UIElement_Scrollable@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIElement_Scrollable.ResizeScrollableArea:
        // public void ResizeScrollableArea(int i_iWidth, int i_iHeight) => ((delegate* unmanaged[Thiscall]<ref UIElement_Scrollable, int, int, void>)0xDEADBEEF)(ref this, i_iWidth, i_iHeight); // .text:00474730 ; void __thiscall UIElement_Scrollable::ResizeScrollableArea(UIElement_Scrollable *this, int i_iWidth, int i_iHeight) .text:00474730 ?ResizeScrollableArea@UIElement_Scrollable@@IAEXJJ@Z
    }
    public unsafe struct UIElement_Viewport {
        // Struct:
        public UIElement a0;
        public CreatureMode a1;
        public override string ToString() => $"a0(UIElement):{a0}, a1(CreatureMode):{a1}";

        // Functions:

        // UIElement_Viewport.PostInit:
        // public void PostInit() => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, void>)0xDEADBEEF)(ref this); // .text:0046BB40 ; void __thiscall UIElement_Viewport::PostInit(UIElement_Viewport *this) .text:0046BB40 ?PostInit@UIElement_Viewport@@MAEXXZ

        // UIElement_Viewport.SetCamera:
        public void SetCamera(Vector3* position, Vector3* direction) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, Vector3*, Vector3*, void>)0x0046BE10)(ref this, position, direction); // .text:0046BB60 ; void __thiscall UIElement_Viewport::SetCamera(UIElement_Viewport *this, Vector3 *position, Vector3 *direction) .text:0046BB60 ?SetCamera@UIElement_Viewport@@QAEXABVVector3@@0@Z

        // UIElement_Viewport.SetLight:
        public void SetLight(LIGHTINFO.LightType lightType, Single intensity, Vector3* direction) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, LIGHTINFO.LightType, Single, Vector3*, void>)0x0046BE40)(ref this, lightType, intensity, direction); // .text:0046BB90 ; void __thiscall UIElement_Viewport::SetLight(UIElement_Viewport *this, LIGHTINFO::LightType lightType, float intensity, Vector3 *direction) .text:0046BB90 ?SetLight@UIElement_Viewport@@QAEXW4LightType@LIGHTINFO@@MABVVector3@@@Z

        // UIElement_Viewport.Register:
        // public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0046BC10 ; void __cdecl UIElement_Viewport::Register() .text:0046BC10 ?Register@UIElement_Viewport@@SAXXZ

        // UIElement_Viewport.InqAvailableProperties:
        // public Byte InqAvailableProperties(AvailablePropertySet* _set) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, AvailablePropertySet*, Byte>)0xDEADBEEF)(ref this, _set); // .text:0046BC20 ; bool __thiscall UIElement_Viewport::InqAvailableProperties(UIElement_Viewport *this, AvailablePropertySet *_set) .text:0046BC20 ?InqAvailableProperties@UIElement_Viewport@@UBE_NAAVAvailablePropertySet@@@Z

        // UIElement_Viewport.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:0046BA70 ; UIElement *__thiscall UIElement_Viewport::DynamicCast(UIElement_Viewport *this, unsigned int i_eType) .text:0046BA70 ?DynamicCast@UIElement_Viewport@@UAEPAVUIElement@@K@Z

        // UIElement_Viewport.MakeUIObject:
        public Byte MakeUIObject(UIObject** o_pcUIObject) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, UIObject**, Byte>)0x0046BDA0)(ref this, o_pcUIObject); // .text:0046BAF0 ; bool __thiscall UIElement_Viewport::MakeUIObject(UIElement_Viewport *this, UIObject **o_pcUIObject) .text:0046BAF0 ?MakeUIObject@UIElement_Viewport@@MAE_NAAPAVUIObject@@@Z

        // UIElement_Viewport.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:0046BA90 ; UIElement *__cdecl UIElement_Viewport::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0046BA90 ?Create@UIElement_Viewport@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElement_Viewport.OnSetAttribute:
        // public void OnSetAttribute(BaseProperty* _attribute) => ((delegate* unmanaged[Thiscall]<ref UIElement_Viewport, BaseProperty*, void>)0xDEADBEEF)(ref this, _attribute); // .text:0046BAD0 ; void __thiscall UIElement_Viewport::OnSetAttribute(UIElement_Viewport *this, BaseProperty *_attribute) .text:0046BAD0 ?OnSetAttribute@UIElement_Viewport@@UAEXABVBaseProperty@@@Z
    }

    public unsafe struct UIElementManager {
        // Struct:
        public CInputHandler a0;
        public IInputActionCallback a1;
        public SmartArray<PTR<UIElement>> m_deleteQueue;
        public SmartArray<PTR<UIElement>> m_elementList;
        public HashTable<UInt32, int> m_classCreateMethodTable; // delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>
        public LayoutDesc* m_pHollowLayoutDesc;
        public ElementDesc* m_pHollowElementDesc;
        public UIElement* m_pRootElement;
        public Vector3 m_vGlobalScale;
        public AutoGrowHashTable<UInt32, AutoGrowHashTable<UInt32, SmartArray<UIMessageData>>> m_elementListenerTable;
        public AutoGrowHashTable<UInt32, SmartArray<UIMessageData>> m_globalMessageListenerTable;
        public SmartArray<UIMessageRemovalData> m_aUIMessageRemovalData;
        public AutoGrowHashTable<UInt32, SmartArray<PTR<UIElement>>> m_elementInputActionListenerTable;
        public _List<UIElementMessageInfo> m_listQueuedElementMessages;
        public Byte m_bBroadcastingMessage;
        public UInt32 m_defaultCursorDID;
        public int m_defaultCursorHotX;
        public int m_defaultCursorHotY;
        public UInt32 m_lastCursorDID;
        public int m_lastCursorHotX;
        public int m_lastCursorHotY;
        public Byte m_bPerformMouseHitTest;
        public UIElement* m_pElementLastOver;
        public UIElement* m_pElementLastEntered;
        public UIElement* m_pElementWithMouseCapture;
        public UIElement* m_pElementLastDragCursorOver;
        public HashSet<UInt32> m_setActionsTriggeringCapture;
        public UInt32 m_nMouseCapture;
        public Byte m_bDoVisualMouseDebugging;
        public UInt32 m_debugFontDID;
        public Byte m_bMouseHasLeftTheWindow;
        public Double m_lastMouseMoveTime;
        public Double m_tooltipStart;
        public Byte m_tooltipEnable;
        public Single m_tooltipDelay;
        public Single m_tooltipDuration;
        public UIElement* m_pTooltipOwner;
        public UIElement* m_pTooltipElement;
        public Double m_buttonDownTime;
        public int m_dragX;
        public int m_dragY;
        public int m_dragBaseX;
        public int m_dragBaseY;
        public UIElement* m_pcPotentialDragElement;
        public UIElement* m_dragElement;
        public UIElement* m_dragOwner;
        public Byte m_bDragStarted;
        public Byte m_bHoverStarted;
        public UIElement* m_focusElement;
        public UIElement* m_activeElement;
        public SmartArray<PTR<UIElement>> m_activatableElements;
        public ContextMenu* m_pCSM;
        public override string ToString() => $"a0(CInputHandler):{a0}, a1(IInputActionCallback):{a1}, m_deleteQueue(SmartArray<UIElement*,1>):{m_deleteQueue}, m_elementList(SmartArray<UIElement*,1>):{m_elementList}, m_classCreateMethodTable(HashTable<UInt32,UIElement* (__cdecl*)(LayoutDesc*,ElementDesc*),0>):{m_classCreateMethodTable}, m_pHollowLayoutDesc:->(LayoutDesc*)0x{(int)m_pHollowLayoutDesc:X8}, m_pHollowElementDesc:->(ElementDesc*)0x{(int)m_pHollowElementDesc:X8}, m_pRootElement:->(UIElement*)0x{(int)m_pRootElement:X8}, m_vGlobalScale(Vector3):{m_vGlobalScale}, m_elementListenerTable(AutoGrowHashTable<UInt32,AutoGrowHashTable<UInt32,SmartArray<UIMessageData,1> > >):{m_elementListenerTable}, m_globalMessageListenerTable(AutoGrowHashTable<UInt32,SmartArray<UIMessageData,1> >):{m_globalMessageListenerTable}, m_aUIMessageRemovalData(SmartArray<UIMessageRemovalData,1>):{m_aUIMessageRemovalData}, m_elementInputActionListenerTable(AutoGrowHashTable<UInt32,SmartArray<UIElement*,1> >):{m_elementInputActionListenerTable}, m_listQueuedElementMessages(List<UIElementMessageInfo>):{m_listQueuedElementMessages}, m_bBroadcastingMessage:{m_bBroadcastingMessage:X2}, m_defaultCursorDID:{m_defaultCursorDID:X8}, m_defaultCursorHotX(int):{m_defaultCursorHotX}, m_defaultCursorHotY(int):{m_defaultCursorHotY}, m_lastCursorDID:{m_lastCursorDID:X8}, m_lastCursorHotX(int):{m_lastCursorHotX}, m_lastCursorHotY(int):{m_lastCursorHotY}, m_bPerformMouseHitTest:{m_bPerformMouseHitTest:X2}, m_pElementLastOver:->(UIElement*)0x{(int)m_pElementLastOver:X8}, m_pElementLastEntered:->(UIElement*)0x{(int)m_pElementLastEntered:X8}, m_pElementWithMouseCapture:->(UIElement*)0x{(int)m_pElementWithMouseCapture:X8}, m_pElementLastDragCursorOver:->(UIElement*)0x{(int)m_pElementLastDragCursorOver:X8}, m_setActionsTriggeringCapture(HashSet<UInt32>):{m_setActionsTriggeringCapture}, m_nMouseCapture:{m_nMouseCapture:X8}, m_bDoVisualMouseDebugging:{m_bDoVisualMouseDebugging:X2}, m_debugFontDID:{m_debugFontDID:X8}, m_bMouseHasLeftTheWindow:{m_bMouseHasLeftTheWindow:X2}, m_lastMouseMoveTime:{m_lastMouseMoveTime:n5}, m_tooltipStart:{m_tooltipStart:n5}, m_tooltipEnable:{m_tooltipEnable:X2}, m_tooltipDelay:{m_tooltipDelay:n5}, m_tooltipDuration:{m_tooltipDuration:n5}, m_pTooltipOwner:->(UIElement*)0x{(int)m_pTooltipOwner:X8}, m_pTooltipElement:->(UIElement*)0x{(int)m_pTooltipElement:X8}, m_buttonDownTime:{m_buttonDownTime:n5}, m_dragX(int):{m_dragX}, m_dragY(int):{m_dragY}, m_dragBaseX(int):{m_dragBaseX}, m_dragBaseY(int):{m_dragBaseY}, m_pcPotentialDragElement:->(UIElement*)0x{(int)m_pcPotentialDragElement:X8}, m_dragElement:->(UIElement*)0x{(int)m_dragElement:X8}, m_dragOwner:->(UIElement*)0x{(int)m_dragOwner:X8}, m_bDragStarted:{m_bDragStarted:X2}, m_bHoverStarted:{m_bHoverStarted:X2}, m_focusElement:->(UIElement*)0x{(int)m_focusElement:X8}, m_activeElement:->(UIElement*)0x{(int)m_activeElement:X8}, m_activatableElements(SmartArray<UIElement*,1>):{m_activatableElements}, m_pCSM:->(ContextMenu*)0x{(int)m_pCSM:X8}";

        // Functions:

        // UIElementManager.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045F6B0)(ref this); // .text:0045F5D0 ; void __thiscall UIElementManager::UIElementManager(UIElementManager *this) .text:0045F5D0 ??0UIElementManager@@QAE@XZ

        // UIElementManager.ActionHandler:
        public void ActionHandler(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, InputEvent*, void>)0x0045CD80)(ref this, i_evt); // .text:0045CC00 ; void __thiscall UIElementManager::ActionHandler(UIElementManager *this, InputEvent *i_evt) .text:0045CC00 ?ActionHandler@UIElementManager@@UAEXABVInputEvent@@@Z

        // UIElementManager.ActivateNext:
        public void ActivateNext(Byte _backwards) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Byte, void>)0x00459980)(ref this, _backwards); // .text:00459910 ; void __thiscall UIElementManager::ActivateNext(UIElementManager *this, bool _backwards) .text:00459910 ?ActivateNext@UIElementManager@@QAEX_N@Z

        // UIElementManager.ActivationAlert:
        public void ActivationAlert(UIElement* _element, Byte _active) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, Byte, void>)0x0045C540)(ref this, _element, _active); // .text:0045C460 ; void __thiscall UIElementManager::ActivationAlert(UIElementManager *this, UIElement *_element, bool _active) .text:0045C460 ?ActivationAlert@UIElementManager@@QAEXPAVUIElement@@_N@Z

        // UIElementManager.AddElementToDeleteQueue:
        public void AddElementToDeleteQueue(UIElement* _element) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045B350)(ref this, _element); // .text:0045B270 ; void __thiscall UIElementManager::AddElementToDeleteQueue(UIElementManager *this, UIElement *_element) .text:0045B270 ?AddElementToDeleteQueue@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.BroadcastElementMessage:
        public Byte BroadcastElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElementMessageInfo*, Byte>)0x0045AC50)(ref this, i_rMsg); // .text:0045AB40 ; bool __thiscall UIElementManager::BroadcastElementMessage(UIElementManager *this, UIElementMessageInfo *i_rMsg) .text:0045AB40 ?BroadcastElementMessage@UIElementManager@@QAE_NABUUIElementMessageInfo@@@Z

        // UIElementManager.BroadcastElementMessage:
        public Byte BroadcastElementMessage(UInt32 _elementID, UIElement* _element, UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, UIElement*, UInt32, int, Byte>)0x0045B3A0)(ref this, _elementID, _element, _messageID, _data_int); // .text:0045B2C0 ; bool __thiscall UIElementManager::BroadcastElementMessage(UIElementManager *this, unsigned int _elementID, UIElement *_element, unsigned int _messageID, int _data_int) .text:0045B2C0 ?BroadcastElementMessage@UIElementManager@@QAE_NKPAVUIElement@@KJ@Z

        // UIElementManager.BroadcastElementMessage:
        public Byte BroadcastElementMessage(UIElement* i_pElement, UInt32 i_idMessage, UInt32 i_dwParam1, UInt32 i_dwParam2) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UInt32, UInt32, UInt32, Byte>)0x0045B450)(ref this, i_pElement, i_idMessage, i_dwParam1, i_dwParam2); // .text:0045B370 ; bool __thiscall UIElementManager::BroadcastElementMessage(UIElementManager *this, UIElement *i_pElement, unsigned int i_idMessage, unsigned int i_dwParam1, unsigned int i_dwParam2) .text:0045B370 ?BroadcastElementMessage@UIElementManager@@QAE_NPAVUIElement@@KKK@Z

        // UIElementManager.BroadcastGlobalMessage:
        public void BroadcastGlobalMessage(UInt32 _messageID, int _data_int) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, int, void>)0x0045B4C0)(ref this, _messageID, _data_int); // .text:0045B3E0 ; void __thiscall UIElementManager::BroadcastGlobalMessage(UIElementManager *this, unsigned int _messageID, int _data_int) .text:0045B3E0 ?BroadcastGlobalMessage@UIElementManager@@QAEXKJ@Z

        // UIElementManager.CheckCursor:
        public void CheckCursor() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045AD00)(ref this); // .text:0045ABF0 ; void __thiscall UIElementManager::CheckCursor(UIElementManager *this) .text:0045ABF0 ?CheckCursor@UIElementManager@@QAEXXZ

        // UIElementManager.CheckTooltip:
        public void CheckTooltip() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045B7C0)(ref this); // .text:0045B6E0 ; void __thiscall UIElementManager::CheckTooltip(UIElementManager *this) .text:0045B6E0 ?CheckTooltip@UIElementManager@@IAEXXZ

        // UIElementManager.CleanDeleteQueue:
        public void CleanDeleteQueue() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045A350)(ref this); // .text:0045A240 ; void __thiscall UIElementManager::CleanDeleteQueue(UIElementManager *this) .text:0045A240 ?CleanDeleteQueue@UIElementManager@@IAEXXZ

        // UIElementManager.Cleanup:
        public void Cleanup() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045F200)(ref this); // .text:0045F120 ; void __thiscall UIElementManager::Cleanup(UIElementManager *this) .text:0045F120 ?Cleanup@UIElementManager@@QAEXXZ

        // UIElementManager.ClearDragandDrop:
        public Byte ClearDragandDrop() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Byte>)0x00459400)(ref this); // .text:004592E0 ; bool __thiscall UIElementManager::ClearDragandDrop(UIElementManager *this) .text:004592E0 ?ClearDragandDrop@UIElementManager@@IAE_NXZ

        // UIElementManager.ConsoleCommand_PrintUISurfaceUsage:
        public static Byte ConsoleCommand_PrintUISurfaceUsage() => ((delegate* unmanaged[Cdecl]<Byte>)0x0045E930)(); // .text:0045E850 ; bool __cdecl UIElementManager::ConsoleCommand_PrintUISurfaceUsage() .text:0045E850 ?ConsoleCommand_PrintUISurfaceUsage@UIElementManager@@SA_NXZ

        // UIElementManager.CreateChildElement:
        public UIElement* CreateChildElement(UIElement* i_pParent, LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, LayoutDesc*, ElementDesc*, UIElement*>)0x0045D160)(ref this, i_pParent, _layout, _full_desc); // .text:0045D080 ; UIElement *__thiscall UIElementManager::CreateChildElement(UIElementManager *this, UIElement *i_pParent, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0045D080 ?CreateChildElement@UIElementManager@@QAEPAVUIElement@@PAV2@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElementManager.CreateChildElement:
        public UIElement* CreateChildElement(UIElement* i_pParent, LayoutDesc* i_layout, UInt32 i_elementID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, LayoutDesc*, UInt32, UIElement*>)0x0045D8B0)(ref this, i_pParent, i_layout, i_elementID); // .text:0045D7D0 ; UIElement *__thiscall UIElementManager::CreateChildElement(UIElementManager *this, UIElement *i_pParent, LayoutDesc *i_layout, unsigned int i_elementID) .text:0045D7D0 ?CreateChildElement@UIElementManager@@QAEPAVUIElement@@PAV2@ABVLayoutDesc@@K@Z

        // UIElementManager.CreateChildElementByDid:
        public UIElement* CreateChildElementByDid(UIElement* i_pParent, UInt32 _layoutID, UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UInt32, UInt32, UIElement*>)0x0045E580)(ref this, i_pParent, _layoutID, _elementID); // .text:0045E4A0 ; UIElement *__thiscall UIElementManager::CreateChildElementByDid(UIElementManager *this, UIElement *i_pParent, IDClass<_tagDataID,32,0> _layoutID, unsigned int _elementID) .text:0045E4A0 ?CreateChildElementByDid@UIElementManager@@QAEPAVUIElement@@PAV2@V?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIElementManager.CreateChildElementByEnum:
        public UIElement* CreateChildElementByEnum(UIElement* i_pParent, UInt32 _layoutEnum, UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UInt32, UInt32, UIElement*>)0x0045E520)(ref this, i_pParent, _layoutEnum, _elementID); // .text:0045E440 ; UIElement *__thiscall UIElementManager::CreateChildElementByEnum(UIElementManager *this, UIElement *i_pParent, const unsigned int _layoutEnum, unsigned int _elementID) .text:0045E440 ?CreateChildElementByEnum@UIElementManager@@QAEPAVUIElement@@PAV2@KK@Z

        // UIElementManager.CreateElement:
        public UIElement* CreateElement(LayoutDesc* _layout, ElementDesc* _desc) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, LayoutDesc*, ElementDesc*, UIElement*>)0x0045CCF0)(ref this, _layout, _desc); // .text:0045CB70 ; UIElement *__thiscall UIElementManager::CreateElement(UIElementManager *this, LayoutDesc *_layout, ElementDesc *_desc) .text:0045CB70 ?CreateElement@UIElementManager@@IAEPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElementManager.CreateElementRecursiveFromFullDesc:
        public UIElement* CreateElementRecursiveFromFullDesc(LayoutDesc* _layout, ElementDesc* full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, LayoutDesc*, ElementDesc*, UIElement*>)0x0045B1A0)(ref this, _layout, full_desc); // .text:0045B0C0 ; UIElement *__thiscall UIElementManager::CreateElementRecursiveFromFullDesc(UIElementManager *this, LayoutDesc *_layout, ElementDesc *full_desc) .text:0045B0C0 ?CreateElementRecursiveFromFullDesc@UIElementManager@@IAEPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElementManager.CreateElementRecursiveFromPartialDesc:
        public UIElement* CreateElementRecursiveFromPartialDesc(LayoutDesc* _layout, ElementDesc* _desc) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, LayoutDesc*, ElementDesc*, UIElement*>)0x0045C090)(ref this, _layout, _desc); // .text:0045BFB0 ; UIElement *__thiscall UIElementManager::CreateElementRecursiveFromPartialDesc(UIElementManager *this, LayoutDesc *_layout, ElementDesc *_desc) .text:0045BFB0 ?CreateElementRecursiveFromPartialDesc@UIElementManager@@IAEPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElementManager.CreateHollowElement:
        public UIElement* CreateHollowElement(UIElement* i_pParent) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UIElement*>)0x0045D1C0)(ref this, i_pParent); // .text:0045D0E0 ; UIElement *__thiscall UIElementManager::CreateHollowElement(UIElementManager *this, UIElement *i_pParent) .text:0045D0E0 ?CreateHollowElement@UIElementManager@@QAEPAVUIElement@@PAV2@@Z

        // UIElementManager.CreateRootElement:
        public UIElement* CreateRootElement(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, LayoutDesc*, ElementDesc*, UIElement*>)0x0045D100)(ref this, _layout, _full_desc); // .text:0045D020 ; UIElement *__thiscall UIElementManager::CreateRootElement(UIElementManager *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0045D020 ?CreateRootElement@UIElementManager@@QAEPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // UIElementManager.CreateRootElement:
        public UIElement* CreateRootElement(LayoutDesc* _layout, UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, LayoutDesc*, UInt32, UIElement*>)0x0045D880)(ref this, _layout, _elementID); // .text:0045D7A0 ; UIElement *__thiscall UIElementManager::CreateRootElement(UIElementManager *this, LayoutDesc *_layout, unsigned int _elementID) .text:0045D7A0 ?CreateRootElement@UIElementManager@@QAEPAVUIElement@@ABVLayoutDesc@@K@Z

        // UIElementManager.CreateRootElementByDataID:
        public UIElement* CreateRootElementByDataID(UInt32 _layoutDID, UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, UInt32, UIElement*>)0x0045E4B0)(ref this, _layoutDID, _elementID); // .text:0045E3D0 ; UIElement *__thiscall UIElementManager::CreateRootElementByDataID(UIElementManager *this, IDClass<_tagDataID,32,0> _layoutDID, unsigned int _elementID) .text:0045E3D0 ?CreateRootElementByDataID@UIElementManager@@QAEPAVUIElement@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIElementManager.CreateUIElementManager:
        public static void CreateUIElementManager() => ((delegate* unmanaged[Cdecl]<void>)0x0045F900)(); // .text:0045F820 ; void __cdecl UIElementManager::CreateUIElementManager() .text:0045F820 ?CreateUIElementManager@UIElementManager@@SAXXZ

        // UIElementManager.DeletingElement:
        public void DeletingElement(UIElement* _element) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045E600)(ref this, _element); // .text:0045E520 ; void __thiscall UIElementManager::DeletingElement(UIElementManager *this, UIElement *_element) .text:0045E520 ?DeletingElement@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.DestroyUIElementManager:
        public static void DestroyUIElementManager() => ((delegate* unmanaged[Cdecl]<void>)0x00459310)(); // .text:004591F0 ; void __cdecl UIElementManager::DestroyUIElementManager() .text:004591F0 ?DestroyUIElementManager@UIElementManager@@SAXXZ

        // UIElementManager.DoMouseUpdate:
        public void DoMouseUpdate() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045CDE0)(ref this); // .text:0045CC60 ; void __thiscall UIElementManager::DoMouseUpdate(UIElementManager *this) .text:0045CC60 ?DoMouseUpdate@UIElementManager@@IAEXXZ

        // UIElementManager.DoVisibilityToggleAction:
        public Byte DoVisibilityToggleAction(UInt32 _action) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, Byte>)0x0045B740)(ref this, _action); // .text:0045B660 ; bool __thiscall UIElementManager::DoVisibilityToggleAction(UIElementManager *this, unsigned int _action) .text:0045B660 ?DoVisibilityToggleAction@UIElementManager@@QAE_NK@Z

        // UIElementManager.DrawDirtyRegions:
        public void DrawDirtyRegions() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045B900)(ref this); // .text:0045B820 ; void __thiscall UIElementManager::DrawDirtyRegions(UIElementManager *this) .text:0045B820 ?DrawDirtyRegions@UIElementManager@@QAEXXZ

        // UIElementManager.DrawRegion:
        public void DrawRegion(UIElement* i_pElement, UIObject** io_pPrevObject) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UIObject**, void>)0x0045B8A0)(ref this, i_pElement, io_pPrevObject); // .text:0045B7C0 ; void __thiscall UIElementManager::DrawRegion(UIElementManager *this, UIElement *i_pElement, UIObject **io_pPrevObject) .text:0045B7C0 ?DrawRegion@UIElementManager@@QAEXPAVUIElement@@AAPAVUIObject@@@Z

        // UIElementManager.DrawRegionWithObject:
        public void DrawRegionWithObject(UIElement* i_pElementWithObject, UIObject** io_pPrevObject) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UIObject**, void>)0x0045AD80)(ref this, i_pElementWithObject, io_pPrevObject); // .text:0045AC70 ; void __thiscall UIElementManager::DrawRegionWithObject(UIElementManager *this, UIElement *i_pElementWithObject, UIObject **io_pPrevObject) .text:0045AC70 ?DrawRegionWithObject@UIElementManager@@QAEXPAVUIElement@@AAPAVUIObject@@@Z


        //public static ClientCombatSystem* GetCombatSystem() => ((delegate* unmanaged[Cdecl]<ClientCombatSystem*>)0x0056B210)(); // .text:0056A4D0 ; ClientCombatSystem *__cdecl ClientCombatSystem::GetCombatSystem() .text:0056A4D0 ?GetCombatSystem@ClientCombatSystem@@SAPAV1@XZ

        // UIElementManager.GetElement:
        public UIElement* GetElement(UInt32 _ID) => ((delegate* unmanaged[Thiscall]<UIElementManager, UInt32, UIElement*>)0x00459A00)(this, _ID); // .text:00459990 ; UIElement *__thiscall UIElementManager::GetElement(UIElementManager *this, unsigned int _ID) .text:00459990 ?GetElement@UIElementManager@@QAEPAVUIElement@@K@Z

        // UIElementManager.HandlePreferenceCallback:
        public static void HandlePreferenceCallback(PStringBase<char>* _Name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, void>)0x0045CD20)(_Name); // .text:0045CBA0 ; void __cdecl UIElementManager::HandlePreferenceCallback(PStringBase<char> *_Name) .text:0045CBA0 ?HandlePreferenceCallback@UIElementManager@@SAXABV?$PStringBase@D@@@Z

        // UIElementManager.Init:
        public Byte Init() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Byte>)0x0045EEF0)(ref this); // .text:0045EE10 ; bool __thiscall UIElementManager::Init(UIElementManager *this) .text:0045EE10 ?Init@UIElementManager@@QAE_NXZ

        // UIElementManager.KeyPressEvent:
        public void KeyPressEvent(UInt32 _action, Single _extent) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, Single, void>)0x0045C3E0)(ref this, _action, _extent); // .text:0045C300 ; void __thiscall UIElementManager::KeyPressEvent(UIElementManager *this, unsigned int _action, float _extent) .text:0045C300 ?KeyPressEvent@UIElementManager@@IAEXKM@Z

        // UIElementManager.MouseDownEvent:
        public void MouseDownEvent(UInt32 _action, Single _extent) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, Single, void>)0x0045DC40)(ref this, _action, _extent); // .text:0045DB60 ; void __thiscall UIElementManager::MouseDownEvent(UIElementManager *this, unsigned int _action, float _extent) .text:0045DB60 ?MouseDownEvent@UIElementManager@@IAEXKM@Z

        // UIElementManager.MouseLeaveEvent:
        public void MouseLeaveEvent() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045C380)(ref this); // .text:0045C2A0 ; void __thiscall UIElementManager::MouseLeaveEvent(UIElementManager *this) .text:0045C2A0 ?MouseLeaveEvent@UIElementManager@@QAEXXZ

        // UIElementManager.MouseMoveHandler:
        public void MouseMoveHandler(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, int, int, void>)0x0045E7F0)(ref this, i_xWindow, i_yWindow); // .text:0045E710 ; void __thiscall UIElementManager::MouseMoveHandler(UIElementManager *this, int i_xWindow, int i_yWindow) .text:0045E710 ?MouseMoveHandler@UIElementManager@@UAEXJJ@Z

        // UIElementManager.MouseUpEvent:
        public void MouseUpEvent(UInt32 _action, IInputActionCallback* i_pcCallback) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, IInputActionCallback*, void>)0x0045DE30)(ref this, _action, i_pcCallback); // .text:0045DD50 ; void __thiscall UIElementManager::MouseUpEvent(UIElementManager *this, unsigned int _action, IInputActionCallback *i_pcCallback) .text:0045DD50 ?MouseUpEvent@UIElementManager@@IAEXKPAVIInputActionCallback@@@Z

        // UIElementManager.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, InputEvent*, Byte>)0x0045E780)(ref this, i_evt); // .text:0045E6A0 ; bool __thiscall UIElementManager::OnAction(UIElementManager *this, InputEvent *i_evt) .text:0045E6A0 ?OnAction@UIElementManager@@UAE_NABVInputEvent@@@Z

        // UIElementManager.ProcessUIMessageRemovalData:
        public void ProcessUIMessageRemovalData() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x004596B0)(ref this); // .text:00459640 ; void __thiscall UIElementManager::ProcessUIMessageRemovalData(UIElementManager *this) .text:00459640 ?ProcessUIMessageRemovalData@UIElementManager@@IAEXXZ

        // UIElementManager.RefreshEvent:
        public Byte RefreshEvent() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Byte>)0x0045C610)(ref this); // .text:0045C530 ; bool __thiscall UIElementManager::RefreshEvent(UIElementManager *this) .text:0045C530 ?RefreshEvent@UIElementManager@@QAE_NXZ

        // UIElementManager.RegisterActivatable:
        public void RegisterActivatable(UIElement* _element) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045C4A0)(ref this, _element); // .text:0045C3C0 ; void __thiscall UIElementManager::RegisterActivatable(UIElementManager *this, UIElement *_element) .text:0045C3C0 ?RegisterActivatable@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.RegisterElementClass:
        public void RegisterElementClass(UInt32 _type, delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*> _createMethod) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>, void>)0x0045D310)(ref this, _type, _createMethod); // .text:0045D230 ; void __thiscall UIElementManager::RegisterElementClass(UIElementManager *this, unsigned int _type, UIElement *(__cdecl *_createMethod)(LayoutDesc *, ElementDesc *)) .text:0045D230 ?RegisterElementClass@UIElementManager@@QAEXKP6APAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z@Z

        // UIElementManager.RegisterElementForInputAction:
        public void RegisterElementForInputAction(UInt32 i_eInputAction, UIElement* i_pElement) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, UIElement*, void>)0x0045D8E0)(ref this, i_eInputAction, i_pElement); // .text:0045D800 ; void __thiscall UIElementManager::RegisterElementForInputAction(UIElementManager *this, unsigned int i_eInputAction, UIElement *i_pElement) .text:0045D800 ?RegisterElementForInputAction@UIElementManager@@QAEXKPAVUIElement@@@Z

        // UIElementManager.RegisterForElementMessage:
        public void RegisterForElementMessage(UIListener* _listener, UInt32 _elementID, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, UInt32, UInt32, void>)0x0045F380)(ref this, _listener, _elementID, _messageID); // .text:0045F2A0 ; void __thiscall UIElementManager::RegisterForElementMessage(UIElementManager *this, UIListener *_listener, unsigned int _elementID, unsigned int _messageID) .text:0045F2A0 ?RegisterForElementMessage@UIElementManager@@QAEXPAVUIListener@@KK@Z

        // UIElementManager.RegisterForGlobalMessage:
        public void RegisterForGlobalMessage(UIListener* _listener, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, UInt32, void>)0x0045E760)(ref this, _listener, _messageID); // .text:0045E680 ; void __thiscall UIElementManager::RegisterForGlobalMessage(UIElementManager *this, UIListener *_listener, unsigned int _messageID) .text:0045E680 ?RegisterForGlobalMessage@UIElementManager@@QAEXPAVUIListener@@K@Z

        // UIElementManager.RegisterForMessageInternal:
        public void RegisterForMessageInternal(UIListener* _pListener, AutoGrowHashTable<UInt32, SmartArray<UIMessageData>>* _pTable, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, AutoGrowHashTable<UInt32, SmartArray<UIMessageData>>*, UInt32, void>)0x0045DBA0)(ref this, _pListener, _pTable, _messageID); // .text:0045DAC0 ; void __thiscall UIElementManager::RegisterForMessageInternal(UIElementManager *this, UIListener *_pListener, AutoGrowHashTable<unsigned long,SmartArray<UIMessageData,1> > *_pTable, unsigned int _messageID) .text:0045DAC0 ?RegisterForMessageInternal@UIElementManager@@IBEXPAVUIListener@@PAV?$AutoGrowHashTable@KV?$SmartArray@UUIMessageData@@$00@@@@K@Z

        // UIElementManager.ReleaseMouseCapture:
        public void ReleaseMouseCapture(UIElement* i_pElement) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045D390)(ref this, i_pElement); // .text:0045D2B0 ; void __thiscall UIElementManager::ReleaseMouseCapture(UIElementManager *this, UIElement *i_pElement) .text:0045D2B0 ?ReleaseMouseCapture@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.RemoveAndDeleteRootElement:
        public void RemoveAndDeleteRootElement(UIElement* _element) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045C160)(ref this, _element); // .text:0045C080 ; void __thiscall UIElementManager::RemoveAndDeleteRootElement(UIElementManager *this, UIElement *_element) .text:0045C080 ?RemoveAndDeleteRootElement@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.ResetTooltip:
        public void ResetTooltip() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045C440)(ref this); // .text:0045C360 ; void __thiscall UIElementManager::ResetTooltip(UIElementManager *this) .text:0045C360 ?ResetTooltip@UIElementManager@@QAEXXZ

        // UIElementManager.SetCursor:
        public void SetCursor(UInt32 _cursorDID, int _xOffset, int _yOffset, Byte _default) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UInt32, int, int, Byte, void>)0x0045A910)(ref this, _cursorDID, _xOffset, _yOffset, _default); // .text:0045A800 ; void __thiscall UIElementManager::SetCursor(UIElementManager *this, IDClass<_tagDataID,32,0> _cursorDID, int _xOffset, int _yOffset, bool _default) .text:0045A800 ?SetCursor@UIElementManager@@QAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@JJ_N@Z

        // UIElementManager.SetDurationForCurrentTooltip:
        public void SetDurationForCurrentTooltip(Single i_secCustomDuration) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Single, void>)0x004593E0)(ref this, i_secCustomDuration); // .text:004592C0 ; void __thiscall UIElementManager::SetDurationForCurrentTooltip(UIElementManager *this, float i_secCustomDuration) .text:004592C0 ?SetDurationForCurrentTooltip@UIElementManager@@QAEXM@Z

        // UIElementManager.SetFocusElement:
        public void SetFocusElement(UIElement* _focusElement) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045B970)(ref this, _focusElement); // .text:0045B890 ; void __thiscall UIElementManager::SetFocusElement(UIElementManager *this, UIElement *_focusElement) .text:0045B890 ?SetFocusElement@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.SetMouseCapture:
        public void SetMouseCapture(UIElement* i_pElementToGetAllMouseMessages) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045D350)(ref this, i_pElementToGetAllMouseMessages); // .text:0045D270 ; void __thiscall UIElementManager::SetMouseCapture(UIElementManager *this, UIElement *i_pElementToGetAllMouseMessages) .text:0045D270 ?SetMouseCapture@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.SetVisible:
        public void SetVisible(Byte _visible) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, Byte, void>)0x00459440)(ref this, _visible); // .text:00459320 ; void __thiscall UIElementManager::SetVisible(UIElementManager *this, bool _visible) .text:00459320 ?SetVisible@UIElementManager@@QAEX_N@Z

        // UIElementManager.StartDragandDrop:
        public Byte StartDragandDrop(UIElement* _elem, int i_iClickX, int i_iClickY) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, int, int, Byte>)0x0045E120)(ref this, _elem, i_iClickX, i_iClickY); // .text:0045E040 ; bool __thiscall UIElementManager::StartDragandDrop(UIElementManager *this, UIElement *_elem, int i_iClickX, int i_iClickY) .text:0045E040 ?StartDragandDrop@UIElementManager@@QAE_NPAVUIElement@@JJ@Z

        // UIElementManager.StartHover:
        public void StartHover(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, int, int, void>)0x00459370)(ref this, i_xWindow, i_yWindow); // .text:00459250 ; void __thiscall UIElementManager::StartHover(UIElementManager *this, int i_xWindow, int i_yWindow) .text:00459250 ?StartHover@UIElementManager@@IAEXJJ@Z

        // UIElementManager.StartTooltip:
        public void StartTooltip(StringInfo* i_siToolTip, UIElement* i_pElementOwner, UInt32 i_idToolTip, UInt32 i_idTooltipLayout, UInt32 i_idToolTipText) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, StringInfo*, UIElement*, UInt32, UInt32, UInt32, void>)0x0045DF70)(ref this, i_siToolTip, i_pElementOwner, i_idToolTip, i_idTooltipLayout, i_idToolTipText); // .text:0045DE90 ; void __thiscall UIElementManager::StartTooltip(UIElementManager *this, StringInfo *i_siToolTip, UIElement *i_pElementOwner, unsigned int i_idToolTip, IDClass<_tagDataID,32,0> i_idTooltipLayout, unsigned int i_idToolTipText) .text:0045DE90 ?StartTooltip@UIElementManager@@QAEXABVStringInfo@@PAVUIElement@@KV?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIElementManager.StartTooltip:
        public void StartTooltip(UIElement* i_pElementOwner, UIElement* i_pElementTooltip) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, UIElement*, void>)0x00459770)(ref this, i_pElementOwner, i_pElementTooltip); // .text:00459700 ; void __thiscall UIElementManager::StartTooltip(UIElementManager *this, UIElement *i_pElementOwner, UIElement *i_pElementTooltip) .text:00459700 ?StartTooltip@UIElementManager@@QAEXPAVUIElement@@0@Z

        // UIElementManager.StopDragandDrop:
        public void StopDragandDrop() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x00459880)(ref this); // .text:00459810 ; void __thiscall UIElementManager::StopDragandDrop(UIElementManager *this) .text:00459810 ?StopDragandDrop@UIElementManager@@QAEXXZ

        // UIElementManager.StopHover:
        public void StopHover() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x004593A0)(ref this); // .text:00459280 ; void __thiscall UIElementManager::StopHover(UIElementManager *this) .text:00459280 ?StopHover@UIElementManager@@IAEXXZ

        // UIElementManager.SwitchMouseOver:
        public void SwitchMouseOver(UIElement* pCurMouseOver) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045B640)(ref this, pCurMouseOver); // .text:0045B560 ; void __thiscall UIElementManager::SwitchMouseOver(UIElementManager *this, UIElement *pCurMouseOver) .text:0045B560 ?SwitchMouseOver@UIElementManager@@IAEXPAVUIElement@@@Z

        // UIElementManager.UnRegisterElementForAllInputActions:
        public void UnRegisterElementForAllInputActions(UIElement* i_pElement) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x0045D970)(ref this, i_pElement); // .text:0045D890 ; void __thiscall UIElementManager::UnRegisterElementForAllInputActions(UIElementManager *this, UIElement *i_pElement) .text:0045D890 ?UnRegisterElementForAllInputActions@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.UnRegisterForAllMessages:
        public void UnRegisterForAllMessages(UIListener* _listener) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, void>)0x0045C210)(ref this, _listener); // .text:0045C130 ; void __thiscall UIElementManager::UnRegisterForAllMessages(UIElementManager *this, UIListener *_listener) .text:0045C130 ?UnRegisterForAllMessages@UIElementManager@@QAEXPAVUIListener@@@Z

        // UIElementManager.UnRegisterForAllMessagesInternal:
        public void UnRegisterForAllMessagesInternal(UIListener* _pListener, SmartArray<UIMessageData>* _uiListenerArray) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, SmartArray<UIMessageData>*, void>)0x0045B5D0)(ref this, _pListener, _uiListenerArray); // .text:0045B4F0 ; void __thiscall UIElementManager::UnRegisterForAllMessagesInternal(UIElementManager *this, UIListener *_pListener, SmartArray<UIMessageData,1> *_uiListenerArray) .text:0045B4F0 ?UnRegisterForAllMessagesInternal@UIElementManager@@IAEXPAVUIListener@@AAV?$SmartArray@UUIMessageData@@$00@@@Z

        // UIElementManager.UnRegisterForElementMessage:
        public void UnRegisterForElementMessage(UIListener* _listener, UInt32 _elementID, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, UInt32, UInt32, void>)0x0045C1B0)(ref this, _listener, _elementID, _messageID); // .text:0045C0D0 ; void __thiscall UIElementManager::UnRegisterForElementMessage(UIElementManager *this, UIListener *_listener, unsigned int _elementID, unsigned int _messageID) .text:0045C0D0 ?UnRegisterForElementMessage@UIElementManager@@QAEXPAVUIListener@@KK@Z

        // UIElementManager.UnRegisterForGlobalMessage:
        public void UnRegisterForGlobalMessage(UIListener* _listener, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, UInt32, void>)0x0045C1F0)(ref this, _listener, _messageID); // .text:0045C110 ; void __thiscall UIElementManager::UnRegisterForGlobalMessage(UIElementManager *this, UIListener *_listener, unsigned int _messageID) .text:0045C110 ?UnRegisterForGlobalMessage@UIElementManager@@QAEXPAVUIListener@@K@Z

        // UIElementManager.UnRegisterForMessageInternal:
        public void UnRegisterForMessageInternal(UIListener* _pListener, AutoGrowHashTable<UInt32, SmartArray<UIMessageData>>* _pTable, UInt32 _messageID) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIListener*, AutoGrowHashTable<UInt32, SmartArray<UIMessageData>>*, UInt32, void>)0x0045B540)(ref this, _pListener, _pTable, _messageID); // .text:0045B460 ; void __thiscall UIElementManager::UnRegisterForMessageInternal(UIElementManager *this, UIListener *_pListener, AutoGrowHashTable<unsigned long,SmartArray<UIMessageData,1> > *_pTable, unsigned int _messageID) .text:0045B460 ?UnRegisterForMessageInternal@UIElementManager@@IAEXPAVUIListener@@PAV?$AutoGrowHashTable@KV?$SmartArray@UUIMessageData@@$00@@@@K@Z

        // UIElementManager.UnregisterActivatable:
        public void UnregisterActivatable(UIElement* _element) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, UIElement*, void>)0x00459960)(ref this, _element); // .text:004598F0 ; void __thiscall UIElementManager::UnregisterActivatable(UIElementManager *this, UIElement *_element) .text:004598F0 ?UnregisterActivatable@UIElementManager@@QAEXPAVUIElement@@@Z

        // UIElementManager.UpdateMouseOver:
        public void UpdateMouseOver(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref UIElementManager, int, int, void>)0x0045C390)(ref this, i_xWindow, i_yWindow); // .text:0045C2B0 ; void __thiscall UIElementManager::UpdateMouseOver(UIElementManager *this, int i_xWindow, int i_yWindow) .text:0045C2B0 ?UpdateMouseOver@UIElementManager@@IAEXJJ@Z

        // UIElementManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref UIElementManager, void>)0x0045D0B0)(ref this); // .text:0045CFD0 ; void __thiscall UIElementManager::UseTime(UIElementManager *this) .text:0045CFD0 ?UseTime@UIElementManager@@QAEXXZ

        // Globals:
        public static UIElementManager* s_pInstance = *(UIElementManager**)0x0083E03C; // .data:0083D03C ; UIElementManager *UIElementManager::s_pInstance .data:0083D03C ?s_pInstance@UIElementManager@@1PAV1@A
    }
    public unsafe struct UIMessageData {
        // Struct:
        public UIListener* pListener;
        public int nCount;
        public override string ToString() => $"pListener:->(UIListener*)0x{(int)pListener:X8}, nCount(int):{nCount}";
    }
    public unsafe struct UIMessageRemovalData {
        // Struct:
        public UIListener* pListener;
        public SmartArray<UIMessageData>* pListenerArray;
        public override string ToString() => $"pListener:->(UIListener*)0x{(int)pListener:X8}, pListenerArray:->(SmartArray<UIMessageData,1>*)0x{(int)pListenerArray:X8}";
    }
    public unsafe struct ContextMenu {
        // Struct:
        public UIListener a0;
        public InstanceID m_weenieTarget;
        public UIElement* m_pParentDisplay;
        public UIElement* m_pRoot;
        public SmartArray<ContextMenuData> m_data;
        public StringInfo m_siInfoText;
        public Byte m_bDrawInactive;
        public Byte m_initted;
        public UIElement* m_display;
        public UIElement_ListBox* m_listbox;
        public UIElement* m_mouseChild;
        public ContextMenu* m_pOpenSubMenu;
        public Double m_mouseTime;
        public Single m_openDelay;
        public Byte m_open;
        public Byte m_bTopLevel;
        public Byte m_bUpperLeftSet;
        public Byte m_bLowerLeftSet;
        public int m_iX0;
        public int m_iY0;
        public override string ToString() => $"a0(UIListener):{a0}, m_weenieTarget(InstanceID):{m_weenieTarget}, m_pParentDisplay:->(UIElement*)0x{(int)m_pParentDisplay:X8}, m_pRoot:->(UIElement*)0x{(int)m_pRoot:X8}, m_data(SmartArray<ContextMenuData,1>):{m_data}, m_siInfoText(StringInfo):{m_siInfoText}, m_bDrawInactive:{m_bDrawInactive:X2}, m_initted:{m_initted:X2}, m_display:->(UIElement*)0x{(int)m_display:X8}, m_listbox:->(UIElement_ListBox*)0x{(int)m_listbox:X8}, m_mouseChild:->(UIElement*)0x{(int)m_mouseChild:X8}, m_pOpenSubMenu:->(ContextMenu*)0x{(int)m_pOpenSubMenu:X8}, m_mouseTime:{m_mouseTime:n5}, m_openDelay:{m_openDelay:n5}, m_open:{m_open:X2}, m_bTopLevel:{m_bTopLevel:X2}, m_bUpperLeftSet:{m_bUpperLeftSet:X2}, m_bLowerLeftSet:{m_bLowerLeftSet:X2}, m_iX0(int):{m_iX0}, m_iY0(int):{m_iY0}";

        // Functions:

        // ContextMenu.Close:
        // public Byte Close() => ((delegate* unmanaged[Thiscall]<ref ContextMenu, Byte>)0xDEADBEEF)(ref this); // .text:00474B70 ; bool __thiscall ContextMenu::Close(ContextMenu *this) .text:00474B70 ?Close@ContextMenu@@QAE_NXZ

        // ContextMenu.SetVisible:
        public void SetVisible(Byte _visible) => ((delegate* unmanaged[Thiscall]<ref ContextMenu, Byte, void>)0x00474FF0)(ref this, _visible); // .text:00474C30 ; void __thiscall ContextMenu::SetVisible(ContextMenu *this, bool _visible) .text:00474C30 ?SetVisible@ContextMenu@@QAEX_N@Z
    }
    public unsafe struct InstanceID {
        // Struct:
        public _InstanceID a0;
        public override string ToString() => a0.ToString();
    }
    public unsafe struct _InstanceID {
        // Struct:
        public UInt64 id;
        public override string ToString() => $"id(UInt64):{id}";
    }
    public unsafe struct ContextMenuData {
        // Struct:
        public ContextMenuData.Vtbl* vfptr;
        public UInt32 m_entryType;
        public StringInfo m_siText;
        public UInt32 m_didHandler;
        public UInt32 m_ahtHint;
        public ContextMenu* m_subMenu;
        public Byte m_bActive;
        public Byte m_bBoolEntry;
        public Byte m_bBoolEntryActive;
        public UInt32 m_didIcon;
        public override string ToString() => $"vfptr:->(ContextMenuData.Vtbl*)0x{(int)vfptr:X8}, m_entryType:{m_entryType:X8}, m_siText(StringInfo):{m_siText}, m_didHandler:{m_didHandler:X8}, m_ahtHint:{m_ahtHint:X8}, m_subMenu:->(ContextMenu*)0x{(int)m_subMenu:X8}, m_bActive:{m_bActive:X2}, m_bBoolEntry:{m_bBoolEntry:X2}, m_bBoolEntryActive:{m_bBoolEntryActive:X2}, m_didIcon:{m_didIcon:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ContextMenuData*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(ContextMenuData *this, unsigned int);
        }
    }



}