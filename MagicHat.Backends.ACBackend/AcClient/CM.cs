//$! go run parse.go full CM_UI:ECM_UI:ECM_DDD:ECM_Item:ECM_Physics:ECM_Login:ECM_Character:CM_Character:CM_Magic:CM_Communication:CM_Social:CM_Fellowship:CM_Allegiance:CM_Train:CM_Advocate:CM_Item:CM_Game:CM_Writing:CM_Combat:CM_Vendor:CM_House:CM_Inventory:CM_Physics:CM_Trade:CM_Login:CM_Admin:CM_Qualities:CM_Misc:CM_Examine:CM_CharGen:CM_Movement >CM.cs
using System;
using System.Runtime.InteropServices;
//DispatchSB_: executes Smartbox actions (3d window)
// receives SmartBox *smartbox, NetBlob *blob
// returns Int32

//DispatchUI_: executes UI actions
// receives UIQueueManager *ui, void *buf, UInt32 size
// returns UInt32

//Event_:  blindly sends the described packet to the server
// receives (variable)
// returns bool

//SendNotice_: broadcasts notice to UI elements, in turn updating UI
// receives (variable)
// returns bool

namespace AcClient {
    //CM is a pretty good place to be.

    public unsafe struct CM_UI {

        // Functions:

        // CM_UI.SendNotice_FullMergingItem:
        public static Byte SendNotice_FullMergingItem(UInt32 i_oldObject, UInt32 i_mergeTo) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x0047A050)(i_oldObject, i_mergeTo); // .text:00479C50 ; bool __cdecl CM_UI::SendNotice_FullMergingItem(unsigned int i_oldObject, unsigned int i_mergeTo) .text:00479C50 ?SendNotice_FullMergingItem@CM_UI@@YA_NKK@Z

