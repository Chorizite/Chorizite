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
    public enum HookGroupType : uint {
        Undef = 0x0,

        NoisemakingItems = 0x1,

        TestItems = 0x2,

        PortalItems = 0x4,

        WritableItems = 0x8,

        SpellCastingItems = 0x10,

        SpellTeachingItems = 0x20,

    };
}
