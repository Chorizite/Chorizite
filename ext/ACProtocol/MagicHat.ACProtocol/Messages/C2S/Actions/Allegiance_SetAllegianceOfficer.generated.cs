using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Sets an allegiance officer
    /// </summary>
    public class Allegiance_SetAllegianceOfficer : ACGameAction {
        /// <summary>
        /// The allegiance officer&#39;s name
        /// </summary>
        public string CharacterName;

        /// <summary>
        /// Level of the officer
        /// </summary>
        public AllegianceOfficerLevel Level;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            CharacterName = reader.ReadString16L();
            Level = (AllegianceOfficerLevel)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(CharacterName);
            writer.Write((uint)Level);
        }

    }

}
