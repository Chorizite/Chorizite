using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Instructs the client to show the portal graphic.
    /// </summary>
    public class Effects_PlayerTeleport : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF751;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Effects_PlayerTeleport;

        /// <summary>
        /// The teleport sequence value for the object
        /// </summary>
        public ushort ObjectTeleportSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectTeleportSequence = reader.ReadUInt16();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectTeleportSequence);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
