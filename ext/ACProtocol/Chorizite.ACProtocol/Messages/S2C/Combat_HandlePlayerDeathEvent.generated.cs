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
    /// A Player Kill occurred nearby (also sent for suicides).
    /// </summary>
    public class Combat_HandlePlayerDeathEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x019E;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Combat_HandlePlayerDeathEvent;

        /// <summary>
        /// The death message
        /// </summary>
        public string Message;

        /// <summary>
        /// The Id of the departed.
        /// </summary>
        public uint KilledId;

        /// <summary>
        /// The Id of the character doing the killing.
        /// </summary>
        public uint KillerId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Message = reader.ReadString16L();
            KilledId = reader.ReadUInt32();
            KillerId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Message);
            writer.Write(KilledId);
            writer.Write(KillerId);
        }

    }

}
