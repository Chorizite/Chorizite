using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Stops a movement
    /// </summary>
    public class Movement_StopMovementCommand : ACGameAction {
        /// <summary>
        /// Motion being stopped
        /// </summary>
        public uint Motion;

        /// <summary>
        /// Key being held
        /// </summary>
        public HoldKey HoldKey;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Motion = reader.ReadUInt32();
            HoldKey = (HoldKey)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Motion);
            writer.Write((uint)HoldKey);
        }

    }

}
