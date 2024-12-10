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
    /// Optional header data when PacketHeaderFlags includes ConnectRequest
    /// </summary>
    public class ConnectRequestHeader : IACDataType {
        public double ServerTime;

        public ulong Cookie;

        public int NetID;

        public uint OutgoingSeed;

        public uint IncomingSeed;

        public uint Unknown;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            ServerTime = reader.ReadDouble();
            Cookie = reader.ReadUInt64();
            NetID = reader.ReadInt32();
            OutgoingSeed = reader.ReadUInt32();
            IncomingSeed = reader.ReadUInt32();
            Unknown = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(ServerTime);
            writer.Write(Cookie);
            writer.Write(NetID);
            writer.Write(OutgoingSeed);
            writer.Write(IncomingSeed);
            writer.Write(Unknown);
        }

    }

}
