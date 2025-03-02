using System;

namespace AcClient {
    public unsafe struct CInputManager_WIN32 {
        // Struct:
        public CInputManager a0;
        public static delegate* unmanaged[Thiscall]<HINSTANCE__*, UInt32, _GUID*, void**, IUnknown*, int> m_pfnDirectInputCreate; // HRESULT (__stdcall *m_pfnDirectInputCreate)(HINSTANCE__ *, unsigned int, _GUID *, void **, IUnknown *);
        public HINSTANCE__* m_hDInputDLL;
        public IDirectInput8A* m_pDI;
        public HWND__* m_hwnd;
        public SmartArray<CInputManager_WIN32.InputDevice> m_aDevices;
        public UInt32 m_nKeyboardDevice;
        public UInt32 m_nMouseDevice;
        public UInt32 m_nVirtualDevice;
        public HashTable<ControlSpecification, ControlType> m_hashControlToType;
        public HashTable<ControlSpecification, CInputManager_WIN32.RecentControlState> m_hashActiveControls;
        public CMasterInputMap m_InputMap;
        public UInt32 m_metaKeyMode;
        public PriorityHash<ControlSpecification, CInputManager_WIN32.ButtonHistoryEntry> m_ButtonHistory;
        public tagPOINT m_ptMousePosBeforeMouseLookMode;
        public MouseLookBehavior m_eMouseLookBehavior;
        public tagPOINT m_ptNonMousePointerMovement;
        public Byte m_fClientIsActive;
        public Byte m_fMainWindowHasFocus;
        public int m_cSetCapture;
        public Byte m_bProcessingKeyDown;
        public Byte m_bProcessingActionInResponseToKeyDown;
        public Byte m_bIgnoreNextChar;
        public override string ToString() => $"a0(CInputManager):{a0}, m_hDInputDLL:->(HINSTANCE__*)0x{(int)m_hDInputDLL:X8}, m_pDI:->(IDirectInput8A*)0x{(int)m_pDI:X8}, m_hwnd:->(HWND__*)0x{(int)m_hwnd:X8}, m_aDevices(SmartArray<CInputManager_WIN32.InputDevice,1>):{m_aDevices}, m_nKeyboardDevice:{m_nKeyboardDevice:X8}, m_nMouseDevice:{m_nMouseDevice:X8}, m_nVirtualDevice:{m_nVirtualDevice:X8}, m_hashControlToType(HashTable<ControlSpecification,ControlType,0>):{m_hashControlToType}, m_hashActiveControls(HashTable<ControlSpecification,CInputManager_WIN32.RecentControlState,0>):{m_hashActiveControls}, m_InputMap(CMasterInputMap):{m_InputMap}, m_metaKeyMode:{m_metaKeyMode:X8}, m_ButtonHistory(PriorityHash<ControlSpecification,CInputManager_WIN32.ButtonHistoryEntry,1>):{m_ButtonHistory}, m_ptMousePosBeforeMouseLookMode(tagPOINT):{m_ptMousePosBeforeMouseLookMode}, m_eMouseLookBehavior(MouseLookBehavior):{m_eMouseLookBehavior}, m_ptNonMousePointerMovement(tagPOINT):{m_ptNonMousePointerMovement}, m_fClientIsActive:{m_fClientIsActive:X2}, m_fMainWindowHasFocus:{m_fMainWindowHasFocus:X2}, m_cSetCapture(int):{m_cSetCapture}, m_bProcessingKeyDown:{m_bProcessingKeyDown:X2}, m_bProcessingActionInResponseToKeyDown:{m_bProcessingActionInResponseToKeyDown:X2}, m_bIgnoreNextChar:{m_bIgnoreNextChar:X2}";
        public unsafe struct InputDevice {
            public IDirectInputDevice8A* pDev;
            public _GUID guidInstance;
            public _GUID guidProduct;
            public UInt32 iDeviceIndex;
            public UInt32 nType;
            public Byte bActive;
            public override string ToString() => $"pDev:->(IDirectInputDevice8A*)0x{(int)pDev:X8}, guidInstance(_GUID):{guidInstance}, guidProduct(_GUID):{guidProduct}, iDeviceIndex:{iDeviceIndex:X8}, nType:{nType:X8}, bActive:{bActive:X2}";
        }
        public unsafe struct RecentControlState {
            public UInt32 dwData;
            public ControlType type;
            public UInt32 mode;
            public UInt32 activation;
            public UInt32 idActionMatched;
            public UInt32 idInputMapMatched;
            public override string ToString() => $"dwData:{dwData:X8}, type(ControlType):{type}, mode:{mode:X8}, activation:{activation:X8}, idActionMatched:{idActionMatched:X8}, idInputMapMatched:{idInputMapMatched:X8}";
        }
        public unsafe struct ButtonHistoryEntry {
            public CTimestamp<UInt32> a0;
            public tagPOINT ptMousePos;
            public override string ToString() => $"a0(CTimestamp<UInt32>):{a0}, ptMousePos(tagPOINT):{ptMousePos}";
        }

        // Functions:

        // CInputManager_WIN32.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x006895D0)(ref this); // .text:00688540 ; void __thiscall CInputManager_WIN32::CInputManager_WIN32(CInputManager_WIN32 *this) .text:00688540 ??0CInputManager_WIN32@@QAE@XZ

