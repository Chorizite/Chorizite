using System.IO;

namespace MagicHat.ACProtocol.Packets {
	public class EchoResponseHeader {
		public float LocalTime;
		public float HoldingTime;

		public EchoResponseHeader() {

		}

		public EchoResponseHeader(BinaryReader reader) {
			LocalTime = reader.ReadSingle();
			HoldingTime = reader.ReadSingle();
		}
	}
}