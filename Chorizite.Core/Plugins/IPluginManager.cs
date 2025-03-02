using Autofac;
using Chorizite.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Chorizite.Core.Plugins {
    /// <summary>
    /// The plugin manager
    /// </summary>
    public interface IPluginManager : IDisposable {
        /// <summary>
        /// The absolute path to the directory where plugins are stored.
        /// </summary>
        string PluginDirectory { get; }

        /// <summary>
        /// The current environment.
        /// </summary>
        ChoriziteEnvironment Environment { get; }

        /// <summary>
        /// A list of currently registered plugin loaders.
        /// </summary>
        List<IPluginLoader> PluginLoaders { get; }

        /// <summary>
        /// A list of currently loaded plugin manifests.
        /// </summary>
        List<PluginManifest> PluginManifests { get; }

        /// <summary>
        /// A list of currently loaded plugins.
        /// </summary>
        List<PluginInstance> Plugins { get; }

        /// <summary>
        /// The service provider
        /// </summary>
        ILifetimeScope ServiceProvider { get; }

        /// <summary>
        /// The absolute path to the directory where plugins are stored.
        /// </summary>
        string StorageDirectory { get; }

        /// <summary>
        /// Fired after all plugins have been loaded.
        /// </summary>
        public event EventHandler<EventArgs> OnPluginsLoaded;

        /// <summary>
        /// An event that is triggered before plugins are unloaded.
        /// </summary>
        public event EventHandler<PluginsUnloadedEventArgs> OnBeforePluginsUnloaded;

        /// <summary>
        /// Load all plugins for the current environment.
        /// </summary>
        /// <param name="isReloading">True if plugins are reloading</param>
        void LoadPlugins(bool isReloading = false);

        /// <summary>
        /// Unload all plugins.
        /// </summary>
        /// <param name="isReloading">True if plugins are reloading</param>
        void UnloadPlugins(bool isReloading = false);

        /// <summary>
        /// This will trigger a reload of all plugins on the next frame.
        /// </summary>
        void ReloadPlugins();

        /// <summary>
        /// Load all plugin manifests
        /// </summary>
        void LoadPluginManifests();

        /// <summary>
        /// Get a plugin by name.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PluginInstance? GetPlugin(string id);

        /// <summary>
        /// Check if a plugin is loaded.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool PluginIsLoaded(string id);

        /// <summary>
        /// Try and get a plugin instance from a file path. This only works if the plugin is loaded.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="plugin"></param>
        /// <returns>Returns true if a plugin was found</returns>
        bool TryGetPluginFromPath(string path, [NotNullWhen(true)] out PluginInstance? plugin);

        /// <summary>
        /// Try and get an <see cref="IPluginLoader"/> instance for the specified plugin manifest.
        /// </summary>
        /// <param name="manifest">The manifest to use</param>
        /// <param name="loader">The loader found, if any</param>
        /// <returns>Returns true if a loader was found.</returns>
        bool TryGetPluginLoader(PluginManifest manifest, [NotNullWhen(true)] out IPluginLoader loader);

        /// <summary>
        /// Register a plugin loader.
        /// </summary>
        /// <param name="loader">The loader to register.</param>
        void RegisterPluginLoader(IPluginLoader loader);

        /// <summary>
        /// Unregister a plugin loader.
        /// </summary>
        /// <param name="loader">The loader to unregister.</param>
        void UnregisterPluginLoader(IPluginLoader loader);
    }
}