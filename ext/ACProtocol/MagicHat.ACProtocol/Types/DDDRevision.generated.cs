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
    public class DDDRevision : IACDataType {
        /// <summary>
        /// Dat File header offset 0x0150, Dat File header offset 0x014C
        /// </summary>
        public ulong IdDatFile;

        /// <summary>
        /// Derived from IdDatFile. Type of DAT file being revised
        /// </summary>
        public uint DatFileType { get => (uint)(IdDatFile >> 32); }

        /// <summary>
        /// The corresponding Dat file revision for this patch set
        /// </summary>
        public uint Iteration;

        public List<uint> IdsToDownload = new();

        public List<uint> IdsToPurge = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            IdDatFile = reader.ReadUInt64();
            Iteration = reader.ReadUInt32();
            IdsToDownload = reader.ReadPackableList<uint>();
            IdsToPurge = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(IdDatFile);
            writer.Write(Iteration);
            writer.WritePackableList(IdsToDownload);
            writer.WritePackableList(IdsToPurge);
        }

    }

}
