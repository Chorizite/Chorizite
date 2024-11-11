using ACUI.Lib;
using ACUI.Lib.RmlUi;
using Autofac;
using Core.UI.Lib;
using Core.UI.Lib.RmlUi;
using Core.UI.Models;
using Chorizite.Core;
using Chorizite.Core.Backend;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using Chorizite.Common;
using System.Text.Json.Serialization.Metadata;

namespace Core.UI {
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    public class CoreUIPlugin : IPluginCore, ISerializeState<UIState> {
        private Dictionary<string, UIDataModel> _models = [];
        private readonly Dictionary<string, string> _gameScreenRmls = [];
        private Screen? _activePanel;
        private TestPlugin? _testPlugin;
        private RmlUIRenderInterface? _rmlRenderInterface;
        private ACSystemInterface? _rmlSystemInterface;
        private RmlInputManager? _rmlInput;
        private TestElementInstancer? _rmlElementInstancer;
        private bool _didInitRml;
        private bool _isDebugging;
        private UIState _state;

        internal static ILogger Log;
        internal readonly IChoriziteBackend Backend;

        internal readonly IPluginManager PluginManager;
        internal static Context? RmlContext;

        public PanelManager PanelManager { get; private set; }

        /// <summary>
        /// The current screen
        /// </summary>
        public string Screen {
            get => _state.Screen;
            set {
                SetScreen(value);
            }
        }

        public static CoreUIPlugin? Instance { get; internal set; }

        JsonTypeInfo<UIState> ISerializeState<UIState>.JsonStateTypeInfo => SourceGenerationContext.Default.UIState;

        /// <summary>
        /// Fired when the screen changes
        /// </summary>
        public event EventHandler<EventArgs> OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnScreenChanged = new WeakEvent<EventArgs>();

        protected CoreUIPlugin(AssemblyPluginManifest manifest, IChoriziteConfig config, IPluginManager pluginManager, IChoriziteBackend ChoriziteBackend, ILifetimeScope scope, ILogger log) : base(manifest) {
            Instance = this;
            Log = log;
            PluginManager = pluginManager;
            Backend = ChoriziteBackend;
            if (!Directory.Exists(DataDirectory)) {
                Directory.CreateDirectory(DataDirectory);
            }

            InitRmlUI();

            OnScreenChanged += CoreUIPlugin_OnScreenChanged;
            PluginManager.OnPluginUnloaded += PluginManager_OnPluginUnloaded;
        }

        private void PluginManager_OnPluginUnloaded(object? sender, PluginUnloadedEventArgs e) {
            foreach (var kv in _models) {
                if (kv.Value.GetType().Assembly.GetName().Name?.Contains(e.Name) == true) {
                    _models.Remove(kv.Key);
                }
            }
        }

        private void SetScreen(string value, bool force = false) {
            if (force || _state.Screen != value) {
                _state.Screen = value;
                _OnScreenChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        UIState ISerializeState<UIState>.SerializeBeforeUnload() => _state;

        void ISerializeState<UIState>.DeserializeAfterLoad(UIState? state) {
            _state = state ?? new UIState();

            SetScreen(_state.Screen, true);
        }

        #region Public API
        /// <summary>
        /// Register a named screen and its RML file
        /// </summary>
        /// <param name="name">The game screen</param>
        /// <param name="rmlFilePath">The absolute path to an RML file</param>
        /// <returns></returns>
        public bool RegisterScreen(string name, string rmlFilePath) {
            // TODO: allow multiple screens
            if (_gameScreenRmls.ContainsKey(name)) {
                _gameScreenRmls[name] = rmlFilePath;
            }
            else {
                _gameScreenRmls.Add(name, rmlFilePath);
            }
            return true;
        }

        /// <summary>
        /// Unregister a named screen and its RML file
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rmlFilePath"></param>
        public void UnregisterScreen(string name, string rmlFilePath) {
            if (_gameScreenRmls.TryGetValue(name, out var rmlFile) && rmlFile == rmlFilePath) {
                _gameScreenRmls.Remove(name);
            }
        }

        /// <summary>
        /// Register a UI model to the specified name
        /// </summary>
        /// <param name="name">The name to bind the model to</param>
        /// <param name="model">The model to bind</param>
        /// <returns></returns>
        public bool RegisterUIModel(string name, UIDataModel model) {
            if (_models.ContainsKey(name)) {
                _models[name].Dispose();
                _models.Remove(name);
            }
            _models.Add(name, model);
            model.Init(name);
            return true;
        }

        /// <summary>
        /// Unregister a UI model
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        public void UnregisterUIModel(string name, UIDataModel model) {
            _models.Remove(name);
        }

        #endregion

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
            Log?.LogDebug($"Initializing UI");

            try {
                // we need to manually load RmlUiNative.dll with an absolute path, or DllImport will
                // fail to find it later

                var rmlNativePath = Path.Combine(AssemblyDirectory, "runtimes", (IntPtr.Size == 8) ? "win-x64" : "win-x86", "native", "RmlUiNative.dll");
                Log?.LogDebug($"Manually pre-loading {rmlNativePath}");
                Native.LoadLibrary(rmlNativePath);

                //_testPlugin = new TestPlugin(_log);
                _rmlRenderInterface = new RmlUIRenderInterface(Backend.Renderer);
                _rmlSystemInterface = new ACSystemInterface(Log);

                Rml.SetSystemInterface(_rmlSystemInterface);
                Rml.SetRenderInterface(_rmlRenderInterface);

                var size = new Vector2i((int)Backend.Renderer.ViewportSize.X, (int)Backend.Renderer.ViewportSize.Y);
                Log?.LogDebug($"Window size: {size.X}x{size.Y}");

                if (Rml.Initialise()) {
                    //Rml.RegisterPlugin(_testPlugin);
                    //_rmlElementInstancer = new TestElementInstancer(_log);
                    RmlContext = Rml.CreateContext("viewport", size);

                    if (RmlContext is null) {
                        throw new Exception("Unable to create RmlUi context");
                    }

                    _rmlInput = new RmlInputManager(Backend.Input, RmlContext, Log);
                    PanelManager = new PanelManager(RmlContext, Backend.Renderer, Log);

                    var fontFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile)!, "assets"), "*.ttf");
                    foreach (var fontFile in fontFiles) {
                        Rml.LoadFontFace(fontFile);
                    }

                    Backend.Renderer.OnRender2D += Renderer_OnRender2D;
                    Backend.Renderer.OnGraphicsPreReset += PluginManager_OnGraphicsPreReset;
                    Backend.Renderer.OnGraphicsPostReset += PluginManager_OnGraphicsPostReset;

                    _didInitRml = true;
                }
                else {
                    throw new Exception("Unable to initialize RmlUi");
                }
            }
            catch (Exception ex) {
                Log?.LogError(ex, "Error during initialization");
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
                Log?.LogError(ex, "Error during render");
            }
        }

        private void ShutdownRmlUI() {
            Log?.LogDebug($"ShutdownRmlUI");

            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;
            Backend.Renderer.OnGraphicsPreReset -= PluginManager_OnGraphicsPreReset;
            Backend.Renderer.OnGraphicsPostReset -= PluginManager_OnGraphicsPostReset;

            _rmlInput?.Dispose();
            PanelManager?.Dispose();

            foreach (var model in _models.Values) {
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

        private void PluginManager_OnGraphicsPreReset(object? sender, EventArgs e) {
            ShutdownRmlUI();
        }

        private void PluginManager_OnGraphicsPostReset(object? sender, EventArgs e) {
            InitRmlUI();
        }

        private void CoreUIPlugin_OnScreenChanged(object? sender, EventArgs e) {
            PanelManager.UnloadScreen();
            if (_gameScreenRmls.TryGetValue(Screen, out var rmlFilePath)) {
                PanelManager.LoadScreenFile(Screen, rmlFilePath);
            }
        }

        /// <summary>
        /// Called when your plugin is unloaded. Either when logging out, closing the client, or hot reloading.
        /// </summary>
        public override void Dispose() {
            try {
                OnScreenChanged -= CoreUIPlugin_OnScreenChanged;

                PluginManager.OnPluginUnloaded -= PluginManager_OnPluginUnloaded;
                ShutdownRmlUI();
            }
            catch (Exception ex) {
                Log?.LogError(ex, "Error during shutdown");
            }
        }
    }
}
