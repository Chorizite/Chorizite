using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MagicHat.ACProtocol.Packets {
	public class AckSequenceHeader {
		public uint Sequence;

		public AckSequenceHeader() {
			
		}

		public AckSequenceHeader(BinaryReader reader) {
			Sequence = reader.ReadUInt32();
		}
	}
}
