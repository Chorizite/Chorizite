using System.IO;
using System;
using Microsoft.Extensions.Logging;
using ACClientLib.DatReaderWriter;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;

namespace Core.DatService {
    public class CoreDatService : IPluginCore {
        private IPluginManager _pluginManager;
        public static ILogger<CoreDatService>? Log;

        public DatDatabaseReader PortalDat { get; }

        protected CoreDatService(AssemblyPluginManifest manifest, IChoriziteConfig config, IPluginManager pluginManager, ILogger<CoreDatService>? log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Log?.LogDebug($"CoreDatService Version: {Manifest.Version}");

            PortalDat = new DatDatabaseReader(options => {
                options.FilePath = Path.Combine(config.DatDirectory, $"client_Portal.dat");
                options.IndexCachingStrategy = ACClientLib.DatReaderWriter.Options.IndexCachingStrategy.Upfront;
            });
        }

        public override void Dispose() {
            PortalDat?.Dispose();
        }
    }
}
