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
    /// Account has been booted
    /// </summary>
    public class Login_AccountBooted : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7DC;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_AccountBooted;

        public string AdditionalReasonText;

        public string ReasonText;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            AdditionalReasonText = reader.ReadString16L();
            ReasonText = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(AdditionalReasonText);
            writer.Write(ReasonText);
        }

    }

}
