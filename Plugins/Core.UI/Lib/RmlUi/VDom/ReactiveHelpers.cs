using Core.UI.Lib.RmlUi.Elements;
using Cortex.Net;
using Cortex.Net.Api;
using Cortex.Net.Core;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using static Core.UI.Lib.RmlUi.Elements.ScriptableDocumentElement;

namespace Core.UI.Lib.RmlUi.VDom {
    public class ReactiveHelpers {
        internal ScriptableDocumentElement _doc;
        private IDisposable _r;
        private Reaction _reaction;

        public ISharedState SharedState => _doc.SharedState;

        public ReactiveHelpers(ScriptableDocumentElement doc) {
            _doc = doc;
        }

        public T CreateState<T>(Func<T> value) where T : class {
            return SharedState.Observable<T>(value);
        }

        internal void CreateNode(Func<VirtualNode> nodeCreator, VirtualNode? parent = null) {
            SharedState.Reaction(r => {
                CoreUIPlugin.Log.LogDebug($"Start CreateNode Expression[{r.Name}]: {r.Observing.Count}, {r.NewObserving.Count}");
                var node = nodeCreator();
                CoreUIPlugin.Log.LogDebug($"End CreateNode Expression[{r.Name}:{node}]: {r.Observing.Count}, {r.NewObserving.Count}");
                return node;
            },
            (node, r) => {
                CoreUIPlugin.Log.LogDebug($"\t Start CreateNode Expression[{r.Name}]: {r.Observing.Count}, {r.NewObserving.Count}");
                if (parent is not null) {
                    node.Parent = parent;
                    parent.Children.Add(node);
                }
                foreach (var child in node.ChildrenBuilder) {
                    CreateNode(child, node);
                }
                CoreUIPlugin.Log.LogDebug($"\t End CreateNode Expression[{r.Name}:{node}]: {r.Observing.Count}, {r.NewObserving.Count}");
            }, new ReactionOptions<VirtualNode>() { FireImmediately = true });
        }

        internal void WatchAndMount(Element el, Func<Func<VirtualNode>> virtualNode) {
            var firstRun = true;
            _r = SharedState.Autorun((r) => {
                _reaction = r;
                CoreUIPlugin.Log.LogDebug($"Start WatchAndMount Expression[{r.Name}]: {r.Observing.Count}, {r.NewObserving.Count}");
                var node = virtualNode()();
                // now here it would be bnice to be able to call WatchAndMount for each child and get those observables,
                CoreUIPlugin.Log.LogDebug($"End WatchAndMoun Expression[{r.Name}]: {r.Observing.Count}, {r.NewObserving.Count}");

                if (firstRun) {
                    node.UpdateElement(el);
                    firstRun = false;
                }
            });
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

        public Func<VirtualNode> Progress(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("progress", props, children, text);

        public Func<VirtualNode> Br(Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) => El("br", props, children, text);
    }
}