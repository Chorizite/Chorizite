using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Lib;
using MagicHat.ACProtocol.Messages;
using MagicHat.ACProtocol.Packets;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace MagicHat.ACProtocol {
    public class PacketReader {
        protected readonly ILogger _log;
        protected Dictionary<uint, ACFragment> _pendingFragments = new Dictionary<uint, ACFragment>();

        public MessageReader Messages { get; }

        public EventHandler<PacketEventArgs>? OnC2SPacket;
        public EventHandler<PacketEventArgs>? OnS2CPacket;

        public PacketReader(ILogger log, MessageReader reader) {
            _log = log;
            Messages = reader;
        }

        public ACPacket? HandleS2CPacket(byte[] data) {
            return HandlePacket(data, MessageDirection.ServerToClient);
        }

        public ACPacket? HandleC2SPacket(byte[] data) {
            return HandlePacket(data, MessageDirection.ClientToServer);
        }

        private ACPacket? HandlePacket(byte[] data, MessageDirection direction) {
            try {
                using var reader = new BinaryReader(new MemoryStream(data));
                var startOffset = reader.BaseStream.Position;

                var acPacket = new ACPacket(reader);

                if (acPacket.Header.Flags.HasFlag(PacketHeaderFlags.Retransmission)) {
                    // TODO...
                    _ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + data.Length));
                }
                else if (acPacket.Header.Flags.HasFlag(PacketHeaderFlags.RequestRetransmit)) {
                    // TODO...
                    _ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + data.Length));
                }
                else if (acPacket.Header.Flags.HasFlag(PacketHeaderFlags.RejectRetransmit)) {
                    // TODO...
                    _ = reader.ReadBytes((int)(reader.BaseStream.Position - startOffset + data.Length));
                }
                else if (acPacket.Header.Flags.HasFlag(PacketHeaderFlags.BlobFragments)) {
                    while (reader.BaseStream.Position < startOffset + acPacket.Header.Size) {
                        var frag = ParseFragment(reader, direction, out var messages);
                        acPacket.Fragment = frag;
                        acPacket.Messages.AddRange(messages);
                    }
                }
                return acPacket;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Failed to process packet: {FormatBytes(data)}");
            }

            return null;
        }

        private ACFragment? ParseFragment(BinaryReader reader, MessageDirection direction, out List<ACMessage> messages) {
            messages = new List<ACMessage>();
            try {
                var fragmentHeader = new ACFragmentHeader(reader);

                ACFragment? frag = null;
                if (!_pendingFragments.TryGetValue(fragmentHeader.Sequence, out frag)) {
                    frag = new ACFragment(fragmentHeader.Sequence, fragmentHeader.Count);
                    _pendingFragments.Add(fragmentHeader.Sequence, frag);
                }

                int fragLength = fragmentHeader.Size - 16;
                var bytes = reader.ReadBytes(fragLength);

                frag.AddChunk(bytes, fragmentHeader.Index, fragLength);

                if (frag.Count == frag.Received) {
                    var count = 0;
                    ACMessage? msg = null;
                    using var messageStream = new MemoryStream(frag.Data);
                    using var messageReader = new BinaryReader(messageStream);
                    _pendingFragments.Remove(fragmentHeader.Sequence);

                    if (direction == MessageDirection.ClientToServer) {
                        msg = Messages.ProcessC2SMessage(messageReader);
                    }
                    else {
                        msg = Messages.ProcessS2CMessage(messageReader);
                    }

                    if (msg != null) {
                        messages.Add(msg);
                    }
                    else {
                        _log?.LogError($"Failed to process message: {FormatBytes(frag.Data.Skip((int)messageReader.BaseStream.Position).ToArray())}");
                    }
                }
                return frag;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Failed to process fragment");
            }
            return null;
        }

        private string FormatBytes(byte[] bytes) {
            return string.Join(" ", bytes.Select(b => $"{b:X2}"));
        }
    }
}
