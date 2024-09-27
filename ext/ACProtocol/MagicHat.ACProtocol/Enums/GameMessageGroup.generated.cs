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
    public enum GameMessageGroup : uint {
        Event = 0x0001,

        /// <summary>
        /// C2S, small number of admin messages and a few others
        /// </summary>
        Control = 0x0002,

        /// <summary>
        /// C2S, most all game actions, all ordered
        /// </summary>
        Weenie = 0x0003,

        /// <summary>
        /// Bidirectional, login messages, turbine chat
        /// </summary>
        Logon = 0x0004,

        /// <summary>
        /// Bidirectional, DAT patching
        /// </summary>
        Database = 0x0005,

        SecureControl = 0x0006,

        SecureWeenie = 0x0007,

        SecureLogin = 0x0008,

        /// <summary>
        /// S2C, game events (ordered) and other character related messages
        /// </summary>
        UIQueue = 0x0009,

        /// <summary>
        /// S2C, messages mostly related to object creation/deletion and their motion, effects
        /// </summary>
        SmartBox = 0x000A,

        Observer = 0x0008,

    };
}
