using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using System.Linq;
using Chorizite.Core.Backend;
using XLua;
using Core.Lua.Lib;
using System.Text;
using System.Collections.Generic;

namespace Core.Lua {
    public class CoreLuaPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        private readonly IClientBackend? _clientBackend;
        private LuaContext _lua;
        public static ILogger? Log;

        /// <summary>
        /// The path to builtin lua scripts
        /// </summary>
        public string LuaScriptsPath => Path.Combine(AssemblyDirectory, "LuaScripts");

        public CoreLuaPlugin(AssemblyPluginManifest manifest, IClientBackend? clientBackend, IPluginManager pluginManager, ILogger log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;
            _clientBackend = clientBackend;

            if (_clientBackend is not null) {
                _clientBackend.OnChatTextAdded += OnChatText;
                _clientBackend.OnChatInput += OnChatInput;
            }
            
            var xluaNativePath = Path.Combine(AssemblyDirectory, "runtimes", (IntPtr.Size == 8) ? "win-x64" : "win-x86", "native", "xlua.dll");
            Log?.LogTrace($"Manually pre-loading {xluaNativePath}");
            Native.LoadLibrary(xluaNativePath);

            return;
            //_lua = MakeLuaEnv();

            try {
                _clientBackend?.AddChatText($"[Lua] {_lua.FormatLuaResult(RunLuaString("return {}"))}");
            }
            catch (Exception ex) {
                _clientBackend?.AddChatText($"[Lua] Error: {ex.Message}", ChatType.HelpChannel);
            }
        }

        public LuaContext MakeLuaEnv() {
            return new LuaContext(LuaScriptsPath, Log);
        }

        private void OnChatInput(object? sender, ChatInputEventArgs e) {
            if (e.Text.StartsWith("/lua")) {
                e.Eat = true;

                if (e.Text.Length < 5) {
                    _clientBackend?.AddChatText($"[Lua] Version {_lua.DoString("return _VERSION").FirstOrDefault()}");
                    return;
                }

                var res = RunLuaString(e.Text.Substring(5));
                _clientBackend?.AddChatText($"[Lua] Result: {_lua.FormatLuaResult(res)}");
            }
        }

        public object[]? RunLuaString(string luaStr) {
            try {
                return _lua.DoString(luaStr);
            }
            catch (Exception ex) {
                _clientBackend?.AddChatText($"[Lua] Error: {ex.Message}", ChatType.HelpChannel);
                return null;
            }
        }

        private void OnChatText(object? sender, ChatTextAddedEventArgs e) {
            Log.LogDebug($"ChatText: [{e.Type}] {e.Text}");
        }

        protected override void Dispose() {
            if (_clientBackend is not null) {
                _clientBackend.OnChatTextAdded -= OnChatText;
                _clientBackend.OnChatInput -= OnChatInput;
            }

            _lua?.Dispose();
            _lua = null;

            Log = null;
        }
    }
}
