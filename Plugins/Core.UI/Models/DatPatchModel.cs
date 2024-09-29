using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Messages.S2C;
using MagicHat.Core.Backend;
using MagicHat.Core.Net;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UI.Models {
    public class DatPatchModel : UIDataModel {
        private readonly NetworkParser _net;

        private float _connectPercentage = 0f;
        private float _patchPercentage = 0f;

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

        public DatPatchModel(Context context, IMagicHatBackend backend, NetworkParser net) : base("DatPatchScreen", context) {
            _net = net;

            _net.OnS2CPacket += Net_OnS2CPacket;
            _net.OnC2SPacket += Net_OnC2SPacket;

            _net.Messages.S2C.OnDDD_InterrogationMessage += Messages_S2C_OnDDD_InterrogationMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD += Messages_S2C_OnDDD_OnEndDDD;

            // TODO: percentage based on actual patching progress
        }

        private void Messages_S2C_OnDDD_InterrogationMessage(object? sender, DDD_InterrogationMessage e) {
            PatchPercentage = 0.1f;
            _net.Messages.S2C.OnDDD_InterrogationMessage -= Messages_S2C_OnDDD_InterrogationMessage;
        }

        private void Messages_S2C_OnDDD_OnEndDDD(object? sender, DDD_OnEndDDD e) {
            PatchPercentage = 1f;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
        }

        private void Net_OnS2CPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(MagicHat.ACProtocol.Enums.PacketHeaderFlags.ConnectRequest)) {
                ConnectPercentage = 1f;
                _net.OnS2CPacket -= Net_OnS2CPacket;
            }
        }

        private void Net_OnC2SPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(MagicHat.ACProtocol.Enums.PacketHeaderFlags.LoginRequest)) {
                ConnectPercentage = 0.5f;
                _net.OnC2SPacket -= Net_OnC2SPacket;
            }
        }

        public override void Dispose() {
            _net.OnS2CPacket -= Net_OnS2CPacket;
            _net.OnC2SPacket -= Net_OnC2SPacket;
            _net.Messages.S2C.OnDDD_InterrogationMessage -= Messages_S2C_OnDDD_InterrogationMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
        }
    }
}
