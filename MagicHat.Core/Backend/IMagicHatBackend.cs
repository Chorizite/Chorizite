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
    public interface IMagicHatBackend : IDisposable {
        /// <summary>
        /// Get the <see cref="IRenderInterface"/> being used for this backend.
        /// </summary>
        public IRenderInterface Renderer { get; }

        /// <summary>
        /// Get the <see cref="IInputManager"/> being used for this backend.
        /// </summary>
        public IInputManager Input { get; }

        public event EventHandler<PacketDataEventArgs>? OnC2SData;
        public event EventHandler<PacketDataEventArgs>? OnS2CData;

        public virtual static IMagicHatBackend Create(IContainer container) => throw new NotImplementedException("You must implement IMagicHatBackend.Create static method.");
        void Exit();
        bool EnterGame(uint characterId);
        bool ShowScreen(GameScreen screen);
    }
}
