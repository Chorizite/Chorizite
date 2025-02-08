using Core.UI.Lib.RmlUi.VDom;
using System;

namespace Core.UI.Lib.RmlUi.Elements {
    public partial class ScriptableDocumentElement {
        private class MountedElement : IDisposable {
            public IDisposable AutoRun { get; set; }
            public string Selector { get; set; }
            public VirtualNode? CurrentDom { get; set; }

            public MountedElement(string selector) {
                Selector = selector;
            }

            public void Dispose() {
                AutoRun.Dispose();
                CurrentDom?.Dispose();
            }
        }
    }
}
