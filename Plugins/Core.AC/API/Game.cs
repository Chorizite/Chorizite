using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Common;
using Chorizite.Core.Net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.AC.API {
    /// <summary>
    /// The main game api entry point
    /// </summary>
    public class Game : IDisposable {
        private ClientState _clientState = ClientState.Initial;
        private readonly ILogger _log;
        private readonly NetworkParser _net;

        /// <summary>
        /// The name of this server
        /// </summary>
        [JsonInclude]
        public string ServerName { get; internal set; } = "";

        /// <summary>
        /// The name of the account this client is connected as
        /// </summary>
        [JsonInclude]
        public string AccountName { get; internal set; } = "";

        /// <summary>
        /// Maximum number of allowed characters on this server
        /// </summary>
        [JsonInclude]
        public uint MaxAllowedCharacters { get; internal set; } = 0;

        /// <summary>
        /// The current state of the client. Use this to check if you are logged in
        /// </summary>
        [JsonInclude]
        public ClientState State {
            get => _clientState;
            set {
                if (value != _clientState) {
                    var oldState = _clientState;
                    _clientState = value;
                    _OnStateChanged?.Invoke(this, new GameStateChangedEventArgs(_clientState, oldState));
                }
            }
        }

        /// <summary>
        /// Fired when client state changes. See <see cref="ClientState"/> for a list of valid states.
        /// </summary>
        public event EventHandler<GameStateChangedEventArgs> OnStateChanged {
            add => _OnStateChanged.Subscribe(value);
            remove => _OnStateChanged.Unsubscribe(value);
        }
        private WeakEvent<GameStateChangedEventArgs> _OnStateChanged = new();

        public Game() {
            _log = CoreACPlugin.Log;
            _net = CoreACPlugin.Instance.Net;

            _net.S2C.OnLogin_WorldInfo += OnLogin_WorldInfo;
            _net.S2C.OnLogin_LoginCharacterSet += OnLogin_LoginCharacterSet;

            State = ClientState.GameStarted;
        }

        #region Event Handlers
        private void OnLogin_WorldInfo(object? sender, Login_WorldInfo e) {
            ServerName = e.WorldName;
        }

        private void OnLogin_LoginCharacterSet(object? sender, Login_LoginCharacterSet e) {
            AccountName = e.Account;
            MaxAllowedCharacters = e.NumAllowedCharacters;
            var characters = e.Characters.Select(c => new CharacterIdentity(c)).Cast<CharacterIdentity>().ToList();
            characters.Sort((a, b) => a.Name.CompareTo(b.Name));

            State = ClientState.CharacterSelect;
        }
        #endregion // Event Handlers

        public void Dispose() {
            _net.S2C.OnLogin_WorldInfo -= OnLogin_WorldInfo;
            _net.S2C.OnLogin_LoginCharacterSet -= OnLogin_LoginCharacterSet;
        }
    }
}
