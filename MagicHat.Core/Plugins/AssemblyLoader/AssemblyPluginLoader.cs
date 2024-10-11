using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Plugins.AssemblyLoader {
    /// <summary>
    /// A plugin loader that can load plugins from dotnet assemblies.
    /// </summary>
    public class AssemblyPluginLoader : IPluginLoader {
        private readonly ILifetimeScope _serviceProvider;
        private readonly ILogger _log;
        private readonly IPluginManager _pluginManager;

        public AssemblyPluginLoader(ILifetimeScope serviceProvider, IPluginManager pluginManager, ILogger<AssemblyPluginLoader> log) {
            _log = log;
            _pluginManager = pluginManager;
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc cref="IPluginLoader.CanLoadPlugin(PluginManifest)"/>
        public bool CanLoadPlugin(PluginManifest manifest) {
            return Path.GetExtension(manifest?.EntryFile ?? "") == ".dll";
        }

        /// <inheritdoc cref="IPluginLoader.LoadPluginInstance(PluginManifest, out PluginInstance?)"/>
        public bool LoadPluginInstance(PluginManifest manifest, out PluginInstance? instance) {
            if (PluginManifest.TryLoadManifest<AssemblyPluginManifest>(manifest.ManifestFile, out var assemblyManifest, out string? errors)) {
                instance = new AssemblyPluginInstance(_pluginManager, assemblyManifest, _serviceProvider);
                return true;
            }
            _log?.LogError(errors);
            instance = null;
            return false;
        }

        /// <inheritdoc cref="IPluginLoader.GetPluginInterface(PluginInstance)"/>
        public IPluginCore? GetPluginInterface(PluginInstance plugin) {
            if (plugin is AssemblyPluginInstance instance) {
                return instance.PluginInstance;
            }

            return null;
        }
    }
}
