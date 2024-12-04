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
using ACUI.Lib;
using Core.AC.API;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore, IScreenProvider<GameScreen>, IPanelProvider<GamePanel>, ISerializeState<PluginState> {
        private readonly Dictionary<GameScreen, string> _registeredGameScreens = [];
        private readonly Dictionary<GamePanel, string> _registeredGamePanels = [];
        private readonly Dictionary<GamePanel, string> _registeredCustomPanels = [];
        private PluginState _state;
        private Panel? _tooltip;

        internal static ILogger Log;
        internal static CoreACPlugin Instance;
        private TooltipModel _tooltipModel;

        internal CoreUIPlugin CoreUI { get; }
        internal NetworkParser Net { get; }
        internal IClientBackend ClientBackend { get; }

        JsonTypeInfo<PluginState> ISerializeState<PluginState>.TypeInfo => SourceGenerationContext.Default.PluginState;

        /// <summary>
        /// Client API entry point
        /// </summary>
        public Game Game => _state.Game;

        /// <summary>
        /// The current <see cref="GameScreen"/> being shown
        /// </summary>
        public GameScreen CurrentScreen {
            get => _state.CurrentScreen;
            set => SetScreen(value);
        }

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
            _tooltipModel = new TooltipModel();

            CoreUI.RegisterUIModel("CharSelectScreen", _state.CharSelectModel);
            CoreUI.RegisterUIModel("DatPatchScreen", _state.DatPatchModel);
            CoreUI.RegisterUIModel("Tooltip", _tooltipModel);

            RegisterScreen(GameScreen.CharSelect, Path.Combine(AssemblyDirectory, "assets", "screens", "CharSelect.rml"));
            RegisterScreen(GameScreen.DatPatch, Path.Combine(AssemblyDirectory, "assets", "screens", "DatPatch.rml"));


            //RegisterPanel(GamePanel.Logs, Path.Combine(AssemblyDirectory, "assets", "panels", "Test.rml"));

            ClientBackend.OnScreenChanged += ClientBackend_OnScreenChanged;

            _tooltip = RegisterPanel(GamePanel.Tooltip, Path.Combine(AssemblyDirectory, "assets", "panels", "Tooltip.rml"));
            ClientBackend.OnShowTooltip += ClientBackend_OnShowTooltip;
            ClientBackend.OnHideTooltip += ClientBackend_OnHideTooltip;

            SetScreen(_state.CurrentScreen, true);
        }

        private void ClientBackend_OnShowTooltip(object? sender, ShowTooltipEventArgs e) {
            if (_tooltip is null) return;
            _tooltip.ScriptableDocument?.LuaContext.SetGlobal("tooltip", e);
            var x = (ClientBackend as IChoriziteBackend)?.Input.MouseX + 15;
            var y = (ClientBackend as IChoriziteBackend)?.Input.MouseY;
            _tooltip.ScriptableDocument?.SetAttribute("style", "left: " + x + "px; top: " + y + "px;");
            _tooltip.Show();

            e.Eat = true;
        }

        private void ClientBackend_OnHideTooltip(object? sender, EventArgs e) {
            //_tooltip?.Hide();
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
        PluginState ISerializeState<PluginState>.SerializeBeforeUnload() => _state;

        void ISerializeState<PluginState>.DeserializeAfterLoad(PluginState? state) {
            _state = state ?? new PluginState();
            _state.CharSelectModel ??= new CharSelectScreenModel();
            _state.DatPatchModel ??= new DatPatchScreenModel();
            _state.Game ??= new Game();

            Log.LogDebug($"Initializing CoreACPlugin: {Game.AccountName} // {Game.ServerName} // {Game.State}");

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
        public bool RegisterPanelFromString(string panelName, string rmlContents) {
            _registeredCustomPanels.TryAdd(CustomPanelFromName(panelName), panelName);
            return RegisterPanelFromString(CustomPanelFromName(panelName), rmlContents);
        }

        public bool RegisterPanelFromString(GamePanel panel, string rmlContents) {
            if (_registeredGamePanels.TryGetValue(panel, out var existingRmlPath)) {
                CoreUI.UnregisterPanel(panel.ToString(), existingRmlPath);
                _registeredGamePanels[panel] = rmlContents;
            }
            else {
                _registeredGamePanels.Add(panel, rmlContents);
            }

            var panelName = panel.ToString();
            if (_registeredCustomPanels.TryGetValue(panel, out var customPanelName)) {
                panelName = customPanelName;
            }

            return CoreUI.RegisterPanelFromString(panelName, rmlContents);
        }

         /// <inheritdoc/>
        public Panel? RegisterPanel(GamePanel panel, string rmlPath) {
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
        public void UnregisterPanel(GamePanel panel, string? rmlPath) {
            _registeredGamePanels.Remove(panel);

            var panelName = panel.ToString();
            if (_registeredCustomPanels.TryGetValue(panel, out var customPanelName)) {
                panelName = customPanelName;
            }

            CoreUI.UnregisterPanel(panelName, rmlPath);
        }

        /// <inheritdoc/>
        public GamePanel CustomPanelFromName(string name) {
            var customGamePanel = GamePanelHelpers.FromString(name);
            if (!_registeredCustomPanels.ContainsKey(customGamePanel)) {
                _registeredCustomPanels.Add(customGamePanel, name);
            }
            return customGamePanel;
        }

        /// <inheritdoc/>
        public bool IsPanelVisible(GamePanel panel) => CoreUI.IsPanelVisible(panel.ToString());

        /// <inheritdoc/>
        public void TogglePanelVisibility(GamePanel panel, bool visible) => CoreUI.TogglePanelVisibility(panel.ToString(), visible);
        #endregion // PanelProvider

        protected override void Dispose() {
            ClientBackend.OnScreenChanged -= ClientBackend_OnScreenChanged;
            ClientBackend.OnShowTooltip -= ClientBackend_OnShowTooltip;
            ClientBackend.OnHideTooltip -= ClientBackend_OnHideTooltip;

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
            CoreUI.UnregisterUIModel("Tooltip", _tooltipModel);

            _state.CharSelectModel.Dispose();
            _state.DatPatchModel.Dispose();
            _tooltipModel.Dispose();

            Game.Dispose();
            Instance = null!;
        }
    }
}
