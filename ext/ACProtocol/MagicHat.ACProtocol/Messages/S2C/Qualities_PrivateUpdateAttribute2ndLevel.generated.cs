using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Set or update a Character Vital value
    /// </summary>
    public class Qualities_PrivateUpdateAttribute2ndLevel : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02E9;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_PrivateUpdateAttribute2ndLevel;

        /// <summary>
        /// sequence number
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// vital Id
        /// </summary>
        public CurVitalId Key;

        /// <summary>
        /// current value
        /// </summary>
        public uint Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            Key = (CurVitalId)reader.ReadUInt32();
            Value = reader.ReadUInt32();
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
