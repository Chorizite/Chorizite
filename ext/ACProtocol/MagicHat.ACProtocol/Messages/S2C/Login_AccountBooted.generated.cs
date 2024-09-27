using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
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
