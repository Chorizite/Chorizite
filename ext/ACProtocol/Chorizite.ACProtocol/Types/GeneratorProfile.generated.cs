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
    public class GeneratorProfile : IACDataType {
        public float Probability;

        public uint TypeId;

        public double Delay;

        public uint InitCreate;

        public uint MaxNum;

        public uint WhenCreate;

        public uint WhereCreate;

        public uint StackSize;

        public uint Ptid;

        public float Shade;

        public Position PosVal;

        public uint Slot;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Probability = reader.ReadSingle();
            TypeId = reader.ReadUInt32();
            Delay = reader.ReadDouble();
            InitCreate = reader.ReadUInt32();
            MaxNum = reader.ReadUInt32();
            WhenCreate = reader.ReadUInt32();
            WhereCreate = reader.ReadUInt32();
            StackSize = reader.ReadUInt32();
            Ptid = reader.ReadUInt32();
            Shade = reader.ReadSingle();
            PosVal = new Position();
            PosVal.Read(reader);
            Slot = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Probability);
            writer.Write(TypeId);
            writer.Write(Delay);
            writer.Write(InitCreate);
            writer.Write(MaxNum);
            writer.Write(WhenCreate);
            writer.Write(WhereCreate);
            writer.Write(StackSize);
            writer.Write(Ptid);
            writer.Write(Shade);
            PosVal.Write(writer);
            writer.Write(Slot);
        }

    }

}
