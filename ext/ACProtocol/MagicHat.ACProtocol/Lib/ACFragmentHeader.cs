using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using MagicHat.ACProtocol.Types;

namespace MagicHat.ACProtocol.Lib {
	public class ACFragmentHeader : IACDataType {
		public uint Sequence { get; set; }
		public uint Id { get; set; }
		public ushort Count { get; set; }
		public ushort Size { get; set; }
		public ushort Index { get; set; }
		public FragmentGroup Group { get; set; }
		public const int ChunkSize = 448;

		public ACFragmentHeader() {

		}

		public ACFragmentHeader(BinaryReader reader) : this() {
			Read(reader);
		}

		public void Read(BinaryReader reader) {
			Sequence = reader.ReadUInt32();
            Id = reader.ReadUInt32();
			Count = reader.ReadUInt16();
			Size = reader.ReadUInt16();
			Index = reader.ReadUInt16();
			Group = (FragmentGroup)reader.ReadUInt16();
		}
		public void Write(BinaryWriter writer) {
			writer.Write(Sequence);
			writer.Write(Id);
			writer.Write(Count);
			writer.Write(Size);
			writer.Write(Index);
			writer.Write((ushort)Group);
		}
	}
}
