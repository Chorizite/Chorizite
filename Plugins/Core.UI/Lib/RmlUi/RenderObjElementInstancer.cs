using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Core.UI.Lib.RmlUi.Elements;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.UI.Lib.RmlUi {
    internal class RenderObjElementInstancer : ElementInstancer {
        private readonly Dictionary<IntPtr, RenderObjElement> _elements = [];
        private ILogger _log;
        private readonly IChoriziteBackend _backend;
        private readonly IDatReaderInterface _dat;

        public RenderObjElementInstancer(IChoriziteBackend backend, IDatReaderInterface dat, ILogger logger) : base("renderobj") {
            _log = logger;
            _backend = backend;
            _dat = dat;
        }
        internal void Update() {
            var renderEls = _elements.Values.ToArray();
            foreach (var renderEl in renderEls) {
                renderEl.Update();
            }
        }

        public override IntPtr OnInstanceElement(Element parent, string tag, XMLAttributes attributes) {
            var document = new RenderObjElement(_backend, _dat, _log, attributes);
            _elements.Add(document.NativePtr, document);
            return document.NativePtr;
        }

        public override void OnReleaseElement(Element element) {
            if (_elements.TryGetValue(element.NativePtr, out var renderEl)) {
                _elements.Remove(element.NativePtr);
                renderEl.Dispose();
            }
        }

        public override void Dispose() {
            base.Dispose();
        }
    }
}
