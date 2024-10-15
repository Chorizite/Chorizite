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
    /// Contains information for animations and general free motion
    /// </summary>
    public class InterpertedMotionState : IACDataType {
        public uint Flags;

        /// <summary>
        /// Derived from Flags. 
        /// </summary>
        public uint CommandListLength { get => (uint)((Flags >> 7) & 0x7F); }

        /// <summary>
        /// Stance.  If not present, defaults to 0x3D (NonCombat)
        /// </summary>
        public StanceMode CurrentStyle;

        /// <summary>
        /// Command for our forward movement. If not present, defaults to 0x03 (Ready)
        /// </summary>
        public MovementCommand ForwardCommand;

        /// <summary>
        /// Command for our sidestep movememnt. If not present, defaults to 0x00
        /// </summary>
        public MovementCommand SidestepCommand;

        /// <summary>
        /// Command for our turn movememnt. If not present, defaults to 0x00
        /// </summary>
        public MovementCommand TurnCommand;

        /// <summary>
        /// Forward movement speed. If not present, defaults to 1.0
        /// </summary>
        public float ForwardSpeed;

        /// <summary>
        /// Sidestep movement speed. If not present, defaults to 1.0
        /// </summary>
        public float SidestepSpeed;

        /// <summary>
        /// Turn movement speed. If not present, defaults to 1.0
        /// </summary>
        public float TurnSpeed;

        public List<PackedMotionCommand> Commands = new List<PackedMotionCommand>();

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Flags = reader.ReadUInt32();
            if (((uint)Flags & (uint)0x00000001) != 0) {
                CurrentStyle = (StanceMode)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                ForwardCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                SidestepCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                TurnCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                ForwardSpeed = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                SidestepSpeed = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                TurnSpeed = reader.ReadSingle();
            }
            for (var i=0; i < CommandListLength; i++) {
                Commands.Add(reader.ReadItem<PackedMotionCommand>());
            }
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.Write((ushort)CurrentStyle);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                writer.Write((ushort)ForwardCommand);
            }
            if (((uint)Flags & (uint)0x00000008) != 0) {
                writer.Write((ushort)SidestepCommand);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                writer.Write((ushort)TurnCommand);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                writer.Write(ForwardSpeed);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                writer.Write(SidestepSpeed);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                writer.Write(TurnSpeed);
            }
            for (var i=0; i < CommandListLength; i++) {
            }
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
        }

    }

}
