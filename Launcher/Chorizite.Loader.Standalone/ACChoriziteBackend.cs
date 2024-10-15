using AcClient;
using Autofac;
using Iced.Intel;
using Chorizite.ACProtocol;
using Chorizite.ACProtocol.Enums;
using Chorizite.Core;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Extensions;
using Chorizite.Core.Input;
using Chorizite.Core.Net;
using Chorizite.Core.Render;
using Chorizite.Loader.Standalone.Input;
using Chorizite.Loader.Standalone.Render;
using Microsoft.Extensions.Logging;
using System;

namespace Chorizite.Loader.Standalone {
    public unsafe class ACChoriziteBackend : IClientBackend, IChoriziteBackend {
        private int _previousGameScreen = (int)UIMode.None;

        public IRenderInterface Renderer { get; }
        public DX9RenderInterface DX9Renderer { get; }

        public IInputManager Input { get; }
        public Win32InputManager Win32Input { get; }

        public int GameScreen {
            get => ((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null) ? 0 : (int)(*UIFlow.m_instance)->_curMode;
            set {
                if (!((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null)) {
                    if (value != _previousGameScreen) {
                        if ((int)(*UIFlow.m_instance)->_curMode != value) {
                            (*UIFlow.m_instance)->QueueUIMode((UIMode)value);
                        }
                        OnScreenChanged?.InvokeSafely(this, EventArgs.Empty);
                        _previousGameScreen = value;
                    }
                }
            }
        }

        public event EventHandler<PacketDataEventArgs>? OnC2SData;
        public event EventHandler<PacketDataEventArgs>? OnS2CData;
        public event EventHandler<EventArgs>? OnScreenChanged;

        public static IChoriziteBackend Create(IContainer container) {
            var renderer = new DX9RenderInterface(StandaloneLoader.UnmanagedD3DPtr, container.Resolve<ILogger<DX9RenderInterface>>(), container.Resolve<IDatReaderInterface>());
            var input = new Win32InputManager(container.Resolve<ILogger<Win32InputManager>>());

            return new ACChoriziteBackend(renderer, input);
        }

        private ACChoriziteBackend(DX9RenderInterface renderer, Win32InputManager input) {
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

        public bool EnterGame(uint characterId) {
            // Todo: check that it is a valid character id
            if ((*UIFlow.m_instance)->_curMode != UIMode.CharacterManagementUI) {
                return false;
            }
            return AcClient.CPlayerSystem.GetPlayerSystem()->LogOnCharacter(characterId) == 1;
        }

        private static delegate* unmanaged[Thiscall]<Client*, int> Cleanup = (delegate* unmanaged[Thiscall]<Client*, int>)0x00401EC0;
        private static delegate* unmanaged[Thiscall]<Client*, void> CleanupNet = (delegate* unmanaged[Thiscall]<Client*, void>)0x00412060;

        public void Exit() {
            CleanupNet(*Client.m_instance);
            Cleanup(*Client.m_instance);
        }

        public void Dispose() {
            Renderer?.Dispose();
            Input?.Dispose();
        }
    }
}
