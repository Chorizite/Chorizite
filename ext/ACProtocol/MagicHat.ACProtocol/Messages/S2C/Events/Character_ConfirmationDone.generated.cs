using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Confirmation done
    /// </summary>
    public class Character_ConfirmationDone : ACGameEvent {
        /// <summary>
        /// the type of confirmation panel being closed
        /// </summary>
        public ConfirmationType ConfirmationType;

        /// <summary>
        /// sequence number
        /// </summary>
        public uint ContextId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ConfirmationType = (ConfirmationType)reader.ReadUInt32();
            ContextId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)ConfirmationType);
            writer.Write(ContextId);
        }

    }

}
