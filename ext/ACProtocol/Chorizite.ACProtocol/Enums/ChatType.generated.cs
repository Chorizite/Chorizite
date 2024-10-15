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
    /// Chat channel type, for turbine chat
    /// </summary>
    public enum ChatType : uint {
        Undef = 0x00000000,

        Allegiance = 0x00000001,

        General = 0x00000002,

        Trade = 0x00000003,

        LFG = 0x00000004,

        Roleplay = 0x00000005,

        Society = 0x00000006,

        SocietyCelHan = 0x00000007,

        SocietyEldWeb = 0x00000008,

        SocietyRadBlo = 0x00000009,

        Olthoi = 0x0000000a,

    };
}
