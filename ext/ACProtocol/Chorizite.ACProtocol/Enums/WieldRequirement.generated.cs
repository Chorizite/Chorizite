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
    public enum WieldRequirement : int {
        Undef = 0,

        Skill = 1,

        RawSkill = 2,

        Attrib = 3,

        RawAttrib = 4,

        SecondaryAttrib = 5,

        RawSecondaryAttrib = 6,

        Level = 7,

        Training = 8,

        IntStat = 9,

        BoolStat = 10,

        CreatureType = 11,

        HeritageType = 12,

    };
}
