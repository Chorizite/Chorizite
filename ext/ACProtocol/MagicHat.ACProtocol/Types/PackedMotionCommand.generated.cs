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
    public class PackedMotionCommand : IACDataType {
        /// <summary>
        /// Command Id
        /// </summary>
        public Command CommandId;

        /// <summary>
        /// Sequence of the animation.
        /// </summary>
        public ushort PackedSequence;

        /// <summary>
        /// Derived from PackedSequence. Sequence of the animation.
        /// </summary>
        public ushort ServerActionSequence { get => (ushort)(PackedSequence & 0x7FFF); }

        /// <summary>
        /// Derived from PackedSequence. Whether command is autonomous
        /// </summary>
        public ushort Autonomous { get => (ushort)((PackedSequence >> 15) & 0x1); }

        /// <summary>
        /// Command speed
        /// </summary>
        public float Speed;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            CommandId = (Command)reader.ReadUInt16();
            PackedSequence = reader.ReadUInt16();
            Speed = reader.ReadSingle();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((ushort)CommandId);
            writer.Write(PackedSequence);
            writer.Write(Speed);
        }

    }

}
