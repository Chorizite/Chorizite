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
    /// Boots a player from the allegiance, optionally all characters on their account
    /// </summary>
    public class Allegiance_BreakAllegianceBoot : ACGameAction {
        /// <summary>
        /// Name of character to boot
        /// </summary>
        public string BooteeName;

        /// <summary>
        /// Whether to boot all characters on their account
        /// </summary>
        public bool AccountBoot;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BooteeName = reader.ReadString16L();
            AccountBoot = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(BooteeName);
            writer.Write(AccountBoot);
        }

    }

}
