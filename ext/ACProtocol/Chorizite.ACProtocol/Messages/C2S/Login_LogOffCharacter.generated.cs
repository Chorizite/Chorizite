using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Instructs the client to return to 2D mode - the character list.
    /// </summary>
    public class Login_LogOffCharacter : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF653;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Login_LogOffCharacter;

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
