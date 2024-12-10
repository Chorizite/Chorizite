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
    /// The AttributeCache structure contains information about a character attributes.
    /// </summary>
    public class AttributeCache : IACDataType {
        /// <summary>
        /// The attributes included in the character description - this is always 0x1FF
        /// </summary>
        public uint Flags;

        /// <summary>
        /// strength attribute information
        /// </summary>
        public AttributeInfo Strength;

        /// <summary>
        /// endurance attribute information
        /// </summary>
        public AttributeInfo Endurance;

        /// <summary>
        /// quickness attribute information
        /// </summary>
        public AttributeInfo Quickness;

        /// <summary>
        /// coordination attribute information
        /// </summary>
        public AttributeInfo Coordination;

        /// <summary>
        /// focus attribute information
        /// </summary>
        public AttributeInfo Focus;

        /// <summary>
        /// self attribute information
        /// </summary>
        public AttributeInfo Self;

        /// <summary>
        /// health vital information
        /// </summary>
        public SecondaryAttributeInfo Health;

        /// <summary>
        /// stamina vital information
        /// </summary>
        public SecondaryAttributeInfo Stamina;

        /// <summary>
        /// mana vital information
        /// </summary>
        public SecondaryAttributeInfo Mana;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = reader.ReadUInt32();
            if (((uint)Flags & (uint)0x00000001) != 0) {
                Strength = new AttributeInfo();
                Strength.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                Endurance = new AttributeInfo();
                Endurance.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                Quickness = new AttributeInfo();
                Quickness.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                Coordination = new AttributeInfo();
                Coordination.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                Focus = new AttributeInfo();
                Focus.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                Self = new AttributeInfo();
                Self.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                Health = new SecondaryAttributeInfo();
                Health.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                Stamina = new SecondaryAttributeInfo();
                Stamina.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                Mana = new SecondaryAttributeInfo();
                Mana.Read(reader);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            if (((uint)Flags & (uint)0x00000001) != 0) {
                Strength.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                Endurance.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                Quickness.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                Coordination.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                Focus.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                Self.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                Health.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                Stamina.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                Mana.Write(writer);
            }
        }

    }

}
