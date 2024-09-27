using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Merges one stack with another
    /// </summary>
    public class Inventory_StackableMerge : ACGameAction {
        /// <summary>
        /// Id of object where items are being taken from
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Id of object where items are being merged into
        /// </summary>
        public uint TargetId;

        /// <summary>
        /// Number of items from the source stack to be added to the destination stack
        /// </summary>
        public uint Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            TargetId = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(TargetId);
            writer.Write(Amount);
        }

    }

}
