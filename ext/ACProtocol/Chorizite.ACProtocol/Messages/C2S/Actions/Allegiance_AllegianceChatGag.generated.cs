using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using Chorizite.Common.Enums;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Gags a person in allegiance chat
    /// </summary>
    public class Allegiance_AllegianceChatGag : ACGameAction {
        /// <summary>
        /// Player who is being gagged or ungagged
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Whether the gag is on
        /// </summary>
        public bool On;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterName = reader.ReadString16L();
            On = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterName);
            writer.Write(On);
        }

    }

}
