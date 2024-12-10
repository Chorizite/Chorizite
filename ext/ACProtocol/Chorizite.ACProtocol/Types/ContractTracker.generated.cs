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
    /// <summary>
    /// Contains information about a contract.
    /// </summary>
    public class ContractTracker : IACDataType {
        public uint Version;

        public ContractId ContractId;

        public ContractStage ContractStage;

        public long TimeWhenDone;

        public long TimeWhenRepeats;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Version = reader.ReadUInt32();
            ContractId = (ContractId)reader.ReadUInt32();
            ContractStage = (ContractStage)reader.ReadUInt32();
            TimeWhenDone = reader.ReadInt64();
            TimeWhenRepeats = reader.ReadInt64();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Version);
            writer.Write((uint)ContractId);
            writer.Write((uint)ContractStage);
            writer.Write(TimeWhenDone);
            writer.Write(TimeWhenRepeats);
        }

    }

}
