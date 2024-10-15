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
    /// Data related to an item, namely the amount and description
    /// </summary>
    public class ItemProfile : IACDataType {
        public uint PackedAmount;

        /// <summary>
        /// Derived from PackedAmount. the number of items for sale (-1 for an unlimited supply)
        /// </summary>
        public int Amount { get => (int)(PackedAmount & 0xFFFFFF); }

        /// <summary>
        /// Derived from PackedAmount. flag indicating whether the new or old PublicWeenieDesc is used
        /// </summary>
        public int PwdType { get => (int)(PackedAmount >> 24); }

        /// <summary>
        /// the object Id of the item
        /// </summary>
        public uint ObjectId;

        /// <summary>
        /// details about the item
        /// </summary>
        public PublicWeenieDesc WeenieDescription;

        /// <summary>
        /// details about the item
        /// </summary>
        public OldPublicWeenieDesc OldWeenieDescription;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            PackedAmount = reader.ReadUInt32();
            ObjectId = reader.ReadUInt32();
            switch((int)PwdType) {
                case -1:
                    WeenieDescription = new PublicWeenieDesc();
                    WeenieDescription.Read(reader);
                    break;
                case 1:
                    OldWeenieDescription = new OldPublicWeenieDesc();
                    OldWeenieDescription.Read(reader);
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(PackedAmount);
            writer.Write(ObjectId);
            switch((int)PwdType) {
                case -1:
                    WeenieDescription.Write(writer);
                    break;
                case 1:
                    OldWeenieDescription.Write(writer);
                    break;
            }
        }

    }

}
