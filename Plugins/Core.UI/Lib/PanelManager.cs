using ACUI.Lib.RmlUi;
using Chorizite.Common;
using Chorizite.Core.Lua;
using Chorizite.Core.Render;
using Core.UI;
using Core.UI.Lib;
using Core.UI.Lib.Fonts;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using XLua;

namespace ACUI.Lib {
    /// <summary>
    /// Manages panels and screens
    /// </summary>
    public class PanelManager : IDisposable {
        private readonly Dictionary<string, Panel> _panels = []; // <filename, panel>
        private Screen? _currentScreen = null;
        private Panel? _currentModal = null;
        internal IDictionary<string, object>? _externalDragDropEventData;
        private readonly IRenderInterface Render;
        private readonly ACSystemInterface _rmlSystemInterface;
        private readonly Context Context;
        private readonly ILogger Log;

        public Screen? CurrentScreen => _currentScreen;
        public Panel? CurrentModal => _currentModal;

        public List<Panel> Panels => _panels.Values.ToList();

        public event EventHandler<PanelAddedEventArgs> OnPanelAdded {
            add => _OnPanelAdded.Subscribe(value);
            remove => _OnPanelAdded.Unsubscribe(value);
        }
        private WeakEvent<PanelAddedEventArgs> _OnPanelAdded = new();

        public event EventHandler<PanelRemovedEventArgs> OnPanelRemoved {
            add => _OnPanelRemoved.Subscribe(value);
            remove => _OnPanelRemoved.Unsubscribe(value);
        }
        private WeakEvent<PanelRemovedEventArgs> _OnPanelRemoved = new();

        public event EventHandler<PanelVisibilityChangedEventArgs> OnPanelVisibilityChanged {
            add => _OnPanelVisibilityChanged.Subscribe(value);
            remove => _OnPanelVisibilityChanged.Unsubscribe(value);
        }
        private WeakEvent<PanelVisibilityChangedEventArgs> _OnPanelVisibilityChanged = new();

        internal PanelManager(Context ctx, ACSystemInterface rmlSystemInterface, IRenderInterface render, ILogger log) {
            Log = log;
            Context = ctx;
            Render = render;
            _rmlSystemInterface = rmlSystemInterface;

            Render.OnGraphicsPreReset += Render_OnGraphicsPreReset;
            Render.OnGraphicsPostReset += Render_OnGraphicsPostReset;
        }

        private void Render_OnGraphicsPreReset(object? sender, EventArgs e) {
            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.HandleGraphicsPreReset();
            }
        }

