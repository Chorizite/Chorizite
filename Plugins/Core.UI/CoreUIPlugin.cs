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
using Core.UI.Lib.Fonts;
using Core.Lua;
using XLua;

namespace Core.UI {
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    public class CoreUIPlugin : IPluginCore, ISerializeState<UIState> {
        private Dictionary<string, UIDataModel> _models = [];
        private readonly Dictionary<string, string> _gameScreenRmls = [];
        private readonly Dictionary<string, Panel> _gamePanelRmls = [];
        private RmlUIRenderInterface? _rmlRenderInterface;
        private ACSystemInterface? _rmlSystemInterface;
        private ThemePlugin _themePlugin;
        private RmlInputManager? _rmlInput;
        private bool _didInitRml;
        private bool _isDebugging;
        private UIState _state;

        internal static ILogger Log;
        internal readonly IChoriziteBackend Backend;

        public FontManager FontManager { get; }
        public CoreLuaPlugin Lua { get; }

        internal readonly IPluginManager PluginManager;
        private ScriptableDocumentInstancer _scriptableDocumentInstancer;
        private ScriptableEventListenerInstancer _scriptableEventListenerInstancer;
        internal static Context? RmlContext;
        private bool _needsViewportUpdate;
        private int _clickSoundId;

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

        JsonTypeInfo<UIState> ISerializeState<UIState>.TypeInfo => SourceGenerationContext.Default.UIState;

        /// <summary>
        /// Fired when the screen changes
        /// </summary>
        public event EventHandler<EventArgs> OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnScreenChanged = new WeakEvent<EventArgs>();

        protected CoreUIPlugin(AssemblyPluginManifest manifest, IChoriziteConfig config, IPluginManager pluginManager, IChoriziteBackend ChoriziteBackend, ILifetimeScope scope, ILogger log, CoreLuaPlugin lua) : base(manifest) {
            Instance = this;
            Log = log;
            PluginManager = pluginManager;
            Backend = ChoriziteBackend;
            FontManager = new FontManager(Log);
            Lua = lua;

            var rmlUINativePath = Path.Combine(AssemblyDirectory, "runtimes", (IntPtr.Size == 8) ? "win-x64" : "win-x86", "native", "RmlUiNative.dll");
            Log?.LogTrace($"Manually pre-loading {rmlUINativePath}");
            Native.LoadLibrary(rmlUINativePath);

            InitRmlUI();

            OnScreenChanged += CoreUIPlugin_OnScreenChanged;
            PluginManager.OnPluginUnloaded += PluginManager_OnPluginUnloaded;

            Backend.Renderer.OnRender2D += Renderer_OnRender2D;
            Backend.Renderer.OnGraphicsPostReset += Renderer_OnGraphicsPostReset;
        }

        private void Renderer_OnGraphicsPostReset(object? sender, EventArgs e) {
            _needsViewportUpdate = true;
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
            if (!File.Exists(rmlFilePath)) {
                Log?.LogError($"Could not find RML file {rmlFilePath}");
                return false;
            }
                
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


        public bool RegisterPanel(string name, string rmlFilePath) {
            if (!File.Exists(rmlFilePath)) {
                Log?.LogError($"Could not find RML file {rmlFilePath}");
                return false;
            }

            UnregisterPanel(name, rmlFilePath);

            var panel = PanelManager.CreatePanel(name, rmlFilePath);

            // TODO: allow multiple panels
            if (_gamePanelRmls.ContainsKey(name)) {
                _gamePanelRmls[name] = panel;
            }
            else {
                _gamePanelRmls.Add(name, panel);
            }

            return true;
        }

        public void UnregisterPanel(string name, string rmlFilePath) {
            if (_gamePanelRmls.TryGetValue(name, out var panel) && panel?.File == rmlFilePath) {
                _gamePanelRmls.Remove(name);
            }

            PanelManager.DestroyPanel(name);
        }

        public bool IsPanelVisible(string name) {
            return true;
        }

        public void TogglePanelVisibility(string name, bool visible) {
            
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

            try {
                var x = Backend.Renderer.ViewportSize.X;
            }
            catch (Exception ex) {
                return;
            }

            try {
                // we need to manually load RmlUiNative.dll with an absolute path, or DllImport will
                // fail to find it later

                _rmlRenderInterface = new RmlUIRenderInterface(Backend.Renderer);
                _rmlSystemInterface = new ACSystemInterface(FontManager, Log);

                Rml.SetSystemInterface(_rmlSystemInterface);
                Rml.SetRenderInterface(_rmlRenderInterface);

                var size = new Vector2i((int)Backend.Renderer.ViewportSize.X, (int)Backend.Renderer.ViewportSize.Y);

                if (Rml.Initialise()) {
                    _clickSoundId = StyleSheetSpecification.RegisterProperty("click-sound", "none", false, false)
                        .AddParser("string", "none")
                        .GetId();

                    _scriptableDocumentInstancer = new ScriptableDocumentInstancer(Backend, Lua, Log);
                    //_scriptableEventListenerInstancer = new ScriptableEventListenerInstancer(_scriptableDocumentInstancer, Log);

                    RmlContext = Rml.CreateContext("viewport", size);

                    if (RmlContext is null) {
                        throw new Exception("Unable to create RmlUi context");
                    }

                    _rmlInput = new RmlInputManager(Backend.Input, RmlContext, Log);
                    PanelManager = new PanelManager(RmlContext, _rmlSystemInterface, Backend.Renderer, Log);
                    _themePlugin = new ThemePlugin(PanelManager, Backend, Log, _clickSoundId);
                    Rml.RegisterPlugin(_themePlugin);

                    LoadDefaultFonts();

                    var fontFiles = Directory.GetFiles(Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile)!, "assets"), "*.ttf");
                    foreach (var fontFile in fontFiles) {
                        Rml.LoadFontFace(fontFile);
                    }

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

        private void LoadDefaultFonts() {
            if (!FontManager.TryGetFont("Palatino Linotype", "regular", out var fontInfo)) {
                if (!FontManager.TryGetFont("Arial", "regular", out fontInfo)) {
                    Log.LogWarning("Could not find default fonts Palatino Linotype or Arial");
                }
            }

            if (fontInfo is not null) {
                Rml.LoadFontFace(fontInfo.Filename, true, FontWeight.Normal);
            }

            if (!FontManager.TryGetFont("Palatino Linotype", "bold", out var fontInfoBold)) {
                if (!FontManager.TryGetFont("Arial", "bold", out fontInfoBold)) {
                    Log.LogWarning("Could not find default fonts Palatino Linotype or Arial");
                }
            }

            if (fontInfoBold is not null) {
                Rml.LoadFontFace(fontInfoBold.Filename, false, FontWeight.Bold);
            }
        }

        private void Renderer_OnRender2D(object? sender, EventArgs e) {
            try {
                if (!_didInitRml) return;
                if (_needsViewportUpdate) {
                    RmlContext?.SetDimensions((int)Backend.Renderer.ViewportSize.X, (int)Backend.Renderer.ViewportSize.Y);
                    _needsViewportUpdate = false;
                }
                PanelManager?.Update();
                RmlContext?.Update();
                RmlContext?.Render();
            }
            catch (Exception ex) {
                Log?.LogError(ex, "Error during render");
            }
        }

        private void ShutdownRmlUI() {
            Log?.LogDebug($"ShutdownRmlUI");

            _rmlInput?.Dispose();

            foreach (var model in _models.Values) {
                model.Dispose();
            }
            _models.Clear();

            RmlContext?.Dispose();
            _themePlugin?.Dispose();

            if (_didInitRml) {
                Rml.Shutdown();
            }
            _scriptableDocumentInstancer?.Dispose();
            _scriptableEventListenerInstancer?.Dispose();
            _rmlRenderInterface?.Dispose();
            _rmlSystemInterface?.Dispose(); 

            _didInitRml = false;
        }

        private void CoreUIPlugin_OnScreenChanged(object? sender, EventArgs e) {
            PanelManager.DestroyScreen();
            if (_gameScreenRmls.TryGetValue(Screen, out var rmlFilePath)) {
                PanelManager.CreateScreen(Screen, rmlFilePath);
            }
        }

        /// <summary>
        /// Called when your plugin is unloaded. Either when logging out, closing the client, or hot reloading.
        /// </summary>
        protected override void Dispose() {
            try {
                Backend.Renderer.OnGraphicsPostReset -= Renderer_OnGraphicsPostReset;
                Backend.Renderer.OnRender2D -= Renderer_OnRender2D;
                OnScreenChanged -= CoreUIPlugin_OnScreenChanged;

                PanelManager.Dispose();
                PluginManager.OnPluginUnloaded -= PluginManager_OnPluginUnloaded;
                ShutdownRmlUI();
                PanelManager?.Dispose();
                FontManager?.Dispose();
            }
            catch (Exception ex) {
                Log?.LogError(ex, "Error during shutdown");
            }
        }
    }
}
