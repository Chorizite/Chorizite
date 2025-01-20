using System;

namespace Chorizite.Common.Enums {
    /// <summary>
    /// The EquipMask value describes the equipment slots an item uses.
    /// </summary>
    [Flags]
    public enum EquipMask : uint {
        None = 0x00000000,
        HeadWear = 0x00000001,
        ChestWear = 0x00000002,
        AbdomenWear = 0x00000004,
        UpperArmWear = 0x00000008,
        LowerArmWear = 0x00000010,
        HandWear = 0x00000020,
        UpperLegWear = 0x00000040,
        LowerLegWear = 0x00000080,
        FootWear = 0x00000100,
        ChestArmor = 0x00000200,
        AbdomenArmor = 0x00000400,
        UpperArmArmor = 0x00000800,
        LowerArmArmor = 0x00001000,
        UpperLegArmor = 0x00002000,
        LowerLegArmor = 0x00004000,
        NeckWear = 0x00008000,
        WristWearLeft = 0x00010000,
        WristWearRight = 0x00020000,
        FingerWearLeft = 0x00040000,
        FingerWearRight = 0x00080000,
        MeleeWeapon = 0x00100000,
        Shield = 0x00200000,
        MissileWeapon = 0x00400000,
        MissileAmmo = 0x00800000,
        Held = 0x01000000,
        TwoHanded = 0x02000000,
        TrinketOne = 0x04000000,
        Cloak = 0x08000000,
        SigilOne = 0x10000000,
        SigilTwo = 0x20000000,
        SigilThree = 0x40000000
    };
}
