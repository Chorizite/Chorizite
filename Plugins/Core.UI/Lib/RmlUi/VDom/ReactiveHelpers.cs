using Core.UI.Lib.RmlUi.Elements;
using Cortex.Net;
using Cortex.Net.Api;
using Cortex.Net.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Core.UI.Lib.RmlUi.Elements.ScriptableDocumentElement;

namespace Core.UI.Lib.RmlUi.VDom {
    public class ReactiveHelpers {
        internal ScriptableDocumentElement _doc;

        public ISharedState SharedState => _doc.SharedState;

        public ReactiveHelpers(ScriptableDocumentElement doc) {
            _doc = doc;
        }

        public T CreateState<T>(Func<T> value) where T : class {
            return _doc.SharedState.Observable<T>(value);
        }

        public Func<VirtualNode> El(string type, Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) {
            return new Func<VirtualNode>(() => {
                return new VirtualNode(_doc, type, props, children, text);
            });
        }

        public Func<VirtualNode> Div(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("div", props, children, text);

        public Func<VirtualNode> Ul(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("ul", props, children, text);

        public Func<VirtualNode> Li(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("li", props, children, text);

        public Func<VirtualNode> P(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("p", props, children, text);

        public Func<VirtualNode> Input(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("input", props, children, text);

        public Func<VirtualNode> Form(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("form", props, children, text);

        public Func<VirtualNode> Button(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("button", props, children, text);

        public Func<VirtualNode> Span(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("span", props, children, text);

        public Func<VirtualNode> H1(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h1", props, children, text);

        public Func<VirtualNode> H2(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h2", props, children, text);

        public Func<VirtualNode> H3(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h3", props, children, text);

        public Func<VirtualNode> H4(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h4", props, children, text);

        public Func<VirtualNode> H5(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h5", props, children, text);

        public Func<VirtualNode> H6(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("h6", props, children, text);
    }
}