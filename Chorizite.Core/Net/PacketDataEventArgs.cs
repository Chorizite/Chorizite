using Chorizite.ACProtocol.Enums;

namespace Chorizite.Core.Net {
    /// <summary>
    /// Event args for packet data
    /// </summary>
    public class PacketDataEventArgs : System.EventArgs {
        /// <summary>
        /// Packet direction
        /// </summary>
        public MessageDirection Direction { get; }

        /// <summary>
        /// Packet data
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="data"></param>
        public PacketDataEventArgs(MessageDirection direction, byte[] data) {
            Direction = direction;
            Data = data;
        }
    }
}