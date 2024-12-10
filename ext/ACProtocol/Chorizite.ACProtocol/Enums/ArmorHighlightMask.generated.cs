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
    /// The ArmorHighlightMask selects which armor attributes highlighting is applied to.
    /// </summary>
    [Flags]
    public enum ArmorHighlightMask : ushort {
        ArmorLevel = 0x0001,

        SlashingProtection = 0x0002,

        PiercingProtection = 0x0004,

        BludgeoningProtection = 0x0008,

        ColdProtection = 0x0010,

        FireProtection = 0x0020,

        AcidProtection = 0x0040,

        ElectricalProtection = 0x0080,

    };
}
