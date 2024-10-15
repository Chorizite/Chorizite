using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S {
    /// <summary>
    /// Admin command to restore a character
    /// </summary>
    public class Admin_SendAdminRestoreCharacter : ACC2SMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7D9;

        /// <inheritdoc />
        public override C2SMessageType MessageType => C2SMessageType.Admin_SendAdminRestoreCharacter;

        /// <summary>
        /// Id of character to restore
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Name of character to restore
        /// </summary>
        public string RestoredCharName;

        /// <summary>
        /// Account name to restore the character on
        /// </summary>
        public string AccountToRestoreTo;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            RestoredCharName = reader.ReadString16L();
            AccountToRestoreTo = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(RestoredCharName);
            writer.Write(AccountToRestoreTo);
        }

    }

}
