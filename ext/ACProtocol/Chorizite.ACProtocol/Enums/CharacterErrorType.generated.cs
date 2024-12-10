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
    /// The CharacterErrorType identifies the type of character error that has occured.
    /// </summary>
    public enum CharacterErrorType : uint {
        /// <summary>
        /// Id_CHAR_ERROR_LOGON
        /// </summary>
        Logon = 0x01,

        /// <summary>
        /// Id_CHAR_ERROR_ACCOUNT_LOGON
        /// </summary>
        AccountLogin = 0x03,

        /// <summary>
        /// Id_CHAR_ERROR_SERVER_CRASH
        /// </summary>
        ServerCrash = 0x04,

        /// <summary>
        /// Id_CHAR_ERROR_LOGOFF
        /// </summary>
        Logoff = 0x05,

        /// <summary>
        /// Id_CHAR_ERROR_DELETE
        /// </summary>
        Delete = 0x06,

        /// <summary>
        /// Id_CHAR_ERROR_SERVER_CRASH
        /// </summary>
        ServerCrash2 = 0x08,

        /// <summary>
        /// Id_CHAR_ERROR_ACCOUNT_INVALId
        /// </summary>
        AccountInvalid = 0x09,

        /// <summary>
        /// Id_CHAR_ERROR_ACCOUNT_DOESNT_EXIST
        /// </summary>
        AccountDoesntExist = 0x0A,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_GENERIC
        /// </summary>
        EnterGameGeneric = 0x0B,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_STRESS_ACCOUNT
        /// </summary>
        EnterGameStressAccount = 0x0C,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_CHARACTER_IN_WORLD
        /// </summary>
        EnterGameCharacterInWorld = 0x0D,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_PLAYER_ACCOUNT_MISSING
        /// </summary>
        EnterGamePlayerAccountMissing = 0x0E,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_CHARACTER_NOT_OWNED
        /// </summary>
        EnterGameCharacterNotOwned = 0x0F,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_CHARACTER_IN_WORLD_SERVER
        /// </summary>
        EnterGameCharacterInWorldServer = 0x10,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_OLD_CHARACTER
        /// </summary>
        EnterGameOldCharacter = 0x11,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_CORRUPT_CHARACTER
        /// </summary>
        EnterGameCorruptCharacter = 0x12,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_START_SERVER_DOWN
        /// </summary>
        EnterGameStartServerDown = 0x13,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_COULDNT_PLACE_CHARACTER
        /// </summary>
        EnterGameCouldntPlaceCharacter = 0x14,

        /// <summary>
        /// Id_CHAR_ERROR_LOGON_SERVER_FULL
        /// </summary>
        LogonServerFull = 0x15,

        /// <summary>
        /// Id_CHAR_ERROR_ENTER_GAME_CHARACTER_LOCKED
        /// </summary>
        EnterGameCharacterLocked = 0x17,

        /// <summary>
        /// Id_CHAR_ERROR_SUBSCRIPTION_EXPIRED
        /// </summary>
        SubscriptionExpired = 0x18,

    };
}
