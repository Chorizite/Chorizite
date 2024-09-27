using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sets the parent for an object, eg. equipting an object.
    /// </summary>
    public class Item_ParentEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF749;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_ParentEvent;

        /// <summary>
        /// id of the parent object
        /// </summary>
        public uint ParentId;

        /// <summary>
        /// id of the child object
        /// </summary>
        public uint ChildId;

        /// <summary>
        /// Location object is being equipt to (Read from CSetup table in dat)
        /// </summary>
        public ParentLocation Location;

        /// <summary>
        /// Placement frame id
        /// </summary>
        public Placement Placement;

        /// <summary>
        /// The instance sequence value for the parent object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The position sequence value for the child object
        /// </summary>
        public ushort ChildPositionSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ParentId = reader.ReadUInt32();
            ChildId = reader.ReadUInt32();
            Location = (ParentLocation)reader.ReadUInt32();
            Placement = (Placement)reader.ReadUInt32();
            ObjectInstanceSequence = reader.ReadUInt16();
            ChildPositionSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ParentId);
            writer.Write(ChildId);
            writer.Write((uint)Location);
            writer.Write((uint)Placement);
            writer.Write(ObjectInstanceSequence);
            writer.Write(ChildPositionSequence);
        }

    }

}
