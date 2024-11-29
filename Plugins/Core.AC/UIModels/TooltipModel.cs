using Core.UI.Models;
using Chorizite.ACProtocol;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Core.Net;
using Core.UI.Lib.Serialization;
using System.Text.Json.Serialization;
using Chorizite.Core.Backend;
using System;

namespace Core.AC.UIModels {
    [JsonConverter(typeof(UIDataModelJsonConverter))]
    public class TooltipModel : UIDataModel {
        public DataVariable<string> Text { get; } = new("");
        public DataVariable<uint> ObjectId { get; } = new(0);

        public TooltipModel() : base() {

            CoreACPlugin.Instance.ClientBackend.OnShowTooltip += ClientBackend_OnShowTooltip;
            CoreACPlugin.Instance.ClientBackend.OnHideTooltip += ClientBackend_OnHideTooltip;
        }

        private void ClientBackend_OnShowTooltip(object? sender, ShowTooltipEventArgs e) {
            Text.Value = e.Text;
            ObjectId.Value = e.ObjectId;
            CoreACPlugin.Instance.ClientBackend.AddChatText(e.Text);
        }

        private void ClientBackend_OnHideTooltip(object? sender, EventArgs e) {
            
        }

        public override void Dispose() {
            base.Dispose();
            CoreACPlugin.Instance.ClientBackend.OnShowTooltip -= ClientBackend_OnShowTooltip;
            CoreACPlugin.Instance.ClientBackend.OnHideTooltip -= ClientBackend_OnHideTooltip;
        }
    }
}
