//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;

namespace Chorizite.ACProtocol.Enums {
    /// <summary>
    /// Ordered (0xF7B1) Client to server opcodes
    /// </summary>
    public enum GameActionType : uint {
        Character_PlayerOptionChangedEvent = 0x0005,

        Combat_TargetedMeleeAttack = 0x0008,

        Combat_TargetedMissileAttack = 0x000A,

        Communication_SetAFKMode = 0x000F,

        Communication_SetAFKMessage = 0x0010,

        Communication_Talk = 0x0015,

        Social_RemoveFriend = 0x0017,

        Social_AddFriend = 0x0018,

        Inventory_PutItemInContainer = 0x0019,

        Inventory_GetAndWieldItem = 0x001A,

        Inventory_DropItem = 0x001B,

        Allegiance_SwearAllegiance = 0x001D,

        Allegiance_BreakAllegiance = 0x001E,

        Allegiance_UpdateRequest = 0x001F,

        Social_ClearFriends = 0x0025,

        Character_TeleToPKLArena = 0x0026,

        Character_TeleToPKArena = 0x0027,

        Social_SetDisplayCharacterTitle = 0x002C,

        Allegiance_QueryAllegianceName = 0x0030,

        Allegiance_ClearAllegianceName = 0x0031,

        Communication_TalkDirect = 0x0032,

        Allegiance_SetAllegianceName = 0x0033,

        Inventory_UseWithTargetEvent = 0x0035,

        Inventory_UseEvent = 0x0036,

        Allegiance_SetAllegianceOfficer = 0x003B,

        Allegiance_SetAllegianceOfficerTitle = 0x003C,

        Allegiance_ListAllegianceOfficerTitles = 0x003D,

        Allegiance_ClearAllegianceOfficerTitles = 0x003E,

        Allegiance_DoAllegianceLockAction = 0x003F,

        Allegiance_SetAllegianceApprovedVassal = 0x0040,

        Allegiance_AllegianceChatGag = 0x0041,

        Allegiance_DoAllegianceHouseAction = 0x0042,

        Train_TrainAttribute2nd = 0x0044,

        Train_TrainAttribute = 0x0045,

        Train_TrainSkill = 0x0046,

        Train_TrainSkillAdvancementClass = 0x0047,

        Magic_CastUntargetedSpell = 0x0048,

        Magic_CastTargetedSpell = 0x004A,

        Combat_ChangeCombatMode = 0x0053,

        Inventory_StackableMerge = 0x0054,

        Inventory_StackableSplitToContainer = 0x0055,

        Inventory_StackableSplitTo3D = 0x0056,

        Communication_ModifyCharacterSquelch = 0x0058,

        Communication_ModifyAccountSquelch = 0x0059,

        Communication_ModifyGlobalSquelch = 0x005B,

        Communication_TalkDirectByName = 0x005D,

        Vendor_Buy = 0x005F,

        Vendor_Sell = 0x0060,

        Character_TeleToLifestone = 0x0063,

        Character_LoginCompleteNotification = 0x00A1,

        Fellowship_Create = 0x00A2,

        Fellowship_Quit = 0x00A3,

        Fellowship_Dismiss = 0x00A4,

        Fellowship_Recruit = 0x00A5,

        Fellowship_UpdateRequest = 0x00A6,

        Writing_BookAddPage = 0x00AA,

        Writing_BookModifyPage = 0x00AB,

        Writing_BookData = 0x00AC,

        Writing_BookDeletePage = 0x00AD,

        Writing_BookPageData = 0x00AE,

        Writing_SetInscription = 0x00BF,

        Item_Appraise = 0x00C8,

        Inventory_GiveObjectRequest = 0x00CD,

        Advocate_Teleport = 0x00D6,

        Character_AbuseLogRequest = 0x0140,

        Communication_AddToChannel = 0x0145,

        Communication_RemoveFromChannel = 0x0146,

        Communication_ChannelBroadcast = 0x0147,

        Communication_ChannelList = 0x0148,

        Communication_ChannelIndex = 0x0149,

        Inventory_NoLongerViewingContents = 0x0195,

        Inventory_StackableSplitToWield = 0x019B,

        Character_AddShortCut = 0x019C,

        Character_RemoveShortCut = 0x019D,

        Character_CharacterOptionsEvent = 0x01A1,

