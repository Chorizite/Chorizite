//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
namespace MagicHat.ACProtocol.Enums {
    /// <summary>
    /// The AmmoType value describes the type of ammunition a missile weapon uses.
    /// </summary>
    [Flags]
    public enum AmmoType : ushort {
        ThrownWeapon = 0x0000,

        Arrow = 0x0001,

        Bolt = 0x0002,

        Dart = 0x0004,

    };
}
