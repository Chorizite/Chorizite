using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Give an item to someone.
    /// </summary>
    public class Inventory_GiveObjectRequest : ACGameAction {
        /// <summary>
        /// The recipient of the item
        /// </summary>
        public uint TargetId;

        /// <summary>
        /// The item being given
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The amount from a stack being given
        /// </summary>
        public uint Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            TargetId = reader.ReadUInt32();
            ObjectId = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(TargetId);
            writer.Write(ObjectId);
            writer.Write(Amount);
        }

    }

}
