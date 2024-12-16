using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using Core.UI;
using Core.AC;
using Core.AC.Lib.Panels;
using Core.AC.API;

namespace AuctionHouse {
    public class AuctionHousePlugin : IPluginCore {
        internal static ILogger Log;
        private readonly GamePanel _panelId;

        public CoreUIPlugin UI { get; }
        public CoreACPlugin AC { get; }

        protected AuctionHousePlugin(AssemblyPluginManifest manifest, CoreUIPlugin coreUI, CoreACPlugin coreAC, ILogger log) : base(manifest) {
            Log = log;
            UI = coreUI;
            AC = coreAC;

            _panelId = AC.CustomPanelFromName("AuctionHouse");

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
            AC.RegisterPanel(_panelId, Path.Combine(AssemblyDirectory, "assets", "AuctionHouse.rml"));
        }

        protected override void Dispose() {
            AC.UnregisterPanel(_panelId, Path.Combine(AssemblyDirectory, "assets", "AuctionHouse.rml"));
        }
    }
}
