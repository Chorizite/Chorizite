using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Packets;
using System;

namespace Chorizite.ACProtocol {
    public class PacketEventArgs : EventArgs {
        public ACPacket Packet { get; }
        public MessageDirection Direction { get; }

        public PacketEventArgs(ACPacket packet, MessageDirection direction) {
            Packet = packet;
            Direction = direction;
        }
    }
}