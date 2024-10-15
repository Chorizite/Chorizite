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
    /// The SkillAdvancementClass identifies whether a skill is untrained, trained or specialized.
    /// </summary>
    public enum SkillAdvancementClass : uint {
        Untrained = 0x01,

        Trained = 0x02,

        Specialized = 0x03,

    };
}
