using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Remove an int property from an object
    /// </summary>
    public class Qualities_RemoveIntEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x01D2;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_RemoveIntEvent;

        public byte Sequence;

        /// <summary>
        /// Id of object being updated
        /// </summary>
        public uint ObjectId;

        public PropertyInt Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            ObjectId = reader.ReadUInt32();
            Type = (PropertyInt)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write(ObjectId);
            writer.Write((uint)Type);
        }

    }

}
