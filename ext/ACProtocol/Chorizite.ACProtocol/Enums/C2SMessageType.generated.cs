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
    /// Client to Server message opcodes
    /// </summary>
    public enum C2SMessageType : uint {
        Login_LogOffCharacter = 0xF653,

        Character_CharacterDelete = 0xF655,

        Character_SendCharGenResult = 0xF656,

        Login_SendEnterWorld = 0xF657,

        Object_SendForceObjdesc = 0xF6EA,

        Login_SendEnterWorldRequest = 0xF7C8,

        Admin_SendAdminGetServerVersion = 0xF7CC,

        Social_SendFriendsCommand = 0xF7CD,

        Admin_SendAdminRestoreCharacter = 0xF7D9,

        Communication_TurbineChat = 0xF7DE,

        DDD_RequestDataMessage = 0xF7E3,

        DDD_InterrogationResponseMessage = 0xF7E6,

        DDD_OnEndDDD = 0xF7EA,

        DDD_EndDDDMessage = 0xF7EB,

        Ordered_GameAction = 0xF7B1,

    };
}
