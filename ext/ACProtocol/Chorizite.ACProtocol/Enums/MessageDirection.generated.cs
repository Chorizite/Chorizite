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
    public enum MessageDirection : ushort {
        Undef = 0x00,

        /// <summary>
        /// Server to Client messages
        /// </summary>
        ServerToClient = 0x01,

        /// <summary>
        /// Client to Server messages
        /// </summary>
        ClientToServer = 0x02,

    };
}
