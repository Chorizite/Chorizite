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
    /// The DamageLocation indicates where damage was done.
    /// </summary>
    public enum DamageLocation : uint {
        Head = 0x00,

        Chest = 0x01,

        Abdomen = 0x02,

        UpperArm = 0x03,

        LowerArm = 0x04,

        Hand = 0x05,

        UpperLeg = 0x06,

        LowerLeg = 0x07,

        Foot = 0x08,

    };
}
