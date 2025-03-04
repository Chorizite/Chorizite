using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Lib {
    /// <summary>
    /// Simple file watcher
    /// </summary>
    public class FileWatcher : IDisposable {
        private readonly FileSystemWatcher? _docWatcher;
        private Action<string>? _onFileChanged;
        private bool _needsReload;
        private DateTime _changedAt = DateTime.MinValue;
        private string _changedFile = "";

        /// <summary>
        /// The amount of time to wait after a file has changed before triggering the event
        /// </summary>
        public TimeSpan Delay { get; set; } = TimeSpan.FromMilliseconds(500);

        /// <summary>
        /// Create a new file watcher
        /// </summary>
        /// <param name="directory">The directory to watch</param>
        /// <param name="pattern">The pattern to watch (*.txt)</param>
        /// <param name="onFileChanged">An action to run when a file is changed, after <see cref="Delay"/></param>
        public FileWatcher(string directory, string pattern, Action<string>? onFileChanged = null) {
            if (!Directory.Exists(directory)) {
                ChoriziteStatics.Log.LogWarning("FileWatcher directory does not exist: {0} ({1})", directory, pattern);
                return;
            }

            try {
                ChoriziteStatics.Log.LogTrace("FileWatcher created: {0} ({1})", directory, pattern);
            }
            catch { }

            _onFileChanged = onFileChanged;

            _docWatcher = new FileSystemWatcher();
            _docWatcher.Path = directory;
            _docWatcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
            _docWatcher.Filter = pattern;
            _docWatcher.Changed += DocWatcher_Changed;
            _docWatcher.EnableRaisingEvents = true;
        }

        private void DocWatcher_Changed(object sender, FileSystemEventArgs e) {
            _changedAt = DateTime.Now;

            try {
                ChoriziteStatics.Log.LogTrace("FileWatcher changed: {0}", e.FullPath);
            }
            catch { }
            if (!_needsReload) {
                _needsReload = true;
                _changedFile = e.FullPath;
                ChoriziteStatics.Backend.Renderer.OnRender2D += OnRender2D;
            }
        }

        private void OnRender2D(object? sender, EventArgs e) {
            if (_needsReload && _changedAt + Delay > DateTime.Now) {
                try {
                    _onFileChanged?.Invoke(_changedFile);
                }
                catch(Exception ex) {
                    ChoriziteStatics.Log.LogError(ex, "Error in file watcher onFileChanged action");
                }
                _needsReload = false;
            }
            if (!_needsReload) {
                ChoriziteStatics.Backend.Renderer.OnRender2D -= OnRender2D;
            }
        }

        /// <inheritdoc/>
        public void Dispose() {
            if (_needsReload) {
                ChoriziteStatics.Backend.Renderer.OnRender2D -= OnRender2D;
                _needsReload = false;
            }
            _docWatcher?.Dispose();
            _onFileChanged = null;
        }
    }
}
