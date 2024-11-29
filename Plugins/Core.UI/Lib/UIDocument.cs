﻿using ACUI.Lib.RmlUi;
using Chorizite.Common;
using Chorizite.Core.Lib;
using Core.UI.Lib.RmlUi;
using Core.UI.Lib.RmlUi.Elements;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib {
    public abstract class UIDocument : IDisposable {
        private readonly ILogger _log;
        private readonly string _docFile;
        private readonly FileWatcher? _fileWatcher;
        private ElementDocument? _doc;
        private DateTime _requestedReloadTime = DateTime.MinValue;

        internal Context Context { get; }

        private ACSystemInterface _rmlSystemInterface;

        internal IntPtr NativePtr { get; private set; }
        internal bool NeedsReload;

        /// <summary>
        /// Whether or not the ui document should reload on file changes
        /// </summary>
        public bool LiveReload { get; set; } = true;
        public bool IsSource { get; }

        /// <summary>
        /// The filename of the ui document
        /// </summary>
        public string File => _docFile;

        /// <summary>
        /// The friendly name of this ui document.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The rendered width of the screen
        /// </summary>
        public int Width => _doc is null ? 0 : (int)_doc.GetClientWidth();

        /// <summary>
        /// The rendered height of the screen
        /// </summary>
        public int Height => _doc is null ? 0 : (int)_doc.GetClientHeight();

        public event EventHandler<EventArgs> OnAfterReload {
            add => _onAfterReload.Subscribe(value);
            remove => _onAfterReload.Unsubscribe(value);
        }
        private WeakEvent<EventArgs> _onAfterReload = new();

        public ScriptableDocumentElement? ScriptableDocument => CoreUIPlugin.Instance.ScriptableDocumentInstancer.GetDocument(NativePtr);

        internal UIDocument(string name, string filename, Context context, ACSystemInterface rmlSystemInterface, ILogger log, bool isSource = false) {
            Name = name;
            _log = log;
            IsSource = isSource;
            _docFile = IsSource ? filename : PathHelpers.TryMakeDevPath(filename);
            Context = context;
            _rmlSystemInterface = rmlSystemInterface;

            LoadDoc();

            if (!IsSource && LiveReload) {
                _fileWatcher = new FileWatcher(Path.GetDirectoryName(_docFile), Path.GetFileName(_docFile), (file) => {
                    NeedsReload = true;
                });
            }
        }

        private void LoadDoc() {
            if (_doc is not null) {
                UnloadDoc();
            }
            _log?.LogTrace($"Loading document {Name} {_docFile}");

            if (IsSource) {
                _doc = Context.LoadDocumentFromMemory(_docFile, $"server://TODO_SERVERNAME/{Name}.rml");
            }
            else {
                if (!System.IO.File.Exists(_docFile)) {
                    throw new Exception($"Unable to find document {_docFile}");
                }

                _doc = Context.LoadDocument(_docFile);
            }
            if (_doc is null) {
                throw new Exception($"Unable to create RmlUi document {Name} {_docFile}");
            }

            if (_rmlSystemInterface.HasNewFontsLoaded) {
                _rmlSystemInterface.HasNewFontsLoaded = false;
                _log?.LogDebug($"New fonts were loaded, reloading document {Name} {_docFile}");
                _doc?.Dispose();
                LoadDoc();
                return;
            }

            NativePtr = _doc.NativePtr;
            _doc.Show();
        }

        private void UnloadDoc() {
            _log?.LogTrace($"Unloading document {Name} {_docFile}");
            _doc?.Close();
            _doc?.Dispose();
            _doc = null;
            NativePtr = IntPtr.Zero;
        }

        internal unsafe void Update() {
            if (NeedsReload) {
                NeedsReload = false;
                _log.LogDebug($"Reloading document {Name} {_docFile}");
                LoadDoc();
                Context.Update();
                _onAfterReload.Invoke(this, EventArgs.Empty);
            }
        }

        internal void HandleGraphicsPreReset() {
            UnloadDoc();
        }

        internal void HandleGraphicsPostReset() {
            LoadDoc();
        }

        public void Dispose() {
            _fileWatcher?.Dispose();
            UnloadDoc();
        }
    }
}
