using MagicHat.ACProtocol.Enums;

namespace MagicHat.Core.Net {
    public class PacketDataEventArgs : System.EventArgs {
        public MessageDirection Direction { get; }
        public byte[] Data { get; }

        public PacketDataEventArgs(MessageDirection direction, byte[] data) {
            Direction = direction;
            Data = data;
        }
    }
}