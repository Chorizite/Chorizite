using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Failure to give an item
    /// </summary>
    public class Character_ServerSaysAttemptFailed : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x00A0;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Character_ServerSaysAttemptFailed;

        /// <summary>
        /// Item that could not be given
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Failure reason code
        /// </summary>
        public WeenieError Reason;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Reason = (WeenieError)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write((uint)Reason);
        }

    }

}
