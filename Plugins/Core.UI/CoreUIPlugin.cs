using ACUI.Lib;
using ACUI.Lib.RmlUi;
using Autofac;
using Core.DatService;
using Core.UI.Lib.RmlUi;
using Core.UI.Lib.Serialization;
using Core.UI.Models;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core.Backend;
using MagicHat.Core.Input;
using MagicHat.Core.Net;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Core.UI {
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    public class CoreUIPlugin : IPluginCore {
        private readonly ILogger<CoreUIPlugin> _log;
        private readonly Dictionary<GameScreen, UIDataModel> _models = [];
        private Panel? _activePanel;
        private TestPlugin? _testPlugin;
        private RmlUIRenderInterface? _rmlRenderInterface;
        private ACSystemInterface? _rmlSystemInterface;
        private RmlInputManager? _rmlInput;
        private TestElementInstancer? _rmlElementInstancer;
        private bool _didInitRml;

        internal static ILogger Log;
        internal readonly IMagicHatBackend Backend;
        internal readonly NetworkParser Net;
        internal readonly IPluginManager PluginManager;
        internal Context? RmlContext;
        private bool _isDebugging;

        internal bool IsHotReload { get; }

        public PanelManager PanelManager { get; private set; }

        /// <summary>
        /// Called when the game screen changes.
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        protected CoreUIPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, IMagicHatBackend backend, NetworkParser net, ILogger<CoreUIPlugin> log) : base(manifest) {
            Net = net;
            _log = log;
            Log = _log;
            PluginManager = pluginManager;
            Backend = backend;
            IsHotReload = Backend.GetScreen() != GameScreen.None;
            if (!Directory.Exists(DataDirectory)) {
                Directory.CreateDirectory(DataDirectory);
            }
            InitRmlUI();

            Backend.Input.OnKeyPress += Input_OnKeyPress;
        }

        private void Input_OnKeyPress(object? sender, KeyPressEventArgs e) {
            if (e.Key == Key.F7 || e.Key == Key.KEY_P) {
                ToggleDebugger();
            }
        }

        private void ToggleDebugger() {
            if (!_didInitRml || RmlContext is null) return;

            if (_isDebugging) {
                Debugger.SetVisible(false);
                Debugger.Shutdown();
                _isDebugging = false;
            }
            else {
                Debugger.Initialise(RmlContext);
                Debugger.SetVisible(true);
                _isDebugging = true;
            }
        }

        private void InitRmlUI() {
            if (_didInitRml) return;
            _log?.LogDebug($"Initializing UI"); 

            try {
                // we need to manually load RmlUiNative.dll with an absolute path, or DllImport will
                // fail to find it later
                _log?.LogDebug($"Manually pre-loading {Path.Combine(AssemblyDirectory, "RmlUiNative.dll")}");
                Native.LoadLibrary(Path.Combine(AssemblyDirectory, "RmlUiNative.dll"));

                //_testPlugin = new TestPlugin(_log);
                _rmlRenderInterface = new RmlUIRenderInterface(Backend.Renderer);
                _rmlSystemInterface = new ACSystemInterface(_log);

                Rml.SetSystemInterface(_rmlSystemInterface);
                Rml.SetRenderInterface(_rmlRenderInterface);

                var size = new Vector2i((int)Backend.Renderer.ViewportSize.X, (int)Backend.Renderer.ViewportSize.Y);
                _log?.LogDebug($"Window size: {size.X}x{size.Y}");

                if (Rml.Initialise()) {
                    //Rml.RegisterPlugin(_testPlugin);
                    //_rmlElementInstancer = new TestElementInstancer(_log);
                    RmlContext = Rml.CreateContext("viewport", size);

                    if (RmlContext is null) {
                        throw new Exception("Unable to create RmlUi context");
                    }

                    if (!IsHotReload) {
                        _models.Add(GameScreen.DatPatch, new DatPatchScreenModel("DatPatchScreen", this));
                        _models.Add(GameScreen.CharSelect, new CharSelectScreenModel("CharSelectScreen", this));
                    }
                    else if (File.Exists(Path.Combine(DataDirectory, "models.json"))) {
                        var serializeOptions = new JsonSerializerOptions {
                            WriteIndented = true,
                            Converters = {
                                    new UIDataModelJsonConverter(this)
                                }
                        };
                        try {
                            var models = JsonSerializer.Deserialize<Dictionary<GameScreen, UIDataModel>>(File.ReadAllText(Path.Combine(DataDirectory, "models.json")), serializeOptions);
                            foreach (var model in models) {
                                _models.Add(model.Key, model.Value);
                            }
                        }
                        catch (Exception ex) {
                            _log?.LogError(ex, "Error deserializing models.json"); 
                        }
                    }

                    _rmlInput = new RmlInputManager(Backend.Input, RmlContext, _log);
                    PanelManager = new PanelManager(RmlContext, Backend.Renderer, _log);

                    var fontFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile)!, "assets"), "*.ttf");
                    foreach (var fontFile in fontFiles) {
                        Rml.LoadFontFace(fontFile);
                    }

                    Backend.Renderer.OnRender2D += Renderer_OnRender2D;
                    Backend.Renderer.OnGraphicsPreReset += PluginManager_OnGraphicsPreReset;
                    Backend.Renderer.OnGraphicsPostReset += PluginManager_OnGraphicsPostReset;
                    Backend.Renderer.OnScreenChanged += PluginManager_OnScreenChanged;

                    _didInitRml = true;

                    PluginManager_OnScreenChanged(this, new ScreenChangedEventArgs(GameScreen.None, Backend.GetScreen()));
                }
                else {
                    throw new Exception("Unable to initialize RmlUi");
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during initialization");
            }
        }

        private void Renderer_OnRender2D(object? sender, EventArgs e) {
            try {
                PanelManager?.Update();
                if (!_didInitRml) return;
                RmlContext?.Update();
                RmlContext?.Render();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during render");
            }
        }

        private void ShutdownRmlUI() {
            _log?.LogDebug($"ShutdownRmlUI");
            var serializeOptions = new JsonSerializerOptions {
                WriteIndented = true,
                Converters = {
                    new UIDataModelJsonConverter(this)
                }
            };
            string jsonString = JsonSerializer.Serialize(_models, serializeOptions);
            File.WriteAllText(Path.Combine(DataDirectory, "models.json"), jsonString);

            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;
            Backend.Renderer.OnGraphicsPreReset -= PluginManager_OnGraphicsPreReset;
            Backend.Renderer.OnGraphicsPostReset -= PluginManager_OnGraphicsPostReset;
            Backend.Renderer.OnScreenChanged -= PluginManager_OnScreenChanged;

            _rmlInput?.Dispose();
            PanelManager?.Dispose();

            foreach (var model in _models.Values) {
                RmlContext?.RemoveDataModel(model.Name);
                model.Dispose();
            }
            _models.Clear();

            RmlContext?.Dispose();

            if (_didInitRml) {
                Rml.Shutdown();
            }

            _rmlRenderInterface?.Dispose();
            _rmlSystemInterface?.Dispose();
            _testPlugin?.Dispose();

            _didInitRml = false;
        }

        private void PluginManager_OnScreenChanged(object? sender, ScreenChangedEventArgs e) {
            if (_activePanel is not null) {
                PanelManager?.UnloadPanel(_activePanel);
            }
            var screenFile = Path.Combine(AssemblyDirectory, "assets", $"{e.NewScreen}.rml");
            if (File.Exists(screenFile)) {
                _log?.LogDebug($"Loading {screenFile}");
                _activePanel = PanelManager?.LoadPanelFile(screenFile);
            }
            OnScreenChanged?.Invoke(this, e);
        }

        private void PluginManager_OnGraphicsPreReset(object? sender, EventArgs e) {
            ShutdownRmlUI();
        }

        private void PluginManager_OnGraphicsPostReset(object? sender, EventArgs e) {
            InitRmlUI();
        }

        /// <summary>
        /// Called when your plugin is unloaded. Either when logging out, closing the client, or hot reloading.
        /// </summary>
        public override void Dispose() {
            try {
                _log?.LogDebug($"Shutting down");
                Backend.Input.OnKeyPress -= Input_OnKeyPress;
                ShutdownRmlUI();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during shutdown");
            }
        }
    }
}
