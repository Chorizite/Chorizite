using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Contains the text associated with an emote action.
    /// </summary>
    public class Communication_HearSoulEmote : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0x01E2;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_HearSoulEmote;

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
