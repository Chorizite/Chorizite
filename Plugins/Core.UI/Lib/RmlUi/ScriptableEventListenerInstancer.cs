using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi {
    internal class ScriptableEventListenerInstancer : EventListenerInstancer {
        private readonly ILogger _log;
        private readonly ScriptableDocumentInstancer _scriptableDocumentInstancer;

        public ScriptableEventListenerInstancer(ScriptableDocumentInstancer scriptableDocumentInstancer, ILogger log) {
            _log = log;
            _scriptableDocumentInstancer = scriptableDocumentInstancer;
        }

        public override EventListener OnInstanceElement(string value, Element element) {
            return new ScriptableEventListener(_scriptableDocumentInstancer, value, _log);
        }
    }
}
