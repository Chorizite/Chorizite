using Autofac;
using Chorizite.Common;
using Chorizite.Core.Dats;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// A plugin manager.
    /// </summary>
    public class PluginManager : IPluginManager {
        private bool _hasPluginsLoaded = false;
        private readonly Dictionary<string, PluginManifest> _loadedManifests = [];
        private readonly Dictionary<string, PluginInstance> _loadedPlugins = [];
        private readonly List<IPluginLoader> _pluginLoaders = [];
        private readonly IChoriziteConfig _config;
        private readonly ILogger _log;
        private readonly IRenderInterface _render;

        /// <inheritdoc />
        public string PluginDirectory => _config.PluginDirectory;

        /// <inheritdoc />
        public List<PluginInstance> Plugins => [.. _loadedPlugins.Values];

        /// <inheritdoc />
        public List<IPluginLoader> PluginLoaders => _pluginLoaders;

        /// <inheritdoc />
        public List<PluginManifest> PluginManifests => [.. _loadedManifests.Values];

        public bool WantsReload { get; private set; }

        /// <inheritdoc />
        public event EventHandler<EventArgs>? OnPluginsLoaded {
            add { _OnPluginsLoaded.Subscribe(value); }
            remove { _OnPluginsLoaded.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnPluginsLoaded = new();

        /// <inheritdoc />
        public event EventHandler<PluginsUnloadedEventArgs>? OnBeforePluginsUnloaded {
            add { _OnBeforePluginsUnloaded.Subscribe(value); }
            remove { _OnBeforePluginsUnloaded.Unsubscribe(value); }
        }
        private readonly WeakEvent<PluginsUnloadedEventArgs> _OnBeforePluginsUnloaded = new();

        public PluginManager(IChoriziteConfig config, ILogger log) {
            _config = config;
            _log = log;
        }

        public PluginManager(IChoriziteConfig config, IRenderInterface render, ILogger<PluginManager> log) {
            _config = config;
            _log = log;
            _render = render;

            _render.OnRender2D += Render_OnRender2D;
        }

        /// <inheritdoc />
        public bool PluginIsLoaded(string name) {
            return _loadedPlugins.Values.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault() is not null;
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public T? GetPlugin<T>(string name) where T : IPluginCore {
            var plugin = _loadedPlugins.Values.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (plugin is null) {
                return default;
            }

            var loader = _pluginLoaders.Where(l => l.CanLoadPlugin(plugin.Manifest)).FirstOrDefault();
            if (loader is null) {
                return default;
            }

            return (T?)loader.GetPluginInterface(plugin);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LoadPlugins(bool isReloading = false) {
            if (_hasPluginsLoaded) {
                UnloadPlugins(isReloading);
            }

            LoadPluginManifests();

            _log.LogDebug($"Found {_loadedManifests.Count} plugin manifests: {string.Join(", ", _loadedManifests.Values.Select(m => $"{m.Name}({m.Version})"))}");

            foreach (var manifest in _loadedManifests.Values) {
                if (manifest.Environments.HasFlag(_config.Environment)) {
                    if (TryGetPluginLoader(manifest, out IPluginLoader? loader)) {
                        if (loader?.LoadPluginInstance(manifest, out var plugin) == true && plugin is not null) {
                            _loadedPlugins.Add(plugin.Manifest.EntryFile, plugin);
                        }
                    }
                    else {
                        _log?.LogError($"Failed to find plugin loader for {manifest.Name}");
                    }
                }
            }

            var plugins = _loadedPlugins.Values.ToArray();
            var startedPlugins = new List<string>();

            _log?.LogDebug($"Starting all plugins: {string.Join(", ", plugins.Select(p => $"{p.Name}({p.Manifest.Version})"))}");

            foreach (var plugin in plugins) {
                StartPlugin(plugin, ref startedPlugins);
            }

            _hasPluginsLoaded = true;
            _OnPluginsLoaded.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void UnloadPlugins(bool isReloading = false) {
            _log.LogDebug("Unloading plugins");

            _OnBeforePluginsUnloaded.Invoke(this, new PluginsUnloadedEventArgs(isReloading));

            var pluginsToUnload = _loadedPlugins.Values.ToArray();
            var unloadedPlugins = new List<PluginInstance>();
            foreach (var plugin in pluginsToUnload) {
                UnloadPluginAndDependents(plugin, ref unloadedPlugins, isReloading);
            }

            for (var i = 0; i < 20; i++) {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            var failedToUnload = new List<string>();
            foreach (var plugin in pluginsToUnload) {
                var isAlive = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.GetName().Name?.Contains(plugin.Name) == true);
                if (isAlive) {
                    failedToUnload.Add(plugin.Name);
                }
            }

            if (failedToUnload.Count > 0) {
                _log?.LogWarning($"Failed to unload plugins: {string.Join(", ", failedToUnload)}");
            }

            _loadedPlugins.Clear();
            _loadedManifests.Clear();

            _hasPluginsLoaded = false;
        }

        /// <inheritdoc />
        public void ReloadPlugins() {
            WantsReload = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void ReloadPluginsInternal() {
            try {
                _log.LogDebug("Reloading plugins");
                LoadPlugins(true);
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error reloading plugins: {0}", ex.Message);
            }
        }

        private void Render_OnRender2D(object? sender, EventArgs e) {
            if (WantsReload || Plugins.Any(p => p.IsLoaded && p.WantsReload)) {
                WantsReload = false;
                ReloadPluginsInternal();
            }
        }

        /// <inheritdoc />
        private void LoadPluginManifests() {
            _log?.LogTrace($"Loading plugin manifests");
            if (!Directory.Exists(PluginDirectory)) {
                _log?.LogWarning($"Plugin directory does not exist: {PluginDirectory}");
                return;
            }

            foreach (var file in Directory.EnumerateDirectories(PluginDirectory)) {
                try {
                    var manifestFile = Path.GetFullPath(Path.Combine(file, "manifest.json"));
                    if (!LoadPluginManifest(manifestFile, out PluginManifest? manifest) || manifest is null) {
                        _log?.LogWarning($"Failed to load plugin manifest: {manifestFile}");
                        continue;
                    }

                    _loadedManifests.Add(manifest.ManifestFile, manifest);
                }
                catch (Exception ex) {
                    _log?.LogError(ex, "Error loading plugin: {0}: {1}", PluginDirectory, ex.Message);
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UnloadPluginAndDependents(PluginInstance plugin, ref List<PluginInstance> unloadedPlugins, bool isReloading) {
            foreach (var depPlugin in _loadedPlugins.Values.Where(p => p.Manifest.Dependencies.Select(d => d.Split('@').First()).Contains(plugin.Name))) {
                if (!unloadedPlugins.Contains(depPlugin)) {
                    UnloadPluginAndDependents(depPlugin, ref unloadedPlugins, isReloading);
                }
            }
            unloadedPlugins.Add(plugin);
            plugin.Unload(isReloading);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool LoadPluginManifest(string manifestFile, out PluginManifest manifest) {
            try {
                _log?.LogTrace($"Loading plugin manifest: {manifestFile}");
                if (PluginManifest.TryLoadManifest(manifestFile, out manifest, out string? errorStr)) {
                    _log?.LogTrace($"Loaded plugin manifest {manifest.Name} v{manifest.Version} which depends on: {string.Join(", ", manifest.Dependencies)}");
                    return true;
                }
                else {
                    _log?.LogError(errorStr);
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin manifest: {0}: {1}", manifestFile, ex.Message);
            }
            manifest = default;
            return false;
        }

        /// <inheritdoc />
        public void RegisterPluginLoader(IPluginLoader loader) {
            _log?.LogDebug($"Registering plugin loader: {loader}");
            _pluginLoaders.Add(loader);
        }

        /// <inheritdoc />
        public void UnregisterPluginLoader(IPluginLoader loader) {
            _log?.LogDebug($"Unregistering plugin loader: {loader}");
            _pluginLoaders.Remove(loader);
        }

        /// <inheritdoc />
        public bool TryGetPluginLoader(PluginManifest manifest, out IPluginLoader? loader) {
            foreach (var pluginLoader in _pluginLoaders) {
                if (pluginLoader.CanLoadPlugin(manifest)) {
                    loader = pluginLoader;
                    return true;
                }
            }
            loader = null;
            return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool StartPlugin(PluginInstance plugin, ref List<string> startedPlugins) {
            if (plugin.IsLoaded || startedPlugins.Contains(plugin.Name.ToLower())) {
                return true;
            }
            _log?.LogTrace($"Starting plugin: {plugin.Name}");

            foreach (var dep in plugin.Manifest.Dependencies) {
                var parts = dep.Split('@');
                var depName = parts[0];
                var depVersion = parts.Length > 1 ? new Version(parts[1].TrimEnd('?')) : new Version(0, 0, 0);
                var isOptional = parts.Length > 1 ? parts[1].EndsWith("?") : false;

                var depPlugin = _loadedPlugins.Values.Where(p => p.Name.ToLower() == depName.ToLower()).FirstOrDefault();

                if (depPlugin is null) {
                    if (isOptional) continue;

                    _log?.LogError($"Failed to start plugin {plugin.Name}: Dependency {depName} not found");
                    return false;
                }

                if (new Version(depPlugin.Manifest.Version) < depVersion) {
                    if (isOptional) continue;

                    _log?.LogError($"Failed to start plugin {plugin.Name}: Dependency {depName} version {depVersion} was less than the loaded version of {depPlugin.Manifest.Version}");
                    return false;
                }

                if (startedPlugins.Contains(depName.ToLower())) {
                    continue;
                }

                if (!StartPlugin(depPlugin, ref startedPlugins)) {
                    if (isOptional) continue;

                    _log?.LogError($"Failed to start plugin {plugin.Name}: Dependency {depName} failed to start");
                    return false;
                }
            }
            if (!plugin.Load()) {
                _log?.LogError($"Failed to load plugin: {plugin.Name} v{plugin.Manifest.Version}");
                _loadedPlugins.Remove(plugin.Manifest.EntryFile);
            }

            _log?.LogTrace($"Started plugin: {plugin.Name}");
            startedPlugins.Add(plugin.Name.ToLower());

            return true;
        }

        public void Dispose() {
            _render.OnRender2D -= Render_OnRender2D;

            foreach (var plugin in Plugins) {
                plugin.Dispose();
            }
            _loadedPlugins.Clear();
        }
    }
}