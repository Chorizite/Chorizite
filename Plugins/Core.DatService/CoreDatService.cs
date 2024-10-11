using System.IO;
using System;
using Microsoft.Extensions.Logging;
using ACClientLib.DatReaderWriter;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using MagicHat.Core;

namespace Core.DatService {
    public class CoreDatService : IPluginCore {
        private IPluginManager _pluginManager;
        public static ILogger<CoreDatService>? Log;

        public DatDatabaseReader PortalDat { get; }

        protected CoreDatService(AssemblyPluginManifest manifest, IMagicHatConfig config, IPluginManager pluginManager, ILogger<CoreDatService>? log) : base(manifest) {
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
