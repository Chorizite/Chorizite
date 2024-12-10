//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// Contains information related to the spells in effect on the character
    /// </summary>
    public class EnchantmentRegistry : IACDataType {
        /// <summary>
        /// Flags that determine what data is contained in the EnchantmentRegistry
        /// </summary>
        public EnchantmentRegistryFlags Flags;

        /// <summary>
        /// Life spells active on the player
        /// </summary>
        public List<Enchantment> LifeSpells = new();

        /// <summary>
        /// Creature spells active on the player
        /// </summary>
        public List<Enchantment> CreatureSpells = new();

        /// <summary>
        /// Vitae Penalty.
        /// </summary>
        public Enchantment Vitae;

        /// <summary>
        /// Cooldown spells active on the player
        /// </summary>
        public List<Enchantment> Cooldowns = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = (EnchantmentRegistryFlags)reader.ReadUInt32();
            if (Flags.HasFlag(EnchantmentRegistryFlags.LifeSpells)) {
                LifeSpells = reader.ReadPackableList<Enchantment>();
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.CreatureSpells)) {
                CreatureSpells = reader.ReadPackableList<Enchantment>();
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.Vitae)) {
                Vitae = new Enchantment();
                Vitae.Read(reader);
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.Cooldowns)) {
                Cooldowns = reader.ReadPackableList<Enchantment>();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Flags);
            if (Flags.HasFlag(EnchantmentRegistryFlags.LifeSpells)) {
                writer.WritePackableList(LifeSpells);
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.CreatureSpells)) {
                writer.WritePackableList(CreatureSpells);
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.Vitae)) {
                Vitae.Write(writer);
            }
            if (Flags.HasFlag(EnchantmentRegistryFlags.Cooldowns)) {
                writer.WritePackableList(Cooldowns);
            }
        }

    }

}
