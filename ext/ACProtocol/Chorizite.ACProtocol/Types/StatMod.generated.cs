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
    /// Information on stat modification
    /// </summary>
    public class StatMod : IACDataType {
        /// <summary>
        /// flags that indicate the type of effect the spell has
        /// </summary>
        public EnchantmentTypeFlags Type;

        /// <summary>
        /// along with flags, indicates which attribute is affected by the spell
        /// </summary>
        public uint Key;

        /// <summary>
        /// the effect value/amount
        /// </summary>
        public float Value;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Type = (EnchantmentTypeFlags)reader.ReadUInt32();
            Key = reader.ReadUInt32();
            Value = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Type);
            writer.Write(Key);
            writer.Write(Value);
        }

    }

}
