using System.IO;
using System;
using Microsoft.Extensions.Logging;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore {
        private IPluginManager _pluginManager;
        public static ILogger<CoreACPlugin>? Log;

        protected CoreACPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger<CoreACPlugin>? log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Log?.LogDebug($"CoreAC Version: {Manifest.Version}");
        }

        public int Test() {
            return 123;
        }

        protected override void Dispose() {
            
        }
    }
}
