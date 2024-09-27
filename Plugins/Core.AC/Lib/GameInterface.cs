using Core.AC.Lib.Enums;
using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Messages.C2S;
using MagicHat.ACProtocol.Messages.C2S.Actions;
using MagicHat.ACProtocol.Messages.S2C;
using MagicHat.ACProtocol.Messages.S2C.Events;
using MagicHat.ACProtocol.Types;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AC.Lib {

    public class GameInterface : IDisposable {
        private readonly ILogger _log;
        private GameState _gameState = GameState.Initial;
        private bool _gotWorldInfo;
        private bool _gotCharacterList;
        private readonly List<CharacterIdentity> _characters = [];
        private readonly MessageReader _messageReader;

        /// <summary>
        /// Fired when client state changes. See [ClientState](xref:UBScript.Enums.ClientState) for a list of valid states.
        /// </summary>
        public event EventHandler<GameStateChangedEventArgs> OnStateChanged;

        /// <summary>
        /// Fired every frame, during 3D rendering
        /// </summary>
        public event EventHandler<EventArgs> OnRender3D;

        /// <summary>
        /// A list of characters available on the character select screen.
        /// </summary>
        public IReadOnlyList<CharacterIdentity> Characters => _characters;

        /// <summary>
        /// The name of this server
        /// </summary>
        public string ServerName { get; private set; } = "";

        /// <summary>
        /// The name of the account this client is connected as
        /// </summary>
        public string AccountName { get; private set; } = "";

        /// <summary>
        /// Maximum number of allowed characters on this server
        /// </summary>
        public uint MaxAllowedCharacters { get; private set; } = 0;

        /// <summary>
        /// The current state of the client. Use this to check if you are logged in
        /// </summary>
        public virtual GameState State {
            get => _gameState;
            internal set {
                if (value != _gameState) {
                    _gameState = value;
                    OnStateChanged?.Invoke(this, new GameStateChangedEventArgs(State));
                }
            }
        }

        public GameInterface(ILogger logger, MessageReader messageReader) {
            _messageReader = messageReader;
            _log = logger;

            _messageReader.S2C.OnLogin_LoginCharacterSet += MessageHandler_Login_LoginCharacterSet_S2C;
            _messageReader.S2C.OnLogin_WorldInfo += MessageHandler_Login_WorldInfo_S2C;
            _messageReader.S2C.OnLogin_PlayerDescription += MessageHandler_Login_PlayerDescription_S2C;
            _messageReader.C2S.OnLogin_SendEnterWorld += MessageHandler_Login_SendEnterWorld_C2S;
            _messageReader.S2C.OnLogin_LogOffCharacter += MessageHandler_Login_LogOffCharacter_S2C;
            _messageReader.C2S.OnCharacter_LoginCompleteNotification += MessageHandler_Character_LoginCompleteNotification_C2S;
        }

        #region public api
        //public Hud CreateHud(string name) {
        //    return null;
        //return UBService.UBService.Huds.CreateHud(name);
        //}
        #endregion // public api

        internal void Render3D() {
            OnRender3D?.Invoke(this, EventArgs.Empty);
        }

        #region Message Handlers
        protected virtual void MessageHandler_Character_LoginCompleteNotification_C2S(object sender, Character_LoginCompleteNotification e) {
            // this gets fired every time you exit portal space, not just after logging in
            if (State != GameState.InGame)
                State = GameState.InGame;
        }

        protected virtual void MessageHandler_Login_LogOffCharacter_S2C(object sender, MagicHat.ACProtocol.Messages.S2C.Login_LogOffCharacter e) {
            State = GameState.LoggingOut;
        }

        protected virtual void MessageHandler_Login_SendEnterWorld_C2S(object sender, Login_SendEnterWorld e) {
            State = GameState.LoggingIn;
        }

        protected virtual void MessageHandler_Login_PlayerDescription_S2C(object sender, Login_PlayerDescription e) {
            State = GameState.PlayerDescReceived;
        }


        private void MessageHandler_Login_WorldInfo_S2C(object sender, Login_WorldInfo e) {
            ServerName = e.WorldName;
            _gotWorldInfo = true;
            if (_gotCharacterList) {
                State = GameState.CharacterSelect;
            }
        }

        private void MessageHandler_Login_LoginCharacterSet_S2C(object sender, Login_LoginCharacterSet e) {
            AccountName = e.Account;
            MaxAllowedCharacters = e.NumAllowedCharacters;
            var characters = e.Characters.ToList();
            characters.Sort((a, b) => a.Name.CompareTo(b.Name));
            _characters.Clear();
            _characters.AddRange(characters);

            // we have to delay here, there is a client bug where if you login too quickly the client stays
            // at the char select screen, but still logs in a character...

            /*
            var start = DateTime.UtcNow;
            EventHandler<EventArgs> gameState_OnTick = null;
            gameState_OnTick = (s, e) => {
                if (DateTime.UtcNow - start > TimeSpan.FromMilliseconds(1000)) {
                    OnTick -= gameState_OnTick;
                    State = ClientState.Character_Select_Screen;
                }
            };

            OnTick += gameState_OnTick;
            */
            _gotCharacterList = true;
            if (_gotWorldInfo) {
                State = GameState.CharacterSelect;
            }

        }
        #endregion // Message Handlers

        /// <summary>
        /// Cleans up. Only the script manager should call this, not individual scripts.
        /// </summary>
        public virtual void Dispose() {
            _messageReader.S2C.OnLogin_LoginCharacterSet -= MessageHandler_Login_LoginCharacterSet_S2C;
            _messageReader.S2C.OnLogin_WorldInfo -= MessageHandler_Login_WorldInfo_S2C;
            _messageReader.S2C.OnLogin_PlayerDescription -= MessageHandler_Login_PlayerDescription_S2C;
            _messageReader.C2S.OnLogin_SendEnterWorld -= MessageHandler_Login_SendEnterWorld_C2S;
            _messageReader.S2C.OnLogin_LogOffCharacter -= MessageHandler_Login_LogOffCharacter_S2C;
            _messageReader.C2S.OnCharacter_LoginCompleteNotification -= MessageHandler_Character_LoginCompleteNotification_C2S;
        }
    }
}
