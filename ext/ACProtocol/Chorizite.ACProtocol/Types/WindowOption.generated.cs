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
    public class WindowOption : IACDataType {
        public uint Type_a;

        public byte Unknown_b;

        public byte PropertyCount;

        public List<WindowProperty> Properties = new List<WindowProperty>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Type_a = reader.ReadUInt32();
            switch((int)Type_a) {
                case 0x1000008b:
                    Unknown_b = reader.ReadByte();
                    PropertyCount = reader.ReadByte();
                    for (var i=0; i < PropertyCount; i++) {
                        Properties.Add(reader.ReadItem<WindowProperty>());
                    }
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Type_a);
            switch((int)Type_a) {
                case 0x1000008b:
                    writer.Write(Unknown_b);
                    writer.Write(PropertyCount);
                    for (var i=0; i < PropertyCount; i++) {
                    }
                    break;
            }
        }

    }

}
