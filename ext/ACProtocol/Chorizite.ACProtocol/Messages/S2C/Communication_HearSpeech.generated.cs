using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
    /// </summary>
    public class Communication_HearSpeech : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02BB;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_HearSpeech;

        /// <summary>
        /// message text
        /// </summary>
        public string Message;

        /// <summary>
        /// sender name
        /// </summary>
        public string SenderName;

        /// <summary>
        /// sender Id
        /// </summary>
        public uint SenderId;

        /// <summary>
        /// message type
        /// </summary>
        public ChatFragmentType Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Message = reader.ReadString16L();
            SenderName = reader.ReadString16L();
            SenderId = reader.ReadUInt32();
            Type = (ChatFragmentType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Message);
            writer.Write(SenderName);
            writer.Write(SenderId);
            writer.Write((uint)Type);
        }

    }

}
