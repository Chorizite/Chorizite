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
    /// Information related to a secure trade.
    /// </summary>
    public class Trade : IACDataType {
        /// <summary>
        /// Id of other participant in the trade
        /// </summary>
        public uint PartnerId;

        /// <summary>
        /// Some kind of sequence
        /// </summary>
        public ulong Sequence;

        /// <summary>
        /// Some kind of status for the trade TODO
        /// </summary>
        public uint Status;

        /// <summary>
        /// Id of person who initiated the trade
        /// </summary>
        public uint InitiatorId;

        /// <summary>
        /// Whether you accepted this trade
        /// </summary>
        public bool Accepted;

        /// <summary>
        /// Whether the partner accepted this trade
        /// </summary>
        public bool PartnerAccepted;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            PartnerId = reader.ReadUInt32();
            Sequence = reader.ReadUInt64();
            Status = reader.ReadUInt32();
            InitiatorId = reader.ReadUInt32();
            Accepted = reader.ReadBool();
            PartnerAccepted = reader.ReadBool();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(PartnerId);
            writer.Write(Sequence);
            writer.Write(Status);
            writer.Write(InitiatorId);
            writer.Write(Accepted);
            writer.Write(PartnerAccepted);
        }

    }

}
