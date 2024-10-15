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
    /// A position with sequences
    /// </summary>
    public class PositionPack : IACDataType {
        public PositionFlags Flags;

        /// <summary>
        /// the location of the object in the world
        /// </summary>
        public Origin Origin;

        public float WQuat;

        public float XQuat;

        public float YQuat;

        public float ZQuat;

        public Vector3 Velocity;

        public uint PlacementId;

        /// <summary>
        /// The instance sequence value for the object (number of logins for players)
        /// </summary>
        public ushort ObjectInstanceSequence;

        /// <summary>
        /// The position sequence value for the object
        /// </summary>
        public ushort ObjectPositionSequence;

        /// <summary>
        /// The teleport sequence value for the object
        /// </summary>
        public ushort ObjectTeleportSequence;

        /// <summary>
        /// The forced position sequence value for the object
        /// </summary>
        public ushort ObjectForcePositionSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = (PositionFlags)reader.ReadUInt32();
            Origin = new Origin();
            Origin.Read(reader);
            if ((((uint)Flags ^ 0x00000078) & 0x00000008) != 0) {
                WQuat = reader.ReadSingle();
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000010) != 0) {
                XQuat = reader.ReadSingle();
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000020) != 0) {
                YQuat = reader.ReadSingle();
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000040) != 0) {
                ZQuat = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                Velocity = reader.ReadVector3();
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                PlacementId = reader.ReadUInt32();
            }
            ObjectInstanceSequence = reader.ReadUInt16();
            ObjectPositionSequence = reader.ReadUInt16();
            ObjectTeleportSequence = reader.ReadUInt16();
            ObjectForcePositionSequence = reader.ReadUInt16();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write((uint)Flags);
            Origin.Write(writer);
            if ((((uint)Flags ^ 0x00000078) & 0x00000008) != 0) {
                writer.Write(WQuat);
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000010) != 0) {
                writer.Write(XQuat);
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000020) != 0) {
                writer.Write(YQuat);
            }
            if ((((uint)Flags ^ 0x00000078) & 0x00000040) != 0) {
                writer.Write(ZQuat);
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.WriteVector3(Velocity);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                writer.Write(PlacementId);
            }
            writer.Write(ObjectInstanceSequence);
            writer.Write(ObjectPositionSequence);
            writer.Write(ObjectTeleportSequence);
            writer.Write(ObjectForcePositionSequence);
        }

    }

}
