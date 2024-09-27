using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// TradeFailure: Failure to add a trade item
    /// </summary>
    public class Trade_TradeFailure : ACGameEvent {
        /// <summary>
        /// Item that could not be added to trade window
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The numeric reason it couldn&#39;t be traded. Client does not appear to use this.
        /// </summary>
        public uint Reason;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Reason = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(Reason);
        }

    }

}