        // CInputManager_WIN32.AcquireAll:
        public void AcquireAll() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x00687550)(ref this); // .text:00686500 ; void __thiscall CInputManager_WIN32::AcquireAll(CInputManager_WIN32 *this) .text:00686500 ?AcquireAll@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.Activate:
        public void Activate(Byte fActive) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte, void>)0x0068AB30)(ref this, fActive); // .text:00689AA0 ; void __thiscall CInputManager_WIN32::Activate(CInputManager_WIN32 *this, bool fActive) .text:00689AA0 ?Activate@CInputManager_WIN32@@UAEX_N@Z

        // CInputManager_WIN32.AddDevice:
        public HRESULT AddDevice(UInt32 dwDeviceType, _GUID* gInstance, _GUID* gProduct) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, _GUID*, _GUID*, HRESULT>)0x00688240)(ref this, dwDeviceType, gInstance, gProduct); // .text:006871F0 ; HRESULT __thiscall CInputManager_WIN32::AddDevice(CInputManager_WIN32 *this, unsigned int dwDeviceType, _GUID *gInstance, _GUID *gProduct) .text:006871F0 ?AddDevice@CInputManager_WIN32@@IAEJKABU_GUID@@0@Z

        // CInputManager_WIN32.AddDevicePointer:
        public void AddDevicePointer(UInt32 dwDeviceType, _GUID* gInstance, _GUID* gProduct, IDirectInputDevice8A* pDevice) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, _GUID*, _GUID*, IDirectInputDevice8A*, void>)0x00688070)(ref this, dwDeviceType, gInstance, gProduct, pDevice); // .text:00687020 ; void __thiscall CInputManager_WIN32::AddDevicePointer(CInputManager_WIN32 *this, unsigned int dwDeviceType, _GUID *gInstance, _GUID *gProduct, IDirectInputDevice8A *pDevice) .text:00687020 ?AddDevicePointer@CInputManager_WIN32@@IAEXKABU_GUID@@0PAUIDirectInputDevice8A@@@Z

        // CInputManager_WIN32.AddDeviceToInputMap:
        public Byte AddDeviceToInputMap(CInputManager_WIN32.InputDevice* inputDevice) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, CInputManager_WIN32.InputDevice*, Byte>)0x00687080)(ref this, inputDevice); // .text:00686030 ; bool __thiscall CInputManager_WIN32::AddDeviceToInputMap(CInputManager_WIN32 *this, CInputManager_WIN32::InputDevice *inputDevice) .text:00686030 ?AddDeviceToInputMap@CInputManager_WIN32@@IAE_NAAUInputDevice@1@@Z

        // CInputManager_WIN32.AddKeyMap:
        public Byte AddKeyMap(UInt32 _actID) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, Byte>)0x00687510)(ref this, _actID); // .text:006864C0 ; bool __thiscall CInputManager_WIN32::AddKeyMap(CInputManager_WIN32 *this, unsigned int _actID) .text:006864C0 ?AddKeyMap@CInputManager_WIN32@@UAE_NK@Z

        // CInputManager_WIN32.AddKeyMap:
        public Byte AddKeyMap(PStringBase<char> strFilename) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>, Byte>)0x00687AE0)(ref this, strFilename); // .text:00686A90 ; bool __thiscall CInputManager_WIN32::AddKeyMap(CInputManager_WIN32 *this, PStringBase<char> strFilename) .text:00686A90 ?AddKeyMap@CInputManager_WIN32@@UAE_NV?$PStringBase@D@@@Z

        // CInputManager_WIN32.AltKeyDown:
        public Byte AltKeyDown() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x006876F0)(ref this); // .text:006866A0 ; bool __thiscall CInputManager_WIN32::AltKeyDown(CInputManager_WIN32 *this) .text:006866A0 ?AltKeyDown@CInputManager_WIN32@@UBE_NXZ

        // CInputManager_WIN32.BindAction:
        public Byte BindAction(QualifiedControl i_key, UInt32 i_idAction, UInt32 i_idMap) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, QualifiedControl, UInt32, UInt32, Byte>)0x006873F0)(ref this, i_key, i_idAction, i_idMap); // .text:006863A0 ; bool __thiscall CInputManager_WIN32::BindAction(CInputManager_WIN32 *this, QualifiedControl i_key, unsigned int i_idAction, unsigned int i_idMap) .text:006863A0 ?BindAction@CInputManager_WIN32@@UAE_NVQualifiedControl@@KK@Z

        // CInputManager_WIN32.ClearKeyMap:
        public Byte ClearKeyMap() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x00687100)(ref this); // .text:006860B0 ; bool __thiscall CInputManager_WIN32::ClearKeyMap(CInputManager_WIN32 *this) .text:006860B0 ?ClearKeyMap@CInputManager_WIN32@@UAE_NXZ

        // CInputManager_WIN32.ConfigureMouseLookMode:
        public void ConfigureMouseLookMode(MouseLookBehavior i_eBehavior, int i_x, int i_y) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, MouseLookBehavior, int, int, void>)0x006896C0)(ref this, i_eBehavior, i_x, i_y); // .text:00688630 ; void __thiscall CInputManager_WIN32::ConfigureMouseLookMode(CInputManager_WIN32 *this, MouseLookBehavior i_eBehavior, int i_x, int i_y) .text:00688630 ?ConfigureMouseLookMode@CInputManager_WIN32@@UAEXW4MouseLookBehavior@@JJ@Z

        // CInputManager_WIN32.CtrlKeyDown:
        public Byte CtrlKeyDown() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x006876E0)(ref this); // .text:00686690 ; bool __thiscall CInputManager_WIN32::CtrlKeyDown(CInputManager_WIN32 *this) .text:00686690 ?CtrlKeyDown@CInputManager_WIN32@@UBE_NXZ

        // CInputManager_WIN32.DIDataToActivationType:
        public UInt32 DIDataToActivationType(ControlType ct, UInt32 dwData, Single* o_rData) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlType, UInt32, Single*, UInt32>)0x00687250)(ref this, ct, dwData, o_rData); // .text:00686200 ; unsigned int __thiscall CInputManager_WIN32::DIDataToActivationType(CInputManager_WIN32 *this, ControlType ct, unsigned int dwData, float *o_rData) .text:00686200 ?DIDataToActivationType@CInputManager_WIN32@@IAEKW4ControlType@@KAAM@Z

        // CInputManager_WIN32.DITypeToControlType:
        public ControlType DITypeToControlType(UInt32 dwType) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, ControlType>)0x006871E0)(ref this, dwType); // .text:00686190 ; ControlType __thiscall CInputManager_WIN32::DITypeToControlType(CInputManager_WIN32 *this, unsigned int dwType) .text:00686190 ?DITypeToControlType@CInputManager_WIN32@@IAE?AW4ControlType@@K@Z

        // CInputManager_WIN32.EnumSuitableDevices:
        public Byte EnumSuitableDevices() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x00688810)(ref this); // .text:00687780 ; bool __thiscall CInputManager_WIN32::EnumSuitableDevices(CInputManager_WIN32 *this) .text:00687780 ?EnumSuitableDevices@CInputManager_WIN32@@IAE_NXZ

        // CInputManager_WIN32.EnumSuitableDevicesCB:
        public int EnumSuitableDevicesCB(void* pContext) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void*, int>)0x00688440)(ref this, pContext); // .text:006873F0 ; int __stdcall CInputManager_WIN32::EnumSuitableDevicesCB(DIDEVICEINSTANCEA *pDIDI, void *pContext) .text:006873F0 ?EnumSuitableDevicesCB@CInputManager_WIN32@@KGHPBUDIDEVICEINSTANCEA@@PAX@Z

        // CInputManager_WIN32.FindConflictingControls:
        public Byte FindConflictingControls(QualifiedControl* i_key, UInt32 i_eMapID, SmartArray<_STL.Pair<QualifiedControl, UInt32>>* o_controls) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, QualifiedControl*, UInt32, SmartArray<_STL.Pair<QualifiedControl, UInt32>>*, Byte>)0x00688C80)(ref this, i_key, i_eMapID, o_controls); // .text:00687BF0 ; bool __thiscall CInputManager_WIN32::FindConflictingControls(CInputManager_WIN32 *this, QualifiedControl *i_key, unsigned int i_eMapID, SmartArray<_STL::pair<QualifiedControl,unsigned long>,1> *o_controls) .text:00687BF0 ?FindConflictingControls@CInputManager_WIN32@@UBE_NABVQualifiedControl@@KAAV?$SmartArray@U?$pair@VQualifiedControl@@K@_STL@@$00@@@Z

        // CInputManager_WIN32.FindConflictingInputMaps:
        public Byte FindConflictingInputMaps(UInt32 i_eMapID, _List<UInt32>* o_listMapIDs) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, _List<UInt32>*, Byte>)0x00687440)(ref this, i_eMapID, o_listMapIDs); // .text:006863F0 ; bool __thiscall CInputManager_WIN32::FindConflictingInputMaps(CInputManager_WIN32 *this, unsigned int i_eMapID, List<unsigned long> *o_listMapIDs) .text:006863F0 ?FindConflictingInputMaps@CInputManager_WIN32@@UBE_NKAAV?$List@K@@@Z

        // CInputManager_WIN32.FindKeysForAction:
        public Byte FindKeysForAction(UInt32 i_id, UInt32 i_idMap, _List<QualifiedControl>* o_list) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, UInt32, _List<QualifiedControl>*, Byte>)0x00688C40)(ref this, i_id, i_idMap, o_list); // .text:00687BB0 ; bool __thiscall CInputManager_WIN32::FindKeysForAction(CInputManager_WIN32 *this, unsigned int i_id, unsigned int i_idMap, List<QualifiedControl> *o_list) .text:00687BB0 ?FindKeysForAction@CInputManager_WIN32@@UAE_NKKAAV?$List@VQualifiedControl@@@@@Z

        // CInputManager_WIN32.FireInputEvent:
        public Byte FireInputEvent(ControlSpecification key, ControlType ct, UInt32 dwData, UInt32 dwTimestamp) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlSpecification, ControlType, UInt32, UInt32, Byte>)0x00689890)(ref this, key, ct, dwData, dwTimestamp); // .text:00688800 ; bool __thiscall CInputManager_WIN32::FireInputEvent(CInputManager_WIN32 *this, ControlSpecification key, ControlType ct, unsigned int dwData, unsigned int dwTimestamp) .text:00688800 ?FireInputEvent@CInputManager_WIN32@@IAE_NVControlSpecification@@W4ControlType@@KI@Z

        // CInputManager_WIN32.GenerateKeyboardEvent:
        public void GenerateKeyboardEvent(tagMSG* i_msg) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, tagMSG*, void>)0x0068A3D0)(ref this, i_msg); // .text:0068A3D0 ; void __thiscall CInputManager_WIN32::GenerateKeyboardEvent(CInputManager_WIN32 *this, tagMSG *i_msg) .text:00689340 ?GenerateKeyboardEvent@CInputManager_WIN32@@IAEXABUtagMSG@@@Z

        // CInputManager_WIN32.GenerateMouseButtonEvent:
        public void GenerateMouseButtonEvent(int iButton, Byte fUp, UInt32 dwTime) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, int, Byte, UInt32, void>)0x0068A4D0)(ref this, iButton, fUp, dwTime); // .text:00689440 ; void __thiscall CInputManager_WIN32::GenerateMouseButtonEvent(CInputManager_WIN32 *this, int iButton, bool fUp, unsigned int dwTime) .text:00689440 ?GenerateMouseButtonEvent@CInputManager_WIN32@@IAEXH_NK@Z

        // CInputManager_WIN32.GenerateMouseWheelEvent:
        public void GenerateMouseWheelEvent(int iDeltaZ, UInt32 dwTime) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, int, UInt32, void>)0x0068A5A0)(ref this, iDeltaZ, dwTime); // .text:00689510 ; void __thiscall CInputManager_WIN32::GenerateMouseWheelEvent(CInputManager_WIN32 *this, int iDeltaZ, unsigned int dwTime) .text:00689510 ?GenerateMouseWheelEvent@CInputManager_WIN32@@IAEXHK@Z

        // CInputManager_WIN32.GetDeviceTypeFromKey:
        public DeviceType GetDeviceTypeFromKey(ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlSpecification, DeviceType>)0x00687900)(ref this, key); // .text:006868B0 ; DeviceType __thiscall CInputManager_WIN32::GetDeviceTypeFromKey(CInputManager_WIN32 *this, ControlSpecification key) .text:006868B0 ?GetDeviceTypeFromKey@CInputManager_WIN32@@MBE?AW4DeviceType@@VControlSpecification@@@Z

        // CInputManager_WIN32.GetDoubleClickDelay:
        public UInt32 GetDoubleClickDelay() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32>)0x006896F0)(ref this); // .text:00688660 ; unsigned int __thiscall CInputManager_WIN32::GetDoubleClickDelay(CInputManager_WIN32 *this) .text:00688660 ?GetDoubleClickDelay@CInputManager_WIN32@@UAEKXZ

        // CInputManager_WIN32.GetInput:
        public void GetInput() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x0068A830)(ref this); // .text:006897A0 ; void __thiscall CInputManager_WIN32::GetInput(CInputManager_WIN32 *this) .text:006897A0 ?GetInput@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.GetNameFromKey:
        public PStringBase<char>* GetNameFromKey(PStringBase<char>* result, QualifiedControl* key) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>*, QualifiedControl*, PStringBase<char>*>)0x00688F70)(ref this, result, key); // .text:00687F40 ; PStringBase<char> *__thiscall CInputManager_WIN32::GetNameFromKey(CInputManager_WIN32 *this, PStringBase<char> *result, QualifiedControl *key) .text:00687F40 ?GetNameFromKey@CInputManager_WIN32@@UBE?AV?$PStringBase@D@@ABVQualifiedControl@@@Z

        // CInputManager_WIN32.GetNameFromKey:
        public PStringBase<char>* GetNameFromKey(PStringBase<char>* result, ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>*, ControlSpecification, PStringBase<char>*>)0x00688F30)(ref this, result, key); // .text:00687F00 ; PStringBase<char> *__thiscall CInputManager_WIN32::GetNameFromKey(CInputManager_WIN32 *this, PStringBase<char> *result, ControlSpecification key) .text:00687F00 ?GetNameFromKey@CInputManager_WIN32@@UBE?AV?$PStringBase@D@@VControlSpecification@@@Z

        // CInputManager_WIN32.GetNameFromKey_Internal:
        public PStringBase<char>* GetNameFromKey_Internal(PStringBase<char>* result, ControlSpecification key, UInt32 i_eKeyOverrideTable) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>*, ControlSpecification, UInt32, PStringBase<char>*>)0x00688890)(ref this, result, key, i_eKeyOverrideTable); // .text:00687800 ; PStringBase<char> *__thiscall CInputManager_WIN32::GetNameFromKey_Internal(CInputManager_WIN32 *this, PStringBase<char> *result, ControlSpecification key, unsigned int i_eKeyOverrideTable) .text:00687800 ?GetNameFromKey_Internal@CInputManager_WIN32@@IBE?AV?$PStringBase@D@@VControlSpecification@@K@Z

        // CInputManager_WIN32.GetNameFromMetaKey:
        public PStringBase<char>* GetNameFromMetaKey(PStringBase<char>* result, ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>*, ControlSpecification, PStringBase<char>*>)0x00688F50)(ref this, result, key); // .text:00687F20 ; PStringBase<char> *__thiscall CInputManager_WIN32::GetNameFromMetaKey(CInputManager_WIN32 *this, PStringBase<char> *result, ControlSpecification key) .text:00687F20 ?GetNameFromMetaKey@CInputManager_WIN32@@UBE?AV?$PStringBase@D@@VControlSpecification@@@Z

        // CInputManager_WIN32.GetPreviousControlState:
        public Byte GetPreviousControlState(ControlSpecification i_key, ControlType i_ct, CInputManager_WIN32.RecentControlState* o_rcsPreviousState) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlSpecification, ControlType, CInputManager_WIN32.RecentControlState*, Byte>)0x00688470)(ref this, i_key, i_ct, o_rcsPreviousState); // .text:00687420 ; bool __thiscall CInputManager_WIN32::GetPreviousControlState(CInputManager_WIN32 *this, ControlSpecification i_key, ControlType i_ct, CInputManager_WIN32::RecentControlState *o_rcsPreviousState) .text:00687420 ?GetPreviousControlState@CInputManager_WIN32@@IAE_NVControlSpecification@@W4ControlType@@AAURecentControlState@1@@Z

        // CInputManager_WIN32.GetTapDelay:
        public UInt32 GetTapDelay() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32>)0x00689700)(ref this); // .text:00688670 ; unsigned int __thiscall CInputManager_WIN32::GetTapDelay(CInputManager_WIN32 *this) .text:00688670 ?GetTapDelay@CInputManager_WIN32@@UAEKXZ

        // CInputManager_WIN32.InitializeKeymap:
        public Byte InitializeKeymap() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x00687060)(ref this); // .text:00686010 ; bool __thiscall CInputManager_WIN32::InitializeKeymap(CInputManager_WIN32 *this) .text:00686010 ?InitializeKeymap@CInputManager_WIN32@@UAE_NXZ

        // CInputManager_WIN32.IsMetaKey:
        public Byte IsMetaKey(ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlSpecification, Byte>)0x00687110)(ref this, key); // .text:006860C0 ; bool __thiscall CInputManager_WIN32::IsMetaKey(CInputManager_WIN32 *this, ControlSpecification key) .text:006860C0 ?IsMetaKey@CInputManager_WIN32@@UBE_NVControlSpecification@@@Z

        // CInputManager_WIN32.IsMetaKeyDown:
        public Byte IsMetaKeyDown(UInt32 idKey) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, Byte>)0x00687660)(ref this, idKey); // .text:00686610 ; bool __thiscall CInputManager_WIN32::IsMetaKeyDown(CInputManager_WIN32 *this, unsigned int idKey) .text:00686610 ?IsMetaKeyDown@CInputManager_WIN32@@IBE_NK@Z

        // CInputManager_WIN32.OnMessage:
        public int OnMessage(tagMSG* i_msg, Byte* o_fHandled) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, tagMSG*, Byte*, int>)0x0068ABC0)(ref this, i_msg, o_fHandled); // .text:00689B30 ; int __thiscall CInputManager_WIN32::OnMessage(CInputManager_WIN32 *this, tagMSG *i_msg, bool *o_fHandled) .text:00689B30 ?OnMessage@CInputManager_WIN32@@UAEJABUtagMSG@@AA_N@Z

        // CInputManager_WIN32.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x006893B0)(ref this); // .text:00688320 ; void __thiscall CInputManager_WIN32::OnShutdown(CInputManager_WIN32 *this) .text:00688320 ?OnShutdown@CInputManager_WIN32@@UAEXXZ

        // CInputManager_WIN32.OnStartup:
        public Byte OnStartup(int dwUserData) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, int, Byte>)0x00688DA0)(ref this, dwUserData); // .text:00687D70 ; bool __thiscall CInputManager_WIN32::OnStartup(CInputManager_WIN32 *this, int dwUserData) .text:00687D70 ?OnStartup@CInputManager_WIN32@@UAE_NJ@Z

        // CInputManager_WIN32.OnSwitchMouseMode:
        public void OnSwitchMouseMode(Byte fEnterMouseLook) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte, void>)0x0068A2A0)(ref this, fEnterMouseLook); // .text:00689210 ; void __thiscall CInputManager_WIN32::OnSwitchMouseMode(CInputManager_WIN32 *this, bool fEnterMouseLook) .text:00689210 ?OnSwitchMouseMode@CInputManager_WIN32@@MAEX_N@Z

        // CInputManager_WIN32.OnSwitchTextMode:
        public void OnSwitchTextMode(Byte mode) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte, void>)0x00687700)(ref this, mode); // .text:006866B0 ; void __thiscall CInputManager_WIN32::OnSwitchTextMode(CInputManager_WIN32 *this, bool mode) .text:006866B0 ?OnSwitchTextMode@CInputManager_WIN32@@MAEX_N@Z

        // CInputManager_WIN32.PollDevice:
        public Byte PollDevice(IDirectInputDevice8A* _pDev, Byte _bAttemptAcquire) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, IDirectInputDevice8A*, Byte, Byte>)0x00687130)(ref this, _pDev, _bAttemptAcquire); // .text:006860E0 ; bool __thiscall CInputManager_WIN32::PollDevice(CInputManager_WIN32 *this, IDirectInputDevice8A *_pDev, bool _bAttemptAcquire) .text:006860E0 ?PollDevice@CInputManager_WIN32@@IAE_NPAUIDirectInputDevice8A@@_N@Z

        // CInputManager_WIN32.ProcessDeviceData:
        public Byte ProcessDeviceData(UInt32 nDevice, DIDEVICEOBJECTDATA* dod) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, DIDEVICEOBJECTDATA*, Byte>)0x0068A070)(ref this, nDevice, dod); // .text:00688FE0 ; bool __thiscall CInputManager_WIN32::ProcessDeviceData(CInputManager_WIN32 *this, unsigned int nDevice, DIDEVICEOBJECTDATA *dod) .text:00688FE0 ?ProcessDeviceData@CInputManager_WIN32@@IAE_NKABUDIDEVICEOBJECTDATA@@@Z

        // CInputManager_WIN32.ReleaseDevices:
        public void ReleaseDevices() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x00687610)(ref this); // .text:006865C0 ; void __thiscall CInputManager_WIN32::ReleaseDevices(CInputManager_WIN32 *this) .text:006865C0 ?ReleaseDevices@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.ReleasePressedKeys:
        public void ReleasePressedKeys() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x0068A620)(ref this); // .text:00689590 ; void __thiscall CInputManager_WIN32::ReleasePressedKeys(CInputManager_WIN32 *this) .text:00689590 ?ReleasePressedKeys@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.SaveKeyMap:
        public Byte SaveKeyMap(PStringBase<char> strFilename) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, PStringBase<char>, Byte>)0x00687C70)(ref this, strFilename); // .text:00686C20 ; bool __thiscall CInputManager_WIN32::SaveKeyMap(CInputManager_WIN32 *this, PStringBase<char> strFilename) .text:00686C20 ?SaveKeyMap@CInputManager_WIN32@@UAE_NV?$PStringBase@D@@@Z

        // CInputManager_WIN32.SendActionToListeners:
        public void SendActionToListeners(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, InputEvent*, void>)0x00687460)(ref this, i_inEvt); // .text:00686410 ; void __thiscall CInputManager_WIN32::SendActionToListeners(CInputManager_WIN32 *this, InputEvent *i_inEvt) .text:00686410 ?SendActionToListeners@CInputManager_WIN32@@MAEXAAVInputEvent@@@Z

        // CInputManager_WIN32.SetMouseXY:
        public Byte SetMouseXY(int i_xWindow, int i_yWindow) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, int, int, Byte>)0x00689710)(ref this, i_xWindow, i_yWindow); // .text:00688680 ; bool __thiscall CInputManager_WIN32::SetMouseXY(CInputManager_WIN32 *this, int i_xWindow, int i_yWindow) .text:00688680 ?SetMouseXY@CInputManager_WIN32@@UAE_NJJ@Z

        // CInputManager_WIN32.ShiftKeyDown:
        public Byte ShiftKeyDown() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, Byte>)0x006876D0)(ref this); // .text:00686680 ; bool __thiscall CInputManager_WIN32::ShiftKeyDown(CInputManager_WIN32 *this) .text:00686680 ?ShiftKeyDown@CInputManager_WIN32@@UBE_NXZ

        // CInputManager_WIN32.SubControlFromData:
        public SubControlIndex SubControlFromData(ControlType ct, UInt32 dwData) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ControlType, UInt32, SubControlIndex>)0x00687320)(ref this, ct, dwData); // .text:006862D0 ; SubControlIndex __thiscall CInputManager_WIN32::SubControlFromData(CInputManager_WIN32 *this, ControlType ct, unsigned int dwData) .text:006862D0 ?SubControlFromData@CInputManager_WIN32@@IAE?AW4SubControlIndex@@W4ControlType@@K@Z

        // CInputManager_WIN32.SyncCursorToMousePos:
        public void SyncCursorToMousePos() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x006873B0)(ref this); // .text:00686360 ; void __thiscall CInputManager_WIN32::SyncCursorToMousePos(CInputManager_WIN32 *this) .text:00686360 ?SyncCursorToMousePos@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.UnacquireAll:
        public void UnacquireAll() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x006875C0)(ref this); // .text:00686570 ; void __thiscall CInputManager_WIN32::UnacquireAll(CInputManager_WIN32 *this) .text:00686570 ?UnacquireAll@CInputManager_WIN32@@IAEXXZ

        // CInputManager_WIN32.UnbindAllByAction:
        public Byte UnbindAllByAction(UInt32 i_id, UInt32 i_eMapID) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, UInt32, UInt32, Byte>)0x00688CD0)(ref this, i_id, i_eMapID); // .text:00687C40 ; bool __thiscall CInputManager_WIN32::UnbindAllByAction(CInputManager_WIN32 *this, unsigned int i_id, unsigned int i_eMapID) .text:00687C40 ?UnbindAllByAction@CInputManager_WIN32@@UAE_NKK@Z

        // CInputManager_WIN32.UnbindByKey:
        public Byte UnbindByKey(QualifiedControl i_key, UInt32 i_idMap) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, QualifiedControl, UInt32, Byte>)0x00688BE0)(ref this, i_key, i_idMap); // .text:00687B50 ; bool __thiscall CInputManager_WIN32::UnbindByKey(CInputManager_WIN32 *this, QualifiedControl i_key, unsigned int i_idMap) .text:00687B50 ?UnbindByKey@CInputManager_WIN32@@UAE_NVQualifiedControl@@K@Z

        // CInputManager_WIN32.UpdateCharacter:
        public void UpdateCharacter(ushort charToHandle) => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, ushort, void>)0x006871A0)(ref this, charToHandle); // .text:00686150 ; void __thiscall CInputManager_WIN32::UpdateCharacter(CInputManager_WIN32 *this, wchar_t charToHandle) .text:00686150 ?UpdateCharacter@CInputManager_WIN32@@IAEXG@Z

        // CInputManager_WIN32.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CInputManager_WIN32, void>)0x0068ABB0)(ref this); // .text:00689B20 ; void __thiscall CInputManager_WIN32::UseTime(CInputManager_WIN32 *this) .text:00689B20 ?UseTime@CInputManager_WIN32@@UAEXXZ

        // Globals:
        public static UInt32* sm_timeTap = (UInt32*)0x008F8C6C; // .data:008F7C6C ; unsigned int CInputManager_WIN32::sm_timeTap .data:008F7C6C ?sm_timeTap@CInputManager_WIN32@@1KA
        public static UInt32* sm_cxDblClick = (UInt32*)0x008F8C70; // .data:008F7C70 ; unsigned int CInputManager_WIN32::sm_cxDblClick .data:008F7C70 ?sm_cxDblClick@CInputManager_WIN32@@1KA
        public static UInt32* sm_cyDblClick = (UInt32*)0x008F8C74; // .data:008F7C74 ; unsigned int CInputManager_WIN32::sm_cyDblClick .data:008F7C74 ?sm_cyDblClick@CInputManager_WIN32@@1KA
        public static UInt32* sm_timeDoubleClick = (UInt32*)0x008F8C68; // .data:008F7C68 ; unsigned int CInputManager_WIN32::sm_timeDoubleClick .data:008F7C68 ?sm_timeDoubleClick@CInputManager_WIN32@@1KA
    }

    public unsafe struct HINSTANCE__ {
        // Struct:
        public int unused;
        public override string ToString() => unused.ToString();
    }
    public unsafe struct HRESULT {
        public int value;
        public override string ToString() => value.ToString();

    }
    public unsafe struct CInputManager {
        // Struct:
        public ICIDM a0;
        public tagPOINT m_ptMousePos;
        public Double m_ttLastInputEvent;
        public Byte m_fWantMouseLookMode;
        public Byte m_fInMouseLookMode;
        public Byte m_textMode;
        public Byte m_lastFocus;
        public _List<PTR<CInputHandler>> m_actionList;
        public _List<PTR<CInputHandler>> m_characterList;
        public _List<PTR<CInputHandler>> m_mouseLookList;
        public _List<PTR<CInputHandler>> m_mouseMoveList;
        public _List<PTR<CInputHandler>> m_focusSwitchList;
        public _List<CInputManager.InputMapEntry> m_inputMapList;
        public CInputHandler* m_pKeyHitHandler;
        public Single m_MouseLookSensitivity;
        public Single m_MouseLookSmoothingAmount;
        public Byte m_InvertMouseLookYAxis;
        public Byte m_UseMouseTurning;
        public ActionMap* m_action_map;
        public IntrusiveHashTable<UInt32, PTR<ActionState>> m_hashActionStates;
        public override string ToString() => $"a0(ICIDM):{a0}, m_ptMousePos(tagPOINT):{m_ptMousePos}, m_ttLastInputEvent:{m_ttLastInputEvent:n5}, m_fWantMouseLookMode:{m_fWantMouseLookMode:X2}, m_fInMouseLookMode:{m_fInMouseLookMode:X2}, m_textMode:{m_textMode:X2}, m_lastFocus:{m_lastFocus:X2}, m_actionList(List<CInputHandler*>):{m_actionList}, m_characterList(List<CInputHandler*>):{m_characterList}, m_mouseLookList(List<CInputHandler*>):{m_mouseLookList}, m_mouseMoveList(List<CInputHandler*>):{m_mouseMoveList}, m_focusSwitchList(List<CInputHandler*>):{m_focusSwitchList}, m_inputMapList(List<CInputManager.InputMapEntry>):{m_inputMapList}, m_pKeyHitHandler:->(CInputHandler*)0x{(int)m_pKeyHitHandler:X8}, m_MouseLookSensitivity:{m_MouseLookSensitivity:n5}, m_MouseLookSmoothingAmount:{m_MouseLookSmoothingAmount:n5}, m_InvertMouseLookYAxis:{m_InvertMouseLookYAxis:X2}, m_UseMouseTurning:{m_UseMouseTurning:X2}, m_action_map:->(ActionMap*)0x{(int)m_action_map:X8}, m_hashActionStates(IntrusiveHashTable<UInt32,ActionState*,1>):{m_hashActionStates}";
        public unsafe struct InputMapEntry {
            public UInt32 m_mapID;
            public IInputActionCallback* m_pcCallback;
            public int m_nPriority;
            public override string ToString() => $"m_mapID:{m_mapID:X8}, m_pcCallback:->(IInputActionCallback*)0x{(int)m_pcCallback:X8}, m_nPriority(int):{m_nPriority}";
        }

        // Functions:

        // CInputManager.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CInputManager, void>)0x00432430)(ref this); // .text:00432290 ; void __thiscall CInputManager::CInputManager(CInputManager *this) .text:00432290 ??0CInputManager@@QAE@XZ

        // CInputManager.ActivateActionKey:
        public void ActivateActionKey(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x004327F0)(ref this, i_inEvt); // .text:00432650 ; void __thiscall CInputManager::ActivateActionKey(CInputManager *this, InputEvent *i_inEvt) .text:00432650 ?ActivateActionKey@CInputManager@@IAEXAAVInputEvent@@@Z

        // CInputManager.CallCharacterHandler:
        public void CallCharacterHandler(ushort charToHandle) => ((delegate* unmanaged[Thiscall]<ref CInputManager, ushort, void>)0x00431350)(ref this, charToHandle); // .text:004311B0 ; void __thiscall CInputManager::CallCharacterHandler(CInputManager *this, wchar_t charToHandle) .text:004311B0 ?CallCharacterHandler@CInputManager@@IAEXG@Z

        // CInputManager.CallFocusSwitchHandler:
        public void CallFocusSwitchHandler(Byte have_focus) => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte, void>)0x004313F0)(ref this, have_focus); // .text:00431250 ; void __thiscall CInputManager::CallFocusSwitchHandler(CInputManager *this, bool have_focus) .text:00431250 ?CallFocusSwitchHandler@CInputManager@@IAEX_N@Z

        // CInputManager.CallKeyHitHandler:
        public Byte CallKeyHitHandler(QualifiedControl* i_key, UInt32* o_idAction) => ((delegate* unmanaged[Thiscall]<ref CInputManager, QualifiedControl*, UInt32*, Byte>)0x00430EA0)(ref this, i_key, o_idAction); // .text:00430D00 ; bool __thiscall CInputManager::CallKeyHitHandler(CInputManager *this, QualifiedControl *i_key, unsigned int *o_idAction) .text:00430D00 ?CallKeyHitHandler@CInputManager@@IAE_NABVQualifiedControl@@AAK@Z

        // CInputManager.CallMouseLookHandler:
        public void CallMouseLookHandler(int dxpos, int dypos) => ((delegate* unmanaged[Thiscall]<ref CInputManager, int, int, void>)0x004313C0)(ref this, dxpos, dypos); // .text:00431220 ; void __thiscall CInputManager::CallMouseLookHandler(CInputManager *this, int dxpos, int dypos) .text:00431220 ?CallMouseLookHandler@CInputManager@@IAEXJJ@Z

        // CInputManager.CallMouseMoveHandler:
        public void CallMouseMoveHandler(int cx, int cy) => ((delegate* unmanaged[Thiscall]<ref CInputManager, int, int, void>)0x00431390)(ref this, cx, cy); // .text:004311F0 ; void __thiscall CInputManager::CallMouseMoveHandler(CInputManager *this, int cx, int cy) .text:004311F0 ?CallMouseMoveHandler@CInputManager@@IAEXJJ@Z

        // CInputManager.DeactivateActionKey:
        public void DeactivateActionKey(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x004326D0)(ref this, i_inEvt); // .text:00432530 ; void __thiscall CInputManager::DeactivateActionKey(CInputManager *this, InputEvent *i_inEvt) .text:00432530 ?DeactivateActionKey@CInputManager@@IAEXAAVInputEvent@@@Z

        // CInputManager.FireActionEvent:
        public void FireActionEvent(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x004328C0)(ref this, i_inEvt); // .text:00432720 ; void __thiscall CInputManager::FireActionEvent(CInputManager *this, InputEvent *i_inEvt) .text:00432720 ?FireActionEvent@CInputManager@@IAEXAAVInputEvent@@@Z

        // CInputManager.GetActionMap:
        public ActionMap* GetActionMap() => ((delegate* unmanaged[Thiscall]<ref CInputManager, ActionMap*>)0x00431CF0)(ref this); // .text:00431B50 ; ActionMap *__thiscall CInputManager::GetActionMap(CInputManager *this) .text:00431B50 ?GetActionMap@CInputManager@@UBEPBVActionMap@@XZ

        // CInputManager.GetLastInputTimestamp:
        public Double GetLastInputTimestamp() => ((delegate* unmanaged[Thiscall]<ref CInputManager, Double>)0x00431D00)(ref this); // .text:00431B60 ; long double __thiscall CInputManager::GetLastInputTimestamp(CInputManager *this) .text:00431B60 ?GetLastInputTimestamp@CInputManager@@MAENXZ

        // CInputManager.GetMouseLookMode:
        public Byte GetMouseLookMode() => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte>)0x00431CD0)(ref this); // .text:00431B30 ; bool __thiscall CInputManager::GetMouseLookMode(CInputManager *this) .text:00431B30 ?GetMouseLookMode@CInputManager@@UAE_NXZ

        // CInputManager.GetMouseX:
        public ShortCutManager* GetMouseX() => ((delegate* unmanaged[Thiscall]<ref CInputManager, ShortCutManager*>)0x004F1B20)(ref this); // .text:004F0E90 ; ShortCutManager *__thiscall CInputManager::GetMouseX(PlayerModule *this) .text:004F0E90 ?GetMouseX@CInputManager@@UAEJXZ

        // CInputManager.GetTextMode:
        public Byte GetTextMode() => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte>)0x00431CE0)(ref this); // .text:00431B40 ; bool __thiscall CInputManager::GetTextMode(CInputManager *this) .text:00431B40 ?GetTextMode@CInputManager@@UAE_NXZ

        // CInputManager.IsActionInProgress:
        public Byte IsActionInProgress(UInt32 i_action) => ((delegate* unmanaged[Thiscall]<ref CInputManager, UInt32, Byte>)0x00431AF0)(ref this, i_action); // .text:00431950 ; bool __thiscall CInputManager::IsActionInProgress(CInputManager *this, unsigned int i_action) .text:00431950 ?IsActionInProgress@CInputManager@@QAE_NK@Z

        // CInputManager.OnStartup:
        public Byte OnStartup(int dwUserData) => ((delegate* unmanaged[Thiscall]<ref CInputManager, int, Byte>)0x00430E00)(ref this, dwUserData); // .text:00430C60 ; bool __thiscall CInputManager::OnStartup(CInputManager *this, int dwUserData) .text:00430C60 ?OnStartup@CInputManager@@UAE_NJ@Z

        // CInputManager.OnSwitchMouseMode:
        public void OnSwitchMouseMode(Byte fEnterMouseLook) => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte, void>)0x00430E90)(ref this, fEnterMouseLook); // .text:00430CF0 ; void __thiscall CInputManager::OnSwitchMouseMode(CInputManager *this, bool fEnterMouseLook) .text:00430CF0 ?OnSwitchMouseMode@CInputManager@@MAEX_N@Z

        // CInputManager.RegisterInputHandler:
        public Byte RegisterInputHandler(CInputHandler* handler, UInt32 modes) => ((delegate* unmanaged[Thiscall]<ref CInputManager, CInputHandler*, UInt32, Byte>)0x00432140)(ref this, handler, modes); // .text:00431FA0 ; bool __thiscall CInputManager::RegisterInputHandler(CInputManager *this, CInputHandler *handler, unsigned int modes) .text:00431FA0 ?RegisterInputHandler@CInputManager@@UAE_NPAVCInputHandler@@K@Z

        // CInputManager.RegisterInputMap:
        public Byte RegisterInputMap(UInt32 i_id, IInputActionCallback* i_pcCallback, int i_nPriority) => ((delegate* unmanaged[Thiscall]<ref CInputManager, UInt32, IInputActionCallback*, int, Byte>)0x00431D10)(ref this, i_id, i_pcCallback, i_nPriority); // .text:00431B70 ; bool __thiscall CInputManager::RegisterInputMap(CInputManager *this, unsigned int i_id, IInputActionCallback *i_pcCallback, int i_nPriority) .text:00431B70 ?RegisterInputMap@CInputManager@@UAE_NKPAVIInputActionCallback@@J@Z

        // CInputManager.RegisterPreferences:
        public void RegisterPreferences() => ((delegate* unmanaged[Thiscall]<ref CInputManager, void>)0x004319B0)(ref this); // .text:00431810 ; void __thiscall CInputManager::RegisterPreferences(CInputManager *this) .text:00431810 ?RegisterPreferences@CInputManager@@IAEXXZ

        // CInputManager.SendActionToListeners:
        public void SendActionToListeners(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x00431440)(ref this, i_inEvt); // .text:004312A0 ; void __thiscall CInputManager::SendActionToListeners(CInputManager *this, InputEvent *i_inEvt) .text:004312A0 ?SendActionToListeners@CInputManager@@MAEXAAVInputEvent@@@Z

        // CInputManager.SetActionMap:
        public Byte SetActionMap(UInt32 _actID) => ((delegate* unmanaged[Thiscall]<ref CInputManager, UInt32, Byte>)0x00430E50)(ref this, _actID); // .text:00430CB0 ; bool __thiscall CInputManager::SetActionMap(CInputManager *this, unsigned int _actID) .text:00430CB0 ?SetActionMap@CInputManager@@UAE_NK@Z

        // CInputManager.SetMouseLookMode:
        public void SetMouseLookMode(Byte fEnterMouseLook) => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte, void>)0x00431560)(ref this, fEnterMouseLook); // .text:004313C0 ; void __thiscall CInputManager::SetMouseLookMode(CInputManager *this, bool fEnterMouseLook) .text:004313C0 ?SetMouseLookMode@CInputManager@@UAEX_N@Z

        // CInputManager.SetTextMode:
        public void SetTextMode(Byte mode) => ((delegate* unmanaged[Thiscall]<ref CInputManager, Byte, void>)0x00431590)(ref this, mode); // .text:004313F0 ; void __thiscall CInputManager::SetTextMode(CInputManager *this, bool mode) .text:004313F0 ?SetTextMode@CInputManager@@UAEX_N@Z

        // CInputManager.StartAction:
        public void StartAction(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x00430EC0)(ref this, i_inEvt); // .text:00430D20 ; void __thiscall CInputManager::StartAction(CInputManager *this, InputEvent *i_inEvt) .text:00430D20 ?StartAction@CInputManager@@IAEXAAVInputEvent@@@Z

        // CInputManager.ToggleActionKey:
        public void ToggleActionKey(InputEvent* i_inEvt) => ((delegate* unmanaged[Thiscall]<ref CInputManager, InputEvent*, void>)0x00432620)(ref this, i_inEvt); // .text:00432480 ; void __thiscall CInputManager::ToggleActionKey(CInputManager *this, InputEvent *i_inEvt) .text:00432480 ?ToggleActionKey@CInputManager@@IAEXAAVInputEvent@@@Z

        // CInputManager.TurnOffRunLock:
        public void TurnOffRunLock() => ((delegate* unmanaged[Thiscall]<ref CInputManager, void>)0x00432780)(ref this); // .text:004325E0 ; void __thiscall CInputManager::TurnOffRunLock(CInputManager *this) .text:004325E0 ?TurnOffRunLock@CInputManager@@QAEXXZ

        // CInputManager.UnregisterCallback:
        public void UnregisterCallback(IInputActionCallback* i_pcCallback) => ((delegate* unmanaged[Thiscall]<ref CInputManager, IInputActionCallback*, void>)0x004318B0)(ref this, i_pcCallback); // .text:00431710 ; void __thiscall CInputManager::UnregisterCallback(CInputManager *this, IInputActionCallback *i_pcCallback) .text:00431710 ?UnregisterCallback@CInputManager@@UAEXPAVIInputActionCallback@@@Z

        // CInputManager.UnregisterInputHandler:
        public Byte UnregisterInputHandler(CInputHandler* handler, UInt32 modes) => ((delegate* unmanaged[Thiscall]<ref CInputManager, CInputHandler*, UInt32, Byte>)0x00431770)(ref this, handler, modes); // .text:004315D0 ; bool __thiscall CInputManager::UnregisterInputHandler(CInputManager *this, CInputHandler *handler, unsigned int modes) .text:004315D0 ?UnregisterInputHandler@CInputManager@@UAE_NPAVCInputHandler@@K@Z

        // CInputManager.UnregisterInputMap:
        public Byte UnregisterInputMap(UInt32 i_id, IInputActionCallback* i_pcCallback) => ((delegate* unmanaged[Thiscall]<ref CInputManager, UInt32, IInputActionCallback*, Byte>)0x00431870)(ref this, i_id, i_pcCallback); // .text:004316D0 ; bool __thiscall CInputManager::UnregisterInputMap(CInputManager *this, unsigned int i_id, IInputActionCallback *i_pcCallback) .text:004316D0 ?UnregisterInputMap@CInputManager@@UAE_NKPAVIInputActionCallback@@@Z

        // CInputManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CInputManager, void>)0x00431D60)(ref this); // .text:00431BC0 ; void __thiscall CInputManager::UseTime(CInputManager *this) .text:00431BC0 ?UseTime@CInputManager@@UAEXXZ

        // Globals:
        public static Double* sm_timeKeyRepeatDelay = (Double*)0x00818A78; // .data:00817A78 ; long double CInputManager::sm_timeKeyRepeatDelay .data:00817A78 ?sm_timeKeyRepeatDelay@CInputManager@@1NA
        public static Double* sm_timeKeyRepeatSpeed = (Double*)0x00818A80; // .data:00817A80 ; long double CInputManager::sm_timeKeyRepeatSpeed .data:00817A80 ?sm_timeKeyRepeatSpeed@CInputManager@@1NA
    }

    public unsafe struct ActionState {
        // Struct:
        /*
        public IntrusiveHashData<UInt32, PTR<ActionState>> a0;
        public Double m_timeActionBegan;
        public UInt32 m_cRepeatCount;
        public UInt32 m_toggle;
        public IInputActionCallback* m_pcCallback;
        public SmartArray<ActionState.SingleKeyInfo> m_rgKeys;
        public override string ToString() => $"a0(IntrusiveHashData<UInt32,ActionState*>):{a0}, m_timeActionBegan:{m_timeActionBegan:n5}, m_cRepeatCount:{m_cRepeatCount:X8}, m_toggle:{m_toggle:X8}, m_pcCallback:->(IInputActionCallback*)0x{(int)m_pcCallback:X8}, m_rgKeys(SmartArray<ActionState.SingleKeyInfo,1>):{m_rgKeys}";
        public unsafe struct SingleKeyInfo {
            public ControlSpecification key;
            public Single extent;
            public override string ToString() => $"key(ControlSpecification):{key}, extent:{extent:n5}";
        }
        */
        // Functions:

        // ActionState.AddKeyPress:
        public ActionStateChangeType AddKeyPress(InputEvent* io_inEvt) => ((delegate* unmanaged[Thiscall]<ref ActionState, InputEvent*, ActionStateChangeType>)0x00431FA0)(ref this, io_inEvt); // .text:00431E00 ; ActionStateChangeType __thiscall ActionState::AddKeyPress(ActionState *this, InputEvent *io_inEvt) .text:00431E00 ?AddKeyPress@ActionState@@QAE?AW4ActionStateChangeType@@AAVInputEvent@@@Z

        // ActionState.GetExtent:
        public Single GetExtent() => ((delegate* unmanaged[Thiscall]<ref ActionState, Single>)0x00430F90)(ref this); // .text:00430DF0 ; float __thiscall ActionState::GetExtent(ActionState *this) .text:00430DF0 ?GetExtent@ActionState@@QBEMXZ

        // ActionState.RemoveKeyPress:
        public ActionStateChangeType RemoveKeyPress(InputEvent* io_inEvt) => ((delegate* unmanaged[Thiscall]<ref ActionState, InputEvent*, ActionStateChangeType>)0x004315C0)(ref this, io_inEvt); // .text:00431420 ; ActionStateChangeType __thiscall ActionState::RemoveKeyPress(ActionState *this, InputEvent *io_inEvt) .text:00431420 ?RemoveKeyPress@ActionState@@QAE?AW4ActionStateChangeType@@AAVInputEvent@@@Z
    }

    public unsafe struct ActionMap {
        // Struct:
        public DBObj a0;
        public HashList<UInt32, HashList<UInt32, ActionMapValue>> m_hashInputMaps;
        public UInt32 m_didStringTable;
        public HashTable<UInt32, InputMapConflictsValue> m_hashConflictingMaps;
        public override string ToString() => $"a0(DBObj):{a0}, m_hashInputMaps(HashList<UInt32,HashList<UInt32,ActionMapValue,1>,1>):{m_hashInputMaps}, m_didStringTable:{m_didStringTable:X8}, m_hashConflictingMaps(HashTable<UInt32,InputMapConflictsValue,0>):{m_hashConflictingMaps}";

        // Functions:

        // ActionMap.__Ctor:
        // public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ActionMap, void>)0xDEADBEEF)(ref this); // .text:00685BA0 ; void __thiscall ActionMap::ActionMap(ActionMap *this) .text:00685BA0 ??0ActionMap@@QAE@XZ

        // ActionMap.Allocator:
        // public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0xDEADBEEF)(); // .text:004F7210 ; DBObj *__cdecl ActionMap::Allocator() .text:004F7210 ?Allocator@ActionMap@@SAPAVDBObj@@XZ

        // ActionMap.Destroy:
        // public void Destroy() => ((delegate* unmanaged[Thiscall]<ref ActionMap, void>)0xDEADBEEF)(ref this); // .text:00685B80 ; void __thiscall ActionMap::Destroy(ActionMap *this) .text:00685B80 ?Destroy@ActionMap@@UAEXXZ

        // ActionMap.GetActionClass:
        // public UInt32 GetActionClass(UInt32 i_eAction, UInt32 i_eMapID) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, UInt32, UInt32>)0xDEADBEEF)(ref this, i_eAction, i_eMapID); // .text:006855C0 ; unsigned int __thiscall ActionMap::GetActionClass(ActionMap *this, unsigned int i_eAction, unsigned int i_eMapID) .text:006855C0 ?GetActionClass@ActionMap@@QBEKKK@Z

        // ActionMap.GetConflictingInputMaps:
        public Byte GetConflictingInputMaps(UInt32 i_eMapID, _List<UInt32>* o_listConflictingInputMaps) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, _List<UInt32>*, Byte>)0x00685F30)(ref this, i_eMapID, o_listConflictingInputMaps); // .text:00684EE0 ; bool __thiscall ActionMap::GetConflictingInputMaps(ActionMap *this, unsigned int i_eMapID, List<unsigned long> *o_listConflictingInputMaps) .text:00684EE0 ?GetConflictingInputMaps@ActionMap@@QBE_NKAAV?$List@K@@@Z

        // ActionMap.GetDBOType:
        // public UInt32 GetDBOType() => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32>)0xDEADBEEF)(ref this); // .text:00685C00 ; unsigned int __thiscall ActionMap::GetDBOType(ActionMap *this) .text:00685C00 ?GetDBOType@ActionMap@@UBEKXZ

        // ActionMap.GetDescripValues:
        // public Byte GetDescripValues(UInt32 i_eAction, UInt32 i_eMapID, PStringBase<UInt16>* o_strName, PStringBase<UInt16>* o_strDescrip) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, UInt32, PStringBase<UInt16>*, PStringBase<UInt16>*, Byte>)0xDEADBEEF)(ref this, i_eAction, i_eMapID, o_strName, o_strDescrip); // .text:00685690 ; bool __thiscall ActionMap::GetDescripValues(ActionMap *this, unsigned int i_eAction, unsigned int i_eMapID, PStringBase<unsigned short> *o_strName, PStringBase<unsigned short> *o_strDescrip) .text:00685690 ?GetDescripValues@ActionMap@@QBE_NKKAAV?$PStringBase@G@@0@Z

        // ActionMap.GetToggleType:
        // public UInt32 GetToggleType(UInt32 i_eAction, UInt32 i_eMapID) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, UInt32, UInt32>)0xDEADBEEF)(ref this, i_eAction, i_eMapID); // .text:00685350 ; unsigned int __thiscall ActionMap::GetToggleType(ActionMap *this, unsigned int i_eAction, unsigned int i_eMapID) .text:00685350 ?GetToggleType@ActionMap@@QBEKKK@Z

        // ActionMap.IsActionAllowedInInputMap:
        // public Byte IsActionAllowedInInputMap(UInt32 i_eAction, UInt32 i_eMapID) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, UInt32, Byte>)0xDEADBEEF)(ref this, i_eAction, i_eMapID); // .text:00685420 ; bool __thiscall ActionMap::IsActionAllowedInInputMap(ActionMap *this, unsigned int i_eAction, unsigned int i_eMapID) .text:00685420 ?IsActionAllowedInInputMap@ActionMap@@QBE_NKK@Z

        // ActionMap.IsUserBindable:
        // public Byte IsUserBindable(UInt32 i_eAction, UInt32 i_eMapID) => ((delegate* unmanaged[Thiscall]<ref ActionMap, UInt32, UInt32, Byte>)0xDEADBEEF)(ref this, i_eAction, i_eMapID); // .text:006854E0 ; bool __thiscall ActionMap::IsUserBindable(ActionMap *this, unsigned int i_eAction, unsigned int i_eMapID) .text:006854E0 ?IsUserBindable@ActionMap@@QBE_NKK@Z

        // ActionMap.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref ActionMap, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:00685F10 ; void __thiscall ActionMap::Serialize(ActionMap *this, Archive *io_archive) .text:00685F10 ?Serialize@ActionMap@@UAEXAAVArchive@@@Z
    }
    public unsafe struct ActionMapValue {
        // Struct:
        public UInt32 m_eToggleType;
        public UserBindingValue m_userBindingData;
        public override string ToString() => $"m_eToggleType:{m_eToggleType:X8}, m_userBindingData(UserBindingValue):{m_userBindingData}";

        // Functions:

        // ActionMapValue.GetDescriptionValues:
        // public Byte GetDescriptionValues(UInt32 i_didStringTable, PStringBase<UInt16>* o_strName, PStringBase<UInt16>* o_strDescription) => ((delegate* unmanaged[Thiscall]<ref ActionMapValue, UInt32, PStringBase<UInt16>*, PStringBase<UInt16>*, Byte>)0xDEADBEEF)(ref this, i_didStringTable, o_strName, o_strDescription); // .text:006845E0 ; bool __thiscall ActionMapValue::GetDescriptionValues(ActionMapValue *this, IDClass<_tagDataID,32,0> i_didStringTable, PStringBase<unsigned short> *o_strName, PStringBase<unsigned short> *o_strDescription) .text:006845E0 ?GetDescriptionValues@ActionMapValue@@QBE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAV?$PStringBase@G@@1@Z

        // ActionMapValue.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref ActionMapValue, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:00684A30 ; void __thiscall ActionMapValue::Serialize(ActionMapValue *this, Archive *io_archive) .text:00684A30 ?Serialize@ActionMapValue@@QAEXAAVArchive@@@Z
    }
    public unsafe struct UserBindingValue {
        // Struct:
        public UInt32 m_eActionClass;
        public UInt32 m_action_name;
        public UInt32 m_description;
        public override string ToString() => $"m_eActionClass:{m_eActionClass:X8}, m_action_name:{m_action_name:X8}, m_description:{m_description:X8}";
    }
    public unsafe struct InputMapConflictsValue {
        // Struct:
        public UInt32 m_eInputMap;
        public _List<UInt32> m_listConflictingInputMaps;
        public override string ToString() => $"m_eInputMap:{m_eInputMap:X8}, m_listConflictingInputMaps(List<UInt32>):{m_listConflictingInputMaps}";
    }
    public unsafe struct ICIDM {
        // Struct:
        public ICIDM.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(ICIDM.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(ICIDM *this, unsigned int);
            public fixed byte gap4[20];
            public static delegate* unmanaged[Thiscall]<ICIDM*, int> GetMouseX; // int (__thiscall *GetMouseX)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, int> GetMouseY; // int (__thiscall *GetMouseY)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, int, int, Byte> SetMouseXY; // bool (__thiscall *SetMouseXY)(ICIDM *this, int, int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> ClearKeyMap; // bool (__thiscall *ClearKeyMap)(ICIDM *this);
            public fixed byte gap28[4];
            public static delegate* unmanaged[Thiscall]<ICIDM*, PStringBase<char>, bool> AddKeyMap; // bool (__thiscall *AddKeyMap)(ICIDM *this, PStringBase<char>);
            public static delegate* unmanaged[Thiscall]<ICIDM*, PStringBase<char>, Byte> SaveKeyMap; // bool (__thiscall *SaveKeyMap)(ICIDM *this, PStringBase<char>);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, IInputActionCallback*, int, Byte> RegisterInputMap; // bool (__thiscall *RegisterInputMap)(ICIDM *this, unsigned int, IInputActionCallback *, int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, IInputActionCallback*, Byte> UnregisterInputMap; // bool (__thiscall *UnregisterInputMap)(ICIDM *this, unsigned int, IInputActionCallback *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, IInputActionCallback*, void> UnregisterCallback; // void (__thiscall *UnregisterCallback)(ICIDM *this, IInputActionCallback *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, Byte> SetActionMap; // bool (__thiscall *SetActionMap)(ICIDM *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, ActionMap*> GetActionMap; // ActionMap *(__thiscall *GetActionMap)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, CInputHandler*, UInt32, Byte> RegisterInputHandler; // bool (__thiscall *RegisterInputHandler)(ICIDM *this, CInputHandler *, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, CInputHandler*, UInt32, Byte> UnregisterInputHandler; // bool (__thiscall *UnregisterInputHandler)(ICIDM *this, CInputHandler *, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, ControlSpecification, Byte> IsMetaKey; // bool (__thiscall *IsMetaKey)(ICIDM *this, ControlSpecification);
            public static delegate* unmanaged[Thiscall]<ICIDM*, ControlSpecification, DeviceType> GetDeviceTypeFromKey; // DeviceType (__thiscall *GetDeviceTypeFromKey)(ICIDM *this, ControlSpecification);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> ShiftKeyDown; // bool (__thiscall *ShiftKeyDown)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> CtrlKeyDown; // bool (__thiscall *CtrlKeyDown)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> AltKeyDown; // bool (__thiscall *AltKeyDown)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte, void> SetMouseLookMode; // void (__thiscall *SetMouseLookMode)(ICIDM *this, bool);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> GetMouseLookMode; // bool (__thiscall *GetMouseLookMode)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, MouseLookBehavior, int, int, void> ConfigureMouseLookMode; // void (__thiscall *ConfigureMouseLookMode)(ICIDM *this, MouseLookBehavior, int, int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, tagMSG*, Byte*, int> OnMessage; // int (__thiscall *OnMessage)(ICIDM *this, tagMSG *, bool *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte, void> Activate; // void (__thiscall *Activate)(ICIDM *this, bool);
            public static delegate* unmanaged[Thiscall]<ICIDM*, void> OnUIElementActivationChanging; // void (__thiscall *OnUIElementActivationChanging)(ICIDM *this);
            //maybe empty?
            public fixed byte gap2[4];
            public static delegate* unmanaged[Thiscall]<ICIDM*, PStringBase<char>*, ControlSpecification, PStringBase<char>*> GetNameFromKey; // PStringBase<char> *(__thiscall *GetNameFromKey)(ICIDM *this, PStringBase<char> *result, ControlSpecification);
            public static delegate* unmanaged[Thiscall]<ICIDM*, PStringBase<char>*, ControlSpecification, PStringBase<char>*> GetNameFromMetaKey; // PStringBase<char> *(__thiscall *GetNameFromMetaKey)(ICIDM *this, PStringBase<char> *result, ControlSpecification);
            public static delegate* unmanaged[Thiscall]<ICIDM*, QualifiedControl, UInt32, UInt32, Byte> BindAction; // bool (__thiscall *BindAction)(ICIDM *this, QualifiedControl, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, QualifiedControl, UInt32, Byte> UnbindByKey; // bool (__thiscall *UnbindByKey)(ICIDM *this, QualifiedControl, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, UInt32, _List<QualifiedControl>*, Byte> FindKeysForAction; // bool (__thiscall *FindKeysForAction)(ICIDM *this, unsigned int, unsigned int, List<QualifiedControl> *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, _List<UInt32>*, Byte> FindConflictingInputMaps; // bool (__thiscall *FindConflictingInputMaps)(ICIDM *this, unsigned int, List<unsigned long> *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, QualifiedControl*, UInt32, SmartArray<_STL.Pair<QualifiedControl, UInt32>>*, Byte> FindConflictingControls; // bool (__thiscall *FindConflictingControls)(ICIDM *this, QualifiedControl *, unsigned int, SmartArray<_STL::pair<QualifiedControl,unsigned long>,1> *);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32, UInt32, Byte> UnbindAllByAction; // bool (__thiscall *UnbindAllByAction)(ICIDM *this, unsigned int, unsigned int);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32> GetDoubleClickDelay; // unsigned int (__thiscall *GetDoubleClickDelay)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, UInt32> GetTapDelay; // unsigned int (__thiscall *GetTapDelay)(ICIDM *this);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte, void> SetTextMode; // void (__thiscall *SetTextMode)(ICIDM *this, bool);
            public static delegate* unmanaged[Thiscall]<ICIDM*, Byte> GetTextMode; // bool (__thiscall *GetTextMode)(ICIDM *this);
        }

        // Globals:
        public static ICIDM** s_cidm = (ICIDM**)0x00837FF4; // .data:00836FF4 ; ICIDM *ICIDM::s_cidm .data:00836FF4 ?s_cidm@ICIDM@@1PAV1@A
    }
    public unsafe struct tagMSG {
        // Struct:
        public HWND__* hwnd;
        public UInt32 message;
        public UInt32 wParam;
        public int lParam;
        public UInt32 time;
        public tagPOINT pt;
        public override string ToString() => $"hwnd:->(HWND__*)0x{(int)hwnd:X8}, message:{message:X8}, wParam:{wParam:X8}, lParam(int):{lParam}, time:{time:X8}, pt(tagPOINT):{pt}";
    }
    public unsafe struct HWND__ {
        // Struct:
        public int unused;
        public override string ToString() => $"unused(int):{unused}";
    }
    public unsafe struct DIDEVICEOBJECTDATA {
        // Struct:
        public UInt32 dwOfs;
        public UInt32 dwData;
        public UInt32 dwTimeStamp;
        public UInt32 dwSequence;
        public UInt32 uAppData;
        public override string ToString() => $"dwOfs:{dwOfs:X8}, dwData:{dwData:X8}, dwTimeStamp:{dwTimeStamp:X8}, dwSequence:{dwSequence:X8}, uAppData:{uAppData:X8}";
    }
    public unsafe struct IDirectInputDevice8A {
        // Struct:
        public IUnknown a0;
        public override string ToString() => $"a0(IUnknown):{a0}";
    }
    public unsafe struct IUnknown {
        // Struct:
        public IUnknown.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(IUnknown.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<IUnknown*, _GUID*, void**, int> QueryInterface; // int (__stdcall *QueryInterface)(IUnknown *this, _GUID *, void **);
            public static delegate* unmanaged[Thiscall]<IUnknown*, UInt32> AddRef; // unsigned int (__stdcall *AddRef)(IUnknown *this);
            public static delegate* unmanaged[Thiscall]<IUnknown*, UInt32> Release; // unsigned int (__stdcall *Release)(IUnknown *this);
        }
    }
    public unsafe struct IDirectInput8A {
        // Struct:
        public IUnknown a0;
        public override string ToString() => $"a0(IUnknown):{a0}";
    }

    public unsafe struct CMasterInputMap {
        // Struct:
        public DBObj a0;
        public PStringBase<char> m_strName;
        public Turbine_GUID m_guidMap;
        public SmartArray<DeviceKeyMapEntry> m_rgDevices;
        public HashList<ControlSpecification, UInt32> m_listMetaKeys;
        public HashList<UInt32, PTR<CInputMap>> m_hashSections;
        public UInt32 m_dwUsedMetaKeys;
        public override string ToString() => $"a0(DBObj):{a0}, m_strName(PStringBase<char>):{m_strName}, m_guidMap(Turbine_GUID):{m_guidMap}, m_rgDevices(SmartArray<DeviceKeyMapEntry,1>):{m_rgDevices}, m_listMetaKeys(HashList<ControlSpecification,UInt32,1>):{m_listMetaKeys}, m_hashSections(HashList<UInt32,CInputMap*,1>):{m_hashSections}, m_dwUsedMetaKeys:{m_dwUsedMetaKeys:X8}";

        // Functions:

        // CMasterInputMap.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, void>)0x0068F710)(ref this); // .text:0068E7C0 ; void __thiscall CMasterInputMap::CMasterInputMap(CMasterInputMap *this) .text:0068E7C0 ??0CMasterInputMap@@QAE@XZ

        // CMasterInputMap.AddDeviceEntry:
        public int AddDeviceEntry(DeviceKeyMapEntry* device) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, DeviceKeyMapEntry*, int>)0x0068E0A0)(ref this, device); // .text:0068D150 ; int __thiscall CMasterInputMap::AddDeviceEntry(CMasterInputMap *this, DeviceKeyMapEntry *device) .text:0068D150 ?AddDeviceEntry@CMasterInputMap@@QAEHABVDeviceKeyMapEntry@@@Z

        // CMasterInputMap.Allocator:
        // public static DBObj* Allocator() => ((delegate* unmanaged[Cdecl]<DBObj*>)0xDEADBEEF)(); // .text:004F71C0 ; DBObj *__cdecl CMasterInputMap::Allocator() .text:004F71C0 ?Allocator@CMasterInputMap@@SAPAVDBObj@@XZ

        // CMasterInputMap.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, void>)0x0068FA90)(ref this); // .text:0068EB40 ; void __thiscall CMasterInputMap::Clear(CMasterInputMap *this) .text:0068EB40 ?Clear@CMasterInputMap@@QAEXXZ

        // CMasterInputMap.CopyInto:
        // public Byte CopyInto(DBObj* retval) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, DBObj*, Byte>)0xDEADBEEF)(ref this, retval); // .text:0068FC70 ; bool __thiscall CMasterInputMap::CopyInto(CMasterInputMap *this, DBObj *retval) .text:0068FC70 ?CopyInto@CMasterInputMap@@UBE_NAAVDBObj@@@Z

        // CMasterInputMap.CreateInputMap:
        public CInputMap* CreateInputMap(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, UInt32, CInputMap*>)0x00690260)(ref this, id); // .text:0068F310 ; CInputMap *__thiscall CMasterInputMap::CreateInputMap(CMasterInputMap *this, unsigned int id) .text:0068F310 ?CreateInputMap@CMasterInputMap@@QAEPAVCInputMap@@K@Z

        // CMasterInputMap.FromFileNode:
        public Byte FromFileNode(PFileNode* pRootNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Byte>)0x00690F30)(ref this, pRootNode); // .text:0068FFE0 ; bool __thiscall CMasterInputMap::FromFileNode(CMasterInputMap *this, PFileNode *pRootNode) .text:0068FFE0 ?FromFileNode@CMasterInputMap@@QAE_NPBVPFileNode@@@Z

        // CMasterInputMap.GetDBOType:
        // public UInt32 GetDBOType() => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, UInt32>)0xDEADBEEF)(ref this); // .text:0068E820 ; unsigned int __thiscall CMasterInputMap::GetDBOType(CMasterInputMap *this) .text:0068E820 ?GetDBOType@CMasterInputMap@@UBEKXZ

        // CMasterInputMap.GetInputMapByID:
        public CInputMap* GetInputMapByID(UInt32 id) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, UInt32, CInputMap*>)0x006887D0)(ref this, id); // .text:004DB250 ; CInputMap *__thiscall CMasterInputMap::GetInputMapByID(CMasterInputMap *this, unsigned int id) .text:004DB250 ?GetInputMapByID@CMasterInputMap@@QAEPAVCInputMap@@K@Z

        // CMasterInputMap.IsMetaKey:
        public Byte IsMetaKey(ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, ControlSpecification, Byte>)0x0068E760)(ref this, key); // .text:0068D810 ; bool __thiscall CMasterInputMap::IsMetaKey(CMasterInputMap *this, ControlSpecification key) .text:0068D810 ?IsMetaKey@CMasterInputMap@@QBE_NVControlSpecification@@@Z

        // CMasterInputMap.KeyFromMetaMode:
        public ControlSpecification* KeyFromMetaMode(ControlSpecification* result, UInt32 _data) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, ControlSpecification*, UInt32, ControlSpecification*>)0x0068E7E0)(ref this, result, _data); // .text:0068D890 ; ControlSpecification *__thiscall CMasterInputMap::KeyFromMetaMode(CMasterInputMap *this, ControlSpecification *result, unsigned int _data) .text:0068D890 ?KeyFromMetaMode@CMasterInputMap@@QBE?AVControlSpecification@@K@Z

        // CMasterInputMap.Merge:
        public Byte Merge(CMasterInputMap* rhs, Byte fForce) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, CMasterInputMap*, Byte, Byte>)0x00690640)(ref this, rhs, fForce); // .text:0068F6F0 ; bool __thiscall CMasterInputMap::Merge(CMasterInputMap *this, CMasterInputMap *rhs, bool fForce) .text:0068F6F0 ?Merge@CMasterInputMap@@QAE_NABV1@_N@Z

        // CMasterInputMap.MetaModeFromKey:
        public UInt32 MetaModeFromKey(ControlSpecification key) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, ControlSpecification, UInt32>)0x0068E7A0)(ref this, key); // .text:0068D850 ; unsigned int __thiscall CMasterInputMap::MetaModeFromKey(CMasterInputMap *this, ControlSpecification key) .text:0068D850 ?MetaModeFromKey@CMasterInputMap@@QBEKVControlSpecification@@@Z

        // CMasterInputMap.ReadBindingsFromFileNode:
        // public Byte ReadBindingsFromFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068FA90 ; bool __thiscall CMasterInputMap::ReadBindingsFromFileNode(CMasterInputMap *this, PFileNode *i_pNode) .text:0068FA90 ?ReadBindingsFromFileNode@CMasterInputMap@@IAE_NPBVPFileNode@@@Z

        // CMasterInputMap.ReadDevicesFromFileNode:
        // public Byte ReadDevicesFromFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068D6B0 ; bool __thiscall CMasterInputMap::ReadDevicesFromFileNode(CMasterInputMap *this, PFileNode *i_pNode) .text:0068D6B0 ?ReadDevicesFromFileNode@CMasterInputMap@@IAE_NPBVPFileNode@@@Z

        // CMasterInputMap.ReadGuidFromFileNode:
        // public Byte ReadGuidFromFileNode(PFileNode* i_pNode, Turbine_GUID* o_guid) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Turbine_GUID*, Byte>)0xDEADBEEF)(ref this, i_pNode, o_guid); // .text:0068CE60 ; bool __thiscall CMasterInputMap::ReadGuidFromFileNode(CMasterInputMap *this, PFileNode *i_pNode, Turbine_GUID *o_guid) .text:0068CE60 ?ReadGuidFromFileNode@CMasterInputMap@@IAE_NPBVPFileNode@@AAUTurbine_GUID@@@Z

        // CMasterInputMap.ReadMetaKeysFromFileNode:
        // public Byte ReadMetaKeysFromFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068F1E0 ; bool __thiscall CMasterInputMap::ReadMetaKeysFromFileNode(CMasterInputMap *this, PFileNode *i_pNode) .text:0068F1E0 ?ReadMetaKeysFromFileNode@CMasterInputMap@@IAE_NPBVPFileNode@@@Z

        // CMasterInputMap.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:0068FCE0 ; void __thiscall CMasterInputMap::Serialize(CMasterInputMap *this, Archive *io_archive) .text:0068FCE0 ?Serialize@CMasterInputMap@@UAEXAAVArchive@@@Z

        // CMasterInputMap.ToFileNode:
        public Byte ToFileNode(PFileNode* pRootNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, PFileNode*, Byte>)0x0068E850)(ref this, pRootNode); // .text:0068D900 ; bool __thiscall CMasterInputMap::ToFileNode(CMasterInputMap *this, PFileNode *pRootNode) .text:0068D900 ?ToFileNode@CMasterInputMap@@QBE_NPAVPFileNode@@@Z

        // CMasterInputMap.WriteGuidToFileNode:
        // public Byte WriteGuidToFileNode(Turbine_GUID* i_guid, PFileNode* io_pNode) => ((delegate* unmanaged[Thiscall]<ref CMasterInputMap, Turbine_GUID*, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_guid, io_pNode); // .text:0068D080 ; bool __thiscall CMasterInputMap::WriteGuidToFileNode(CMasterInputMap *this, Turbine_GUID *i_guid, PFileNode *io_pNode) .text:0068D080 ?WriteGuidToFileNode@CMasterInputMap@@IBE_NABUTurbine_GUID@@PAVPFileNode@@@Z
    }
    public unsafe struct DeviceKeyMapEntry {
        // Struct:
        public DeviceType dt;
        public Turbine_GUID guid;
        public override string ToString() => $"dt(DeviceType):{dt}, guid(Turbine_GUID):{guid}";
    }
    public unsafe struct CInputMap {
        // Struct:
        public CMasterInputMap* m_pParent;
        public UInt32 m_eInputMapID;
        public CInputMap.ActionBindingList m_listMappings;
        public override string ToString() => $"m_pParent:->(CMasterInputMap*)0x{(int)m_pParent:X8}, m_eInputMapID:{m_eInputMapID:X8}, m_listMappings(CInputMap.ActionBindingList):{m_listMappings}";
        public unsafe struct ActionBindingList {
            public HashList<QualifiedControl, UInt32> a0;
            public override string ToString() => $"a0(HashList<QualifiedControl,UInt32>):{a0}";
        }

        // Functions:

        // CInputMap.AddMapping:
        public Byte AddMapping(UInt32 id, QualifiedControl key) => ((delegate* unmanaged[Thiscall]<ref CInputMap, UInt32, QualifiedControl, Byte>)0x0068FEE0)(ref this, id, key); // .text:0068EF90 ; bool __thiscall CInputMap::AddMapping(CInputMap *this, unsigned int id, QualifiedControl key) .text:0068EF90 ?AddMapping@CInputMap@@QAE_NKVQualifiedControl@@@Z

        // CInputMap.FindBestMatch:
        public Byte FindBestMatch(QualifiedControl* i_key, UInt32* o_idAction, QualifiedControl* o_key) => ((delegate* unmanaged[Thiscall]<ref CInputMap, QualifiedControl*, UInt32*, QualifiedControl*, Byte>)0x0068E540)(ref this, i_key, o_idAction, o_key); // .text:0068D5F0 ; bool __thiscall CInputMap::FindBestMatch(CInputMap *this, QualifiedControl *i_key, unsigned int *o_idAction, QualifiedControl *o_key) .text:0068D5F0 ?FindBestMatch@CInputMap@@QBE_NABVQualifiedControl@@AAKAAV2@@Z

        // CInputMap.FindConflictingControls:
        public Byte FindConflictingControls(QualifiedControl* i_key, SmartArray<_STL.Pair<QualifiedControl, UInt32>>* o_controls) => ((delegate* unmanaged[Thiscall]<ref CInputMap, QualifiedControl*, SmartArray<_STL.Pair<QualifiedControl, UInt32>>*, Byte>)0x0068E550)(ref this, i_key, o_controls); // .text:0068D600 ; bool __thiscall CInputMap::FindConflictingControls(CInputMap *this, QualifiedControl *i_key, SmartArray<_STL::pair<QualifiedControl,unsigned long>,1> *o_controls) .text:0068D600 ?FindConflictingControls@CInputMap@@QBE_NABVQualifiedControl@@AAV?$SmartArray@U?$pair@VQualifiedControl@@K@_STL@@$00@@@Z

        // CInputMap.FindKeysForAction:
        public Byte FindKeysForAction(UInt32 i_id, _List<QualifiedControl>* o_list) => ((delegate* unmanaged[Thiscall]<ref CInputMap, UInt32, _List<QualifiedControl>*, Byte>)0x0068E560)(ref this, i_id, o_list); // .text:0068D610 ; bool __thiscall CInputMap::FindKeysForAction(CInputMap *this, unsigned int i_id, List<QualifiedControl> *o_list) .text:0068D610 ?FindKeysForAction@CInputMap@@QAE_NKAAV?$List@VQualifiedControl@@@@@Z

        // CInputMap.FromFileNode:
        // public Byte FromFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref CInputMap, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068F3B0 ; bool __thiscall CInputMap::FromFileNode(CInputMap *this, PFileNode *i_pNode) .text:0068F3B0 ?FromFileNode@CInputMap@@IAE_NPBVPFileNode@@@Z

        // CInputMap.Merge:
        // public Byte Merge(CInputMap* rhs, HashTable<UInt32,UInt32>* hashMap, Byte fForce) => ((delegate* unmanaged[Thiscall]<ref CInputMap, CInputMap*, HashTable<UInt32,UInt32>*, Byte, Byte>)0xDEADBEEF)(ref this, rhs, hashMap, fForce); // .text:0068F0A0 ; bool __thiscall CInputMap::Merge(CInputMap *this, CInputMap *rhs, HashTable<unsigned long,unsigned long,0> *hashMap, bool fForce) .text:0068F0A0 ?Merge@CInputMap@@IAE_NABV1@ABV?$HashTable@KK$0A@@@_N@Z

        // CInputMap.Serialize:
        // public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref CInputMap, Archive*, void>)0xDEADBEEF)(ref this, io_archive); // .text:0068EE60 ; void __thiscall CInputMap::Serialize(CInputMap *this, Archive *io_archive) .text:0068EE60 ?Serialize@CInputMap@@QAEXAAVArchive@@@Z

        // CInputMap.ToFileNode:
        // public Byte ToFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref CInputMap, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068D2A0 ; bool __thiscall CInputMap::ToFileNode(CInputMap *this, PFileNode *i_pNode) .text:0068D2A0 ?ToFileNode@CInputMap@@IBE_NPAVPFileNode@@@Z

        // CInputMap.UnbindAllByAction:
        public Byte UnbindAllByAction(UInt32 i_id) => ((delegate* unmanaged[Thiscall]<ref CInputMap, UInt32, Byte>)0x0068F950)(ref this, i_id); // .text:0068EA00 ; bool __thiscall CInputMap::UnbindAllByAction(CInputMap *this, unsigned int i_id) .text:0068EA00 ?UnbindAllByAction@CInputMap@@QAE_NK@Z

        // CInputMap.UnbindByKey:
        public Byte UnbindByKey(QualifiedControl i_key) => ((delegate* unmanaged[Thiscall]<ref CInputMap, QualifiedControl, Byte>)0x0068F6B0)(ref this, i_key); // .text:0068E760 ; bool __thiscall CInputMap::UnbindByKey(CInputMap *this, QualifiedControl i_key) .text:0068E760 ?UnbindByKey@CInputMap@@QAE_NVQualifiedControl@@@Z

        // CInputMap.VerifyActivationAndToggleType:
        // public Byte VerifyActivationAndToggleType(QualifiedControl* i_key, UInt32 i_idAction, PFileNode* i_pCurLine) => ((delegate* unmanaged[Thiscall]<ref CInputMap, QualifiedControl*, UInt32, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_key, i_idAction, i_pCurLine); // .text:0068CD60 ; bool __thiscall CInputMap::VerifyActivationAndToggleType(CInputMap *this, QualifiedControl *i_key, unsigned int i_idAction, PFileNode *i_pCurLine) .text:0068CD60 ?VerifyActivationAndToggleType@CInputMap@@IAE_NABVQualifiedControl@@KPBVPFileNode@@@Z
    }
    public unsafe struct CInputHandler {
        // Struct:
        public CInputHandler.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(CInputHandler.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<CInputHandler*, InputEvent*, void> ActionHandler; // void (__thiscall *ActionHandler)(CInputHandler *this, InputEvent *);
            public static delegate* unmanaged[Thiscall]<CInputHandler*, int, int, void> MouseMoveHandler; // void (__thiscall *MouseMoveHandler)(CInputHandler *this, int, int);
            public static delegate* unmanaged[Thiscall]<CInputHandler*, int, int, void> MouseLookHandler; // void (__thiscall *MouseLookHandler)(CInputHandler *this, int, int);
            public static delegate* unmanaged[Thiscall]<CInputHandler*, Byte, int, void> FocusSwitchHandler; // void (__thiscall *FocusSwitchHandler)(CInputHandler *this, bool, int);
            public static delegate* unmanaged[Thiscall]<CInputHandler*, ushort, void> CharacterHandler; // void (__thiscall *CharacterHandler)(CInputHandler *this, wchar_t);
            public static delegate* unmanaged[Thiscall]<CInputHandler*, QualifiedControl*, UInt32*, Byte> KeyHitHandler; // bool (__thiscall *KeyHitHandler)(CInputHandler *this, QualifiedControl *, unsigned int *);
        }
    }
    public unsafe struct InputEvent {
        // Struct:
        public UInt32 m_InputAction;
        public UInt32 m_InputMapID;
        public QualifiedControl m_InputKey;
        public Single m_InputExtent;
        public UInt32 m_InputTimestamp;
        public UInt32 m_ToggleType;
        public Byte m_fStart;
        public Double m_timeActionBegan;
        public UInt32 m_cRepeatDelta;
        public UInt32 m_cRepeatTotal;
        public tagPOINT m_ptMousePos;
        public IInputActionCallback* m_pcCallback;
        public override string ToString() => $"m_InputAction:{m_InputAction:X8}, m_InputMapID:{m_InputMapID:X8}, m_InputKey(QualifiedControl):{m_InputKey}, m_InputExtent:{m_InputExtent:n5}, m_InputTimestamp:{m_InputTimestamp:X8}, m_ToggleType:{m_ToggleType:X8}, m_fStart:{m_fStart:X2}, m_timeActionBegan:{m_timeActionBegan:n5}, m_cRepeatDelta:{m_cRepeatDelta:X8}, m_cRepeatTotal:{m_cRepeatTotal:X8}, m_ptMousePos(tagPOINT):{m_ptMousePos}, m_pcCallback:->(IInputActionCallback*)0x{(int)m_pcCallback:X8}";

        // Functions:

        // InputEvent.__Ctor:
        public void __Ctor(ActionState* _as) => ((delegate* unmanaged[Thiscall]<ref InputEvent, ActionState*, void>)0x00430FF0)(ref this, _as); // .text:00430E50 ; void __thiscall InputEvent::InputEvent(InputEvent *this, ActionState *as) .text:00430E50 ??0InputEvent@@QAE@ABVActionState@@@Z

        // InputEvent.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref InputEvent, void>)0x00430EE0)(ref this); // .text:00430D40 ; void __thiscall InputEvent::InputEvent(InputEvent *this) .text:00430D40 ??0InputEvent@@QAE@XZ
    }
    public unsafe struct IInputActionCallback {
        // Struct:
        public IInputActionCallback.Vtbl* vfptr;
        public override string ToString() => $"vfptr:->(IInputActionCallback.Vtbl*)0x{(int)vfptr:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<IInputActionCallback*, UInt32, void*> __vecDelDtor; // void *(__thiscall *__vecDelDtor)(IInputActionCallback *this, unsigned int);
            public static delegate* unmanaged[Thiscall]<IInputActionCallback*, InputEvent*, Byte> OnAction; // bool (__thiscall *OnAction)(IInputActionCallback *this, InputEvent *);
            public static delegate* unmanaged[Thiscall]<IInputActionCallback*, UInt32, UInt32, UInt32, CallbackLoseFocusResult> OnLoseFocus; // CallbackLoseFocusResult (__thiscall *OnLoseFocus)(IInputActionCallback *this, unsigned int, unsigned int, unsigned int);
        }

        // Functions:

        // IInputActionCallback.OnLoseFocus:
        public ObjectDrawStatus OnLoseFocus(CGfxObj* mesh, Position* mesh_pos, Byte building_flag) => ((delegate* unmanaged[Thiscall]<ref IInputActionCallback, CGfxObj*, Position*, Byte, ObjectDrawStatus>)0x006B4CF0)(ref this, mesh, mesh_pos, building_flag); // .text:006B3DB0 ; ObjectDrawStatus __thiscall IInputActionCallback::OnLoseFocus(RenderDevice *this, CGfxObj *mesh, Position *mesh_pos, bool building_flag) .text:006B3DB0 ?OnLoseFocus@IInputActionCallback@@UAE?AW4CallbackLoseFocusResult@@KKK@Z
    }
    public unsafe struct QualifiedControl {
        // Struct:
        public ControlSpecification m_key;
        public UInt32 m_metamode;
        public UInt32 m_activation;
        public override string ToString() => $"m_key(ControlSpecification):{m_key}, m_metamode:{m_metamode:X8}, m_activation:{m_activation:X8}";

        // Functions:

        // QualifiedControl.operator_is_equal:
        // public Byte operator_is_equal(QualifiedControl* rhs) => ((delegate* unmanaged[Thiscall]<ref QualifiedControl, QualifiedControl*, Byte>)0xDEADBEEF)(ref this, rhs); // .text:0068A1D0 ; bool __thiscall QualifiedControl::operator==(QualifiedControl *this, QualifiedControl *rhs) .text:0068A1D0 ??8QualifiedControl@@QBE_NABV0@@Z

        // QualifiedControl.IsBetterMatch:
        public Byte IsBetterMatch(QualifiedControl* lhs, QualifiedControl* rhs) => ((delegate* unmanaged[Thiscall]<ref QualifiedControl, QualifiedControl*, QualifiedControl*, Byte>)0x0068B300)(ref this, lhs, rhs); // .text:0068A270 ; bool __thiscall QualifiedControl::IsBetterMatch(QualifiedControl *this, QualifiedControl *lhs, QualifiedControl *rhs) .text:0068A270 ?IsBetterMatch@QualifiedControl@@QBE_NABV1@0@Z

        // QualifiedControl.IsConflicting:
        public Byte IsConflicting(QualifiedControl* rhs) => ((delegate* unmanaged[Thiscall]<ref QualifiedControl, QualifiedControl*, Byte>)0x0068B190)(ref this, rhs); // .text:0068A100 ; bool __thiscall QualifiedControl::IsConflicting(QualifiedControl *this, QualifiedControl *rhs) .text:0068A100 ?IsConflicting@QualifiedControl@@QBE_NABV1@@Z

        // QualifiedControl.IsExactlyEqual:
        public Byte IsExactlyEqual(QualifiedControl* rhs) => ((delegate* unmanaged[Thiscall]<ref QualifiedControl, QualifiedControl*, Byte>)0x0068B160)(ref this, rhs); // .text:0068A0D0 ; bool __thiscall QualifiedControl::IsExactlyEqual(QualifiedControl *this, QualifiedControl *rhs) .text:0068A0D0 ?IsExactlyEqual@QualifiedControl@@QBE_NABV1@@Z

        // QualifiedControl.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref QualifiedControl, Archive*, void>)0x006855E0)(ref this, io_archive); // .text:0068A3A0 ; void __thiscall QualifiedControl::Serialize(AC1Legacy::Vector3 *this, Archive *io_archive) .text:0068A3A0 ?Serialize@QualifiedControl@@QAEXAAVArchive@@@Z
    }




    public unsafe struct ControlSpecification {
        // Struct:
        public UInt32 m_dwKey;
        public UInt32 m_ofsKey; // union UInt32 m_idxDevice,m_eSubControl;
        public override string ToString() => $"m_dwKey:{m_dwKey:X8} m_ofsKey:{m_ofsKey:X8}";

        // Functions:

        // ControlSpecification.operator%:
        public UInt32 operator_modulus(UInt32 nBuckets) => ((delegate* unmanaged[Thiscall]<ref ControlSpecification, UInt32, UInt32>)0x00686FE0)(ref this, nBuckets); // .text:00685F90 ; unsigned int __thiscall ControlSpecification::operator%(ControlSpecification *this, unsigned int nBuckets) .text:00685F90 ??LControlSpecification@@QBEKK@Z

        // ControlSpecification.FromFileNode:
        // public Byte FromFileNode(PFileNode* i_pNode) => ((delegate* unmanaged[Thiscall]<ref ControlSpecification, PFileNode*, Byte>)0xDEADBEEF)(ref this, i_pNode); // .text:0068B2B0 ; bool __thiscall ControlSpecification::FromFileNode(ControlSpecification *this, PFileNode *i_pNode) .text:0068B2B0 ?FromFileNode@ControlSpecification@@QAE_NPBVPFileNode@@@Z

        // ControlSpecification.GetDIKName:
        public PStringBase<char>* GetDIKName(PStringBase<char>* result) => ((delegate* unmanaged[Thiscall]<ref ControlSpecification, PStringBase<char>*, PStringBase<char>*>)0x0068BCB0)(ref this, result); // .text:0068ACB0 ; PStringBase<char> *__thiscall ControlSpecification::GetDIKName(ControlSpecification *this, PStringBase<char> *result) .text:0068ACB0 ?GetDIKName@ControlSpecification@@QBE?AV?$PStringBase@D@@XZ

        // ControlSpecification.Serialize:
        public void Serialize(Archive* io_archive) => ((delegate* unmanaged[Thiscall]<ref ControlSpecification, Archive*, void>)0x0068B220)(ref this, io_archive); // .text:0068A190 ; void __thiscall ControlSpecification::Serialize(ControlSpecification *this, Archive *io_archive) .text:0068A190 ?Serialize@ControlSpecification@@QAEXAAVArchive@@@Z

        // ControlSpecification.ToFileNode:
        // public Byte ToFileNode(PFileNode* i_pNode, DeviceType i_dt) => ((delegate* unmanaged[Thiscall]<ref ControlSpecification, PFileNode*, DeviceType, Byte>)0xDEADBEEF)(ref this, i_pNode, i_dt); // .text:0068AB80 ; bool __thiscall ControlSpecification::ToFileNode(ControlSpecification *this, PFileNode *i_pNode, DeviceType i_dt) .text:0068AB80 ?ToFileNode@ControlSpecification@@QBE_NPAVPFileNode@@W4DeviceType@@@Z
    }



}