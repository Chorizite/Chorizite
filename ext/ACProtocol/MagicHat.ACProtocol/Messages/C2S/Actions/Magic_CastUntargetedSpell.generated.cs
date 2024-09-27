using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Cast a spell with no target.
    /// </summary>
    public class Magic_CastUntargetedSpell : ACGameAction {
        /// <summary>
        /// The Id of the spell
        /// </summary>
        public LayeredSpellId SpellId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            SpellId = new LayeredSpellId();
            SpellId.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            SpellId.Write(writer);
        }

    }

}
