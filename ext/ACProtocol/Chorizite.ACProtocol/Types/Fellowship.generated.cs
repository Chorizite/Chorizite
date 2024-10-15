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
    /// Set of information for a fellowship
    /// </summary>
    public class Fellowship : IACDataType {
        /// <summary>
        /// Set of fellowship members with their Id as the key and some additional info for them
        /// </summary>
        public Dictionary<uint, Fellow> Members = new();

        /// <summary>
        /// the fellowship name
        /// </summary>
        public string Name;

        /// <summary>
        /// the object Id of the fellowship leader
        /// </summary>
        public uint LeaderId;

        /// <summary>
        /// XP sharing: 0=no, 1=yes
        /// </summary>
        public bool ShareXP;

        /// <summary>
        /// Even XP sharing: 0=no, 1=yes
        /// </summary>
        public bool EvenXPSplit;

        /// <summary>
        /// Open fellowship: 0=no, 1=yes
        /// </summary>
        public bool Open;

        /// <summary>
        /// Locked fellowship: 0=no, 1=yes
        /// </summary>
        public bool Locked;

        /// <summary>
        /// I suspect this is a list of recently disconnected fellows which can be reinvited, even in locked fellowship
        /// </summary>
        public Dictionary<uint, int> RecentlyDeparted = new();

        public Dictionary<String, FellowshipLockData> Locks = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Members = reader.ReadPackableHashTable<uint, Fellow>();
            Name = reader.ReadString16L();
            LeaderId = reader.ReadUInt32();
            ShareXP = reader.ReadBool();
            EvenXPSplit = reader.ReadBool();
            Open = reader.ReadBool();
            Locked = reader.ReadBool();
            RecentlyDeparted = reader.ReadPackableHashTable<uint, int>();
            Locks = reader.ReadPackableHashTable<String, FellowshipLockData>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.WritePackableHashTable(Members);
            writer.Write(Name);
            writer.Write(LeaderId);
            writer.Write(ShareXP);
            writer.Write(EvenXPSplit);
            writer.Write(Open);
            writer.Write(Locked);
            writer.WritePackableHashTable(RecentlyDeparted);
            writer.WritePackableHashTable(Locks);
        }

    }

}
