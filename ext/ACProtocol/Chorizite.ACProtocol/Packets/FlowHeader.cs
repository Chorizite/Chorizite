using System.IO;

namespace Chorizite.ACProtocol.Packets {
	public class FlowHeader {
		public uint DataReceived;
		public ushort Interval;

		public FlowHeader() {

		}

		public FlowHeader(BinaryReader reader) {
			DataReceived = reader.ReadUInt32();
			Interval = reader.ReadUInt16();
		}
	}
}