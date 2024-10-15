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
    /// Data related to the movement and animation of the object
    /// </summary>
    public class MovementData : IACDataType {
        /// <summary>
        /// The movement sequence value for this object
        /// </summary>
        public ushort ObjectMovementSequence;

        /// <summary>
        /// The server control sequence value for the object
        /// </summary>
        public ushort ObjectServerControlSequence;

        /// <summary>
        /// 0x0 - server controlled, 0x1 - autonomous
        /// </summary>
        public ushort Autonomous;

        /// <summary>
        /// Determines the type of movement that follows
        /// </summary>
        public MovementType MovementType;

        /// <summary>
        /// Options for this movement (sticky, standing long jump)
        /// </summary>
        public MovementOption OptionFlags;

        /// <summary>
        /// Current stance
        /// </summary>
        public StanceMode Stance;

        /// <summary>
        /// Set of motion data
        /// </summary>
        public InterpertedMotionState State;

        /// <summary>
        /// object to stick to
        /// </summary>
        public uint StickyObject;

        /// <summary>
        /// The id of target that&#39;s being moved to
        /// </summary>
        public uint Target;

        /// <summary>
        /// the location of the target in the world
        /// </summary>
        public Origin Origin;

        /// <summary>
        /// Set of movement parameters
        /// </summary>
        public MoveToMovementParameters MoveToParams;

        /// <summary>
        /// Run speed of the moving object
        /// </summary>
        public float MyRunRate;

        /// <summary>
        /// The id of target that&#39;s being faced
        /// </summary>
        public uint TargetId;

        /// <summary>
        /// Heading of the target to turn to, this is used instead of the desiredHeading in the parameters
        /// </summary>
        public float DesiredHeading;

        /// <summary>
        /// Set of movement parameters
        /// </summary>
        public TurnToMovementParameters TurnToParams;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            ObjectMovementSequence = reader.ReadUInt16();
            ObjectServerControlSequence = reader.ReadUInt16();
            Autonomous = reader.ReadUInt16();
            MovementType = (MovementType)reader.ReadByte();
            OptionFlags = (MovementOption)reader.ReadByte();
            Stance = (StanceMode)reader.ReadUInt16();
            switch((int)MovementType) {
                case 0x0000:
                    State = new InterpertedMotionState();
                    State.Read(reader);
                    if (((uint)OptionFlags & (uint)0x01) != 0) {
                        StickyObject = reader.ReadUInt32();
                    }
                    break;
                case 0x0006:
                    Target = reader.ReadUInt32();
                    Origin = new Origin();
                    Origin.Read(reader);
                    MoveToParams = new MoveToMovementParameters();
                    MoveToParams.Read(reader);
                    MyRunRate = reader.ReadSingle();
                    break;
                case 0x0007:
                    Origin = new Origin();
                    Origin.Read(reader);
                    MoveToParams = new MoveToMovementParameters();
                    MoveToParams.Read(reader);
                    MyRunRate = reader.ReadSingle();
                    break;
                case 0x0008:
                    TargetId = reader.ReadUInt32();
                    DesiredHeading = reader.ReadSingle();
                    TurnToParams = new TurnToMovementParameters();
                    TurnToParams.Read(reader);
                    break;
                case 0x0009:
                    TurnToParams = new TurnToMovementParameters();
                    TurnToParams.Read(reader);
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(ObjectMovementSequence);
            writer.Write(ObjectServerControlSequence);
            writer.Write(Autonomous);
            writer.Write((byte)MovementType);
            writer.Write((byte)OptionFlags);
            writer.Write((ushort)Stance);
            switch((int)MovementType) {
                case 0x0000:
                    State.Write(writer);
                    if (((uint)OptionFlags & (uint)0x01) != 0) {
                        writer.Write(StickyObject);
                    }
                    break;
                case 0x0006:
                    writer.Write(Target);
                    Origin.Write(writer);
                    MoveToParams.Write(writer);
                    writer.Write(MyRunRate);
                    break;
                case 0x0007:
                    Origin.Write(writer);
                    MoveToParams.Write(writer);
                    writer.Write(MyRunRate);
                    break;
                case 0x0008:
                    writer.Write(TargetId);
                    writer.Write(DesiredHeading);
                    TurnToParams.Write(writer);
                    break;
                case 0x0009:
                    TurnToParams.Write(writer);
                    break;
            }
        }

    }

}
