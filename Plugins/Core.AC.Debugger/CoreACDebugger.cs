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

            return;

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

        protected override void Dispose() {
            _imgui.OnRender -= ImGui_OnRender;
        }
    }
}
