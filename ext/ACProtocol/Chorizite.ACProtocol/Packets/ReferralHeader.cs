using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Chorizite.ACProtocol.Packets {
	public class ReferralHeader {
		public ulong Cookie;
		public SocketAddr SocketAddress;
		public ushort IdServer;
		public uint Unknown;

		public ReferralHeader() {
			SocketAddress = new SocketAddr();
		}

		public ReferralHeader(BinaryReader reader) {
			Cookie = reader.ReadUInt64();
			SocketAddress = new SocketAddr(reader);
			IdServer = reader.ReadUInt16();
			_ = reader.ReadUInt16(); // padding
			Unknown = reader.ReadUInt32();
		}
	}
}
