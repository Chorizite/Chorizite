using System.IO;
using System;
using Microsoft.Extensions.Logging;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using Core.AC.Lib;
using MagicHat.Core.Net;
using MagicHat.ACProtocol;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore {
        private IPluginManager _pluginManager;
        private readonly NetworkParser _net;

        public static ILogger<CoreACPlugin>? Log;
        public GameInterface Game { get; }

        protected CoreACPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, NetworkParser net, ILogger<CoreACPlugin> log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;
            _net = net;
            Game = new GameInterface(log, _net.Messages);

            Log?.LogDebug($"CoreAC Version: {Manifest.Version}");
        }

        public int Test() {
            return 123;
        }

        protected override void Dispose() {
            
        }
    }
}
