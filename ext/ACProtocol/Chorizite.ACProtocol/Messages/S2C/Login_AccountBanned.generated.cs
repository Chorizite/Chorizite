using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Account has been banned
    /// </summary>
    public class Login_AccountBanned : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7C1;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_AccountBanned;

        /// <summary>
        /// Timestamp when ban expires, or 0 for permaban
        /// </summary>
        public uint BannedUntil;

        /// <summary>
        /// I believe this will be empty (len=1) in current version
        /// </summary>
        public string Text;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BannedUntil = reader.ReadUInt32();
            Text = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(BannedUntil);
            writer.Write(Text);
        }

    }

}
