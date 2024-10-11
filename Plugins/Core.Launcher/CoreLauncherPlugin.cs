using System.IO;
using System;
using Microsoft.Extensions.Logging;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using Core.UI;
using Core.Launcher.Lib;
using System.Collections.Generic;
using Core.UI.Lib;
using Core.Launcher.UIModels;
using Core.UI.Lib.Serialization;
using System.Text.Json;
using MagicHat.Core.Backend;

namespace Core.Launcher {
    public class CoreLauncherPlugin : IPluginCore, ScreenProvider<LauncherScreen> {
        private IPluginManager _pluginManager;
        private readonly CoreUIPlugin CoreUI;
        private readonly SimpleLoginScreenModel _simpleLoginScreenModel;
        private LauncherScreen _currentScreen = LauncherScreen.None;
        private readonly Dictionary<LauncherScreen, string> _registeredScreens = [];
        private readonly JsonSerializerOptions _serializerSettings;

        internal static CoreLauncherPlugin Instance { get; private set; }
        internal static ILogger<CoreLauncherPlugin>? Log;
        internal readonly ILauncherBackend LauncherBackend;
        internal readonly IMagicHatBackend Backend;

        public LauncherScreen CurrentScreen {
            get => _currentScreen;
            set {
                // TODO: validate screen transitions
                if (_currentScreen != value) {
                    var oldScreen = _currentScreen;
                    _currentScreen = value;
                    CoreUI.Screen = _currentScreen.ToString();
                    OnScreenChanged?.Invoke(this, new ScreenChangedEventArgs(oldScreen, _currentScreen));
                }
            }
        }

        /// <summary>
        /// Called when the game screen changes.
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        protected CoreLauncherPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger<CoreLauncherPlugin> log, CoreUIPlugin coreUI, ILauncherBackend launcherBackend, IMagicHatBackend backend) : base(manifest) {
            Instance = this;
            Log = log;
            _pluginManager = pluginManager;
            LauncherBackend = launcherBackend;
            Backend = backend;
            CoreUI = coreUI;

            _serializerSettings = new JsonSerializerOptions {
                WriteIndented = true,
                Converters = {
                    new UIDataModelJsonConverter()
                }
            };

            _simpleLoginScreenModel = SimpleLoginScreenModel.LoadFrom(DataDirectory, _serializerSettings, Log);

            CoreUI.RegisterUIModel("SimpleLoginScreen", _simpleLoginScreenModel);
            RegisterScreen(LauncherScreen.Simple, Path.Combine(AssemblyDirectory, "assets", "Simple.rml"));

            Log?.LogDebug($"Version: {Manifest.Version}");

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
                _registeredScreens[screen] = rmlPath;
            }
            else {
                _registeredScreens.Add(screen, rmlPath);
            }

            return CoreUI.RegisterScreen(screen.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public void UnregisterScreen(LauncherScreen screen, string rmlPath) {
            if (_registeredScreens.TryGetValue(screen, out var rmlFile) && rmlFile == rmlPath) {
                _registeredScreens.Remove(screen);
            }

            CoreUI.UnregisterScreen(screen.ToString(), rmlPath);
        }

        public override void Dispose() {
            Backend.Renderer.OnRender2D -= Renderer_OnRender2D;

            _simpleLoginScreenModel?.Save(DataDirectory, _serializerSettings, Log);
            _simpleLoginScreenModel?.Dispose();
        }
    }
}
