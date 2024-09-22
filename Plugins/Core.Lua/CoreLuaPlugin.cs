using System.IO;
using System;
using Microsoft.Extensions.Logging;
using WattleScript.Interpreter;
using ScriptHost.Lib;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using Core.AC;

namespace ScriptHost {
    public class CoreLuaPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        public static ILogger<CoreLuaPlugin>? Log;

        public Script Script { get; }

        public CoreLuaPlugin(AssemblyPluginManifest manifest, IPluginManager pluginManager, ILogger<CoreLuaPlugin> log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;

            if (_pluginManager.PluginIsLoaded("Core.AC")) {
                CallScriptHost();
            }
            else {
                Log?.LogWarning("Core.AC is not loaded");
            }

            Script = new Script();
            Script.Options.AutoAwait = true;
            Script.Options.Syntax = ScriptSyntax.Lua;

            UserData.RegisterType(typeof(TestClassScripting));

            Script.Options.DebugPrint = (message) => {
                Log?.LogInformation(message);
            };

            Script.Globals["TestClassScripting"] = new TestClassScripting();
        }

        private void CallScriptHost() {
            try {
                var scriptHost = _pluginManager.GetPlugin<CoreACPlugin>("Core.AC");

                if (scriptHost is not null) {
                    Log?.LogInformation($"Lua called ScriptHost: {scriptHost?.Test()}");
                }
                else {
                    Log?.LogInformation("Lua called ScriptHost: null");
                }
            }
            catch (Exception ex) {
                Log?.LogInformation("Lua called ScriptHost: null ex");
            }

        }

        public void Startup() {
            try {
                Script.DoString("print(\"Hello from lua\", TestClassScripting.Test())");
            }
            catch   (Exception ex) {
                Log?.LogError(ex, ex.Message);
            }
        }

        protected override void Dispose() {
            
        }
    }
}
