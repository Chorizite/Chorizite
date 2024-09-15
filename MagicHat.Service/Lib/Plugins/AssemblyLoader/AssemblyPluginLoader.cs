using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Service.Lib.Plugins.AssemblyLoader {
    /// <summary>
    /// A plugin loader that can load plugins from dotnet assemblies.
    /// </summary>
    public class AssemblyPluginLoader : IPluginLoader {
        private readonly IContainer _serviceProvider;

        public AssemblyPluginLoader(IContainer serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc cref="IPluginLoader.CanLoadPlugin(PluginManifest)"/>
        public bool CanLoadPlugin(PluginManifest manifest) {
            return Path.GetExtension(manifest?.EntryFile ?? "") == ".dll";
        }

        /// <inheritdoc cref="IPluginLoader.LoadPluginInstance(PluginManifest, out PluginInstance?)"/>
        public bool LoadPluginInstance(PluginManifest manifest, out PluginInstance? instance) {
            if (PluginManifest.TryLoadManifest<AssemblyPluginManifest>(manifest.ManifestFile, out var assemblyManifest)) {
                instance = new AssemblyPluginInstance(assemblyManifest, _serviceProvider);
                return true;
            }
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
