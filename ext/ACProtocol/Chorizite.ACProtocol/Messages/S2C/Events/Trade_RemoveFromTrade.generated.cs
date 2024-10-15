using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Removes an item from the trade window, not sure if this is used still?
    /// </summary>
    public class Trade_RemoveFromTrade : ACGameEvent {
        /// <summary>
        /// The item being removed from the trade window
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Side of the trade window object was removed
        /// </summary>
        public TradeSide Side;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Side = (TradeSide)reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write((uint)Side);
        }

    }

}
