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
using ChatType = Chorizite.Core.Backend.Client.ChatType;
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
using Chorizite.Core.Backend.Client;
using System.Runtime.InteropServices;

namespace Chorizite.Loader.Standalone {
    public unsafe class ACChoriziteBackend : IChoriziteBackend, IClientBackend {
        private readonly AudioPlaybackEngine _engine;
        private Dictionary<int, AudioPlaybackEngine> _audioEngines = new();

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
                    if ((int)(*UIFlow.m_instance)->_curMode != value) {
                        (*UIFlow.m_instance)->QueueUIMode((UIMode)value);
                    }
                }
                else {
                    StandaloneLoader.Log.LogError("UIFlow.m_instance is null");
                }
            }
        }

        public uint SelectedObjectId {
            get {
                if (GameScreen != (int)UIMode.GamePlayUI) {
                    return 0;
                }
                return SmartBox.smartbox[0]->target_object_id;
            }
            set {
                if (GameScreen != (int)UIMode.GamePlayUI) {
                    return;
                }
                ACCWeenieObject.SetSelectedObject(value, 1);
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

        public IClientUIBackend UIBackend => ACUIBackend;
        internal ACClientUIBackend ACUIBackend { get; } = new ACClientUIBackend();

        private readonly WeakEvent<PacketDataEventArgs> _OnC2SData = new WeakEvent<PacketDataEventArgs>();
        public event EventHandler<PacketDataEventArgs> OnC2SData {
            add { _OnC2SData.Subscribe(value); }
            remove { _OnC2SData.Unsubscribe(value); }
        }

        private readonly WeakEvent<PacketDataEventArgs> _OnS2CData = new WeakEvent<PacketDataEventArgs>();
        public event EventHandler<PacketDataEventArgs> OnS2CData {
            add { _OnS2CData.Subscribe(value); }
            remove { _OnS2CData.Unsubscribe(value); }
        }

        private readonly WeakEvent<ChatInputEventArgs> _OnChatInput = new();
        public event EventHandler<ChatInputEventArgs> OnChatInput {
            add { _OnChatInput.Subscribe(value); }
            remove { _OnChatInput.Unsubscribe(value); }
        }

        internal readonly WeakEvent<ChatTextAddedEventArgs> _OnChatTextAdded = new();
        public event EventHandler<ChatTextAddedEventArgs> OnChatTextAdded {
            add { _OnChatTextAdded.Subscribe(value); }
            remove { _OnChatTextAdded.Unsubscribe(value); }
        }

        private readonly WeakEvent<ObjectSelectedEventArgs> _OnObjectSelected = new();
        public event EventHandler<ObjectSelectedEventArgs> OnObjectSelected {
            add { _OnObjectSelected.Subscribe(value); }
            remove { _OnObjectSelected.Unsubscribe(value); }
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

        public bool LogOff(bool immediate = false) {
            if ((*UIFlow.m_instance)->_curMode != UIMode.GamePlayUI) {
                return false;
            }

            byte immediateByte = (byte)(immediate ? 1 : 0); 
            AcClient.CPlayerSystem.GetPlayerSystem()->LogOffCharacter(immediateByte);
            return true;
        }

        public void AddChatText(string text, ChatType type = ChatType.Default) {
            ChatHooks.AddChatText(text, (eChatTypes)type);
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

        private static delegate* unmanaged[Thiscall]<Client*, int> Cleanup = (delegate* unmanaged[Thiscall]<Client*, int>)0x004010F0;
        private static delegate* unmanaged[Thiscall]<Client*, void> CleanupNet = (delegate* unmanaged[Thiscall]<Client*, void>)0x00412060;

        public override void SetClipboardText(string text) {
            Native.SetClipboardText(text);
        }

        public override string? GetClipboardText() {
            return Native.GetClipboardText();
        }

        public void SendProtoUIMessage(byte[] message) {
            if (message is null || message.Length == 0) return;
            try {
                var bytePtr = (byte*)NativeMemory.AlignedAlloc((uint)message.Length, 4);
                Marshal.Copy(message, 0, (IntPtr)bytePtr, message.Length);
                // a NetBlob is created from bytePtr and will free it
                Proto_UI.SendToControl(bytePtr, message.Length);
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to send ProtoUI message");
            }
        }

        public void SendProtoUIMessage(PacketWriter stream) {
            if (stream is null) return;

            SendProtoUIMessage(stream.ToArray());
        }

        public void Exit() {
            if (UIFlow.m_instance[0] is not null) {
                UIFlow.m_instance[0]->QueueUIMode(UIMode.EpilogueUI);
            }
        }

        #region internal event callers
        internal void HandleC2SPacketData(byte[] bytes) {
            try {
                _OnC2SData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ClientToServer, bytes));
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to handle C2S packet data");
            }
        }

        internal void HandleS2CPacketData(byte[] bytes) {
            try {
                _OnS2CData?.Invoke(this, new PacketDataEventArgs(MessageDirection.ServerToClient, bytes));
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to handle S2C packet data");
            }
        }

        internal void HandleChatTextAdded(ChatTextAddedEventArgs eventArgs) {
            try {
                _OnChatTextAdded?.Invoke(this, eventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnChatTextAdded event handler");
            }
        }

        internal void HandleChatTextInput(ChatInputEventArgs eventArgs) {
            try {
                _OnChatInput?.Invoke(this, eventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnChatInput event handler");
            }
        }

        internal void HandleObjectSelected(ObjectSelectedEventArgs eventArgs) {
            try {
                _OnObjectSelected?.Invoke(this, eventArgs);
            }
            catch (Exception ex) {
                StandaloneLoader.Log.LogError(ex, "Error in OnObjectSelected event handler");
            }
        }
        #endregion // internal event callers

        public void Dispose() {
            Renderer?.Dispose();
            Input?.Dispose();
        }
    }
}
