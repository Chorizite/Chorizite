using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// The character to log in.
    /// </summary>
    public class Login_SendEnterWorld : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF657;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Login_SendEnterWorld;

        /// <summary>
        /// The character Id of the character to log in
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// The account name associated with the character
        /// </summary>
        public string Account;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterId = reader.ReadUInt32();
            Account = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterId);
            writer.Write(Account);
        }

    }

}
