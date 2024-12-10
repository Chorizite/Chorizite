using System;

namespace Chorizite.Common.Enums {
    /// <summary>
    /// The CharacterOptions2 word contains additional character options.
    /// </summary>
    [Flags]
    public enum CharacterOptions2 : uint {
        PersistentAtDay = 0x00000001,

        DisplayDateOfBirth = 0x00000002,

        DisplayChessRank = 0x00000004,

        DisplayFishingSkill = 0x00000008,

        DisplayNumberDeaths = 0x00000010,

        DisplayAge = 0x00000020,

        TimeStamp = 0x00000040,

        SalvageMultiple = 0x00000080,

        HearGeneralChat = 0x00000100,

        HearTradeChat = 0x00000200,

        HearLFGChat = 0x00000400,

        HearRoleplayChat = 0x00000800,

        AppearOffline = 0x00001000,

        DisplayNumberCharacterTitles = 0x00002000,

        MainPackPreferred = 0x00004000,

        LeadMissileTargets = 0x00008000,

        UseFastMissiles = 0x00010000,

        FilterLanguage = 0x00020000,

        ConfirmVolatileRareUse = 0x00040000,

        HearSocietyChat = 0x00080000,

        ShowHelm = 0x00100000,

        DisableDistanceFog = 0x00200000,

        UseMouseTurning = 0x00400000,

        ShowCloak = 0x00800000,

        LockUI = 0x01000000,

        HearPKDeath = 0x02000000,

    };
}
