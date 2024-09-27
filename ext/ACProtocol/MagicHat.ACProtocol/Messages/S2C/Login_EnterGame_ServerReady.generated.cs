using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Switch from the character display to the game display.
    /// </summary>
    public class Login_EnterGame_ServerReady : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7DF;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Login_EnterGame_ServerReady;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
        }

    }

}
