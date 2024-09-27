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
                if (scriptHost is null) throw new Exception("Core.AC is not loaded");

                scriptHost.Game.OnStateChanged += (s, e) => {
                    Log?.LogInformation($"Detected state change: {e.NewState}");
                    if (e.NewState == Core.AC.Lib.Enums.GameState.CharacterSelect) {
                        Log?.LogInformation($"Characters: {string.Join(", ", scriptHost.Game.Characters.Select(c => c.Name))}");
                    }
                };

                if (scriptHost is not null) {
                    Log?.LogInformation($"Lua called ScriptHost: {scriptHost.Game.State} // {scriptHost.Test()}");
                }
                else {
                    Log?.LogInformation("Lua called ScriptHost: null");
                }
            }
            catch (Exception ex) {
                Log?.LogInformation($"Error calling ScriptHost: {ex.Message}");
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
