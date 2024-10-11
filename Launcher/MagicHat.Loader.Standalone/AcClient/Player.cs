using System;

namespace AcClient {
    public unsafe struct CPlayerSystem {
        // Struct:
        public ClientSystem a0;
        public IInputActionCallback a1;
        public QualityChangeHandler a2;
        public ObjectRangeHandler a3;
        public Turbine_RefCount m_cTurbineRefCount;
        public accountID account_;
        public ClientCharGenState* m_pCharGenState;
        public CPlayerModule playerModule;
        public UInt32 playerID;
        public Byte m_accountHasThroneofDestiny;
        public Double logOnRequestTime;
        public Double logOffRequestTime;
        public Double logOffTime;
        public Double deleteCharRequestTime;
        public Byte fReadyToEnterGame;
        public Byte awaitingLogOn;
        public Byte sendLoginCompletePending;
        public Byte initialLoginComplete;
        public Byte allContainedObjectsReceived;
        public Byte player_initialized;
        public Byte player_desc_received;
        public Double playerInitTime;
        public Byte loggingOff;
        public Byte logOffRequested;
        public Byte connectionLost;
        public Byte awaitingExpiration;
        public Double expirationTime;
        public UInt32 inventoryMask;
        public UInt32 clothingPriorityMask;
        public Byte teleportInProgress;
        public Single m_fLoad;
        public Byte m_layoutFromFile;
        public UInt32 lastFullyMergedSrcID;
        public UInt32 lastFullyMergedDstID;
        public CInvSlotModule m_invSlotModule;
        public UInt32 blockingID;
        public UInt32 blockedID;
        public UInt32 blockingDestID;
        public UInt32 blockedSpellTargetID;
        public UInt32 blockedSpellID;
        public UI_SLOT_SIDE blockedSide;
        public int unblockAttemptNum;
        public UInt32 mOpenContainerID;
        public NIList<UInt32> pending_components_list;
        public ComponentTracker* componentTracker;
        public _List<ObjectRangeInfo> m_objectRangeCheckList;
        public CContractTrackerTable m_contractTrackerTable;
        public override string ToString() => $"a0(ClientSystem):{a0}, a1(IInputActionCallback):{a1}, a2(QualityChangeHandler):{a2}, a3(ObjectRangeHandler):{a3}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, account_(accountID):{account_}, m_pCharGenState:->(ClientCharGenState*)0x{(int)m_pCharGenState:X8}, playerModule(CPlayerModule):{playerModule}, playerID:{playerID:X8}, m_accountHasThroneofDestiny:{m_accountHasThroneofDestiny:X2}, logOnRequestTime:{logOnRequestTime:n5}, logOffRequestTime:{logOffRequestTime:n5}, logOffTime:{logOffTime:n5}, deleteCharRequestTime:{deleteCharRequestTime:n5}, fReadyToEnterGame:{fReadyToEnterGame:X2}, awaitingLogOn:{awaitingLogOn:X2}, sendLoginCompletePending:{sendLoginCompletePending:X2}, initialLoginComplete:{initialLoginComplete:X2}, allContainedObjectsReceived:{allContainedObjectsReceived:X2}, player_initialized:{player_initialized:X2}, player_desc_received:{player_desc_received:X2}, playerInitTime:{playerInitTime:n5}, loggingOff:{loggingOff:X2}, logOffRequested:{logOffRequested:X2}, connectionLost:{connectionLost:X2}, awaitingExpiration:{awaitingExpiration:X2}, expirationTime:{expirationTime:n5}, inventoryMask:{inventoryMask:X8}, clothingPriorityMask:{clothingPriorityMask:X8}, teleportInProgress:{teleportInProgress:X2}, m_fLoad:{m_fLoad:n5}, m_layoutFromFile:{m_layoutFromFile:X2}, lastFullyMergedSrcID:{lastFullyMergedSrcID:X8}, lastFullyMergedDstID:{lastFullyMergedDstID:X8}, m_invSlotModule(CInvSlotModule):{m_invSlotModule}, blockingID:{blockingID:X8}, blockedID:{blockedID:X8}, blockingDestID:{blockingDestID:X8}, blockedSpellTargetID:{blockedSpellTargetID:X8}, blockedSpellID:{blockedSpellID:X8}, blockedSide(UI_SLOT_SIDE):{blockedSide}, unblockAttemptNum(int):{unblockAttemptNum}, mOpenContainerID:{mOpenContainerID:X8}, pending_components_list(NIList<UInt32>):{pending_components_list}, componentTracker:->(ComponentTracker*)0x{(int)componentTracker:X8}, m_objectRangeCheckList(List<ObjectRangeInfo>):{m_objectRangeCheckList}, m_contractTrackerTable(CContractTrackerTable):{m_contractTrackerTable}";

        // Functions:

        // CPlayerSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x005611E0)(ref this); // .text:00560470 ; void __thiscall CPlayerSystem::CPlayerSystem(CPlayerSystem *this) .text:00560470 ??0CPlayerSystem@@QAE@XZ

