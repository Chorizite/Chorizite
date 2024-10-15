using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chorizite.ACProtocol.Packets {
	public class ServerSwitchHeader {
		public uint SeqNo;
		public ServerSwitchType Type;

		public ServerSwitchHeader() {
			
		}

		public ServerSwitchHeader(BinaryReader reader) {
			SeqNo = reader.ReadUInt32();
			Type = (ServerSwitchType)reader.ReadUInt32();
		}
	}
}
