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
    /// Flags that determine what data is contained in the EnchantmentRegistry
    /// </summary>
    [Flags]
    public enum EnchantmentRegistryFlags : uint {
        LifeSpells = 0x0001,

        CreatureSpells = 0x0002,

        Vitae = 0x0004,

        Cooldowns = 0x0008,

    };
}
