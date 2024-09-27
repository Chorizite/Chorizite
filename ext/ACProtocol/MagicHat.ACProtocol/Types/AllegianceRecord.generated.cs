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
    /// Allegience record
    /// </summary>
    public class AllegianceRecord : IACDataType {
        /// <summary>
        /// The Object Id for the parent character to this character.  Used by the client to decide how to build the display in the Allegiance tab. 1 is the monarch.
        /// </summary>
        public uint TreeParent;

        public AllegianceData AllegianceData;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            TreeParent = reader.ReadUInt32();
            AllegianceData = new AllegianceData();
            AllegianceData.Read(reader);
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(TreeParent);
            AllegianceData.Write(writer);
        }

    }

}
