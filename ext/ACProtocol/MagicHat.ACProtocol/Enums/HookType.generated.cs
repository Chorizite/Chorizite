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
    /// The HookType identifies the types of dwelling hooks.
    /// </summary>
    [Flags]
    public enum HookType : ushort {
        Floor = 0x0001,

        Wall = 0x0002,

        Ceiling = 0x0004,

        Yard = 0x0008,

        Roof = 0x0010,

    };
}
