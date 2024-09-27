using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public class ConnectResponseHeader {
		public ulong Prim;

		public ConnectResponseHeader() {

		}

		public ConnectResponseHeader(BinaryReader reader) {
			Prim = reader.ReadUInt64();
		}
	}
}
