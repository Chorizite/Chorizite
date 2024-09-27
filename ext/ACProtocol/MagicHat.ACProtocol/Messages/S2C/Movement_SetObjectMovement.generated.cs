using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// These are animations. Whenever a human, monster or object moves - one of these little messages is sent. Even idle emotes (like head scratching and nodding) are sent in this manner.
    /// </summary>
    public class Movement_SetObjectMovement : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF74C;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Movement_SetObjectMovement;

        /// <summary>
        /// Id of the character moving
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The instance sequence value for this object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// Set of movement data
        /// </summary>
        public MovementData MovementData;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ObjectInstanceSequence = reader.ReadUInt16();
            MovementData = new MovementData();
            MovementData.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ObjectInstanceSequence);
            MovementData.Write(writer);
        }

    }

}
