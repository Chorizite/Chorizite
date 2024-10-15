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
    public class GameplayOptions : IACDataType {
        /// <summary>
        /// The size in bytes of the GameplayOptions payload that follows
        /// </summary>
        public uint Size;

        public byte Unknown200_2;

        public byte OptionPropertyCount;

        public List<OptionProperty> OptionProperties = new List<OptionProperty>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Size = reader.ReadUInt32();
            Unknown200_2 = reader.ReadByte();
            OptionPropertyCount = reader.ReadByte();
            for (var i=0; i < OptionPropertyCount; i++) {
                OptionProperties.Add(reader.ReadItem<OptionProperty>());
            }
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Size);
            writer.Write(Unknown200_2);
            writer.Write(OptionPropertyCount);
            for (var i=0; i < OptionPropertyCount; i++) {
            }
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
