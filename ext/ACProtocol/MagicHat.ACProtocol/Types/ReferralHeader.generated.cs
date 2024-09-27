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
    /// Optional header data when PacketHeaderFlags includes Referral
    /// </summary>
    public class ReferralHeader : IACDataType {
        public ulong Cookie;

        public SocketAddress Address;

        public ushort IdServer;

        public uint Unknown;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            Cookie = reader.ReadUInt64();
            Address = new SocketAddress();
            Address.Read(reader);
            IdServer = reader.ReadUInt16();
            if ((reader.BaseStream.Position % 4) != 0) {
                reader.BaseStream.Position += 4 - (reader.BaseStream.Position % 4);
            }
            Unknown = reader.ReadUInt32();
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(Cookie);
            Address.Write(writer);
            writer.Write(IdServer);
            if ((writer.BaseStream.Position % 4) != 0) {
                writer.BaseStream.Position += 4 - (writer.BaseStream.Position % 4);
            }
            writer.Write(Unknown);
        }

    }

}
