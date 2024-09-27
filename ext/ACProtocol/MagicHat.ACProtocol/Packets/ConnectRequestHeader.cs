using System.IO;
using MagicHat.ACProtocol.Extensions;

namespace MagicHat.ACProtocol.Packets {
	public class ConnectRequestHeader {
		public double ServerTime;
		public ulong Cookie;
		public uint NetID;
		public uint OutgoingSeed;
		public uint IncomingSeed;
		public uint Unknown;

		public ConnectRequestHeader() {
			
		}

		public ConnectRequestHeader(BinaryReader reader) {
			ServerTime = reader.ReadDouble();
			Cookie = reader.ReadUInt64();
			NetID = reader.ReadUInt32();
			OutgoingSeed = reader.ReadUInt32();
			IncomingSeed = reader.ReadUInt32();
			Unknown = reader.ReadUInt32();
		}
	}
}