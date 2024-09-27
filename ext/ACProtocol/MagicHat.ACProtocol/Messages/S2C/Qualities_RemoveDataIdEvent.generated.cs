using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Remove an dataId property from an object
    /// </summary>
    public class Qualities_RemoveDataIdEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x01DA;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_RemoveDataIdEvent;

        public byte Sequence;

        /// <summary>
        /// Id of object being updated
        /// </summary>
        public uint ObjectId;

        public PropertyDataId Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            ObjectId = reader.ReadUInt32();
            Type = (PropertyDataId)reader.ReadUInt32();
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
