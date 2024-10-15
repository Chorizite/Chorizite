using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Mark a character for deletetion.
    /// </summary>
    public class Character_CharacterDelete : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF655;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Character_CharacterDelete;

        /// <summary>
        /// The account for the character
        /// </summary>
        public string Account;

        /// <summary>
        /// Slot to delete
        /// </summary>
        public int Slot;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Account = reader.ReadString16L();
            Slot = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Account);
            writer.Write(Slot);
        }

    }

}
