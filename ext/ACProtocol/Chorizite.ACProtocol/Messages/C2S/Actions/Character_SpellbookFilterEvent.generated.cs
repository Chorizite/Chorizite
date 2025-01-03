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
    /// Changes the spell book filter
    /// </summary>
    public class Character_SpellbookFilterEvent : ACGameAction {
        /// <summary>
        /// Mask containing the different filters applied to the spellbook
        /// </summary>
        public SpellBookFilterOptions Options;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Options = (SpellBookFilterOptions)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Options);
        }

    }

}
