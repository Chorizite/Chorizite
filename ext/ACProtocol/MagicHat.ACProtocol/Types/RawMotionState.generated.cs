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
    /// Data related to the movement of the object sent from a client
    /// </summary>
    public class RawMotionState : IACDataType {
        /// <summary>
        /// Command Id
        /// </summary>
        public uint Flags;

        /// <summary>
        /// Derived from Flags. Sequence of the animation.
        /// </summary>
        public ushort CommandListLength { get => (ushort)((Flags >> 11) & 0xF8); }

        public HoldKey CurrentHoldkey;

        /// <summary>
        /// Current stance.  If not present, defaults to 0x3D (NonCombat)
        /// </summary>
        public StanceMode CurrentStyle;

        /// <summary>
        /// Command for our forward movement. If not present, defaults to 0x03 (Ready)
        /// </summary>
        public MovementCommand ForwardCommand;

        /// <summary>
        /// Whether forward key is being held
        /// </summary>
        public HoldKey ForwardHoldkey;

        /// <summary>
        /// Forward movement speed. If not present, defaults to 1.0
        /// </summary>
        public float ForwardSpeed;

        /// <summary>
        /// Command for our sidestep movememnt. If not present, defaults to 0x00
        /// </summary>
        public MovementCommand SidestepCommand;

        /// <summary>
        /// Whether sidestep key is being held
        /// </summary>
        public HoldKey SidestepHoldkey;

        /// <summary>
        /// Sidestep movement speed. If not present, defaults to 1.0
        /// </summary>
        public float SidestepSpeed;

        /// <summary>
        /// Command for our turn movememnt. If not present, defaults to 0x00
        /// </summary>
        public MovementCommand TurnCommand;

        /// <summary>
        /// Whether turn key is being held
        /// </summary>
        public uint TurnHoldkey;

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
                CurrentHoldkey = (HoldKey)reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                CurrentStyle = (StanceMode)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                ForwardCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x0000008) != 0) {
                ForwardHoldkey = (HoldKey)reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                ForwardSpeed = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                SidestepCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                SidestepHoldkey = (HoldKey)reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                SidestepSpeed = reader.ReadSingle();
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                TurnCommand = (MovementCommand)reader.ReadUInt16();
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                TurnHoldkey = reader.ReadUInt32();
            }
            if (((uint)Flags & (uint)0x00000400) != 0) {
                TurnSpeed = reader.ReadSingle();
            }
            for (var i=0; i < CommandListLength; i++) {
                Commands.Add(reader.ReadItem<PackedMotionCommand>());
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Flags);
            if (((uint)Flags & (uint)0x00000001) != 0) {
                writer.Write((uint)CurrentHoldkey);
            }
            if (((uint)Flags & (uint)0x00000002) != 0) {
                writer.Write((ushort)CurrentStyle);
            }
            if (((uint)Flags & (uint)0x00000004) != 0) {
                writer.Write((ushort)ForwardCommand);
            }
            if (((uint)Flags & (uint)0x0000008) != 0) {
                writer.Write((uint)ForwardHoldkey);
            }
            if (((uint)Flags & (uint)0x00000010) != 0) {
                writer.Write(ForwardSpeed);
            }
            if (((uint)Flags & (uint)0x00000020) != 0) {
                writer.Write((ushort)SidestepCommand);
            }
            if (((uint)Flags & (uint)0x00000040) != 0) {
                writer.Write((uint)SidestepHoldkey);
            }
            if (((uint)Flags & (uint)0x00000080) != 0) {
                writer.Write(SidestepSpeed);
            }
            if (((uint)Flags & (uint)0x00000100) != 0) {
                writer.Write((ushort)TurnCommand);
            }
            if (((uint)Flags & (uint)0x00000200) != 0) {
                writer.Write(TurnHoldkey);
            }
            if (((uint)Flags & (uint)0x00000400) != 0) {
                writer.Write(TurnSpeed);
            }
            for (var i=0; i < CommandListLength; i++) {
            }
        }

    }

}
