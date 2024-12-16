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

namespace Chorizite.Core.Backend {
    public interface IClientBackend : IDisposable {
        int GameScreen { get; set; }

        public event EventHandler<PacketDataEventArgs> OnC2SData;
        public event EventHandler<PacketDataEventArgs> OnS2CData;
        public event EventHandler<EventArgs> OnScreenChanged;
        public event EventHandler<ChatInputEventArgs> OnChatInput;
        public event EventHandler<ChatTextAddedEventArgs> OnChatTextAdded;
        public event EventHandler<GameObjectDragDropEventArgs>? OnGameObjectDragEnd;
        public event EventHandler<GameObjectDragDropEventArgs>? OnGameObjectDragStart;
        public event EventHandler<EventArgs>? OnHideTooltip;
        public event EventHandler<ShowTooltipEventArgs>? OnShowTooltip;

        public bool EnterGame(uint characterId);
        public void Exit();
        public void AddChatText(string text, ChatType type = ChatType.Default);
        void InvokeChat(string text, int windowId = 1);
        void ClearDragandDrop();
        void SendProtoUIMessage(byte[] message);
        void SendProtoUIMessage(PacketWriter stream);
    }
}
