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
    /// The stance for a character or monster.
    /// </summary>
    public enum StanceMode : ushort {
        HandCombat = 0x3C,

        NonCombat = 0x3D,

        SwordCombat = 0x3E,

        BowCombat = 0x3F,

        SwordShieldCombat = 0x40,

        CrossbowCombat = 0x41,

        UnusedCombat = 0x42,

        SlingCombat = 0x43,

        TwoHandedSwordCombat = 0x44,

        TwoHandedStaffCombat = 0x45,

        DualWieldCombat = 0x46,

        ThrownWeaponCombat = 0x47,

        BowNoAmmo = 0xE8,

        CrossBowNoAmmo = 0xE9,

        AtlatlCombat = 0x138,

        ThrownShieldCombat = 0x139,

    };
}
