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
    /// The various options for filtering the spellbook
    /// </summary>
    [Flags]
    public enum SpellBookFilterOptions : uint {
        None = 0x00000000,

        Creature = 0x00000001,

        Item = 0x00000002,

        Life = 0x00000004,

        War = 0x00000008,

        Level1 = 0x00000010,

        Level2 = 0x00000020,

        Level3 = 0x00000040,

        Level4 = 0x00000080,

        Level5 = 0x00000100,

        Level6 = 0x00000200,

        Level7 = 0x00000400,

        Level8 = 0x00000800,

        Level9 = 0x00001000,

        Void = 0x00002000,

    };
}
