using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// Sent when you first open a book, contains the entire table of contents.
    /// </summary>
    public class Writing_BookOpen : ACGameEvent {
        /// <summary>
        /// The readable object you have just opened.
        /// </summary>
        public uint BookId;

        /// <summary>
        /// The total number of pages in the book.
        /// </summary>
        public uint MaxNumPages;

        /// <summary>
        /// The set of page data
        /// </summary>
        public PageDataList PageData;

        /// <summary>
        /// The inscription comment and the book title.
        /// </summary>
        public string Inscription;

        /// <summary>
        /// The author of the inscription (and not coincidentally, the book title).
        /// </summary>
        public uint ScribeId;

        /// <summary>
        /// The name of the inscription author.
        /// </summary>
        public string ScribeName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BookId = reader.ReadUInt32();
            MaxNumPages = reader.ReadUInt32();
            PageData = new PageDataList();
            PageData.Read(reader);
            Inscription = reader.ReadString16L();
            ScribeId = reader.ReadUInt32();
            ScribeName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(BookId);
            writer.Write(MaxNumPages);
            PageData.Write(writer);
            writer.Write(Inscription);
            writer.Write(ScribeId);
            writer.Write(ScribeName);
        }

    }

}
