using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Set or update a Character Int property value
    /// </summary>
    public class Qualities_PrivateUpdateInt : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02CD;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_PrivateUpdateInt;

        /// <summary>
        /// sequence number
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// Int property Id
        /// </summary>
        public PropertyInt Key;

        /// <summary>
        /// Int property value
        /// </summary>
        public int Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            Key = (PropertyInt)reader.ReadUInt32();
            Value = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write((uint)Key);
            writer.Write(Value);
        }

    }

}
