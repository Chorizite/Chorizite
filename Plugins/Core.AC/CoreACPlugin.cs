using System.IO;
using System;
using Microsoft.Extensions.Logging;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Core.AC.Lib;
using Chorizite.Core.Net;
using Chorizite.ACProtocol;
using Core.UI;
using Core.AC.UIModels;
using Chorizite.Core.Render;
using System.Collections.Generic;
using System.Xml.Linq;
using Core.UI.Lib;
using Chorizite.Core.Backend;
using Chorizite.Core.Input;
using Chorizite.Common;
using System.Text.Json.Serialization.Metadata;
using Core.AC.Lib.Screens;
using Core.AC.Lib.Panels;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore, IScreenProvider<GameScreen>, IPanelProvider<GamePanel>, ISerializeState<ACState> {
        private readonly Dictionary<GameScreen, string> _registeredGameScreens = [];
        private readonly Dictionary<GamePanel, string> _registeredGamePanels = [];
        private ACState _state;

        internal static ILogger Log;
        internal static CoreACPlugin Instance;
        internal CoreUIPlugin CoreUI { get; }
        internal NetworkParser Net { get; }
        internal IClientBackend ClientBackend { get; }

        public GameInterface Game { get; private set; }

        public GameScreen CurrentScreen {
            get => _state.CurrentScreen;
            set => SetScreen(value);
        }

        JsonTypeInfo<ACState> ISerializeState<ACState>.TypeInfo => SourceGenerationContext.Default.ACState;

        /// <summary>
        /// Screen changed
        /// </summary>
        public event EventHandler<ScreenChangedEventArgs> OnScreenChanged {
            add { _OnScreenChanged.Subscribe(value); }
            remove { _OnScreenChanged.Unsubscribe(value); }
        }
        private readonly WeakEvent<ScreenChangedEventArgs> _OnScreenChanged = new();

        protected CoreACPlugin(AssemblyPluginManifest manifest, IClientBackend clientBackend, IPluginManager pluginManager, NetworkParser net, CoreUIPlugin coreUI, ILogger log) : base(manifest) {
            Instance = this;
            Log = log;
            Net = net;
            CoreUI = coreUI;
            ClientBackend = clientBackend;

            // since this plugin is ISerializeState<ACState>, we wait to do full initialization until after loading state.
            // ISerializeState{ACState}.DeserializeAfterLoad(ACState?) is now responsible for calling Init()
        }

        private void Init() {
            Game = new GameInterface(Log, Net.Messages);

            CoreUI.RegisterUIModel("CharSelectScreen", _state.CharSelectModel);
            CoreUI.RegisterUIModel("DatPatchScreen", _state.DatPatchModel);

            RegisterScreen(GameScreen.CharSelect, Path.Combine(AssemblyDirectory, "assets", "screens", "CharSelect.rml"));
            RegisterScreen(GameScreen.DatPatch, Path.Combine(AssemblyDirectory, "assets", "screens", "DatPatch.rml"));

            //RegisterPanel(GamePanel.Logs, Path.Combine(AssemblyDirectory, "assets", "panels", "Logs.rml"));

            ClientBackend.OnScreenChanged += ClientBackend_OnScreenChanged;

            SetScreen(_state.CurrentScreen, true);
        }

        private void SetScreen(GameScreen value, bool force = false) {
            // TODO: validate screen transitions
            if (force || _state.CurrentScreen != value) {
                var oldScreen = _state.CurrentScreen;
                _state.CurrentScreen = value;
                CoreUI.Screen = _state.CurrentScreen.ToString();
                _OnScreenChanged?.Invoke(this, new ScreenChangedEventArgs(oldScreen, _state.CurrentScreen));
            }
        }

        #region State / Settings Serialization
        ACState ISerializeState<ACState>.SerializeBeforeUnload() => _state;

        void ISerializeState<ACState>.DeserializeAfterLoad(ACState? state) {
            _state = state ?? new ACState();
            _state.CharSelectModel ??= new CharSelectScreenModel();
            _state.DatPatchModel ??= new DatPatchScreenModel();

            Init();
        }
        #endregion // State / Settings Serialization

        #region ScreenProvider
        private void ClientBackend_OnScreenChanged(object? sender, EventArgs e) {
            CurrentScreen = (GameScreen)ClientBackend.GameScreen;
        }

        /// <inheritdoc/>
        public bool RegisterScreen(GameScreen screen, string rmlPath) {
            if (_registeredGameScreens.ContainsKey(screen)) {
                _registeredGameScreens[screen] = rmlPath;
            }
            else {
                _registeredGameScreens.Add(screen, rmlPath);
            }

            return CoreUI.RegisterScreen(screen.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public void UnregisterScreen(GameScreen screen, string rmlPath) {
            if (_registeredGameScreens.TryGetValue(screen, out var rmlFile) && rmlFile == rmlPath) {
                _registeredGameScreens.Remove(screen);
            }

            CoreUI.UnregisterScreen(screen.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public GameScreen CustomScreenFromName(string name) => GameScreenHelpers.FromString(name);
        #endregion // ScreenProvider

        #region PanelProvider
        /// <inheritdoc/>
        public bool RegisterPanel(GamePanel panel, string rmlPath) {
            if (_registeredGamePanels.TryGetValue(panel, out var existingRmlPath)) {
                CoreUI.UnregisterPanel(panel.ToString(), existingRmlPath);
                _registeredGamePanels[panel] = rmlPath;
            }
            else {
                _registeredGamePanels.Add(panel, rmlPath);
            }

            return CoreUI.RegisterPanel(panel.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public void UnregisterPanel(GamePanel panel, string rmlPath) {
            if (_registeredGamePanels.TryGetValue(panel, out var rmlFile) && rmlFile == rmlPath) {
                _registeredGamePanels.Remove(panel);
            }

            CoreUI.UnregisterPanel(panel.ToString(), rmlPath);
        }

        /// <inheritdoc/>
        public GamePanel CustomPanelFromName(string name) => GamePanelHelpers.FromString(name);

        /// <inheritdoc/>
        public bool IsPanelVisible(GamePanel panel) => CoreUI.IsPanelVisible(panel.ToString());

        /// <inheritdoc/>
        public void TogglePanelVisibility(GamePanel panel, bool visible) => CoreUI.TogglePanelVisibility(panel.ToString(), visible);
        #endregion // PanelProvider

        protected override void Dispose() {
            ClientBackend.OnScreenChanged -= ClientBackend_OnScreenChanged;

            CoreUI.Screen = "None";

            foreach (var screen in _registeredGameScreens) {
                UnregisterScreen(screen.Key, screen.Value);
            }
            _registeredGameScreens.Clear();

            foreach (var panel in _registeredGamePanels) {
                UnregisterPanel(panel.Key, panel.Value);
            }
            _registeredGamePanels.Clear();

            CoreUI.UnregisterUIModel("CharSelectScreen", _state.CharSelectModel);
            CoreUI.UnregisterUIModel("DatPatchScreen", _state.DatPatchModel);

            _state.CharSelectModel.Dispose();
            _state.DatPatchModel.Dispose();

            Game.Dispose();
            Instance = null!;
        }
    }
}
