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
        private readonly CoreACPlugin _ac;
        private readonly CoreImGui _imgui;

        public Inspector Inspector { get; private set; }

        protected CoreACDebugger(AssemblyPluginManifest manifest, CoreACPlugin ac, CoreImGui imgui, ILogger log) : base(manifest) {
            Log = log;
            _ac = ac;
            _imgui = imgui;
        }

        protected override void Initialize() {
            if (_ac.Game.State == ClientState.InGame) {
                CreateInspector();
            }
            else {
                _ac.Game.OnStateChanged += Game_OnStateChanged;
            }
        }

        private void CreateInspector() {
            if (Inspector is not null) return;

            Inspector = new Inspector("Inspector", _ac.Game);
            _imgui.OnRender += ImGui_OnRender;
        }

        private void ImGui_OnRender(object? sender, EventArgs e) {
            try {
                Inspector.Render();
            } catch (Exception ex) {
                Log.LogError(ex, "Error during render");
            }
        }

        private void Game_OnStateChanged(object? sender, GameStateChangedEventArgs e) {
            if (e.NewState == ClientState.InGame) {
                _ac.Game.OnStateChanged -= Game_OnStateChanged;
                CreateInspector();
            }
        }

        protected override void Dispose() {
            _imgui.OnRender -= ImGui_OnRender;
            if (_ac.Game is not null) {
                _ac.Game.OnStateChanged -= Game_OnStateChanged;
            }
        }
    }
}
