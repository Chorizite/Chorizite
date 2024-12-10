using System;

namespace Chorizite.Common.Enums {
    /// <summary>
    /// The combat mode for a character or monster.
    /// </summary>
    [Flags]
    public enum CombatMode : uint {
        NonCombat = 0x1,

        Melee = 0x2,

        Missile = 0x4,

        Magic = 0x8,

    };
}
