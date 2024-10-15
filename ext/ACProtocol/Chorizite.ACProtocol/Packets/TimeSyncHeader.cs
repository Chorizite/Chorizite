using System.IO;

namespace Chorizite.ACProtocol.Packets {
	public class TimeSyncHeader {
		public ulong Time;

		public TimeSyncHeader() {

		}

		public TimeSyncHeader(BinaryReader reader) {
			Time = reader.ReadUInt64();
		}
	}
}