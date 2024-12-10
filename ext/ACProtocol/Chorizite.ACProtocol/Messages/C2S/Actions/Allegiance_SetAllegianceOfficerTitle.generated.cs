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
    /// Sets an allegiance officer title for a given level
    /// </summary>
    public class Allegiance_SetAllegianceOfficerTitle : ACGameAction {
        /// <summary>
        /// The allegiance officer level
        /// </summary>
        public AllegianceOfficerLevel Level;

        /// <summary>
        /// The new title for officers at that level
        /// </summary>
        public string Title;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Level = (AllegianceOfficerLevel)reader.ReadUInt32();
            Title = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Level);
            writer.Write(Title);
        }

    }

}
