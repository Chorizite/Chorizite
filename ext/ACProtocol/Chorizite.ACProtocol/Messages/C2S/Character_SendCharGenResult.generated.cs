using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Character creation result
    /// </summary>
    public class Character_SendCharGenResult : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF656;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Character_SendCharGenResult;

        /// <summary>
        /// The account for the character
        /// </summary>
        public string Account;

        /// <summary>
        /// The data for the character generation
        /// </summary>
        public CharGenResult Result;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Account = reader.ReadString16L();
            Result = new CharGenResult();
            Result.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Account);
            Result.Write(writer);
        }

    }

}
