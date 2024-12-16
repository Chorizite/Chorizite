using Autofac;
using Launcher.Render;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using Chorizite.Common;
using DatReaderWriter.DBObjs;
using NAudio.Wave;
using Chorizite.Core;

namespace Launcher.Lib {
    internal class LauncherChoriziteBackend : IChoriziteBackend, ILauncherBackend {
        private readonly ILogger _log;
        private readonly AudioPlaybackEngine _engine;
        private Dictionary<int, AudioPlaybackEngine> _audioEngines = new();

        /// <inheritdoc/>
        public override IRenderInterface Renderer { get; }

        /// <summary>
        /// The <see cref="OpenGLRenderer"/> used by this backend
        /// </summary>
        public OpenGLRenderer GLRenderer { get; }

        /// <inheritdoc/>
        public override IInputManager Input { get; }
        /// <inheritdoc/>
        public IDatReaderInterface DatReader { get; }

        /// <summary>
        /// The <see cref="SDLInputManager"/> used by this backend
        /// </summary>
        public SDLInputManager SDLInput { get; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override ChoriziteEnvironment Environment => ChoriziteEnvironment.Launcher;

        public static IChoriziteBackend Create(IContainer container) {
            var renderer = new OpenGLRenderer(container.Resolve<ILogger<OpenGLRenderer>>(), container.Resolve<IDatReaderInterface>());
            var input = new SDLInputManager(container.Resolve<ILogger<SDLInputManager>>());

            return new LauncherChoriziteBackend(renderer, input, container.Resolve<IDatReaderInterface>(), container.Resolve<ILogger<LauncherChoriziteBackend>>());
        }

        private LauncherChoriziteBackend(OpenGLRenderer renderer, SDLInputManager input, IDatReaderInterface datReader, ILogger log) {
            GLRenderer = renderer;
            Renderer = renderer;
            SDLInput = input;
            Input = input;
            DatReader = datReader;
            _log = log;
        }

        public void SetWindowSize(int width, int height) {
            GLRenderer.Resize(width, height);
        }

        public void LaunchClient(string clientPath, string server, string username, string password) {
            Program.LaunchManager.Launch(clientPath, server, username, password);
        }

        public void Exit() {
            Program.Exit();
        }
        public override void SetClipboardText(string text) {
            Native.SetClipboardText(text);
        }

        public override string? GetClipboardText() {
            return Native.GetClipboardText();
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
                    _log.LogDebug($"Sound {soundId:X8} not found");
                }
            }
            catch (Exception ex) {
                _log.LogError(ex, $"Failed to play sound {soundId:X8}");
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

        public void Minimize() {
            Native.ShowWindow(GLRenderer.HWND, 2);
        }

        public override void SetCursorDid(uint did, int hotX = 0, int hotY = 0, bool makeDefault = false) {
            
        }

        public void Dispose() {
            
        }
    }
}