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
    /// Set information about an item for creation
    /// </summary>
    public class CreationProfile : IACDataType {
        public uint WeenieClassId;

        public uint Palette;

        public float Shade;

        public uint Destination;

        public int StackSize;

        public bool TryToBond;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            WeenieClassId = reader.ReadUInt32();
            Palette = reader.ReadUInt32();
            Shade = reader.ReadSingle();
            Destination = reader.ReadUInt32();
            StackSize = reader.ReadInt32();
            TryToBond = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(WeenieClassId);
            writer.Write(Palette);
            writer.Write(Shade);
            writer.Write(Destination);
            writer.Write(StackSize);
            writer.Write(TryToBond);
        }

    }

}
