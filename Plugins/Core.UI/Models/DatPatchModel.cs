using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages.S2C;
using MagicHat.Core.Backend;
using MagicHat.Core.Net;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;

namespace Core.UI.Models {
    public class DatPatchModel : UIDataModel {
        private readonly NetworkParser _net;

        private float _connectPercentage = 0f;
        private float _patchPercentage = 0f;
        private uint _expectedBytes = 0;
        private uint _receivedBytes = 0;

        public float ConnectPercentage {
            get => _connectPercentage;
            set {
                if (value != _connectPercentage) {
                    _connectPercentage = value;
                    InvokePropertyChange();
                }
            }
        }

        public float PatchPercentage {
            get => _patchPercentage;
            set {
                if (value != _patchPercentage) {
                    _patchPercentage = value;
                    InvokePropertyChange();
                }
            }
        }

        public uint ExpectedBytes {
            get => _expectedBytes;
            set {
                if (value != _expectedBytes) {
                    _expectedBytes = value;
                    InvokePropertyChange();
                }
            }
        }

        public uint ReceivedBytes {
            get => _receivedBytes;
            set {
                if (value != _receivedBytes) {
                    _receivedBytes = value;
                    InvokePropertyChange();
                }
            }
        }

        public DatPatchModel(Context context, IMagicHatBackend backend, NetworkParser net) : base("DatPatchScreen", context) {
            _net = net;

            _net.OnS2CPacket += Net_OnS2CPacket;
            _net.OnC2SPacket += Net_OnC2SPacket;

            _net.Messages.S2C.OnDDD_BeginDDDMessage += Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage += Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD += Messages_S2C_OnDDD_OnEndDDD;
        }

        private void Messages_S2C_OnDDD_BeginDDDMessage(object? sender, DDD_BeginDDDMessage e) {
            ExpectedBytes = e.DataExpected;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;
        }

        private void Messages_S2C_OnDDD_DataMessage(object? sender, DDD_DataMessage e) {
            ReceivedBytes += e.DataSize;
            PatchPercentage = (float)ReceivedBytes / (float)ExpectedBytes;
        }

        private void Messages_S2C_OnDDD_OnEndDDD(object? sender, DDD_OnEndDDD e) {
            PatchPercentage = 1f;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;
        }

        private void Net_OnS2CPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.ConnectRequest)) {
                ConnectPercentage = 1f;
                _net.OnS2CPacket -= Net_OnS2CPacket;
            }
        }

        private void Net_OnC2SPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.LoginRequest)) {
                ConnectPercentage = 0.5f;
                _net.OnC2SPacket -= Net_OnC2SPacket;
            }
        }

        public override void Dispose() {
            _net.OnS2CPacket -= Net_OnS2CPacket;
            _net.OnC2SPacket -= Net_OnC2SPacket;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
        }
    }
}
