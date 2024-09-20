using ACUI.Lib.Fonts;
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

        internal readonly Context Context;

        public FontManager FontManager { get; }

        public PanelManager(Context ctx, ILogger? log) {
            Log = log;
            FontManager = new FontManager(log);
            Context = ctx;
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

            FontManager.Dispose();
        }
    }
}
