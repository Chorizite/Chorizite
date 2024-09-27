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
    /// Information on armor levels
    /// </summary>
    public class ArmorCache : IACDataType {
        public int BaseArmor;

        public int ArmorVsSlash;

        public int ArmorVsPierce;

        public int ArmorVsBludgeon;

        public int ArmorVsCold;

        public int ArmorVsFire;

        public int ArmorVsAcid;

        public int ArmorVsElectric;

        public int ArmorVsNether;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            BaseArmor = reader.ReadInt32();
            ArmorVsSlash = reader.ReadInt32();
            ArmorVsPierce = reader.ReadInt32();
            ArmorVsBludgeon = reader.ReadInt32();
            ArmorVsCold = reader.ReadInt32();
            ArmorVsFire = reader.ReadInt32();
            ArmorVsAcid = reader.ReadInt32();
            ArmorVsElectric = reader.ReadInt32();
            ArmorVsNether = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(BaseArmor);
            writer.Write(ArmorVsSlash);
            writer.Write(ArmorVsPierce);
            writer.Write(ArmorVsBludgeon);
            writer.Write(ArmorVsCold);
            writer.Write(ArmorVsFire);
            writer.Write(ArmorVsAcid);
            writer.Write(ArmorVsElectric);
            writer.Write(ArmorVsNether);
        }

    }

}
