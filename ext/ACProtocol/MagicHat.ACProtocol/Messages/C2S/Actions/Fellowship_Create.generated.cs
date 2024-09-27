using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Create a fellowship
    /// </summary>
    public class Fellowship_Create : ACGameAction {
        /// <summary>
        /// Name of the fellowship
        /// </summary>
        public string Name;

        /// <summary>
        /// Whether fellowship shares xp
        /// </summary>
        public bool ShareXP;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Name = reader.ReadString16L();
            ShareXP = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Name);
            writer.Write(ShareXP);
        }

    }

}
