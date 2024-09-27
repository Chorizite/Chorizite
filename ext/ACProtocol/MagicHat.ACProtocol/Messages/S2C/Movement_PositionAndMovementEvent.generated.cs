using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sets both the position and movement, such as when materializing at a lifestone
    /// </summary>
    public class Movement_PositionAndMovementEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF619;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Movement_PositionAndMovementEvent;

        /// <summary>
        /// ObjectId of the character doing the animation
        /// </summary>
        public uint ObjectId;

        public PositionPack Position;

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
            Position = new PositionPack();
            Position.Read(reader);
            MovementData = new MovementData();
            MovementData.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            Position.Write(writer);
            MovementData.Write(writer);
        }

    }

}
