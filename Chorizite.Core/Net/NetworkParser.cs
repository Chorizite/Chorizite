using Chorizite.ACProtocol;
using Chorizite.Core.Backend.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Net {
    /// <summary>
    /// Network parser
    /// </summary>
    public class NetworkParser : PacketReader, IDisposable {
        private readonly IClientBackend _backend;

        /// <summary>
        /// Server -> Client message events
        /// </summary>
        public S2CMessageHandler S2C => Messages.S2C;

        /// <summary>
        /// Client -> Server message events
        /// </summary>
        public C2SMessageHandler C2S => Messages.C2S;

        public NetworkParser(ILogger<NetworkParser> logger) : base(logger, new MessageReader()) {
            
        }

        public NetworkParser(IClientBackend backend, ILogger<NetworkParser> logger) : base(logger, new MessageReader()) {
            _backend = backend;

            _backend.OnC2SData += Backend_OnC2SData;
            _backend.OnS2CData += Backend_OnS2CData;
        }

        private void Backend_OnS2CData(object? sender, PacketDataEventArgs e) {
            HandleS2CPacket(e.Data);
        }

        private void Backend_OnC2SData(object? sender, PacketDataEventArgs e) {
            HandleC2SPacket(e.Data);
        }

        internal void Init() {
            
        }

        public void Dispose() {
            _backend.OnC2SData -= Backend_OnC2SData;
            _backend.OnS2CData -= Backend_OnS2CData;
        }
    }
}
