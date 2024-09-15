using MagicHat.Service.Lib.Plugins;
using System.IO;
using System;
using MagicHat.Service.Lib;
using Microsoft.Extensions.Logging;
using MagicHat.Service.Lib.Plugins.AssemblyLoader;
using ACClientLib.DatReaderWriter;

namespace Core.DatService {
    public class CoreDatService : IPluginCore {
        private PluginManager _pluginManager;
        public static ILogger<CoreDatService>? Log;

        public DatDatabaseReader PortalDat { get; }

        protected CoreDatService(AssemblyPluginManifest manifest, PluginManager pluginManager, ILogger<CoreDatService>? log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Log?.LogDebug($"CoreDatService Version: {Manifest.Version}");

            PortalDat = new DatDatabaseReader(options => {
                options.FilePath = $"client_Portal.dat";
                options.IndexCachingStrategy = ACClientLib.DatReaderWriter.Options.IndexCachingStrategy.Upfront;
            });
        }

        protected override void Dispose() {
            PortalDat?.Dispose();
        }
    }
}
