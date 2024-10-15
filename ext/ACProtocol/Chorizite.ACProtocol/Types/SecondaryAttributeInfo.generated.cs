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
    /// The SecondaryAttribute structure contains information about a character vital.
    /// </summary>
    public class SecondaryAttributeInfo : IACDataType {
        /// <summary>
        /// secondary attribute&#39;s data
        /// </summary>
        public AttributeInfo Attribute;

        /// <summary>
        /// current value of the vital
        /// </summary>
        public uint Current;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Attribute = new AttributeInfo();
            Attribute.Read(reader);
            Current = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            Attribute.Write(writer);
            writer.Write(Current);
        }

    }

}
