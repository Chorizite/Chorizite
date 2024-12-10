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
    /// Allegience hierarchy information
    /// </summary>
    public class AllegianceHierarchy : IACDataType {
        /// <summary>
        /// Number of character allegiance records.
        /// </summary>
        public ushort RecordCount;

        /// <summary>
        /// Defines which properties are available. 0x0B seems to be the latest version which includes all properties.
        /// </summary>
        public ushort OldVersion;

        /// <summary>
        /// Taking a guess on these values.  Guessing they may only be valid on Monarchs.
        /// </summary>
        public Dictionary<uint, AllegianceOfficerLevel> Officers = new();

        /// <summary>
        /// Believe these may pass in the current officer title list.  Guessing they may only be valid on Monarchs.
        /// </summary>
        public List<string> OfficerTitles = new();

        /// <summary>
        /// May only be valid for Monarchs/Speakers?
        /// </summary>
        public uint MonarchBroadcastTime;

        /// <summary>
        /// May only be valid for Monarchs/Speakers?
        /// </summary>
        public uint MonarchBroadcastsToday;

        /// <summary>
        /// May only be valid for Monarchs/Speakers?
        /// </summary>
        public uint SpokesBroadcastTime;

        /// <summary>
        /// May only be valid for Monarchs/Speakers?
        /// </summary>
        public uint SpokesBroadcastsToday;

        /// <summary>
        /// Text for current motd. May only be valid for Monarchs/Speakers?
        /// </summary>
        public string Motd;

        /// <summary>
        /// Who set the current motd. May only be valid for Monarchs/Speakers?
        /// </summary>
        public string MotdSetBy;

        /// <summary>
        /// allegiance chat channel number
        /// </summary>
        public uint ChatRoomId;

        /// <summary>
        /// Location of monarchy bindpoint
        /// </summary>
        public Position Bindpoint;

        /// <summary>
        /// The name of the allegiance.
        /// </summary>
        public string AllegianceName;

        /// <summary>
        /// Time name was last set.  Seems to count upward for some reason.
        /// </summary>
        public uint NameLastSetTime;

        /// <summary>
        /// Whether allegiance is locked.
        /// </summary>
        public bool IsLocked;

        public int ApprovedVassal;

        /// <summary>
        /// Monarch&#39;s data
        /// </summary>
        public AllegianceData MonarchData;

        /// <summary>
        /// Data for remaining people, which I believe should be your vassels.
        /// </summary>
        public List<AllegianceRecord> Records = new List<AllegianceRecord>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            RecordCount = reader.ReadUInt16();
            OldVersion = reader.ReadUInt16();
            Officers = reader.ReadPHashTable<uint, AllegianceOfficerLevel>();
            OfficerTitles = reader.ReadPackableList<string>();
            MonarchBroadcastTime = reader.ReadUInt32();
            MonarchBroadcastsToday = reader.ReadUInt32();
            SpokesBroadcastTime = reader.ReadUInt32();
            SpokesBroadcastsToday = reader.ReadUInt32();
            Motd = reader.ReadString16L();
            MotdSetBy = reader.ReadString16L();
            ChatRoomId = reader.ReadUInt32();
            Bindpoint = new Position();
            Bindpoint.Read(reader);
            AllegianceName = reader.ReadString16L();
            NameLastSetTime = reader.ReadUInt32();
            IsLocked = reader.ReadBool();
            ApprovedVassal = reader.ReadInt32();
            if (RecordCount > 0) {
                MonarchData = new AllegianceData();
                MonarchData.Read(reader);
            }
            for (var i=0; i < RecordCount - 1; i++) {
                Records.Add(reader.ReadItem<AllegianceRecord>());
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(RecordCount);
            writer.Write(OldVersion);
            writer.WritePHashTable(Officers);
            writer.WritePackableList(OfficerTitles);
            writer.Write(MonarchBroadcastTime);
            writer.Write(MonarchBroadcastsToday);
            writer.Write(SpokesBroadcastTime);
            writer.Write(SpokesBroadcastsToday);
            writer.Write(Motd);
            writer.Write(MotdSetBy);
            writer.Write(ChatRoomId);
            Bindpoint.Write(writer);
            writer.Write(AllegianceName);
            writer.Write(NameLastSetTime);
            writer.Write(IsLocked);
            writer.Write(ApprovedVassal);
            if (RecordCount > 0) {
                MonarchData.Write(writer);
            }
            for (var i=0; i < RecordCount - 1; i++) {
            }
        }

    }

}
