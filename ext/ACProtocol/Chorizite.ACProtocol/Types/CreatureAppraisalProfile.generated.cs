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
    public class CreatureAppraisalProfile : IACDataType {
        /// <summary>
        /// These Flags indication which members will be available for assess.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// current health
        /// </summary>
        public uint Health;

        /// <summary>
        /// maximum health
        /// </summary>
        public uint HealthMax;

        /// <summary>
        /// strength
        /// </summary>
        public uint Strength;

        /// <summary>
        /// endurance
        /// </summary>
        public uint Endurance;

        /// <summary>
        /// quickness
        /// </summary>
        public uint Quickness;

        /// <summary>
        /// coordination
        /// </summary>
        public uint Coordination;

        /// <summary>
        /// focus
        /// </summary>
        public uint Focus;

        /// <summary>
        /// self
        /// </summary>
        public uint Self;

        /// <summary>
        /// current stamina
        /// </summary>
        public uint Stamina;

        /// <summary>
        /// current mana
        /// </summary>
        public uint Mana;

        /// <summary>
        /// maximum stamina
        /// </summary>
        public uint StaminaMax;

        /// <summary>
        /// maximum mana
        /// </summary>
        public uint ManaMax;

        /// <summary>
        /// highlight enable bitmask: 0=no, 1=yes
        /// </summary>
        public AttributeMask AttrHighlight;

        /// <summary>
        /// highlight color bitmask: 0=red, 1=green
        /// </summary>
        public AttributeMask AttrColor;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = reader.ReadUInt32();
            Health = reader.ReadUInt32();
            HealthMax = reader.ReadUInt32();
            if (((uint)Flags & (uint)0x00000008) != 0) {
                Strength = reader.ReadUInt32();
                Endurance = reader.ReadUInt32();
                Quickness = reader.ReadUInt32();
                Coordination = reader.ReadUInt32();
                Focus = reader.ReadUInt32();
                Self = reader.ReadUInt32();
                Stamina = reader.ReadUInt32();
                Mana = reader.ReadUInt32();
                StaminaMax = reader.ReadUInt32();
                ManaMax = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                AttrHighlight = (AttributeMask)reader.ReadUInt16();
                AttrColor = (AttributeMask)reader.ReadUInt16();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            writer.Write(Health);
            writer.Write(HealthMax);
            if (((uint)Flags & (uint)0x00000008) != 0) {
                writer.Write(Strength);
                writer.Write(Endurance);
                writer.Write(Quickness);
                writer.Write(Coordination);
                writer.Write(Focus);
                writer.Write(Self);
                writer.Write(Stamina);
                writer.Write(Mana);
                writer.Write(StaminaMax);
                writer.Write(ManaMax);
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.Write((ushort)AttrHighlight);
                writer.Write((ushort)AttrColor);
            }
        }

    }

}
