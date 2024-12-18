using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using Core.DearImGui;
using Core.AC.API;

namespace Core.AC.Debugger {
    public class CoreACDebugger : IPluginCore {
        internal static ILogger Log;
        private Inspector _inspector;
        private readonly CoreACPlugin _ac;
        private readonly CoreImGui _imgui;

        protected CoreACDebugger(AssemblyPluginManifest manifest, CoreACPlugin ac, CoreImGui imgui, ILogger log) : base(manifest) {
            Log = log;
            _ac = ac;
            _imgui = imgui;

            if (_ac.Game.State == ClientState.InGame) {
                Init();
            }
            else {
                _ac.Game.OnStateChanged += Game_OnStateChanged;
            }
        }

        private void Init() {
            _inspector = new Inspector("Inspector", _ac.Game);
            _imgui.OnRender += ImGui_OnRender;
        }

        private void ImGui_OnRender(object? sender, EventArgs e) {
            try {
                _inspector.Render();
            } catch (Exception ex) {
                Log.LogError(ex, "Error during render");
            }
        }

        private void Game_OnStateChanged(object? sender, GameStateChangedEventArgs e) {
            if (e.NewState == ClientState.InGame) {
                _ac.Game.OnStateChanged -= Game_OnStateChanged;
                Init();
            }
        }

        protected override void Dispose() {
            _imgui.OnRender -= ImGui_OnRender;
            _ac.Game.OnStateChanged -= Game_OnStateChanged;
        }
    }
}
