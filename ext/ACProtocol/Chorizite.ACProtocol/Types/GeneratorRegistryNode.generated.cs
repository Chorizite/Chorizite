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
    public class GeneratorRegistryNode : IACDataType {
        public uint WcidOrType;

        public double Ts;

        public uint TreasureType;

        public uint Slot;

        public uint Checkpointed;

        public uint Shop;

        public uint Amount;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            WcidOrType = reader.ReadUInt32();
            Ts = reader.ReadDouble();
            TreasureType = reader.ReadUInt32();
            Slot = reader.ReadUInt32();
            Checkpointed = reader.ReadUInt32();
            Shop = reader.ReadUInt32();
            Amount = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(WcidOrType);
            writer.Write(Ts);
            writer.Write(TreasureType);
            writer.Write(Slot);
            writer.Write(Checkpointed);
            writer.Write(Shop);
            writer.Write(Amount);
        }

    }

}
