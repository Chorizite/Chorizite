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
    public class BodyPartSelectionData : IACDataType {
        public int HLF;

        public int MLF;

        public int LLF;

        public int HRF;

        public int MRF;

        public int LRF;

        public int HLB;

        public int MLB;

        public int LLB;

        public int HRB;

        public int MRB;

        public int LRB;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            HLF = reader.ReadInt32();
            MLF = reader.ReadInt32();
            LLF = reader.ReadInt32();
            HRF = reader.ReadInt32();
            MRF = reader.ReadInt32();
            LRF = reader.ReadInt32();
            HLB = reader.ReadInt32();
            MLB = reader.ReadInt32();
            LLB = reader.ReadInt32();
            HRB = reader.ReadInt32();
            MRB = reader.ReadInt32();
            LRB = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(HLF);
            writer.Write(MLF);
            writer.Write(LLF);
            writer.Write(HRF);
            writer.Write(MRF);
            writer.Write(LRF);
            writer.Write(HLB);
            writer.Write(MLB);
            writer.Write(LLB);
            writer.Write(HRB);
            writer.Write(MRB);
            writer.Write(LRB);
        }

    }

}
