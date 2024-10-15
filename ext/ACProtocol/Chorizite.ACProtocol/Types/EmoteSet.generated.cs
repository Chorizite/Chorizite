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
    public class EmoteSet : IACDataType {
        public EmoteCategory Category;

        public float Probability;

        public uint ClassId;

        public uint Style;

        public uint Substyle;

        public string Quest;

        public uint VendorType;

        public float MinHealth;

        public float MaxHealth;

        /// <summary>
        /// List of emotes
        /// </summary>
        public List<Emote> Emotes = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Category = (EmoteCategory)reader.ReadUInt32();
            Probability = reader.ReadSingle();
            switch((int)Category) {
                case 0x01:
                case 0x06:
                    ClassId = reader.ReadUInt32();
                    break;
                case 0x05:
                    Style = reader.ReadUInt32();
                    Substyle = reader.ReadUInt32();
                    break;
                case 0x0C:
                case 0x0D:
                case 0x16:
                case 0x17:
                case 0x1B:
                case 0x1C:
                case 0x1D:
                case 0x1E:
                case 0x1F:
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x24:
                case 0x25:
                case 0x26:
                    Quest = reader.ReadString16L();
                    break;
                case 0x02:
                    VendorType = reader.ReadUInt32();
                    break;
                case 0x0F:
                    MinHealth = reader.ReadSingle();
                    MaxHealth = reader.ReadSingle();
                    break;
            }
            Emotes = reader.ReadPackableList<Emote>();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Category);
            writer.Write(Probability);
            switch((int)Category) {
                case 0x01:
                case 0x06:
                    writer.Write(ClassId);
                    break;
                case 0x05:
                    writer.Write(Style);
                    writer.Write(Substyle);
                    break;
                case 0x0C:
                case 0x0D:
                case 0x16:
                case 0x17:
                case 0x1B:
                case 0x1C:
                case 0x1D:
                case 0x1E:
                case 0x1F:
                case 0x20:
                case 0x21:
                case 0x22:
                case 0x23:
                case 0x24:
                case 0x25:
                case 0x26:
                    writer.Write(Quest);
                    break;
                case 0x02:
                    writer.Write(VendorType);
                    break;
                case 0x0F:
                    writer.Write(MinHealth);
                    writer.Write(MaxHealth);
                    break;
            }
            writer.WritePackableList(Emotes);
        }

    }

}
