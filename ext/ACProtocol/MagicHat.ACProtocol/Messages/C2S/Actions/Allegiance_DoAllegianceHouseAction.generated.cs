using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Perform the allegiance house action
    /// </summary>
    public class Allegiance_DoAllegianceHouseAction : ACGameAction {
        /// <summary>
        /// Allegiance housing action to take
        /// </summary>
        public AllegianceHouseAction Action;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Action = (AllegianceHouseAction)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write((uint)Action);
        }

    }

}
