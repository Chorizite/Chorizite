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
    /// A collection of property tables.
    /// </summary>
    public class ACBaseQualities : IACDataType {
        /// <summary>
        /// determines which property types appear in the message
        /// </summary>
        public ACBaseQualitiesFlags Flags;

        /// <summary>
        /// Expect it always should be 0xA
        /// </summary>
        public WeenieType WeenieType;

        public Dictionary<PropertyInt, int> IntProperties = new();

        public Dictionary<PropertyInt64, long> Int64Properties = new();

        public Dictionary<PropertyBool, bool> BoolProperties = new();

        public Dictionary<PropertyFloat, double> FloatProperties = new();

        public Dictionary<PropertyString, string> StringProperties = new();

        public Dictionary<PropertyDataId, uint> DataProperties = new();

        public Dictionary<PropertyInstanceId, uint> InstanceProperties = new();

        public Dictionary<PropertyPosition, Position> PositionProperties = new();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = (ACBaseQualitiesFlags)reader.ReadUInt32();
            WeenieType = (WeenieType)reader.ReadUInt32();
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt)) {
                IntProperties = reader.ReadPackableHashTable<PropertyInt, int>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt64)) {
                Int64Properties = reader.ReadPackableHashTable<PropertyInt64, long>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyBool)) {
                BoolProperties = reader.ReadPackableHashTable<PropertyBool, bool>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyFloat)) {
                FloatProperties = reader.ReadPackableHashTable<PropertyFloat, double>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyString)) {
                StringProperties = reader.ReadPackableHashTable<PropertyString, string>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyDataId)) {
                DataProperties = reader.ReadPackableHashTable<PropertyDataId, uint>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInstanceId)) {
                InstanceProperties = reader.ReadPackableHashTable<PropertyInstanceId, uint>();
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyPosition)) {
                PositionProperties = reader.ReadPackableHashTable<PropertyPosition, Position>();
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Flags);
            writer.Write((uint)WeenieType);
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt)) {
                writer.WritePackableHashTable(IntProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInt64)) {
                writer.WritePackableHashTable(Int64Properties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyBool)) {
                writer.WritePackableHashTable(BoolProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyFloat)) {
                writer.WritePackableHashTable(FloatProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyString)) {
                writer.WritePackableHashTable(StringProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyDataId)) {
                writer.WritePackableHashTable(DataProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyInstanceId)) {
                writer.WritePackableHashTable(InstanceProperties);
            }
            if (Flags.HasFlag(ACBaseQualitiesFlags.PropertyPosition)) {
                writer.WritePackableHashTable(PositionProperties);
            }
        }

    }

}
