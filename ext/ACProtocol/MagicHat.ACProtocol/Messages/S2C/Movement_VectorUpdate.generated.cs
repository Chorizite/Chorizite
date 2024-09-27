using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Changes an objects vector, for things like jumping
    /// </summary>
    public class Movement_VectorUpdate : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF74E;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Movement_VectorUpdate;

        /// <summary>
        /// Id of the object being updated
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// new velocity component
        /// </summary>
        public Vector3 Velocity;

        /// <summary>
        /// new omega component
        /// </summary>
        public Vector3 Omega;

        /// <summary>
        /// The instance sequence value for this object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The vector sequence value for this object
        /// </summary>
        public ushort ObjectVectorSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Velocity = reader.ReadVector3();
            Omega = reader.ReadVector3();
            ObjectInstanceSequence = reader.ReadUInt16();
            ObjectVectorSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.WriteVector3(Velocity);
            writer.WriteVector3(Omega);
            writer.Write(ObjectInstanceSequence);
            writer.Write(ObjectVectorSequence);
        }

    }

}
