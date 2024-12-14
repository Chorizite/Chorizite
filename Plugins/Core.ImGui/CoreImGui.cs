using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;

namespace Core.ImGui {
    public class CoreImGui : IPluginCore {
        private IPluginManager _pluginManager;
        internal static ILogger Log;

        protected CoreImGui(AssemblyPluginManifest manifest, IChoriziteConfig config, IPluginManager pluginManager, ILogger log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Log?.LogDebug($"CoreImGui Version: {Manifest.Version}");
        }

        protected override void Dispose() {
            
        }
    }
}
