using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
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
