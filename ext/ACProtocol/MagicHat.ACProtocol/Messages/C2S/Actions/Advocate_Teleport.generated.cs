using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Advocate Teleport
    /// </summary>
    public class Advocate_Teleport : ACGameAction {
        /// <summary>
        /// Person being teleported
        /// </summary>
        public string ObjectId;

        /// <summary>
        /// Destination to teleport target to
        /// </summary>
        public Position Destination;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadString16L();
            Destination = new Position();
            Destination.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            Destination.Write(writer);
        }

    }

}
