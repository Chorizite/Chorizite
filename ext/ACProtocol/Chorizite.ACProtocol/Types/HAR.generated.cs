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
    /// Set of information related to house access
    /// </summary>
    public class HAR : IACDataType {
        /// <summary>
        /// 0x10000002, seems to be some kind of version. Older version started with bitmask, so starting with 0x10000000 allows them to determine if this is V1 or V2.  The latter half appears to indicate wheither there is a roommate list or not.
        /// </summary>
        public uint Version;

        /// <summary>
        /// 0 is private house, 1 = open to public
        /// </summary>
        public uint Bitmask;

        /// <summary>
        /// populated when any allegiance access is specified
        /// </summary>
        public uint MonarchId;

        /// <summary>
        /// Set of guests with their Id as the key and some additional info for them
        /// </summary>
        public Dictionary<uint, GuestInfo> GuestList = new();

        /// <summary>
        /// List that has the Id&#39;s of your roommates
        /// </summary>
        public List<uint> RoommateList = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Version = reader.ReadUInt32();
            Bitmask = reader.ReadUInt32();
            MonarchId = reader.ReadUInt32();
            GuestList = reader.ReadPackableHashTable<uint, GuestInfo>();
            RoommateList = reader.ReadPackableList<uint>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Version);
            writer.Write(Bitmask);
            writer.Write(MonarchId);
            writer.WritePackableHashTable(GuestList);
            writer.WritePackableList(RoommateList);
        }

    }

}
