using Core.AC.Lib;
using Core.UI.Models;
using MagicHat.ACProtocol;
using MagicHat.ACProtocol.Enums;
using MagicHat.ACProtocol.Messages.S2C;
using MagicHat.Core.Backend;
using MagicHat.Core.Net;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Core.AC.UIModels {
    public class CharSelectScreenModel : UIDataModel {
        private readonly NetworkParser _net;

        public class CharacterInfo : UIDataSubModel {
            public DataVariable<uint> Id { get; } = new(0);
            public DataVariable<string> Name { get; } = new("");
            public DataVariable<uint> TimeToDeletion { get; } = new(0);

            public CharacterInfo() : base() {

            }

            public CharacterInfo(uint id, string name, uint timeToDeletion = 0) : base() {
                Id.Value = id;
                Name.Value = name;
                TimeToDeletion.Value = timeToDeletion;
            }
        }

        public DataVariable<string> WorldName { get; } = new("");
        public DataVariable<uint> MaxConnections { get; } = new(0);
        public DataVariable<uint> CurrentConnections { get; } = new(0);
        public DataVariable<CharacterInfo> SelectedCharacter { get; } = new(new CharacterInfo(0, ""));
        public DataVariableList<CharacterInfo> Characters { get; } = new([]);

        private bool _showingModal = false;

        public CharSelectScreenModel() : base() {
            _net = CoreACPlugin.Instance.Net;

            _net.Messages.S2C.OnLogin_WorldInfo += Messages_S2C_OnLogin_WorldInfo;
            _net.Messages.S2C.OnLogin_LoginCharacterSet += Messages_S2C_OnLogin_LoginCharacterSet;
        }

        public override void Init(string name) {
            base.Init(name);

            BindAction("create_character", (evt, variants) => {
                CoreACPlugin.Instance.ClientBackend.GameScreen = (int)GameScreen.CharCreate;
            });

            BindAction("show_credits", (evt, variants) => {
                CoreACPlugin.Instance.ClientBackend.GameScreen = (int)GameScreen.Credits;
            });

            BindAction("exit", (evt, variants) => {
                CoreACPlugin.Instance.ClientBackend.Exit();
            });

            BindAction("enter_game", (evt, variants) => {
                if (variants.First().Value is uint characterId) {
                    CoreACPlugin.Instance.ClientBackend.EnterGame(characterId);
                }
            });

            BindAction("select", (evt, variants) => {
                if (variants.Count() == 1 && variants.FirstOrDefault()?.Type == VariantType.UINT) {
                    var character = Characters.Value.FirstOrDefault(c => c.Id.Value == (uint)variants.First().Value!);
                    if (character is not null) {
                        SelectedCharacter.Value.Name.Value = character.Name.Value;
                        SelectedCharacter.Value.Id.Value = character.Id.Value;
                        _modelConstructor.Handle.DirtyAllVariables();
                    }
                }
            });
        }

        private void Messages_S2C_OnLogin_LoginCharacterSet(object? sender, Login_LoginCharacterSet e) {
            Characters.Value.Clear();
            foreach (var character in e.Characters) {
                Characters.Value.Add(new CharacterInfo(character.CharacterId, character.Name, character.SecondsGreyedOut));
            }
            var firstCharacter = Characters.Value.FirstOrDefault();
            if (firstCharacter is not null) {
                SelectedCharacter.Value.Name.Value = firstCharacter.Name.Value;
                SelectedCharacter.Value.Id.Value = firstCharacter.Id.Value;
            }
        }

        private void Messages_S2C_OnLogin_WorldInfo(object? sender, Login_WorldInfo e) {
            WorldName.Value = e.WorldName;
            CurrentConnections.Value = e.Connections;
            MaxConnections.Value = e.MaxConnections;

            _net.Messages.S2C.OnLogin_WorldInfo -= Messages_S2C_OnLogin_WorldInfo;
        }

        public override void Dispose() {
            _net.Messages.S2C.OnLogin_WorldInfo -= Messages_S2C_OnLogin_WorldInfo;
            _net.Messages.S2C.OnLogin_LoginCharacterSet -= Messages_S2C_OnLogin_LoginCharacterSet;
            foreach (var character in Characters.Value) {
                character.Dispose();
            }
            base.Dispose();
        }
    }
}
