using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Someone has sent you a @tell.
    /// </summary>
    public class Communication_HearDirectSpeech : ACGameEvent {
        /// <summary>
        /// the message text
        /// </summary>
        public string Message;

        /// <summary>
        /// the name of the creature sending you the message
        /// </summary>
        public string SenderName;

        /// <summary>
        /// the object Id of the creature sending you the message
        /// </summary>
        public uint SenderId;

        /// <summary>
        /// the object Id of the recipient of the message (should be you)
        /// </summary>
        public uint TargetId;

        /// <summary>
        /// the message type, controls color and @filter processing
        /// </summary>
        public ChatFragmentType Type;

        /// <summary>
        /// doesn&#39;t seem to be used by the client
        /// </summary>
        public uint SecretFlags;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Message = reader.ReadString16L();
            SenderName = reader.ReadString16L();
            SenderId = reader.ReadUInt32();
            TargetId = reader.ReadUInt32();
            Type = (ChatFragmentType)reader.ReadUInt32();
            SecretFlags = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Message);
            writer.Write(SenderName);
            writer.Write(SenderId);
            writer.Write(TargetId);
            writer.Write((uint)Type);
            writer.Write(SecretFlags);
        }

    }

}
