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
    /// The list of characters on the current account.
    /// </summary>
    public class Login_LoginCharacterSet : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF658;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_LoginCharacterSet;

        public uint Status;

        public List<CharacterIdentity> Characters = new();

        public List<CharacterIdentity> DeletedCharacters = new();

        /// <summary>
        /// The total count of character slots this server supports.
        /// </summary>
        public uint NumAllowedCharacters;

        /// <summary>
        /// The name for this account.
        /// </summary>
        public string Account;

        /// <summary>
        /// Whether or not Turbine Chat (Allegiance chat) enabled.
        /// </summary>
        public bool UseTurbineChat;

        /// <summary>
        /// Whether or not this account has purchansed ToD
        /// </summary>
        public bool HasThroneofDestiny;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Status = reader.ReadUInt32();
            Characters = reader.ReadPackableList<CharacterIdentity>();
            DeletedCharacters = reader.ReadPackableList<CharacterIdentity>();
            NumAllowedCharacters = reader.ReadUInt32();
            Account = reader.ReadString16L();
            UseTurbineChat = reader.ReadBool();
            HasThroneofDestiny = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Status);
            writer.WritePackableList(Characters);
            writer.WritePackableList(DeletedCharacters);
            writer.Write(NumAllowedCharacters);
            writer.Write(Account);
            writer.Write(UseTurbineChat);
            writer.Write(HasThroneofDestiny);
        }

    }

}
