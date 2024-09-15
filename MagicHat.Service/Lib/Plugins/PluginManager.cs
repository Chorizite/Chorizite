using Autofac;
using MagicHat.Service.Lib.Logging;
using MagicHat.Service.Lib.Plugins.AssemblyLoader;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MagicHat.Service.Lib.Plugins {
    /// <summary>
    /// A plugin manager.
    /// </summary>
    public class PluginManager {
        private Dictionary<string, PluginInstance> _loadedPlugins = [];
        private List<IPluginLoader> _pluginLoaders = [];
        private ILogger _log;

        public IBackendProvider Backend { get; }

        /// <summary>
        /// The absolute path to the directory where plugins are stored.
        /// </summary>
        public string PluginDirectory => System.IO.Path.Combine(MagicHatService.AssemblyDirectory, "plugins");

        /// <summary>
        /// A list of currently loaded plugins.
        /// </summary>
        public IReadOnlyList<PluginInstance> Plugins => [.. _loadedPlugins.Values];

        /// <summary>
        /// A list of currently registered plugin loaders.
        /// </summary>
        public IReadOnlyList<IPluginLoader> PluginLoaders => _pluginLoaders;

        public PluginManager(IBackendProvider backend) {
            _log = MakeLogger("PluginManager");
            Backend = backend;
        }

        internal void Init(IContainer serviceProvider) {
            RegisterPluginLoader(new AssemblyPluginLoader(serviceProvider));
        }

        /// <summary>
        /// Create a new logger with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ILogger MakeLogger(string name) {
            return new MagicHatLogger(name);
        }

        public bool PluginIsLoaded(string name) {
            return _loadedPlugins.Values.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault() is not null;
        }

        public T? GetPlugin<T>(string name) where T : IPluginCore {
            var plugin = _loadedPlugins.Values.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault();
            if (plugin is null) {
                return default;
            }

            var loader = _pluginLoaders.Where(l => l.CanLoadPlugin(plugin.Manifest)).FirstOrDefault();
            if (plugin is null) {
                return default;
            }

            return (T?)loader.GetPluginInterface(plugin);
        }

        /// <summary>
        /// Load all plugin manifests from the <see cref="PluginDirectory"/>.
        /// </summary>
        public void LoadPlugins() {
            _log?.LogDebug($"Loading plugins");
            if (!Directory.Exists(PluginDirectory)) {
                _log?.LogWarning($"Plugin directory does not exist: {PluginDirectory}");
                return;
            }

            foreach (var file in Directory.EnumerateDirectories(PluginDirectory)) {
                var manifestFile = Path.Combine(file, "manifest.json");
                if (!LoadPluginManifest(manifestFile, out PluginInstance? plugin) || plugin is null) {
                    continue;
                }

                _loadedPlugins.Add(plugin.Manifest.EntryFile, plugin);
            }
        }

        /// <summary>
        /// Load a plugin from a manifest file.
        /// </summary>
        /// <param name="manifestFile">The absolute path to a plugin manifest.</param>
        /// <param name="plugin">The plugin instance, if it was loaded succesfully.</param>
        /// <returns></returns>
        private bool LoadPluginManifest(string manifestFile, out PluginInstance? plugin) {
            try {
                _log?.LogDebug($"Loading plugin manifest: {manifestFile}");
                if (PluginManifest.TryLoadManifest(manifestFile, out PluginManifest manifest)) {
                    _log?.LogDebug($"Loaded plugin manifest {manifest.Name} v{manifest.Version} which depends on: {string.Join(", ", manifest.Dependencies)}");
                    if (TryGetPluginLoader(manifest, out IPluginLoader? loader)) {
                        if (loader?.LoadPluginInstance(manifest, out plugin) == true && plugin is not null) {
                            return true;
                        }
                    }
                    else {
                        _log?.LogError("Failed to find plugin loader for: {0}", manifest.EntryFile); ;
                    }
                }
                else {
                    _log?.LogError("Failed to load plugin manifest: {0}", manifestFile);
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin manifest: {0}: {1}", manifestFile, ex.Message);
            }
            plugin = null;
            return false;
        }

        /// <summary>
        /// Register a plugin loader.
        /// </summary>
        /// <param name="loader">The loader to register.</param>
        public void RegisterPluginLoader(IPluginLoader loader) {
            _log?.LogDebug($"Registering plugin loader: {loader}");
            _pluginLoaders.Add(loader);
        }

        /// <summary>
        /// Unregister a plugin loader.
        /// </summary>
        /// <param name="loader">The loader to unregister.</param>
        public void UnregisterPluginLoader(IPluginLoader loader) {
            _log?.LogDebug($"Unregistering plugin loader: {loader}");
            _pluginLoaders.Remove(loader);
        }

        /// <summary>
        /// Try and get an <see cref="IPluginLoader"/> instance for the specified plugin manifest.
        /// </summary>
        /// <param name="manifest">The manifest to use</param>
        /// <param name="loader">The loader found, if any</param>
        /// <returns>Returns true if a loader was found.</returns>
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

        internal void Startup() {
            var plugins = _loadedPlugins.Values.ToArray();
            var startedPlugins = new List<string>();
            _log?.LogDebug($"Starting all plugins: {string.Join(", ", plugins.Select(p => $"{p.Name}({p.Manifest.Version})"))}");

            foreach (var plugin in plugins) {
                StartPlugin(plugin, ref startedPlugins);
            }
        }

        private bool StartPlugin(PluginInstance plugin, ref List<string> startedPlugins) {
            if (startedPlugins.Contains(plugin.Name.ToLower())) {
                return true;
            }

            _log?.LogTrace($"Starting plugin: {plugin.Name}");

            foreach (var dep in plugin.Manifest.Dependencies) {
                var parts = dep.Split('@');
                var depName = parts[0];
                var depVersion = parts.Length > 1 ? new Version(parts[1].TrimEnd('?')) : new Version(0,0,0);
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
            startedPlugins.Add(plugin.Name.ToLower());

            return true;
        }

        internal bool TryResolvePluginAssembly(ResolveEventArgs args, out Assembly? loadedAssembly) {
            var name = new AssemblyName(args.Name);
            loadedAssembly = null;
            var plugins = _loadedPlugins.Values.Where(p => p is AssemblyPluginInstance).Cast<AssemblyPluginInstance>().ToArray();

            foreach (var plugin in plugins) {
                if (plugin.Assembly is not null && plugin.Assembly?.GetName()?.Name == args.RequestingAssembly?.GetName()?.Name) {
                    var localDllPath = Path.Combine(Path.GetDirectoryName(plugin.Manifest.ManifestFile), $"{name.Name}.dll");
                    if (File.Exists(localDllPath)) {
                        _log?.LogTrace($"Resolved assembly {name.Name} for {plugin.Name} at {localDllPath}");
                        loadedAssembly = Assembly.Load(File.ReadAllBytes(localDllPath));
                        return true;
                    }
                    else {
                        _log?.LogWarning($"Failed to resolve assembly for plugin {plugin.Name}: {localDllPath}");
                    }
                    break;
                }
            }

            return false;
        }

        internal void Dispose() {
            foreach (var plugin in Plugins) {
                plugin.Dispose();
            }
            _loadedPlugins.Clear();
        }
    }
}