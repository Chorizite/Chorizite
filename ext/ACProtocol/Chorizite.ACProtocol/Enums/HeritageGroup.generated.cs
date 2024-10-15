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
    /// Heritage of a player
    /// </summary>
    public enum HeritageGroup : byte {
        Invalid = 0x00,

        Aluvian = 0x01,

        Gharundim = 0x02,

        Sho = 0x03,

        Viamontian = 0x04,

        Shadowbound = 0x05,

        Gearknight = 0x06,

        Tumerok = 0x07,

        Lugian = 0x08,

        Empyrean = 0x09,

        Penumbraen = 0x0A,

        Undead = 0x0B,

        Olthoi = 0x0C,

        OlthoiAcid = 0x0D,

    };
}
