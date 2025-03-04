using Autofac;
using LauncherApp.Render;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using Chorizite.Common;
using DatReaderWriter.DBObjs;
using NAudio.Wave;
using Chorizite.Core.Backend.Launcher;
using Microsoft.Win32;
using System.Collections.Concurrent;
using Chorizite.Common.Enums;
using System.Runtime.InteropServices;
using Chorizite.Core;

namespace LauncherApp.Lib {
    internal class LauncherChoriziteBackend : IChoriziteBackend, ILauncherBackend {
        private readonly ILogger _log;
        private readonly IContainer _container;
        private Dictionary<int, AudioPlaybackEngine> _audioEngines = [];
        private ConcurrentQueue<Action> _invokeQueue = new();

        /// <inheritdoc/>
        public override IRenderInterface Renderer { get; }

        /// <summary>
        /// The <see cref="OpenGLRenderer"/> used by this backend
        /// </summary>
        public OpenGLRenderer GLRenderer { get; }

        /// <inheritdoc/>
        public override IInputManager Input { get; }

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
            var renderer = new OpenGLRenderer(container.Resolve<ILogger<OpenGLRenderer>>());
            var input = new SDLInputManager(container.Resolve<ILogger<SDLInputManager>>());

            return new LauncherChoriziteBackend(renderer, input, container);
        }

        private LauncherChoriziteBackend(OpenGLRenderer renderer, SDLInputManager input, IContainer container) {
            GLRenderer = renderer;
            Renderer = renderer;
            SDLInput = input;
            Input = input;
            _log = container.Resolve<ILogger<LauncherChoriziteBackend>>();
            _container = container;

            Renderer.OnRender2D += OnRender2D;
        }

        private void OnRender2D(object? sender, EventArgs e) {
            while (_invokeQueue.TryDequeue(out var action)) {
                try {
                    action.Invoke();
                }
                catch (Exception ex) {
                    Program.Log.LogError(ex, "Error in OnRender2D event handler");
                }
            }
        }

        public override void Invoke(Action action) {
            _invokeQueue.Enqueue(action);
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
                if (!_container.TryResolve<IDatReaderInterface>(out var reader)) {
                    _log.LogWarning($"No IDatReaderInterface could be found to play sound 0x{soundId:X8}.");
                    return;
                }
                if (reader?.TryGet<Wave>(soundId, out var sound) == true) {
                    var stream = new MemoryStream();
                    using var binaryWriter = new BinaryWriter(stream, System.Text.Encoding.Default, true);

                    binaryWriter.Write(System.Text.Encoding.ASCII.GetBytes("RIFF"));

                    uint filesize = (uint)(sound!.Data.Length + 36); // 36 is added for all the extra we're adding for the WAV header format
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
                else if (reader is null) {
                    _log.LogWarning($"No IDatReaderInterface found, could not play sound {soundId:X8}");
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
            //Native.ShowWindow(GLRenderer.HWND, 2);
        }

        public override void SetCursorDid(uint did, int hotX = 0, int hotY = 0, bool makeDefault = false) {
            
        }

        public void Dispose() {
            Renderer.OnRender2D -= OnRender2D;
        }

        public string GetDefaultClientPath() {
            var defaultPath = "C:\\Turbine\\Asheron's Call\\acclient.exe";
            
            try {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                    var sk1 = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\{F0EE55BA-193D-4670-90C0-76E0E25F3A08}");
                    if (sk1 == null) {
                        return defaultPath;
                    }
                    string acInstallPath = (string)sk1.GetValue("InstallLocation", "");
                    if (!string.IsNullOrWhiteSpace(acInstallPath)) {
                        var path = Path.Combine(acInstallPath, "acclient.exe");
                        if (File.Exists(path)) {
                            return path;
                        }
                    }
                }
            }
            catch (Exception ex) {
                _log.LogWarning(ex, "Failed to get default client path");
            }
            return defaultPath;
        }
    }
}