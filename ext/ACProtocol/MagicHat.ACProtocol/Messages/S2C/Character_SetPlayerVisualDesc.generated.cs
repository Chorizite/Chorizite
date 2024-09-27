using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// Sets the player visual desc, TODO confirm this
    /// </summary>
    public class Character_SetPlayerVisualDesc : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF630;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.Character_SetPlayerVisualDesc;

        /// <summary>
        /// Set of visual description information for the player
        /// </summary>
        public ObjDesc ObjectDescription;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectDescription = new ObjDesc();
            ObjectDescription.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            ObjectDescription.Write(writer);
        }

    }

}
