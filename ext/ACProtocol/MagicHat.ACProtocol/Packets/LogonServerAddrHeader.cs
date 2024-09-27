using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public class LogonServerAddrHeader {
		public SocketAddr SocketAddress;

		public LogonServerAddrHeader() {
			SocketAddress = new SocketAddr();
		}

		public LogonServerAddrHeader(BinaryReader reader) {
			SocketAddress = new SocketAddr(reader);
		}
	}
}
