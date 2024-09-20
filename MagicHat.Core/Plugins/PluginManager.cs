﻿using Autofac;
using MagicHat.Core.Dats;
using MagicHat.Core.Plugins.AssemblyLoader;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MagicHat.Core.Plugins {
    /// <summary>
    /// A plugin manager.
    /// </summary>
    public class PluginManager : IPluginManager {
        private readonly Dictionary<string, PluginInstance> _loadedPlugins = [];
        private readonly List<IPluginLoader> _pluginLoaders = [];
        private readonly IMagicHatConfig _config;
        private readonly ILogger _log;

        /// <inheritdoc />
        public string PluginDirectory => _config.PluginDirectory;

        /// <inheritdoc />
        public IReadOnlyList<PluginInstance> Plugins => [.. _loadedPlugins.Values];

        /// <inheritdoc />
        public IReadOnlyList<IPluginLoader> PluginLoaders => _pluginLoaders;

        public PluginManager(IMagicHatConfig config, ILogger<PluginManager> log) {
            _config = config;
            _log = log;
            _log?.LogInformation($"Finished with PluginManager::startup, {_config.PluginDirectory}");
        }

        /// <inheritdoc />
        public bool PluginIsLoaded(string name) {
            return _loadedPlugins.Values.Where(p => p.Name.ToLower() == name.ToLower()).FirstOrDefault() is not null;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void LoadPluginManifests() {
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

        /// <inheritdoc />
        public void StartPlugins() {
            var plugins = _loadedPlugins.Values.ToArray();
            var startedPlugins = new List<string>();
            _log?.LogDebug($"Starting all plugins: {string.Join(", ", plugins.Select(p => $"{p.Name}({p.Manifest.Version})"))}");

            foreach (var plugin in plugins) {
                StartPlugin(plugin, ref startedPlugins);
            }
        }

        private bool LoadPluginManifest(string manifestFile, out PluginInstance? plugin) {
            try {
                _log?.LogDebug($"Loading plugin manifest: {manifestFile}");
                if (PluginManifest.TryLoadManifest(manifestFile, out PluginManifest manifest, out string? errorStr)) {
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
                    _log?.LogError(errorStr);
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin manifest: {0}: {1}", manifestFile, ex.Message);
            }
            plugin = null;
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

        private bool StartPlugin(PluginInstance plugin, ref List<string> startedPlugins) {
            if (startedPlugins.Contains(plugin.Name.ToLower())) {
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
            startedPlugins.Add(plugin.Name.ToLower());

            return true;
        }

        public void Dispose() {
            foreach (var plugin in Plugins) {
                plugin.Dispose();
            }
            _loadedPlugins.Clear();
        }
    }
}