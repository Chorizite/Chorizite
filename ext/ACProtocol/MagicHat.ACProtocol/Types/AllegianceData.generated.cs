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
    /// Set of allegiance data for a specific player
    /// </summary>
    public class AllegianceData : IACDataType {
        /// <summary>
        /// Character Id
        /// </summary>
        public uint CharacterId;

        /// <summary>
        /// XP gained while logged off
        /// </summary>
        public uint XPCached;

        /// <summary>
        /// Total allegiance XP contribution.
        /// </summary>
        public uint XPTithed;

        public uint Flags;

        /// <summary>
        /// The gender of the character (for determining title).
        /// </summary>
        public Gender Gender;

        /// <summary>
        /// The heritage of the character (for determining title).
        /// </summary>
        public HeritageGroup Heritage;

        /// <summary>
        /// The numerical rank (1 is lowest).
        /// </summary>
        public ushort Rank;

        public uint Level;

        /// <summary>
        /// Character loyalty.
        /// </summary>
        public ushort Loyalty;

        /// <summary>
        /// Character leadership.
        /// </summary>
        public ushort Leadership;

        public ulong TimeOnline;

        public uint AllegianceAge;

        public string Name;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            CharacterId = reader.ReadUInt32();
            XPCached = reader.ReadUInt32();
            XPTithed = reader.ReadUInt32();
            Flags = reader.ReadUInt32();
            Gender = (Gender)reader.ReadByte();
            Heritage = (HeritageGroup)reader.ReadByte();
            Rank = reader.ReadUInt16();
            if (((uint)Flags & (uint)0x8) != 0) {
                Level = reader.ReadUInt32();
            }
            Loyalty = reader.ReadUInt16();
            Leadership = reader.ReadUInt16();
            if (Flags == 0x4) {
                TimeOnline = reader.ReadUInt64();
            }
            else {
                TimeOnline = reader.ReadUInt32();
                AllegianceAge = reader.ReadUInt32();
            }
            Name = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(CharacterId);
            writer.Write(XPCached);
            writer.Write(XPTithed);
            writer.Write(Flags);
            writer.Write((byte)Gender);
            writer.Write((byte)Heritage);
            writer.Write(Rank);
            if (((uint)Flags & (uint)0x8) != 0) {
                writer.Write(Level);
            }
            writer.Write(Loyalty);
            writer.Write(Leadership);
            if (Flags == 0x4) {
                writer.Write(TimeOnline);
            }
            else {
                writer.Write(TimeOnline);
                writer.Write(AllegianceAge);
            }
            writer.Write(Name);
        }

    }

}
