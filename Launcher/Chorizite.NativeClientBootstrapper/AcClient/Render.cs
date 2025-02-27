using Chorizite.NativeClientBootstrapper.Lib;
using System;

namespace AcClient {
    public unsafe struct Render {
        // Struct:
        public Render.Vtbl* vfptr;
        public RenderConfig m_Config;
        public UInt32 m_nDisplayAdapter;
        public SmartArray<RenderDisplayModeType> m_DisplayModes;
        public override string ToString() => $"vfptr:->(Render.Vtbl*)0x{(int)vfptr:X8}, m_Config(RenderConfig):{m_Config}, m_nDisplayAdapter:{m_nDisplayAdapter:X8}, m_DisplayModes(SmartArray<RenderDisplayModeType,1>):{m_DisplayModes}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<Render*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(Render *this, unsigned int);
            public fixed int gap4[8];
            public static delegate* unmanaged[Thiscall]<Render*, RenderDevice*> CreateRenderDevice; // RenderDevice *(__thiscall *CreateRenderDevice)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, int> InitInternal; // int (__thiscall *InitInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, void> CleanupInternal; // void (__thiscall *CleanupInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, int, int, int, int, int> Set3DViewInternal; // int (__thiscall *Set3DViewInternal)(Render *this, int, int, int, int);
            public static delegate* unmanaged[Thiscall]<Render*, Single, void> SetFOVInternal; // void (__thiscall *SetFOVInternal)(Render *this, float);
            public static delegate* unmanaged[Thiscall]<Render*, Single, Single> GetFogAdjustment; // float (__thiscall *GetFogAdjustment)(Render *this, float);
            public static delegate* unmanaged[Thiscall]<Render*, void> SetupViewportInternal; // void (__thiscall *SetupViewportInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, void> UpdateLightsInternal; // void (__thiscall *UpdateLightsInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, CMaterial*, void> SetMaterialInternal; // void (__thiscall *SetMaterialInternal)(Render *this, CMaterial *);
            public static delegate* unmanaged[Thiscall]<Render*, int, Position*, void> positionPushInternal; // void (__thiscall *positionPushInternal)(Render *this, int, Position *);
            public static delegate* unmanaged[Thiscall]<Render*, int> positionPopInternal; // int (__thiscall *positionPopInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, void> CalcObjectMatrixInternal; // void (__thiscall *CalcObjectMatrixInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, Matrix4*> GetObjectMatrixInternal; // Matrix4 *(__thiscall *GetObjectMatrixInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, void> polyListFinishInternal; // void (__thiscall *polyListFinishInternal)(Render *this);
            public static delegate* unmanaged[Thiscall]<Render*, AC1Legacy.Vector3*, Vec2D*, BoundingType> xformPointInternal; // BoundingType (__thiscall *xformPointInternal)(Render *this, AC1Legacy::Vector3 *, Vec2D *);
            public override string ToString() => $"gap4[8](fixed int):{gap4[8]}";
        }
        public unsafe struct MouseSelectData {
            public Byte bFoundPolygon;
            public Double fClosestPolygon;
            public UInt32 PolygonID;
            public int PolygonIndex;
            public Byte bFoundSphere;
            public Double fClosestSphere;
            public UInt32 SphereID;
            public int SphereIndex;
            public override string ToString() => $"bFoundPolygon:{bFoundPolygon:X2}, fClosestPolygon:{fClosestPolygon:n5}, PolygonID:{PolygonID:X8}, PolygonIndex(int):{PolygonIndex}, bFoundSphere:{bFoundSphere:X2}, fClosestSphere:{fClosestSphere:n5}, SphereID:{SphereID:X8}, SphereIndex(int):{SphereIndex}";
        }
        // Enums:
        public enum LightingType : UInt32 {
            DYNAMIC_LIGHTING = 0x0,
            STATIC_LIGHTING = 0x1,
            FULL_LIGHTING = 0x2,
            FORCE_LightingType_32_BIT = 0x7FFFFFFF,
        };

        // Functions:

        // Render.Begin:
        public void Begin() => ((delegate* unmanaged[Thiscall]<ref Render, void>)0x0054EBB0)(ref this); // .text:0054DFA0 ; void __thiscall Render::Begin(Render *this) .text:0054DFA0 ?Begin@Render@@AAEXXZ

        // Render.CC_SetGraphicsQuality:
        // public static Byte CC_SetGraphicsQuality(PStringBaseArray<char>* _Args) => ((delegate* unmanaged[Cdecl]<PStringBaseArray<char>*, Byte>)0xDEADBEEF)(_Args); // .text:0054E900 ; bool __cdecl Render::CC_SetGraphicsQuality(PStringBaseArray<char> *_Args) .text:0054E900 ?CC_SetGraphicsQuality@Render@@KA_NABV?$PStringBaseArray@D@@@Z

        // Render.CalcDegLevel:
        // public static void CalcDegLevel() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0054CAF0 ; void __cdecl Render::CalcDegLevel() .text:0054CAF0 ?CalcDegLevel@Render@@SAXXZ

        // Render.CalcObjectMatrix:
        public static void CalcObjectMatrix() => ((delegate* unmanaged[Cdecl]<void>)0x0054C9F0)(); // .text:0054BDE0 ; void __cdecl Render::CalcObjectMatrix() .text:0054BDE0 ?CalcObjectMatrix@Render@@SAXXZ

        // Render.CheckForLostDevice:
        public static void CheckForLostDevice() => ((delegate* unmanaged[Cdecl]<void>)0x0054F4A0)(); // .text:0054E890 ; void __cdecl Render::CheckForLostDevice() .text:0054E890 ?CheckForLostDevice@Render@@SAXXZ

        // Render.CreateIndexBuffer:
        // public static RenderIndexBuffer* CreateIndexBuffer() => ((delegate* unmanaged[Cdecl]<RenderIndexBuffer*>)0xDEADBEEF)(); // .text:0054C690 ; RenderIndexBuffer *__cdecl Render::CreateIndexBuffer() .text:0054C690 ?CreateIndexBuffer@Render@@SAPAVRenderIndexBuffer@@XZ

        // Render.DetermineOverallGraphicsQuality:
        // public static UInt32 DetermineOverallGraphicsQuality() => ((delegate* unmanaged[Cdecl]<UInt32>)0xDEADBEEF)(); // .text:0054B170 ; unsigned int __cdecl Render::DetermineOverallGraphicsQuality() .text:0054B170 ?DetermineOverallGraphicsQuality@Render@@SAKXZ

        // Render.End:
        public void End() => ((delegate* unmanaged[Thiscall]<ref Render, void>)0x0054EBC0)(ref this); // .text:0054DFB0 ; void __thiscall Render::End(Render *this) .text:0054DFB0 ?End@Render@@AAEXXZ

        // Render.FlushGraphicsResources:
        public static Byte FlushGraphicsResources() => ((delegate* unmanaged[Cdecl]<Byte>)0x0054E260)(); // .text:0054D650 ; bool __cdecl Render::FlushGraphicsResources() .text:0054D650 ?FlushGraphicsResources@Render@@SA_NXZ

        // Render.GRPCallback_OnRenderPreferenceChanged:
        // public static void GRPCallback_OnRenderPreferenceChanged(PStringBase<char>* _Name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, void>)0xDEADBEEF)(_Name); // .text:0054C6F0 ; void __cdecl Render::GRPCallback_OnRenderPreferenceChanged(PStringBase<char> *_Name) .text:0054C6F0 ?GRPCallback_OnRenderPreferenceChanged@Render@@SAXABV?$PStringBase@D@@@Z

        // Render.GetFogAdjustment:
        public Single GetFogAdjustment(Single fog_distance) => ((delegate* unmanaged[Thiscall]<ref Render, Single, Single>)0x0058BD30)(ref this, fog_distance); // .text:0058AF00 ; float __thiscall Render::GetFogAdjustment(Render *this, float fog_distance) .text:0058AF00 ?GetFogAdjustment@Render@@MBEMM@Z

        // Render.GetFramerate:
        // public static Single GetFramerate() => ((delegate* unmanaged[Cdecl]<Single>)0xDEADBEEF)(); // .text:0054C730 ; float __cdecl Render::GetFramerate() .text:0054C730 ?GetFramerate@Render@@SAMXZ

        // Render.GetMouseSelectionObjectID:
        public static UInt32 GetMouseSelectionObjectID() => ((delegate* unmanaged[Cdecl]<UInt32>)0x0054D560)(); // .text:0054C950 ; unsigned int __cdecl Render::GetMouseSelectionObjectID() .text:0054C950 ?GetMouseSelectionObjectID@Render@@SAKXZ

        // Render.GetMouseSelectionPartIndex:
        public static int GetMouseSelectionPartIndex() => ((delegate* unmanaged[Cdecl]<int>)0x0054D590)(); // .text:0054C980 ; int __cdecl Render::GetMouseSelectionPartIndex() .text:0054C980 ?GetMouseSelectionPartIndex@Render@@SAHXZ

        // Render.GetObjectMatrix:
        public static Matrix4* GetObjectMatrix() => ((delegate* unmanaged[Cdecl]<Matrix4*>)0x0054CA00)(); // .text:0054BDF0 ; Matrix4 *__cdecl Render::GetObjectMatrix() .text:0054BDF0 ?GetObjectMatrix@Render@@SAABVMatrix4@@XZ

        // Render.GetViewerBBox:
        public static void GetViewerBBox(CSphere* sphere, AC1Legacy.Vector3* top_left, AC1Legacy.Vector3* bottom_right) => ((delegate* unmanaged[Cdecl]<CSphere*, AC1Legacy.Vector3*, AC1Legacy.Vector3*, void>)0x0054C010)(sphere, top_left, bottom_right); // .text:0054B400 ; void __cdecl Render::GetViewerBBox(CSphere *sphere, AC1Legacy::Vector3 *top_left, AC1Legacy::Vector3 *bottom_right) .text:0054B400 ?GetViewerBBox@Render@@SAXABVCSphere@@AAVVector3@AC1Legacy@@1@Z

        // Render.GfxObjUnderSelectionRay:
        // public static Byte GfxObjUnderSelectionRay(CGfxObj* mesh) => ((delegate* unmanaged[Cdecl]<CGfxObj*, Byte>)0xDEADBEEF)(mesh); // .text:0054C740 ; bool __cdecl Render::GfxObjUnderSelectionRay(CGfxObj *mesh) .text:0054C740 ?GfxObjUnderSelectionRay@Render@@SA_NPBVCGfxObj@@@Z

        // Render.Init:
        public static int Init() => ((delegate* unmanaged[Cdecl]<int>)0x0054E6A0)(); // .text:0054DA90 ; int __cdecl Render::Init() .text:0054DA90 ?Init@Render@@SAHXZ

        // Render.LinkRGRCallback:
        //public static Byte LinkRGRCallback(Byte a0, __cdecl* _RGRCallback) => ((delegate* unmanaged[Cdecl]<Byte, __cdecl*, Byte>)0x0054FC10)(a0, _RGRCallback); // .text:0054F000 ; bool __cdecl Render::LinkRGRCallback(bool (__cdecl *_RGRCallback)()) .text:0054F000 ?LinkRGRCallback@Render@@SA_NP6A_NXZ@Z

        // Render.RestartDevice:
        // public static Byte RestartDevice(UInt32 _nDisplayAdapter, RenderDevicePresentation* _presentation, RenderDeviceConfig* _deviceConfig) => ((delegate* unmanaged[Cdecl]<UInt32, RenderDevicePresentation*, RenderDeviceConfig*, Byte>)0xDEADBEEF)(_nDisplayAdapter, _presentation, _deviceConfig); // .text:0054C5F0 ; bool __cdecl Render::RestartDevice(const unsigned int _nDisplayAdapter, RenderDevicePresentation *_presentation, RenderDeviceConfig *_deviceConfig) .text:0054C5F0 ?RestartDevice@Render@@KA_NKAAVRenderDevicePresentation@@AAVRenderDeviceConfig@@@Z

        // Render.RestartRenderingSystem:
        // public static Byte RestartRenderingSystem(RenderDevicePresentation* _presentation, RenderDeviceConfig* _config) => ((delegate* unmanaged[Cdecl]<RenderDevicePresentation*, RenderDeviceConfig*, Byte>)0xDEADBEEF)(_presentation, _config); // .text:0054D6B0 ; bool __cdecl Render::RestartRenderingSystem(RenderDevicePresentation *_presentation, RenderDeviceConfig *_config) .text:0054D6B0 ?RestartRenderingSystem@Render@@SA_NAAVRenderDevicePresentation@@AAVRenderDeviceConfig@@@Z

        // Render.RestartRenderingSystem:
        // public static Byte RestartRenderingSystem() => ((delegate* unmanaged[Cdecl]<Byte>)0xDEADBEEF)(); // .text:0054D710 ; bool __cdecl Render::RestartRenderingSystem() .text:0054D710 ?RestartRenderingSystem@Render@@SA_NXZ

        // Render.SafelyStopUsingAndReleaseTexture:
        // public static void SafelyStopUsingAndReleaseTexture(RenderTexture** io_pTexture) => ((delegate* unmanaged[Cdecl]<RenderTexture**, void>)0xDEADBEEF)(io_pTexture); // .text:0054C6D0 ; void __cdecl Render::SafelyStopUsingAndReleaseTexture(RenderTexture **io_pTexture) .text:0054C6D0 ?SafelyStopUsingAndReleaseTexture@Render@@SAXAAPAVRenderTexture@@@Z

        // Render.Set3DView:
        public static int Set3DView(int _x, int _y, int _width, int _height) => ((delegate* unmanaged[Cdecl]<int, int, int, int, int>)0x0054BE30)(_x, _y, _width, _height); // .text:0054B220 ; int __cdecl Render::Set3DView(int _x, int _y, int _width, int _height) .text:0054B220 ?Set3DView@Render@@SAHHHHH@Z

        // Render.Set3DViewInternal:
        public int Set3DViewInternal(int _x, int _y, int _width, int _height) => ((delegate* unmanaged[Thiscall]<ref Render, int, int, int, int, int>)0x0054FC80)(ref this, _x, _y, _width, _height); // .text:0054F070 ; int __thiscall Render::Set3DViewInternal(Render *this, int _x, int _y, int _width, int _height) .text:0054F070 ?Set3DViewInternal@Render@@MAEHHHHH@Z

        // Render.SetBuildingDetailSurface:
        public static void SetBuildingDetailSurface(CSurface* s) => ((delegate* unmanaged[Cdecl]<CSurface*, void>)0x0054C3E0)(s); // .text:0054B7D0 ; void __cdecl Render::SetBuildingDetailSurface(CSurface *s) .text:0054B7D0 ?SetBuildingDetailSurface@Render@@SAXPAVCSurface@@@Z

        // Render.SetBuildingDetailTiling:
        public static void SetBuildingDetailTiling(Single tiling) => ((delegate* unmanaged[Cdecl]<Single, void>)0x0054C430)(tiling); // .text:0054B820 ; void __cdecl Render::SetBuildingDetailTiling(float tiling) .text:0054B820 ?SetBuildingDetailTiling@Render@@SAXM@Z

        // Render.SetDegradeLevelInternal:
        // public static int SetDegradeLevelInternal(Single new_deg_mul) => ((delegate* unmanaged[Cdecl]<Single, int>)0xDEADBEEF)(new_deg_mul); // .text:0054C3C0 ; int __cdecl Render::SetDegradeLevelInternal(float new_deg_mul) .text:0054C3C0 ?SetDegradeLevelInternal@Render@@KAHM@Z

        // Render.SetEnvironmentDetailSurface:
        public static void SetEnvironmentDetailSurface(CSurface* s) => ((delegate* unmanaged[Cdecl]<CSurface*, void>)0x0054C3F0)(s); // .text:0054B7E0 ; void __cdecl Render::SetEnvironmentDetailSurface(CSurface *s) .text:0054B7E0 ?SetEnvironmentDetailSurface@Render@@SAXPAVCSurface@@@Z

        // Render.SetEnvironmentDetailTiling:
        public static void SetEnvironmentDetailTiling(Single tiling) => ((delegate* unmanaged[Cdecl]<Single, void>)0x0054C420)(tiling); // .text:0054B810 ; void __cdecl Render::SetEnvironmentDetailTiling(float tiling) .text:0054B810 ?SetEnvironmentDetailTiling@Render@@SAXM@Z

        // Render.SetFOVInternal:
        public void SetFOVInternal(Single _radians) => ((delegate* unmanaged[Thiscall]<ref Render, Single, void>)0x0054BF50)(ref this, _radians); // .text:0054B340 ; void __thiscall Render::SetFOVInternal(Render *this, float _radians) .text:0054B340 ?SetFOVInternal@Render@@MAEXM@Z

        // Render.SetFOVRad:
        public static int SetFOVRad(Single _radians) => ((delegate* unmanaged[Cdecl]<Single, int>)0x0054BEE0)(_radians); // .text:0054B2D0 ; int __cdecl Render::SetFOVRad(float _radians) .text:0054B2D0 ?SetFOVRad@Render@@SAHM@Z

        // Render.SetLandscapeDetailSurface:
        public static void SetLandscapeDetailSurface(CSurface* s) => ((delegate* unmanaged[Cdecl]<CSurface*, void>)0x0054C3D0)(s); // .text:0054B7C0 ; void __cdecl Render::SetLandscapeDetailSurface(CSurface *s) .text:0054B7C0 ?SetLandscapeDetailSurface@Render@@SAXPAVCSurface@@@Z

        // Render.SetLandscapeDetailTiling:
        public static void SetLandscapeDetailTiling(Single tiling) => ((delegate* unmanaged[Cdecl]<Single, void>)0x0054C410)(tiling); // .text:0054B800 ; void __cdecl Render::SetLandscapeDetailTiling(float tiling) .text:0054B800 ?SetLandscapeDetailTiling@Render@@SAXM@Z

