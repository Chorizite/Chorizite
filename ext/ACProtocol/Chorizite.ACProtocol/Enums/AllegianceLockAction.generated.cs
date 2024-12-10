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
    /// Actions related to /allegiance lock
    /// </summary>
    public enum AllegianceLockAction : uint {
        LockedOff = 0x01,

        LockedOn = 0x02,

        ToggleLocked = 0x03,

        CheckLocked = 0x04,

        DisplayBypass = 0x05,

        ClearBypass = 0x06,

    };
}
