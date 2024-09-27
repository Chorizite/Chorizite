using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Packets;
using System;

namespace MagicHat.ACProtocol {
    public class PacketEventArgs : EventArgs {
        public ACPacket Packet { get; }
        public MessageDirection Direction { get; }

        public PacketEventArgs(ACPacket packet, MessageDirection direction) {
            Packet = packet;
            Direction = direction;
        }
    }
}