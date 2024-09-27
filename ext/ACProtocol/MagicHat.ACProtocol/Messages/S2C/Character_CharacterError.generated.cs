using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Failure to log in
    /// </summary>
    public class Character_CharacterError : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF659;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Character_CharacterError;

        /// <summary>
        /// Identifies type of error
        /// </summary>
        public CharacterErrorType Reason;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Reason = (CharacterErrorType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Reason);
        }

    }

}
