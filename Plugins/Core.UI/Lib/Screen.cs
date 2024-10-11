using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACUI.Lib {
    public class Screen : IDisposable {
        private readonly FileSystemWatcher _docWatcher;
        private readonly ILogger _log;
        
        private string _docFile;
        private ElementDocument? _doc;
        private bool _needsReload;
        private DateTime _requestedReloadTime = DateTime.MinValue;
        private DateTime _start = DateTime.UtcNow;
        private bool _didListener;

        public bool LiveReload { get; private set; } = true;
        public string File => _docFile;
        public string Name { get; }
        public Context Context { get; }

        public int Width => _doc is null ? 0 : (int)_doc.GetClientWidth();
        public int Height => _doc is null ? 0 : (int)_doc.GetClientHeight();

        public Screen(string name, string filename, Context context, ILogger log) {
            Name = name;
            _docFile = filename;
            _log = log;
            Context = context;

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

        private void LoadDoc() {
            if (_doc is not null) {
                UnloadDoc(); 
            }
            _log?.LogTrace($"Loading document {Name} {_docFile}");

            _didListener = false;
            _doc = Context.LoadDocument(_docFile);
            _doc?.Show();

            if (_doc is null) {
                throw new Exception("Unable to create RmlUi document");
            }
        }

        private void UnloadDoc() {
            _log?.LogTrace($"Unloading document {Name} {_docFile}");
            _doc?.Close();
            _doc?.Dispose();
            _doc = null;
        }

        private void DocWatcher_Changed(object sender, FileSystemEventArgs e) {
            _requestedReloadTime = DateTime.UtcNow;
            if (!_needsReload) {
                _log?.LogTrace($"Detected Changes in {_docFile}");
                _needsReload = true;
            }
        }

        internal unsafe void Update() {
            if (_needsReload && _requestedReloadTime + TimeSpan.FromMilliseconds(200) < DateTime.UtcNow) {
                _needsReload = false;
                LoadDoc();
            }
        }

        public void Dispose() {
            _docWatcher?.Dispose();
            UnloadDoc();
        }
    }
}