        // CPlayerSystem.AccountHasThroneOfDestiny:
        public Byte AccountHasThroneOfDestiny() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte>)0x0055E470)(ref this); // .text:0055D750 ; bool __thiscall CPlayerSystem::AccountHasThroneOfDestiny(CPlayerSystem *this) .text:0055D750 ?AccountHasThroneOfDestiny@CPlayerSystem@@QAE_NXZ

        // CPlayerSystem.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32>)0x0055F0D0)(ref this); // .text:0055E3B0 ; unsigned int __thiscall CPlayerSystem::AddRef(CPlayerSystem *this) .text:0055E3B0 ?AddRef@CPlayerSystem@@UBEKXZ

        // CPlayerSystem.AttemptSendLoginCompleteNotification:
        public void AttemptSendLoginCompleteNotification() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00563CC0)(ref this); // .text:00562F20 ; void __thiscall CPlayerSystem::AttemptSendLoginCompleteNotification(CPlayerSystem *this) .text:00562F20 ?AttemptSendLoginCompleteNotification@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.AutoSort:
        public Byte AutoSort(UInt32 _item, int _wield, int _quiet) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, int, int, Byte>)0x00561710)(ref this, _item, _wield, _quiet); // .text:005609A0 ; bool __thiscall CPlayerSystem::AutoSort(CPlayerSystem *this, unsigned int _item, int _wield, int _quiet) .text:005609A0 ?AutoSort@CPlayerSystem@@QAE_NKHH@Z

        // CPlayerSystem.AutoWear:
        public Byte AutoWear(UInt32 _item, int* _blockedBySelf, int _quiet) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, int*, int, Byte>)0x00560F30)(ref this, _item, _blockedBySelf, _quiet); // .text:005601C0 ; bool __thiscall CPlayerSystem::AutoWear(CPlayerSystem *this, unsigned int _item, int *_blockedBySelf, int _quiet) .text:005601C0 ?AutoWear@CPlayerSystem@@QAE_NKAAHH@Z

        // CPlayerSystem.AutoWearIsLegal:
        public Byte AutoWearIsLegal(UInt32 _item, int* _blockedBySelf, int _quiet) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, int*, int, Byte>)0x0055FCB0)(ref this, _item, _blockedBySelf, _quiet); // .text:0055EF40 ; bool __thiscall CPlayerSystem::AutoWearIsLegal(CPlayerSystem *this, unsigned int _item, int *_blockedBySelf, int _quiet) .text:0055EF40 ?AutoWearIsLegal@CPlayerSystem@@QAE_NKAAHH@Z

        // CPlayerSystem.AutoWield:
        public Byte AutoWield(UInt32 _item, UI_SLOT_SIDE _slotSide, int _quiet, int _unblock, int _autosortOnFail, int _trySecondChoiceSide) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, UI_SLOT_SIDE, int, int, int, int, Byte>)0x005617D0)(ref this, _item, _slotSide, _quiet, _unblock, _autosortOnFail, _trySecondChoiceSide); // .text:00560A60 ; bool __thiscall CPlayerSystem::AutoWield(CPlayerSystem *this, unsigned int _item, UI_SLOT_SIDE _slotSide, int _quiet, int _unblock, int _autosortOnFail, int _trySecondChoiceSide) .text:00560A60 ?AutoWield@CPlayerSystem@@QAE_NKW4UI_SLOT_SIDE@@HHHH@Z

        // CPlayerSystem.AutoWieldIsLegal:
        public Byte AutoWieldIsLegal(UInt32 _item, int _quiet) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, int, Byte>)0x0055FAD0)(ref this, _item, _quiet); // .text:0055ED60 ; bool __thiscall CPlayerSystem::AutoWieldIsLegal(CPlayerSystem *this, unsigned int _item, int _quiet) .text:0055ED60 ?AutoWieldIsLegal@CPlayerSystem@@QAE_NKH@Z

        // CPlayerSystem.Begin:
        public void Begin() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055E130)(ref this); // .text:0055D410 ; void __thiscall CPlayerSystem::Begin(CPlayerSystem *this) .text:0055D410 ?Begin@CPlayerSystem@@IAEXXZ

        // CPlayerSystem.CalculateObjectRangeChecks:
        public void CalculateObjectRangeChecks() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x005600D0)(ref this); // .text:0055F360 ; void __thiscall CPlayerSystem::CalculateObjectRangeChecks(CPlayerSystem *this) .text:0055F360 ?CalculateObjectRangeChecks@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.DeleteCharacter:
        public void DeleteCharacter(UInt32 i_iidAvatar) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x005605A0)(ref this, i_iidAvatar); // .text:0055F830 ; void __thiscall CPlayerSystem::DeleteCharacter(CPlayerSystem *this, unsigned int i_iidAvatar) .text:0055F830 ?DeleteCharacter@CPlayerSystem@@QAEXK@Z

        // CPlayerSystem.End:
        public void End() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00561430)(ref this); // .text:005606C0 ; void __thiscall CPlayerSystem::End(CPlayerSystem *this) .text:005606C0 ?End@CPlayerSystem@@IAEXXZ

        // CPlayerSystem.ExecuteLogOff:
        public void ExecuteLogOff() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055E4A0)(ref this); // .text:0055D780 ; void __thiscall CPlayerSystem::ExecuteLogOff(CPlayerSystem *this) .text:0055D780 ?ExecuteLogOff@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.Farther:
        public Byte Farther(Double dist_a, UInt32 id_a, Double dist_b, UInt32 id_b) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Double, UInt32, Double, UInt32, Byte>)0x0055E550)(ref this, dist_a, id_a, dist_b, id_b); // .text:0055D830 ; bool __thiscall CPlayerSystem::Farther(CPlayerSystem *this, long double dist_a, unsigned int id_a, long double dist_b, unsigned int id_b) .text:0055D830 ?Farther@CPlayerSystem@@QAE_NNKNK@Z

        // CPlayerSystem.GetCharGenState:
        public ClientCharGenState* GetCharGenState() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ClientCharGenState*>)0x0055E1E0)(ref this); // .text:0055D4C0 ; ClientCharGenState *__thiscall CPlayerSystem::GetCharGenState(CPlayerSystem *this) .text:0055D4C0 ?GetCharGenState@CPlayerSystem@@QAEAAVClientCharGenState@@XZ

        // CPlayerSystem.GetComponentTracker:
        public ComponentTracker* GetComponentTracker() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ComponentTracker*>)0x0055E220)(ref this); // .text:0055D500 ; ComponentTracker *__thiscall CPlayerSystem::GetComponentTracker(CPlayerSystem *this) .text:0055D500 ?GetComponentTracker@CPlayerSystem@@QAEPAVComponentTracker@@XZ

        // CPlayerSystem.GetPlayerSystem:
        public static CPlayerSystem* GetPlayerSystem() => ((delegate* unmanaged[Cdecl]<CPlayerSystem*>)0x0055E1D0)(); // .text:0055D4B0 ; CPlayerSystem *__cdecl CPlayerSystem::GetPlayerSystem() .text:0055D4B0 ?GetPlayerSystem@CPlayerSystem@@SAPAV1@XZ

        // CPlayerSystem.GetRadarRadius:
        public Single GetRadarRadius() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Single>)0x0055E5A0)(ref this); // .text:0055D880 ; float __thiscall CPlayerSystem::GetRadarRadius(CPlayerSystem *this) .text:0055D880 ?GetRadarRadius@CPlayerSystem@@QAEMXZ

        // CPlayerSystem.Handle_AccountBanned:
        public void Handle_AccountBanned(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void*, UInt32, void>)0x00563970)(ref this, buff, size); // .text:00562BD0 ; void __thiscall CPlayerSystem::Handle_AccountBanned(CPlayerSystem *this, void *buff, unsigned int size) .text:00562BD0 ?Handle_AccountBanned@CPlayerSystem@@QAEXPAXI@Z

        // CPlayerSystem.Handle_AccountBooted:
        public void Handle_AccountBooted(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void*, UInt32, void>)0x00563810)(ref this, buff, size); // .text:00562A70 ; void __thiscall CPlayerSystem::Handle_AccountBooted(CPlayerSystem *this, void *buff, unsigned int size) .text:00562A70 ?Handle_AccountBooted@CPlayerSystem@@QAEXPAXI@Z

        // CPlayerSystem.Handle_Admin__Environs:
        public UInt32 Handle_Admin__Environs(int environs_option) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, int, UInt32>)0x0055EB40)(ref this, environs_option); // .text:0055DE20 ; unsigned int __thiscall CPlayerSystem::Handle_Admin__Environs(CPlayerSystem *this, const int environs_option) .text:0055DE20 ?Handle_Admin__Environs@CPlayerSystem@@QAEKJ@Z

        // CPlayerSystem.Handle_AwaitingSubscriptionExpiration:
        public void Handle_AwaitingSubscriptionExpiration(UInt32 secondsRemaining) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x0055E380)(ref this, secondsRemaining); // .text:0055D660 ; void __thiscall CPlayerSystem::Handle_AwaitingSubscriptionExpiration(CPlayerSystem *this, unsigned int secondsRemaining) .text:0055D660 ?Handle_AwaitingSubscriptionExpiration@CPlayerSystem@@QAEXK@Z

        // CPlayerSystem.Handle_CharGenVerificationResponse:
        public void Handle_CharGenVerificationResponse(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void*, UInt32, void>)0x0055F620)(ref this, buff, size); // .text:0055E8B0 ; void __thiscall CPlayerSystem::Handle_CharGenVerificationResponse(CPlayerSystem *this, void *buff, unsigned int size) .text:0055E8B0 ?Handle_CharGenVerificationResponse@CPlayerSystem@@QAEXPAXI@Z

        // CPlayerSystem.Handle_CharacterDelete:
        public void Handle_CharacterDelete() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055E310)(ref this); // .text:0055D5F0 ; void __thiscall CPlayerSystem::Handle_CharacterDelete(CPlayerSystem *this) .text:0055D5F0 ?Handle_CharacterDelete@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.Handle_CharacterError:
        public void Handle_CharacterError(CharError _error) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, CharError, void>)0x0055E2F0)(ref this, _error); // .text:0055D5D0 ; void __thiscall CPlayerSystem::Handle_CharacterError(CPlayerSystem *this, charError _error) .text:0055D5D0 ?Handle_CharacterError@CPlayerSystem@@QAEXW4charError@@@Z

        // CPlayerSystem.Handle_Character__EnterGame_ServerReady:
        // public UInt32 Handle_Character__EnterGame_ServerReady() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32>)0xDEADBEEF)(ref this); // .text:0055E4F0 ; unsigned int __thiscall CPlayerSystem::Handle_Character__EnterGame_ServerReady(CPlayerSystem *this) .text:0055E4F0 ?Handle_Character__EnterGame_ServerReady@CPlayerSystem@@QAEKXZ

        // CPlayerSystem.Handle_Character__EnterGame_ServerReady:
        // (ERR) .text:0055F210 ; public: unsigned long __thiscall CPlayerSystem::Handle_Character__EnterGame_ServerReady(void) .text:0055F210 ?Handle_Character__EnterGame_ServerReady@CPlayerSystem@@QAEKXZ:

        // CPlayerSystem.Handle_Login__CharacterSet:
        public void Handle_Login__CharacterSet(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void*, UInt32, void>)0x00560440)(ref this, buff, size); // .text:0055F6D0 ; void __thiscall CPlayerSystem::Handle_Login__CharacterSet(CPlayerSystem *this, void *buff, unsigned int size) .text:0055F6D0 ?Handle_Login__CharacterSet@CPlayerSystem@@QAEXPAXI@Z

        // CPlayerSystem.Handle_PlayerDescription:
        public void Handle_PlayerDescription(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void*, UInt32, void>)0x00564440)(ref this, buff, size); // .text:005636A0 ; void __thiscall CPlayerSystem::Handle_PlayerDescription(CPlayerSystem *this, void *buff, unsigned int size) .text:005636A0 ?Handle_PlayerDescription@CPlayerSystem@@QAEXPAXI@Z

        // CPlayerSystem.InitializePlayer:
        public void InitializePlayer() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00564310)(ref this); // .text:00563570 ; void __thiscall CPlayerSystem::InitializePlayer(CPlayerSystem *this) .text:00563570 ?InitializePlayer@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.InqPlayerCoords:
        public Byte InqPlayerCoords(Double* x, Double* y) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Double*, Double*, Byte>)0x00560E00)(ref this, x, y); // .text:00560090 ; bool __thiscall CPlayerSystem::InqPlayerCoords(CPlayerSystem *this, long double *x, long double *y) .text:00560090 ?InqPlayerCoords@CPlayerSystem@@QAE_NAAN0@Z

        // CPlayerSystem.IsOlthoi:
        public static int IsOlthoi() => ((delegate* unmanaged[Cdecl]<int>)0x00560F80)(); // .text:00560210 ; int __cdecl CPlayerSystem::IsOlthoi() .text:00560210 ?IsOlthoi@CPlayerSystem@@SAHXZ

        // CPlayerSystem.IsOutside:
        public Byte IsOutside() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte>)0x0055E5C0)(ref this); // .text:0055D8A0 ; bool __thiscall CPlayerSystem::IsOutside(CPlayerSystem *this) .text:0055D8A0 ?IsOutside@CPlayerSystem@@QAE_NXZ

        // CPlayerSystem.LogOffCharacter:
        public void LogOffCharacter(Byte _immediate) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte, void>)0x005642C0)(ref this, _immediate); // .text:00563520 ; void __thiscall CPlayerSystem::LogOffCharacter(CPlayerSystem *this, bool _immediate) .text:00563520 ?LogOffCharacter@CPlayerSystem@@QAEX_N@Z

        // CPlayerSystem.LogOnCharacter:
        public Byte LogOnCharacter(UInt32 i_iidAvatar) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, Byte>)0x00560600)(ref this, i_iidAvatar); // .text:0055F890 ; bool __thiscall CPlayerSystem::LogOnCharacter(CPlayerSystem *this, unsigned int i_iidAvatar) .text:0055F890 ?LogOnCharacter@CPlayerSystem@@QAE_NK@Z

        // CPlayerSystem.ObjectIsWithinRadarRange:
        public Byte ObjectIsWithinRadarRange(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, Byte>)0x00560CE0)(ref this, _objectID); // .text:0055FF70 ; bool __thiscall CPlayerSystem::ObjectIsWithinRadarRange(CPlayerSystem *this, unsigned int _objectID) .text:0055FF70 ?ObjectIsWithinRadarRange@CPlayerSystem@@QAE_NK@Z

        // CPlayerSystem.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, InputEvent*, Byte>)0x00562600)(ref this, i_evt); // .text:00561890 ; bool __thiscall CPlayerSystem::OnAction(CPlayerSystem *this, InputEvent *i_evt) .text:00561890 ?OnAction@CPlayerSystem@@MAE_NABVInputEvent@@@Z

        // CPlayerSystem.OnBeginCharacterSession:
        public void OnBeginCharacterSession() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055F410)(ref this); // .text:0055E6F0 ; void __thiscall CPlayerSystem::OnBeginCharacterSession(CPlayerSystem *this) .text:0055E6F0 ?OnBeginCharacterSession@CPlayerSystem@@MAEXXZ

        // CPlayerSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00563610)(ref this); // .text:00562870 ; void __thiscall CPlayerSystem::OnEndCharacterSession(CPlayerSystem *this) .text:00562870 ?OnEndCharacterSession@CPlayerSystem@@MAEXXZ

        // CPlayerSystem.OnLoadChanged:
        public Byte OnLoadChanged() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte>)0x00560280)(ref this); // .text:0055F510 ; bool __thiscall CPlayerSystem::OnLoadChanged(CPlayerSystem *this) .text:0055F510 ?OnLoadChanged@CPlayerSystem@@QAE_NXZ

        // CPlayerSystem.OnObjectRangeExit:
        public void OnObjectRangeExit(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x005615E0)(ref this, _objectID); // .text:00560870 ; void __thiscall CPlayerSystem::OnObjectRangeExit(CPlayerSystem *this, unsigned int _objectID) .text:00560870 ?OnObjectRangeExit@CPlayerSystem@@UAEXK@Z

        // CPlayerSystem.OnQualityRemoved:
        public void OnQualityRemoved(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, CWeenieObject*, StatType, UInt32, void>)0x00561660)(ref this, cwobj, stype, senum); // .text:005608F0 ; void __thiscall CPlayerSystem::OnQualityRemoved(CPlayerSystem *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:005608F0 ?OnQualityRemoved@CPlayerSystem@@MAEXPAVCWeenieObject@@W4StatType@@K@Z

        // CPlayerSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055FA60)(ref this); // .text:0055ECF0 ; void __thiscall CPlayerSystem::OnShutdown(CPlayerSystem *this) .text:0055ECF0 ?OnShutdown@CPlayerSystem@@MAEXXZ

        // CPlayerSystem.PlaceInBackpack:
        public Byte PlaceInBackpack(UInt32 i_iidItem, Byte bPlaceInMainPack) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, Byte, Byte>)0x0055E5E0)(ref this, i_iidItem, bPlaceInMainPack); // .text:0055D8C0 ; bool __thiscall CPlayerSystem::PlaceInBackpack(CPlayerSystem *this, unsigned int i_iidItem, bool bPlaceInMainPack) .text:0055D8C0 ?PlaceInBackpack@CPlayerSystem@@QAE_NK_N@Z

        // CPlayerSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x0055F0E0)(ref this, result, i_rcInterface, o_ppvInterface); // .text:0055E3C0 ; TResult *__thiscall CPlayerSystem::QueryInterface(CPlayerSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0055E3C0 ?QueryInterface@CPlayerSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // CPlayerSystem.RecvNotice_EnchantmentsChanged:
        public void RecvNotice_EnchantmentsChanged() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x005615D0)(ref this); // .text:00560860 ; void __thiscall CPlayerSystem::RecvNotice_EnchantmentsChanged(CPlayerSystem *this) .text:00560860 ?RecvNotice_EnchantmentsChanged@CPlayerSystem@@UAEXXZ

        // CPlayerSystem.RecvNotice_ItemAttributesChanged:
        public void RecvNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, UInt32, void>)0x005601D0)(ref this, i_target, i_attrib); // .text:0055F460 ; void __thiscall CPlayerSystem::RecvNotice_ItemAttributesChanged(CPlayerSystem *this, unsigned int i_target, unsigned int i_attrib) .text:0055F460 ?RecvNotice_ItemAttributesChanged@CPlayerSystem@@UAEXKK@Z

        // CPlayerSystem.RecvNotice_NewParentContainer:
        public void RecvNotice_NewParentContainer(UInt32 i_newContainerID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x0055E270)(ref this, i_newContainerID); // .text:0055D550 ; void __thiscall CPlayerSystem::RecvNotice_NewParentContainer(CPlayerSystem *this, unsigned int i_newContainerID) .text:0055D550 ?RecvNotice_NewParentContainer@CPlayerSystem@@UAEXK@Z

        // CPlayerSystem.RecvNotice_ServerSaysAttemptFailed:
        public void RecvNotice_ServerSaysAttemptFailed(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x0055F1B0)(ref this, _itemID); // .text:0055E490 ; void __thiscall CPlayerSystem::RecvNotice_ServerSaysAttemptFailed(CPlayerSystem *this, unsigned int _itemID) .text:0055E490 ?RecvNotice_ServerSaysAttemptFailed@CPlayerSystem@@UAEXK@Z

        // CPlayerSystem.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x00564000)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:00563260 ; void __thiscall CPlayerSystem::RecvNotice_ServerSaysMoveItem(CPlayerSystem *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:00563260 ?RecvNotice_ServerSaysMoveItem@CPlayerSystem@@UAEXKKKKKHKK@Z

        // CPlayerSystem.RecvNotice_SetSelectedItem:
        public void RecvNotice_SetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, UInt32, void>)0x00561490)(ref this, _oldSelectedID, _selectedID); // .text:00560720 ; void __thiscall CPlayerSystem::RecvNotice_SetSelectedItem(CPlayerSystem *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:00560720 ?RecvNotice_SetSelectedItem@CPlayerSystem@@UAEXKK@Z

        // CPlayerSystem.RegisterInputMaps:
        public void RegisterInputMaps() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055EAA0)(ref this); // .text:0055DD80 ; void __thiscall CPlayerSystem::RegisterInputMaps(CPlayerSystem *this) .text:0055DD80 ?RegisterInputMaps@CPlayerSystem@@IAEXXZ

        // CPlayerSystem.RegisterObjectRangeHandler:
        public void RegisterObjectRangeHandler(ObjectRangeHandler* _handler, UInt32 _objectID, Double _range, Byte _useRadii, Byte _ignoreZDelta, Double _timeInterval, Double _timeOut) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ObjectRangeHandler*, UInt32, Double, Byte, Byte, Double, Double, void>)0x00561040)(ref this, _handler, _objectID, _range, _useRadii, _ignoreZDelta, _timeInterval, _timeOut); // .text:005602D0 ; void __thiscall CPlayerSystem::RegisterObjectRangeHandler(CPlayerSystem *this, ObjectRangeHandler *_handler, unsigned int _objectID, long double _range, bool _useRadii, bool _ignoreZDelta, long double _timeInterval, long double _timeOut) .text:005602D0 ?RegisterObjectRangeHandler@CPlayerSystem@@QAEXPAVObjectRangeHandler@@KN_N1NN@Z

        // CPlayerSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32>)0x00561400)(ref this); // .text:00560690 ; unsigned int __thiscall CPlayerSystem::Release(CPlayerSystem *this) .text:00560690 ?Release@CPlayerSystem@@UBEKXZ

        // CPlayerSystem.RequestLogOff:
        public void RequestLogOff() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00563B70)(ref this); // .text:00562DD0 ; void __thiscall CPlayerSystem::RequestLogOff(CPlayerSystem *this) .text:00562DD0 ?RequestLogOff@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.ResetUnblocking:
        public void ResetUnblocking() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055E660)(ref this); // .text:0055D940 ; void __thiscall CPlayerSystem::ResetUnblocking(CPlayerSystem *this) .text:0055D940 ?ResetUnblocking@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.RestoreCharacter:
        public void RestoreCharacter(UInt32 i_iidAvatar) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x0055E480)(ref this, i_iidAvatar); // .text:0055D760 ; void __thiscall CPlayerSystem::RestoreCharacter(CPlayerSystem *this, unsigned int i_iidAvatar) .text:0055D760 ?RestoreCharacter@CPlayerSystem@@QAEXK@Z

        // CPlayerSystem.SelectNext:
        public void SelectNext(Byte _closer, Byte _extreme, UI_SELECTION_TYPE sel_type, Byte _ignore_wielded) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte, Byte, UI_SELECTION_TYPE, Byte, void>)0x00560710)(ref this, _closer, _extreme, sel_type, _ignore_wielded); // .text:0055F9A0 ; void __thiscall CPlayerSystem::SelectNext(CPlayerSystem *this, bool _closer, bool _extreme, UI_SELECTION_TYPE sel_type, bool _ignore_wielded) .text:0055F9A0 ?SelectNext@CPlayerSystem@@QAEX_N0W4UI_SELECTION_TYPE@@0@Z

        // CPlayerSystem.SendLoginCompleteNotification:
        public void SendLoginCompleteNotification() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00563C30)(ref this); // .text:00562E90 ; void __thiscall CPlayerSystem::SendLoginCompleteNotification(CPlayerSystem *this) .text:00562E90 ?SendLoginCompleteNotification@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.SendQueryPluginData:
        public void SendQueryPluginData(UInt32 context) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, void>)0x00561670)(ref this, context); // .text:00560900 ; void __thiscall CPlayerSystem::SendQueryPluginData(CPlayerSystem *this, unsigned int context) .text:00560900 ?SendQueryPluginData@CPlayerSystem@@IAEXK@Z

        // CPlayerSystem.SetDisplayContractTracker:
        public void SetDisplayContractTracker(CContractTracker contractTracker) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, CContractTracker, void>)0x0055EB30)(ref this, contractTracker); // .text:0055DE10 ; void __thiscall CPlayerSystem::SetDisplayContractTracker(CPlayerSystem *this, CContractTracker contractTracker) .text:0055DE10 ?SetDisplayContractTracker@CPlayerSystem@@QAEXVCContractTracker@@@Z

        // CPlayerSystem.SetLogOffStarted:
        public void SetLogOffStarted() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x0055E4F0)(ref this); // .text:0055D7D0 ; void __thiscall CPlayerSystem::SetLogOffStarted(CPlayerSystem *this) .text:0055D7D0 ?SetLogOffStarted@CPlayerSystem@@QAEXXZ

        // CPlayerSystem.SetTeleportInProgress:
        public void SetTeleportInProgress(Byte bInProgress) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, Byte, void>)0x0055E2A0)(ref this, bInProgress); // .text:0055D580 ; void __thiscall CPlayerSystem::SetTeleportInProgress(CPlayerSystem *this, bool bInProgress) .text:0055D580 ?SetTeleportInProgress@CPlayerSystem@@QAEX_N@Z

        // CPlayerSystem.UnregisterAllObjectRangeHandlers:
        public void UnregisterAllObjectRangeHandlers(ObjectRangeHandler* _handler) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ObjectRangeHandler*, void>)0x0055F930)(ref this, _handler); // .text:0055EBC0 ; void __thiscall CPlayerSystem::UnregisterAllObjectRangeHandlers(CPlayerSystem *this, ObjectRangeHandler *_handler) .text:0055EBC0 ?UnregisterAllObjectRangeHandlers@CPlayerSystem@@QAEXPAVObjectRangeHandler@@@Z

        // CPlayerSystem.UnregisterObjectRangeHandler:
        public void UnregisterObjectRangeHandler(ObjectRangeHandler* _handler, UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ObjectRangeHandler*, UInt32, void>)0x0055F900)(ref this, _handler, _objectID); // .text:0055EB90 ; void __thiscall CPlayerSystem::UnregisterObjectRangeHandler(CPlayerSystem *this, ObjectRangeHandler *_handler, unsigned int _objectID) .text:0055EB90 ?UnregisterObjectRangeHandler@CPlayerSystem@@QAEXPAVObjectRangeHandler@@K@Z

        // CPlayerSystem.UpdateContractTracker:
        public void UpdateContractTracker(CContractTracker contractTracker, int deleteContract) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, CContractTracker, int, void>)0x0055FF00)(ref this, contractTracker, deleteContract); // .text:0055F190 ; void __thiscall CPlayerSystem::UpdateContractTracker(CPlayerSystem *this, CContractTracker contractTracker, int deleteContract) .text:0055F190 ?UpdateContractTracker@CPlayerSystem@@QAEXVCContractTracker@@H@Z

        // CPlayerSystem.UpdateContractTrackerTable:
        public void UpdateContractTrackerTable(CContractTrackerTable* contractTrackerTable) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, CContractTrackerTable*, void>)0x0055FE30)(ref this, contractTrackerTable); // .text:0055F0C0 ; void __thiscall CPlayerSystem::UpdateContractTrackerTable(CPlayerSystem *this, CContractTrackerTable *contractTrackerTable) .text:0055F0C0 ?UpdateContractTrackerTable@CPlayerSystem@@QAEXABVCContractTrackerTable@@@Z

        // CPlayerSystem.UpdateSpellComponent:
        public ComponentTrackerUpdate UpdateSpellComponent(ACCWeenieObject* _weenObj, int _updateUI) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, ACCWeenieObject*, int, ComponentTrackerUpdate>)0x0055F870)(ref this, _weenObj, _updateUI); // .text:0055EB00 ; ComponentTrackerUpdate __thiscall CPlayerSystem::UpdateSpellComponent(CPlayerSystem *this, ACCWeenieObject *_weenObj, int _updateUI) .text:0055EB00 ?UpdateSpellComponent@CPlayerSystem@@QAE?AW4ComponentTrackerUpdate@@PAVACCWeenieObject@@H@Z

        // CPlayerSystem.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, void>)0x00563EB0)(ref this); // .text:00563110 ; void __thiscall CPlayerSystem::UseTime(CPlayerSystem *this) .text:00563110 ?UseTime@CPlayerSystem@@MAEXXZ

        // CPlayerSystem.UsingItem:
        public Byte UsingItem(UInt32 _itemID, int _useable, int _forceUse) => ((delegate* unmanaged[Thiscall]<ref CPlayerSystem, UInt32, int, int, Byte>)0x00563D10)(ref this, _itemID, _useable, _forceUse); // .text:00562F70 ; bool __thiscall CPlayerSystem::UsingItem(CPlayerSystem *this, unsigned int _itemID, int _useable, int _forceUse) .text:00562F70 ?UsingItem@CPlayerSystem@@QAE_NKHH@Z

        // Globals:
        public static CPlayerSystem** s_pPlayerSystem = (CPlayerSystem**)0x0087119C; // .data:0087018C ; CPlayerSystem *CPlayerSystem::s_pPlayerSystem .data:0087018C ?s_pPlayerSystem@CPlayerSystem@@1PAV1@A
    }


    public unsafe struct CPlayerModule {
        // Struct:
        public Interface _Interface;
        public PlayerModule PlayerModule;
        public Byte m_bDirty;
        public Double m_timeFirstDirtied;
        public override string ToString() => $"Interface(Interface):{_Interface}, PlayerModule(PlayerModule):{PlayerModule}, m_bDirty:{m_bDirty:X2}, m_timeFirstDirtied:{m_timeFirstDirtied:n5}";


        // Functions:

        // CPlayerModule.OnChanged:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,BaseProperty*,UInt32> OnChanged = (delegate* unmanaged[Thiscall]<CPlayerModule*,BaseProperty*,UInt32>)0xDEADBEEF; // .text:0059A890 ; void __thiscall CPlayerModule::OnChanged(CPlayerModule *this, BaseProperty *i_prop, UInt32 i_nUserData) .text:0059A890 ?OnChanged@CPlayerModule@@MAEXABVBaseProperty@@K@Z

        // CPlayerModule.OnChanged:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,PlayerOption> OnChanged = (delegate* unmanaged[Thiscall]<CPlayerModule*,PlayerOption>)0xDEADBEEF; // .text:0059A8E0 ; void __thiscall CPlayerModule::OnChanged(CPlayerModule *this, PlayerOption i_po) .text:0059A8E0 ?OnChanged@CPlayerModule@@MAEXW4PlayerOption@@@Z

        // CPlayerModule.__Dtor:
        public static delegate* unmanaged[Thiscall]<CPlayerModule*> __Dtor = (delegate* unmanaged[Thiscall]<CPlayerModule*>)0x0059B5E0; // .text:0059A5E0 ; void __thiscall CPlayerModule::~CPlayerModule(CPlayerModule *this) .text:0059A5E0 ??1CPlayerModule@@UAE@XZ

        // CPlayerModule.SaveToServer:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,Byte> SaveToServer = (delegate* unmanaged[Thiscall]<CPlayerModule*,Byte>)0xDEADBEEF; // .text:0059A660 ; void __thiscall CPlayerModule::SaveToServer(CPlayerModule *this, bool i_bForceUpdate) .text:0059A660 ?SaveToServer@CPlayerModule@@QAEX_N@Z

        // CPlayerModule.__Ctor:
        public static delegate* unmanaged[Thiscall]<CPlayerModule*> __Ctor = (delegate* unmanaged[Thiscall]<CPlayerModule*>)0x0059B760; // .text:0059A750 ; void __thiscall CPlayerModule::CPlayerModule(CPlayerModule *this) .text:0059A750 ??0CPlayerModule@@QAE@XZ

        // CPlayerModule.__scaDelDtor:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<CPlayerModule*,UInt32, void*>)0xDEADBEEF; // .text:0059A790 ; void *__thiscall CPlayerModule::`scalar deleting destructor'(CPlayerModule *this, UInt32) .text:0059A790 ??_GCPlayerModule@@UAEPAXI@Z

        // CPlayerModule.QueryInterface:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,TResult*,Turbine_GUID*,void**, TResult*> QueryInterface = (delegate* unmanaged[Thiscall]<CPlayerModule*,TResult*,Turbine_GUID*,void**, TResult*>)0xDEADBEEF; // .text:0059A7D0 ; TResult *__thiscall CPlayerModule::QueryInterface(CPlayerModule *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0059A7D0 ?QueryInterface@CPlayerModule@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // CPlayerModule.IsAutoSaveOption:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*,PlayerOption, Byte> IsAutoSaveOption = (delegate* unmanaged[Thiscall]<CPlayerModule*,PlayerOption, Byte>)0xDEADBEEF; // .text:0059A600 ; bool __thiscall CPlayerModule::IsAutoSaveOption(CPlayerModule *this, PlayerOption i_po) .text:0059A600 ?IsAutoSaveOption@CPlayerModule@@IAE_NW4PlayerOption@@@Z

        // CPlayerModule.OnInitialize:
        public static delegate* unmanaged[Thiscall]<CPlayerModule*> OnInitialize = (delegate* unmanaged[Thiscall]<CPlayerModule*>)0x0059B6A0; // .text:0059A690 ; void __thiscall CPlayerModule::OnInitialize(CPlayerModule *this) .text:0059A690 ?OnInitialize@CPlayerModule@@QAEXXZ

        // CPlayerModule.UseTime:
        // public static delegate* unmanaged[Thiscall]<CPlayerModule*> UseTime = (delegate* unmanaged[Thiscall]<CPlayerModule*>)0xDEADBEEF; // .text:0059A710 ; void __thiscall CPlayerModule::UseTime(CPlayerModule *this) .text:0059A710 ?UseTime@CPlayerModule@@QAEXXZ
    }



    public unsafe struct PlayerModule {
        // Struct:
        public PackObj PackObj;
        public ShortCutManager* shortcuts_;
        public PackableList<UInt32> favorite_spells_0;
        public PackableList<UInt32> favorite_spells_1;
        public PackableList<UInt32> favorite_spells_2;
        public PackableList<UInt32> favorite_spells_3;
        public PackableList<UInt32> favorite_spells_4;
        public PackableList<UInt32> favorite_spells_5;
        public PackableList<UInt32> favorite_spells_6;
        public PackableList<UInt32> favorite_spells_7;
        public PackableHashTable<UInt32, UInt32>* desired_comps_;
        public UInt32 options_;
        public UInt32 options2_;
        public UInt32 spell_filters_;
        public GenericQualitiesData* m_pPlayerOptionsData;
        public PackObjPropertyCollection m_colGameplayOptions;
        public AC1Legacy.PStringBase<Char> m_TimeStampFormat;
        public override string ToString() => $"PackObj(PackObj):{PackObj}, shortcuts_:->(ShortCutManager*)0x{(Int32)shortcuts_:X8}, favorite_spells_0:({favorite_spells_0}), favorite_spells_1:({favorite_spells_1}), favorite_spells_2:({favorite_spells_2}), favorite_spells_3:({favorite_spells_3}), favorite_spells_4:({favorite_spells_4}), favorite_spells_5:({favorite_spells_5}), favorite_spells_6:({favorite_spells_6}), favorite_spells_7:({favorite_spells_7}), desired_comps_:->(PackableHashTable<UInt32,UInt32>*)0x{(Int32)desired_comps_:X8}, options_:{options_:X8}, options2_:{options2_:X8}, spell_filters_:{spell_filters_:X8}, m_pPlayerOptionsData:->(GenericQualitiesData*)0x{(Int32)m_pPlayerOptionsData:X8}, m_colGameplayOptions(PackObjPropertyCollection):{m_colGameplayOptions}, m_TimeStampFormat:{m_TimeStampFormat}";


        // Functions:

        // PlayerModule.CoordinatesOnRadar:
        public Byte CoordinatesOnRadar() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D40C0)(ref this); // .text:005D30C0 ; bool __thiscall PlayerModule::CoordinatesOnRadar(PlayerModule *this) .text:005D30C0 ?CoordinatesOnRadar@PlayerModule@@QBE_NXZ

        // PlayerModule.SetLockUI:
        public void SetLockUI(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4340)(ref this, on); // .text:005D3340 ; void __thiscall PlayerModule::SetLockUI(PlayerModule *this, const bool on) .text:005D3340 ?SetLockUI@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDesiredCompLevel:
        public Byte SetDesiredCompLevel(UInt32 wcid, int amount) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, int, Byte>)0x005D5A90)(ref this, wcid, amount); // .text:005D4940 ; bool __thiscall PlayerModule::SetDesiredCompLevel(PlayerModule *this, IDClass<_tagDataID,32,0> wcid, const int amount) .text:005D4940 ?SetDesiredCompLevel@PlayerModule@@QAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@J@Z

        // PlayerModule.InqChatWindowOption:
        public Byte InqChatWindowOption(UInt32 i_nWhichWindow, UInt32 i_propName, BaseProperty* o_baseProp) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, UInt32, BaseProperty*, Byte>)0x005D6690)(ref this, i_nWhichWindow, i_propName, o_baseProp); // .text:005D5540 ; bool __thiscall PlayerModule::InqChatWindowOption(PlayerModule *this, unsigned int i_nWhichWindow, unsigned int i_propName, BaseProperty *o_baseProp) .text:005D5540 ?InqChatWindowOption@PlayerModule@@QAE_NKKAAVBaseProperty@@@Z

        // PlayerModule.LeadMissileTargets:
        public Byte LeadMissileTargets() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4420)(ref this); // .text:005D3420 ; bool __thiscall PlayerModule::LeadMissileTargets(PlayerModule *this) .text:005D3420 ?LeadMissileTargets@PlayerModule@@QBE_NXZ

        // PlayerModule.SetHearGeneralChat:
        public void SetHearGeneralChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D45C0)(ref this, on); // .text:005D35C0 ; void __thiscall PlayerModule::SetHearGeneralChat(PlayerModule *this, const bool on) .text:005D35C0 ?SetHearGeneralChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.AddSpellFavorite:
        public void AddSpellFavorite(UInt32 spid, int index, int list) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, int, int, void>)0x005D5460)(ref this, spid, index, list); // .text:005D43E0 ; void __thiscall PlayerModule::AddSpellFavorite(PlayerModule *this, const unsigned int spid, const int index, const int list) .text:005D43E0 ?AddSpellFavorite@PlayerModule@@QAEXKJJ@Z

        // PlayerModule.SetChatWindowOption:
        public Byte SetChatWindowOption(UInt32 i_nWhichWindow, BaseProperty* i_prop) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, BaseProperty*, Byte>)0x005D66C0)(ref this, i_nWhichWindow, i_prop); // .text:005D5570 ; bool __thiscall PlayerModule::SetChatWindowOption(PlayerModule *this, unsigned int i_nWhichWindow, BaseProperty *i_prop) .text:005D5570 ?SetChatWindowOption@PlayerModule@@QAE_NKABVBaseProperty@@@Z

        // PlayerModule.AllowGive:
        public Byte AllowGive() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3A20)(ref this); // .text:005D2A20 ; bool __thiscall PlayerModule::AllowGive(PlayerModule *this) .text:005D2A20 ?AllowGive@PlayerModule@@QBE_NXZ

        // PlayerModule.SetPersistentAtDay:
        public void SetPersistentAtDay(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3C30)(ref this, on); // .text:005D2C30 ; void __thiscall PlayerModule::SetPersistentAtDay(PlayerModule *this, const bool on) .text:005D2C30 ?SetPersistentAtDay@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetAllowGive:
        public void SetAllowGive(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3C70)(ref this, on); // .text:005D2C70 ; void __thiscall PlayerModule::SetAllowGive(PlayerModule *this, const bool on) .text:005D2C70 ?SetAllowGive@PlayerModule@@QAEX_N@Z

        // PlayerModule.HearGeneralChat:
        public Byte HearGeneralChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D45B0)(ref this); // .text:005D35B0 ; bool __thiscall PlayerModule::HearGeneralChat(PlayerModule *this) .text:005D35B0 ?HearGeneralChat@PlayerModule@@QBE_NXZ

        // PlayerModule.GetDesiredCompHashEnd:
        public PackableHashIterator<UInt32, UInt32>* GetDesiredCompHashEnd(PackableHashIterator<UInt32, UInt32>* result) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, PackableHashIterator<UInt32, UInt32>*, PackableHashIterator<UInt32, UInt32>*>)0x005D54D0)(ref this, result); // .text:005D4450 ; PackableHashIterator<IDClass<_tagDataID,32,0>,long> *__thiscall PlayerModule::GetDesiredCompHashEnd(PlayerModule *this, PackableHashIterator<IDClass<_tagDataID,32,0>,long> *result) .text:005D4450 ?GetDesiredCompHashEnd@PlayerModule@@QAE?AV?$PackableHashIterator@V?$IDClass@U_tagDataID@@$0CA@$0A@@@J@@XZ

        // PlayerModule.SetViewCombatTarget:
        public void SetViewCombatTarget(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3CC0)(ref this, on); // .text:005D2CC0 ; void __thiscall PlayerModule::SetViewCombatTarget(PlayerModule *this, const bool on) .text:005D2CC0 ?SetViewCombatTarget@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetUseChargeAttack:
        public void SetUseChargeAttack(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4260)(ref this, on); // .text:005D3260 ; void __thiscall PlayerModule::SetUseChargeAttack(PlayerModule *this, const bool on) .text:005D3260 ?SetUseChargeAttack@PlayerModule@@QAEX_N@Z

        // PlayerModule.AddShortCut:
        public Byte AddShortCut(ShortCutData* scData) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, ShortCutData*, Byte>)0x005D39A0)(ref this, scData); // .text:005D29A0 ; bool __thiscall PlayerModule::AddShortCut(PlayerModule *this, ShortCutData *scData) .text:005D29A0 ?AddShortCut@PlayerModule@@QAE_NABVShortCutData@@@Z

        // PlayerModule.VividTargetingIndicator:
        public Byte VividTargetingIndicator() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3EE0)(ref this); // .text:005D2EE0 ; bool __thiscall PlayerModule::VividTargetingIndicator(PlayerModule *this) .text:005D2EE0 ?VividTargetingIndicator@PlayerModule@@QBE_NXZ

        // PlayerModule.SetShowCloak:
        public void SetShowCloak(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D42F0)(ref this, on); // .text:005D32F0 ; void __thiscall PlayerModule::SetShowCloak(PlayerModule *this, const bool on) .text:005D32F0 ?SetShowCloak@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisplayChessRank:
        public Byte DisplayChessRank() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4870)(ref this); // .text:005D3820 ; bool __thiscall PlayerModule::DisplayChessRank(PlayerModule *this) .text:005D3820 ?DisplayChessRank@PlayerModule@@QBE_NXZ

        // PlayerModule.SetDisplayNumberDeaths:
        public void SetDisplayNumberDeaths(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4920)(ref this, on); // .text:005D38D0 ; void __thiscall PlayerModule::SetDisplayNumberDeaths(PlayerModule *this, const bool on) .text:005D38D0 ?SetDisplayNumberDeaths@PlayerModule@@QAEX_N@Z

        // PlayerModule.RemoveShortCut:
        public void RemoveShortCut(int index) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, int, void>)0x005D39E0)(ref this, index); // .text:005D29E0 ; void __thiscall PlayerModule::RemoveShortCut(PlayerModule *this, const int index) .text:005D29E0 ?RemoveShortCut@PlayerModule@@QAEXJ@Z

        // PlayerModule.SetToggleRun:
        public void SetToggleRun(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3DB0)(ref this, on); // .text:005D2DB0 ; void __thiscall PlayerModule::SetToggleRun(PlayerModule *this, const bool on) .text:005D2DB0 ?SetToggleRun@PlayerModule@@QAEX_N@Z

        // PlayerModule.StayInChatMode:
        public Byte StayInChatMode() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3DF0)(ref this); // .text:005D2DF0 ; bool __thiscall PlayerModule::StayInChatMode(PlayerModule *this) .text:005D2DF0 ?StayInChatMode@PlayerModule@@QBE_NXZ

        // PlayerModule.FellowshipShareXP:
        public Byte FellowshipShareXP() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3F30)(ref this); // .text:005D2F30 ; bool __thiscall PlayerModule::FellowshipShareXP(PlayerModule *this) .text:005D2F30 ?FellowshipShareXP@PlayerModule@@QBE_NXZ

        // PlayerModule.SetDisableHouseRestrictionEffects:
        public void SetDisableHouseRestrictionEffects(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4170)(ref this, on); // .text:005D3170 ; void __thiscall PlayerModule::SetDisableHouseRestrictionEffects(PlayerModule *this, const bool on) .text:005D3170 ?SetDisableHouseRestrictionEffects@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetHearTradeChat:
        public void SetHearTradeChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4610)(ref this, on); // .text:005D3610 ; void __thiscall PlayerModule::SetHearTradeChat(PlayerModule *this, const bool on) .text:005D3610 ?SetHearTradeChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetIgnoreFellowshipRequests:
        public void SetIgnoreFellowshipRequests(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3B40)(ref this, on); // .text:005D2B40 ; void __thiscall PlayerModule::SetIgnoreFellowshipRequests(PlayerModule *this, const bool on) .text:005D2B40 ?SetIgnoreFellowshipRequests@PlayerModule@@QAEX_N@Z

        // PlayerModule.FilterLanguage:
        public Byte FilterLanguage() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D49B0)(ref this); // .text:005D3960 ; bool __thiscall PlayerModule::FilterLanguage(PlayerModule *this) .text:005D3960 ?FilterLanguage@PlayerModule@@QBE_NXZ

        // PlayerModule.GetChatOptionStructure:
        public BaseProperty* GetChatOptionStructure(UInt32 i_nWhichWindow) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, BaseProperty*>)0x005D6450)(ref this, i_nWhichWindow); // .text:005D5300 ; BaseProperty *__thiscall PlayerModule::GetChatOptionStructure(PlayerModule *this, unsigned int i_nWhichWindow) .text:005D5300 ?GetChatOptionStructure@PlayerModule@@IAEPAVBaseProperty@@K@Z

        // PlayerModule.SetFellowshipShareLoot:
        public void SetFellowshipShareLoot(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3FE0)(ref this, on); // .text:005D2FE0 ; void __thiscall PlayerModule::SetFellowshipShareLoot(PlayerModule *this, const bool on) .text:005D2FE0 ?SetFellowshipShareLoot@PlayerModule@@QAEX_N@Z

        // PlayerModule.ShowHelm:
        public Byte ShowHelm() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D42A0)(ref this); // .text:005D32A0 ; bool __thiscall PlayerModule::ShowHelm(PlayerModule *this) .text:005D32A0 ?ShowHelm@PlayerModule@@QBE_NXZ

        // PlayerModule.SetHearAllegianceChat:
        public void SetHearAllegianceChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4570)(ref this, on); // .text:005D3570 ; void __thiscall PlayerModule::SetHearAllegianceChat(PlayerModule *this, const bool on) .text:005D3570 ?SetHearAllegianceChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetOption:
        public void SetOption(PlayerOption po, Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, PlayerOption, Byte, void>)0x005D4F20)(ref this, po, on); // .text:005D3EB0 ; void __thiscall PlayerModule::SetOption(PlayerModule *this, PlayerOption po, bool on) .text:005D3EB0 ?SetOption@PlayerModule@@QAEXW4PlayerOption@@_N@Z

        // PlayerModule.HearRoleplayChat:
        public Byte HearRoleplayChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D46A0)(ref this); // .text:005D36A0 ; bool __thiscall PlayerModule::HearRoleplayChat(PlayerModule *this) .text:005D36A0 ?HearRoleplayChat@PlayerModule@@QBE_NXZ

        // PlayerModule.ToggleRun:
        public Byte ToggleRun() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3DA0)(ref this); // .text:005D2DA0 ; bool __thiscall PlayerModule::ToggleRun(PlayerModule *this) .text:005D2DA0 ?ToggleRun@PlayerModule@@QBE_NXZ

        // PlayerModule.SetAutoTarget:
        public void SetAutoTarget(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3EA0)(ref this, on); // .text:005D2EA0 ; void __thiscall PlayerModule::SetAutoTarget(PlayerModule *this, const bool on) .text:005D2EA0 ?SetAutoTarget@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetShowHelm:
        public void SetShowHelm(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D42B0)(ref this, on); // .text:005D32B0 ; void __thiscall PlayerModule::SetShowHelm(PlayerModule *this, const bool on) .text:005D32B0 ?SetShowHelm@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetAppearOffline:
        public void SetAppearOffline(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4790)(ref this, on); // .text:005D3740 ; void __thiscall PlayerModule::SetAppearOffline(PlayerModule *this, const bool on) .text:005D3740 ?SetAppearOffline@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisplayNumberDeaths:
        public Byte DisplayNumberDeaths() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4910)(ref this); // .text:005D38C0 ; bool __thiscall PlayerModule::DisplayNumberDeaths(PlayerModule *this) .text:005D38C0 ?DisplayNumberDeaths@PlayerModule@@QBE_NXZ

        // PlayerModule.SetFellowshipAutoAcceptRequests:
        public void SetFellowshipAutoAcceptRequests(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4030)(ref this, on); // .text:005D3030 ; void __thiscall PlayerModule::SetFellowshipAutoAcceptRequests(PlayerModule *this, const bool on) .text:005D3030 ?SetFellowshipAutoAcceptRequests@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisplayAllegianceLogonNotifications:
        public void SetDisplayAllegianceLogonNotifications(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4210)(ref this, on); // .text:005D3210 ; void __thiscall PlayerModule::SetDisplayAllegianceLogonNotifications(PlayerModule *this, const bool on) .text:005D3210 ?SetDisplayAllegianceLogonNotifications@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetHearLFGChat:
        public void SetHearLFGChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4660)(ref this, on); // .text:005D3660 ; void __thiscall PlayerModule::SetHearLFGChat(PlayerModule *this, const bool on) .text:005D3660 ?SetHearLFGChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetMainPackPreferred:
        public void SetMainPackPreferred(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4AB0)(ref this, on); // .text:005D3A60 ; void __thiscall PlayerModule::SetMainPackPreferred(PlayerModule *this, const bool on) .text:005D3A60 ?SetMainPackPreferred@PlayerModule@@QAEX_N@Z

        // PlayerModule.AutoTarget:
        public Byte AutoTarget() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3E90)(ref this); // .text:005D2E90 ; bool __thiscall PlayerModule::AutoTarget(PlayerModule *this) .text:005D2E90 ?AutoTarget@PlayerModule@@QBE_NXZ

        // PlayerModule.SetUseDeception:
        public void SetUseDeception(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3D60)(ref this, on); // .text:005D2D60 ; void __thiscall PlayerModule::SetUseDeception(PlayerModule *this, const bool on) .text:005D2D60 ?SetUseDeception@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetStayInChatMode:
        public void SetStayInChatMode(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3E00)(ref this, on); // .text:005D2E00 ; void __thiscall PlayerModule::SetStayInChatMode(PlayerModule *this, const bool on) .text:005D2E00 ?SetStayInChatMode@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetUseFastMissiles:
        public void SetUseFastMissiles(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4480)(ref this, on); // .text:005D3480 ; void __thiscall PlayerModule::SetUseFastMissiles(PlayerModule *this, const bool on) .text:005D3480 ?SetUseFastMissiles@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetConfirmVolatileRareUse:
        public void SetConfirmVolatileRareUse(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4520)(ref this, on); // .text:005D3520 ; void __thiscall PlayerModule::SetConfirmVolatileRareUse(PlayerModule *this, const bool on) .text:005D3520 ?SetConfirmVolatileRareUse@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetFilterLanguage:
        public void SetFilterLanguage(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D49C0)(ref this, on); // .text:005D3970 ; void __thiscall PlayerModule::SetFilterLanguage(PlayerModule *this, const bool on) .text:005D3970 ?SetFilterLanguage@PlayerModule@@QAEX_N@Z

        // PlayerModule.GetDefaultOptionValue:
        public Byte GetDefaultOptionValue(PlayerOption po) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, PlayerOption, Byte>)0x005D3A30)(ref this, po); // .text:005D2A30 ; bool __thiscall PlayerModule::GetDefaultOptionValue(PlayerModule *this, PlayerOption po) .text:005D2A30 ?GetDefaultOptionValue@PlayerModule@@QBE_NW4PlayerOption@@@Z

        // PlayerModule.SetDisableMostWeatherEffects:
        public void SetDisableMostWeatherEffects(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3BE0)(ref this, on); // .text:005D2BE0 ; void __thiscall PlayerModule::SetDisableMostWeatherEffects(PlayerModule *this, const bool on) .text:005D2BE0 ?SetDisableMostWeatherEffects@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetFellowshipShareXP:
        public void SetFellowshipShareXP(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3F40)(ref this, on); // .text:005D2F40 ; void __thiscall PlayerModule::SetFellowshipShareXP(PlayerModule *this, const bool on) .text:005D2F40 ?SetFellowshipShareXP@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetCoordinatesOnRadar:
        public void SetCoordinatesOnRadar(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D40D0)(ref this, on); // .text:005D30D0 ; void __thiscall PlayerModule::SetCoordinatesOnRadar(PlayerModule *this, const bool on) .text:005D30D0 ?SetCoordinatesOnRadar@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisableDistanceFog:
        public void SetDisableDistanceFog(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D43E0)(ref this, on); // .text:005D33E0 ; void __thiscall PlayerModule::SetDisableDistanceFog(PlayerModule *this, const bool on) .text:005D33E0 ?SetDisableDistanceFog@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisplayDateOfBirth:
        public Byte DisplayDateOfBirth() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D47D0)(ref this); // .text:005D3780 ; bool __thiscall PlayerModule::DisplayDateOfBirth(PlayerModule *this) .text:005D3780 ?DisplayDateOfBirth@PlayerModule@@QBE_NXZ

        // PlayerModule.DisplayNumberCharacterTitles:
        public Byte DisplayNumberCharacterTitles() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4960)(ref this); // .text:005D3910 ; bool __thiscall PlayerModule::DisplayNumberCharacterTitles(PlayerModule *this) .text:005D3910 ?DisplayNumberCharacterTitles@PlayerModule@@QBE_NXZ

        // PlayerModule.GetOption:
        public Byte GetOption(PlayerOption po) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, PlayerOption, Byte>)0x005D4AF0)(ref this, po); // .text:005D3AA0 ; bool __thiscall PlayerModule::GetOption(PlayerModule *this, PlayerOption po) .text:005D3AA0 ?GetOption@PlayerModule@@QBE_NW4PlayerOption@@@Z

        // PlayerModule.SetIgnoreAllegianceRequests:
        public void SetIgnoreAllegianceRequests(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3AF0)(ref this, on); // .text:005D2AF0 ; void __thiscall PlayerModule::SetIgnoreAllegianceRequests(PlayerModule *this, const bool on) .text:005D2AF0 ?SetIgnoreAllegianceRequests@PlayerModule@@QAEX_N@Z

        // PlayerModule.IgnoreTradeRequests:
        public Byte IgnoreTradeRequests() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3B80)(ref this); // .text:005D2B80 ; bool __thiscall PlayerModule::IgnoreTradeRequests(PlayerModule *this) .text:005D2B80 ?IgnoreTradeRequests@PlayerModule@@QBE_NXZ

        // PlayerModule.ShowTooltips:
        public Byte ShowTooltips() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3D00)(ref this); // .text:005D2D00 ; bool __thiscall PlayerModule::ShowTooltips(PlayerModule *this) .text:005D2D00 ?ShowTooltips@PlayerModule@@QBE_NXZ

        // PlayerModule.DisableDistanceFog:
        public Byte DisableDistanceFog() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D43D0)(ref this); // .text:005D33D0 ; bool __thiscall PlayerModule::DisableDistanceFog(PlayerModule *this) .text:005D33D0 ?DisableDistanceFog@PlayerModule@@QBE_NXZ

        // PlayerModule.SetLeadMissileTargets:
        public void SetLeadMissileTargets(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4430)(ref this, on); // .text:005D3430 ; void __thiscall PlayerModule::SetLeadMissileTargets(PlayerModule *this, const bool on) .text:005D3430 ?SetLeadMissileTargets@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisplayTimeStamps:
        public void SetDisplayTimeStamps(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4A10)(ref this, on); // .text:005D39C0 ; void __thiscall PlayerModule::SetDisplayTimeStamps(PlayerModule *this, const bool on) .text:005D39C0 ?SetDisplayTimeStamps@PlayerModule@@QAEX_N@Z

        // PlayerModule.GetDesiredCompHashStart:
        public PackableHashIterator<UInt32, UInt32>* GetDesiredCompHashStart(PackableHashIterator<UInt32, UInt32>* result) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, PackableHashIterator<UInt32, UInt32>*, PackableHashIterator<UInt32, UInt32>*>)0x005D5490)(ref this, result); // .text:005D4410 ; PackableHashIterator<IDClass<_tagDataID,32,0>,long> *__thiscall PlayerModule::GetDesiredCompHashStart(PlayerModule *this, PackableHashIterator<IDClass<_tagDataID,32,0>,long> *result) .text:005D4410 ?GetDesiredCompHashStart@PlayerModule@@QAE?AV?$PackableHashIterator@V?$IDClass@U_tagDataID@@$0CA@$0A@@@J@@XZ

        // PlayerModule.SideBySideVitals:
        public Byte SideBySideVitals() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4070)(ref this); // .text:005D3070 ; bool __thiscall PlayerModule::SideBySideVitals(PlayerModule *this) .text:005D3070 ?SideBySideVitals@PlayerModule@@QBE_NXZ

        // PlayerModule.SetUseMouseTurning:
        public void SetUseMouseTurning(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4390)(ref this, on); // .text:005D3390 ; void __thiscall PlayerModule::SetUseMouseTurning(PlayerModule *this, const bool on) .text:005D3390 ?SetUseMouseTurning@PlayerModule@@QAEX_N@Z

        // PlayerModule.UseDeception:
        public Byte UseDeception() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3D50)(ref this); // .text:005D2D50 ; bool __thiscall PlayerModule::UseDeception(PlayerModule *this) .text:005D2D50 ?UseDeception@PlayerModule@@QBE_NXZ

        // PlayerModule.ConfirmVolatileRareUse:
        public Byte ConfirmVolatileRareUse() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4510)(ref this); // .text:005D3510 ; bool __thiscall PlayerModule::ConfirmVolatileRareUse(PlayerModule *this) .text:005D3510 ?ConfirmVolatileRareUse@PlayerModule@@QBE_NXZ

        // PlayerModule.HearLFGChat:
        public Byte HearLFGChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4650)(ref this); // .text:005D3650 ; bool __thiscall PlayerModule::HearLFGChat(PlayerModule *this) .text:005D3650 ?HearLFGChat@PlayerModule@@QBE_NXZ

        // PlayerModule.IgnoreAllegianceRequests:
        public Byte IgnoreAllegianceRequests() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3AE0)(ref this); // .text:005D2AE0 ; bool __thiscall PlayerModule::IgnoreAllegianceRequests(PlayerModule *this) .text:005D2AE0 ?IgnoreAllegianceRequests@PlayerModule@@QBE_NXZ

        // PlayerModule.AdvancedCombatUI:
        public Byte AdvancedCombatUI() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3E40)(ref this); // .text:005D2E40 ; bool __thiscall PlayerModule::AdvancedCombatUI(PlayerModule *this) .text:005D2E40 ?AdvancedCombatUI@PlayerModule@@QBE_NXZ

        // PlayerModule.UseMouseTurning:
        public Byte UseMouseTurning() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4380)(ref this); // .text:005D3380 ; bool __thiscall PlayerModule::UseMouseTurning(PlayerModule *this) .text:005D3380 ?UseMouseTurning@PlayerModule@@QBE_NXZ

        // PlayerModule.SetTimeStampFormat:
        public void SetTimeStampFormat(AC1Legacy.PStringBase<char> format) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, AC1Legacy.PStringBase<char>, void>)0x005D5880)(ref this, format); // .text:005D4800 ; void __thiscall PlayerModule::SetTimeStampFormat(PlayerModule *this, AC1Legacy::PStringBase<char> format) .text:005D4800 ?SetTimeStampFormat@PlayerModule@@QAEXV?$PStringBase@D@AC1Legacy@@@Z

        // PlayerModule.SetVividTargetingIndicator:
        public void SetVividTargetingIndicator(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3EF0)(ref this, on); // .text:005D2EF0 ; void __thiscall PlayerModule::SetVividTargetingIndicator(PlayerModule *this, const bool on) .text:005D2EF0 ?SetVividTargetingIndicator@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisplayNumberCharacterTitles:
        public void SetDisplayNumberCharacterTitles(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4970)(ref this, on); // .text:005D3920 ; void __thiscall PlayerModule::SetDisplayNumberCharacterTitles(PlayerModule *this, const bool on) .text:005D3920 ?SetDisplayNumberCharacterTitles@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisplayTimeStamps:
        public Byte DisplayTimeStamps() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4A00)(ref this); // .text:005D39B0 ; bool __thiscall PlayerModule::DisplayTimeStamps(PlayerModule *this) .text:005D39B0 ?DisplayTimeStamps@PlayerModule@@QBE_NXZ

        // PlayerModule.GetDesiredCompLevel:
        public int GetDesiredCompLevel(UInt32 wcid) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, int>)0x005D5850)(ref this, wcid); // .text:005D47D0 ; int __thiscall PlayerModule::GetDesiredCompLevel(PlayerModule *this, IDClass<_tagDataID,32,0> wcid) .text:005D47D0 ?GetDesiredCompLevel@PlayerModule@@QAEJV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z

        // PlayerModule.GetFavoriteSpellsList:
        public PackableList<UInt32>* GetFavoriteSpellsList(int list) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, int, PackableList<UInt32>*>)0x005D39F0)(ref this, list); // .text:005D29F0 ; PackableList<unsigned long> *__thiscall PlayerModule::GetFavoriteSpellsList(PlayerModule *this, const int list) .text:005D29F0 ?GetFavoriteSpellsList@PlayerModule@@QAEPAV?$PackableList@K@@J@Z

        // PlayerModule.SetShowTooltips:
        public void SetShowTooltips(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3D10)(ref this, on); // .text:005D2D10 ; void __thiscall PlayerModule::SetShowTooltips(PlayerModule *this, const bool on) .text:005D2D10 ?SetShowTooltips@PlayerModule@@QAEX_N@Z

        // PlayerModule.FellowshipShareLoot:
        public Byte FellowshipShareLoot() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3FD0)(ref this); // .text:005D2FD0 ; bool __thiscall PlayerModule::FellowshipShareLoot(PlayerModule *this) .text:005D2FD0 ?FellowshipShareLoot@PlayerModule@@QBE_NXZ

        // PlayerModule.SetSpellDuration:
        public void SetSpellDuration(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4120)(ref this, on); // .text:005D3120 ; void __thiscall PlayerModule::SetSpellDuration(PlayerModule *this, const bool on) .text:005D3120 ?SetSpellDuration@PlayerModule@@QAEX_N@Z

        // PlayerModule.UseFastMissiles:
        public Byte UseFastMissiles() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4470)(ref this); // .text:005D3470 ; bool __thiscall PlayerModule::UseFastMissiles(PlayerModule *this) .text:005D3470 ?UseFastMissiles@PlayerModule@@QBE_NXZ

        // PlayerModule.RemoveSpellFavorite:
        public void RemoveSpellFavorite(UInt32 spid, int list) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, int, void>)0x005D5A60)(ref this, spid, list); // .text:005D4910 ; void __thiscall PlayerModule::RemoveSpellFavorite(PlayerModule *this, const unsigned int spid, const int list) .text:005D4910 ?RemoveSpellFavorite@PlayerModule@@QAEXKJ@Z

        // PlayerModule.SetAutoRepeatAttack:
        public void SetAutoRepeatAttack(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3AA0)(ref this, on); // .text:005D2AA0 ; void __thiscall PlayerModule::SetAutoRepeatAttack(PlayerModule *this, const bool on) .text:005D2AA0 ?SetAutoRepeatAttack@PlayerModule@@QAEX_N@Z

        // PlayerModule.FellowshipAutoAcceptRequests:
        public Byte FellowshipAutoAcceptRequests() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4020)(ref this); // .text:005D3020 ; bool __thiscall PlayerModule::FellowshipAutoAcceptRequests(PlayerModule *this) .text:005D3020 ?FellowshipAutoAcceptRequests@PlayerModule@@QBE_NXZ

        // PlayerModule.SetSalvageMultiple:
        public void SetSalvageMultiple(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4A60)(ref this, on); // .text:005D3A10 ; void __thiscall PlayerModule::SetSalvageMultiple(PlayerModule *this, const bool on) .text:005D3A10 ?SetSalvageMultiple@PlayerModule@@QAEX_N@Z

        // PlayerModule.GetSpellbookFilters:
        public UInt32 GetSpellbookFilters() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32>)0x00401DB0)(ref this); // .text:00401C80 ; unsigned int __thiscall PlayerModule::GetSpellbookFilters(PlayerModule *this) .text:00401C80 ?GetSpellbookFilters@PlayerModule@@QBEKXZ

        // PlayerModule.SetSideBySideVitals:
        public void SetSideBySideVitals(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4080)(ref this, on); // .text:005D3080 ; void __thiscall PlayerModule::SetSideBySideVitals(PlayerModule *this, const bool on) .text:005D3080 ?SetSideBySideVitals@PlayerModule@@QAEX_N@Z

        // PlayerModule.SpellDuration:
        public Byte SpellDuration() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4110)(ref this); // .text:005D3110 ; bool __thiscall PlayerModule::SpellDuration(PlayerModule *this) .text:005D3110 ?SpellDuration@PlayerModule@@QBE_NXZ

        // PlayerModule.SetDisplayDateOfBirth:
        public void SetDisplayDateOfBirth(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D47E0)(ref this, on); // .text:005D3790 ; void __thiscall PlayerModule::SetDisplayDateOfBirth(PlayerModule *this, const bool on) .text:005D3790 ?SetDisplayDateOfBirth@PlayerModule@@QAEX_N@Z

        // PlayerModule.InqOption:
        public Byte InqOption(UInt32 i_propName, BaseProperty* o_baseProp) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32, BaseProperty*, Byte>)0x005D5E20)(ref this, i_propName, o_baseProp); // .text:005D4CD0 ; bool __thiscall PlayerModule::InqOption(PlayerModule *this, unsigned int i_propName, BaseProperty *o_baseProp) .text:005D4CD0 ?InqOption@PlayerModule@@QBE_NKAAVBaseProperty@@@Z

        // PlayerModule.SetUseCraftSuccessDialog:
        public void SetUseCraftSuccessDialog(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D44D0)(ref this, on); // .text:005D34D0 ; void __thiscall PlayerModule::SetUseCraftSuccessDialog(PlayerModule *this, const bool on) .text:005D34D0 ?SetUseCraftSuccessDialog@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisplayFishingSkill:
        public void SetDisplayFishingSkill(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D48D0)(ref this, on); // .text:005D3880 ; void __thiscall PlayerModule::SetDisplayFishingSkill(PlayerModule *this, const bool on) .text:005D3880 ?SetDisplayFishingSkill@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetOption:
        public void SetOption(BaseProperty* i_prop) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, BaseProperty*, void>)0x005D6410)(ref this, i_prop); // .text:005D52C0 ; void __thiscall PlayerModule::SetOption(PlayerModule *this, BaseProperty *i_prop) .text:005D52C0 ?SetOption@PlayerModule@@QAEXABVBaseProperty@@@Z

        // PlayerModule.SetHearSocietyChat:
        public void SetHearSocietyChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4700)(ref this, on); // .text:005D3700 ; void __thiscall PlayerModule::SetHearSocietyChat(PlayerModule *this, const bool on) .text:005D3700 ?SetHearSocietyChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.SetDisplayAge:
        public void SetDisplayAge(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4830)(ref this, on); // .text:005D37E0 ; void __thiscall PlayerModule::SetDisplayAge(PlayerModule *this, const bool on) .text:005D37E0 ?SetDisplayAge@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisplayFishingSkill:
        public Byte DisplayFishingSkill() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D48C0)(ref this); // .text:005D3870 ; bool __thiscall PlayerModule::DisplayFishingSkill(PlayerModule *this) .text:005D3870 ?DisplayFishingSkill@PlayerModule@@QBE_NXZ

        // PlayerModule.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, void**, UInt32, UInt32>)0x005D5640)(ref this, addr, size); // .text:005D45C0 ; unsigned int __thiscall PlayerModule::Pack(PlayerModule *this, void **addr, unsigned int size) .text:005D45C0 ?Pack@PlayerModule@@UAEIAAPAXI@Z

        // PlayerModule.Clear:
        public void Clear() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, void>)0x005D59F0)(ref this); // .text:005D48A0 ; void __thiscall PlayerModule::Clear(PlayerModule *this) .text:005D48A0 ?Clear@PlayerModule@@QAEXXZ

        // PlayerModule.SetAcceptLootPermits:
        public void SetAcceptLootPermits(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3F90)(ref this, on); // .text:005D2F90 ; void __thiscall PlayerModule::SetAcceptLootPermits(PlayerModule *this, const bool on) .text:005D2F90 ?SetAcceptLootPermits@PlayerModule@@QAEX_N@Z

        // PlayerModule.DisableHouseRestrictionEffects:
        public Byte DisableHouseRestrictionEffects() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4160)(ref this); // .text:005D3160 ; bool __thiscall PlayerModule::DisableHouseRestrictionEffects(PlayerModule *this) .text:005D3160 ?DisableHouseRestrictionEffects@PlayerModule@@QBE_NXZ

        // PlayerModule.DisplayAllegianceLogonNotifications:
        public Byte DisplayAllegianceLogonNotifications() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4200)(ref this); // .text:005D3200 ; bool __thiscall PlayerModule::DisplayAllegianceLogonNotifications(PlayerModule *this) .text:005D3200 ?DisplayAllegianceLogonNotifications@PlayerModule@@QBE_NXZ

        // PlayerModule.SetHearRoleplayChat:
        public void SetHearRoleplayChat(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D46B0)(ref this, on); // .text:005D36B0 ; void __thiscall PlayerModule::SetHearRoleplayChat(PlayerModule *this, const bool on) .text:005D36B0 ?SetHearRoleplayChat@PlayerModule@@QAEX_N@Z

        // PlayerModule.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, void**, UInt32, int>)0x005D5B20)(ref this, addr, size); // .text:005D49D0 ; int __thiscall PlayerModule::UnPack(PlayerModule *this, void **addr, unsigned int size) .text:005D49D0 ?UnPack@PlayerModule@@UAEHAAPAXI@Z

        // PlayerModule.ClearDesiredCompList:
        public void ClearDesiredCompList() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, void>)0x005D3A00)(ref this); // .text:005D2A00 ; void __thiscall PlayerModule::ClearDesiredCompList(PlayerModule *this) .text:005D2A00 ?ClearDesiredCompList@PlayerModule@@QAEXXZ

        // PlayerModule.DisableMostWeatherEffects:
        public Byte DisableMostWeatherEffects() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3BD0)(ref this); // .text:005D2BD0 ; bool __thiscall PlayerModule::DisableMostWeatherEffects(PlayerModule *this) .text:005D2BD0 ?DisableMostWeatherEffects@PlayerModule@@QBE_NXZ

        // PlayerModule.LockUI:
        public Byte LockUI() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4330)(ref this); // .text:005D3330 ; bool __thiscall PlayerModule::LockUI(PlayerModule *this) .text:005D3330 ?LockUI@PlayerModule@@QBE_NXZ

        // PlayerModule.UseCraftSuccessDialog:
        public Byte UseCraftSuccessDialog() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D44C0)(ref this); // .text:005D34C0 ; bool __thiscall PlayerModule::UseCraftSuccessDialog(PlayerModule *this) .text:005D34C0 ?UseCraftSuccessDialog@PlayerModule@@QBE_NXZ

        // PlayerModule.HearTradeChat:
        public Byte HearTradeChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4600)(ref this); // .text:005D3600 ; bool __thiscall PlayerModule::HearTradeChat(PlayerModule *this) .text:005D3600 ?HearTradeChat@PlayerModule@@QBE_NXZ

        // PlayerModule.DisplayAge:
        public Byte DisplayAge() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4820)(ref this); // .text:005D37D0 ; bool __thiscall PlayerModule::DisplayAge(PlayerModule *this) .text:005D37D0 ?DisplayAge@PlayerModule@@QBE_NXZ

        // PlayerModule.SetDisplayChessRank:
        public void SetDisplayChessRank(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D4880)(ref this, on); // .text:005D3830 ; void __thiscall PlayerModule::SetDisplayChessRank(PlayerModule *this, const bool on) .text:005D3830 ?SetDisplayChessRank@PlayerModule@@QAEX_N@Z

        // PlayerModule.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32>)0x005D5580)(ref this); // .text:005D4500 ; unsigned int __thiscall PlayerModule::GetPackSize(PlayerModule *this) .text:005D4500 ?GetPackSize@PlayerModule@@MAEIXZ

        // PlayerModule.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, void>)0x005D6340)(ref this); // .text:005D51F0 ; void __thiscall PlayerModule::PlayerModule(PlayerModule *this) .text:005D51F0 ??0PlayerModule@@QAE@XZ

        // PlayerModule.SetDragItemOnPlayerOpensSecureTrade:
        public void SetDragItemOnPlayerOpensSecureTrade(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D41C0)(ref this, on); // .text:005D31C0 ; void __thiscall PlayerModule::SetDragItemOnPlayerOpensSecureTrade(PlayerModule *this, const bool on) .text:005D31C0 ?SetDragItemOnPlayerOpensSecureTrade@PlayerModule@@QAEX_N@Z

        // PlayerModule.MainPackPreferred:
        public Byte MainPackPreferred() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4AA0)(ref this); // .text:005D3A50 ; bool __thiscall PlayerModule::MainPackPreferred(PlayerModule *this) .text:005D3A50 ?MainPackPreferred@PlayerModule@@QBE_NXZ

        // PlayerModule.IgnoreFellowshipRequests:
        public Byte IgnoreFellowshipRequests() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3B30)(ref this); // .text:005D2B30 ; bool __thiscall PlayerModule::IgnoreFellowshipRequests(PlayerModule *this) .text:005D2B30 ?IgnoreFellowshipRequests@PlayerModule@@QBE_NXZ

        // PlayerModule.SetAdvancedCombatUI:
        public void SetAdvancedCombatUI(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3E50)(ref this, on); // .text:005D2E50 ; void __thiscall PlayerModule::SetAdvancedCombatUI(PlayerModule *this, const bool on) .text:005D2E50 ?SetAdvancedCombatUI@PlayerModule@@QAEX_N@Z

        // PlayerModule.DragItemOnPlayerOpensSecureTrade:
        public Byte DragItemOnPlayerOpensSecureTrade() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D41B0)(ref this); // .text:005D31B0 ; bool __thiscall PlayerModule::DragItemOnPlayerOpensSecureTrade(PlayerModule *this) .text:005D31B0 ?DragItemOnPlayerOpensSecureTrade@PlayerModule@@QBE_NXZ

        // PlayerModule.AutoRepeatAttack:
        public Byte AutoRepeatAttack() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3A90)(ref this); // .text:005D2A90 ; bool __thiscall PlayerModule::AutoRepeatAttack(PlayerModule *this) .text:005D2A90 ?AutoRepeatAttack@PlayerModule@@QBE_NXZ

        // PlayerModule.SetIgnoreTradeRequests:
        public void SetIgnoreTradeRequests(Byte on) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte, void>)0x005D3B90)(ref this, on); // .text:005D2B90 ; void __thiscall PlayerModule::SetIgnoreTradeRequests(PlayerModule *this, bool on) .text:005D2B90 ?SetIgnoreTradeRequests@PlayerModule@@QAEX_N@Z

        // PlayerModule.PersistentAtDay:
        public Byte PersistentAtDay() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3C20)(ref this); // .text:005D2C20 ; bool __thiscall PlayerModule::PersistentAtDay(PlayerModule *this) .text:005D2C20 ?PersistentAtDay@PlayerModule@@QBE_NXZ

        // PlayerModule.ViewCombatTarget:
        public Byte ViewCombatTarget() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3CB0)(ref this); // .text:005D2CB0 ; bool __thiscall PlayerModule::ViewCombatTarget(PlayerModule *this) .text:005D2CB0 ?ViewCombatTarget@PlayerModule@@QBE_NXZ

        // PlayerModule.HearAllegianceChat:
        public Byte HearAllegianceChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4560)(ref this); // .text:005D3560 ; bool __thiscall PlayerModule::HearAllegianceChat(PlayerModule *this) .text:005D3560 ?HearAllegianceChat@PlayerModule@@QBE_NXZ

        // PlayerModule.SalvageMultiple:
        public Byte SalvageMultiple() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4A50)(ref this); // .text:005D3A00 ; bool __thiscall PlayerModule::SalvageMultiple(PlayerModule *this) .text:005D3A00 ?SalvageMultiple@PlayerModule@@QBE_NXZ

        // PlayerModule.UseChargeAttack:
        public Byte UseChargeAttack() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D4250)(ref this); // .text:005D3250 ; bool __thiscall PlayerModule::UseChargeAttack(PlayerModule *this) .text:005D3250 ?UseChargeAttack@PlayerModule@@QBE_NXZ

        // PlayerModule.HearSocietyChat:
        public Byte HearSocietyChat() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D46F0)(ref this); // .text:005D36F0 ; bool __thiscall PlayerModule::HearSocietyChat(PlayerModule *this) .text:005D36F0 ?HearSocietyChat@PlayerModule@@QBE_NXZ

        // PlayerModule.SetPackHeader:
        public void SetPackHeader(UInt32* bitfield) => ((delegate* unmanaged[Thiscall]<ref PlayerModule, UInt32*, void>)0x005D5520)(ref this, bitfield); // .text:005D44A0 ; void __thiscall PlayerModule::SetPackHeader(PlayerModule *this, unsigned int *bitfield) .text:005D44A0 ?SetPackHeader@PlayerModule@@IAEXAAK@Z

        // PlayerModule.AcceptLootPermits:
        public Byte AcceptLootPermits() => ((delegate* unmanaged[Thiscall]<ref PlayerModule, Byte>)0x005D3F80)(ref this); // .text:005D2F80 ; bool __thiscall PlayerModule::AcceptLootPermits(PlayerModule *this) .text:005D2F80 ?AcceptLootPermits@PlayerModule@@QBE_NXZ

    }



    public unsafe struct CInvSlotInfo {
        // Struct:
        public UInt32 m_itemID;
        public UInt32 m_invLoc;
        public override string ToString() => $"m_itemID:{m_itemID:X8}, m_invLoc:{m_invLoc:X8}";
    }
    public unsafe struct CInvSlotModule {
        // Struct:
        public CInvSlotInfo* neckSlot;
        public CInvSlotInfo* leftWristSlot;
        public CInvSlotInfo* leftRingSlot;
        public CInvSlotInfo* rightWristSlot;
        public CInvSlotInfo* rightRingSlot;
        public CInvSlotInfo* weaponReadySlot;
        public CInvSlotInfo* ammoReadySlot;
        public CInvSlotInfo* shieldReadySlot;
        public CInvSlotInfo* clothesPantsSlot;
        public CInvSlotInfo* clothesShirtSlot;
        public CInvSlotInfo* trinketOneSlot;
        public CInvSlotInfo* cloakSlot;
        public CInvSlotInfo* sigilOneSlot;
        public CInvSlotInfo* sigilTwoSlot;
        public CInvSlotInfo* sigilThreeSlot;
        public CInvSlotInfo* headSlot;
        public CInvSlotInfo* chestSlot;
        public CInvSlotInfo* abdomenSlot;
        public CInvSlotInfo* upperArmSlot;
        public CInvSlotInfo* lowerArmSlot;
        public CInvSlotInfo* handSlot;
        public CInvSlotInfo* upperLegSlot;
        public CInvSlotInfo* lowerLegSlot;
        public CInvSlotInfo* footSlot;
        public override string ToString() => $"neckSlot:->(CInvSlotInfo*)0x{(int)neckSlot:X8}, leftWristSlot:->(CInvSlotInfo*)0x{(int)leftWristSlot:X8}, leftRingSlot:->(CInvSlotInfo*)0x{(int)leftRingSlot:X8}, rightWristSlot:->(CInvSlotInfo*)0x{(int)rightWristSlot:X8}, rightRingSlot:->(CInvSlotInfo*)0x{(int)rightRingSlot:X8}, weaponReadySlot:->(CInvSlotInfo*)0x{(int)weaponReadySlot:X8}, ammoReadySlot:->(CInvSlotInfo*)0x{(int)ammoReadySlot:X8}, shieldReadySlot:->(CInvSlotInfo*)0x{(int)shieldReadySlot:X8}, clothesPantsSlot:->(CInvSlotInfo*)0x{(int)clothesPantsSlot:X8}, clothesShirtSlot:->(CInvSlotInfo*)0x{(int)clothesShirtSlot:X8}, trinketOneSlot:->(CInvSlotInfo*)0x{(int)trinketOneSlot:X8}, cloakSlot:->(CInvSlotInfo*)0x{(int)cloakSlot:X8}, sigilOneSlot:->(CInvSlotInfo*)0x{(int)sigilOneSlot:X8}, sigilTwoSlot:->(CInvSlotInfo*)0x{(int)sigilTwoSlot:X8}, sigilThreeSlot:->(CInvSlotInfo*)0x{(int)sigilThreeSlot:X8}, headSlot:->(CInvSlotInfo*)0x{(int)headSlot:X8}, chestSlot:->(CInvSlotInfo*)0x{(int)chestSlot:X8}, abdomenSlot:->(CInvSlotInfo*)0x{(int)abdomenSlot:X8}, upperArmSlot:->(CInvSlotInfo*)0x{(int)upperArmSlot:X8}, lowerArmSlot:->(CInvSlotInfo*)0x{(int)lowerArmSlot:X8}, handSlot:->(CInvSlotInfo*)0x{(int)handSlot:X8}, upperLegSlot:->(CInvSlotInfo*)0x{(int)upperLegSlot:X8}, lowerLegSlot:->(CInvSlotInfo*)0x{(int)lowerLegSlot:X8}, footSlot:->(CInvSlotInfo*)0x{(int)footSlot:X8}";

        // Functions:

        // CInvSlotModule.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CInvSlotModule, void>)0x0055E680)(ref this); // .text:0055D960 ; void __thiscall CInvSlotModule::CInvSlotModule(CInvSlotModule *this) .text:0055D960 ??0CInvSlotModule@@QAE@XZ

        // CInvSlotModule.Reset:
        public void Reset() => ((delegate* unmanaged[Thiscall]<ref CInvSlotModule, void>)0x0055E9C0)(ref this); // .text:0055DCA0 ; void __thiscall CInvSlotModule::Reset(CInvSlotModule *this) .text:0055DCA0 ?Reset@CInvSlotModule@@QAEXXZ
    }
    public unsafe struct SkillSystem {
        // Struct:

        // Functions:

        // SkillSystem.InqAttribute2ndDescription:
        public static Byte InqAttribute2ndDescription(UInt32 stype, PStringBase<UInt16>* name) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9F50)(stype, name); // .text:005C8F70 ; bool __cdecl SkillSystem::InqAttribute2ndDescription(unsigned int stype, PStringBase<unsigned short> *name) .text:005C8F70 ?InqAttribute2ndDescription@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqAttribute2ndName:
        public static Byte InqAttribute2ndName(UInt32 stype, AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x005C9880)(stype, name); // .text:005C88A0 ; bool __cdecl SkillSystem::InqAttribute2ndName(unsigned int stype, AC1Legacy::PStringBase<char> *name) .text:005C88A0 ?InqAttribute2ndName@SkillSystem@@SA_NKAAV?$PStringBase@D@AC1Legacy@@@Z

        // SkillSystem.InqAttribute2ndName:
        public static Byte InqAttribute2ndName(UInt32 stype, PStringBase<UInt16>* name) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9EB0)(stype, name); // .text:005C8ED0 ; bool __cdecl SkillSystem::InqAttribute2ndName(unsigned int stype, PStringBase<unsigned short> *name) .text:005C8ED0 ?InqAttribute2ndName@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqAttributeDescription:
        public static Byte InqAttributeDescription(UInt32 stype, PStringBase<UInt16>* name) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9E10)(stype, name); // .text:005C8E30 ; bool __cdecl SkillSystem::InqAttributeDescription(unsigned int stype, PStringBase<unsigned short> *name) .text:005C8E30 ?InqAttributeDescription@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqAttributeName:
        public static Byte InqAttributeName(UInt32 stype, AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x005C97E0)(stype, name); // .text:005C8800 ; bool __cdecl SkillSystem::InqAttributeName(unsigned int stype, AC1Legacy::PStringBase<char> *name) .text:005C8800 ?InqAttributeName@SkillSystem@@SA_NKAAV?$PStringBase@D@AC1Legacy@@@Z

        // SkillSystem.InqAttributeName:
        public static Byte InqAttributeName(UInt32 stype, PStringBase<UInt16>* name) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9D70)(stype, name); // .text:005C8D90 ; bool __cdecl SkillSystem::InqAttributeName(unsigned int stype, PStringBase<unsigned short> *name) .text:005C8D90 ?InqAttributeName@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqSkillDescription:
        public static Byte InqSkillDescription(UInt32 skill, AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x005C9750)(skill, name); // .text:005C8770 ; bool __cdecl SkillSystem::InqSkillDescription(unsigned int skill, AC1Legacy::PStringBase<char> *name) .text:005C8770 ?InqSkillDescription@SkillSystem@@SA_NKAAV?$PStringBase@D@AC1Legacy@@@Z

        // SkillSystem.InqSkillDescription:
        public static Byte InqSkillDescription(UInt32 i_skill, PStringBase<UInt16>* o_strWideName) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9D00)(i_skill, o_strWideName); // .text:005C8D20 ; bool __cdecl SkillSystem::InqSkillDescription(unsigned int i_skill, PStringBase<unsigned short> *o_strWideName) .text:005C8D20 ?InqSkillDescription@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqSkillFormula:
        public static Byte InqSkillFormula(UInt32 skill, AC1Legacy.PStringBase<char>* formula) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x005C9990)(skill, formula); // .text:005C89B0 ; bool __cdecl SkillSystem::InqSkillFormula(unsigned int skill, AC1Legacy::PStringBase<char> *formula) .text:005C89B0 ?InqSkillFormula@SkillSystem@@SA_NKAAV?$PStringBase@D@AC1Legacy@@@Z

        // SkillSystem.InqSkillFormula:
        public static Byte InqSkillFormula(UInt32 i_skill, PStringBase<UInt16>* o_strWideFormula) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9C90)(i_skill, o_strWideFormula); // .text:005C8CB0 ; bool __cdecl SkillSystem::InqSkillFormula(unsigned int i_skill, PStringBase<unsigned short> *o_strWideFormula) .text:005C8CB0 ?InqSkillFormula@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z

        // SkillSystem.InqSkillName:
        public static Byte InqSkillName(UInt32 skill, AC1Legacy.PStringBase<char>* name) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x005C96C0)(skill, name); // .text:005C86E0 ; bool __cdecl SkillSystem::InqSkillName(unsigned int skill, AC1Legacy::PStringBase<char> *name) .text:005C86E0 ?InqSkillName@SkillSystem@@SA_NKAAV?$PStringBase@D@AC1Legacy@@@Z

        // SkillSystem.InqSkillName:
        public static Byte InqSkillName(UInt32 i_skill, PStringBase<UInt16>* o_strWideName) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<UInt16>*, Byte>)0x005C9920)(i_skill, o_strWideName); // .text:005C8940 ; bool __cdecl SkillSystem::InqSkillName(unsigned int i_skill, PStringBase<unsigned short> *o_strWideName) .text:005C8940 ?InqSkillName@SkillSystem@@SA_NKAAV?$PStringBase@G@@@Z
    }



}
