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
    /// A the location and orientation of an object within a landcell
    /// </summary>
    public class Frame : IACDataType {
        /// <summary>
        /// the location in a landcell in which the object is located
        /// </summary>
        public Vector3 Origin;

        /// <summary>
        /// a quaternion describing the object&#39;s orientation
        /// </summary>
        public Quaternion Orientation;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Origin = reader.ReadVector3();
            Orientation = reader.ReadQuaternion();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.WriteVector3(Origin);
            writer.WriteQuaternion(Orientation);
        }

    }

}
