using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages.S2C;
using MagicHat.Core.Backend;
using MagicHat.Core.Net;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;

namespace Core.UI.Models {
    public class CharSelectModel : UIDataModel {
        private readonly NetworkParser _net;
        private string _worldName = "";
        private uint _currentWorldConnections;
        private uint _maxWorldConnections;

        public string WorldName {
            get => _worldName;
            set {
                if (value != _worldName) {
                    _worldName = value;
                    InvokePropertyChange();
                }
            }
        }

        public uint CurrentWorldConnections {
            get => _currentWorldConnections;
            set {
                if (value != _currentWorldConnections) {
                    _currentWorldConnections = value;
                    InvokePropertyChange();
                }
            }
        }

        public uint MaxWorldConnections {
            get => _maxWorldConnections;
            set {
                if (value != _maxWorldConnections) {
                    _maxWorldConnections = value;
                    InvokePropertyChange();
                }
            }
        }

        public CharSelectModel(Context context, IMagicHatBackend backend, NetworkParser net, CoreUIPlugin plugin) : base("CharSelectScreen", context, plugin) {
            _net = net;
            _net.Messages.S2C.OnLogin_WorldInfo += Messages_S2C_OnLogin_WorldInfo;
        }

        private void Messages_S2C_OnLogin_WorldInfo(object? sender, Login_WorldInfo e) {
            WorldName = e.WorldName;
            CurrentWorldConnections = e.Connections;
            MaxWorldConnections = e.MaxConnections;

            _net.Messages.S2C.OnLogin_WorldInfo -= Messages_S2C_OnLogin_WorldInfo;
        }

        public override void Dispose() {
            _net.Messages.S2C.OnLogin_WorldInfo -= Messages_S2C_OnLogin_WorldInfo;
        }
    }
}
