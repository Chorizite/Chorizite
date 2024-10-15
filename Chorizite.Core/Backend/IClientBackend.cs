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

namespace Chorizite.Core.Backend {
    public interface IClientBackend : IDisposable {
        int GameScreen { get; set; }

        public event EventHandler<PacketDataEventArgs>? OnC2SData;
        public event EventHandler<PacketDataEventArgs>? OnS2CData;
        event EventHandler<EventArgs>? OnScreenChanged;

        bool EnterGame(uint characterId);
        void Exit();
    }
}
