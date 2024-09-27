using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C {
    /// <summary>
    /// A list of dat files that need to be patched
    /// </summary>
    public class DDD_BeginDDDMessage : ACS2CMessage {
        /// <inheritdoc />
        public override uint OpCode => 0xF7E7;

        /// <inheritdoc />
        public override S2CMessageType MessageType => S2CMessageType.DDD_BeginDDDMessage;

        /// <summary>
        /// Amount of data expected
        /// </summary>
        public uint DataExpected;

        public List<DDDRevision> Revisions = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            DataExpected = reader.ReadUInt32();
            Revisions = reader.ReadPackableList<DDDRevision>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(DataExpected);
            writer.WritePackableList(Revisions);
        }

    }

}
