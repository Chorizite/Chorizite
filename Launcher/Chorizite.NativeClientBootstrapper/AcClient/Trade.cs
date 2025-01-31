using System;
using System.Runtime.InteropServices;

namespace AcClient {

    public unsafe struct Trade {
        // Struct:
        public PackObj a0;
        public PackableList<ContentProfile> _self_list;
        public PackableList<ContentProfile> _partner_list;
        public UInt32 _partner;
        public Double _stamp;
        public UInt32 _status;
        public int _initiator;
        public int _accepted;
        public int _p_accepted;
        public override string ToString() => $"a0(PackObj):{a0}, _self_list(PackableList<ContentProfile>):{_self_list}, _partner_list(PackableList<ContentProfile>):{_partner_list}, _partner:{_partner:X8}, _stamp:{_stamp:n5}, _status:{_status:X8}, _initiator(int):{_initiator}, _accepted(int):{_accepted}, _p_accepted(int):{_p_accepted}";

        // Functions:

        // Trade.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Trade, void>)0x005BB6A0)(ref this); // .text:005BA560 ; void __thiscall Trade::Trade(Trade *this) .text:005BA560 ??0Trade@@QAE@XZ

        // Trade.AddItem:
        public int AddItem(UInt32 item, PackableList<ContentProfile>* list, UInt32 loc) => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32, PackableList<ContentProfile>*, UInt32, int>)0x005BB2F0)(ref this, item, list, loc); // .text:005BA1B0 ; int __thiscall Trade::AddItem(Trade *this, unsigned int item, PackableList<ContentProfile> *list, unsigned int loc) .text:005BA1B0 ?AddItem@Trade@@IAEHKAAV?$PackableList@VContentProfile@@@@K@Z

        // Trade.AddItem:
        public int AddItem(UInt32 item, UInt32 id, UInt32 loc) => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32, UInt32, UInt32, int>)0x005BB450)(ref this, item, id, loc); // .text:005BA310 ; int __thiscall Trade::AddItem(Trade *this, unsigned int item, unsigned int id, unsigned int loc) .text:005BA310 ?AddItem@Trade@@QAEHKKK@Z

        // Trade.GetNumContainers:
        public UInt32 GetNumContainers() => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32>)0x005BB1E0)(ref this); // .text:005BA0A0 ; unsigned int __thiscall Trade::GetNumContainers(Trade *this) .text:005BA0A0 ?GetNumContainers@Trade@@QBEKXZ

        // Trade.GetNumItems:
        public UInt32 GetNumItems() => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32>)0x005BB1C0)(ref this); // .text:005BA080 ; unsigned int __thiscall Trade::GetNumItems(Trade *this) .text:005BA080 ?GetNumItems@Trade@@QBEKXZ

        // Trade.GetNumPartnerContainers:
        public UInt32 GetNumPartnerContainers() => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32>)0x005BB220)(ref this); // .text:005BA0E0 ; unsigned int __thiscall Trade::GetNumPartnerContainers(Trade *this) .text:005BA0E0 ?GetNumPartnerContainers@Trade@@QBEKXZ

        // Trade.GetNumPartnerItems:
        public UInt32 GetNumPartnerItems() => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32>)0x005BB200)(ref this); // .text:005BA0C0 ; unsigned int __thiscall Trade::GetNumPartnerItems(Trade *this) .text:005BA0C0 ?GetNumPartnerItems@Trade@@QBEKXZ

        // Trade.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32>)0x005BB060)(ref this); // .text:005B9F20 ; unsigned int __thiscall Trade::GetPackSize(Trade *this) .text:005B9F20 ?GetPackSize@Trade@@MAEIXZ

        // Trade.IsPartnerTradingItem:
        public int IsPartnerTradingItem(UInt32 item) => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32, int>)0x005BB0E0)(ref this, item); // .text:005B9FA0 ; int __thiscall Trade::IsPartnerTradingItem(Trade *this, unsigned int item) .text:005B9FA0 ?IsPartnerTradingItem@Trade@@QBEHK@Z

        // Trade.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Trade, void**, UInt32, UInt32>)0x005BB130)(ref this, addr, size); // .text:005B9FF0 ; unsigned int __thiscall Trade::Pack(Trade *this, void **addr, unsigned int size) .text:005B9FF0 ?Pack@Trade@@UAEIAAPAXI@Z

        // Trade.Register:
        public int Register(UInt32 partner, Double stamp) => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32, Double, int>)0x005BB030)(ref this, partner, stamp); // .text:005B9EF0 ; int __thiscall Trade::Register(Trade *this, unsigned int partner, long double stamp) .text:005B9EF0 ?Register@Trade@@QAEHKN@Z

        // Trade.RemoveItem:
        public int RemoveItem(UInt32 item, UInt32 id) => ((delegate* unmanaged[Thiscall]<ref Trade, UInt32, UInt32, int>)0x005BB4E0)(ref this, item, id); // .text:005BA3A0 ; int __thiscall Trade::RemoveItem(Trade *this, unsigned int item, unsigned int id) .text:005BA3A0 ?RemoveItem@Trade@@QAEHKK@Z

        // Trade.Reset:
        public int Reset() => ((delegate* unmanaged[Thiscall]<ref Trade, int>)0x005BB570)(ref this); // .text:005BA430 ; int __thiscall Trade::Reset(Trade *this) .text:005BA430 ?Reset@Trade@@QAEHXZ

        // Trade.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Trade, void**, UInt32, int>)0x005BB5A0)(ref this, addr, size); // .text:005BA460 ; int __thiscall Trade::UnPack(Trade *this, void **addr, unsigned int size) .text:005BA460 ?UnPack@Trade@@UAEHAAPAXI@Z
    }



    public unsafe struct ClientTradeSystem {
        // Struct:
        public ClientSystem a0;
        public Turbine_RefCount m_cTurbineRefCount;
        public Trade* m_pTrade;
        public UInt32 m_iidTradeInitiator;
        public UInt32 m_iidTradePartner;
        public UInt32 attemptTradeToPlayerID;
        public UInt32 attemptTradeObjectID;
        public override string ToString() => $"a0(ClientSystem):{a0}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_pTrade:->(Trade*)0x{(int)m_pTrade:X8}, m_iidTradeInitiator:{m_iidTradeInitiator:X8}, m_iidTradePartner:{m_iidTradePartner:X8}, attemptTradeToPlayerID:{attemptTradeToPlayerID:X8}, attemptTradeObjectID:{attemptTradeObjectID:X8}";

        // Functions:

        // ClientTradeSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056EB10)(ref this); // .text:0056DD60 ; void __thiscall ClientTradeSystem::ClientTradeSystem(ClientTradeSystem *this) .text:0056DD60 ??0ClientTradeSystem@@QAE@XZ

        // ClientTradeSystem.AcceptTrade:
        public void AcceptTrade() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E7A0)(ref this); // .text:0056D9F0 ; void __thiscall ClientTradeSystem::AcceptTrade(ClientTradeSystem *this) .text:0056D9F0 ?AcceptTrade@ClientTradeSystem@@QAEXXZ

        // ClientTradeSystem.AddItemToSelfTradeList:
        public void AddItemToSelfTradeList(UInt32 i_iidItem, int i_nPos) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, int, void>)0x0056E780)(ref this, i_iidItem, i_nPos); // .text:0056D9D0 ; void __thiscall ClientTradeSystem::AddItemToSelfTradeList(ClientTradeSystem *this, unsigned int i_iidItem, int i_nPos) .text:0056D9D0 ?AddItemToSelfTradeList@ClientTradeSystem@@QAEXKJ@Z

        // ClientTradeSystem.AddPartnerItem:
        public Byte AddPartnerItem(UInt32 itemID, UInt32 pos) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, Byte>)0x0056EEB0)(ref this, itemID, pos); // .text:0056E100 ; bool __thiscall ClientTradeSystem::AddPartnerItem(ClientTradeSystem *this, unsigned int itemID, unsigned int pos) .text:0056E100 ?AddPartnerItem@ClientTradeSystem@@IAE_NKK@Z

        // ClientTradeSystem.AttemptToOpenTradeNegotiations:
        public Byte AttemptToOpenTradeNegotiations(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, Byte>)0x0056EC90)(ref this, i_iidPlayer); // .text:0056DEE0 ; bool __thiscall ClientTradeSystem::AttemptToOpenTradeNegotiations(ClientTradeSystem *this, unsigned int i_iidPlayer) .text:0056DEE0 ?AttemptToOpenTradeNegotiations@ClientTradeSystem@@QAE_NK@Z

        // ClientTradeSystem.AttemptToTradeItem:
        public void AttemptToTradeItem(UInt32 idPlayer, UInt32 idObject) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, void>)0x0056ED30)(ref this, idPlayer, idObject); // .text:0056DF80 ; void __thiscall ClientTradeSystem::AttemptToTradeItem(ClientTradeSystem *this, unsigned int idPlayer, unsigned int idObject) .text:0056DF80 ?AttemptToTradeItem@ClientTradeSystem@@QAEXKK@Z

        // ClientTradeSystem.CloseTradeNegotiations:
        public void CloseTradeNegotiations() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E7E0)(ref this); // .text:0056DA30 ; void __thiscall ClientTradeSystem::CloseTradeNegotiations(ClientTradeSystem *this) .text:0056DA30 ?CloseTradeNegotiations@ClientTradeSystem@@QAEXXZ

        // ClientTradeSystem.DeclineTrade:
        public void DeclineTrade() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E7C0)(ref this); // .text:0056DA10 ; void __thiscall ClientTradeSystem::DeclineTrade(ClientTradeSystem *this) .text:0056DA10 ?DeclineTrade@ClientTradeSystem@@QAEXXZ

        // ClientTradeSystem.GetItemLocationInPartnerTradeList:
        public int GetItemLocationInPartnerTradeList(UInt32 i_iidItem) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, int>)0x0056EB80)(ref this, i_iidItem); // .text:0056DDD0 ; int __thiscall ClientTradeSystem::GetItemLocationInPartnerTradeList(ClientTradeSystem *this, unsigned int i_iidItem) .text:0056DDD0 ?GetItemLocationInPartnerTradeList@ClientTradeSystem@@QAEJK@Z

        // ClientTradeSystem.GetNumPartnerObjectsInTrade:
        public UInt32 GetNumPartnerObjectsInTrade() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32>)0x0056E810)(ref this); // .text:0056DA60 ; unsigned int __thiscall ClientTradeSystem::GetNumPartnerObjectsInTrade(ClientTradeSystem *this) .text:0056DA60 ?GetNumPartnerObjectsInTrade@ClientTradeSystem@@QBEKXZ

        // ClientTradeSystem.GetNumSelfObjectsInTrade:
        public UInt32 GetNumSelfObjectsInTrade() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32>)0x0056E7F0)(ref this); // .text:0056DA40 ; unsigned int __thiscall ClientTradeSystem::GetNumSelfObjectsInTrade(ClientTradeSystem *this) .text:0056DA40 ?GetNumSelfObjectsInTrade@ClientTradeSystem@@QBEKXZ

        // ClientTradeSystem.GetTradeSystem:
        public static ClientTradeSystem* GetTradeSystem() => ((delegate* unmanaged[Cdecl]<ClientTradeSystem*>)0x0056E6B0)(); // .text:0056D900 ; ClientTradeSystem *__cdecl ClientTradeSystem::GetTradeSystem() .text:0056D900 ?GetTradeSystem@ClientTradeSystem@@SAPAV1@XZ
        /*
        TODO. here are the hooks.
.text:006ADD72                 call    ?Handle_Trade__Recv_AcceptTrade@ClientTradeSystem@@QAEKK@Z ; ClientTradeSystem::Handle_Trade__Recv_AcceptTrade(ulong)
.text:006ADDB2                 call    ?Handle_Trade__Recv_AddToTrade@ClientTradeSystem@@QAEKKKK@Z ; ClientTradeSystem::Handle_Trade__Recv_AddToTrade(ulong,ulong,ulong)
.text:006ADDDE                 jmp     ?Handle_Trade__Recv_ClearTradeAcceptance@ClientTradeSystem@@QAEKXZ ; ClientTradeSystem::Handle_Trade__Recv_ClearTradeAcceptance(void)
.text:006ADE12                 call    ?Handle_Trade__Recv_CloseTrade@ClientTradeSystem@@QAEKK@Z ; ClientTradeSystem::Handle_Trade__Recv_CloseTrade(ulong)
.text:006ADE42                 call    ?Handle_Trade__Recv_DeclineTrade@ClientTradeSystem@@QAEKK@Z ; ClientTradeSystem::Handle_Trade__Recv_DeclineTrade(ulong)
.text:006ADE72                 call    ?Handle_Trade__Recv_OpenTrade@ClientTradeSystem@@QAEKK@Z ; ClientTradeSystem::Handle_Trade__Recv_OpenTrade(ulong)
.text:006ADEC7                 call    ?Handle_Trade__Recv_RegisterTrade@ClientTradeSystem@@QAEKKKN@Z ; ClientTradeSystem::Handle_Trade__Recv_RegisterTrade(ulong,ulong,double)
.text:006ADF0A                 call    ?Handle_Trade__Recv_RemoveFromTrade@ClientTradeSystem@@QAEKKK@Z ; ClientTradeSystem::Handle_Trade__Recv_RemoveFromTrade(ulong,ulong)
.text:006ADF32                 call    ?Handle_Trade__Recv_ResetTrade@ClientTradeSystem@@QAEKK@Z ; ClientTradeSystem::Handle_Trade__Recv_ResetTrade(ulong)
.text:006ADF6A                 call    ?Handle_Trade__Recv_TradeFailure@ClientTradeSystem@@QAEKKK@Z ; ClientTradeSystem::Handle_Trade__Recv_TradeFailure(ulong,ulong)
        */
        // ClientTradeSystem.Handle_Trade__Recv_AcceptTrade:
        public UInt32 Handle_Trade__Recv_AcceptTrade(UInt32 source) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32>)0x0056E9F0)(ref this, source); // .text:0056DC40 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_AcceptTrade(ClientTradeSystem *this, unsigned int source) .text:0056DC40 ?Handle_Trade__Recv_AcceptTrade@ClientTradeSystem@@QAEKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_AddToTrade:
        public UInt32 Handle_Trade__Recv_AddToTrade(UInt32 item, UInt32 id, UInt32 loc) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, UInt32, UInt32>)0x0056EF90)(ref this, item, id, loc); // .text:0056E1E0 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_AddToTrade(ClientTradeSystem *this, unsigned int item, unsigned int id, unsigned int loc) .text:0056E1E0 ?Handle_Trade__Recv_AddToTrade@ClientTradeSystem@@QAEKKKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_ClearTradeAcceptance:
        public UInt32 Handle_Trade__Recv_ClearTradeAcceptance() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32>)0x0056E770)(ref this); // .text:0056D9C0 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_ClearTradeAcceptance(ClientTradeSystem *this) .text:0056D9C0 ?Handle_Trade__Recv_ClearTradeAcceptance@ClientTradeSystem@@QAEKXZ

        // ClientTradeSystem.Handle_Trade__Recv_CloseTrade:
        public UInt32 Handle_Trade__Recv_CloseTrade(UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32>)0x0056EBE0)(ref this, etype); // .text:0056DE30 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_CloseTrade(ClientTradeSystem *this, unsigned int etype) .text:0056DE30 ?Handle_Trade__Recv_CloseTrade@ClientTradeSystem@@QAEKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_DeclineTrade:
        public UInt32 Handle_Trade__Recv_DeclineTrade(UInt32 source) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32>)0x0056EA90)(ref this, source); // .text:0056DCE0 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_DeclineTrade(ClientTradeSystem *this, unsigned int source) .text:0056DCE0 ?Handle_Trade__Recv_DeclineTrade@ClientTradeSystem@@QAEKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_OpenTrade:
        public UInt32 Handle_Trade__Recv_OpenTrade(UInt32 source) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32>)0x0056E6E0)(ref this, source); // .text:0056D930 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_OpenTrade(ClientTradeSystem *this, unsigned int source) .text:0056D930 ?Handle_Trade__Recv_OpenTrade@ClientTradeSystem@@QAEKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_RegisterTrade:
        public UInt32 Handle_Trade__Recv_RegisterTrade(UInt32 initiator, UInt32 partner, Double stamp) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, Double, UInt32>)0x0056EE00)(ref this, initiator, partner, stamp); // .text:0056E050 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_RegisterTrade(ClientTradeSystem *this, unsigned int initiator, unsigned int partner, long double stamp) .text:0056E050 ?Handle_Trade__Recv_RegisterTrade@ClientTradeSystem@@QAEKKKN@Z

        // ClientTradeSystem.Handle_Trade__Recv_RemoveFromTrade:
        public UInt32 Handle_Trade__Recv_RemoveFromTrade(UInt32 i_iidItem, UInt32 id) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, UInt32>)0x0056E9B0)(ref this, i_iidItem, id); // .text:0056DC00 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_RemoveFromTrade(ClientTradeSystem *this, unsigned int i_iidItem, unsigned int id) .text:0056DC00 ?Handle_Trade__Recv_RemoveFromTrade@ClientTradeSystem@@QAEKKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_ResetTrade:
        public UInt32 Handle_Trade__Recv_ResetTrade(UInt32 source) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32>)0x0056E700)(ref this, source); // .text:0056D950 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_ResetTrade(ClientTradeSystem *this, unsigned int source) .text:0056D950 ?Handle_Trade__Recv_ResetTrade@ClientTradeSystem@@QAEKK@Z

        // ClientTradeSystem.Handle_Trade__Recv_TradeFailure:
        public UInt32 Handle_Trade__Recv_TradeFailure(UInt32 i_iidItem, UInt32 etype) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, UInt32, UInt32>)0x0056E740)(ref this, i_iidItem, etype); // .text:0056D990 ; unsigned int __thiscall ClientTradeSystem::Handle_Trade__Recv_TradeFailure(ClientTradeSystem *this, unsigned int i_iidItem, unsigned int etype) .text:0056D990 ?Handle_Trade__Recv_TradeFailure@ClientTradeSystem@@QAEKKK@Z

        // ClientTradeSystem.IsPartnerTradingItem:
        public Byte IsPartnerTradingItem(UInt32 i_iidItem) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32, Byte>)0x0056E830)(ref this, i_iidItem); // .text:0056DA80 ; bool __thiscall ClientTradeSystem::IsPartnerTradingItem(ClientTradeSystem *this, unsigned int i_iidItem) .text:0056DA80 ?IsPartnerTradingItem@ClientTradeSystem@@QAE_NK@Z

        // ClientTradeSystem.NotifyServerThatTradeIsOutOfSync:
        public void NotifyServerThatTradeIsOutOfSync() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056EFF0)(ref this); // .text:0056E240 ; void __thiscall ClientTradeSystem::NotifyServerThatTradeIsOutOfSync(ClientTradeSystem *this) .text:0056E240 ?NotifyServerThatTradeIsOutOfSync@ClientTradeSystem@@QAEXXZ

        // ClientTradeSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E850)(ref this); // .text:0056DAA0 ; void __thiscall ClientTradeSystem::OnEndCharacterSession(ClientTradeSystem *this) .text:0056DAA0 ?OnEndCharacterSession@ClientTradeSystem@@MAEXXZ

        // ClientTradeSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E6C0)(ref this); // .text:0056D910 ; void __thiscall ClientTradeSystem::OnShutdown(ClientTradeSystem *this) .text:0056D910 ?OnShutdown@ClientTradeSystem@@MAEXXZ

        // ClientTradeSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x0056E8E0)(ref this, result, i_rcInterface, o_ppvInterface); // .text:0056DB30 ; TResult *__thiscall ClientTradeSystem::QueryInterface(ClientTradeSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:0056DB30 ?QueryInterface@ClientTradeSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientTradeSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, UInt32>)0x0056EBB0)(ref this); // .text:0056DE00 ; unsigned int __thiscall ClientTradeSystem::Release(ClientTradeSystem *this) .text:0056DE00 ?Release@ClientTradeSystem@@UBEKXZ

        // ClientTradeSystem.ResetTrade:
        public void ResetTrade() => ((delegate* unmanaged[Thiscall]<ref ClientTradeSystem, void>)0x0056E7D0)(ref this); // .text:0056DA20 ; void __thiscall ClientTradeSystem::ResetTrade(ClientTradeSystem *this) .text:0056DA20 ?ResetTrade@ClientTradeSystem@@QAEXXZ

        // Globals:
        public static ClientTradeSystem* s_pTradeSystem = *(ClientTradeSystem**)0x0087174C; // .data:0087073C ; ClientTradeSystem *ClientTradeSystem::s_pTradeSystem .data:0087073C ?s_pTradeSystem@ClientTradeSystem@@1PAV1@A
    }


    public unsafe struct ContentProfile {
        // Struct:
        public PackObj a0;
        public UInt32 m_iid;
        public UInt32 m_uContainerProperties;
        public override string ToString() => $"a0(PackObj):{a0}, m_iid:{m_iid:X8}, m_uContainerProperties:{m_uContainerProperties:X8}";

        // Functions:

        // ContentProfile.__Ctor:
        public void __Ctor(UInt32 iid) => ((delegate* unmanaged[Thiscall]<ref ContentProfile, UInt32, void>)0x006B0DA0)(ref this, iid); // .text:006AFED0 ; void __thiscall ContentProfile::ContentProfile(ContentProfile *this, unsigned int iid) .text:006AFED0 ??0ContentProfile@@QAE@K@Z

        // ContentProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ContentProfile, void>)0x006B0DC0)(ref this); // .text:006AFEF0 ; void __thiscall ContentProfile::ContentProfile(ContentProfile *this) .text:006AFEF0 ??0ContentProfile@@QAE@XZ

        // ContentProfile.operator_is_equal:
        public int operator_is_equal(Enchantment* rhs) => ((delegate* unmanaged[Thiscall]<ref ContentProfile, Enchantment*, int>)0x006B0D80)(ref this, rhs); // .text:006AFEB0 ; int __thiscall ContentProfile::operator==(Enchantment *this, Enchantment *rhs) .text:006AFEB0 ??8ContentProfile@@QAEHABV0@@Z

        // ContentProfile.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ContentProfile, void**, UInt32, UInt32>)0x005A9890)(ref this, addr, size); // .text:005A87E0 ; unsigned int __thiscall ContentProfile::Pack(CloTextureEffect *this, void **addr, unsigned int size) .text:005A87E0 ?Pack@ContentProfile@@UAEIAAPAXI@Z

        // ContentProfile.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ContentProfile, void**, UInt32, int>)0x006B0DE0)(ref this, addr, size); // .text:006AFF10 ; int __thiscall ContentProfile::UnPack(ContentProfile *this, void **addr, unsigned int size) .text:006AFF10 ?UnPack@ContentProfile@@UAEHAAPAXI@Z
    }



    /// <summary>
    /// gmSecureTradeUI* mine = (gmSecureTradeUI*)GlobalEventHandler.geh->ResolveHandler(5100083);
    /// </summary>
    public unsafe struct gmSecureTradeUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public ObjectRangeHandler a2;
        public ItemListDragHandler a3;
        public UIElement_Button* m_pTradeButton;
        public UIElement_Text* m_pSelfPlayerName;
        public UIElement_Text* m_pSelfTotalItemsLabel;
        public UIElement_ItemList* m_pSelfItemsList;
        public UIElement* m_pOtherTradeStatusIndicator;
        public UIElement_Text* m_pOtherPlayerName;
        public UIElement_Text* m_pOtherTotalItemsLabel;
        public UIElement_ItemList* m_pOtherItemsList;
        public UIElement_Button* m_pClearAllItemsButton;
        public UInt32 splitItemID;
        public UInt32 splitItemClassID;
        public UInt32 splitItemStackSize;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(ObjectRangeHandler):{a2}, a3(ItemListDragHandler):{a3}, m_pTradeButton:->(UIElement_Button*)0x{(int)m_pTradeButton:X8}, m_pSelfPlayerName:->(UIElement_Text*)0x{(int)m_pSelfPlayerName:X8}, m_pSelfTotalItemsLabel:->(UIElement_Text*)0x{(int)m_pSelfTotalItemsLabel:X8}, m_pSelfItemsList:->(UIElement_ItemList*)0x{(int)m_pSelfItemsList:X8}, m_pOtherTradeStatusIndicator:->(UIElement*)0x{(int)m_pOtherTradeStatusIndicator:X8}, m_pOtherPlayerName:->(UIElement_Text*)0x{(int)m_pOtherPlayerName:X8}, m_pOtherTotalItemsLabel:->(UIElement_Text*)0x{(int)m_pOtherTotalItemsLabel:X8}, m_pOtherItemsList:->(UIElement_ItemList*)0x{(int)m_pOtherItemsList:X8}, m_pClearAllItemsButton:->(UIElement_Button*)0x{(int)m_pClearAllItemsButton:X8}, splitItemID:{splitItemID:X8}, splitItemClassID:{splitItemClassID:X8}, splitItemStackSize:{splitItemStackSize:X8}";

        // Functions:

        // gmSecureTradeUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, LayoutDesc*, ElementDesc*, void>)0x004CA3B0)(ref this, _layout, _full_desc); // .text:004C97C0 ; void __thiscall gmSecureTradeUI::gmSecureTradeUI(gmSecureTradeUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C97C0 ??0gmSecureTradeUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmSecureTradeUI.AcceptDragObject:
        public Byte AcceptDragObject(UInt32 i_iidObject) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, Byte>)0x004CB630)(ref this, i_iidObject); // .text:004CAA40 ; bool __thiscall gmSecureTradeUI::AcceptDragObject(gmSecureTradeUI *this, unsigned int i_iidObject) .text:004CAA40 ?AcceptDragObject@gmSecureTradeUI@@IAE_NK@Z

        // gmSecureTradeUI.AcceptTheTrade:
        public void AcceptTheTrade() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA600)(ref this); // .text:004C9A10 ; void __thiscall gmSecureTradeUI::AcceptTheTrade(gmSecureTradeUI *this) .text:004C9A10 ?AcceptTheTrade@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.AddItem:
        public int AddItem(UInt32 _itemID, int _position, Byte _removeDuplicates, Byte _addContents, Byte _excludeIfUnacceptable) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, int, Byte, Byte, Byte, int>)0x004CB370)(ref this, _itemID, _position, _removeDuplicates, _addContents, _excludeIfUnacceptable); // .text:004CA780 ; int __thiscall gmSecureTradeUI::AddItem(gmSecureTradeUI *this, unsigned int _itemID, int _position, bool _removeDuplicates, bool _addContents, bool _excludeIfUnacceptable) .text:004CA780 ?AddItem@gmSecureTradeUI@@IAEHKH_N00@Z

        // gmSecureTradeUI.AddMyItem:
        public Byte AddMyItem(UInt32 i_iidItem, UInt32 i_uiPos) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, Byte>)0x004CAA70)(ref this, i_iidItem, i_uiPos); // .text:004C9E80 ; bool __thiscall gmSecureTradeUI::AddMyItem(gmSecureTradeUI *this, unsigned int i_iidItem, unsigned int i_uiPos) .text:004C9E80 ?AddMyItem@gmSecureTradeUI@@IAE_NKK@Z

        // gmSecureTradeUI.AddPartnerItem:
        public Byte AddPartnerItem(UInt32 i_iidItem, UInt32 i_uiPos) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, Byte>)0x004CAB20)(ref this, i_iidItem, i_uiPos); // .text:004C9F30 ; bool __thiscall gmSecureTradeUI::AddPartnerItem(gmSecureTradeUI *this, unsigned int i_iidItem, unsigned int i_uiPos) .text:004C9F30 ?AddPartnerItem@gmSecureTradeUI@@IAE_NKK@Z

        // gmSecureTradeUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004CA480)(_layout, _full_desc); // .text:004C9890 ; UIElement *__cdecl gmSecureTradeUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C9890 ?Create@gmSecureTradeUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmSecureTradeUI.DeclineTheTrade:
        public void DeclineTheTrade() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA680)(ref this); // .text:004C9A90 ; void __thiscall gmSecureTradeUI::DeclineTheTrade(gmSecureTradeUI *this) .text:004C9A90 ?DeclineTheTrade@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.DragItemAcceptable:
        public Byte DragItemAcceptable(UInt32 i_iidItem, Byte _silent) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, Byte, Byte>)0x004CB290)(ref this, i_iidItem, _silent); // .text:004CA6A0 ; bool __thiscall gmSecureTradeUI::DragItemAcceptable(gmSecureTradeUI *this, unsigned int i_iidItem, bool _silent) .text:004CA6A0 ?DragItemAcceptable@gmSecureTradeUI@@IAE_NK_N@Z

        // gmSecureTradeUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UIElement*>)0x004CA2C0)(ref this, i_eType); // .text:004C96D0 ; UIElement *__thiscall gmSecureTradeUI::DynamicCast(gmSecureTradeUI *this, unsigned int i_eType) .text:004C96D0 ?DynamicCast@gmSecureTradeUI@@UAEPAVUIElement@@K@Z

        // gmSecureTradeUI.FlushTradeLists:
        public void FlushTradeLists() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA6B0)(ref this); // .text:004C9AC0 ; void __thiscall gmSecureTradeUI::FlushTradeLists(gmSecureTradeUI *this) .text:004C9AC0 ?FlushTradeLists@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32>)0x004CA2E0)(ref this); // .text:004C96F0 ; unsigned int __thiscall gmSecureTradeUI::GetUIElementType(gmSecureTradeUI *this) .text:004C96F0 ?GetUIElementType@gmSecureTradeUI@@UBEKXZ

        // gmSecureTradeUI.HandleDropRelease:
        public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UIElementMessageInfo*, void>)0x004CBA00)(ref this, i_rMsg); // .text:004CAE10 ; void __thiscall gmSecureTradeUI::HandleDropRelease(gmSecureTradeUI *this, UIElementMessageInfo *i_rMsg) .text:004CAE10 ?HandleDropRelease@gmSecureTradeUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmSecureTradeUI.ItemAttributesChanged:
        public void ItemAttributesChanged(UInt32 i_iidItem, int _flags) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, int, void>)0x004CB5C0)(ref this, i_iidItem, _flags); // .text:004CA9D0 ; void __thiscall gmSecureTradeUI::ItemAttributesChanged(gmSecureTradeUI *this, unsigned int i_iidItem, int _flags) .text:004CA9D0 ?ItemAttributesChanged@gmSecureTradeUI@@IAEXKH@Z

        // gmSecureTradeUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004CBA70)(ref this, i_rMsg); // .text:004CAE80 ; UIElementMessageListenResult __thiscall gmSecureTradeUI::ListenToElementMessage(gmSecureTradeUI *this, UIElementMessageInfo *i_rMsg) .text:004CAE80 ?ListenToElementMessage@gmSecureTradeUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmSecureTradeUI.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004CB570)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004CA980 ; bool __thiscall gmSecureTradeUI::OnItemListDragOver(gmSecureTradeUI *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004CA980 ?OnItemListDragOver@gmSecureTradeUI@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // gmSecureTradeUI.OnObjectRangeExit:
        public void OnObjectRangeExit(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CB0B0)(ref this, _objectID); // .text:004CA4C0 ; void __thiscall gmSecureTradeUI::OnObjectRangeExit(gmSecureTradeUI *this, unsigned int _objectID) .text:004CA4C0 ?OnObjectRangeExit@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, Byte, void>)0x004CB060)(ref this, i_bVisible); // .text:004CA470 ; void __thiscall gmSecureTradeUI::OnVisibilityChanged(gmSecureTradeUI *this, bool i_bVisible) .text:004CA470 ?OnVisibilityChanged@gmSecureTradeUI@@MAEX_N@Z

        // gmSecureTradeUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CAD50)(ref this); // .text:004CA160 ; void __thiscall gmSecureTradeUI::PostInit(gmSecureTradeUI *this) .text:004CA160 ?PostInit@gmSecureTradeUI@@UAEXXZ

        // gmSecureTradeUI.RecvNotice_AcceptTrade:
        public void RecvNotice_AcceptTrade(UInt32 i_iidSource) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CA8D0)(ref this, i_iidSource); // .text:004C9CE0 ; void __thiscall gmSecureTradeUI::RecvNotice_AcceptTrade(gmSecureTradeUI *this, unsigned int i_iidSource) .text:004C9CE0 ?RecvNotice_AcceptTrade@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_AddItemToTrade:
        public void RecvNotice_AddItemToTrade(UInt32 i_iidItem, UInt32 i_eTradeListID, UInt32 i_uiPos) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, UInt32, void>)0x004CB0F0)(ref this, i_iidItem, i_eTradeListID, i_uiPos); // .text:004CA500 ; void __thiscall gmSecureTradeUI::RecvNotice_AddItemToTrade(gmSecureTradeUI *this, unsigned int i_iidItem, unsigned int i_eTradeListID, unsigned int i_uiPos) .text:004CA500 ?RecvNotice_AddItemToTrade@gmSecureTradeUI@@MAEXKKK@Z

        // gmSecureTradeUI.RecvNotice_ClearTradeAcceptance:
        public void RecvNotice_ClearTradeAcceptance() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CB130)(ref this); // .text:004CA540 ; void __thiscall gmSecureTradeUI::RecvNotice_ClearTradeAcceptance(gmSecureTradeUI *this) .text:004CA540 ?RecvNotice_ClearTradeAcceptance@gmSecureTradeUI@@MAEXXZ

        // gmSecureTradeUI.RecvNotice_CloseTrade:
        public void RecvNotice_CloseTrade(UInt32 i_eError) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CB140)(ref this, i_eError); // .text:004CA550 ; void __thiscall gmSecureTradeUI::RecvNotice_CloseTrade(gmSecureTradeUI *this, unsigned int i_eError) .text:004CA550 ?RecvNotice_CloseTrade@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_DeclineTrade:
        public void RecvNotice_DeclineTrade(UInt32 i_iidSource) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CA960)(ref this, i_iidSource); // .text:004C9D70 ; void __thiscall gmSecureTradeUI::RecvNotice_DeclineTrade(gmSecureTradeUI *this, unsigned int i_iidSource) .text:004C9D70 ?RecvNotice_DeclineTrade@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_ItemAttributesChanged:
        public void RecvNotice_ItemAttributesChanged(UInt32 i_iidObject, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, void>)0x004CB930)(ref this, i_iidObject, i_attrib); // .text:004CAD40 ; void __thiscall gmSecureTradeUI::RecvNotice_ItemAttributesChanged(gmSecureTradeUI *this, unsigned int i_iidObject, unsigned int i_attrib) .text:004CAD40 ?RecvNotice_ItemAttributesChanged@gmSecureTradeUI@@MAEXKK@Z

        // gmSecureTradeUI.RecvNotice_RegisterTrade:
        public void RecvNotice_RegisterTrade(UInt32 i_iidInitiator, UInt32 i_iidPartner, Double i_ttStamp) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, Double, void>)0x004CB1B0)(ref this, i_iidInitiator, i_iidPartner, i_ttStamp); // .text:004CA5C0 ; void __thiscall gmSecureTradeUI::RecvNotice_RegisterTrade(gmSecureTradeUI *this, unsigned int i_iidInitiator, unsigned int i_iidPartner, long double i_ttStamp) .text:004CA5C0 ?RecvNotice_RegisterTrade@gmSecureTradeUI@@MAEXKKN@Z

        // gmSecureTradeUI.RecvNotice_RemoveItemFromTrade:
        public void RecvNotice_RemoveItemFromTrade(UInt32 i_iidItem, UInt32 i_eTradeListID) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, void>)0x004CB220)(ref this, i_iidItem, i_eTradeListID); // .text:004CA630 ; void __thiscall gmSecureTradeUI::RecvNotice_RemoveItemFromTrade(gmSecureTradeUI *this, unsigned int i_iidItem, unsigned int i_eTradeListID) .text:004CA630 ?RecvNotice_RemoveItemFromTrade@gmSecureTradeUI@@MAEXKK@Z

        // gmSecureTradeUI.RecvNotice_ResetTrade:
        public void RecvNotice_ResetTrade(UInt32 i_iidSource) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CB260)(ref this, i_iidSource); // .text:004CA670 ; void __thiscall gmSecureTradeUI::RecvNotice_ResetTrade(gmSecureTradeUI *this, unsigned int i_iidSource) .text:004CA670 ?RecvNotice_ResetTrade@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_ServerSaysAttemptFailed:
        public void RecvNotice_ServerSaysAttemptFailed(UInt32 i_iidItem) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CA4B0)(ref this, i_iidItem); // .text:004C98C0 ; void __thiscall gmSecureTradeUI::RecvNotice_ServerSaysAttemptFailed(gmSecureTradeUI *this, unsigned int i_iidItem) .text:004C98C0 ?RecvNotice_ServerSaysAttemptFailed@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 i_itemID, UInt32 i_oldContainer, UInt32 i_oldWielder, UInt32 i_oldLocation, UInt32 i_newContainer, int i_place, UInt32 i_newWielder, UInt32 i_newLocation) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004CB920)(ref this, i_itemID, i_oldContainer, i_oldWielder, i_oldLocation, i_newContainer, i_place, i_newWielder, i_newLocation); // .text:004CAD30 ; void __thiscall gmSecureTradeUI::RecvNotice_ServerSaysMoveItem(gmSecureTradeUI *this, unsigned int i_itemID, unsigned int i_oldContainer, unsigned int i_oldWielder, unsigned int i_oldLocation, unsigned int i_newContainer, int i_place, unsigned int i_newWielder, unsigned int i_newLocation) .text:004CAD30 ?RecvNotice_ServerSaysMoveItem@gmSecureTradeUI@@MAEXKKKKKHKK@Z

        // gmSecureTradeUI.RecvNotice_TradeAnItemForDummies:
        public void RecvNotice_TradeAnItemForDummies(UInt32 i_iidObject) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CBB20)(ref this, i_iidObject); // .text:004CAF30 ; void __thiscall gmSecureTradeUI::RecvNotice_TradeAnItemForDummies(gmSecureTradeUI *this, unsigned int i_iidObject) .text:004CAF30 ?RecvNotice_TradeAnItemForDummies@gmSecureTradeUI@@MAEXK@Z

        // gmSecureTradeUI.RecvNotice_TradeFailure:
        public void RecvNotice_TradeFailure(UInt32 i_iidItem, UInt32 i_eError) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, void>)0x004CB270)(ref this, i_iidItem, i_eError); // .text:004CA680 ; void __thiscall gmSecureTradeUI::RecvNotice_TradeFailure(gmSecureTradeUI *this, unsigned int i_iidItem, unsigned int i_eError) .text:004CA680 ?RecvNotice_TradeFailure@gmSecureTradeUI@@MAEXKK@Z

        // gmSecureTradeUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004CA8B0)(); // .text:004C9CC0 ; void __cdecl gmSecureTradeUI::Register() .text:004C9CC0 ?Register@gmSecureTradeUI@@SAXXZ

        // gmSecureTradeUI.RemoveAddedItem:
        public Byte RemoveAddedItem(UInt32 itemID) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, Byte>)0x004CABB0)(ref this, itemID); // .text:004C9FC0 ; bool __thiscall gmSecureTradeUI::RemoveAddedItem(gmSecureTradeUI *this, unsigned int itemID) .text:004C9FC0 ?RemoveAddedItem@gmSecureTradeUI@@IAE_NK@Z

        // gmSecureTradeUI.RemoveItem:
        public void RemoveItem(ACCWeenieObject* i_pItem) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, ACCWeenieObject*, void>)0x004CA7D0)(ref this, i_pItem); // .text:004C9BE0 ; void __thiscall gmSecureTradeUI::RemoveItem(gmSecureTradeUI *this, ACCWeenieObject *i_pItem) .text:004C9BE0 ?RemoveItem@gmSecureTradeUI@@IAEXPAVACCWeenieObject@@@Z

        // gmSecureTradeUI.RemovePartnerItem:
        public Byte RemovePartnerItem(UInt32 itemID) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, Byte>)0x004CAC50)(ref this, itemID); // .text:004CA060 ; bool __thiscall gmSecureTradeUI::RemovePartnerItem(gmSecureTradeUI *this, unsigned int itemID) .text:004CA060 ?RemovePartnerItem@gmSecureTradeUI@@IAE_NK@Z

        // gmSecureTradeUI.Reset:
        public void Reset() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CACF0)(ref this); // .text:004CA100 ; void __thiscall gmSecureTradeUI::Reset(gmSecureTradeUI *this) .text:004CA100 ?Reset@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.ServerSaysMoveItem:
        public void ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004CB810)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004CAC20 ; void __thiscall gmSecureTradeUI::ServerSaysMoveItem(gmSecureTradeUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004CAC20 ?ServerSaysMoveItem@gmSecureTradeUI@@IAEXKKKKKHKK@Z

        // gmSecureTradeUI.SetMyItemNumber:
        public void SetMyItemNumber() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA4C0)(ref this); // .text:004C98D0 ; void __thiscall gmSecureTradeUI::SetMyItemNumber(gmSecureTradeUI *this) .text:004C98D0 ?SetMyItemNumber@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.SetOtherItemNumber:
        public void SetOtherItemNumber() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA560)(ref this); // .text:004C9970 ; void __thiscall gmSecureTradeUI::SetOtherItemNumber(gmSecureTradeUI *this) .text:004C9970 ?SetOtherItemNumber@gmSecureTradeUI@@IAEXXZ

        // gmSecureTradeUI.SetTradePartner:
        public void SetTradePartner(UInt32 i_iidPartner) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, void>)0x004CA9C0)(ref this, i_iidPartner); // .text:004C9DD0 ; void __thiscall gmSecureTradeUI::SetTradePartner(gmSecureTradeUI *this, unsigned int i_iidPartner) .text:004C9DD0 ?SetTradePartner@gmSecureTradeUI@@IAEXK@Z

        // gmSecureTradeUI.TradeAnItemForDummies:
        public Byte TradeAnItemForDummies(UInt32 i_iidItemToTrade) => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, UInt32, Byte>)0x004CB940)(ref this, i_iidItemToTrade); // .text:004CAD50 ; bool __thiscall gmSecureTradeUI::TradeAnItemForDummies(gmSecureTradeUI *this, unsigned int i_iidItemToTrade) .text:004CAD50 ?TradeAnItemForDummies@gmSecureTradeUI@@IAE_NK@Z

        // gmSecureTradeUI.UpdateTradeButtonState:
        public void UpdateTradeButtonState() => ((delegate* unmanaged[Thiscall]<ref gmSecureTradeUI, void>)0x004CA2F0)(ref this); // .text:004C9700 ; void __thiscall gmSecureTradeUI::UpdateTradeButtonState(gmSecureTradeUI *this) .text:004C9700 ?UpdateTradeButtonState@gmSecureTradeUI@@IAEXXZ
    }




}