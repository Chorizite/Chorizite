using Chorizite.ACProtocol.Enums;
using Chorizite.ACProtocol;
using Chorizite.Core.Net;
using Core.UI.Models;
using System;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Common;

namespace Core.AC.API {
    /// <summary>
    /// Information about game connection / patch progress
    /// </summary>
    public class PatchProgress : IDisposable {
        private readonly NetworkParser _net;

        /// <summary>
        /// The percentage of the connection that has been completed. 0-1. This goes to 0.5 when
        /// the login request is sent, and 1.0 when the login is acknowledged from the server.
        /// </summary>
        public float ConnectPercentage { get; set; }

        /// <summary>
        /// The percentage of the patch that has been downloaded. 0-1.
        /// </summary>
        public float PatchPercentage { get; set; }

        /// <summary>
        /// The total number of bytes expected to be received for the patch.
        /// </summary>
        public uint ExpectedBytes { get; set; }

        /// <summary>
        /// The total number of bytes received for the patch.
        /// </summary>
        public uint ReceivedBytes { get; set; }

        /// <summary>
        /// True if the client is currently downloading patch data
        /// </summary>
        public bool IsPatching { get; set; }

        /// <summary>
        /// Fired when connect / patch progress has changed.
        /// </summary>
        public event EventHandler<EventArgs> OnProgressChanged {
            add => _OnProgressChanged.Subscribe(value);
            remove => _OnProgressChanged.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnProgressChanged = new();

        /// <summary>
        /// Fired when connect progress has changed.
        /// </summary>
        public event EventHandler<EventArgs> OnConnectProgress {
            add => _OnConnectProgress.Subscribe(value);
            remove => _OnConnectProgress.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnConnectProgress = new();

        /// <summary>
        /// Fired when patching progress has changed.
        /// </summary>
        public event EventHandler<EventArgs> OnPatchProgress {
            add => _OnPatchProgress.Subscribe(value);
            remove => _OnPatchProgress.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnPatchProgress = new();

        public PatchProgress() {
            _net = CoreACPlugin.Instance.Net;
            _net.OnS2CPacket += Net_OnS2CPacket;
            _net.OnC2SPacket += Net_OnC2SPacket;

            _net.Messages.S2C.OnDDD_BeginDDDMessage += Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage += Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD += Messages_S2C_OnDDD_OnEndDDD;
        }

        private void Messages_S2C_OnDDD_BeginDDDMessage(object? sender, DDD_BeginDDDMessage e) {
            ExpectedBytes = e.DataExpected;
            IsPatching = true;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;

            _OnPatchProgress.Invoke(this, EventArgs.Empty);
            _OnProgressChanged.Invoke(this, EventArgs.Empty);
        }

        private void Messages_S2C_OnDDD_DataMessage(object? sender, DDD_DataMessage e) {
            ReceivedBytes += e.DataSize;
            PatchPercentage = (float)ReceivedBytes / (float)ExpectedBytes;

            _OnPatchProgress.Invoke(this, EventArgs.Empty);
            _OnProgressChanged.Invoke(this, EventArgs.Empty);
        }

        private void Messages_S2C_OnDDD_OnEndDDD(object? sender, DDD_OnEndDDD e) {
            PatchPercentage = 1f;
            IsPatching = false;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;

            _OnPatchProgress.Invoke(this, EventArgs.Empty);
            _OnProgressChanged.Invoke(this, EventArgs.Empty);
        }

        private void Net_OnS2CPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.ConnectRequest)) {
                ConnectPercentage = 1f;
                _net.OnS2CPacket -= Net_OnS2CPacket;

                _OnConnectProgress.Invoke(this, EventArgs.Empty);
                _OnProgressChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void Net_OnC2SPacket(object? sender, PacketEventArgs e) {
            if (e.Packet.Header.Flags.HasFlag(PacketHeaderFlags.LoginRequest)) {
                ConnectPercentage = 0.5f;
                _net.OnC2SPacket -= Net_OnC2SPacket;

                _OnConnectProgress.Invoke(this, EventArgs.Empty);
                _OnProgressChanged.Invoke(this, EventArgs.Empty);
            }
        }

        public void Dispose() {
            _net.OnS2CPacket -= Net_OnS2CPacket;
            _net.OnC2SPacket -= Net_OnC2SPacket;
            _net.Messages.S2C.OnDDD_BeginDDDMessage -= Messages_S2C_OnDDD_BeginDDDMessage;
            _net.Messages.S2C.OnDDD_DataMessage -= Messages_S2C_OnDDD_DataMessage;
            _net.Messages.S2C.OnDDD_OnEndDDD -= Messages_S2C_OnDDD_OnEndDDD;
        }
    }
}