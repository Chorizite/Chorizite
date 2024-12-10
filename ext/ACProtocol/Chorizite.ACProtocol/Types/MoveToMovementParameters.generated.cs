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
    /// Set of movement parameters required for a MoveTo movement
    /// </summary>
    public class MoveToMovementParameters : IACDataType {
        /// <summary>
        /// bitmember of some options related to the motion (TODO needs further research)
        /// </summary>
        public uint Bitmember;

        /// <summary>
        /// The distance to the given location
        /// </summary>
        public float DistanceToObject;

        /// <summary>
        /// The minimum distance required for the movement
        /// </summary>
        public float MinDistance;

        /// <summary>
        /// The distance at which the movement will fail
        /// </summary>
        public float FailDistance;

        /// <summary>
        /// speed of animation
        /// </summary>
        public float AnimationSpeed;

        /// <summary>
        /// The distance from the location which determines whether you walk or run towards it.
        /// </summary>
        public float WalkRunThreshold;

        /// <summary>
        /// Heading the object is turning to
        /// </summary>
        public float DesiredHeading;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Bitmember = reader.ReadUInt32();
            DistanceToObject = reader.ReadSingle();
            MinDistance = reader.ReadSingle();
            FailDistance = reader.ReadSingle();
            AnimationSpeed = reader.ReadSingle();
            WalkRunThreshold = reader.ReadSingle();
            DesiredHeading = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Bitmember);
            writer.Write(DistanceToObject);
            writer.Write(MinDistance);
            writer.Write(FailDistance);
            writer.Write(AnimationSpeed);
            writer.Write(WalkRunThreshold);
            writer.Write(DesiredHeading);
        }

    }

}
