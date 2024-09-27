//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//                                                            //
//                          WARNING                           //
//                                                            //
//           DO NOT MAKE LOCAL CHANGES TO THIS FILE           //
//               EDIT THE .tt TEMPLATE INSTEAD                //
//                                                            //
//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//


using System;
using System.Numerics;
using System.IO;
using System.Collections.Generic;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Extensions;
namespace MagicHat.ACProtocol.Types {
    /// <summary>
    /// List of pages in a book
    /// </summary>
    public class PageDataList : IACDataType {
        public uint MaxNumPages;

        public uint MaxNumCharsPerPage;

        /// <summary>
        /// List of pages
        /// </summary>
        public List<PageData> Pages = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            MaxNumPages = reader.ReadUInt32();
            MaxNumCharsPerPage = reader.ReadUInt32();
            Pages = reader.ReadPackableList<PageData>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(MaxNumPages);
            writer.Write(MaxNumCharsPerPage);
            writer.WritePackableList(Pages);
        }

    }

}
