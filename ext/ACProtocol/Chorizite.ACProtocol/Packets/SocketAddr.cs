using System.IO;
using System.Net;

namespace Chorizite.ACProtocol.Packets {
	public class SocketAddr {
		public short Family;
		public ushort Port;
		public IPAddress Address;

		public SocketAddr() {
			Address = new IPAddress(0);
		}

		public SocketAddr(BinaryReader reader) {
			Family = reader.ReadInt16();
			Port = reader.ReadUInt16();
			Address = new IPAddress(reader.ReadBytes(4));
			_ = reader.ReadBytes(8); // char sin_zero[8]
		}
	}
}