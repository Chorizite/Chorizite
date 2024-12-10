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
    /// The Enchantment structure describes an active enchantment.
    /// </summary>
    public class Enchantment : IACDataType {
        /// <summary>
        /// the spell Id of the enchantment
        /// </summary>
        public LayeredSpellId Id;

        /// <summary>
        /// Value greater or equal to 1 means we read EquipmentSet
        /// </summary>
        public ushort HasEquipmentSet;

        /// <summary>
        /// the family of related spells this enchantment belongs to
        /// </summary>
        public SpellCategory SpellCategory;

        /// <summary>
        /// the difficulty of the spell
        /// </summary>
        public uint PowerLevel;

        /// <summary>
        /// the amount of time this enchantment has been active
        /// </summary>
        public double StartTime;

        /// <summary>
        /// the duration of the spell
        /// </summary>
        public double Duration;

        /// <summary>
        /// the object Id of the creature or item that cast this enchantment
        /// </summary>
        public uint CasterId;

        /// <summary>
        /// unknown
        /// </summary>
        public float DegradeModifier;

        /// <summary>
        /// unknown
        /// </summary>
        public float DegradeLimit;

        /// <summary>
        /// the time when this enchantment was cast
        /// </summary>
        public double LastTimeDegraded;

        /// <summary>
        /// Stat modification information
        /// </summary>
        public StatMod StatMod;

        /// <summary>
        /// Related to armor sets somehow?
        /// </summary>
        public EquipmentSet EquipmentSet;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Id = new LayeredSpellId();
            Id.Read(reader);
            HasEquipmentSet = reader.ReadUInt16();
            SpellCategory = (SpellCategory)reader.ReadUInt16();
            PowerLevel = reader.ReadUInt32();
            StartTime = reader.ReadDouble();
            Duration = reader.ReadDouble();
            CasterId = reader.ReadUInt32();
            DegradeModifier = reader.ReadSingle();
            DegradeLimit = reader.ReadSingle();
            LastTimeDegraded = reader.ReadDouble();
            StatMod = new StatMod();
            StatMod.Read(reader);
            if (HasEquipmentSet > 0) {
                EquipmentSet = (EquipmentSet)reader.ReadUInt32();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            Id.Write(writer);
            writer.Write(HasEquipmentSet);
            writer.Write((ushort)SpellCategory);
            writer.Write(PowerLevel);
            writer.Write(StartTime);
            writer.Write(Duration);
            writer.Write(CasterId);
            writer.Write(DegradeModifier);
            writer.Write(DegradeLimit);
            writer.Write(LastTimeDegraded);
            StatMod.Write(writer);
            if (HasEquipmentSet > 0) {
                writer.Write((uint)EquipmentSet);
            }
        }

    }

}
