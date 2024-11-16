using System.IO;
using System;
using Microsoft.Extensions.Logging;
using WattleScript.Interpreter;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Core.AC;
using System.Linq;
using Core.UI;
using Chorizite.Core.Backend;

namespace Core.Lua {
    public class CoreLuaPlugin : IPluginCore {
        private readonly IPluginManager _pluginManager;
        private readonly CoreUIPlugin _coreUI;
        private readonly IClientBackend _backend;
        public static ILogger? Log;

        public CoreLuaPlugin(AssemblyPluginManifest manifest, IClientBackend backend, CoreUIPlugin coreUI, IPluginManager pluginManager, ILogger log) : base(manifest) {
            Log = log;
            _pluginManager = pluginManager;
            _coreUI = coreUI;
            _backend = backend;

            _backend.OnChatTextAdded += OnChatText;
            _backend.OnChatInput += OnChatInput;

            Log.LogDebug("Loaded Core.Lua");
        }

        private void OnChatInput(object? sender, ChatInputEventArgs e) {
            if (e.Text.StartsWith("/lua")) {
                Log.LogDebug($"Found LUA command: {e.Text}");
                _backend.AddChatText($"Found LUA command: {e.Text}", ChatType.Default);
                _backend.AddChatText($"Found LUA command: {e.Text}", ChatType.Transient);
                e.Eat = true;
            }
        }

        private void OnChatText(object? sender, ChatTextAddedEventArgs e) {
            Log.LogDebug($"ChatText: [{e.Type}] {e.Text}");
        }

        protected override void Dispose() {
            _backend.OnChatTextAdded -= OnChatText;
            _backend.OnChatInput -= OnChatInput;

            Log = null;
        }
    }
}