        private void Render_OnGraphicsPostReset(object? sender, EventArgs e) {
            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.HandleGraphicsPostReset();
            }
        }

        public void SetExternalDragDropEventData(Dictionary<string, object> data) {
            foreach (var kv in data) {
                if (_externalDragDropEventData is null) {
                    _externalDragDropEventData = new Dictionary<string, object>(data.Count);
                }
                if (!_externalDragDropEventData.TryAdd(kv.Key, kv.Value)) {
                    _externalDragDropEventData[kv.Key] = kv.Value;
                }
            }
            _externalDragDropEventData = data;
        }

        public void ClearExternalDragDropEventData(Dictionary<string, object> data) {
            if (_externalDragDropEventData is not null) {
                foreach (var kv in data) {
                    _externalDragDropEventData.Remove(kv.Key);
                }
            }
        }

        public Screen? GetScreen() => _currentScreen;

        /// <summary>
        /// Create a screen
        /// </summary>
        /// <param name="name">The name of the screen</param>
        /// <param name="rmlFilePath">The path to the rml file</param>
        /// <returns></returns>
        public Screen CreateScreen(string name, string rmlFilePath) {
            if (_currentScreen is not null) {
                DestroyScreen();
            }

            return _currentScreen = new Screen(name, rmlFilePath, Context, _rmlSystemInterface, Log);
        }

        /// <summary>
        /// Unloads the current screen
        /// </summary>
        public void DestroyScreen() {
            _currentScreen?.Dispose();
            _currentScreen = null;
            Context.Update();
        }

        public Panel? GetPanel(string name) {
            if (_panels.TryGetValue(name, out Panel? panel)) {
                return panel;
            }
            return null;
        }

        /// <summary>
        /// Create a panel
        /// </summary>
        /// <param name="name">The name of the panel</param>
        /// <param name="rmlFilePath">The rml file of the panel</param>
        /// <returns></returns>
        public Panel CreatePanelFromSource(string name, string rmlFilePath) {
            var panel = new Panel(name, rmlFilePath, Context, _rmlSystemInterface, Log);
            AddPanelInternal(name, panel);

            return panel;
        }

        /// <summary>
        /// Create a panel
        /// </summary>
        /// <param name="name">The name of the panel</param>
        /// <param name="rmlFilePath">The rml file of the panel</param>
        /// <returns></returns>
        public Panel CreatePanel(string name, string rmlFilePath, Action<UIDocument>? init = null) {
            var panel = new Panel(name, rmlFilePath, Context, _rmlSystemInterface, Log, false, init);
            AddPanelInternal(name, panel);

            return panel;
        }

        public Panel CreatePanelFromString(string name, string rmlContents, Action<UIDocument>? init = null) {
            var panel = new Panel(name, rmlContents, Context, _rmlSystemInterface, Log, true, init);
            AddPanelInternal(name, panel);

            return panel;
        }

        /// <summary>
        /// Destroy a panel
        /// </summary>
        /// <param name="name">The name of the panel</param>
        /// <returns></returns>
        public Panel? DestroyPanel(string name) {
            if (_panels.Remove(name, out var panel)) {
                panel.OnShow -= Panel_OnShow;
                panel.OnHide -= Panel_OnHide;

                _OnPanelRemoved?.Invoke(this, new PanelRemovedEventArgs(panel));
                panel.Dispose();
            }
            Context.Update();

            return panel;
        }

        private void AddPanelInternal(string name, Panel panel) {
            DestroyPanel(name);

            panel.OnShow += Panel_OnShow;
            panel.OnHide += Panel_OnHide;

            _panels.Add(name, panel);

            _OnPanelAdded?.Invoke(this, new PanelAddedEventArgs(panel));
        }

        private void Panel_OnHide(object? sender, EventArgs e) {
            _OnPanelVisibilityChanged?.Invoke(this, new PanelVisibilityChangedEventArgs((Panel)sender!, false));
        }

        private void Panel_OnShow(object? sender, EventArgs e) {
            _OnPanelVisibilityChanged?.Invoke(this, new PanelVisibilityChangedEventArgs((Panel)sender!, true));
        }

        internal Panel? GetPanelByPtr(IntPtr ptr) => _panels.Values.FirstOrDefault(p => p.NativePtr == ptr);

        internal void Update() {
            _currentScreen?.Update();

            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.Update();
            }
        }

        public bool IsAnyPanelUnderMouse() {
            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                if (panel.IsGhost || panel.ScriptableDocument is null) continue;

                var mouseX = CoreUIPlugin.Instance.Backend.Input.MouseX;
                var mouseY = CoreUIPlugin.Instance.Backend.Input.MouseY;

                var panelX = panel.ScriptableDocument.GetAbsoluteLeft();
                var panelY = panel.ScriptableDocument.GetAbsoluteTop();
                var panelWidth = panel.ScriptableDocument.GetClientWidth();
                var panelHeight = panel.ScriptableDocument.GetClientHeight();

                // check if mouse is over panel
                if (mouseX >= panelX && mouseX <= panelX + panelWidth && mouseY >= panelY && mouseY <= panelY + panelHeight) {
                    return true;
                }
            }
            return false;
        }

        public void Dispose() {
            Render.OnGraphicsPreReset -= Render_OnGraphicsPreReset;
            Render.OnGraphicsPostReset -= Render_OnGraphicsPostReset;

            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.Dispose();
            }

            _panels.Clear();
            _currentScreen?.Dispose();
            _currentScreen = null;
        }

        public Panel ShowModalConfirmation(string text, Action<string> callback, params string[] buttons) {
            CloseModal();
            var modalTemplate = System.IO.Path.Combine(CoreUIPlugin.Instance.AssemblyDirectory, "assets", "templates", "modal.rml");
            var _modalPanel = CreatePanel($"Modal_{text}", modalTemplate, (panel) => {
                var modal = panel.ScriptableDocument.LuaContext.NewTable();
                modal.SetInPath("text", text);
                modal.SetInPath("callback", (Action<string>)((buttonText) => {
                    try {
                        callback(buttonText);
                    }
                    catch(Exception ex) { Log.LogError(ex, "Error running Modal callback"); }
                    panel.Dispose();
                }));
                var buttonsTable = panel.ScriptableDocument.LuaContext.NewTable();
                for (var i = 0; i < buttons.Length; i++) {
                    buttonsTable.Set(i + 1, buttons[i]);
                }
                modal.SetInPath("buttons", buttonsTable);
                panel.ScriptableDocument.LuaContext.SetGlobal("modal", modal);
            });
            _currentModal = _modalPanel;
            _modalPanel.Show();

            return _modalPanel;
        }

        public void CloseModal() {
            if (_currentModal != null) {
                DestroyPanel(_currentModal.Name);
            }
        }
    }
}
