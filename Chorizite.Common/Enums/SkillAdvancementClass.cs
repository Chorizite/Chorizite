//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


namespace Chorizite.Common.Enums {
    /// <summary>
    /// The SkillAdvancementClass identifies whether a skill is untrained, trained or specialized.
    /// </summary>
    public enum SkillAdvancementClass : uint {
        Unusable = 0x00,

        Untrained = 0x01,

        Trained = 0x02,

        Specialized = 0x03,
    };
}
