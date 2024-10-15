using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Indirect &#39;/e&#39; text.
    /// </summary>
    public class Communication_HearEmote : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x01E0;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_HearEmote;

        /// <summary>
        /// The Id of the character performing the emote - used for squelch/radar filtering.
        /// </summary>
        public uint SenderId;

        /// <summary>
        /// Name of the character performing the emote.
        /// </summary>
        public string SenderName;

        /// <summary>
        /// Text representation of the emote.
        /// </summary>
        public string Text;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            SenderId = reader.ReadUInt32();
            SenderName = reader.ReadString16L();
            Text = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(SenderId);
            writer.Write(SenderName);
            writer.Write(Text);
        }

    }

}
