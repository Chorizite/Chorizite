using System.IO;

namespace Chorizite.ACProtocol.Packets {
	public class EchoRequestHeader {
		public float LocalTime;

		public EchoRequestHeader() {

		}

		public EchoRequestHeader(BinaryReader reader) {
			LocalTime = reader.ReadSingle();
		}
	}
}