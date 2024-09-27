using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sets the position/motion of an object
    /// </summary>
    public class Movement_PositionEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF748;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Movement_PositionEvent;

        /// <summary>
        /// The object with the position changing.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The current or starting location.
        /// </summary>
        public PositionPack Position;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Position = new PositionPack();
            Position.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            Position.Write(writer);
        }

    }

}
