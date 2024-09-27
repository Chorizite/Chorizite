using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Contains the text of a single page of a book, parchment or sign.
    /// </summary>
    public class Writing_BookPageDataResponse : ACGameEvent {
        /// <summary>
        /// The object id for the readable object.
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// The 0-based index of the page you are currently viewing.
        /// </summary>
        public uint Page;

        public PageData PageData;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Page = reader.ReadUInt32();
            PageData = new PageData();
            PageData.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(Page);
            PageData.Write(writer);
        }

    }

}
