using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Update an item&#39;s mana bar.
    /// </summary>
    public class Item_QueryItemManaResponse : ACGameEvent {
        /// <summary>
        /// the object Id of the item
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// the amount of mana remaining, scaled from 0.0 (none) to 1.0 (full)
        /// </summary>
        public float Mana;

        /// <summary>
        /// show mana bar: 0=no, 1=yes
        /// </summary>
        public bool Success;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Mana = reader.ReadSingle();
            Success = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(Mana);
            writer.Write(Success);
        }

    }

}
