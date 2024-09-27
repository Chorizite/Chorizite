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
    /// Flags related to the use of the item.
    /// </summary>
    [Flags]
    public enum ObjectDescriptionFlag : uint {
        /// <summary>
        /// can be opened (false if locked)
        /// </summary>
        Openable = 0x00000001,

        /// <summary>
        /// inscribable
        /// </summary>
        Inscribable = 0x00000002,

        /// <summary>
        /// cannot be picked up
        /// </summary>
        Stuck = 0x00000004,

        /// <summary>
        /// player
        /// </summary>
        Player = 0x00000008,

        /// <summary>
        /// attackable
        /// </summary>
        Attackable = 0x00000010,

        /// <summary>
        /// player killer
        /// </summary>
        PlayerKiller = 0x00000020,

        /// <summary>
        /// hidden admin
        /// </summary>
        HiddenAdmin = 0x00000040,

        /// <summary>
        /// hidden
        /// </summary>
        UiHidden = 0x00000080,

        /// <summary>
        /// book
        /// </summary>
        Book = 0x00000100,

        /// <summary>
        /// merchant
        /// </summary>
        Vendor = 0x00000200,

        /// <summary>
        /// pk altar
        /// </summary>
        PkSwitch = 0x00000400,

        /// <summary>
        /// npk altar
        /// </summary>
        NpkSwitch = 0x00000800,

        /// <summary>
        /// door
        /// </summary>
        Door = 0x00001000,

        /// <summary>
        /// corpse
        /// </summary>
        Corpse = 0x00002000,

        /// <summary>
        /// lifestone
        /// </summary>
        LifeStone = 0x00004000,

        /// <summary>
        /// food
        /// </summary>
        Food = 0x00008000,

        /// <summary>
        /// healing kit
        /// </summary>
        Healer = 0x00010000,

        /// <summary>
        /// lockpick
        /// </summary>
        Lockpick = 0x00020000,

        /// <summary>
        /// portal
        /// </summary>
        Portal = 0x00040000,

        /// <summary>
        /// admin
        /// </summary>
        Admin = 0x00100000,

        /// <summary>
        /// free pk status
        /// </summary>
        FreePkStatus = 0x00200000,

        /// <summary>
        /// immute cell restrictions
        /// </summary>
        ImmuneCellRestrictions = 0x00400000,

        /// <summary>
        /// requires pack slot
        /// </summary>
        RequiresPackSlot = 0x00800000,

        /// <summary>
        /// retained
        /// </summary>
        Retained = 0x01000000,

        /// <summary>
        /// pklite status
        /// </summary>
        PkLiteStatus = 0x02000000,

        /// <summary>
        /// has an extra flags DWORD
        /// </summary>
        IncludesSecondHeader = 0x04000000,

        /// <summary>
        /// bindstone
        /// </summary>
        BindStone = 0x08000000,

        /// <summary>
        /// volatile rare
        /// </summary>
        VolatileRare = 0x10000000,

        /// <summary>
        /// wield on use
        /// </summary>
        WieldOnUse = 0x20000000,

        /// <summary>
        /// wield left
        /// </summary>
        WieldLeft = 0x40000000,

    };
}
