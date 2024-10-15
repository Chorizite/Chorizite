using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chorizite.ACProtocol.Packets {
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
