using System.IO;
using System.Collections.Generic;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Types;
using Chorizite.ACProtocol.Extensions;
using System.Numerics;

namespace Chorizite.ACProtocol.Messages.S2C.Events {
    /// <summary>
    /// The result of an attempt to assess an item or creature.
    /// </summary>
    public class Item_SetAppraiseInfo : ACGameEvent {
        /// <summary>
        /// the object Id of the item or creature being assessed
        /// </summary>
        public uint ObjectId;

        public uint Flags;

        /// <summary>
        /// assessment successful: 0=no, 1=yes
        /// </summary>
        public bool Success;

        public Dictionary<PropertyInt, int> IntProperties = new();

        public Dictionary<PropertyInt64, long> Int64Properties = new();

        public Dictionary<PropertyBool, bool> BoolProperties = new();

        public Dictionary<PropertyFloat, double> FloatProperties = new();

        public Dictionary<PropertyString, string> StringProperties = new();

        public Dictionary<PropertyDataId, uint> DataIdProperties = new();

        public List<LayeredSpellId> SpellBook = new();

        public ArmorProfile ArmorProfile;

        public CreatureAppraisalProfile CreatureProfile;

        public WeaponProfile WeaponProfile;

        public HookAppraisalProfile HookProfile;

        /// <summary>
        /// highlight enable bitmask: 0=no, 1=yes
        /// </summary>
        public ArmorHighlightMask ArmorHighlight;

        /// <summary>
        /// highlight color bitmask: 0=red, 1=green
        /// </summary>
        public ArmorHighlightMask ArmorColor;

        /// <summary>
        /// highlight enable bitmask: 0=no, 1=yes
        /// </summary>
        public WeaponHighlightMask WeaponHighlight;

        /// <summary>
        /// highlight color bitmask: 0=red, 1=green
        /// </summary>
        public WeaponHighlightMask WeaponColor;

        /// <summary>
        /// highlight enable bitmask: 0=no, 1=yes
        /// </summary>
        public ResistHighlightMask ResistHighlight;

        /// <summary>
        /// highlight color bitmask: 0=red, 1=green
        /// </summary>
        public ResistHighlightMask ResistColor;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorHead;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorChest;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorGroin;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorBicep;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorWrist;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorHand;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorThigh;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorShin;

        /// <summary>
        /// Armor level
        /// </summary>
        public uint BaseArmorFoot;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public override void Read(BinaryReader reader) {
            base.Read(reader);
            ObjectId = reader.ReadUInt32();
            Flags = reader.ReadUInt32();
            Success = reader.ReadBool();
            if (((uint)Flags & (uint)0x00000001) != 0) {
                IntProperties = reader.ReadPackableHashTable<PropertyInt, int>();
            }
            if (((uint)Flags & (uint)0x00002000) != 0) {
                Int64Properties = reader.ReadPackableHashTable<PropertyInt64, long>();
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                BoolProperties = reader.ReadPackableHashTable<PropertyBool, bool>();
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                FloatProperties = reader.ReadPackableHashTable<PropertyFloat, double>();
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                StringProperties = reader.ReadPackableHashTable<PropertyString, string>();
            }
            if (((uint)Flags & (uint)0x00001000) != 0) {
                DataIdProperties = reader.ReadPackableHashTable<PropertyDataId, uint>();
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                SpellBook = reader.ReadPackableList<LayeredSpellId>();
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                ArmorProfile = new ArmorProfile();
                ArmorProfile.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                CreatureProfile = new CreatureAppraisalProfile();
                CreatureProfile.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                WeaponProfile = new WeaponProfile();
                WeaponProfile.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                HookProfile = new HookAppraisalProfile();
                HookProfile.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                ArmorHighlight = (ArmorHighlightMask)reader.ReadUInt16();
                ArmorColor = (ArmorHighlightMask)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000800) != 0) {
                WeaponHighlight = (WeaponHighlightMask)reader.ReadUInt16();
                WeaponColor = (WeaponHighlightMask)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000400) != 0) {
                ResistHighlight = (ResistHighlightMask)reader.ReadUInt16();
                ResistColor = (ResistHighlightMask)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00004000) != 0) {
                BaseArmorHead = reader.ReadUInt32();
                BaseArmorChest = reader.ReadUInt32();
                BaseArmorGroin = reader.ReadUInt32();
                BaseArmorBicep = reader.ReadUInt32();
                BaseArmorWrist = reader.ReadUInt32();
                BaseArmorHand = reader.ReadUInt32();
                BaseArmorThigh = reader.ReadUInt32();
                BaseArmorShin = reader.ReadUInt32();
                BaseArmorFoot = reader.ReadUInt32();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public override void Write(BinaryWriter writer) {
            base.Write(writer);
            writer.Write(ObjectId);
            writer.Write(Flags);
            writer.Write(Success);
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.WritePackableHashTable(IntProperties);
            }
            if (((uint)Flags & (uint)0x00002000) != 0) {
                writer.WritePackableHashTable(Int64Properties);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                writer.WritePackableHashTable(BoolProperties);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                writer.WritePackableHashTable(FloatProperties);
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                writer.WritePackableHashTable(StringProperties);
            }
            if (((uint)Flags & (uint)0x00001000) != 0) {
                writer.WritePackableHashTable(DataIdProperties);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                writer.WritePackableList(SpellBook);
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                ArmorProfile.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                CreatureProfile.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                WeaponProfile.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                HookProfile.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                writer.Write((ushort)ArmorHighlight);
                writer.Write((ushort)ArmorColor);
            }
            if (((uint)Flags & (uint)0x00000800) != 0) {
                writer.Write((ushort)WeaponHighlight);
                writer.Write((ushort)WeaponColor);
            }
            if (((uint)Flags & (uint)0x00000400) != 0) {
                writer.Write((ushort)ResistHighlight);
                writer.Write((ushort)ResistColor);
            }
            if (((uint)Flags & (uint)0x00004000) != 0) {
                writer.Write(BaseArmorHead);
                writer.Write(BaseArmorChest);
                writer.Write(BaseArmorGroin);
                writer.Write(BaseArmorBicep);
                writer.Write(BaseArmorWrist);
                writer.Write(BaseArmorHand);
                writer.Write(BaseArmorThigh);
                writer.Write(BaseArmorShin);
                writer.Write(BaseArmorFoot);
            }
        }

    }

}
