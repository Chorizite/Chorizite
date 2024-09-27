using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Sets an autonomy level
    /// </summary>
    public class Movement_AutonomyLevel : ACGameAction {
        /// <summary>
        /// Seems to be 0, 1 or 2. I think 0/1 is server controlled, 2 is client controlled
        /// </summary>
        public uint AutonomyLevel;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            AutonomyLevel = reader.ReadUInt32();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(AutonomyLevel);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
