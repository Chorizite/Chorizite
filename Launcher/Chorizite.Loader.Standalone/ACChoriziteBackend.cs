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
using Chorizite.Common;
using Chorizite.Loader.Standalone.Hooks;
using ChatType = Chorizite.Core.Backend.ChatType;
using System.Text;
using System.Linq;
using SharpDX;
using DatReaderWriter.DBObjs;
using System.IO;
using System.Collections.Generic;
using SharpDX.Multimedia;
using NAudio.Wave;
using WaveFormat = NAudio.Wave.WaveFormat;
using NAudio.Wave.SampleProviders;
using Chorizite.Loader.Standalone.Lib;

namespace Chorizite.Loader.Standalone {
    public unsafe class ACChoriziteBackend : IChoriziteBackend, IClientBackend {
        private readonly AudioPlaybackEngine _engine;
        private Dictionary<int, AudioPlaybackEngine> _audioEngines = new();
        private int _previousGameScreen = (int)UIMode.None;

        public override IRenderInterface Renderer { get; }
        public DX9RenderInterface DX9Renderer { get; }

        public override IInputManager Input { get; }
        public ILogger Log { get; }
        public Win32InputManager Win32Input { get; }
        /// <inheritdoc/>
        public IDatReaderInterface DatReader { get; }

