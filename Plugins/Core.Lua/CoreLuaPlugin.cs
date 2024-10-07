using System.IO;
using System;
using Microsoft.Extensions.Logging;
using WattleScript.Interpreter;
using ScriptHost.Lib;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using Core.AC;
using System.Linq;

namespace ScriptHost {
    public class CoreLuaPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        public static ILogger<CoreLuaPlugin>? Log;

        public Script Script { get; }

        public CoreLuaPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger<CoreLuaPlugin> log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            Script = new Script();
            Script.Options.AutoAwait = true;
            Script.Options.Syntax = ScriptSyntax.Lua;

            Script.Options.DebugPrint = (message) => {
                Log?.LogInformation(message);
            };
        }

        public void Startup() {
            try {
                Script.DoString("print(\"Hello from lua\", TestClassScripting.Test())");
            }
            catch   (Exception ex) {
                Log?.LogError(ex, ex.Message);
            }
        }

        public override void Dispose() {
            
        }
    }
}
