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
    /// The ResistHighlightMask selects which wand attributes highlighting is applied to.
    /// </summary>
    [Flags]
    public enum ResistHighlightMask : ushort {
        ResistSlash = 0x0001,

        ResistPierce = 0x0002,

        ResistBludgeon = 0x0004,

        ResistFire = 0x0008,

        ResistCold = 0x0010,

        ResistAcid = 0x0020,

        ResistElectric = 0x0040,

        ResistHealthBoost = 0x0080,

        ResistStaminaDrain = 0x0100,

        ResistStaminaBoost = 0x0200,

        ResistManaDrain = 0x0400,

        ResistManaBoost = 0x0800,

        ManaConversionMod = 0x1000,

        ElementalDamageMod = 0x2000,

        ResistNether = 0x4000,

    };
}
