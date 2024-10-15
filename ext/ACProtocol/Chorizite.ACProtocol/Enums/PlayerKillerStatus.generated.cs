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
    [Flags]
    public enum PlayerKillerStatus : ushort {
        Undef = 0x00,

        Protected = 0x01,

        NPK = 0x02,

        PK = 0x04,

        Unprotected = 0x08,

        RubberGlue = 0x10,

        Free = 0x20,

        PKLite = 0x40,

        Creature = Unprotected,

        Trap = Unprotected,

        NPC = Protected,

        Vendor = RubberGlue,

        Baelzharon = Free,

    };
}
