using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// The name of the current world.
    /// </summary>
    public class Login_WorldInfo : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E1;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_WorldInfo;

        /// <summary>
        /// the number of players connected
        /// </summary>
        public uint Connections;

        /// <summary>
        /// the max number of players allowed to connect
        /// </summary>
        public uint MaxConnections;

        /// <summary>
        /// the name of the current world
        /// </summary>
        public string WorldName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Connections = reader.ReadUInt32();
            MaxConnections = reader.ReadUInt32();
            WorldName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Connections);
            writer.Write(MaxConnections);
            writer.Write(WorldName);
        }

    }

}
