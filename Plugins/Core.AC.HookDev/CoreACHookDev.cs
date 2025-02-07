using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core;
using Core.AC.HookDev.Lib;
using AcClient;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend.Client;

namespace Core.AC.HookDev {
    unsafe public class CoreACHookDev : IPluginCore {
        internal static ILogger Log;

        internal Hooks Hooks { get; }
        public IClientBackend Client { get; }

        protected CoreACHookDev(AssemblyPluginManifest manifest, ILogger log, IClientBackend clientBackend) : base(manifest) {
            Log = log;
            Hooks = new Hooks(log, clientBackend);
            Client = clientBackend;
        }

        protected override void Initialize() {
            Client.OnChatInput += Client_OnChatInput;
        }

        private void Client_OnChatInput(object? sender, ChatInputEventArgs e) {
            if (e.Text.StartsWith("/hook")) {
                e.Eat = true;
                Client.AddChatText($"Hook: {e.Text}");
                //FindRadar();

                var isLocked = CPlayerSystem.s_pPlayerSystem[0]->playerModule.PlayerModule.LockUI() == 1 ? true : false;

                Client.AddChatText($"LockUI: {isLocked}");

                return;
                var el = UIElementManager.s_pInstance->GetElement(UIElementId.MiniGamePanel_Field);
                if (el is not null) {
                    Client.AddChatText($"Radar: {el->IsVisible()}");
                    el->SetVisible((byte)(el->IsVisible() == 1 ? 0 : 1));
                }
            }
        }

        private void FindRadar() {
            try {
                var el = UIElementManager.s_pInstance->GetElement(UIElementId.RootGameplay_FloatyIndicators_Field);
                var pos = Client.UIBackend.GetUIElementPosition((uint)UIElementId.RootGameplay_FloatyIndicators_Field);

                if (el is not null) {
                    if (el->IsVisible() == 1) {
                        el->SetVisible(0);
                    }
                    else {
                        el->SetVisible(1);
                    }
                }

                Client.AddChatText($"Radar: {pos.X}, {pos.Y} -> {pos.Z - pos.X}, {pos.W - pos.Y} // {(el is null ? "null" : "hasEl")}");
            }
            catch (Exception ex) {
                Client.AddChatText(ex.Message, ChatType.HelpChannel);
                Log.LogError(ex, ex.Message);
            }
        }

        protected override void Dispose() {
            Client.OnChatInput -= Client_OnChatInput;
            Hooks.Dispose();
        }
    }
}
