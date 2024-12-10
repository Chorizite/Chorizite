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
    /// Indicates what data is present in the ACQualities data
    /// </summary>
    [Flags]
    public enum ACQualitiesFlags : uint {
        Attributes = 0x00000001,

        Skills = 0x00000002,

        Body = 0x00000004,

        SpellBook = 0x00000100,

        Enchantments = 0x00000200,

        EventFilter = 0x00000008,

        Emotes = 0x00000010,

        CreationProfile = 0x00000020,

        PageData = 0x00000040,

        Generators = 0x00000080,

        GeneratorRegistry = 0x00000400,

        GeneratorQueue = 0x00000800,

    };
}
