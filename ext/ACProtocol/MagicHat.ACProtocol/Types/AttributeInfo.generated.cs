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
    /// <summary>
    /// The Attribute structure contains information about a character attribute.
    /// </summary>
    public class AttributeInfo : IACDataType {
        /// <summary>
        /// points raised
        /// </summary>
        public uint PointsRaised;

        /// <summary>
        /// innate points
        /// </summary>
        public uint InnatePoints;

        /// <summary>
        /// XP spent on this attribute
        /// </summary>
        public uint ExperienceSpent;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            PointsRaised = reader.ReadUInt32();
            InnatePoints = reader.ReadUInt32();
            ExperienceSpent = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(PointsRaised);
            writer.Write(InnatePoints);
            writer.Write(ExperienceSpent);
        }

    }

}
