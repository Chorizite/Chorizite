using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// TODO
    /// </summary>
    public class DDD_InterrogationResponseMessage : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E6;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.DDD_InterrogationResponseMessage;

        public uint Language;

        public List<long> Files = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Language = reader.ReadUInt32();
            Files = reader.ReadPackableList<long>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Language);
            writer.WritePackableList(Files);
        }

    }

}
