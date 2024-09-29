using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Remove multiple enchantments from your character.
    /// </summary>
    public class Magic_RemoveMultipleEnchantments : ACGameEvent {
        /// <summary>
        /// List of enchantments getting removed
        /// </summary>
        public List<LayeredSpellId> Enchantments = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Enchantments = reader.ReadPackableList<LayeredSpellId>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.WritePackableList(Enchantments);
        }

    }

}