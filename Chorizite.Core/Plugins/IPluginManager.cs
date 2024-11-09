using System;
using System.Collections.Generic;

namespace Chorizite.Core.Plugins {
    public interface IPluginManager : IDisposable {
        /// <summary>
        /// The absolute path to the directory where plugins are stored.
        /// </summary>
        string PluginDirectory { get; }

        /// <summary>
        /// A list of currently registered plugin loaders.
        /// </summary>
        IReadOnlyList<IPluginLoader> PluginLoaders { get; }

        /// <summary>
        /// A list of currently loaded plugins.
        /// </summary>
        IReadOnlyList<PluginInstance> Plugins { get; }

        /// <summary>
        /// An event that is triggered when a plugin is loaded.
        /// </summary>
        public event EventHandler<PluginLoadedEventArgs> OnPluginLoaded;

        /// <summary>
        /// An event that is triggered when a plugin is unloaded.
        /// </summary>
        public event EventHandler<PluginUnloadedEventArgs> OnPluginUnloaded;

        /// <summary>
        /// Load all plugin manifests from the <see cref="PluginDirectory"/>.
        /// </summary>
        void LoadPluginManifests();

        /// <summary>
        /// Start all plugins. Make sure you call <see cref="LoadPluginManifests"/> first.
        /// </summary>
        void StartPlugins();

        /// <summary>
        /// Get a plugin by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T? GetPlugin<T>(string name) where T : IPluginCore;

        /// <summary>
        /// Check if a plugin is loaded.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool PluginIsLoaded(string name);

        /// <summary>
        /// Try and get an <see cref="IPluginLoader"/> instance for the specified plugin manifest.
        /// </summary>
        /// <param name="manifest">The manifest to use</param>
        /// <param name="loader">The loader found, if any</param>
        /// <returns>Returns true if a loader was found.</returns>
        bool TryGetPluginLoader(PluginManifest manifest, out IPluginLoader? loader);

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