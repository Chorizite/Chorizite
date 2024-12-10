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
    /// Stage a contract is in.  Values 4+ appear to provide contract specific update messages
    /// </summary>
    public enum ContractStage : uint {
        New = 0x01,

        InProgress = 0x02,

        /// <summary>
        /// If this is set, it looks at the time when repeats to show either Done, Available, or # to Repeat
        /// </summary>
        DoneOrPendingRepeat = 0x03,

    };
}