        // Render.SetObjectDetailSurface:
        public static void SetObjectDetailSurface(CSurface* s) => ((delegate* unmanaged[Cdecl]<CSurface*, void>)0x0054C400)(s); // .text:0054B7F0 ; void __cdecl Render::SetObjectDetailSurface(CSurface *s) .text:0054B7F0 ?SetObjectDetailSurface@Render@@SAXPAVCSurface@@@Z

        // Render.SetObjectDetailTiling:
        public static void SetObjectDetailTiling(Single tiling) => ((delegate* unmanaged[Cdecl]<Single, void>)0x0054C440)(tiling); // .text:0054B830 ; void __cdecl Render::SetObjectDetailTiling(float tiling) .text:0054B830 ?SetObjectDetailTiling@Render@@SAXM@Z

        // Render.SetObjectScale:
        public static void SetObjectScale(Vector3* scale) => ((delegate* unmanaged[Cdecl]<Vector3*, void>)0x0050DF00)(scale); // .text:0050D430 ; void __cdecl Render::SetObjectScale(Vector3 *scale) .text:0050D430 ?SetObjectScale@Render@@SAXABVVector3@@@Z

        // Render.SetOverallGraphicsQuality:
        public static void SetOverallGraphicsQuality(UInt32 _Level) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x0054BC30)(_Level); // .text:0054B020 ; void __cdecl Render::SetOverallGraphicsQuality(unsigned int _Level) .text:0054B020 ?SetOverallGraphicsQuality@Render@@SAXK@Z

        // Render.SetSurfaceArray:
        public static void SetSurfaceArray(CSurface** surf_array) => ((delegate* unmanaged[Cdecl]<CSurface**, void>)0x0054C3C0)(surf_array); // .text:0054B7B0 ; void __cdecl Render::SetSurfaceArray(CSurface **surf_array) .text:0054B7B0 ?SetSurfaceArray@Render@@SAXPAPAVCSurface@@@Z

        // Render.ShouldDropHighDetail:
        // public static Byte ShouldDropHighDetail() => ((delegate* unmanaged[Cdecl]<Byte>)0xDEADBEEF)(); // .text:0054C700 ; bool __cdecl Render::ShouldDropHighDetail() .text:0054C700 ?ShouldDropHighDetail@Render@@SA_NXZ

        // Render.Shutdown:
        public void Shutdown() => ((delegate* unmanaged[Thiscall]<ref Render, void>)0x0054F3B0)(ref this); // .text:0054E7A0 ; void __thiscall Render::Shutdown(Render *this) .text:0054E7A0 ?Shutdown@Render@@UAEXXZ

        // Render.ShutdownDevice:
        // public static void ShutdownDevice() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0054C550 ; void __cdecl Render::ShutdownDevice() .text:0054C550 ?ShutdownDevice@Render@@KAXXZ

        // Render.ShutdownRenderingSystem:
        public static void ShutdownRenderingSystem() => ((delegate* unmanaged[Cdecl]<void>)0x0054D190)(); // .text:0054C580 ; void __cdecl Render::ShutdownRenderingSystem() .text:0054C580 ?ShutdownRenderingSystem@Render@@SAXXZ

        // Render.Startup:
        public Byte Startup(RenderConfig* _config) => ((delegate* unmanaged[Thiscall]<ref Render, RenderConfig*, Byte>)0x0054F5C0)(ref this, _config); // .text:0054E9B0 ; bool __thiscall Render::Startup(Render *this, RenderConfig *_config) .text:0054E9B0 ?Startup@Render@@UAE_NABVRenderConfig@@@Z

        // Render.StartupDevice:
        // public static Byte StartupDevice(UInt32 _nDisplayAdapter, RenderDevicePresentation* _presentation, RenderDeviceConfig* _deviceConfig) => ((delegate* unmanaged[Cdecl]<UInt32, RenderDevicePresentation*, RenderDeviceConfig*, Byte>)0xDEADBEEF)(_nDisplayAdapter, _presentation, _deviceConfig); // .text:0054C500 ; bool __cdecl Render::StartupDevice(const unsigned int _nDisplayAdapter, RenderDevicePresentation *_presentation, RenderDeviceConfig *_deviceConfig) .text:0054C500 ?StartupDevice@Render@@KA_NKABVRenderDevicePresentation@@ABVRenderDeviceConfig@@@Z

        // Render.StartupRenderingDevice:
        public static Byte StartupRenderingDevice(RenderDevicePresentation* _presentation, RenderDeviceConfig* _deviceConfig) => ((delegate* unmanaged[Cdecl]<RenderDevicePresentation*, RenderDeviceConfig*, Byte>)0x0054E1A0)(_presentation, _deviceConfig); // .text:0054D590 ; bool __cdecl Render::StartupRenderingDevice(RenderDevicePresentation *_presentation, RenderDeviceConfig *_deviceConfig) .text:0054D590 ?StartupRenderingDevice@Render@@SA_NABVRenderDevicePresentation@@ABVRenderDeviceConfig@@@Z

        // Render.StartupRenderingSystem:
        public static Byte StartupRenderingSystem(RenderConfig* _config) => ((delegate* unmanaged[Cdecl]<RenderConfig*, Byte>)0x0054D0C0)(_config); // .text:0054C4B0 ; bool __cdecl Render::StartupRenderingSystem(RenderConfig *_config) .text:0054C4B0 ?StartupRenderingSystem@Render@@SA_NABVRenderConfig@@@Z

        // Render.UnlinkRGRCallback:
        //public static void UnlinkRGRCallback(Byte a0, __cdecl* _RGRCallback) => ((delegate* unmanaged[Cdecl]<Byte, __cdecl*, void>)0x0054E370)(a0, _RGRCallback); // .text:0054D760 ; void __cdecl Render::UnlinkRGRCallback(bool (__cdecl *_RGRCallback)()) .text:0054D760 ?UnlinkRGRCallback@Render@@SAXP6A_NXZ@Z

        // Render.UpdateFromPreferences:
        // public static void UpdateFromPreferences() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0054D850 ; void __cdecl Render::UpdateFromPreferences() .text:0054D850 ?UpdateFromPreferences@Render@@SAXXZ

        // Render.add_active_light:
        public static void add_active_light(int index, int lightClass) => ((delegate* unmanaged[Cdecl]<int, int, void>)0x0054CBC0)(index, lightClass); // .text:0054BFB0 ; void __cdecl Render::add_active_light(int index, int lightClass) .text:0054BFB0 ?add_active_light@Render@@KAXHH@Z

        // Render.add_dynamic_light:
        public static void add_dynamic_light(LIGHTINFO* light_info, UInt32 cell_id, Frame* frame) => ((delegate* unmanaged[Cdecl]<LIGHTINFO*, UInt32, Frame*, void>)0x0054E030)(light_info, cell_id, frame); // .text:0054D420 ; void __cdecl Render::add_dynamic_light(LIGHTINFO *light_info, const unsigned int cell_id, Frame *frame) .text:0054D420 ?add_dynamic_light@Render@@SAXABVLIGHTINFO@@KABVFrame@@@Z

        // Render.add_static_light:
        public static void add_static_light(LIGHTINFO* light_info, UInt32 cell_id, Frame* frame) => ((delegate* unmanaged[Cdecl]<LIGHTINFO*, UInt32, Frame*, void>)0x0054DFF0)(light_info, cell_id, frame); // .text:0054D3E0 ; void __cdecl Render::add_static_light(LIGHTINFO *light_info, const unsigned int cell_id, Frame *frame) .text:0054D3E0 ?add_static_light@Render@@SAXABVLIGHTINFO@@KABVFrame@@@Z

        // Render.block_check:
        public static BoundingType block_check(ViewIntervalType* corner1, ViewIntervalType* corner2, ViewIntervalType* corner3, ViewIntervalType* corner4, Single max_height, Single min_height) => ((delegate* unmanaged[Cdecl]<ViewIntervalType*, ViewIntervalType*, ViewIntervalType*, ViewIntervalType*, Single, Single, BoundingType>)0x0054E860)(corner1, corner2, corner3, corner4, max_height, min_height); // .text:0054DC50 ; BoundingType __cdecl Render::block_check(ViewIntervalType *corner1, ViewIntervalType *corner2, ViewIntervalType *corner3, ViewIntervalType *corner4, float max_height, float min_height) .text:0054DC50 ?block_check@Render@@SA?AW4BoundingType@@AAUViewIntervalType@@000MM@Z

        // Render.block_plane_check:
        // public static BoundingType block_plane_check(Single corner1, Single corner2, Single corner3, Single corner4, Single min, Single max) => ((delegate* unmanaged[Cdecl]<Single, Single, Single, Single, Single, Single, BoundingType>)0xDEADBEEF)(corner1, corner2, corner3, corner4, min, max); // .text:0054D060 ; BoundingType __cdecl Render::block_plane_check(float corner1, float corner2, float corner3, float corner4, float min, float max) .text:0054D060 ?block_plane_check@Render@@KA?AW4BoundingType@@MMMMMM@Z

        // Render.clear_selection_cursor:
        public static void clear_selection_cursor() => ((delegate* unmanaged[Cdecl]<void>)0x0054C3A0)(); // .text:0054B790 ; void __cdecl Render::clear_selection_cursor() .text:0054B790 ?clear_selection_cursor@Render@@SAXXZ

        // Render.copy_view:
        public static int copy_view(portal_view_type* portal_view, Vec2Dscreen** clip_view, UInt32 num_pts) => ((delegate* unmanaged[Cdecl]<portal_view_type*, Vec2Dscreen**, UInt32, int>)0x0054EBD0)(portal_view, clip_view, num_pts); // .text:0054DFC0 ; int __cdecl Render::copy_view(portal_view_type *portal_view, Vec2Dscreen **clip_view, unsigned int num_pts) .text:0054DFC0 ?copy_view@Render@@SAHPAUportal_view_type@@PAPAUVec2Dscreen@@I@Z

        // Render.corner_plane_check:
        public static BoundingType corner_plane_check(Single corner, Single min, Single max) => ((delegate* unmanaged[Cdecl]<Single, Single, Single, BoundingType>)0x0054C540)(corner, min, max); // .text:0054B930 ; BoundingType __cdecl Render::corner_plane_check(float corner, float min, float max) .text:0054B930 ?corner_plane_check@Render@@KA?AW4BoundingType@@MMM@Z

        // Render.enable_active_lights:
        public static void enable_active_lights() => ((delegate* unmanaged[Cdecl]<void>)0x0054CC90)(); // .text:0054C080 ; void __cdecl Render::enable_active_lights() .text:0054C080 ?enable_active_lights@Render@@KAXXZ

        // Render.framePop:
        public static int framePop() => ((delegate* unmanaged[Cdecl]<int>)0x0054C9E0)(); // .text:0054BDD0 ; int __cdecl Render::framePop() .text:0054BDD0 ?framePop@Render@@SAHXZ

        // Render.framePush:
        public static void framePush(int op, Frame* frame, int prevIndex) => ((delegate* unmanaged[Cdecl]<int, Frame*, int, void>)0x0054DD60)(op, frame, prevIndex); // .text:0054D150 ; void __cdecl Render::framePush(const int op, Frame *frame, const int prevIndex) .text:0054D150 ?framePush@Render@@SAXHPBVFrame@@H@Z

        // Render.get_clip_height:
        public static void get_clip_height(Single x, Single y, ViewIntervalType* vint) => ((delegate* unmanaged[Cdecl]<Single, Single, ViewIntervalType*, void>)0x0054DC00)(x, y, vint); // .text:0054CFF0 ; void __cdecl Render::get_clip_height(float x, float y, ViewIntervalType *vint) .text:0054CFF0 ?get_clip_height@Render@@SAXMMAAUViewIntervalType@@@Z

        // Render.get_pt_limit:
        public static Single get_pt_limit(Single x, Single y, Plane* plane) => ((delegate* unmanaged[Cdecl]<Single, Single, Plane*, Single>)0x0054C450)(x, y, plane); // .text:0054B840 ; float __cdecl Render::get_pt_limit(float x, float y, Plane *plane) .text:0054B840 ?get_pt_limit@Render@@KAMMMABVPlane@@@Z

        // Render.insert_light:
        // public static void insert_light(int max_lights, int* num_lights, RenderLight* lights, RenderLight** sorted_lights, LIGHTINFO* light_info, UInt32 cell_id, Frame* frame, int offset) => ((delegate* unmanaged[Cdecl]<int, int*, RenderLight*, RenderLight**, LIGHTINFO*, UInt32, Frame*, int, void>)0xDEADBEEF)(max_lights, num_lights, lights, sorted_lights, light_info, cell_id, frame, offset); // .text:0054D1B0 ; void __cdecl Render::insert_light(int max_lights, int *num_lights, RenderLight *lights, RenderLight **sorted_lights, LIGHTINFO *light_info, const unsigned int cell_id, Frame *frame, int offset) .text:0054D1B0 ?insert_light@Render@@KAXHAAHPAVRenderLight@@PAPAV2@ABVLIGHTINFO@@KABVFrame@@H@Z

        // Render.minimize_envcell_lighting:
        public static void minimize_envcell_lighting(Position* cellPos, Single cellRadius) => ((delegate* unmanaged[Cdecl]<Position*, Single, void>)0x0054CD80)(cellPos, cellRadius); // .text:0054C170 ; void __cdecl Render::minimize_envcell_lighting(Position *cellPos, float cellRadius) .text:0054C170 ?minimize_envcell_lighting@Render@@KAXABVPosition@@M@Z

        // Render.minimize_object_lighting:
        // public static void minimize_object_lighting() => ((delegate* unmanaged[Cdecl]<void>)0xDEADBEEF)(); // .text:0054D480 ; void __cdecl Render::minimize_object_lighting() .text:0054D480 ?minimize_object_lighting@Render@@KAXXZ

        // Render.obj_view_set:
        public static void obj_view_set() => ((delegate* unmanaged[Cdecl]<void>)0x0054C5C0)(); // .text:0054B9B0 ; void __cdecl Render::obj_view_set() .text:0054B9B0 ?obj_view_set@Render@@SAXXZ

        // Render.pick_ray:
        public static AC1Legacy.Vector3* pick_ray(AC1Legacy.Vector3* result, int x, int y) => ((delegate* unmanaged[Cdecl]<AC1Legacy.Vector3*, int, int, AC1Legacy.Vector3*>)0x0054C220)(result, x, y); // .text:0054B610 ; AC1Legacy::Vector3 *__cdecl Render::pick_ray(AC1Legacy::Vector3 *result, int x, int y) .text:0054B610 ?pick_ray@Render@@SA?AVVector3@AC1Legacy@@HH@Z

        // Render.positionPush:
        public static void positionPush(int op, Position* position) => ((delegate* unmanaged[Cdecl]<int, Position*, void>)0x0054C9C0)(op, position); // .text:0054BDB0 ; void __cdecl Render::positionPush(const int op, Position *position) .text:0054BDB0 ?positionPush@Render@@SAXHPBVPosition@@@Z

        // Render.remove_object_light:
        public static int remove_object_light(LIGHTINFO* light_info) => ((delegate* unmanaged[Cdecl]<LIGHTINFO*, int>)0x0054CDC0)(light_info); // .text:0054C1B0 ; int __cdecl Render::remove_object_light(LIGHTINFO *light_info) .text:0054C1B0 ?remove_object_light@Render@@KAHABVLIGHTINFO@@@Z

        // Render.reset_active_lights_state:
        public static void reset_active_lights_state() => ((delegate* unmanaged[Cdecl]<void>)0x0054CA10)(); // .text:0054BE00 ; void __cdecl Render::reset_active_lights_state() .text:0054BE00 ?reset_active_lights_state@Render@@KAXXZ

        // Render.restore_all_lighting:
        public static void restore_all_lighting() => ((delegate* unmanaged[Cdecl]<void>)0x0054CE30)(); // .text:0054C220 ; void __cdecl Render::restore_all_lighting() .text:0054C220 ?restore_all_lighting@Render@@SAXXZ

        // Render.set_default_view:
        public static void set_default_view() => ((delegate* unmanaged[Cdecl]<void>)0x0054FB60)(); // .text:0054EF50 ; void __cdecl Render::set_default_view() .text:0054EF50 ?set_default_view@Render@@SAXXZ

        // Render.set_selection_cursor:
        public static void set_selection_cursor(int x, int y, Byte fPolyAccurate) => ((delegate* unmanaged[Cdecl]<int, int, Byte, void>)0x0054C360)(x, y, fPolyAccurate); // .text:0054B750 ; void __cdecl Render::set_selection_cursor(int x, int y, bool fPolyAccurate) .text:0054B750 ?set_selection_cursor@Render@@SAXHH_N@Z

        // Render.set_vdst:
        public static void set_vdst(Single _vdst) => ((delegate* unmanaged[Cdecl]<Single, void>)0x0054BE50)(_vdst); // .text:0054B240 ; void __cdecl Render::set_vdst(float _vdst) .text:0054B240 ?set_vdst@Render@@SAXM@Z

        // Render.set_view:
        public static void set_view(view_type* view, int view_num) => ((delegate* unmanaged[Cdecl]<view_type*, int, void>)0x0054DCF0)(view, view_num); // .text:0054D0E0 ; void __cdecl Render::set_view(view_type *view, int view_num) .text:0054D0E0 ?set_view@Render@@SAXAAUview_type@@H@Z

        // Render.set_zfar:
        // public static void set_zfar(Single _zfar) => ((delegate* unmanaged[Cdecl]<Single, void>)0xDEADBEEF)(_zfar); // .text:0054B320 ; void __cdecl Render::set_zfar(float _zfar) .text:0054B320 ?set_zfar@Render@@SAXM@Z

        // Render.update_viewpoint:
        public static void update_viewpoint(Frame* _viewer_frame) => ((delegate* unmanaged[Cdecl]<Frame*, void>)0x0054E830)(_viewer_frame); // .text:0054DC20 ; void __cdecl Render::update_viewpoint(Frame *_viewer_frame) .text:0054DC20 ?update_viewpoint@Render@@SAXABVFrame@@@Z

        // Render.update_viewpoint:
        // public static void update_viewpoint(Position* _viewer_pos) => ((delegate* unmanaged[Cdecl]<Position*, void>)0xDEADBEEF)(_viewer_pos); // .text:0054CDD0 ; void __cdecl Render::update_viewpoint(Position *_viewer_pos) .text:0054CDD0 ?update_viewpoint@Render@@SAXABVPosition@@@Z

        // Render.useSunlightSet:
        public static void useSunlightSet(int use_sunlight) => ((delegate* unmanaged[Cdecl]<int, void>)0x0054E060)(use_sunlight); // .text:0054D450 ; void __cdecl Render::useSunlightSet(int use_sunlight) .text:0054D450 ?useSunlightSet@Render@@SAXH@Z

        // Render.viewconeCheck:
        public static BoundingType viewconeCheck(CSphere* sphere) => ((delegate* unmanaged[Cdecl]<CSphere*, BoundingType>)0x0054CE60)(sphere); // .text:0054C250 ; BoundingType __cdecl Render::viewconeCheck(CSphere *sphere) .text:0054C250 ?viewconeCheck@Render@@SA?AW4BoundingType@@PBVCSphere@@@Z

        // Globals:
        public static Single* znear = (Single*)0x0081FC94; // .data:0081EC84 ; float Render::znear .data:0081EC84 ?znear@Render@@1MA
                                                           // public static int* max_static_lights = (int*)0xDEADBEEF; // .data:0081EC94 ; int Render::max_static_lights .data:0081EC94 ?max_static_lights@Render@@1HA
        public static int* portal_npnts = (int*)0x00847060; // .data:00846050 ; int Render::portal_npnts .data:00846050 ?portal_npnts@Render@@1HA
                                                            // public static Single* PolyCurrentMod = (Single*)0xDEADBEEF; // .data:00846054 ; float Render::PolyCurrentMod .data:00846054 ?PolyCurrentMod@Render@@1MA
                                                            // public static frameContext* FrameStack[10] = (frameContext*)0xDEADBEEF; // .data:00866460 ; frameContext Render::FrameStack[10] .data:00866460 ?FrameStack@Render@@1PAUframeContext@@A
                                                            // public static CPolygon** PolyCurrent = (CPolygon**)0xDEADBEEF; // .data:008662FC ; CPolygon *Render::PolyCurrent .data:008662FC ?PolyCurrent@Render@@1PAVCPolygon@@A
        public static int* selection_x = (int*)0x00867324; // .data:00866314 ; int Render::selection_x .data:00866314 ?selection_x@Render@@1HA
        public static Single* s_rDegradeDistance = (Single*)0x0081FC68; // .data:0081EC58 ; float Render::s_rDegradeDistance .data:0081EC58 ?s_rDegradeDistance@Render@@1MA
                                                                        // public static Single* min_framerate = (Single*)0xDEADBEEF; // .data:0081EC60 ; float Render::min_framerate .data:0081EC60 ?min_framerate@Render@@1MA
        public static Double* tx = (Double*)0x00847058; // .data:00846048 ; long double Render::tx .data:00846048 ?tx@Render@@1NA
        public static polyListEntry*** PolyList = (polyListEntry***)0x008471C8; // .data:008461B8 ; polyListEntry Render::PolyList[] .data:008461B8 ?PolyList@Render@@1PAUpolyListEntry@@A
                                                                              // public static Frame** ClipPlaneListFrame = (Frame**)0xDEADBEEF; // .data:00866264 ; Frame *Render::ClipPlaneListFrame .data:00866264 ?ClipPlaneListFrame@Render@@1PBVFrame@@B
        public static polyListEntry** PolyNext = (polyListEntry**)0x008672E8; // .data:008662D8 ; polyListEntry *Render::PolyNext .data:008662D8 ?PolyNext@Render@@1PAUpolyListEntry@@A
                                                                              // public static CSurface** curr_detail_surface = (CSurface**)0xDEADBEEF; // .data:00866364 ; CSurface *Render::curr_detail_surface .data:00866364 ?curr_detail_surface@Render@@1PAVCSurface@@A
                                                                              // public static LightParms* viewer_lights = (LightParms*)0xDEADBEEF; // .data:0086B228 ; LightParms Render::viewer_lights .data:0086B228 ?viewer_lights@Render@@1ULightParms@@A
                                                                              // public static int* in_range = (int*)0xDEADBEEF; // .data:0081EC70 ; int Render::in_range .data:0081EC70 ?in_range@Render@@2HA
                                                                              // public static int* deg_test = (int*)0xDEADBEEF; // .data:00866310 ; int Render::deg_test .data:00866310 ?deg_test@Render@@2HA
        public static int* FramePushCount = (int*)0x00867338; // .data:00866328 ; int Render::FramePushCount .data:00866328 ?FramePushCount@Render@@1HA
        public static Byte* check_curr_object = (Byte*)0x00867348; // .data:00866338 ; bool Render::check_curr_object .data:00866338 ?check_curr_object@Render@@1_NA
                                                                   // public static UInt32* m_CacheOverallGraphicsQuality = (UInt32*)0xDEADBEEF; // .data:00866340 ; unsigned int Render::m_CacheOverallGraphicsQuality .data:00866340 ?m_CacheOverallGraphicsQuality@Render@@1KA
                                                                   // public static UInt32* curr_surface_type = (UInt32*)0xDEADBEEF; // .data:00866374 ; unsigned int Render::curr_surface_type .data:00866374 ?curr_surface_type@Render@@1KA
                                                                   // public static int* curr_texture_is_set = (int*)0xDEADBEEF; // .data:00866378 ; int Render::curr_texture_is_set .data:00866378 ?curr_texture_is_set@Render@@1HA
                                                                   // .data:0086737C ; protected: static class CSurface * * Render::curr_surfaces .data:0086737C ?curr_surfaces@Render@@1PAPAVCSurface@@A
        public static Single* environment_detail_tiling = (Single*)0x0081FCBC; // .data:0081ECAC ; float Render::environment_detail_tiling .data:0081ECAC ?environment_detail_tiling@Render@@1MA
                                                                               // public static int* PolyCurrentPos = (int*)0xDEADBEEF; // .data:008460B8 ; int Render::PolyCurrentPos .data:008460B8 ?PolyCurrentPos@Render@@1HA
        public static Single* ymin = (Single*)0x008470CC; // .data:008460BC ; float Render::ymin .data:008460BC ?ymin@Render@@1MA
        public static int** dynamic_light_used = (int**)0x00867248; // .data:00866238 ; int Render::dynamic_light_used[10] .data:00866238 ?dynamic_light_used@Render@@1PAHA
        public static Double* yinvscale = (Double*)0x008672F0; // .data:008662E0 ; long double Render::yinvscale .data:008662E0 ?yinvscale@Render@@1NA
                                                               // public static Single* xmin = (Single*)0xDEADBEEF; // .data:008662F4 ; float Render::xmin .data:008662F4 ?xmin@Render@@1MA
        public static Single* particle_distance_2dsq = (Single*)0x0086C208; // .data:0086B1F8 ; float Render::particle_distance_2dsq .data:0086B1F8 ?particle_distance_2dsq@Render@@1MA
                                                                            // public static Single* max_framerate = (Single*)0xDEADBEEF; // .data:0081EC5C ; float Render::max_framerate .data:0081EC5C ?max_framerate@Render@@1MA
        public static int* force_level = (int*)0x0081FC7C; // .data:0081EC6C ; int Render::force_level .data:0081EC6C ?force_level@Render@@2HA
                                                           // public static int* portal_view_num = (int*)0xDEADBEEF; // .data:008662DC ; int Render::portal_view_num .data:008662DC ?portal_view_num@Render@@1HA
        public static Single* deg_mul = (Single*)0x0086731C; // .data:0086630C ; float Render::deg_mul .data:0086630C ?deg_mul@Render@@1MA
                                                             // public static ClipPlaneList** ClipPlaneListCurrent = (ClipPlaneList**)0xDEADBEEF; // .data:0086631C ; ClipPlaneList *Render::ClipPlaneListCurrent .data:0086631C ?ClipPlaneListCurrent@Render@@1PAVClipPlaneList@@A
        public static Render** m_pRenderer = (Render**)0x0086734C; // .data:0086633C ; Render *Render::m_pRenderer .data:0086633C ?m_pRenderer@Render@@1PAV1@A
        public static Single* zfar = (Single*)0x0081FC98; // .data:0081EC88 ; float Render::zfar .data:0081EC88 ?zfar@Render@@1MA
        public static Single* local_object_radius = (Single*)0x00867270; // .data:00866260 ; float Render::local_object_radius .data:00866260 ?local_object_radius@Render@@1MA
        public static Double* bh = (Double*)0x008672E0; // .data:008662D0 ; long double Render::bh .data:008662D0 ?bh@Render@@1NA
                                                        // public static portal_view_type** PortalList = (portal_view_type**)0xDEADBEEF; // .data:00866320 ; portal_view_type *Render::PortalList .data:00866320 ?PortalList@Render@@1PAUportal_view_type@@A
        public static CSurface** environment_detail_surface = (CSurface**)0x0086736C; // .data:0086635C ; CSurface *Render::environment_detail_surface .data:0086635C ?environment_detail_surface@Render@@1PAVCSurface@@A
                                                                                      // public static Single* TextureVSize = (Single*)0xDEADBEEF; // .data:0081ECC0 ; float Render::TextureVSize .data:0081ECC0 ?TextureVSize@Render@@1MA
        public static view_vertex** portal_vertex = (view_vertex**)0x00847050; // .data:00846040 ; view_vertex *Render::portal_vertex .data:00846040 ?portal_vertex@Render@@1PAUview_vertex@@A
        public static Byte* check_selection = (Byte*)0x0086734A; // .data:0086633A ; bool Render::check_selection .data:0086633A ?check_selection@Render@@1_NA
                                                                 // public static DrawParms* viewer_world_space = (DrawParms*)0xDEADBEEF; // .data:0086640C ; DrawParms Render::viewer_world_space .data:0086640C ?viewer_world_space@Render@@1UDrawParms@@A
                                                                 // public static SmartArray<Byte (__cdecl*)(void),1>* m_RGRCallbacks = (SmartArray<Byte (__cdecl*)(void),1>*)0xDEADBEEF; // .data:0086B1FC ; SmartArray<bool (__cdecl*)(void),1> Render::m_RGRCallbacks .data:0086B1FC ?m_RGRCallbacks@Render@@1V?$SmartArray@P6A_NXZ$00@@A
        public static Plane** portal_obj_plane = (Plane**)0x00870088; // .data:0086F078 ; Plane Render::portal_obj_plane[32] .data:0086F078 ?portal_obj_plane@Render@@1PAVPlane@@A
                                                                      // public static char** UVIndexTbl = (char**)0xDEADBEEF; // .data:0086637C ; char *Render::UVIndexTbl .data:0086637C ?UVIndexTbl@Render@@1PADA
                                                                      // public static int* max_dynamic_lights = (int*)0xDEADBEEF; // .data:0081EC98 ; int Render::max_dynamic_lights .data:0081EC98 ?max_dynamic_lights@Render@@1HA
                                                                      // public static BlendMode* curr_detail_dst_blend = (BlendMode*)0xDEADBEEF; // .data:0081ECA4 ; BlendMode Render::curr_detail_dst_blend .data:0081ECA4 ?curr_detail_dst_blend@Render@@2KA
                                                                      // public static Vector3* object_scale_vec = (Vector3*)0xDEADBEEF; // .data:0081EEB0 ; Vector3 Render::object_scale_vec .data:0081EEB0 ?object_scale_vec@Render@@1VVector3@@A
                                                                      // public static Position* player_pos = (Position*)0xDEADBEEF; // .data:0081EF48 ; Position Render::player_pos .data:0081EF48 ?player_pos@Render@@1VPosition@@A
                                                                      // public static frameContext** FrameCurrent = (frameContext**)0x00867334; // .data:00866324 ; frameContext *Render::FrameCurrent .data:00866324 ?FrameCurrent@Render@@1PAUframeContext@@A
                                                                      // public static Byte* sm_WantSafeRenderSettings = (Byte*)0xDEADBEEF; // .data:00866344 ; bool Render::sm_WantSafeRenderSettings .data:00866344 ?sm_WantSafeRenderSettings@Render@@1_NA
                                                                      // public static Single* ymax = (Single*)0xDEADBEEF; // .data:008662F0 ; float Render::ymax .data:008662F0 ?ymax@Render@@1MA
        public static Double* ty = (Double*)0x00867310; // .data:00866300 ; long double Render::ty .data:00866300 ?ty@Render@@1NA
        public static int* useSunlight = (int*)0x00867344; // .data:00866334 ; int Render::useSunlight .data:00866334 ?useSunlight@Render@@1HA
        public static CSurface** landscape_detail_surface = (CSurface**)0x00867364; // .data:00866354 ; CSurface *Render::landscape_detail_surface .data:00866354 ?landscape_detail_surface@Render@@1PAVCSurface@@A
                                                                                    // public static AC1Legacy.Vector3* selection_ray = (AC1Legacy.Vector3*)0xDEADBEEF; // .data:008663EC ; AC1Legacy::Vector3 Render::selection_ray .data:008663EC ?selection_ray@Render@@1VVector3@AC1Legacy@@A
        public static LightParms* world_lights = (LightParms*)0x008682B0; // .data:008672A0 ; LightParms Render::world_lights .data:008672A0 ?world_lights@Render@@1ULightParms@@A
        public static int* pushLevelOffset = (int*)0x0086733C; // .data:0086632C ; int Render::pushLevelOffset .data:0086632C ?pushLevelOffset@Render@@1HA
                                                               // public static CSurface** curr_surface = (CSurface**)0xDEADBEEF; // .data:00866370 ; CSurface *Render::curr_surface .data:00866370 ?curr_surface@Render@@1PAVCSurface@@A
        public static Single* fov = (Single*)0x0081FC88; // .data:0081EC78 ; float Render::fov .data:0081EC78 ?fov@Render@@1MA
        public static Single* scale = (Single*)0x0081FC8C; // .data:0081EC7C ; float Render::scale .data:0081EC7C ?scale@Render@@1MA
                                                           // public static Render.LightingType* lighting_type = (Render.LightingType*)0xDEADBEEF; // .data:0081EC9C ; Render::LightingType Render::lighting_type .data:0081EC9C ?lighting_type@Render@@1W4LightingType@1@A
        public static Single* building_detail_tiling = (Single*)0x0081FCC0; // .data:0081ECB0 ; float Render::building_detail_tiling .data:0081ECB0 ?building_detail_tiling@Render@@1MA
                                                                            // public static RenderPrefs* m_RenderPrefs = (RenderPrefs*)0xDEADBEEF; // .data:0081EF90 ; RenderPrefs Render::m_RenderPrefs .data:0081EF90 ?m_RenderPrefs@Render@@1VRenderPrefs@@A
                                                                            // public static int* portal_inmask = (int*)0xDEADBEEF; // .data:008661B8 ; int Render::portal_inmask .data:008661B8 ?portal_inmask@Render@@1HA
        public static Byte* auto_update_deg_mul = (Byte*)0x0081FC78; // .data:0081EC68 ; bool Render::auto_update_deg_mul .data:0081EC68 ?auto_update_deg_mul@Render@@1_NA
        public static Single* object_scale = (Single*)0x0081FC84; // .data:0081EC74 ; float Render::object_scale .data:0081EC74 ?object_scale@Render@@1MA
        public static int* selection_y = (int*)0x00867328; // .data:00866318 ; int Render::selection_y .data:00866318 ?selection_y@Render@@1HA
        public static CSurface** building_detail_surface = (CSurface**)0x00867368; // .data:00866358 ; CSurface *Render::building_detail_surface .data:00866358 ?building_detail_surface@Render@@1PAVCSurface@@A
                                                                                   // public static Render.MouseSelectData* m_MouseSelectData = (Render.MouseSelectData*)0xDEADBEEF; // .data:0086B190 ; Render::MouseSelectData Render::m_MouseSelectData .data:0086B190 ?m_MouseSelectData@Render@@1UMouseSelectData@1@A
                                                                                   // public static int* FrameEraNext = (int*)0xDEADBEEF; // .data:0081EC8C ; int Render::FrameEraNext .data:0081EC8C ?FrameEraNext@Render@@1HA
                                                                                   // public static RGBColor* diffuse = (RGBColor*)0xDEADBEEF; // .data:0081EFC0 ; RGBColor Render::diffuse .data:0081EFC0 ?diffuse@Render@@1VRGBColor@@A
        public static Single* xmax = (Single*)0x008470D0; // .data:008460C0 ; float Render::xmax .data:008460C0 ?xmax@Render@@1MA
        public static int** static_light_used = (int**)0x008470D8; // .data:008460C8 ; int Render::static_light_used[60] .data:008460C8 ?static_light_used@Render@@1PAHA
        public static int* FrameEra = (int*)0x00867340; // .data:00866330 ; int Render::FrameEra .data:00866330 ?FrameEra@Render@@1HA
                                                        // public static Single* ideal_framerate = (Single*)0xDEADBEEF; // .data:0081EC64 ; float Render::ideal_framerate .data:0081EC64 ?ideal_framerate@Render@@1MA
        public static Single* landscape_detail_tiling = (Single*)0x0081FCB8; // .data:0081ECA8 ; float Render::landscape_detail_tiling .data:0081ECA8 ?landscape_detail_tiling@Render@@1MA
        public static Single* object_detail_tiling = (Single*)0x0081FCC4; // .data:0081ECB4 ; float Render::object_detail_tiling .data:0081ECB4 ?object_detail_tiling@Render@@1MA
        public static CSurface** object_detail_surface = (CSurface**)0x00867370; // .data:00866360 ; CSurface *Render::object_detail_surface .data:00866360 ?object_detail_surface@Render@@1PAVCSurface@@A
                                                                                 // public static AC1Legacy.Vector3* Yaxis = (AC1Legacy.Vector3*)0xDEADBEEF; // .data:0086B17C ; AC1Legacy::Vector3 Render::Yaxis .data:0086B17C ?Yaxis@Render@@1VVector3@AC1Legacy@@A
                                                                                 // public static AC1Legacy.Vector3* Xaxis = (AC1Legacy.Vector3*)0xDEADBEEF; // .data:0086B1C0 ; AC1Legacy::Vector3 Render::Xaxis .data:0086B1C0 ?Xaxis@Render@@1VVector3@AC1Legacy@@A
                                                                                 // public static RenderDevice** render_device = (RenderDevice**)0xDEADBEEF; // .data:00866348 ; RenderDevice *Render::render_device .data:00866348 ?render_device@Render@@1PAVRenderDevice@@A
                                                                                 // public static RGBColor* luminosity = (RGBColor*)0xDEADBEEF; // .data:008663F8 ; RGBColor Render::luminosity .data:008663F8 ?luminosity@Render@@1VRGBColor@@A
                                                                                 // public static BlendMode* curr_detail_src_blend = (BlendMode*)0xDEADBEEF; // .data:0081ECA0 ; BlendMode Render::curr_detail_src_blend .data:0081ECA0 ?curr_detail_src_blend@Render@@2KA
                                                                                 // public static view_type** portal_view = (view_type**)0xDEADBEEF; // .data:00846044 ; view_type *Render::portal_view .data:00846044 ?portal_view@Render@@1PAUview_type@@A
        public static HWLightUsage** prevLightUsage = (HWLightUsage**)0x00867278; // .data:00866268 ; HWLightUsage Render::prevLightUsage[8] .data:00866268 ?prevLightUsage@Render@@1PAUHWLightUsage@@A
        public static Double* xinvscale = (Double*)0x008672D8; // .data:008662C8 ; long double Render::xinvscale .data:008662C8 ?xinvscale@Render@@1NA
        public static Double* bw = (Double*)0x008672F8; // .data:008662E8 ; long double Render::bw .data:008662E8 ?bw@Render@@1NA
        public static Byte* check_curr_object_polys = (Byte*)0x00867349; // .data:00866339 ; bool Render::check_curr_object_polys .data:00866339 ?check_curr_object_polys@Render@@1_NA
                                                                         // public static AC1Legacy.Vector3* local_object_center = (AC1Legacy.Vector3*)0xDEADBEEF; // .data:0086B114 ; AC1Legacy::Vector3 Render::local_object_center .data:0086B114 ?local_object_center@Render@@1VVector3@AC1Legacy@@A
        public static HWLightUsage** curLightUsage = (HWLightUsage**)0x00847068; // .data:00846058 ; HWLightUsage Render::curLightUsage[8] .data:00846058 ?curLightUsage@Render@@1PAUHWLightUsage@@A
        public static Single* s_rUserSuppliedDegradeBias = (Single*)0x00867318; // .data:00866308 ; float Render::s_rUserSuppliedDegradeBias .data:00866308 ?s_rUserSuppliedDegradeBias@Render@@1MA
        public static Single* object_distance_2dsq = (Single*)0x00867414; // .data:00866404 ; float Render::object_distance_2dsq .data:00866404 ?object_distance_2dsq@Render@@1MA
                                                                          // public static AC1Legacy.Vector3* Zaxis = (AC1Legacy.Vector3*)0xDEADBEEF; // .data:00866428 ; AC1Legacy::Vector3 Render::Zaxis .data:00866428 ?Zaxis@Render@@1VVector3@AC1Legacy@@A
        public static Single* vdst = (Single*)0x0081FC90; // .data:0081EC80 ; float Render::vdst .data:0081EC80 ?vdst@Render@@1MA
                                                          // public static int* CachedMatrixFrameEra = (int*)0xDEADBEEF; // .data:0081EC90 ; int Render::CachedMatrixFrameEra .data:0081EC90 ?CachedMatrixFrameEra@Render@@1HA
                                                          // public static Single* curr_detail_tiling = (Single*)0xDEADBEEF; // .data:0081ECB8 ; float Render::curr_detail_tiling .data:0081ECB8 ?curr_detail_tiling@Render@@1MA
                                                          // public static Single* TextureUSize = (Single*)0xDEADBEEF; // .data:0081ECBC ; float Render::TextureUSize .data:0081ECBC ?TextureUSize@Render@@1MA
        public static Position* viewer_pos = (Position*)0x0081FF10; // .data:0081EF00 ; Position Render::viewer_pos .data:0081EF00 ?viewer_pos@Render@@1VPosition@@A
                                                                    // public static CMaterial** curr_material = (CMaterial**)0xDEADBEEF; // .data:00866368 ; CMaterial *Render::curr_material .data:00866368 ?curr_material@Render@@1PAVCMaterial@@A
    }
    public unsafe struct RenderConfig {
        // Struct:
        public GraphicsDriver m_GraphicsDriver;
        public override string ToString() => $"m_GraphicsDriver(GraphicsDriver):{m_GraphicsDriver}";
    }
    public unsafe struct RenderDisplayModeType {
        // Struct:
        public UInt32 nWidth;
        public UInt32 nHeight;
        public PixelFormatID Format;
        public UInt32 nRefreshRate;
        public override string ToString() => $"nWidth:{nWidth:X8}, nHeight:{nHeight:X8}, Format(PixelFormatID):{Format}, nRefreshRate:{nRefreshRate:X8}";
    }

    public unsafe struct _D3DVSHADERCAPS2_0 {
        public int Caps;
        public int DynamicFlowControlDepth;
        public int NumTemps;
        public int StaticFlowControlDepth;
    };

    public unsafe struct _D3DCAPS9 {
        public uint DeviceType;
        public uint AdapterOrdinal;
        public int Caps;
        public int Caps2;
        public int Caps3;
        public int PresentationIntervals;
        public int CursorCaps;
        public int DevCaps;
        public int PrimitiveMiscCaps;
        public int RasterCaps;
        public int ZCmpCaps;
        public int SrcBlendCaps;
        public int DestBlendCaps;
        public int AlphaCmpCaps;
        public int ShadeCaps;
        public int TextureCaps;
        public int TextureFilterCaps;
        public int CubeTextureFilterCaps;
        public int VolumeTextureFilterCaps;
        public int TextureAddressCaps;
        public int VolumeTextureAddressCaps;
        public int LineCaps;
        public int MaxTextureWidth;
        public int MaxTextureHeight;
        public int MaxVolumeExtent;
        public int MaxTextureRepeat;
        public int MaxTextureAspectRatio;
        public int MaxAnisotropy;
        public float MaxVertexW;
        public float GuardBandLeft;
        public float GuardBandTop;
        public float GuardBandRight;
        public float GuardBandBottom;
        public float ExtentsAdjust;
        public int StencilCaps;
        public int FVFCaps;
        public int TextureOpCaps;
        public int MaxTextureBlendStages;
        public int MaxSimultaneousTextures;
        public int VertexProcessingCaps;
        public int MaxActiveLights;
        public int MaxUserClipPlanes;
        public int MaxVertexBlendMatrices;
        public int MaxVertexBlendMatrixIndex;
        public float MaxPointSize;
        public int MaxPrimitiveCount;
        public int MaxVertexIndex;
        public int MaxStreams;
        public int MaxStreamStride;
        public int VertexShaderVersion;
        public int MaxVertexShaderConst;
        public int PixelShaderVersion;
        public float PixelShader1xMaxValue;
        public int DevCaps2;
        public float MaxNpatchTessellationLevel;
        public int Reserved5;
        public uint MasterAdapterOrdinal;
        public uint AdapterOrdinalInGroup;
        public uint NumberOfAdaptersInGroup;
        public int DeclTypes;
        public int NumSimultaneousRTs;
        public int StretchRectFilterCaps;
        public _D3DVSHADERCAPS2_0 VS20Caps;
        public _D3DVSHADERCAPS2_0 PS20Caps;
        public int VertexTextureFilterCaps;
        public int MaxVShaderInstructionsExecuted;
        public int MaxPShaderInstructionsExecuted;
        public int MaxPShaderInstructionsExecuted2;
    }

    public unsafe struct RenderDeviceD3D {
        public RenderDevice RenderDevice;
        public uint m_AdapterID;
        public uint m_D3DDeviceType;
        public _D3DCAPS9 m_D3DCaps;
        public tagRECT m_PresentSourceRect;
        public tagRECT m_PresentDestRect;
        public HWND__* m_hPresentWindow;
        public uint m_nFrontBufferWidth;
        public uint m_nFrontBufferHeight;
        public IDirect3DDevice9* m_pDirect3DDevice;

        public override string ToString() {
            return $"RendeRdevice: {RenderDevice.ToString()} m_AdapterID={m_AdapterID} m_D3DDeviceType={m_D3DDeviceType} m_D3DCaps={m_D3DCaps} m_PresentSourceRect={m_PresentSourceRect.ToString()} m_PresentDestRect={m_PresentDestRect.ToString()} m_hPresentWindow={(int)m_hPresentWindow:X8} m_nFrontBufferWidth={m_nFrontBufferWidth} m_nFrontBufferHeight={m_nFrontBufferHeight} m_pDirect3DDevice={(int)m_pDirect3DDevice:X8}";
        }
    }

    public unsafe struct RenderDevice {
        // Struct:
        public RenderDevice.Vtbl* vfptr;
        public RenderDevicePresentation m_presentation;
        public RenderDeviceConfig m_config;
        public RenderDeviceCaps m_caps;
        public RenderDeviceDisplayInfo m_displayInfo;
        public UInt32 m_viewportX;
        public UInt32 m_viewportY;
        public UInt32 m_viewportWidth;
        public UInt32 m_viewportHeight;
        public UInt32 m_RenderTargetWidth;
        public UInt32 m_RenderTargetHeight;
        public Single m_DisplayAspectRatio;
        public Single m_ViewportAspectRatio;
        public Byte m_bOpenScene;
        public Byte m_bDeviceLost;
        public UInt32 m_nFrameStamp;
        public RenderSurface* m_pFrameBufferSurface;
        public RenderSurface* m_pDepthStencilSurface;
        public RenderSurface* m_pRenderTarget;
        public RenderSurface* m_pDepthStencilTarget;
        public Byte m_WireframeMode;
        public Byte m_ReverseCulling;
        public RenderDevice.GraphicsStatesType m_GState;
        public TextureBasedFont* m_pDebugFont;
        public UInt32 m_DebugFontWidth;
        public UInt32 m_DebugFontHeight;
        public override string ToString() => $"vfptr:->(RenderDevice.Vtbl*)0x{(int)vfptr:X8}, m_presentation(RenderDevicePresentation):{m_presentation}, m_config(RenderDeviceConfig):{m_config}, m_caps(RenderDeviceCaps):{m_caps}, m_displayInfo(RenderDeviceDisplayInfo):{m_displayInfo}, m_viewportX:{m_viewportX:X8}, m_viewportY:{m_viewportY:X8}, m_viewportWidth:{m_viewportWidth:X8}, m_viewportHeight:{m_viewportHeight:X8}, m_RenderTargetWidth:{m_RenderTargetWidth:X8}, m_RenderTargetHeight:{m_RenderTargetHeight:X8}, m_DisplayAspectRatio:{m_DisplayAspectRatio:n5}, m_ViewportAspectRatio:{m_ViewportAspectRatio:n5}, m_bOpenScene:{m_bOpenScene:X2}, m_bDeviceLost:{m_bDeviceLost:X2}, m_nFrameStamp:{m_nFrameStamp:X8}, m_pFrameBufferSurface:->(RenderSurface*)0x{(int)m_pFrameBufferSurface:X8}, m_pDepthStencilSurface:->(RenderSurface*)0x{(int)m_pDepthStencilSurface:X8}, m_pRenderTarget:->(RenderSurface*)0x{(int)m_pRenderTarget:X8}, m_pDepthStencilTarget:->(RenderSurface*)0x{(int)m_pDepthStencilTarget:X8}, m_WireframeMode:{m_WireframeMode:X2}, m_ReverseCulling:{m_ReverseCulling:X2}, m_GState(RenderDevice.GraphicsStatesType):{m_GState}, m_pDebugFont:->(TextureBasedFont*)0x{(int)m_pDebugFont:X8}, m_DebugFontWidth:{m_DebugFontWidth:X8}, m_DebugFontHeight:{m_DebugFontHeight:X8}";
        public unsafe struct GraphicsStatesType {
            public Matrix4 ModelToWorldMatrix;
            public Matrix4 WorldToViewMatrix;
            public Matrix4 ViewToClipMatrix;
            public RGBAColor AmbientLight;
            public RGBAColor DistanceFogColor;
            public Single DistanceFogNear;
            public Single DistanceFogFar;
            public Single DistantSpriteOpacityNear;
            public Single DistantSpriteOpacityRange;
            public Single OpacityFogNearDistance;
            public Single OpacityFogRange;
            public RenderLight* pMPLightSource;
            public RenderTexture* pMPLightProjectorTexture;
            public SmartArray<RenderLight> FFLightSources;
            public Byte ChangedFFLightSources;
            public RGBAColor FrameBufferBloomRGBAmount;
            public fixed int PixelFilterTexCoords[15 * 4];
            public Vector4 BSVLightOriginAndExtrusionOffset;
            public Single FrameBufferViewportOffsetX;
            public Single FrameBufferViewportOffsetY;
            public Single FrameBufferViewportScaleX;
            public Single FrameBufferViewportScaleY;
            public override string ToString() => $"ModelToWorldMatrix(Matrix4):{ModelToWorldMatrix}, WorldToViewMatrix(Matrix4):{WorldToViewMatrix}, ViewToClipMatrix(Matrix4):{ViewToClipMatrix}, AmbientLight(RGBAColor):{AmbientLight}, DistanceFogColor(RGBAColor):{DistanceFogColor}, DistanceFogNear:{DistanceFogNear:n5}, DistanceFogFar:{DistanceFogFar:n5}, DistantSpriteOpacityNear:{DistantSpriteOpacityNear:n5}, DistantSpriteOpacityRange:{DistantSpriteOpacityRange:n5}, OpacityFogNearDistance:{OpacityFogNearDistance:n5}, OpacityFogRange:{OpacityFogRange:n5}, pMPLightSource:->(RenderLight*)0x{(int)pMPLightSource:X8}, pMPLightProjectorTexture:->(RenderTexture*)0x{(int)pMPLightProjectorTexture:X8}, FFLightSources(SmartArray<RenderLight,1>):{FFLightSources}, ChangedFFLightSources:{ChangedFFLightSources:X2}, FrameBufferBloomRGBAmount(RGBAColor):{FrameBufferBloomRGBAmount}, PixelFilterTexCoords[15](fixed int):{PixelFilterTexCoords[15]}, BSVLightOriginAndExtrusionOffset(Vector4):{BSVLightOriginAndExtrusionOffset}, FrameBufferViewportOffsetX:{FrameBufferViewportOffsetX:n5}, FrameBufferViewportOffsetY:{FrameBufferViewportOffsetY:n5}, FrameBufferViewportScaleX:{FrameBufferViewportScaleX:n5}, FrameBufferViewportScaleY:{FrameBufferViewportScaleY:n5}";
        }
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<RenderDevice*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(RenderDevice *this, unsigned int);
            public fixed int gap4[12];
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderSurface*> CreateSurface; // RenderSurface *(__thiscall *CreateSurface)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderTexture*> CreateTexture; // RenderTexture *(__thiscall *CreateTexture)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderIndexBuffer*> CreateIndexBuffer; // RenderIndexBuffer *(__thiscall *CreateIndexBuffer)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderVertexBuffer*> CreateVertexBuffer; // RenderVertexBuffer *(__thiscall *CreateVertexBuffer)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, void> BeginScene; // void (__thiscall *BeginScene)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, void> EndScene; // void (__thiscall *EndScene)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, void> Flip; // void (__thiscall *Flip)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, UInt32, RGBAColor*, Single, void> Clear; // void (__thiscall *Clear)(RenderDevice *this, unsigned int, RGBAColor *, float);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, Byte> IsResetPossible; // bool (__thiscall *IsResetPossible)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, UInt32, RenderSurface*, RenderSurface*, void> SetRenderTarget; // void (__thiscall *SetRenderTarget)(RenderDevice *this, unsigned int, RenderSurface *, RenderSurface *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderDevicePresentation*, Byte> ResetDevice; // bool (__thiscall *ResetDevice)(RenderDevice *this, RenderDevicePresentation *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, RenderSurface*> GenerateSurfaceFromFrontBuffer; // RenderSurface *(__thiscall *GenerateSurfaceFromFrontBuffer)(RenderDevice *this);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, UInt32, UInt32, UInt32, UInt32, Byte, void> SetViewport; // void (__thiscall *SetViewport)(RenderDevice *this, unsigned int, unsigned int, unsigned int, unsigned int, bool);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, LScape*, void> SetLandscape; // void (__thiscall *SetLandscape)(RenderDevice *this, LScape *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CEnvCell*, void> DrawInside; // void (__thiscall *DrawInside)(RenderDevice *this, CEnvCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CPortalPoly*, int, int, void> DrawPortal; // void (__thiscall *DrawPortal)(RenderDevice *this, CPortalPoly *, int, int);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CLandBlock*, void> DrawBlock; // void (__thiscall *DrawBlock)(RenderDevice *this, CLandBlock *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CLandCell*, void> DrawLandCell; // void (__thiscall *DrawLandCell)(RenderDevice *this, CLandCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CSortCell*, void> DrawSortCell; // void (__thiscall *DrawSortCell)(RenderDevice *this, CSortCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CEnvCell*, void> DrawEnvCell; // void (__thiscall *DrawEnvCell)(RenderDevice *this, CEnvCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CObjCell*, void> DrawObjCell; // void (__thiscall *DrawObjCell)(RenderDevice *this, CObjCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CObjCell*, void> DrawObjCellForDummies; // void (__thiscall *DrawObjCellForDummies)(RenderDevice *this, CObjCell *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CBuildingObj*, void> DrawBuilding; // void (__thiscall *DrawBuilding)(RenderDevice *this, CBuildingObj *);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, UInt32, void> DrawBuildingLeaf; // void (__thiscall *DrawBuildingLeaf)(RenderDevice *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CGfxObj*, Position*, Byte, ObjectDrawStatus> DrawMesh; // ObjectDrawStatus (__thiscall *DrawMesh)(RenderDevice *this, CGfxObj *, Position *, bool);
            public static delegate* unmanaged[Thiscall]<RenderDevice*, CGfxObj*, Position*, void> DrawDetailMesh; // void (__thiscall *DrawDetailMesh)(RenderDevice *this, CGfxObj *, Position *);
            public override string ToString() => $"gap4[12](fixed int):{gap4[12]}";
        }

        // Functions:

        // RenderDevice.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, void>)0xDEADBEEF)(ref this); // .text:0059DCD0 ; void __thiscall RenderDevice::RenderDevice(RenderDevice *this) .text:0059DCD0 ??0RenderDevice@@QAE@XZ

        // RenderDevice.Begin:
        // public void Begin() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, void>)0xDEADBEEF)(ref this); // .text:0054FC40 ; void __thiscall RenderDevice::Begin(RenderDevice *this) .text:0054FC40 ?Begin@RenderDevice@@AAEXXZ

        // RenderDevice.ComputeAspectForViewport:
        // public Single ComputeAspectForViewport(UInt32 x, UInt32 y, UInt32 width, UInt32 height, Byte _UseAutoAspect) => ((delegate* unmanaged[Thiscall]<ref RenderDevice, UInt32, UInt32, UInt32, UInt32, Byte, Single>)0xDEADBEEF)(ref this, x, y, width, height, _UseAutoAspect); // .text:0054F150 ; float __thiscall RenderDevice::ComputeAspectForViewport(RenderDevice *this, unsigned int x, unsigned int y, unsigned int width, unsigned int height, bool _UseAutoAspect) .text:0054F150 ?ComputeAspectForViewport@RenderDevice@@QBEMKKKK_N@Z

        // RenderDevice.CreateLocalSurface:
        // public RenderSurface* CreateLocalSurface() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, RenderSurface*>)0xDEADBEEF)(ref this); // .text:0054F130 ; RenderSurface *__thiscall RenderDevice::CreateLocalSurface(RenderDevice *this) .text:0054F130 ?CreateLocalSurface@RenderDevice@@UBEPAVRenderSurface@@XZ

        // RenderDevice.End:
        // public void End() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, void>)0xDEADBEEF)(ref this); // .text:0054F690 ; void __thiscall RenderDevice::End(RenderDevice *this) .text:0054F690 ?End@RenderDevice@@AAEXXZ

        // RenderDevice.GetDisplayHeight:
        public UInt32 GetDisplayHeight() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, UInt32>)0x0054FD30)(ref this); // .text:0054F120 ; unsigned int __thiscall RenderDevice::GetDisplayHeight(RenderDevice *this) .text:0054F120 ?GetDisplayHeight@RenderDevice@@QBEKXZ

        // RenderDevice.GetDisplayWidth:
        public UInt32 GetDisplayWidth() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, UInt32>)0x0054FD20)(ref this); // .text:0054F110 ; unsigned int __thiscall RenderDevice::GetDisplayWidth(RenderDevice *this) .text:0054F110 ?GetDisplayWidth@RenderDevice@@QBEKXZ

        // RenderDevice.GetUISurfaceFormat:
        public PixelFormatID GetUISurfaceFormat() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, PixelFormatID>)0x0054FE80)(ref this); // .text:0054F270 ; PixelFormatID __thiscall RenderDevice::GetUISurfaceFormat(RenderDevice *this) .text:0054F270 ?GetUISurfaceFormat@RenderDevice@@QBE?BW4PixelFormatID@@XZ

        // RenderDevice.IsResetPossible:
        // public Byte IsResetPossible() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, Byte>)0xDEADBEEF)(ref this); // .text:0059DDB0 ; bool __thiscall RenderDevice::IsResetPossible(RenderDevice *this) .text:0059DDB0 ?IsResetPossible@RenderDevice@@UAE_NXZ

        // RenderDevice.ReleaseSurfaceResources:
        // public void ReleaseSurfaceResources() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, void>)0xDEADBEEF)(ref this); // .text:0054F0B0 ; void __thiscall RenderDevice::ReleaseSurfaceResources(RenderDevice *this) .text:0054F0B0 ?ReleaseSurfaceResources@RenderDevice@@IAEXXZ

        // RenderDevice.SetViewport:
        // public void SetViewport(UInt32 x, UInt32 y, UInt32 width, UInt32 height, Byte _UseAutoAspect) => ((delegate* unmanaged[Thiscall]<ref RenderDevice, UInt32, UInt32, UInt32, UInt32, Byte, void>)0xDEADBEEF)(ref this, x, y, width, height, _UseAutoAspect); // .text:0054F1C0 ; void __thiscall RenderDevice::SetViewport(RenderDevice *this, unsigned int x, unsigned int y, unsigned int width, unsigned int height, bool _UseAutoAspect) .text:0054F1C0 ?SetViewport@RenderDevice@@UAEXKKKK_N@Z

        // RenderDevice.Shutdown:
        // public void Shutdown() => ((delegate* unmanaged[Thiscall]<ref RenderDevice, void>)0xDEADBEEF)(ref this); // .text:0054FEB0 ; void __thiscall RenderDevice::Shutdown(RenderDevice *this) .text:0054FEB0 ?Shutdown@RenderDevice@@UAEXXZ

        // RenderDevice.Startup:
        // public Byte Startup(UInt32 _nDisplayAdapter, RenderDevicePresentation* _presentation, RenderDeviceConfig* _config) => ((delegate* unmanaged[Thiscall]<ref RenderDevice, UInt32, RenderDevicePresentation*, RenderDeviceConfig*, Byte>)0xDEADBEEF)(ref this, _nDisplayAdapter, _presentation, _config); // .text:0054F240 ; bool __thiscall RenderDevice::Startup(RenderDevice *this, const unsigned int _nDisplayAdapter, RenderDevicePresentation *_presentation, RenderDeviceConfig *_config) .text:0054F240 ?Startup@RenderDevice@@UAE_NKABVRenderDevicePresentation@@ABVRenderDeviceConfig@@@Z

        // Globals:
        public static RenderDevice** render_device = (RenderDevice**)0x00870340; // .data:0086F330 ; RenderDevice *RenderDevice::render_device .data:0086F330 ?render_device@RenderDevice@@2PAV1@A
    }
    public unsafe struct RenderDeviceConfig {
        // Struct:
        public HWND__* hFocusWindow;
        public Byte bUseStencilBuffer;
        public Byte bSoftwareVertexProcessing;
        public Byte bUsePureDevice;
        public override string ToString() => $"hFocusWindow:->(HWND__*)0x{(int)hFocusWindow:X8}, bUseStencilBuffer:{bUseStencilBuffer:X2}, bSoftwareVertexProcessing:{bSoftwareVertexProcessing:X2}, bUsePureDevice:{bUsePureDevice:X2}";
    }
    public unsafe struct RenderDevicePresentation {
        // Struct:
        public HWND__* hRenderWindow;
        public UInt32 Width;
        public UInt32 Height;
        public Byte FullScreen;
        public UInt32 FSRefreshRate;
        public UInt32 FSBitsPerPixel;
        public Byte FSTripleBuffering;
        public Byte FSSyncToDisplayRefresh;
        public Byte Antialiasing;
        public override string ToString() => $"hRenderWindow:->(HWND__*)0x{(int)hRenderWindow:X8}, Width:{Width:X8}, Height:{Height:X8}, FullScreen:{FullScreen:X2}, FSRefreshRate:{FSRefreshRate:X8}, FSBitsPerPixel:{FSBitsPerPixel:X8}, FSTripleBuffering:{FSTripleBuffering:X2}, FSSyncToDisplayRefresh:{FSSyncToDisplayRefresh:X2}, Antialiasing:{Antialiasing:X2}";

        // Functions:

        // RenderDevicePresentation.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RenderDevicePresentation, void>)0x00439140)(ref this); // .text:00438E40 ; void __thiscall RenderDevicePresentation::RenderDevicePresentation(RenderDevicePresentation *this) .text:00438E40 ??0RenderDevicePresentation@@QAE@XZ
    }
    public unsafe struct ViewIntervalType {
        // Struct:
        public fixed int bound[32];
        public override string ToString() => $"bound[0](fixed int):{bound[0]:X8}";
    }
    public unsafe struct polyListEntry {
        // Struct:
        public CPolygon* poly;
        public int planeMask;
        public override string ToString() => $"poly:->(CPolygon*)0x{(int)poly:X8}, planeMask(int):{planeMask}";
    }
    public unsafe struct HWLightUsage {
        // Struct:
        public Byte carryOver;
        public int lightClass;
        public int index;
        public override string ToString() => $"carryOver:{carryOver:X2}, lightClass(int):{lightClass}, index(int):{index}";
    }
    public unsafe struct LightParms {
        // Struct:
        public RGBColor ambient_color;
        public RGBColor sunlight_color;
        public AC1Legacy.Vector3 sunlight;
        public Byte m_bSunlightValid;
        public RenderLight m_Sunlight;
        public int num_static_lights;
        public fixed int static_lights[60];
        public fixed int sorted_static_lights[60];
        public int num_dynamic_lights;
        public fixed int dynamic_lights[10];
        public fixed int sorted_dynamic_lights[10];
        public override string ToString() => $"ambient_color(RGBColor):{ambient_color}, sunlight_color(RGBColor):{sunlight_color}, sunlight(AC1Legacy.Vector3):{sunlight}, m_bSunlightValid:{m_bSunlightValid:X2}, m_Sunlight(RenderLight):{m_Sunlight}, num_static_lights(int):{num_static_lights}, static_lights[60](fixed int):{static_lights[60]}, sorted_static_lights[60](fixed int):{sorted_static_lights[60]}, num_dynamic_lights(int):{num_dynamic_lights}, dynamic_lights[10](fixed int):{dynamic_lights[10]}, sorted_dynamic_lights[10](fixed int):{sorted_dynamic_lights[10]}";

        // Functions:

        // LightParms.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref LightParms, void>)0xDEADBEEF)(ref this); // .text:0054D7A0 ; void __thiscall LightParms::LightParms(LightParms *this) .text:0054D7A0 ??0LightParms@@QAE@XZ
    }
    public unsafe struct RenderDeviceCaps {
        // Struct:
        public UInt32 MaxTextureWidth;
        public UInt32 MaxTextureHeight;
        public UInt32 MaxSimultaneousTextures;
        public UInt32 MaxTextureBlendStages;
        public UInt32 MaxSimultaneousRenderTargets;
        public UInt32 MaxActiveLights;
        public UInt32 MaxUserClipPlanes;
        public Byte bCanDoSinglePassDetailing;
        public Byte bTexOpDotProduct3;
        public Byte bTexOpBumpEnvMap;
        public Byte bDestinationAlpha;
        public Byte bSquareTexturesOnly;
        public Byte b3DTextures;
        public Byte bCubeTextures;
        public Byte bColorWriteControl;
        public Byte bHardwareVertexProcessing;
        public Byte bOcclusionQueries;
        public Byte bSimpleNonPowerOfTwoTextures;
        public Byte bPointSprites;
        public Byte bAutoGenMipMaps;
        public Byte bDynamicTextures;
        public Byte bSlopeScaleDepthBias;
        public Byte bBlendOp;
        public Byte bTwoSidedStencil;
        public Byte bCompressedTextures;
        public override string ToString() => $"MaxTextureWidth:{MaxTextureWidth:X8}, MaxTextureHeight:{MaxTextureHeight:X8}, MaxSimultaneousTextures:{MaxSimultaneousTextures:X8}, MaxTextureBlendStages:{MaxTextureBlendStages:X8}, MaxSimultaneousRenderTargets:{MaxSimultaneousRenderTargets:X8}, MaxActiveLights:{MaxActiveLights:X8}, MaxUserClipPlanes:{MaxUserClipPlanes:X8}, bCanDoSinglePassDetailing:{bCanDoSinglePassDetailing:X2}, bTexOpDotProduct3:{bTexOpDotProduct3:X2}, bTexOpBumpEnvMap:{bTexOpBumpEnvMap:X2}, bDestinationAlpha:{bDestinationAlpha:X2}, bSquareTexturesOnly:{bSquareTexturesOnly:X2}, b3DTextures:{b3DTextures:X2}, bCubeTextures:{bCubeTextures:X2}, bColorWriteControl:{bColorWriteControl:X2}, bHardwareVertexProcessing:{bHardwareVertexProcessing:X2}, bOcclusionQueries:{bOcclusionQueries:X2}, bSimpleNonPowerOfTwoTextures:{bSimpleNonPowerOfTwoTextures:X2}, bPointSprites:{bPointSprites:X2}, bAutoGenMipMaps:{bAutoGenMipMaps:X2}, bDynamicTextures:{bDynamicTextures:X2}, bSlopeScaleDepthBias:{bSlopeScaleDepthBias:X2}, bBlendOp:{bBlendOp:X2}, bTwoSidedStencil:{bTwoSidedStencil:X2}, bCompressedTextures:{bCompressedTextures:X2}";
    }
    public unsafe struct RenderDeviceDisplayInfo {
        // Struct:
        public Byte bStencilBuffer;
        public Byte bTextureRenderTargets;
        public Byte bMultiSampling;
        public Byte bMultiSample_2_Samples;
        public Byte bMultiSample_4_Samples;
        public PixelFormatID pfRenderTargets;
        public PixelFormatID pfDepthBuffers;
        public PixelFormatID pfRGBTextures;
        public PixelFormatID pfARGBTextures;
        public PixelFormatID pfAlphaTextures;
        public PixelFormatID pfRGBSurfaces;
        public PixelFormatID pfARGBSurfaces;
        public PixelFormatID pfAlphaSurfaces;
        public PixelFormatID pfLowRGBSurfaces;
        public PixelFormatID pfLowARGBSurfaces;
        public PixelFormatID pfLowAlphaSurfaces;
        public override string ToString() => $"bStencilBuffer:{bStencilBuffer:X2}, bTextureRenderTargets:{bTextureRenderTargets:X2}, bMultiSampling:{bMultiSampling:X2}, bMultiSample_2_Samples:{bMultiSample_2_Samples:X2}, bMultiSample_4_Samples:{bMultiSample_4_Samples:X2}, pfRenderTargets(PixelFormatID):{pfRenderTargets}, pfDepthBuffers(PixelFormatID):{pfDepthBuffers}, pfRGBTextures(PixelFormatID):{pfRGBTextures}, pfARGBTextures(PixelFormatID):{pfARGBTextures}, pfAlphaTextures(PixelFormatID):{pfAlphaTextures}, pfRGBSurfaces(PixelFormatID):{pfRGBSurfaces}, pfARGBSurfaces(PixelFormatID):{pfARGBSurfaces}, pfAlphaSurfaces(PixelFormatID):{pfAlphaSurfaces}, pfLowRGBSurfaces(PixelFormatID):{pfLowRGBSurfaces}, pfLowARGBSurfaces(PixelFormatID):{pfLowARGBSurfaces}, pfLowAlphaSurfaces(PixelFormatID):{pfLowAlphaSurfaces}";
    }
    public unsafe struct TextureBasedFont {
        // Struct:
        public Turbine_RefCount a0;
        public UInt32 m_SourceFontDID;
        public RenderTexture* m_pTexture;
        public RenderMaterial* m_pMaterial;
        public UInt16 m_FirstUnicodeCharacter;
        public UInt16 m_LastUnicodeCharacter;
        public UInt32 m_MaxCharacterHeight;
        public UInt32 m_HorizontalSpacing;
        public UInt32 m_VerticalSpacing;
        public FixedArray<TextureBasedFontCharacter> m_Characters;
        public Byte m_IsReadyToRender;
        public Byte m_QueuedTextUsesScaling;
        public override string ToString() => $"a0(Turbine_RefCount):{a0}, m_SourceFontDID:{m_SourceFontDID:X8}, m_pTexture:->(RenderTexture*)0x{(int)m_pTexture:X8}, m_pMaterial:->(RenderMaterial*)0x{(int)m_pMaterial:X8}, m_FirstUnicodeCharacter:{m_FirstUnicodeCharacter:X4}, m_LastUnicodeCharacter:{m_LastUnicodeCharacter:X4}, m_MaxCharacterHeight:{m_MaxCharacterHeight:X8}, m_HorizontalSpacing:{m_HorizontalSpacing:X8}, m_VerticalSpacing:{m_VerticalSpacing:X8}, m_Characters(FixedArray<TextureBasedFontCharacter>):{m_Characters}, m_IsReadyToRender:{m_IsReadyToRender:X2}, m_QueuedTextUsesScaling:{m_QueuedTextUsesScaling:X2}";

        // Functions:

        // TextureBasedFont.BeginRenderingText:
        // public void BeginRenderingText() => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, void>)0xDEADBEEF)(ref this); // .text:00696190 ; void __thiscall TextureBasedFont::BeginRenderingText(TextureBasedFont *this) .text:00696190 ?BeginRenderingText@TextureBasedFont@@QAEXXZ

        // TextureBasedFont.ComputeTextWidth:
        // public UInt32 ComputeTextWidth(char* _pText, UInt32 _Flags) => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, char*, UInt32, UInt32>)0xDEADBEEF)(ref this, _pText, _Flags); // .text:006966E0 ; unsigned int __thiscall TextureBasedFont::ComputeTextWidth(TextureBasedFont *this, const char *_pText, const unsigned int _Flags) .text:006966E0 ?ComputeTextWidth@TextureBasedFont@@QAEKPBDK@Z

        // TextureBasedFont.CreateFromFont:
        // public static TResult* CreateFromFont(TResult* result, UInt32 _FontID, TextureBasedFont** _pOutObject) => ((delegate* unmanaged[Cdecl]<TResult*, UInt32, TextureBasedFont**, TResult*>)0xDEADBEEF)(result, _FontID, _pOutObject); // .text:00697630 ; TResult *__cdecl TextureBasedFont::CreateFromFont(TResult *result, const unsigned int _FontID, TextureBasedFont **_pOutObject) .text:00697630 ?CreateFromFont@TextureBasedFont@@SA?AVTResult@@KAAPAV1@@Z

        // TextureBasedFont.EndRenderingText:
        // public void EndRenderingText() => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, void>)0xDEADBEEF)(ref this); // .text:00696610 ; void __thiscall TextureBasedFont::EndRenderingText(TextureBasedFont *this) .text:00696610 ?EndRenderingText@TextureBasedFont@@QAEXXZ

        // TextureBasedFont.InitFromFont:
        // public Byte InitFromFont(UInt32 _FontID) => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, UInt32, Byte>)0xDEADBEEF)(ref this, _FontID); // .text:006974A0 ; bool __thiscall TextureBasedFont::InitFromFont(TextureBasedFont *this, const unsigned int _FontID) .text:006974A0 ?InitFromFont@TextureBasedFont@@AAE_NK@Z

        // TextureBasedFont.RenderText:
        // public void RenderText(int _X, int _Y, char* _pText, UInt32 _Color32, UInt32 _Flags) => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, int, int, char*, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _X, _Y, _pText, _Color32, _Flags); // .text:00697470 ; void __thiscall TextureBasedFont::RenderText(TextureBasedFont *this, const int _X, const int _Y, const char *_pText, const unsigned int _Color32, const unsigned int _Flags) .text:00697470 ?RenderText@TextureBasedFont@@QAEXJJPBDKK@Z

        // TextureBasedFont.RenderText:
        // public void RenderText(Single _X, Single _Y, Single _Scale, char* _pText, UInt32 _Color32, UInt32 _Flags) => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, Single, Single, Single, char*, UInt32, UInt32, void>)0xDEADBEEF)(ref this, _X, _Y, _Scale, _pText, _Color32, _Flags); // .text:006968B0 ; void __thiscall TextureBasedFont::RenderText(TextureBasedFont *this, const float _X, const float _Y, const float _Scale, const char *_pText, const unsigned int _Color32, const unsigned int _Flags) .text:006968B0 ?RenderText@TextureBasedFont@@QAEXMMMPBDKK@Z

        // TextureBasedFont.SetupFontTexture:
        // public Byte SetupFontTexture() => ((delegate* unmanaged[Thiscall]<ref TextureBasedFont, Byte>)0xDEADBEEF)(ref this); // .text:00696280 ; bool __thiscall TextureBasedFont::SetupFontTexture(TextureBasedFont *this) .text:00696280 ?SetupFontTexture@TextureBasedFont@@AAE_NXZ
    }
    public unsafe struct TextureBasedFontCharacter {
        // Struct:
        public Single m_U0;
        public Single m_V0;
        public Single m_U1;
        public Single m_V1;
        public char m_Width;
        public char m_Height;
        public char m_HorizontalOffsetBefore;
        public char m_HorizontalOffsetAfter;
        public char m_VerticalOffsetBefore;
        public override string ToString() => $"m_U0:{m_U0:n5}, m_V0:{m_V0:n5}, m_U1:{m_U1:n5}, m_V1:{m_V1:n5}, m_Width(char):{m_Width}, m_Height(char):{m_Height}, m_HorizontalOffsetBefore(char):{m_HorizontalOffsetBefore}, m_HorizontalOffsetAfter(char):{m_HorizontalOffsetAfter}, m_VerticalOffsetBefore(char):{m_VerticalOffsetBefore}";
    }

    public unsafe struct RenderMaterial {
        // Struct:
        public DBObj a0;
        public Byte m_IsInstance;
        public MaterialModifier properties;
        public SmartArray<PTR<MaterialLayer>> layers;
        public SmartArray<PStringBase<char>> m_MaterialShaderConstantNames;
        public SmartArray<MaterialShaderConstant> m_MaterialShaderConstants;
        public Byte m_IsOptimized;
        public Byte m_SupportsLighting;
        public Byte m_SupportsMultiPassLighting;
        public Byte m_SupportsCombinedAmbientPass;
        public Byte m_SupportsGlowing;
        public Byte m_NeedsAlphaBlendPass;
        public Byte m_UsesVideoPost;
        public Single m_Opacity;
        // (ERR)   char m_LayerIndices[45][8][3];
        public override string ToString() => $"a0(DBObj):{a0}, m_IsInstance:{m_IsInstance:X2}, properties(MaterialModifier):{properties}, layers(SmartArray<MaterialLayer*,1>):{layers}, m_MaterialShaderConstantNames(SmartArray<PStringBase<char>,1>):{m_MaterialShaderConstantNames}, m_MaterialShaderConstants(SmartArray<MaterialShaderConstant,1>):{m_MaterialShaderConstants}, m_IsOptimized:{m_IsOptimized:X2}, m_SupportsLighting:{m_SupportsLighting:X2}, m_SupportsMultiPassLighting:{m_SupportsMultiPassLighting:X2}, m_SupportsCombinedAmbientPass:{m_SupportsCombinedAmbientPass:X2}, m_SupportsGlowing:{m_SupportsGlowing:X2}, m_NeedsAlphaBlendPass:{m_NeedsAlphaBlendPass:X2}, m_UsesVideoPost:{m_UsesVideoPost:X2}, m_Opacity:{m_Opacity:n5}";

        // Functions:

        // RenderMaterial.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, void>)0xDEADBEEF)(ref this); // .text:004496A0 ; void __thiscall RenderMaterial::RenderMaterial(RenderMaterial *this) .text:004496A0 ??0RenderMaterial@@QAE@XZ

        // RenderMaterial.Allocate:
        // public DBObj* Allocate() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, DBObj*>)0xDEADBEEF)(ref this); // .text:00449800 ; DBObj *__thiscall RenderMaterial::Allocate(RenderMaterial *this) .text:00449800 ?Allocate@RenderMaterial@@UBEPAVDBObj@@XZ

        // RenderMaterial.Allocator:
        // public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0xDEADBEEF)(); // .text:00449810 ; DBObj *__cdecl RenderMaterial::Allocator() .text:00449810 ?Allocator@RenderMaterial@@SAPAVDBObj@@XZ

        // RenderMaterial.CheckOutputField:
        // public Byte CheckOutputField(PStringBase<char>* propString, RMFieldType fieldType, RMDataType dataType, UInt32 index1, UInt32 index2) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, PStringBase<char>*, RMFieldType, RMDataType, UInt32, UInt32, Byte>)0xDEADBEEF)(ref this, propString, fieldType, dataType, index1, index2); // .text:004492E0 ; bool __thiscall RenderMaterial::CheckOutputField(RenderMaterial *this, PStringBase<char> *propString, RMFieldType fieldType, RMDataType dataType, const unsigned int index1, const unsigned int index2) .text:004492E0 ?CheckOutputField@RenderMaterial@@QBE_NAAV?$PStringBase@D@@W4RMFieldType@@W4RMDataType@@KK@Z

        // RenderMaterial.CheckParseField:
        // public Byte CheckParseField(PStringBase<char>* test, RMFieldType fieldType, RMDataType dataType, UInt32 index1, UInt32 index2) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, PStringBase<char>*, RMFieldType, RMDataType, UInt32, UInt32, Byte>)0xDEADBEEF)(ref this, test, fieldType, dataType, index1, index2); // .text:0044A0C0 ; bool __thiscall RenderMaterial::CheckParseField(RenderMaterial *this, PStringBase<char> *test, RMFieldType fieldType, RMDataType dataType, const unsigned int index1, const unsigned int index2) .text:0044A0C0 ?CheckParseField@RenderMaterial@@QAE_NABV?$PStringBase@D@@W4RMFieldType@@W4RMDataType@@KK@Z

        // RenderMaterial.CopyInto:
        public Byte CopyInto(DBObj* retval) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, DBObj*, Byte>)0x00449A60)(ref this, retval); // .text:00449920 ; bool __thiscall RenderMaterial::CopyInto(RenderMaterial *this, DBObj *retval) .text:00449920 ?CopyInto@RenderMaterial@@UBE_NAAVDBObj@@@Z

        // RenderMaterial.Destroy:
        // public void Destroy() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, void>)0xDEADBEEF)(ref this); // .text:00449BB0 ; void __thiscall RenderMaterial::Destroy(RenderMaterial *this) .text:00449BB0 ?Destroy@RenderMaterial@@UAEXXZ

        // RenderMaterial.End:
        public void End() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, void>)0x00449970)(ref this); // .text:00449830 ; void __thiscall RenderMaterial::End(RenderMaterial *this) .text:00449830 ?End@RenderMaterial@@AAEXXZ

        // RenderMaterial.GetDBOType:
        // public UInt32 GetDBOType() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, UInt32>)0xDEADBEEF)(ref this); // .text:00449740 ; unsigned int __thiscall RenderMaterial::GetDBOType(RenderMaterial *this) .text:00449740 ?GetDBOType@RenderMaterial@@UBEKXZ

        // RenderMaterial.GetSubDataIDs:
        // public void GetSubDataIDs(QualifiedDataIDArray* id_array) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, QualifiedDataIDArray*, void>)0xDEADBEEF)(ref this, id_array); // .text:004495D0 ; void __thiscall RenderMaterial::GetSubDataIDs(RenderMaterial *this, QualifiedDataIDArray *id_array) .text:004495D0 ?GetSubDataIDs@RenderMaterial@@UBEXAAVQualifiedDataIDArray@@@Z

        // RenderMaterial.GetSubObjects:
        // public Byte GetSubObjects() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, Byte>)0xDEADBEEF)(ref this); // .text:00449D90 ; bool __thiscall RenderMaterial::GetSubObjects(RenderMaterial *this) .text:00449D90 ?GetSubObjects@RenderMaterial@@UAE_NXZ

        // RenderMaterial.InsertLayer:
        // public void InsertLayer(UInt32 index, MaterialLayer* _pLayer) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, UInt32, MaterialLayer*, void>)0xDEADBEEF)(ref this, index, _pLayer); // .text:0043FE20 ; void __thiscall RenderMaterial::InsertLayer(RenderMaterial *this, const unsigned int index, MaterialLayer *_pLayer) .text:0043FE20 ?InsertLayer@RenderMaterial@@QAEXKPAVMaterialLayer@@@Z

        // RenderMaterial.Optimize:
        // public void Optimize() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, void>)0xDEADBEEF)(ref this); // .text:004493A0 ; void __thiscall RenderMaterial::Optimize(RenderMaterial *this) .text:004493A0 ?Optimize@RenderMaterial@@QAEXXZ

        // RenderMaterial.ReleaseSubObjects:
        // public Byte ReleaseSubObjects() => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, Byte>)0xDEADBEEF)(ref this); // .text:00449750 ; bool __thiscall RenderMaterial::ReleaseSubObjects(RenderMaterial *this) .text:00449750 ?ReleaseSubObjects@RenderMaterial@@UAE_NXZ

        // RenderMaterial.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref RenderMaterial, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:00449C10 ; void __thiscall RenderMaterial::Serialize(RenderMaterial *this, Archive *io_archive) .text:00449C10 ?Serialize@RenderMaterial@@MAEXAAVArchive@@@Z
    }
    public unsafe struct MaterialModifier {
        // Struct:
        public DBObj a0;
        public SmartArray<PTR<MaterialProperty>> properties;
        public override string ToString() => $"a0(DBObj):{a0}, properties(SmartArray<MaterialProperty*,1>):{properties}";

        // Functions:

        // MaterialModifier.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, void>)0xDEADBEEF)(ref this); // .text:00450440 ; void __thiscall MaterialModifier::MaterialModifier(MaterialModifier *this) .text:00450440 ??0MaterialModifier@@QAE@XZ

        // MaterialModifier.Allocate:
        // public DBObj* Allocate() => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, DBObj*>)0xDEADBEEF)(ref this); // .text:00450550 ; DBObj *__thiscall MaterialModifier::Allocate(MaterialModifier *this) .text:00450550 ?Allocate@MaterialModifier@@UBEPAVDBObj@@XZ

        // MaterialModifier.Allocator:
        // public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0xDEADBEEF)(); // .text:00450560 ; DBObj *__cdecl MaterialModifier::Allocator() .text:00450560 ?Allocator@MaterialModifier@@SAPAVDBObj@@XZ

        // MaterialModifier.CopyInto:
        // public Byte CopyInto(DBObj* retval) => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, DBObj*, Byte>)0xDEADBEEF)(ref this, retval); // .text:00450640 ; bool __thiscall MaterialModifier::CopyInto(MaterialModifier *this, DBObj *retval) .text:00450640 ?CopyInto@MaterialModifier@@UBE_NAAVDBObj@@@Z

        // MaterialModifier.End:
        // public void End() => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, void>)0xDEADBEEF)(ref this); // .text:00450480 ; void __thiscall MaterialModifier::End(MaterialModifier *this) .text:00450480 ?End@MaterialModifier@@IAEXXZ

        // MaterialModifier.GetSubDataIDs:
        // public void GetSubDataIDs(QualifiedDataIDArray* id_array) => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, QualifiedDataIDArray*, void>)0xDEADBEEF)(ref this, id_array); // .text:004503B0 ; void __thiscall MaterialModifier::GetSubDataIDs(MaterialModifier *this, QualifiedDataIDArray *id_array) .text:004503B0 ?GetSubDataIDs@MaterialModifier@@UBEXAAVQualifiedDataIDArray@@@Z

        // MaterialModifier.GetSubObjects:
        // public Byte GetSubObjects() => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, Byte>)0xDEADBEEF)(ref this); // .text:004503E0 ; bool __thiscall MaterialModifier::GetSubObjects(MaterialModifier *this) .text:004503E0 ?GetSubObjects@MaterialModifier@@UAE_NXZ

        // MaterialModifier.ReleaseSubObjects:
        // public Byte ReleaseSubObjects() => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, Byte>)0xDEADBEEF)(ref this); // .text:00450410 ; bool __thiscall MaterialModifier::ReleaseSubObjects(MaterialModifier *this) .text:00450410 ?ReleaseSubObjects@MaterialModifier@@UAE_NXZ

        // MaterialModifier.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref MaterialModifier, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:004506C0 ; void __thiscall MaterialModifier::Serialize(MaterialModifier *this, Archive *io_archive) .text:004506C0 ?Serialize@MaterialModifier@@UAEXAAVArchive@@@Z
    }
    public unsafe struct MaterialProperty {
        // Struct:
        public PStringBase<char> name;
        public UInt32 nameID;
        public RMDataType dataType;
        public UInt32 dataLength;
        public void* data;
        public PStringBase<char> dataName;
        public Byte m_IsShaderConstant;
        public SmartArray<PTR<MaterialField>> fields;
        public RenderTexture* m_pCachedTexture;
        public override string ToString() => $"name(PStringBase<char>):{name}, nameID:{nameID:X8}, dataType(RMDataType):{dataType}, dataLength:{dataLength:X8}, data:->(void*)0x{(int)data:X8}, dataName(PStringBase<char>):{dataName}, m_IsShaderConstant:{m_IsShaderConstant:X2}, fields(SmartArray<MaterialField*,1>):{fields}, m_pCachedTexture:->(RenderTexture*)0x{(int)m_pCachedTexture:X8}";

        // Functions:

        // MaterialProperty.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, void>)0xDEADBEEF)(ref this); // .text:0044FD70 ; void __thiscall MaterialProperty::MaterialProperty(MaterialProperty *this) .text:0044FD70 ??0MaterialProperty@@QAE@XZ

        // MaterialProperty.Apply:
        // public void Apply(RenderMaterial* material, MaterialProperty* refProp) => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, RenderMaterial*, MaterialProperty*, void>)0xDEADBEEF)(ref this, material, refProp); // .text:0044FAB0 ; void __thiscall MaterialProperty::Apply(MaterialProperty *this, RenderMaterial *material, MaterialProperty *refProp) .text:0044FAB0 ?Apply@MaterialProperty@@QAEXAAVRenderMaterial@@ABV1@@Z

        // MaterialProperty.Begin:
        // public void Begin() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, void>)0xDEADBEEF)(ref this); // .text:0044FA10 ; void __thiscall MaterialProperty::Begin(MaterialProperty *this) .text:0044FA10 ?Begin@MaterialProperty@@IAEXXZ

        // MaterialProperty.Copy:
        // public MaterialProperty* Copy() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, MaterialProperty*>)0xDEADBEEF)(ref this); // .text:00450340 ; MaterialProperty *__thiscall MaterialProperty::Copy(MaterialProperty *this) .text:00450340 ?Copy@MaterialProperty@@QBEPAV1@XZ

        // MaterialProperty.CopyInto:
        // public Byte CopyInto(MaterialProperty* target) => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, MaterialProperty*, Byte>)0xDEADBEEF)(ref this, target); // .text:0044FF50 ; bool __thiscall MaterialProperty::CopyInto(MaterialProperty *this, MaterialProperty *target) .text:0044FF50 ?CopyInto@MaterialProperty@@QBE_NAAV1@@Z

        // MaterialProperty.End:
        // public void End() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, void>)0xDEADBEEF)(ref this); // .text:0044FDC0 ; void __thiscall MaterialProperty::End(MaterialProperty *this) .text:0044FDC0 ?End@MaterialProperty@@IAEXXZ

        // MaterialProperty.GetSubDataIDs:
        // public void GetSubDataIDs(QualifiedDataIDArray* id_array) => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, QualifiedDataIDArray*, void>)0xDEADBEEF)(ref this, id_array); // .text:0044FEA0 ; void __thiscall MaterialProperty::GetSubDataIDs(MaterialProperty *this, QualifiedDataIDArray *id_array) .text:0044FEA0 ?GetSubDataIDs@MaterialProperty@@QBEXAAVQualifiedDataIDArray@@@Z

        // MaterialProperty.GetSubObjects:
        // public Byte GetSubObjects() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, Byte>)0xDEADBEEF)(ref this); // .text:0044FD10 ; bool __thiscall MaterialProperty::GetSubObjects(MaterialProperty *this) .text:0044FD10 ?GetSubObjects@MaterialProperty@@QAE_NXZ

        // MaterialProperty.ReleaseSubObjects:
        // public Byte ReleaseSubObjects() => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, Byte>)0xDEADBEEF)(ref this); // .text:0044F9F0 ; bool __thiscall MaterialProperty::ReleaseSubObjects(MaterialProperty *this) .text:0044F9F0 ?ReleaseSubObjects@MaterialProperty@@QAE_NXZ

        // MaterialProperty.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref MaterialProperty, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:004500E0 ; void __thiscall MaterialProperty::Serialize(MaterialProperty *this, Archive *io_archive) .text:004500E0 ?Serialize@MaterialProperty@@QAEXAAVArchive@@@Z
    }
    public unsafe struct MaterialField {
        // Struct:
        public RMFieldType fieldType;
        public RMDataType dataType;
        public UInt32 layerIndex;
        public UInt32 tcIndex; // union unsigned int stageIndex; union unsigned int modifierIndex;

        public override string ToString() => $"fieldType(RMFieldType):{fieldType}, dataType(RMDataType):{dataType}, layerIndex:{layerIndex:X8}, tcIndex:{tcIndex:X8}";
    }

    public unsafe struct MaterialLayer {
        // Struct:
        public UInt32 m_Options;
        public UInt32 m_TrueFlags;
        public UInt32 m_FalseFlags;
        public RenderPassType m_RenderPass;
        public SmartArray<ShaderResourceType> m_ShaderResources;
        public SmartArray<PTR<LayerStage>> m_Stages;
        public SmartArray<PTR<LayerModifier>> m_FFModifiers;
        public BlendMode m_SourceBlend;
        public BlendMode m_DestBlend;
        public BlendOpType m_BlendOp;
        public DepthTestMode m_DepthTest;
        public Byte m_DepthWrite;
        public CullModeType m_CullMode;
        public Byte m_AlphaTest;
        public Waveform m_AlphaTestRef;
        public RGBAColor m_cDiffuse;
        public RGBAColor m_cSpecular;
        public Waveform m_wSpecularPower;
        public RGBAColor m_cDye;
        public override string ToString() => $"m_Options:{m_Options:X8}, m_TrueFlags:{m_TrueFlags:X8}, m_FalseFlags:{m_FalseFlags:X8}, m_RenderPass(RenderPassType):{m_RenderPass}, m_ShaderResources(SmartArray<ShaderResourceType,1>):{m_ShaderResources}, m_Stages(SmartArray<LayerStage*,1>):{m_Stages}, m_FFModifiers(SmartArray<LayerModifier*,1>):{m_FFModifiers}, m_SourceBlend(BlendMode):{m_SourceBlend}, m_DestBlend(BlendMode):{m_DestBlend}, m_BlendOp(BlendOpType):{m_BlendOp}, m_DepthTest(DepthTestMode):{m_DepthTest}, m_DepthWrite:{m_DepthWrite:X2}, m_CullMode(CullModeType):{m_CullMode}, m_AlphaTest:{m_AlphaTest:X2}, m_AlphaTestRef(Waveform):{m_AlphaTestRef}, m_cDiffuse(RGBAColor):{m_cDiffuse}, m_cSpecular(RGBAColor):{m_cSpecular}, m_wSpecularPower(Waveform):{m_wSpecularPower}, m_cDye(RGBAColor):{m_cDye}";

        // Functions:

        // MaterialLayer.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, void>)0xDEADBEEF)(ref this); // .text:0044A900 ; void __thiscall MaterialLayer::MaterialLayer(MaterialLayer *this) .text:0044A900 ??0MaterialLayer@@QAE@XZ

        // MaterialLayer.Begin:
        public void Begin() => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, void>)0x0044A930)(ref this); // .text:0044A7F0 ; void __thiscall MaterialLayer::Begin(MaterialLayer *this) .text:0044A7F0 ?Begin@MaterialLayer@@AAEXXZ

        // MaterialLayer.Copy:
        // public MaterialLayer* Copy(Byte _IsInstance) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Byte, MaterialLayer*>)0xDEADBEEF)(ref this, _IsInstance); // .text:0044B4B0 ; MaterialLayer *__thiscall MaterialLayer::Copy(MaterialLayer *this, const bool _IsInstance) .text:0044B4B0 ?Copy@MaterialLayer@@QBEPAV1@_N@Z

        // MaterialLayer.CopyInto:
        // public Byte CopyInto(Byte _IsInstance, MaterialLayer* target) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Byte, MaterialLayer*, Byte>)0xDEADBEEF)(ref this, _IsInstance, target); // .text:0044A940 ; bool __thiscall MaterialLayer::CopyInto(MaterialLayer *this, const bool _IsInstance, MaterialLayer *target) .text:0044A940 ?CopyInto@MaterialLayer@@QBE_N_NAAV1@@Z

        // MaterialLayer.End:
        public void End() => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, void>)0x0044A4F0)(ref this); // .text:0044A3B0 ; void __thiscall MaterialLayer::End(MaterialLayer *this) .text:0044A3B0 ?End@MaterialLayer@@AAEXXZ

        // MaterialLayer.GetSubObjects:
        // public Byte GetSubObjects(SmartArray<PStringBase<char>>* _MaterialShaderConstants) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, SmartArray<PStringBase<char>>*, Byte>)0xDEADBEEF)(ref this, _MaterialShaderConstants); // .text:0044A200 ; bool __thiscall MaterialLayer::GetSubObjects(MaterialLayer *this, SmartArray<PStringBase<char>,1> *_MaterialShaderConstants) .text:0044A200 ?GetSubObjects@MaterialLayer@@QAE_NABV?$SmartArray@V?$PStringBase@D@@$00@@@Z

        // MaterialLayer.InsertStage:
        // public void InsertStage(UInt32 _Index, LayerStage* _pStage) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, UInt32, LayerStage*, void>)0xDEADBEEF)(ref this, _Index, _pStage); // .text:0043FE00 ; void __thiscall MaterialLayer::InsertStage(MaterialLayer *this, const unsigned int _Index, LayerStage *_pStage) .text:0043FE00 ?InsertStage@MaterialLayer@@QAEXKPAVLayerStage@@@Z

        // MaterialLayer.ReleaseSubObjects:
        // public Byte ReleaseSubObjects() => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Byte>)0xDEADBEEF)(ref this); // .text:0044A240 ; bool __thiscall MaterialLayer::ReleaseSubObjects(MaterialLayer *this) .text:0044A240 ?ReleaseSubObjects@MaterialLayer@@QAE_NXZ

        // MaterialLayer.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:0044AE20 ; void __thiscall MaterialLayer::Serialize(MaterialLayer *this, Archive *io_archive) .text:0044AE20 ?Serialize@MaterialLayer@@QAEXAAVArchive@@@Z

        // MaterialLayer.SetAlphaTestRef:
        // public void SetAlphaTestRef(Waveform* _w) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Waveform*, void>)0xDEADBEEF)(ref this, _w); // .text:0044F930 ; void __thiscall MaterialLayer::SetAlphaTestRef(MaterialLayer *this, Waveform *_w) .text:0044F930 ?SetAlphaTestRef@MaterialLayer@@QAEXABVWaveform@@@Z

        // MaterialLayer.SetDiffuse:
        public void SetDiffuse(RGBAColor* _cColor) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, RGBAColor*, void>)0x0043DC50)(ref this, _cColor); // .text:0043DAB0 ; void __thiscall MaterialLayer::SetDiffuse(MaterialLayer *this, RGBAColor *_cColor) .text:0043DAB0 ?SetDiffuse@MaterialLayer@@QAEXABVRGBAColor@@@Z

        // MaterialLayer.SetSpecularPower:
        // public void SetSpecularPower(Waveform* _wWave) => ((delegate* unmanaged[Thiscall]<ref MaterialLayer, Waveform*, void>)0xDEADBEEF)(ref this, _wWave); // .text:0044F980 ; void __thiscall MaterialLayer::SetSpecularPower(MaterialLayer *this, Waveform *_wWave) .text:0044F980 ?SetSpecularPower@MaterialLayer@@QAEXABVWaveform@@@Z
    }
    public unsafe struct MaterialShaderConstant {
        // Struct:
        public UInt32 m_PropertyType;
        public BasePropertyValue* m_pPropertyValue;
        public override string ToString() => $"m_PropertyType:{m_PropertyType:X8}, m_pPropertyValue:->(BasePropertyValue*)0x{(int)m_pPropertyValue:X8}";
    }
    public unsafe struct ShaderResourceType {
        // Struct:
        public ShaderVersionType Version;
        public PStringBase<char> VertexShaderFunctionName;
        public PStringBase<char> PixelShaderFunctionName;
        public SmartBuffer BinaryVertexShaderData;
        public SmartBuffer BinaryPixelShaderData;
        public override string ToString() => $"Version(ShaderVersionType):{Version}, VertexShaderFunctionName(PStringBase<char>):{VertexShaderFunctionName}, PixelShaderFunctionName(PStringBase<char>):{PixelShaderFunctionName}, BinaryVertexShaderData(SmartBuffer):{BinaryVertexShaderData}, BinaryPixelShaderData(SmartBuffer):{BinaryPixelShaderData}";

        // Functions:

        // ShaderResourceType.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ShaderResourceType, void>)0xDEADBEEF)(ref this); // .text:0044A270 ; void __thiscall ShaderResourceType::ShaderResourceType(ShaderResourceType *this) .text:0044A270 ??0ShaderResourceType@@QAE@XZ

        // ShaderResourceType.operator_equals:
        // public ShaderResourceType* operator_equals() => ((delegate* unmanaged[Thiscall]<ref ShaderResourceType, ShaderResourceType*>)0xDEADBEEF)(ref this); // .text:0044A310 ; public: struct ShaderResourceType & __thiscall ShaderResourceType::operator=(struct ShaderResourceType const &) .text:0044A310 ??4ShaderResourceType@@QAEAAU0@ABU0@@Z
    }
    public unsafe struct LayerStage {
        // Struct:
        public PStringBase<char> m_SamplerName;
        public PStringBase<char> m_TextureFileName;
        public UInt32 m_TextureDID;
        public RenderTexture* m_pTexture;
        public UInt32 m_SpecialTexture;
        public TexAddress m_AddressModeU;
        public TexAddress m_AddressModeV;
        public TexFilterMode m_MinFilterMode;
        public TexFilterMode m_MagFilterMode;
        public TexFilterMode m_MipFilterMode;
        public TextureOp m_FFColorOp;
        public UInt32 m_FFColorArg1;
        public UInt32 m_FFColorArg2;
        public TextureOp m_FFAlphaOp;
        public UInt32 m_FFAlphaArg1;
        public UInt32 m_FFAlphaArg2;
        public UInt32 m_FFTexCoordIndex;
        public Byte m_FFUseProjection;
        public override string ToString() => $"m_SamplerName(PStringBase<char>):{m_SamplerName}, m_TextureFileName(PStringBase<char>):{m_TextureFileName}, m_TextureDID:{m_TextureDID:X8}, m_pTexture:->(RenderTexture*)0x{(int)m_pTexture:X8}, m_SpecialTexture:{m_SpecialTexture:X8}, m_AddressModeU(TexAddress):{m_AddressModeU}, m_AddressModeV(TexAddress):{m_AddressModeV}, m_MinFilterMode(TexFilterMode):{m_MinFilterMode}, m_MagFilterMode(TexFilterMode):{m_MagFilterMode}, m_MipFilterMode(TexFilterMode):{m_MipFilterMode}, m_FFColorOp(TextureOp):{m_FFColorOp}, m_FFColorArg1:{m_FFColorArg1:X8}, m_FFColorArg2:{m_FFColorArg2:X8}, m_FFAlphaOp(TextureOp):{m_FFAlphaOp}, m_FFAlphaArg1:{m_FFAlphaArg1:X8}, m_FFAlphaArg2:{m_FFAlphaArg2:X8}, m_FFTexCoordIndex:{m_FFTexCoordIndex:X8}, m_FFUseProjection:{m_FFUseProjection:X2}";

        // Functions:

        // LayerStage.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref LayerStage, void>)0xDEADBEEF)(ref this); // .text:004481F0 ; void __thiscall LayerStage::LayerStage(LayerStage *this) .text:004481F0 ??0LayerStage@@QAE@XZ

        // LayerStage.Begin:
        // public void Begin() => ((delegate* unmanaged[Thiscall]<ref LayerStage, void>)0xDEADBEEF)(ref this); // .text:00447E10 ; void __thiscall LayerStage::Begin(LayerStage *this) .text:00447E10 ?Begin@LayerStage@@AAEXXZ

        // LayerStage.Copy:
        // public LayerStage* Copy(Byte _IsInstance) => ((delegate* unmanaged[Thiscall]<ref LayerStage, Byte, LayerStage*>)0xDEADBEEF)(ref this, _IsInstance); // .text:00448290 ; LayerStage *__thiscall LayerStage::Copy(LayerStage *this, const bool _IsInstance) .text:00448290 ?Copy@LayerStage@@QBEPAV1@_N@Z

        // LayerStage.CopyInto:
        // public Byte CopyInto(Byte _IsInstance, LayerStage* target) => ((delegate* unmanaged[Thiscall]<ref LayerStage, Byte, LayerStage*, Byte>)0xDEADBEEF)(ref this, _IsInstance, target); // .text:00447EE0 ; bool __thiscall LayerStage::CopyInto(LayerStage *this, const bool _IsInstance, LayerStage *target) .text:00447EE0 ?CopyInto@LayerStage@@QBE_N_NAAV1@@Z

        // LayerStage.GetSubObjects:
        // public Byte GetSubObjects() => ((delegate* unmanaged[Thiscall]<ref LayerStage, Byte>)0xDEADBEEF)(ref this); // .text:00448300 ; bool __thiscall LayerStage::GetSubObjects(LayerStage *this) .text:00448300 ?GetSubObjects@LayerStage@@QAE_NXZ

        // LayerStage.ReleaseSubObjects:
        public Byte ReleaseSubObjects() => ((delegate* unmanaged[Thiscall]<ref LayerStage, Byte>)0x00447F60)(ref this); // .text:00447E00 ; bool __thiscall LayerStage::ReleaseSubObjects(LayerStage *this) .text:00447E00 ?ReleaseSubObjects@LayerStage@@QAE_NXZ

        // LayerStage.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref LayerStage, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:00448380 ; void __thiscall LayerStage::Serialize(LayerStage *this, Archive *io_archive) .text:00448380 ?Serialize@LayerStage@@QAEXAAVArchive@@@Z

        // LayerStage.SetTexture:
        // public Byte SetTexture(PStringBase<char>* _TextureFileName, UInt32 _TextureID) => ((delegate* unmanaged[Thiscall]<ref LayerStage, PStringBase<char>*, UInt32, Byte>)0xDEADBEEF)(ref this, _TextureFileName, _TextureID); // .text:00447FE0 ; bool __thiscall LayerStage::SetTexture(LayerStage *this, PStringBase<char> *_TextureFileName, IDClass<_tagDataID,32,0> _TextureID) .text:00447FE0 ?SetTexture@LayerStage@@QAE_NABV?$PStringBase@D@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // LayerStage.SetTexture:
        // public Byte SetTexture(RenderTexture* _pNewTexture) => ((delegate* unmanaged[Thiscall]<ref LayerStage, RenderTexture*, Byte>)0xDEADBEEF)(ref this, _pNewTexture); // .text:004480A0 ; bool __thiscall LayerStage::SetTexture(LayerStage *this, RenderTexture *_pNewTexture) .text:004480A0 ?SetTexture@LayerStage@@QAE_NPAVRenderTexture@@@Z
    }
    public unsafe struct LayerModifier {
        // Struct:
        public LayerModifier.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(LayerModifier.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<LayerModifier*, LayerModType> _GetType; // LayerModType (__thiscall *GetType)(LayerModifier *this);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, UInt32> GetSize; // unsigned int (__thiscall *GetSize)(LayerModifier *this) __declspec(align(8));
            public static delegate* unmanaged[Thiscall]<LayerModifier*, Byte> DoesModifyVertex; // bool (__thiscall *DoesModifyVertex)(LayerModifier *this);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, LayerModifier*> Copy; // LayerModifier *(__thiscall *Copy)(LayerModifier *this);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, void*, VertexFormatInfo*, void> Apply; // void (__thiscall *Apply)(LayerModifier *this, void *, VertexFormatInfo *);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, Matrix4*, void> ApplyTextureTransform; // void (__thiscall *ApplyTextureTransform)(LayerModifier *this, Matrix4 *);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, Archive*, void> Serialize; // void (__thiscall *Serialize)(LayerModifier *this, Archive *);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, PFileNode*, RenderMaterial*, UInt32, UInt32, Byte> LoadFromFileNode; // bool (__thiscall *LoadFromFileNode)(LayerModifier *this, PFileNode *, RenderMaterial *, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<LayerModifier*, PFileNode*, RenderMaterial*, UInt32, UInt32, Byte> SaveToFileNode; // bool (__thiscall *SaveToFileNode)(LayerModifier *this, PFileNode *, RenderMaterial *, unsigned int, unsigned int);
        }
    }
    public unsafe struct Waveform {
        // Struct:
        public WaveformType type;
        public Single _base;
        public Single base_vel;
        public Single amplitude;
        public Single amplitude_vel;
        public Single phase;
        public Single phase_vel;
        public Single frequency;
        public Single frequency_vel;
        public Single roughness;
        public Single roughness_vel;
        public override string ToString() => $"type(WaveformType):{type}, base:{_base:n5}, base_vel:{base_vel:n5}, amplitude:{amplitude:n5}, amplitude_vel:{amplitude_vel:n5}, phase:{phase:n5}, phase_vel:{phase_vel:n5}, frequency:{frequency:n5}, frequency_vel:{frequency_vel:n5}, roughness:{roughness:n5}, roughness_vel:{roughness_vel:n5}";

        // Functions:

        // Waveform.__Ctor:
        public void __Ctor(Single _base) => ((delegate* unmanaged[Thiscall]<ref Waveform, Single, void>)0x005B2280)(ref this, _base); // .text:005B11D0 ; void __thiscall Waveform::Waveform(Waveform *this, const float _base) .text:005B11D0 ??0Waveform@@QAE@M@Z

        // Waveform.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Waveform, void>)0x005B2250)(ref this); // .text:005B11A0 ; void __thiscall Waveform::Waveform(Waveform *this) .text:005B11A0 ??0Waveform@@QAE@XZ

        // Waveform.operator_equals:
        // public Waveform* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Waveform, Waveform*>)0xDEADBEEF)(ref this); // .text:004254E0 ; public: class Waveform & __thiscall Waveform::operator=(class Waveform const &) .text:004254E0 ??4Waveform@@QAEAAV0@ABV0@@Z

        // Waveform.operator_is_equal:
        // public Byte operator_is_equal(Waveform* _rhs) => ((delegate* unmanaged[Thiscall]<ref Waveform, Waveform*, Byte>)0xDEADBEEF)(ref this, _rhs); // .text:004255F0 ; bool __thiscall Waveform::operator==(Waveform *this, Waveform *_rhs) .text:004255F0 ??8Waveform@@QBE_NABV0@@Z

        // Waveform.GetTypeString:
        public void GetTypeString(PStringBase<char>* dest) => ((delegate* unmanaged[Thiscall]<ref Waveform, PStringBase<char>*, void>)0x005B27A0)(ref this, dest); // .text:005B16F0 ; void __thiscall Waveform::GetTypeString(Waveform *this, PStringBase<char> *dest) .text:005B16F0 ?GetTypeString@Waveform@@QBEXAAV?$PStringBase@D@@@Z

        // Waveform.GetValue:
        public Single GetValue(Double time) => ((delegate* unmanaged[Thiscall]<ref Waveform, Double, Single>)0x005B2230)(ref this, time); // .text:005B1180 ; float __thiscall Waveform::GetValue(Waveform *this, const long double time) .text:005B1180 ?GetValue@Waveform@@QBEMN@Z

        // Waveform.GetValueForPhase:
        public Single GetValueForPhase(Single p, Double time) => ((delegate* unmanaged[Thiscall]<ref Waveform, Single, Double, Single>)0x005B2010)(ref this, p, time); // .text:005B0F60 ; float __thiscall Waveform::GetValueForPhase(Waveform *this, const float p, const long double time) .text:005B0F60 ?GetValueForPhase@Waveform@@QBEMMN@Z

        // Waveform.Output:
        public void Output(PFileNode* baseNode) => ((delegate* unmanaged[Thiscall]<ref Waveform, PFileNode*, void>)0x005B28A0)(ref this, baseNode); // .text:005B17F0 ; void __thiscall Waveform::Output(Waveform *this, PFileNode *baseNode) .text:005B17F0 ?Output@Waveform@@QBEXPAVPFileNode@@@Z

        // Waveform.Parse:
        public Byte Parse(PFileNode* baseNode) => ((delegate* unmanaged[Thiscall]<ref Waveform, PFileNode*, Byte>)0x005B2300)(ref this, baseNode); // .text:005B1250 ; bool __thiscall Waveform::Parse(Waveform *this, PFileNode *baseNode) .text:005B1250 ?Parse@Waveform@@QAE_NPBVPFileNode@@@Z

        // Waveform.Serialize:
        public void Serialize(Archive* _ar) => ((delegate* unmanaged[Thiscall]<ref Waveform, Archive*, void>)0x005B22C0)(ref this, _ar); // .text:005B1210 ; void __thiscall Waveform::Serialize(Waveform *this, Archive *_ar) .text:005B1210 ?Serialize@Waveform@@QAEXAAVArchive@@@Z

        // Waveform.SetDefaults:
        public void SetDefaults() => ((delegate* unmanaged[Thiscall]<ref Waveform, void>)0x005B1FE0)(ref this); // .text:005B0F30 ; void __thiscall Waveform::SetDefaults(Waveform *this) .text:005B0F30 ?SetDefaults@Waveform@@QAEXXZ

        // Waveform.ToString:
        public PStringBase<char>* ToString(PStringBase<char>* result) => ((delegate* unmanaged[Thiscall]<ref Waveform, PStringBase<char>*, PStringBase<char>*>)0x005B2C30)(ref this, result); // .text:005B1B80 ; PStringBase<char> *__thiscall Waveform::ToString(Waveform *this, PStringBase<char> *result) .text:005B1B80 ?ToString@Waveform@@QBE?AV?$PStringBase@D@@XZ

        // Globals:
        public static PerlinNoise* perlinNoise = (PerlinNoise*)0x008EF144; // .data:008EE134 ; PerlinNoise Waveform::perlinNoise .data:008EE134 ?perlinNoise@Waveform@@1VPerlinNoise@@A
    }
    public unsafe struct PerlinNoise {
        // Struct:

        // Functions:

        // PerlinNoise.Init:
        public void Init() => ((delegate* unmanaged[Thiscall]<ref PerlinNoise, void>)0x005B38D0)(ref this); // .text:005B2820 ; void __thiscall PerlinNoise::Init(PerlinNoise *this) .text:005B2820 ?Init@PerlinNoise@@QAEXXZ

        // PerlinNoise.Noise:
        public Single Noise(Double arg) => ((delegate* unmanaged[Thiscall]<ref PerlinNoise, Double, Single>)0x005B3980)(ref this, arg); // .text:005B28D0 ; float __thiscall PerlinNoise::Noise(PerlinNoise *this, long double arg) .text:005B28D0 ?Noise@PerlinNoise@@QAEMN@Z

        // PerlinNoise.fBm1:
        public Single fBm1(Double point, Double H, Double lacunarity, Double octaves) => ((delegate* unmanaged[Thiscall]<ref PerlinNoise, Double, Double, Double, Double, Single>)0x005B3A10)(ref this, point, H, lacunarity, octaves); // .text:005B2960 ; float __thiscall PerlinNoise::fBm1(PerlinNoise *this, long double point, long double H, long double lacunarity, long double octaves) .text:005B2960 ?fBm1@PerlinNoise@@QAEMNNNN@Z
    }
    public unsafe struct RenderLight {
        // Struct:
        public _D3DLIGHT9 d3dLight;
        public int d3dLightIndex;
        public UInt32 cellID;
        public LIGHTINFO info;
        public Single distancesq;
        public override string ToString() => $"d3dLight(_D3DLIGHT9):{d3dLight}, d3dLightIndex(int):{d3dLightIndex}, cellID:{cellID:X8}, info(LIGHTINFO):{info}, distancesq:{distancesq:n5}";

        // Functions:

        // RenderLight.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref RenderLight, void>)0xDEADBEEF)(ref this); // .text:0054CAC0 ; void __thiscall RenderLight::RenderLight(RenderLight *this) .text:0054CAC0 ??0RenderLight@@QAE@XZ

        // RenderLight.operator_equals:
        // public RenderLight* operator_equals() => ((delegate* unmanaged[Thiscall]<ref RenderLight, RenderLight*>)0xDEADBEEF)(ref this); // .text:0054F2E0 ; public: class RenderLight & __thiscall RenderLight::operator=(class RenderLight const &) .text:0054F2E0 ??4RenderLight@@QAEAAV0@ABV0@@Z
    }
    public unsafe struct _D3DLIGHT9 {
        // Struct:
        public _D3DLIGHTTYPE Type;
        public _D3DCOLORVALUE Diffuse;
        public _D3DCOLORVALUE Specular;
        public _D3DCOLORVALUE Ambient;
        public _D3DVECTOR Position;
        public _D3DVECTOR Direction;
        public Single Range;
        public Single Falloff;
        public Single Attenuation0;
        public Single Attenuation1;
        public Single Attenuation2;
        public Single Theta;
        public Single Phi;
        public override string ToString() => $"Type(_D3DLIGHTTYPE):{Type}, Diffuse(_D3DCOLORVALUE):{Diffuse}, Specular(_D3DCOLORVALUE):{Specular}, Ambient(_D3DCOLORVALUE):{Ambient}, Position(_D3DVECTOR):{Position}, Direction(_D3DVECTOR):{Direction}, Range:{Range:n5}, Falloff:{Falloff:n5}, Attenuation0:{Attenuation0:n5}, Attenuation1:{Attenuation1:n5}, Attenuation2:{Attenuation2:n5}, Theta:{Theta:n5}, Phi:{Phi:n5}";
    }
    public unsafe struct _D3DVECTOR {
        // Struct:
        public Single x;
        public Single y;
        public Single z;
        public override string ToString() => $"x:{x:n5}, y:{y:n5}, z:{z:n5}";
    }

    public unsafe struct RenderIndexBuffer {
        // Struct:
        public RenderIndexBuffer.Vtbl* vfptr;
        public UInt32 m_nNumIndices;
        public UInt32 m_nActualNumIndices;
        public char indexSize;
        public char* indices;
        public Byte staticData;
        public Byte m_OnlyWriteOnce;
        public Byte locked;
        public Byte needRefresh;
        public Byte m_bUseIndexCaching;
        public UInt32 m_nMinVertexIndex;
        public UInt32 m_nMaxVertexIndex;
        public Byte m_bNeedRecalcMinMax;
        public override string ToString() => $"vfptr:->(RenderIndexBuffer.Vtbl*)0x{(int)vfptr:X8}, m_nNumIndices:{m_nNumIndices:X8}, m_nActualNumIndices:{m_nActualNumIndices:X8}, indexSize(char):{indexSize}, indices:->(char*)0x{(int)indices:X8}, staticData:{staticData:X2}, m_OnlyWriteOnce:{m_OnlyWriteOnce:X2}, locked:{locked:X2}, needRefresh:{needRefresh:X2}, m_bUseIndexCaching:{m_bUseIndexCaching:X2}, m_nMinVertexIndex:{m_nMinVertexIndex:X8}, m_nMaxVertexIndex:{m_nMaxVertexIndex:X8}, m_bNeedRecalcMinMax:{m_bNeedRecalcMinMax:X2}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<RenderIndexBuffer*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(RenderIndexBuffer *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<RenderIndexBuffer*, UInt32, char, Byte, Byte, Byte, Byte> Startup; // bool (__thiscall *Startup)(RenderIndexBuffer *this, unsigned int, char, bool, bool, bool);
            public static delegate* unmanaged[Thiscall]<RenderIndexBuffer*, void> Shutdown; // void (__thiscall *Shutdown)(RenderIndexBuffer *this);
            public static delegate* unmanaged[Thiscall]<RenderIndexBuffer*, RenderIndexBuffer*> Duplicate; // RenderIndexBuffer *(__thiscall *Duplicate)(RenderIndexBuffer *this);
        }

        // Functions:

        // RenderIndexBuffer.AllocateIndexBuffer:
        // public static RenderIndexBuffer* AllocateIndexBuffer() => ((delegate* unmanaged[Cdecl]<RenderIndexBuffer*>)0xDEADBEEF)(); // .text:0044CAA0 ; RenderIndexBuffer *__cdecl RenderIndexBuffer::AllocateIndexBuffer() .text:0044CAA0 ?AllocateIndexBuffer@RenderIndexBuffer@@SAPAV1@XZ

        // RenderIndexBuffer.Begin:
        // public void Begin() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, void>)0xDEADBEEF)(ref this); // .text:0044C8A0 ; void __thiscall RenderIndexBuffer::Begin(RenderIndexBuffer *this) .text:0044C8A0 ?Begin@RenderIndexBuffer@@AAEXXZ

        // RenderIndexBuffer.Duplicate:
        // public RenderIndexBuffer* Duplicate() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, RenderIndexBuffer*>)0xDEADBEEF)(ref this); // .text:0044CC30 ; RenderIndexBuffer *__thiscall RenderIndexBuffer::Duplicate(RenderIndexBuffer *this) .text:0044CC30 ?Duplicate@RenderIndexBuffer@@UBEPAV1@XZ

        // RenderIndexBuffer.End:
        // public void End() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, void>)0xDEADBEEF)(ref this); // .text:0044C8D0 ; void __thiscall RenderIndexBuffer::End(RenderIndexBuffer *this) .text:0044C8D0 ?End@RenderIndexBuffer@@AAEXXZ

        // RenderIndexBuffer.FromFileNode:
        // public Byte FromFileNode(PFileNode* node) => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, PFileNode*, Byte>)0xDEADBEEF)(ref this, node); // .text:0044CD00 ; bool __thiscall RenderIndexBuffer::FromFileNode(RenderIndexBuffer *this, PFileNode *node) .text:0044CD00 ?FromFileNode@RenderIndexBuffer@@QAE_NPBVPFileNode@@@Z

        // RenderIndexBuffer.Lock:
        // public char* Lock() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, char*>)0xDEADBEEF)(ref this); // .text:0044C9B0 ; char *__thiscall RenderIndexBuffer::Lock(RenderIndexBuffer *this) .text:0044C9B0 ?Lock@RenderIndexBuffer@@QAEPAEXZ

        // RenderIndexBuffer.RecalculateMinMaxIndices:
        // public void RecalculateMinMaxIndices() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, void>)0xDEADBEEF)(ref this); // .text:0044C9D0 ; void __thiscall RenderIndexBuffer::RecalculateMinMaxIndices(RenderIndexBuffer *this) .text:0044C9D0 ?RecalculateMinMaxIndices@RenderIndexBuffer@@IBEXXZ

        // RenderIndexBuffer.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:0044CBA0 ; void __thiscall RenderIndexBuffer::Serialize(RenderIndexBuffer *this, Archive *io_archive) .text:0044CBA0 ?Serialize@RenderIndexBuffer@@QAEXAAVArchive@@@Z

        // RenderIndexBuffer.SetRenderIndexBuffer:
        // public Byte SetRenderIndexBuffer(RenderIndexBuffer* source) => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, RenderIndexBuffer*, Byte>)0xDEADBEEF)(ref this, source); // .text:0044CB00 ; bool __thiscall RenderIndexBuffer::SetRenderIndexBuffer(RenderIndexBuffer *this, RenderIndexBuffer *source) .text:0044CB00 ?SetRenderIndexBuffer@RenderIndexBuffer@@QAE_NABV1@@Z

        // RenderIndexBuffer.Shutdown:
        // public void Shutdown() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, void>)0xDEADBEEF)(ref this); // .text:0044C960 ; void __thiscall RenderIndexBuffer::Shutdown(RenderIndexBuffer *this) .text:0044C960 ?Shutdown@RenderIndexBuffer@@UAEXXZ

        // RenderIndexBuffer.Startup:
        // public Byte Startup(UInt32 _nNumIndices, char _indexSize, Byte _staticData, Byte _OnlyWriteOnce, Byte _bUseIndexCaching) => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, UInt32, char, Byte, Byte, Byte, Byte>)0xDEADBEEF)(ref this, _nNumIndices, _indexSize, _staticData, _OnlyWriteOnce, _bUseIndexCaching); // .text:0044C900 ; bool __thiscall RenderIndexBuffer::Startup(RenderIndexBuffer *this, const unsigned int _nNumIndices, const char _indexSize, const bool _staticData, const bool _OnlyWriteOnce, const bool _bUseIndexCaching) .text:0044C900 ?Startup@RenderIndexBuffer@@UAE_NKE_N00@Z

        // RenderIndexBuffer.Unlock:
        // public void Unlock() => ((delegate* unmanaged[Thiscall]<ref RenderIndexBuffer, void>)0xDEADBEEF)(ref this); // .text:0044C9C0 ; void __thiscall RenderIndexBuffer::Unlock(RenderIndexBuffer *this) .text:0044C9C0 ?Unlock@RenderIndexBuffer@@QAEXXZ
    }

}
