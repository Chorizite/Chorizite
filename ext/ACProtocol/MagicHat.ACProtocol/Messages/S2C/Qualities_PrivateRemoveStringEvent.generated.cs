using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Remove a string property from the character
    /// </summary>
    public class Qualities_PrivateRemoveStringEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x01D7;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Qualities_PrivateRemoveStringEvent;

        public byte Sequence;

        public PropertyString Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Sequence = reader.ReadByte();
            Type = (PropertyString)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Sequence);
            writer.Write((uint)Type);
        }

    }

}