        // CM_UI.SendNotice_LoadUI:
        public static Byte SendNotice_LoadUI(PStringBase<char>* i_file_name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, Byte>)0x0047A110)(i_file_name); // .text:00479D10 ; bool __cdecl CM_UI::SendNotice_LoadUI(PStringBase<char> *i_file_name) .text:00479D10 ?SendNotice_LoadUI@CM_UI@@YA_NABV?$PStringBase@D@@@Z

        // CM_UI.SendNotice_OpenContainedContainer:
        public static Byte SendNotice_OpenContainedContainer(UInt32 i_containerID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x0047A1B0)(i_containerID); // .text:00479DB0 ; bool __cdecl CM_UI::SendNotice_OpenContainedContainer(unsigned int i_containerID) .text:00479DB0 ?SendNotice_OpenContainedContainer@CM_UI@@YA_NK@Z

        // CM_UI.SendNotice_SetChatWindowTitle:
        public static Byte SendNotice_SetChatWindowTitle(UInt32 i_idWindowToSet, StringInfo* i_siTitle) => ((delegate* unmanaged[Cdecl]<UInt32, StringInfo*, Byte>)0x0047A3A0)(i_idWindowToSet, i_siTitle); // .text:00479FA0 ; bool __cdecl CM_UI::SendNotice_SetChatWindowTitle(unsigned int i_idWindowToSet, StringInfo *i_siTitle) .text:00479FA0 ?SendNotice_SetChatWindowTitle@CM_UI@@YA_NKABVStringInfo@@@Z

        // CM_UI.SendNotice_SplitStack:
        public static Byte SendNotice_SplitStack(UInt32 i_i_iidItem) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x0047A500)(i_i_iidItem); // .text:0047A100 ; bool __cdecl CM_UI::SendNotice_SplitStack(unsigned int i_i_iidItem) .text:0047A100 ?SendNotice_SplitStack@CM_UI@@YA_NK@Z

        // CM_UI.SendNotice_UpdateRadarVisibility:
        public static Byte SendNotice_UpdateRadarVisibility(Byte i_bRadarVisible) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x0047A650)(i_bRadarVisible); // .text:0047A250 ; bool __cdecl CM_UI::SendNotice_UpdateRadarVisibility(bool i_bRadarVisible) .text:0047A250 ?SendNotice_UpdateRadarVisibility@CM_UI@@YA_N_N@Z

        // CM_UI.SendNotice_UserPreferenceChanged:
        public static Byte SendNotice_UserPreferenceChanged(PStringBase<char>* i_strPref) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, Byte>)0x0047A740)(i_strPref); // .text:0047A340 ; bool __cdecl CM_UI::SendNotice_UserPreferenceChanged(PStringBase<char> *i_strPref) .text:0047A340 ?SendNotice_UserPreferenceChanged@CM_UI@@YA_NABV?$PStringBase@D@@@Z

        // CM_UI.SendNotice_EndCharacterSession:
        public static Byte SendNotice_EndCharacterSession(int i_confirm) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x00479F40)(i_confirm); // .text:00479B40 ; bool __cdecl CM_UI::SendNotice_EndCharacterSession(int i_confirm) .text:00479B40 ?SendNotice_EndCharacterSession@CM_UI@@YA_NH@Z

        // CM_UI.SendNotice_PlayerDescReceived:
        public static Byte SendNotice_PlayerDescReceived(CACQualities* i_playerDesc, CPlayerModule* i_playerModule) => ((delegate* unmanaged[Cdecl]<CACQualities*, CPlayerModule*, Byte>)0x0047A200)(i_playerDesc, i_playerModule); // .text:00479E00 ; bool __cdecl CM_UI::SendNotice_PlayerDescReceived(CACQualities *i_playerDesc, CPlayerModule *i_playerModule) .text:00479E00 ?SendNotice_PlayerDescReceived@CM_UI@@YA_NABVCACQualities@@ABVCPlayerModule@@@Z

        // CM_UI.SendNotice_EnableChatTargetSelection:
        public static Byte SendNotice_EnableChatTargetSelection(UInt32 i_eTalkFocus, Byte i_bEnabled) => ((delegate* unmanaged[Cdecl]<UInt32, Byte, Byte>)0x00479EE0)(i_eTalkFocus, i_bEnabled); // .text:00479AE0 ; bool __cdecl CM_UI::SendNotice_EnableChatTargetSelection(unsigned int i_eTalkFocus, bool i_bEnabled) .text:00479AE0 ?SendNotice_EnableChatTargetSelection@CM_UI@@YA_NK_N@Z

        // CM_UI.SendNotice_NewParentContainer:
        public static Byte SendNotice_NewParentContainer(UInt32 i_i_newContainerID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x0047A160)(i_i_newContainerID); // .text:00479D60 ; bool __cdecl CM_UI::SendNotice_NewParentContainer(unsigned int i_i_newContainerID) .text:00479D60 ?SendNotice_NewParentContainer@CM_UI@@YA_NK@Z

        // CM_UI.SendNotice_SetDisplayInventory:
        public static Byte SendNotice_SetDisplayInventory(int i_display) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x0047A400)(i_display); // .text:0047A000 ; bool __cdecl CM_UI::SendNotice_SetDisplayInventory(int i_display) .text:0047A000 ?SendNotice_SetDisplayInventory@CM_UI@@YA_NH@Z

        // CM_UI.SendNotice_StackSliderChanged:
        public static Byte SendNotice_StackSliderChanged(UInt32 i_splitSize, UInt32 i_maxSplitSize) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x0047A550)(i_splitSize, i_maxSplitSize); // .text:0047A150 ; bool __cdecl CM_UI::SendNotice_StackSliderChanged(unsigned int i_splitSize, unsigned int i_maxSplitSize) .text:0047A150 ?SendNotice_StackSliderChanged@CM_UI@@YA_NKK@Z

        // CM_UI.SendNotice_PlayerOptionChanged:
        public static Byte SendNotice_PlayerOptionChanged(PlayerOption i_eOption) => ((delegate* unmanaged[Cdecl]<PlayerOption, Byte>)0x0047A260)(i_eOption); // .text:00479E60 ; bool __cdecl CM_UI::SendNotice_PlayerOptionChanged(PlayerOption i_eOption) .text:00479E60 ?SendNotice_PlayerOptionChanged@CM_UI@@YA_NW4PlayerOption@@@Z

        // CM_UI.SendNotice_UpdateToolbarSelectionDisplay:
        public static Byte SendNotice_UpdateToolbarSelectionDisplay() => ((delegate* unmanaged[Cdecl]<Byte>)0x0047A6F0)(); // .text:0047A2F0 ; bool __cdecl CM_UI::SendNotice_UpdateToolbarSelectionDisplay() .text:0047A2F0 ?SendNotice_UpdateToolbarSelectionDisplay@CM_UI@@YA_NXZ

        // CM_UI.SendNotice_StartTell:
        public static Byte SendNotice_StartTell(PStringBase<UInt16>* i_strName) => ((delegate* unmanaged[Cdecl]<PStringBase<UInt16>*, Byte>)0x0047A5B0)(i_strName); // .text:0047A1B0 ; bool __cdecl CM_UI::SendNotice_StartTell(PStringBase<unsigned short> *i_strName) .text:0047A1B0 ?SendNotice_StartTell@CM_UI@@YA_NABV?$PStringBase@G@@@Z

        // CM_UI.SendNotice_SaveUI:
        public static Byte SendNotice_SaveUI(PStringBase<char>* i_file_name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, Byte>)0x0047A300)(i_file_name); // .text:00479F00 ; bool __cdecl CM_UI::SendNotice_SaveUI(PStringBase<char> *i_file_name) .text:00479F00 ?SendNotice_SaveUI@CM_UI@@YA_NABV?$PStringBase@D@@@Z

        // CM_UI.SendNotice_SelectionChanged:
        public static Byte SendNotice_SelectionChanged() => ((delegate* unmanaged[Cdecl]<Byte>)0x0047A350)(); // .text:00479F50 ; bool __cdecl CM_UI::SendNotice_SelectionChanged() .text:00479F50 ?SendNotice_SelectionChanged@CM_UI@@YA_NXZ

        // CM_UI.SendNotice_ToggleChatEntry:
        public static Byte SendNotice_ToggleChatEntry(Byte i_bActive) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x0047A600)(i_bActive); // .text:0047A200 ; bool __cdecl CM_UI::SendNotice_ToggleChatEntry(bool i_bActive) .text:0047A200 ?SendNotice_ToggleChatEntry@CM_UI@@YA_N_N@Z

        // CM_UI.SendNotice_ClearChatBuffer:
        public static Byte SendNotice_ClearChatBuffer(UInt32 i_idWindowToClear) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x00479E90)(i_idWindowToClear); // .text:00479A90 ; bool __cdecl CM_UI::SendNotice_ClearChatBuffer(unsigned int i_idWindowToClear) .text:00479A90 ?SendNotice_ClearChatBuffer@CM_UI@@YA_NK@Z

        // CM_UI.SendNotice_FillComponentBuyList:
        public static Byte SendNotice_FillComponentBuyList(SpellComponentCategory i_sp_cat, int i_max_to_buy) => ((delegate* unmanaged[Cdecl]<SpellComponentCategory, int, Byte>)0x00479F90)(i_sp_cat, i_max_to_buy); // .text:00479B90 ; bool __cdecl CM_UI::SendNotice_FillComponentBuyList(SpellComponentCategory i_sp_cat, int i_max_to_buy) .text:00479B90 ?SendNotice_FillComponentBuyList@CM_UI@@YA_NW4SpellComponentCategory@@J@Z

        // CM_UI.SendNotice_FontSettingsChanged:
        public static Byte SendNotice_FontSettingsChanged(UInt32 i_nFontFace, UInt32 i_nFontSize) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00479FF0)(i_nFontFace, i_nFontSize); // .text:00479BF0 ; bool __cdecl CM_UI::SendNotice_FontSettingsChanged(unsigned int i_nFontFace, unsigned int i_nFontSize) .text:00479BF0 ?SendNotice_FontSettingsChanged@CM_UI@@YA_NKK@Z

        // CM_UI.SendNotice_GameplayOptionChanged:
        public static Byte SendNotice_GameplayOptionChanged(BaseProperty* i_prop, UInt32 i_i_nUserData) => ((delegate* unmanaged[Cdecl]<BaseProperty*, UInt32, Byte>)0x0047A0B0)(i_prop, i_i_nUserData); // .text:00479CB0 ; bool __cdecl CM_UI::SendNotice_GameplayOptionChanged(BaseProperty *i_prop, unsigned int i_i_nUserData) .text:00479CB0 ?SendNotice_GameplayOptionChanged@CM_UI@@YA_NABVBaseProperty@@K@Z

        // CM_UI.SendNotice_RefreshOptionsPanel:
        public static Byte SendNotice_RefreshOptionsPanel() => ((delegate* unmanaged[Cdecl]<Byte>)0x0047A2B0)(); // .text:00479EB0 ; bool __cdecl CM_UI::SendNotice_RefreshOptionsPanel() .text:00479EB0 ?SendNotice_RefreshOptionsPanel@CM_UI@@YA_NXZ

        // CM_UI.SendNotice_SetFramerateDisplay:
        public static Byte SendNotice_SetFramerateDisplay(Byte i_bVisible) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x0047A450)(i_bVisible); // .text:0047A050 ; bool __cdecl CM_UI::SendNotice_SetFramerateDisplay(bool i_bVisible) .text:0047A050 ?SendNotice_SetFramerateDisplay@CM_UI@@YA_N_N@Z

        // CM_UI.SendNotice_SetPanelVisibility:
        public static Byte SendNotice_SetPanelVisibility(UInt32 i_ePanelID, Byte i_bVisible) => ((delegate* unmanaged[Cdecl]<UInt32, Byte, Byte>)0x0047A4A0)(i_ePanelID, i_bVisible); // .text:0047A0A0 ; bool __cdecl CM_UI::SendNotice_SetPanelVisibility(unsigned int i_ePanelID, bool i_bVisible) .text:0047A0A0 ?SendNotice_SetPanelVisibility@CM_UI@@YA_NK_N@Z

        // CM_UI.SendNotice_UpdateSquelchPanel:
        // public static Byte SendNotice_UpdateSquelchPanel() => ((delegate* unmanaged[Cdecl]<Byte>)0xDEADBEEF)(); // .text:0047A2A0 ; bool __cdecl CM_UI::SendNotice_UpdateSquelchPanel() .text:0047A2A0 ?SendNotice_UpdateSquelchPanel@CM_UI@@YA_NXZ

        // CM_UI.SendNotice_UserPreferenceChanged_Menu:
        public static Byte SendNotice_UserPreferenceChanged_Menu(PStringBase<char>* i_strPref, UInt32 i_oldValue, UInt32 i_newValue) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, UInt32, UInt32, Byte>)0x0047A790)(i_strPref, i_oldValue, i_newValue); // .text:0047A390 ; bool __cdecl CM_UI::SendNotice_UserPreferenceChanged_Menu(PStringBase<char> *i_strPref, unsigned int i_oldValue, unsigned int i_newValue) .text:0047A390 ?SendNotice_UserPreferenceChanged_Menu@CM_UI@@YA_NABV?$PStringBase@D@@KK@Z
    }
    public unsafe struct ECM_UI {

        // Functions:

        // ECM_UI.SendNotice_DisplayWeenieError:
        public static Byte SendNotice_DisplayWeenieError(UInt32 i_etype, AC1Legacy.PStringBase<char>* i_user_data) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x00693550)(i_etype, i_user_data); // .text:00692600 ; bool __cdecl ECM_UI::SendNotice_DisplayWeenieError(unsigned int i_etype, AC1Legacy::PStringBase<char> *i_user_data) .text:00692600 ?SendNotice_DisplayWeenieError@ECM_UI@@YA_NKABV?$PStringBase@D@AC1Legacy@@@Z

        // ECM_UI.SendNotice_TextTag_IIDClick:
        public static Byte SendNotice_TextTag_IIDClick(UInt32 i_eType, UInt32 i_iid) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00693670)(i_eType, i_iid); // .text:00692720 ; bool __cdecl ECM_UI::SendNotice_TextTag_IIDClick(unsigned int i_eType, unsigned int i_iid) .text:00692720 ?SendNotice_TextTag_IIDClick@ECM_UI@@YA_NKK@Z

        // ECM_UI.SendNotice_TextTag_IIDEnumClick:
        public static Byte SendNotice_TextTag_IIDEnumClick(UInt32 i_eType, UInt32 i_iid, UInt32 i_eValue) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, Byte>)0x006936C0)(i_eType, i_iid, i_eValue); // .text:00692770 ; bool __cdecl ECM_UI::SendNotice_TextTag_IIDEnumClick(unsigned int i_eType, unsigned int i_iid, unsigned int i_eValue) .text:00692770 ?SendNotice_TextTag_IIDEnumClick@ECM_UI@@YA_NKKK@Z

        // ECM_UI.SendNotice_TextTag_IIDStringClick:
        public static Byte SendNotice_TextTag_IIDStringClick(UInt32 i_eType, UInt32 i_iid, PStringBase<UInt16>* i_strValue) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, PStringBase<UInt16>*, Byte>)0x00693710)(i_eType, i_iid, i_strValue); // .text:006927C0 ; bool __cdecl ECM_UI::SendNotice_TextTag_IIDStringClick(unsigned int i_eType, unsigned int i_iid, PStringBase<unsigned short> *i_strValue) .text:006927C0 ?SendNotice_TextTag_IIDStringClick@ECM_UI@@YA_NKKABV?$PStringBase@G@@@Z

        // ECM_UI.SendNotice_UpdateGameView:
        public static Byte SendNotice_UpdateGameView(UInt32 i_x, UInt32 i_y, UInt32 i_width, UInt32 i_height) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, UInt32, Byte>)0x00693760)(i_x, i_y, i_width, i_height); // .text:00692810 ; bool __cdecl ECM_UI::SendNotice_UpdateGameView(unsigned int i_x, unsigned int i_y, unsigned int i_width, unsigned int i_height) .text:00692810 ?SendNotice_UpdateGameView@ECM_UI@@YA_NKKKK@Z

        // ECM_UI.SendNotice_CloseDialog:
        public static Byte SendNotice_CloseDialog(UInt32 i_context, PropertyCollection* i_data) => ((delegate* unmanaged[Cdecl]<UInt32, PropertyCollection*, Byte>)0x00693450)(i_context, i_data); // .text:00692500 ; bool __cdecl ECM_UI::SendNotice_CloseDialog(unsigned int i_context, PropertyCollection *i_data) .text:00692500 ?SendNotice_CloseDialog@ECM_UI@@YA_NKABVPropertyCollection@@@Z

        // ECM_UI.SendNotice_DisplayFinalStringInfo:
        public static Byte SendNotice_DisplayFinalStringInfo(UInt32 i_lt, StringInfo* i_siMessage, StringInfo* i_siPrefix, UInt32 i_idDestinationOverride) => ((delegate* unmanaged[Cdecl]<UInt32, StringInfo*, StringInfo*, UInt32, Byte>)0x006934A0)(i_lt, i_siMessage, i_siPrefix, i_idDestinationOverride); // .text:00692550 ; bool __cdecl ECM_UI::SendNotice_DisplayFinalStringInfo(unsigned int i_lt, StringInfo *i_siMessage, StringInfo *i_siPrefix, unsigned int i_idDestinationOverride) .text:00692550 ?SendNotice_DisplayFinalStringInfo@ECM_UI@@YA_NKABVStringInfo@@0K@Z

        // ECM_UI.SendNotice_DisplayStringInfo:
        public static Byte SendNotice_DisplayStringInfo(UInt32 i_lt, StringInfo* i_si) => ((delegate* unmanaged[Cdecl]<UInt32, StringInfo*, Byte>)0x00693500)(i_lt, i_si); // .text:006925B0 ; bool __cdecl ECM_UI::SendNotice_DisplayStringInfo(unsigned int i_lt, StringInfo *i_si) .text:006925B0 ?SendNotice_DisplayStringInfo@ECM_UI@@YA_NKABVStringInfo@@@Z

        // ECM_UI.SendNotice_OpenDialog:
        public static Byte SendNotice_OpenDialog(UInt32 i_context) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006935A0)(i_context); // .text:00692650 ; bool __cdecl ECM_UI::SendNotice_OpenDialog(unsigned int i_context) .text:00692650 ?SendNotice_OpenDialog@ECM_UI@@YA_NK@Z

        // ECM_UI.SendNotice_SmartBoxObjectFound:
        public static Byte SendNotice_SmartBoxObjectFound(UInt32 i_iidObject) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006935E0)(i_iidObject); // .text:00692690 ; bool __cdecl ECM_UI::SendNotice_SmartBoxObjectFound(unsigned int i_iidObject) .text:00692690 ?SendNotice_SmartBoxObjectFound@ECM_UI@@YA_NK@Z

        // ECM_UI.SendNotice_TextTag_DIDClick:
        public static Byte SendNotice_TextTag_DIDClick(UInt32 i_eType, UInt32 i_did) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00693620)(i_eType, i_did); // .text:006926D0 ; bool __cdecl ECM_UI::SendNotice_TextTag_DIDClick(unsigned int i_eType, IDClass<_tagDataID,32,0> i_did) .text:006926D0 ?SendNotice_TextTag_DIDClick@ECM_UI@@YA_NKV?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z
    }
    public unsafe struct ECM_DDD {

        // Functions:

        // ECM_DDD.SendNotice_RuntimeDDDStatus:
        public static Byte SendNotice_RuntimeDDDStatus(Byte i_fCurrentlyDownloading, UInt32 i_cItemsDownloaded, UInt32 i_cTotalItems) => ((delegate* unmanaged[Cdecl]<Byte, UInt32, UInt32, Byte>)0x006937C0)(i_fCurrentlyDownloading, i_cItemsDownloaded, i_cTotalItems); // .text:00692870 ; bool __cdecl ECM_DDD::SendNotice_RuntimeDDDStatus(bool i_fCurrentlyDownloading, unsigned int i_cItemsDownloaded, unsigned int i_cTotalItems) .text:00692870 ?SendNotice_RuntimeDDDStatus@ECM_DDD@@YA_N_NKK@Z
    }
    public unsafe struct ECM_Item {

        // Functions:

        // ECM_Item.SendNotice_ItemAttributesChanged:
        public static Byte SendNotice_ItemAttributesChanged(UInt32 i_target, UInt32 i_attrib) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00693810)(i_target, i_attrib); // .text:006928C0 ; bool __cdecl ECM_Item::SendNotice_ItemAttributesChanged(unsigned int i_target, unsigned int i_attrib) .text:006928C0 ?SendNotice_ItemAttributesChanged@ECM_Item@@YA_NKK@Z

        // ECM_Item.SendNotice_ServerSaysAttemptFailed:
        public static Byte SendNotice_ServerSaysAttemptFailed(UInt32 i_itemID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x00693860)(i_itemID); // .text:00692910 ; bool __cdecl ECM_Item::SendNotice_ServerSaysAttemptFailed(unsigned int i_itemID) .text:00692910 ?SendNotice_ServerSaysAttemptFailed@ECM_Item@@YA_NK@Z

        // ECM_Item.SendNotice_ServerSaysMoveItem:
        public static Byte SendNotice_ServerSaysMoveItem(UInt32 i_itemID, UInt32 i_oldContainer, UInt32 i_oldWielder, UInt32 i_oldLocation, UInt32 i_newContainer, int i_place, UInt32 i_newWielder, UInt32 i_newLocation) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, UInt32, UInt32, int, UInt32, UInt32, Byte>)0x006938A0)(i_itemID, i_oldContainer, i_oldWielder, i_oldLocation, i_newContainer, i_place, i_newWielder, i_newLocation); // .text:00692950 ; bool __cdecl ECM_Item::SendNotice_ServerSaysMoveItem(unsigned int i_itemID, unsigned int i_oldContainer, unsigned int i_oldWielder, unsigned int i_oldLocation, unsigned int i_newContainer, int i_place, unsigned int i_newWielder, unsigned int i_newLocation) .text:00692950 ?SendNotice_ServerSaysMoveItem@ECM_Item@@YA_NKKKKKHKK@Z

        // ECM_Item.SendNotice_SetSelectedItem:
        public static Byte SendNotice_SetSelectedItem(UInt32 i_oldSelectedID, UInt32 i_selectedID) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x00693910)(i_oldSelectedID, i_selectedID); // .text:006929C0 ; bool __cdecl ECM_Item::SendNotice_SetSelectedItem(unsigned int i_oldSelectedID, unsigned int i_selectedID) .text:006929C0 ?SendNotice_SetSelectedItem@ECM_Item@@YA_NKK@Z
    }
    public unsafe struct ECM_Physics {

        // Functions:

        // ECM_Physics.SendNotice_BeingDeleted:
        public static Byte SendNotice_BeingDeleted(CWeenieObject* obj) => ((delegate* unmanaged[Cdecl]<CWeenieObject*, Byte>)0x00693960)(obj); // .text:00692A10 ; bool __cdecl ECM_Physics::SendNotice_BeingDeleted(CWeenieObject *obj) .text:00692A10 ?SendNotice_BeingDeleted@ECM_Physics@@YA_NAAVCWeenieObject@@@Z

        // ECM_Physics.SendNotice_CreateObject:
        public static Byte SendNotice_CreateObject(UInt32 i_iidObject) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006939A0)(i_iidObject); // .text:00692A50 ; bool __cdecl ECM_Physics::SendNotice_CreateObject(unsigned int i_iidObject) .text:00692A50 ?SendNotice_CreateObject@ECM_Physics@@YA_NK@Z
    }
    public unsafe struct ECM_Login {

        // Functions:

        // ECM_Login.SendNotice_WorldName:
        public static Byte SendNotice_WorldName(AC1Legacy.PStringBase<char>* i_strName) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x00693A60)(i_strName); // .text:00692B10 ; bool __cdecl ECM_Login::SendNotice_WorldName(AC1Legacy::PStringBase<char> *i_strName) .text:00692B10 ?SendNotice_WorldName@ECM_Login@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // ECM_Login.SendNotice_CharacterError:
        public static Byte SendNotice_CharacterError(CharError i_error) => ((delegate* unmanaged[Cdecl]<CharError, Byte>)0x006939E0)(i_error); // .text:00692A90 ; bool __cdecl ECM_Login::SendNotice_CharacterError(charError i_error) .text:00692A90 ?SendNotice_CharacterError@ECM_Login@@YA_NW4charError@@@Z

        // ECM_Login.SendNotice_ServerDied:
        public static Byte SendNotice_ServerDied() => ((delegate* unmanaged[Cdecl]<Byte>)0x00693A20)(); // .text:00692AD0 ; bool __cdecl ECM_Login::SendNotice_ServerDied() .text:00692AD0 ?SendNotice_ServerDied@ECM_Login@@YA_NXZ
    }
    public unsafe struct ECM_Character {

        // Functions:

        // ECM_Character.SendNotice_PlayerObjDescChanged:
        public static Byte SendNotice_PlayerObjDescChanged() => ((delegate* unmanaged[Cdecl]<Byte>)0x00693AE0)(); // .text:00692B90 ; bool __cdecl ECM_Character::SendNotice_PlayerObjDescChanged() .text:00692B90 ?SendNotice_PlayerObjDescChanged@ECM_Character@@YA_NXZ

        // ECM_Character.SendNotice_CharacterSet:
        public static Byte SendNotice_CharacterSet(CharacterSet* i_charSet) => ((delegate* unmanaged[Cdecl]<CharacterSet*, Byte>)0x00693AA0)(i_charSet); // .text:00692B50 ; bool __cdecl ECM_Character::SendNotice_CharacterSet(CharacterSet *i_charSet) .text:00692B50 ?SendNotice_CharacterSet@ECM_Character@@YA_NABVCharacterSet@@@Z
    }
    public unsafe struct CM_Character {

        // Functions:

        // CM_Character.Event_ClearPlayerConsentList:
        public static Byte Event_ClearPlayerConsentList() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A1FA0)(); // .text:006A1180 ; bool __cdecl CM_Character::Event_ClearPlayerConsentList() .text:006A1180 ?Event_ClearPlayerConsentList@CM_Character@@YA_NXZ

        // CM_Character.Event_LoginCompleteNotification:
        public static Byte Event_LoginCompleteNotification() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A22A0)(); // .text:006A1480 ; bool __cdecl CM_Character::Event_LoginCompleteNotification() .text:006A1480 ?Event_LoginCompleteNotification@CM_Character@@YA_NXZ

        // CM_Character.Event_QueryBirth:
        public static Byte Event_QueryBirth(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A2510)(i_target); // .text:006A16F0 ; bool __cdecl CM_Character::Event_QueryBirth(unsigned int i_target) .text:006A16F0 ?Event_QueryBirth@CM_Character@@YA_NK@Z

        // CM_Character.Event_TeleToLifestone:
        public static Byte Event_TeleToLifestone() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A29B0)(); // .text:006A1B90 ; bool __cdecl CM_Character::Event_TeleToLifestone() .text:006A1B90 ?Event_TeleToLifestone@CM_Character@@YA_NXZ

        // CM_Character.DispatchUI_StartBarber:
        public static UInt32 DispatchUI_StartBarber(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A2BF0)(ui, buf, size); // .text:006A1DD0 ; unsigned int __cdecl CM_Character::DispatchUI_StartBarber(UIQueueManager *ui, void *buf, unsigned int size) .text:006A1DD0 ?DispatchUI_StartBarber@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Character.Event_FinishBarber:
        public static Byte Event_FinishBarber(UInt32 i_base_palette, UInt32 i_head_object, UInt32 i_head_texture, UInt32 i_default_head_texture, UInt32 i_eyes_texture, UInt32 i_default_eyes_texture, UInt32 i_nose_texture, UInt32 i_default_nose_texture, UInt32 i_mouth_texture, UInt32 i_default_mouth_texture, UInt32 i_skin_palette, UInt32 i_hair_palette, UInt32 i_eyes_palette, UInt32 i_setup_id, int i_option1, int i_option2) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, int, int, Byte>)0x006A2CE0)(i_base_palette, i_head_object, i_head_texture, i_default_head_texture, i_eyes_texture, i_default_eyes_texture, i_nose_texture, i_default_nose_texture, i_mouth_texture, i_default_mouth_texture, i_skin_palette, i_hair_palette, i_eyes_palette, i_setup_id, i_option1, i_option2); // .text:006A1EC0 ; bool __cdecl CM_Character::Event_FinishBarber(IDClass<_tagDataID,32,0> i_base_palette, IDClass<_tagDataID,32,0> i_head_object, IDClass<_tagDataID,32,0> i_head_texture, IDClass<_tagDataID,32,0> i_default_head_texture, IDClass<_tagDataID,32,0> i_eyes_texture, IDClass<_tagDataID,32,0> i_default_eyes_texture, IDClass<_tagDataID,32,0> i_nose_texture, IDClass<_tagDataID,32,0> i_default_nose_texture, IDClass<_tagDataID,32,0> i_mouth_texture, IDClass<_tagDataID,32,0> i_default_mouth_texture, IDClass<_tagDataID,32,0> i_skin_palette, IDClass<_tagDataID,32,0> i_hair_palette, IDClass<_tagDataID,32,0> i_eyes_palette, IDClass<_tagDataID,32,0> i_setup_id, int i_option1, int i_option2) .text:006A1EC0 ?Event_FinishBarber@CM_Character@@YA_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@0000000000000JJ@Z

        // CM_Character.SendNotice_AlterAttribute_ConfirmationRequest:
        public static Byte SendNotice_AlterAttribute_ConfirmationRequest(AC1Legacy.PStringBase<char>* i_userData, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A3320)(i_userData, i_uiContextID); // .text:006A2500 ; bool __cdecl CM_Character::SendNotice_AlterAttribute_ConfirmationRequest(AC1Legacy::PStringBase<char> *i_userData, unsigned int i_uiContextID) .text:006A2500 ?SendNotice_AlterAttribute_ConfirmationRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Character.Event_AddShortCut:
        public static Byte Event_AddShortCut(CShortCutData* i_scData) => ((delegate* unmanaged[Cdecl]<CShortCutData*, Byte>)0x006A1CD0)(i_scData); // .text:006A0EB0 ; bool __cdecl CM_Character::Event_AddShortCut(CShortCutData *i_scData) .text:006A0EB0 ?Event_AddShortCut@CM_Character@@YA_NABVCShortCutData@@@Z

        // CM_Character.SendNotice_ReloadOptions:
        public static Byte SendNotice_ReloadOptions() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A3680)(); // .text:006A2860 ; bool __cdecl CM_Character::SendNotice_ReloadOptions() .text:006A2860 ?SendNotice_ReloadOptions@CM_Character@@YA_NXZ

        // CM_Character.Event_RemoveFromPlayerConsentList:
        public static Byte Event_RemoveFromPlayerConsentList(AC1Legacy.PStringBase<char>* i_targetName) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A3A30)(i_targetName); // .text:006A2C10 ; bool __cdecl CM_Character::Event_RemoveFromPlayerConsentList(AC1Legacy::PStringBase<char> *i_targetName) .text:006A2C10 ?Event_RemoveFromPlayerConsentList@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Character.SendNotice_Ping:
        public static Byte SendNotice_Ping() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A35E0)(); // .text:006A27C0 ; bool __cdecl CM_Character::SendNotice_Ping() .text:006A27C0 ?SendNotice_Ping@CM_Character@@YA_NXZ

        // CM_Character.Event_EnterPKLite:
        public static Byte Event_EnterPKLite() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2210)(); // .text:006A13F0 ; bool __cdecl CM_Character::Event_EnterPKLite() .text:006A13F0 ?Event_EnterPKLite@CM_Character@@YA_NXZ

        // CM_Character.Event_AddPlayerPermission:
        public static Byte Event_AddPlayerPermission(AC1Legacy.PStringBase<char>* i_targetName) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A3970)(i_targetName); // .text:006A2B50 ; bool __cdecl CM_Character::Event_AddPlayerPermission(AC1Legacy::PStringBase<char> *i_targetName) .text:006A2B50 ?Event_AddPlayerPermission@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Character.DispatchUI_QueryAgeResponse:
        public static UInt32 DispatchUI_QueryAgeResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3C60)(ui, buf, size); // .text:006A2E40 ; unsigned int __cdecl CM_Character::DispatchUI_QueryAgeResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2E40 ?DispatchUI_QueryAgeResponse@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Character.Event_DisplayPlayerConsentList:
        public static Byte Event_DisplayPlayerConsentList() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2180)(); // .text:006A1360 ; bool __cdecl CM_Character::Event_DisplayPlayerConsentList() .text:006A1360 ?Event_DisplayPlayerConsentList@CM_Character@@YA_NXZ

        // CM_Character.SendNotice_FinishPowerbar:
        public static Byte SendNotice_FinishPowerbar(PowerBarMode i_pbm) => ((delegate* unmanaged[Cdecl]<PowerBarMode, Byte>)0x006A3540)(i_pbm); // .text:006A2720 ; bool __cdecl CM_Character::SendNotice_FinishPowerbar(PowerBarMode i_pbm) .text:006A2720 ?SendNotice_FinishPowerbar@CM_Character@@YA_NW4PowerBarMode@@@Z

        // CM_Character.SendNotice_StartBarberNotice:
        public static Byte SendNotice_StartBarberNotice(UInt32 i_base_palette, UInt32 i_head_object, UInt32 i_head_texture, UInt32 i_default_head_texture, UInt32 i_eyes_texture, UInt32 i_default_eyes_texture, UInt32 i_nose_texture, UInt32 i_default_nose_texture, UInt32 i_mouth_texture, UInt32 i_default_mouth_texture, UInt32 i_skin_palette, UInt32 i_hair_palette, UInt32 i_eyes_palette, UInt32 i_setup_id, int i_option1, int i_option2) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, int, int, Byte>)0x006A3730)(i_base_palette, i_head_object, i_head_texture, i_default_head_texture, i_eyes_texture, i_default_eyes_texture, i_nose_texture, i_default_nose_texture, i_mouth_texture, i_default_mouth_texture, i_skin_palette, i_hair_palette, i_eyes_palette, i_setup_id, i_option1, i_option2); // .text:006A2910 ; bool __cdecl CM_Character::SendNotice_StartBarberNotice(IDClass<_tagDataID,32,0> i_base_palette, IDClass<_tagDataID,32,0> i_head_object, IDClass<_tagDataID,32,0> i_head_texture, IDClass<_tagDataID,32,0> i_default_head_texture, IDClass<_tagDataID,32,0> i_eyes_texture, IDClass<_tagDataID,32,0> i_default_eyes_texture, IDClass<_tagDataID,32,0> i_nose_texture, IDClass<_tagDataID,32,0> i_default_nose_texture, IDClass<_tagDataID,32,0> i_mouth_texture, IDClass<_tagDataID,32,0> i_default_mouth_texture, IDClass<_tagDataID,32,0> i_skin_palette, IDClass<_tagDataID,32,0> i_hair_palette, IDClass<_tagDataID,32,0> i_eyes_palette, IDClass<_tagDataID,32,0> i_setup_id, int i_option1, int i_option2) .text:006A2910 ?SendNotice_StartBarberNotice@CM_Character@@YA_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@0000000000000JJ@Z

        // CM_Character.Event_RemoveShortCut:
        public static Byte Event_RemoveShortCut(int i_index) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A25E0)(i_index); // .text:006A17C0 ; bool __cdecl CM_Character::Event_RemoveShortCut(int i_index) .text:006A17C0 ?Event_RemoveShortCut@CM_Character@@YA_NH@Z

        // CM_Character.Event_RequestPing:
        public static Byte Event_RequestPing() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A27C0)(); // .text:006A19A0 ; bool __cdecl CM_Character::Event_RequestPing() .text:006A19A0 ?Event_RequestPing@CM_Character@@YA_NXZ

        // CM_Character.SendNotice_AlterSkill_ConfirmationRequest:
        public static Byte SendNotice_AlterSkill_ConfirmationRequest(AC1Legacy.PStringBase<char>* i_userData, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A3380)(i_userData, i_uiContextID); // .text:006A2560 ; bool __cdecl CM_Character::SendNotice_AlterSkill_ConfirmationRequest(AC1Legacy::PStringBase<char> *i_userData, unsigned int i_uiContextID) .text:006A2560 ?SendNotice_AlterSkill_ConfirmationRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Character.SendNotice_CraftInteraction_ConfirmationRequest:
        public static Byte SendNotice_CraftInteraction_ConfirmationRequest(AC1Legacy.PStringBase<char>* i_userData, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A34E0)(i_userData, i_uiContextID); // .text:006A26C0 ; bool __cdecl CM_Character::SendNotice_CraftInteraction_ConfirmationRequest(AC1Legacy::PStringBase<char> *i_userData, unsigned int i_uiContextID) .text:006A26C0 ?SendNotice_CraftInteraction_ConfirmationRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Character.SendNotice_LoadChanged:
        public static Byte SendNotice_LoadChanged(Single i_fNewLoad) => ((delegate* unmanaged[Cdecl]<Single, Byte>)0x006A3590)(i_fNewLoad); // .text:006A2770 ; bool __cdecl CM_Character::SendNotice_LoadChanged(float i_fNewLoad) .text:006A2770 ?SendNotice_LoadChanged@CM_Character@@YA_NM@Z

        // CM_Character.Event_AbuseLogRequest:
        public static Byte Event_AbuseLogRequest(AC1Legacy.PStringBase<char>* i_target, int i_status, AC1Legacy.PStringBase<char>* i_complaint) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, int, AC1Legacy.PStringBase<char>*, Byte>)0x006A3850)(i_target, i_status, i_complaint); // .text:006A2A30 ; bool __cdecl CM_Character::Event_AbuseLogRequest(AC1Legacy::PStringBase<char> *i_target, int i_status, AC1Legacy::PStringBase<char> *i_complaint) .text:006A2A30 ?Event_AbuseLogRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@H0@Z

        // CM_Character.Event_AddSpellFavorite:
        public static Byte Event_AddSpellFavorite(UInt32 i_spid, int i_index, int i_list) => ((delegate* unmanaged[Cdecl]<UInt32, int, int, Byte>)0x006A1D90)(i_spid, i_index, i_list); // .text:006A0F70 ; bool __cdecl CM_Character::Event_AddSpellFavorite(unsigned int i_spid, int i_index, int i_list) .text:006A0F70 ?Event_AddSpellFavorite@CM_Character@@YA_NKJJ@Z

        // CM_Character.SendNotice_SetPowerbarLevel:
        public static Byte SendNotice_SetPowerbarLevel(PowerBarMode i_pbm, Single i_fLevel) => ((delegate* unmanaged[Cdecl]<PowerBarMode, Single, Byte>)0x006A36D0)(i_pbm, i_fLevel); // .text:006A28B0 ; bool __cdecl CM_Character::SendNotice_SetPowerbarLevel(PowerBarMode i_pbm, float i_fLevel) .text:006A28B0 ?SendNotice_SetPowerbarLevel@CM_Character@@YA_NW4PowerBarMode@@M@Z

        // CM_Character.Event_RemovePlayerPermission:
        public static Byte Event_RemovePlayerPermission(AC1Legacy.PStringBase<char>* i_targetName) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A3AF0)(i_targetName); // .text:006A2CD0 ; bool __cdecl CM_Character::Event_RemovePlayerPermission(AC1Legacy::PStringBase<char> *i_targetName) .text:006A2CD0 ?Event_RemovePlayerPermission@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Character.DispatchUI_ConfirmationRequest:
        public static UInt32 DispatchUI_ConfirmationRequest(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3BB0)(ui, buf, size); // .text:006A2D90 ; unsigned int __cdecl CM_Character::DispatchUI_ConfirmationRequest(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2D90 ?DispatchUI_ConfirmationRequest@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Character.SendNotice_Augmentation_ConfirmationRequest:
        public static Byte SendNotice_Augmentation_ConfirmationRequest(AC1Legacy.PStringBase<char>* i_userData, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A33E0)(i_userData, i_uiContextID); // .text:006A25C0 ; bool __cdecl CM_Character::SendNotice_Augmentation_ConfirmationRequest(AC1Legacy::PStringBase<char> *i_userData, unsigned int i_uiContextID) .text:006A25C0 ?SendNotice_Augmentation_ConfirmationRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Character.Event_ConfirmationResponse:
        public static Byte Event_ConfirmationResponse(int i_confirmType, UInt32 i_context, int i_bAccepted) => ((delegate* unmanaged[Cdecl]<int, UInt32, int, Byte>)0x006A2030)(i_confirmType, i_context, i_bAccepted); // .text:006A1210 ; bool __cdecl CM_Character::Event_ConfirmationResponse(int i_confirmType, unsigned int i_context, int i_bAccepted) .text:006A1210 ?Event_ConfirmationResponse@CM_Character@@YA_NJKH@Z

        // CM_Character.SendNotice_AbortConfirmationRequest:
        public static Byte SendNotice_AbortConfirmationRequest(int i_confirmationType, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<int, UInt32, Byte>)0x006A3280)(i_confirmationType, i_uiContextID); // .text:006A2460 ; bool __cdecl CM_Character::SendNotice_AbortConfirmationRequest(int i_confirmationType, unsigned int i_uiContextID) .text:006A2460 ?SendNotice_AbortConfirmationRequest@CM_Character@@YA_NJK@Z

        // CM_Character.DispatchUI_ReturnPing:
        public static UInt32 DispatchUI_ReturnPing(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A1CA0)(ui, buf, size); // .text:006A0E80 ; unsigned int __cdecl CM_Character::DispatchUI_ReturnPing(UIQueueManager *ui, void *buf, unsigned int size) .text:006A0E80 ?DispatchUI_ReturnPing@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Character.Event_CharacterOptionsEvent:
        public static Byte Event_CharacterOptionsEvent(PlayerModule* i_pMod) => ((delegate* unmanaged[Cdecl]<PlayerModule*, Byte>)0x006A1EE0)(i_pMod); // .text:006A10C0 ; bool __cdecl CM_Character::Event_CharacterOptionsEvent(PlayerModule *i_pMod) .text:006A10C0 ?Event_CharacterOptionsEvent@CM_Character@@YA_NABVPlayerModule@@@Z

        // CM_Character.Event_PlayerOptionChangedEvent:
        public static Byte Event_PlayerOptionChangedEvent(PlayerOption i_po, int i_value) => ((delegate* unmanaged[Cdecl]<PlayerOption, int, Byte>)0x006A2330)(i_po, i_value); // .text:006A1510 ; bool __cdecl CM_Character::Event_PlayerOptionChangedEvent(PlayerOption i_po, int i_value) .text:006A1510 ?Event_PlayerOptionChangedEvent@CM_Character@@YA_NW4PlayerOption@@H@Z

        // CM_Character.Event_QueryAge:
        public static Byte Event_QueryAge(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A2440)(i_target); // .text:006A1620 ; bool __cdecl CM_Character::Event_QueryAge(unsigned int i_target) .text:006A1620 ?Event_QueryAge@CM_Character@@YA_NK@Z

        // CM_Character.Event_RemoveSpellFavorite:
        public static Byte Event_RemoveSpellFavorite(UInt32 i_spid, int i_list) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006A26B0)(i_spid, i_list); // .text:006A1890 ; bool __cdecl CM_Character::Event_RemoveSpellFavorite(unsigned int i_spid, int i_list) .text:006A1890 ?Event_RemoveSpellFavorite@CM_Character@@YA_NKJ@Z

        // CM_Character.Event_SpellbookFilterEvent:
        public static Byte Event_SpellbookFilterEvent(UInt32 i_options) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A2850)(i_options); // .text:006A1A30 ; bool __cdecl CM_Character::Event_SpellbookFilterEvent(unsigned int i_options) .text:006A1A30 ?Event_SpellbookFilterEvent@CM_Character@@YA_NK@Z

        // CM_Character.Event_TeleToPKArena:
        public static Byte Event_TeleToPKArena() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2AD0)(); // .text:006A1CB0 ; bool __cdecl CM_Character::Event_TeleToPKArena() .text:006A1CB0 ?Event_TeleToPKArena@CM_Character@@YA_NXZ

        // CM_Character.Event_TeleToPKLArena:
        public static Byte Event_TeleToPKLArena() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2B60)(); // .text:006A1D40 ; bool __cdecl CM_Character::Event_TeleToPKLArena() .text:006A1D40 ?Event_TeleToPKLArena@CM_Character@@YA_NXZ

        // CM_Character.DispatchUI_EnterGame_ServerReady:
        public static UInt32 DispatchUI_EnterGame_ServerReady(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A1C70)(ui, buf, size); // .text:006A0E50 ; unsigned int __cdecl CM_Character::DispatchUI_EnterGame_ServerReady(UIQueueManager *ui, void *buf, unsigned int size) .text:006A0E50 ?DispatchUI_EnterGame_ServerReady@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Character.SendNotice_AbuseReportResponse:
        public static Byte SendNotice_AbuseReportResponse(UInt32 i_error) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A32D0)(i_error); // .text:006A24B0 ; bool __cdecl CM_Character::SendNotice_AbuseReportResponse(unsigned int i_error) .text:006A24B0 ?SendNotice_AbuseReportResponse@CM_Character@@YA_NK@Z

        // CM_Character.SendNotice_BeginPowerbar:
        public static Byte SendNotice_BeginPowerbar(PowerBarMode i_pbm) => ((delegate* unmanaged[Cdecl]<PowerBarMode, Byte>)0x006A3440)(i_pbm); // .text:006A2620 ; bool __cdecl CM_Character::SendNotice_BeginPowerbar(PowerBarMode i_pbm) .text:006A2620 ?SendNotice_BeginPowerbar@CM_Character@@YA_NW4PowerBarMode@@@Z

        // CM_Character.SendNotice_ChangeRadarLook:
        public static Byte SendNotice_ChangeRadarLook(CWeenieObject* obj) => ((delegate* unmanaged[Cdecl]<CWeenieObject*, Byte>)0x006A3490)(obj); // .text:006A2670 ; bool __cdecl CM_Character::SendNotice_ChangeRadarLook(CWeenieObject *obj) .text:006A2670 ?SendNotice_ChangeRadarLook@CM_Character@@YA_NAAVCWeenieObject@@@Z

        // CM_Character.SendNotice_YesNo_ConfirmationRequest:
        public static Byte SendNotice_YesNo_ConfirmationRequest(AC1Legacy.PStringBase<char>* i_userData, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A37F0)(i_userData, i_uiContextID); // .text:006A29D0 ; bool __cdecl CM_Character::SendNotice_YesNo_ConfirmationRequest(AC1Legacy::PStringBase<char> *i_userData, unsigned int i_uiContextID) .text:006A29D0 ?SendNotice_YesNo_ConfirmationRequest@CM_Character@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Character.Event_SetDesiredComponentLevel:
        public static Byte Event_SetDesiredComponentLevel(UInt32 i_wcid, int i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006A3170)(i_wcid, i_amount); // .text:006A2350 ; bool __cdecl CM_Character::Event_SetDesiredComponentLevel(IDClass<_tagDataID,32,0> i_wcid, int i_amount) .text:006A2350 ?Event_SetDesiredComponentLevel@CM_Character@@YA_NV?$IDClass@U_tagDataID@@$0CA@$0A@@@J@Z

        // CM_Character.Event_Suicide:
        public static Byte Event_Suicide() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2920)(); // .text:006A1B00 ; bool __cdecl CM_Character::Event_Suicide() .text:006A1B00 ?Event_Suicide@CM_Character@@YA_NXZ

        // CM_Character.Event_TeleToMarketplace:
        public static Byte Event_TeleToMarketplace() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A2A40)(); // .text:006A1C20 ; bool __cdecl CM_Character::Event_TeleToMarketplace() .text:006A1C20 ?Event_TeleToMarketplace@CM_Character@@YA_NXZ

        // CM_Character.SendNotice_RefreshActionKeyMapping:
        public static Byte SendNotice_RefreshActionKeyMapping(QualifiedControl* i_qcMapped) => ((delegate* unmanaged[Cdecl]<QualifiedControl*, Byte>)0x006A3630)(i_qcMapped); // .text:006A2810 ; bool __cdecl CM_Character::SendNotice_RefreshActionKeyMapping(QualifiedControl *i_qcMapped) .text:006A2810 ?SendNotice_RefreshActionKeyMapping@CM_Character@@YA_NABVQualifiedControl@@@Z

        // CM_Character.DispatchUI_ConfirmationDone:
        public static UInt32 DispatchUI_ConfirmationDone(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A1C40)(ui, buf, size); // .text:006A0E20 ; unsigned int __cdecl CM_Character::DispatchUI_ConfirmationDone(UIQueueManager *ui, void *buf, unsigned int size) .text:006A0E20 ?DispatchUI_ConfirmationDone@CM_Character@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Magic {

        // Functions:

        // CM_Magic.SendNotice_UpdateSpellComponents:
        public static Byte SendNotice_UpdateSpellComponents(int i_change) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A45F0)(i_change); // .text:006A37D0 ; bool __cdecl CM_Magic::SendNotice_UpdateSpellComponents(int i_change) .text:006A37D0 ?SendNotice_UpdateSpellComponents@CM_Magic@@YA_NJ@Z

        // CM_Magic.SendNotice_EnchantmentsChanged:
        public static Byte SendNotice_EnchantmentsChanged() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4280)(); // .text:006A3460 ; bool __cdecl CM_Magic::SendNotice_EnchantmentsChanged() .text:006A3460 ?SendNotice_EnchantmentsChanged@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_LastSpellSelection:
        public static Byte SendNotice_LastSpellSelection() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4370)(); // .text:006A3550 ; bool __cdecl CM_Magic::SendNotice_LastSpellSelection() .text:006A3550 ?SendNotice_LastSpellSelection@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_PrevSpellTab:
        public static Byte SendNotice_PrevSpellTab() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4500)(); // .text:006A36E0 ; bool __cdecl CM_Magic::SendNotice_PrevSpellTab() .text:006A36E0 ?SendNotice_PrevSpellTab@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_AddSpellShortcut:
        public static Byte SendNotice_AddSpellShortcut(UInt32 i_spellID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A4190)(i_spellID); // .text:006A3370 ; bool __cdecl CM_Magic::SendNotice_AddSpellShortcut(unsigned int i_spellID) .text:006A3370 ?SendNotice_AddSpellShortcut@CM_Magic@@YA_NK@Z

        // CM_Magic.Event_CastUntargetedSpell:
        public static Byte Event_CastUntargetedSpell(UInt32 i_spell_id) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A3F70)(i_spell_id); // .text:006A3150 ; bool __cdecl CM_Magic::Event_CastUntargetedSpell(unsigned int i_spell_id) .text:006A3150 ?Event_CastUntargetedSpell@CM_Magic@@YA_NK@Z

        // CM_Magic.DispatchUI_DispelEnchantment:
        public static UInt32 DispatchUI_DispelEnchantment(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3D40)(ui, buf, size); // .text:006A2F20 ; unsigned int __cdecl CM_Magic::DispatchUI_DispelEnchantment(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2F20 ?DispatchUI_DispelEnchantment@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.SendNotice_NextSpellTab:
        public static Byte SendNotice_NextSpellTab() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4460)(); // .text:006A3640 ; bool __cdecl CM_Magic::SendNotice_NextSpellTab() .text:006A3640 ?SendNotice_NextSpellTab@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_VitaeChanged:
        public static Byte SendNotice_VitaeChanged() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4640)(); // .text:006A3820 ; bool __cdecl CM_Magic::SendNotice_VitaeChanged() .text:006A3820 ?SendNotice_VitaeChanged@CM_Magic@@YA_NXZ

        // CM_Magic.DispatchUI_RemoveMultipleEnchantments:
        public static UInt32 DispatchUI_RemoveMultipleEnchantments(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A4720)(ui, buf, size); // .text:006A3900 ; unsigned int __cdecl CM_Magic::DispatchUI_RemoveMultipleEnchantments(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3900 ?DispatchUI_RemoveMultipleEnchantments@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.DispatchUI_RemoveSpell:
        public static UInt32 DispatchUI_RemoveSpell(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3E00)(ui, buf, size); // .text:006A2FE0 ; unsigned int __cdecl CM_Magic::DispatchUI_RemoveSpell(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2FE0 ?DispatchUI_RemoveSpell@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.Event_CastTargetedSpell:
        public static Byte Event_CastTargetedSpell(UInt32 i_target, UInt32 i_spell_id) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A3E60)(i_target, i_spell_id); // .text:006A3040 ; bool __cdecl CM_Magic::Event_CastTargetedSpell(unsigned int i_target, unsigned int i_spell_id) .text:006A3040 ?Event_CastTargetedSpell@CM_Magic@@YA_NKK@Z

        // CM_Magic.SendNotice_CastQuickslotSpell:
        public static Byte SendNotice_CastQuickslotSpell(int i_slot) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A4230)(i_slot); // .text:006A3410 ; bool __cdecl CM_Magic::SendNotice_CastQuickslotSpell(int i_slot) .text:006A3410 ?SendNotice_CastQuickslotSpell@CM_Magic@@YA_NJ@Z

        // CM_Magic.SendNotice_FirstSpellTab:
        public static Byte SendNotice_FirstSpellTab() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4320)(); // .text:006A3500 ; bool __cdecl CM_Magic::SendNotice_FirstSpellTab() .text:006A3500 ?SendNotice_FirstSpellTab@CM_Magic@@YA_NXZ

        // CM_Magic.DispatchUI_UpdateMultipleEnchantments:
        public static UInt32 DispatchUI_UpdateMultipleEnchantments(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A47B0)(ui, buf, size); // .text:006A3990 ; unsigned int __cdecl CM_Magic::DispatchUI_UpdateMultipleEnchantments(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3990 ?DispatchUI_UpdateMultipleEnchantments@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.DispatchUI_RemoveEnchantment:
        public static UInt32 DispatchUI_RemoveEnchantment(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3DD0)(ui, buf, size); // .text:006A2FB0 ; unsigned int __cdecl CM_Magic::DispatchUI_RemoveEnchantment(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2FB0 ?DispatchUI_RemoveEnchantment@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.SendNotice_CastCurrentSpell:
        public static Byte SendNotice_CastCurrentSpell() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A41E0)(); // .text:006A33C0 ; bool __cdecl CM_Magic::SendNotice_CastCurrentSpell() .text:006A33C0 ?SendNotice_CastCurrentSpell@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_FirstSpellSelection:
        public static Byte SendNotice_FirstSpellSelection() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A42D0)(); // .text:006A34B0 ; bool __cdecl CM_Magic::SendNotice_FirstSpellSelection() .text:006A34B0 ?SendNotice_FirstSpellSelection@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_LastSpellTab:
        public static Byte SendNotice_LastSpellTab() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A43C0)(); // .text:006A35A0 ; bool __cdecl CM_Magic::SendNotice_LastSpellTab() .text:006A35A0 ?SendNotice_LastSpellTab@CM_Magic@@YA_NXZ

        // CM_Magic.DispatchUI_DispelMultipleEnchantments:
        public static UInt32 DispatchUI_DispelMultipleEnchantments(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A4690)(ui, buf, size); // .text:006A3870 ; unsigned int __cdecl CM_Magic::DispatchUI_DispelMultipleEnchantments(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3870 ?DispatchUI_DispelMultipleEnchantments@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.DispatchUI_UpdateSpell:
        public static UInt32 DispatchUI_UpdateSpell(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3E30)(ui, buf, size); // .text:006A3010 ; unsigned int __cdecl CM_Magic::DispatchUI_UpdateSpell(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3010 ?DispatchUI_UpdateSpell@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.SendNotice_PrevSpellSelection:
        public static Byte SendNotice_PrevSpellSelection() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A44B0)(); // .text:006A3690 ; bool __cdecl CM_Magic::SendNotice_PrevSpellSelection() .text:006A3690 ?SendNotice_PrevSpellSelection@CM_Magic@@YA_NXZ

        // CM_Magic.SendNotice_SpellAdded:
        public static Byte SendNotice_SpellAdded(UInt32 i_eSpellID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A4550)(i_eSpellID); // .text:006A3730 ; bool __cdecl CM_Magic::SendNotice_SpellAdded(unsigned int i_eSpellID) .text:006A3730 ?SendNotice_SpellAdded@CM_Magic@@YA_NK@Z

        // CM_Magic.SendNotice_SpellRemoved:
        public static Byte SendNotice_SpellRemoved(UInt32 i_eSpellID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A45A0)(i_eSpellID); // .text:006A3780 ; bool __cdecl CM_Magic::SendNotice_SpellRemoved(unsigned int i_eSpellID) .text:006A3780 ?SendNotice_SpellRemoved@CM_Magic@@YA_NK@Z

        // CM_Magic.DispatchUI_PurgeBadEnchantments:
        public static UInt32 DispatchUI_PurgeBadEnchantments(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3D70)(ui, buf, size); // .text:006A2F50 ; unsigned int __cdecl CM_Magic::DispatchUI_PurgeBadEnchantments(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2F50 ?DispatchUI_PurgeBadEnchantments@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.Event_RemoveSpell:
        public static Byte Event_RemoveSpell(UInt32 i_spell_id) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A4040)(i_spell_id); // .text:006A3220 ; bool __cdecl CM_Magic::Event_RemoveSpell(unsigned int i_spell_id) .text:006A3220 ?Event_RemoveSpell@CM_Magic@@YA_NK@Z

        // CM_Magic.DispatchUI_UpdateEnchantment:
        public static UInt32 DispatchUI_UpdateEnchantment(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A4110)(ui, buf, size); // .text:006A32F0 ; unsigned int __cdecl CM_Magic::DispatchUI_UpdateEnchantment(UIQueueManager *ui, void *buf, unsigned int size) .text:006A32F0 ?DispatchUI_UpdateEnchantment@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Magic.SendNotice_NextSpellSelection:
        public static Byte SendNotice_NextSpellSelection() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A4410)(); // .text:006A35F0 ; bool __cdecl CM_Magic::SendNotice_NextSpellSelection() .text:006A35F0 ?SendNotice_NextSpellSelection@CM_Magic@@YA_NXZ

        // CM_Magic.DispatchUI_PurgeEnchantments:
        public static UInt32 DispatchUI_PurgeEnchantments(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A3DA0)(ui, buf, size); // .text:006A2F80 ; unsigned int __cdecl CM_Magic::DispatchUI_PurgeEnchantments(UIQueueManager *ui, void *buf, unsigned int size) .text:006A2F80 ?DispatchUI_PurgeEnchantments@CM_Magic@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Communication {

        // Functions:

        // CM_Communication.DispatchUI_SetSquelchDB:
        public static UInt32 DispatchUI_SetSquelchDB(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A4840)(ui, buf, size); // .text:006A3A20 ; unsigned int __cdecl CM_Communication::DispatchUI_SetSquelchDB(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3A20 ?DispatchUI_SetSquelchDB@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_WeenieErrorWithString:
        public static UInt32 DispatchUI_WeenieErrorWithString(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5FD0)(ui, buf, size); // .text:006A5070 ; unsigned int __cdecl CM_Communication::DispatchUI_WeenieErrorWithString(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5070 ?DispatchUI_WeenieErrorWithString@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_Talk:
        public static Byte Event_Talk(AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A53E0)(i_msg); // .text:006A45C0 ; bool __cdecl CM_Communication::Event_Talk(AC1Legacy::PStringBase<char> *i_msg) .text:006A45C0 ?Event_Talk@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.Event_TalkDirectByName:
        public static Byte Event_TalkDirectByName(AC1Legacy.PStringBase<char>* i_msg, AC1Legacy.PStringBase<char>* i_target_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, Byte>)0x006A55A0)(i_msg, i_target_name); // .text:006A4780 ; bool __cdecl CM_Communication::Event_TalkDirectByName(AC1Legacy::PStringBase<char> *i_msg, AC1Legacy::PStringBase<char> *i_target_name) .text:006A4780 ?Event_TalkDirectByName@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@0@Z

        // CM_Communication.DispatchUI_ChannelIndex:
        public static UInt32 DispatchUI_ChannelIndex(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6300)(ui, buf, size); // .text:006A53A0 ; unsigned int __cdecl CM_Communication::DispatchUI_ChannelIndex(UIQueueManager *ui, void *buf, unsigned int size) .text:006A53A0 ?DispatchUI_ChannelIndex@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_ChannelList:
        public static UInt32 DispatchUI_ChannelList(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6390)(ui, buf, size); // .text:006A5430 ; unsigned int __cdecl CM_Communication::DispatchUI_ChannelList(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5430 ?DispatchUI_ChannelList@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_ChannelList:
        public static Byte Event_ChannelList(UInt32 i_chan) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A4A50)(i_chan); // .text:006A3C30 ; bool __cdecl CM_Communication::Event_ChannelList(unsigned int i_chan) .text:006A3C30 ?Event_ChannelList@CM_Communication@@YA_NK@Z

        // CM_Communication.Event_ModifyGlobalSquelch:
        public static Byte Event_ModifyGlobalSquelch(int i_add, UInt32 i_msg_type) => ((delegate* unmanaged[Cdecl]<int, UInt32, Byte>)0x006A4B20)(i_add, i_msg_type); // .text:006A3D00 ; bool __cdecl CM_Communication::Event_ModifyGlobalSquelch(int i_add, unsigned int i_msg_type) .text:006A3D00 ?Event_ModifyGlobalSquelch@CM_Communication@@YA_NHK@Z

        // CM_Communication.DispatchUI_ChannelBroadcast:
        public static UInt32 DispatchUI_ChannelBroadcast(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5830)(ui, buf, size); // .text:006A48D0 ; unsigned int __cdecl CM_Communication::DispatchUI_ChannelBroadcast(UIQueueManager *ui, void *buf, unsigned int size) .text:006A48D0 ?DispatchUI_ChannelBroadcast@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_HearSoulEmote:
        public static UInt32 DispatchUI_HearSoulEmote(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5C20)(ui, buf, size); // .text:006A4CC0 ; unsigned int __cdecl CM_Communication::DispatchUI_HearSoulEmote(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4CC0 ?DispatchUI_HearSoulEmote@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_AddToChannel:
        public static Byte Event_AddToChannel(UInt32 i_chan) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A48F0)(i_chan); // .text:006A3AD0 ; bool __cdecl CM_Communication::Event_AddToChannel(unsigned int i_chan) .text:006A3AD0 ?Event_AddToChannel@CM_Communication@@YA_NK@Z

        // CM_Communication.Event_SetAFKMessage:
        public static Byte Event_SetAFKMessage(AC1Legacy.PStringBase<char>* i_strMessage) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A5260)(i_strMessage); // .text:006A4440 ; bool __cdecl CM_Communication::Event_SetAFKMessage(AC1Legacy::PStringBase<char> *i_strMessage) .text:006A4440 ?Event_SetAFKMessage@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.Event_TalkDirect:
        public static Byte Event_TalkDirect(AC1Legacy.PStringBase<char>* i_msg, UInt32 i_target_id) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A54A0)(i_msg, i_target_id); // .text:006A4680 ; bool __cdecl CM_Communication::Event_TalkDirect(AC1Legacy::PStringBase<char> *i_msg, unsigned int i_target_id) .text:006A4680 ?Event_TalkDirect@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Communication.DispatchUI_HearDirectSpeech:
        public static UInt32 DispatchUI_HearDirectSpeech(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5920)(ui, buf, size); // .text:006A49C0 ; unsigned int __cdecl CM_Communication::DispatchUI_HearDirectSpeech(UIQueueManager *ui, void *buf, unsigned int size) .text:006A49C0 ?DispatchUI_HearDirectSpeech@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_RemoveFromChannel:
        public static Byte Event_RemoveFromChannel(UInt32 i_chan) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A4C30)(i_chan); // .text:006A3E10 ; bool __cdecl CM_Communication::Event_RemoveFromChannel(unsigned int i_chan) .text:006A3E10 ?Event_RemoveFromChannel@CM_Communication@@YA_NK@Z

        // CM_Communication.DispatchUI_TransientString:
        public static UInt32 DispatchUI_TransientString(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5F30)(ui, buf, size); // .text:006A4FD0 ; unsigned int __cdecl CM_Communication::DispatchUI_TransientString(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4FD0 ?DispatchUI_TransientString@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_ChannelIndex:
        public static Byte Event_ChannelIndex() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A49C0)(); // .text:006A3BA0 ; bool __cdecl CM_Communication::Event_ChannelIndex() .text:006A3BA0 ?Event_ChannelIndex@CM_Communication@@YA_NXZ

        // CM_Communication.Event_SetAFKMode:
        public static Byte Event_SetAFKMode(int i_bAFK) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A4D00)(i_bAFK); // .text:006A3EE0 ; bool __cdecl CM_Communication::Event_SetAFKMode(int i_bAFK) .text:006A3EE0 ?Event_SetAFKMode@CM_Communication@@YA_NH@Z

        // CM_Communication.Event_Emote:
        public static Byte Event_Emote(AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A4F40)(i_msg); // .text:006A4120 ; bool __cdecl CM_Communication::Event_Emote(AC1Legacy::PStringBase<char> *i_msg) .text:006A4120 ?Event_Emote@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.DispatchUI_HearEmote:
        public static UInt32 DispatchUI_HearEmote(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5A20)(ui, buf, size); // .text:006A4AC0 ; unsigned int __cdecl CM_Communication::DispatchUI_HearEmote(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4AC0 ?DispatchUI_HearEmote@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_HearRangedSpeech:
        public static UInt32 DispatchUI_HearRangedSpeech(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5B10)(ui, buf, size); // .text:006A4BB0 ; unsigned int __cdecl CM_Communication::DispatchUI_HearRangedSpeech(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4BB0 ?DispatchUI_HearRangedSpeech@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_HearSpeech:
        public static UInt32 DispatchUI_HearSpeech(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5D10)(ui, buf, size); // .text:006A4DB0 ; unsigned int __cdecl CM_Communication::DispatchUI_HearSpeech(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4DB0 ?DispatchUI_HearSpeech@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_WeenieError:
        public static UInt32 DispatchUI_WeenieError(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A48C0)(ui, buf, size); // .text:006A3AA0 ; unsigned int __cdecl CM_Communication::DispatchUI_WeenieError(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3AA0 ?DispatchUI_WeenieError@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_Recv_ChatRoomTracker:
        public static UInt32 DispatchUI_Recv_ChatRoomTracker(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A4DD0)(ui, buf, size); // .text:006A3FB0 ; unsigned int __cdecl CM_Communication::DispatchUI_Recv_ChatRoomTracker(UIQueueManager *ui, void *buf, unsigned int size) .text:006A3FB0 ?DispatchUI_Recv_ChatRoomTracker@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.DispatchUI_PopUpString:
        public static UInt32 DispatchUI_PopUpString(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5E00)(ui, buf, size); // .text:006A4EA0 ; unsigned int __cdecl CM_Communication::DispatchUI_PopUpString(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4EA0 ?DispatchUI_PopUpString@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Communication.Event_ChannelBroadcast:
        public static Byte Event_ChannelBroadcast(UInt32 i_chan, AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x006A4E50)(i_chan, i_msg); // .text:006A4030 ; bool __cdecl CM_Communication::Event_ChannelBroadcast(unsigned int i_chan, AC1Legacy::PStringBase<char> *i_msg) .text:006A4030 ?Event_ChannelBroadcast@CM_Communication@@YA_NKABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.Event_ModifyAccountSquelch:
        public static Byte Event_ModifyAccountSquelch(int i_add, AC1Legacy.PStringBase<char>* i_character_name) => ((delegate* unmanaged[Cdecl]<int, AC1Legacy.PStringBase<char>*, Byte>)0x006A5000)(i_add, i_character_name); // .text:006A41E0 ; bool __cdecl CM_Communication::Event_ModifyAccountSquelch(int i_add, AC1Legacy::PStringBase<char> *i_character_name) .text:006A41E0 ?Event_ModifyAccountSquelch@CM_Communication@@YA_NHABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.Event_ModifyCharacterSquelch:
        public static Byte Event_ModifyCharacterSquelch(int i_add, UInt32 i_character_id, AC1Legacy.PStringBase<char>* i_character_name, UInt32 i_msg_type) => ((delegate* unmanaged[Cdecl]<int, UInt32, AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A50F0)(i_add, i_character_id, i_character_name, i_msg_type); // .text:006A42D0 ; bool __cdecl CM_Communication::Event_ModifyCharacterSquelch(int i_add, unsigned int i_character_id, AC1Legacy::PStringBase<char> *i_character_name, unsigned int i_msg_type) .text:006A42D0 ?Event_ModifyCharacterSquelch@CM_Communication@@YA_NHKABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Communication.Event_SoulEmote:
        public static Byte Event_SoulEmote(AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A5320)(i_msg); // .text:006A4500 ; bool __cdecl CM_Communication::Event_SoulEmote(AC1Legacy::PStringBase<char> *i_msg) .text:006A4500 ?Event_SoulEmote@CM_Communication@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Communication.DispatchUI_TextboxString:
        public static UInt32 DispatchUI_TextboxString(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A5E90)(ui, buf, size); // .text:006A4F30 ; unsigned int __cdecl CM_Communication::DispatchUI_TextboxString(UIQueueManager *ui, void *buf, unsigned int size) .text:006A4F30 ?DispatchUI_TextboxString@CM_Communication@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Social {

        // Functions:

        // CM_Social.Event_ClearFriends:
        public static Byte Event_ClearFriends() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A6520)(); // .text:006A55C0 ; bool __cdecl CM_Social::Event_ClearFriends() .text:006A55C0 ?Event_ClearFriends@CM_Social@@YA_NXZ

        // CM_Social.SendNotice_ChatCommand_DisplayFriends:
        public static Byte SendNotice_ChatCommand_DisplayFriends(Byte i_onlineOnly) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x006A6880)(i_onlineOnly); // .text:006A5920 ; bool __cdecl CM_Social::SendNotice_ChatCommand_DisplayFriends(bool i_onlineOnly) .text:006A5920 ?SendNotice_ChatCommand_DisplayFriends@CM_Social@@YA_N_N@Z

        // CM_Social.SendNotice_ChatCommand_RemoveAllFriends:
        public static Byte SendNotice_ChatCommand_RemoveAllFriends() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A68D0)(); // .text:006A5970 ; bool __cdecl CM_Social::SendNotice_ChatCommand_RemoveAllFriends() .text:006A5970 ?SendNotice_ChatCommand_RemoveAllFriends@CM_Social@@YA_NXZ

        // CM_Social.SendNotice_UpdateContractTracker:
        public static Byte SendNotice_UpdateContractTracker(CContractTracker* i_contractTracker, int i_bDeleteContract) => ((delegate* unmanaged[Cdecl]<CContractTracker*, int, Byte>)0x006A6A60)(i_contractTracker, i_bDeleteContract); // .text:006A5B00 ; bool __cdecl CM_Social::SendNotice_UpdateContractTracker(CContractTracker *i_contractTracker, int i_bDeleteContract) .text:006A5B00 ?SendNotice_UpdateContractTracker@CM_Social@@YA_NABVCContractTracker@@H@Z

        // CM_Social.DispatchUI_CharacterTitleTable:
        public static UInt32 DispatchUI_CharacterTitleTable(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6CB0)(ui, buf, size); // .text:006A5D50 ; unsigned int __cdecl CM_Social::DispatchUI_CharacterTitleTable(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5D50 ?DispatchUI_CharacterTitleTable@CM_Social@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Social.DispatchUI_AddOrSetCharacterTitle:
        public static UInt32 DispatchUI_AddOrSetCharacterTitle(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6420)(ui, buf, size); // .text:006A54C0 ; unsigned int __cdecl CM_Social::DispatchUI_AddOrSetCharacterTitle(UIQueueManager *ui, void *buf, unsigned int size) .text:006A54C0 ?DispatchUI_AddOrSetCharacterTitle@CM_Social@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Social.Event_AbandonContract:
        public static Byte Event_AbandonContract(UInt32 i_contract_id) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A6450)(i_contract_id); // .text:006A54F0 ; bool __cdecl CM_Social::Event_AbandonContract(unsigned int i_contract_id) .text:006A54F0 ?Event_AbandonContract@CM_Social@@YA_NK@Z

        // CM_Social.SendNotice_AddCharacterTitle:
        public static Byte SendNotice_AddCharacterTitle(UInt32 i_i_title) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A67E0)(i_i_title); // .text:006A5880 ; bool __cdecl CM_Social::SendNotice_AddCharacterTitle(unsigned int i_i_title) .text:006A5880 ?SendNotice_AddCharacterTitle@CM_Social@@YA_NK@Z

        // CM_Social.SendNotice_SetDisplayContractTracker:
        public static Byte SendNotice_SetDisplayContractTracker(CContractTracker* i_contractTracker) => ((delegate* unmanaged[Cdecl]<CContractTracker*, Byte>)0x006A69C0)(i_contractTracker); // .text:006A5A60 ; bool __cdecl CM_Social::SendNotice_SetDisplayContractTracker(CContractTracker *i_contractTracker) .text:006A5A60 ?SendNotice_SetDisplayContractTracker@CM_Social@@YA_NABVCContractTracker@@@Z

        // CM_Social.SendNotice_UpdateContractTrackerTable:
        public static Byte SendNotice_UpdateContractTrackerTable(CContractTrackerTable* i_contractTrackerTable) => ((delegate* unmanaged[Cdecl]<CContractTrackerTable*, Byte>)0x006A6AC0)(i_contractTrackerTable); // .text:006A5B60 ; bool __cdecl CM_Social::SendNotice_UpdateContractTrackerTable(CContractTrackerTable *i_contractTrackerTable) .text:006A5B60 ?SendNotice_UpdateContractTrackerTable@CM_Social@@YA_NABVCContractTrackerTable@@@Z

        // CM_Social.Event_RemoveFriend:
        public static Byte Event_RemoveFriend(UInt32 i_friendID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A65B0)(i_friendID); // .text:006A5650 ; bool __cdecl CM_Social::Event_RemoveFriend(unsigned int i_friendID) .text:006A5650 ?Event_RemoveFriend@CM_Social@@YA_NK@Z

        // CM_Social.Event_SetDisplayCharacterTitle:
        public static Byte Event_SetDisplayCharacterTitle(UInt32 i_i_title) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A6680)(i_i_title); // .text:006A5720 ; bool __cdecl CM_Social::Event_SetDisplayCharacterTitle(unsigned int i_i_title) .text:006A5720 ?Event_SetDisplayCharacterTitle@CM_Social@@YA_NK@Z

        // CM_Social.SendNotice_ChatCommand_AddFriend:
        public static Byte SendNotice_ChatCommand_AddFriend(PStringBase<char>* i_friend_name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, Byte>)0x006A6830)(i_friend_name); // .text:006A58D0 ; bool __cdecl CM_Social::SendNotice_ChatCommand_AddFriend(PStringBase<char> *i_friend_name) .text:006A58D0 ?SendNotice_ChatCommand_AddFriend@CM_Social@@YA_NABV?$PStringBase@D@@@Z

        // CM_Social.SendNotice_SetDisplayCharacterTitle:
        public static Byte SendNotice_SetDisplayCharacterTitle(UInt32 i_i_title) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A6970)(i_i_title); // .text:006A5A10 ; bool __cdecl CM_Social::SendNotice_SetDisplayCharacterTitle(unsigned int i_i_title) .text:006A5A10 ?SendNotice_SetDisplayCharacterTitle@CM_Social@@YA_NK@Z

        // CM_Social.SendNotice_UpdateCharacterTitleTable:
        public static Byte SendNotice_UpdateCharacterTitleTable(CharacterTitleTable* i_i_titleTable) => ((delegate* unmanaged[Cdecl]<CharacterTitleTable*, Byte>)0x006A6A10)(i_i_titleTable); // .text:006A5AB0 ; bool __cdecl CM_Social::SendNotice_UpdateCharacterTitleTable(CharacterTitleTable *i_i_titleTable) .text:006A5AB0 ?SendNotice_UpdateCharacterTitleTable@CM_Social@@YA_NABVCharacterTitleTable@@@Z

        // CM_Social.Event_AddFriend:
        public static Byte Event_AddFriend(AC1Legacy.PStringBase<char>* i_friend_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A6B70)(i_friend_name); // .text:006A5C10 ; bool __cdecl CM_Social::Event_AddFriend(AC1Legacy::PStringBase<char> *i_friend_name) .text:006A5C10 ?Event_AddFriend@CM_Social@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Social.DispatchUI_SendClientContractTrackerTable:
        public static UInt32 DispatchUI_SendClientContractTrackerTable(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6C30)(ui, buf, size); // .text:006A5CD0 ; unsigned int __cdecl CM_Social::DispatchUI_SendClientContractTrackerTable(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5CD0 ?DispatchUI_SendClientContractTrackerTable@CM_Social@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Social.DispatchUI_SendClientContractTracker:
        public static UInt32 DispatchUI_SendClientContractTracker(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6750)(ui, buf, size); // .text:006A57F0 ; unsigned int __cdecl CM_Social::DispatchUI_SendClientContractTracker(UIQueueManager *ui, void *buf, unsigned int size) .text:006A57F0 ?DispatchUI_SendClientContractTracker@CM_Social@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Social.SendNotice_ChatCommand_RemoveFriend:
        public static Byte SendNotice_ChatCommand_RemoveFriend(PStringBase<char>* i_friend_name) => ((delegate* unmanaged[Cdecl]<PStringBase<char>*, Byte>)0x006A6920)(i_friend_name); // .text:006A59C0 ; bool __cdecl CM_Social::SendNotice_ChatCommand_RemoveFriend(PStringBase<char> *i_friend_name) .text:006A59C0 ?SendNotice_ChatCommand_RemoveFriend@CM_Social@@YA_NABV?$PStringBase@D@@@Z

        // CM_Social.SendNotice_UpdateFriendsList:
        public static Byte SendNotice_UpdateFriendsList(FriendDataList* i_friendDataList, int i_updateType) => ((delegate* unmanaged[Cdecl]<FriendDataList*, int, Byte>)0x006A6B10)(i_friendDataList, i_updateType); // .text:006A5BB0 ; bool __cdecl CM_Social::SendNotice_UpdateFriendsList(FriendDataList *i_friendDataList, int i_updateType) .text:006A5BB0 ?SendNotice_UpdateFriendsList@CM_Social@@YA_NABVFriendDataList@@J@Z

        // CM_Social.DispatchUI_FriendsUpdate:
        public static UInt32 DispatchUI_FriendsUpdate(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6D30)(ui, buf, size); // .text:006A5DD0 ; unsigned int __cdecl CM_Social::DispatchUI_FriendsUpdate(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5DD0 ?DispatchUI_FriendsUpdate@CM_Social@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Fellowship {

        // Functions:

        // CM_Fellowship.DispatchUI_FellowUpdateDone:
        public static UInt32 DispatchUI_FellowUpdateDone(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6E70)(ui, buf, size); // .text:006A5F10 ; unsigned int __cdecl CM_Fellowship::DispatchUI_FellowUpdateDone(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5F10 ?DispatchUI_FellowUpdateDone@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.DispatchUI_Quit:
        public static UInt32 DispatchUI_Quit(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6EA0)(ui, buf, size); // .text:006A5F40 ; unsigned int __cdecl CM_Fellowship::DispatchUI_Quit(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5F40 ?DispatchUI_Quit@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.Event_AssignNewLeader:
        public static Byte Event_AssignNewLeader(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A6ED0)(i_target); // .text:006A5F70 ; bool __cdecl CM_Fellowship::Event_AssignNewLeader(unsigned int i_target) .text:006A5F70 ?Event_AssignNewLeader@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.Event_Dismiss:
        public static Byte Event_Dismiss(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7070)(i_target); // .text:006A6110 ; bool __cdecl CM_Fellowship::Event_Dismiss(unsigned int i_target) .text:006A6110 ?Event_Dismiss@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.SendNotice_FellowAdded:
        public static Byte SendNotice_FellowAdded(UInt32 i_iidPlayer) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A73B0)(i_iidPlayer); // .text:006A6450 ; bool __cdecl CM_Fellowship::SendNotice_FellowAdded(unsigned int i_iidPlayer) .text:006A6450 ?SendNotice_FellowAdded@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.SendNotice_FellowshipDisbanded:
        public static Byte SendNotice_FellowshipDisbanded() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7500)(); // .text:006A65A0 ; bool __cdecl CM_Fellowship::SendNotice_FellowshipDisbanded() .text:006A65A0 ?SendNotice_FellowshipDisbanded@CM_Fellowship@@YA_NXZ

        // CM_Fellowship.SendNotice_FellowshipLeaderChanged:
        public static Byte SendNotice_FellowshipLeaderChanged(UInt32 i_iidNewLeader, UInt32 i_iidOldLeader) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A7550)(i_iidNewLeader, i_iidOldLeader); // .text:006A65F0 ; bool __cdecl CM_Fellowship::SendNotice_FellowshipLeaderChanged(unsigned int i_iidNewLeader, unsigned int i_iidOldLeader) .text:006A65F0 ?SendNotice_FellowshipLeaderChanged@CM_Fellowship@@YA_NKK@Z

        // CM_Fellowship.Event_Create:
        public static Byte Event_Create(AC1Legacy.PStringBase<char>* i_name, int i_share_xp) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, int, Byte>)0x006A7700)(i_name, i_share_xp); // .text:006A67A0 ; bool __cdecl CM_Fellowship::Event_Create(AC1Legacy::PStringBase<char> *i_name, int i_share_xp) .text:006A67A0 ?Event_Create@CM_Fellowship@@YA_NABV?$PStringBase@D@AC1Legacy@@H@Z

        // CM_Fellowship.DispatchUI_FullUpdate:
        public static UInt32 DispatchUI_FullUpdate(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A7800)(ui, buf, size); // .text:006A68A0 ; unsigned int __cdecl CM_Fellowship::DispatchUI_FullUpdate(UIQueueManager *ui, void *buf, unsigned int size) .text:006A68A0 ?DispatchUI_FullUpdate@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.DispatchUI_Disband:
        public static UInt32 DispatchUI_Disband(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6DE0)(ui, buf, size); // .text:006A5E80 ; unsigned int __cdecl CM_Fellowship::DispatchUI_Disband(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5E80 ?DispatchUI_Disband@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.DispatchUI_Dismiss:
        public static UInt32 DispatchUI_Dismiss(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6E10)(ui, buf, size); // .text:006A5EB0 ; unsigned int __cdecl CM_Fellowship::DispatchUI_Dismiss(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5EB0 ?DispatchUI_Dismiss@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.Event_UpdateRequest:
        public static Byte Event_UpdateRequest(int i_on) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A72E0)(i_on); // .text:006A6380 ; bool __cdecl CM_Fellowship::Event_UpdateRequest(int i_on) .text:006A6380 ?Event_UpdateRequest@CM_Fellowship@@YA_NH@Z

        // CM_Fellowship.SendNotice_FellowQuit:
        public static Byte SendNotice_FellowQuit(UInt32 i_iidPlayer) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7450)(i_iidPlayer); // .text:006A64F0 ; bool __cdecl CM_Fellowship::SendNotice_FellowQuit(unsigned int i_iidPlayer) .text:006A64F0 ?SendNotice_FellowQuit@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.SendNotice_FellowshipUpdate:
        public static Byte SendNotice_FellowshipUpdate(CFellowship* i_fellowship) => ((delegate* unmanaged[Cdecl]<CFellowship*, Byte>)0x006A7610)(i_fellowship); // .text:006A66B0 ; bool __cdecl CM_Fellowship::SendNotice_FellowshipUpdate(CFellowship *i_fellowship) .text:006A66B0 ?SendNotice_FellowshipUpdate@CM_Fellowship@@YA_NABVCFellowship@@@Z

        // CM_Fellowship.Event_Recruit:
        public static Byte Event_Recruit(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7210)(i_target); // .text:006A62B0 ; bool __cdecl CM_Fellowship::Event_Recruit(unsigned int i_target) .text:006A62B0 ?Event_Recruit@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.SendNotice_FellowUpdated:
        public static Byte SendNotice_FellowUpdated(UInt32 i_iidPlayer, Fellow* i_fellow, UInt32 i_uiUpdateType) => ((delegate* unmanaged[Cdecl]<UInt32, Fellow*, UInt32, Byte>)0x006A74A0)(i_iidPlayer, i_fellow, i_uiUpdateType); // .text:006A6540 ; bool __cdecl CM_Fellowship::SendNotice_FellowUpdated(unsigned int i_iidPlayer, Fellow *i_fellow, unsigned int i_uiUpdateType) .text:006A6540 ?SendNotice_FellowUpdated@CM_Fellowship@@YA_NKABVFellow@@K@Z

        // CM_Fellowship.DispatchUI_UpdateFellow:
        public static UInt32 DispatchUI_UpdateFellow(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A7660)(ui, buf, size); // .text:006A6700 ; unsigned int __cdecl CM_Fellowship::DispatchUI_UpdateFellow(UIQueueManager *ui, void *buf, unsigned int size) .text:006A6700 ?DispatchUI_UpdateFellow@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.DispatchUI_FellowStatsDone:
        public static UInt32 DispatchUI_FellowStatsDone(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A6E40)(ui, buf, size); // .text:006A5EE0 ; unsigned int __cdecl CM_Fellowship::DispatchUI_FellowStatsDone(UIQueueManager *ui, void *buf, unsigned int size) .text:006A5EE0 ?DispatchUI_FellowStatsDone@CM_Fellowship@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Fellowship.Event_ChangeFellowOpeness:
        public static Byte Event_ChangeFellowOpeness(int i_open) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A6FA0)(i_open); // .text:006A6040 ; bool __cdecl CM_Fellowship::Event_ChangeFellowOpeness(int i_open) .text:006A6040 ?Event_ChangeFellowOpeness@CM_Fellowship@@YA_NH@Z

        // CM_Fellowship.Event_Quit:
        public static Byte Event_Quit(int i_disband) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A7140)(i_disband); // .text:006A61E0 ; bool __cdecl CM_Fellowship::Event_Quit(int i_disband) .text:006A61E0 ?Event_Quit@CM_Fellowship@@YA_NH@Z

        // CM_Fellowship.SendNotice_FellowDismissed:
        public static Byte SendNotice_FellowDismissed(UInt32 i_iidPlayer) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7400)(i_iidPlayer); // .text:006A64A0 ; bool __cdecl CM_Fellowship::SendNotice_FellowDismissed(unsigned int i_iidPlayer) .text:006A64A0 ?SendNotice_FellowDismissed@CM_Fellowship@@YA_NK@Z

        // CM_Fellowship.SendNotice_FellowshipRequest:
        public static Byte SendNotice_FellowshipRequest(AC1Legacy.PStringBase<char>* i_strRequestor, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A75B0)(i_strRequestor, i_uiContextID); // .text:006A6650 ; bool __cdecl CM_Fellowship::SendNotice_FellowshipRequest(AC1Legacy::PStringBase<char> *i_strRequestor, unsigned int i_uiContextID) .text:006A6650 ?SendNotice_FellowshipRequest@CM_Fellowship@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z
    }
    public unsafe struct CM_Allegiance {

        // Functions:

        // CM_Allegiance.DispatchUI_AllegianceInfoResponseEvent:
        public static UInt32 DispatchUI_AllegianceInfoResponseEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A83D0)(ui, buf, size); // .text:006A7470 ; unsigned int __cdecl CM_Allegiance::DispatchUI_AllegianceInfoResponseEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006A7470 ?DispatchUI_AllegianceInfoResponseEvent@CM_Allegiance@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Allegiance.Event_BreakAllegiance:
        public static Byte Event_BreakAllegiance(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A78E0)(i_target); // .text:006A6980 ; bool __cdecl CM_Allegiance::Event_BreakAllegiance(unsigned int i_target) .text:006A6980 ?Event_BreakAllegiance@CM_Allegiance@@YA_NK@Z

        // CM_Allegiance.Event_RecallAllegianceHometown:
        public static Byte Event_RecallAllegianceHometown() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A8060)(); // .text:006A7100 ; bool __cdecl CM_Allegiance::Event_RecallAllegianceHometown() .text:006A7100 ?Event_RecallAllegianceHometown@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_QueryAllegianceName:
        public static Byte Event_QueryAllegianceName() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7F40)(); // .text:006A6FE0 ; bool __cdecl CM_Allegiance::Event_QueryAllegianceName() .text:006A6FE0 ?Event_QueryAllegianceName@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_AllegianceInfoRequest:
        public static Byte Event_AllegianceInfoRequest(AC1Legacy.PStringBase<char>* i_target_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A8720)(i_target_name); // .text:006A77C0 ; bool __cdecl CM_Allegiance::Event_AllegianceInfoRequest(AC1Legacy::PStringBase<char> *i_target_name) .text:006A77C0 ?Event_AllegianceInfoRequest@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_SetAllegianceOfficerTitle:
        public static Byte Event_SetAllegianceOfficerTitle(UInt32 i_level, AC1Legacy.PStringBase<char>* i_title) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x006A8CE0)(i_level, i_title); // .text:006A7D80 ; bool __cdecl CM_Allegiance::Event_SetAllegianceOfficerTitle(unsigned int i_level, AC1Legacy::PStringBase<char> *i_title) .text:006A7D80 ?Event_SetAllegianceOfficerTitle@CM_Allegiance@@YA_NKABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_ClearAllegianceOfficerTitles:
        public static Byte Event_ClearAllegianceOfficerTitles() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7A40)(); // .text:006A6AE0 ; bool __cdecl CM_Allegiance::Event_ClearAllegianceOfficerTitles() .text:006A6AE0 ?Event_ClearAllegianceOfficerTitles@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_DoAllegianceLockAction:
        public static Byte Event_DoAllegianceLockAction(UInt32 i_iAction) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7CC0)(i_iAction); // .text:006A6D60 ; bool __cdecl CM_Allegiance::Event_DoAllegianceLockAction(unsigned int i_iAction) .text:006A6D60 ?Event_DoAllegianceLockAction@CM_Allegiance@@YA_NK@Z

        // CM_Allegiance.Event_ListAllegianceBans:
        public static Byte Event_ListAllegianceBans() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7D90)(); // .text:006A6E30 ; bool __cdecl CM_Allegiance::Event_ListAllegianceBans() .text:006A6E30 ?Event_ListAllegianceBans@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.SendNotice_AllegianceUpdate:
        public static Byte SendNotice_AllegianceUpdate(CAllegianceProfile* i_prof, UInt32 i_rank) => ((delegate* unmanaged[Cdecl]<CAllegianceProfile*, UInt32, Byte>)0x006A82E0)(i_prof, i_rank); // .text:006A7380 ; bool __cdecl CM_Allegiance::SendNotice_AllegianceUpdate(CAllegianceProfile *i_prof, unsigned int i_rank) .text:006A7380 ?SendNotice_AllegianceUpdate@CM_Allegiance@@YA_NABVCAllegianceProfile@@K@Z

        // CM_Allegiance.Event_UpdateRequest:
        public static Byte Event_UpdateRequest(int i_on) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A81C0)(i_on); // .text:006A7260 ; bool __cdecl CM_Allegiance::Event_UpdateRequest(int i_on) .text:006A7260 ?Event_UpdateRequest@CM_Allegiance@@YA_NH@Z

        // CM_Allegiance.Event_AddAllegianceBan:
        public static Byte Event_AddAllegianceBan(AC1Legacy.PStringBase<char>* i_char_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A8480)(i_char_name); // .text:006A7520 ; bool __cdecl CM_Allegiance::Event_AddAllegianceBan(AC1Legacy::PStringBase<char> *i_char_name) .text:006A7520 ?Event_AddAllegianceBan@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_ClearMotd:
        public static Byte Event_ClearMotd() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7B60)(); // .text:006A6C00 ; bool __cdecl CM_Allegiance::Event_ClearMotd() .text:006A6C00 ?Event_ClearMotd@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_RemoveAllegianceBan:
        public static Byte Event_RemoveAllegianceBan(AC1Legacy.PStringBase<char>* i_char_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A88E0)(i_char_name); // .text:006A7980 ; bool __cdecl CM_Allegiance::Event_RemoveAllegianceBan(AC1Legacy::PStringBase<char> *i_char_name) .text:006A7980 ?Event_RemoveAllegianceBan@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.SendNotice_AllegianceUpdateAborted:
        public static Byte SendNotice_AllegianceUpdateAborted(UInt32 i_etype) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A8330)(i_etype); // .text:006A73D0 ; bool __cdecl CM_Allegiance::SendNotice_AllegianceUpdateAborted(unsigned int i_etype) .text:006A73D0 ?SendNotice_AllegianceUpdateAborted@CM_Allegiance@@YA_NK@Z

        // CM_Allegiance.SendNotice_SwearAllegianceRequest:
        public static Byte SendNotice_SwearAllegianceRequest(AC1Legacy.PStringBase<char>* i_strRequestor, UInt32 i_uiContextID) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A8380)(i_strRequestor, i_uiContextID); // .text:006A7420 ; bool __cdecl CM_Allegiance::SendNotice_SwearAllegianceRequest(AC1Legacy::PStringBase<char> *i_strRequestor, unsigned int i_uiContextID) .text:006A7420 ?SendNotice_SwearAllegianceRequest@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Allegiance.Event_AllegianceChatGag:
        public static Byte Event_AllegianceChatGag(AC1Legacy.PStringBase<char>* i_char_name, int i_bOn) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, int, Byte>)0x006A8620)(i_char_name, i_bOn); // .text:006A76C0 ; bool __cdecl CM_Allegiance::Event_AllegianceChatGag(AC1Legacy::PStringBase<char> *i_char_name, int i_bOn) .text:006A76C0 ?Event_AllegianceChatGag@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@H@Z

        // CM_Allegiance.Event_RemoveAllegianceOfficer:
        public static Byte Event_RemoveAllegianceOfficer(AC1Legacy.PStringBase<char>* i_char_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A89A0)(i_char_name); // .text:006A7A40 ; bool __cdecl CM_Allegiance::Event_RemoveAllegianceOfficer(AC1Legacy::PStringBase<char> *i_char_name) .text:006A7A40 ?Event_RemoveAllegianceOfficer@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_SetAllegianceName:
        public static Byte Event_SetAllegianceName(AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A8B20)(i_msg); // .text:006A7BC0 ; bool __cdecl CM_Allegiance::Event_SetAllegianceName(AC1Legacy::PStringBase<char> *i_msg) .text:006A7BC0 ?Event_SetAllegianceName@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_SetAllegianceOfficer:
        public static Byte Event_SetAllegianceOfficer(AC1Legacy.PStringBase<char>* i_char_name, UInt32 i_level) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, UInt32, Byte>)0x006A8BE0)(i_char_name, i_level); // .text:006A7C80 ; bool __cdecl CM_Allegiance::Event_SetAllegianceOfficer(AC1Legacy::PStringBase<char> *i_char_name, unsigned int i_level) .text:006A7C80 ?Event_SetAllegianceOfficer@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@K@Z

        // CM_Allegiance.Event_ClearAllegianceName:
        public static Byte Event_ClearAllegianceName() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A79B0)(); // .text:006A6A50 ; bool __cdecl CM_Allegiance::Event_ClearAllegianceName() .text:006A6A50 ?Event_ClearAllegianceName@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_SwearAllegiance:
        public static Byte Event_SwearAllegiance(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A80F0)(i_target); // .text:006A7190 ; bool __cdecl CM_Allegiance::Event_SwearAllegiance(unsigned int i_target) .text:006A7190 ?Event_SwearAllegiance@CM_Allegiance@@YA_NK@Z

        // CM_Allegiance.Event_ListAllegianceOfficerTitles:
        public static Byte Event_ListAllegianceOfficerTitles() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7E20)(); // .text:006A6EC0 ; bool __cdecl CM_Allegiance::Event_ListAllegianceOfficerTitles() .text:006A6EC0 ?Event_ListAllegianceOfficerTitles@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_ListAllegianceOfficers:
        public static Byte Event_ListAllegianceOfficers() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7EB0)(); // .text:006A6F50 ; bool __cdecl CM_Allegiance::Event_ListAllegianceOfficers() .text:006A6F50 ?Event_ListAllegianceOfficers@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.SendNotice_AllegianceLogin:
        public static Byte SendNotice_AllegianceLogin(UInt32 i_iidMember, Byte i_bNowLoggedIn) => ((delegate* unmanaged[Cdecl]<UInt32, Byte, Byte>)0x006A8290)(i_iidMember, i_bNowLoggedIn); // .text:006A7330 ; bool __cdecl CM_Allegiance::SendNotice_AllegianceLogin(unsigned int i_iidMember, bool i_bNowLoggedIn) .text:006A7330 ?SendNotice_AllegianceLogin@CM_Allegiance@@YA_NK_N@Z

        // CM_Allegiance.Event_SetMotd:
        public static Byte Event_SetMotd(AC1Legacy.PStringBase<char>* i_msg) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A8DD0)(i_msg); // .text:006A7E70 ; bool __cdecl CM_Allegiance::Event_SetMotd(AC1Legacy::PStringBase<char> *i_msg) .text:006A7E70 ?Event_SetMotd@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.DispatchUI_AllegianceLoginNotificationEvent:
        public static UInt32 DispatchUI_AllegianceLoginNotificationEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A7880)(ui, buf, size); // .text:006A6920 ; unsigned int __cdecl CM_Allegiance::DispatchUI_AllegianceLoginNotificationEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006A6920 ?DispatchUI_AllegianceLoginNotificationEvent@CM_Allegiance@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Allegiance.DispatchUI_AllegianceUpdateAborted:
        public static UInt32 DispatchUI_AllegianceUpdateAborted(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A78B0)(ui, buf, size); // .text:006A6950 ; unsigned int __cdecl CM_Allegiance::DispatchUI_AllegianceUpdateAborted(UIQueueManager *ui, void *buf, unsigned int size) .text:006A6950 ?DispatchUI_AllegianceUpdateAborted@CM_Allegiance@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Allegiance.Event_QueryMotd:
        public static Byte Event_QueryMotd() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7FD0)(); // .text:006A7070 ; bool __cdecl CM_Allegiance::Event_QueryMotd() .text:006A7070 ?Event_QueryMotd@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_AllegianceChatBoot:
        public static Byte Event_AllegianceChatBoot(AC1Legacy.PStringBase<char>* i_char_name, AC1Legacy.PStringBase<char>* i_reason) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, Byte>)0x006A8540)(i_char_name, i_reason); // .text:006A75E0 ; bool __cdecl CM_Allegiance::Event_AllegianceChatBoot(AC1Legacy::PStringBase<char> *i_char_name, AC1Legacy::PStringBase<char> *i_reason) .text:006A75E0 ?Event_AllegianceChatBoot@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@0@Z

        // CM_Allegiance.Event_BreakAllegianceBoot:
        public static Byte Event_BreakAllegianceBoot(AC1Legacy.PStringBase<char>* i_bootee_name, int i_account_boot) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, int, Byte>)0x006A87E0)(i_bootee_name, i_account_boot); // .text:006A7880 ; bool __cdecl CM_Allegiance::Event_BreakAllegianceBoot(AC1Legacy::PStringBase<char> *i_bootee_name, int i_account_boot) .text:006A7880 ?Event_BreakAllegianceBoot@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@H@Z

        // CM_Allegiance.Event_SetAllegianceApprovedVassal:
        public static Byte Event_SetAllegianceApprovedVassal(AC1Legacy.PStringBase<char>* i_char_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006A8A60)(i_char_name); // .text:006A7B00 ; bool __cdecl CM_Allegiance::Event_SetAllegianceApprovedVassal(AC1Legacy::PStringBase<char> *i_char_name) .text:006A7B00 ?Event_SetAllegianceApprovedVassal@CM_Allegiance@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Allegiance.Event_ClearAllegianceOfficers:
        public static Byte Event_ClearAllegianceOfficers() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A7AD0)(); // .text:006A6B70 ; bool __cdecl CM_Allegiance::Event_ClearAllegianceOfficers() .text:006A6B70 ?Event_ClearAllegianceOfficers@CM_Allegiance@@YA_NXZ

        // CM_Allegiance.Event_DoAllegianceHouseAction:
        public static Byte Event_DoAllegianceHouseAction(UInt32 i_iAction) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A7BF0)(i_iAction); // .text:006A6C90 ; bool __cdecl CM_Allegiance::Event_DoAllegianceHouseAction(unsigned int i_iAction) .text:006A6C90 ?Event_DoAllegianceHouseAction@CM_Allegiance@@YA_NK@Z
    }
    public unsafe struct CM_Train {

        // Functions:

        // CM_Train.Event_TrainSkillAdvancementClass:
        public static Byte Event_TrainSkillAdvancementClass(UInt32 i_stype, UInt32 i_credits_spent) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A91C0)(i_stype, i_credits_spent); // .text:006A8260 ; bool __cdecl CM_Train::Event_TrainSkillAdvancementClass(unsigned int i_stype, unsigned int i_credits_spent) .text:006A8260 ?Event_TrainSkillAdvancementClass@CM_Train@@YA_NKK@Z

        // CM_Train.SendNotice_SkillAdvancementClassChanged:
        public static Byte SendNotice_SkillAdvancementClassChanged() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A92D0)(); // .text:006A8370 ; bool __cdecl CM_Train::SendNotice_SkillAdvancementClassChanged() .text:006A8370 ?SendNotice_SkillAdvancementClassChanged@CM_Train@@YA_NXZ

        // CM_Train.Event_TrainAttribute:
        public static Byte Event_TrainAttribute(UInt32 i_atype, UInt32 i_xp_spent) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A8E90)(i_atype, i_xp_spent); // .text:006A7F30 ; bool __cdecl CM_Train::Event_TrainAttribute(unsigned int i_atype, unsigned int i_xp_spent) .text:006A7F30 ?Event_TrainAttribute@CM_Train@@YA_NKK@Z

        // CM_Train.Event_TrainAttribute2nd:
        public static Byte Event_TrainAttribute2nd(UInt32 i_atype, UInt32 i_xp_spent) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A8FA0)(i_atype, i_xp_spent); // .text:006A8040 ; bool __cdecl CM_Train::Event_TrainAttribute2nd(unsigned int i_atype, unsigned int i_xp_spent) .text:006A8040 ?Event_TrainAttribute2nd@CM_Train@@YA_NKK@Z

        // CM_Train.Event_TrainSkill:
        public static Byte Event_TrainSkill(UInt32 i_stype, UInt32 i_xp_spent) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A90B0)(i_stype, i_xp_spent); // .text:006A8150 ; bool __cdecl CM_Train::Event_TrainSkill(unsigned int i_stype, unsigned int i_xp_spent) .text:006A8150 ?Event_TrainSkill@CM_Train@@YA_NKK@Z
    }
    public unsafe struct CM_Advocate {

        // Functions:

        // CM_Advocate.Event_Teleport:
        public static Byte Event_Teleport(AC1Legacy.PStringBase<char>* i_target, Position* i_dest) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Position*, Byte>)0x006A9320)(i_target, i_dest); // .text:006A83C0 ; bool __cdecl CM_Advocate::Event_Teleport(AC1Legacy::PStringBase<char> *i_target, Position *i_dest) .text:006A83C0 ?Event_Teleport@CM_Advocate@@YA_NABV?$PStringBase@D@AC1Legacy@@ABVPosition@@@Z
    }
    public unsafe struct CM_Item {

        // Functions:

        // CM_Item.DispatchUI_AppraiseDone:
        public static UInt32 DispatchUI_AppraiseDone(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9400)(ui, buf, size); // .text:006A84A0 ; unsigned int __cdecl CM_Item::DispatchUI_AppraiseDone(UIQueueManager *ui, void *buf, unsigned int size) .text:006A84A0 ?DispatchUI_AppraiseDone@CM_Item@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Item.DispatchUI_UseDone:
        public static UInt32 DispatchUI_UseDone(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9470)(ui, buf, size); // .text:006A8510 ; unsigned int __cdecl CM_Item::DispatchUI_UseDone(UIQueueManager *ui, void *buf, unsigned int size) .text:006A8510 ?DispatchUI_UseDone@CM_Item@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Item.Event_QueryItemMana:
        public static Byte Event_QueryItemMana(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A9570)(i_target); // .text:006A8610 ; bool __cdecl CM_Item::Event_QueryItemMana(unsigned int i_target) .text:006A8610 ?Event_QueryItemMana@CM_Item@@YA_NK@Z

        // CM_Item.SendNotice_BeginDrag:
        public static Byte SendNotice_BeginDrag(UInt32 i_itemID, UInt32 i_spellID, Byte i_bIsAlias) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte, Byte>)0x006A9640)(i_itemID, i_spellID, i_bIsAlias); // .text:006A86E0 ; bool __cdecl CM_Item::SendNotice_BeginDrag(unsigned int i_itemID, unsigned int i_spellID, bool i_bIsAlias) .text:006A86E0 ?SendNotice_BeginDrag@CM_Item@@YA_NKK_N@Z

        // CM_Item.SendNotice_UpdateItemMana:
        public static Byte SendNotice_UpdateItemMana(UInt32 i_iidItem, Single i_mana, Byte i_bSuccess) => ((delegate* unmanaged[Cdecl]<UInt32, Single, Byte, Byte>)0x006A97F0)(i_iidItem, i_mana, i_bSuccess); // .text:006A8890 ; bool __cdecl CM_Item::SendNotice_UpdateItemMana(unsigned int i_iidItem, float i_mana, bool i_bSuccess) .text:006A8890 ?SendNotice_UpdateItemMana@CM_Item@@YA_NKM_N@Z

        // CM_Item.SendNotice_ShowPendingInPlayer:
        public static Byte SendNotice_ShowPendingInPlayer(UInt32 i_i_itemID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A97A0)(i_i_itemID); // .text:006A8840 ; bool __cdecl CM_Item::SendNotice_ShowPendingInPlayer(unsigned int i_i_itemID) .text:006A8840 ?SendNotice_ShowPendingInPlayer@CM_Item@@YA_NK@Z

        // CM_Item.DispatchUI_QueryItemManaResponse:
        public static UInt32 DispatchUI_QueryItemManaResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9430)(ui, buf, size); // .text:006A84D0 ; unsigned int __cdecl CM_Item::DispatchUI_QueryItemManaResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006A84D0 ?DispatchUI_QueryItemManaResponse@CM_Item@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Item.Event_Appraise:
        public static Byte Event_Appraise(UInt32 i_objectID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A94A0)(i_objectID); // .text:006A8540 ; bool __cdecl CM_Item::Event_Appraise(unsigned int i_objectID) .text:006A8540 ?Event_Appraise@CM_Item@@YA_NK@Z

        // CM_Item.SendNotice_EndPendingInPlayer:
        public static Byte SendNotice_EndPendingInPlayer() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A96A0)(); // .text:006A8740 ; bool __cdecl CM_Item::SendNotice_EndPendingInPlayer() .text:006A8740 ?SendNotice_EndPendingInPlayer@CM_Item@@YA_NXZ

        // CM_Item.SendNotice_ItemListBeginDrag:
        public static Byte SendNotice_ItemListBeginDrag(UIElement* i_itemList, int i_slotNum) => ((delegate* unmanaged[Cdecl]<UIElement*, int, Byte>)0x006A96F0)(i_itemList, i_slotNum); // .text:006A8790 ; bool __cdecl CM_Item::SendNotice_ItemListBeginDrag(UIElement *i_itemList, int i_slotNum) .text:006A8790 ?SendNotice_ItemListBeginDrag@CM_Item@@YA_NABVUIElement@@J@Z

        // CM_Item.SendNotice_SetGroundObject:
        public static Byte SendNotice_SetGroundObject(UInt32 i_groundObj) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A9750)(i_groundObj); // .text:006A87F0 ; bool __cdecl CM_Item::SendNotice_SetGroundObject(unsigned int i_groundObj) .text:006A87F0 ?SendNotice_SetGroundObject@CM_Item@@YA_NK@Z
    }
    public unsafe struct CM_Game {

        // Functions:

        // CM_Game.SendNotice_MoveResponse:
        public static Byte SendNotice_MoveResponse(UInt32 i_idGame, int i_iMoveResult) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006A9FC0)(i_idGame, i_iMoveResult); // .text:006A9060 ; bool __cdecl CM_Game::SendNotice_MoveResponse(unsigned int i_idGame, int i_iMoveResult) .text:006A9060 ?SendNotice_MoveResponse@CM_Game@@YA_NKJ@Z

        // CM_Game.SendNotice_StartGame:
        public static Byte SendNotice_StartGame(UInt32 i_idGame, int i_iTeam) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006AA0E0)(i_idGame, i_iTeam); // .text:006A9180 ; bool __cdecl CM_Game::SendNotice_StartGame(unsigned int i_idGame, int i_iTeam) .text:006A9180 ?SendNotice_StartGame@CM_Game@@YA_NKJ@Z

        // CM_Game.DispatchUI_Recv_GameOver:
        public static UInt32 DispatchUI_Recv_GameOver(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9850)(ui, buf, size); // .text:006A88F0 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_GameOver(UIQueueManager *ui, void *buf, unsigned int size) .text:006A88F0 ?DispatchUI_Recv_GameOver@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.DispatchUI_Recv_StartGame:
        public static UInt32 DispatchUI_Recv_StartGame(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9920)(ui, buf, size); // .text:006A89C0 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_StartGame(UIQueueManager *ui, void *buf, unsigned int size) .text:006A89C0 ?DispatchUI_Recv_StartGame@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.Event_Join:
        public static Byte Event_Join(UInt32 i_idGame, UInt32 i_iWhichTeam) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006A9950)(i_idGame, i_iWhichTeam); // .text:006A89F0 ; bool __cdecl CM_Game::Event_Join(unsigned int i_idGame, unsigned int i_iWhichTeam) .text:006A89F0 ?Event_Join@CM_Game@@YA_NKK@Z

        // CM_Game.SendNotice_EndGame:
        public static Byte SendNotice_EndGame() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A9EB0)(); // .text:006A8F50 ; bool __cdecl CM_Game::SendNotice_EndGame() .text:006A8F50 ?SendNotice_EndGame@CM_Game@@YA_NXZ

        // CM_Game.SendNotice_JoinGameResponse:
        public static Byte SendNotice_JoinGameResponse(UInt32 i_idGame, int i_iTeam) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006A9F60)(i_idGame, i_iTeam); // .text:006A9000 ; bool __cdecl CM_Game::SendNotice_JoinGameResponse(unsigned int i_idGame, int i_iTeam) .text:006A9000 ?SendNotice_JoinGameResponse@CM_Game@@YA_NKJ@Z

        // CM_Game.DispatchUI_Recv_MoveResponse:
        public static UInt32 DispatchUI_Recv_MoveResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A98B0)(ui, buf, size); // .text:006A8950 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_MoveResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006A8950 ?DispatchUI_Recv_MoveResponse@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.DispatchUI_Recv_OppenentStalemateState:
        public static UInt32 DispatchUI_Recv_OppenentStalemateState(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A98E0)(ui, buf, size); // .text:006A8980 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_OppenentStalemateState(UIQueueManager *ui, void *buf, unsigned int size) .text:006A8980 ?DispatchUI_Recv_OppenentStalemateState@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.DispatchUI_Recv_OpponentTurn:
        public static UInt32 DispatchUI_Recv_OpponentTurn(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9DE0)(ui, buf, size); // .text:006A8E80 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_OpponentTurn(UIQueueManager *ui, void *buf, unsigned int size) .text:006A8E80 ?DispatchUI_Recv_OpponentTurn@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.SendNotice_OpponentOffersStalemate:
        public static Byte SendNotice_OpponentOffersStalemate(UInt32 i_idGame, int i_iTeam, int i_fOn) => ((delegate* unmanaged[Cdecl]<UInt32, int, int, Byte>)0x006AA020)(i_idGame, i_iTeam, i_fOn); // .text:006A90C0 ; bool __cdecl CM_Game::SendNotice_OpponentOffersStalemate(unsigned int i_idGame, int i_iTeam, int i_fOn) .text:006A90C0 ?SendNotice_OpponentOffersStalemate@CM_Game@@YA_NKJH@Z

        // CM_Game.SendNotice_OpponentTurn:
        public static Byte SendNotice_OpponentTurn(UInt32 i_idGame, int i_iTeam, GameMoveData* i_move) => ((delegate* unmanaged[Cdecl]<UInt32, int, GameMoveData*, Byte>)0x006AA080)(i_idGame, i_iTeam, i_move); // .text:006A9120 ; bool __cdecl CM_Game::SendNotice_OpponentTurn(unsigned int i_idGame, int i_iTeam, GameMoveData *i_move) .text:006A9120 ?SendNotice_OpponentTurn@CM_Game@@YA_NKJABVGameMoveData@@@Z

        // CM_Game.Event_Stalemate:
        public static Byte Event_Stalemate(int i_fOn) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006A9D10)(i_fOn); // .text:006A8DB0 ; bool __cdecl CM_Game::Event_Stalemate(int i_fOn) .text:006A8DB0 ?Event_Stalemate@CM_Game@@YA_NH@Z

        // CM_Game.SendNotice_TryToQuitGame:
        public static Byte SendNotice_TryToQuitGame(Byte i_bQuitting) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x006AA140)(i_bQuitting); // .text:006A91E0 ; bool __cdecl CM_Game::SendNotice_TryToQuitGame(bool i_bQuitting) .text:006A91E0 ?SendNotice_TryToQuitGame@CM_Game@@YA_N_N@Z

        // CM_Game.SendNotice_GameOver:
        public static Byte SendNotice_GameOver(UInt32 i_idGame, int i_iTeamWinner) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006A9F00)(i_idGame, i_iTeamWinner); // .text:006A8FA0 ; bool __cdecl CM_Game::SendNotice_GameOver(unsigned int i_idGame, int i_iTeamWinner) .text:006A8FA0 ?SendNotice_GameOver@CM_Game@@YA_NKJ@Z

        // CM_Game.DispatchUI_Recv_JoinGameResponse:
        public static UInt32 DispatchUI_Recv_JoinGameResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006A9880)(ui, buf, size); // .text:006A8920 ; unsigned int __cdecl CM_Game::DispatchUI_Recv_JoinGameResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006A8920 ?DispatchUI_Recv_JoinGameResponse@CM_Game@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Game.Event_Move:
        public static Byte Event_Move(int i_xFrom, int i_yFrom, int i_xTo, int i_yTo) => ((delegate* unmanaged[Cdecl]<int, int, int, int, Byte>)0x006A9A60)(i_xFrom, i_yFrom, i_xTo, i_yTo); // .text:006A8B00 ; bool __cdecl CM_Game::Event_Move(int i_xFrom, int i_yFrom, int i_xTo, int i_yTo) .text:006A8B00 ?Event_Move@CM_Game@@YA_NHHHH@Z

        // CM_Game.Event_MovePass:
        public static Byte Event_MovePass() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A9BF0)(); // .text:006A8C90 ; bool __cdecl CM_Game::Event_MovePass() .text:006A8C90 ?Event_MovePass@CM_Game@@YA_NXZ

        // CM_Game.Event_Quit:
        public static Byte Event_Quit() => ((delegate* unmanaged[Cdecl]<Byte>)0x006A9C80)(); // .text:006A8D20 ; bool __cdecl CM_Game::Event_Quit() .text:006A8D20 ?Event_Quit@CM_Game@@YA_NXZ

        // CM_Game.SendNotice_BeginGame:
        public static Byte SendNotice_BeginGame(UInt32 i_iidGame) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006A9E60)(i_iidGame); // .text:006A8F00 ; bool __cdecl CM_Game::SendNotice_BeginGame(unsigned int i_iidGame) .text:006A8F00 ?SendNotice_BeginGame@CM_Game@@YA_NK@Z
    }
    public unsafe struct CM_Writing {

        // Functions:

        // CM_Writing.Event_BookData:
        public static Byte Event_BookData(UInt32 i_objectID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AA260)(i_objectID); // .text:006A9300 ; bool __cdecl CM_Writing::Event_BookData(unsigned int i_objectID) .text:006A9300 ?Event_BookData@CM_Writing@@YA_NK@Z

        // CM_Writing.Event_BookDeletePage:
        public static Byte Event_BookDeletePage(UInt32 i_objectID, int i_pageNum) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006AA330)(i_objectID, i_pageNum); // .text:006A93D0 ; bool __cdecl CM_Writing::Event_BookDeletePage(unsigned int i_objectID, int i_pageNum) .text:006A93D0 ?Event_BookDeletePage@CM_Writing@@YA_NKJ@Z

        // CM_Writing.Event_BookModifyPage:
        public static Byte Event_BookModifyPage(UInt32 i_objectID, int i_pageNum, AC1Legacy.PStringBase<char>* i_pageText) => ((delegate* unmanaged[Cdecl]<UInt32, int, AC1Legacy.PStringBase<char>*, Byte>)0x006AA6E0)(i_objectID, i_pageNum, i_pageText); // .text:006A9780 ; bool __cdecl CM_Writing::Event_BookModifyPage(unsigned int i_objectID, int i_pageNum, AC1Legacy::PStringBase<char> *i_pageText) .text:006A9780 ?Event_BookModifyPage@CM_Writing@@YA_NKJABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Writing.Event_BookAddPage:
        public static Byte Event_BookAddPage(UInt32 i_objectID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AA190)(i_objectID); // .text:006A9230 ; bool __cdecl CM_Writing::Event_BookAddPage(unsigned int i_objectID) .text:006A9230 ?Event_BookAddPage@CM_Writing@@YA_NK@Z

        // CM_Writing.SendNotice_BookAddPageResponse:
        public static Byte SendNotice_BookAddPageResponse(UInt32 i_bookID, int i_pageNum, int i_success) => ((delegate* unmanaged[Cdecl]<UInt32, int, int, Byte>)0x006AA550)(i_bookID, i_pageNum, i_success); // .text:006A95F0 ; bool __cdecl CM_Writing::SendNotice_BookAddPageResponse(unsigned int i_bookID, int i_pageNum, int i_success) .text:006A95F0 ?SendNotice_BookAddPageResponse@CM_Writing@@YA_NKJH@Z

        // CM_Writing.SendNotice_BookDeletePageResponse:
        public static Byte SendNotice_BookDeletePageResponse(UInt32 i_bookID, int i_pageNum, int i_success) => ((delegate* unmanaged[Cdecl]<UInt32, int, int, Byte>)0x006AA5B0)(i_bookID, i_pageNum, i_success); // .text:006A9650 ; bool __cdecl CM_Writing::SendNotice_BookDeletePageResponse(unsigned int i_bookID, int i_pageNum, int i_success) .text:006A9650 ?SendNotice_BookDeletePageResponse@CM_Writing@@YA_NKJH@Z

        // CM_Writing.SendNotice_BookPageDataResponse:
        public static Byte SendNotice_BookPageDataResponse(UInt32 i_bookID, int i_pageNum, PageData* i_pageData) => ((delegate* unmanaged[Cdecl]<UInt32, int, PageData*, Byte>)0x006AA610)(i_bookID, i_pageNum, i_pageData); // .text:006A96B0 ; bool __cdecl CM_Writing::SendNotice_BookPageDataResponse(unsigned int i_bookID, int i_pageNum, PageData *i_pageData) .text:006A96B0 ?SendNotice_BookPageDataResponse@CM_Writing@@YA_NKJABVPageData@@@Z

        // CM_Writing.SendNotice_OpenBook:
        public static Byte SendNotice_OpenBook(UInt32 i_bookID, int i_maxNumPages, PageDataList* i_pageDataList, AC1Legacy.PStringBase<char>* i_inscription, UInt32 i_scribeID, AC1Legacy.PStringBase<char>* i_scribeName) => ((delegate* unmanaged[Cdecl]<UInt32, int, PageDataList*, AC1Legacy.PStringBase<char>*, UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x006AA670)(i_bookID, i_maxNumPages, i_pageDataList, i_inscription, i_scribeID, i_scribeName); // .text:006A9710 ; bool __cdecl CM_Writing::SendNotice_OpenBook(unsigned int i_bookID, int i_maxNumPages, PageDataList *i_pageDataList, AC1Legacy::PStringBase<char> *i_inscription, unsigned int i_scribeID, AC1Legacy::PStringBase<char> *i_scribeName) .text:006A9710 ?SendNotice_OpenBook@CM_Writing@@YA_NKJABVPageDataList@@ABV?$PStringBase@D@AC1Legacy@@K1@Z

        // CM_Writing.Event_SetInscription:
        public static Byte Event_SetInscription(UInt32 i_objectID, AC1Legacy.PStringBase<char>* i_inscription) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x006AA810)(i_objectID, i_inscription); // .text:006A98B0 ; bool __cdecl CM_Writing::Event_SetInscription(unsigned int i_objectID, AC1Legacy::PStringBase<char> *i_inscription) .text:006A98B0 ?Event_SetInscription@CM_Writing@@YA_NKABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Writing.Event_BookPageData:
        public static Byte Event_BookPageData(UInt32 i_objectID, int i_pageNum) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006AA440)(i_objectID, i_pageNum); // .text:006A94E0 ; bool __cdecl CM_Writing::Event_BookPageData(unsigned int i_objectID, int i_pageNum) .text:006A94E0 ?Event_BookPageData@CM_Writing@@YA_NKJ@Z
    }
    public unsafe struct CM_Combat {

        // Functions:

        // CM_Combat.SendNotice_SetCombatMode:
        public static Byte SendNotice_SetCombatMode(COMBAT_MODE i_eCombatMode) => ((delegate* unmanaged[Cdecl]<COMBAT_MODE, Byte>)0x006AAEB0)(i_eCombatMode); // .text:006A9F50 ; bool __cdecl CM_Combat::SendNotice_SetCombatMode(COMBAT_MODE i_eCombatMode) .text:006A9F50 ?SendNotice_SetCombatMode@CM_Combat@@YA_NW4COMBAT_MODE@@@Z

        // CM_Combat.SendNotice_UpdateObjectHealth:
        public static Byte SendNotice_UpdateObjectHealth(UInt32 i_target, Single i_health) => ((delegate* unmanaged[Cdecl]<UInt32, Single, Byte>)0x006AAF00)(i_target, i_health); // .text:006A9FA0 ; bool __cdecl CM_Combat::SendNotice_UpdateObjectHealth(unsigned int i_target, float i_health) .text:006A9FA0 ?SendNotice_UpdateObjectHealth@CM_Combat@@YA_NKM@Z

        // CM_Combat.DispatchUI_QueryHealthResponse:
        public static UInt32 DispatchUI_QueryHealthResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AA900)(ui, buf, size); // .text:006A99A0 ; unsigned int __cdecl CM_Combat::DispatchUI_QueryHealthResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006A99A0 ?DispatchUI_QueryHealthResponse@CM_Combat@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Combat.Event_ChangeCombatMode:
        public static Byte Event_ChangeCombatMode(COMBAT_MODE i_mode) => ((delegate* unmanaged[Cdecl]<COMBAT_MODE, Byte>)0x006AA9D0)(i_mode); // .text:006A9A70 ; bool __cdecl CM_Combat::Event_ChangeCombatMode(COMBAT_MODE i_mode) .text:006A9A70 ?Event_ChangeCombatMode@CM_Combat@@YA_NW4COMBAT_MODE@@@Z

        // CM_Combat.Event_TargetedMeleeAttack:
        public static Byte Event_TargetedMeleeAttack(UInt32 i_targetID, ATTACK_HEIGHT i_ah, Single i_power_level) => ((delegate* unmanaged[Cdecl]<UInt32, ATTACK_HEIGHT, Single, Byte>)0x006AAB70)(i_targetID, i_ah, i_power_level); // .text:006A9C10 ; bool __cdecl CM_Combat::Event_TargetedMeleeAttack(unsigned int i_targetID, ATTACK_HEIGHT i_ah, float i_power_level) .text:006A9C10 ?Event_TargetedMeleeAttack@CM_Combat@@YA_NKW4ATTACK_HEIGHT@@M@Z

        // CM_Combat.Event_TargetedMissileAttack:
        public static Byte Event_TargetedMissileAttack(UInt32 i_targetID, ATTACK_HEIGHT i_ah, Single i_accuracy_level) => ((delegate* unmanaged[Cdecl]<UInt32, ATTACK_HEIGHT, Single, Byte>)0x006AACC0)(i_targetID, i_ah, i_accuracy_level); // .text:006A9D60 ; bool __cdecl CM_Combat::Event_TargetedMissileAttack(unsigned int i_targetID, ATTACK_HEIGHT i_ah, float i_accuracy_level) .text:006A9D60 ?Event_TargetedMissileAttack@CM_Combat@@YA_NKW4ATTACK_HEIGHT@@M@Z

        // CM_Combat.SendNotice_DesiredAttackPowerChanged:
        public static Byte SendNotice_DesiredAttackPowerChanged(Single i_i_fLevel) => ((delegate* unmanaged[Cdecl]<Single, Byte>)0x006AAE60)(i_i_fLevel); // .text:006A9F00 ; bool __cdecl CM_Combat::SendNotice_DesiredAttackPowerChanged(float i_i_fLevel) .text:006A9F00 ?SendNotice_DesiredAttackPowerChanged@CM_Combat@@YA_NM@Z

        // CM_Combat.Event_CancelAttack:
        public static Byte Event_CancelAttack() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AA940)(); // .text:006A99E0 ; bool __cdecl CM_Combat::Event_CancelAttack() .text:006A99E0 ?Event_CancelAttack@CM_Combat@@YA_NXZ

        // CM_Combat.Event_QueryHealth:
        public static Byte Event_QueryHealth(UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AAAA0)(i_target); // .text:006A9B40 ; bool __cdecl CM_Combat::Event_QueryHealth(unsigned int i_target) .text:006A9B40 ?Event_QueryHealth@CM_Combat@@YA_NK@Z

        // CM_Combat.SendNotice_AttackHeightChanged:
        public static Byte SendNotice_AttackHeightChanged(ATTACK_HEIGHT i_i_height) => ((delegate* unmanaged[Cdecl]<ATTACK_HEIGHT, Byte>)0x006AAE10)(i_i_height); // .text:006A9EB0 ; bool __cdecl CM_Combat::SendNotice_AttackHeightChanged(ATTACK_HEIGHT i_i_height) .text:006A9EB0 ?SendNotice_AttackHeightChanged@CM_Combat@@YA_NW4ATTACK_HEIGHT@@@Z
    }
    public unsafe struct CM_Vendor {

        // Functions:

        // CM_Vendor.SendNotice_AddItemToSell:
        public static Byte SendNotice_AddItemToSell(UInt32 i_itemID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AB180)(i_itemID); // .text:006AA220 ; bool __cdecl CM_Vendor::SendNotice_AddItemToSell(unsigned int i_itemID) .text:006AA220 ?SendNotice_AddItemToSell@CM_Vendor@@YA_NK@Z

        // CM_Vendor.SendNotice_CloseVendor:
        public static Byte SendNotice_CloseVendor(Byte i_bUpdating) => ((delegate* unmanaged[Cdecl]<Byte, Byte>)0x006AB1D0)(i_bUpdating); // .text:006AA270 ; bool __cdecl CM_Vendor::SendNotice_CloseVendor(bool i_bUpdating) .text:006AA270 ?SendNotice_CloseVendor@CM_Vendor@@YA_N_N@Z

        // CM_Vendor.SendNotice_OpenVendor:
        public static Byte SendNotice_OpenVendor(UInt32 i_vendorID, VendorProfile* i_vendorProfile, PackableList<ItemProfile>* i_itemProfileList, ShopMode i_startMode) => ((delegate* unmanaged[Cdecl]<UInt32, VendorProfile*, PackableList<ItemProfile>*, ShopMode, Byte>)0x006AB220)(i_vendorID, i_vendorProfile, i_itemProfileList, i_startMode); // .text:006AA2C0 ; bool __cdecl CM_Vendor::SendNotice_OpenVendor(unsigned int i_vendorID, VendorProfile *i_vendorProfile, PackableList<ItemProfile> *i_itemProfileList, ShopMode i_startMode) .text:006AA2C0 ?SendNotice_OpenVendor@CM_Vendor@@YA_NKABVVendorProfile@@ABV?$PackableList@VItemProfile@@@@W4ShopMode@@@Z

        // CM_Vendor.Event_Sell:
        public static Byte Event_Sell(UInt32 i_vendorID, PackableList<ItemProfile>* i_stuff) => ((delegate* unmanaged[Cdecl]<UInt32, PackableList<ItemProfile>*, Byte>)0x006AAF60)(i_vendorID, i_stuff); // .text:006AA000 ; bool __cdecl CM_Vendor::Event_Sell(unsigned int i_vendorID, PackableList<ItemProfile> *i_stuff) .text:006AA000 ?Event_Sell@CM_Vendor@@YA_NKABV?$PackableList@VItemProfile@@@@@Z

        // CM_Vendor.Event_Buy:
        public static Byte Event_Buy(UInt32 i_vendorID, PackableList<ItemProfile>* i_stuff, UInt32 i_alternateCurrencyID) => ((delegate* unmanaged[Cdecl]<UInt32, PackableList<ItemProfile>*, UInt32, Byte>)0x006AB050)(i_vendorID, i_stuff, i_alternateCurrencyID); // .text:006AA0F0 ; bool __cdecl CM_Vendor::Event_Buy(unsigned int i_vendorID, PackableList<ItemProfile> *i_stuff, IDClass<_tagDataID,32,0> i_alternateCurrencyID) .text:006AA0F0 ?Event_Buy@CM_Vendor@@YA_NKABV?$PackableList@VItemProfile@@@@V?$IDClass@U_tagDataID@@$0CA@$0A@@@@Z
    }
    public unsafe struct CM_House {

        // Functions:

        // CM_House.DispatchUI_Recv_HouseTransaction:
        public static UInt32 DispatchUI_Recv_HouseTransaction(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AB2B0)(ui, buf, size); // .text:006AA350 ; unsigned int __cdecl CM_House::DispatchUI_Recv_HouseTransaction(UIQueueManager *ui, void *buf, unsigned int size) .text:006AA350 ?DispatchUI_Recv_HouseTransaction@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.Event_ListAvailableHouses:
        public static Byte Event_ListAvailableHouses(UInt32 i_houseType) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AB6F0)(i_houseType); // .text:006AA790 ; bool __cdecl CM_House::Event_ListAvailableHouses(unsigned int i_houseType) .text:006AA790 ?Event_ListAvailableHouses@CM_House@@YA_NK@Z

        // CM_House.Event_BootSpecificHouseGuest_Event:
        public static Byte Event_BootSpecificHouseGuest_Event(AC1Legacy.PStringBase<char>* i_guest_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006AC280)(i_guest_name); // .text:006AB320 ; bool __cdecl CM_House::Event_BootSpecificHouseGuest_Event(AC1Legacy::PStringBase<char> *i_guest_name) .text:006AB320 ?Event_BootSpecificHouseGuest_Event@CM_House@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_House.DispatchUI_Recv_UpdateHAR:
        public static UInt32 DispatchUI_Recv_UpdateHAR(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AB2E0)(ui, buf, size); // .text:006AA380 ; unsigned int __cdecl CM_House::DispatchUI_Recv_UpdateHAR(UIQueueManager *ui, void *buf, unsigned int size) .text:006AA380 ?DispatchUI_Recv_UpdateHAR@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.SendNotice_UpdateRentPayment:
        public static Byte SendNotice_UpdateRentPayment(HousePaymentList* i_rent) => ((delegate* unmanaged[Cdecl]<HousePaymentList*, Byte>)0x006AC120)(i_rent); // .text:006AB1C0 ; bool __cdecl CM_House::SendNotice_UpdateRentPayment(HousePaymentList *i_rent) .text:006AB1C0 ?SendNotice_UpdateRentPayment@CM_House@@YA_NABVHousePaymentList@@@Z

        // CM_House.DispatchUI_Recv_UpdateRentTime:
        public static UInt32 DispatchUI_Recv_UpdateRentTime(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AB360)(ui, buf, size); // .text:006AA400 ; unsigned int __cdecl CM_House::DispatchUI_Recv_UpdateRentTime(UIQueueManager *ui, void *buf, unsigned int size) .text:006AA400 ?DispatchUI_Recv_UpdateRentTime@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.Event_BootEveryone_Event:
        public static Byte Event_BootEveryone_Event() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AB570)(); // .text:006AA610 ; bool __cdecl CM_House::Event_BootEveryone_Event() .text:006AA610 ?Event_BootEveryone_Event@CM_House@@YA_NXZ

        // CM_House.Event_RemoveAllStoragePermission:
        public static Byte Event_RemoveAllStoragePermission() => ((delegate* unmanaged[Cdecl]<Byte>)0x006ABB50)(); // .text:006AABF0 ; bool __cdecl CM_House::Event_RemoveAllStoragePermission() .text:006AABF0 ?Event_RemoveAllStoragePermission@CM_House@@YA_NXZ

        // CM_House.DispatchUI_Recv_AvailableHouses:
        public static UInt32 DispatchUI_Recv_AvailableHouses(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AC500)(ui, buf, size); // .text:006AB5A0 ; unsigned int __cdecl CM_House::DispatchUI_Recv_AvailableHouses(UIQueueManager *ui, void *buf, unsigned int size) .text:006AB5A0 ?DispatchUI_Recv_AvailableHouses@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.Event_AddAllStoragePermission:
        public static Byte Event_AddAllStoragePermission() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AB4E0)(); // .text:006AA580 ; bool __cdecl CM_House::Event_AddAllStoragePermission() .text:006AA580 ?Event_AddAllStoragePermission@CM_House@@YA_NXZ

        // CM_House.Event_ModifyAllegianceStoragePermission:
        public static Byte Event_ModifyAllegianceStoragePermission(int i_add) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006AB890)(i_add); // .text:006AA930 ; bool __cdecl CM_House::Event_ModifyAllegianceStoragePermission(int i_add) .text:006AA930 ?Event_ModifyAllegianceStoragePermission@CM_House@@YA_NH@Z

        // CM_House.Event_RentHouse:
        public static Byte Event_RentHouse(UInt32 i_slumlord, PackableList<UInt32>* i_stuff) => ((delegate* unmanaged[Cdecl]<UInt32, PackableList<UInt32>*, Byte>)0x006ABBE0)(i_slumlord, i_stuff); // .text:006AAC80 ; bool __cdecl CM_House::Event_RentHouse(unsigned int i_slumlord, PackableList<unsigned long> *i_stuff) .text:006AAC80 ?Event_RentHouse@CM_House@@YA_NKABV?$PackableList@K@@@Z

        // CM_House.SendNotice_UpdateHouseData:
        public static Byte SendNotice_UpdateHouseData(HouseData* i_houseData) => ((delegate* unmanaged[Cdecl]<HouseData*, Byte>)0x006AC070)(i_houseData); // .text:006AB110 ; bool __cdecl CM_House::SendNotice_UpdateHouseData(HouseData *i_houseData) .text:006AB110 ?SendNotice_UpdateHouseData@CM_House@@YA_NABVHouseData@@@Z

        // CM_House.SendNotice_UpdateRentTime:
        public static Byte SendNotice_UpdateRentTime(int i_rentTime) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006AC170)(i_rentTime); // .text:006AB210 ; bool __cdecl CM_House::SendNotice_UpdateRentTime(int i_rentTime) .text:006AB210 ?SendNotice_UpdateRentTime@CM_House@@YA_NJ@Z

        // CM_House.DispatchUI_Recv_HouseData:
        public static UInt32 DispatchUI_Recv_HouseData(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AC700)(ui, buf, size); // .text:006AB7A0 ; unsigned int __cdecl CM_House::DispatchUI_Recv_HouseData(UIQueueManager *ui, void *buf, unsigned int size) .text:006AB7A0 ?DispatchUI_Recv_HouseData@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.Event_RemoveAllPermanentGuests_Event:
        public static Byte Event_RemoveAllPermanentGuests_Event() => ((delegate* unmanaged[Cdecl]<Byte>)0x006ABAC0)(); // .text:006AAB60 ; bool __cdecl CM_House::Event_RemoveAllPermanentGuests_Event() .text:006AAB60 ?Event_RemoveAllPermanentGuests_Event@CM_House@@YA_NXZ

        // CM_House.Event_SetHooksVisibility:
        public static Byte Event_SetHooksVisibility(int i_bVisible) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006ABD60)(i_bVisible); // .text:006AAE00 ; bool __cdecl CM_House::Event_SetHooksVisibility(int i_bVisible) .text:006AAE00 ?Event_SetHooksVisibility@CM_House@@YA_NH@Z

        // CM_House.DispatchUI_Recv_HouseStatus:
        public static UInt32 DispatchUI_Recv_HouseStatus(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AB280)(ui, buf, size); // .text:006AA320 ; unsigned int __cdecl CM_House::DispatchUI_Recv_HouseStatus(UIQueueManager *ui, void *buf, unsigned int size) .text:006AA320 ?DispatchUI_Recv_HouseStatus@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.DispatchUI_Recv_UpdateRestrictions:
        public static UInt32 DispatchUI_Recv_UpdateRestrictions(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AB390)(ui, buf, size); // .text:006AA430 ; unsigned int __cdecl CM_House::DispatchUI_Recv_UpdateRestrictions(UIQueueManager *ui, void *buf, unsigned int size) .text:006AA430 ?DispatchUI_Recv_UpdateRestrictions@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.Event_AbandonHouse:
        public static Byte Event_AbandonHouse() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AB450)(); // .text:006AA4F0 ; bool __cdecl CM_House::Event_AbandonHouse() .text:006AA4F0 ?Event_AbandonHouse@CM_House@@YA_NXZ

        // CM_House.Event_ModifyAllegianceGuestPermission:
        public static Byte Event_ModifyAllegianceGuestPermission(int i_add) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006AB7C0)(i_add); // .text:006AA860 ; bool __cdecl CM_House::Event_ModifyAllegianceGuestPermission(int i_add) .text:006AA860 ?Event_ModifyAllegianceGuestPermission@CM_House@@YA_NH@Z

        // CM_House.Event_QueryHouse:
        public static Byte Event_QueryHouse() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AB960)(); // .text:006AAA00 ; bool __cdecl CM_House::Event_QueryHouse() .text:006AAA00 ?Event_QueryHouse@CM_House@@YA_NXZ

        // CM_House.Event_QueryLord:
        public static Byte Event_QueryLord(UInt32 i_lord) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AB9F0)(i_lord); // .text:006AAA90 ; bool __cdecl CM_House::Event_QueryLord(unsigned int i_lord) .text:006AAA90 ?Event_QueryLord@CM_House@@YA_NK@Z

        // CM_House.Event_AddPermanentGuest_Event:
        public static Byte Event_AddPermanentGuest_Event(AC1Legacy.PStringBase<char>* i_guest_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006AC1C0)(i_guest_name); // .text:006AB260 ; bool __cdecl CM_House::Event_AddPermanentGuest_Event(AC1Legacy::PStringBase<char> *i_guest_name) .text:006AB260 ?Event_AddPermanentGuest_Event@CM_House@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_House.Event_RequestFullGuestList_Event:
        public static Byte Event_RequestFullGuestList_Event() => ((delegate* unmanaged[Cdecl]<Byte>)0x006ABCD0)(); // .text:006AAD70 ; bool __cdecl CM_House::Event_RequestFullGuestList_Event() .text:006AAD70 ?Event_RequestFullGuestList_Event@CM_House@@YA_NXZ

        // CM_House.Event_TeleToHouse_Event:
        public static Byte Event_TeleToHouse_Event() => ((delegate* unmanaged[Cdecl]<Byte>)0x006ABF00)(); // .text:006AAFA0 ; bool __cdecl CM_House::Event_TeleToHouse_Event() .text:006AAFA0 ?Event_TeleToHouse_Event@CM_House@@YA_NXZ

        // CM_House.Event_TeleToMansion_Event:
        public static Byte Event_TeleToMansion_Event() => ((delegate* unmanaged[Cdecl]<Byte>)0x006ABF90)(); // .text:006AB030 ; bool __cdecl CM_House::Event_TeleToMansion_Event() .text:006AB030 ?Event_TeleToMansion_Event@CM_House@@YA_NXZ

        // CM_House.SendNotice_FailedHouseTransaction:
        public static Byte SendNotice_FailedHouseTransaction(UInt32 i_eType) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AC020)(i_eType); // .text:006AB0C0 ; bool __cdecl CM_House::SendNotice_FailedHouseTransaction(unsigned int i_eType) .text:006AB0C0 ?SendNotice_FailedHouseTransaction@CM_House@@YA_NK@Z

        // CM_House.Event_ChangeStoragePermission_Event:
        public static Byte Event_ChangeStoragePermission_Event(AC1Legacy.PStringBase<char>* i_guest_name, int i_has_permission) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, int, Byte>)0x006AC340)(i_guest_name, i_has_permission); // .text:006AB3E0 ; bool __cdecl CM_House::Event_ChangeStoragePermission_Event(AC1Legacy::PStringBase<char> *i_guest_name, int i_has_permission) .text:006AB3E0 ?Event_ChangeStoragePermission_Event@CM_House@@YA_NABV?$PStringBase@D@AC1Legacy@@H@Z

        // CM_House.Event_RemovePermanentGuest_Event:
        public static Byte Event_RemovePermanentGuest_Event(AC1Legacy.PStringBase<char>* i_guest_name) => ((delegate* unmanaged[Cdecl]<AC1Legacy.PStringBase<char>*, Byte>)0x006AC440)(i_guest_name); // .text:006AB4E0 ; bool __cdecl CM_House::Event_RemovePermanentGuest_Event(AC1Legacy::PStringBase<char> *i_guest_name) .text:006AB4E0 ?Event_RemovePermanentGuest_Event@CM_House@@YA_NABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_House.Event_BuyHouse:
        public static Byte Event_BuyHouse(UInt32 i_slumlord, PackableList<UInt32>* i_stuff) => ((delegate* unmanaged[Cdecl]<UInt32, PackableList<UInt32>*, Byte>)0x006AB600)(i_slumlord, i_stuff); // .text:006AA6A0 ; bool __cdecl CM_House::Event_BuyHouse(unsigned int i_slumlord, PackableList<unsigned long> *i_stuff) .text:006AA6A0 ?Event_BuyHouse@CM_House@@YA_NKABV?$PackableList@K@@@Z

        // CM_House.Event_SetOpenHouseStatus_Event:
        public static Byte Event_SetOpenHouseStatus_Event(int i_open_house) => ((delegate* unmanaged[Cdecl]<int, Byte>)0x006ABE30)(i_open_house); // .text:006AAED0 ; bool __cdecl CM_House::Event_SetOpenHouseStatus_Event(int i_open_house) .text:006AAED0 ?Event_SetOpenHouseStatus_Event@CM_House@@YA_NH@Z

        // CM_House.SendNotice_UpdateHouseProfile:
        public static Byte SendNotice_UpdateHouseProfile(UInt32 i_iidOwner, HouseProfile* i_prof) => ((delegate* unmanaged[Cdecl]<UInt32, HouseProfile*, Byte>)0x006AC0C0)(i_iidOwner, i_prof); // .text:006AB160 ; bool __cdecl CM_House::SendNotice_UpdateHouseProfile(unsigned int i_iidOwner, HouseProfile *i_prof) .text:006AB160 ?SendNotice_UpdateHouseProfile@CM_House@@YA_NKABVHouseProfile@@@Z

        // CM_House.DispatchUI_Recv_HouseProfile:
        public static UInt32 DispatchUI_Recv_HouseProfile(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AC5E0)(ui, buf, size); // .text:006AB680 ; unsigned int __cdecl CM_House::DispatchUI_Recv_HouseProfile(UIQueueManager *ui, void *buf, unsigned int size) .text:006AB680 ?DispatchUI_Recv_HouseProfile@CM_House@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_House.DispatchUI_Recv_UpdateRentPayment:
        public static UInt32 DispatchUI_Recv_UpdateRentPayment(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AC670)(ui, buf, size); // .text:006AB710 ; unsigned int __cdecl CM_House::DispatchUI_Recv_UpdateRentPayment(UIQueueManager *ui, void *buf, unsigned int size) .text:006AB710 ?DispatchUI_Recv_UpdateRentPayment@CM_House@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Inventory {

        // Functions:

        // CM_Inventory.Event_CreateTinkeringTool:
        public static Byte Event_CreateTinkeringTool(UInt32 i_toolID, PackableList<UInt32>* i_gems) => ((delegate* unmanaged[Cdecl]<UInt32, PackableList<UInt32>*, Byte>)0x006AC790)(i_toolID, i_gems); // .text:006AB830 ; bool __cdecl CM_Inventory::Event_CreateTinkeringTool(unsigned int i_toolID, PackableList<unsigned long> *i_gems) .text:006AB830 ?Event_CreateTinkeringTool@CM_Inventory@@YA_NKABV?$PackableList@K@@@Z

        // CM_Inventory.Event_DropItem:
        public static Byte Event_DropItem(UInt32 i_item) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AC880)(i_item); // .text:006AB920 ; bool __cdecl CM_Inventory::Event_DropItem(unsigned int i_item) .text:006AB920 ?Event_DropItem@CM_Inventory@@YA_NK@Z

        // CM_Inventory.Event_GetAndWieldItem:
        public static Byte Event_GetAndWieldItem(UInt32 i_item, UInt32 i_loc) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006AC950)(i_item, i_loc); // .text:006AB9F0 ; bool __cdecl CM_Inventory::Event_GetAndWieldItem(unsigned int i_item, unsigned int i_loc) .text:006AB9F0 ?Event_GetAndWieldItem@CM_Inventory@@YA_NKK@Z

        // CM_Inventory.Event_StackableMerge:
        public static Byte Event_StackableMerge(UInt32 i_mergeFromID, UInt32 i_mergeToID, int i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, int, Byte>)0x006ACDD0)(i_mergeFromID, i_mergeToID, i_amount); // .text:006ABE70 ; bool __cdecl CM_Inventory::Event_StackableMerge(unsigned int i_mergeFromID, unsigned int i_mergeToID, int i_amount) .text:006ABE70 ?Event_StackableMerge@CM_Inventory@@YA_NKKJ@Z

        // CM_Inventory.Event_StackableSplitTo3D:
        public static Byte Event_StackableSplitTo3D(UInt32 i_stackID, int i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, int, Byte>)0x006ACF20)(i_stackID, i_amount); // .text:006ABFC0 ; bool __cdecl CM_Inventory::Event_StackableSplitTo3D(unsigned int i_stackID, int i_amount) .text:006ABFC0 ?Event_StackableSplitTo3D@CM_Inventory@@YA_NKJ@Z

        // CM_Inventory.DispatchUI_Recv_SalvageOperationsResultData:
        public static UInt32 DispatchUI_Recv_SalvageOperationsResultData(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AD580)(ui, buf, size); // .text:006AC620 ; unsigned int __cdecl CM_Inventory::DispatchUI_Recv_SalvageOperationsResultData(UIQueueManager *ui, void *buf, unsigned int size) .text:006AC620 ?DispatchUI_Recv_SalvageOperationsResultData@CM_Inventory@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Inventory.Event_StackableSplitToWield:
        public static Byte Event_StackableSplitToWield(UInt32 i_stackID, UInt32 i_loc, int i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, int, Byte>)0x006AD1C0)(i_stackID, i_loc, i_amount); // .text:006AC260 ; bool __cdecl CM_Inventory::Event_StackableSplitToWield(unsigned int i_stackID, unsigned int i_loc, int i_amount) .text:006AC260 ?Event_StackableSplitToWield@CM_Inventory@@YA_NKKJ@Z

        // CM_Inventory.Event_UseEvent:
        public static Byte Event_UseEvent(UInt32 i_object) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AD310)(i_object); // .text:006AC3B0 ; bool __cdecl CM_Inventory::Event_UseEvent(unsigned int i_object) .text:006AC3B0 ?Event_UseEvent@CM_Inventory@@YA_NK@Z

        // CM_Inventory.Event_UseWithTargetEvent:
        public static Byte Event_UseWithTargetEvent(UInt32 i_object, UInt32 i_target) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006AD3E0)(i_object, i_target); // .text:006AC480 ; bool __cdecl CM_Inventory::Event_UseWithTargetEvent(unsigned int i_object, unsigned int i_target) .text:006AC480 ?Event_UseWithTargetEvent@CM_Inventory@@YA_NKK@Z

        // CM_Inventory.SendNotice_OpenSalvagePanel:
        public static Byte SendNotice_OpenSalvagePanel(UInt32 i_toolID) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AD4F0)(i_toolID); // .text:006AC590 ; bool __cdecl CM_Inventory::SendNotice_OpenSalvagePanel(unsigned int i_toolID) .text:006AC590 ?SendNotice_OpenSalvagePanel@CM_Inventory@@YA_NK@Z

        // CM_Inventory.Event_GiveObjectRequest:
        public static Byte Event_GiveObjectRequest(UInt32 i_targetID, UInt32 i_objectID, UInt32 i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, Byte>)0x006ACA60)(i_targetID, i_objectID, i_amount); // .text:006ABB00 ; bool __cdecl CM_Inventory::Event_GiveObjectRequest(unsigned int i_targetID, unsigned int i_objectID, unsigned int i_amount) .text:006ABB00 ?Event_GiveObjectRequest@CM_Inventory@@YA_NKKK@Z

        // CM_Inventory.Event_NoLongerViewingContents:
        public static Byte Event_NoLongerViewingContents(UInt32 i_container) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006ACBB0)(i_container); // .text:006ABC50 ; bool __cdecl CM_Inventory::Event_NoLongerViewingContents(unsigned int i_container) .text:006ABC50 ?Event_NoLongerViewingContents@CM_Inventory@@YA_NK@Z

        // CM_Inventory.Event_PutItemInContainer:
        public static Byte Event_PutItemInContainer(UInt32 i_item, UInt32 i_container, UInt32 i_loc) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, Byte>)0x006ACC80)(i_item, i_container, i_loc); // .text:006ABD20 ; bool __cdecl CM_Inventory::Event_PutItemInContainer(unsigned int i_item, unsigned int i_container, unsigned int i_loc) .text:006ABD20 ?Event_PutItemInContainer@CM_Inventory@@YA_NKKK@Z

        // CM_Inventory.Event_StackableSplitToContainer:
        public static Byte Event_StackableSplitToContainer(UInt32 i_stackID, UInt32 i_containerID, int i_place, int i_amount) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, int, int, Byte>)0x006AD030)(i_stackID, i_containerID, i_place, i_amount); // .text:006AC0D0 ; bool __cdecl CM_Inventory::Event_StackableSplitToContainer(unsigned int i_stackID, unsigned int i_containerID, int i_place, int i_amount) .text:006AC0D0 ?Event_StackableSplitToContainer@CM_Inventory@@YA_NKKJJ@Z
    }
    public unsafe struct CM_Physics {

        // Functions:

        // CM_Physics.DispatchSB_PickupEvent:
        public static NetBlobProcessedStatus DispatchSB_PickupEvent(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006ADB10)(smartbox, blob); // .text:006ACBB0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_PickupEvent(SmartBox *smartbox, NetBlob *blob) .text:006ACBB0 ?DispatchSB_PickupEvent@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_PlayScriptID:
        public static NetBlobProcessedStatus DispatchSB_PlayScriptID(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006ADBA0)(smartbox, blob); // .text:006ACC40 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_PlayScriptID(SmartBox *smartbox, NetBlob *blob) .text:006ACC40 ?DispatchSB_PlayScriptID@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_PlayScriptType:
        public static NetBlobProcessedStatus DispatchSB_PlayScriptType(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD640)(smartbox, blob); // .text:006AC6E0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_PlayScriptType(SmartBox *smartbox, NetBlob *blob) .text:006AC6E0 ?DispatchSB_PlayScriptType@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_PlayerTeleport:
        public static NetBlobProcessedStatus DispatchSB_PlayerTeleport(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD690)(smartbox, blob); // .text:006AC730 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_PlayerTeleport(SmartBox *smartbox, NetBlob *blob) .text:006AC730 ?DispatchSB_PlayerTeleport@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_ParentEvent:
        public static NetBlobProcessedStatus DispatchSB_ParentEvent(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006ADA50)(smartbox, blob); // .text:006ACAF0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_ParentEvent(SmartBox *smartbox, NetBlob *blob) .text:006ACAF0 ?DispatchSB_ParentEvent@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_CreateObject:
        public static NetBlobProcessedStatus DispatchSB_CreateObject(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD830)(smartbox, blob); // .text:006AC8D0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_CreateObject(SmartBox *smartbox, NetBlob *blob) .text:006AC8D0 ?DispatchSB_CreateObject@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_CreatePlayer:
        public static NetBlobProcessedStatus DispatchSB_CreatePlayer(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD950)(smartbox, blob); // .text:006AC9F0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_CreatePlayer(SmartBox *smartbox, NetBlob *blob) .text:006AC9F0 ?DispatchSB_CreatePlayer@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_ObjDescEvent:
        public static NetBlobProcessedStatus DispatchSB_ObjDescEvent(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD980)(smartbox, blob); // .text:006ACA20 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_ObjDescEvent(SmartBox *smartbox, NetBlob *blob) .text:006ACA20 ?DispatchSB_ObjDescEvent@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_SetState:
        public static NetBlobProcessedStatus DispatchSB_SetState(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006ADBE0)(smartbox, blob); // .text:006ACC80 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_SetState(SmartBox *smartbox, NetBlob *blob) .text:006ACC80 ?DispatchSB_SetState@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_VectorUpdate:
        public static NetBlobProcessedStatus DispatchSB_VectorUpdate(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006ADC80)(smartbox, blob); // .text:006ACD20 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_VectorUpdate(SmartBox *smartbox, NetBlob *blob) .text:006ACD20 ?DispatchSB_VectorUpdate@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_DeleteObject:
        public static NetBlobProcessedStatus DispatchSB_DeleteObject(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD600)(smartbox, blob); // .text:006AC6A0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_DeleteObject(SmartBox *smartbox, NetBlob *blob) .text:006AC6A0 ?DispatchSB_DeleteObject@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_SoundEvent:
        public static NetBlobProcessedStatus DispatchSB_SoundEvent(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD6C0)(smartbox, blob); // .text:006AC760 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_SoundEvent(SmartBox *smartbox, NetBlob *blob) .text:006AC760 ?DispatchSB_SoundEvent@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z

        // CM_Physics.DispatchSB_UpdateObject:
        public static NetBlobProcessedStatus DispatchSB_UpdateObject(SmartBox* smartbox, NetBlob* blob) => ((delegate* unmanaged[Cdecl]<SmartBox*, NetBlob*, NetBlobProcessedStatus>)0x006AD710)(smartbox, blob); // .text:006AC7B0 ; NetBlobProcessedStatus __cdecl CM_Physics::DispatchSB_UpdateObject(SmartBox *smartbox, NetBlob *blob) .text:006AC7B0 ?DispatchSB_UpdateObject@CM_Physics@@YA?AW4NetBlobProcessedStatus@@PAVSmartBox@@PAVNetBlob@@@Z
    }
    public unsafe struct CM_Trade {

        // Functions:

        // CM_Trade.DispatchUI_Recv_CloseTrade:
        public static UInt32 DispatchUI_Recv_CloseTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADDF0)(ui, buf, size); // .text:006ACE90 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_CloseTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACE90 ?DispatchUI_Recv_CloseTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.DispatchUI_Recv_RegisterTrade:
        public static UInt32 DispatchUI_Recv_RegisterTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADE80)(ui, buf, size); // .text:006ACF20 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_RegisterTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACF20 ?DispatchUI_Recv_RegisterTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.SendNotice_DeclineTrade:
        public static Byte SendNotice_DeclineTrade(UInt32 i_source) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE510)(i_source); // .text:006AD5B0 ; bool __cdecl CM_Trade::SendNotice_DeclineTrade(unsigned int i_source) .text:006AD5B0 ?SendNotice_DeclineTrade@CM_Trade@@YA_NK@Z

        // CM_Trade.DispatchUI_Recv_AddToTrade:
        public static UInt32 DispatchUI_Recv_AddToTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADD80)(ui, buf, size); // .text:006ACE20 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_AddToTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACE20 ?DispatchUI_Recv_AddToTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.SendNotice_CloseTrade:
        public static Byte SendNotice_CloseTrade(UInt32 i_etype) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE4C0)(i_etype); // .text:006AD560 ; bool __cdecl CM_Trade::SendNotice_CloseTrade(unsigned int i_etype) .text:006AD560 ?SendNotice_CloseTrade@CM_Trade@@YA_NK@Z

        // CM_Trade.SendNotice_TradeAnItemForDummies:
        public static Byte SendNotice_TradeAnItemForDummies(UInt32 i_iidObject) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE6C0)(i_iidObject); // .text:006AD760 ; bool __cdecl CM_Trade::SendNotice_TradeAnItemForDummies(unsigned int i_iidObject) .text:006AD760 ?SendNotice_TradeAnItemForDummies@CM_Trade@@YA_NK@Z

        // CM_Trade.DispatchUI_Recv_AcceptTrade:
        public static UInt32 DispatchUI_Recv_AcceptTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADD50)(ui, buf, size); // .text:006ACDF0 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_AcceptTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACDF0 ?DispatchUI_Recv_AcceptTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.DispatchUI_Recv_OpenTrade:
        public static UInt32 DispatchUI_Recv_OpenTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADE50)(ui, buf, size); // .text:006ACEF0 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_OpenTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACEF0 ?DispatchUI_Recv_OpenTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.Event_AddToTrade:
        public static Byte Event_AddToTrade(UInt32 i_item, UInt32 i_loc) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006AE030)(i_item, i_loc); // .text:006AD0D0 ; bool __cdecl CM_Trade::Event_AddToTrade(unsigned int i_item, unsigned int i_loc) .text:006AD0D0 ?Event_AddToTrade@CM_Trade@@YA_NKK@Z

        // CM_Trade.Event_DeclineTrade:
        public static Byte Event_DeclineTrade() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AE1D0)(); // .text:006AD270 ; bool __cdecl CM_Trade::Event_DeclineTrade() .text:006AD270 ?Event_DeclineTrade@CM_Trade@@YA_NXZ

        // CM_Trade.Event_ResetTrade:
        public static Byte Event_ResetTrade() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AE330)(); // .text:006AD3D0 ; bool __cdecl CM_Trade::Event_ResetTrade() .text:006AD3D0 ?Event_ResetTrade@CM_Trade@@YA_NXZ

        // CM_Trade.DispatchUI_Recv_ClearTradeAcceptance:
        public static UInt32 DispatchUI_Recv_ClearTradeAcceptance(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADDC0)(ui, buf, size); // .text:006ACE60 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_ClearTradeAcceptance(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACE60 ?DispatchUI_Recv_ClearTradeAcceptance@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.DispatchUI_Recv_RemoveFromTrade:
        public static UInt32 DispatchUI_Recv_RemoveFromTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADEE0)(ui, buf, size); // .text:006ACF80 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_RemoveFromTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACF80 ?DispatchUI_Recv_RemoveFromTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.DispatchUI_Recv_DeclineTrade:
        public static UInt32 DispatchUI_Recv_DeclineTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADE20)(ui, buf, size); // .text:006ACEC0 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_DeclineTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACEC0 ?DispatchUI_Recv_DeclineTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.Event_OpenTradeNegotiations:
        public static Byte Event_OpenTradeNegotiations(UInt32 i_other) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE260)(i_other); // .text:006AD300 ; bool __cdecl CM_Trade::Event_OpenTradeNegotiations(unsigned int i_other) .text:006AD300 ?Event_OpenTradeNegotiations@CM_Trade@@YA_NK@Z

        // CM_Trade.SendNotice_AcceptTrade:
        public static Byte SendNotice_AcceptTrade(UInt32 i_source) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE3C0)(i_source); // .text:006AD460 ; bool __cdecl CM_Trade::SendNotice_AcceptTrade(unsigned int i_source) .text:006AD460 ?SendNotice_AcceptTrade@CM_Trade@@YA_NK@Z

        // CM_Trade.SendNotice_TradeFailure:
        public static Byte SendNotice_TradeFailure(UInt32 i_item, UInt32 i_etype) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006AE710)(i_item, i_etype); // .text:006AD7B0 ; bool __cdecl CM_Trade::SendNotice_TradeFailure(unsigned int i_item, unsigned int i_etype) .text:006AD7B0 ?SendNotice_TradeFailure@CM_Trade@@YA_NKK@Z

        // CM_Trade.DispatchUI_Recv_TradeFailure:
        public static UInt32 DispatchUI_Recv_TradeFailure(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADF40)(ui, buf, size); // .text:006ACFE0 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_TradeFailure(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACFE0 ?DispatchUI_Recv_TradeFailure@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.Event_CloseTradeNegotiations:
        public static Byte Event_CloseTradeNegotiations() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AE140)(); // .text:006AD1E0 ; bool __cdecl CM_Trade::Event_CloseTradeNegotiations() .text:006AD1E0 ?Event_CloseTradeNegotiations@CM_Trade@@YA_NXZ

        // CM_Trade.SendNotice_OpenTrade:
        public static Byte SendNotice_OpenTrade(UInt32 i_source) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE560)(i_source); // .text:006AD600 ; bool __cdecl CM_Trade::SendNotice_OpenTrade(unsigned int i_source) .text:006AD600 ?SendNotice_OpenTrade@CM_Trade@@YA_NK@Z

        // CM_Trade.SendNotice_ResetTrade:
        public static Byte SendNotice_ResetTrade(UInt32 i_source) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006AE670)(i_source); // .text:006AD710 ; bool __cdecl CM_Trade::SendNotice_ResetTrade(unsigned int i_source) .text:006AD710 ?SendNotice_ResetTrade@CM_Trade@@YA_NK@Z

        // CM_Trade.SendNotice_AddItemToTrade:
        public static Byte SendNotice_AddItemToTrade(UInt32 i_item, UInt32 i_id, UInt32 i_loc) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, UInt32, Byte>)0x006AE410)(i_item, i_id, i_loc); // .text:006AD4B0 ; bool __cdecl CM_Trade::SendNotice_AddItemToTrade(unsigned int i_item, unsigned int i_id, unsigned int i_loc) .text:006AD4B0 ?SendNotice_AddItemToTrade@CM_Trade@@YA_NKKK@Z

        // CM_Trade.SendNotice_RemoveItemFromTrade:
        public static Byte SendNotice_RemoveItemFromTrade(UInt32 i_item, UInt32 i_id) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Byte>)0x006AE610)(i_item, i_id); // .text:006AD6B0 ; bool __cdecl CM_Trade::SendNotice_RemoveItemFromTrade(unsigned int i_item, unsigned int i_id) .text:006AD6B0 ?SendNotice_RemoveItemFromTrade@CM_Trade@@YA_NKK@Z

        // CM_Trade.DispatchUI_Recv_ResetTrade:
        public static UInt32 DispatchUI_Recv_ResetTrade(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006ADF10)(ui, buf, size); // .text:006ACFB0 ; unsigned int __cdecl CM_Trade::DispatchUI_Recv_ResetTrade(UIQueueManager *ui, void *buf, unsigned int size) .text:006ACFB0 ?DispatchUI_Recv_ResetTrade@CM_Trade@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Trade.Event_AcceptTrade:
        public static Byte Event_AcceptTrade(Trade* i_stuff) => ((delegate* unmanaged[Cdecl]<Trade*, Byte>)0x006ADF70)(i_stuff); // .text:006AD010 ; bool __cdecl CM_Trade::Event_AcceptTrade(Trade *i_stuff) .text:006AD010 ?Event_AcceptTrade@CM_Trade@@YA_NABVTrade@@@Z

        // CM_Trade.SendNotice_ClearTradeAcceptance:
        public static Byte SendNotice_ClearTradeAcceptance() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AE470)(); // .text:006AD510 ; bool __cdecl CM_Trade::SendNotice_ClearTradeAcceptance() .text:006AD510 ?SendNotice_ClearTradeAcceptance@CM_Trade@@YA_NXZ

        // CM_Trade.SendNotice_RegisterTrade:
        public static Byte SendNotice_RegisterTrade(UInt32 i_initiator, UInt32 i_partner, Double i_stamp) => ((delegate* unmanaged[Cdecl]<UInt32, UInt32, Double, Byte>)0x006AE5B0)(i_initiator, i_partner, i_stamp); // .text:006AD650 ; bool __cdecl CM_Trade::SendNotice_RegisterTrade(unsigned int i_initiator, unsigned int i_partner, long double i_stamp) .text:006AD650 ?SendNotice_RegisterTrade@CM_Trade@@YA_NKKN@Z
    }
    public unsafe struct CM_Login {

        // Functions:

        // CM_Login.SendNotice_BeginEnterWorld:
        public static Byte SendNotice_BeginEnterWorld() => ((delegate* unmanaged[Cdecl]<Byte>)0x006AE770)(); // .text:006AD810 ; bool __cdecl CM_Login::SendNotice_BeginEnterWorld() .text:006AD810 ?SendNotice_BeginEnterWorld@CM_Login@@YA_NXZ

        // CM_Login.DispatchUI_WorldInfo:
        public static UInt32 DispatchUI_WorldInfo(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AE7C0)(ui, buf, size); // .text:006AD860 ; unsigned int __cdecl CM_Login::DispatchUI_WorldInfo(UIQueueManager *ui, void *buf, unsigned int size) .text:006AD860 ?DispatchUI_WorldInfo@CM_Login@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Admin {

        // Functions:

        // CM_Admin.DispatchUI_ReceivePlayerData:
        public static UInt32 DispatchUI_ReceivePlayerData(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF430)(ui, buf, size); // .text:006AE560 ; unsigned int __cdecl CM_Admin::DispatchUI_ReceivePlayerData(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE560 ?DispatchUI_ReceivePlayerData@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Admin.DispatchUI_Environs:
        public static UInt32 DispatchUI_Environs(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AE870)(ui, buf, size); // .text:006AD910 ; unsigned int __cdecl CM_Admin::DispatchUI_Environs(UIQueueManager *ui, void *buf, unsigned int size) .text:006AD910 ?DispatchUI_Environs@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Admin.DispatchUI_Recv_QueryPluginList:
        public static UInt32 DispatchUI_Recv_QueryPluginList(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AE8A0)(ui, buf, size); // .text:006AD940 ; unsigned int __cdecl CM_Admin::DispatchUI_Recv_QueryPluginList(UIQueueManager *ui, void *buf, unsigned int size) .text:006AD940 ?DispatchUI_Recv_QueryPluginList@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Admin.Event_QueryPluginListResponse:
        public static Byte Event_QueryPluginListResponse(UInt32 i_context, AC1Legacy.PStringBase<char>* i_pluginList) => ((delegate* unmanaged[Cdecl]<UInt32, AC1Legacy.PStringBase<char>*, Byte>)0x006AE970)(i_context, i_pluginList); // .text:006ADAA0 ; bool __cdecl CM_Admin::Event_QueryPluginListResponse(unsigned int i_context, AC1Legacy::PStringBase<char> *i_pluginList) .text:006ADAA0 ?Event_QueryPluginListResponse@CM_Admin@@YA_NKABV?$PStringBase@D@AC1Legacy@@@Z

        // CM_Admin.Event_QueryPluginResponse:
        public static Byte Event_QueryPluginResponse(UInt32 i_context, int i_success, AC1Legacy.PStringBase<char>* i_pluginName, AC1Legacy.PStringBase<char>* i_pluginAuthor, AC1Legacy.PStringBase<char>* i_pluginEMail, AC1Legacy.PStringBase<char>* i_pluginWebpage) => ((delegate* unmanaged[Cdecl]<UInt32, int, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, AC1Legacy.PStringBase<char>*, Byte>)0x006AEA60)(i_context, i_success, i_pluginName, i_pluginAuthor, i_pluginEMail, i_pluginWebpage); // .text:006ADB90 ; bool __cdecl CM_Admin::Event_QueryPluginResponse(unsigned int i_context, int i_success, AC1Legacy::PStringBase<char> *i_pluginName, AC1Legacy::PStringBase<char> *i_pluginAuthor, AC1Legacy::PStringBase<char> *i_pluginEMail, AC1Legacy::PStringBase<char> *i_pluginWebpage) .text:006ADB90 ?Event_QueryPluginResponse@CM_Admin@@YA_NKHABV?$PStringBase@D@AC1Legacy@@000@Z

        // CM_Admin.DispatchUI_Recv_QueryPlugin:
        public static UInt32 DispatchUI_Recv_QueryPlugin(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AEC70)(ui, buf, size); // .text:006ADDA0 ; unsigned int __cdecl CM_Admin::DispatchUI_Recv_QueryPlugin(UIQueueManager *ui, void *buf, unsigned int size) .text:006ADDA0 ?DispatchUI_Recv_QueryPlugin@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Admin.DispatchUI_Recv_QueryPluginResponse:
        public static UInt32 DispatchUI_Recv_QueryPluginResponse(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AED10)(ui, buf, size); // .text:006ADE40 ; unsigned int __cdecl CM_Admin::DispatchUI_Recv_QueryPluginResponse(UIQueueManager *ui, void *buf, unsigned int size) .text:006ADE40 ?DispatchUI_Recv_QueryPluginResponse@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Admin.DispatchUI_ReceiveAccountData:
        public static UInt32 DispatchUI_ReceiveAccountData(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF390)(ui, buf, size); // .text:006AE4C0 ; unsigned int __cdecl CM_Admin::DispatchUI_ReceiveAccountData(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE4C0 ?DispatchUI_ReceiveAccountData@CM_Admin@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Qualities {

        // Functions:

        // CM_Qualities.DispatchUI_PrivateRemoveBoolEvent:
        public static UInt32 DispatchUI_PrivateRemoveBoolEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF4D0)(ui, buf, size); // .text:006AE600 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveBoolEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE600 ?DispatchUI_PrivateRemoveBoolEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateBool:
        public static UInt32 DispatchUI_PrivateUpdateBool(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF880)(ui, buf, size); // .text:006AE9B0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateBool(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE9B0 ?DispatchUI_PrivateUpdateBool@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateBool:
        public static UInt32 DispatchUI_UpdateBool(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFF00)(ui, buf, size); // .text:006AF030 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateBool(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF030 ?DispatchUI_UpdateBool@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateInt64:
        public static UInt32 DispatchUI_UpdateInt64(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0050)(ui, buf, size); // .text:006AF180 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateInt64(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF180 ?DispatchUI_UpdateInt64@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateDataID:
        public static UInt32 DispatchUI_UpdateDataID(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B02C0)(ui, buf, size); // .text:006AF3F0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateDataID(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF3F0 ?DispatchUI_UpdateDataID@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveFloatEvent:
        public static UInt32 DispatchUI_PrivateRemoveFloatEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF550)(ui, buf, size); // .text:006AE680 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveFloatEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE680 ?DispatchUI_PrivateRemoveFloatEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateAttribute2ndLevel:
        public static UInt32 DispatchUI_PrivateUpdateAttribute2ndLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF800)(ui, buf, size); // .text:006AE930 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateAttribute2ndLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE930 ?DispatchUI_PrivateUpdateAttribute2ndLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveDataIDEvent:
        public static UInt32 DispatchUI_RemoveDataIDEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFB60)(ui, buf, size); // .text:006AEC90 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveDataIDEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEC90 ?DispatchUI_RemoveDataIDEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveFloatEvent:
        public static UInt32 DispatchUI_RemoveFloatEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFBA0)(ui, buf, size); // .text:006AECD0 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveFloatEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AECD0 ?DispatchUI_RemoveFloatEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveInt64Event:
        public static UInt32 DispatchUI_RemoveInt64Event(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFC20)(ui, buf, size); // .text:006AED50 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveInt64Event(UIQueueManager *ui, void *buf, unsigned int size) .text:006AED50 ?DispatchUI_RemoveInt64Event@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateAttribute:
        public static UInt32 DispatchUI_UpdateAttribute(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFD20)(ui, buf, size); // .text:006AEE50 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateAttribute(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEE50 ?DispatchUI_UpdateAttribute@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateSkill:
        public static UInt32 DispatchUI_UpdateSkill(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B00A0)(ui, buf, size); // .text:006AF1D0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateSkill(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF1D0 ?DispatchUI_UpdateSkill@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveStringEvent:
        public static UInt32 DispatchUI_PrivateRemoveStringEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF690)(ui, buf, size); // .text:006AE7C0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveStringEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE7C0 ?DispatchUI_PrivateRemoveStringEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateFloat:
        public static UInt32 DispatchUI_UpdateFloat(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFF50)(ui, buf, size); // .text:006AF080 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateFloat(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF080 ?DispatchUI_UpdateFloat@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateAttributeLevel:
        public static UInt32 DispatchUI_PrivateUpdateAttributeLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF840)(ui, buf, size); // .text:006AE970 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateAttributeLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE970 ?DispatchUI_PrivateUpdateAttributeLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateSkillAC:
        public static UInt32 DispatchUI_PrivateUpdateSkillAC(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFAA0)(ui, buf, size); // .text:006AEBD0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateSkillAC(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEBD0 ?DispatchUI_PrivateUpdateSkillAC@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateSkillLevel:
        public static UInt32 DispatchUI_PrivateUpdateSkillLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFAE0)(ui, buf, size); // .text:006AEC10 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateSkillLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEC10 ?DispatchUI_PrivateUpdateSkillLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveStringEvent:
        public static UInt32 DispatchUI_RemoveStringEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFCE0)(ui, buf, size); // .text:006AEE10 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveStringEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEE10 ?DispatchUI_RemoveStringEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateInstanceID:
        public static UInt32 DispatchUI_UpdateInstanceID(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFFB0)(ui, buf, size); // .text:006AF0E0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateInstanceID(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF0E0 ?DispatchUI_UpdateInstanceID@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateSkillAC:
        public static UInt32 DispatchUI_UpdateSkillAC(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0150)(ui, buf, size); // .text:006AF280 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateSkillAC(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF280 ?DispatchUI_UpdateSkillAC@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveDataIDEvent:
        public static UInt32 DispatchUI_PrivateRemoveDataIDEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF510)(ui, buf, size); // .text:006AE640 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveDataIDEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE640 ?DispatchUI_PrivateRemoveDataIDEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemovePositionEvent:
        public static UInt32 DispatchUI_PrivateRemovePositionEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF650)(ui, buf, size); // .text:006AE780 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemovePositionEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE780 ?DispatchUI_PrivateRemovePositionEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateInstanceID:
        public static UInt32 DispatchUI_PrivateUpdateInstanceID(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF920)(ui, buf, size); // .text:006AEA50 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateInstanceID(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEA50 ?DispatchUI_PrivateUpdateInstanceID@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateInt64:
        public static UInt32 DispatchUI_PrivateUpdateInt64(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF9A0)(ui, buf, size); // .text:006AEAD0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateInt64(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEAD0 ?DispatchUI_PrivateUpdateInt64@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateAttributeLevel:
        public static UInt32 DispatchUI_UpdateAttributeLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFEB0)(ui, buf, size); // .text:006AEFE0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateAttributeLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEFE0 ?DispatchUI_UpdateAttributeLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateAttribute2ndLevel:
        public static UInt32 DispatchUI_UpdateAttribute2ndLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFE60)(ui, buf, size); // .text:006AEF90 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateAttribute2ndLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEF90 ?DispatchUI_UpdateAttribute2ndLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveInstanceIDEvent:
        public static UInt32 DispatchUI_PrivateRemoveInstanceIDEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF590)(ui, buf, size); // .text:006AE6C0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveInstanceIDEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE6C0 ?DispatchUI_PrivateRemoveInstanceIDEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveIntEvent:
        public static UInt32 DispatchUI_PrivateRemoveIntEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF610)(ui, buf, size); // .text:006AE740 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveIntEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE740 ?DispatchUI_PrivateRemoveIntEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateAttribute:
        public static UInt32 DispatchUI_PrivateUpdateAttribute(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF6D0)(ui, buf, size); // .text:006AE800 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateAttribute(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE800 ?DispatchUI_PrivateUpdateAttribute@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateFloat:
        public static UInt32 DispatchUI_PrivateUpdateFloat(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF8C0)(ui, buf, size); // .text:006AE9F0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateFloat(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE9F0 ?DispatchUI_PrivateUpdateFloat@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveBoolEvent:
        public static UInt32 DispatchUI_RemoveBoolEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFB20)(ui, buf, size); // .text:006AEC50 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveBoolEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEC50 ?DispatchUI_RemoveBoolEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveInstanceIDEvent:
        public static UInt32 DispatchUI_RemoveInstanceIDEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFBE0)(ui, buf, size); // .text:006AED10 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveInstanceIDEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AED10 ?DispatchUI_RemoveInstanceIDEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemoveIntEvent:
        public static UInt32 DispatchUI_RemoveIntEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFC60)(ui, buf, size); // .text:006AED90 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemoveIntEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AED90 ?DispatchUI_RemoveIntEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateInt:
        public static UInt32 DispatchUI_UpdateInt(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0000)(ui, buf, size); // .text:006AF130 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateInt(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF130 ?DispatchUI_UpdateInt@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateDataID:
        public static UInt32 DispatchUI_PrivateUpdateDataID(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B01F0)(ui, buf, size); // .text:006AF320 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateDataID(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF320 ?DispatchUI_PrivateUpdateDataID@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdatePosition:
        public static UInt32 DispatchUI_PrivateUpdatePosition(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0230)(ui, buf, size); // .text:006AF360 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdatePosition(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF360 ?DispatchUI_PrivateUpdatePosition@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdatePosition:
        public static UInt32 DispatchUI_UpdatePosition(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0310)(ui, buf, size); // .text:006AF440 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdatePosition(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF440 ?DispatchUI_UpdatePosition@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateRemoveInt64Event:
        public static UInt32 DispatchUI_PrivateRemoveInt64Event(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF5D0)(ui, buf, size); // .text:006AE700 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateRemoveInt64Event(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE700 ?DispatchUI_PrivateRemoveInt64Event@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateInt:
        public static UInt32 DispatchUI_PrivateUpdateInt(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF960)(ui, buf, size); // .text:006AEA90 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateInt(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEA90 ?DispatchUI_PrivateUpdateInt@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateSkill:
        public static UInt32 DispatchUI_PrivateUpdateSkill(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF9F0)(ui, buf, size); // .text:006AEB20 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateSkill(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEB20 ?DispatchUI_PrivateUpdateSkill@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateAttribute2nd:
        public static UInt32 DispatchUI_UpdateAttribute2nd(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFDC0)(ui, buf, size); // .text:006AEEF0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateAttribute2nd(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEEF0 ?DispatchUI_UpdateAttribute2nd@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_PrivateUpdateAttribute2nd:
        public static UInt32 DispatchUI_PrivateUpdateAttribute2nd(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AF770)(ui, buf, size); // .text:006AE8A0 ; unsigned int __cdecl CM_Qualities::DispatchUI_PrivateUpdateAttribute2nd(UIQueueManager *ui, void *buf, unsigned int size) .text:006AE8A0 ?DispatchUI_PrivateUpdateAttribute2nd@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_RemovePositionEvent:
        public static UInt32 DispatchUI_RemovePositionEvent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006AFCA0)(ui, buf, size); // .text:006AEDD0 ; unsigned int __cdecl CM_Qualities::DispatchUI_RemovePositionEvent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AEDD0 ?DispatchUI_RemovePositionEvent@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Qualities.DispatchUI_UpdateSkillLevel:
        public static UInt32 DispatchUI_UpdateSkillLevel(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B01A0)(ui, buf, size); // .text:006AF2D0 ; unsigned int __cdecl CM_Qualities::DispatchUI_UpdateSkillLevel(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF2D0 ?DispatchUI_UpdateSkillLevel@CM_Qualities@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Misc {

        // Functions:

        // CM_Misc.DispatchUI_PortalStormImminent:
        public static UInt32 DispatchUI_PortalStormImminent(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0410)(ui, buf, size); // .text:006AF540 ; unsigned int __cdecl CM_Misc::DispatchUI_PortalStormImminent(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF540 ?DispatchUI_PortalStormImminent@CM_Misc@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Misc.DispatchUI_PortalStormSubsided:
        public static UInt32 DispatchUI_PortalStormSubsided(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B0440)(ui, buf, size); // .text:006AF570 ; unsigned int __cdecl CM_Misc::DispatchUI_PortalStormSubsided(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF570 ?DispatchUI_PortalStormSubsided@CM_Misc@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Misc.SendNotice_PlayerPortalStormed:
        public static Byte SendNotice_PlayerPortalStormed() => ((delegate* unmanaged[Cdecl]<Byte>)0x006B0470)(); // .text:006AF5A0 ; bool __cdecl CM_Misc::SendNotice_PlayerPortalStormed() .text:006AF5A0 ?SendNotice_PlayerPortalStormed@CM_Misc@@YA_NXZ

        // CM_Misc.SendNotice_PortalStormLevel:
        public static Byte SendNotice_PortalStormLevel(Single i_fExtent) => ((delegate* unmanaged[Cdecl]<Single, Byte>)0x006B04C0)(i_fExtent); // .text:006AF5F0 ; bool __cdecl CM_Misc::SendNotice_PortalStormLevel(float i_fExtent) .text:006AF5F0 ?SendNotice_PortalStormLevel@CM_Misc@@YA_NM@Z

        // CM_Misc.DispatchUI_PortalStorm:
        public static UInt32 DispatchUI_PortalStorm(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B03B0)(ui, buf, size); // .text:006AF4E0 ; unsigned int __cdecl CM_Misc::DispatchUI_PortalStorm(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF4E0 ?DispatchUI_PortalStorm@CM_Misc@@YAKPAVUIQueueManager@@PAXI@Z

        // CM_Misc.DispatchUI_PortalStormBrewing:
        public static UInt32 DispatchUI_PortalStormBrewing(UIQueueManager* ui, void* buf, UInt32 size) => ((delegate* unmanaged[Cdecl]<UIQueueManager*, void*, UInt32, UInt32>)0x006B03E0)(ui, buf, size); // .text:006AF510 ; unsigned int __cdecl CM_Misc::DispatchUI_PortalStormBrewing(UIQueueManager *ui, void *buf, unsigned int size) .text:006AF510 ?DispatchUI_PortalStormBrewing@CM_Misc@@YAKPAVUIQueueManager@@PAXI@Z
    }
    public unsafe struct CM_Examine {

        // Functions:

        // CM_Examine.SendNotice_ExamineObject:
        public static Byte SendNotice_ExamineObject(UInt32 i_objid) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006B0510)(i_objid); // .text:006AF640 ; bool __cdecl CM_Examine::SendNotice_ExamineObject(unsigned int i_objid) .text:006AF640 ?SendNotice_ExamineObject@CM_Examine@@YA_NK@Z

        // CM_Examine.SendNotice_ExamineSpell:
        public static Byte SendNotice_ExamineSpell(UInt32 i_spellid) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006B0560)(i_spellid); // .text:006AF690 ; bool __cdecl CM_Examine::SendNotice_ExamineSpell(unsigned int i_spellid) .text:006AF690 ?SendNotice_ExamineSpell@CM_Examine@@YA_NK@Z

        // CM_Examine.SendNotice_SetAppraiseInfo:
        public static Byte SendNotice_SetAppraiseInfo(UInt32 i_objid, AppraisalProfile* i_prof) => ((delegate* unmanaged[Cdecl]<UInt32, AppraisalProfile*, Byte>)0x006B05B0)(i_objid, i_prof); // .text:006AF6E0 ; bool __cdecl CM_Examine::SendNotice_SetAppraiseInfo(unsigned int i_objid, AppraisalProfile *i_prof) .text:006AF6E0 ?SendNotice_SetAppraiseInfo@CM_Examine@@YA_NKABVAppraisalProfile@@@Z
    }
    public unsafe struct CM_CharGen {

        // Functions:

        // CM_CharGen.SendNotice_CharGenVerificationResponse:
        public static Byte SendNotice_CharGenVerificationResponse(CG_VERIFICATION_RESPONSE i_rsvp) => ((delegate* unmanaged[Cdecl]<CG_VERIFICATION_RESPONSE, Byte>)0x006B0610)(i_rsvp); // .text:006AF740 ; bool __cdecl CM_CharGen::SendNotice_CharGenVerificationResponse(CG_VERIFICATION_RESPONSE i_rsvp) .text:006AF740 ?SendNotice_CharGenVerificationResponse@CM_CharGen@@YA_NW4CG_VERIFICATION_RESPONSE@@@Z
    }
    public unsafe struct CM_Movement {

        // Functions:

        // CM_Movement.Event_Jump_NonAutonomous:
        public static Byte Event_Jump_NonAutonomous(Single i_extent) => ((delegate* unmanaged[Cdecl]<Single, Byte>)0x006B0A00)(i_extent); // .text:006AFB30 ; bool __cdecl CM_Movement::Event_Jump_NonAutonomous(float i_extent) .text:006AFB30 ?Event_Jump_NonAutonomous@CM_Movement@@YA_NM@Z

        // CM_Movement.Event_MoveToState:
        public static Byte Event_MoveToState(MoveToStatePack* i_mtsp) => ((delegate* unmanaged[Cdecl]<MoveToStatePack*, Byte>)0x006B0AD0)(i_mtsp); // .text:006AFC00 ; bool __cdecl CM_Movement::Event_MoveToState(MoveToStatePack *i_mtsp) .text:006AFC00 ?Event_MoveToState@CM_Movement@@YA_NABVMoveToStatePack@@@Z

        // CM_Movement.Event_StopMovementCommand:
        public static Byte Event_StopMovementCommand(UInt32 i_motion, HoldKey i_hold_key) => ((delegate* unmanaged[Cdecl]<UInt32, HoldKey, Byte>)0x006B0B90)(i_motion, i_hold_key); // .text:006AFCC0 ; bool __cdecl CM_Movement::Event_StopMovementCommand(unsigned int i_motion, HoldKey i_hold_key) .text:006AFCC0 ?Event_StopMovementCommand@CM_Movement@@YA_NKW4HoldKey@@@Z

        // CM_Movement.Event_TurnToEvent:
        public static Byte Event_TurnToEvent(TurnToEventPack* i_ttep) => ((delegate* unmanaged[Cdecl]<TurnToEventPack*, Byte>)0x006B0CA0)(i_ttep); // .text:006AFDD0 ; bool __cdecl CM_Movement::Event_TurnToEvent(TurnToEventPack *i_ttep) .text:006AFDD0 ?Event_TurnToEvent@CM_Movement@@YA_NABVTurnToEventPack@@@Z

        // CM_Movement.Event_AutonomousPosition:
        public static Byte Event_AutonomousPosition(AutonomousPositionPack* i_app) => ((delegate* unmanaged[Cdecl]<AutonomousPositionPack*, Byte>)0x006B0660)(i_app); // .text:006AF790 ; bool __cdecl CM_Movement::Event_AutonomousPosition(AutonomousPositionPack *i_app) .text:006AF790 ?Event_AutonomousPosition@CM_Movement@@YA_NABVAutonomousPositionPack@@@Z

        // CM_Movement.Event_AutonomyLevel:
        public static Byte Event_AutonomyLevel(UInt32 i_autonomy_level) => ((delegate* unmanaged[Cdecl]<UInt32, Byte>)0x006B0720)(i_autonomy_level); // .text:006AF850 ; bool __cdecl CM_Movement::Event_AutonomyLevel(unsigned int i_autonomy_level) .text:006AF850 ?Event_AutonomyLevel@CM_Movement@@YA_NK@Z

        // CM_Movement.Event_DoMovementCommand:
        public static Byte Event_DoMovementCommand(UInt32 i_motion, Single i_speed, HoldKey i_hold_key) => ((delegate* unmanaged[Cdecl]<UInt32, Single, HoldKey, Byte>)0x006B07F0)(i_motion, i_speed, i_hold_key); // .text:006AF920 ; bool __cdecl CM_Movement::Event_DoMovementCommand(unsigned int i_motion, float i_speed, HoldKey i_hold_key) .text:006AF920 ?Event_DoMovementCommand@CM_Movement@@YA_NKMW4HoldKey@@@Z

        // CM_Movement.Event_Jump:
        public static Byte Event_Jump(JumpPack* i_jp) => ((delegate* unmanaged[Cdecl]<JumpPack*, Byte>)0x006B0940)(i_jp); // .text:006AFA70 ; bool __cdecl CM_Movement::Event_Jump(JumpPack *i_jp) .text:006AFA70 ?Event_Jump@CM_Movement@@YA_NABVJumpPack@@@Z
    }

}

