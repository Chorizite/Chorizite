using Chorizite.ACProtocol.Messages.C2S;
using Chorizite.ACProtocol.Messages.C2S.Actions;
using Chorizite.ACProtocol.Messages.S2C;
using Chorizite.Common;
using Chorizite.Core.Net;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public string ServerName { get; set; } = "";

        /// <summary>
        /// The name of the account this client is connected as
        /// </summary>
        public string AccountName { get; set; } = "";

        /// <summary>
        /// Maximum number of allowed characters on this server
        /// </summary>
        public uint MaxAllowedCharacters { get; set; } = 0;

        /// <summary>
        /// Information about connection / patch progress.
        /// </summary>
        public PatchProgress PatchProgress { get; set; } = new();

        /// <summary>
        /// The current state of the client. Use this to check if you are logged in
        /// </summary>
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
        /// A list of characters on the account. Only valid if <see cref="State"> is greater than <see cref="ClientState.CharacterSelect"/>
        /// </summary>
        public List<CharacterIdentity> Characters { get; set; } = [];

        /// <summary>
        /// The currently logged in character. This data will be invalid if the client is not logged in.
        /// </summary>
        public Character Character { get; set; } = new();

        /// <summary>
        /// Information about the world around your character. This data will only be valid if the client is logged in.
        /// </summary>
        public World World { get; set; } = new();

        /// <summary>
        /// Fired when client state changes. See <see cref="ClientState"/> for a list of valid states.
        /// </summary>
        public event EventHandler<GameStateChangedEventArgs> OnStateChanged {
            add => _OnStateChanged.Subscribe(value);
            remove => _OnStateChanged.Unsubscribe(value);
        }
        private WeakEvent<GameStateChangedEventArgs> _OnStateChanged = new();

        /// <summary>
        /// Fired when your list of characters changes
        /// </summary>
        public event EventHandler<EventArgs> OnCharactersChanged {
            add => _OnCharactersChanged.Subscribe(value);
            remove => _OnCharactersChanged.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnCharactersChanged = new();

        public Game() {
            _log = CoreACPlugin.Log;
            _net = CoreACPlugin.Instance.Net;

            _net.S2C.OnLogin_WorldInfo += OnLogin_WorldInfo;
            _net.S2C.OnLogin_LoginCharacterSet += OnLogin_LoginCharacterSet;
            _net.C2S.OnLogin_SendEnterWorld += OnLogin_SendEnterWorld;
            _net.S2C.OnLogin_LogOffCharacter += OnLogin_LogOffCharacter;
            _net.C2S.OnCharacter_LoginCompleteNotification += OnCharacter_LoginCompleteNotification;

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

            Characters.Clear();
            Characters.AddRange(characters);

            State = ClientState.CharacterSelect;
            _OnCharactersChanged?.Invoke(this, EventArgs.Empty);
        }

        private void OnLogin_SendEnterWorld(object? sender, Login_SendEnterWorld e) {
            State = ClientState.EnteringGame;
        }

        private void OnCharacter_LoginCompleteNotification(object? sender, Character_LoginCompleteNotification e) {
            // this gets fired every time you exit portal space, not just after logging in
            if (State != ClientState.InGame) {
                State = ClientState.InGame;
            }
        }

        private void OnLogin_LogOffCharacter(object? sender, Chorizite.ACProtocol.Messages.S2C.Login_LogOffCharacter e) {
            State = ClientState.LoggingOut;
        }
        #endregion // Event Handlers

        public void Dispose() {
            _net.S2C.OnLogin_WorldInfo -= OnLogin_WorldInfo;
            _net.S2C.OnLogin_LoginCharacterSet -= OnLogin_LoginCharacterSet;
            _net.C2S.OnLogin_SendEnterWorld -= OnLogin_SendEnterWorld;
            _net.S2C.OnLogin_LogOffCharacter -= OnLogin_LogOffCharacter;
            _net.C2S.OnCharacter_LoginCompleteNotification -= OnCharacter_LoginCompleteNotification;
            
            PatchProgress?.Dispose();
            Character?.Dispose();
            World?.Dispose();
        }
    }
}
