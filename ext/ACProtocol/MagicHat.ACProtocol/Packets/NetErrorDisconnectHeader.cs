using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public class NetErrorDisconnectHeader {
		public NetError Error;

		public NetErrorDisconnectHeader() {
			Error = new NetError();
		}

		public NetErrorDisconnectHeader(BinaryReader reader) {
			Error = new NetError(reader);
		}
	}
}
