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
    /// The AttributeId identifies a specific Character attribute.
    /// </summary>
    public enum AttributeId : uint {
        Strength = 0x01,

        Endurance = 0x02,

        Quickness = 0x03,

        Coordination = 0x04,

        Focus = 0x05,

        Self = 0x06,

    };
}
