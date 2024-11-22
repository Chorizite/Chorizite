using Chorizite.Core.Backend;
using Chorizite.Core.Lua;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XLua;

namespace Core.UI.Lib.RmlUi.Elements {
    public class ScriptableDocumentElement : ElementDocument {
        private readonly ILogger _log;
        private readonly IChoriziteBackend _backend;
        private LuaTable _luaState;
        private List<ScriptContext> _scripts = new List<ScriptContext>();

        private struct ScriptContext {
            public string Source;
            public string SourcePath;
            public int SourceLine;

            public ScriptContext(string source, string source_path, int source_line) {
                Source = source;
                SourcePath = source_path;
                SourceLine = source_line;
            }
        }

        public LuaContext LuaContext { get; private set; }

        public ScriptableDocumentElement(IChoriziteBackend backend, ILogger logger) : base() {
            _log = logger;
            _backend = backend;

            LuaContext = new LuaContext();
            LuaContext.Global.Set("document", this);

            AddEventListener("click", HandleClick);
            AddEventListener("load", HandleLoad);
        }

        private void HandleLoad(Event evt) {
            foreach (var script in _scripts) {
                try {
                    LuaContext.DoString(script.Source, $"{script.SourcePath}:{script.SourceLine}");
                }
                catch (Exception ex) {
                    _log.LogError(LuaContext.FormatDocumentException(ex));
                }
            }
        }

        private void HandleClick(Event evt) {
            if (evt.TargetElement is null) return;
            var clickSound = evt.TargetElement.GetProperty("click-sound");

            if (!string.IsNullOrEmpty(clickSound) && clickSound != "none") {
                if (clickSound.StartsWith("0x", StringComparison.CurrentCultureIgnoreCase)) {
                    clickSound = clickSound.Substring(2);
                }

                if (uint.TryParse(clickSound, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uint soundId)) {
                    _backend.PlaySound(soundId);
                }
                else {
                    _log.LogError("Invalid Click Sound: {0}", clickSound);
                }
            }
        }

        public override void OnLoadInlineScript(string context, string source_path, int source_line) {
            // delay loading inline scripts until the document is loaded
            _scripts.Add(new ScriptContext(context, source_path, source_line));
        }

        public override void Dispose() {
            LuaContext?.Dispose();
            base.Dispose();
            LuaContext = null;
        }
    }
}
