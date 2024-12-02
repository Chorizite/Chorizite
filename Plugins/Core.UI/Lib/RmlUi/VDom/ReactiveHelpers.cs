using Core.UI.Lib.RmlUi.Elements;
using Cortex.Net.Api;
using System;
using System.Collections.Generic;

namespace Core.UI.Lib.RmlUi.VDom {
    public class ReactiveHelpers {
        private ScriptableDocumentElement _doc;

        public ReactiveHelpers(ScriptableDocumentElement doc) {
            _doc = doc;
        }

        public T CreateState<T>(Func<T> value) where T : class {
            return _doc.SharedState.Observable<T>(value);
        }

        public Func<VirtualNode> Div(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("div", props, children, text));

        public Func<VirtualNode> Ul(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("ul", props, children, text));

        public Func<VirtualNode> Li(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("li", props, children, text));

        public Func<VirtualNode> P(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("p", props, children, text));

        public Func<VirtualNode> Input(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("input", props, children, text));

        public Func<VirtualNode> Form(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("form", props, children, text));

        public Func<VirtualNode> Button(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("button", props, children, text));

        public Func<VirtualNode> Span(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("span", props, children, text));

        public Func<VirtualNode> H1(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h1", props, children, text));

        public Func<VirtualNode> H2(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h2", props, children, text));

        public Func<VirtualNode> H3(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h3", props, children, text));

        public Func<VirtualNode> H4(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h4", props, children, text));

        public Func<VirtualNode> H5(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h5", props, children, text));

        public Func<VirtualNode> H6(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => new Func<VirtualNode>(() => new VirtualNode("h6", props, children, text));
    }
}