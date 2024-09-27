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
    /// The ChatDisplayMask identifies that types of chat that are displayed in each chat window. 
    /// </summary>
    public enum ChatDisplayMask : uint {
        /// <summary>
        /// Gameplay (main chat window only)
        /// </summary>
        Gameplay = 0x03912021,

        /// <summary>
        /// Mandatory (main chat window only, cannot be disabled)
        /// </summary>
        Mandatory = 0x0000c302,

        AreaChat = 0x00001004,

        Tells = 0x00000018,

        Combat = 0x00600040,

        Magic = 0x00020080,

        Allegiance = 0x00040c00,

        Fellowship = 0x00080000,

        Errors = 0x04000000,

        TradeChannel = 0x10000000,

        LFGChannel = 0x20000000,

        RoleplayChannel = 0x40000000,

    };
}
