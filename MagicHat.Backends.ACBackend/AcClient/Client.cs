using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct Client { // EOR = 312Bytes
        // Struct:
        public Interface a0;
        public ArgumentParser ArgumentParser;
        public CDDDStatusPlugin CDDDStatusPlugin;
        public IInputActionCallback IInputActionCallback;
        public LinkStatusHolder LinkStatusHolder;
        public Turbine_RefCount m_cTurbineRefCount;
        public PStringBase<Char> m_FullOutputText;
        public PStringBase<Char> m_preferencesFile;
        public Int32 m_fWindowed;
        public Int32 m_fUseMemoryManager;
        public Int32 m_fReadOnlyDatFiles;
        public accountID m_account;
        public PStringBase<Char> m_pPrimer;
        public PStringBase<Char> m_LanguageStr;
        public PStringBase<Char> m_hostName;
        public Int32 m_noflowqueue;
        public Int32 m_port;
        public Int32 m_clientPort;
        public Int32 m_latencyDelay;
        public Int32 m_latencyPercent;
        public Int32 m_Language;
        public PStringBase<UInt16> m_worldName;
        public Int32* m_pDBCache; // CLCache*
        public UIFlow* m_ui;
        public Int32 m_connected;
        public NetAuthenticator m_netAuth;
        public ClientNet* m_net;
        public GlobalEventHandler* m_eventHandler;
        public QualityRegistrar* m_qualityRegistrar;
        public PStringBase<Char> m_strPreferenceBindInterface;
        public Int32 m_bPreferenceComputeUniquePort;
        public UInt32 m_nPreferenceUserSpecifiedPort;
        public IQueuedUIEventDeliverer* m_UIQueueManager;
        public NetAuthenticator* pNetAuth_;
        public SmartBox* smartbox_;
        public NIList<NetBlob>* m_logonEventQueue;
        public PacketController* packControl_;
        public NIList<NetBlob>** netQueues_;
        public AlreadyRunningCheck m_running_check;
        public override string ToString() => $"a0:{a0}, ArgumentParser:{ArgumentParser}, CDDDStatusPlugin:{CDDDStatusPlugin}, IInputActionCallback:{IInputActionCallback}, LinkStatusHolder:{LinkStatusHolder}, m_cTurbineRefCount:{m_cTurbineRefCount} m_FullOutputText:{m_FullOutputText}, m_preferencesFile:{m_preferencesFile}, m_fWindowed:{m_fWindowed}, m_fUseMemoryManager:{m_fUseMemoryManager}, m_fReadOnlyDatFiles:{m_fReadOnlyDatFiles}, m_account(accountID):{m_account}, m_pPrimer:{m_pPrimer}, m_LanguageStr:{m_LanguageStr}, m_hostName:{m_hostName}, m_noflowqueue:{m_noflowqueue}, m_port:{m_port}, m_clientPort:{m_clientPort}, m_latencyDelay:{m_latencyDelay}, m_latencyPercent:{m_latencyPercent}, m_Language:{m_Language}, m_worldName:{m_worldName}, m_pDBCache:->(CLCache*)0x{(Int32)m_pDBCache:X8}, m_ui:->(UIFlow*)0x{(Int32)m_ui:X8}, m_connected:{m_connected:X2}, m_netAuth:{m_netAuth}, m_net:->(ClientNet*)0x{(Int32)m_net:X8}, m_eventHandler:->(GlobalEventHandler*)0x{(Int32)m_eventHandler:X8}, m_qualityRegistrar:->(QualityRegistrar*)0x{(Int32)m_qualityRegistrar:X8}, m_strPreferenceBindInterface:{m_strPreferenceBindInterface}, m_bPreferenceComputeUniquePort:{m_bPreferenceComputeUniquePort:X2}, m_nPreferenceUserSpecifiedPort:{m_nPreferenceUserSpecifiedPort:X8}, m_UIQueueManager:->(IQueuedUIEventDeliverer*)0x{(Int32)m_UIQueueManager:X8}, pNetAuth_:->(NetAuthenticator*)0x{(Int32)pNetAuth_:X8}, smartbox_:->(SmartBox*)0x{(Int32)smartbox_:X8}, m_logonEventQueue:->(NIList<NetBlob*>*)0x{(Int32)m_logonEventQueue:X8}, packControl_:->(PacketController*)0x{(Int32)packControl_:X8}, netQueues_:->(NIList<NetBlob*>**)0x{(Int32)netQueues_:X8}, m_running_check(AlreadyRunningCheck):{m_running_check}";


        // Functions:

        // Client.Release:
        public static delegate* unmanaged[Thiscall]<Client*, UInt32> Release = (delegate* unmanaged[Thiscall]<Client*, UInt32>)0x00401E70; // .text:00401D40 ; UInt32 __thiscall Client::Release(Client *this) .text:00401D40 ?Release@Client@@UBEKXZ

        // Client.GetNameRuleLanguage:
        public static delegate* unmanaged[Thiscall]<Client*, UInt32> GetNameRuleLanguage = (delegate* unmanaged[Thiscall]<Client*, UInt32>)0x004116B0; // .text:00411350 ; UInt32 __thiscall Client::GetNameRuleLanguage(Client *this) .text:00411350 ?GetNameRuleLanguage@Client@@UBEKXZ

        // Client.InitUI:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*, Byte> InitUI = (delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*, Byte>)0x004119C0; // .text:00411660 ; bool __thiscall Client::InitUI(Client *this, PStringBase<Char> *windowTitle) .text:00411660 ?InitUI@Client@@MAE_NABV?$PStringBase@D@@@Z

        // Client.SetLanguage:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*> SetLanguage = (delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*>)0x00411B50; // .text:004117F0 ; void __thiscall Client::SetLanguage(Client *this, PStringBase<Char> *_lang) .text:004117F0 ?SetLanguage@Client@@UAEXABV?$PStringBase@D@@@Z

        // Client.EvaluateCommandLineArg:
        public static delegate* unmanaged[Thiscall]<Client*, CommandLineArg*, PStringBase<Char>*, Byte> EvaluateCommandLineArg = (delegate* unmanaged[Thiscall]<Client*, CommandLineArg*, PStringBase<Char>*, Byte>)0x00412850; // .text:004124F0 ; bool __thiscall Client::EvaluateCommandLineArg(Client *this, CommandLineArg *ArgData, PStringBase<Char> *arg) .text:004124F0 ?EvaluateCommandLineArg@Client@@UAE_NABUCommandLineArg@@ABV?$PStringBase@D@@@Z

        // Client.__Ctor:
        public static delegate* unmanaged[Thiscall]<Client*> __Ctor = (delegate* unmanaged[Thiscall]<Client*>)0x00412E50; // .text:00412AF0 ; void __thiscall Client::Client(Client *this) .text:00412AF0 ??0Client@@QAE@XZ

        // Client.GetHostName:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*> GetHostName = (delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*>)0x00401DA0; // .text:00401C70 ; PStringBase<Char> *__thiscall Client::GetHostName(Client *this) .text:00401C70 ?GetHostName@Client@@UBEABV?$PStringBase@D@@XZ

        // Client.CleanupDatabase:
        public static delegate* unmanaged[Thiscall]<Client*> CleanupDatabase = (delegate* unmanaged[Thiscall]<Client*>)0x00411560; // .text:00411200 ; void __thiscall Client::CleanupDatabase(Client *this) .text:00411200 ?CleanupDatabase@Client@@MAEXXZ

        // Client.InitAuth:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> InitAuth = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x004115D0; // .text:00411270 ; bool __thiscall Client::InitAuth(Client *this) .text:00411270 ?InitAuth@Client@@MAE_NXZ

        // Client.Cleanup:
        public static delegate* unmanaged[Thiscall]<Client*> Cleanup = (delegate* unmanaged[Thiscall]<Client*>)0x004118D0; // .text:00411570 ; void __thiscall Client::Cleanup(Client *this) .text:00411570 ?Cleanup@Client@@UAEXXZ

        // Client.ProcessLogonEventQueue:
        public static delegate* unmanaged[Thiscall]<Client*> ProcessLogonEventQueue = (delegate* unmanaged[Thiscall]<Client*>)0x00411C20; // .text:004118C0 ; void __thiscall Client::ProcessLogonEventQueue(Client *this) .text:004118C0 ?ProcessLogonEventQueue@Client@@IAEXXZ

        // Client.UseTime:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> UseTime = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x00411FA0; // .text:00411C40 ; bool __thiscall Client::UseTime(Client *this) .text:00411C40 ?UseTime@Client@@UAE_NXZ

        // Client.CleanupNet:
        public static delegate* unmanaged[Thiscall]<Client*> CleanupNet = (delegate* unmanaged[Thiscall]<Client*>)0x00412060; // .text:00411D00 ; void __thiscall Client::CleanupNet(Client *this) .text:00411D00 ?CleanupNet@Client@@MAEXXZ

        // Client.FinishOutputText:
        public static delegate* unmanaged[Thiscall]<Client*> FinishOutputText = (delegate* unmanaged[Thiscall]<Client*>)0x00412A80; // .text:00412720 ; void __thiscall Client::FinishOutputText(Client *this) .text:00412720 ?FinishOutputText@Client@@UAEXXZ

        // Client.SetPortA:
        public static delegate* unmanaged[Thiscall]<PlayerModule*, UInt32> SetPortA = (delegate* unmanaged[Thiscall]<PlayerModule*, UInt32>)0x00401DC0; // .text:00401C90 ; void __thiscall Client::SetPortA(PlayerModule *this, UInt32 filters) .text:00401C90 ?SetPortA@Client@@UAEXJ@Z

        // Client.Connect:
        public static delegate* unmanaged[Thiscall]<Client*, NetError*, NetError*> Connect = (delegate* unmanaged[Thiscall]<Client*, NetError*, NetError*>)0x00413180; // .text:00412E20 ; NetError *__thiscall Client::Connect(Client *this, NetError *result) .text:00412E20 ?Connect@Client@@UAE?AVNetError@@XZ

        // Client.IsAlreadyRunning:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> IsAlreadyRunning = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x004122A0; // .text:00411F40 ; bool __thiscall Client::IsAlreadyRunning(Client *this) .text:00411F40 ?IsAlreadyRunning@Client@@MAE_NXZ

        // Client.InitPreferences:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> InitPreferences = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x00412310; // .text:00411FB0 ; bool __thiscall Client::InitPreferences(Client *this) .text:00411FB0 ?InitPreferences@Client@@MAE_NXZ

        // Client.BuildCommandLineArgs:
        public static delegate* unmanaged[Thiscall]<Client*, ArgumentParser.CommandLineArgList*> BuildCommandLineArgs = (delegate* unmanaged[Thiscall]<Client*, ArgumentParser.CommandLineArgList*>)0x00412420; // .text:004120C0 ; void __thiscall Client::BuildCommandLineArgs(Client *this, ArgumentParser::CommandLineArgList *Args) .text:004120C0 ?BuildCommandLineArgs@Client@@UAEXAAVCommandLineArgList@ArgumentParser@@@Z

        // Client.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<Client*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<Client*, UInt32, void*>)0x00413040; // .text:00412CE0 ; void *__thiscall Client::`scalar deleting destructor'(Client *this, UInt32) .text:00412CE0 ??_GClient@@MAEPAXI@Z

        // Client.CleanupPreferences:
        public static delegate* unmanaged[Thiscall]<Client*> CleanupPreferences = (delegate* unmanaged[Thiscall]<Client*>)0x004115A0; // .text:00411240 ; void __thiscall Client::CleanupPreferences(Client *this) .text:00411240 ?CleanupPreferences@Client@@MAEXXZ

        // Client.SetHostName:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*> SetHostName = (delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*>)0x004021E0; // .text:00402040 ; void __thiscall Client::SetHostName(Client *this, PStringBase<Char> *newName) .text:00402040 ?SetHostName@Client@@UAEXABV?$PStringBase@D@@@Z

        // Client.OnDDDEvent:
        public static delegate* unmanaged[Thiscall]<Client*, DDDEvent, UInt32> OnDDDEvent = (delegate* unmanaged[Thiscall]<Client*, DDDEvent, UInt32>)0x00411BA0; // .text:00411840 ; void __thiscall Client::OnDDDEvent(Client *this, DDDEvent evtNum, UInt32 nBytes) .text:00411840 ?OnDDDEvent@Client@@UAEXW4DDDEvent@@I@Z

        // Client.RemoveDDDStatusPlugin:
        public static delegate* unmanaged[Thiscall]<Client*, CDDDStatusPlugin*, Byte> RemoveDDDStatusPlugin = (delegate* unmanaged[Thiscall]<Client*, CDDDStatusPlugin*, Byte>)0x00412AC0; // .text:00412760 ; bool __thiscall Client::RemoveDDDStatusPlugin(Client *this, CDDDStatusPlugin *i_pPlugin) .text:00412760 ?RemoveDDDStatusPlugin@Client@@UAE_NPAVCDDDStatusPlugin@@@Z

        // Client.__Dtor:
        public static delegate* unmanaged[Thiscall]<Client*> __Dtor = (delegate* unmanaged[Thiscall]<Client*>)0x00412B70; // .text:00412810 ; void __thiscall Client::~Client(Client *this) .text:00412810 ??1Client@@MAE@XZ

        // Client.QueryInterface:
        public static delegate* unmanaged[Thiscall]<Client*, TResult*, Turbine_GUID*, void**, TResult*> QueryInterface = (delegate* unmanaged[Thiscall]<Client*, TResult*, Turbine_GUID*, void**, TResult*>)0x00401E00; // .text:00401CD0 ; TResult *__thiscall Client::QueryInterface(Client *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppObject) .text:00401CD0 ?QueryInterface@Client@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // Client.CleanupUI:
        public static delegate* unmanaged[Thiscall]<Client*> CleanupUI = (delegate* unmanaged[Thiscall]<Client*>)0x004114D0; // .text:00411170 ; void __thiscall Client::CleanupUI(Client *this) .text:00411170 ?CleanupUI@Client@@MAEXXZ

        // Client.Disconnect:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> Disconnect = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x004115F0; // .text:00411290 ; bool __thiscall Client::Disconnect(Client *this) .text:00411290 ?Disconnect@Client@@UAE_NXZ

        // Client.Run:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> Run = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x00411B10; // .text:004117B0 ; bool __thiscall Client::Run(Client *this) .text:004117B0 ?Run@Client@@UAE_NXZ

        //        // Client.__vecDelDtor`adjustor{8}':
        //        public static delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*> __vecDelDtor`adjustor{8}' = (delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*>)0x00412D80; // .text:00412A20 ; [thunk]:protected: virtual void * __thiscall Client::`vector deleting destructor'`adjustor{8}
        //' (UInt32) .text:00412A20 ??_EClient@@O7AEPAXI@Z

        //    // Client.__vecDelDtor`adjustor{12}':
        //    public static delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*> __vecDelDtor`adjustor { 12}
        //' = (delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*>)0x00412D90; // .text:00412A30 ; [thunk]:protected: virtual void * __thiscall Client::`vector deleting destructor'`adjustor { 12}
        //' (UInt32) .text:00412A30 ??_EClient@@OM@AEPAXI@Z

        // Client.GetWorldName:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<UInt16>*> GetWorldName = (delegate* unmanaged[Thiscall]<Client*, PStringBase<UInt16>*>)0x00401DD0; // .text:00401CA0 ; PStringBase<UInt16> *__thiscall Client::GetWorldName(Client *this) .text:00401CA0 ?GetWorldName@Client@@UBEABV?$PStringBase@G@@XZ

        // Client.SetAccountName:
        // public static delegate* unmanaged[Thiscall]<Client*,accountID*> SetAccountName = (delegate* unmanaged[Thiscall]<Client*,accountID*>)0xDEADBEEF; // .text:004032B0 ; void __thiscall Client::SetAccountName(Client *this, accountID *account) .text:004032B0 ?SetAccountName@Client@@UAEXABVaccountID@@@Z

        // Client.Init:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*, Int32, Int32, Byte> Init = (delegate* unmanaged[Thiscall]<Client*, PStringBase<Char>*, Int32, Int32, Byte>)0x00412180; // .text:00411E20 ; bool __thiscall Client::Init(Client *this, PStringBase<Char> *windowTitle, const Int32 language_i, const Int32 region_i) .text:00411E20 ?Init@Client@@UAE_NABV?$PStringBase@D@@JJ@Z

        // Client.InitDatabase:
        public static delegate* unmanaged[Thiscall]<Client*, Int32, Int32, Byte, Byte> InitDatabase = (delegate* unmanaged[Thiscall]<Client*, Int32, Int32, Byte, Byte>)0x00413070; // .text:00412D10 ; bool __thiscall Client::InitDatabase(Client *this, const Int32 language_i, const Int32 region_i, bool open_readonly) .text:00412D10 ?InitDatabase@Client@@MAE_NJJ_N@Z

        // Client.AddDDDStatusPlugin:
        public static delegate* unmanaged[Thiscall]<Client*, CDDDStatusPlugin*, Byte> AddDDDStatusPlugin = (delegate* unmanaged[Thiscall]<Client*, CDDDStatusPlugin*, Byte>)0x00413450; // .text:004130F0 ; bool __thiscall Client::AddDDDStatusPlugin(Client *this, CDDDStatusPlugin *i_pPlugin) .text:004130F0 ?AddDDDStatusPlugin@Client@@UAE_NPAVCDDDStatusPlugin@@@Z

        // Client.GetInstance:
        // (ERR) .text:004114C0 ; public: static class Client * __cdecl Client::GetInstance(void) .text:004114C0 ?GetInstance@Client@@SAPAV1@XZ

        // Client.GetAccountName:
        public static delegate* unmanaged[Thiscall]<Client*, accountID*> GetAccountName = (delegate* unmanaged[Thiscall]<Client*, accountID*>)0x00401D90; // .text:00401C60 ; accountID *__thiscall Client::GetAccountName(Client *this) .text:00401C60 ?GetAccountName@Client@@UAEAAVaccountID@@XZ

        // Client.AppendOutputText:
        public static delegate* unmanaged[Thiscall]<Client*, Char*, ArgumentParser.OutputTextType> AppendOutputText = (delegate* unmanaged[Thiscall]<Client*, Char*, ArgumentParser.OutputTextType>)0x00412DA0; // .text:00412A40 ; void __thiscall Client::AppendOutputText(Client *this, const Char *Text, ArgumentParser::OutputTextType i_eFormattingHInt32) .text:00412A40 ?AppendOutputText@Client@@MAEXPBDW4OutputTextType@ArgumentParser@@@Z

        // Client.GetLanguage:
        public static delegate* unmanaged[Thiscall]<Client*, Int32> GetLanguage = (delegate* unmanaged[Thiscall]<Client*, Int32>)0x00411980; // .text:00411620 ; Int32 __thiscall Client::GetLanguage(Client *this) .text:00411620 ?GetLanguage@Client@@UBE?BJXZ

        // Client.SetWorldName:
        public static delegate* unmanaged[Thiscall]<Client*, PStringBase<UInt16>*> SetWorldName = (delegate* unmanaged[Thiscall]<Client*, PStringBase<UInt16>*>)0x00402230; // .text:00402090 ; void __thiscall Client::SetWorldName(Client *this, PStringBase<UInt16> *_worldName) .text:00402090 ?SetWorldName@Client@@UAEXABV?$PStringBase@G@@@Z

        // Client.KeepUIAlive:
        public static delegate* unmanaged[Thiscall]<Client*> KeepUIAlive = (delegate* unmanaged[Thiscall]<Client*>)0x00411630; // .text:004112D0 ; void __thiscall Client::KeepUIAlive(Client *this) .text:004112D0 ?KeepUIAlive@Client@@QAEXXZ

        // Client.GetCharactersToWrapUsageTo:
        public static delegate* unmanaged[Thiscall]<Client*, Int32> GetCharactersToWrapUsageTo = (delegate* unmanaged[Thiscall]<Client*, Int32>)0x004116A0; // .text:00411340 ; Int32 __thiscall Client::GetCharactersToWrapUsageTo(Client *this) .text:00411340 ?GetCharactersToWrapUsageTo@Client@@MAEHXZ

        // Client.AddNetQueue:
        public static delegate* unmanaged[Thiscall]<Client*, Int16, Int32> AddNetQueue = (delegate* unmanaged[Thiscall]<Client*, Int16, Int32>)0x00411AA0; // .text:00411740 ; Int32 __thiscall Client::AddNetQueue(Client *this, __Int3216 queueID) .text:00411740 ?AddNetQueue@Client@@IAEHF@Z

        // Client.InitNet:
        public static delegate* unmanaged[Thiscall]<Client*, Byte> InitNet = (delegate* unmanaged[Thiscall]<Client*, Byte>)0x00411E80; // .text:00411B20 ; bool __thiscall Client::InitNet(Client *this) .text:00411B20 ?InitNet@Client@@MAE_NXZ

        // Client.AddRef:
        public static delegate* unmanaged[Thiscall]<Client*, UInt32> AddRef = (delegate* unmanaged[Thiscall]<Client*, UInt32>)0x00401E60; // .text:00401D30 ; UInt32 __thiscall Client::AddRef(Client *this) .text:00401D30 ?AddRef@Client@@UBEKXZ

        // Globals:
        public static Client** m_instance = (Client**)0x008379E4; // .data:008369E4 ; Client *Client::m_instance .data:008369E4 ?m_instance@Client@@1PAV1@A
    }

    public unsafe struct gmClient {
        // Struct:
        public Client Client;
        public NoticeHandler NoticeHandler;
        public PStringBase<Char> m_startChar;
        public PStringBase<Char> m_createChar;
        public PStringBase<Char> m_strKeymapFile;
        public Byte m_bKeymapLoaded;
        public PStringBase<Char> m_strZoneTicket;
        public PStringBase<Char> m_strGLSTicket;
        public PStringBase<UInt16> m_wstrMigrationURL;
        public PStringBase<Char> m_strVGPassword;
        public override string ToString() => $"Client(Client):{Client}, NoticeHandler(NoticeHandler):{NoticeHandler}, m_startChar:{m_startChar}, m_createChar:{m_createChar}, m_strKeymapFile:{m_strKeymapFile}, m_bKeymapLoaded:{m_bKeymapLoaded:X2}, m_strZoneTicket:{m_strZoneTicket}, m_strGLSTicket:{m_strGLSTicket}, m_wstrMigrationURL(PStringBase<UInt16>):{m_wstrMigrationURL}, m_strVGPassword:{m_strVGPassword}";


        // Functions:

        // gmClient.GRPCallback_OnFontPreferenceChanged:
        public static delegate* unmanaged[Cdecl]<PStringBase<Char>*> GRPCallback_OnFontPreferenceChanged = (delegate* unmanaged[Cdecl]<PStringBase<Char>*>)0x00401900; // .text:004018F0 ; void __cdecl gmClient::GRPCallback_OnFontPreferenceChanged(PStringBase<Char> *_Name) .text:004018F0 ?GRPCallback_OnFontPreferenceChanged@gmClient@@KAXABV?$PStringBase@D@@@Z

        // gmClient.Connect:
        public static delegate* unmanaged[Thiscall]<gmClient*, NetError*, NetError*> Connect = (delegate* unmanaged[Thiscall]<gmClient*, NetError*, NetError*>)0x00402000; // .text:00401ED0 ; NetError *__thiscall gmClient::Connect(gmClient *this, NetError *result) .text:00401ED0 ?Connect@gmClient@@UAE?AVNetError@@XZ

        // gmClient.InitPreferences:
        public static delegate* unmanaged[Thiscall]<gmClient*, Byte> InitPreferences = (delegate* unmanaged[Thiscall]<gmClient*, Byte>)0x00403170; // .text:00402F90 ; bool __thiscall gmClient::InitPreferences(gmClient *this) .text:00402F90 ?InitPreferences@gmClient@@MAE_NXZ

        // gmClient.InitAuth:
        public static delegate* unmanaged[Thiscall]<gmClient*, Byte> InitAuth = (delegate* unmanaged[Thiscall]<gmClient*, Byte>)0x00403270; // .text:00403090 ; bool __thiscall gmClient::InitAuth(gmClient *this) .text:00403090 ?InitAuth@gmClient@@MAE_NXZ

        // gmClient.Disconnect:
        public static delegate* unmanaged[Thiscall]<gmClient*, Byte> Disconnect = (delegate* unmanaged[Thiscall]<gmClient*, Byte>)0x00401780; // .text:00401770 ; bool __thiscall gmClient::Disconnect(gmClient *this) .text:00401770 ?Disconnect@gmClient@@UAE_NXZ

        // gmClient.__Dtor:
        public static delegate* unmanaged[Thiscall]<gmClient*> __Dtor = (delegate* unmanaged[Thiscall]<gmClient*>)0x00401C50; // .text:00401B20 ; void __thiscall gmClient::~gmClient(gmClient *this) .text:00401B20 ??1gmClient@@MAE@XZ

        // gmClient.__vecDelDtor`adjustor{8}':
        //        public static delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*> __vecDelDtor`adjustor{8}' = (delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*>)0x00401DE0; // .text:00401CB0 ; [thunk]:protected: virtual void * __thiscall gmClient::`vector deleting destructor'`adjustor{8}
        //' (UInt32) .text:00401CB0 ??_EgmClient@@O7AEPAXI@Z

        // gmClient.Cleanup:
        public static delegate* unmanaged[Thiscall]<gmClient*> Cleanup = (delegate* unmanaged[Thiscall]<gmClient*>)0x00401EC0; // .text:00401D90 ; void __thiscall gmClient::Cleanup(gmClient *this) .text:00401D90 ?Cleanup@gmClient@@UAEXXZ

        // gmClient.BuildCommandLineArgs:
        public static delegate* unmanaged[Thiscall]<gmClient*, ArgumentParser.CommandLineArgList*> BuildCommandLineArgs = (delegate* unmanaged[Thiscall]<gmClient*, ArgumentParser.CommandLineArgList*>)0x00402A90; // .text:004028B0 ; void __thiscall gmClient::BuildCommandLineArgs(gmClient *this, ArgumentParser::CommandLineArgList *Args) .text:004028B0 ?BuildCommandLineArgs@gmClient@@UAEXAAVCommandLineArgList@ArgumentParser@@@Z

        // gmClient.OnDDDEvent:
        public static delegate* unmanaged[Thiscall]<gmClient*, DDDEvent, UInt32> OnDDDEvent = (delegate* unmanaged[Thiscall]<gmClient*, DDDEvent, UInt32>)0x00401790; // .text:00401780 ; void __thiscall gmClient::OnDDDEvent(gmClient *this, DDDEvent evtNum, UInt32 nBytes) .text:00401780 ?OnDDDEvent@gmClient@@UAEXW4DDDEvent@@I@Z

        // gmClient.EvaluateCommandLineArg:
        public static delegate* unmanaged[Thiscall]<gmClient*, CommandLineArg*, PStringBase<Char>*, Byte> EvaluateCommandLineArg = (delegate* unmanaged[Thiscall]<gmClient*, CommandLineArg*, PStringBase<Char>*, Byte>)0x00402DF0; // .text:00402C10 ; bool __thiscall gmClient::EvaluateCommandLineArg(gmClient *this, CommandLineArg *ArgData, PStringBase<Char> *arg) .text:00402C10 ?EvaluateCommandLineArg@gmClient@@UAE_NABUCommandLineArg@@ABV?$PStringBase@D@@@Z

        // gmClient.InitKeymap:
        public static delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*, Byte> InitKeymap = (delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*, Byte>)0x00402FE0; // .text:00402E00 ; bool __thiscall gmClient::InitKeymap(gmClient *this, PStringBase<Char> *i_strKeymapFilename) .text:00402E00 ?InitKeymap@gmClient@@UAE_NABV?$PStringBase@D@@@Z

        // gmClient.InitUIPreferences:
        public static delegate* unmanaged[Thiscall]<gmClient*> InitUIPreferences = (delegate* unmanaged[Thiscall]<gmClient*>)0x004037B0; // .text:004035B0 ; void __thiscall gmClient::InitUIPreferences(gmClient *this) .text:004035B0 ?InitUIPreferences@gmClient@@QAEXXZ

        // gmClient.RecvNotice_WorldName:
        public static delegate* unmanaged[Thiscall]<gmClient*, AC1Legacy.PStringBase<Char>*> RecvNotice_WorldName = (delegate* unmanaged[Thiscall]<gmClient*, AC1Legacy.PStringBase<Char>*>)0x00404AE0; // .text:004048E0 ; void __thiscall gmClient::RecvNotice_WorldName(gmClient *this, AC1Legacy::PStringBase<Char> *i_strName) .text:004048E0 ?RecvNotice_WorldName@gmClient@@UAEXABV?$PStringBase@D@AC1Legacy@@@Z

        // gmClient.__Ctor:
        public static delegate* unmanaged[Thiscall]<gmClient*> __Ctor = (delegate* unmanaged[Thiscall]<gmClient*>)0x00402810; // .text:00402630 ; void __thiscall gmClient::gmClient(gmClient *this) .text:00402630 ??0gmClient@@QAE@XZ

        // gmClient.DetachUIPreferences:
        public static delegate* unmanaged[Thiscall]<gmClient*> DetachUIPreferences = (delegate* unmanaged[Thiscall]<gmClient*>)0x004017E0; // .text:004017D0 ; void __thiscall gmClient::DetachUIPreferences(gmClient *this) .text:004017D0 ?DetachUIPreferences@gmClient@@QAEXXZ

        // gmClient.__vecDelDtor`adjustor{12}':
        //public static delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*> __vecDelDtor`adjustor { 12}
        //' = (delegate* unmanaged[Thiscall]<UInt32, [thunk]:void*>)0x00401DF0; // .text:00401CC0 ; [thunk]:protected: virtual void * __thiscall gmClient::`vector deleting destructor'`adjustor { 12}
        //' (UInt32) .text:00401CC0 ??_EgmClient@@OM@AEPAXI@Z

        // gmClient.SetKeyMapFileName:
        public static delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*> SetKeyMapFileName = (delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*>)0x00402020; // .text:00401EF0 ; void __thiscall gmClient::SetKeyMapFileName(gmClient *this, PStringBase<Char> *i_strKeymapFilename) .text:00401EF0 ?SetKeyMapFileName@gmClient@@QAEXABV?$PStringBase@D@@@Z

        // gmClient.__scaDelDtor:
        public static delegate* unmanaged[Thiscall]<gmClient*, UInt32, void*> __scaDelDtor = (delegate* unmanaged[Thiscall]<gmClient*, UInt32, void*>)0x00402630; // .text:00402490 ; void *__thiscall gmClient::`scalar deleting destructor'(gmClient *this, UInt32) .text:00402490 ??_GgmClient@@MAEPAXI@Z

        // gmClient.OnCommandLineEvaluationDone:
        public static delegate* unmanaged[Thiscall]<gmClient*, Byte> OnCommandLineEvaluationDone = (delegate* unmanaged[Thiscall]<gmClient*, Byte>)0x00402F60; // .text:00402D80 ; bool __thiscall gmClient::OnCommandLineEvaluationDone(gmClient *this) .text:00402D80 ?OnCommandLineEvaluationDone@gmClient@@UAE_NXZ

        // gmClient.Init:
        public static delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*, Int32, Int32, Byte> Init = (delegate* unmanaged[Thiscall]<gmClient*, PStringBase<Char>*, Int32, Int32, Byte>)0x004049A0; // .text:004047A0 ; bool __thiscall gmClient::Init(gmClient *this, PStringBase<Char> *windowTitle, const Int32 language_i, const Int32 region_i) .text:004047A0 ?Init@gmClient@@UAE_NABV?$PStringBase@D@@JJ@Z

        // gmClient.UseTime:
        public static delegate* unmanaged[Thiscall]<gmClient*, Byte> UseTime = (delegate* unmanaged[Thiscall]<gmClient*, Byte>)0x004017C0; // .text:004017B0 ; bool __thiscall gmClient::UseTime(gmClient *this) .text:004017B0 ?UseTime@gmClient@@MAE_NXZ

        // Globals:
        public static UInt32* sm_nFontFace = (UInt32*)0x0081820C; // .data:0081720C ; UInt32 gmClient::sm_nFontFace .data:0081720C ?sm_nFontFace@gmClient@@1KA
        public static UInt32* sm_nFontSize = (UInt32*)0x00818210; // .data:00817210 ; UInt32 gmClient::sm_nFontSize .data:00817210 ?sm_nFontSize@gmClient@@1KA
    }









    public unsafe struct AlreadyRunningCheck {
        // Struct:
        public void* m_UniqueClientSemaphore;
        public override string ToString() => $"m_UniqueClientSemaphore:->(void*)0x{(Int32)m_UniqueClientSemaphore:X8}";

    }

    public unsafe struct IQueuedUIEventDeliverer {
        // Struct:
        public Interface a0;
        public override string ToString() => a0.ToString();


        // Functions:

        // IQueuedUIEventDeliverer.__Ctor:
        // public static delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*> __Ctor = (delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*>)0xDEADBEEF; // .text:004FC5D0 ; void __thiscall IQueuedUIEventDeliverer::IQueuedUIEventDeliverer(IQueuedUIEventDeliverer *this) .text:004FC5D0 ??0IQueuedUIEventDeliverer@@QAE@XZ

        // IQueuedUIEventDeliverer.__Dtor:
        // public static delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*> __Dtor = (delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*>)0xDEADBEEF; // .text:004FC5B0 ; void __thiscall IQueuedUIEventDeliverer::~IQueuedUIEventDeliverer(IQueuedUIEventDeliverer *this) .text:004FC5B0 ??1IQueuedUIEventDeliverer@@QAE@XZ

        // IQueuedUIEventDeliverer.OnShutdown:
        // public static delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*> OnShutdown = (delegate* unmanaged[Thiscall]<IQueuedUIEventDeliverer*>)0xDEADBEEF; // .text:004FC5C0 ; void __thiscall IQueuedUIEventDeliverer::OnShutdown(IQueuedUIEventDeliverer *this) .text:004FC5C0 ?OnShutdown@IQueuedUIEventDeliverer@@UAEXXZ

        // Globals:
        public static IQueuedUIEventDeliverer** s_pInstance = (IQueuedUIEventDeliverer**)0x00842454; // .data:00841444 ; IQueuedUIEventDeliverer *IQueuedUIEventDeliverer::s_pInstance .data:00841444 ?s_pInstance@IQueuedUIEventDeliverer@@1PAV1@A
    }




    public unsafe struct ArgumentParser {
        // Struct:
        public Vtbl* vfptr;
        public PStringBase<Char> m_ErrorText;
        public PStringBase<Char> m_CmdChars;
        public UInt16** m_argv;
        public Int32 m_argc;
        public Int32 m_CurArg;
        public override string ToString() => $"vfptr:->(ArgumentParserVtbl*)0x{(Int32)vfptr:X8}, m_ErrorText:{m_ErrorText}, m_CmdChars:{m_CmdChars}, m_argv:->(UInt16**)0x{(Int32)m_argv:X8}, m_argc:{m_argc}, m_CurArg:{m_CurArg}";

        public unsafe struct Vtbl {
            // Struct:
            public static delegate* unmanaged[Thiscall]<ArgumentParser*> Usage; //   void (__thiscall *Usage)(ArgumentParser *this);
            public fixed Byte gap4[12];
            public ___u1 ___u1;
            public fixed Byte gap14[4];
            public ___u2 ___u2;
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, ArgumentParser.CommandLineArgList*> DisplayUsage; //   void (__thiscall *DisplayUsage)(ArgumentParser *this, ArgumentParser::CommandLineArgList *);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>*> SetErrorText; //   void (__thiscall *SetErrorText)(ArgumentParser *this, PStringBase<Char> *);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, ArgumentParser.OutputTextType> AppendOutputText; //   void (__thiscall *AppendOutputText)(ArgumentParser *this, const Char *, ArgumentParser::OutputTextType);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Int32, Int32, ArgumentParser.OutputTextType, Int32> AppendAndWordWrap; //   Int32 (__thiscall *AppendAndWordWrap)(ArgumentParser *this, const Char *, Int32, Int32, ArgumentParser::OutputTextType);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>, PStringBase<Char>, PStringBase<Char>> AppendArgumentText; //   void (__thiscall *AppendArgumentText)(ArgumentParser *this, PStringBase<Char>, PStringBase<Char>, PStringBase<Char>);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*> FinishOutputText; //   void (__thiscall *FinishOutputText)(ArgumentParser *this);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, Int32> GetCharactersToWrapUsageTo; //   Int32 (__thiscall *GetCharactersToWrapUsageTo)(ArgumentParser *this);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, ArgumentParser.CommandLineArgList*> BuildCommandLineArgs; //   void (__thiscall *BuildCommandLineArgs)(ArgumentParser *this, ArgumentParser::CommandLineArgList *);
            public fixed Byte gap3C[4];
            public ___u11 ___u11;
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, Byte> OnCommandLineEvaluationDone; //   bool (__thiscall *OnCommandLineEvaluationDone)(ArgumentParser *this);
            public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<UInt16>*, Byte, Byte> IsCommandLineArgument; //   bool (__thiscall *IsCommandLineArgument)(ArgumentParser *this, PStringBase<UInt16> *, bool);
        }


        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct ___u1 {
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<UInt16>>*, Byte, Byte> ParseArgs; //   bool (__thiscall *ParseArgs)(ArgumentParser *this, SmartArray<PStringBase<UInt16>,1> *, bool);
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<Char>>*, Byte, Byte> ParseArgs_; //   bool (__thiscall *ParseArgs)(ArgumentParser *this, SmartArray<PStringBase<Char>,1> *, bool);
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16**, Int32, Byte, Byte> ParseArgs__; //   bool (__thiscall *ParseArgs)(ArgumentParser *this, wChar_t **, Int32, bool);
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, Char**, Int32, Byte, Byte> ParseArgs___; //   bool (__thiscall *ParseArgs)(ArgumentParser *this, Char **, Int32, bool);
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct ___u2 {
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16*, Byte, Byte> ParseCommandLine; //   bool (__thiscall *ParseCommandLine)(ArgumentParser *this, const wChar_t *, bool);
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Byte, Byte> ParseCommandLine_; //   bool (__thiscall *ParseCommandLine)(ArgumentParser *this, const Char *, bool);
        }

        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct ___u11 {
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<Char>*, Byte> EvaluateCommandLineArg; //   bool (__thiscall *EvaluateCommandLineArg)(ArgumentParser *this, CommandLineArg *, PStringBase<Char> *);
            [FieldOffset(0)] public delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<UInt16>*, Byte> EvaluateCommandLineArg_; //   bool (__thiscall *EvaluateCommandLineArg)(ArgumentParser *this, CommandLineArg *, PStringBase<UInt16> *);
        }


        public unsafe struct CommandLineArgList {
            // Struct:
            public SmartArray<CommandLineArg> arr;
            public AutoGrowHashTable<CaseInsensitiveStringBase<PStringBase<UInt16>>, UInt32> m_LongNamesHash;
            public AutoGrowHashTable<UInt16, UInt32> m_ShortNamesHash;
            public override string ToString() => $"arr(SmartArray<CommandLineArg>):{arr} m_LongNamesHash(AutoGrowHashTable<CaseInsensitiveStringBase<PStringBase<UInt16> >,UInt32>):{m_LongNamesHash}, m_ShortNamesHash(AutoGrowHashTable<UInt16,UInt32>):{m_ShortNamesHash}";


            // Functions:

            // ArgumentParser::CommandLineArgList.FindByLongCmd:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*, PStringBase<UInt16>*, Int32> FindByLongCmd = (delegate* unmanaged[Thiscall]<CommandLineArgList*, PStringBase<UInt16>*, Int32>)0x004092C0; // .text:00409010 ; Int32 __thiscall ArgumentParser::CommandLineArgList::FindByLongCmd(ArgumentParser::CommandLineArgList *this, PStringBase<UInt16> *LongCmd) .text:00409010 ?FindByLongCmd@CommandLineArgList@ArgumentParser@@QBEHABV?$PStringBase@G@@@Z

            // ArgumentParser::CommandLineArgList.add:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*, CommandLineArg*, Byte> add = (delegate* unmanaged[Thiscall]<CommandLineArgList*, CommandLineArg*, Byte>)0x0040A0D0; // .text:00409D70 ; bool __thiscall ArgumentParser::CommandLineArgList::add(ArgumentParser::CommandLineArgList *this, CommandLineArg *data) .text:00409D70 ?add@CommandLineArgList@ArgumentParser@@QAE_NABUCommandLineArg@@@Z

            // ArgumentParser::CommandLineArgList.CommandLineArgList:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*> __Ctor = (delegate* unmanaged[Thiscall]<CommandLineArgList*>)0x0040A2B0; // .text:00409F50 ; void __thiscall ArgumentParser::CommandLineArgList::CommandLineArgList(ArgumentParser::CommandLineArgList *this) .text:00409F50 ??0CommandLineArgList@ArgumentParser@@QAE@XZ

            // ArgumentParser::CommandLineArgList.~CommandLineArgList:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*> __Dtor = (delegate* unmanaged[Thiscall]<CommandLineArgList*>)0x0040A310; // .text:00409FB0 ; void __thiscall ArgumentParser::CommandLineArgList::~CommandLineArgList(ArgumentParser::CommandLineArgList *this) .text:00409FB0 ??1CommandLineArgList@ArgumentParser@@QAE@XZ

            // ArgumentParser::CommandLineArgList.AddCmd:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*, Int32, Char, PStringBase<Char>*, PStringBase<Char>*, void*, UInt32, UInt32, Byte> AddCmd = (delegate* unmanaged[Thiscall]<CommandLineArgList*, Int32, Char, PStringBase<Char>*, PStringBase<Char>*, void*, UInt32, UInt32, Byte>)0x00402660; // .text:004024C0 ; bool __thiscall ArgumentParser::CommandLineArgList::AddCmd(ArgumentParser::CommandLineArgList *this, Int32 type, Char ShortCmd, PStringBase<Char> *LongCmd, PStringBase<Char> *Descript, void *Dest, UInt32 dwParam, UInt32 dwExtraData) .text:004024C0 ?AddCmd@CommandLineArgList@ArgumentParser@@QAE_NHDABV?$PStringBase@D@@0PAXKK@Z

            // ArgumentParser::CommandLineArgList.FindByShortCmd:
            public static delegate* unmanaged[Thiscall]<CommandLineArgList*, UInt16, Int32> FindByShortCmd = (delegate* unmanaged[Thiscall]<CommandLineArgList*, UInt16, Int32>)0x00408F80; // .text:00408CD0 ; Int32 __thiscall ArgumentParser::CommandLineArgList::FindByShortCmd(ArgumentParser::CommandLineArgList *this, UInt16 ShortCmd) .text:00408CD0 ?FindByShortCmd@CommandLineArgList@ArgumentParser@@QBEHG@Z
        }





        // Enums:
        public enum OutputTextType : UInt32 {
            ottNormal = 0x0,
            ottErrorText = 0x1,
            ottShortVersion = 0x2,
            ottLongVersion = 0x3,
            ottDescription = 0x4,
        };

        // Functions:

        // ArgumentParser.EvaluateCommandLineArg:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<UInt16>*, Byte> EvaluateCommandLineArg = (delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<UInt16>*, Byte>)0x00409860; // .text:004095B0 ; bool __thiscall ArgumentParser::EvaluateCommandLineArg(ArgumentParser *this, CommandLineArg *ArgData, PStringBase<UInt16> *param) .text:004095B0 ?EvaluateCommandLineArg@ArgumentParser@@MAE_NABUCommandLineArg@@ABV?$PStringBase@G@@@Z

        // ArgumentParser.ParseCommandLine:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Byte, Byte> ParseCommandLine = (delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Byte, Byte>)0x00409900; // .text:00409650 ; bool __thiscall ArgumentParser::ParseCommandLine(ArgumentParser *this, const Char *commandline, bool fSkipArgv0) .text:00409650 ?ParseCommandLine@ArgumentParser@@UAE_NPBD_N@Z


        // ArgumentParser.ParseArgs:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<Char>>*, Byte, Byte> ParseArgs = (delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<Char>>*, Byte, Byte>)0x00407640; // .text:00407390 ; bool __thiscall ArgumentParser::ParseArgs(ArgumentParser *this, SmartArray<PStringBase<Char>,1> *args, bool fSkipArgv0) .text:00407390 ?ParseArgs@ArgumentParser@@UAE_NABV?$SmartArray@V?$PStringBase@D@@$00@@_N@Z

        // ArgumentParser.SetErrorText:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>*> SetErrorText = (delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>*>)0x00407D30; // .text:00407A80 ; void __thiscall ArgumentParser::SetErrorText(ArgumentParser *this, PStringBase<Char> *ErrorText) .text:00407A80 ?SetErrorText@ArgumentParser@@MAEXABV?$PStringBase@D@@@Z

        // ArgumentParser.EvaluateCommandLineArg:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<Char>*, Byte> EvaluateCommandLineArg_ = (delegate* unmanaged[Thiscall]<ArgumentParser*, CommandLineArg*, PStringBase<Char>*, Byte>)0x004083F0; // .text:00408140 ; bool __thiscall ArgumentParser::EvaluateCommandLineArg(ArgumentParser *this, CommandLineArg *ArgData, PStringBase<Char> *param) .text:00408140 ?EvaluateCommandLineArg@ArgumentParser@@MAE_NABUCommandLineArg@@ABV?$PStringBase@D@@@Z

        // ArgumentParser.DisplayUsage:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, ArgumentParser.CommandLineArgList*> DisplayUsage = (delegate* unmanaged[Thiscall]<ArgumentParser*, ArgumentParser.CommandLineArgList*>)0x00409330; // .text:00409080 ; void __thiscall ArgumentParser::DisplayUsage(ArgumentParser *this, ArgumentParser::CommandLineArgList *UnsortedArgs) .text:00409080 ?DisplayUsage@ArgumentParser@@MAEXABVCommandLineArgList@1@@Z

        // ArgumentParser.IsCommandLineArgument:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<UInt16>*, Byte, Byte> IsCommandLineArgument = (delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<UInt16>*, Byte, Byte>)0x00408CB0; // .text:00408A00 ; bool __thiscall ArgumentParser::IsCommandLineArgument(ArgumentParser *this, PStringBase<UInt16> *Token, bool bLookingForParameter) .text:00408A00 ?IsCommandLineArgument@ArgumentParser@@MAE_NAAV?$PStringBase@G@@_N@Z

        // ArgumentParser.GetCharactersToWrapUsageTo:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, Int32> GetCharactersToWrapUsageTo = (delegate* unmanaged[Thiscall]<ArgumentParser*, Int32>)0x00412B60; // .text:00412800 ; Int32 __thiscall ArgumentParser::GetCharactersToWrapUsageTo(ArgumentParser *this) .text:00412800 ?GetCharactersToWrapUsageTo@ArgumentParser@@MAEHXZ

        // ArgumentParser.ParseArgs:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char**, Int32, Byte, Byte> ParseArgs_ = (delegate* unmanaged[Thiscall]<ArgumentParser*, Char**, Int32, Byte, Byte>)0x00409B00; // .text:00409850 ; bool __thiscall ArgumentParser::ParseArgs(ArgumentParser *this, Char **argv, Int32 argc, bool fSkipArgv0) .text:00409850 ?ParseArgs@ArgumentParser@@UAE_NPAPADH_N@Z

        // ArgumentParser.Usage:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*> Usage = (delegate* unmanaged[Thiscall]<ArgumentParser*>)0x0040A3B0; // .text:0040A050 ; void __thiscall ArgumentParser::Usage(ArgumentParser *this) .text:0040A050 ?Usage@ArgumentParser@@UAEXXZ

        // ArgumentParser.ParseArgs:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16**, Int32, Byte, Byte> ParseArgs__ = (delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16**, Int32, Byte, Byte>)0x0040A400; // .text:0040A0A0 ; bool __thiscall ArgumentParser::ParseArgs(ArgumentParser *this, UInt16 **argv, Int32 argc, bool fSkipArgv0) .text:0040A0A0 ?ParseArgs@ArgumentParser@@UAE_NPAPAGH_N@Z

        // ArgumentParser.ParseCommandLine:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16*, Byte, Byte> ParseCommandLine_ = (delegate* unmanaged[Thiscall]<ArgumentParser*, UInt16*, Byte, Byte>)0x00409A00; // .text:00409750 ; bool __thiscall ArgumentParser::ParseCommandLine(ArgumentParser *this, const UInt16 *commandline, bool fSkipArgv0) .text:00409750 ?ParseCommandLine@ArgumentParser@@UAE_NPBG_N@Z

        // ArgumentParser.AppendOutputText:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, ArgumentParser.OutputTextType> AppendOutputText = (delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, ArgumentParser.OutputTextType>)0x00407550; // .text:00407250 ; void __thiscall ArgumentParser::AppendOutputText(ArgumentParser *this, const Char *Text, ArgumentParser::OutputTextType i_eFormattingHInt32) .text:00407250 ?AppendOutputText@ArgumentParser@@MAEXPBDW4OutputTextType@1@@Z

        // ArgumentParser.ParseArgs:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<UInt16>>*, Byte, Byte> ParseArgs___ = (delegate* unmanaged[Thiscall]<ArgumentParser*, SmartArray<PStringBase<UInt16>>*, Byte, Byte>)0x00407600; // .text:00407350 ; bool __thiscall ArgumentParser::ParseArgs(ArgumentParser *this, SmartArray<PStringBase<UInt16>,1> *args, bool fSkipArgv0) .text:00407350 ?ParseArgs@ArgumentParser@@UAE_NABV?$SmartArray@V?$PStringBase@G@@$00@@_N@Z

        // ArgumentParser.AppendArgumentText:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>, PStringBase<Char>, PStringBase<Char>> AppendArgumentText = (delegate* unmanaged[Thiscall]<ArgumentParser*, PStringBase<Char>, PStringBase<Char>, PStringBase<Char>>)0x00407B50; // .text:004078A0 ; void __thiscall ArgumentParser::AppendArgumentText(ArgumentParser *this, PStringBase<Char> i_strShort, PStringBase<Char> i_strLong, PStringBase<Char> i_strDescription) .text:004078A0 ?AppendArgumentText@ArgumentParser@@MAEXV?$PStringBase@D@@00@Z

        // ArgumentParser.AppendAndWordWrap:
        public static delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Int32, Int32, ArgumentParser.OutputTextType, Int32> AppendAndWordWrap = (delegate* unmanaged[Thiscall]<ArgumentParser*, Char*, Int32, Int32, ArgumentParser.OutputTextType, Int32>)0x00408A60; // .text:004087B0 ; Int32 __thiscall ArgumentParser::AppendAndWordWrap(ArgumentParser *this, const Char *Text, Int32 nIndent, Int32 iCursorX, ArgumentParser::OutputTextType i_eFormattingHInt32) .text:004087B0 ?AppendAndWordWrap@ArgumentParser@@MAEHPBDHHW4OutputTextType@1@@Z

    }


    public unsafe struct CommandLineArg {
        // Struct:
        public Int32 ArgType;
        public Char ShortVersion;
        public PStringBase<Char> LongVersion;
        public PStringBase<Char> Description;
        public void* VariableToModify;
        public UInt32 ValueToStore;
        public UInt32 UserData;
        public override string ToString() => $"ArgType:{ArgType}, ShortVersion:{ShortVersion}, LongVersion:{LongVersion}, Description:{Description}, VariableToModify:->(void*)0x{(Int32)VariableToModify:X8}, ValueToStore:{ValueToStore:X8}, UserData:{UserData:X8}";


        // Functions:

        // CommandLineArg.__Dtor:
        public static delegate* unmanaged[Thiscall]<CommandLineArg*> __Dtor = (delegate* unmanaged[Thiscall]<CommandLineArg*>)0x00402280; // .text:004020E0 ; void __thiscall CommandLineArg::~CommandLineArg(CommandLineArg *this) .text:004020E0 ??1CommandLineArg@@QAE@XZ

        // CommandLineArg.operator=:
        public static delegate* unmanaged[Thiscall]<CommandLineArg*, CommandLineArg*> operator_equals = (delegate* unmanaged[Thiscall]<CommandLineArg*, CommandLineArg*>)0x00407750; // .text:004074A0 ; public: struct CommandLineArg & __thiscall CommandLineArg::operator=(struct CommandLineArg const &) .text:004074A0 ??4CommandLineArg@@QAEAAU0@ABU0@@Z

        // CommandLineArg.__Ctor:
        public static delegate* unmanaged[Thiscall]<CommandLineArg*> __Ctor = (delegate* unmanaged[Thiscall]<CommandLineArg*>)0x00407B10; // .text:00407860 ; void __thiscall CommandLineArg::CommandLineArg(CommandLineArg *this) .text:00407860 ??0CommandLineArg@@QAE@XZ

        // CommandLineArg.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<CommandLineArg*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CommandLineArg*, UInt32, void*>)0x00407D80; // .text:00407AD0 ; void *__thiscall CommandLineArg::`vector deleting destructor'(CommandLineArg *this, UInt32) .text:00407AD0 ??_ECommandLineArg@@QAEPAXI@Z
    }


    public unsafe struct CDDDStatusPlugin {
        // Struct:
        public CPluginPrototype CPluginPrototype;
        public override string ToString() => $"CPluginPrototype(CPluginPrototype):{CPluginPrototype}";


        // Functions:

        // CDDDStatusPlugin.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<CDDDStatusPlugin*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CDDDStatusPlugin*, UInt32, void*>)0x00412020; // .text:00411CC0 ; void *__thiscall CDDDStatusPlugin::`vector deleting destructor'(CDDDStatusPlugin *this, UInt32) .text:00411CC0 ??_ECDDDStatusPlugin@@UAEPAXI@Z
    }
    public unsafe struct CPluginPrototype {
        // Struct:
        public CPluginPrototypeVtbl* vfptr;
        public CPluginManager* m_pManager;
        public override string ToString() => $"vfptr:->(CPluginPrototypeVtbl*)0x{(Int32)vfptr:X8}, m_pManager:->(CPluginManager*)0x{(Int32)m_pManager:X8}";


        // Functions:

        // CPluginPrototype.OnPluggedIn:
        public static delegate* unmanaged[Thiscall]<CPluginPrototype*, CPluginManager*> OnPluggedIn = (delegate* unmanaged[Thiscall]<CPluginPrototype*, CPluginManager*>)0x00401D80; // .text:00401C50 ; void __thiscall CPluginPrototype::OnPluggedIn(CPluginPrototype *this, CPluginManager *pManager) .text:00401C50 ?OnPluggedIn@CPluginPrototype@@MAEXPAVCPluginManager@@@Z

        // CPluginPrototype.__vecDelDtor:
        public static delegate* unmanaged[Thiscall]<CPluginPrototype*, UInt32, void*> __vecDelDtor = (delegate* unmanaged[Thiscall]<CPluginPrototype*, UInt32, void*>)0x0040E450; // .text:0040E0F0 ; void *__thiscall CPluginPrototype::`vector deleting destructor'(CPluginPrototype *this, UInt32) .text:0040E0F0 ??_ECPluginPrototype@@UAEPAXI@Z
    }
    public unsafe struct CPluginPrototypeVtbl {
        // Struct:
        public static delegate* unmanaged[Thiscall]<CPluginPrototype*, UInt32, void*> __vecDelDtor; //   void *(__thiscall *__vecDelDtor)(CPluginPrototype *this, UInt32);
        public static delegate* unmanaged[Thiscall]<CPluginPrototype*, CPluginManager*> OnPluggedIn; //   void (__thiscall *OnPluggedIn)(CPluginPrototype *this, CPluginManager *);
    }

    public unsafe struct CPluginManager {
        // Struct:
        public SmartArray<PTR<CPluginPrototype>> m_Plugins;
        public override string ToString() => $"m_Plugins(SmartArray<CPluginPrototype*,1>):{m_Plugins}";


        // Functions:

        // CPluginManager.RemovePluginPrototype:
        public static delegate* unmanaged[Thiscall]<CPluginManager*, CPluginPrototype*, Byte> RemovePluginPrototype = (delegate* unmanaged[Thiscall]<CPluginManager*, CPluginPrototype*, Byte>)0x0040E340; // .text:0040DFE0 ; bool __thiscall CPluginManager::RemovePluginPrototype(CPluginManager *this, CPluginPrototype *pPlugin) .text:0040DFE0 ?RemovePluginPrototype@CPluginManager@@IAE_NPAVCPluginPrototype@@@Z

        // CPluginManager.__Dtor:
        public static delegate* unmanaged[Thiscall]<CPluginManager*> __Dtor = (delegate* unmanaged[Thiscall]<CPluginManager*>)0x0040E3E0; // .text:0040E080 ; void __thiscall CPluginManager::~CPluginManager(CPluginManager *this) .text:0040E080 ??1CPluginManager@@QAE@XZ

        // CPluginManager.AddPluginPrototype:
        public static delegate* unmanaged[Thiscall]<CPluginManager*, CPluginPrototype*, Byte> AddPluginPrototype = (delegate* unmanaged[Thiscall]<CPluginManager*, CPluginPrototype*, Byte>)0x0040E4E0; // .text:0040E180 ; bool __thiscall CPluginManager::AddPluginPrototype(CPluginManager *this, CPluginPrototype *pPlugin) .text:0040E180 ?AddPluginPrototype@CPluginManager@@IAE_NPAVCPluginPrototype@@@Z
    }
    public unsafe struct CPluginManagerTemplate<T> where T : unmanaged {
        // Struct:
        public CPluginManager CPluginManager;
        public override string ToString() => $"CPluginManager(CPluginManager):{CPluginManager}";

    }

}