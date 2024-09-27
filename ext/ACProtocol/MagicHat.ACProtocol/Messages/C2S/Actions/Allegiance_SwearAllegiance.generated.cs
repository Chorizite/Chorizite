using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Swear allegiance
    /// </summary>
    public class Allegiance_SwearAllegiance : ACGameAction {
        /// <summary>
        /// The person you are swearing allegiance to
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
        }

    }

}
