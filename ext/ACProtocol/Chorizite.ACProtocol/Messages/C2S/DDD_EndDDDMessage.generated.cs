using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Ends DDD message update
    /// </summary>
    public class DDD_EndDDDMessage : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7EB;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.DDD_EndDDDMessage;

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
