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
    /// The type response to a chargen request
    /// </summary>
    public enum CharGenResponseType : uint {
        OK = 0x0001,

        NameInUse = 0x0003,

        NameBanned = 0x0004,

        Corrupt = 0x0005,

        Corrupt_0x0006 = 0x0006,

        AdminPrivilegeDenied = 0x0007,

    };
}
