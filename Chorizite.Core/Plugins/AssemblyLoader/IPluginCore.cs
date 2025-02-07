using Chorizite.Core.Plugins.AssemblyLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins {
    public abstract class IPluginCore {
        internal int Id { get; set; }

        /// <summary>
        /// The manifest that was used to load this plugin.
        /// </summary>
        public AssemblyPluginManifest Manifest { get; }

        /// <summary>
        /// The path to the entry file assembly directory.
        /// </summary>
        public string AssemblyDirectory => System.IO.Path.GetDirectoryName(Manifest.ManifestFile);

        /// <summary>
        /// The path to where this plugin should store data
        /// </summary>
        public string DataDirectory => System.IO.Path.Combine(ChoriziteStatics.Config.StorageDirectory, "plugins", Manifest.Name);

        /// <summary>
        /// Use <see cref="Initialize"/> to initialize the plugin instead of the constructor. If your plugin is
        /// using state/settings/views, these wont be ready to setup until Initizalize is called.
        /// </summary>
        /// <param name="manifest"></param>
        protected IPluginCore(AssemblyPluginManifest manifest) {
            Manifest = manifest;
        }

        /// <summary>
        /// Initializes the plugin. When this is called, the plugin is ready to be used.
        /// </summary>
        protected abstract void Initialize();

        /// <summary>
        /// Disposes the plugin. Use this to clean up any resources used by the plugin.
        /// </summary>
        protected abstract void Dispose();
    }
}
