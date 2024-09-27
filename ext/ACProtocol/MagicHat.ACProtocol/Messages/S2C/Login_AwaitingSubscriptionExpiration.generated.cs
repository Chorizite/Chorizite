using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sent when your subsciption is about to expire
    /// </summary>
    public class Login_AwaitingSubscriptionExpiration : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF651;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_AwaitingSubscriptionExpiration;

        /// <summary>
        /// Time remaining before your subscription expires.
        /// </summary>
        public uint SecondsRemaining;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            SecondsRemaining = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(SecondsRemaining);
        }

    }

}
