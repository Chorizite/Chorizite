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
    /// Optional header data when PacketHeaderFlags includes LoginRequest
    /// </summary>
    public class LoginRequestHeader : IACDataType {
        public string ClientVersion;

        public uint Length;

        public NetAuthType AuthType;

        public AuthFlags Flags;

        public uint Sequence;

        /// <summary>
        /// The name of the account that is authenticating.
        /// </summary>
        public string Account;

        /// <summary>
        /// The name of the account to login as (admin only).
        /// </summary>
        public string AccountToLoginAs;

        /// <summary>
        /// The password for this account, when using NetaAuthType.AccountPassword
        /// </summary>
        public string Password;

        /// <summary>
        /// The GlsTicket for this account, when using NetaAuthType.GlsTicket
        /// </summary>
        public string GlsTicket;

        /// <summary>
        /// Reads instance data from a binary reader
        /// </summary>
        public void Read(BinaryReader reader) {
            ClientVersion = reader.ReadString16L();
            Length = reader.ReadUInt32();
            AuthType = (NetAuthType)reader.ReadUInt32();
            Flags = (AuthFlags)reader.ReadUInt32();
            Sequence = reader.ReadUInt32();
            Account = reader.ReadString16L();
            AccountToLoginAs = reader.ReadString16L();
            switch((int)AuthType) {
                case 0x00000002:
                    Password = reader.ReadString32L();
                    break;
                case 0x40000002:
                    GlsTicket = reader.ReadString16L();
                    break;
            }
        }

        /// <summary>
        /// Writes instance data to a binary writer
        /// </summary>
        public void Write(BinaryWriter writer) {
            writer.Write(ClientVersion);
            writer.Write(Length);
            writer.Write((uint)AuthType);
            writer.Write((uint)Flags);
            writer.Write(Sequence);
            writer.Write(Account);
            writer.Write(AccountToLoginAs);
            switch((int)AuthType) {
                case 0x00000002:
                    writer.Write(Password);
                    break;
                case 0x40000002:
                    writer.Write(GlsTicket);
                    break;
            }
        }

    }

}
