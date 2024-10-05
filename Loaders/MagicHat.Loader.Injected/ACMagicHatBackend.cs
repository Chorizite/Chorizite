using AcClient;
using Autofac;
using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Enums;
using MagicHat.Backends.ACBackend.Input;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core;
using MagicHat.Core.Backend;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Net;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using System;

namespace MagicHat.Loader.Injected {
    public unsafe class ACMagicHatBackend : IMagicHatBackend {
        public IRenderInterface Renderer { get; }
        public DX9RenderInterface DX9Renderer { get; }

        public IInputManager Input { get; }
        public Win32InputManager Win32Input { get; }

        public event EventHandler<PacketDataEventArgs>? OnC2SData;
        public event EventHandler<PacketDataEventArgs>? OnS2CData;

        public static IMagicHatBackend Create(IContainer container) {
            var renderer = new DX9RenderInterface(InjectedLoader.UnmanagedD3DPtr, container.Resolve<ILogger<DX9RenderInterface>>(), container.Resolve<IDatReaderInterface>());
            var input = new Win32InputManager(container.Resolve<ILogger<Win32InputManager>>());

            return new ACMagicHatBackend(renderer, input);
        }

        private ACMagicHatBackend(DX9RenderInterface renderer, Win32InputManager input) {
            DX9Renderer = renderer;
            Renderer = renderer;
            Win32Input = input;
            Input = input;
        }

        internal void HandleC2SPacketData(byte[] bytes) {
            OnC2SData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ClientToServer, bytes));
        }

        internal void HandleS2CPacketData(byte[] bytes) {
            OnS2CData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ServerToClient, bytes));
        }

        public bool ShowScreen(GameScreen screen) {
            // Todo: check that we are able to switch to this next state...
            (*UIFlow.m_instance)->QueueUIMode((UIMode)screen);
            return true;
        }

        public GameScreen GetScreen() {
            try {
                return ((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null) ? GameScreen.None : (GameScreen)(*UIFlow.m_instance)->_curMode;
            }
            catch {
                return GameScreen.None;
            }
        }

        public bool EnterGame(uint characterId) {
            // Todo: check that it is a valid character id
            if ((*UIFlow.m_instance)->_curMode != UIMode.CharacterManagementUI) {
                return false;
            }
            return AcClient.CPlayerSystem.GetPlayerSystem()->LogOnCharacter(characterId) == 1;
        }

        private delegate* unmanaged[Thiscall]<gmClient*, int> Cleanup = (delegate* unmanaged[Thiscall]<gmClient*, int>)0x00401EC0;
        public static delegate* unmanaged[Thiscall]<Client*, void> CleanupNet = (delegate* unmanaged[Thiscall]<Client*, void>)0x00412060;

        public void Exit() {
            CleanupNet(*Client.m_instance);
            Cleanup((gmClient*)*Client.m_instance);
        }

        public void Dispose() {
            Renderer?.Dispose();
            Input?.Dispose();
        }
    }
}
