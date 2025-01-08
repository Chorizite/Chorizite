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
using ACUI.Lib;
using Core.AC.API;
using Chorizite.Core.Dats;

namespace Core.AC {
    public class CoreACPlugin : IPluginCore, IScreenProvider<GameScreen>, ISerializeState<PluginState> {
        private readonly Dictionary<GameScreen, string> _registeredGameScreens = [];
        private PluginState _state;
        private Panel? _indicatorPanel;
        private Panel? _tooltip;

        internal static ILogger Log;
        internal static CoreACPlugin Instance;

        internal CoreUIPlugin CoreUI { get; }
        internal NetworkParser Net { get; }
        internal IClientBackend ClientBackend { get; }
        internal IChoriziteBackend ChoriziteBackend { get; }
        internal IDatReaderInterface Dat { get; }
        internal DragDropManager DragDropManager { get; private set; }

        JsonTypeInfo<PluginState> ISerializeState<PluginState>.TypeInfo => SourceGenerationContext.Default.PluginState;
        
        /// <summary>
        /// Client API entry point
        /// </summary>
        public Game Game => _state?.Game;

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

        protected CoreACPlugin(AssemblyPluginManifest manifest, IChoriziteBackend choriziteBackend, IClientBackend clientBackend, IPluginManager pluginManager, NetworkParser net, CoreUIPlugin coreUI, IDatReaderInterface dat, ILogger log) : base(manifest) {
            Instance = this;
            Log = log;
            Net = net;
            CoreUI = coreUI;
            ClientBackend = clientBackend;
            ChoriziteBackend = choriziteBackend;
            Dat = dat;

            // since this plugin is ISerializeState<ACState>, we wait to do full initialization until after loading state.
            // ISerializeState{ACState}.DeserializeAfterLoad(ACState?) is now responsible for calling Init()
        }

        private void Init() {
            DragDropManager = new DragDropManager();

            ChoriziteBackend.RegisterLuaModule("ac", Game);
            CoreUI.RegisterUIModel("Tooltip", _state.TooltipModel);

            RegisterScreen(GameScreen.CharSelect, Path.Combine(AssemblyDirectory, "assets", "screens", "CharSelect.rml"));
            RegisterScreen(GameScreen.DatPatch, Path.Combine(AssemblyDirectory, "assets", "screens", "DatPatch.rml"));

            ClientBackend.UIBackend.OnScreenChanged += ClientBackend_OnScreenChanged;

            //_tooltip = RegisterPanel(GamePanel.Tooltip, Path.Combine(AssemblyDirectory, "assets", "panels", "Tooltip.rml"));
            ClientBackend.UIBackend.OnShowTooltip += ClientBackend_OnShowTooltip;
            ClientBackend.UIBackend.OnHideTooltip += ClientBackend_OnHideTooltip;

            ClientBackend.UIBackend.OnShowRootElement += ClientBackend_OnShowRootElement;
            ClientBackend.UIBackend.OnHideRootElement += ClientBackend_OnHideRootElement;

            SetScreen(_state.CurrentScreen, true);

            if (Game.State == ClientState.InGame) {
                ShowIndicatorsPanel();
            }
        }

        private void ClientBackend_OnShowRootElement(object? sender, ToggleElementVisibleEventArgs e) {
            if (e.ElementId == Chorizite.Common.Enums.RootElementId.Indicators) {
                if (ShowIndicatorsPanel()) {
                    e.Eat = true;
                }
            }
        }

        private bool ShowIndicatorsPanel() {
            _indicatorPanel ??= CoreUI.CreatePanel("Core.AC.Indicators", Path.Combine(AssemblyDirectory, "assets", "panels", "Indicators.rml"));
            if (_indicatorPanel is not null) {
                _indicatorPanel.Show();
                return true;
            }
            return false;
        }

        private void ClientBackend_OnHideRootElement(object? sender, ToggleElementVisibleEventArgs e) {
            if (e.ElementId == Chorizite.Common.Enums.RootElementId.Indicators) {
                e.Eat = true;
                _indicatorPanel?.Dispose();
                _indicatorPanel = null;
            }
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

        #region State / Settings Serialization
        PluginState ISerializeState<PluginState>.SerializeBeforeUnload() => _state;

        void ISerializeState<PluginState>.DeserializeAfterLoad(PluginState? state) {
            _state = state ?? new PluginState();
            _state.TooltipModel ??= new TooltipModel();
            _state.Game ??= new Game();
            
            Init();
        }
        #endregion // State / Settings Serialization

        #region ScreenProvider
        private void SetScreen(GameScreen value, bool force = false) {
            // TODO: validate screen transitions
            if (force || _state.CurrentScreen != value) {
                var oldScreen = _state.CurrentScreen;
                _state.CurrentScreen = value;
                CoreUI.Screen = _state.CurrentScreen.ToString();

                _OnScreenChanged?.Invoke(this, new ScreenChangedEventArgs(oldScreen, _state.CurrentScreen));
            }
        }
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

        protected override void Dispose() {
            ClientBackend.UIBackend.OnScreenChanged -= ClientBackend_OnScreenChanged;
            ClientBackend.UIBackend.OnShowTooltip -= ClientBackend_OnShowTooltip;
            ClientBackend.UIBackend.OnHideTooltip -= ClientBackend_OnHideTooltip;
            ClientBackend.UIBackend.OnShowRootElement -= ClientBackend_OnShowRootElement;
            ClientBackend.UIBackend.OnHideRootElement -= ClientBackend_OnHideRootElement;

            ChoriziteBackend.UnregisterLuaModule("ac");
            DragDropManager.Dispose();
            CoreUI.Screen = "None";

            foreach (var screen in _registeredGameScreens) {
                UnregisterScreen(screen.Key, screen.Value);
            }
            _registeredGameScreens.Clear();

            _indicatorPanel?.Dispose();
            _indicatorPanel = null;

            CoreUI.UnregisterUIModel("Tooltip", _state.TooltipModel);

            _state.TooltipModel.Dispose();
            Game?.Dispose();

            _state = null;
            Instance = null!;
        }
    }
}