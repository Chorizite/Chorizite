using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Display a confirmation panel.
    /// </summary>
    public class Character_ConfirmationRequest : ACGameEvent {
        /// <summary>
        /// the type of confirmation panel to display
        /// </summary>
        public ConfirmationType ConfirmationType;

        /// <summary>
        /// sequence number
        /// </summary>
        public uint ContextId;

        /// <summary>
        /// text to be included in the confirmation panel message
        /// </summary>
        public string Text;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ConfirmationType = (ConfirmationType)reader.ReadUInt32();
            ContextId = reader.ReadUInt32();
            Text = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)ConfirmationType);
            writer.Write(ContextId);
            writer.Write(Text);
        }

    }

}
