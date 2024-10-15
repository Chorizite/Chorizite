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
    /// <summary>
    /// The OldPublicWeenieDesc structure defines an object&#39;s game behavior.
    /// </summary>
    public class OldPublicWeenieDesc : IACDataType {
        /// <summary>
        /// game data flags
        /// </summary>
        public uint Header;

        /// <summary>
        /// object name
        /// </summary>
        public string Name;

        /// <summary>
        /// object weenie class id
        /// </summary>
        public uint WeenieClassId;

        /// <summary>
        /// icon ResourceId (minus 0x06000000)
        /// </summary>
        public uint Icon;

        /// <summary>
        /// object type
        /// </summary>
        public ItemType Type;

        /// <summary>
        /// object behaviors
        /// </summary>
        public ObjectDescriptionFlag Bitfield;

        /// <summary>
        /// plural object name (if not specified, use &lt;name&gt; followed by &#39;s&#39; or &#39;es&#39;)
        /// </summary>
        public string PluralName;

        /// <summary>
        /// number of item slots
        /// </summary>
        public byte ItemsCapacity;

        /// <summary>
        /// number of pack slots
        /// </summary>
        public byte ContainerCapacity;

        /// <summary>
        /// object value
        /// </summary>
        public uint Value;

        public Usable Useability;

        /// <summary>
        /// distance a player will walk to use an object
        /// </summary>
        public float UseRadius;

        /// <summary>
        /// the object categories this object may be used on
        /// </summary>
        public ItemType TargetType;

        /// <summary>
        /// the type of highlight (outline) applied to the object&#39;s icon
        /// </summary>
        public IconHighlight Effects;

        /// <summary>
        /// missile ammunition type
        /// </summary>
        public AmmoType AmmunitionType;

        /// <summary>
        /// the type of wieldable item this is
        /// </summary>
        public WieldType CombatUse;

        /// <summary>
        /// the number of uses remaining for this item (also salvage quantity)
        /// </summary>
        public ushort Structure;

        /// <summary>
        /// the maximum number of uses possible for this item (also maximum salvage quantity)
        /// </summary>
        public ushort MaxStructure;

        /// <summary>
        /// the number of items in this stack of objects
        /// </summary>
        public ushort StackSize;

        /// <summary>
        /// the maximum number of items possible in this stack of objects
        /// </summary>
        public ushort MaxStackSize;

        /// <summary>
        /// the Id of the container holding this object
        /// </summary>
        public uint ContainerId;

        /// <summary>
        /// the Id of the creature equipping this object
        /// </summary>
        public uint WielderId;

        /// <summary>
        /// the potential equipment slots this object may be placed in
        /// </summary>
        public EquipMask ValidSlots;

        /// <summary>
        /// the actual equipment slots this object is currently placed in
        /// </summary>
        public EquipMask Slots;

        /// <summary>
        /// the parts of the body this object protects
        /// </summary>
        public CoverageMask Priority;

        /// <summary>
        /// radar dot color
        /// </summary>
        public RadarColor BlipColor;

        /// <summary>
        /// radar type
        /// </summary>
        public RadarBehavior RadarEnum;

        public float ObviousDistance;

        public ushort Vndwcid;

        /// <summary>
        /// the spell cast by this object
        /// </summary>
        public ushort SpellId;

        public uint HouseOwnerId;

        public ushort PhysicsScript;

        /// <summary>
        /// the access control list for this dwelling object
        /// </summary>
        public RestrictionDB Restrictions;

        /// <summary>
        /// the types of hooks this object may be placed on (-1 for hooks)
        /// </summary>
        public HookType HookType;

        /// <summary>
        /// what type of dwelling hook is this
        /// </summary>
        public HookType HookItemTypes;

        /// <summary>
        /// this player&#39;s monarch
        /// </summary>
        public uint MonarchId;

        /// <summary>
        /// icon overlay ResourceId (minus 0x06000000)
        /// </summary>
        public uint IconOverlay;

        /// <summary>
        /// the type of material this object is made of
        /// </summary>
        public MaterialType Material;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Header = reader.ReadUInt32();
            Name = reader.ReadString16L();
            WeenieClassId = reader.ReadPackedDWORD();
            Icon = reader.ReadPackedDWORD();
            Type = (ItemType)reader.ReadUInt32();
            Bitfield = (ObjectDescriptionFlag)reader.ReadUInt32();
            if (((uint)Header & (uint)0x00000001) != 0) {
                PluralName = reader.ReadString16L();
            }
            if (((uint)Header & (uint)0x00000002) != 0) {
                ItemsCapacity = reader.ReadByte();
            }
            if (((uint)Header & (uint)0x00000004) != 0) {
                ContainerCapacity = reader.ReadByte();
            }
            if (((uint)Header & (uint)0x00000008) != 0) {
                Value = reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00000010) != 0) {
                Useability = (Usable)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00000020) != 0) {
                UseRadius = reader.ReadSingle();
            }
            if (((uint)Header & (uint)0x00080000) != 0) {
                TargetType = (ItemType)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00000080) != 0) {
                Effects = (IconHighlight)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00000100) != 0) {
                AmmunitionType = (AmmoType)reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00000200) != 0) {
                CombatUse = (WieldType)reader.ReadByte();
            }
            if (((uint)Header & (uint)0x00000400) != 0) {
                Structure = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00000800) != 0) {
                MaxStructure = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00001000) != 0) {
                StackSize = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00002000) != 0) {
                MaxStackSize = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00004000) != 0) {
                ContainerId = reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00008000) != 0) {
                WielderId = reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00010000) != 0) {
                ValidSlots = (EquipMask)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00020000) != 0) {
                Slots = (EquipMask)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00040000) != 0) {
                Priority = (CoverageMask)reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x00100000) != 0) {
                BlipColor = (RadarColor)reader.ReadByte();
            }
            if (((uint)Header & (uint)0x00800000) != 0) {
                RadarEnum = (RadarBehavior)reader.ReadByte();
            }
            if (((uint)Header & (uint)0x01000000) != 0) {
                ObviousDistance = reader.ReadSingle();
            }
            if (((uint)Header & (uint)0x00200000) != 0) {
                Vndwcid = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00400000) != 0) {
                SpellId = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x02000000) != 0) {
                HouseOwnerId = reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x08000000) != 0) {
                PhysicsScript = reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x04000000) != 0) {
                Restrictions = new RestrictionDB();
                Restrictions.Read(reader);
            }
            if (((uint)Header & (uint)0x10000000) != 0) {
                HookType = (HookType)reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x20000000) != 0) {
                HookItemTypes = (HookType)reader.ReadUInt16();
            }
            if (((uint)Header & (uint)0x00000040) != 0) {
                MonarchId = reader.ReadUInt32();
            }
            if (((uint)Header & (uint)0x40000000) != 0) {
                IconOverlay = reader.ReadPackedDWORD();
            }
            if (((uint)Header & (uint)0x80000000) != 0) {
                Material = (MaterialType)reader.ReadUInt32();
            }
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Header);
            writer.Write(Name);
            writer.Write(WeenieClassId);
            writer.Write(Icon);
            writer.Write((uint)Type);
            writer.Write((uint)Bitfield);
            if (((uint)Header & (uint)0x00000001) != 0) {
                writer.Write(PluralName);
            }
            if (((uint)Header & (uint)0x00000002) != 0) {
                writer.Write(ItemsCapacity);
            }
            if (((uint)Header & (uint)0x00000004) != 0) {
                writer.Write(ContainerCapacity);
            }
            if (((uint)Header & (uint)0x00000008) != 0) {
                writer.Write(Value);
            }
            if (((uint)Header & (uint)0x00000010) != 0) {
                writer.Write((uint)Useability);
            }
            if (((uint)Header & (uint)0x00000020) != 0) {
                writer.Write(UseRadius);
            }
            if (((uint)Header & (uint)0x00080000) != 0) {
                writer.Write((uint)TargetType);
            }
            if (((uint)Header & (uint)0x00000080) != 0) {
                writer.Write((uint)Effects);
            }
            if (((uint)Header & (uint)0x00000100) != 0) {
                writer.Write((ushort)AmmunitionType);
            }
            if (((uint)Header & (uint)0x00000200) != 0) {
                writer.Write((byte)CombatUse);
            }
            if (((uint)Header & (uint)0x00000400) != 0) {
                writer.Write(Structure);
            }
            if (((uint)Header & (uint)0x00000800) != 0) {
                writer.Write(MaxStructure);
            }
            if (((uint)Header & (uint)0x00001000) != 0) {
                writer.Write(StackSize);
            }
            if (((uint)Header & (uint)0x00002000) != 0) {
                writer.Write(MaxStackSize);
            }
            if (((uint)Header & (uint)0x00004000) != 0) {
                writer.Write(ContainerId);
            }
            if (((uint)Header & (uint)0x00008000) != 0) {
                writer.Write(WielderId);
            }
            if (((uint)Header & (uint)0x00010000) != 0) {
                writer.Write((uint)ValidSlots);
            }
            if (((uint)Header & (uint)0x00020000) != 0) {
                writer.Write((uint)Slots);
            }
            if (((uint)Header & (uint)0x00040000) != 0) {
                writer.Write((uint)Priority);
            }
            if (((uint)Header & (uint)0x00100000) != 0) {
                writer.Write((byte)BlipColor);
            }
            if (((uint)Header & (uint)0x00800000) != 0) {
                writer.Write((byte)RadarEnum);
            }
            if (((uint)Header & (uint)0x01000000) != 0) {
                writer.Write(ObviousDistance);
            }
            if (((uint)Header & (uint)0x00200000) != 0) {
                writer.Write(Vndwcid);
            }
            if (((uint)Header & (uint)0x00400000) != 0) {
                writer.Write(SpellId);
            }
            if (((uint)Header & (uint)0x02000000) != 0) {
                writer.Write(HouseOwnerId);
            }
            if (((uint)Header & (uint)0x08000000) != 0) {
                writer.Write(PhysicsScript);
            }
            if (((uint)Header & (uint)0x04000000) != 0) {
                Restrictions.Write(writer);
            }
            if (((uint)Header & (uint)0x10000000) != 0) {
                writer.Write((ushort)HookType);
            }
            if (((uint)Header & (uint)0x20000000) != 0) {
                writer.Write((ushort)HookItemTypes);
            }
            if (((uint)Header & (uint)0x00000040) != 0) {
                writer.Write(MonarchId);
            }
            if (((uint)Header & (uint)0x40000000) != 0) {
                writer.Write(IconOverlay);
            }
            if (((uint)Header & (uint)0x80000000) != 0) {
                writer.Write((uint)Material);
            }
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
