using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Sends an abuse report.
    /// </summary>
    public class Character_AbuseLogRequest : ACGameAction {
        /// <summary>
        /// Name of character
        /// </summary>
        public string Character;

        /// <summary>
        /// 1
        /// </summary>
        public uint Status;

        /// <summary>
        /// Description of complaint
        /// </summary>
        public string Complaint;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            Character = reader.ReadString16L();
            Status = reader.ReadUInt32();
            Complaint = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(Character);
            writer.Write(Status);
            writer.Write(Complaint);
        }

    }

}
