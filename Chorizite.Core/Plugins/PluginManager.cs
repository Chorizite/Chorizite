using Autofac;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// A plugin manager.
    /// </summary>
    public class PluginManager : IPluginManager {
        private readonly ILogger _log;
        private readonly Dictionary<string, PluginManifest> _loadedManifests = [];
        private readonly Dictionary<string, PluginInstance> _loadedPlugins = [];
        private readonly List<IPluginLoader> _pluginLoaders = [];
        private bool _hasPluginsLoaded = false;
        private bool _wantsReload = false;

        /// <inheritdoc />
        public string PluginDirectory { get; }

        /// <inheritdoc />
        public string StorageDirectory { get; }

        /// <inheritdoc />
        public ChoriziteEnvironment Environment { get; }
        /// <inheritdoc />
        public ILifetimeScope ServiceProvider { get; }

        private readonly IRenderInterface _renderer;

        /// <inheritdoc />
        public List<PluginInstance> Plugins => [.. _loadedPlugins.Values];

        /// <inheritdoc />
        public List<IPluginLoader> PluginLoaders => _pluginLoaders;

        /// <inheritdoc />
        public List<PluginManifest> PluginManifests => [.. _loadedManifests.Values];

        /// <inheritdoc />
        public event EventHandler<EventArgs> OnPluginsLoaded {
            add { _OnPluginsLoaded.Subscribe(value); }
            remove { _OnPluginsLoaded.Unsubscribe(value); }
        }
        private readonly WeakEvent<EventArgs> _OnPluginsLoaded = new();

        /// <inheritdoc />
        public event EventHandler<PluginsUnloadedEventArgs> OnBeforePluginsUnloaded {
            add { _OnBeforePluginsUnloaded.Subscribe(value); }
            remove { _OnBeforePluginsUnloaded.Unsubscribe(value); }
        }
        private readonly WeakEvent<PluginsUnloadedEventArgs> _OnBeforePluginsUnloaded = new();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="pluginDirectory"></param>
        /// <param name="pluginStorageDirectory"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="renderInterface"></param>
        /// <param name="log"></param>
        public PluginManager(ChoriziteEnvironment environment, string pluginDirectory, string pluginStorageDirectory, ILifetimeScope serviceProvider, IRenderInterface renderInterface, ILogger log) {
            _log = log;
            PluginDirectory = pluginDirectory;
            StorageDirectory = pluginStorageDirectory;
            Environment = environment;
            ServiceProvider = serviceProvider;
            _renderer = renderInterface;

            _renderer.OnRender2D += RenderInterface_OnRender2D;
        }

        private void RenderInterface_OnRender2D(object? sender, EventArgs e) {
            try {
                Update();
            }
            catch (Exception ex) {
                _log.LogError(ex, ex.Message);
            }
        }

        /// <inheritdoc />
        public bool PluginIsLoaded(string id) {
            return _loadedPlugins.Values.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault() is not null;
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public PluginInstance? GetPlugin(string id) {
            return _loadedPlugins.Values.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault();
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void LoadPlugins(bool isReloading = false) {
            if (_hasPluginsLoaded) {
                UnloadPlugins(isReloading);
            }

            LoadPluginManifests();

            _log.LogDebug($"Found {_loadedManifests.Count} plugin manifests: {string.Join(", ", _loadedManifests.Values.Select(m => $"{m.Name}({m.Version})"))}");

            var plugins = _loadedManifests.Values.ToArray();
            var startedPlugins = new List<string>();

            _log?.LogDebug($"Starting all plugins: {string.Join(", ", plugins.Select(p => $"{p.Name}({p.Version})"))}");

            foreach (var plugin in plugins) {
                StartPlugin(plugin, ref startedPlugins);
            }

            _hasPluginsLoaded = true;
            _OnPluginsLoaded.Invoke(this, EventArgs.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool StartPlugin(PluginManifest manifest, ref List<string> startedPlugins) {
            if (_loadedPlugins.ContainsKey(manifest.EntryFile) || startedPlugins.Contains(manifest.Id.ToLower())) {
                return true;
            }


            if (!(manifest.Environments.HasFlag(Environment) || Environment == ChoriziteEnvironment.DocGen)) {
                return false;
            }

            _log?.LogTrace($"Starting plugin: {manifest.Name}");

            foreach (var dep in manifest.Dependencies) {
                var parts = dep.Split('@');
                var depId = parts[0];
                var depVersion = parts.Length > 1 ? new Version(parts[1].TrimEnd('?')) : new Version(0, 0, 0);
                var isOptional = parts.Length > 1 ? parts[1].EndsWith("?") : false;

                var depPlugin = _loadedManifests.Values.Where(p => p.Id.ToLower() == depId.ToLower()).FirstOrDefault();

                if (depPlugin is null) {
                    if (isOptional) continue;

                    _log?.LogError($"Failed to start plugin {manifest.Name}: Dependency {depId} not found");
                    return false;
                }

                if (new Version(manifest.Version.Split('-').First()) < depVersion) {
                    _log?.LogWarning($"Plugin {manifest.Name}: Dependency {depId} version {depVersion} was less than the loaded version of {depPlugin.Version}");
                }

                if (startedPlugins.Contains(depId.ToLower())) {
                    continue;
                }

                if (!StartPlugin(depPlugin, ref startedPlugins)) {
                    if (isOptional) continue;

                    _log?.LogError($"Failed to start plugin {manifest.Name}: Dependency {depId} failed to start");
                    return false;
                }
            }

            if (TryGetPluginLoader(manifest, out IPluginLoader loader)) {
                if (loader?.LoadPluginInstance(manifest, out var plugin) == true && plugin is not null) {
                    _loadedPlugins.Add(manifest.EntryFile, plugin);
                    startedPlugins.Add(plugin.Id.ToLower());

                    if (!plugin.Load()) {
                        _log?.LogError($"Failed to load plugin: {plugin.DisplayName} v{plugin.Manifest.Version}");
                        _loadedPlugins.Remove(plugin.Manifest.EntryFile);
                        return false;
                    }

                    _log?.LogTrace($"Started plugin: {plugin.DisplayName}");
                    return true;
                }
                else {
                    _log?.LogError($"Failed to load plugin {manifest.Name}");
                }
            }
            else {
                _log?.LogError($"Failed to find plugin loader for {manifest.Name}");
            }

            return true;
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
            _loadedPlugins.Clear();
            _loadedManifests.Clear();

            for (var i = 0; i < 50; i++) {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            var failedToUnload = new List<string>();
            foreach (var plugin in pluginsToUnload.Where(p => p is AssemblyPluginInstance).Cast<AssemblyPluginInstance>()) {
                var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name?.Equals(plugin.AssemblyName) == true);
                if (assembly is not null) {
                    _log.LogDebug($"Failed to unload assembly: {assembly.FullName} ({assembly.Location})");
                    failedToUnload.Add(plugin.DisplayName);
                }
            }

            if (failedToUnload.Count > 0) {
                _log?.LogWarning($"Failed to unload plugins: {string.Join(", ", failedToUnload)}");
                System.Diagnostics.Debugger.Break();
            }

            _hasPluginsLoaded = false;
        }

        /// <inheritdoc />
        public void ReloadPlugins() {
            _wantsReload = true;
        }

        /// <inheritdoc />
        public void LoadPluginManifests() {
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
        private void ReloadPluginsInternal() {
            try {
                _log.LogDebug("Reloading plugins");
                LoadPlugins(true);
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error reloading plugins: {0}", ex.Message);
            }
        }

        /// <summary>
        /// Update the plugin manager, should be called once per frame.
        /// </summary>
        private void Update() {
            if (_wantsReload || Plugins.Any(p => p.IsLoaded && p.WantsReload)) {
                _wantsReload = false;
                ReloadPluginsInternal();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UnloadPluginAndDependents(PluginInstance plugin, ref List<PluginInstance> unloadedPlugins, bool isReloading) {
            foreach (var depPlugin in _loadedPlugins.Values.Where(p => p.Manifest.Dependencies.Select(d => d.Split('@').First()).Contains(plugin.DisplayName))) {
                if (!unloadedPlugins.Contains(depPlugin)) {
                    UnloadPluginAndDependents(depPlugin, ref unloadedPlugins, isReloading);
                }
            }
            unloadedPlugins.Add(plugin);
            plugin.Unload(isReloading);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private bool LoadPluginManifest(string manifestFile, out PluginManifest? manifest) {
            try {
                _log?.LogTrace($"Loading plugin manifest: {manifestFile}");
                if (PluginManifest.TryLoadManifest(manifestFile, out manifest, out string? errorStr)) {
                    _log?.LogTrace($"Loaded plugin manifest {manifest!.Name} v{manifest.Version} which depends on: {string.Join(", ", manifest.Dependencies)}");
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
        public bool TryGetPluginLoader(PluginManifest manifest, out IPluginLoader loader) {
            foreach (var pluginLoader in _pluginLoaders) {
                if (pluginLoader.CanLoadPlugin(manifest)) {
                    loader = pluginLoader;
                    return true;
                }
            }
            loader = null!;
            return false;
        }

        /// <inheritdoc />
        public bool TryGetPluginFromPath(string path, [NotNullWhen(true)] out PluginInstance plugin) {
            if (Path.HasExtension(path) || !File.Exists(path)) {
                path = Path.GetDirectoryName(path)!;
            }

            foreach (var p in _loadedPlugins.Values) {
                if (!string.IsNullOrWhiteSpace(p.DevManifest?.Source) && path.StartsWith(p.DevManifest.Source)) {
                    plugin = p;
                    return true;
                }

                if (!string.IsNullOrWhiteSpace(p.Manifest.BaseDirectory) && path.StartsWith(p.Manifest.BaseDirectory)) {
                    plugin = p;
                    return true;
                }
            }

            plugin = null!;
            return false;
        }

        /// <summary>
        /// Dispose of the plugin manager
        /// </summary>
        public void Dispose() {
            _renderer.OnRender2D -= RenderInterface_OnRender2D;
            foreach (var plugin in Plugins) {
                plugin.Dispose();
            }
            _loadedPlugins.Clear();
        }
    }
}