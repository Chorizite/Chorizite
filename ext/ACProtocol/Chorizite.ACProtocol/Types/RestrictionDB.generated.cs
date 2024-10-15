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
using Chorizite.ACProtocol.Extensions;
namespace Chorizite.ACProtocol.Types {
    /// <summary>
    /// The RestrictionDB contains the access control list for a dwelling object.
    /// </summary>
    public class RestrictionDB : IACDataType {
        /// <summary>
        /// If high word is not 0, this value indicates the version of the message.
        /// </summary>
        public uint Version;

        /// <summary>
        /// 0 = private dwelling, 1 = open to public
        /// </summary>
        public uint Flags;

        /// <summary>
        /// allegiance monarch (if allegiance access granted)
        /// </summary>
        public uint MonarchId;

        /// <summary>
        /// Set of permissions on a per user basis. Key is the character id, value is 0 = dwelling access only, 1 = storage access also
        /// </summary>
        public Dictionary<uint, uint> Permissions = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Version = reader.ReadUInt32();
            Flags = reader.ReadUInt32();
            MonarchId = reader.ReadUInt32();
            Permissions = reader.ReadPHashTable<uint, uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Version);
            writer.Write(Flags);
            writer.Write(MonarchId);
            writer.WritePHashTable(Permissions);
        }

    }

}
