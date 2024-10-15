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
    /// Set of information related to owning a housing
    /// </summary>
    public class HouseData : IACDataType {
        /// <summary>
        /// when the house was purchased (Unix timestamp)
        /// </summary>
        public uint BuyTime;

        /// <summary>
        /// when the current maintenance period began (Unix timestamp)
        /// </summary>
        public uint RentTime;

        /// <summary>
        /// the type of house (1=cottage, 2=villa, 3=mansion, 4=apartment)
        /// </summary>
        public HouseType Type;

        /// <summary>
        /// indicates maintenance is free this period, I assume admin controlled
        /// </summary>
        public bool MaintenanceFree;

        public List<HousePayment> Buy = new();

        public List<HousePayment> Rent = new();

        /// <summary>
        /// house position
        /// </summary>
        public Position Position;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            BuyTime = reader.ReadUInt32();
            RentTime = reader.ReadUInt32();
            Type = (HouseType)reader.ReadUInt32();
            MaintenanceFree = reader.ReadBool();
            Buy = reader.ReadPackableList<HousePayment>();
            Rent = reader.ReadPackableList<HousePayment>();
            Position = new Position();
            Position.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(BuyTime);
            writer.Write(RentTime);
            writer.Write((uint)Type);
            writer.Write(MaintenanceFree);
            writer.WritePackableList(Buy);
            writer.WritePackableList(Rent);
            Position.Write(writer);
        }

    }

}
