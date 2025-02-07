using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;

namespace Core.DatService {
    public class CoreDatService : IPluginCore {
        private IPluginManager _pluginManager;
        internal static ILogger Log;

        protected CoreDatService(AssemblyPluginManifest manifest, IChoriziteConfig config, IPluginManager pluginManager, ILogger log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Log?.LogDebug($"CoreDatService Version: {Manifest.Version}");
        }

        protected override void Initialize() {
            
        }

        protected override void Dispose() {
            
        }
    }
}
