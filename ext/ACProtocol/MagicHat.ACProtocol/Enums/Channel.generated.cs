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
    /// Chat channels
    /// </summary>
    [Flags]
    public enum Channel : uint {
        Undef = 0x00000000,

        Abuse = 0x00000001,

        Admin = 0x00000002,

        Audit = 0x00000004,

        Advocate1 = 0x00000008,

        Advocate2 = 0x00000010,

        Advocate3 = 0x00000020,

        QA1 = 0x00000040,

        QA2 = 0x00000080,

        Debug = 0x00000100,

        Sentinel = 0x00000200,

        Help = 0x00000400,

        AllBroadcast = 0x00000401,

        Fellow = 0x00000800,

        Vassals = 0x00001000,

        Patron = 0x00002000,

        Monarch = 0x00004000,

        AlArqas = 0x00008000,

        Holtburg = 0x00010000,

        Lytelthorpe = 0x00020000,

        Nanto = 0x00040000,

        Rithwic = 0x00080000,

        Samsur = 0x00100000,

        Shoushi = 0x00200000,

        Yanshi = 0x00400000,

        Yaraq = 0x00800000,

        TownChans = 0x00FF8000,

        CoVassals = 0x01000000,

        AllegianceBroadcast = 0x02000000,

        FellowBroadcast = 0x04000000,

        SocietyCelHanBroadcast = 0x08000000,

        SocietyEldWebBroadcast = 0x10000000,

        SocietyRadBloBroadcast = 0x20000000,

        Olthoi = 0x40000000,

        GhostChans = 0x7F007800,

    };
}
