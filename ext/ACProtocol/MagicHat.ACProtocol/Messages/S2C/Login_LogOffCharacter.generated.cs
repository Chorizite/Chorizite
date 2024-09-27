using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Instructs the client to return to 2D mode - the character list.
    /// </summary>
    public class Login_LogOffCharacter : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF653;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_LogOffCharacter;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
        }

    }

}
