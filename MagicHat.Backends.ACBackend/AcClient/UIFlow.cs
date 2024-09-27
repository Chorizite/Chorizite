using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct UIFlow {
        // Struct:
        public Interface a0;
        public NoticeHandler a1;
        public UIListener a2;
        public Turbine_RefCount m_cTurbineRefCount;
        public UIMode _curMode;
        public UIMode _nextMode;
        public UIMainFramework* _curUI;
        public UIPersistantData* _data;
        public StringInfo _nextText;
        public override string ToString() => $"a0(_Interface):{a0}, a1(NoticeHandler):{a1}, a2(UIListener):{a2}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, _curMode:{_curMode:X8}, _nextMode:{_nextMode:X8}, _curUI:->(UIMainFramework*)0x{(int)_curUI:X8}, _data:->(UIPersistantData*)0x{(int)_data:X8}, _nextText(StringInfo):{_nextText}";

        // Functions:

        // UIFlow.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref UIFlow, void>)0x004799C0)(ref this); // .text:004795C0 ; void __thiscall UIFlow::UIFlow(UIFlow *this) .text:004795C0 ??0UIFlow@@QAE@XZ

        // UIFlow.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32>)0x00479940)(ref this); // .text:00479540 ; unsigned int __thiscall UIFlow::AddRef(UIFlow *this) .text:00479540 ?AddRef@UIFlow@@UBEKXZ

        // UIFlow.GetPersistantData:
        public UInt32 GetPersistantData() => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32>)0x0051DFB0)(ref this); // .text:0051D480 ; unsigned int __thiscall UIFlow::GetPersistantData(PhysicsDesc *this) .text:0051D480 ?GetPersistantData@UIFlow@@UAEPAVUIPersistantData@@XZ

        // UIFlow.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 messageID, int data_int) => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32, int, void>)0x00479BA0)(ref this, messageID, data_int); // .text:004797A0 ; void __thiscall UIFlow::ListenToGlobalMessage(UIFlow *this, unsigned int messageID, int data_int) .text:004797A0 ?ListenToGlobalMessage@UIFlow@@UAEXKJ@Z

        // UIFlow.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppObject) => ((delegate* unmanaged[Thiscall]<ref UIFlow, TResult*, Turbine_GUID*, void**, TResult*>)0x004798E0)(ref this, result, i_rcInterface, o_ppObject); // .text:004794E0 ; TResult *__thiscall UIFlow::QueryInterface(UIFlow *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppObject) .text:004794E0 ?QueryInterface@UIFlow@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // UIFlow.QueueUIMode:
        public void QueueUIMode(UInt32 newMode) => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32, void>)0x004797C0)(ref this, newMode); // .text:004793C0 ; void __thiscall UIFlow::QueueUIMode(UIFlow *this, const unsigned int newMode) .text:004793C0 ?QueueUIMode@UIFlow@@UAEXK@Z

        // UIFlow.QueueUIModeWithError:
        public void QueueUIModeWithError(UInt32 newMode, StringInfo* newText) => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32, StringInfo*, void>)0x004797F0)(ref this, newMode, newText); // .text:004793F0 ; void __thiscall UIFlow::QueueUIModeWithError(UIFlow *this, const unsigned int newMode, StringInfo *newText) .text:004793F0 ?QueueUIModeWithError@UIFlow@@UAEXKABVStringInfo@@@Z

        // UIFlow.RegisterFrameworkClass:  
        public static void RegisterFrameworkClass(UInt32 mode, delegate* unmanaged[Cdecl]<UIMainFramework*> createMethod) => ((delegate* unmanaged[Cdecl]<UInt32, delegate* unmanaged[Cdecl]<UIMainFramework*>, void>)0x00479C50)(mode, createMethod); // .text:00479850 ; void __cdecl UIFlow::RegisterFrameworkClass(unsigned int mode, UIMainFramework *(__cdecl *createMethod)()) .text:00479850 ?RegisterFrameworkClass@UIFlow@@SAXKP6APAVUIMainFramework@@XZ@Z

        // UIFlow.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref UIFlow, UInt32>)0x00479950)(ref this); // .text:00479550 ; unsigned int __thiscall UIFlow::Release(UIFlow *this) .text:00479550 ?Release@UIFlow@@UBEKXZ

        // UIFlow.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref UIFlow, void>)0x00479830)(ref this); // .text:00479430 ; void __thiscall UIFlow::Update(UIFlow *this) .text:00479430 ?Update@UIFlow@@UAEXXZ

        // UIFlow.UseNewMode:
        public void UseNewMode() => ((delegate* unmanaged[Thiscall]<ref UIFlow, void>)0x00479AA0)(ref this); // .text:004796A0 ; void __thiscall UIFlow::UseNewMode(UIFlow *this) .text:004796A0 ?UseNewMode@UIFlow@@IAEXXZ

        // Globals:
        // public static HashTable<UInt32,UIMainFramework* (__cdecl*)(void),0>* _frameworkCreateMethodTable = (HashTable<UInt32,UIMainFramework* (__cdecl*)(void),0>*)0xDEADBEEF; // .data:00818F88 ; HashTable<unsigned long,UIMainFramework * (__cdecl*)(void),0> UIFlow::_frameworkCreateMethodTable .data:00818F88 ?_frameworkCreateMethodTable@UIFlow@@1V?$HashTable@KP6APAVUIMainFramework@@XZ$0A@@@A
        public static UIFlow** m_instance = (UIFlow**)0x0083E72C; // .data:0083D72C ; UIFlow *UIFlow::m_instance .data:0083D72C ?m_instance@UIFlow@@1PAV1@A
    }

    public unsafe struct UIMainFramework {
        // Struct:
        public UIFramework a0;
        public SmartArray<PTR<UIElement>> m_rootElements;
        public override string ToString() => $"a0(UIFramework):{a0}, m_rootElements(SmartArray<PTR<UIElement>>):{m_rootElements}";

        // Functions:

        // UIMainFramework.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref UIMainFramework, void>)0x006A1AB0)(ref this); // .text:006A0C90 ; void __thiscall UIMainFramework::UIMainFramework(UIMainFramework *this) .text:006A0C90 ??0UIMainFramework@@QAE@XZ

        // UIMainFramework.CreateAndAddRootElement:
        public UIElement* CreateAndAddRootElement(UInt32 layoutEnum, UInt32 elementID) => ((delegate* unmanaged[Thiscall]<ref UIMainFramework, UInt32, UInt32, UIElement*>)0x006A1A20)(ref this, layoutEnum, elementID); // .text:006A0C00 ; UIElement *__thiscall UIMainFramework::CreateAndAddRootElement(UIMainFramework *this, const unsigned int layoutEnum, const unsigned int elementID) .text:006A0C00 ?CreateAndAddRootElement@UIMainFramework@@MAEPAVUIElement@@KK@Z

        // UIMainFramework.CreateAndAddRootElementByDataID:
        public UIElement* CreateAndAddRootElementByDataID(UInt32 _layoutID, UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref UIMainFramework, UInt32, UInt32, UIElement*>)0x006A1B70)(ref this, _layoutID, _elementID); // .text:006A0D50 ; UIElement *__thiscall UIMainFramework::CreateAndAddRootElementByDataID(UIMainFramework *this, IDClass<_tagDataID,32,0> _layoutID, const unsigned int _elementID) .text:006A0D50 ?CreateAndAddRootElementByDataID@UIMainFramework@@MAEPAVUIElement@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@K@Z

        // UIMainFramework.RemoveRootElement:
        public void RemoveRootElement(UIElement** element) => ((delegate* unmanaged[Thiscall]<ref UIMainFramework, UIElement**, void>)0x006A1A60)(ref this, element); // .text:006A0C40 ; void __thiscall UIMainFramework::RemoveRootElement(UIMainFramework *this, UIElement **element) .text:006A0C40 ?RemoveRootElement@UIMainFramework@@MAEXAAPAVUIElement@@@Z
    }
    public unsafe struct UIFramework {
        // Struct:
        public UIListener a0;
        public Byte m_bCanForceHide;
        public Byte m_bIsForcedHidden;
        public Byte m_shown;
        public SmartArray<int> m_children; // UIChildFramework*
        public override string ToString() => $"a0(UIListener):{a0}, m_bCanForceHide:{m_bCanForceHide:X2}, m_bIsForcedHidden:{m_bIsForcedHidden:X2}, m_shown:{m_shown:X2}, m_children(SmartArray<UIChildFramework*,1>):{m_children}";

        // Functions:

        // UIFramework.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref UIFramework, void>)0x006A1900)(ref this); // .text:006A0AE0 ; void __thiscall UIFramework::UIFramework(UIFramework *this) .text:006A0AE0 ??0UIFramework@@QAE@XZ

        // UIFramework.AddChild:
        public void AddChild(UIChildFramework* child) => ((delegate* unmanaged[Thiscall]<ref UIFramework, UIChildFramework*, void>)0x006A19C0)(ref this, child); // .text:006A0BA0 ; void __thiscall UIFramework::AddChild(UIFramework *this, UIChildFramework *child) .text:006A0BA0 ?AddChild@UIFramework@@UAEXPAVUIChildFramework@@@Z

        // UIFramework.FindChild:
        public int FindChild(UIChildFramework* child) => ((delegate* unmanaged[Thiscall]<ref UIFramework, UIChildFramework*, int>)0x006A1830)(ref this, child); // .text:006A0A10 ; int __thiscall UIFramework::FindChild(UIFramework *this, UIChildFramework *child) .text:006A0A10 ?FindChild@UIFramework@@UAEJPAVUIChildFramework@@@Z

        // UIFramework.ForceHidden:
        public void ForceHidden(Byte hide) => ((delegate* unmanaged[Thiscall]<ref UIFramework, Byte, void>)0x006A17C0)(ref this, hide); // .text:006A09A0 ; void __thiscall UIFramework::ForceHidden(UIFramework *this, bool hide) .text:006A09A0 ?ForceHidden@UIFramework@@UAEX_N@Z

        // UIFramework.GetPersistantData:
        public UIPersistantData* GetPersistantData() => ((delegate* unmanaged[Thiscall]<ref UIFramework, UIPersistantData*>)0x006A1730)(ref this); // .text:006A0910 ; UIPersistantData *__thiscall UIFramework::GetPersistantData(UIFramework *this) .text:006A0910 ?GetPersistantData@UIFramework@@QBEPAVUIPersistantData@@XZ

        // UIFramework.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref UIFramework, UIElementMessageInfo*, UIElementMessageListenResult>)0x006A1860)(ref this, i_rMsg); // .text:006A0A40 ; UIElementMessageListenResult __thiscall UIFramework::ListenToElementMessage(UIFramework *this, UIElementMessageInfo *i_rMsg) .text:006A0A40 ?ListenToElementMessage@UIFramework@@MAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // UIFramework.QueueUIMode:
        public void QueueUIMode(UInt32 newMode) => ((delegate* unmanaged[Thiscall]<ref UIFramework, UInt32, void>)0x006A1740)(ref this, newMode); // .text:006A0920 ; void __thiscall UIFramework::QueueUIMode(UIFramework *this, const unsigned int newMode) .text:006A0920 ?QueueUIMode@UIFramework@@QAEXK@Z

        // UIFramework.RemoveChild:
        public void RemoveChild(UIChildFramework* child) => ((delegate* unmanaged[Thiscall]<ref UIFramework, UIChildFramework*, void>)0x006A18B0)(ref this, child); // .text:006A0A90 ; void __thiscall UIFramework::RemoveChild(UIFramework *this, UIChildFramework *child) .text:006A0A90 ?RemoveChild@UIFramework@@UAEXPAVUIChildFramework@@@Z

        // UIFramework.Show:
        public void Show(Byte shown) => ((delegate* unmanaged[Thiscall]<ref UIFramework, Byte, void>)0x006A1750)(ref this, shown); // .text:006A0930 ; void __thiscall UIFramework::Show(UIFramework *this, bool shown) .text:006A0930 ?Show@UIFramework@@UAEX_N@Z

        // UIFramework.Shown:
        public Byte Shown() => ((delegate* unmanaged[Thiscall]<ref UIFramework, Byte>)0x004E7AE0)(ref this); // .text:004E6E50 ; bool __thiscall UIFramework::Shown(UIFramework *this) .text:004E6E50 ?Shown@UIFramework@@UBE_NXZ
    }
    public unsafe struct UIChildFramework {
        // Struct:
        public UIFramework a0;
        public UIFramework* m_parent;
        public override string ToString() => $"a0(UIFramework):{a0}, m_parent:->(UIFramework*)0x{(int)m_parent:X8}";
    }
    public unsafe struct UIPersistantData {
        // Struct:
        public NoticeHandler a0;
        public CharacterSet _charSet;
        public Byte _receivedSet;
        public UInt32 m_iidSelectedAvatar;
        public override string ToString() => $"a0(NoticeHandler):{a0}, _charSet(CharacterSet):{_charSet}, _receivedSet:{_receivedSet:X2}, m_iidSelectedAvatar:{m_iidSelectedAvatar:X8}";

        // Functions:

        // UIPersistantData.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref UIPersistantData, void>)0x00479E00)(ref this); // .text:00479A00 ; void __thiscall UIPersistantData::UIPersistantData(UIPersistantData *this) .text:00479A00 ??0UIPersistantData@@QAE@XZ

        // UIPersistantData.RecvNotice_CharacterSet:
        public void RecvNotice_CharacterSet(CharacterSet* charSet) => ((delegate* unmanaged[Thiscall]<ref UIPersistantData, CharacterSet*, void>)0x00479D00)(ref this, charSet); // .text:00479900 ; void __thiscall UIPersistantData::RecvNotice_CharacterSet(UIPersistantData *this, CharacterSet *charSet) .text:00479900 ?RecvNotice_CharacterSet@UIPersistantData@@UAEXABVCharacterSet@@@Z
    }

    public unsafe struct CharacterSet {
        // Struct:
        public PackObj a0;
        public StrHashData a1;
        public AC1Legacy.SmartArray<PTR<CharacterIdentity>> set_;
        public AC1Legacy.SmartArray<PTR<CharacterIdentity>> delSet_;
        public UInt32 status_;
        public Int32 numAllowedCharacters_;
        public accountID account_;
        public Int32 m_fUseTurbineChat;
        public Int32 m_fHasThroneofDestiny;
        public override string ToString() => $"set_:({set_}), delSet_:({delSet_}), status_:{status_:X8}, numAllowedCharacters_:{numAllowedCharacters_}, account_:{account_}, m_fUseTurbineChat:{m_fUseTurbineChat}, m_fHasThroneofDestiny:{m_fHasThroneofDestiny}";

        // Functions:

        // CharacterSet.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CharacterSet, void>)0x00479D30)(ref this); // .text:00479930 ; void __thiscall CharacterSet::CharacterSet(CharacterSet *this) .text:00479930 ??0CharacterSet@@QAE@XZ

        // CharacterSet.operator_equals:
        // public CharacterSet* operator_equals() => ((delegate* unmanaged[Thiscall]<ref CharacterSet, CharacterSet*>)0xDEADBEEF)(ref this); // .text:004FE570 ; public: class CharacterSet & __thiscall CharacterSet::operator=(class CharacterSet const &) .text:004FE570 ??4CharacterSet@@QAEAAV0@ABV0@@Z

        // CharacterSet.AddIdentity:
        public int AddIdentity(CharacterIdentity* toAdd) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, CharacterIdentity*, int>)0x004FEF70)(ref this, toAdd); // .text:004FE4F0 ; int __thiscall CharacterSet::AddIdentity(CharacterSet *this, CharacterIdentity *toAdd) .text:004FE4F0 ?AddIdentity@CharacterSet@@QAEHAAVCharacterIdentity@@@Z

        // CharacterSet.ClearIdentity:
        public void ClearIdentity(int slot) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, int, void>)0x004FE960)(ref this, slot); // .text:004FDEE0 ; void __thiscall CharacterSet::ClearIdentity(CharacterSet *this, int slot) .text:004FDEE0 ?ClearIdentity@CharacterSet@@QAEXH@Z

        // CharacterSet.GetGID:
        public UInt32 GetGID(int slot) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, int, UInt32>)0x004FE9B0)(ref this, slot); // .text:004FDF30 ; unsigned int __thiscall CharacterSet::GetGID(CharacterSet *this, int slot) .text:004FDF30 ?GetGID@CharacterSet@@QAEKH@Z

        // CharacterSet.GetGreyedOutFor:
        public UInt32 GetGreyedOutFor(int slot) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, int, UInt32>)0x004FEA20)(ref this, slot); // .text:004FDFA0 ; unsigned int __thiscall CharacterSet::GetGreyedOutFor(CharacterSet *this, int slot) .text:004FDFA0 ?GetGreyedOutFor@CharacterSet@@QAEKH@Z

        // CharacterSet.GetIdentity:
        public CharacterIdentity* GetIdentity(int indexSigned) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, int, CharacterIdentity*>)0x004E8B20)(ref this, indexSigned); // .text:004E7E90 ; CharacterIdentity *__thiscall CharacterSet::GetIdentity(CharacterSet *this, int indexSigned) .text:004E7E90 ?GetIdentity@CharacterSet@@QAEPAVCharacterIdentity@@H@Z

        // CharacterSet.GetName:
        public char* GetName(int index) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, int, char*>)0x004FE980)(ref this, index); // .text:004FDF00 ; const char *__thiscall CharacterSet::GetName(CharacterSet *this, int index) .text:004FDF00 ?GetName@CharacterSet@@QAEPBDH@Z

        // CharacterSet.GetSlot:
        public int GetSlot(UInt32 i_iidAvatar) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, UInt32, int>)0x004FE9E0)(ref this, i_iidAvatar); // .text:004FDF60 ; int __thiscall CharacterSet::GetSlot(CharacterSet *this, unsigned int i_iidAvatar) .text:004FDF60 ?GetSlot@CharacterSet@@QAEHK@Z

        // CharacterSet.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:004FE260 ; unsigned int __thiscall CharacterSet::Pack(CharacterSet *this, void **addr, unsigned int size) .text:004FE260 ?Pack@CharacterSet@@UAEIAAPAXI@Z

        // CharacterSet.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CharacterSet, void**, UInt32, int>)0x004FEDC0)(ref this, addr, size); // .text:004FE340 ; int __thiscall CharacterSet::UnPack(CharacterSet *this, void **addr, unsigned int size) .text:004FE340 ?UnPack@CharacterSet@@UAEHAAPAXI@Z

        // CharacterSet.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref CharacterSet, UInt32>)0xDEADBEEF)(ref this); // .text:004FE1B0 ; unsigned int __thiscall CharacterSet::pack_size(CharacterSet *this) .text:004FE1B0 ?pack_size@CharacterSet@@QAEIXZ

    }
    public unsafe struct CharacterIdentity {
        // Struct:
        public PackObj a0;
        public UInt32 gid_;
        public AC1Legacy.PStringBase<char> name_;
        public UInt32 secondsGreyedOut_;
        public override string ToString() => $"(gid_:{gid_:X8}, name_:{name_}, secondsGreyedOut_:{secondsGreyedOut_})";

        // Functions:

        // CharacterIdentity.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CharacterIdentity, void>)0x004FF180)(ref this); // .text:004FE700 ; void __thiscall CharacterIdentity::CharacterIdentity(CharacterIdentity *this) .text:004FE700 ??0CharacterIdentity@@QAE@XZ

        // CharacterIdentity.operator_equals:
        // public CharacterIdentity* operator_equals() => ((delegate* unmanaged[Thiscall]<ref CharacterIdentity, CharacterIdentity*>)0xDEADBEEF)(ref this); // .text:004FE820 ; public: class CharacterIdentity & __thiscall CharacterIdentity::operator=(class CharacterIdentity const &) .text:004FE820 ??4CharacterIdentity@@QAEAAV0@ABV0@@Z

        // CharacterIdentity.Pack:
        // public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CharacterIdentity, void**, UInt32, UInt32>)0xDEADBEEF)(ref this, addr, size); // .text:004FE780 ; unsigned int __thiscall CharacterIdentity::Pack(CharacterIdentity *this, void **addr, unsigned int size) .text:004FE780 ?Pack@CharacterIdentity@@UAEIAAPAXI@Z

        // CharacterIdentity.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref CharacterIdentity, void**, UInt32, int>)0x004FF300)(ref this, addr, size); // .text:004FE880 ; int __thiscall CharacterIdentity::UnPack(CharacterIdentity *this, void **addr, unsigned int size) .text:004FE880 ?UnPack@CharacterIdentity@@UAEHAAPAXI@Z

        // CharacterIdentity.pack_size:
        // public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref CharacterIdentity, UInt32>)0xDEADBEEF)(ref this); // .text:004FE730 ; unsigned int __thiscall CharacterIdentity::pack_size(CharacterIdentity *this) .text:004FE730 ?pack_size@CharacterIdentity@@QAEIXZ
    }



    public unsafe struct accountID {
        // Struct:
        public AC1Legacy.PStringBase<Char> name;
        public Int32 fIsDarkMajestyExpansion_;
        public Int32 m_fIsThroneOfDestinyExpansion;
        public Int32 m_fPreOrderedThroneOfDestinyExpansion;
        public override string ToString() => $"name:{name}, fIsDarkMajestyExpansion_:{fIsDarkMajestyExpansion_}, m_fIsThroneOfDestinyExpansion:{m_fIsThroneOfDestinyExpansion}, m_fPreOrderedThroneOfDestinyExpansion:{m_fPreOrderedThroneOfDestinyExpansion}";

        // Functions:

        // accountID.__Ctor:
        public void __Ctor(accountID* rhs) => ((delegate* unmanaged[Thiscall]<ref accountID, accountID*, void>)0x004E9280)(ref this, rhs); // .text:004E85F0 ; void __thiscall accountID::accountID(accountID *this, accountID *rhs) .text:004E85F0 ??0accountID@@QAE@ABV0@@Z

    }
    public unsafe struct UIQueueManager {
        // Struct:
        public IQueuedUIEventDeliverer a0;
        public Turbine_RefCount m_cTurbineRefCount;
        public NIList<NetBlob> m_rgWaitingBlobs;
        public Byte m_fCrucialOrderedEventsReceived;
        public NIList<NetBlob>* m_pUIQueue;
        public SmartArray<PTR<ClientSystem>> m_rgSystems;
        public ClientMagicSystem* m_pMagicSystem;
        public ClientCommunicationSystem* m_pCommunicationSystem;
        public ClientObjMaintSystem* m_pObjMaintSystem;
        public ClientUISystem* m_pUISystem;
        public ClientAllegianceSystem* m_pAllegianceSystem;
        public ClientFellowshipSystem* m_pFellowshipSystem;
        public CPlayerSystem* m_pPlayerSystem;
        public ClientHousingSystem* m_pHousingSystem;
        public ClientMiniGameSystem* m_pMiniGameSystem;
        public ClientAdminSystem* m_pAdminSystem;
        public ClientCombatSystem* m_pCombatSystem;
        public ClientTradeSystem* m_pTradeSystem;
        public override string ToString() => $"a0(IQueuedUIEventDeliverer):{a0}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_rgWaitingBlobs(NIList<NetBlob*>):{m_rgWaitingBlobs}, m_fCrucialOrderedEventsReceived:{m_fCrucialOrderedEventsReceived:X2}, m_pUIQueue:->(NIList<NetBlob*>*)0x{(int)m_pUIQueue:X8}, m_rgSystems(SmartArray<ClientSystem*,1>):{m_rgSystems}, m_pMagicSystem:->(ClientMagicSystem*)0x{(int)m_pMagicSystem:X8}, m_pCommunicationSystem:->(ClientCommunicationSystem*)0x{(int)m_pCommunicationSystem:X8}, m_pObjMaintSystem:->(ClientObjMaintSystem*)0x{(int)m_pObjMaintSystem:X8}, m_pUISystem:->(ClientUISystem*)0x{(int)m_pUISystem:X8}, m_pAllegianceSystem:->(ClientAllegianceSystem*)0x{(int)m_pAllegianceSystem:X8}, m_pFellowshipSystem:->(ClientFellowshipSystem*)0x{(int)m_pFellowshipSystem:X8}, m_pPlayerSystem:->(CPlayerSystem*)0x{(int)m_pPlayerSystem:X8}, m_pHousingSystem:->(ClientHousingSystem*)0x{(int)m_pHousingSystem:X8}, m_pMiniGameSystem:->(ClientMiniGameSystem*)0x{(int)m_pMiniGameSystem:X8}, m_pAdminSystem:->(ClientAdminSystem*)0x{(int)m_pAdminSystem:X8}, m_pCombatSystem:->(ClientCombatSystem*)0x{(int)m_pCombatSystem:X8}, m_pTradeSystem:->(ClientTradeSystem*)0x{(int)m_pTradeSystem:X8}";
        // Enums:
        public enum Enum18 : UInt32 {
            IMPLEMENT_STD_ADDREF_UNIQUE_RETVAL = 0x0,
        };

        // Functions:

        // UIQueueManager.__Ctor:
        public void __Ctor(NIList<NetBlob>* pqueue) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, NIList<NetBlob>*, void>)0x0055B530)(ref this, pqueue); // .text:0055A860 ; void __thiscall UIQueueManager::UIQueueManager(UIQueueManager *this, NIList<NetBlob *> *pqueue) .text:0055A860 ??0UIQueueManager@@QAE@PAV?$NIList@PAVNetBlob@@@@@Z

        // UIQueueManager.CrucialOrderedEventsReceived:
        // public void CrucialOrderedEventsReceived() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0xDEADBEEF)(ref this); // .text:0055A7F0 ; void __thiscall UIQueueManager::CrucialOrderedEventsReceived(UIQueueManager *this) .text:0055A7F0 ?CrucialOrderedEventsReceived@UIQueueManager@@IAEXXZ

        // UIQueueManager.HandleOrderingForBlob:
        // public void HandleOrderingForBlob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, NetBlob*, void>)0xDEADBEEF)(ref this, blob); // .text:0055D1C0 ; void __thiscall UIQueueManager::HandleOrderingForBlob(UIQueueManager *this, NetBlob *blob) .text:0055D1C0 ?HandleOrderingForBlob@UIQueueManager@@IAEXPAVNetBlob@@@Z

        // UIQueueManager.HandleStringUpdateEvents:
        // public UInt32 HandleStringUpdateEvents(void* buff, UInt32 size, UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void*, UInt32, UInt32, UInt32>)0xDEADBEEF)(ref this, buff, size, etype); // .text:0055A980 ; unsigned int __thiscall UIQueueManager::HandleStringUpdateEvents(UIQueueManager *this, void *buff, unsigned int size, unsigned int etype) .text:0055A980 ?HandleStringUpdateEvents@UIQueueManager@@IAEKPAXIK@Z

        // UIQueueManager.OnBeginCharacterSession:
        // public void OnBeginCharacterSession() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0xDEADBEEF)(ref this); // .text:0055A6A0 ; void __thiscall UIQueueManager::OnBeginCharacterSession(UIQueueManager *this) .text:0055A6A0 ?OnBeginCharacterSession@UIQueueManager@@QAEXXZ

        // UIQueueManager.OnEndCharacterSession:
        // public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0xDEADBEEF)(ref this); // .text:0055A6D0 ; void __thiscall UIQueueManager::OnEndCharacterSession(UIQueueManager *this) .text:0055A6D0 ?OnEndCharacterSession@UIQueueManager@@QAEXXZ

        // UIQueueManager.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0x0055B340)(ref this); // .text:0055A700 ; void __thiscall UIQueueManager::OnShutdown(UIQueueManager *this) .text:0055A700 ?OnShutdown@UIQueueManager@@UAEXXZ

        // UIQueueManager.OnStartup:
        public void OnStartup() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0x0055B820)(ref this); // .text:0055AB50 ; void __thiscall UIQueueManager::OnStartup(UIQueueManager *this) .text:0055AB50 ?OnStartup@UIQueueManager@@UAEXXZ

        // UIQueueManager.ProcessEphemeralNetBlob:
        // public void ProcessEphemeralNetBlob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, NetBlob*, void>)0xDEADBEEF)(ref this, blob); // .text:0055D0C0 ; void __thiscall UIQueueManager::ProcessEphemeralNetBlob(UIQueueManager *this, NetBlob *blob) .text:0055D0C0 ?ProcessEphemeralNetBlob@UIQueueManager@@MAEXPAVNetBlob@@@Z

        // UIQueueManager.ProcessNetBlobData:
        // public UInt32 ProcessNetBlobData(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void*, UInt32, UInt32>)0xDEADBEEF)(ref this, buff, size); // .text:0055B000 ; unsigned int __thiscall UIQueueManager::ProcessNetBlobData(UIQueueManager *this, void *buff, unsigned int size) .text:0055B000 ?ProcessNetBlobData@UIQueueManager@@IAEKPAXI@Z

        // UIQueueManager.ProcessOrderedNetBlob:
        // public void ProcessOrderedNetBlob(NetBlob* blob) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, NetBlob*, void>)0xDEADBEEF)(ref this, blob); // .text:0055D060 ; void __thiscall UIQueueManager::ProcessOrderedNetBlob(UIQueueManager *this, NetBlob *blob) .text:0055D060 ?ProcessOrderedNetBlob@UIQueueManager@@MAEXPAVNetBlob@@@Z

        // UIQueueManager.QueryInterface:
        // public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, TResult*, Turbine_GUID*, void**, TResult*>)0xDEADBEEF)(ref this, result, i_rcInterface, o_ppvInterface); // .text:0055A5D0 ; TResult *__thiscall UIQueueManager::QueryInterface(UIQueueManager *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0055A5D0 ?QueryInterface@UIQueueManager@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // UIQueueManager.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, UInt32>)0x0055B7F0)(ref this); // .text:0055AB20 ; unsigned int __thiscall UIQueueManager::Release(UIQueueManager *this) .text:0055AB20 ?Release@UIQueueManager@@UBEKXZ

        // UIQueueManager.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref UIQueueManager, void>)0x0055E050)(ref this); // .text:0055D330 ; void __thiscall UIQueueManager::UseTime(UIQueueManager *this) .text:0055D330 ?UseTime@UIQueueManager@@UAEXXZ
    }

    public unsafe struct ClientUISystem {
        // Struct:
        public ClientSystem a0;
        public IInputActionCallback a1;
        public Turbine_RefCount m_cTurbineRefCount;
        public UInt32 m_cBusy;
        public UInt32 groundObject;
        public UInt32 requestedGroundObject;
        public UInt32 vendorID;
        public UInt32 attemptOpenVendorID;
        public UInt32 attemptSaleObjectID;
        public Target_Mode targetMode;
        public UInt32 m_didCurrentCursor;
        public CSoundTable* soundTable;
        public Byte m_bLeaveTargetMode;
        public CameraSet* m_pCameraSet;
        public Byte m_bRadarVisible;
        public Byte m_bRadarBlank;
        public override string ToString() => $"a0(ClientSystem):{a0}, a1(IInputActionCallback):{a1}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_cBusy:{m_cBusy:X8}, groundObject:{groundObject:X8}, requestedGroundObject:{requestedGroundObject:X8}, vendorID:{vendorID:X8}, attemptOpenVendorID:{attemptOpenVendorID:X8}, attemptSaleObjectID:{attemptSaleObjectID:X8}, targetMode(Target_Mode):{targetMode}, m_didCurrentCursor:{m_didCurrentCursor:X8}, soundTable:->(CSoundTable*)0x{(int)soundTable:X8}, m_bLeaveTargetMode:{m_bLeaveTargetMode:X2}, m_pCameraSet:->(CameraSet*)0x{(int)m_pCameraSet:X8}, m_bRadarVisible:{m_bRadarVisible:X2}, m_bRadarBlank:{m_bRadarBlank:X2}";

        // Functions:

        // ClientUISystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565540)(ref this); // .text:005647A0 ; void __thiscall ClientUISystem::ClientUISystem(ClientUISystem *this) .text:005647A0 ??0ClientUISystem@@QAE@XZ

        // ClientUISystem.AccessCameraSet:
        public CameraSet* AccessCameraSet() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, CameraSet*>)0x00564F90)(ref this); // .text:005641F0 ; CameraSet *__thiscall ClientUISystem::AccessCameraSet(ClientUISystem *this) .text:005641F0 ?AccessCameraSet@ClientUISystem@@QAEPAVCameraSet@@XZ

        // ClientUISystem.AddRef:
        public UInt32 AddRef() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32>)0x0056F560)(ref this); // .text:0056E7B0 ; unsigned int __thiscall ClientUISystem::AddRef(ClientCommunicationSystem *this) .text:0056E7B0 ?AddRef@ClientUISystem@@UBEKXZ

        // ClientUISystem.AttemptSellToVendor:
        public void AttemptSellToVendor(UInt32 _vendorID, UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, UInt32, void>)0x00564DB0)(ref this, _vendorID, _objectID); // .text:00564010 ; void __thiscall ClientUISystem::AttemptSellToVendor(ClientUISystem *this, unsigned int _vendorID, unsigned int _objectID) .text:00564010 ?AttemptSellToVendor@ClientUISystem@@QAEXKK@Z

        // ClientUISystem.CleanUpGameUI:
        public void CleanUpGameUI() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565640)(ref this); // .text:005648A0 ; void __thiscall ClientUISystem::CleanUpGameUI(ClientUISystem *this) .text:005648A0 ?CleanUpGameUI@ClientUISystem@@QAEXXZ

        // ClientUISystem.CloseVendor:
        public void CloseVendor(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, Byte, void>)0x00564E10)(ref this, _updating); // .text:00564070 ; void __thiscall ClientUISystem::CloseVendor(ClientUISystem *this, bool _updating) .text:00564070 ?CloseVendor@ClientUISystem@@QAEX_N@Z

        // ClientUISystem.DecrementBusyCount:
        public void DecrementBusyCount() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565630)(ref this); // .text:00564890 ; void __thiscall ClientUISystem::DecrementBusyCount(ClientUISystem *this) .text:00564890 ?DecrementBusyCount@ClientUISystem@@QAEXXZ

        // ClientUISystem.DeltaTimeToString:
        public static Byte DeltaTimeToString(Double time, PStringBase<UInt16>* dst) => ((delegate* unmanaged[Cdecl]<Double, PStringBase<UInt16>*, Byte>)0x00566BB0)(time, dst); // .text:00565E10 ; bool __cdecl ClientUISystem::DeltaTimeToString(const long double time, PStringBase<unsigned short> *dst) .text:00565E10 ?DeltaTimeToString@ClientUISystem@@SA_NNAAV?$PStringBase@G@@@Z

        // ClientUISystem.ExamineObject:
        public void ExamineObject(UInt32 i_iid) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, void>)0x005657B0)(ref this, i_iid); // .text:00564A10 ; void __thiscall ClientUISystem::ExamineObject(ClientUISystem *this, unsigned int i_iid) .text:00564A10 ?ExamineObject@ClientUISystem@@QAEXK@Z

        // ClientUISystem.ExamineSpell:
        public void ExamineSpell(UInt32 i_spellID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, void>)0x00565810)(ref this, i_spellID); // .text:00564A70 ; void __thiscall ClientUISystem::ExamineSpell(ClientUISystem *this, unsigned int i_spellID) .text:00564A70 ?ExamineSpell@ClientUISystem@@QAEXK@Z

        // ClientUISystem.ExecuteTargetModeForItem:
        public void ExecuteTargetModeForItem(UInt32 _itemID, Target_Mode _mode) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Target_Mode, void>)0x005658D0)(ref this, _itemID, _mode); // .text:00564B30 ; void __thiscall ClientUISystem::ExecuteTargetModeForItem(ClientUISystem *this, unsigned int _itemID, Target_Mode _mode) .text:00564B30 ?ExecuteTargetModeForItem@ClientUISystem@@QAEXKW4Target_Mode@@@Z

        // ClientUISystem.ExecuteTargetModeForSpell:
        public void ExecuteTargetModeForSpell(UInt32 _spellID, Target_Mode _mode) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Target_Mode, void>)0x00565910)(ref this, _spellID, _mode); // .text:00564B70 ; void __thiscall ClientUISystem::ExecuteTargetModeForSpell(ClientUISystem *this, unsigned int _spellID, Target_Mode _mode) .text:00564B70 ?ExecuteTargetModeForSpell@ClientUISystem@@QAEXKW4Target_Mode@@@Z

        // ClientUISystem.GetUISoundTable:
        public CSoundTable* GetUISoundTable() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, CSoundTable*>)0x00564D50)(ref this); // .text:00563FB0 ; CSoundTable *__thiscall ClientUISystem::GetUISoundTable(ClientUISystem *this) .text:00563FB0 ?GetUISoundTable@ClientUISystem@@QAEPBVCSoundTable@@XZ

        // ClientUISystem.GetUISystem:
        public static ClientUISystem* GetUISystem() => ((delegate* unmanaged[Cdecl]<ClientUISystem*>)0x00564D30)(); // .text:00563F90 ; ClientUISystem *__cdecl ClientUISystem::GetUISystem() .text:00563F90 ?GetUISystem@ClientUISystem@@SAPAV1@XZ

        // ClientUISystem.Handle_Character__ConfirmationDone:
        public UInt32 Handle_Character__ConfirmationDone(int confirm, UInt32 context) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, int, UInt32, UInt32>)0x00564F20)(ref this, confirm, context); // .text:00564180 ; unsigned int __thiscall ClientUISystem::Handle_Character__ConfirmationDone(ClientUISystem *this, int confirm, unsigned int context) .text:00564180 ?Handle_Character__ConfirmationDone@ClientUISystem@@QAEKJK@Z

        // ClientUISystem.Handle_Character__ConfirmationRequest:
        public UInt32 Handle_Character__ConfirmationRequest(int confirm, UInt32 context, AC1Legacy.PStringBase<char>* userData) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, int, UInt32, AC1Legacy.PStringBase<char>*, UInt32>)0x00564E40)(ref this, confirm, context, userData); // .text:005640A0 ; unsigned int __thiscall ClientUISystem::Handle_Character__ConfirmationRequest(ClientUISystem *this, int confirm, unsigned int context, AC1Legacy::PStringBase<char> *userData) .text:005640A0 ?Handle_Character__ConfirmationRequest@ClientUISystem@@QAEKJKABV?$PStringBase@D@AC1Legacy@@@Z

        // ClientUISystem.Handle_Character__ReturnPing:
        // public UInt32 Handle_Character__ReturnPing() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32>)0xDEADBEEF)(ref this); // .text:00564090 ; unsigned int __thiscall ClientUISystem::Handle_Character__ReturnPing(ClientUISystem *this) .text:00564090 ?Handle_Character__ReturnPing@ClientUISystem@@QAEKXZ

        // ClientUISystem.Handle_Character__StartBarber:
        public UInt32 Handle_Character__StartBarber(UInt32 _base_palette, UInt32 _head_object, UInt32 _head_texture, UInt32 _default_head_texture, UInt32 _eyes_texture, UInt32 _default_eyes_texture, UInt32 _nose_texture, UInt32 _default_nose_texture, UInt32 _mouth_texture, UInt32 _default_mouth_texture, UInt32 _skin_palette, UInt32 _hair_palette, UInt32 _eyes_palette, UInt32 _setup_id, int option1, int option2) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, int, int, UInt32>)0x00565050)(ref this, _base_palette, _head_object, _head_texture, _default_head_texture, _eyes_texture, _default_eyes_texture, _nose_texture, _default_nose_texture, _mouth_texture, _default_mouth_texture, _skin_palette, _hair_palette, _eyes_palette, _setup_id, option1, option2); // .text:005642B0 ; unsigned int __thiscall ClientUISystem::Handle_Character__StartBarber(ClientUISystem *this, IDClass<_tagDataID,32,0> _base_palette, IDClass<_tagDataID,32,0> _head_object, IDClass<_tagDataID,32,0> _head_texture, IDClass<_tagDataID,32,0> _default_head_texture, IDClass<_tagDataID,32,0> _eyes_texture, IDClass<_tagDataID,32,0> _default_eyes_texture, IDClass<_tagDataID,32,0> _nose_texture, IDClass<_tagDataID,32,0> _default_nose_texture, IDClass<_tagDataID,32,0> _mouth_texture, IDClass<_tagDataID,32,0> _default_mouth_texture, IDClass<_tagDataID,32,0> _skin_palette, IDClass<_tagDataID,32,0> _hair_palette, IDClass<_tagDataID,32,0> _eyes_palette, IDClass<_tagDataID,32,0> _setup_id, int option1, int option2) .text:005642B0 ?Handle_Character__StartBarber@ClientUISystem@@QAEKV?$IDClass@U_tagDataID@@$0CA@$0A@@@0000000000000JJ@Z

        // ClientUISystem.Handle_Inventory__Recv_SalvageOperationsResultData:
        public UInt32 Handle_Inventory__Recv_SalvageOperationsResultData(SalvageOperationsResultData* operationsResultData) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, SalvageOperationsResultData*, UInt32>)0x005663C0)(ref this, operationsResultData); // .text:00565620 ; unsigned int __thiscall ClientUISystem::Handle_Inventory__Recv_SalvageOperationsResultData(ClientUISystem *this, SalvageOperationsResultData *operationsResultData) .text:00565620 ?Handle_Inventory__Recv_SalvageOperationsResultData@ClientUISystem@@QAEKABVSalvageOperationsResultData@@@Z

        // ClientUISystem.Handle_Item__QueryItemManaResponse:
        public UInt32 Handle_Item__QueryItemManaResponse(UInt32 target, Single mana, int fSuccess) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Single, int, UInt32>)0x00564D80)(ref this, target, mana, fSuccess); // .text:00563FE0 ; unsigned int __thiscall ClientUISystem::Handle_Item__QueryItemManaResponse(ClientUISystem *this, unsigned int target, float mana, int fSuccess) .text:00563FE0 ?Handle_Item__QueryItemManaResponse@ClientUISystem@@QAEKKMH@Z

        // ClientUISystem.Handle_Item__UseDone:
        public UInt32 Handle_Item__UseDone(UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, UInt32>)0x005656A0)(ref this, etype); // .text:00564900 ; unsigned int __thiscall ClientUISystem::Handle_Item__UseDone(ClientUISystem *this, const unsigned int etype) .text:00564900 ?Handle_Item__UseDone@ClientUISystem@@QAEKK@Z

        // ClientUISystem.Handle_Login__WorldInfo:
        public UInt32 Handle_Login__WorldInfo(int cConnections, int cMaxConnections, AC1Legacy.PStringBase<char>* strWorldName) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, int, int, AC1Legacy.PStringBase<char>*, UInt32>)0x00564F40)(ref this, cConnections, cMaxConnections, strWorldName); // .text:005641A0 ; unsigned int __thiscall ClientUISystem::Handle_Login__WorldInfo(ClientUISystem *this, int cConnections, int cMaxConnections, AC1Legacy::PStringBase<char> *strWorldName) .text:005641A0 ?Handle_Login__WorldInfo@ClientUISystem@@QAEKJJABV?$PStringBase@D@AC1Legacy@@@Z

        // ClientUISystem.Handle_Misc__PortalStorm:
        // public UInt32 Handle_Misc__PortalStorm() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32>)0xDEADBEEF)(ref this); // .text:00565170 ; unsigned int __thiscall ClientUISystem::Handle_Misc__PortalStorm(ClientUISystem *this) .text:00565170 ?Handle_Misc__PortalStorm@ClientUISystem@@QAEKXZ

        // ClientUISystem.Handle_Misc__PortalStormBrewing:
        public UInt32 Handle_Misc__PortalStormBrewing(Single extent) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, Single, UInt32>)0x00565D70)(ref this, extent); // .text:00564FD0 ; unsigned int __thiscall ClientUISystem::Handle_Misc__PortalStormBrewing(ClientUISystem *this, float extent) .text:00564FD0 ?Handle_Misc__PortalStormBrewing@ClientUISystem@@QAEKM@Z

        // ClientUISystem.Handle_Misc__PortalStormImminent:
        public UInt32 Handle_Misc__PortalStormImminent(Single extent) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, Single, UInt32>)0x00565E40)(ref this, extent); // .text:005650A0 ; unsigned int __thiscall ClientUISystem::Handle_Misc__PortalStormImminent(ClientUISystem *this, float extent) .text:005650A0 ?Handle_Misc__PortalStormImminent@ClientUISystem@@QAEKM@Z

        // ClientUISystem.Handle_Misc__PortalStormSubsided:
        public UInt32 Handle_Misc__PortalStormSubsided() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32>)0x00565CD0)(ref this); // .text:00564F30 ; unsigned int __thiscall ClientUISystem::Handle_Misc__PortalStormSubsided(ClientUISystem *this) .text:00564F30 ?Handle_Misc__PortalStormSubsided@ClientUISystem@@QAEKXZ

        // ClientUISystem.Handle_Social__AddOrSetCharacterTitle:
        public UInt32 Handle_Social__AddOrSetCharacterTitle(UInt32 newTitle, int bSetAsDisplayTitle) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, int, UInt32>)0x00565000)(ref this, newTitle, bSetAsDisplayTitle); // .text:00564260 ; unsigned int __thiscall ClientUISystem::Handle_Social__AddOrSetCharacterTitle(ClientUISystem *this, unsigned int newTitle, int bSetAsDisplayTitle) .text:00564260 ?Handle_Social__AddOrSetCharacterTitle@ClientUISystem@@QAEKKH@Z

        // ClientUISystem.Handle_Social__CharacterTitleTable:
        public UInt32 Handle_Social__CharacterTitleTable(CharacterTitleTable* titleTable) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, CharacterTitleTable*, UInt32>)0x00564FE0)(ref this, titleTable); // .text:00564240 ; unsigned int __thiscall ClientUISystem::Handle_Social__CharacterTitleTable(ClientUISystem *this, CharacterTitleTable *titleTable) .text:00564240 ?Handle_Social__CharacterTitleTable@ClientUISystem@@QAEKABVCharacterTitleTable@@@Z

        // ClientUISystem.Handle_Social__FriendsUpdate:
        public UInt32 Handle_Social__FriendsUpdate(FriendDataList* friendDataList, int updateType) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, FriendDataList*, int, UInt32>)0x00564FC0)(ref this, friendDataList, updateType); // .text:00564220 ; unsigned int __thiscall ClientUISystem::Handle_Social__FriendsUpdate(ClientUISystem *this, FriendDataList *friendDataList, int updateType) .text:00564220 ?Handle_Social__FriendsUpdate@ClientUISystem@@QAEKABVFriendDataList@@J@Z

        // ClientUISystem.Handle_Social__SendClientContractTracker:
        public UInt32 Handle_Social__SendClientContractTracker(CContractTracker* contractTracker, int bDeleteContract, int bSetAsDisplayContract) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, CContractTracker*, int, int, UInt32>)0x005654F0)(ref this, contractTracker, bDeleteContract, bSetAsDisplayContract); // .text:00564750 ; unsigned int __thiscall ClientUISystem::Handle_Social__SendClientContractTracker(ClientUISystem *this, CContractTracker *contractTracker, int bDeleteContract, int bSetAsDisplayContract) .text:00564750 ?Handle_Social__SendClientContractTracker@ClientUISystem@@QAEKABVCContractTracker@@HH@Z

        // ClientUISystem.Handle_Social__SendClientContractTrackerTable:
        public UInt32 Handle_Social__SendClientContractTrackerTable(CContractTrackerTable* contractTrackerTable) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, CContractTrackerTable*, UInt32>)0x00565030)(ref this, contractTrackerTable); // .text:00564290 ; unsigned int __thiscall ClientUISystem::Handle_Social__SendClientContractTrackerTable(ClientUISystem *this, CContractTrackerTable *contractTrackerTable) .text:00564290 ?Handle_Social__SendClientContractTrackerTable@ClientUISystem@@QAEKABVCContractTrackerTable@@@Z

        // ClientUISystem.Handle_VendorInfo:
        public void Handle_VendorInfo(void* buff, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void*, UInt32, void>)0x00566AB0)(ref this, buff, size); // .text:00565D10 ; void __thiscall ClientUISystem::Handle_VendorInfo(ClientUISystem *this, void *buff, unsigned int size) .text:00565D10 ?Handle_VendorInfo@ClientUISystem@@QAEXPAXI@Z

        // ClientUISystem.IncrementBusyCount:
        public void IncrementBusyCount() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565610)(ref this); // .text:00564870 ; void __thiscall ClientUISystem::IncrementBusyCount(ClientUISystem *this) .text:00564870 ?IncrementBusyCount@ClientUISystem@@QAEXXZ

        // ClientUISystem.InitializeCameraSet:
        public void InitializeCameraSet(SmartBox* i_pSmartBox) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, SmartBox*, void>)0x00564F60)(ref this, i_pSmartBox); // .text:005641C0 ; void __thiscall ClientUISystem::InitializeCameraSet(ClientUISystem *this, SmartBox *i_pSmartBox) .text:005641C0 ?InitializeCameraSet@ClientUISystem@@QAEXPAVSmartBox@@@Z

        // ClientUISystem.OnAction:
        public Byte OnAction(InputEvent* i_evt) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, InputEvent*, Byte>)0x00565930)(ref this, i_evt); // .text:00564B90 ; bool __thiscall ClientUISystem::OnAction(ClientUISystem *this, InputEvent *i_evt) .text:00564B90 ?OnAction@ClientUISystem@@MAE_NABVInputEvent@@@Z

        // ClientUISystem.OnBeginCharacterSession:
        public void OnBeginCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565380)(ref this); // .text:005645E0 ; void __thiscall ClientUISystem::OnBeginCharacterSession(ClientUISystem *this) .text:005645E0 ?OnBeginCharacterSession@ClientUISystem@@MAEXXZ

        // ClientUISystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565870)(ref this); // .text:00564AD0 ; void __thiscall ClientUISystem::OnEndCharacterSession(ClientUISystem *this) .text:00564AD0 ?OnEndCharacterSession@ClientUISystem@@MAEXXZ

        // ClientUISystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565170)(ref this); // .text:005643D0 ; void __thiscall ClientUISystem::OnShutdown(ClientUISystem *this) .text:005643D0 ?OnShutdown@ClientUISystem@@MAEXXZ

        // ClientUISystem.OnStartup:
        public void OnStartup() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00564D40)(ref this); // .text:00563FA0 ; void __thiscall ClientUISystem::OnStartup(ClientUISystem *this) .text:00563FA0 ?OnStartup@ClientUISystem@@MAEXXZ

        // ClientUISystem.OnViewContents:
        public void OnViewContents(UInt32 obj, PackableList<ContentProfile>* contents) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, PackableList<ContentProfile>*, void>)0x00566610)(ref this, obj, contents); // .text:00565870 ; void __thiscall ClientUISystem::OnViewContents(ClientUISystem *this, unsigned int obj, PackableList<ContentProfile> *contents) .text:00565870 ?OnViewContents@ClientUISystem@@QAEXKAAV?$PackableList@VContentProfile@@@@@Z

        // ClientUISystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, TResult*, Turbine_GUID*, void**, TResult*>)0x005651E0)(ref this, result, i_rcInterface, o_ppvInterface); // .text:00564440 ; TResult *__thiscall ClientUISystem::QueryInterface(ClientUISystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:00564440 ?QueryInterface@ClientUISystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientUISystem.RecvNotice_ToggleChatEntry:
        public void RecvNotice_ToggleChatEntry(Byte i_bActive) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, Byte, void>)0x00564FA0)(ref this, i_bActive); // .text:00564200 ; void __thiscall ClientUISystem::RecvNotice_ToggleChatEntry(ClientUISystem *this, bool i_bActive) .text:00564200 ?RecvNotice_ToggleChatEntry@ClientUISystem@@MAEX_N@Z

        // ClientUISystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32>)0x00565140)(ref this); // .text:005643A0 ; unsigned int __thiscall ClientUISystem::Release(ClientUISystem *this) .text:005643A0 ?Release@ClientUISystem@@UBEKXZ

        // ClientUISystem.SetGroundObject:
        public void SetGroundObject(UInt32 _groundObject, Byte _askServer) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Byte, void>)0x005652B0)(ref this, _groundObject, _askServer); // .text:00564510 ; void __thiscall ClientUISystem::SetGroundObject(ClientUISystem *this, unsigned int _groundObject, bool _askServer) .text:00564510 ?SetGroundObject@ClientUISystem@@QAEXK_N@Z

        // ClientUISystem.SetTargetMode:
        public void SetTargetMode(Target_Mode i_targetMode) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, Target_Mode, void>)0x005656E0)(ref this, i_targetMode); // .text:00564940 ; void __thiscall ClientUISystem::SetTargetMode(ClientUISystem *this, Target_Mode i_targetMode) .text:00564940 ?SetTargetMode@ClientUISystem@@QAEXW4Target_Mode@@@Z

        // ClientUISystem.TargetedUsageCallback:
        public static void TargetedUsageCallback(PropertyCollection* i_rcResults) => ((delegate* unmanaged[Cdecl]<PropertyCollection*, void>)0x00566700)(i_rcResults); // .text:00565960 ; void __cdecl ClientUISystem::TargetedUsageCallback(PropertyCollection *i_rcResults) .text:00565960 ?TargetedUsageCallback@ClientUISystem@@SAXABVPropertyCollection@@@Z

        // ClientUISystem.TargetedUsageConfirmation_ManaStone:
        public Byte TargetedUsageConfirmation_ManaStone(UInt32 toolID, UInt32 targetID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, UInt32, Byte>)0x00566EE0)(ref this, toolID, targetID); // .text:00566140 ; bool __thiscall ClientUISystem::TargetedUsageConfirmation_ManaStone(ClientUISystem *this, unsigned int toolID, unsigned int targetID) .text:00566140 ?TargetedUsageConfirmation_ManaStone@ClientUISystem@@QAE_NKK@Z

        // ClientUISystem.TargetedUsageConfirmation_Salvage:
        public Byte TargetedUsageConfirmation_Salvage(UInt32 toolID, UInt32 targetID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, UInt32, Byte>)0x00567790)(ref this, toolID, targetID); // .text:005669F0 ; bool __thiscall ClientUISystem::TargetedUsageConfirmation_Salvage(ClientUISystem *this, unsigned int toolID, unsigned int targetID) .text:005669F0 ?TargetedUsageConfirmation_Salvage@ClientUISystem@@QAE_NKK@Z

        // ClientUISystem.UpdateCursorState:
        public void UpdateCursorState() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x005653D0)(ref this); // .text:00564630 ; void __thiscall ClientUISystem::UpdateCursorState(ClientUISystem *this) .text:00564630 ?UpdateCursorState@ClientUISystem@@QAEXXZ

        // ClientUISystem.UsageCallback:
        public static void UsageCallback(PropertyCollection* i_rcResults) => ((delegate* unmanaged[Cdecl]<PropertyCollection*, void>)0x005668C0)(i_rcResults); // .text:00565B20 ; void __cdecl ClientUISystem::UsageCallback(PropertyCollection *i_rcResults) .text:00565B20 ?UsageCallback@ClientUISystem@@SAXABVPropertyCollection@@@Z

        // ClientUISystem.UsageConfirmation_NPKAltar:
        public Byte UsageConfirmation_NPKAltar(UInt32 altarID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Byte>)0x005673B0)(ref this, altarID); // .text:00566610 ; bool __thiscall ClientUISystem::UsageConfirmation_NPKAltar(ClientUISystem *this, unsigned int altarID) .text:00566610 ?UsageConfirmation_NPKAltar@ClientUISystem@@QAE_NK@Z

        // ClientUISystem.UsageConfirmation_PKAltar:
        public Byte UsageConfirmation_PKAltar(UInt32 altarID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Byte>)0x005671C0)(ref this, altarID); // .text:00566420 ; bool __thiscall ClientUISystem::UsageConfirmation_PKAltar(ClientUISystem *this, unsigned int altarID) .text:00566420 ?UsageConfirmation_PKAltar@ClientUISystem@@QAE_NK@Z

        // ClientUISystem.UsageConfirmation_VolatileRare:
        public Byte UsageConfirmation_VolatileRare(UInt32 rareID) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, Byte>)0x005675A0)(ref this, rareID); // .text:00566800 ; bool __thiscall ClientUISystem::UsageConfirmation_VolatileRare(ClientUISystem *this, unsigned int rareID) .text:00566800 ?UsageConfirmation_VolatileRare@ClientUISystem@@QAE_NK@Z

        // ClientUISystem.UseObject:
        public void UseObject(UInt32 i_iid) => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, UInt32, void>)0x00565750)(ref this, i_iid); // .text:005649B0 ; void __thiscall ClientUISystem::UseObject(ClientUISystem *this, unsigned int i_iid) .text:005649B0 ?UseObject@ClientUISystem@@QAEXK@Z

        // ClientUISystem.UseTime:
        public void UseTime() => ((delegate* unmanaged[Thiscall]<ref ClientUISystem, void>)0x00565F90)(ref this); // .text:005651F0 ; void __thiscall ClientUISystem::UseTime(ClientUISystem *this) .text:005651F0 ?UseTime@ClientUISystem@@MAEXXZ

        // Globals:
        public static ClientUISystem** s_pUISystem = (ClientUISystem**)0x00871354; // .data:00870344 ; ClientUISystem *ClientUISystem::s_pUISystem .data:00870344 ?s_pUISystem@ClientUISystem@@1PAV1@A
    }
    public unsafe struct Proto_UI {

        // Functions:

        // Proto_UI.GetNextUICounter:
        public static UInt32 GetNextUICounter() => ((delegate* unmanaged[Cdecl]<UInt32>)0x005473A0)(); // .text:005467E0 ; unsigned int __cdecl Proto_UI::GetNextUICounter() .text:005467E0 ?GetNextUICounter@Proto_UI@@YAIXZ

        // Proto_UI.LogOffCharacter:
        public static int LogOffCharacter(UInt32 gid) => ((delegate* unmanaged[Cdecl]<UInt32, int>)0x005475E0)(gid); // .text:00546A20 ; int __cdecl Proto_UI::LogOffCharacter(unsigned int gid) .text:00546A20 ?LogOffCharacter@Proto_UI@@YAHK@Z

        // Proto_UI.SendAdminGetServerVersion:
        public static int SendAdminGetServerVersion() => ((delegate* unmanaged[Cdecl]<int>)0x00547610)(); // .text:00546A50 ; int __cdecl Proto_UI::SendAdminGetServerVersion() .text:00546A50 ?SendAdminGetServerVersion@Proto_UI@@YAHXZ

        // Proto_UI.SendAdminRestoreCharacter:
        public static int SendAdminRestoreCharacter(UInt32 iid, PStringBase<char>* i_restoredCharName, PStringBase<char>* i_acctToRestoreTo) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<char>*, PStringBase<char>*, int>)0x005478B0)(iid, i_restoredCharName, i_acctToRestoreTo); // .text:00546CF0 ; int __cdecl Proto_UI::SendAdminRestoreCharacter(unsigned int iid, PStringBase<char> *i_restoredCharName, PStringBase<char> *i_acctToRestoreTo) .text:00546CF0 ?SendAdminRestoreCharacter@Proto_UI@@YAHKABV?$PStringBase@D@@0@Z

        // Proto_UI.SendBlob:
        public static int SendBlob(NetBlob* pBlob) => ((delegate* unmanaged[Cdecl]<NetBlob*, int>)0x00547300)(pBlob); // .text:00546740 ; int __cdecl Proto_UI::SendBlob(NetBlob *pBlob) .text:00546740 ?SendBlob@Proto_UI@@YAHPAVNetBlob@@@Z

        // Proto_UI.SendCharGenResult:
        public static bool SendCharGenResult(ACCharGenResult* _charGenResult, accountID account) => ((delegate* unmanaged[Cdecl]<ACCharGenResult*, accountID, bool>)0x00547630)(_charGenResult, account); // .text:00546A70 ; int __cdecl Proto_UI::SendCharGenResult(CharGenResult *_charGenResult, accountID account, int _secure) .text:00546A70 ?SendCharGenResult@Proto_UI@@YAHPAVCharGenResult@@VaccountID@@H@Z

        // Proto_UI.SendDeleteCharacter:
        public static int SendDeleteCharacter(accountID account, int slot) => ((delegate* unmanaged[Cdecl]<accountID, int, int>)0x005476F0)(account, slot); // .text:00546B30 ; int __cdecl Proto_UI::SendDeleteCharacter(accountID account, int slot) .text:00546B30 ?SendDeleteCharacter@Proto_UI@@YAHVaccountID@@H@Z

        // Proto_UI.SendEnterWorld:
        public static int SendEnterWorld(UInt32 gid, accountID account) => ((delegate* unmanaged[Cdecl]<UInt32, accountID, int>)0x00547780)(gid, account); // .text:00546BC0 ; int __cdecl Proto_UI::SendEnterWorld(unsigned int gid, accountID account) .text:00546BC0 ?SendEnterWorld@Proto_UI@@YAHKVaccountID@@@Z

        // Proto_UI.SendEnterWorldRequest:
        public static int SendEnterWorldRequest() => ((delegate* unmanaged[Cdecl]<int>)0x005475C0)(); // .text:00546A00 ; int __cdecl Proto_UI::SendEnterWorldRequest() .text:00546A00 ?SendEnterWorldRequest@Proto_UI@@YAHXZ

        // Proto_UI.SendForceObjdesc:
        public static int SendForceObjdesc(UInt32 object_id) => ((delegate* unmanaged[Cdecl]<UInt32, int>)0x00547590)(object_id); // .text:005469D0 ; int __cdecl Proto_UI::SendForceObjdesc(unsigned int object_id) .text:005469D0 ?SendForceObjdesc@Proto_UI@@YAHK@Z

        // Proto_UI.SendFriendsCommand:
        public static int SendFriendsCommand(UInt32 cmd, PStringBase<char>* i_player) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<char>*, int>)0x00547810)(cmd, i_player); // .text:00546C50 ; int __cdecl Proto_UI::SendFriendsCommand(unsigned int cmd, PStringBase<char> *i_player) .text:00546C50 ?SendFriendsCommand@Proto_UI@@YAHIABV?$PStringBase@D@@@Z

        // Proto_UI.SendToControl:
        public static Byte SendToControl(char* buf, int size) => ((delegate* unmanaged[Cdecl]<char*, int, Byte>)0x00547440)(buf, size); // .text:00546880 ; bool __cdecl Proto_UI::SendToControl(char *buf, int size) .text:00546880 ?SendToControl@Proto_UI@@YA_NPAEH@Z

        // Proto_UI.SendToDatabase:
        public static Byte SendToDatabase(char* buf, int size) => ((delegate* unmanaged[Cdecl]<char*, int, Byte>)0x00547520)(buf, size); // .text:00546960 ; bool __cdecl Proto_UI::SendToDatabase(char *buf, int size) .text:00546960 ?SendToDatabase@Proto_UI@@YA_NPAEH@Z

        // Proto_UI.SendToLogon:
        public static Byte SendToLogon(char* buf, int size) => ((delegate* unmanaged[Cdecl]<char*, int, Byte>)0x005474B0)(buf, size); // .text:005468F0 ; bool __cdecl Proto_UI::SendToLogon(char *buf, int size) .text:005468F0 ?SendToLogon@Proto_UI@@YA_NPAEH@Z

        // Proto_UI.SendToWeenie:
        public static Byte SendToWeenie(char* buf, int size) => ((delegate* unmanaged[Cdecl]<char*, int, Byte>)0x005473D0)(buf, size); // .text:00546810 ; bool __cdecl Proto_UI::SendToWeenie(char *buf, int size) .text:00546810 ?SendToWeenie@Proto_UI@@YA_NPAEH@Z

        // Proto_UI.SetEventCounter:
        public static void SetEventCounter(UInt32 tsVal) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x005473C0)(tsVal); // .text:00546800 ; void __cdecl Proto_UI::SetEventCounter(unsigned int tsVal) .text:00546800 ?SetEventCounter@Proto_UI@@YAXI@Z

        // Proto_UI.UICounterFailedSend:
        public static void UICounterFailedSend(UInt32 in_value) => ((delegate* unmanaged[Cdecl]<UInt32, void>)0x005473B0)(in_value); // .text:005467F0 ; void __cdecl Proto_UI::UICounterFailedSend(unsigned int in_value) .text:005467F0 ?UICounterFailedSend@Proto_UI@@YAXI@Z

        // Globals:
        public static UInt32* eventCounter_ = (UInt32*)0x00846F38; // .data:00845F28 ; unsigned int Proto_UI::eventCounter_ .data:00845F28 ?eventCounter_@Proto_UI@@3IA
        public static UInt16* m_UnorderedStamp = (UInt16*)0x00846F3C; // .data:00845F2C ; unsigned __int16 Proto_UI::m_UnorderedStamp .data:00845F2C ?m_UnorderedStamp@Proto_UI@@3GA
    }

}