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
    /// Data for a character creation
    /// </summary>
    public class CharGenResult : IACDataType {
        /// <summary>
        /// Account name
        /// </summary>
        public string Account;

        /// <summary>
        /// Always 1
        /// </summary>
        public uint One;

        public HeritageGroup HeritageGroup;

        public Gender Gender;

        public uint EyesStrip;

        public uint NoseStrip;

        public uint MouthStrip;

        public uint HairColor;

        public uint EyeColor;

        public uint HairStyle;

        public uint HeadgearStyle;

        public uint HeadgearColor;

        public uint ShirtStyle;

        public uint ShirtColor;

        public uint TrousersStyle;

        public uint TrousersColor;

        public uint FootwearStyle;

        public uint FootwearColor;

        public ulong SkinShade;

        public ulong HairShade;

        public ulong HeadgearShade;

        public ulong ShirtShade;

        public ulong TrousersShade;

        public ulong TootwearShade;

        public uint TemplateNum;

        public uint Strength;

        public uint Endurance;

        public uint Coordination;

        public uint Quickness;

        public uint Focus;

        public uint Self;

        public uint Slot;

        public uint ClassId;

        public List<SkillAdvancementClass> Skills = new();

        public string Name;

        public uint StartArea;

        public uint IsAdmin;

        public uint IsEnvoy;

        /// <summary>
        /// Seems to be the total of heritageGroup, gender, eyesStrip, noseStrip, mouthStrip, hairColor, eyeColor, hairStyle, headgearStyle, shirtStyle, trousersStyle, footwearStyle, templateNum, strength, endurance, coordination, quickness, focus, self. Perhaps used for some kind of validation?
        /// </summary>
        public uint Validation;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Account = reader.ReadString16L();
            One = reader.ReadUInt32();
            HeritageGroup = (HeritageGroup)reader.ReadByte();
            Gender = (Gender)reader.ReadByte();
            EyesStrip = reader.ReadUInt32();
            NoseStrip = reader.ReadUInt32();
            MouthStrip = reader.ReadUInt32();
            HairColor = reader.ReadUInt32();
            EyeColor = reader.ReadUInt32();
            HairStyle = reader.ReadUInt32();
            HeadgearStyle = reader.ReadUInt32();
            HeadgearColor = reader.ReadUInt32();
            ShirtStyle = reader.ReadUInt32();
            ShirtColor = reader.ReadUInt32();
            TrousersStyle = reader.ReadUInt32();
            TrousersColor = reader.ReadUInt32();
            FootwearStyle = reader.ReadUInt32();
            FootwearColor = reader.ReadUInt32();
            SkinShade = reader.ReadUInt64();
            HairShade = reader.ReadUInt64();
            HeadgearShade = reader.ReadUInt64();
            ShirtShade = reader.ReadUInt64();
            TrousersShade = reader.ReadUInt64();
            TootwearShade = reader.ReadUInt64();
            TemplateNum = reader.ReadUInt32();
            Strength = reader.ReadUInt32();
            Endurance = reader.ReadUInt32();
            Coordination = reader.ReadUInt32();
            Quickness = reader.ReadUInt32();
            Focus = reader.ReadUInt32();
            Self = reader.ReadUInt32();
            Slot = reader.ReadUInt32();
            ClassId = reader.ReadUInt32();
            Skills = reader.ReadPackableList<SkillAdvancementClass>();
            Name = reader.ReadString16L();
            StartArea = reader.ReadUInt32();
            IsAdmin = reader.ReadUInt32();
            IsEnvoy = reader.ReadUInt32();
            Validation = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Account);
            writer.Write(One);
            writer.Write((byte)HeritageGroup);
            writer.Write((byte)Gender);
            writer.Write(EyesStrip);
            writer.Write(NoseStrip);
            writer.Write(MouthStrip);
            writer.Write(HairColor);
            writer.Write(EyeColor);
            writer.Write(HairStyle);
            writer.Write(HeadgearStyle);
            writer.Write(HeadgearColor);
            writer.Write(ShirtStyle);
            writer.Write(ShirtColor);
            writer.Write(TrousersStyle);
            writer.Write(TrousersColor);
            writer.Write(FootwearStyle);
            writer.Write(FootwearColor);
            writer.Write(SkinShade);
            writer.Write(HairShade);
            writer.Write(HeadgearShade);
            writer.Write(ShirtShade);
            writer.Write(TrousersShade);
            writer.Write(TootwearShade);
            writer.Write(TemplateNum);
            writer.Write(Strength);
            writer.Write(Endurance);
            writer.Write(Coordination);
            writer.Write(Quickness);
            writer.Write(Focus);
            writer.Write(Self);
            writer.Write(Slot);
            writer.Write(ClassId);
            writer.WritePackableList(Skills);
            writer.Write(Name);
            writer.Write(StartArea);
            writer.Write(IsAdmin);
            writer.Write(IsEnvoy);
            writer.Write(Validation);
        }

    }

}
