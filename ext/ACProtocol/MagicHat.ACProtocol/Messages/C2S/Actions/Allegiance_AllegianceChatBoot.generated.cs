using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Boots a player from the allegiance chat
    /// </summary>
    public class Allegiance_AllegianceChatBoot : ACGameAction {
        /// <summary>
        /// Character name being booted
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Reason for getting booted
        /// </summary>
        public string Reason;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterName = reader.ReadString16L();
            Reason = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterName);
            writer.Write(Reason);
        }

    }

}
