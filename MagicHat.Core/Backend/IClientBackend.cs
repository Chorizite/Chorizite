using Autofac;
using MagicHat.ACProtocol;
using MagicHat.Core.Input;
using MagicHat.Core.Net;
using MagicHat.Core.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Backend {
    public interface IClientBackend : IDisposable {
        int GameScreen { get; set; }

        public event EventHandler<PacketDataEventArgs>? OnC2SData;
        public event EventHandler<PacketDataEventArgs>? OnS2CData;
        event EventHandler<EventArgs>? OnScreenChanged;

        bool EnterGame(uint characterId);
        void Exit();
    }
}
