using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// For stackable items, this changes the number of items in the stack.
    /// </summary>
    public class Item_UpdateStackSize : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x0197;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_UpdateStackSize;

        /// <summary>
        /// Sequence number for this message
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// Item getting it&#39;s stack adjusted.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// New number of items in the stack.
        /// </summary>
        public uint Amount;

        /// <summary>
        /// New value for the item.
        /// </summary>
        public uint NewValue;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            ObjectId = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
            NewValue = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write(ObjectId);
            writer.Write(Amount);
            writer.Write(NewValue);
        }

    }

}
