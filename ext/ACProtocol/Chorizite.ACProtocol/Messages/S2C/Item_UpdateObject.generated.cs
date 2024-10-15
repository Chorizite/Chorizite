using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Update an existing object&#39;s data.
    /// </summary>
    public class Item_UpdateObject : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7DB;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_UpdateObject;

        /// <summary>
        /// the object being updated
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// updated model data
        /// </summary>
        public ObjDesc ObjectDesc;

        /// <summary>
        /// updated physics data
        /// </summary>
        public PhysicsDesc PhysicsDesc;

        /// <summary>
        /// updated game data
        /// </summary>
        public PublicWeenieDesc WeenieDesc;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ObjectDesc = new ObjDesc();
            ObjectDesc.Read(reader);
            PhysicsDesc = new PhysicsDesc();
            PhysicsDesc.Read(reader);
            WeenieDesc = new PublicWeenieDesc();
            WeenieDesc.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            ObjectDesc.Write(writer);
            PhysicsDesc.Write(writer);
            WeenieDesc.Write(writer);
        }

    }

}
