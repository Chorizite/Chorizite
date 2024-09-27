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
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Extensions;
namespace MagicHat.ACProtocol.Types {
    public class WeaponProfile : IACDataType {
        /// <summary>
        /// the type of damage done by the weapon
        /// </summary>
        public DamageType DamageType;

        /// <summary>
        /// the speed of the weapon
        /// </summary>
        public uint Speed;

        /// <summary>
        /// the skill used by the weapon (-1 if none)
        /// </summary>
        public SkillId Skill;

        /// <summary>
        /// the maximum damage done by the weapon
        /// </summary>
        public uint Damage;

        /// <summary>
        /// the maximum damage variance of the weapon
        /// </summary>
        public double Variance;

        /// <summary>
        /// the damage modifier of the weapon
        /// </summary>
        public double Modifier;

        public double Length;

        /// <summary>
        /// the power of the weapon (this affects range)
        /// </summary>
        public double MaxVelocity;

        /// <summary>
        /// the attack skill bonus of the weapon
        /// </summary>
        public double Offsense;

        public uint MaxVelocityEstimated;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            DamageType = (DamageType)reader.ReadUInt32();
            Speed = reader.ReadUInt32();
            Skill = (SkillId)reader.ReadInt32();
            Damage = reader.ReadUInt32();
            Variance = reader.ReadDouble();
            Modifier = reader.ReadDouble();
            Length = reader.ReadDouble();
            MaxVelocity = reader.ReadDouble();
            Offsense = reader.ReadDouble();
            MaxVelocityEstimated = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)DamageType);
            writer.Write(Speed);
            writer.Write((int)Skill);
            writer.Write(Damage);
            writer.Write(Variance);
            writer.Write(Modifier);
            writer.Write(Length);
            writer.Write(MaxVelocity);
            writer.Write(Offsense);
            writer.Write(MaxVelocityEstimated);
        }

    }

}
