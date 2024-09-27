using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S {
    /// <summary>
    /// The user has clicked &#39;Enter&#39;. This message does not contain the Id of the character logging on; that comes later.
    /// </summary>
    public class Login_SendEnterWorldRequest : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7C8;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Login_SendEnterWorldRequest;

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
