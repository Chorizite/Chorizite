//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
namespace MagicHat.ACProtocol.Enums {
    /// <summary>
    /// Ordered (0xF7B0) Server to Client opcodes
    /// </summary>
    public enum GameEventType : uint {
        Allegiance_AllegianceUpdateAborted = 0x0003,

        Communication_PopUpString = 0x0004,

        Login_PlayerDescription = 0x0013,

        Allegiance_AllegianceUpdate = 0x0020,

        Social_FriendsUpdate = 0x0021,

        Item_ServerSaysContainId = 0x0022,

        Item_WearItem = 0x0023,

        Social_CharacterTitleTable = 0x0029,

        Social_AddOrSetCharacterTitle = 0x002B,

        Item_StopViewingObjectContents = 0x0052,

        Vendor_VendorInfo = 0x0062,

        Character_StartBarber = 0x0075,

        Fellowship_Quit = 0x00A3,

        Fellowship_Dismiss = 0x00A4,

        Writing_BookOpen = 0x00B4,

        Writing_BookAddPageResponse = 0x00B6,

        Writing_BookDeletePageResponse = 0x00B7,

        Writing_BookPageDataResponse = 0x00B8,

        Item_GetInscriptionResponse = 0x00C3,

        Item_SetAppraiseInfo = 0x00C9,

        Communication_ChannelBroadcast = 0x0147,

        Communication_ChannelList = 0x0148,

        Communication_ChannelIndex = 0x0149,

        Item_OnViewContents = 0x0196,

        Item_ServerSaysMoveItem = 0x019A,

        Combat_HandleAttackDoneEvent = 0x01A7,

        Magic_RemoveSpell = 0x01A8,

        Combat_HandleVictimNotificationEventSelf = 0x01AC,

        Combat_HandleVictimNotificationEventOther = 0x01AD,

        Combat_HandleAttackerNotificationEvent = 0x01B1,

        Combat_HandleDefenderNotificationEvent = 0x01B2,

        Combat_HandleEvasionAttackerNotificationEvent = 0x01B3,

        Combat_HandleEvasionDefenderNotificationEvent = 0x01B4,

        Combat_HandleCommenceAttackEvent = 0x01B8,

        Combat_QueryHealthResponse = 0x01C0,

        Character_QueryAgeResponse = 0x01C3,

        Item_UseDone = 0x01C7,

        Allegiance_AllegianceUpdateDone = 0x01C8,

        Fellowship_FellowUpdateDone = 0x01C9,

        Fellowship_FellowStatsDone = 0x01CA,

        Item_AppraiseDone = 0x01CB,

        Character_ReturnPing = 0x01EA,

        Communication_SetSquelchDB = 0x01F4,

        Trade_RegisterTrade = 0x01FD,

        Trade_OpenTrade = 0x01FE,

        Trade_CloseTrade = 0x01FF,

        Trade_AddToTrade = 0x0200,

        Trade_RemoveFromTrade = 0x0201,

        Trade_AcceptTrade = 0x0202,

        Trade_DeclineTrade = 0x0203,

        Trade_ResetTrade = 0x0205,

        Trade_TradeFailure = 0x0207,

        Trade_ClearTradeAcceptance = 0x0208,

        House_HouseProfile = 0x021D,

        House_HouseData = 0x0225,

        House_HouseStatus = 0x0226,

        House_UpdateRentTime = 0x0227,

        House_UpdateRentPayment = 0x0228,

        House_UpdateRestrictions = 0x0248,

        House_UpdateHAR = 0x0257,

        House_HouseTransaction = 0x0259,

        Item_QueryItemManaResponse = 0x0264,

        House_AvailableHouses = 0x0271,

        Character_ConfirmationRequest = 0x0274,

        Character_ConfirmationDone = 0x0276,

        Allegiance_AllegianceLoginNotificationEvent = 0x027A,

        Allegiance_AllegianceInfoResponseEvent = 0x027C,

        Game_JoinGameResponse = 0x0281,

        Game_StartGame = 0x0282,

        Game_MoveResponse = 0x0283,

        Game_OpponentTurn = 0x0284,

        Game_OpponentStalemateState = 0x0285,

        Communication_WeenieError = 0x028A,

        Communication_WeenieErrorWithString = 0x028B,

        Game_GameOver = 0x028C,

        Communication_ChatRoomTracker = 0x0295,

        Admin_QueryPluginList = 0x02AE,

        Admin_QueryPlugin = 0x02B1,

        Admin_QueryPluginResponse2 = 0x02B3,

        Inventory_SalvageOperationsResultData = 0x02B4,

        Communication_HearDirectSpeech = 0x02BD,

        Fellowship_FullUpdate = 0x02BE,

        Fellowship_Disband = 0x02BF,

        Fellowship_UpdateFellow = 0x02C0,

        Magic_UpdateSpell = 0x02C1,

        Magic_UpdateEnchantment = 0x02C2,

        Magic_RemoveEnchantment = 0x02C3,

        Magic_UpdateMultipleEnchantments = 0x02C4,

        Magic_RemoveMultipleEnchantments = 0x02C5,

        Magic_PurgeEnchantments = 0x02C6,

        Magic_DispelEnchantment = 0x02C7,

        Magic_DispelMultipleEnchantments = 0x02C8,

        Misc_PortalStormBrewing = 0x02C9,

        Misc_PortalStormImminent = 0x02CA,

        Misc_PortalStorm = 0x02CB,

        Misc_PortalStormSubsided = 0x02CC,

        Communication_TransientString = 0x02EB,

        Magic_PurgeBadEnchantments = 0x0312,

        Social_SendClientContractTrackerTable = 0x0314,

        Social_SendClientContractTracker = 0x0315,

    };
}
