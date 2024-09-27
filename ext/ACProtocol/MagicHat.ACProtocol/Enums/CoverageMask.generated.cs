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
    /// The CoverageMask value describes what parts of the body an item protects.
    /// </summary>
    [Flags]
    public enum CoverageMask : uint {
        UpperLegsUnderwear = 0x00000002,

        LowerLegsUnderwear = 0x00000004,

        ChestUnderwear = 0x00000008,

        AbdomenUnderwear = 0x00000010,

        UpperArmsUnderwear = 0x00000020,

        LowerArmsUnderwear = 0x00000040,

        UpperLegs = 0x00000100,

        LowerLegs = 0x00000200,

        Chest = 0x00000400,

        Abdomen = 0x00000800,

        UpperArms = 0x00001000,

        LowerArms = 0x00002000,

        Head = 0x00004000,

        Hands = 0x00008000,

        Feet = 0x00010000,

    };
}
