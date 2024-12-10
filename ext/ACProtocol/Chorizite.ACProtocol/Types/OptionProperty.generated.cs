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
    public class OptionProperty : IACDataType {
        public uint Type;

        public uint Unknown_a;

        public List<WindowOption> WindowOptions = new();

        public uint Unknown_k;

        public float ActiveOpacity;

        public uint Unknown_l;

        public float InactiveOpacity;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Type = reader.ReadUInt32();
            switch((int)Type) {
                case 0x1000008c:
                    Unknown_a = reader.ReadUInt32();
                    WindowOptions = reader.ReadPackableList<WindowOption>();
                    break;
                case 0x10000081:
                    Unknown_k = reader.ReadUInt32();
                    ActiveOpacity = reader.ReadSingle();
                    break;
                case 0x10000080:
                    Unknown_l = reader.ReadUInt32();
                    InactiveOpacity = reader.ReadSingle();
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Type);
            switch((int)Type) {
                case 0x1000008c:
                    writer.Write(Unknown_a);
                    writer.WritePackableList(WindowOptions);
                    break;
                case 0x10000081:
                    writer.Write(Unknown_k);
                    writer.Write(ActiveOpacity);
                    break;
                case 0x10000080:
                    writer.Write(Unknown_l);
                    writer.Write(InactiveOpacity);
                    break;
            }
        }

    }

}
