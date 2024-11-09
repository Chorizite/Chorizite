using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Chorizite.ACProtocol;
using Chorizite.ACProtocol.Messages;
using Chorizite.Common;

namespace Chorizite.ACProtocol
{

    public class MessageReader {
        /// <summary>
        /// Fired for every valid parsed Message. This includes C2S and S2C
        /// </summary>
        public event EventHandler<MessageEventArgs>? OnMessage {
            add { _OnMessage.Subscribe(value); }
            remove { _OnMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<MessageEventArgs> _OnMessage = new();

        /// <summary>
        /// Fired when an unknown Message type was encountered. This includes C2S and S2C
        /// </summary>
        public event EventHandler<UnknownMessageEventArgs>? OnUnknownMessage {
            add { _OnUnknownMessage.Subscribe(value); }
            remove { _OnUnknownMessage.Unsubscribe(value); }
        }
        private readonly WeakEvent<UnknownMessageEventArgs> _OnUnknownMessage = new();

        /// <summary>
        /// Server to Client message events
		/// </summary>
        public S2CMessageHandler S2C { get; } = new S2CMessageHandler();

        /// <summary>
        /// Client to Server message events
        /// </summary>
        public C2SMessageHandler C2S { get; } = new C2SMessageHandler();

        public MessageReader() {
            S2C.OnMessage += S2C_OnMessage;
            S2C.OnUnknownMessage += S2C_OnUnknownMessage;

            C2S.OnMessage += C2S_OnMessage;
            C2S.OnUnknownMessage += C2S_OnUnknownMessage;
        }

        private void S2C_OnUnknownMessage(object sender, UnknownMessageEventArgs e) {
            _OnUnknownMessage?.Invoke(sender, e);
        }

        private void C2S_OnUnknownMessage(object sender, UnknownMessageEventArgs e) {
            _OnUnknownMessage?.Invoke(sender, e);
        }

        private void S2C_OnMessage(object sender, MessageEventArgs e) {
            _OnMessage?.Invoke(sender, e);
        }

        private void C2S_OnMessage(object sender, MessageEventArgs e) {
            _OnMessage?.Invoke(sender, e);
        }

        public ACMessage? ProcessS2CMessage(BinaryReader reader) {
            return S2C.ProcessS2CMessage(reader);
        }

        public ACMessage? ProcessC2SMessage(BinaryReader reader) {
            return C2S.ProcessC2SMessage(reader);
        }
    }
}
