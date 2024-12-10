using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Display a parameterized status message in the chat window.
    /// </summary>
    public class Communication_WeenieErrorWithString : ACGameEvent {
        /// <summary>
        /// the type of status message to display
        /// </summary>
        public WeenieErrorWithString Type;

        /// <summary>
        /// text to be included in the status message
        /// </summary>
        public string Text;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Type = (WeenieErrorWithString)reader.ReadUInt32();
            Text = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Type);
            writer.Write(Text);
        }

    }

}
