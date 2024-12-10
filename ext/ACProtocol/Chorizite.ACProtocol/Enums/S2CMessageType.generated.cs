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
    /// Server to Client message opcodes
    /// </summary>
    public enum S2CMessageType : uint {
        Item_ServerSaysRemove = 0x0024,

        Character_ServerSaysAttemptFailed = 0x00A0,

        Item_UpdateStackSize = 0x0197,

        Combat_HandlePlayerDeathEvent = 0x019E,

        Qualities_PrivateRemoveIntEvent = 0x01D1,

        Qualities_RemoveIntEvent = 0x01D2,

        Qualities_PrivateRemoveBoolEvent = 0x01D3,

        Qualities_RemoveBoolEvent = 0x01D4,

        Qualities_PrivateRemoveFloatEvent = 0x01D5,

        Qualities_RemoveFloatEvent = 0x01D6,

        Qualities_PrivateRemoveStringEvent = 0x01D7,

        Qualities_RemoveStringEvent = 0x01D8,

        Qualities_PrivateRemoveDataIdEvent = 0x01D9,

        Qualities_RemoveDataIdEvent = 0x01DA,

        Qualities_PrivateRemoveInstanceIdEvent = 0x01DB,

        Qualities_RemoveInstanceIdEvent = 0x01DC,

        Qualities_PrivateRemovePositionEvent = 0x01DD,

        Qualities_RemovePositionEvent = 0x01DE,

        Communication_HearEmote = 0x01E0,

        Communication_HearSoulEmote = 0x01E2,

        Qualities_PrivateRemoveInt64Event = 0x02B8,

        Qualities_RemoveInt64Event = 0x02B9,

        Communication_HearSpeech = 0x02BB,

        Communication_HearRangedSpeech = 0x02BC,

        Qualities_PrivateUpdateInt = 0x02CD,

        Qualities_UpdateInt = 0x02CE,

        Qualities_PrivateUpdateInt64 = 0x02CF,

        Qualities_UpdateInt64 = 0x02D0,

        Qualities_PrivateUpdateBool = 0x02D1,

        Qualities_UpdateBool = 0x02D2,

        Qualities_PrivateUpdateFloat = 0x02D3,

        Qualities_UpdateFloat = 0x02D4,

        Qualities_PrivateUpdateString = 0x02D5,

        Qualities_UpdateString = 0x02D6,

        Qualities_PrivateUpdateDataId = 0x02D7,

        Qualities_UpdateDataId = 0x02D8,

        Qualities_PrivateUpdateInstanceId = 0x02D9,

        Qualities_UpdateInstanceId = 0x02DA,

        Qualities_PrivateUpdatePosition = 0x02DB,

        Qualities_UpdatePosition = 0x02DC,

        Qualities_PrivateUpdateSkill = 0x02DD,

        Qualities_UpdateSkill = 0x02DE,

        Qualities_PrivateUpdateSkillLevel = 0x02DF,

        Qualities_UpdateSkillLevel = 0x02E0,

        Qualities_PrivateUpdateSkillAC = 0x02E1,

        Qualities_UpdateSkillAC = 0x02E2,

        Qualities_PrivateUpdateAttribute = 0x02E3,

        Qualities_UpdateAttribute = 0x02E4,

        Qualities_PrivateUpdateAttributeLevel = 0x02E5,

        Qualities_UpdateAttributeLevel = 0x02E6,

        Qualities_PrivateUpdateAttribute2nd = 0x02E7,

        Qualities_UpdateAttribute2nd = 0x02E8,

        Qualities_PrivateUpdateAttribute2ndLevel = 0x02E9,

        Qualities_UpdateAttribute2ndLevel = 0x02EA,

        Admin_Environs = 0xEA60,

        Movement_PositionAndMovementEvent = 0xF619,

        Item_ObjDescEvent = 0xF625,

        Character_SetPlayerVisualDesc = 0xF630,

        Character_CharGenVerificationResponse = 0xF643,

        Login_AwaitingSubscriptionExpiration = 0xF651,

        Login_LogOffCharacter = 0xF653,

        Character_CharacterDelete = 0xF655,

        Login_LoginCharacterSet = 0xF658,

        Character_CharacterError = 0xF659,

        Item_CreateObject = 0xF745,

        Login_CreatePlayer = 0xF746,

        Item_DeleteObject = 0xF747,

        Movement_PositionEvent = 0xF748,

        Item_ParentEvent = 0xF749,

        Inventory_PickupEvent = 0xF74A,

        Item_SetState = 0xF74B,

        Movement_SetObjectMovement = 0xF74C,

        Movement_VectorUpdate = 0xF74E,

        Effects_SoundEvent = 0xF750,

        Effects_PlayerTeleport = 0xF751,

        Effects_PlayScriptId = 0xF754,

        Effects_PlayScriptType = 0xF755,

        Login_AccountBanned = 0xF7C1,

        Admin_ReceiveAccountData = 0xF7CA,

        Admin_ReceivePlayerData = 0xF7CB,

        Item_UpdateObject = 0xF7DB,

        Login_AccountBooted = 0xF7DC,

        Communication_TurbineChat = 0xF7DE,

        Login_EnterGame_ServerReady = 0xF7DF,

        Communication_TextboxString = 0xF7E0,

        Login_WorldInfo = 0xF7E1,

        DDD_DataMessage = 0xF7E2,

        DDD_ErrorMessage = 0xF7E4,

        DDD_InterrogationMessage = 0xF7E5,

        DDD_BeginDDDMessage = 0xF7E7,

        DDD_OnEndDDD = 0xF7EA,

        Ordered_GameEvent = 0xF7B0,

    };
}
