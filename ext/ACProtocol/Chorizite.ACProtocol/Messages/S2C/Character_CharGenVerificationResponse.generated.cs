using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C {
    /// <summary>
    /// Character creation screen initilised.
    /// </summary>
    public class Character_CharGenVerificationResponse : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF643;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Character_CharGenVerificationResponse;

        /// <summary>
        /// Type of response
        /// </summary>
        public CharGenResponseType ResponseType;

        /// <summary>
        /// The character Id for this entry.
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string Name;

        /// <summary>
        /// When 0, this character is not being deleted (not shown crossed out). Otherwise, it&#39;s a countdown timer in the number of seconds until the character is submitted for deletion.
        /// </summary>
        public uint SecondsUntilDeletion;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ResponseType = (CharGenResponseType)reader.ReadUInt32();
            switch((int)ResponseType) {
                case 0x1:
                    CharacterId = reader.ReadUInt32();
                    Name = reader.ReadString16L();
                    SecondsUntilDeletion = reader.ReadUInt32();
                    if ((reader.BaseStream.Position % 4) != 0) {
                        reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
                    }
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)ResponseType);
            switch((int)ResponseType) {
                case 0x1:
                    writer.Write(CharacterId);
                    writer.Write(Name);
                    writer.Write(SecondsUntilDeletion);
                    if ((writer.BaseStream.Position % 4) != 0) {
                        writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
                    }
                    break;
            }
        }

    }

}
