using Microsoft.Extensions.Logging;
using RmlUiNet;
using System.Xml.Linq;

namespace Core.UI.Lib.RmlUi {
    internal class TestPlugin : Plugin {
        private ILogger? _log;

        public TestPlugin(Microsoft.Extensions.Logging.ILogger? logger) {
            _log = logger;
        }

        public override void OnInitialise() {
            //_log?.LogDebug("TestPlugin::OnInitialise");
            base.OnInitialise();
        }

        public override void OnShutdown() {
            //_log?.LogDebug("TestPlugin::OnShutdown");
            base.OnShutdown();
        }

        public override void OnDocumentOpen(Context context, string documentPath) {
            //_log?.LogDebug($"TestPlugin::OnDocumentOpen: {context?.Name} ({documentPath})");
            base.OnDocumentOpen(context, documentPath);
        }

        public override void OnDocumentLoad(ElementDocument document) {
            //_log?.LogDebug($"TestPlugin::OnDocumentLoad: {document is null}");
            base.OnDocumentLoad(document);
        }

        public override void OnDocumentUnload(ElementDocument document) {
            //_log?.LogDebug($"TestPlugin::OnDocumentUnload: {document?.TagName}");
            base.OnDocumentUnload(document);
        }

        public override void OnContextCreate(Context context) {
            //_log?.LogDebug($"TestPlugin::OnContextCreate: {context?.Name}");
            base.OnContextCreate(context);
        }

        public override void OnContextDestroy(Context context) {
            //_log?.LogDebug($"TestPlugin::OnContextDestroy: {context?.Name}");
            base.OnContextDestroy(context);
        }

        public override void OnElementCreate(Element element) {
            //_log?.LogDebug($"TestPlugin::OnElementCreate: {element?.TagName}");
            base.OnElementCreate(element);
        }

        public override void OnElementDestroy(Element element) {
            //_log?.LogDebug($"TestPlugin::OnElementDestroy: {element?.TagName}");
            base.OnElementDestroy(element);
        }
    }
}