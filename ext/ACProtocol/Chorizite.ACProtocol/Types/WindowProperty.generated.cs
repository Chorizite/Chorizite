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
    public class WindowProperty : IACDataType {
        public uint Key_a;

        public uint Unknown_c;

        public byte TitleSource;

        public uint StringId;

        public uint FileId;

        public string Value_a;

        public uint Unknown_1b;

        public ushort Unknown_1c;

        public uint Unknown_d;

        public byte Value_d;

        public uint Unknown_e;

        public uint Value_e;

        public uint Unknown_f;

        public uint Value_f;

        public uint Unknown_h;

        public uint Value_h;

        public uint Unknown_i;

        public uint Value_i;

        public uint Unknown_j;

        public ulong Value_j;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Key_a = reader.ReadUInt32();
            switch((int)Key_a) {
                case 0x1000008d:
                    Unknown_c = reader.ReadUInt32();
                    TitleSource = reader.ReadByte();
                    switch((int)TitleSource) {
                        case 0x00:
                            StringId = reader.ReadUInt32();
                            FileId = reader.ReadUInt32();
                            break;
                        case 0x01:
                            Value_a = reader.ReadString32L();
                            break;
                    }
                    Unknown_1b = reader.ReadUInt32();
                    Unknown_1c = reader.ReadUInt16();
                    break;
                case 0x1000008a:
                    Unknown_d = reader.ReadUInt32();
                    Value_d = reader.ReadByte();
                    break;
                case 0x10000089:
                    Unknown_e = reader.ReadUInt32();
                    Value_e = reader.ReadUInt32();
                    break;
                case 0x10000088:
                    Unknown_f = reader.ReadUInt32();
                    Value_f = reader.ReadUInt32();
                    break;
                case 0x10000087:
                    Unknown_h = reader.ReadUInt32();
                    Value_h = reader.ReadUInt32();
                    break;
                case 0x10000086:
                    Unknown_i = reader.ReadUInt32();
                    Value_i = reader.ReadUInt32();
                    break;
                case 0x1000007F:
                    Unknown_j = reader.ReadUInt32();
                    Value_j = reader.ReadUInt64();
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Key_a);
            switch((int)Key_a) {
                case 0x1000008d:
                    writer.Write(Unknown_c);
                    writer.Write(TitleSource);
                    switch((int)TitleSource) {
                        case 0x00:
                            writer.Write(StringId);
                            writer.Write(FileId);
                            break;
                        case 0x01:
                            writer.Write(Value_a);
                            break;
                    }
                    writer.Write(Unknown_1b);
                    writer.Write(Unknown_1c);
                    break;
                case 0x1000008a:
                    writer.Write(Unknown_d);
                    writer.Write(Value_d);
                    break;
                case 0x10000089:
                    writer.Write(Unknown_e);
                    writer.Write(Value_e);
                    break;
                case 0x10000088:
                    writer.Write(Unknown_f);
                    writer.Write(Value_f);
                    break;
                case 0x10000087:
                    writer.Write(Unknown_h);
                    writer.Write(Value_h);
                    break;
                case 0x10000086:
                    writer.Write(Unknown_i);
                    writer.Write(Value_i);
                    break;
                case 0x1000007F:
                    writer.Write(Unknown_j);
                    writer.Write(Value_j);
                    break;
            }
        }

    }

}
