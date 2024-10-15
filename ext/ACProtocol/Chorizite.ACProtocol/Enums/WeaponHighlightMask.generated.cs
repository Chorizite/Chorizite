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
    /// The WeaponHighlightMask selects which weapon attributes highlighting is applied to.
    /// </summary>
    [Flags]
    public enum WeaponHighlightMask : ushort {
        AttackSkill = 0x0001,

        MeleeDefense = 0x0002,

        Speed = 0x0004,

        Damage = 0x0008,

        DamageVariance = 0x0010,

        DamageMod = 0x0020,

    };
}
