using AcClient;
using ACUI.Lib;
using ACUI.Lib.Input;
using ACUI.Lib.RmlUi;
using Autofac;
using Core.DatService;
using Core.UI.Lib.RmlUi;
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

namespace Core.UI {
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    public class CoreUIPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        private readonly ILogger<CoreUIPlugin> _log;
        private readonly NetworkParser _net;
        private readonly Dictionary<GameScreen, UIDataModel> _models = [];
        private Panel? _activePanel;
        private TestPlugin? _testPlugin;
        private RmlUIRenderInterface? _rmlRenderInterface;
        private ACSystemInterface? _rmlSystemInterface;
        private RmlInputManager? _rmlInput;
        private TestElementInstancer? _rmlElementInstancer;
        private Context? _ctx;
        private bool _didInitRml;

        public static ILogger Log;
        internal readonly IMagicHatBackend Backend;

        public PanelManager PanelManager { get; private set; }

        /// <summary>
        /// Called when the game screen changes.
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        protected CoreUIPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, IMagicHatBackend backend, NetworkParser net, ILogger<CoreUIPlugin> log) : base(manifest) {
            _net = net;
            _log = log;
            Log = _log;
            _pluginManager = pluginManager;
            Backend = backend;
            InitRmlUI();
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
                    _ctx = Rml.CreateContext("viewport", size);
                     
                    if (_ctx is null) {
                        throw new Exception("Unable to create RmlUi context"); 
                    }

                    _models.Add(GameScreen.DatPatch, new DatPatchScreenModel("DatPatchScreen", _ctx, _net, this));
                    _models.Add(GameScreen.CharSelect, new CharSelectScreenModel("CharSelectScreen", _ctx, _net, this));

                    _rmlInput = new RmlInputManager(Backend.Input, _ctx, _log);
                    PanelManager = new PanelManager(_ctx, Backend.Renderer, _log);

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
                _ctx?.Update();
                _ctx?.Render();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during render");
            }
        }

        private void ShutdownRmlUI() {
            _log?.LogDebug($"ShutdownRmlUI");

            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;
            Backend.Renderer.OnGraphicsPreReset -= PluginManager_OnGraphicsPreReset;
            Backend.Renderer.OnGraphicsPostReset -= PluginManager_OnGraphicsPostReset;
            Backend.Renderer.OnScreenChanged -= PluginManager_OnScreenChanged;

            _rmlInput?.Dispose();
            PanelManager?.Dispose();

            foreach (var model in _models.Values) {
                _ctx?.RemoveDataModel(model.Name);
                model.Dispose();
            }
            _models.Clear();

            _ctx?.Dispose(); 

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
        protected override void Dispose() {
            try {
                _log?.LogDebug($"Shutting down"); 
                ShutdownRmlUI();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during shutdown");
            }
        }
    }
}
