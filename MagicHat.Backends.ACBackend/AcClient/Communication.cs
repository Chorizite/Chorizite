using System;

namespace AcClient {

    public unsafe struct ClientCommunicationSystem {
        public ClientSystem clientSystem;
        public QualityChangeHandler qualityChangeHandler;
        public Turbine_RefCount m_cTurbineRefCount;
        public IntrusiveHashTable_CaseInsensitiveStringBase_PStringBase_Char__ClientCommunicationSystem__CmdHashData__1_ m_hashCommands;
        public PStringBase<Char> m_strLastCommandLine;
        public PStringBase<Char> m_strCurrentCommand;
        public UInt32 m_idCurrentCommandSource;
        public Int32 m_LastSpamCheck;
        public Int32 m_ChatMessageCount;
        public PStringBase<Char> m_strLogName;



        // public  () => ((def_)Marshal.GetDelegateForFunctionPointer((IntPtr)0x, typeof(def_)))(This, ); // 
        // [UnmanagedFunctionPointer(CallingConvention.ThisCall)] internal delegate  def_(* This, ); // 
        //
        //public void Begin() => ((def_Begin)Marshal.GetDelegateForFunctionPointer((IntPtr)0x0056B1A0, typeof(def_Begin)))(This); // .text:0056B1A0 ; protected: void __thiscall ClientCombatSystem::Begin(void)
        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)] internal delegate void def_Begin(ClientCombatSystem* This); // void __thiscall ClientCombatSystem::Begin(ClientCombatSystem* This); // idb
        ////Down j   ClientCombatSystem__OnEndCharacterSession+3B jmp     ClientCombatSystem__Begin
        ////Down    j ClientCombatSystem__OnEndCharacterSession+4F	jmp ClientCombatSystem__Begin
        ////Down p   ClientCombatSystem__ClientCombatSystem+41	call ClientCombatSystem__Begin


        //public static ClientCommunicationSystem* This = (ClientCommunicationSystem*)*(Int32*)0x00000000; // .data:00870BE4 ; void *CCommunicationSystem::s_pInstance
                                                                                                       // struct ClientCommunicationSystem *ClientCommunicationSystem::s_pCommunicationSystem


        /*(0056E480)
ClientCommunicationSystem *__cdecl ClientCommunicationSystem::GetCommunicationSystem(); // idb
void __thiscall ClientCommunicationSystem::OnBeginCharacterSession(ClientCommunicationSystem *this); // idb
void __thiscall ClientCommunicationSystem::OnEndCharacterSession(ClientCommunicationSystem *this); // idb
UInt32 __stdcall ClientCommunicationSystem::Handle_Communication__Recv_ChatRoomTracker(ChatRoomTracker *chatRoomTracker);
UInt32 __stdcall ClientCommunicationSystem::Handle_Communication__HearRangedSpeech(AC1Legacy::PStringBase<Char> *msg, AC1Legacy::PStringBase<Char> *name, UInt32 sender_id, Single range, UInt32 ltt);
bool __thiscall ClientCommunicationSystem::IsMessageSpam(ClientCommunicationSystem *this, Int32 wait_time);
Char __stdcall ClientCommunicationSystem::HelpMessageTypes(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __stdcall ClientCommunicationSystem::DoBirth(Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoClear(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __stdcall ClientCommunicationSystem::DoChannelIndex(Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::EnableChatTalkFocuses(ClientCommunicationSystem *this);
TResult *__thiscall ClientCommunicationSystem::QueryInterface(ClientCommunicationSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface); // idb
void __thiscall ClientCommunicationSystem::RecvNotice_DisplayStringInfo(ClientCommunicationSystem *this, UInt32 type, StringInfo *msg); // idb
void __thiscall ClientCommunicationSystem::RecvNotice_PlayerDescReceived(ClientCommunicationSystem *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule); // idb
void __thiscall ClientCommunicationSystem::RecvNotice_PlayerOptionChanged(ClientCommunicationSystem *this, PlayerOption i_eOption); // idb
IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *__thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::`vector deleting destructor'(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, UInt32 a2);
void __thiscall ClientCommunicationSystem::~ClientCommunicationSystem(ClientCommunicationSystem *this); // idb
UInt32 __stdcall ClientCommunicationSystem::Handle_Communication__SetSquelchDB(SquelchDB *db);
void __thiscall ClientCommunicationSystem::CmdHashData::CmdHashData(ClientCommunicationSystem::CmdHashData *this, CaseInsensitiveStringBase<PStringBase<Char> > *name, bool (__thiscall *i_pfnFunc)(ClientCommunicationSystem *this, Int32, Char **), bool (__thiscall *i_pfnHelp)(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType, const Char *, PStringBase<Char> *), bool (__thiscall *i_pfnHelpa)(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType, const Char *, PStringBase<Char> *), Int32 a6);
Int32 __stdcall ClientCommunicationSystem::IsMessageSafe(PStringBase<Char> *msg);
bool __thiscall ClientCommunicationSystem::DoAllegianceHometown(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __stdcall ClientCommunicationSystem::DoAllegianceHouse(Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpStupidChannelHack(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __stdcall ClientCommunicationSystem::DoJoinChat(Int32 argc, Char **argv);
bool __stdcall ClientCommunicationSystem::DoLeaveChat(Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::DoChatToggle(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoNoTell(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::DoLifestone(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoMarketplace(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoFillComponents(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoSaveUI(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoLoadUI(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoSaveAutoUI(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoLoadAutoUI(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoLockUI(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::DoHouseRecall(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoMansionRecall(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::DoHouseAvailableList(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoDay(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoFrameRate(ClientCommunicationSystem *this, Int32 argc, Char **argv);
UInt32 __thiscall ClientCommunicationSystem::Release(ClientCommunicationSystem *this); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__ChannelBroadcast(ClientCommunicationSystem *this, UInt32 chanID, AC1Legacy::PStringBase<Char> *senderName, AC1Legacy::PStringBase<Char> *msg); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Character__QueryAgeResponse(ClientCommunicationSystem *this, AC1Legacy::PStringBase<Char> *targetName, AC1Legacy::PStringBase<Char> *age); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__HearSpeech(ClientCommunicationSystem *this, AC1Legacy::PStringBase<Char> *msg, AC1Legacy::PStringBase<Char> *name, UInt32 sender_id, UInt32 ltt); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__HearDirectSpeech(ClientCommunicationSystem *this, AC1Legacy::PStringBase<Char> *msg, AC1Legacy::PStringBase<Char> *name, UInt32 sender_id, UInt32 target_id, UInt32 ltt, UInt32 secretFlags); // idb
void __thiscall ClientCommunicationSystem::HandleFailureEvent(ClientCommunicationSystem *this, UInt32 etype, PStringBase<UInt16> *user_data); // idb
Char __thiscall ClientCommunicationSystem::DoAllegianceChat(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __stdcall ClientCommunicationSystem::DoAllegianceBroadcast(Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoAllegianceBan(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoAllegianceInfo(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::DoAllegianceOfficer(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoAllegianceOfficerTitle(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __stdcall ClientCommunicationSystem::DoAllegianceName(Int32 argc, Char **argv);
bool __stdcall ClientCommunicationSystem::DoAllegianceLock(Int32 argc, Char **argv);
bool __stdcall ClientCommunicationSystem::DoMotd(Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpMotd(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpSpeaker(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpChannelsGroup(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __thiscall ClientCommunicationSystem::DoChannelCommand(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::HelpJoinChat(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpLeaveChat(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_Allegiance(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_General(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_Trade(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_LFG(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_Roleplay(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_Olthoi(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpTurbineChat_Society(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpChatToggle(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpNoTell(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoReply(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpReply(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoReTell(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpReTell(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpSay(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoTell(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpTell(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpAFK(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpConsent(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoCorpse(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpCorpse(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpDie(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpLifestone(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpMarketplace(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoPermit(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpPermit(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoPKArena(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::HelpPKArena(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoPKLArena(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::HelpPKLArena(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::DoEmote(Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpEmote(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpEmoteList(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpFillComponents(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpSaveUI(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpLoadUI(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpSaveAutoUI(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpLoadAutoUI(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpLockUI(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpFriends(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoFriendsAdd(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoFriendsRemove(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoHouseGuests(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoHouseStorage(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoHouseBoot(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpHouse(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpHouseAvailableList(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpAdvancedSquelch(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpAdvancedUnSquelch(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::ProcessSquelChargs(ClientCommunicationSystem *this, Int32 argc, Char **argv, bool requires_name_output, bool *is_zoneid, PStringBase<Char> *name, UInt32 *mask);
Char __thiscall ClientCommunicationSystem::DoMessageTypes(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::HelpAge(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpBirth(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpDay(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpEndurance(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpFrameRate(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoLoc(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpLoc(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoPKLite(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __stdcall ClientCommunicationSystem::HelpPKLite(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpVersion(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::HelpClear(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __thiscall ClientCommunicationSystem::DoTitle(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::HelpTitle(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpFilter(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpUnFilter(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::HelpLoadFile(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __stdcall ClientCommunicationSystem::DoSetOutputHelp(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __thiscall ClientCommunicationSystem::DoChannelList(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoChannelOn(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoChannelOff(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char ClientCommunicationSystem::PlayerIsPSR();
Char __thiscall ClientCommunicationSystem::CloseLogFile(ClientCommunicationSystem *this);
Char __thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::grow(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this);
void __thiscall ClientCommunicationSystem::OnShutdown(ClientCommunicationSystem *this); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__WeenieError(ClientCommunicationSystem *this, UInt32 etype); // idb
Char __stdcall ClientCommunicationSystem::HelpAllegiance(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoAllegianceBoot(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::DoStupidChannelHack(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __stdcall ClientCommunicationSystem::HelpChattingGroup(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoAFK(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::HelpDeathGroup(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
void __cdecl ClientCommunicationSystem::DieDialogCallback(PropertyCollection *i_rcResults); // idb
Char __thiscall ClientCommunicationSystem::DoEmoteList(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoFriends(ClientCommunicationSystem *this, Int32 argc, Char **argv);
void __cdecl ClientCommunicationSystem::HouseAbandonDialogCallback_Second(PropertyCollection *i_rcResults); // idb
bool __thiscall ClientCommunicationSystem::DoSquelch(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoUnSquelch(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::HelpSquelch(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::PerformGlobalSquelchMod(ClientCommunicationSystem *this, Int32 argc, Char **argv, bool add);
Char __thiscall ClientCommunicationSystem::HelpStatusGroup(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __stdcall ClientCommunicationSystem::DoAge(Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoEndurance(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::HelpTextGroup(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoFilter(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoUnFilter(ClientCommunicationSystem *this, Int32 argc, Char **argv);
BOOL __thiscall ClientCommunicationSystem::StartCopyOutputToFile(ClientCommunicationSystem *this, PStringBase<Char> *file);
void __thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, UInt32 _numBuckets); // idb
void __thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::add_internal(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, ClientCommunicationSystem::CmdHashData *data); // idb
Char __thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::resize_internal(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, UInt32 _numBuckets);
void __thiscall ClientCommunicationSystem::OnQualityChanged(ClientCommunicationSystem *this, CWeenieObject *cwobj, StatType stype, UInt32 senum); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__WeenieErrorWithString(ClientCommunicationSystem *this, UInt32 etype, AC1Legacy::PStringBase<Char> *user_data); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__HearEmote(ClientCommunicationSystem *this, UInt32 sender, AC1Legacy::PStringBase<Char> *name, AC1Legacy::PStringBase<Char> *msg); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__HearSoulEmote(ClientCommunicationSystem *this, UInt32 sender, AC1Legacy::PStringBase<Char> *name, AC1Legacy::PStringBase<Char> *msg); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__ChannelIndex(ClientCommunicationSystem *this, PackableList<AC1Legacy::PStringBase<Char> > *index); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__ChannelList(ClientCommunicationSystem *this, PackableList<AC1Legacy::PStringBase<Char> > *list); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__TextboxString(ClientCommunicationSystem *this, AC1Legacy::PStringBase<Char> *msg, UInt32 ltt); // idb
UInt32 __thiscall ClientCommunicationSystem::Handle_Communication__TransientString(ClientCommunicationSystem *this, AC1Legacy::PStringBase<Char> *msg); // idb
Char __stdcall ClientCommunicationSystem::HelpAllegiancesGroup(ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoAllegiance(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoSpeaker(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::SendTurbineChat(ClientCommunicationSystem *this, UInt32 roomID, ChatTypeEnum chatType, PStringBase<Char> *message, bool isListening); // idb
Char __thiscall ClientCommunicationSystem::DoConsent(ClientCommunicationSystem *this, Int32 argc, Char **argv);
bool __thiscall ClientCommunicationSystem::DoRenderOption(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::DoVersion(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::DoCommand(ClientCommunicationSystem *this);
Char __thiscall ClientCommunicationSystem::DoSetOutput(ClientCommunicationSystem *this, Int32 argc, Char **argv);
void __thiscall ClientCommunicationSystem::RecvNotice_DisplayWeenieError(ClientCommunicationSystem *this, UInt32 etype, AC1Legacy::PStringBase<Char> *user_data); // idb
Char __thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::add(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, ClientCommunicationSystem::CmdHashData *data);
ClientCommunicationSystem::CmdHashData *__thiscall IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char>>,ClientCommunicationSystem::CmdHashData *,1>::remove(IntrusiveHashTable<CaseInsensitiveStringBase<PStringBase<Char> >,ClientCommunicationSystem::CmdHashData *,1> *this, CaseInsensitiveStringBase<PStringBase<Char> > *key); // idb
Char __thiscall ClientCommunicationSystem::HelpAllGroup(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType type, const Char *argv0, PStringBase<Char> *msg);
bool __thiscall ClientCommunicationSystem::DoTurbineChat_Allegiance(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_General(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_Trade(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_LFG(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_Roleplay(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_Olthoi(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
bool __thiscall ClientCommunicationSystem::DoTurbineChat_Society(ClientCommunicationSystem *this, Int32 argc, Char **argv); // idb
Char __thiscall ClientCommunicationSystem::StartupTurbineChatSystem(ClientCommunicationSystem *this);
Char __thiscall ClientCommunicationSystem::DoHelp(ClientCommunicationSystem *this, Int32 argc, Char **argv);
UInt32 __stdcall ClientCommunicationSystem::Handle_Communication__PopUpString(AC1Legacy::PStringBase<Char> *msg);
Char __thiscall ClientCommunicationSystem::DoDie(ClientCommunicationSystem *this, Int32 argc, Char **argv);
void __cdecl ClientCommunicationSystem::HouseAbandonDialogCallback_First(PropertyCollection *i_rcResults); // idb
Char __thiscall ClientCommunicationSystem::Pose(ClientCommunicationSystem *this, PStringBase<Char> *pose_txt);
void __stdcall ClientCommunicationSystem::MakeLoadFileVariableSubstitutions(PStringBase<Char> *lineStr);
Char __thiscall ClientCommunicationSystem::DoHouse(ClientCommunicationSystem *this, Int32 argc, Char **argv);
void __thiscall ClientCommunicationSystem::RemoveTextBetween(ClientCommunicationSystem *this, PStringBaseIter<Char> *iter, Char first, Char second); // idb
void __thiscall ClientCommunicationSystem::PublicChat(ClientCommunicationSystem *this, PStringBase<Char> *input); // idb
Char __thiscall ClientCommunicationSystem::DoSay(ClientCommunicationSystem *this, Int32 argc, Char **argv);
Char __thiscall ClientCommunicationSystem::OnChatCommand(ClientCommunicationSystem *this, PStringBase<UInt16> *i_strLine, UInt32 i_idCommandSource);
Char __thiscall ClientCommunicationSystem::LoadFile(ClientCommunicationSystem *this, PStringBase<Char> *fileName);
Char __thiscall ClientCommunicationSystem::DoLoadFile(ClientCommunicationSystem *this, Int32 argc, Char **argv);
void __thiscall ClientCommunicationSystem::InitializeCommands(ClientCommunicationSystem *this); // idb
void __thiscall ClientCommunicationSystem::ClientCommunicationSystem(ClientCommunicationSystem *this); // idb


        */


    };

    public unsafe struct ClientCommunicationSystem__CmdHashData {
        public UInt32 m_hashKey;
        public ClientCommunicationSystem__CmdHashData* m_hashNext;
        //bool (__thiscall *func)(ClientCommunicationSystem *this, Int32, Char **);
        //bool (__thiscall *help)(ClientCommunicationSystem *this, ClientCommunicationSystem::HelpType, const Char *, PStringBase<Char> *) __declspec(align(8));
    };


    public unsafe struct IntrusiveHashTable_CaseInsensitiveStringBase_PStringBase_Char__ClientCommunicationSystem__CmdHashData__1_ {
        public _Vtbl* vfptr;
        public fixed Int32 m_aInplaceBuckets[23]; // ClientCommunicationSystem__CmdHashData *
        public ClientCommunicationSystem__CmdHashData** m_buckets;
        public ClientCommunicationSystem__CmdHashData** m_firstInterestingBucket;
        public UInt32 m_numBuckets;
        public UInt32 m_numElements;
    };
    public unsafe struct IntrusiveHashData_CaseInsensitiveStringBase_PStringBase_Char__ClientCommunicationSystem__CmdHashData__ {
        public CaseInsensitiveStringBase<PStringBase<Char>> m_hashKey;
        public ClientCommunicationSystem__CmdHashData* m_hashNext;
    };

    public unsafe struct IntrusiveHashIterator_CaseInsensitiveStringBase_PStringBase_Char__ClientCommunicationSystem__CmdHashData__1_ {
        public IntrusiveHashTable_CaseInsensitiveStringBase_PStringBase_Char__ClientCommunicationSystem__CmdHashData__1_* m_currHashTable;
        public ClientCommunicationSystem__CmdHashData** m_currBucket;
        public ClientCommunicationSystem__CmdHashData* m_currElement;
    };












}