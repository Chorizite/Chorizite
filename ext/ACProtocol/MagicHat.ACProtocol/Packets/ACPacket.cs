using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MagicHat.ACProtocol.Lib;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Types;

namespace MagicHat.ACProtocol.Packets {
	public class ACPacket {
		public ACPacketHeader Header { get; }
		public List<ACMessage> Messages { get; } = new List<ACMessage>();
		public ACFragment? Fragment { get; internal set; }

		public ACPacket() {
			Header = new ACPacketHeader();
		}

		public ACPacket(BinaryReader reader) {
			Header = new ACPacketHeader(reader);
		}
	}
}
