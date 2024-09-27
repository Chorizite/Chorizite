using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Set&#39;s the current state of the object. Client appears to only process the following state changes post creation: NoDraw, LightingOn, Hidden
    /// </summary>
    public class Item_SetState : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF74B;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_SetState;

        /// <summary>
        /// The object being changed
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The new state for the object
        /// </summary>
        public PhysicsState NewState;

        /// <summary>
        /// The instance sequence value for this object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The state sequence value for this object
        /// </summary>
        public ushort ObjectStateSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            NewState = (PhysicsState)reader.ReadUInt32();
            ObjectInstanceSequence = reader.ReadUInt16();
            ObjectStateSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write((uint)NewState);
            writer.Write(ObjectInstanceSequence);
            writer.Write(ObjectStateSequence);
        }

    }

}
