using System;

namespace Chorizite.Common.Enums {
    [Flags]
    public enum PortalBitmask : int {
        Undef = 0x00,

        NotPassable = 0x00,

        Unrestricted = 0x01,

        NoPk = 0x02,

        NoPKLite = 0x04,

        NoNPK = 0x08,

        NoSummon = 0x10,

        NoRecall = 0x20,

        OnlyOlthoiPCs = 0x40,

        NoOlthoiPCs = 0x80,

        NoVitae = 0x100,

        NoNewAccounts = 0x200,

    };
}
