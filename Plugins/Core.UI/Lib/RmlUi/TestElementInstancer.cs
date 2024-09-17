using Core.UI.Lib.RmlUi.Elements;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi {
    internal class TestElementInstancer : ElementInstancer {
        private readonly Dictionary<IntPtr, DatIconElement> _elements = [];
        private ILogger? _log;

        public TestElementInstancer(ILogger? logger) : base("datimg") {
            _log = logger;
        }

        public override ElementCustom OnInstanceElement(Element parent, string tag, XMLAttributes attributes) {
            var datImageEl = new DatIconElement();
            _log?.LogDebug($"TestElementInstancer::OnInstanceElement: {parent?.TagName} -> {tag} !!!! {datImageEl.TagName}");

            _elements.Add(datImageEl.NativePtr, datImageEl);

            return datImageEl;
        }

        public override void OnReleaseElement(Element element) {
            if (_elements.TryGetValue(element.NativePtr, out var datImageEl)) {
                _elements.Remove(element.NativePtr);
                datImageEl.Dispose();
            }
        }
    }
}
