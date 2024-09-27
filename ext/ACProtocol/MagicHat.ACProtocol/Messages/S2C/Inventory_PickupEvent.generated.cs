using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sent when picking up an object
    /// </summary>
    public class Inventory_PickupEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF74A;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Inventory_PickupEvent;

        /// <summary>
        /// The object being picked up
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The instance sequence value for the object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The position sequence value for the object
        /// </summary>
        public ushort ObjectPositionSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ObjectInstanceSequence = reader.ReadUInt16();
            ObjectPositionSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(ObjectInstanceSequence);
            writer.Write(ObjectPositionSequence);
        }

    }

}
