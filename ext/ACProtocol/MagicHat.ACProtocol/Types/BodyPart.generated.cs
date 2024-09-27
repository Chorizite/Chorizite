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
    /// Information on individual body parts. (Needs to be confirmed if this was used in prod)
    /// </summary>
    public class BodyPart : IACDataType {
        public int HasBPSD;

        public DamageType DamageType;

        public int DamageVal;

        public int DamageVar;

        /// <summary>
        /// Armor info
        /// </summary>
        public ArmorCache ArmorCache;

        public int BH;

        public BodyPartSelectionData BPSD;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            HasBPSD = reader.ReadInt32();
            DamageType = (DamageType)reader.ReadUInt32();
            DamageVal = reader.ReadInt32();
            DamageVar = reader.ReadInt32();
            ArmorCache = new ArmorCache();
            ArmorCache.Read(reader);
            BH = reader.ReadInt32();
            if (((uint)HasBPSD & (uint)0x00000001) != 0) {
                BPSD = new BodyPartSelectionData();
                BPSD.Read(reader);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(HasBPSD);
            writer.Write((uint)DamageType);
            writer.Write(DamageVal);
            writer.Write(DamageVar);
            ArmorCache.Write(writer);
            writer.Write(BH);
            if (((uint)HasBPSD & (uint)0x00000001) != 0) {
                BPSD.Write(writer);
            }
        }

    }

}
