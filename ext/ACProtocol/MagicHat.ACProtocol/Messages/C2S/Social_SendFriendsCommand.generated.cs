using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S {
    /// <summary>
    /// Seems to be a legacy friends command, /friends old, for when Jan 2006 event changed the friends list
    /// </summary>
    public class Social_SendFriendsCommand : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7CD;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Social_SendFriendsCommand;

        /// <summary>
        /// Only 0 is used in client, I suspect it is list/display
        /// </summary>
        public uint Command;

        /// <summary>
        /// I assume it would be used to pass a friend to add/remove.  Display passes null string.
        /// </summary>
        public string Player;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Command = reader.ReadUInt32();
            Player = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Command);
            writer.Write(Player);
        }

    }

}
