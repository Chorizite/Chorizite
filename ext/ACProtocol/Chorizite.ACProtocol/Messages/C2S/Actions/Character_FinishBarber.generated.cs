using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.C2S.Actions {
    /// <summary>
    /// Completes the barber interaction
    /// </summary>
    public class Character_FinishBarber : ACGameAction {
        public uint BasePalette;

        public uint HeadObject;

        public uint HeadTexture;

        public uint DefaultHeadTexture;

        public uint EyesTexture;

        public uint DefaultEyesTexture;

        public uint NoseTexture;

        public uint DefaultNoseTexture;

        public uint MouthTexture;

        public uint DefaultMouthTexture;

        public uint SkinPalette;

        public uint HairPalette;

        public uint EyesPalette;

        public uint SetupId;

        /// <summary>
        /// Specifies the toggle option for some races, such as floating empyrean or flaming head on undead
        /// </summary>
        public int Option1;

        /// <summary>
        /// Seems to be unused
        /// </summary>
        public int Option2;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            BasePalette = reader.ReadPackedDWORD();
            HeadObject = reader.ReadPackedDWORD();
            HeadTexture = reader.ReadPackedDWORD();
            DefaultHeadTexture = reader.ReadPackedDWORD();
            EyesTexture = reader.ReadPackedDWORD();
            DefaultEyesTexture = reader.ReadPackedDWORD();
            NoseTexture = reader.ReadPackedDWORD();
            DefaultNoseTexture = reader.ReadPackedDWORD();
            MouthTexture = reader.ReadPackedDWORD();
            DefaultMouthTexture = reader.ReadPackedDWORD();
            SkinPalette = reader.ReadPackedDWORD();
            HairPalette = reader.ReadPackedDWORD();
            EyesPalette = reader.ReadPackedDWORD();
            SetupId = reader.ReadPackedDWORD();
            Option1 = reader.ReadInt32();
            Option2 = reader.ReadInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(BasePalette);
            writer.Write(HeadObject);
            writer.Write(HeadTexture);
            writer.Write(DefaultHeadTexture);
            writer.Write(EyesTexture);
            writer.Write(DefaultEyesTexture);
            writer.Write(NoseTexture);
            writer.Write(DefaultNoseTexture);
            writer.Write(MouthTexture);
            writer.Write(DefaultMouthTexture);
            writer.Write(SkinPalette);
            writer.Write(HairPalette);
            writer.Write(EyesPalette);
            writer.Write(SetupId);
            writer.Write(Option1);
            writer.Write(Option2);
        }

    }

}
