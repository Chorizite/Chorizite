using System.IO;
using MagicHat.ACProtocol.Extensions;

namespace MagicHat.ACProtocol.Packets {
	public class WorldLoginRequestHeader {
		public ulong Prim;

		public WorldLoginRequestHeader() {
			
		}

		public WorldLoginRequestHeader(BinaryReader reader) {
			Prim = reader.ReadUInt64();
		}
	}
}