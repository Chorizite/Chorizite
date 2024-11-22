using ACUI.Lib.RmlUi;
using Chorizite.Core.Render;
using Core.UI.Lib;
using Core.UI.Lib.Fonts;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ACUI.Lib {
    /// <summary>
    /// Manages panels and screens
    /// </summary>
    public class PanelManager : IDisposable {
        private readonly Dictionary<string, Panel> _panels = []; // <filename, panel>
        private ElementDocument? _modalPanel;
        private Screen? _currentScreen = null;
        private readonly IRenderInterface Render;
        private readonly ACSystemInterface _rmlSystemInterface;
        private readonly Context Context;
        private readonly ILogger Log;

        public Screen? CurrentScreen => _currentScreen;

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

        /// <summary>
        /// Create a panel
        /// </summary>
        /// <param name="name">The name of the panel</param>
        /// <param name="rmlFilePath">The rml file of the panel</param>
        /// <returns></returns>
        public Panel CreatePanel(string name, string rmlFilePath) {
            if (_panels.Remove(name, out var panel)) {
                panel.Dispose();
            }

            panel = new Panel(name, rmlFilePath, Context, _rmlSystemInterface, Log);
            _panels.Add(name, panel);

            return panel;
        }

        /// <summary>
        /// Destroy a panel
        /// </summary>
        /// <param name="name">The name of the panel</param>
        /// <returns></returns>
        public Panel? DestroyPanel(string name) {
            if (_panels.Remove(name, out var panel)) {
                panel.Dispose();
            }
            Context.Update();

            return panel;
        }

        internal Panel? GetPanelByPtr(IntPtr ptr) => _panels.Values.FirstOrDefault(p => p.NativePtr == ptr);

        internal void Update() {
            _currentScreen?.Update();

            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.Update();
            }
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
            _modalPanel?.Dispose();
            _modalPanel = null;
        }

        internal void ShowModalConfirmation(string text, IEnumerable<string> buttons, Action<string> callback) {
            var buttonsStr = new StringBuilder();
            foreach (var button in buttons) {
                buttonsStr.Append($"""<button data-event-click="exit('{button}')">{button}</button>""");
            }
            _modalPanel = Context.LoadDocumentFromMemory($$$"""
<rml>
    <head>
        <title>{{{text}}}</title>
        <style>
            body {
                display: block;
                width: 100%;
                height: 100%;
                background-color: #00000088;
                font-family: LatoLatin;
            }
            div {
                display: block;
            }
            p {
                display: inline-block;
                padding: 20px;
            }
            button {
                display: inline-block;
                font-size: 30px;
                padding: 10px;
                margin: 10px;
                color: white;
                background-color: #093754;
                border-color: white;
                border-width: 1px;
            }
            button:hover {
                background-color: orange;
            }
            button:active {
                background-color: red;
            }
            .modal {
                display: block;
                margin: auto;
                width: 300px;
                height: 200px;
                color: white;
                background-color: #001421;
                border-color: white;
                border-width: 3px;
                text-align: center;
                font-size: 22px;
            }
        </style>
    </head>
    <body>
        <div class="modal" data-model="CharSelectScreen">
            <p id="message">{{{text}}}</p>
            <div class="buttons">
                {{{buttonsStr}}}
            </div>
        </div>
    </body>
</rml>
""");
            
            _modalPanel.Show();
        }

        internal void HideModal() {
            _modalPanel?.Close();
            _modalPanel = null;
        }
    }
}
