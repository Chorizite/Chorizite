using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S {
    /// <summary>
    /// Ends DDD update
    /// </summary>
    public class DDD_OnEndDDD : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7EA;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.DDD_OnEndDDD;

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