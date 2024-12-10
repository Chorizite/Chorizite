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
    /// The AttributeMask selects which creature attributes highlighting is applied to.
    /// </summary>
    [Flags]
    public enum AttributeMask : ushort {
        Strength = 0x0001,

        Endurance = 0x0002,

        Quickness = 0x0004,

        Coordination = 0x0008,

        Focus = 0x0010,

        Self = 0x0020,

        Health = 0x0040,

        Stamina = 0x0080,

        Mana = 0x0100,

    };
}
