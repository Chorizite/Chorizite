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
    /// the type of highlight (outline) applied to the object&#39;s icon
    /// </summary>
    [Flags]
    public enum IconHighlight : uint {
        Invalid = 0x0000,

        Magical = 0x0001,

        Poisoned = 0x0002,

        BoostHealth = 0x0004,

        BoostMana = 0x0008,

        BoostStamina = 0x0010,

        Fire = 0x0020,

        Lightning = 0x0040,

        Frost = 0x0080,

        Acid = 0x0100,

        Bludgeoning = 0x0200,

        Slashing = 0x0400,

        Piercing = 0x0800,

        Nether = 0x1000,

    };
}
