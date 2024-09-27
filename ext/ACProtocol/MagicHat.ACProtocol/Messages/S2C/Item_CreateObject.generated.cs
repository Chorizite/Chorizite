using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Create an object somewhere in the world
    /// </summary>
    public class Item_CreateObject : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF745;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Item_CreateObject;

        /// <summary>
        /// object Id
        /// </summary>
        public uint ObjectId;

        public ObjDesc ObjectDescription;

        public PhysicsDesc PhysicsDescription;

        public PublicWeenieDesc WeenieDescription;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            ObjectDescription = new ObjDesc();
            ObjectDescription.Read(reader);
            PhysicsDescription = new PhysicsDesc();
            PhysicsDescription.Read(reader);
            WeenieDescription = new PublicWeenieDesc();
            WeenieDescription.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            ObjectDescription.Write(writer);
            PhysicsDescription.Write(writer);
            WeenieDescription.Write(writer);
        }

    }

}
