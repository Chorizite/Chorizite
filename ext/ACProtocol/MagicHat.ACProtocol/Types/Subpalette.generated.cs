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
    /// Contains data for a subpalette
    /// </summary>
    public class Subpalette : IACDataType {
        /// <summary>
        /// palette DataId (minus 0x04000000)
        /// </summary>
        public uint Palette;

        /// <summary>
        /// The number of palette entries to skip
        /// </summary>
        public byte Offset;

        /// <summary>
        /// The number of palette entries to copy. This is multiplied by 8.  If it is 0, it defaults to 256*8.
        /// </summary>
        public byte NumColors;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Palette = reader.ReadPackedDWORD();
            Offset = reader.ReadByte();
            NumColors = reader.ReadByte();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Palette);
            writer.Write(Offset);
            writer.Write(NumColors);
        }

    }

}
