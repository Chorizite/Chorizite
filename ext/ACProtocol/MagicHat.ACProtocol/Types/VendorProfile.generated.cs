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
    public class VendorProfile : IACDataType {
        /// <summary>
        /// the categories of items the merchant will buy
        /// </summary>
        public ItemType Categories;

        /// <summary>
        /// the lowest value of an item the merchant will buy
        /// </summary>
        public uint MinValue;

        /// <summary>
        /// the highest value of an item the merchant will buy
        /// </summary>
        public uint MaxValue;

        public bool DealsMagic;

        /// <summary>
        /// the merchant&#39;s buy rate
        /// </summary>
        public float BuyPrice;

        /// <summary>
        /// the merchant&#39;s sell rate
        /// </summary>
        public float SellPrice;

        /// <summary>
        /// wcid of currency
        /// </summary>
        public uint CurrencyId;

        /// <summary>
        /// amount of currency player has
        /// </summary>
        public uint CurrencyAmount;

        /// <summary>
        /// name of currency
        /// </summary>
        public string CurrencyName;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Categories = (ItemType)reader.ReadUInt32();
            MinValue = reader.ReadUInt32();
            MaxValue = reader.ReadUInt32();
            DealsMagic = reader.ReadBool();
            BuyPrice = reader.ReadSingle();
            SellPrice = reader.ReadSingle();
            CurrencyId = reader.ReadUInt32();
            CurrencyAmount = reader.ReadUInt32();
            CurrencyName = reader.ReadString16L();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Categories);
            writer.Write(MinValue);
            writer.Write(MaxValue);
            writer.Write(DealsMagic);
            writer.Write(BuyPrice);
            writer.Write(SellPrice);
            writer.Write(CurrencyId);
            writer.Write(CurrencyAmount);
            writer.Write(CurrencyName);
        }

    }

}
