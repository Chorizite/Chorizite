using Chorizite.Common;
using Chorizite.Core.Backend;
using Chorizite.Core.Lib;
using Chorizite.Core.Lua;
using Core.UI.Lib.RmlUi.VDom;
using Cortex.Net;
using Cortex.Net.Api;
using Cortex.Net.Core;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using RoyT.TrueType.Tables.Kern;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using XLua;
using static Core.UI.Lib.RmlUi.Elements.ScriptableDocumentElement;

namespace Core.UI.Lib.RmlUi.Elements {
    public partial class ScriptableDocumentElement : ElementDocument {
        private List<MyObservable> _observables = [];
        private readonly ILogger _log;
        private readonly IChoriziteBackend _backend;
        private LuaTable _luaState;
        private List<ScriptContext> _scripts = new List<ScriptContext>();
        private List<FileWatcher> _scriptWatchers = new List<FileWatcher>();

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

        internal UIDocument Panel { get; set; }

        public LuaContext LuaContext { get; private set; }
        public ISharedState SharedState { get; private set; }
        public ReactiveHelpers Rx { get; private set; }
        public string DocumentDirectory => Path.GetDirectoryName(GetSourceURL());

        public event EventHandler<EventArgs> OnUnload {
            add => _OnUnload.Subscribe(value);
            remove => _OnUnload.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _OnUnload = new();

        public ScriptableDocumentElement(IChoriziteBackend backend, ILogger logger) : base() {
            _log = logger;
            _backend = backend;
            Rx = new ReactiveHelpers(this);

            SharedState = new SharedState();
            SharedState.Configuration.EnforceActions = EnforceAction.Never;
            SharedState.UnhandledReactionException += (s, ex) => _log.LogError($"Unhandled reaction exception: {ex.ExceptionObject}");

            LuaContext = new LuaContext();
            LuaContext.Global.Set("__Rx", Rx);

            LuaContext.AddLoader(UIModulesLoader);

            AddEventListener("click", HandleClick);
            //AddEventListener("load", HandleLoad);
        }

        private byte[] UIModulesLoader(ref string filepath) {
            var rxPath = Path.Combine(CoreUIPlugin.Instance.AssemblyDirectory, "lua", "rx.lua");
            if (filepath == "rx" && File.Exists(rxPath)) {
                return File.ReadAllBytes(rxPath);
            }

            return null;
        }

        internal void Update() {
            LuaContext?.Tick();
        }

        internal void HandleLoad() {
            LuaContext.Global.Set("document", Panel);
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
            _scripts.Add(new ScriptContext(context, source_path, source_line));
        }

        public override void OnLoadExternalScript(string source_path) {
            source_path = source_path.Replace('|', ':');
            if (File.Exists(source_path)) {
                _scripts.Add(new ScriptContext(File.ReadAllText(source_path), source_path, 0));
                _scriptWatchers.Add(new FileWatcher(Path.GetDirectoryName(source_path), Path.GetFileName(source_path), (e) => {
                    Panel.NeedsReload = true;
                }));
            }
            else {
                CoreUIPlugin.Log.LogError($"Failed to find external script: {source_path} in {GetSourceURL()}");
            }
        }

        internal MyObservable Observable(string name = "[anonymous]", MyObservable parent = null) {
            var observable = new MyObservable(SharedState, name, parent);
            _observables.Add(observable);
            return observable;
        }

        private List<IDisposable> _mounts = [];
        internal Reaction? _currentReaction;
        internal void Mount(Func<Func<VirtualNode>> virtualNode, string selector) {
            var el = QuerySelector(selector) ?? throw new Exception($"Could not find element with selector '{selector}' to mount to");
            if (virtualNode is null) throw new ArgumentNullException(nameof(virtualNode));

            VirtualNode? currentVDom = null;

            _mounts.Add(SharedState.Autorun((r) => {
                try {
                    var sw = System.Diagnostics.Stopwatch.StartNew();
                    if (currentVDom is null) {
                        currentVDom = virtualNode()();
                        currentVDom.UpdateElement(el.AppendChildTag(currentVDom.Type));
                    }
                    else {
                        var newVDom = virtualNode()();
                        var patches = VirtualDom.Diff(currentVDom, newVDom);
                        if (patches != null && patches.Count > 0) {
                            foreach (var patch in patches) {
                                VirtualDom.Patch(patch);
                            }
                        }
                        currentVDom = newVDom;
                    }

                    el.OwnerDocument.GetElementById("render-time")?.SetInnerRml($"Rendered {CoreUIPlugin.TaskCount} tasks in {(double)sw.ElapsedTicks / (double)TimeSpan.TicksPerMillisecond:N4}ms");
                }
                catch (Exception e) {
                    CoreUIPlugin.Log.LogError($"Failed to patch ui from state: {LuaContext.FormatDocumentException(e)}");
                }
            }));
        }

        public override void Dispose() {
            try {
                _OnUnload?.Invoke(this, EventArgs.Empty);
                WrappedElement._elementCache.Remove(NativePtr);
            } catch( Exception ex) {
                _log.LogError(ex, "Error in ScriptibleDocumentElement.OnUnload");
            }
            foreach (var watcher in _scriptWatchers) {
                watcher.Dispose();
            }
            _scriptWatchers.Clear();
            foreach (var mount in _mounts) {
                mount.Dispose();
            }
            _mounts.Clear();
            SharedState = null;
            _observables.Clear();
            LuaContext?.Dispose();
            base.Dispose();
            LuaContext = null;
        }
    }
}
