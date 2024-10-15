using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Asks server for a new object description
    /// </summary>
    public class Object_SendForceObjdesc : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF6EA;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Object_SendForceObjdesc;

        /// <summary>
        /// Object to get new Obj Desc for
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
        }

    }

}
