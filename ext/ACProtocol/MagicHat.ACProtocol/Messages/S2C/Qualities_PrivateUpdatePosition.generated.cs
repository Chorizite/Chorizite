using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Set or update a Character Position property value
    /// </summary>
    public class Qualities_PrivateUpdatePosition : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02DB;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_PrivateUpdatePosition;

        /// <summary>
        /// sequence number
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// Position property Id
        /// </summary>
        public PropertyPosition Key;

        /// <summary>
        /// Position property value
        /// </summary>
        public Position Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            Key = (PropertyPosition)reader.ReadUInt32();
            Value = new Position();
            Value.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write((uint)Key);
            Value.Write(writer);
        }

    }

}