        public int GameScreen {
            get => ((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null) ? 0 : (int)(*UIFlow.m_instance)->_curMode;
            set {
                if (!((IntPtr)UIFlow.m_instance == IntPtr.Zero || *UIFlow.m_instance is null)) {
                    if (value != _previousGameScreen) {
                        if ((int)(*UIFlow.m_instance)->_curMode != value) {
                            (*UIFlow.m_instance)->QueueUIMode((UIMode)value);
                        }
                        _previousGameScreen = value;
                        _OnScreenChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }
        }

        public override event EventHandler<LogMessageEventArgs>? OnLogMessage {
            add { _OnLogMessage.Subscribe(value); }
            remove { _OnLogMessage.Unsubscribe(value); }
        }
        WeakEvent<LogMessageEventArgs> _OnLogMessage { get; } = new();

        /// <summary>
        /// Handle a log message.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public override void HandleLogMessage(LogMessageEventArgs evt) => _OnLogMessage.Invoke(this, evt);

        public override ChoriziteEnvironment Environment => ChoriziteEnvironment.Client;

        private readonly WeakEvent<PacketDataEventArgs> _OnC2SData = new WeakEvent<PacketDataEventArgs>();
        public event EventHandler<PacketDataEventArgs>? OnC2SData {
            add { _OnC2SData.Subscribe(value); }
            remove { _OnC2SData.Unsubscribe(value); }
        }

        private readonly WeakEvent<PacketDataEventArgs> _OnS2CData = new WeakEvent<PacketDataEventArgs>();
        public event EventHandler<PacketDataEventArgs>? OnS2CData {
            add { _OnS2CData.Subscribe(value); }
            remove { _OnS2CData.Unsubscribe(value); }
        }

        private readonly WeakEvent<ChatInputEventArgs> _OnChatInput = new();
        public event EventHandler<ChatInputEventArgs>? OnChatInput {
            add { _OnChatInput.Subscribe(value); }
            remove { _OnChatInput.Unsubscribe(value); }
        }

        private readonly WeakEvent<ChatTextAddedEventArgs> _OnChatTextAdded = new();
        public event EventHandler<ChatTextAddedEventArgs>? OnChatTextAdded {
            add { _OnChatTextAdded.Subscribe(value); }
            remove { _OnChatTextAdded.Unsubscribe(value); }
        }

        private readonly WeakEvent<EventArgs> _OnScreenChanged = new WeakEvent<EventArgs>();
        public event EventHandler<EventArgs>? OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }

        private readonly WeakEvent<GameObjectDragDropEventArgs> _OnGameObjectDragStart = new WeakEvent<GameObjectDragDropEventArgs>();
        public event EventHandler<GameObjectDragDropEventArgs>? OnGameObjectDragStart {
            add { _OnGameObjectDragStart.Subscribe(value); }
            remove { _OnGameObjectDragStart.Unsubscribe(value); }
        }

        private readonly WeakEvent<GameObjectDragDropEventArgs> _OnGameObjectDragEnd = new WeakEvent<GameObjectDragDropEventArgs>();
        public event EventHandler<GameObjectDragDropEventArgs>? OnGameObjectDragEnd {
            add { _OnGameObjectDragEnd.Subscribe(value); }
            remove { _OnGameObjectDragEnd.Unsubscribe(value); }
        }

        private readonly WeakEvent<ShowTooltipEventArgs> _OnShowTooltip = new WeakEvent<ShowTooltipEventArgs>();
        public event EventHandler<ShowTooltipEventArgs>? OnShowTooltip {
            add { _OnShowTooltip.Subscribe(value); }
            remove { _OnShowTooltip.Unsubscribe(value); }
        }

        private readonly WeakEvent<EventArgs> _OnHideTooltip = new WeakEvent<EventArgs>();
        public event EventHandler<EventArgs>? OnHideTooltip {
            add { _OnHideTooltip.Subscribe(value); }
            remove { _OnHideTooltip.Unsubscribe(value); }
        }

        public static IChoriziteBackend Create(IContainer container) {
            var renderer = new DX9RenderInterface(StandaloneLoader.UnmanagedD3DPtr, container.Resolve<ILogger<DX9RenderInterface>>(), container.Resolve<IDatReaderInterface>());
            var input = new Win32InputManager(container.Resolve<ILogger<Win32InputManager>>());

            return new ACChoriziteBackend(renderer, input, container.Resolve<ILogger<ACChoriziteBackend>>(), container.Resolve<IDatReaderInterface>());
        }

        private ACChoriziteBackend(DX9RenderInterface renderer, Win32InputManager input, ILogger log, IDatReaderInterface datReader) {
            DX9Renderer = renderer;
            Renderer = renderer;
            Win32Input = input;
            Input = input;
            Log = log;
            DatReader = datReader;
        }

        public bool EnterGame(uint characterId) {
            // Todo: check that it is a valid character id
            if ((*UIFlow.m_instance)->_curMode != UIMode.CharacterManagementUI) {
                return false;
            }
            return AcClient.CPlayerSystem.GetPlayerSystem()->LogOnCharacter(characterId) == 1;
        }

        public void AddChatText(string text, ChatType type = ChatType.Default) {
            ChatHooks.AddChatText(text, (eChatTypes)type);
        }

        public void ClearDragandDrop() {
            if (UIElementManager.s_pInstance is not null) {
                UIElementManager.s_pInstance->StopDragandDrop();
            }
        }

        public override void SetCursorDid(uint did, int hotX = 0, int hotY = 0, bool makeDefault = false) {
            UIHooks.CursorDid = did;
            UIElementManager.s_pInstance->SetCursor(did, hotX, hotY, (byte)(makeDefault ? 1 : 0));
        }

        public override void PlaySound(uint soundId) {
            try {
                if (DatReader.TryGet<Wave>(soundId, out var sound)) {
                    var stream = new MemoryStream();
                    using var binaryWriter = new BinaryWriter(stream, System.Text.Encoding.Default, true);

                    binaryWriter.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));

                    uint filesize = (uint)(sound.Data.Length + 36); // 36 is added for all the extra we're adding for the WAV header format
                    binaryWriter.Write(filesize);

                    binaryWriter.Write(System.Text.Encoding.ASCII.GetBytes("WAVE"));

                    binaryWriter.Write(System.Text.Encoding.ASCII.GetBytes("fmt"));
                    binaryWriter.Write((byte)0x20); // Null ending to the fmt

                    binaryWriter.Write((int)0x10); // 16 ... length of all the above

                    // AC audio headers start at Format Type,
                    // and are usually 18 bytes, with some exceptions
                    // notably objectID A000393 which is 30 bytes

                    // WAV headers are always 16 bytes from Format Type to end of header,
                    // so this extra data is truncated here.
                    binaryWriter.Write(sound.Header.Take(16).ToArray());

                    binaryWriter.Write(System.Text.Encoding.ASCII.GetBytes("data"));
                    binaryWriter.Write((uint)sound.Data.Length);
                    binaryWriter.Write(sound.Data);
                    binaryWriter.Flush();
                    binaryWriter.Close();
                    stream.Position = 0;

                    ReadBitRate(stream, out var numChannels, out var sampleRate, out var bitRate);

                    if (!_audioEngines.TryGetValue(sampleRate, out var _engine)) {
                        _engine = new AudioPlaybackEngine(sampleRate, numChannels);
                        _audioEngines.Add(sampleRate, _engine);
                    }

                    _engine.PlaySound(stream);
                }
                else {
                    Log.LogDebug($"Sound {soundId:X8} not found");
                }
            }
            catch (Exception ex) {
                Log.LogError(ex, $"Failed to play sound {soundId:X8}");
            }

        }

