using System;
using System.Runtime.InteropServices;

namespace AcClient {
    public unsafe struct VendorProfile {
        // Struct:
        public PackObj a0;
        public UInt32 item_types;
        public int min_value;
        public int max_value;
        public int magic;
        public Single buy_price;
        public Single sell_price;
        public UInt32 trade_id;
        public int trade_num;
        public AC1Legacy.PStringBase<char> trade_name;
        public override string ToString() => $"a0(PackObj):{a0}, item_types:{item_types:X8}, min_value(int):{min_value}, max_value(int):{max_value}, magic(int):{magic}, buy_price:{buy_price:n5}, sell_price:{sell_price:n5}, trade_id:{trade_id:X8}, trade_num(int):{trade_num}, trade_name:{trade_name}";

        // Functions:

        // VendorProfile.__Ctor:
        public void __Ctor() => ((delegate* unmanaged[Thiscall]<ref VendorProfile, void>)0x005D2BE0)(ref this); // .text:005D1BE0 ; void __thiscall VendorProfile::VendorProfile(VendorProfile *this) .text:005D1BE0 ??0VendorProfile@@QAE@XZ

        // VendorProfile.operator_equals:
        public VendorProfile* operator_equals() => ((delegate* unmanaged[Thiscall]<ref VendorProfile, VendorProfile*>)0x004C16E0)(ref this); // .text:004C0AF0 ; public: class VendorProfile & __thiscall VendorProfile::operator=(class VendorProfile const &) .text:004C0AF0 ??4VendorProfile@@QAEAAV0@ABV0@@Z

        // VendorProfile.GetPackSize:
        public UInt32 GetPackSize() => ((delegate* unmanaged[Thiscall]<ref VendorProfile, UInt32>)0x005D2C60)(ref this); // .text:005D1C60 ; unsigned int __thiscall VendorProfile::GetPackSize(VendorProfile *this) .text:005D1C60 ?GetPackSize@VendorProfile@@UAEIXZ

