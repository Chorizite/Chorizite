using MagicHat.Core.Plugins.AssemblyLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Plugins {
    public abstract class IPluginCore {
        /// <summary>
        /// The manifest that was used to load this plugin.
        /// </summary>
        public AssemblyPluginManifest Manifest { get; }

        /// <summary>
        /// The path to the entry file assembly directory.
        /// </summary>
        public string AssemblyDirectory => System.IO.Path.GetDirectoryName(Manifest.ManifestFile);

        protected IPluginCore(AssemblyPluginManifest manifest) {
            Manifest = manifest;
        }

        protected abstract void Dispose();
    }
}
