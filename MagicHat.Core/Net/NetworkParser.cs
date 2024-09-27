using MagicHat.ACProtocol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Net {
    public class NetworkParser : PacketReader {
        public NetworkParser(ILogger<NetworkParser> logger) : base(logger, new MessageReader()) {
            
        }

        internal void Init() {
            _log?.LogDebug("NetworkParser: Init 123");
        }
    }
}
