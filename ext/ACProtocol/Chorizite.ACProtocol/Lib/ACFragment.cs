using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace Chorizite.ACProtocol.Lib {
	public class ACFragment {
		public byte[] Data;
		public int Count;
		public int Received;
		public int Length;

		public uint Sequence;

		private bool[] chunks;

		public ACFragment(uint sequence, int count) {
			Sequence = sequence;
			Data = new byte[count * ACFragmentHeader.ChunkSize];
			Count = count;

			chunks = new bool[Count];
		}

		public void AddChunk(byte[] data, int index, int size) {
			if (index < chunks.Length && !chunks[index]) {
				data.CopyTo(Data, index * ACFragmentHeader.ChunkSize);
				Received++;
				Length += size;
				chunks[index] = true;
			}
			else {
				//Console.WriteLine($"Chunk {index}/{Count} ?? {size} // {Sequence}");
			}
		}
	}
}
