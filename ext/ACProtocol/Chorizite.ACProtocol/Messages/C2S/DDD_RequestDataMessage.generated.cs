using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// DDD request for data
    /// </summary>
    public class DDD_RequestDataMessage : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E3;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.DDD_RequestDataMessage;

        /// <summary>
        /// the resource type
        /// </summary>
        public uint ResourceType;

        /// <summary>
        /// the resource Id number
        /// </summary>
        public uint ResourceId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ResourceType = reader.ReadUInt32();
            ResourceId = reader.ReadPackedDWORD();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ResourceType);
            writer.Write(ResourceId);
        }

    }

}
