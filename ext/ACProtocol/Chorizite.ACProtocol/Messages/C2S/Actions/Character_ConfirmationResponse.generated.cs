using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Confirms a dialog
    /// </summary>
    public class Character_ConfirmationResponse : ACGameAction {
        public ConfirmationType Type;

        public uint Context;

        public bool Accepted;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Type = (ConfirmationType)reader.ReadUInt32();
            Context = reader.ReadUInt32();
            Accepted = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Type);
            writer.Write(Context);
            writer.Write(Accepted);
        }

    }

}
