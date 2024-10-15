using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Friends list update
    /// </summary>
    public class Social_FriendsUpdate : ACGameEvent {
        public List<FriendData> Friends = new();

        /// <summary>
        /// The type of the update
        /// </summary>
        public FriendsUpdateType Type;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Friends = reader.ReadPackableList<FriendData>();
            Type = (FriendsUpdateType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.WritePackableList(Friends);
            writer.Write((uint)Type);
        }

    }

}
