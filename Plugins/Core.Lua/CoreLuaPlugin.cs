using System.IO;
using System;
using Microsoft.Extensions.Logging;
using WattleScript.Interpreter;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Core.AC;
using System.Linq;
using Core.UI;

namespace Core.Lua {
    public class CoreLuaPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        private readonly CoreUIPlugin _coreUI;
        public static ILogger? Log;

        public CoreLuaPlugin(AssemblyPluginManifest manifest, CoreUIPlugin coreUI, IPluginManager pluginManager, ILogger log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;
            _coreUI = coreUI;

            Log?.LogDebug($"Core.Lua 4: {Manifest.Version}");
            var count = 0;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                if (assembly.FullName.Contains("Core.Lua")) {
                    Log?.LogDebug($"\t Found Core.Lua assembly1: {assembly.FullName}");
                    count++;
                }
            }

            Log?.LogDebug($"\t Found Core.Lua assembly2: {count}"); 
        }

        public override void Dispose() {
            Log = null;
        }
    }
}
