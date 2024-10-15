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
    /// The DamageType identifies the type of damage.
    /// </summary>
    [Flags]
    public enum DamageType : uint {
        Slashing = 0x01,

        Piercing = 0x02,

        Bludgeoning = 0x04,

        Cold = 0x08,

        Fire = 0x10,

        Acid = 0x20,

        Electric = 0x40,

    };
}
