using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MagicHat.ACProtocol.Extensions;

namespace MagicHat.ACProtocol.Lib.PCap {
	public record PCapPacketHeader {
		public PhysicalAddress EthDestination { get; }
		public PhysicalAddress EthSource { get; }
		public ushort EthProtocol { get; }

		public IPAddress SourceAddr { get; }
		public IPAddress DestinationAddr { get; }
		public byte IPProtocol { get; }

		public ushort SourcePort { get; }
		public ushort DestinationPort { get; }
		public ushort Length { get; }
		public ushort Crc { get; }

		public PCapPacketHeader() {

		}

		public PCapPacketHeader(BinaryReader reader) : this() {
			// ethernet frame
			_ = reader.ReadBytes(6);
			_ = reader.ReadBytes(6);
			//EthDestination = new PhysicalAddress(reader.ReadBytes(6));
			//EthSource = new PhysicalAddress(reader.ReadBytes(6));
			EthProtocol = reader.ReadUInt16BigEndian();

			// ip header... 
			_ = reader.ReadBytes(9);
			IPProtocol = reader.ReadByte();
			_ = reader.ReadBytes(2);
			SourceAddr = new IPAddress(reader.ReadBytes(4));
			DestinationAddr = new IPAddress(reader.ReadBytes(4));

			// udp
			if (IPProtocol == 0x11) {
				SourcePort = reader.ReadUInt16BigEndian();
				DestinationPort = reader.ReadUInt16BigEndian();
				Length = reader.ReadUInt16BigEndian();
				Crc = reader.ReadUInt16BigEndian();
			}
		}
	}
}
