using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Admin Receive Account Data
    /// </summary>
    public class Admin_ReceiveAccountData : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7CA;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Admin_ReceiveAccountData;

        public uint Unknown;

        /// <summary>
        /// Set of account data
        /// </summary>
        public List<AdminAccountData> AdminAccountData = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Unknown = reader.ReadUInt32();
            AdminAccountData = reader.ReadPackableList<AdminAccountData>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Unknown);
            writer.WritePackableList(AdminAccountData);
        }

    }

}
