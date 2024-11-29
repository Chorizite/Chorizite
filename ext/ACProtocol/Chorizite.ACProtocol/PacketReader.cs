using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Lib;
using Chorizite.ACProtocol.Messages;
using Chorizite.ACProtocol.Packets;
using Chorizite.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Chorizite.ACProtocol {
    public class PacketReader {
        protected readonly ILogger _log;
        protected Dictionary<uint, ACFragment> _pendingFragments = new Dictionary<uint, ACFragment>();

        public MessageReader Messages { get; }

        /// <summary>
        /// Called when a packet is sent from client to server
        /// </summary>
        public event EventHandler<PacketEventArgs>? OnC2SPacket {
            add { _OnC2SPacket.Subscribe(value); }
            remove { _OnC2SPacket.Unsubscribe(value); }
        }
        private readonly WeakEvent<PacketEventArgs> _OnC2SPacket = new();

        /// <summary>
        /// Called when a packet is sent from server to client
        /// </summary>
        public event EventHandler<PacketEventArgs>? OnS2CPacket {
            add { _OnS2CPacket.Subscribe(value); }
            remove { _OnS2CPacket.Unsubscribe(value); }
        }
        private readonly WeakEvent<PacketEventArgs> _OnS2CPacket = new();

        public PacketReader(ILogger log, MessageReader reader) {
            _log = log;
            Messages = reader;
        }

        public IEnumerable<ACPacket> HandleS2CPacket(byte[] data) {
            return HandlePacket(data, MessageDirection.ServerToClient);
        }

        public IEnumerable<ACPacket> HandleC2SPacket(byte[] data) {
            return HandlePacket(data, MessageDirection.ClientToServer);
        }

        private IEnumerable<ACPacket> HandlePacket(byte[] data, MessageDirection direction) {
            var packets = new List<ACPacket>();
            try {
                using var reader = new BinaryReader(new MemoryStream(data));
                while (reader.BaseStream.Position < reader.BaseStream.Length) {
                    var startOffset = reader.BaseStream.Position;
                    var acPacket = new ACPacket(reader);

                    if (acPacket.Header.Flags.HasFlag(PacketHeaderFlags.BlobFragments)) {
                        while (reader.BaseStream.Position < startOffset + ACPacketHeader.HEADER_SIZE + acPacket.Header.Size) {
                            var frag = ParseFragment(reader, direction, out var messages);
                            acPacket.Fragment = frag;
                            acPacket.Messages.AddRange(messages);
                        }
                    }

                    if (direction == MessageDirection.ClientToServer) {
                        _OnC2SPacket?.Invoke(this, new PacketEventArgs(acPacket, direction));
                    }
                    else if (direction == MessageDirection.ServerToClient) {
                        _OnS2CPacket?.Invoke(this, new PacketEventArgs(acPacket, direction));
                    }
                    packets.Add(acPacket);

                    if (reader.BaseStream.Position != startOffset + ACPacketHeader.HEADER_SIZE + acPacket.Header.Size) {
                        _log.LogWarning($"Skipped reading {startOffset + ACPacketHeader.HEADER_SIZE + acPacket.Header.Size - reader.BaseStream.Position} bytes? {FormatBytes(data)}");
                        reader.BaseStream.Position = startOffset + ACPacketHeader.HEADER_SIZE + acPacket.Header.Size;
                    }
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Failed to process packet: {FormatBytes(data)}");
            }

            return packets;
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
