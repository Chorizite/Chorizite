using ACUI.Lib.Fonts;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib {
    public class PanelManager : IDisposable {
        private Dictionary<string, Panel> _panels = []; // <filename, panel>
        internal ILogger? Log;
        private ElementDocument? _modalPanel;
        internal readonly Context Context;

        public IRenderInterface Render { get; }
        public FontManager FontManager { get; }

        public PanelManager(Context ctx, IRenderInterface render, ILogger? log) {
            Log = log;
            FontManager = new FontManager(log);
            Context = ctx;
            Render = render;
        }

        public Panel LoadPanelFile(string file) {
            if (_panels.TryGetValue(file, out var panel)) {
                panel.Dispose();
                _panels.Remove(file);
            }

            panel = new Panel(this, file);
            _panels.Add(file, panel);

            return panel;
        }

        public Panel UnloadPanel(Panel panel) {
            panel.Dispose();
            _panels.Remove(panel.File);

            return panel;
        }

        internal void Update() {
            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.Update();
            }
        }

        public void Dispose() {
            var panels = _panels.Values.ToArray();
            foreach (var panel in panels) {
                panel.Dispose();
            }

            _panels.Clear();
            _modalPanel?.Dispose();
            FontManager.Dispose();
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
