using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using Core.UI;
using Core.AC;
using Core.AC.API;
using ACUI.Lib;

namespace AuctionHouse {
    public class AuctionHousePlugin : IPluginCore {
        internal static ILogger Log;
        private Panel? _panel;

        public CoreUIPlugin UI { get; }
        public CoreACPlugin AC { get; }

        protected AuctionHousePlugin(AssemblyPluginManifest manifest, CoreUIPlugin coreUI, CoreACPlugin coreAC, ILogger log) : base(manifest) {
            Log = log;
            UI = coreUI;
            AC = coreAC;

            if (AC.Game.State == ClientState.InGame) {
                Init();
            }
            else {
                AC.Game.OnStateChanged += Game_OnStateChanged;
            }
        }

        private void Game_OnStateChanged(object? sender, GameStateChangedEventArgs e) {
            if (e.NewState == ClientState.InGame) {
                AC.Game.OnStateChanged -= Game_OnStateChanged;
                Init();
            }
        }

        private void Init() {
            _panel = UI.CreatePanel("ActionHouse", Path.Combine(AssemblyDirectory, "assets", "AuctionHouse.rml"));
            if (_panel is not null) {
                _panel.ShowInBar = true;
                _panel.Show();
            }
        }

        protected override void Dispose() {
            _panel?.Dispose();
        }
    }
}
