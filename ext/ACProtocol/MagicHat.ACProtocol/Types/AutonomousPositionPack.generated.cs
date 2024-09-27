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
    /// An autonomous position with sequences
    /// </summary>
    public class AutonomousPositionPack : IACDataType {
        /// <summary>
        /// position
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
        /// Whether the player has contact with the ground
        /// </summary>
        public byte Contact;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
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
