using MagicHat.Service.Lib.Plugins;
using System.IO;
using System;
using MagicHat.Service.Lib;
using Microsoft.Extensions.Logging;
using WattleScript.Interpreter;
using ScriptHost.Lib;
using MagicHat.Service.Lib.Plugins.AssemblyLoader;

namespace ScriptHost {
    public class CoreLuaPlugin : IPluginCore {
        private string _assemblyDirectory = null;
        private PluginManager _pluginManager;
        private IBackendProvider _backendProvider;
        public static ILogger<CoreLuaPlugin>? Log;

        public Script Script { get; }

        /// <summary>
        /// Assembly directory containing the plugin dll
        /// </summary>
        public string AssemblyDirectory {
            get {
                if (_assemblyDirectory == null) {
                    try {
                        _assemblyDirectory = Path.GetDirectoryName(typeof(CoreLuaPlugin).Assembly.Location);
                    }
                    catch {
                        _assemblyDirectory = Environment.CurrentDirectory;
                    }
                }
                return _assemblyDirectory;
            }
            set {
                Log?.LogTrace($"Setting AssemblyDirectory to {value}");
                _assemblyDirectory = value;
            }
        }
        public CoreLuaPlugin(PluginManager pluginManager, IBackendProvider backendProvider, ILogger<CoreLuaPlugin>? log) {
            Log = log;
            _pluginManager = pluginManager;
            _backendProvider = backendProvider;

            if (_pluginManager.PluginIsLoaded("ScriptHost")) {
                CallScriptHost();
            }
            else {
                Log?.LogWarning("ScriptHost is not loaded");
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
                var scriptHost = _pluginManager.GetPlugin<CoreACPlugin>("ScriptHost");

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

        public void Dispose() {
            
        }
    }
}
