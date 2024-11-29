using ACUI.Lib;
using Chorizite.Core.Backend;
using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Core.UI.Lib.RmlUi {
    internal class ThemePlugin : Plugin {
        private readonly ILogger _log;
        private readonly IChoriziteBackend _backend;
        private readonly PanelManager _panelManager;
        private readonly Dictionary<IntPtr, ElementDocument> _documents = [];
        private readonly int _clickSoundId;
        private string _themeFile;
        private StyleSheetContainer _styleSheetContainer;
        private FileSystemWatcher _docWatcher;
        private bool _needsThemeLoad;

        public ThemePlugin(PanelManager panelManager, IChoriziteBackend backend, ILogger logger) {
            _log = logger;
            _backend = backend;
            _panelManager = panelManager;
            _themeFile = PathHelpers.TryMakeDevPath(Path.Combine(CoreUIPlugin.Instance!.AssemblyDirectory, "assets", "theme.rcss"));
            LoadTheme();
        }

        private void Renderer_OnRender2D(object? sender, EventArgs e) {
            try {
                LoadTheme();
                var documents = _documents.Values.ToArray();
                foreach (var document in documents) {
                    var panel = _panelManager?.GetPanelByPtr(document.NativePtr);
                    if (panel is not null) {
                        panel.NeedsReload = true;
                    }
                    else {
                        _log?.LogDebug($"Could not find panel for document {(_panelManager is null ? "null" : "not null")} {document.NativePtr:X8}");
                    }
                }
            }
            catch (Exception ex) {
                _log.LogError(ex, "Error reloading theme");
            }
            _backend.Renderer.OnRender2D -= Renderer_OnRender2D;
        }

        private void DocWatcher_Changed(object sender, FileSystemEventArgs e) {
            _needsThemeLoad = true;
            _backend.Renderer.OnRender2D += Renderer_OnRender2D;
        }

        private void LoadTheme() {
            if (_docWatcher is not null) {
                _docWatcher.Dispose();
            }

            if (!File.Exists(_themeFile)) {
                _log.LogError($"Theme file {_themeFile} does not exist");
                return;
            }
            if (_styleSheetContainer is not null) {
                _styleSheetContainer.Dispose();
            }

            _styleSheetContainer = new StyleSheetContainer(_themeFile);

            _docWatcher = new FileSystemWatcher();
            _docWatcher.Path = Path.GetDirectoryName(_themeFile);
            _docWatcher.NotifyFilter = NotifyFilters.Attributes |
                NotifyFilters.CreationTime |
                NotifyFilters.FileName |
                NotifyFilters.LastWrite |
                NotifyFilters.Size |
                NotifyFilters.Security;
            _docWatcher.Filter = Path.GetFileName(_themeFile);
            _docWatcher.Changed += DocWatcher_Changed;
            _docWatcher.EnableRaisingEvents = true;
        }

        public override void OnInitialise() {
            base.OnInitialise();
        }

        public override void OnShutdown() {
            base.OnShutdown();
        }

        public override void OnDocumentOpen(Context context, string documentPath) {
            base.OnDocumentOpen(context, documentPath);
        }

        public override void OnDocumentLoad(ElementDocument document) {
            _log.LogDebug($"OnDocumentLoad FROM PLUGIN: {document.GetSourceURL()}");
            _documents.TryAdd(document.NativePtr, document);
            document.AddStyleSheetContainer(_styleSheetContainer);
            base.OnDocumentLoad(document);
        }

        public override void OnDocumentUnload(ElementDocument document) {
            _documents.Remove(document.NativePtr);
            base.OnDocumentUnload(document);
        }

        public override void OnContextCreate(Context context) {
            base.OnContextCreate(context);
        }

        public override void OnContextDestroy(Context context) {
            base.OnContextDestroy(context);
        }

        public override void OnElementCreate(Element element) {
            base.OnElementCreate(element);
        }

        public override void OnElementDestroy(Element element) {
            base.OnElementDestroy(element);
        }

        public override void Dispose() {
            _backend.Renderer.OnRender2D -= Renderer_OnRender2D;
            _styleSheetContainer?.Dispose();
            _docWatcher?.Dispose();
            base.Dispose();
        }
    }
}