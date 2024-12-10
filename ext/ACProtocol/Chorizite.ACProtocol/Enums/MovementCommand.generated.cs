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
    /// The movement (forward, side, turn) for a character or monster.
    /// </summary>
    public enum MovementCommand : ushort {
        HoldRun = 0x01,

        HoldSidestep = 0x02,

        WalkForward = 0x05,

        WalkBackwards = 0x06,

        RunForward = 0x07,

        TurnRight = 0x0D,

        TurnLeft = 0x0E,

        SideStepRight = 0x0F,

        SideStepLeft = 0x10,

    };
}
