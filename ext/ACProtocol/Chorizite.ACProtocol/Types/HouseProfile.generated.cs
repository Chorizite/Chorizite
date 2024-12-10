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
    /// Set of information related to purchasing a housing
    /// </summary>
    public class HouseProfile : IACDataType {
        /// <summary>
        /// the number associated with this dwelling
        /// </summary>
        public uint DwellingId;

        /// <summary>
        /// the object Id of the the current owner
        /// </summary>
        public uint OwnerId;

        public HouseBitfield Flags;

        /// <summary>
        /// the level requirement to purchase this dwelling (-1 if no requirement)
        /// </summary>
        public int MinLevel;

        public int MaxLevel;

        /// <summary>
        /// the rank requirement to purchase this dwelling (-1 if no requirement)
        /// </summary>
        public int MinAllegRank;

        public int MaxAllegRank;

        public bool MaintenanceFree;

        /// <summary>
        /// the type of dwelling (1=cottage, 2=villa, 3=mansion, 4=apartment)
        /// </summary>
        public HouseType Type;

        /// <summary>
        /// the name of the current owner
        /// </summary>
        public string OwnerName;

        public List<HousePayment> Buy = new();

        public List<HousePayment> Rent = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            DwellingId = reader.ReadUInt32();
            OwnerId = reader.ReadUInt32();
            Flags = (HouseBitfield)reader.ReadUInt32();
            MinLevel = reader.ReadInt32();
            MaxLevel = reader.ReadInt32();
            MinAllegRank = reader.ReadInt32();
            MaxAllegRank = reader.ReadInt32();
            MaintenanceFree = reader.ReadBool();
            Type = (HouseType)reader.ReadUInt32();
            OwnerName = reader.ReadString16L();
            Buy = reader.ReadPackableList<HousePayment>();
            Rent = reader.ReadPackableList<HousePayment>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(DwellingId);
            writer.Write(OwnerId);
            writer.Write((uint)Flags);
            writer.Write(MinLevel);
            writer.Write(MaxLevel);
            writer.Write(MinAllegRank);
            writer.Write(MaxAllegRank);
            writer.Write(MaintenanceFree);
            writer.Write((uint)Type);
            writer.Write(OwnerName);
            writer.WritePackableList(Buy);
            writer.WritePackableList(Rent);
        }

    }

}
