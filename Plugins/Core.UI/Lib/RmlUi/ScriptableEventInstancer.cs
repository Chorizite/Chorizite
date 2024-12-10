using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.RmlUi {
    internal class ScriptableEventInstancer : EventInstancer {
        public override void OnInstanceEvent(Element element, RmlUiNet.EventId id, string name, Dictionary<string, object> parameters, bool interruptible) {
            switch (id) {
                case RmlUiNet.EventId.DragDrop:
                case RmlUiNet.EventId.DragOver:
                case RmlUiNet.EventId.DragOut:
                    if (CoreUIPlugin.Instance?.PanelManager._externalDragDropEventData is not null) {
                        foreach (var kv in CoreUIPlugin.Instance.PanelManager._externalDragDropEventData) {
                            if (!parameters.TryAdd(kv.Key, kv.Value)) {
                                parameters[kv.Key] = kv.Value;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
