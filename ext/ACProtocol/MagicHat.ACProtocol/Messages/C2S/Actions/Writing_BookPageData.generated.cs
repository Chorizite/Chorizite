using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;
using MagicHat.ACProtocol.Extensions;
using System.Numerics;

namespace MagicHat.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Requests data for a page in a book
    /// </summary>
    public class Writing_BookPageData : ACGameAction {
        /// <summary>
        /// Id of book
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// Number of page to get data for
        /// </summary>
        public int PageNum;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            PageNum = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(PageNum);
        }

    }

}
