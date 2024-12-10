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
    /// DDD error
    /// </summary>
    public class DDD_ErrorMessage : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E4;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.DDD_ErrorMessage;

        /// <summary>
        /// the resource type
        /// </summary>
        public uint ResourceType;

        /// <summary>
        /// the resource Id number
        /// </summary>
        public uint ResourceId;

        public uint RError;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ResourceType = reader.ReadUInt32();
            ResourceId = reader.ReadPackedDWORD();
            RError = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ResourceType);
            writer.Write(ResourceId);
            writer.Write(RError);
        }

    }

}
