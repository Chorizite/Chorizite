using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// A message to be displayed in the chat window, spoken by a nearby player, NPC or creature
    /// </summary>
    public class Communication_HearRangedSpeech : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x02BC;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_HearRangedSpeech;

        /// <summary>
        /// message text
        /// </summary>
        public string Message;

        /// <summary>
        /// sender name
        /// </summary>
        public string SenderName;

        /// <summary>
        /// sender Id, must be between 0x50000001 and 0x6FFFFFFF to appear as clickable
        /// </summary>
        public uint SenderId;

        /// <summary>
        /// broadcast range
        /// </summary>
        public float Range;

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
            Range = reader.ReadSingle();
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
            writer.Write(Range);
            writer.Write((uint)Type);
        }

    }

}
