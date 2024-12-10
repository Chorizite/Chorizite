using System;

namespace Chorizite.Common.Enums {
    /// <summary>
    /// The EquipMask value describes the equipment slots an item uses.
    /// </summary>
    [Flags]
    public enum EquipMask : uint {
        Head = 0x00000001,

        ChestUnderwear = 0x00000002,

        AbdomenUnderwear = 0x00000004,

        UpperArmsUnderwear = 0x00000008,

        LowerArmsUnderwear = 0x00000010,

        Hands = 0x00000020,

        UpperLegsUnderwear = 0x00000040,

        LowerLegsUnderwear = 0x00000080,

        Feet = 0x00000100,

        Chest = 0x00000200,

        Abdomen = 0x00000400,

        UpperArms = 0x00000800,

        LowerArms = 0x00001000,

        UpperLegs = 0x00002000,

        LowerLegs = 0x00004000,

        Necklace = 0x00008000,

        RightBracelet = 0x00010000,

        LeftBracelet = 0x00020000,

        RightRing = 0x00040000,

        LeftRing = 0x00080000,

        MeleeWeapon = 0x00100000,

        Shield = 0x00200000,

        MissileWeapon = 0x00400000,

        Ammunition = 0x00800000,

        Wand = 0x01000000,

    };
}
