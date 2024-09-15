using MagicHat.Service.Lib.Plugins;
using System.IO;
using System;
using MagicHat.Service.Lib;
using Microsoft.Extensions.Logging;
using MagicHat.Service.Lib.Plugins.AssemblyLoader;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore {
        private PluginManager _pluginManager;
        public static ILogger<CoreACPlugin>? Log;

        protected CoreACPlugin(AssemblyPluginManifest manifest, PluginManager pluginManager, ILogger<CoreACPlugin>? log) : base(manifest) {
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
