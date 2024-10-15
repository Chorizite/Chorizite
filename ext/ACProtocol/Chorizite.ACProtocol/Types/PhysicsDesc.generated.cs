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
    /// The PhysicsDesc structure defines an object&#39;s physical behavior.
    /// </summary>
    public class PhysicsDesc : IACDataType {
        /// <summary>
        /// physics data flags
        /// </summary>
        public uint Flags;

        /// <summary>
        /// The current physics state for the object
        /// </summary>
        public PhysicsState State;

        public List<byte> MovementBuffer = new();

        /// <summary>
        /// Whether the movement is autonomous (0 for no, 1 for yes).  NOTE that this is only present if movementByteCount &gt; 0
        /// </summary>
        public bool Autonomous;

        /// <summary>
        /// The current animation frame.  NOTE this can only be present if 0x00010000 is not set
        /// </summary>
        public uint AnimationFrame;

        /// <summary>
        /// object position
        /// </summary>
        public Position Position;

        /// <summary>
        /// motion table id for this object
        /// </summary>
        public uint MotionId;

        /// <summary>
        /// sound table id for this object
        /// </summary>
        public uint SoundId;

        /// <summary>
        /// physics script table id for this object
        /// </summary>
        public uint PhysicsScriptId;

        /// <summary>
        /// setup table id for this object
        /// </summary>
        public uint SetupId;

        /// <summary>
        /// the creature equipping this object
        /// </summary>
        public uint ParentId;

        /// <summary>
        /// the slot in which this object is equipped, referenced in the Setup table of the dats
        /// </summary>
        public ParentLocation ParentLocation;

        public List<EquipLocation> Children = new();

        /// <summary>
        /// the size of this object
        /// </summary>
        public float Scale;

        public float Friction;

        public float Elasticity;

        public float Translucency;

        public Vector3 Velocity;

        public Vector3 Acceleration;

        public Vector3 Omega;

        public uint DefaultScript;

        public float DefaultScriptIntensity;

        public ushort ObjectPositionSequence;

        public ushort ObjectMovementSequence;

        public ushort ObjectStateSequence;

        public ushort ObjectVectorSequence;

        public ushort ObjectTeleportSequence;

        public ushort ObjectServerControlSequence;

        public ushort ObjectForcePositionSequence;

        public ushort ObjectVisualDescSequence;

        public ushort ObjectInstanceSequence;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = reader.ReadUInt32();
            State = (PhysicsState)reader.ReadUInt32();
            if (((uint)Flags & (uint)0x00010000) != 0) {
                MovementBuffer = reader.ReadPackableList<byte>();
                Autonomous = reader.ReadBool();
            }
            if (((uint)Flags & (uint)0x00020000) != 0) {
                AnimationFrame = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00008000) != 0) {
                Position = new Position();
                Position.Read(reader);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                MotionId = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000800) != 0) {
                SoundId = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00001000) != 0) {
                PhysicsScriptId = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                SetupId = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                ParentId = reader.ReadUInt32();
                ParentLocation = (ParentLocation)reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                Children = reader.ReadPackableList<EquipLocation>();
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                Scale = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                Friction = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                Elasticity = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00040000) != 0) {
                Translucency = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                Velocity = reader.ReadVector3();
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                Acceleration = reader.ReadVector3();
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                Omega = reader.ReadVector3();
            }
            if (((uint)Flags & (uint)0x00002000) != 0) {
                DefaultScript = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00004000) != 0) {
                DefaultScriptIntensity = reader.ReadSingle();
            }
            ObjectPositionSequence = reader.ReadUInt16();
            ObjectMovementSequence = reader.ReadUInt16();
            ObjectStateSequence = reader.ReadUInt16();
            ObjectVectorSequence = reader.ReadUInt16();
            ObjectTeleportSequence = reader.ReadUInt16();
            ObjectServerControlSequence = reader.ReadUInt16();
            ObjectForcePositionSequence = reader.ReadUInt16();
            ObjectVisualDescSequence = reader.ReadUInt16();
            ObjectInstanceSequence = reader.ReadUInt16();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            writer.Write((uint)State);
            if (((uint)Flags & (uint)0x00010000) != 0) {
                writer.WritePackableList(MovementBuffer);
                writer.Write(Autonomous);
            }
            if (((uint)Flags & (uint)0x00020000) != 0) {
                writer.Write(AnimationFrame);
            }
            if (((uint)Flags & (uint)0x00008000) != 0) {
                Position.Write(writer);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                writer.Write(MotionId);
            }
            if (((uint)Flags & (uint)0x00000800) != 0) {
                writer.Write(SoundId);
            }
            if (((uint)Flags & (uint)0x00001000) != 0) {
                writer.Write(PhysicsScriptId);
            }
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.Write(SetupId);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                writer.Write(ParentId);
                writer.Write((uint)ParentLocation);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                writer.WritePackableList(Children);
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                writer.Write(Scale);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                writer.Write(Friction);
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                writer.Write(Elasticity);
            }
            if (((uint)Flags & (uint)0x00040000) != 0) {
                writer.Write(Translucency);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                writer.WriteVector3(Velocity);
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                writer.WriteVector3(Acceleration);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                writer.WriteVector3(Omega);
            }
            if (((uint)Flags & (uint)0x00002000) != 0) {
                writer.Write(DefaultScript);
            }
            if (((uint)Flags & (uint)0x00004000) != 0) {
                writer.Write(DefaultScriptIntensity);
            }
            writer.Write(ObjectPositionSequence);
            writer.Write(ObjectMovementSequence);
            writer.Write(ObjectStateSequence);
            writer.Write(ObjectVectorSequence);
            writer.Write(ObjectTeleportSequence);
            writer.Write(ObjectServerControlSequence);
            writer.Write(ObjectForcePositionSequence);
            writer.Write(ObjectVisualDescSequence);
            writer.Write(ObjectInstanceSequence);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
