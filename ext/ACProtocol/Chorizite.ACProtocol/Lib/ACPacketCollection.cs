using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Lib.PCap;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Packets;
using Chorizite.ACProtocol.Types;

namespace Chorizite.ACProtocol.Lib {
	public class ACPacketCollection {
		public List<ACPCapPacket> Packets { get; } = new List<ACPCapPacket>();
		public Dictionary<uint, ACFragment>  PendingFragments = new Dictionary<uint, ACFragment>();

		private MessageReader _messageHandler;

		public static async Task<ACPacketCollection> FromPCap(Stream stream, Action<string>? onProgress = null) {
			var collection = new ACPacketCollection();
			var pcapHeaderSize = 24;
			var buffer = new byte[pcapHeaderSize];
			var readBytes = await stream.ReadAsync(buffer, 0, pcapHeaderSize);
			var magic = BitConverter.ToUInt32(buffer, 0);

			if (readBytes != pcapHeaderSize || magic != 0xa1b2c3d4) {
				throw new Exception($"Unsupported PCap file. Magic was {magic}");
			}

			// ehhhhhh
			var readBuffer = new byte[stream.Length - 24];
			var offset = 0;
			int bytesRead;
			do {
				bytesRead = await stream.ReadAsync(readBuffer, offset, Math.Min(1024 * 1024, (int)stream.Length - 24 - offset));
				offset += bytesRead;
				onProgress?.Invoke($"Reading PCap file... {Math.Round(offset / (double)stream.Length * 100)}%");
				await Task.Delay(1);
			}
			while (bytesRead > 0);

			using var byteStream = new MemoryStream(readBuffer);
			using var reader = new BinaryReader(byteStream);
			var i = 0;
			var time = DateTime.UtcNow;
			while (reader.BaseStream.Position < reader.BaseStream.Length) {
				try {
					await collection.ParsePCapPacket(reader);

					if (i++ % 1000 == 0) {
						onProgress?.Invoke($"Parsing PCap Packets... {Math.Round(byteStream.Position / (double)byteStream.Length * 100)}%");
						await Task.Delay(1);
					}
				}
				catch (Exception ex) {
					Console.WriteLine(ex.ToString());
				}
			}

			onProgress?.Invoke($"Finished!");
			return collection;
		}

		private async Task ParsePCapPacket(BinaryReader reader) {
			var timestampSeconds = reader.ReadUInt32();
			var timestampMicroseconds = reader.ReadUInt32();
			var capturedLength = reader.ReadUInt32();
			var actualLength = reader.ReadUInt32();

			var pcapPacket = new PCapPacket(DateTime.UtcNow, reader, capturedLength);

			await AddPCapPacket(pcapPacket, reader, capturedLength);
		}

		public ACPacketCollection() {
			_messageHandler = new MessageReader();
		}

		public async Task AddPCapPacket(PCapPacket packet, BinaryReader reader, uint capturedLength) {
			var startOffset = reader.BaseStream.Position;
			ACMessage? msg = null;

			var x = reader.ReadBytes((int)capturedLength);
			reader.BaseStream.Position = startOffset;
			//Console.WriteLine($"Reading Packet: #{Packets.Count}");
			//WriteBytes(x);
			var acPacket = new ACPCapPacket(packet, new ACPacket(reader));
			acPacket.Id = Packets.Count;

			Console.WriteLine($"#{acPacket.Id} {acPacket.ACPacket.Header.Flags}");

			if (acPacket.ACPacket.Header.Flags.HasFlag(PacketHeaderFlags.Retransmission)) {
				// TODO...
				_ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + capturedLength));
			}
			else if (acPacket.ACPacket.Header.Flags.HasFlag(PacketHeaderFlags.RequestRetransmit)) {
				// TODO...
				_ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + capturedLength));
			}
			else if (acPacket.ACPacket.Header.Flags.HasFlag(PacketHeaderFlags.RejectRetransmit)) {
				// TODO...
				_ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + capturedLength));
			}
			else if (acPacket.ACPacket.Header.Flags.HasFlag(PacketHeaderFlags.BlobFragments)) {
				while (reader.BaseStream.Position < startOffset + acPacket.ACPacket.Header.Size) {
					try {
						var fragmentHeader = new ACFragmentHeader(reader);

						//Console.WriteLine($"FragmentHEadeR: {fragmentHeader.Id}:{fragmentHeader.Index} // {fragmentHeader.Count} | {fragmentHeader.Size}");
						ACFragment? frag = null;
						if (!PendingFragments.TryGetValue(fragmentHeader.Sequence, out frag)) {
							frag = new ACFragment(fragmentHeader.Sequence, fragmentHeader.Count);
							PendingFragments.Add(fragmentHeader.Sequence, frag);
						}

						int fragLength = fragmentHeader.Size - 16;
						var bytes = reader.ReadBytes(fragLength);
						//Console.WriteLine($"Chunk (len {bytes.Length}): {string.Join(" ", bytes.Select(c => $"{c:X2}"))}");

						frag.AddChunk(bytes, fragmentHeader.Index, fragLength);

						acPacket.ACPacket.Fragment = frag;

						if (frag.Count == frag.Received) {
							PendingFragments.Remove(fragmentHeader.Sequence);
							using var messageStream = new MemoryStream(frag.Data);
							using var messageReader = new BinaryReader(messageStream);
							if (packet.IsC2S) {
								msg = _messageHandler.ProcessC2SMessage(messageReader);
							}
							else {
								msg = _messageHandler.ProcessS2CMessage(messageReader);
							}

							if (msg != null) {
                                Console.WriteLine($"#{acPacket.Id} {acPacket.ACPacket.Header.Flags}: {msg}");
								acPacket.ACPacket.Messages.Add(msg);
							}
							else {
								//throw new Exception($"Message was null: {packet.IsC2S} {string.Join(" ", frag.Data.Select(c => $"{c:X2}"))}");
							}
						}
					}
					catch (Exception ex) {
						Console.WriteLine($"#{acPacket.Id} {acPacket.ACPacket.Header.Flags}: {ex}");
						throw ex;
					}
				}
			}

			Packets.Add(acPacket);
		}

		private void WriteBytes(byte[] x) {
			for (var i = 0; i < x.Length; i += 16) {
				Console.WriteLine("\t" + string.Join(" ", x.Skip(i).Take(16).Select(c => $"{c:X2}")));
			}
		}
	}
}
