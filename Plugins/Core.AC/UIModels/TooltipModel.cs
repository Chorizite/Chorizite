using Core.UI.Models;
using Chorizite.ACProtocol;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Core.Net;
using Core.UI.Lib.Serialization;
using System.Text.Json.Serialization;
using Chorizite.Core.Backend;
using System;
using Microsoft.Extensions.Logging;
using ChatType = Chorizite.Core.Backend.ChatType;

namespace Core.AC.UIModels {
    [JsonConverter(typeof(UIDataModelJsonConverter))]
    public class TooltipModel : UIDataModel {
        public DataVariable<string> Text { get; } = new("");
        public DataVariable<uint> ObjectId { get; } = new(0);
        public DataVariable<uint> IconId { get; } = new(0);
        public DataVariable<string> IconPath { get; } = new("red");

        public TooltipModel() : base() {

            CoreACPlugin.Instance.ClientBackend.OnShowTooltip += ClientBackend_OnShowTooltip;
            CoreACPlugin.Instance.ClientBackend.OnHideTooltip += ClientBackend_OnHideTooltip;
        }

        private void ClientBackend_OnShowTooltip(object? sender, ShowTooltipEventArgs e) {
            Text.Value = e.Text;
            ObjectId.Value = e.ObjectId;
            IconId.Value = e.IconId;
            IconPath.Value = $"red";
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
