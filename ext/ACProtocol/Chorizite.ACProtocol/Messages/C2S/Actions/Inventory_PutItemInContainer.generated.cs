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
    /// Store an item in a container.
    /// </summary>
    public class Inventory_PutItemInContainer : ACGameAction {
        /// <summary>
        /// The item being stored
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The container the item is being stored in
        /// </summary>
        public uint ContainerId;

        /// <summary>
        /// The position in the container where the item is being placed
        /// </summary>
        public uint SlotIndex;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ContainerId = reader.ReadUInt32();
            SlotIndex = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ContainerId);
            writer.Write(SlotIndex);
        }

    }

}
