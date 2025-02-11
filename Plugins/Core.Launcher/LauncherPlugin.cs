using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using RmlUi;
using Launcher.Lib;
using System.Collections.Generic;
using RmlUi.Lib;
using Chorizite.Core.Backend;
using Chorizite.Common;
using System.Text.Json.Serialization.Metadata;
using Chorizite.Core.Backend.Launcher;

namespace Launcher {
    public class LauncherPlugin : IPluginCore, IScreenProvider<LauncherScreen>, ISerializeState<LauncherState>, ISerializeSettings<LauncherSettings> {
        private IPluginManager _pluginManager;
        private readonly RmlUiPlugin RmlUi;
        private readonly Dictionary<LauncherScreen, string> _registeredScreens = [];
        private LauncherSettings _settings;
        private LauncherState _state;

        internal static LauncherPlugin? Instance { get; private set; }
        internal static ILogger? Log;
        private Panel? _panel;
        internal readonly ILauncherBackend LauncherBackend;
        internal readonly IChoriziteBackend Backend;

        JsonTypeInfo<LauncherState> ISerializeState<LauncherState>.TypeInfo => SourceGenerationContext.Default.LauncherState;
        JsonTypeInfo<LauncherSettings> ISerializeSettings<LauncherSettings>.TypeInfo => SourceGenerationContext.Default.LauncherSettings;

        public LauncherScreen CurrentScreen {
            get => _state.CurrentScreen;
            set => SetScreen(value);
        }
        public Screen? Screen { get; private set; }

        /// <summary>
        /// Screen changed
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }
        private readonly WeakEvent<ScreenChangedEventArgs> _OnScreenChanged = new();

        protected LauncherPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger log, RmlUiPlugin rmlui, ILauncherBackend launcherBackend, IChoriziteBackend backend) : base(manifest) {
            Instance = this;
            Log = log;
            _pluginManager = pluginManager;
            LauncherBackend = launcherBackend;
            Backend = backend;
            RmlUi = rmlui;

            Backend.Renderer.OnRender2D += Renderer_OnRender2D;
        }

        protected override void Initialize() {
            RegisterScreen(LauncherScreen.Simple, Path.Combine(AssemblyDirectory, "assets", "screens", "Simple.rml"));

            _panel = RmlUi.CreatePanel("PluginsBar", Path.Combine(AssemblyDirectory, "assets", "panels", "pluginsbar.rml"));
            _panel?.Show();

            SetScreen(_state.CurrentScreen, true);
        }

        void ISerializeSettings<LauncherSettings>.DeserializeAfterLoad(LauncherSettings? settings) {
            _settings = settings ?? new LauncherSettings();
        }

        LauncherSettings ISerializeSettings<LauncherSettings>.SerializeBeforeUnload() => _settings;

        void ISerializeState<LauncherState>.DeserializeAfterLoad(LauncherState? state) {
            _state = state ?? new LauncherState(LauncherScreen.Simple);
        }
        LauncherState ISerializeState<LauncherState>.SerializeBeforeUnload() => _state;

        private void SetScreen(LauncherScreen value, bool force = false) {
            if (!force && _state.CurrentScreen == value) {
                return;
            }

            var oldScreen = _state.CurrentScreen;
            _state.CurrentScreen = value;
            RmlUi.Screen = _state.CurrentScreen.ToString();
            Screen = RmlUi.PanelManager.GetScreen();
            _OnScreenChanged.Invoke(this, new ScreenChangedEventArgs(oldScreen, _state.CurrentScreen));
            Log.LogDebug($"Screen changed from {oldScreen} to {_state.CurrentScreen}");
        }

        private void Renderer_OnRender2D(object? sender, EventArgs e) {
            if (RmlUi.PanelManager.CurrentScreen is not null) {
                LauncherBackend.SetWindowSize(RmlUi.PanelManager.CurrentScreen.Width, RmlUi.PanelManager.CurrentScreen.Height);
            }
        }

        /// <inheritdoc/>
        public bool RegisterScreen(LauncherScreen screen, string rmlPath) {
            if (_registeredScreens.ContainsKey(screen)) {
                UnregisterScreen(screen, rmlPath);
            }
            _registeredScreens.Add(screen, rmlPath);

            return RmlUi.RegisterScreen(screen.ToString(), rmlPath); 
        }
        
        /// <inheritdoc/>
        public void UnregisterScreen(LauncherScreen screen, string rmlPath) { 
            if (_registeredScreens.TryGetValue(screen, out var rmlFile)) {  
                _registeredScreens.Remove(screen);
            }

            RmlUi.UnregisterScreen(screen.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public LauncherScreen CustomScreenFromName(string name) => LauncherScreenHelpers.FromString(name);

        protected override void Dispose() {
            Log.LogInformation("CoreLauncherPlugin dispose");
            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;

            RmlUi.Screen = "None";

            foreach (var screen in _registeredScreens.Keys) {
                UnregisterScreen(screen, _registeredScreens[screen]); 
            }
            _registeredScreens.Clear();

            Instance = null;
        }
    }
}
