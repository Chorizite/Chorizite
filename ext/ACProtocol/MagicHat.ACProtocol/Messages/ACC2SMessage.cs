using System;
using System.Collections.Generic;
using System.Text;
using MagicHat.ACProtocol.Enums;

namespace MagicHat.ACProtocol.Messages {
    /// <summary>
    /// Client to server message
    /// </summary>
    public abstract class ACC2SMessage : ACMessage {
        /// <inheritdoc/>
        public override MessageDirection MessageDirection => MessageDirection.ClientToServer;

        /// <summary>
        /// The type of message
        /// </summary>
        public abstract C2SMessageType MessageType { get; }
    }
}
