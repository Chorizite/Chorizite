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
    /// Data for an individual page
    /// </summary>
    public class PageData : IACDataType {
        public uint AuthorId;

        public string AuthorName;

        public string AuthorAccount;

        /// <summary>
        /// if HIWORD is not 0xFFFF, this is textIncluded. For our purpose this should always be 0xFFFF0002
        /// </summary>
        public uint Version;

        public bool TextIncluded;

        public bool IgnoreAuthor;

        public string PageText;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            AuthorId = reader.ReadUInt32();
            AuthorName = reader.ReadString16L();
            AuthorAccount = reader.ReadString16L();
            Version = reader.ReadUInt32();
            TextIncluded = reader.ReadBool();
            IgnoreAuthor = reader.ReadBool();
            if (TextIncluded) {
                PageText = reader.ReadString16L();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(AuthorId);
            writer.Write(AuthorName);
            writer.Write(AuthorAccount);
            writer.Write(Version);
            writer.Write(TextIncluded);
            writer.Write(IgnoreAuthor);
            if (TextIncluded) {
                writer.Write(PageText);
            }
        }

    }

}
