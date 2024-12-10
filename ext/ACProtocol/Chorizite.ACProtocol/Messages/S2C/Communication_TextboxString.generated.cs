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
    /// Display a message in the chat window.
    /// </summary>
    public class Communication_TextboxString : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E0;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Communication_TextboxString;

        /// <summary>
        /// the message text
        /// </summary>
        public string Text;

        /// <summary>
        /// the message type, controls color and @filter processing
        /// </summary>
        public ChatFragmentType Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Text = reader.ReadString16L();
            Type = (ChatFragmentType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Text);
            writer.Write((uint)Type);
        }

    }

}
