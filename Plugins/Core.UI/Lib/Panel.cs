using MagicHat.Service.Lib.Plugins;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib {
    public class Panel : IDisposable {
        private readonly FileSystemWatcher _docWatcher;
        private PanelManager _manager;
        private string _docFile;
        private ElementDocument? _doc;
        private bool _needsReload;
        private DateTime _requestedReloadTime = DateTime.MinValue;
        private MyListener _onHover;

        public bool LiveReload { get; private set; } = true;

        private DateTime _start = DateTime.UtcNow;
        private bool _didListener;

        public Panel(PanelManager manager, string filename) {
            _manager = manager;
            _docFile = filename;

            LoadDoc();

            if (LiveReload) {
                _docWatcher = new FileSystemWatcher();
                _docWatcher.Path = Path.GetDirectoryName(filename);
                _docWatcher.NotifyFilter = NotifyFilters.LastWrite;
                _docWatcher.Filter = Path.GetFileName(filename);
                _docWatcher.Changed += DocWatcher_Changed;
                _docWatcher.EnableRaisingEvents = true;
            }
        }

        private class MyListener : EventListener {
            public List<string> last = [];
            public PanelManager _manager;

            public override void ProcessEvent(Event ev) {
                last.Insert(0, ev.Id.ToString());
            }
        }

        private void LoadDoc() {
            if (_doc is not null) {
                UnloadDoc(); 
            }
            _manager.Log?.LogTrace($"Loading document {_docFile}");

            _didListener = false;
            _doc = _manager.Context.LoadDocument(_docFile);
            _doc?.Show();

            if (_doc is null) {
                throw new Exception("Unable to create RmlUi document");
            }
            _onHover = new MyListener();
            _onHover._manager = _manager;
        }

        private void UnloadDoc() {
            _manager.Log?.LogTrace($"Unloading document {_docFile}");
            _doc?.Close();
            _doc?.Dispose();
            _doc = null;
        }

        private void DocWatcher_Changed(object sender, FileSystemEventArgs e) {
            _requestedReloadTime = DateTime.UtcNow;
            if (!_needsReload) {
                _manager.Log?.LogTrace($"Detected Changes in {_docFile}");
                _needsReload = true;
            }
        }

        internal void Update() {
            if (_needsReload && _requestedReloadTime + TimeSpan.FromMilliseconds(200) < DateTime.UtcNow) {
                _needsReload = false;
                LoadDoc();
            }

            var test = _doc?.GetElementById("test");
            var test1 = _doc?.GetElementById("test1");
            var b = _doc?.GetElementById("b");
            var str = new StringBuilder();
            str.AppendLine($"IsInteracting(ctx):{_manager.Context.IsMouseInteracting}");

            try {
                str.AppendLine($"YPos: {b?.GetOffsetTop():N0}");
            }
            catch (Exception ex) {
                str.AppendLine(ex.Message);
            }

            test?.SetInnerRml(str.ToString().Replace("\n", "<br />")); 
            test1?.SetInnerRml($"Last Events: {string.Join(" ", _onHover.last.Take(20)).ToString()}");

            if (DateTime.UtcNow - _start > TimeSpan.FromSeconds(1) && !_didListener) {
                _didListener = true;

                _manager.Log?.LogTrace($"ADDING EVENT LISTENER");

                foreach (var e in Enum.GetValues(typeof(RmlUiNet.EventId))) {
                    test1?.AddEventListener(e.ToString().ToLower(), _onHover);
                }
            }
        }

        public void Dispose() {
            _docWatcher?.Dispose();
            UnloadDoc();
        }
    }
}
