using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Login of player
    /// </summary>
    public class Login_CreatePlayer : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF746;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_CreatePlayer;

        /// <summary>
        /// Id of the character logging on - should be you.
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterId);
        }

    }

}
