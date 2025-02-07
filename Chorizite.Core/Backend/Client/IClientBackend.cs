using Autofac;
using Chorizite.ACProtocol;
using Chorizite.Core.Input;
using Chorizite.Core.Net;
using Chorizite.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chorizite.Common;
using System.IO;
using System.Numerics;

namespace Chorizite.Core.Backend.Client {
    /// <summary>
    /// Interface for the ac client
    /// </summary>
    public interface IClientBackend : IDisposable {
        int GameScreen { get; set; }
        uint SelectedObjectId { get; set; }

        public event EventHandler<PacketDataEventArgs> OnC2SData;
        public event EventHandler<PacketDataEventArgs> OnS2CData;
        public event EventHandler<ChatInputEventArgs> OnChatInput;
        public event EventHandler<ChatTextAddedEventArgs> OnChatTextAdded;
        public event EventHandler<ObjectSelectedEventArgs> OnObjectSelected;

        public IClientUIBackend UIBackend { get; }

        public bool EnterGame(uint characterId);
        public bool LogOff(bool immediate);

        public void Exit();
        public void AddChatText(string text, ChatType type = ChatType.Default);
        void InvokeChat(string text, int windowId = 1);
        void SendProtoUIMessage(byte[] message);
        void SendProtoUIMessage(PacketWriter stream);
    }
}
