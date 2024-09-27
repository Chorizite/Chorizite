using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct ClientCombatSystem {
        // Struct:
        public ClientSystem a0;
        public IInputActionCallback a1;
        public QualityChangeHandler a2;
        public Turbine_RefCount m_cTurbineRefCount;
        public Byte jump_pending;
        public Byte m_bTrackingTarget;
        public COMBAT_MODE combatMode;
        public COMBAT_MODE pendingCombatMode;
        public ATTACK_HEIGHT requestedAttackHeight;
        public Double buildStartTime;
        public Byte buildInProgress;
        public PowerBarMode powerBarMode;
        public Single latestPowerBarLevel;
        public Byte attackInProgress;
        public Byte attackServerResponsePending;
        public Byte attackRequestInProgress;
        public Single requestedAttackPower;
        public Byte repeatAttacking;
        public Byte currentBuildIsAutomatic;
        public Byte targetWillinglyLost;
        public Byte attackWhenResponseReceived;
        public Single attackWhenResponseReceived_Power;
        public Single m_rUIRequestedPower;
        public Byte m_bAdvancedCombatMode;
        public Double lastAttackedTime;
        public override string ToString() => $"a0(ClientSystem):{a0}, a1(IInputActionCallback):{a1}, a2(QualityChangeHandler):{a2}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, jump_pending:{jump_pending:X2}, m_bTrackingTarget:{m_bTrackingTarget:X2}, combatMode(COMBAT_MODE):{combatMode}, pendingCombatMode(COMBAT_MODE):{pendingCombatMode}, requestedAttackHeight(ATTACK_HEIGHT):{requestedAttackHeight}, buildStartTime:{buildStartTime:n5}, buildInProgress:{buildInProgress:X2}, powerBarMode(PowerBarMode):{powerBarMode}, latestPowerBarLevel:{latestPowerBarLevel:n5}, attackInProgress:{attackInProgress:X2}, attackServerResponsePending:{attackServerResponsePending:X2}, attackRequestInProgress:{attackRequestInProgress:X2}, requestedAttackPower:{requestedAttackPower:n5}, repeatAttacking:{repeatAttacking:X2}, currentBuildIsAutomatic:{currentBuildIsAutomatic:X2}, targetWillinglyLost:{targetWillinglyLost:X2}, attackWhenResponseReceived:{attackWhenResponseReceived:X2}, attackWhenResponseReceived_Power:{attackWhenResponseReceived_Power:n5}, m_rUIRequestedPower:{m_rUIRequestedPower:n5}, m_bAdvancedCombatMode:{m_bAdvancedCombatMode:X2}, lastAttackedTime:{lastAttackedTime:n5}";

        // Functions:

        // ClientCombatSystem.Begin:
        public void Begin() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B1A0)(ref this); // .text:0056A460 ; void __thiscall ClientCombatSystem::Begin(ClientCombatSystem *this) .text:0056A460 ?Begin@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.HandleMagicAction:
        public Byte HandleMagicAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, InputEvent*, Byte>)0x0056B420)(ref this, i_evt); // .text:0056A6E0 ; bool __thiscall ClientCombatSystem::HandleMagicAction(ClientCombatSystem *this, InputEvent *i_evt) .text:0056A6E0 ?HandleMagicAction@ClientCombatSystem@@IAE_NABVInputEvent@@@Z

        // ClientCombatSystem.SetPowerBarLevel:
        public void SetPowerBarLevel(Single level) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Single, void>)0x0056B5D0)(ref this, level); // .text:0056A890 ; void __thiscall ClientCombatSystem::SetPowerBarLevel(ClientCombatSystem *this, float level) .text:0056A890 ?SetPowerBarLevel@ClientCombatSystem@@IAEXM@Z

        // ClientCombatSystem.StartAttackRequest:
        public void StartAttackRequest() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056CD90)(ref this); // .text:0056C040 ; void __thiscall ClientCombatSystem::StartAttackRequest(ClientCombatSystem *this) .text:0056C040 ?StartAttackRequest@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056CF40)(ref this); // .text:0056C1F0 ; void __thiscall ClientCombatSystem::UseTime(ClientCombatSystem *this) .text:0056C1F0 ?UseTime@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.ToggleCombatMode:
        public void ToggleCombatMode() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056D610)(ref this); // .text:0056C8C0 ; void __thiscall ClientCombatSystem::ToggleCombatMode(ClientCombatSystem *this) .text:0056C8C0 ?ToggleCombatMode@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B250)(ref this); // .text:0056A510 ; void __thiscall ClientCombatSystem::OnShutdown(ClientCombatSystem *this) .text:0056A510 ?OnShutdown@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x0056B990)(ref this, result, i_rcInterface, o_ppvInterface); // .text:0056AC50 ; TResult *__thiscall ClientCombatSystem::QueryInterface(ClientCombatSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0056AC50 ?QueryInterface@ClientCombatSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientCombatSystem.GetPowerBarLevel:
        public Single GetPowerBarLevel() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Single>)0x0056BB20)(ref this); // .text:0056ADE0 ; float __thiscall ClientCombatSystem::GetPowerBarLevel(ClientCombatSystem *this) .text:0056ADE0 ?GetPowerBarLevel@ClientCombatSystem@@IBEMXZ

        // ClientCombatSystem.AbortAutomaticAttack:
        public void AbortAutomaticAttack() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BBD0)(ref this); // .text:0056AE90 ; void __thiscall ClientCombatSystem::AbortAutomaticAttack(ClientCombatSystem *this) .text:0056AE90 ?AbortAutomaticAttack@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.HandleAttackerNotificationEvent:
        public void HandleAttackerNotificationEvent(AC1Legacy.PStringBase<char>* defenders_name, DAMAGE_TYPE dtype, Double php, int hp, int critical, Int64 attack_conditions) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, AC1Legacy.PStringBase<char>*, DAMAGE_TYPE, Double, int, int, Int64, void>)0x0056C160)(ref this, defenders_name, dtype, php, hp, critical, attack_conditions); // .text:0056B420 ; void __thiscall ClientCombatSystem::HandleAttackerNotificationEvent(ClientCombatSystem *this, AC1Legacy::PStringBase<char> *defenders_name, DAMAGE_TYPE dtype, const long double php, const int hp, int critical, const __int64 attack_conditions) .text:0056B420 ?HandleAttackerNotificationEvent@ClientCombatSystem@@QAEXABV?$PStringBase@D@AC1Legacy@@W4DAMAGE_TYPE@@NJH_J@Z

        // ClientCombatSystem.SetCombatMode:
        public void SetCombatMode(COMBAT_MODE i_NewCombatMode, Byte i_bPlayerRequested) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, COMBAT_MODE, Byte, void>)0x0056CB80)(ref this, i_NewCombatMode, i_bPlayerRequested); // .text:0056BE30 ; void __thiscall ClientCombatSystem::SetCombatMode(ClientCombatSystem *this, COMBAT_MODE i_NewCombatMode, bool i_bPlayerRequested) .text:0056BE30 ?SetCombatMode@ClientCombatSystem@@QAEXW4COMBAT_MODE@@_N@Z

        // ClientCombatSystem.GetDefaultCombatMode:
        public COMBAT_MODE GetDefaultCombatMode(Byte _quiet) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Byte, COMBAT_MODE>)0x0056C050)(ref this, _quiet); // .text:0056B310 ; COMBAT_MODE __thiscall ClientCombatSystem::GetDefaultCombatMode(ClientCombatSystem *this, bool _quiet) .text:0056B310 ?GetDefaultCombatMode@ClientCombatSystem@@QAE?AW4COMBAT_MODE@@_N@Z

        // ClientCombatSystem.Handle_Combat__QueryHealthResponse:
        public UInt32 Handle_Combat__QueryHealthResponse(UInt32 target, Single health) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, UInt32, Single, UInt32>)0x0056B2A0)(ref this, target, health); // .text:0056A560 ; unsigned int __thiscall ClientCombatSystem::Handle_Combat__QueryHealthResponse(ClientCombatSystem *this, unsigned int target, float health) .text:0056A560 ?Handle_Combat__QueryHealthResponse@ClientCombatSystem@@QAEKKM@Z

        // ClientCombatSystem.FinishJump:
        public void FinishJump() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B6F0)(ref this); // .text:0056A9B0 ; void __thiscall ClientCombatSystem::FinishJump(ClientCombatSystem *this) .text:0056A9B0 ?FinishJump@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, UInt32>)0x0056B960)(ref this); // .text:0056AC20 ; unsigned int __thiscall ClientCombatSystem::Release(ClientCombatSystem *this) .text:0056AC20 ?Release@ClientCombatSystem@@UBEKXZ

        // ClientCombatSystem.HandleCommenceAttackEvent:
        public void HandleCommenceAttackEvent() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BA60)(ref this); // .text:0056AD20 ; void __thiscall ClientCombatSystem::HandleCommenceAttackEvent(ClientCombatSystem *this) .text:0056AD20 ?HandleCommenceAttackEvent@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.OnBeginCharacterSession:
        public void OnBeginCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BC30)(ref this); // .text:0056AEF0 ; void __thiscall ClientCombatSystem::OnBeginCharacterSession(ClientCombatSystem *this) .text:0056AEF0 ?OnBeginCharacterSession@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.CommenceJump:
        public void CommenceJump() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BCD0)(ref this); // .text:0056AF90 ; void __thiscall ClientCombatSystem::CommenceJump(ClientCombatSystem *this) .text:0056AF90 ?CommenceJump@ClientCombatSystem@@QAEXXZ

        // ClientCombatSystem.GetAttackTarget:
        public UInt32 GetAttackTarget() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, UInt32>)0x0056B630)(ref this); // .text:0056A8F0 ; unsigned int __thiscall ClientCombatSystem::GetAttackTarget(ClientCombatSystem *this) .text:0056A8F0 ?GetAttackTarget@ClientCombatSystem@@QAEKXZ

        // ClientCombatSystem.PlayerInReadyPosition:
        public Byte PlayerInReadyPosition(Byte _considerAttackingReady) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Byte, Byte>)0x0056C570)(ref this, _considerAttackingReady); // .text:0056B820 ; bool __thiscall ClientCombatSystem::PlayerInReadyPosition(ClientCombatSystem *this, bool _considerAttackingReady) .text:0056B820 ?PlayerInReadyPosition@ClientCombatSystem@@QAE_N_N@Z

        // ClientCombatSystem.RecvNotice_SelectionChanged:
        public void RecvNotice_SelectionChanged() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056CAD0)(ref this); // .text:0056BD80 ; void __thiscall ClientCombatSystem::RecvNotice_SelectionChanged(ClientCombatSystem *this) .text:0056BD80 ?RecvNotice_SelectionChanged@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.HandleAttackDoneEvent:
        public void HandleAttackDoneEvent(UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, UInt32, void>)0x0056D250)(ref this, etype); // .text:0056C500 ; void __thiscall ClientCombatSystem::HandleAttackDoneEvent(ClientCombatSystem *this, const unsigned int etype) .text:0056C500 ?HandleAttackDoneEvent@ClientCombatSystem@@QAEXK@Z

        // ClientCombatSystem.SetRequestedAttackHeight:
        public void SetRequestedAttackHeight(ATTACK_HEIGHT _height) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, ATTACK_HEIGHT, void>)0x0056D640)(ref this, _height); // .text:0056C8F0 ; void __thiscall ClientCombatSystem::SetRequestedAttackHeight(ClientCombatSystem *this, ATTACK_HEIGHT _height) .text:0056C8F0 ?SetRequestedAttackHeight@ClientCombatSystem@@QAEXW4ATTACK_HEIGHT@@@Z

        // ClientCombatSystem.HandleCombatAction:
        public Byte HandleCombatAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, InputEvent*, Byte>)0x0056E3B0)(ref this, i_evt); // .text:0056D600 ; bool __thiscall ClientCombatSystem::HandleCombatAction(ClientCombatSystem *this, InputEvent *i_evt) .text:0056D600 ?HandleCombatAction@ClientCombatSystem@@IAE_NABVInputEvent@@@Z

        // ClientCombatSystem.ObjectIsAttackable:
        public Byte ObjectIsAttackable(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, UInt32, Byte>)0x0056B340)(ref this, _objectID); // .text:0056A600 ; bool __thiscall ClientCombatSystem::ObjectIsAttackable(ClientCombatSystem *this, unsigned int _objectID) .text:0056A600 ?ObjectIsAttackable@ClientCombatSystem@@QAE_NK@Z

        // ClientCombatSystem.RepeatAttackInProgress:
        public Byte RepeatAttackInProgress() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Byte>)0x0056B5A0)(ref this); // .text:0056A860 ; bool __thiscall ClientCombatSystem::RepeatAttackInProgress(ClientCombatSystem *this) .text:0056A860 ?RepeatAttackInProgress@ClientCombatSystem@@QAE_NXZ

        // ClientCombatSystem.UpdateTargetTracking:
        public void UpdateTargetTracking() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B690)(ref this); // .text:0056A950 ; void __thiscall ClientCombatSystem::UpdateTargetTracking(ClientCombatSystem *this) .text:0056A950 ?UpdateTargetTracking@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BC70)(ref this); // .text:0056AF30 ; void __thiscall ClientCombatSystem::OnEndCharacterSession(ClientCombatSystem *this) .text:0056AF30 ?OnEndCharacterSession@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.ExecuteAttack:
        public void ExecuteAttack(ATTACK_HEIGHT _attackHeight, Byte _expectServerResponse) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, ATTACK_HEIGHT, Byte, void>)0x0056C8C0)(ref this, _attackHeight, _expectServerResponse); // .text:0056BB70 ; void __thiscall ClientCombatSystem::ExecuteAttack(ClientCombatSystem *this, ATTACK_HEIGHT _attackHeight, bool _expectServerResponse) .text:0056BB70 ?ExecuteAttack@ClientCombatSystem@@IAEXW4ATTACK_HEIGHT@@_N@Z

        // ClientCombatSystem.HandleEvasionAttackerNotificationEvent:
        public void HandleEvasionAttackerNotificationEvent(AC1Legacy.PStringBase<char>* defenders_name) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, AC1Legacy.PStringBase<char>*, void>)0x0056D4F0)(ref this, defenders_name); // .text:0056C7A0 ; void __thiscall ClientCombatSystem::HandleEvasionAttackerNotificationEvent(ClientCombatSystem *this, AC1Legacy::PStringBase<char> *defenders_name) .text:0056C7A0 ?HandleEvasionAttackerNotificationEvent@ClientCombatSystem@@QAEXABV?$PStringBase@D@AC1Legacy@@@Z

        // ClientCombatSystem.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, InputEvent*, Byte>)0x0056E640)(ref this, i_evt); // .text:0056D890 ; bool __thiscall ClientCombatSystem::OnAction(ClientCombatSystem *this, InputEvent *i_evt) .text:0056D890 ?OnAction@ClientCombatSystem@@MAE_NABVInputEvent@@@Z

        // ClientCombatSystem.EndAttackRequest:
        public void EndAttackRequest(ATTACK_HEIGHT _attackHeight, Single _power) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, ATTACK_HEIGHT, Single, void>)0x0056CE30)(ref this, _attackHeight, _power); // .text:0056C0E0 ; void __thiscall ClientCombatSystem::EndAttackRequest(ClientCombatSystem *this, ATTACK_HEIGHT _attackHeight, float _power) .text:0056C0E0 ?EndAttackRequest@ClientCombatSystem@@QAEXW4ATTACK_HEIGHT@@M@Z

        // ClientCombatSystem.HandleVictimNotificationEvent:
        public int HandleVictimNotificationEvent(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void*, UInt32, int>)0x0056D160)(ref this, buff, size); // .text:0056C410 ; int __thiscall ClientCombatSystem::HandleVictimNotificationEvent(ClientCombatSystem *this, void *buff, unsigned int size) .text:0056C410 ?HandleVictimNotificationEvent@ClientCombatSystem@@QAEHPAXI@Z

        // ClientCombatSystem.HandleEvasionDefenderNotificationEvent:
        public void HandleEvasionDefenderNotificationEvent(AC1Legacy.PStringBase<char>* attackers_name) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, AC1Legacy.PStringBase<char>*, void>)0x0056D370)(ref this, attackers_name); // .text:0056C620 ; void __thiscall ClientCombatSystem::HandleEvasionDefenderNotificationEvent(ClientCombatSystem *this, AC1Legacy::PStringBase<char> *attackers_name) .text:0056C620 ?HandleEvasionDefenderNotificationEvent@ClientCombatSystem@@QAEXABV?$PStringBase@D@AC1Legacy@@@Z

        // ClientCombatSystem.HandleDefenderNotificationEvent:
        public void HandleDefenderNotificationEvent(AC1Legacy.PStringBase<char>* attackers_name, DAMAGE_TYPE dtype, Double php, int hp, int part, int critical, Int64 attack_conditions) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, AC1Legacy.PStringBase<char>*, DAMAGE_TYPE, Double, int, int, int, Int64, void>)0x0056D670)(ref this, attackers_name, dtype, php, hp, part, critical, attack_conditions); // .text:0056C920 ; void __thiscall ClientCombatSystem::HandleDefenderNotificationEvent(ClientCombatSystem *this, AC1Legacy::PStringBase<char> *attackers_name, DAMAGE_TYPE dtype, const long double php, const int hp, const int part, const int critical, const __int64 attack_conditions) .text:0056C920 ?HandleDefenderNotificationEvent@ClientCombatSystem@@QAEXABV?$PStringBase@D@AC1Legacy@@W4DAMAGE_TYPE@@NJJH_J@Z

        // ClientCombatSystem.AttemptStartBuildingAttack:
        public void AttemptStartBuildingAttack() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056C850)(ref this); // .text:0056BB00 ; void __thiscall ClientCombatSystem::AttemptStartBuildingAttack(ClientCombatSystem *this) .text:0056BB00 ?AttemptStartBuildingAttack@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.AutoTarget:
        public void AutoTarget() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056C9D0)(ref this); // .text:0056BC80 ; void __thiscall ClientCombatSystem::AutoTarget(ClientCombatSystem *this) .text:0056BC80 ?AutoTarget@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.GetCombatSystem:
        public static ClientCombatSystem* GetCombatSystem() => ((delegate* unmanaged[Cdecl]<ClientCombatSystem*>)0x0056B210)(); // .text:0056A4D0 ; ClientCombatSystem *__cdecl ClientCombatSystem::GetCombatSystem() .text:0056A4D0 ?GetCombatSystem@ClientCombatSystem@@SAPAV1@XZ

        // ClientCombatSystem.OnStartup:
        public void OnStartup() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B220)(ref this); // .text:0056A4E0 ; void __thiscall ClientCombatSystem::OnStartup(ClientCombatSystem *this) .text:0056A4E0 ?OnStartup@ClientCombatSystem@@MAEXXZ

        // ClientCombatSystem.CompatibleCombatMode:
        public Byte CompatibleCombatMode(COMBAT_MODE i_combatMode) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, COMBAT_MODE, Byte>)0x0056B2C0)(ref this, i_combatMode); // .text:0056A580 ; bool __thiscall ClientCombatSystem::CompatibleCombatMode(ClientCombatSystem *this, COMBAT_MODE i_combatMode) .text:0056A580 ?CompatibleCombatMode@ClientCombatSystem@@QAE_NW4COMBAT_MODE@@@Z

        // ClientCombatSystem.RegisterInputMaps:
        public void RegisterInputMaps(COMBAT_MODE i_CurrentMode, COMBAT_MODE i_PreviousMode) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, COMBAT_MODE, COMBAT_MODE, void>)0x0056B760)(ref this, i_CurrentMode, i_PreviousMode); // .text:0056AA20 ; void __thiscall ClientCombatSystem::RegisterInputMaps(ClientCombatSystem *this, COMBAT_MODE i_CurrentMode, COMBAT_MODE i_PreviousMode) .text:0056AA20 ?RegisterInputMaps@ClientCombatSystem@@IAEXW4COMBAT_MODE@@0@Z

        // ClientCombatSystem.StartPowerBarBuild:
        public void StartPowerBarBuild() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BAF0)(ref this); // .text:0056ADB0 ; void __thiscall ClientCombatSystem::StartPowerBarBuild(ClientCombatSystem *this) .text:0056ADB0 ?StartPowerBarBuild@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.TrackTarget:
        public void TrackTarget(Byte i_bTrackTarget) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Byte, void>)0x0056BC10)(ref this, i_bTrackTarget); // .text:0056AED0 ; void __thiscall ClientCombatSystem::TrackTarget(ClientCombatSystem *this, bool i_bTrackTarget) .text:0056AED0 ?TrackTarget@ClientCombatSystem@@QAEX_N@Z

        // ClientCombatSystem.OnQualityChanged:
        public void OnQualityChanged(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, CWeenieObject*, StatType, UInt32, void>)0x0056CF00)(ref this, cwobj, stype, senum); // .text:0056C1B0 ; void __thiscall ClientCombatSystem::OnQualityChanged(ClientCombatSystem *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:0056C1B0 ?OnQualityChanged@ClientCombatSystem@@MAEXPAVCWeenieObject@@W4StatType@@K@Z

        // ClientCombatSystem.HandlePlayerDeathEvent:
        public int HandlePlayerDeathEvent(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void*, UInt32, int>)0x0056D070)(ref this, buff, size); // .text:0056C320 ; int __thiscall ClientCombatSystem::HandlePlayerDeathEvent(ClientCombatSystem *this, void *buff, unsigned int size) .text:0056C320 ?HandlePlayerDeathEvent@ClientCombatSystem@@QAEHPAXI@Z

        // ClientCombatSystem.HidePowerBar:
        public void HidePowerBar() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056B5F0)(ref this); // .text:0056A8B0 ; void __thiscall ClientCombatSystem::HidePowerBar(ClientCombatSystem *this) .text:0056A8B0 ?HidePowerBar@ClientCombatSystem@@IAEXXZ

        // ClientCombatSystem.GetJumpPowerLevel:
        public Single GetJumpPowerLevel() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Single>)0x0056BD90)(ref this); // .text:0056B050 ; float __thiscall ClientCombatSystem::GetJumpPowerLevel(ClientCombatSystem *this) .text:0056B050 ?GetJumpPowerLevel@ClientCombatSystem@@QBEMXZ

        // ClientCombatSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, void>)0x0056BDD0)(ref this); // .text:0056B090 ; void __thiscall ClientCombatSystem::ClientCombatSystem(ClientCombatSystem *this) .text:0056B090 ??0ClientCombatSystem@@QAE@XZ

        // ClientCombatSystem.DoJump:
        public void DoJump(Byte autonomous) => ((delegate* unmanaged[Thiscall]<ref ClientCombatSystem, Byte, void>)0x0056BE50)(ref this, autonomous); // .text:0056B110 ; void __thiscall ClientCombatSystem::DoJump(ClientCombatSystem *this, bool autonomous) .text:0056B110 ?DoJump@ClientCombatSystem@@QAEX_N@Z

        // Globals:
        public static ClientCombatSystem* s_pCombatSystem = *(ClientCombatSystem**)0x0087166C; // .data:0087065C ; ClientCombatSystem *ClientCombatSystem::s_pCombatSystem .data:0087065C ?s_pCombatSystem@ClientCombatSystem@@1PAV1@A
    }


}
