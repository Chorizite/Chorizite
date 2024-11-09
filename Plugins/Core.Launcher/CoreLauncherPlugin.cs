using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Core.UI;
using Core.Launcher.Lib;
using System.Collections.Generic;
using Core.UI.Lib;
using Core.Launcher.UIModels;
using Core.UI.Lib.Serialization;
using System.Text.Json;
using Chorizite.Core.Backend;
using System.Runtime.CompilerServices;
using Chorizite.Core.Input;
using Chorizite.Common;

namespace Core.Launcher {
    public class CoreLauncherPlugin : IPluginCore, ScreenProvider<LauncherScreen> {
        private IPluginManager _pluginManager;
        private readonly CoreUIPlugin CoreUI;
        private readonly SimpleLoginScreenModel _simpleLoginScreenModel;
        private LauncherScreen _currentScreen = LauncherScreen.None;
        private readonly Dictionary<LauncherScreen, string> _registeredScreens = [];

        internal static CoreLauncherPlugin Instance { get; private set; }
        internal static ILogger? Log;
        internal readonly ILauncherBackend LauncherBackend;
        internal readonly IChoriziteBackend Backend;

        public LauncherScreen CurrentScreen {
            get => _currentScreen;
            set {
                // TODO: validate screen transitions
                if (_currentScreen != value) {
                    var oldScreen = _currentScreen;
                    _currentScreen = value;
                    CoreUI.Screen = _currentScreen.ToString();
                    _OnScreenChanged.Invoke(this, new ScreenChangedEventArgs(oldScreen, _currentScreen));
                }
            }
        }

        /// <summary>
        /// Screen changed
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }
        private readonly WeakEvent<ScreenChangedEventArgs> _OnScreenChanged = new();

        protected CoreLauncherPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger log, CoreUIPlugin coreUI, ILauncherBackend launcherBackend, IChoriziteBackend backend) : base(manifest) {
            Instance = this;
            Log = log;
            _pluginManager = pluginManager;
            LauncherBackend = launcherBackend;
            Backend = backend;
            CoreUI = coreUI;

            _simpleLoginScreenModel = SimpleLoginScreenModel.LoadFrom(DataDirectory, Log);

            CoreUI.RegisterUIModel("SimpleLoginScreen", _simpleLoginScreenModel);
            RegisterScreen(LauncherScreen.Simple, Path.Combine(AssemblyDirectory, "assets", "Simple.rml"));

            Log?.LogDebug($"Version: {Manifest.Version} dsddfdcfc");

            CurrentScreen = LauncherScreen.Simple;

            Backend.Renderer.OnRender2D += Renderer_OnRender2D;
        }

        private void Renderer_OnRender2D(object? sender, EventArgs e) {
            if (CoreUI.PanelManager.CurrentScreen is not null) {
                LauncherBackend.SetWindowSize(CoreUI.PanelManager.CurrentScreen.Width, CoreUI.PanelManager.CurrentScreen.Height);
            }
        }

        /// <inheritdoc/>
        public bool RegisterScreen(LauncherScreen screen, string rmlPath) {
            if (_registeredScreens.ContainsKey(screen)) {
                UnregisterScreen(screen, rmlPath);
            }
            _registeredScreens.Add(screen, rmlPath);

            return CoreUI.RegisterScreen(screen.ToString(), rmlPath); 
        }

        /// <inheritdoc/>
        public void UnregisterScreen(LauncherScreen screen, string rmlPath) {
            if (_registeredScreens.TryGetValue(screen, out var rmlFile)) {
                _registeredScreens.Remove(screen);
            }

            CoreUI.UnregisterScreen(screen.ToString(), rmlPath);
        }

        public override void Dispose() {
            Log?.LogDebug("Disposing CoreLauncherPlugin");
            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;

            CoreUI.UnregisterUIModel("SimpleLoginScreen", _simpleLoginScreenModel);
            
            foreach (var screen in _registeredScreens.Keys) {
                UnregisterScreen(screen, _registeredScreens[screen]);
            }

            CoreUI.Screen = "None";

            _simpleLoginScreenModel?.Save(DataDirectory, Log);
            _simpleLoginScreenModel?.Dispose();

            _registeredScreens.Clear(); 
            Instance = null;
        }
    }
}
