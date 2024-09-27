using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
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
