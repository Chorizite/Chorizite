using System.IO;

namespace MagicHat.ACProtocol.Packets {
	public class NetError {
		public uint StringId;
		public uint TableId;

		public NetError() {

		}

		public NetError(BinaryReader reader) {
			StringId = reader.ReadUInt32();
			TableId = reader.ReadUInt32();
		}
	}
}