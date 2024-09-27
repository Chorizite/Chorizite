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
    /// Set of movement parameters required for a TurnTo motion
    /// </summary>
    public class TurnToMovementParameters : IACDataType {
        /// <summary>
        /// bitmember of some options related to the motion (TODO needs further research)
        /// </summary>
        public uint Bitmember;

        /// <summary>
        /// speed of animation
        /// </summary>
        public float AnimationSpeed;

        /// <summary>
        /// Heading the object is turning to
        /// </summary>
        public float DesiredHeading;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Bitmember = reader.ReadUInt32();
            AnimationSpeed = reader.ReadSingle();
            DesiredHeading = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Bitmember);
            writer.Write(AnimationSpeed);
            writer.Write(DesiredHeading);
        }

    }

}
