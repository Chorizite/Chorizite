using Chorizite.Core.Backend;
using Chorizite.Core.Lua;
using Core.UI.Lib.RmlUi.VDom;
using Cortex.Net;
using Cortex.Net.Api;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using XLua;

namespace Core.UI.Lib.RmlUi.Elements {
    public partial class ScriptableDocumentElement : ElementDocument {
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
        public ISharedState Rx { get; private set; }

        public ScriptableDocumentElement(IChoriziteBackend backend, ILogger logger) : base() {
            _log = logger;
            _backend = backend;

            Rx = SharedState.GlobalState;//new SharedState();
            Rx.UnhandledReactionException += (s, ex) => _log.LogError($"Unhandled reaction exception: {ex}");
            

            LuaContext = new LuaContext();
            LuaContext.Global.Set("document", this);
            LuaContext.Global.Set("d", PretendJQuery);

            AddEventListener("click", HandleClick);
            AddEventListener("load", HandleLoad);
        }

        internal Element? PretendJQuery(string selector) {
            return QuerySelector(selector);
        }

        internal void Update() {
            LuaContext?.Tick();
        }

        private void HandleLoad(Event evt) {
            foreach (var script in _scripts) {
                try {
                    LuaContext.DoString($"""coroutine.create_managed(function() {script.Source} end, "Document")""", $"{script.SourcePath}:{script.SourceLine}");
                }
                catch (LuaException ex) {
                    _log.LogError(LuaContext.FormatDocumentException(ex));
                }
                catch (Exception ex) {
                    _log.LogError(ex, "Error resuming coroutine");
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

        public void Mount(Func<VirtualNode> virtualNode, string selector) {
            var el = QuerySelector(selector) ?? throw new Exception($"Could not find element with selector '{selector}' to mount to");
            if (virtualNode is null) throw new ArgumentNullException(nameof(virtualNode));

            VirtualNode? currentVDom = null;

            SharedState.GlobalState.Autorun((r) => {
                try {
                    if (currentVDom is null) {
                        currentVDom = virtualNode();
                        currentVDom.UpdateElement(el.AppendChildTag(currentVDom.Type));
                    }
                    else {
                        var newVDom = virtualNode();
                        CoreUIPlugin.Log.LogDebug($"Rendering reactive state");
                        var patches = VirtualDom.Diff(currentVDom, newVDom);
                        if (patches != null && patches.Count > 0) {
                            foreach (var patch in patches) {
                                VirtualDom.Patch(patch);
                            }
                        }
                        currentVDom = newVDom;
                    }
                }
                catch (Exception e) {
                    CoreUIPlugin.Log.LogError(e, "Failed to patch ui from state");
                }
                CoreUIPlugin.Log.LogWarning($"\n{el.GetInnerRml()}\n\n");
            });
        }

        public override void Dispose() {
            LuaContext?.Dispose();
            base.Dispose();
            LuaContext = null;
        }
    }
}
