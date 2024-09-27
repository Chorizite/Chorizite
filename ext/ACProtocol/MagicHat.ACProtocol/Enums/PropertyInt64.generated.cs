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
    /// The PropertyInt64 identifies a specific Character or Object int64 property.
    /// </summary>
    public enum PropertyInt64 : uint {
        TotalExperience = 0x0001,

        AvailableExperience = 0x0002,

        AugmentationCost = 0x0003,

        ItemTotalXp = 0x0004,

        ItemBaseXp = 0x0005,

        AvailableLuminance = 0x0006,

        MaximumLuminance = 0x0007,

        InteractionReqs = 0x0008,

    };
}
