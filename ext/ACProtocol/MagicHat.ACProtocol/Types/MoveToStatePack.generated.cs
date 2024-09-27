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
    /// A set of data related to changing states with sequences
    /// </summary>
    public class MoveToStatePack : IACDataType {
        /// <summary>
        /// Raw motion data
        /// </summary>
        public RawMotionState RawMotionState;

        /// <summary>
        /// Position data
        /// </summary>
        public Position Position;

        /// <summary>
        /// The instance sequence value for the object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The server control sequence value for the object
        /// </summary>
        public ushort ObjectServerControlSequence;

        /// <summary>
        /// The teleport sequence value for the object
        /// </summary>
        public ushort ObjectTeleportSequence;

        /// <summary>
        /// The forced position sequence value for the object
        /// </summary>
        public ushort ObjectForcePositionSequence;

        /// <summary>
        /// Whether the player has contact with the ground, or if we are in longjump_mode(1 = contact, 2 = longjump_mode)
        /// </summary>
        public byte Contact;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            RawMotionState = new RawMotionState();
            RawMotionState.Read(reader);
            Position = new Position();
            Position.Read(reader);
            ObjectInstanceSequence = reader.ReadUInt16();
            ObjectServerControlSequence = reader.ReadUInt16();
            ObjectTeleportSequence = reader.ReadUInt16();
            ObjectForcePositionSequence = reader.ReadUInt16();
            Contact = reader.ReadByte();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            RawMotionState.Write(writer);
            Position.Write(writer);
            writer.Write(ObjectInstanceSequence);
            writer.Write(ObjectServerControlSequence);
            writer.Write(ObjectTeleportSequence);
            writer.Write(ObjectForcePositionSequence);
            writer.Write(Contact);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
