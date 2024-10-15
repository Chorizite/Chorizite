using System.IO;
using Chorizite.ACProtocol.Extensions;

namespace Chorizite.ACProtocol.Packets {
	public class WorldLoginRequestHeader {
		public ulong Prim;

		public WorldLoginRequestHeader() {
			
		}

		public WorldLoginRequestHeader(BinaryReader reader) {
			Prim = reader.ReadUInt64();
		}
	}
}