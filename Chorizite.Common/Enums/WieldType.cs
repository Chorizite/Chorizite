namespace Chorizite.Common.Enums {
    /// <summary>
    /// the type of wieldable item this is
    /// </summary>
    public enum WieldType : byte {
        Invalid = 0x00000000,

        MeleeWeapon = 0x00000001,

        Armor = 0x00000002,

        Clothing = 0x00000004,

        Jewelry = 0x00000008,

    };
}
