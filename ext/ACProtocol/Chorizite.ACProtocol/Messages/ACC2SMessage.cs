using System;
using System.Collections.Generic;
using System.Text;
using Chorizite.ACProtocol.Enums;

namespace Chorizite.ACProtocol.Messages {
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
