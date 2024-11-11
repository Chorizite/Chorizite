using Core.UI.Models;
using Chorizite.ACProtocol;
using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Core.Net;
using Core.UI.Lib.Serialization;
using System.Text.Json.Serialization;

namespace Core.AC.UIModels {
    [JsonConverter(typeof(UIDataModelJsonConverter))]
    public class DatPatchScreenModel : UIDataModel {
        private readonly NetworkParser _net;

        public DataVariable<float> ConnectPercentage { get; } = new(0);
        public DataVariable<float> PatchPercentage { get; } = new(0);
        public DataVariable<uint> ExpectedBytes { get; } = new(0);
        public DataVariable<uint> ReceivedBytes { get; } = new(0);

        public DatPatchScreenModel() : base() {
            _net = CoreACPlugin.Instance.Net;
            _net.OnS2CPacket += Net_OnS2CPacket;
            _net.OnC2SPacket += Net_OnC2SPacket;

            _net.Messages.S2C.OnDDD_BeginDDDMessage += Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage += Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD += Messages_S2C_OnDDD_OnEndDDD;
        }

        private void Messages_S2C_OnDDD_BeginDDDMessage(object? sender, DDD_BeginDDDMessage e) {
            ExpectedBytes.Value = e.DataExpected;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;
        }

        private void Messages_S2C_OnDDD_DataMessage(object? sender, DDD_DataMessage e) {
            ReceivedBytes.Value += e.DataSize;
            PatchPercentage.Value = (float)ReceivedBytes.Value / (float)ExpectedBytes.Value;
        }

        private void Messages_S2C_OnDDD_OnEndDDD(object? sender, DDD_OnEndDDD e) {
            PatchPercentage.Value = 1f;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;
        }

        private void Net_OnS2CPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.ConnectRequest)) {
                ConnectPercentage.Value = 1f;
                _net.OnS2CPacket -= Net_OnS2CPacket;
            }
        }

        private void Net_OnC2SPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.LoginRequest)) {
                ConnectPercentage.Value = 0.5f;
                _net.OnC2SPacket -= Net_OnC2SPacket;
            }
        }

        public override void Dispose() {
            _net.OnS2CPacket -= Net_OnS2CPacket;
            _net.OnC2SPacket -= Net_OnC2SPacket;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
            base.Dispose();
        }
    }
}
