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
    public class Emote : IACDataType {
        public EmoteType Type;

        public float Delay;

        public float Extent;

        public string Message;

        public uint Amount;

        public uint Stat;

        public double Percent;

        public uint Min;

        public uint Max;

        public ulong Amount64;

        public ulong HeroXP64;

        public uint SpellId;

        public CreationProfile CProfile;

        public string Msg;

        /// <summary>
        /// Over 8 is invalid
        /// </summary>
        public int WealthRating;

        public int TreasureClass;

        /// <summary>
        /// Valid values are 0 to 3 
        /// </summary>
        public int TreasureType;

        public uint Motion;

        public Frame Frame;

        public uint PhysicsScript;

        public uint Sound;

        public string TestString;

        public ulong Min64;

        public ulong Max64;

        public double FMin;

        public double FMax;

        public bool Display;

        public Position Position;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Type = (EmoteType)reader.ReadUInt32();
            Delay = reader.ReadSingle();
            Extent = reader.ReadSingle();
            switch((int)Type) {
                case 0x01:
                case 0x08:
                case 0x0A:
                case 0x0D:
                case 0x10:
                case 0x11:
                case 0x12:
                case 0x14:
                case 0x15:
                case 0x16:
                case 0x17:
                case 0x18:
                case 0x19:
                case 0x1A:
                case 0x1F:
                case 0x33:
                case 0x3A:
                case 0x3C:
                case 0x3D:
                case 0x40:
                case 0x41:
                case 0x43:
                case 0x44:
                case 0x4F:
                case 0x50:
                case 0x51:
                case 0x53:
                case 0x58:
                case 0x79:
                    Message = reader.ReadString16L();
                    break;
                case 0x20:
                case 0x21:
                case 0x46:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x59:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x69:
                case 0x6A:
                case 0x6B:
                case 0x6C:
                case 0x6D:
                    Message = reader.ReadString16L();
                    Amount = reader.ReadUInt32();
                    break;
                case 0x35:
                case 0x36:
                case 0x37:
                case 0x45:
                    Stat = reader.ReadUInt32();
                    Amount = reader.ReadUInt32();
                    break;
                case 0x73:
                    Stat = reader.ReadUInt32();
                    break;
                case 0x76:
                    Stat = reader.ReadUInt32();
                    Percent = reader.ReadDouble();
                    break;
                case 0x1E:
                case 0x3B:
                case 0x47:
                case 0x52:
                    Message = reader.ReadString16L();
                    Min = reader.ReadUInt32();
                    Max = reader.ReadUInt32();
                    break;
                case 0x2:
                case 0x3E:
                    Amount64 = reader.ReadUInt64();
                    HeroXP64 = reader.ReadUInt64();
                    break;
                case 0x70:
                case 0x71:
                    Amount64 = reader.ReadUInt64();
                    break;
                case 0x22:
                case 0x2F:
                case 0x30:
                case 0x5A:
                case 0x77:
                case 0x78:
                    Amount = reader.ReadUInt32();
                    break;
                case 0xE:
                case 0x13:
                case 0x1B:
                case 0x49:
                    SpellId = reader.ReadUInt32();
                    break;
                case 0x3:
                case 0x4A:
                    CProfile = new CreationProfile();
                    CProfile.Read(reader);
                    break;
                case 0x4C:
                    Msg = reader.ReadString16L();
                    CProfile = new CreationProfile();
                    CProfile.Read(reader);
                    break;
                case 0x38:
                    WealthRating = reader.ReadInt32();
                    TreasureClass = reader.ReadInt32();
                    TreasureType = reader.ReadInt32();
                    break;
                case 0x5:
                case 0x34:
                    Motion = reader.ReadUInt32();
                    break;
                case 0x4:
                case 0x6:
                case 0xB:
                case 0x57:
                    Frame = new Frame();
                    Frame.Read(reader);
                    break;
                case 0x7:
                    PhysicsScript = reader.ReadUInt32();
                    break;
                case 0x9:
                    Sound = reader.ReadUInt32();
                    break;
                case 0x1C:
                case 0x1D:
                    Amount = reader.ReadUInt32();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x6E:
                    Stat = reader.ReadUInt32();
                    break;
                case 0x6F:
                    Amount = reader.ReadUInt32();
                    break;
                case 0x23:
                case 0x2D:
                case 0x2E:
                    Message = reader.ReadString16L();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x26:
                case 0x4B:
                    Message = reader.ReadString16L();
                    TestString = reader.ReadString16L();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x24:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                case 0x2C:
                    Message = reader.ReadString16L();
                    Min = reader.ReadUInt32();
                    Max = reader.ReadUInt32();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x72:
                    Message = reader.ReadString16L();
                    Min64 = reader.ReadUInt64();
                    Max64 = reader.ReadUInt64();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x25:
                    Message = reader.ReadString16L();
                    FMin = reader.ReadDouble();
                    FMax = reader.ReadDouble();
                    Stat = reader.ReadUInt32();
                    break;
                case 0x31:
                    Percent = reader.ReadDouble();
                    Min64 = reader.ReadUInt64();
                    Max64 = reader.ReadUInt64();
                    break;
                case 0x32:
                    Stat = reader.ReadUInt32();
                    Percent = reader.ReadDouble();
                    Min = reader.ReadUInt32();
                    Max = reader.ReadUInt32();
                    Display = reader.ReadBool();
                    break;
                case 0x3F:
                case 0x63:
                case 0x64:
                    Position = new Position();
                    Position.Read(reader);
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Type);
            writer.Write(Delay);
            writer.Write(Extent);
            switch((int)Type) {
                case 0x01:
                case 0x08:
                case 0x0A:
                case 0x0D:
                case 0x10:
                case 0x11:
                case 0x12:
                case 0x14:
                case 0x15:
                case 0x16:
                case 0x17:
                case 0x18:
                case 0x19:
                case 0x1A:
                case 0x1F:
                case 0x33:
                case 0x3A:
                case 0x3C:
                case 0x3D:
                case 0x40:
                case 0x41:
                case 0x43:
                case 0x44:
                case 0x4F:
                case 0x50:
                case 0x51:
                case 0x53:
                case 0x58:
                case 0x79:
                    writer.Write(Message);
                    break;
                case 0x20:
                case 0x21:
                case 0x46:
                case 0x54:
                case 0x55:
                case 0x56:
                case 0x59:
                case 0x66:
                case 0x67:
                case 0x68:
                case 0x69:
                case 0x6A:
                case 0x6B:
                case 0x6C:
                case 0x6D:
                    writer.Write(Message);
                    writer.Write(Amount);
                    break;
                case 0x35:
                case 0x36:
                case 0x37:
                case 0x45:
                    writer.Write(Stat);
                    writer.Write(Amount);
                    break;
                case 0x73:
                    writer.Write(Stat);
                    break;
                case 0x76:
                    writer.Write(Stat);
                    writer.Write(Percent);
                    break;
                case 0x1E:
                case 0x3B:
                case 0x47:
                case 0x52:
                    writer.Write(Message);
                    writer.Write(Min);
                    writer.Write(Max);
                    break;
                case 0x2:
                case 0x3E:
                    writer.Write(Amount64);
                    writer.Write(HeroXP64);
                    break;
                case 0x70:
                case 0x71:
                    writer.Write(Amount64);
                    break;
                case 0x22:
                case 0x2F:
                case 0x30:
                case 0x5A:
                case 0x77:
                case 0x78:
                    writer.Write(Amount);
                    break;
                case 0xE:
                case 0x13:
                case 0x1B:
                case 0x49:
                    writer.Write(SpellId);
                    break;
                case 0x3:
                case 0x4A:
                    CProfile.Write(writer);
                    break;
                case 0x4C:
                    writer.Write(Msg);
                    CProfile.Write(writer);
                    break;
                case 0x38:
                    writer.Write(WealthRating);
                    writer.Write(TreasureClass);
                    writer.Write(TreasureType);
                    break;
                case 0x5:
                case 0x34:
                    writer.Write(Motion);
                    break;
                case 0x4:
                case 0x6:
                case 0xB:
                case 0x57:
                    Frame.Write(writer);
                    break;
                case 0x7:
                    writer.Write(PhysicsScript);
                    break;
                case 0x9:
                    writer.Write(Sound);
                    break;
                case 0x1C:
                case 0x1D:
                    writer.Write(Amount);
                    writer.Write(Stat);
                    break;
                case 0x6E:
                    writer.Write(Stat);
                    break;
                case 0x6F:
                    writer.Write(Amount);
                    break;
                case 0x23:
                case 0x2D:
                case 0x2E:
                    writer.Write(Message);
                    writer.Write(Stat);
                    break;
                case 0x26:
                case 0x4B:
                    writer.Write(Message);
                    writer.Write(TestString);
                    writer.Write(Stat);
                    break;
                case 0x24:
                case 0x27:
                case 0x28:
                case 0x29:
                case 0x2A:
                case 0x2B:
                case 0x2C:
                    writer.Write(Message);
                    writer.Write(Min);
                    writer.Write(Max);
                    writer.Write(Stat);
                    break;
                case 0x72:
                    writer.Write(Message);
                    writer.Write(Min64);
                    writer.Write(Max64);
                    writer.Write(Stat);
                    break;
                case 0x25:
                    writer.Write(Message);
                    writer.Write(FMin);
                    writer.Write(FMax);
                    writer.Write(Stat);
                    break;
                case 0x31:
                    writer.Write(Percent);
                    writer.Write(Min64);
                    writer.Write(Max64);
                    break;
                case 0x32:
                    writer.Write(Stat);
                    writer.Write(Percent);
                    writer.Write(Min);
                    writer.Write(Max);
                    writer.Write(Display);
                    break;
                case 0x3F:
                case 0x63:
                case 0x64:
                    Position.Write(writer);
                    break;
            }
        }

    }

}
