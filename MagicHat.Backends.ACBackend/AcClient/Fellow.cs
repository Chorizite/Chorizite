//go run parse.go full ClientFellowshipSystem:CFellowship:Fellowship:Fellow:gmFellowshipUI:FellowshipSystem
using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct ClientFellowshipSystem {
        // Struct:
        public ClientSystem a0;
        public Turbine_RefCount m_cTurbineRefCount;
        public CFellowship* m_pFellowship;
        public override string ToString() => $"a0(ClientSystem):{a0}, m_cTurbineRefCount(Turbine_RefCount):{m_cTurbineRefCount}, m_pFellowship:->(CFellowship*)0x{(int)m_pFellowship:X8}";

        // Functions:

        // ClientFellowshipSystem.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x0056A010)(ref this); // .text:00569270 ; void __thiscall ClientFellowshipSystem::ClientFellowshipSystem(ClientFellowshipSystem *this) .text:00569270 ??0ClientFellowshipSystem@@QAE@XZ

        // ClientFellowshipSystem.DeleteFellowship:
        public void DeleteFellowship() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x0056AB50)(ref this); // .text:00569DB0 ; void __thiscall ClientFellowshipSystem::DeleteFellowship(ClientFellowshipSystem *this) .text:00569DB0 ?DeleteFellowship@ClientFellowshipSystem@@IAEXXZ

        // ClientFellowshipSystem.GetFellowshipSystem:
        public static ClientFellowshipSystem* GetFellowshipSystem() => ((delegate* unmanaged[Cdecl]<ClientFellowshipSystem*>)0x00569E30)(); // .text:00569090 ; ClientFellowshipSystem *__cdecl ClientFellowshipSystem::GetFellowshipSystem() .text:00569090 ?GetFellowshipSystem@ClientFellowshipSystem@@SAPAV1@XZ

        // ClientFellowshipSystem.Handle_Fellowship__Disband:
        // public UInt32 Handle_Fellowship__Disband() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32>)0xDEADBEEF)(ref this); // .text:00569E70 ; unsigned int __thiscall ClientFellowshipSystem::Handle_Fellowship__Disband(ClientFellowshipSystem *this) .text:00569E70 ?Handle_Fellowship__Disband@ClientFellowshipSystem@@QAEKXZ

        // ClientFellowshipSystem.Handle_Fellowship__Disband:
        // (ERR) .text:0056AC10 ; public: unsigned long __thiscall ClientFellowshipSystem::Handle_Fellowship__Disband(void) .text:0056AC10 ?Handle_Fellowship__Disband@ClientFellowshipSystem@@QAEKXZ:

        // ClientFellowshipSystem.Handle_Fellowship__Dismiss:
        public UInt32 Handle_Fellowship__Dismiss(UInt32 dismissed) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32, UInt32>)0x0056ACB0)(ref this, dismissed); // .text:00569F10 ; unsigned int __thiscall ClientFellowshipSystem::Handle_Fellowship__Dismiss(ClientFellowshipSystem *this, unsigned int dismissed) .text:00569F10 ?Handle_Fellowship__Dismiss@ClientFellowshipSystem@@QAEKK@Z

        // ClientFellowshipSystem.Handle_Fellowship__FullUpdate:
        public UInt32 Handle_Fellowship__FullUpdate(CFellowship* fellowship) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, CFellowship*, UInt32>)0x0056A160)(ref this, fellowship); // .text:005693C0 ; unsigned int __thiscall ClientFellowshipSystem::Handle_Fellowship__FullUpdate(ClientFellowshipSystem *this, CFellowship *fellowship) .text:005693C0 ?Handle_Fellowship__FullUpdate@ClientFellowshipSystem@@QAEKABVCFellowship@@@Z

        // ClientFellowshipSystem.Handle_Fellowship__Quit:
        public UInt32 Handle_Fellowship__Quit(UInt32 quitter) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32, UInt32>)0x0056AC30)(ref this, quitter); // .text:00569E90 ; unsigned int __thiscall ClientFellowshipSystem::Handle_Fellowship__Quit(ClientFellowshipSystem *this, unsigned int quitter) .text:00569E90 ?Handle_Fellowship__Quit@ClientFellowshipSystem@@QAEKK@Z

        // ClientFellowshipSystem.Handle_Fellowship__UpdateFellow:
        public UInt32 Handle_Fellowship__UpdateFellow(UInt32 id, Fellow* fellow, UInt32 updateType) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32, Fellow*, UInt32, UInt32>)0x00569E60)(ref this, id, fellow, updateType); // .text:005690C0 ; unsigned int __thiscall ClientFellowshipSystem::Handle_Fellowship__UpdateFellow(ClientFellowshipSystem *this, unsigned int id, Fellow *fellow, unsigned int updateType) .text:005690C0 ?Handle_Fellowship__UpdateFellow@ClientFellowshipSystem@@QAEKKABVFellow@@K@Z

        // ClientFellowshipSystem.IsFellow:
        public Byte IsFellow(UInt32 i_iid) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32, Byte>)0x00569ED0)(ref this, i_iid); // .text:00569130 ; bool __thiscall ClientFellowshipSystem::IsFellow(ClientFellowshipSystem *this, unsigned int i_iid) .text:00569130 ?IsFellow@ClientFellowshipSystem@@QAE_NK@Z

        // ClientFellowshipSystem.IsFellowshipLeader:
        public Byte IsFellowshipLeader(UInt32 i_iid) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32, Byte>)0x00569EF0)(ref this, i_iid); // .text:00569150 ; bool __thiscall ClientFellowshipSystem::IsFellowshipLeader(ClientFellowshipSystem *this, unsigned int i_iid) .text:00569150 ?IsFellowshipLeader@ClientFellowshipSystem@@QAE_NK@Z

        // ClientFellowshipSystem.OnEndCharacterSession:
        public void OnEndCharacterSession() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x00569E40)(ref this); // .text:005690A0 ; void __thiscall ClientFellowshipSystem::OnEndCharacterSession(ClientFellowshipSystem *this) .text:005690A0 ?OnEndCharacterSession@ClientFellowshipSystem@@MAEXXZ

        // ClientFellowshipSystem.OnShutdown:
        public void OnShutdown() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x0056ABF0)(ref this); // .text:00569E50 ; void __thiscall ClientFellowshipSystem::OnShutdown(ClientFellowshipSystem *this) .text:00569E50 ?OnShutdown@ClientFellowshipSystem@@MAEXXZ

        // ClientFellowshipSystem.QueryInterface:
        public TResult* QueryInterface(TResult* result, Turbine_GUID* i_rcInterface, void** o_ppvInterface) => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, TResult*, Turbine_GUID*, void**, TResult*>)0x00569F10)(ref this, result, i_rcInterface, o_ppvInterface); // .text:00569170 ; TResult *__thiscall ClientFellowshipSystem::QueryInterface(ClientFellowshipSystem *this, TResult *result, Turbine_GUID *i_rcInterface, void **o_ppvInterface) .text:00569170 ?QueryInterface@ClientFellowshipSystem@@UAE?AVTResult@@ABUTurbine_GUID@@PAPAX@Z

        // ClientFellowshipSystem.Release:
        public UInt32 Release() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, UInt32>)0x00569FE0)(ref this); // .text:00569240 ; unsigned int __thiscall ClientFellowshipSystem::Release(ClientFellowshipSystem *this) .text:00569240 ?Release@ClientFellowshipSystem@@UBEKXZ

        // ClientFellowshipSystem.SelectNextFellow:
        public void SelectNextFellow() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x0056A290)(ref this); // .text:005694F0 ; void __thiscall ClientFellowshipSystem::SelectNextFellow(ClientFellowshipSystem *this) .text:005694F0 ?SelectNextFellow@ClientFellowshipSystem@@QAEXXZ

        // ClientFellowshipSystem.SelectPreviousFellow:
        public void SelectPreviousFellow() => ((delegate* unmanaged[Thiscall]<ref ClientFellowshipSystem, void>)0x0056A360)(ref this); // .text:005695C0 ; void __thiscall ClientFellowshipSystem::SelectPreviousFellow(ClientFellowshipSystem *this) .text:005695C0 ?SelectPreviousFellow@ClientFellowshipSystem@@QAEXXZ

        // Globals:
        public static ClientFellowshipSystem** s_pFellowshipSystem = (ClientFellowshipSystem**)0x0087150C; // .data:008704FC ; ClientFellowshipSystem *ClientFellowshipSystem::s_pFellowshipSystem .data:008704FC ?s_pFellowshipSystem@ClientFellowshipSystem@@1PAV1@A
    }
    public unsafe struct CFellowship {
        // Struct:
        public Fellowship a0;
        public override string ToString() => a0.ToString();

        // Functions:

        // CFellowship.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref CFellowship, void>)0x0059B570)(ref this); // .text:0059A570 ; void __thiscall CFellowship::CFellowship(CFellowship *this) .text:0059A570 ??0CFellowship@@QAE@XZ
    }
    public unsafe struct Fellowship {
        // Struct:
        public PackObj a0;
        public PackableHashTable<UInt32, Fellow> _fellowship_table;
        public AC1Legacy.PStringBase<char> _name;
        public UInt32 _leader;
        public int _share_xp;
        public int _even_xp_split;
        public int _open_fellow;
        public int _locked;
        public PackableHashTable<UInt32, UInt32> _fellows_departed;
        public override string ToString() => $"a0(PackObj):{a0}, _fellowship_table(PackableHashTable<UInt32,Fellow>):{_fellowship_table}, _name(AC1Legacy.PStringBase<char>):{_name}, _leader:{_leader:X8}, _share_xp(int):{_share_xp}, _even_xp_split(int):{_even_xp_split}, _open_fellow(int):{_open_fellow}, _locked(int):{_locked}, _fellows_departed(PackableHashTable<UInt32,UInt32>):{_fellows_departed}";

        // Functions:

        // Fellowship.__Ctor:
        public void __Ctor(Fellowship* __that) => ((delegate* unmanaged[Thiscall]<ref Fellowship, Fellowship*, void>)0x0056AAD0)(ref this, __that); // .text:00569D30 ; void __thiscall Fellowship::Fellowship(Fellowship *this, Fellowship *__that) .text:00569D30 ??0Fellowship@@QAE@ABV0@@Z

        // Fellowship.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Fellowship, void>)0x005BA8E0)(ref this); // .text:005B97A0 ; void __thiscall Fellowship::Fellowship(Fellowship *this) .text:005B97A0 ??0Fellowship@@QAE@XZ

        // Fellowship.operator_equals:
        public Fellowship* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Fellowship, Fellowship*>)0x005BA960)(ref this); // .text:005B9820 ; public: class Fellowship & __thiscall Fellowship::operator=(class Fellowship const &) .text:005B9820 ??4Fellowship@@QAEAAV0@ABV0@@Z

        // Fellowship.AddFellow:
        public int AddFellow(UInt32 fellow_id, Fellow* fellow) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, Fellow*, int>)0x005BA5C0)(ref this, fellow_id, fellow); // .text:005B9480 ; int __thiscall Fellowship::AddFellow(Fellowship *this, unsigned int fellow_id, Fellow *fellow) .text:005B9480 ?AddFellow@Fellowship@@QAEHKABVFellow@@@Z

        // Fellowship.CalculateExperienceProportionSum:
        public UInt32 CalculateExperienceProportionSum() => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32>)0x005BA270)(ref this); // .text:005B9130 ; unsigned int __thiscall Fellowship::CalculateExperienceProportionSum(Fellowship *this) .text:005B9130 ?CalculateExperienceProportionSum@Fellowship@@QAEKXZ

        // Fellowship.GetFellow:
        public Fellow* GetFellow(UInt32 fellow) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, Fellow*>)0x0048EDA0)(ref this, fellow); // .text:0048EAC0 ; Fellow *__thiscall Fellowship::GetFellow(Fellowship *this, unsigned int fellow) .text:0048EAC0 ?GetFellow@Fellowship@@QBEPAVFellow@@K@Z

        // Fellowship.GetLeadersLevel:
        public UInt32 GetLeadersLevel() => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32>)0x005BA2F0)(ref this); // .text:005B91B0 ; unsigned int __thiscall Fellowship::GetLeadersLevel(Fellowship *this) .text:005B91B0 ?GetLeadersLevel@Fellowship@@QAEKXZ

        // Fellowship.GetNonLeaderFellowID:
        public UInt32 GetNonLeaderFellowID() => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32>)0x005BA340)(ref this); // .text:005B9200 ; unsigned int __thiscall Fellowship::GetNonLeaderFellowID(Fellowship *this) .text:005B9200 ?GetNonLeaderFellowID@Fellowship@@QBEKXZ

        // Fellowship.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32>)0x005BA4E0)(ref this); // .text:005B93A0 ; unsigned int __thiscall Fellowship::GetPackSize(Fellowship *this) .text:005B93A0 ?GetPackSize@Fellowship@@MAEIXZ

        // Fellowship.HandleLockedRemoveFellow:
        public void HandleLockedRemoveFellow(UInt32 fellow_id) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, void>)0x005BA3B0)(ref this, fellow_id); // .text:005B9270 ; void __thiscall Fellowship::HandleLockedRemoveFellow(Fellowship *this, unsigned int fellow_id) .text:005B9270 ?HandleLockedRemoveFellow@Fellowship@@QAEXK@Z

        // Fellowship.InqFellow:
        public int InqFellow(UInt32 fellow, Fellow* retval) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, Fellow*, int>)0x005BA210)(ref this, fellow, retval); // .text:005B90D0 ; int __thiscall Fellowship::InqFellow(Fellowship *this, unsigned int fellow, Fellow *retval) .text:005B90D0 ?InqFellow@Fellowship@@QBEHKAAVFellow@@@Z

        // Fellowship.IsFellow:
        public int IsFellow(UInt32 fellow) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, int>)0x005BA1C0)(ref this, fellow); // .text:005B9080 ; int __thiscall Fellowship::IsFellow(Fellowship *this, unsigned int fellow) .text:005B9080 ?IsFellow@Fellowship@@QBEHK@Z

        // Fellowship.IsFull:
        public int IsFull() => ((delegate* unmanaged[Thiscall]<ref Fellowship, int>)0x005BA1B0)(ref this); // .text:005B9070 ; int __thiscall Fellowship::IsFull(Fellowship *this) .text:005B9070 ?IsFull@Fellowship@@QBEHXZ

        // Fellowship.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Fellowship, void**, UInt32, UInt32>)0x005BA530)(ref this, addr, size); // .text:005B93F0 ; unsigned int __thiscall Fellowship::Pack(Fellowship *this, void **addr, unsigned int size) .text:005B93F0 ?Pack@Fellowship@@UAEIAAPAXI@Z

        // Fellowship.RecalculateEvenXPSplitting:
        public void RecalculateEvenXPSplitting() => ((delegate* unmanaged[Thiscall]<ref Fellowship, void>)0x005BA420)(ref this); // .text:005B92E0 ; void __thiscall Fellowship::RecalculateEvenXPSplitting(Fellowship *this) .text:005B92E0 ?RecalculateEvenXPSplitting@Fellowship@@IAEXXZ

        // Fellowship.RemoveFellow:
        public int RemoveFellow(UInt32 fellow) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, int>)0x005BA7C0)(ref this, fellow); // .text:005B9680 ; int __thiscall Fellowship::RemoveFellow(Fellowship *this, unsigned int fellow) .text:005B9680 ?RemoveFellow@Fellowship@@QAEHK@Z

        // Fellowship.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Fellowship, void**, UInt32, int>)0x005BA630)(ref this, addr, size); // .text:005B94F0 ; int __thiscall Fellowship::UnPack(Fellowship *this, void **addr, unsigned int size) .text:005B94F0 ?UnPack@Fellowship@@UAEHAAPAXI@Z

        // Fellowship.UpdateFellow:
        public int UpdateFellow(UInt32 fellow_id, Fellow* fellow) => ((delegate* unmanaged[Thiscall]<ref Fellowship, UInt32, Fellow*, int>)0x005BA870)(ref this, fellow_id, fellow); // .text:005B9730 ; int __thiscall Fellowship::UpdateFellow(Fellowship *this, unsigned int fellow_id, Fellow *fellow) .text:005B9730 ?UpdateFellow@Fellowship@@QAEHKABVFellow@@@Z
    }
    public unsafe struct Fellow {
        // Struct:
        public PackObj a0;
        public AC1Legacy.PStringBase<char> _name;
        public UInt32 _level;
        public UInt32 _cp_cache;
        public UInt32 _lum_cache;
        public int _share_loot;
        public UInt32 _max_health;
        public UInt32 _max_stamina;
        public UInt32 _max_mana;
        public UInt32 _current_health;
        public UInt32 _current_stamina;
        public UInt32 _current_mana;
        public override string ToString() => $"a0(PackObj):{a0}, _name(AC1Legacy.PStringBase<char>):{_name}, _level:{_level:X8}, _cp_cache:{_cp_cache:X8}, _lum_cache:{_lum_cache:X8}, _share_loot(int):{_share_loot}, _max_health:{_max_health:X8}, _max_stamina:{_max_stamina:X8}, _max_mana:{_max_mana:X8}, _current_health:{_current_health:X8}, _current_stamina:{_current_stamina:X8}, _current_mana:{_current_mana:X8}";

        // Functions:

        // Fellow.__Ctor:
        public void __Ctor(Fellow* rhs) => ((delegate* unmanaged[Thiscall]<ref Fellow, Fellow*, void>)0x005BAA30)(ref this, rhs); // .text:005B98F0 ; void __thiscall Fellow::Fellow(Fellow *this, Fellow *rhs) .text:005B98F0 ??0Fellow@@QAE@ABV0@@Z

        // Fellow.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref Fellow, void>)0x005BA9E0)(ref this); // .text:005B98A0 ; void __thiscall Fellow::Fellow(Fellow *this) .text:005B98A0 ??0Fellow@@QAE@XZ

        // Fellow.operator_equals:
        public Fellow* operator_equals() => ((delegate* unmanaged[Thiscall]<ref Fellow, Fellow*>)0x005BAAA0)(ref this); // .text:005B9960 ; public: class Fellow & __thiscall Fellow::operator=(class Fellow const &) .text:005B9960 ??4Fellow@@QAEAAV0@ABV0@@Z

        // Fellow.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref Fellow, UInt32>)0x005BAB30)(ref this); // .text:005B99F0 ; unsigned int __thiscall Fellow::GetPackSize(Fellow *this) .text:005B99F0 ?GetPackSize@Fellow@@UAEIXZ

        // Fellow.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Fellow, void**, UInt32, UInt32>)0x005BAB50)(ref this, addr, size); // .text:005B9A10 ; unsigned int __thiscall Fellow::Pack(Fellow *this, void **addr, unsigned int size) .text:005B9A10 ?Pack@Fellow@@UAEIAAPAXI@Z

        // Fellow.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref Fellow, void**, UInt32, int>)0x005BAC10)(ref this, addr, size); // .text:005B9AD0 ; int __thiscall Fellow::UnPack(Fellow *this, void **addr, unsigned int size) .text:005B9AD0 ?UnPack@Fellow@@UAEHAAPAXI@Z
    }
    public unsafe struct gmFellowshipUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public CFellowship* m_pFellowship;
        public UInt32 m_iidSelectedFellow;
        public UInt32 m_uiAcceptFellowRequestServerContextID;
        public UInt32 m_fellowRequestContext;
        public UIElement* m_pNotInAFellowshipFrame;
        public UIElement* m_pInAFellowshipFrame;
        public UIElement_Text* m_pFellowshipNameEntryBox;
        public UIElement_Button* m_pCreateFellowshipButton;
        public UIElement_Text* m_pFellowshipName;
        public UIElement_ListBox* m_pFellowsListBox;
        public UIElement_Button* m_pFellowLeaderButton;
        public UIElement_Button* m_pFellowQuitButton;
        public UIElement_Button* m_pFellowOpenButton;
        public UIElement_Button* m_pFellowRecruitButton;
        public UIElement_Button* m_pFellowDismissButton;
        public UIElement_Button* m_pFellowDisbandButton;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_pFellowship:->(CFellowship*)0x{(int)m_pFellowship:X8}, m_iidSelectedFellow:{m_iidSelectedFellow:X8}, m_uiAcceptFellowRequestServerContextID:{m_uiAcceptFellowRequestServerContextID:X8}, m_fellowRequestContext:{m_fellowRequestContext:X8}, m_pNotInAFellowshipFrame:->(UIElement*)0x{(int)m_pNotInAFellowshipFrame:X8}, m_pInAFellowshipFrame:->(UIElement*)0x{(int)m_pInAFellowshipFrame:X8}, m_pFellowshipNameEntryBox:->(UIElement_Text*)0x{(int)m_pFellowshipNameEntryBox:X8}, m_pCreateFellowshipButton:->(UIElement_Button*)0x{(int)m_pCreateFellowshipButton:X8}, m_pFellowshipName:->(UIElement_Text*)0x{(int)m_pFellowshipName:X8}, m_pFellowsListBox:->(UIElement_ListBox*)0x{(int)m_pFellowsListBox:X8}, m_pFellowLeaderButton:->(UIElement_Button*)0x{(int)m_pFellowLeaderButton:X8}, m_pFellowQuitButton:->(UIElement_Button*)0x{(int)m_pFellowQuitButton:X8}, m_pFellowOpenButton:->(UIElement_Button*)0x{(int)m_pFellowOpenButton:X8}, m_pFellowRecruitButton:->(UIElement_Button*)0x{(int)m_pFellowRecruitButton:X8}, m_pFellowDismissButton:->(UIElement_Button*)0x{(int)m_pFellowDismissButton:X8}, m_pFellowDisbandButton:->(UIElement_Button*)0x{(int)m_pFellowDisbandButton:X8}";

        // Functions:

        // gmFellowshipUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, LayoutDesc*, ElementDesc*, void>)0x0048E610)(ref this, _layout, _full_desc); // .text:0048E330 ; void __thiscall gmFellowshipUI::gmFellowshipUI(gmFellowshipUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:0048E330 ??0gmFellowshipUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmFellowshipUI.AssignLeadershipToFellow:
        public void AssignLeadershipToFellow(UInt32 i_iidFellow) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048F4C0)(ref this, i_iidFellow); // .text:0048F1E0 ; void __thiscall gmFellowshipUI::AssignLeadershipToFellow(gmFellowshipUI *this, unsigned int i_iidFellow) .text:0048F1E0 ?AssignLeadershipToFellow@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x0048E6E0)(_layout, _full_desc); // .text:0048E400 ; UIElement *__cdecl gmFellowshipUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:0048E400 ?Create@gmFellowshipUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmFellowshipUI.CreateFellowship:
        public void CreateFellowship() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048FA10)(ref this); // .text:0048F730 ; void __thiscall gmFellowshipUI::CreateFellowship(gmFellowshipUI *this) .text:0048F730 ?CreateFellowship@gmFellowshipUI@@IAEXXZ

        // gmFellowshipUI.DismissFellow:
        public void DismissFellow(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048E750)(ref this, i_iidPlayer); // .text:0048E470 ; void __thiscall gmFellowshipUI::DismissFellow(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048E470 ?DismissFellow@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, UIElement*>)0x0048E6B0)(ref this, i_eType); // .text:0048E3D0 ; UIElement *__thiscall gmFellowshipUI::DynamicCast(gmFellowshipUI *this, unsigned int i_eType) .text:0048E3D0 ?DynamicCast@gmFellowshipUI@@UAEPAVUIElement@@K@Z

        // gmFellowshipUI.FellowAdded:
        public void FellowAdded(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048FF00)(ref this, i_iidPlayer); // .text:0048FC20 ; void __thiscall gmFellowshipUI::FellowAdded(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048FC20 ?FellowAdded@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.FellowDismissed:
        public void FellowDismissed(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048FC50)(ref this, i_iidPlayer); // .text:0048F970 ; void __thiscall gmFellowshipUI::FellowDismissed(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048F970 ?FellowDismissed@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.FellowQuit:
        public void FellowQuit(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048FDC0)(ref this, i_iidPlayer); // .text:0048FAE0 ; void __thiscall gmFellowshipUI::FellowQuit(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048FAE0 ?FellowQuit@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.FellowUpdated:
        public void FellowUpdated(UInt32 i_iidPlayer, Fellow* i_fellow, UInt32 i_eUpdateType) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, Fellow*, UInt32, void>)0x0048FFB0)(ref this, i_iidPlayer, i_fellow, i_eUpdateType); // .text:0048FCD0 ; void __thiscall gmFellowshipUI::FellowUpdated(gmFellowshipUI *this, unsigned int i_iidPlayer, Fellow *i_fellow, unsigned int i_eUpdateType) .text:0048FCD0 ?FellowUpdated@gmFellowshipUI@@IAEXKABVFellow@@K@Z

        // gmFellowshipUI.FellowshipDisbanded:
        public void FellowshipDisbanded() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048FB80)(ref this); // .text:0048F8A0 ; void __thiscall gmFellowshipUI::FellowshipDisbanded(gmFellowshipUI *this) .text:0048F8A0 ?FellowshipDisbanded@gmFellowshipUI@@IAEXXZ

        // gmFellowshipUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32>)0x0048E6D0)(ref this); // .text:0048E3F0 ; unsigned int __thiscall gmFellowshipUI::GetUIElementType(gmFellowshipUI *this) .text:0048E3F0 ?GetUIElementType@gmFellowshipUI@@UBEKXZ

        // gmFellowshipUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004904A0)(ref this, i_rMsg); // .text:004901C0 ; UIElementMessageListenResult __thiscall gmFellowshipUI::ListenToElementMessage(gmFellowshipUI *this, UIElementMessageInfo *i_rMsg) .text:004901C0 ?ListenToElementMessage@gmFellowshipUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmFellowshipUI.MakeFellowRequestDialog:
        public Byte MakeFellowRequestDialog(PStringBase<char> i_strRequestor, UInt32 i_uiServerContextID) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, PStringBase<char>, UInt32, Byte>)0x00490900)(ref this, i_strRequestor, i_uiServerContextID); // .text:00490620 ; bool __thiscall gmFellowshipUI::MakeFellowRequestDialog(gmFellowshipUI *this, PStringBase<char> i_strRequestor, unsigned int i_uiServerContextID) .text:00490620 ?MakeFellowRequestDialog@gmFellowshipUI@@IAE_NV?$PStringBase@D@@K@Z

        // gmFellowshipUI.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, Byte, void>)0x0048E740)(ref this, i_bVisible); // .text:0048E460 ; void __thiscall gmFellowshipUI::OnVisibilityChanged(gmFellowshipUI *this, bool i_bVisible) .text:0048E460 ?OnVisibilityChanged@gmFellowshipUI@@MAEX_N@Z

        // gmFellowshipUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x00490020)(ref this); // .text:0048FD40 ; void __thiscall gmFellowshipUI::PostInit(gmFellowshipUI *this) .text:0048FD40 ?PostInit@gmFellowshipUI@@UAEXXZ

        // gmFellowshipUI.RecruitFellow:
        public void RecruitFellow(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048E810)(ref this, i_iidPlayer); // .text:0048E530 ; void __thiscall gmFellowshipUI::RecruitFellow(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048E530 ?RecruitFellow@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.RecvNotice_AbortConfirmationRequest:
        public void RecvNotice_AbortConfirmationRequest(int confirmationType, UInt32 context) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, int, UInt32, void>)0x0048E710)(ref this, confirmationType, context); // .text:0048E430 ; void __thiscall gmFellowshipUI::RecvNotice_AbortConfirmationRequest(gmFellowshipUI *this, int confirmationType, unsigned int context) .text:0048E430 ?RecvNotice_AbortConfirmationRequest@gmFellowshipUI@@UAEXJK@Z

        // gmFellowshipUI.RecvNotice_CloseDialog:
        public void RecvNotice_CloseDialog(UInt32 context, PropertyCollection* data) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, PropertyCollection*, void>)0x0048F5A0)(ref this, context, data); // .text:0048F2C0 ; void __thiscall gmFellowshipUI::RecvNotice_CloseDialog(gmFellowshipUI *this, unsigned int context, PropertyCollection *data) .text:0048F2C0 ?RecvNotice_CloseDialog@gmFellowshipUI@@UAEXKABVPropertyCollection@@@Z

        // gmFellowshipUI.RecvNotice_FellowAdded:
        public void RecvNotice_FellowAdded(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x004908E0)(ref this, i_iidPlayer); // .text:00490600 ; void __thiscall gmFellowshipUI::RecvNotice_FellowAdded(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:00490600 ?RecvNotice_FellowAdded@gmFellowshipUI@@UAEXK@Z

        // gmFellowshipUI.RecvNotice_FellowDismissed:
        public void RecvNotice_FellowDismissed(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x004908D0)(ref this, i_iidPlayer); // .text:004905F0 ; void __thiscall gmFellowshipUI::RecvNotice_FellowDismissed(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:004905F0 ?RecvNotice_FellowDismissed@gmFellowshipUI@@UAEXK@Z

        // gmFellowshipUI.RecvNotice_FellowQuit:
        public void RecvNotice_FellowQuit(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x004908C0)(ref this, i_iidPlayer); // .text:004905E0 ; void __thiscall gmFellowshipUI::RecvNotice_FellowQuit(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:004905E0 ?RecvNotice_FellowQuit@gmFellowshipUI@@UAEXK@Z

        // gmFellowshipUI.RecvNotice_FellowUpdated:
        public void RecvNotice_FellowUpdated(UInt32 i_iidPlayer, Fellow* i_fellow, UInt32 i_uiUpdateType) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, Fellow*, UInt32, void>)0x004908F0)(ref this, i_iidPlayer, i_fellow, i_uiUpdateType); // .text:00490610 ; void __thiscall gmFellowshipUI::RecvNotice_FellowUpdated(gmFellowshipUI *this, unsigned int i_iidPlayer, Fellow *i_fellow, unsigned int i_uiUpdateType) .text:00490610 ?RecvNotice_FellowUpdated@gmFellowshipUI@@UAEXKABVFellow@@K@Z

        // gmFellowshipUI.RecvNotice_FellowshipDisbanded:
        public void RecvNotice_FellowshipDisbanded() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x004908B0)(ref this); // .text:004905D0 ; void __thiscall gmFellowshipUI::RecvNotice_FellowshipDisbanded(gmFellowshipUI *this) .text:004905D0 ?RecvNotice_FellowshipDisbanded@gmFellowshipUI@@UAEXXZ

        // gmFellowshipUI.RecvNotice_FellowshipRequest:
        public void RecvNotice_FellowshipRequest(AC1Legacy.PStringBase<char>* i_strRequestor, UInt32 i_uiContextID) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, AC1Legacy.PStringBase<char>*, UInt32, void>)0x00490B60)(ref this, i_strRequestor, i_uiContextID); // .text:00490880 ; void __thiscall gmFellowshipUI::RecvNotice_FellowshipRequest(gmFellowshipUI *this, AC1Legacy::PStringBase<char> *i_strRequestor, unsigned int i_uiContextID) .text:00490880 ?RecvNotice_FellowshipRequest@gmFellowshipUI@@UAEXABV?$PStringBase@D@AC1Legacy@@K@Z

        // gmFellowshipUI.RecvNotice_FellowshipUpdate:
        public void RecvNotice_FellowshipUpdate(CFellowship* i_fellowship) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, CFellowship*, void>)0x00490770)(ref this, i_fellowship); // .text:00490490 ; void __thiscall gmFellowshipUI::RecvNotice_FellowshipUpdate(gmFellowshipUI *this, CFellowship *i_fellowship) .text:00490490 ?RecvNotice_FellowshipUpdate@gmFellowshipUI@@UAEXABVCFellowship@@@Z

        // gmFellowshipUI.RecvNotice_SelectionChanged:
        public void RecvNotice_SelectionChanged() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048F4A0)(ref this); // .text:0048F1C0 ; void __thiscall gmFellowshipUI::RecvNotice_SelectionChanged(gmFellowshipUI *this) .text:0048F1C0 ?RecvNotice_SelectionChanged@gmFellowshipUI@@UAEXXZ

        // gmFellowshipUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x0048E980)(); // .text:0048E6A0 ; void __cdecl gmFellowshipUI::Register() .text:0048E6A0 ?Register@gmFellowshipUI@@SAXXZ

        // gmFellowshipUI.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048F720)(ref this); // .text:0048F440 ; void __thiscall gmFellowshipUI::Update(gmFellowshipUI *this) .text:0048F440 ?Update@gmFellowshipUI@@IAEXXZ

        // gmFellowshipUI.UpdateButtons:
        public void UpdateButtons() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048E9A0)(ref this); // .text:0048E6C0 ; void __thiscall gmFellowshipUI::UpdateButtons(gmFellowshipUI *this) .text:0048E6C0 ?UpdateButtons@gmFellowshipUI@@IAEXXZ

        // gmFellowshipUI.UpdateFellowSelection:
        public void UpdateFellowSelection() => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, void>)0x0048F3D0)(ref this); // .text:0048F0F0 ; void __thiscall gmFellowshipUI::UpdateFellowSelection(gmFellowshipUI *this) .text:0048F0F0 ?UpdateFellowSelection@gmFellowshipUI@@IAEXXZ

        // gmFellowshipUI.UpdateFellowStats:
        public void UpdateFellowStats(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048EE00)(ref this, i_iidPlayer); // .text:0048EB20 ; void __thiscall gmFellowshipUI::UpdateFellowStats(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048EB20 ?UpdateFellowStats@gmFellowshipUI@@IAEXK@Z

        // gmFellowshipUI.UpdateFellowVitals:
        public void UpdateFellowVitals(UInt32 i_iidPlayer) => ((delegate* unmanaged[Thiscall]<ref gmFellowshipUI, UInt32, void>)0x0048F040)(ref this, i_iidPlayer); // .text:0048ED60 ; void __thiscall gmFellowshipUI::UpdateFellowVitals(gmFellowshipUI *this, unsigned int i_iidPlayer) .text:0048ED60 ?UpdateFellowVitals@gmFellowshipUI@@IAEXK@Z
    }
    public unsafe struct FellowshipSystem {
        // Struct:

        // Functions:

        // FellowshipSystem.GetEvenSplitXPPctg:
        public static Single GetEvenSplitXPPctg(UInt32 uiNumFellows) => ((delegate* unmanaged[Cdecl]<UInt32, Single>)0x005BACE0)(uiNumFellows); // .text:005B9BA0 ; float __cdecl FellowshipSystem::GetEvenSplitXPPctg(unsigned int uiNumFellows) .text:005B9BA0 ?GetEvenSplitXPPctg@FellowshipSystem@@SAMK@Z

        // FellowshipSystem.GetExperienceProportion:
        public static UInt32 GetExperienceProportion(UInt32 level) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32>)0x005BACC0)(level); // .text:005B9B80 ; unsigned int __cdecl FellowshipSystem::GetExperienceProportion(unsigned int level) .text:005B9B80 ?GetExperienceProportion@FellowshipSystem@@SAKK@Z
    }


}