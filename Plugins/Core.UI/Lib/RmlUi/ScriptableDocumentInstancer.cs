using Chorizite.Core.Backend;
using Core.Lua;
using Core.UI.Lib.RmlUi.Elements;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi {
    internal class ScriptableDocumentInstancer : ElementInstancer {
        private readonly Dictionary<IntPtr, ScriptableDocumentElement> _elements = [];
        private ILogger _log;
        private readonly CoreLuaPlugin _lua;
        private readonly IChoriziteBackend _backend;

        public ScriptableDocumentInstancer(IChoriziteBackend backend, CoreLuaPlugin lua, ILogger logger) : base("body") {
            _log = logger;
            _lua = lua;
            _backend = backend;
        }

        internal ScriptableDocumentElement? GetDocument(IntPtr ptr) {
            if (_elements.TryGetValue(ptr, out var document)) {
                return document;
            }
            return null;
        }

        public override IntPtr OnInstanceElement(Element parent, string tag, XMLAttributes attributes) {
            var document = new ScriptableDocumentElement(_backend, _lua, _log);
            _elements.Add(document.NativePtr, document);
            return document.NativePtr;
        }

        public override void OnReleaseElement(Element element) {
            if (_elements.TryGetValue(element.NativePtr, out var document)) {
                _elements.Remove(element.NativePtr);
                document.Dispose();
            }
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
