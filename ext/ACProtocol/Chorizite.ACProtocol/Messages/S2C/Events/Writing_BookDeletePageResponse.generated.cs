using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Response to an attempt to delete a page from a book.
    /// </summary>
    public class Writing_BookDeletePageResponse : ACGameEvent {
        /// <summary>
        /// The readable object being changed.
        /// </summary>
        public uint BookId;

        /// <summary>
        /// The number the of page being deleted in the book.
        /// </summary>
        public uint PageNumber;

        /// <summary>
        /// Whether the request was successful
        /// </summary>
        public bool Success;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BookId = reader.ReadUInt32();
            PageNumber = reader.ReadUInt32();
            Success = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(BookId);
            writer.Write(PageNumber);
            writer.Write(Success);
        }

    }

}