        Magic_RemoveSpell = 0x01A8,

        Combat_CancelAttack = 0x01B7,

        Combat_QueryHealth = 0x01BF,

        Character_QueryAge = 0x01C2,

        Character_QueryBirth = 0x01C4,

        Communication_Emote = 0x01DF,

        Communication_SoulEmote = 0x01E1,

        Character_AddSpellFavorite = 0x01E3,

        Character_RemoveSpellFavorite = 0x01E4,

        Character_RequestPing = 0x01E9,

        Trade_OpenTradeNegotiations = 0x01F6,

        Trade_CloseTradeNegotiations = 0x01F7,

        Trade_AddToTrade = 0x01F8,

        Trade_AcceptTrade = 0x01FA,

        Trade_DeclineTrade = 0x01FB,

        Trade_ResetTrade = 0x0204,

        Character_ClearPlayerConsentList = 0x0216,

        Character_DisplayPlayerConsentList = 0x0217,

        Character_RemoveFromPlayerConsentList = 0x0218,

        Character_AddPlayerPermission = 0x0219,

        House_BuyHouse = 0x021C,

        House_QueryHouse = 0x021E,

        House_AbandonHouse = 0x021F,

        Character_RemovePlayerPermission = 0x0220,

        House_RentHouse = 0x0221,

        Character_SetDesiredComponentLevel = 0x0224,

        House_AddPermanentGuest = 0x0245,

        House_RemovePermanentGuest = 0x0246,

        House_SetOpenHouseStatus = 0x0247,

        House_ChangeStoragePermission = 0x0249,

        House_BootSpecificHouseGuest = 0x024A,

        House_RemoveAllStoragePermission = 0x024C,

        House_RequestFullGuestList = 0x024D,

        Allegiance_SetMotd = 0x0254,

        Allegiance_QueryMotd = 0x0255,

        Allegiance_ClearMotd = 0x0256,

        House_QueryLord = 0x0258,

        House_AddAllStoragePermission = 0x025C,

        House_RemoveAllPermanentGuests = 0x025E,

        House_BootEveryone = 0x025F,

        House_TeleToHouse = 0x0262,

        Item_QueryItemMana = 0x0263,

        House_SetHooksVisibility = 0x0266,

        House_ModifyAllegianceGuestPermission = 0x0267,

        House_ModifyAllegianceStoragePermission = 0x0268,

        Game_Join = 0x0269,

        Game_Quit = 0x026A,

        Game_Move = 0x026B,

        Game_MovePass = 0x026D,

        Game_Stalemate = 0x026E,

        House_ListAvailableHouses = 0x0270,

        Character_ConfirmationResponse = 0x0275,

        Allegiance_BreakAllegianceBoot = 0x0277,

        House_TeleToMansion = 0x0278,

        Character_Suicide = 0x0279,

        Allegiance_AllegianceInfoRequest = 0x027B,

        Inventory_CreateTinkeringTool = 0x027D,

        Character_SpellbookFilterEvent = 0x0286,

        Character_TeleToMarketplace = 0x028D,

        Character_EnterPKLite = 0x028F,

        Fellowship_AssignNewLeader = 0x0290,

        Fellowship_ChangeFellowOpeness = 0x0291,

        Allegiance_AllegianceChatBoot = 0x02A0,

        Allegiance_AddAllegianceBan = 0x02A1,

        Allegiance_RemoveAllegianceBan = 0x02A2,

        Allegiance_ListAllegianceBans = 0x02A3,

        Allegiance_RemoveAllegianceOfficer = 0x02A5,

        Allegiance_ListAllegianceOfficers = 0x02A6,

        Allegiance_ClearAllegianceOfficers = 0x02A7,

        Allegiance_RecallAllegianceHometown = 0x02AB,

        Admin_QueryPluginListResponse = 0x02AF,

        Admin_QueryPluginResponse = 0x02B2,

        Character_FinishBarber = 0x0311,

        Social_AbandonContract = 0x0316,

        Movement_Jump = 0xF61B,

        Movement_MoveToState = 0xF61C,

        Movement_DoMovementCommand = 0xF61E,

        Movement_StopMovementCommand = 0xF661,

        Movement_AutonomyLevel = 0xF752,

        Movement_AutonomousPosition = 0xF753,

        Movement_Jump_NonAutonomous = 0xF7C9,

    };
}