        private static bool ReadBitRate(Stream stream, out int numChannels, out int sampleRate, out int bitRate) {
            using (BinaryReader reader = new BinaryReader(stream, System.Text.Encoding.Default, true)) {
                // Skip RIFF header (4 bytes) and file size (4 bytes)
                reader.BaseStream.Position = 8;

                // Read WAVE format marker (4 bytes)
                string format = new string(reader.ReadChars(4));
                if (format != "WAVE") {
                    throw new InvalidDataException("Not a valid WAV file");
                }

                // Read "fmt " chunk marker (4 bytes)
                string fmtMarker = new string(reader.ReadChars(4));
                if (fmtMarker != "fmt ") {
                    throw new InvalidDataException("Cannot find fmt chunk");
                }

                // Read chunk size (4 bytes)
                int chunkSize = reader.ReadInt32();

                // Read audio format (2 bytes)
                short audioFormat = reader.ReadInt16();

                // Read number of channels (2 bytes)
                numChannels = reader.ReadInt16();

                // Read sample rate (4 bytes)
                sampleRate = reader.ReadInt32();

                // Read byte rate (4 bytes)
                int byteRate = reader.ReadInt32();

                // Calculate bit rate
                bitRate = byteRate * 8;

                stream.Position = 0;
                return true;
            }
        }

        private static delegate* unmanaged[Thiscall]<ClientCommunicationSystem*, PStringBase<ushort>*, int, int> ClientCommunicationSystem_OnChatCommand = (delegate* unmanaged[Thiscall]<ClientCommunicationSystem*, PStringBase<ushort>*, int, int>)0x005821A0;
        public void InvokeChat(string text, int windowId = 1) {
            if (ChatHooks.ClientCommunicationSystem == null) return;
            var pstring = (PStringBase<ushort>)text;
            ClientCommunicationSystem_OnChatCommand(ChatHooks.ClientCommunicationSystem, &pstring, windowId);
        }

        private static delegate* unmanaged[Thiscall]<Client*, int> Cleanup = (delegate* unmanaged[Thiscall]<Client*, int>)0x00401EC0;
        private static delegate* unmanaged[Thiscall]<Client*, void> CleanupNet = (delegate* unmanaged[Thiscall]<Client*, void>)0x00412060;

        public override void SetClipboardText(string text) {
            Native.SetClipboardText(text);
        }

        public override string? GetClipboardText() {
            return Native.GetClipboardText();
        }

        public void Exit() {
            CleanupNet(*Client.m_instance);
            Cleanup(*Client.m_instance);
        }

        #region internal event callers
        internal void HandleC2SPacketData(byte[] bytes) {
            _OnC2SData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ClientToServer, bytes));
        }

        internal void HandleS2CPacketData(byte[] bytes) {
            _OnS2CData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ServerToClient, bytes));
        }

        internal void HandleChatTextAdded(ChatTextAddedEventArgs eventArgs) {
            _OnChatTextAdded?.Invoke(this, eventArgs);
        }

        internal void HandleChatTextInput(ChatInputEventArgs eventArgs) {
            _OnChatInput?.Invoke(this, eventArgs);
        }

        internal void HandleGameObjectDragStart(GameObjectDragDropEventArgs eventArgs) {
            _OnGameObjectDragStart?.Invoke(this, eventArgs);
        }

        internal void HandleGameObjectDragEnd(GameObjectDragDropEventArgs eventArgs) {
            _OnGameObjectDragEnd?.Invoke(this, eventArgs);
        }

        internal void HandleShowTooltip(ShowTooltipEventArgs showTooltipEventArgs) {
            _OnShowTooltip?.Invoke(this, showTooltipEventArgs);
        }

        internal void HandleHideTooltip(EventArgs empty) {
            _OnHideTooltip?.Invoke(this, empty);
        }
        #endregion // internal event callers

        public void Dispose() {
            Renderer?.Dispose();
            Input?.Dispose();
        }
    }
}
