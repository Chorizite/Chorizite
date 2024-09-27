using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Add/Update a member to your fellowship.
    /// </summary>
    public class Fellowship_UpdateFellow : ACGameEvent {
        public Fellow Fellow;

        public FellowUpdateType UpdateType;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Fellow = new Fellow();
            Fellow.Read(reader);
            UpdateType = (FellowUpdateType)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            Fellow.Write(writer);
            writer.Write((uint)UpdateType);
        }

    }

}
