using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sent whenever a character changes their clothes. It contains the entire description of what their wearing (and possibly their facial features as well). This message is only sent for changes, when the character is first created, the body of this message is included inside the creation message.
    /// </summary>
    public class Item_ObjDescEvent : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF625;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_ObjDescEvent;

        /// <summary>
        /// The Id of character whose visual description is changing.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Set of visual description information for the object
        /// </summary>
        public ObjDesc ObjectDescription;

        /// <summary>
        /// The instance sequence value for the object (number of logins for players)
        /// </summary>
        public ushort InstanceSequence;

        /// <summary>
        /// The position sequence value for the object
        /// </summary>
        public ushort VisualDescSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ObjectDescription = new ObjDesc();
            ObjectDescription.Read(reader);
            InstanceSequence = reader.ReadUInt16();
            VisualDescSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            ObjectDescription.Write(writer);
            writer.Write(InstanceSequence);
            writer.Write(VisualDescSequence);
        }

    }

}
