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
    /// Set or update a Character Vital value
    /// </summary>
    public class Qualities_UpdateAttribute2ndLevel : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02EA;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_UpdateAttribute2ndLevel;

        /// <summary>
        /// sequence number
        /// </summary>
        public byte Sequence;

        /// <summary>
        /// object Id
        /// </summary>
        public uint ObjectId;

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
            ObjectId = reader.ReadUInt32();
            Key = (CurVitalId)reader.ReadUInt32();
            Value = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write(ObjectId);
            writer.Write((uint)Key);
            writer.Write(Value);
        }

    }

}
