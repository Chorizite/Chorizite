using Chorizite.Core.Backend;
using Core.Lua;
using Core.Lua.Lib;
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
        private readonly CoreLuaPlugin _lua;
        private LuaTable _luaState;

        public LuaContext LuaContext { get; private set; }

        private class ClickSoundEventListener : EventListener {
            private readonly ILogger _log;
            private readonly IChoriziteBackend _backend;

            public ClickSoundEventListener(IChoriziteBackend backend, ILogger log) : base() {
                _log = log;
                _backend = backend;
            }

            public override void ProcessEvent(Event ev) {
                if (ev.TargetElement is null) return;
                var clickSound = ev.TargetElement.GetProperty("click-sound");

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
        }

        public ScriptableDocumentElement(IChoriziteBackend backend, CoreLuaPlugin lua, ILogger logger) : base() {
            _log = logger;
            _lua = lua;

            LuaContext = lua.MakeLuaEnv();
            LuaContext.Global.Set("document", this);

            AddEventListener("click", new ClickSoundEventListener(backend, _log));
        }

        public override void OnLoadInlineScript(string context, string source_path, int source_line) {
            try {
                var res = LuaContext.DoString(context, $"{source_path}:{source_line}");
                _log.LogDebug("A Result: {0}", LuaContext.FormatLuaResult(res));
            }
            catch (Exception ex) {
                _log.LogError(ex.Message);
            }
        }

        public override void Dispose() {
            LuaContext?.Global.Set<string, ScriptableDocumentElement>("document", null!);
            LuaContext?.Dispose();
            base.Dispose();
            LuaContext = null;
        }
    }
}
