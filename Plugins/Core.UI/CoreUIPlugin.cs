using ACUI.Lib;
using ACUI.Lib.RmlUi;
using Autofac;
using Core.DatService;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core.Input;
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

namespace ACUI {
    /// <summary>
    /// This is the main plugin class. When your plugin is loaded, Startup() is called, and when it's unloaded Shutdown() is called.
    /// </summary>
    public class CoreUIPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        private readonly IRenderInterface _renderer;
        private readonly IInputManager _input;
        private readonly ILogger<CoreUIPlugin>? _log;
        private Panel? _activePanel;

        [DllImport("Kernel32.dll")]
        private static extern IntPtr LoadLibrary(string path);

        public UI UI { get; private set; }

        /// <summary>
        /// Called when the game screen changes.
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs>? OnScreenChanged;

        protected CoreUIPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, IRenderInterface renderer, IInputManager input, ILogger<CoreUIPlugin>? log) : base(manifest) {
            _log = log;
            _pluginManager = pluginManager;
            _renderer = renderer;
            _input = input;
            UI = new UI(manifest);
            try {
                // we need to manually load RmlUiNative.dll with an absolute path, or DllImport will
                // fail to find it later
                _log?.LogDebug($"Manually pre-loading {Path.Combine(AssemblyDirectory, "RmlUiNative.dll")}");
                LoadLibrary(Path.Combine(AssemblyDirectory, "RmlUiNative.dll"));

                UI.Init(_pluginManager, _renderer, _input, _log);

                _renderer.OnGraphicsPreReset += PluginManager_OnGraphicsPreReset;
                _renderer.OnGraphicsPostReset += PluginManager_OnGraphicsPostReset;
                _renderer.OnScreenChanged += PluginManager_OnScreenChanged;
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during initialization ");
            }
        }

        public CoreUIPlugin(AssemblyPluginManifest manifest) : base(manifest) {

        }

        private void PluginManager_OnScreenChanged(object? sender, ScreenChangedEventArgs e) {
            if (_activePanel is not null) {
                UI.PanelManager?.UnloadPanel(_activePanel);
            }
            var screenFile = Path.Combine(AssemblyDirectory, "assets", $"{e.NewScreen}.rml");
            if (File.Exists(screenFile)) {
                _log?.LogDebug($"Loading {screenFile}");
                _activePanel = UI.PanelManager?.LoadPanelFile(screenFile);
            }
            OnScreenChanged?.Invoke(this, e);
        }

        private void PluginManager_OnGraphicsPreReset(object sender, EventArgs e) {
            UI.Dispose();
        }

        private void PluginManager_OnGraphicsPostReset(object sender, EventArgs e) {
            UI.Init(_pluginManager, _renderer, _input, _log);
        }
        
        /// <summary>
        /// Called when your plugin is unloaded. Either when logging out, closing the client, or hot reloading.
        /// </summary>
        protected override void Dispose() {
            try {
                _log?.LogTrace($"Shutting down");
                UI.Dispose();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error during shutdown");
            }
        }
    }
}
