using RmlUiNet;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace Core.UI.Lib.RmlUi {
    internal class ScriptableEventListener : EventListener {
        private string value;
        private ILogger _log;
        private readonly ScriptableDocumentInstancer _scriptableDocumentInstancer;

        public ScriptableEventListener(ScriptableDocumentInstancer scriptableDocumentInstancer, string value, ILogger log) {
            this.value = value;
            _log = log;
            _scriptableDocumentInstancer = scriptableDocumentInstancer;
        }

        public override void ProcessEvent(Event ev) {
            try {
                var scriptableDoc = _scriptableDocumentInstancer.GetDocument(ev.TargetElement?.OwnerDocument.NativePtr ?? ev.CurrentElement.OwnerDocument.NativePtr);
                scriptableDoc?.LuaContext.DoString(value);
            }
            catch (Exception ex) {
                _log.LogError(ex, $"Error running script event: {ev.Id} {value}: {ex.Message}");
            }
        }
    }
}