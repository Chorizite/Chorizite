using Chorizite.Core.Plugins.AssemblyLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins {
    public abstract class IPluginCore {
        /// <summary>
        /// The manifest that was used to load this plugin.
        /// </summary>
        public AssemblyPluginManifest Manifest { get; }

        public int Id { get; set; }

        /// <summary>
        /// The path to the entry file assembly directory.
        /// </summary>
        public string AssemblyDirectory => System.IO.Path.GetDirectoryName(Manifest.ManifestFile);

        /// <summary>
        /// The path to where this plugin should store data
        /// </summary>
        public string DataDirectory => System.IO.Path.Combine(ChoriziteStatics.Config.StorageDirectory, "plugins", Manifest.Name);

        protected IPluginCore(AssemblyPluginManifest manifest) {
            Manifest = manifest;
        }

        protected abstract void Dispose();
    }
}
