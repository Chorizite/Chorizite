//go run parse.go full InventoryPlacement:CObjectInventory:ShortCutData:ShortCutManager:CShortCutData:gmToolbarUI:gmFloatyToolbarUI:gm3DItemsUI:gmBackpackUI:gmPaperDollUI:gmInventoryUI:gmExternalContainerUI


using System;

namespace AcClient {
    public unsafe struct InventoryPlacement {
        // Struct:
        public PackObj a0;
        public UInt32 iid_;
        public UInt32 loc_;
        public UInt32 priority_;
        public override string ToString() => $"iid_:{iid_:X8}, loc_:{loc_:X8}, priority_:{priority_:X8}";

        // Functions:

        // InventoryPlacement.DetermineHigherPriority:
        public static InventoryPlacement* DetermineHigherPriority(InventoryPlacement* _ip1, InventoryPlacement* _ip2, UInt32 _releventLocations) => ((delegate* unmanaged[Cdecl]<InventoryPlacement*, InventoryPlacement*, UInt32, InventoryPlacement*>)0x004A4820)(_ip1, _ip2, _releventLocations); // .text:004A44B0 ; InventoryPlacement *__cdecl InventoryPlacement::DetermineHigherPriority(InventoryPlacement *_ip1, InventoryPlacement *_ip2, unsigned int _releventLocations) .text:004A44B0 ?DetermineHigherPriority@InventoryPlacement@@SAAAV1@AAV1@0K@Z

        // InventoryPlacement.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref InventoryPlacement, void**, UInt32, UInt32>)0x004A3880)(ref this, addr, size); // .text:005CABB0 ; unsigned int __thiscall InventoryPlacement::Pack(ShortCutData *this, void **addr, unsigned int size) .text:005CABB0 ?Pack@InventoryPlacement@@UAEIAAPAXI@Z

        // InventoryPlacement.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref InventoryPlacement, void**, UInt32, int>)0x004A38C0)(ref this, addr, size); // .text:004A3550 ; int __thiscall InventoryPlacement::UnPack(InventoryPlacement *this, void **addr, unsigned int size) .text:004A3550 ?UnPack@InventoryPlacement@@UAEHAAPAXI@Z
    }
    public unsafe struct CObjectInventory {
        // Struct:
        public LongHashData a0;
        public IDList _itemsList;
        public IDList _containersList;
        public PackableList<InventoryPlacement> _invPlacement;
        public override string ToString() => $"id:{a0.a0.id:X8}, _itemsList(IDList):{_itemsList}, _containersList(IDList):{_containersList}, _invPlacement(PackableList<InventoryPlacement>):{_invPlacement}";

        // Functions:

