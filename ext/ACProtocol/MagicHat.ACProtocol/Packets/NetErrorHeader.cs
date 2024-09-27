using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public class NetErrorHeader {
		public NetError Error;

		public NetErrorHeader() {
			Error = new NetError();
		}

		public NetErrorHeader(BinaryReader reader) {
			Error = new NetError(reader);
		}
	}
}
