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
    public class SquelchDB : IACDataType {
        /// <summary>
        /// Account name and 
        /// </summary>
        public Dictionary<string, uint> AccountHash = new();

        public Dictionary<uint, SquelchInfo> CharacterHash = new();

        /// <summary>
        /// Global squelch information
        /// </summary>
        public SquelchInfo GlobalInfo;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            AccountHash = reader.ReadPackableHashTable<string, uint>();
            CharacterHash = reader.ReadPackableHashTable<uint, SquelchInfo>();
            GlobalInfo = new SquelchInfo();
            GlobalInfo.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.WritePackableHashTable(AccountHash);
            writer.WritePackableHashTable(CharacterHash);
            GlobalInfo.Write(writer);
        }

    }

}