        // CObjectInventory.__Ctor:
        public void __Ctor(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref CObjectInventory, UInt32, void>)0x006B5BC0)(ref this, _objectID); // .text:006B4C80 ; void __thiscall CObjectInventory::CObjectInventory(CObjectInventory *this, unsigned int _objectID) .text:006B4C80 ??0CObjectInventory@@QAE@K@Z
    }
    public unsafe struct ShortCutData {
        // Struct:
        public PackObj a0;
        public int index_;
        public UInt32 objectID_;
        public UInt32 spellID_;
        public override string ToString() => $"index_:{index_}, objectID_:{objectID_:X8}, spellID_:{spellID_:X8}";

        // Functions:

        // ShortCutData.__Ctor:
        public void __Ctor(int index, UInt32 objectID, UInt32 spellID) => ((delegate* unmanaged[Thiscall]<ref ShortCutData, int, UInt32, UInt32, void>)0x005D6730)(ref this, index, objectID, spellID); // .text:005D55E0 ; void __thiscall ShortCutData::ShortCutData(ShortCutData *this, int index, unsigned int objectID, unsigned int spellID) .text:005D55E0 ??0ShortCutData@@QAE@JKK@Z

        // ShortCutData.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ShortCutData, void>)0x005D6750)(ref this); // .text:005D5600 ; void __thiscall ShortCutData::ShortCutData(ShortCutData *this) .text:005D5600 ??0ShortCutData@@QAE@XZ
    }
    public unsafe struct ShortCutManager {
        // Struct:
        public PackObj a0;
        public fixed int shortCuts_[18]; // ShortCutData *
        public override string ToString() => $"shortCuts_[0]:{shortCuts_[0]},shortCuts_[1]:{shortCuts_[1]}, shortCuts_[2]:{shortCuts_[2]}, shortCuts_[3]:{shortCuts_[3]}, shortCuts_[4]:{shortCuts_[4]} ...";

        // Functions:

        // ShortCutManager.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, void>)0x005D6880)(ref this); // .text:005D5770 ; void __thiscall ShortCutManager::ShortCutManager(ShortCutManager *this) .text:005D5770 ??0ShortCutManager@@QAE@XZ

        // ShortCutManager.AddShortCut:
        public int AddShortCut(ShortCutData* scData) => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, ShortCutData*, int>)0x005D68A0)(ref this, scData); // .text:005D5790 ; int __thiscall ShortCutManager::AddShortCut(ShortCutManager *this, ShortCutData *scData) .text:005D5790 ?AddShortCut@ShortCutManager@@QAEHABVShortCutData@@@Z

        // ShortCutManager.Destroy:
        public void Destroy() => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, void>)0x005D6770)(ref this); // .text:005D5660 ; void __thiscall ShortCutManager::Destroy(ShortCutManager *this) .text:005D5660 ?Destroy@ShortCutManager@@QAEXXZ

        // ShortCutManager.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, void**, UInt32, UInt32>)0x005D6820)(ref this, addr, size); // .text:005D5710 ; unsigned int __thiscall ShortCutManager::Pack(ShortCutManager *this, void **addr, unsigned int size) .text:005D5710 ?Pack@ShortCutManager@@UAEIAAPAXI@Z

        // ShortCutManager.RemoveShortCut:
        public void RemoveShortCut(int index) => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, int, void>)0x005D67A0)(ref this, index); // .text:005D5690 ; void __thiscall ShortCutManager::RemoveShortCut(ShortCutManager *this, const int index) .text:005D5690 ?RemoveShortCut@ShortCutManager@@QAEXJ@Z

        // ShortCutManager.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, void**, UInt32, int>)0x005D6930)(ref this, addr, size); // .text:005D5820 ; int __thiscall ShortCutManager::UnPack(ShortCutManager *this, void **addr, unsigned int size) .text:005D5820 ?UnPack@ShortCutManager@@UAEHAAPAXI@Z

        // ShortCutManager.pack_size:
        public UInt32 pack_size() => ((delegate* unmanaged[Thiscall]<ref ShortCutManager, UInt32>)0x005D67D0)(ref this); // .text:005D56C0 ; unsigned int __thiscall ShortCutManager::pack_size(ShortCutManager *this) .text:005D56C0 ?pack_size@ShortCutManager@@QAEIXZ
    }
    public unsafe struct CShortCutData {
        // Struct:
        public ShortCutData a0;
        public override string ToString() => a0.ToString();

        // Functions:

        // CShortCutData.__Ctor:
        public void __Ctor(int index, UInt32 objectID, UInt32 spellID) => ((delegate* unmanaged[Thiscall]<ref CShortCutData, int, UInt32, UInt32, void>)0x0059B5B0)(ref this, index, objectID, spellID); // .text:0059A5B0 ; void __thiscall CShortCutData::CShortCutData(CShortCutData *this, int index, unsigned int objectID, unsigned int spellID) .text:0059A5B0 ??0CShortCutData@@QAE@JKK@Z
    }
    public unsafe struct gmToolbarUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public ItemListDragHandler a2;
        public SmartArray<PanelButtonInfo> m_buttonInfoArray;
        public UIElement* m_pUseObjectButton;
        public UIElement* m_pExamineObjectButton;
        public UIElement* m_pSelObjectField;
        public UIElement_Text* m_pSelObjectName;
        public UIElement_Meter* m_pSelObjectHealthMeter;
        public UIElement_Meter* m_pSelObjectManaMeter;
        public UIElement_Text* m_pStackSizeEntryBox;
        public UIElement_Scrollbar* m_pStackSizeSlider;
        public UIElement* m_pInventoryButtonDragOverlay;
        public UInt32 m_iidSelectedObject;
        public SmartArray<PTR<UIElement_ItemList>> m_shortcutSlots;
        public UInt32 m_lastShortcutNumDragged;
        public Byte m_bToolbarActive;
        public UInt32 m_idAmmoObject;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(ItemListDragHandler):{a2}, m_buttonInfoArray(SmartArray<PanelButtonInfo,1>):{m_buttonInfoArray}, m_pUseObjectButton:->(UIElement*)0x{(int)m_pUseObjectButton:X8}, m_pExamineObjectButton:->(UIElement*)0x{(int)m_pExamineObjectButton:X8}, m_pSelObjectField:->(UIElement*)0x{(int)m_pSelObjectField:X8}, m_pSelObjectName:->(UIElement_Text*)0x{(int)m_pSelObjectName:X8}, m_pSelObjectHealthMeter:->(UIElement_Meter*)0x{(int)m_pSelObjectHealthMeter:X8}, m_pSelObjectManaMeter:->(UIElement_Meter*)0x{(int)m_pSelObjectManaMeter:X8}, m_pStackSizeEntryBox:->(UIElement_Text*)0x{(int)m_pStackSizeEntryBox:X8}, m_pStackSizeSlider:->(UIElement_Scrollbar*)0x{(int)m_pStackSizeSlider:X8}, m_pInventoryButtonDragOverlay:->(UIElement*)0x{(int)m_pInventoryButtonDragOverlay:X8}, m_iidSelectedObject:{m_iidSelectedObject:X8}, m_shortcutSlots(SmartArray<UIElement_ItemList*,1>):{m_shortcutSlots}, m_lastShortcutNumDragged:{m_lastShortcutNumDragged:X8}, m_bToolbarActive:{m_bToolbarActive:X2}, m_idAmmoObject:{m_idAmmoObject:X8}";

        // Functions:

        // gmToolbarUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, LayoutDesc*, ElementDesc*, void>)0x004BE3A0)(ref this, _layout, _full_desc); // .text:004BD710 ; void __thiscall gmToolbarUI::gmToolbarUI(gmToolbarUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004BD710 ??0gmToolbarUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmToolbarUI.AddShortcut:
        public void AddShortcut(UInt32 _itemID, int _slot, Byte _broadcast) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, int, Byte, void>)0x004BE630)(ref this, _itemID, _slot, _broadcast); // .text:004BD9A0 ; void __thiscall gmToolbarUI::AddShortcut(gmToolbarUI *this, unsigned int _itemID, int _slot, bool _broadcast) .text:004BD9A0 ?AddShortcut@gmToolbarUI@@IAEXKH_N@Z

        // gmToolbarUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004BE550)(_layout, _full_desc); // .text:004BD8C0 ; UIElement *__cdecl gmToolbarUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004BD8C0 ?Create@gmToolbarUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmToolbarUI.CreateShortcutToItem:
        public void CreateShortcutToItem(UInt32 _itemID, int _shortcutIndex, Byte _pickUp, Byte _silent) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, int, Byte, Byte, void>)0x004BE750)(ref this, _itemID, _shortcutIndex, _pickUp, _silent); // .text:004BDAC0 ; void __thiscall gmToolbarUI::CreateShortcutToItem(gmToolbarUI *this, unsigned int _itemID, int _shortcutIndex, bool _pickUp, bool _silent) .text:004BDAC0 ?CreateShortcutToItem@gmToolbarUI@@IAEXKH_N0@Z

        // gmToolbarUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, UIElement*>)0x004BE460)(ref this, i_eType); // .text:004BD7D0 ; UIElement *__thiscall gmToolbarUI::DynamicCast(gmToolbarUI *this, unsigned int i_eType) .text:004BD7D0 ?DynamicCast@gmToolbarUI@@UAEPAVUIElement@@K@Z

        // gmToolbarUI.FlushShortcuts:
        public void FlushShortcuts() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004BE0B0)(ref this); // .text:004BD420 ; void __thiscall gmToolbarUI::FlushShortcuts(gmToolbarUI *this) .text:004BD420 ?FlushShortcuts@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.GetFirstEmptyShortcutToTheRightOf:
        public int GetFirstEmptyShortcutToTheRightOf(UInt32 index) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, int>)0x004BE1F0)(ref this, index); // .text:004BD560 ; int __thiscall gmToolbarUI::GetFirstEmptyShortcutToTheRightOf(gmToolbarUI *this, unsigned int index) .text:004BD560 ?GetFirstEmptyShortcutToTheRightOf@gmToolbarUI@@IAEHK@Z

        // gmToolbarUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32>)0x004BE480)(ref this); // .text:004BD7F0 ; unsigned int __thiscall gmToolbarUI::GetUIElementType(gmToolbarUI *this) .text:004BD7F0 ?GetUIElementType@gmToolbarUI@@UBEKXZ

        // gmToolbarUI.HandleDropRelease:
        public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UIElementMessageInfo*, void>)0x004BF450)(ref this, i_rMsg); // .text:004BE7C0 ; void __thiscall gmToolbarUI::HandleDropRelease(gmToolbarUI *this, UIElementMessageInfo *i_rMsg) .text:004BE7C0 ?HandleDropRelease@gmToolbarUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmToolbarUI.HandleInventoryButtonDragOver:
        public void HandleInventoryButtonDragOver(UIElement* _dragElement) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UIElement*, void>)0x004BDE10)(ref this, _dragElement); // .text:004BD180 ; void __thiscall gmToolbarUI::HandleInventoryButtonDragOver(gmToolbarUI *this, UIElement *_dragElement) .text:004BD180 ?HandleInventoryButtonDragOver@gmToolbarUI@@IAEXPAVUIElement@@@Z

        // gmToolbarUI.HandleSelectionChanged:
        public void HandleSelectionChanged() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004C0010)(ref this); // .text:004BF380 ; void __thiscall gmToolbarUI::HandleSelectionChanged(gmToolbarUI *this) .text:004BF380 ?HandleSelectionChanged@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.InitShortcutArray:
        public void InitShortcutArray() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004BE9E0)(ref this); // .text:004BDD50 ; void __thiscall gmToolbarUI::InitShortcutArray(gmToolbarUI *this) .text:004BDD50 ?InitShortcutArray@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.IsShortcutEligible:
        public Byte IsShortcutEligible(ACCWeenieObject* _weenObj) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, ACCWeenieObject*, Byte>)0x004BDE60)(ref this, _weenObj); // .text:004BD1D0 ; bool __thiscall gmToolbarUI::IsShortcutEligible(gmToolbarUI *this, ACCWeenieObject *_weenObj) .text:004BD1D0 ?IsShortcutEligible@gmToolbarUI@@IAE_NPAVACCWeenieObject@@@Z

        // gmToolbarUI.IsShortcutSlotAvailable:
        public Byte IsShortcutSlotAvailable(int _slot) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, int, Byte>)0x004BE270)(ref this, _slot); // .text:004BD5E0 ; bool __thiscall gmToolbarUI::IsShortcutSlotAvailable(gmToolbarUI *this, int _slot) .text:004BD5E0 ?IsShortcutSlotAvailable@gmToolbarUI@@IAE_NH@Z

        // gmToolbarUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004BFB20)(ref this, i_rMsg); // .text:004BEE90 ; UIElementMessageListenResult __thiscall gmToolbarUI::ListenToElementMessage(gmToolbarUI *this, UIElementMessageInfo *i_rMsg) .text:004BEE90 ?ListenToElementMessage@gmToolbarUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmToolbarUI.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, int, void>)0x004BF170)(ref this, i_messageID, i_data_int); // .text:004BE4E0 ; void __thiscall gmToolbarUI::ListenToGlobalMessage(gmToolbarUI *this, unsigned int i_messageID, int i_data_int) .text:004BE4E0 ?ListenToGlobalMessage@gmToolbarUI@@UAEXKJ@Z

        // gmToolbarUI.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004BDDE0)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004BD150 ; bool __thiscall gmToolbarUI::OnItemListDragOver(gmToolbarUI *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004BD150 ?OnItemListDragOver@gmToolbarUI@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // gmToolbarUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004BF710)(ref this); // .text:004BEA80 ; void __thiscall gmToolbarUI::PostInit(gmToolbarUI *this) .text:004BEA80 ?PostInit@gmToolbarUI@@UAEXXZ

        // gmToolbarUI.RecvNotice_AddShortcut:
        public void RecvNotice_AddShortcut(UInt32 i_itemID, int i_slot) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, int, void>)0x004BF620)(ref this, i_itemID, i_slot); // .text:004BE990 ; void __thiscall gmToolbarUI::RecvNotice_AddShortcut(gmToolbarUI *this, unsigned int i_itemID, int i_slot) .text:004BE990 ?RecvNotice_AddShortcut@gmToolbarUI@@MAEXKJ@Z

        // gmToolbarUI.RecvNotice_FullMergingItem:
        public void RecvNotice_FullMergingItem(UInt32 i_oldObject, UInt32 i_mergeTo) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, UInt32, void>)0x004BF640)(ref this, i_oldObject, i_mergeTo); // .text:004BE9B0 ; void __thiscall gmToolbarUI::RecvNotice_FullMergingItem(gmToolbarUI *this, unsigned int i_oldObject, unsigned int i_mergeTo) .text:004BE9B0 ?RecvNotice_FullMergingItem@gmToolbarUI@@MAEXKK@Z

        // gmToolbarUI.RecvNotice_ItemAttributesChanged:
        public void RecvNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, UInt32, void>)0x004C0580)(ref this, i_target, i_attrib); // .text:004BF8F0 ; void __thiscall gmToolbarUI::RecvNotice_ItemAttributesChanged(gmToolbarUI *this, unsigned int i_target, unsigned int i_attrib) .text:004BF8F0 ?RecvNotice_ItemAttributesChanged@gmToolbarUI@@MAEXKK@Z

        // gmToolbarUI.RecvNotice_ItemListBeginDrag:
        public void RecvNotice_ItemListBeginDrag(UIElement* i_itemList, int i_slotNum) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UIElement*, int, void>)0x004BE5C0)(ref this, i_itemList, i_slotNum); // .text:004BD930 ; void __thiscall gmToolbarUI::RecvNotice_ItemListBeginDrag(gmToolbarUI *this, UIElement *i_itemList, int i_slotNum) .text:004BD930 ?RecvNotice_ItemListBeginDrag@gmToolbarUI@@MAEXABVUIElement@@J@Z

        // gmToolbarUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, CACQualities*, CPlayerModule*, void>)0x004C0610)(ref this, i_playerDesc, i_playerModule); // .text:004BF980 ; void __thiscall gmToolbarUI::RecvNotice_PlayerDescReceived(gmToolbarUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004BF980 ?RecvNotice_PlayerDescReceived@gmToolbarUI@@MAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmToolbarUI.RecvNotice_RemoveShortcut:
        public void RecvNotice_RemoveShortcut(UInt32 i_itemID) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, void>)0x004BE580)(ref this, i_itemID); // .text:004BD8F0 ; void __thiscall gmToolbarUI::RecvNotice_RemoveShortcut(gmToolbarUI *this, unsigned int i_itemID) .text:004BD8F0 ?RecvNotice_RemoveShortcut@gmToolbarUI@@MAEXK@Z

        // gmToolbarUI.RecvNotice_SelectionChanged:
        public void RecvNotice_SelectionChanged() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004C0600)(ref this); // .text:004BF970 ; void __thiscall gmToolbarUI::RecvNotice_SelectionChanged(gmToolbarUI *this) .text:004BF970 ?RecvNotice_SelectionChanged@gmToolbarUI@@MAEXXZ

        // gmToolbarUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004BFF40)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004BF2B0 ; void __thiscall gmToolbarUI::RecvNotice_ServerSaysMoveItem(gmToolbarUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004BF2B0 ?RecvNotice_ServerSaysMoveItem@gmToolbarUI@@MAEXKKKKKHKK@Z

        // gmToolbarUI.RecvNotice_SetCombatMode:
        public void RecvNotice_SetCombatMode(COMBAT_MODE i_eCombatMode) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, COMBAT_MODE, void>)0x004BE2A0)(ref this, i_eCombatMode); // .text:004BD610 ; void __thiscall gmToolbarUI::RecvNotice_SetCombatMode(gmToolbarUI *this, COMBAT_MODE i_eCombatMode) .text:004BD610 ?RecvNotice_SetCombatMode@gmToolbarUI@@MAEXW4COMBAT_MODE@@@Z

        // gmToolbarUI.RecvNotice_SetPanelVisibility:
        public void RecvNotice_SetPanelVisibility(UInt32 i_ePanelID, Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, Byte, void>)0x004BDF90)(ref this, i_ePanelID, i_bVisible); // .text:004BD300 ; void __thiscall gmToolbarUI::RecvNotice_SetPanelVisibility(gmToolbarUI *this, unsigned int i_ePanelID, bool i_bVisible) .text:004BD300 ?RecvNotice_SetPanelVisibility@gmToolbarUI@@MAEXK_N@Z

        // gmToolbarUI.RecvNotice_SplitStack:
        public void RecvNotice_SplitStack(UInt32 i_iidItem) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, void>)0x004BDF30)(ref this, i_iidItem); // .text:004BD2A0 ; void __thiscall gmToolbarUI::RecvNotice_SplitStack(gmToolbarUI *this, unsigned int i_iidItem) .text:004BD2A0 ?RecvNotice_SplitStack@gmToolbarUI@@MAEXK@Z

        // gmToolbarUI.RecvNotice_UpdateItemMana:
        public void RecvNotice_UpdateItemMana(UInt32 i_iidTarget, Single i_fMana, Byte i_bSuccess) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, Single, Byte, void>)0x004BDD50)(ref this, i_iidTarget, i_fMana, i_bSuccess); // .text:004BD0C0 ; void __thiscall gmToolbarUI::RecvNotice_UpdateItemMana(gmToolbarUI *this, unsigned int i_iidTarget, float i_fMana, bool i_bSuccess) .text:004BD0C0 ?RecvNotice_UpdateItemMana@gmToolbarUI@@MAEXKM_N@Z

        // gmToolbarUI.RecvNotice_UpdateObjectHealth:
        public void RecvNotice_UpdateObjectHealth(UInt32 i_iidTarget, Single i_fHealth) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, Single, void>)0x004BDDA0)(ref this, i_iidTarget, i_fHealth); // .text:004BD110 ; void __thiscall gmToolbarUI::RecvNotice_UpdateObjectHealth(gmToolbarUI *this, unsigned int i_iidTarget, float i_fHealth) .text:004BD110 ?RecvNotice_UpdateObjectHealth@gmToolbarUI@@MAEXKM@Z

        // gmToolbarUI.RecvNotice_UseShortcut:
        public void RecvNotice_UseShortcut(int i_slot) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, int, void>)0x004BE5A0)(ref this, i_slot); // .text:004BD910 ; void __thiscall gmToolbarUI::RecvNotice_UseShortcut(gmToolbarUI *this, int i_slot) .text:004BD910 ?RecvNotice_UseShortcut@gmToolbarUI@@MAEXJ@Z

        // gmToolbarUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004BE730)(); // .text:004BDAA0 ; void __cdecl gmToolbarUI::Register() .text:004BDAA0 ?Register@gmToolbarUI@@SAXXZ

        // gmToolbarUI.RemoveShortcut:
        public int RemoveShortcut(UInt32 _itemID, Byte _broadcast) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, UInt32, Byte, int>)0x004BE0E0)(ref this, _itemID, _broadcast); // .text:004BD450 ; int __thiscall gmToolbarUI::RemoveShortcut(gmToolbarUI *this, unsigned int _itemID, bool _broadcast) .text:004BD450 ?RemoveShortcut@gmToolbarUI@@IAEHK_N@Z

        // gmToolbarUI.RemoveShortcutInSlotNum:
        public UInt32 RemoveShortcutInSlotNum(int _slot, Byte _broadcast) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, int, Byte, UInt32>)0x004BE180)(ref this, _slot, _broadcast); // .text:004BD4F0 ; unsigned int __thiscall gmToolbarUI::RemoveShortcutInSlotNum(gmToolbarUI *this, int _slot, bool _broadcast) .text:004BD4F0 ?RemoveShortcutInSlotNum@gmToolbarUI@@IAEKH_N@Z

        // gmToolbarUI.UpdateAmmoID:
        public void UpdateAmmoID() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004BFEA0)(ref this); // .text:004BF210 ; void __thiscall gmToolbarUI::UpdateAmmoID(gmToolbarUI *this) .text:004BF210 ?UpdateAmmoID@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.UpdateAmmoNumber:
        public void UpdateAmmoNumber() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004BF670)(ref this); // .text:004BE9E0 ; void __thiscall gmToolbarUI::UpdateAmmoNumber(gmToolbarUI *this) .text:004BE9E0 ?UpdateAmmoNumber@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.UpdateFromPlayerDesc:
        public void UpdateFromPlayerDesc() => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, void>)0x004C04A0)(ref this); // .text:004BF810 ; void __thiscall gmToolbarUI::UpdateFromPlayerDesc(gmToolbarUI *this) .text:004BF810 ?UpdateFromPlayerDesc@gmToolbarUI@@IAEXXZ

        // gmToolbarUI.UseShortcut:
        public void UseShortcut(int _slot, Byte i_bUse) => ((delegate* unmanaged[Thiscall]<ref gmToolbarUI, int, Byte, void>)0x004BDFE0)(ref this, _slot, i_bUse); // .text:004BD350 ; void __thiscall gmToolbarUI::UseShortcut(gmToolbarUI *this, int _slot, bool i_bUse) .text:004BD350 ?UseShortcut@gmToolbarUI@@IAEXH_N@Z
    }

    public unsafe struct PanelButtonInfo {
        // Struct:
        public UIElement* button;
        public UInt32 panelID;
        public override string ToString() => $"button:->(UIElement*)0x{(int)button:X8}, panelID:{panelID:X8}";
    }
    public unsafe struct gmFloatyToolbarUI {
        // Struct:
        public gmToolbarUI a0;
        public UInt32 m_eWindowID;
        public UIElement* m_pTopBorder;
        public UIElement* m_pLeftBorder;
        public UIElement* m_pBottomBorder;
        public UIElement* m_pRightBorder;
        public UIElement* m_pTopLeftCorner;
        public UIElement* m_pTopRightCorner;
        public UIElement* m_pBottomLeftCorner;
        public UIElement* m_pBottomRightCorner;
        public UIElement* m_pTopBorder_Locked;
        public UIElement* m_pLeftBorder_Locked;
        public UIElement* m_pBottomBorder_Locked;
        public UIElement* m_pRightBorder_Locked;
        public UIElement* m_pTopLeftCorner_Locked;
        public UIElement* m_pTopRightCorner_Locked;
        public UIElement* m_pBottomLeftCorner_Locked;
        public UIElement* m_pBottomRightCorner_Locked;
        public override string ToString() => $"a0(gmToolbarUI):{a0}, m_eWindowID:{m_eWindowID:X8}, m_pTopBorder:->(UIElement*)0x{(int)m_pTopBorder:X8}, m_pLeftBorder:->(UIElement*)0x{(int)m_pLeftBorder:X8}, m_pBottomBorder:->(UIElement*)0x{(int)m_pBottomBorder:X8}, m_pRightBorder:->(UIElement*)0x{(int)m_pRightBorder:X8}, m_pTopLeftCorner:->(UIElement*)0x{(int)m_pTopLeftCorner:X8}, m_pTopRightCorner:->(UIElement*)0x{(int)m_pTopRightCorner:X8}, m_pBottomLeftCorner:->(UIElement*)0x{(int)m_pBottomLeftCorner:X8}, m_pBottomRightCorner:->(UIElement*)0x{(int)m_pBottomRightCorner:X8}, m_pTopBorder_Locked:->(UIElement*)0x{(int)m_pTopBorder_Locked:X8}, m_pLeftBorder_Locked:->(UIElement*)0x{(int)m_pLeftBorder_Locked:X8}, m_pBottomBorder_Locked:->(UIElement*)0x{(int)m_pBottomBorder_Locked:X8}, m_pRightBorder_Locked:->(UIElement*)0x{(int)m_pRightBorder_Locked:X8}, m_pTopLeftCorner_Locked:->(UIElement*)0x{(int)m_pTopLeftCorner_Locked:X8}, m_pTopRightCorner_Locked:->(UIElement*)0x{(int)m_pTopRightCorner_Locked:X8}, m_pBottomLeftCorner_Locked:->(UIElement*)0x{(int)m_pBottomLeftCorner_Locked:X8}, m_pBottomRightCorner_Locked:->(UIElement*)0x{(int)m_pBottomRightCorner_Locked:X8}";

        // Functions:

        // gmFloatyToolbarUI.__Ctor:
        // public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, LayoutDesc*, ElementDesc*, void>)0xDEADBEEF)(ref this, _layout, _full_desc); // .text:004CF380 ; void __thiscall gmFloatyToolbarUI::gmFloatyToolbarUI(gmFloatyToolbarUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004CF380 ??0gmFloatyToolbarUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmFloatyToolbarUI.Create:
        // public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0xDEADBEEF)(_layout, _full_desc); // .text:004CF460 ; UIElement *__cdecl gmFloatyToolbarUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004CF460 ?Create@gmFloatyToolbarUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmFloatyToolbarUI.DynamicCast:
        // public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, UInt32, UIElement*>)0xDEADBEEF)(ref this, i_eType); // .text:004CF420 ; UIElement *__thiscall gmFloatyToolbarUI::DynamicCast(gmFloatyToolbarUI *this, unsigned int i_eType) .text:004CF420 ?DynamicCast@gmFloatyToolbarUI@@UAEPAVUIElement@@K@Z

        // gmFloatyToolbarUI.GetUIElementType:
        // public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, UInt32>)0xDEADBEEF)(ref this); // .text:004CF450 ; unsigned int __thiscall gmFloatyToolbarUI::GetUIElementType(gmFloatyToolbarUI *this) .text:004CF450 ?GetUIElementType@gmFloatyToolbarUI@@UBEKXZ

        // gmFloatyToolbarUI.ListenToGlobalMessage:
        // public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, UInt32, int, void>)0xDEADBEEF)(ref this, i_messageID, i_data_int); // .text:004CFA80 ; void __thiscall gmFloatyToolbarUI::ListenToGlobalMessage(gmFloatyToolbarUI *this, unsigned int i_messageID, int i_data_int) .text:004CFA80 ?ListenToGlobalMessage@gmFloatyToolbarUI@@MAEXKJ@Z

        // gmFloatyToolbarUI.MoveTo:
        // public void MoveTo(int i_x, int i_y) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, int, int, void>)0xDEADBEEF)(ref this, i_x, i_y); // .text:004CFE80 ; void __thiscall gmFloatyToolbarUI::MoveTo(gmFloatyToolbarUI *this, const int i_x, const int i_y) .text:004CFE80 ?MoveTo@gmFloatyToolbarUI@@UAEXJJ@Z

        // gmFloatyToolbarUI.PostInit:
        // public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, void>)0xDEADBEEF)(ref this); // .text:004CF6F0 ; void __thiscall gmFloatyToolbarUI::PostInit(gmFloatyToolbarUI *this) .text:004CF6F0 ?PostInit@gmFloatyToolbarUI@@UAEXXZ

        // gmFloatyToolbarUI.RecvNotice_PlayerDescReceived:
        // public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, CACQualities*, CPlayerModule*, void>)0xDEADBEEF)(ref this, i_playerDesc, i_playerModule); // .text:004CF660 ; void __thiscall gmFloatyToolbarUI::RecvNotice_PlayerDescReceived(gmFloatyToolbarUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004CF660 ?RecvNotice_PlayerDescReceived@gmFloatyToolbarUI@@MAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmFloatyToolbarUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004D0450)(); // .text:004CF6D0 ; void __cdecl gmFloatyToolbarUI::Register() .text:004CF6D0 ?Register@gmFloatyToolbarUI@@SAXXZ

        // gmFloatyToolbarUI.ResizeTo:
        // public void ResizeTo(int i_width, int i_height) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, int, int, void>)0xDEADBEEF)(ref this, i_width, i_height); // .text:004CFD10 ; void __thiscall gmFloatyToolbarUI::ResizeTo(gmFloatyToolbarUI *this, const int i_width, const int i_height) .text:004CFD10 ?ResizeTo@gmFloatyToolbarUI@@UAEXJJ@Z

        // gmFloatyToolbarUI.SetVisible:
        // public void SetVisible(Byte i_fVisible) => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, Byte, void>)0xDEADBEEF)(ref this, i_fVisible); // .text:004D0080 ; void __thiscall gmFloatyToolbarUI::SetVisible(gmFloatyToolbarUI *this, bool i_fVisible) .text:004D0080 ?SetVisible@gmFloatyToolbarUI@@UAEX_N@Z

        // gmFloatyToolbarUI.UpdateFromPlayerModule:
        // public void UpdateFromPlayerModule() => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, void>)0xDEADBEEF)(ref this); // .text:004CFAB0 ; void __thiscall gmFloatyToolbarUI::UpdateFromPlayerModule(gmFloatyToolbarUI *this) .text:004CFAB0 ?UpdateFromPlayerModule@gmFloatyToolbarUI@@MAEXXZ

        // gmFloatyToolbarUI.UpdateLockedStatus:
        // public void UpdateLockedStatus() => ((delegate* unmanaged[Thiscall]<ref gmFloatyToolbarUI, void>)0xDEADBEEF)(ref this); // .text:004CF490 ; void __thiscall gmFloatyToolbarUI::UpdateLockedStatus(gmFloatyToolbarUI *this) .text:004CF490 ?UpdateLockedStatus@gmFloatyToolbarUI@@IAEXXZ
    }
    public unsafe struct gm3DItemsUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public UIElement_Text* m_contentsText;
        public UIElement_ItemList* m_itemList;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_contentsText:->(UIElement_Text*)0x{(int)m_contentsText:X8}, m_itemList:->(UIElement_ItemList*)0x{(int)m_itemList:X8}";

        // Functions:

        // gm3DItemsUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004A7440)(_layout, _full_desc); // .text:004A70D0 ; UIElement *__cdecl gm3DItemsUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A70D0 ?Create@gm3DItemsUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gm3DItemsUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gm3DItemsUI, UInt32, UIElement*>)0x004A7410)(ref this, i_eType); // .text:004A70A0 ; UIElement *__thiscall gm3DItemsUI::DynamicCast(gm3DItemsUI *this, unsigned int i_eType) .text:004A70A0 ?DynamicCast@gm3DItemsUI@@UAEPAVUIElement@@K@Z

        // gm3DItemsUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gm3DItemsUI, UInt32>)0x004A7430)(ref this); // .text:004A70C0 ; unsigned int __thiscall gm3DItemsUI::GetUIElementType(gm3DItemsUI *this) .text:004A70C0 ?GetUIElementType@gm3DItemsUI@@UBEKXZ

        // gm3DItemsUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gm3DItemsUI, void>)0x004A7510)(ref this); // .text:004A7190 ; void __thiscall gm3DItemsUI::PostInit(gm3DItemsUI *this) .text:004A7190 ?PostInit@gm3DItemsUI@@UAEXXZ

        // gm3DItemsUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004A74F0)(); // .text:004A7170 ; void __cdecl gm3DItemsUI::Register() .text:004A7170 ?Register@gm3DItemsUI@@SAXXZ
    }
    public unsafe struct gmBackpackUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public UIElement_Text* m_burdenText;
        public UIElement_Meter* m_burdenMeter;
        public UIElement_ItemList* m_topContainer;
        public UIElement_ItemList* m_containerList;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_burdenText:->(UIElement_Text*)0x{(int)m_burdenText:X8}, m_burdenMeter:->(UIElement_Meter*)0x{(int)m_burdenMeter:X8}, m_topContainer:->(UIElement_ItemList*)0x{(int)m_topContainer:X8}, m_containerList:->(UIElement_ItemList*)0x{(int)m_containerList:X8}";

        // Functions:

        // gmBackpackUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, LayoutDesc*, ElementDesc*, void>)0x004A70E0)(ref this, _layout, _full_desc); // .text:004A6D70 ; void __thiscall gmBackpackUI::gmBackpackUI(gmBackpackUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A6D70 ??0gmBackpackUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmBackpackUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004A7160)(_layout, _full_desc); // .text:004A6DF0 ; UIElement *__cdecl gmBackpackUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A6DF0 ?Create@gmBackpackUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmBackpackUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, UInt32, UIElement*>)0x004A7130)(ref this, i_eType); // .text:004A6DC0 ; UIElement *__thiscall gmBackpackUI::DynamicCast(gmBackpackUI *this, unsigned int i_eType) .text:004A6DC0 ?DynamicCast@gmBackpackUI@@UAEPAVUIElement@@K@Z

        // gmBackpackUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, UInt32>)0x004A7150)(ref this); // .text:004A6DE0 ; unsigned int __thiscall gmBackpackUI::GetUIElementType(gmBackpackUI *this) .text:004A6DE0 ?GetUIElementType@gmBackpackUI@@UBEKXZ

        // gmBackpackUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, void>)0x004A72E0)(ref this); // .text:004A6F70 ; void __thiscall gmBackpackUI::PostInit(gmBackpackUI *this) .text:004A6F70 ?PostInit@gmBackpackUI@@UAEXXZ

        // gmBackpackUI.RecvNotice_LoadChanged:
        public void RecvNotice_LoadChanged(Single fNewLoad) => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, Single, void>)0x004A73F0)(ref this, fNewLoad); // .text:004A7080 ; void __thiscall gmBackpackUI::RecvNotice_LoadChanged(gmBackpackUI *this, float fNewLoad) .text:004A7080 ?RecvNotice_LoadChanged@gmBackpackUI@@UAEXM@Z

        // gmBackpackUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, CACQualities*, CPlayerModule*, void>)0x004A73B0)(ref this, i_playerDesc, i_playerModule); // .text:004A7040 ; void __thiscall gmBackpackUI::RecvNotice_PlayerDescReceived(gmBackpackUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004A7040 ?RecvNotice_PlayerDescReceived@gmBackpackUI@@UAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmBackpackUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004A71F0)(); // .text:004A6E80 ; void __cdecl gmBackpackUI::Register() .text:004A6E80 ?Register@gmBackpackUI@@SAXXZ

        // gmBackpackUI.SetLoadLevel:
        public void SetLoadLevel(Double _level) => ((delegate* unmanaged[Thiscall]<ref gmBackpackUI, Double, void>)0x004A7210)(ref this, _level); // .text:004A6EA0 ; void __thiscall gmBackpackUI::SetLoadLevel(gmBackpackUI *this, long double _level) .text:004A6EA0 ?SetLoadLevel@gmBackpackUI@@QAEXN@Z
    }
    public unsafe struct gmPaperDollUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public QualityChangeHandler a2;
        public ItemListDragHandler a3;
        public UIElement_ItemList* m_neckSlot;
        public UIElement_ItemList* m_leftWristSlot;
        public UIElement_ItemList* m_leftRingSlot;
        public UIElement_ItemList* m_rightWristSlot;
        public UIElement_ItemList* m_rightRingSlot;
        public UIElement_ItemList* m_weaponReadySlot;
        public UIElement_ItemList* m_ammoReadySlot;
        public UIElement_ItemList* m_shieldReadySlot;
        public UIElement_ItemList* m_clothesPantsSlot;
        public UIElement_ItemList* m_clothesShirtSlot;
        public UIElement_ItemList* m_trinketOneSlot;
        public UIElement_ItemList* m_cloakSlot;
        public UIElement_ItemList* m_sigilOneSlot;
        public UIElement_ItemList* m_sigilTwoSlot;
        public UIElement_ItemList* m_sigilThreeSlot;
        public UIElement_ItemList* m_headSlot;
        public UIElement_ItemList* m_chestSlot;
        public UIElement_ItemList* m_abdomenSlot;
        public UIElement_ItemList* m_upperArmSlot;
        public UIElement_ItemList* m_lowerArmSlot;
        public UIElement_ItemList* m_handSlot;
        public UIElement_ItemList* m_upperLegSlot;
        public UIElement_ItemList* m_lowerLegSlot;
        public UIElement_ItemList* m_footSlot;
        public CPhysicsObj* m_pInventoryObject;
        public UIElement_Viewport* m_pPaperDoll;
        public UInt32 m_didAnimation;
        public UIElement* m_dragIcon;
        public UIElement* m_paperDollDragMask;
        public UIElement* m_paperDollDragOverlay;
        public UIElement* m_sigilOneItem;
        public UIElement* m_sigilTwoItem;
        public UIElement* m_sigilThreeItem;
        public UIElement_Button* m_SlotCheckbox;
        public RenderSurface* m_clickMap;
        public UInt32 m_cFlipCount;
        public Double m_timeNextFlip;
        public UInt32 m_selectionMask;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(QualityChangeHandler):{a2}, a3(ItemListDragHandler):{a3}, m_neckSlot:->(UIElement_ItemList*)0x{(int)m_neckSlot:X8}, m_leftWristSlot:->(UIElement_ItemList*)0x{(int)m_leftWristSlot:X8}, m_leftRingSlot:->(UIElement_ItemList*)0x{(int)m_leftRingSlot:X8}, m_rightWristSlot:->(UIElement_ItemList*)0x{(int)m_rightWristSlot:X8}, m_rightRingSlot:->(UIElement_ItemList*)0x{(int)m_rightRingSlot:X8}, m_weaponReadySlot:->(UIElement_ItemList*)0x{(int)m_weaponReadySlot:X8}, m_ammoReadySlot:->(UIElement_ItemList*)0x{(int)m_ammoReadySlot:X8}, m_shieldReadySlot:->(UIElement_ItemList*)0x{(int)m_shieldReadySlot:X8}, m_clothesPantsSlot:->(UIElement_ItemList*)0x{(int)m_clothesPantsSlot:X8}, m_clothesShirtSlot:->(UIElement_ItemList*)0x{(int)m_clothesShirtSlot:X8}, m_trinketOneSlot:->(UIElement_ItemList*)0x{(int)m_trinketOneSlot:X8}, m_cloakSlot:->(UIElement_ItemList*)0x{(int)m_cloakSlot:X8}, m_sigilOneSlot:->(UIElement_ItemList*)0x{(int)m_sigilOneSlot:X8}, m_sigilTwoSlot:->(UIElement_ItemList*)0x{(int)m_sigilTwoSlot:X8}, m_sigilThreeSlot:->(UIElement_ItemList*)0x{(int)m_sigilThreeSlot:X8}, m_headSlot:->(UIElement_ItemList*)0x{(int)m_headSlot:X8}, m_chestSlot:->(UIElement_ItemList*)0x{(int)m_chestSlot:X8}, m_abdomenSlot:->(UIElement_ItemList*)0x{(int)m_abdomenSlot:X8}, m_upperArmSlot:->(UIElement_ItemList*)0x{(int)m_upperArmSlot:X8}, m_lowerArmSlot:->(UIElement_ItemList*)0x{(int)m_lowerArmSlot:X8}, m_handSlot:->(UIElement_ItemList*)0x{(int)m_handSlot:X8}, m_upperLegSlot:->(UIElement_ItemList*)0x{(int)m_upperLegSlot:X8}, m_lowerLegSlot:->(UIElement_ItemList*)0x{(int)m_lowerLegSlot:X8}, m_footSlot:->(UIElement_ItemList*)0x{(int)m_footSlot:X8}, m_pInventoryObject:->(CPhysicsObj*)0x{(int)m_pInventoryObject:X8}, m_pPaperDoll:->(UIElement_Viewport*)0x{(int)m_pPaperDoll:X8}, m_didAnimation:{m_didAnimation:X8}, m_dragIcon:->(UIElement*)0x{(int)m_dragIcon:X8}, m_paperDollDragMask:->(UIElement*)0x{(int)m_paperDollDragMask:X8}, m_paperDollDragOverlay:->(UIElement*)0x{(int)m_paperDollDragOverlay:X8}, m_sigilOneItem:->(UIElement*)0x{(int)m_sigilOneItem:X8}, m_sigilTwoItem:->(UIElement*)0x{(int)m_sigilTwoItem:X8}, m_sigilThreeItem:->(UIElement*)0x{(int)m_sigilThreeItem:X8}, m_SlotCheckbox:->(UIElement_Button*)0x{(int)m_SlotCheckbox:X8}, m_clickMap:->(RenderSurface*)0x{(int)m_clickMap:X8}, m_cFlipCount:{m_cFlipCount:X8}, m_timeNextFlip:{m_timeNextFlip:n5}, m_selectionMask:{m_selectionMask:X8}";

        // Functions:

        // gmPaperDollUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, LayoutDesc*, ElementDesc*, void>)0x004A4430)(ref this, _layout, _full_desc); // .text:004A40C0 ; void __thiscall gmPaperDollUI::gmPaperDollUI(gmPaperDollUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A40C0 ??0gmPaperDollUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmPaperDollUI.AcceptDragObject:
        public Byte AcceptDragObject(UInt32 _itemID, UInt32* _loc, UI_SLOT_SIDE* _slotSide) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32*, UI_SLOT_SIDE*, Byte>)0x004A3E80)(ref this, _itemID, _loc, _slotSide); // .text:004A3B10 ; bool __thiscall gmPaperDollUI::AcceptDragObject(gmPaperDollUI *this, unsigned int _itemID, unsigned int *_loc, UI_SLOT_SIDE *_slotSide) .text:004A3B10 ?AcceptDragObject@gmPaperDollUI@@IAE_NKAAKAAW4UI_SLOT_SIDE@@@Z

        // gmPaperDollUI.AcceptPaperDollDragObject:
        public Byte AcceptPaperDollDragObject(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, Byte>)0x004A4DE0)(ref this, _itemID); // .text:004A4A70 ; bool __thiscall gmPaperDollUI::AcceptPaperDollDragObject(gmPaperDollUI *this, unsigned int _itemID) .text:004A4A70 ?AcceptPaperDollDragObject@gmPaperDollUI@@IAE_NK@Z

        // gmPaperDollUI.ApplyPartSelectionLighting:
        public void ApplyPartSelectionLighting(UInt32 _locations, Single _luminosity, Single _diffuse) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, Single, Single, void>)0x004A4010)(ref this, _locations, _luminosity, _diffuse); // .text:004A3CA0 ; void __thiscall gmPaperDollUI::ApplyPartSelectionLighting(gmPaperDollUI *this, unsigned int _locations, float _luminosity, float _diffuse) .text:004A3CA0 ?ApplyPartSelectionLighting@gmPaperDollUI@@IAEXKMM@Z

        // gmPaperDollUI.BeginPartSelectionLighting:
        public void BeginPartSelectionLighting(UInt32 _objID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, void>)0x004A4FC0)(ref this, _objID); // .text:004A4C50 ; void __thiscall gmPaperDollUI::BeginPartSelectionLighting(gmPaperDollUI *this, unsigned int _objID) .text:004A4C50 ?BeginPartSelectionLighting@gmPaperDollUI@@IAEXK@Z

        // gmPaperDollUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004A45B0)(_layout, _full_desc); // .text:004A4240 ; UIElement *__cdecl gmPaperDollUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A4240 ?Create@gmPaperDollUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmPaperDollUI.CreateClickMap:
        public void CreateClickMap() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A4BC0)(ref this); // .text:004A4850 ; void __thiscall gmPaperDollUI::CreateClickMap(gmPaperDollUI *this) .text:004A4850 ?CreateClickMap@gmPaperDollUI@@IAEXXZ

        // gmPaperDollUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UIElement*>)0x004A3B30)(ref this, i_eType); // .text:004A37C0 ; UIElement *__thiscall gmPaperDollUI::DynamicCast(gmPaperDollUI *this, unsigned int i_eType) .text:004A37C0 ?DynamicCast@gmPaperDollUI@@UAEPAVUIElement@@K@Z

        // gmPaperDollUI.EndPartSelectionLighting:
        public void EndPartSelectionLighting() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A3FE0)(ref this); // .text:004A3C70 ; void __thiscall gmPaperDollUI::EndPartSelectionLighting(gmPaperDollUI *this) .text:004A3C70 ?EndPartSelectionLighting@gmPaperDollUI@@IAEXXZ

        // gmPaperDollUI.GetLocationInfoFromElementID:
        public void GetLocationInfoFromElementID(UInt32 _elemID, UInt32* _loc, UI_SLOT_SIDE* _slotSide) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32*, UI_SLOT_SIDE*, void>)0x004A3B60)(ref this, _elemID, _loc, _slotSide); // .text:004A37F0 ; void __thiscall gmPaperDollUI::GetLocationInfoFromElementID(gmPaperDollUI *this, unsigned int _elemID, unsigned int *_loc, UI_SLOT_SIDE *_slotSide) .text:004A37F0 ?GetLocationInfoFromElementID@gmPaperDollUI@@IAEXKAAKAAW4UI_SLOT_SIDE@@@Z

        // gmPaperDollUI.GetPaperDollItemUnderMouse:
        public UInt32 GetPaperDollItemUnderMouse(int window_mousex, int window_mousey) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, int, int, UInt32>)0x004A4C90)(ref this, window_mousex, window_mousey); // .text:004A4920 ; unsigned int __thiscall gmPaperDollUI::GetPaperDollItemUnderMouse(gmPaperDollUI *this, int window_mousex, int window_mousey) .text:004A4920 ?GetPaperDollItemUnderMouse@gmPaperDollUI@@IAEKJJ@Z

        // gmPaperDollUI.GetSelectionMaskFromObject:
        public UInt32 GetSelectionMaskFromObject(UInt32 _objID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32>)0x004A4EC0)(ref this, _objID); // .text:004A4B50 ; unsigned int __thiscall gmPaperDollUI::GetSelectionMaskFromObject(gmPaperDollUI *this, unsigned int _objID) .text:004A4B50 ?GetSelectionMaskFromObject@gmPaperDollUI@@IAEKK@Z

        // gmPaperDollUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32>)0x004A3B50)(ref this); // .text:004A37E0 ; unsigned int __thiscall gmPaperDollUI::GetUIElementType(gmPaperDollUI *this) .text:004A37E0 ?GetUIElementType@gmPaperDollUI@@UBEKXZ

        // gmPaperDollUI.GetUpperInvObj:
        public UInt32 GetUpperInvObj(UInt32 _locations) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32>)0x004A4AC0)(ref this, _locations); // .text:004A4750 ; unsigned int __thiscall gmPaperDollUI::GetUpperInvObj(gmPaperDollUI *this, unsigned int _locations) .text:004A4750 ?GetUpperInvObj@gmPaperDollUI@@IAEKK@Z

        // gmPaperDollUI.HandleDropRelease:
        public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UIElementMessageInfo*, void>)0x004A50F0)(ref this, i_rMsg); // .text:004A4D80 ; void __thiscall gmPaperDollUI::HandleDropRelease(gmPaperDollUI *this, UIElementMessageInfo *i_rMsg) .text:004A4D80 ?HandleDropRelease@gmPaperDollUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmPaperDollUI.HandlePaperDollDragOver:
        public void HandlePaperDollDragOver(UIElement* _dragElement) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UIElement*, void>)0x004A3DE0)(ref this, _dragElement); // .text:004A3A70 ; void __thiscall gmPaperDollUI::HandlePaperDollDragOver(gmPaperDollUI *this, UIElement *_dragElement) .text:004A3A70 ?HandlePaperDollDragOver@gmPaperDollUI@@IAEXPAVUIElement@@@Z

        // gmPaperDollUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004A5FA0)(ref this, i_rMsg); // .text:004A5C30 ; UIElementMessageListenResult __thiscall gmPaperDollUI::ListenToElementMessage(gmPaperDollUI *this, UIElementMessageInfo *i_rMsg) .text:004A5C30 ?ListenToElementMessage@gmPaperDollUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmPaperDollUI.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, int, void>)0x004A5020)(ref this, i_messageID, i_data_int); // .text:004A4CB0 ; void __thiscall gmPaperDollUI::ListenToGlobalMessage(gmPaperDollUI *this, unsigned int i_messageID, int i_data_int) .text:004A4CB0 ?ListenToGlobalMessage@gmPaperDollUI@@UAEXKJ@Z

        // gmPaperDollUI.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004A45E0)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004A4270 ; bool __thiscall gmPaperDollUI::OnItemListDragOver(gmPaperDollUI *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004A4270 ?OnItemListDragOver@gmPaperDollUI@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // gmPaperDollUI.OnQualityChanged:
        public void OnQualityChanged(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, CWeenieObject*, StatType, UInt32, void>)0x004A4800)(ref this, cwobj, stype, senum); // .text:004A4490 ; void __thiscall gmPaperDollUI::OnQualityChanged(gmPaperDollUI *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:004A4490 ?OnQualityChanged@gmPaperDollUI@@UAEXPAVCWeenieObject@@W4StatType@@K@Z

        // gmPaperDollUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A56D0)(ref this); // .text:004A5360 ; void __thiscall gmPaperDollUI::PostInit(gmPaperDollUI *this) .text:004A5360 ?PostInit@gmPaperDollUI@@UAEXXZ

        // gmPaperDollUI.PrepareDragIcon:
        public Byte PrepareDragIcon(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, Byte>)0x004A48F0)(ref this, _itemID); // .text:004A4580 ; bool __thiscall gmPaperDollUI::PrepareDragIcon(gmPaperDollUI *this, unsigned int _itemID) .text:004A4580 ?PrepareDragIcon@gmPaperDollUI@@IAE_NK@Z

        // gmPaperDollUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, CACQualities*, CPlayerModule*, void>)0x004A4750)(ref this, i_playerDesc, i_playerModule); // .text:004A43E0 ; void __thiscall gmPaperDollUI::RecvNotice_PlayerDescReceived(gmPaperDollUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004A43E0 ?RecvNotice_PlayerDescReceived@gmPaperDollUI@@UAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmPaperDollUI.RecvNotice_PlayerObjDescChanged:
        public void RecvNotice_PlayerObjDescChanged() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A46C0)(ref this); // .text:004A4350 ; void __thiscall gmPaperDollUI::RecvNotice_PlayerObjDescChanged(gmPaperDollUI *this) .text:004A4350 ?RecvNotice_PlayerObjDescChanged@gmPaperDollUI@@MAEXXZ

        // gmPaperDollUI.RecvNotice_SetSelectedItem:
        public void RecvNotice_SetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32, void>)0x004A51E0)(ref this, _oldSelectedID, _selectedID); // .text:004A4E70 ; void __thiscall gmPaperDollUI::RecvNotice_SetSelectedItem(gmPaperDollUI *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004A4E70 ?RecvNotice_SetSelectedItem@gmPaperDollUI@@UAEXKK@Z

        // gmPaperDollUI.RedressCreature:
        public void RedressCreature() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A3F30)(ref this); // .text:004A3BC0 ; void __thiscall gmPaperDollUI::RedressCreature(gmPaperDollUI *this) .text:004A3BC0 ?RedressCreature@gmPaperDollUI@@IAEXXZ

        // gmPaperDollUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004A48D0)(); // .text:004A4560 ; void __cdecl gmPaperDollUI::Register() .text:004A4560 ?Register@gmPaperDollUI@@SAXXZ

        // gmPaperDollUI.RemakeCharacterInventory:
        public Byte RemakeCharacterInventory() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, Byte>)0x004A6930)(ref this); // .text:004A65C0 ; bool __thiscall gmPaperDollUI::RemakeCharacterInventory(gmPaperDollUI *this) .text:004A65C0 ?RemakeCharacterInventory@gmPaperDollUI@@QAE_NXZ

        // gmPaperDollUI.ServerSaysMoveItem:
        public void ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004A6810)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004A64A0 ; void __thiscall gmPaperDollUI::ServerSaysMoveItem(gmPaperDollUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004A64A0 ?ServerSaysMoveItem@gmPaperDollUI@@IAEXKKKKKHKK@Z

        // gmPaperDollUI.SetUIItemIntoLocation:
        public void SetUIItemIntoLocation(UInt32 _itemID, UInt32 _location) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, UInt32, void>)0x004A6300)(ref this, _itemID, _location); // .text:004A5F90 ; void __thiscall gmPaperDollUI::SetUIItemIntoLocation(gmPaperDollUI *this, unsigned int _itemID, unsigned int _location) .text:004A5F90 ?SetUIItemIntoLocation@gmPaperDollUI@@IAEXKK@Z

        // gmPaperDollUI.UpdateAetheria:
        public void UpdateAetheria(CWeenieObject* cwobj) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, CWeenieObject*, void>)0x004A41C0)(ref this, cwobj); // .text:004A3E50 ; void __thiscall gmPaperDollUI::UpdateAetheria(gmPaperDollUI *this, CWeenieObject *cwobj) .text:004A3E50 ?UpdateAetheria@gmPaperDollUI@@IAEXPAVCWeenieObject@@@Z

        // gmPaperDollUI.UpdateForRace:
        public void UpdateForRace(UInt32 heritage) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UInt32, void>)0x004A4240)(ref this, heritage); // .text:004A3ED0 ; void __thiscall gmPaperDollUI::UpdateForRace(gmPaperDollUI *this, unsigned int heritage) .text:004A3ED0 ?UpdateForRace@gmPaperDollUI@@IAEXK@Z

        // gmPaperDollUI.UpdateItemSlotTooltip:
        public void UpdateItemSlotTooltip(UIElement_ItemList* i_pSlot, UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, UIElement_ItemList*, UInt32, void>)0x004A5200)(ref this, i_pSlot, _itemID); // .text:004A4E90 ; void __thiscall gmPaperDollUI::UpdateItemSlotTooltip(gmPaperDollUI *this, UIElement_ItemList *i_pSlot, unsigned int _itemID) .text:004A4E90 ?UpdateItemSlotTooltip@gmPaperDollUI@@IAEXPAVUIElement_ItemList@@K@Z

        // gmPaperDollUI.UpdatePartSelectionLighting:
        public void UpdatePartSelectionLighting() => ((delegate* unmanaged[Thiscall]<ref gmPaperDollUI, void>)0x004A46D0)(ref this); // .text:004A4360 ; void __thiscall gmPaperDollUI::UpdatePartSelectionLighting(gmPaperDollUI *this) .text:004A4360 ?UpdatePartSelectionLighting@gmPaperDollUI@@IAEXXZ
    }



    // 5100018
    public unsafe struct gmInventoryUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public gmPaperDollUI* m_paperDollUI;
        public gmBackpackUI* m_backpackUI;
        public gm3DItemsUI* m_3DItemsUI;
        public UIElement_Text* m_titleText;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, m_paperDollUI:->(gmPaperDollUI*)0x{(int)m_paperDollUI:X8}, m_backpackUI:->(gmBackpackUI*)0x{(int)m_backpackUI:X8}, m_3DItemsUI:->(gm3DItemsUI*)0x{(int)m_3DItemsUI:X8}, m_titleText:->(UIElement_Text*)0x{(int)m_titleText:X8}";

        // Functions:

        // gmInventoryUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, LayoutDesc*, ElementDesc*, void>)0x004A69E0)(ref this, _layout, _full_desc); // .text:004A6670 ; void __thiscall gmInventoryUI::gmInventoryUI(gmInventoryUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A6670 ??0gmInventoryUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmInventoryUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004A6A60)(_layout, _full_desc); // .text:004A66F0 ; UIElement *__cdecl gmInventoryUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004A66F0 ?Create@gmInventoryUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmInventoryUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, UIElement*>)0x004A6A30)(ref this, i_eType); // .text:004A66C0 ; UIElement *__thiscall gmInventoryUI::DynamicCast(gmInventoryUI *this, unsigned int i_eType) .text:004A66C0 ?DynamicCast@gmInventoryUI@@UAEPAVUIElement@@K@Z

        // gmInventoryUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32>)0x004A6A50)(ref this); // .text:004A66E0 ; unsigned int __thiscall gmInventoryUI::GetUIElementType(gmInventoryUI *this) .text:004A66E0 ?GetUIElementType@gmInventoryUI@@UBEKXZ

        // gmInventoryUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, void>)0x004A6CB0)(ref this); // .text:004A6940 ; void __thiscall gmInventoryUI::PostInit(gmInventoryUI *this) .text:004A6940 ?PostInit@gmInventoryUI@@UAEXXZ

        // gmInventoryUI.RecvNotice_EndPendingInPlayer:
        public void RecvNotice_EndPendingInPlayer() => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, void>)0x004A6C20)(ref this); // .text:004A68B0 ; void __thiscall gmInventoryUI::RecvNotice_EndPendingInPlayer(gmInventoryUI *this) .text:004A68B0 ?RecvNotice_EndPendingInPlayer@gmInventoryUI@@MAEXXZ

        // gmInventoryUI.RecvNotice_ItemAttributesChanged:
        public void RecvNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, UInt32, void>)0x004A6B80)(ref this, i_target, i_attrib); // .text:004A6810 ; void __thiscall gmInventoryUI::RecvNotice_ItemAttributesChanged(gmInventoryUI *this, unsigned int i_target, unsigned int i_attrib) .text:004A6810 ?RecvNotice_ItemAttributesChanged@gmInventoryUI@@MAEXKK@Z

        // gmInventoryUI.RecvNotice_NewParentContainer:
        public void RecvNotice_NewParentContainer(UInt32 i_newContainerID) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, void>)0x004A7000)(ref this, i_newContainerID); // .text:004A6C90 ; void __thiscall gmInventoryUI::RecvNotice_NewParentContainer(gmInventoryUI *this, unsigned int i_newContainerID) .text:004A6C90 ?RecvNotice_NewParentContainer@gmInventoryUI@@MAEXK@Z

        // gmInventoryUI.RecvNotice_OpenContainedContainer:
        public void RecvNotice_OpenContainedContainer(UInt32 i_containerID) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, void>)0x004A6DF0)(ref this, i_containerID); // .text:004A6A80 ; void __thiscall gmInventoryUI::RecvNotice_OpenContainedContainer(gmInventoryUI *this, unsigned int i_containerID) .text:004A6A80 ?RecvNotice_OpenContainedContainer@gmInventoryUI@@MAEXK@Z

        // gmInventoryUI.RecvNotice_PlayerDescReceived:
        public void RecvNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, CACQualities*, CPlayerModule*, void>)0x004A6F30)(ref this, i_playerDesc, i_playerModule); // .text:004A6BC0 ; void __thiscall gmInventoryUI::RecvNotice_PlayerDescReceived(gmInventoryUI *this, CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:004A6BC0 ?RecvNotice_PlayerDescReceived@gmInventoryUI@@MAEXABVCACQualities@@ABVCPlayerModule@@@Z

        // gmInventoryUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004A6BB0)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004A6840 ; void __thiscall gmInventoryUI::RecvNotice_ServerSaysMoveItem(gmInventoryUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004A6840 ?RecvNotice_ServerSaysMoveItem@gmInventoryUI@@MAEXKKKKKHKK@Z

        // gmInventoryUI.RecvNotice_SetDisplayInventory:
        public void RecvNotice_SetDisplayInventory(int display) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, int, void>)0x004A6AC0)(ref this, display); // .text:004A6750 ; void __thiscall gmInventoryUI::RecvNotice_SetDisplayInventory(gmInventoryUI *this, int display) .text:004A6750 ?RecvNotice_SetDisplayInventory@gmInventoryUI@@MAEXH@Z

        // gmInventoryUI.RecvNotice_ShowPendingInPlayer:
        public void RecvNotice_ShowPendingInPlayer(UInt32 i_itemID) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, UInt32, void>)0x004A6EC0)(ref this, i_itemID); // .text:004A6B50 ; void __thiscall gmInventoryUI::RecvNotice_ShowPendingInPlayer(gmInventoryUI *this, unsigned int i_itemID) .text:004A6B50 ?RecvNotice_ShowPendingInPlayer@gmInventoryUI@@MAEXK@Z

        // gmInventoryUI.RecvNotice_UpdateCharacterInformation:
        public void RecvNotice_UpdateCharacterInformation(CACQualities* i_playerDesc) => ((delegate* unmanaged[Thiscall]<ref gmInventoryUI, CACQualities*, void>)0x004A6A90)(ref this, i_playerDesc); // .text:004A6720 ; void __thiscall gmInventoryUI::RecvNotice_UpdateCharacterInformation(gmInventoryUI *this, CACQualities *i_playerDesc) .text:004A6720 ?RecvNotice_UpdateCharacterInformation@gmInventoryUI@@MAEXABVCACQualities@@@Z

        // gmInventoryUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004A6DD0)(); // .text:004A6A60 ; void __cdecl gmInventoryUI::Register() .text:004A6A60 ?Register@gmInventoryUI@@SAXXZ
    }



    // 5100025
    public unsafe struct gmExternalContainerUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public ObjectRangeHandler a2;
        public ItemListDragHandler a3;
        public UIElement_ItemList* m_topContainer;
        public UIElement_ItemList* m_containerList;
        public UIElement_ItemList* m_itemList;
        public UInt32 groundObjectID;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(ObjectRangeHandler):{a2}, a3(ItemListDragHandler):{a3}, m_topContainer:->(UIElement_ItemList*)0x{(int)m_topContainer:X8}, m_containerList:->(UIElement_ItemList*)0x{(int)m_containerList:X8}, m_itemList:->(UIElement_ItemList*)0x{(int)m_itemList:X8}, groundObjectID:{groundObjectID:X8}";

        // Functions:

        // gmExternalContainerUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, LayoutDesc*, ElementDesc*, void>)0x004CC930)(ref this, _layout, _full_desc); // .text:004CBD40 ; void __thiscall gmExternalContainerUI::gmExternalContainerUI(gmExternalContainerUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004CBD40 ??0gmExternalContainerUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmExternalContainerUI.CloseCurrentContainer:
        public void CloseCurrentContainer() => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, void>)0x004CC8A0)(ref this); // .text:004CBCB0 ; void __thiscall gmExternalContainerUI::CloseCurrentContainer(gmExternalContainerUI *this) .text:004CBCB0 ?CloseCurrentContainer@gmExternalContainerUI@@IAEXXZ

        // gmExternalContainerUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004CCB10)(_layout, _full_desc); // .text:004CBF20 ; UIElement *__cdecl gmExternalContainerUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004CBF20 ?Create@gmExternalContainerUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmExternalContainerUI.DragItemAcceptable:
        public Byte DragItemAcceptable(UInt32 _itemID, Byte _silent) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, Byte, Byte>)0x004CC750)(ref this, _itemID, _silent); // .text:004CBB60 ; bool __thiscall gmExternalContainerUI::DragItemAcceptable(gmExternalContainerUI *this, unsigned int _itemID, bool _silent) .text:004CBB60 ?DragItemAcceptable@gmExternalContainerUI@@IAE_NK_N@Z

        // gmExternalContainerUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, UIElement*>)0x004CC690)(ref this, i_eType); // .text:004CBAA0 ; UIElement *__thiscall gmExternalContainerUI::DynamicCast(gmExternalContainerUI *this, unsigned int i_eType) .text:004CBAA0 ?DynamicCast@gmExternalContainerUI@@UAEPAVUIElement@@K@Z

        // gmExternalContainerUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32>)0x004CC6B0)(ref this); // .text:004CBAC0 ; unsigned int __thiscall gmExternalContainerUI::GetUIElementType(CombatManeuverTable *this) .text:004CBAC0 ?GetUIElementType@gmExternalContainerUI@@UBEKXZ

        // gmExternalContainerUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004CC6C0)(ref this, i_rMsg); // .text:004CBAD0 ; UIElementMessageListenResult __thiscall gmExternalContainerUI::ListenToElementMessage(gmExternalContainerUI *this, UIElementMessageInfo *i_rMsg) .text:004CBAD0 ?ListenToElementMessage@gmExternalContainerUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmExternalContainerUI.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004CCB70)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004CBF80 ; bool __thiscall gmExternalContainerUI::OnItemListDragOver(gmExternalContainerUI *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004CBF80 ?OnItemListDragOver@gmExternalContainerUI@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // gmExternalContainerUI.OnObjectRangeExit:
        public void OnObjectRangeExit(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, void>)0x004CC900)(ref this, _objectID); // .text:004CBD10 ; void __thiscall gmExternalContainerUI::OnObjectRangeExit(gmExternalContainerUI *this, unsigned int _objectID) .text:004CBD10 ?OnObjectRangeExit@gmExternalContainerUI@@MAEXK@Z

        // gmExternalContainerUI.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, Byte, void>)0x004CCB40)(ref this, i_bVisible); // .text:004CBF50 ; void __thiscall gmExternalContainerUI::OnVisibilityChanged(gmExternalContainerUI *this, bool i_bVisible) .text:004CBF50 ?OnVisibilityChanged@gmExternalContainerUI@@MAEX_N@Z

        // gmExternalContainerUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, void>)0x004CC9D0)(ref this); // .text:004CBDE0 ; void __thiscall gmExternalContainerUI::PostInit(gmExternalContainerUI *this) .text:004CBDE0 ?PostInit@gmExternalContainerUI@@UAEXXZ

        // gmExternalContainerUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004CC720)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004CBB30 ; void __thiscall gmExternalContainerUI::RecvNotice_ServerSaysMoveItem(gmExternalContainerUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004CBB30 ?RecvNotice_ServerSaysMoveItem@gmExternalContainerUI@@MAEXKKKKKHKK@Z

        // gmExternalContainerUI.RecvNotice_SetGroundObject:
        public void RecvNotice_SetGroundObject(UInt32 i_objid) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, void>)0x004CCBC0)(ref this, i_objid); // .text:004CBFD0 ; void __thiscall gmExternalContainerUI::RecvNotice_SetGroundObject(gmExternalContainerUI *this, unsigned int i_objid) .text:004CBFD0 ?RecvNotice_SetGroundObject@gmExternalContainerUI@@MAEXK@Z

        // gmExternalContainerUI.RecvNotice_StopViewingObject:
        public void RecvNotice_StopViewingObject(UInt32 i_objid) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, void>)0x004CC6F0)(ref this, i_objid); // .text:004CBB00 ; void __thiscall gmExternalContainerUI::RecvNotice_StopViewingObject(gmExternalContainerUI *this, unsigned int i_objid) .text:004CBB00 ?RecvNotice_StopViewingObject@gmExternalContainerUI@@MAEXK@Z

        // gmExternalContainerUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004CCBD0)(); // .text:004CBFE0 ; void __cdecl gmExternalContainerUI::Register() .text:004CBFE0 ?Register@gmExternalContainerUI@@SAXXZ

        // gmExternalContainerUI.SetGroundObject:
        public void SetGroundObject(UInt32 _groundObjectID) => ((delegate* unmanaged[Thiscall]<ref gmExternalContainerUI, UInt32, void>)0x004CC7C0)(ref this, _groundObjectID); // .text:004CBBD0 ; void __thiscall gmExternalContainerUI::SetGroundObject(gmExternalContainerUI *this, unsigned int _groundObjectID) .text:004CBBD0 ?SetGroundObject@gmExternalContainerUI@@IAEXK@Z
    }
    public unsafe struct AppraisalSystem {
        // Struct:

        // Functions:

        // AppraisalSystem.AttunedStatusToString:
        public static int AttunedStatusToString(AttunedStatusEnum attuned, AC1Legacy.PStringBase<char>* label) => ((delegate* unmanaged[Cdecl]<AttunedStatusEnum, AC1Legacy.PStringBase<char>*, int>)0x005B5900)(attuned, label); // .text:005B4850 ; int __cdecl AppraisalSystem::AttunedStatusToString(AttunedStatusEnum attuned, AC1Legacy::PStringBase<char> *label) .text:005B4850 ?AttunedStatusToString@AppraisalSystem@@SAHW4AttunedStatusEnum@@AAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.BondedStatusToString:
        public static int BondedStatusToString(BondedStatusEnum bonded, AC1Legacy.PStringBase<char>* label) => ((delegate* unmanaged[Cdecl]<BondedStatusEnum, AC1Legacy.PStringBase<char>*, int>)0x005B5930)(bonded, label); // .text:005B4880 ; int __cdecl AppraisalSystem::BondedStatusToString(BondedStatusEnum bonded, AC1Legacy::PStringBase<char> *label) .text:005B4880 ?BondedStatusToString@AppraisalSystem@@SAHW4BondedStatusEnum@@AAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.ClothingPriorityToString:
        public static int ClothingPriorityToString(UInt32 priority, AC1Legacy.PStringBase<char>* ps) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B5FE0)(priority, ps); // .text:005B4F30 ; int __cdecl AppraisalSystem::ClothingPriorityToString(unsigned int priority, AC1Legacy::PStringBase<char> *ps) .text:005B4F30 ?ClothingPriorityToString@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.DamageResistanceToString:
        public static int DamageResistanceToString(DAMAGE_TYPE dtype, int al, Single modifier, AC1Legacy.PStringBase<char>* ps) => ((delegate* unmanaged[Cdecl]<DAMAGE_TYPE, int, Single, AC1Legacy.PStringBase<char>*, int>)0x005B6540)(dtype, al, modifier, ps); // .text:005B5490 ; int __cdecl AppraisalSystem::DamageResistanceToString(DAMAGE_TYPE dtype, const int al, float modifier, AC1Legacy::PStringBase<char> *ps) .text:005B5490 ?DamageResistanceToString@AppraisalSystem@@SAHW4DAMAGE_TYPE@@JMAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.DamageTypeToString:
        public static UInt32 DamageTypeToString(DAMAGE_TYPE dtype, char* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<DAMAGE_TYPE, char*, UInt32, UInt32>)0x005B52B0)(dtype, buf, size); // .text:005B4200 ; unsigned int __cdecl AppraisalSystem::DamageTypeToString(DAMAGE_TYPE dtype, char *buf, const unsigned int size) .text:005B4200 ?DamageTypeToString@AppraisalSystem@@SAIW4DAMAGE_TYPE@@PADI@Z

        // AppraisalSystem.InqCreatureDisplayName:
        public static int InqCreatureDisplayName(UInt32 type, AC1Legacy.PStringBase<char>* strName) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B6A90)(type, strName); // .text:005B59E0 ; int __cdecl AppraisalSystem::InqCreatureDisplayName(unsigned int type, AC1Legacy::PStringBase<char> *strName) .text:005B59E0 ?InqCreatureDisplayName@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.InqGenderDisplayName:
        public static int InqGenderDisplayName(UInt32 type, AC1Legacy.PStringBase<char>* strName) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B5870)(type, strName); // .text:005B47C0 ; int __cdecl AppraisalSystem::InqGenderDisplayName(unsigned int type, AC1Legacy::PStringBase<char> *strName) .text:005B47C0 ?InqGenderDisplayName@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.InqGenderHeritageDisplay:
        public static int InqGenderHeritageDisplay(UInt32 gender, UInt32 heritage, UInt32 creature, AC1Legacy.PStringBase<char>* strName) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B6B90)(gender, heritage, creature, strName); // .text:005B5AE0 ; int __cdecl AppraisalSystem::InqGenderHeritageDisplay(unsigned int gender, unsigned int heritage, unsigned int creature, AC1Legacy::PStringBase<char> *strName) .text:005B5AE0 ?InqGenderHeritageDisplay@AppraisalSystem@@SAHKKKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.InqHeritageGroupDisplayName:
        public static int InqHeritageGroupDisplayName(UInt32 type, AC1Legacy.PStringBase<char>* strName) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B57C0)(type, strName); // .text:005B4710 ; int __cdecl AppraisalSystem::InqHeritageGroupDisplayName(unsigned int type, AC1Legacy::PStringBase<char> *strName) .text:005B4710 ?InqHeritageGroupDisplayName@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.InqMaterialName:
        public static int InqMaterialName(UInt32 mat_type, PStringBase<char>* material) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<char>*, int>)0x005B5690)(mat_type, material); // .text:005B45E0 ; int __cdecl AppraisalSystem::InqMaterialName(unsigned int mat_type, PStringBase<char> *material) .text:005B45E0 ?InqMaterialName@AppraisalSystem@@SAHKAAV?$PStringBase@D@@@Z

        // AppraisalSystem.InqPluralizedGemName:
        public static int InqPluralizedGemName(UInt32 gem_type, PStringBase<char>* gemname) => ((delegate* unmanaged[Cdecl]<UInt32, PStringBase<char>*, int>)0x005B68B0)(gem_type, gemname); // .text:005B5800 ; int __cdecl AppraisalSystem::InqPluralizedGemName(unsigned int gem_type, PStringBase<char> *gemname) .text:005B5800 ?InqPluralizedGemName@AppraisalSystem@@SAHKAAV?$PStringBase@D@@@Z

        // AppraisalSystem.InqWorkmanshipAdjective:
        public static int InqWorkmanshipAdjective(UInt32 wlevel, AC1Legacy.PStringBase<char>* workmanship, int gem) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int, int>)0x005B5990)(wlevel, workmanship, gem); // .text:005B48E0 ; int __cdecl AppraisalSystem::InqWorkmanshipAdjective(unsigned int wlevel, AC1Legacy::PStringBase<char> *workmanship, int gem) .text:005B48E0 ?InqWorkmanshipAdjective@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@H@Z

        // AppraisalSystem.LockpickSuccessPercentToString:
        public static int LockpickSuccessPercentToString(int lr, AC1Legacy.PStringBase<char>* ps) => ((delegate* unmanaged[Cdecl]<int, AC1Legacy.PStringBase<char>*, int>)0x005B56B0)(lr, ps); // .text:005B4600 ; int __cdecl AppraisalSystem::LockpickSuccessPercentToString(const int lr, AC1Legacy::PStringBase<char> *ps) .text:005B4600 ?LockpickSuccessPercentToString@AppraisalSystem@@SAHJAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.SkillToString:
        public static int SkillToString(UInt32 stype, AC1Legacy.PStringBase<char>* ps) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, int>)0x005B5AE0)(stype, ps); // .text:005B4A30 ; int __cdecl AppraisalSystem::SkillToString(unsigned int stype, AC1Legacy::PStringBase<char> *ps) .text:005B4A30 ?SkillToString@AppraisalSystem@@SAHKAAV?$PStringBase@D@AC1Legacy@@@Z

        // AppraisalSystem.WeaponTimeToString:
        public static void WeaponTimeToString(int wtime, AC1Legacy.PStringBase<char>* ps) => ((delegate* unmanaged[Cdecl]<int, AC1Legacy.PStringBase<char>*, void>)0x005B5A20)(wtime, ps); // .text:005B4970 ; void __cdecl AppraisalSystem::WeaponTimeToString(const int wtime, AC1Legacy::PStringBase<char> *ps) .text:005B4970 ?WeaponTimeToString@AppraisalSystem@@SAXJAAV?$PStringBase@D@AC1Legacy@@@Z
    }

}
