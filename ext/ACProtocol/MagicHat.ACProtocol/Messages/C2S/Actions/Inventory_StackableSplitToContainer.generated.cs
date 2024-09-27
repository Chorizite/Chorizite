using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Split a stack and place it into a container
    /// </summary>
    public class Inventory_StackableSplitToContainer : ACGameAction {
        /// <summary>
        /// Id of object where items are being taken from
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Id of container where items are being moved to
        /// </summary>
        public uint ContainerId;

        /// <summary>
        /// Slot in container where items are being moved to
        /// </summary>
        public uint SlotIndex;

        /// <summary>
        /// Number of items from the stack to placed into the container
        /// </summary>
        public uint Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ContainerId = reader.ReadUInt32();
            SlotIndex = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ContainerId);
            writer.Write(SlotIndex);
            writer.Write(Amount);
        }

    }

}
