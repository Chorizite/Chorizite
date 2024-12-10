using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Sends a message to a chat channel
    /// </summary>
    public class Communication_ChannelBroadcast : ACGameAction {
        /// <summary>
        /// Channel id
        /// </summary>
        public Channel Channel;

        /// <summary>
        /// the name of the player sending the message
        /// </summary>
        public string SenderName;

        /// <summary>
        /// Message being sent
        /// </summary>
        public string Message;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Channel = (Channel)reader.ReadUInt32();
            SenderName = reader.ReadString16L();
            Message = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Channel);
            writer.Write(SenderName);
            writer.Write(Message);
        }

    }

}
