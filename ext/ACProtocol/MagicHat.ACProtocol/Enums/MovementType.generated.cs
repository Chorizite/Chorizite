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
    /// The movement type defines the fields for the rest of the message
    /// </summary>
    public enum MovementType : byte {
        InterpertedMotionState = 0x00,

        MoveToObject = 0x06,

        MoveToPosition = 0x07,

        TurnToObject = 0x08,

        TurnToPosition = 0x09,

    };
}
