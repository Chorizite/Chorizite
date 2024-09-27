using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S {
    /// <summary>
    /// Sent if player is an PSR, I assume it displays the server version number
    /// </summary>
    public class Admin_SendAdminGetServerVersion : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7CC;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Admin_SendAdminGetServerVersion;

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