        // VendorProfile.InqAcceptability:
        public UInt32 InqAcceptability(PublicWeenieDesc* _item) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, PublicWeenieDesc*, UInt32>)0x005D2A90)(ref this, _item); // .text:005D1A90 ; unsigned int __thiscall VendorProfile::InqAcceptability(VendorProfile *this, PublicWeenieDesc *_item) .text:005D1A90 ?InqAcceptability@VendorProfile@@QAEKAAVPublicWeenieDesc@@@Z

        // VendorProfile.IsAcceptable:
        public int IsAcceptable(PublicWeenieDesc* _item) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, PublicWeenieDesc*, int>)0x005D2B50)(ref this, _item); // .text:005D1B50 ; int __thiscall VendorProfile::IsAcceptable(VendorProfile *this, PublicWeenieDesc *_item) .text:005D1B50 ?IsAcceptable@VendorProfile@@QAEHAAVPublicWeenieDesc@@@Z

        // VendorProfile.Pack:
        public UInt32 Pack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, void**, UInt32, UInt32>)0x005D2C80)(ref this, addr, size); // .text:005D1C80 ; unsigned int __thiscall VendorProfile::Pack(VendorProfile *this, void **addr, unsigned int size) .text:005D1C80 ?Pack@VendorProfile@@UAEIAAPAXI@Z

        // VendorProfile.UnPack:
        public int UnPack(void** addr, UInt32 size) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, void**, UInt32, int>)0x005D2D20)(ref this, addr, size); // .text:005D1D20 ; int __thiscall VendorProfile::UnPack(VendorProfile *this, void **addr, unsigned int size) .text:005D1D20 ?UnPack@VendorProfile@@UAEHAAPAXI@Z

        // VendorProfile.VendorBuyPrice:
        public int VendorBuyPrice(PublicWeenieDesc* _vendor, PublicWeenieDesc* _item) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, PublicWeenieDesc*, PublicWeenieDesc*, int>)0x005D2B70)(ref this, _vendor, _item); // .text:005D1B70 ; int __thiscall VendorProfile::VendorBuyPrice(VendorProfile *this, PublicWeenieDesc *_vendor, PublicWeenieDesc *_item) .text:005D1B70 ?VendorBuyPrice@VendorProfile@@QAEHAAVPublicWeenieDesc@@0@Z

        // VendorProfile.VendorSellPrice:
        public int VendorSellPrice(PublicWeenieDesc* _item, UInt32 _subAmount) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, PublicWeenieDesc*, UInt32, int>)0x005D2B00)(ref this, _item, _subAmount); // .text:005D1B00 ; int __thiscall VendorProfile::VendorSellPrice(VendorProfile *this, PublicWeenieDesc *_item, unsigned int _subAmount) .text:005D1B00 ?VendorSellPrice@VendorProfile@@QAEHAAVPublicWeenieDesc@@K@Z

        // VendorProfile.VendorTradeCurrency:
        public UInt32* VendorTradeCurrency(UInt32* result) => ((delegate* unmanaged[Thiscall]<ref VendorProfile, UInt32*, UInt32*>)0x005D2BD0)(ref this, result); // .text:005D1BD0 ; IDClass<_tagDataID,32,0> *__thiscall VendorProfile::VendorTradeCurrency(VendorProfile *this, IDClass<_tagDataID,32,0> *result) .text:005D1BD0 ?VendorTradeCurrency@VendorProfile@@QAE?AV?$IDClass@U_tagDataID@@$0CA@$0A@@@XZ
    }


    /// <summary>
    /// gmVendorUI* mine = (gmVendorUI*)GlobalEventHandler.geh->ResolveHandler(5100056);
    /// </summary>
    public unsafe struct gmVendorUI {
        // Struct:
        public UIElement_Field a0;
        public gmNoticeHandler a1;
        public QualityChangeHandler a2;
        public ObjectRangeHandler a3;
        public UIElement_Panel* m_vendorPanel;
        public UInt32 shopVendorID;
        public VendorProfile* shopVendorProfile;
        public PackableList<ItemProfile>* shopItemProfileList;
        public PackableList<ItemProfile> m_buyList;
        public PackableList<ItemProfile> m_sellList;
        public VendorItemsUI* m_itemsUI;
        public VendorBuyUI* m_buyUI;
        public VendorSellUI* m_sellUI;
        public int m_totalValue;
        public int m_last_sale;
        public override string ToString() => $"a0(UIElement_Field):{a0}, a1(gmNoticeHandler):{a1}, a2(QualityChangeHandler):{a2}, a3(ObjectRangeHandler):{a3}, m_vendorPanel:->(UIElement_Panel*)0x{(int)m_vendorPanel:X8}, shopVendorID:{shopVendorID:X8}, shopVendorProfile:->(VendorProfile*)0x{(int)shopVendorProfile:X8}, shopItemProfileList:->(PackableList<ItemProfile>*)0x{(int)shopItemProfileList:X8}, m_buyList(PackableList<ItemProfile>):{m_buyList}, m_sellList(PackableList<ItemProfile>):{m_sellList}, m_itemsUI:->(VendorItemsUI*)0x{(int)m_itemsUI:X8}, m_buyUI:->(VendorBuyUI*)0x{(int)m_buyUI:X8}, m_sellUI:->(VendorSellUI*)0x{(int)m_sellUI:X8}, m_totalValue(int):{m_totalValue}, m_last_sale(int):{m_last_sale}";

        // Functions:

        // gmVendorUI.__Ctor:
        public void __Ctor(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, LayoutDesc*, ElementDesc*, void>)0x004C3060)(ref this, _layout, _full_desc); // .text:004C2470 ; void __thiscall gmVendorUI::gmVendorUI(gmVendorUI *this, LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C2470 ??0gmVendorUI@@QAE@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmVendorUI.AddItem:
        public int AddItem(UIElement_ItemList* _uiItemList, UInt32 _itemID, int _position, int _removeDuplicates, int _addContents, int _excludeIfUnacceptable, int _broadcast, int _quantityDisp) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElement_ItemList*, UInt32, int, int, int, int, int, int, int>)0x004C20A0)(ref this, _uiItemList, _itemID, _position, _removeDuplicates, _addContents, _excludeIfUnacceptable, _broadcast, _quantityDisp); // .text:004C14B0 ; int __thiscall gmVendorUI::AddItem(gmVendorUI *this, UIElement_ItemList *_uiItemList, unsigned int _itemID, int _position, int _removeDuplicates, int _addContents, int _excludeIfUnacceptable, int _broadcast, int _quantityDisp) .text:004C14B0 ?AddItem@gmVendorUI@@QAEHPAVUIElement_ItemList@@KHHHHHJ@Z

        // gmVendorUI.AddMissingComp:
        public void AddMissingComp(UInt32 wcid, PStringBase<char>* strResult) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, PStringBase<char>*, void>)0x004C3A80)(ref this, wcid, strResult); // .text:004C2E90 ; void __thiscall gmVendorUI::AddMissingComp(gmVendorUI *this, IDClass<_tagDataID,32,0> wcid, PStringBase<char> *strResult) .text:004C2E90 ?AddMissingComp@gmVendorUI@@IAEXV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAV?$PStringBase@D@@@Z

        // gmVendorUI.AdoptAsContents:
        public void AdoptAsContents(UIElement_ItemList* _uiItemList, PackableList<ItemProfile>* _itemList, Byte _setStackSizeAsAmount) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElement_ItemList*, PackableList<ItemProfile>*, Byte, void>)0x004C38F0)(ref this, _uiItemList, _itemList, _setStackSizeAsAmount); // .text:004C2D00 ; void __thiscall gmVendorUI::AdoptAsContents(gmVendorUI *this, UIElement_ItemList *_uiItemList, PackableList<ItemProfile> *_itemList, const bool _setStackSizeAsAmount) .text:004C2D00 ?AdoptAsContents@gmVendorUI@@QAEXPAVUIElement_ItemList@@AAV?$PackableList@VItemProfile@@@@_N@Z

        // gmVendorUI.BuySingleItem:
        public Byte BuySingleItem(UInt32 _ID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, Byte>)0x004C3410)(ref this, _ID); // .text:004C2820 ; bool __thiscall gmVendorUI::BuySingleItem(gmVendorUI *this, unsigned int _ID) .text:004C2820 ?BuySingleItem@gmVendorUI@@IAE_NK@Z

        // gmVendorUI.CloseVendor:
        public void CloseVendor(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, Byte, void>)0x004C3C10)(ref this, _updating); // .text:004C3020 ; void __thiscall gmVendorUI::CloseVendor(gmVendorUI *this, bool _updating) .text:004C3020 ?CloseVendor@gmVendorUI@@IAEX_N@Z

        // gmVendorUI.CloseVendorDialogCallback:
        public static void CloseVendorDialogCallback(PropertyCollection* i_rcResults) => ((delegate* unmanaged[Cdecl]<PropertyCollection*, void>)0x004C3C70)(i_rcResults); // .text:004C3080 ; void __cdecl gmVendorUI::CloseVendorDialogCallback(PropertyCollection *i_rcResults) .text:004C3080 ?CloseVendorDialogCallback@gmVendorUI@@KAXABVPropertyCollection@@@Z

        // gmVendorUI.Create:
        public static UIElement* Create(LayoutDesc* _layout, ElementDesc* _full_desc) => ((delegate* unmanaged[Cdecl]<LayoutDesc*, ElementDesc*, UIElement*>)0x004C3290)(_layout, _full_desc); // .text:004C26A0 ; UIElement *__cdecl gmVendorUI::Create(LayoutDesc *_layout, ElementDesc *_full_desc) .text:004C26A0 ?Create@gmVendorUI@@SAPAVUIElement@@ABVLayoutDesc@@ABVElementDesc@@@Z

        // gmVendorUI.DeleteItem:
        public void DeleteItem(UIElement_ItemList* _uiItemList, UInt32 _itemID, int _broadcast) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElement_ItemList*, UInt32, int, void>)0x004C0FC0)(ref this, _uiItemList, _itemID, _broadcast); // .text:004C0340 ; void __thiscall gmVendorUI::DeleteItem(gmVendorUI *this, UIElement_ItemList *_uiItemList, unsigned int _itemID, int _broadcast) .text:004C0340 ?DeleteItem@gmVendorUI@@QAEXPAVUIElement_ItemList@@KH@Z

        // gmVendorUI.DynamicCast:
        public UIElement* DynamicCast(UInt32 i_eType) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, UIElement*>)0x004C3130)(ref this, i_eType); // .text:004C2540 ; UIElement *__thiscall gmVendorUI::DynamicCast(gmVendorUI *this, unsigned int i_eType) .text:004C2540 ?DynamicCast@gmVendorUI@@UAEPAVUIElement@@K@Z

        // gmVendorUI.FillComponentList:
        public void FillComponentList(SpellComponentCategory sp_cat, int max_to_spend) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, SpellComponentCategory, int, void>)0x004C5130)(ref this, sp_cat, max_to_spend); // .text:004C4540 ; void __thiscall gmVendorUI::FillComponentList(gmVendorUI *this, SpellComponentCategory sp_cat, int max_to_spend) .text:004C4540 ?FillComponentList@gmVendorUI@@IAEXW4SpellComponentCategory@@J@Z

        // gmVendorUI.FlushSellListSellState:
        public void FlushSellListSellState(PackableList<ItemProfile>* _list) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, PackableList<ItemProfile>*, void>)0x004C17C0)(ref this, _list); // .text:004C0BD0 ; void __thiscall gmVendorUI::FlushSellListSellState(gmVendorUI *this, PackableList<ItemProfile> *_list) .text:004C0BD0 ?FlushSellListSellState@gmVendorUI@@IAEXAAV?$PackableList@VItemProfile@@@@@Z

        // gmVendorUI.GetUIElementType:
        public UInt32 GetUIElementType() => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32>)0x004C3150)(ref this); // .text:004C2560 ; unsigned int __thiscall gmVendorUI::GetUIElementType(gmVendorUI *this) .text:004C2560 ?GetUIElementType@gmVendorUI@@UBEKXZ

        // gmVendorUI.HandleButtonClicks:
        public void HandleButtonClicks(UInt32 _elementID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, void>)0x004C5CC0)(ref this, _elementID); // .text:004C50D0 ; void __thiscall gmVendorUI::HandleButtonClicks(gmVendorUI *this, unsigned int _elementID) .text:004C50D0 ?HandleButtonClicks@gmVendorUI@@IAEXK@Z

        // gmVendorUI.HandleDropRelease:
        public void HandleDropRelease(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElementMessageInfo*, void>)0x004C6270)(ref this, i_rMsg); // .text:004C5680 ; void __thiscall gmVendorUI::HandleDropRelease(gmVendorUI *this, UIElementMessageInfo *i_rMsg) .text:004C5680 ?HandleDropRelease@gmVendorUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmVendorUI.HandleMousePresses:
        public void HandleMousePresses(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElementMessageInfo*, void>)0x004C4CC0)(ref this, i_rMsg); // .text:004C40D0 ; void __thiscall gmVendorUI::HandleMousePresses(gmVendorUI *this, UIElementMessageInfo *i_rMsg) .text:004C40D0 ?HandleMousePresses@gmVendorUI@@IAEXABUUIElementMessageInfo@@@Z

        // gmVendorUI.InqListSlotCount:
        public void InqListSlotCount(PackableList<ItemProfile>* _list, UInt32* _itemCount, UInt32* _containerCount) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, PackableList<ItemProfile>*, UInt32*, UInt32*, void>)0x004C1800)(ref this, _list, _itemCount, _containerCount); // .text:004C0C10 ; void __thiscall gmVendorUI::InqListSlotCount(gmVendorUI *this, PackableList<ItemProfile> *_list, unsigned int *_itemCount, unsigned int *_containerCount) .text:004C0C10 ?InqListSlotCount@gmVendorUI@@IAEXAAV?$PackableList@VItemProfile@@@@AAK1@Z

        // gmVendorUI.ListenToElementMessage:
        public UIElementMessageListenResult ListenToElementMessage(UIElementMessageInfo* i_rMsg) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElementMessageInfo*, UIElementMessageListenResult>)0x004C62F0)(ref this, i_rMsg); // .text:004C5700 ; UIElementMessageListenResult __thiscall gmVendorUI::ListenToElementMessage(gmVendorUI *this, UIElementMessageInfo *i_rMsg) .text:004C5700 ?ListenToElementMessage@gmVendorUI@@UAE?AW4UIElementMessageListenResult@@ABUUIElementMessageInfo@@@Z

        // gmVendorUI.ListenToGlobalMessage:
        public void ListenToGlobalMessage(UInt32 i_messageID, int i_data_int) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, int, void>)0x004C1100)(ref this, i_messageID, i_data_int); // .text:004C0480 ; void __thiscall gmVendorUI::ListenToGlobalMessage(gmVendorUI *this, unsigned int i_messageID, int i_data_int) .text:004C0480 ?ListenToGlobalMessage@gmVendorUI@@UAEXKJ@Z

        // gmVendorUI.OnObjectRangeExit:
        public void OnObjectRangeExit(UInt32 _objectID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, void>)0x004C0F70)(ref this, _objectID); // .text:004C02F0 ; void __thiscall gmVendorUI::OnObjectRangeExit(gmVendorUI *this, unsigned int _objectID) .text:004C02F0 ?OnObjectRangeExit@gmVendorUI@@MAEXK@Z

        // gmVendorUI.OnQualityChanged:
        public void OnQualityChanged(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, CWeenieObject*, StatType, UInt32, void>)0x004C56D0)(ref this, cwobj, stype, senum); // .text:004C4AE0 ; void __thiscall gmVendorUI::OnQualityChanged(gmVendorUI *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:004C4AE0 ?OnQualityChanged@gmVendorUI@@MAEXPAVCWeenieObject@@W4StatType@@K@Z

        // gmVendorUI.OnQualityRemoved:
        public void OnQualityRemoved(CWeenieObject* cwobj, StatType stype, UInt32 senum) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, CWeenieObject*, StatType, UInt32, void>)0x004C5750)(ref this, cwobj, stype, senum); // .text:004C4B60 ; void __thiscall gmVendorUI::OnQualityRemoved(gmVendorUI *this, CWeenieObject *cwobj, StatType stype, unsigned int senum) .text:004C4B60 ?OnQualityRemoved@gmVendorUI@@MAEXPAVCWeenieObject@@W4StatType@@K@Z

        // gmVendorUI.OnVisibilityChanged:
        public void OnVisibilityChanged(Byte i_bVisible) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, Byte, void>)0x004C4410)(ref this, i_bVisible); // .text:004C3820 ; void __thiscall gmVendorUI::OnVisibilityChanged(gmVendorUI *this, bool i_bVisible) .text:004C3820 ?OnVisibilityChanged@gmVendorUI@@MAEX_N@Z

        // gmVendorUI.OpenTab:
        public void OpenTab(UInt32 _tabID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, void>)0x004C1010)(ref this, _tabID); // .text:004C0390 ; void __thiscall gmVendorUI::OpenTab(gmVendorUI *this, unsigned int _tabID) .text:004C0390 ?OpenTab@gmVendorUI@@QAEXK@Z

        // gmVendorUI.OpenVendor:
        public void OpenVendor(UInt32 _vendorID, VendorProfile* _vendorProfile, PackableList<ItemProfile>* _itemProfileList, ShopMode _startMode) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, VendorProfile*, PackableList<ItemProfile>*, ShopMode, void>)0x004C5790)(ref this, _vendorID, _vendorProfile, _itemProfileList, _startMode); // .text:004C4BA0 ; void __thiscall gmVendorUI::OpenVendor(gmVendorUI *this, unsigned int _vendorID, VendorProfile *_vendorProfile, PackableList<ItemProfile> *_itemProfileList, ShopMode _startMode) .text:004C4BA0 ?OpenVendor@gmVendorUI@@IAEXKABVVendorProfile@@ABV?$PackableList@VItemProfile@@@@W4ShopMode@@@Z

        // gmVendorUI.PostInit:
        public void PostInit() => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, void>)0x004C1590)(ref this); // .text:004C09A0 ; void __thiscall gmVendorUI::PostInit(gmVendorUI *this) .text:004C09A0 ?PostInit@gmVendorUI@@UAEXXZ

        // gmVendorUI.RecordContents:
        public Byte RecordContents(UIElement_ItemList* _uiItemList, PackableList<ItemProfile>* _list, int _combineDuplicates, int _setAmountAsStackSize) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElement_ItemList*, PackableList<ItemProfile>*, int, int, Byte>)0x004C1F00)(ref this, _uiItemList, _list, _combineDuplicates, _setAmountAsStackSize); // .text:004C1310 ; bool __thiscall gmVendorUI::RecordContents(gmVendorUI *this, UIElement_ItemList *_uiItemList, PackableList<ItemProfile> *_list, int _combineDuplicates, const int _setAmountAsStackSize) .text:004C1310 ?RecordContents@gmVendorUI@@QAE_NPAVUIElement_ItemList@@AAV?$PackableList@VItemProfile@@@@HH@Z

        // gmVendorUI.RecvNotice_AddItemToSell:
        public void RecvNotice_AddItemToSell(UInt32 i_itemID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, void>)0x004C56B0)(ref this, i_itemID); // .text:004C4AC0 ; void __thiscall gmVendorUI::RecvNotice_AddItemToSell(gmVendorUI *this, unsigned int i_itemID) .text:004C4AC0 ?RecvNotice_AddItemToSell@gmVendorUI@@MAEXK@Z

        // gmVendorUI.RecvNotice_CloseVendor:
        public void RecvNotice_CloseVendor(Byte i_bUpdating) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, Byte, void>)0x004C0F40)(ref this, i_bUpdating); // .text:004C02C0 ; void __thiscall gmVendorUI::RecvNotice_CloseVendor(gmVendorUI *this, bool i_bUpdating) .text:004C02C0 ?RecvNotice_CloseVendor@gmVendorUI@@MAEX_N@Z

        // gmVendorUI.RecvNotice_FillComponentBuyList:
        public void RecvNotice_FillComponentBuyList(SpellComponentCategory i_sp_cat, int i_max_to_buy) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, SpellComponentCategory, int, void>)0x004C56C0)(ref this, i_sp_cat, i_max_to_buy); // .text:004C4AD0 ; void __thiscall gmVendorUI::RecvNotice_FillComponentBuyList(gmVendorUI *this, SpellComponentCategory i_sp_cat, int i_max_to_buy) .text:004C4AD0 ?RecvNotice_FillComponentBuyList@gmVendorUI@@MAEXW4SpellComponentCategory@@J@Z

        // gmVendorUI.RecvNotice_ItemAttributesChanged:
        public void RecvNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, UInt32, void>)0x004C50E0)(ref this, i_target, i_attrib); // .text:004C44F0 ; void __thiscall gmVendorUI::RecvNotice_ItemAttributesChanged(gmVendorUI *this, unsigned int i_target, unsigned int i_attrib) .text:004C44F0 ?RecvNotice_ItemAttributesChanged@gmVendorUI@@MAEXKK@Z

        // gmVendorUI.RecvNotice_ItemListBeginDrag:
        public void RecvNotice_ItemListBeginDrag(UIElement* i_itemList, int i_slotNum) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UIElement*, int, void>)0x004C4F70)(ref this, i_itemList, i_slotNum); // .text:004C4380 ; void __thiscall gmVendorUI::RecvNotice_ItemListBeginDrag(gmVendorUI *this, UIElement *i_itemList, int i_slotNum) .text:004C4380 ?RecvNotice_ItemListBeginDrag@gmVendorUI@@MAEXABVUIElement@@J@Z

        // gmVendorUI.RecvNotice_OpenVendor:
        public void RecvNotice_OpenVendor(UInt32 i_vendorID, VendorProfile* i_vendorProfile, PackableList<ItemProfile>* i_itemProfileList, ShopMode i_startMode) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, VendorProfile*, PackableList<ItemProfile>*, ShopMode, void>)0x004C62E0)(ref this, i_vendorID, i_vendorProfile, i_itemProfileList, i_startMode); // .text:004C56F0 ; void __thiscall gmVendorUI::RecvNotice_OpenVendor(gmVendorUI *this, unsigned int i_vendorID, VendorProfile *i_vendorProfile, PackableList<ItemProfile> *i_itemProfileList, ShopMode i_startMode) .text:004C56F0 ?RecvNotice_OpenVendor@gmVendorUI@@MAEXKABVVendorProfile@@ABV?$PackableList@VItemProfile@@@@W4ShopMode@@@Z

        // gmVendorUI.RecvNotice_ServerSaysMoveItem:
        public void RecvNotice_ServerSaysMoveItem(UInt32 _itemID, UInt32 _oldContainer, UInt32 _oldWielder, UInt32 _oldLocation, UInt32 _newContainer, int _place, UInt32 _newWielder, UInt32 _newLocation) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, void>)0x004C5090)(ref this, _itemID, _oldContainer, _oldWielder, _oldLocation, _newContainer, _place, _newWielder, _newLocation); // .text:004C44A0 ; void __thiscall gmVendorUI::RecvNotice_ServerSaysMoveItem(gmVendorUI *this, unsigned int _itemID, unsigned int _oldContainer, unsigned int _oldWielder, unsigned int _oldLocation, unsigned int _newContainer, int _place, unsigned int _newWielder, unsigned int _newLocation) .text:004C44A0 ?RecvNotice_ServerSaysMoveItem@gmVendorUI@@MAEXKKKKKHKK@Z

        // gmVendorUI.RecvNotice_SetSelectedItem:
        public void RecvNotice_SetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, UInt32, void>)0x004C0F00)(ref this, _oldSelectedID, _selectedID); // .text:004C0280 ; void __thiscall gmVendorUI::RecvNotice_SetSelectedItem(gmVendorUI *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004C0280 ?RecvNotice_SetSelectedItem@gmVendorUI@@MAEXKK@Z

        // gmVendorUI.RecvNotice_StackSliderChanged:
        public void RecvNotice_StackSliderChanged(UInt32 i_splitSize, UInt32 i_maxSplitSize) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, UInt32, void>)0x004C50F0)(ref this, i_splitSize, i_maxSplitSize); // .text:004C4500 ; void __thiscall gmVendorUI::RecvNotice_StackSliderChanged(gmVendorUI *this, unsigned int i_splitSize, unsigned int i_maxSplitSize) .text:004C4500 ?RecvNotice_StackSliderChanged@gmVendorUI@@MAEXKK@Z

        // gmVendorUI.Register:
        public static void Register() => ((delegate* unmanaged[Cdecl]<void>)0x004C3BF0)(); // .text:004C3000 ; void __cdecl gmVendorUI::Register() .text:004C3000 ?Register@gmVendorUI@@SAXXZ

        // gmVendorUI.RemoveProfileFromList:
        public Byte RemoveProfileFromList(PackableList<ItemProfile>* _list, UInt32 _id, int _amount) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, PackableList<ItemProfile>*, UInt32, int, Byte>)0x004C1E50)(ref this, _list, _id, _amount); // .text:004C1260 ; bool __thiscall gmVendorUI::RemoveProfileFromList(gmVendorUI *this, PackableList<ItemProfile> *_list, unsigned int _id, int _amount) .text:004C1260 ?RemoveProfileFromList@gmVendorUI@@QAE_NAAV?$PackableList@VItemProfile@@@@KJ@Z

        // gmVendorUI.ResetShopState:
        public void ResetShopState(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, Byte, void>)0x004C32C0)(ref this, _updating); // .text:004C26D0 ; void __thiscall gmVendorUI::ResetShopState(gmVendorUI *this, bool _updating) .text:004C26D0 ?ResetShopState@gmVendorUI@@IAEX_N@Z

        // gmVendorUI.SellSingleItem:
        public Byte SellSingleItem(UInt32 _ID) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, Byte>)0x004C3730)(ref this, _ID); // .text:004C2B40 ; bool __thiscall gmVendorUI::SellSingleItem(gmVendorUI *this, unsigned int _ID) .text:004C2B40 ?SellSingleItem@gmVendorUI@@IAE_NK@Z

        // gmVendorUI.SendShopEvent:
        public void SendShopEvent(UInt32 _vendorID, PackableList<ItemProfile>* _itemList, UInt32 _altCurrencyID, ShopEvent _event) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, PackableList<ItemProfile>*, UInt32, ShopEvent, void>)0x004C0EA0)(ref this, _vendorID, _itemList, _altCurrencyID, _event); // .text:004C0220 ; void __thiscall gmVendorUI::SendShopEvent(gmVendorUI *this, unsigned int _vendorID, PackableList<ItemProfile> *_itemList, IDClass<_tagDataID,32,0> _altCurrencyID, ShopEvent _event) .text:004C0220 ?SendShopEvent@gmVendorUI@@IAEXKAAV?$PackableList@VItemProfile@@@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@W4ShopEvent@@@Z

        // gmVendorUI.ShopHasItem:
        public Byte ShopHasItem(UInt32 wcidRequestedItem, int* amount_to_buy, UInt32* retval) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, int*, UInt32*, Byte>)0x004C1760)(ref this, wcidRequestedItem, amount_to_buy, retval); // .text:004C0B70 ; bool __thiscall gmVendorUI::ShopHasItem(gmVendorUI *this, IDClass<_tagDataID,32,0> wcidRequestedItem, int *amount_to_buy, unsigned int *retval) .text:004C0B70 ?ShopHasItem@gmVendorUI@@IAE_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@AAJAAK@Z

        // gmVendorUI.UpdateDragOver:
        public void UpdateDragOver() => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, void>)0x004C1030)(ref this); // .text:004C03B0 ; void __thiscall gmVendorUI::UpdateDragOver(gmVendorUI *this) .text:004C03B0 ?UpdateDragOver@gmVendorUI@@IAEXXZ

        // gmVendorUI.UpdateTotalValue:
        public void UpdateTotalValue() => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, void>)0x004C54D0)(ref this); // .text:004C48E0 ; void __thiscall gmVendorUI::UpdateTotalValue(gmVendorUI *this) .text:004C48E0 ?UpdateTotalValue@gmVendorUI@@QAEXXZ

        // gmVendorUI.VendorItemSetSellState:
        public void VendorItemSetSellState(UInt32 _itemID, int _state) => ((delegate* unmanaged[Thiscall]<ref gmVendorUI, UInt32, int, void>)0x004C0FA0)(ref this, _itemID, _state); // .text:004C0320 ; void __thiscall gmVendorUI::VendorItemSetSellState(gmVendorUI *this, unsigned int _itemID, int _state) .text:004C0320 ?VendorItemSetSellState@gmVendorUI@@IAEXKH@Z

        // Globals:
        public static UInt32* m_curDialogContext = (UInt32*)0x00840534; // .data:0083F524 ; unsigned int gmVendorUI::m_curDialogContext .data:0083F524 ?m_curDialogContext@gmVendorUI@@1KA
    }

    public unsafe struct VendorSubUI {
        // Struct:
        public VendorSubUI.Vtbl* vfptr;
        public gmVendorUI* m_parent;
        public override string ToString() => $"vfptr:->(VendorSubUI.Vtbl*)0x{(int)vfptr:X8}, m_parent:->(gmVendorUI*)0x{(int)m_parent:X8}";
        public unsafe struct Vtbl {
            public static delegate* unmanaged[Thiscall]<VendorSubUI*, Byte, void> OpenVendor; // void (__thiscall *OpenVendor)(VendorSubUI *this, bool);
            public static delegate* unmanaged[Thiscall]<VendorSubUI*, void> CloseVendor; // void (__thiscall *CloseVendor)(VendorSubUI *this);
            public static delegate* unmanaged[Thiscall]<VendorSubUI*, UInt32, UInt32, void> HandleSetSelectedItem; // void (__thiscall *HandleSetSelectedItem)(VendorSubUI *this, unsigned int, unsigned int);
        }

        // Functions:

        // VendorSubUI.GetShopVendorID:
        public UInt32 GetShopVendorID() => ((delegate* unmanaged[Thiscall]<ref VendorSubUI, UInt32>)0x004C0E90)(ref this); // .text:004C0210 ; unsigned int __thiscall VendorSubUI::GetShopVendorID(VendorSubUI *this) .text:004C0210 ?GetShopVendorID@VendorSubUI@@IAEKXZ

        // VendorSubUI.SetObjectStackSize:
        public void SetObjectStackSize(ACCWeenieObject* _weenObj, int _stackSize) => ((delegate* unmanaged[Thiscall]<ref VendorSubUI, ACCWeenieObject*, int, void>)0x004C1110)(ref this, _weenObj, _stackSize); // .text:004C0490 ; void __thiscall VendorSubUI::SetObjectStackSize(VendorSubUI *this, ACCWeenieObject *_weenObj, int _stackSize) .text:004C0490 ?SetObjectStackSize@VendorSubUI@@IAEXPAVACCWeenieObject@@J@Z
    }

    public unsafe struct VendorItemsUI {
        // Struct:
        public VendorSubUI a0;
        public UIElement_ItemList* m_shopList;
        public UIElement_Menu* m_itemTypeMenu;
        public UIElement_Text* m_itemNameText;
        public UIElement_Text* m_itemCostText;
        public UIElement* m_buyButton;
        public UIElement* m_addButton;
        public int m_numTypeFilters;
        public override string ToString() => $"a0(VendorSubUI):{a0}, m_shopList:->(UIElement_ItemList*)0x{(int)m_shopList:X8}, m_itemTypeMenu:->(UIElement_Menu*)0x{(int)m_itemTypeMenu:X8}, m_itemNameText:->(UIElement_Text*)0x{(int)m_itemNameText:X8}, m_itemCostText:->(UIElement_Text*)0x{(int)m_itemCostText:X8}, m_buyButton:->(UIElement*)0x{(int)m_buyButton:X8}, m_addButton:->(UIElement*)0x{(int)m_addButton:X8}, m_numTypeFilters(int):{m_numTypeFilters}";

        // Functions:

        // VendorItemsUI.__Ctor:
        public void __Ctor(gmVendorUI* _parentElement) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, gmVendorUI*, void>)0x004C1150)(ref this, _parentElement); // .text:004C04D0 ; void __thiscall VendorItemsUI::VendorItemsUI(VendorItemsUI *this, gmVendorUI *_parentElement) .text:004C04D0 ??0VendorItemsUI@@QAE@PAVgmVendorUI@@@Z

        // VendorItemsUI.AddToBuyList:
        public void AddToBuyList(ACCWeenieObject* weenObj, int amountBuyingNow) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, ACCWeenieObject*, int, void>)0x004C49B0)(ref this, weenObj, amountBuyingNow); // .text:004C3DC0 ; void __thiscall VendorItemsUI::AddToBuyList(VendorItemsUI *this, ACCWeenieObject *weenObj, int amountBuyingNow) .text:004C3DC0 ?AddToBuyList@VendorItemsUI@@IAEXPAVACCWeenieObject@@J@Z

        // VendorItemsUI.AddTypeFilter:
        public void AddTypeFilter(StringInfo* _text, UInt32 _filter) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, StringInfo*, UInt32, void>)0x004C1240)(ref this, _text, _filter); // .text:004C05C0 ; void __thiscall VendorItemsUI::AddTypeFilter(VendorItemsUI *this, StringInfo *_text, unsigned int _filter) .text:004C05C0 ?AddTypeFilter@VendorItemsUI@@IAEXABVStringInfo@@K@Z

        // VendorItemsUI.CloseVendor:
        public void CloseVendor() => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, void>)0x004C1210)(ref this); // .text:004C0590 ; void __thiscall VendorItemsUI::CloseVendor(VendorItemsUI *this) .text:004C0590 ?CloseVendor@VendorItemsUI@@MAEXXZ

        // VendorItemsUI.HandleSetSelectedItem:
        public void HandleSetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, UInt32, UInt32, void>)0x004C55A0)(ref this, _oldSelectedID, _selectedID); // .text:004C49B0 ; void __thiscall VendorItemsUI::HandleSetSelectedItem(VendorItemsUI *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004C49B0 ?HandleSetSelectedItem@VendorItemsUI@@MAEXKK@Z

        // VendorItemsUI.ListContainsType:
        public Byte ListContainsType(PackableList<ItemProfile>* _list, int _types) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, PackableList<ItemProfile>*, int, Byte>)0x004C1980)(ref this, _list, _types); // .text:004C0D90 ; bool __thiscall VendorItemsUI::ListContainsType(VendorItemsUI *this, PackableList<ItemProfile> *_list, int _types) .text:004C0D90 ?ListContainsType@VendorItemsUI@@IAE_NPAV?$PackableList@VItemProfile@@@@H@Z

        // VendorItemsUI.OpenVendor:
        public void OpenVendor(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, Byte, void>)0x004C22C0)(ref this, _updating); // .text:004C16D0 ; void __thiscall VendorItemsUI::OpenVendor(VendorItemsUI *this, bool _updating) .text:004C16D0 ?OpenVendor@VendorItemsUI@@MAEX_N@Z

        // VendorItemsUI.RemoveFromShop:
        public void RemoveFromShop(ACCWeenieObject* _weenObj, int _amountBought) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, ACCWeenieObject*, int, void>)0x004C48D0)(ref this, _weenObj, _amountBought); // .text:004C3CE0 ; void __thiscall VendorItemsUI::RemoveFromShop(VendorItemsUI *this, ACCWeenieObject *_weenObj, int _amountBought) .text:004C3CE0 ?RemoveFromShop@VendorItemsUI@@IAEXPAVACCWeenieObject@@J@Z

        // VendorItemsUI.UpdateItemsList:
        public void UpdateItemsList(int item_type, Byte _selectFirst) => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, int, Byte, void>)0x004C2A90)(ref this, item_type, _selectFirst); // .text:004C1EA0 ; void __thiscall VendorItemsUI::UpdateItemsList(VendorItemsUI *this, int item_type, bool _selectFirst) .text:004C1EA0 ?UpdateItemsList@VendorItemsUI@@IAEXJ_N@Z

        // VendorItemsUI.UpdateItemsUI:
        public void UpdateItemsUI() => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, void>)0x004C44D0)(ref this); // .text:004C38E0 ; void __thiscall VendorItemsUI::UpdateItemsUI(VendorItemsUI *this) .text:004C38E0 ?UpdateItemsUI@VendorItemsUI@@IAEXXZ

        // VendorItemsUI.UpdateQuantityOverlay:
        public void UpdateQuantityOverlay() => ((delegate* unmanaged[Thiscall]<ref VendorItemsUI, void>)0x004C18B0)(ref this); // .text:004C0CC0 ; void __thiscall VendorItemsUI::UpdateQuantityOverlay(VendorItemsUI *this) .text:004C0CC0 ?UpdateQuantityOverlay@VendorItemsUI@@IAEXXZ
    }
    public unsafe struct VendorBuyUI {
        // Struct:
        public VendorSubUI a0;
        public UIElement_ItemList* m_buyShopList;
        public UIElement_Text* m_buyListText;
        public UIElement_Text* m_buyPurseText;
        public UIElement* m_buyItemButton;
        public UIElement* m_buyAllButton;
        public UIElement* m_buyClearItemButton;
        public UIElement* m_buyClearListButton;
        public int m_transactionValue;
        public override string ToString() => $"a0(VendorSubUI):{a0}, m_buyShopList:->(UIElement_ItemList*)0x{(int)m_buyShopList:X8}, m_buyListText:->(UIElement_Text*)0x{(int)m_buyListText:X8}, m_buyPurseText:->(UIElement_Text*)0x{(int)m_buyPurseText:X8}, m_buyItemButton:->(UIElement*)0x{(int)m_buyItemButton:X8}, m_buyAllButton:->(UIElement*)0x{(int)m_buyAllButton:X8}, m_buyClearItemButton:->(UIElement*)0x{(int)m_buyClearItemButton:X8}, m_buyClearListButton:->(UIElement*)0x{(int)m_buyClearListButton:X8}, m_transactionValue(int):{m_transactionValue}";

        // Functions:

        // VendorBuyUI.__Ctor:
        public void __Ctor(gmVendorUI* _parentElement) => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, gmVendorUI*, void>)0x004C1310)(ref this, _parentElement); // .text:004C0690 ; void __thiscall VendorBuyUI::VendorBuyUI(VendorBuyUI *this, gmVendorUI *_parentElement) .text:004C0690 ??0VendorBuyUI@@QAE@PAVgmVendorUI@@@Z

        // VendorBuyUI.CloseVendor:
        public void CloseVendor() => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, void>)0x004C10C0)(ref this); // .text:004C0440 ; void __thiscall VendorBuyUI::CloseVendor(VendorBuyUI *this) .text:004C0440 ?CloseVendor@VendorBuyUI@@MAEXXZ

        // VendorBuyUI.HandleSetSelectedItem:
        public void HandleSetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, UInt32, UInt32, void>)0x004C1A90)(ref this, _oldSelectedID, _selectedID); // .text:004C0EA0 ; void __thiscall VendorBuyUI::HandleSetSelectedItem(VendorBuyUI *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004C0EA0 ?HandleSetSelectedItem@VendorBuyUI@@MAEXKK@Z

        // VendorBuyUI.OpenVendor:
        public void OpenVendor(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, Byte, void>)0x004C55C0)(ref this, _updating); // .text:004C49D0 ; void __thiscall VendorBuyUI::OpenVendor(VendorBuyUI *this, bool _updating) .text:004C49D0 ?OpenVendor@VendorBuyUI@@MAEX_N@Z

        // VendorBuyUI.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, void>)0x004C4B60)(ref this); // .text:004C3F70 ; void __thiscall VendorBuyUI::Update(VendorBuyUI *this) .text:004C3F70 ?Update@VendorBuyUI@@IAEXXZ

        // VendorBuyUI.UpdateBuyUI:
        public void UpdateBuyUI() => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, void>)0x004C1A00)(ref this); // .text:004C0E10 ; void __thiscall VendorBuyUI::UpdateBuyUI(VendorBuyUI *this) .text:004C0E10 ?UpdateBuyUI@VendorBuyUI@@IAEXXZ

        // VendorBuyUI.UpdateTotalValue:
        public void UpdateTotalValue() => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, void>)0x004C3FC0)(ref this); // .text:004C33D0 ; void __thiscall VendorBuyUI::UpdateTotalValue(VendorBuyUI *this) .text:004C33D0 ?UpdateTotalValue@VendorBuyUI@@IAEXXZ

        // VendorBuyUI.UpdateTransactionValue:
        public void UpdateTransactionValue() => ((delegate* unmanaged[Thiscall]<ref VendorBuyUI, void>)0x004C3D40)(ref this); // .text:004C3150 ; void __thiscall VendorBuyUI::UpdateTransactionValue(VendorBuyUI *this) .text:004C3150 ?UpdateTransactionValue@VendorBuyUI@@IAEXXZ
    }
    public unsafe struct VendorSellUI {
        // Struct:
        public VendorSubUI a0;
        public ItemListDragHandler a1;
        public UIElement_ItemList* m_sellShopList;
        public UIElement_Text* m_sellListText;
        public UIElement_Text* m_sellPurseText;
        public UIElement* m_sellItemButton;
        public UIElement* m_sellAllButton;
        public UIElement* m_sellClearItemButton;
        public UIElement* m_sellClearListButton;
        public int m_transactionValue;
        public UIElement_UIItem* m_splitItem;
        public UInt32 m_splitItemClassID;
        public Int16 m_splitItemStackSize;
        public override string ToString() => $"a0(VendorSubUI):{a0}, a1(ItemListDragHandler):{a1}, m_sellShopList:->(UIElement_ItemList*)0x{(int)m_sellShopList:X8}, m_sellListText:->(UIElement_Text*)0x{(int)m_sellListText:X8}, m_sellPurseText:->(UIElement_Text*)0x{(int)m_sellPurseText:X8}, m_sellItemButton:->(UIElement*)0x{(int)m_sellItemButton:X8}, m_sellAllButton:->(UIElement*)0x{(int)m_sellAllButton:X8}, m_sellClearItemButton:->(UIElement*)0x{(int)m_sellClearItemButton:X8}, m_sellClearListButton:->(UIElement*)0x{(int)m_sellClearListButton:X8}, m_transactionValue(int):{m_transactionValue}, m_splitItem:->(UIElement_UIItem*)0x{(int)m_splitItem:X8}, m_splitItemClassID:{m_splitItemClassID:X8}, m_splitItemStackSize:{m_splitItemStackSize}";

        // Functions:

        // VendorSellUI.__Ctor:
        public void __Ctor(gmVendorUI* _parentElement) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, gmVendorUI*, void>)0x004C13D0)(ref this, _parentElement); // .text:004C0750 ; void __thiscall VendorSellUI::VendorSellUI(VendorSellUI *this, gmVendorUI *_parentElement) .text:004C0750 ??0VendorSellUI@@QAE@PAVgmVendorUI@@@Z

        // VendorSellUI.AcceptDragObject:
        public Byte AcceptDragObject(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UInt32, Byte>)0x004C5AF0)(ref this, _itemID); // .text:004C4F00 ; bool __thiscall VendorSellUI::AcceptDragObject(VendorSellUI *this, unsigned int _itemID) .text:004C4F00 ?AcceptDragObject@VendorSellUI@@IAE_NK@Z

        // VendorSellUI.AddItemToSell:
        public void AddItemToSell(UInt32 _itemID) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UInt32, void>)0x004C5610)(ref this, _itemID); // .text:004C4A20 ; void __thiscall VendorSellUI::AddItemToSell(VendorSellUI *this, unsigned int _itemID) .text:004C4A20 ?AddItemToSell@VendorSellUI@@IAEXK@Z

        // VendorSellUI.CloseVendor:
        public void CloseVendor() => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, void>)0x004C10D0)(ref this); // .text:004C0450 ; void __thiscall VendorSellUI::CloseVendor(VendorSellUI *this) .text:004C0450 ?CloseVendor@VendorSellUI@@MAEXXZ

        // VendorSellUI.DragItemAcceptable:
        public Byte DragItemAcceptable(UInt32 _itemID, Byte _silent) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UInt32, Byte, Byte>)0x004C2CB0)(ref this, _itemID, _silent); // .text:004C20C0 ; bool __thiscall VendorSellUI::DragItemAcceptable(VendorSellUI *this, unsigned int _itemID, bool _silent) .text:004C20C0 ?DragItemAcceptable@VendorSellUI@@IAE_NK_N@Z

        // VendorSellUI.HandleSetSelectedItem:
        public void HandleSetSelectedItem(UInt32 _oldSelectedID, UInt32 _selectedID) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UInt32, UInt32, void>)0x004C1B40)(ref this, _oldSelectedID, _selectedID); // .text:004C0F50 ; void __thiscall VendorSellUI::HandleSetSelectedItem(VendorSellUI *this, unsigned int _oldSelectedID, unsigned int _selectedID) .text:004C0F50 ?HandleSetSelectedItem@VendorSellUI@@MAEXKK@Z

        // VendorSellUI.ItemAttributesChanged:
        public void ItemAttributesChanged(UInt32 _itemID, int _flags) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UInt32, int, void>)0x004C4BC0)(ref this, _itemID, _flags); // .text:004C3FD0 ; void __thiscall VendorSellUI::ItemAttributesChanged(VendorSellUI *this, unsigned int _itemID, int _flags) .text:004C3FD0 ?ItemAttributesChanged@VendorSellUI@@IAEXKH@Z

        // VendorSellUI.OnItemListDragOver:
        public Byte OnItemListDragOver(UIElement_UIItem* _catchElement, UInt32 _dropItemID, UInt32 _dropSpellID, DropItemFlags _dropFlags) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, UIElement_UIItem*, UInt32, UInt32, DropItemFlags, Byte>)0x004C2EF0)(ref this, _catchElement, _dropItemID, _dropSpellID, _dropFlags); // .text:004C2300 ; bool __thiscall VendorSellUI::OnItemListDragOver(VendorSellUI *this, UIElement_UIItem *_catchElement, unsigned int _dropItemID, unsigned int _dropSpellID, DropItemFlags _dropFlags) .text:004C2300 ?OnItemListDragOver@VendorSellUI@@MAE_NPAVUIElement_UIItem@@KKW4DropItemFlags@@@Z

        // VendorSellUI.OpenVendor:
        public void OpenVendor(Byte _updating) => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, Byte, void>)0x004C3BA0)(ref this, _updating); // .text:004C2FB0 ; void __thiscall VendorSellUI::OpenVendor(VendorSellUI *this, bool _updating) .text:004C2FB0 ?OpenVendor@VendorSellUI@@MAEX_N@Z

        // VendorSellUI.Update:
        public void Update() => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, void>)0x004C4B90)(ref this); // .text:004C3FA0 ; void __thiscall VendorSellUI::Update(VendorSellUI *this) .text:004C3FA0 ?Update@VendorSellUI@@IAEXXZ

        // VendorSellUI.UpdateSellUI:
        public void UpdateSellUI() => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, void>)0x004C1AB0)(ref this); // .text:004C0EC0 ; void __thiscall VendorSellUI::UpdateSellUI(VendorSellUI *this) .text:004C0EC0 ?UpdateSellUI@VendorSellUI@@IAEXXZ

        // VendorSellUI.UpdateTotalValue:
        public void UpdateTotalValue() => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, void>)0x004C4340)(ref this); // .text:004C3750 ; void __thiscall VendorSellUI::UpdateTotalValue(VendorSellUI *this) .text:004C3750 ?UpdateTotalValue@VendorSellUI@@IAEXXZ

        // VendorSellUI.UpdateTransactionValue:
        public void UpdateTransactionValue() => ((delegate* unmanaged[Thiscall]<ref VendorSellUI, void>)0x004C41A0)(ref this); // .text:004C35B0 ; void __thiscall VendorSellUI::UpdateTransactionValue(VendorSellUI *this) .text:004C35B0 ?UpdateTransactionValue@VendorSellUI@@IAEXXZ
    }


    public unsafe struct ShopSystem {
        // Struct:

        // Functions:

        // ShopSystem.BuyPrice:
        public static int BuyPrice(int unit_value, ITEM_TYPE itype, Single buy_price, int num_item) => ((delegate* unmanaged[Cdecl]<int, ITEM_TYPE, Single, int, int>)0x006B7060)(unit_value, itype, buy_price, num_item); // .text:006B6120 ; int __cdecl ShopSystem::BuyPrice(int unit_value, ITEM_TYPE itype, float buy_price, int num_item) .text:006B6120 ?BuyPrice@ShopSystem@@SAJJW4ITEM_TYPE@@MJ@Z

        // ShopSystem.SellPrice:
        public static int SellPrice(int unit_value, ITEM_TYPE itype, Single sell_price, int num_item) => ((delegate* unmanaged[Cdecl]<int, ITEM_TYPE, Single, int, int>)0x006B70C0)(unit_value, itype, sell_price, num_item); // .text:006B6180 ; int __cdecl ShopSystem::SellPrice(int unit_value, ITEM_TYPE itype, float sell_price, int num_item) .text:006B6180 ?SellPrice@ShopSystem@@SAJJW4ITEM_TYPE@@MJ@Z
    }


}