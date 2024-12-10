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
using Chorizite.ACProtocol.Enums;
using Chorizite.Common.Enums;
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// Blob fragment data used to contruct message data. These can be spread across multiple packets
    /// </summary>
    public class BlobFragments : IACDataType {
        /// <summary>
        /// Fragment Sequence / Order
        /// </summary>
        public uint Sequence;

        /// <summary>
        /// The id of this fragment
        /// </summary>
        public uint Id;

        /// <summary>
        /// The total number of blob fragments used to make up the message data
        /// </summary>
        public ushort Count;

        /// <summary>
        /// The total size of data in this message, including this header data
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Derived from Size. The size of just the body following this header data
        /// </summary>
        public ushort BodySize { get => (ushort)(Size - 16); }

        /// <summary>
        /// The zero-based index of Count total fragment bodies that will be used to contruct the message data
        /// </summary>
        public ushort Index;

        public FragmentGroup Group;

        /// <summary>
        /// The fragment body data
        /// </summary>
        public List<byte> Data = new List<byte>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Sequence = reader.ReadUInt32();
            Id = reader.ReadUInt32();
            Count = reader.ReadUInt16();
            Size = reader.ReadUInt16();
            Index = reader.ReadUInt16();
            Group = (FragmentGroup)reader.ReadUInt16();
            for (var i=0; i < BodySize; i++) {
                Data.Add(reader.ReadItem<byte>());
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Sequence);
            writer.Write(Id);
            writer.Write(Count);
            writer.Write(Size);
            writer.Write(Index);
            writer.Write((ushort)Group);
            for (var i=0; i < BodySize; i++) {
            }
        }

    }

}
