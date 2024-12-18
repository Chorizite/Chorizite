using Chorizite.Common.Enums;
using Chorizite.Core.Backend.Client;
using Core.UI.Lib.Extensions;
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
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using XLua;

namespace Core.UI.Lib.RmlUi.VDom {
    // Represents a node in the Virtual DOM
    public class VirtualNode : IEquatable<VirtualNode>, IDisposable {
        private List<Action<Event>> _eventHandlers = [];
        private ScriptableDocumentElement _docEl;

        private readonly HashSet<string> _lifecycleEvents = new HashSet<string>() {
        "onUpdate",
        "onMount"
    };
        private bool _hasMounted = false;

        public string Type { get; set; }
        public Dictionary<string, object> Props { get; set; }
        public List<VirtualNode> Children { get; } = [];
        public string Text { get; set; }
        public VirtualNode Parent { get; set; }

        public WrappedElement? Element { get; internal set; }
        public bool IsDirty { get; internal set; }
        internal List<Func<VirtualNode>> ChildrenBuilder { get; set; }

        public VirtualNode(ScriptableDocumentElement doc, string type, Dictionary<string, object>? props = null, List<Func<VirtualNode>>? children = null, string? text = null) {
            _docEl = doc;
            Type = type;
            Props = props ?? [];
            Text = text;
            Children.AddRange(children?.Select(c => c()) ?? []);
            Children.ForEach(c => c.Parent = this);
        }

        public bool Equals(VirtualNode? other) {
            return IsEqual(other);
        }

        // Deep equality check for nodes
        public bool IsEqual(VirtualNode other) {
            if (other == null) return false;

            // Check type
            if (Type != other.Type) return false;

            // Check text content
            if (Text != other.Text) return false;

            // Compare props
            if (!ArePropsDictionariesEqual(Props, other.Props)) return false;

            /*
            // Compare children count
            if (Children.Count != other.Children.Count) return false;

            // Recursively compare children
            for (int i = 0; i < Children.Count; i++) {
                if (!Children.ElementAt(i).IsEqual(other.Children.ElementAt(i))) return false;
            }
            */
            return true;
        }

        private bool ArePropsDictionariesEqual(IDictionary<string, object> dict1, IDictionary<string, object> dict2) {
            return VirtualDom.ArePropsEqual(dict1, dict2);
        }

        // Method to find the index of this node in its parent's children
        public int GetIndexInParent() {
            var children = Parent?.Children.ToList() ?? [];
            return children.IndexOf(this);
        }

        internal void UpdateProp(string key, object? value, object? oldValue) {
            if (key == "value" && value != null && value is not string)
                value = value.ToString();

            if (value?.Equals(oldValue) == true) {
                return;
            }
            if (Element is null) {
                CoreUIPlugin.Log.LogWarning($"Element is null, skipping prop update on {ToString()}: {key}={value}");
                return;
            }

            if (_lifecycleEvents.Contains(key))
                return;

            if (value is string stringValue) {
                if (!string.IsNullOrEmpty(stringValue)) {
                    Element.DocEl.SetAttribute(key, stringValue);
                }
                else {
                    Element.DocEl.RemoveAttribute(key);
                }
            }
            else if (value is Action<Event> || oldValue is Action<Event>) {
                var evtName = key.StartsWith("on") ? key.Substring(2) : key;
                if (value is Action<Event> action) {
                    Element.SetEventListener(evtName.ToLower(), action);
                }
                else {
                    Element.RemoveEventListener(evtName.ToLower());
                }
            }
            else if (value is LuaFunction || oldValue is LuaFunction) {
                var evtName = key.StartsWith("on") ? key.Substring(2) : key;
                if (value is LuaFunction action) {
                    Element.SetEventListener(evtName.ToLower(), (e) => {
                        try {
                            UIDocument? doc = CoreUIPlugin.Instance.PanelManager.GetPanelByPtr(_docEl.OwnerDocument.NativePtr);
                            if (doc is null) {
                                if (_docEl.OwnerDocument.NativePtr == CoreUIPlugin.Instance.PanelManager.GetScreen()?.NativePtr) {
                                    doc = CoreUIPlugin.Instance.PanelManager.GetScreen();
                                }

                                if (doc is null) {
                                    CoreUIPlugin.Log.LogWarning($"Document is null, skipping event handler on {ToString()}: {key}={value}");
                                    return;
                                }
                            }
                            var evtTable = doc.ScriptableDocument.LuaContext.NewTable();
                            evtTable.SetInPath("Id", e.Id);
                            evtTable.SetInPath("IsInterruptible", e.IsInterruptible);
                            evtTable.SetInPath("CurrentElement", e.CurrentElement);
                            evtTable.SetInPath("TargetElement", e.TargetElement);
                            evtTable.SetInPath("IsImmediatePropagating", e.IsImmediatePropagating);
                            evtTable.SetInPath("IsPropagating", e.IsPropagating);
                            evtTable.SetInPath("Phase", e.Phase);
                            evtTable.SetInPath("StopPropagation", e.StopPropagation);
                            evtTable.SetInPath("StopImmediatePropagation", e.StopImmediatePropagation);
                            var paramsTable = doc.ScriptableDocument.LuaContext.NewTable();
                            foreach (var param in e.Parameters) {
                                switch (param.Key) {
                                    case "DropFlags":
                                        paramsTable.SetInPath(param.Key, (DragDropFlags)param.Value);
                                        break;
                                    case "IconEffects":
                                        paramsTable.SetInPath(param.Key, (UiEffects)param.Value);
                                        break;
                                    default:
                                        paramsTable.SetInPath(param.Key, param.Value);
                                        break;
                                }
                            }
                            evtTable.SetInPath("Params", paramsTable);
                            action.Call(evtTable);
                        }
                        catch (Exception ex) {
                            CoreUIPlugin.Log.LogError(ex, "Error calling event handler");
                        }
                    });
                }
                else {
                    Element.RemoveEventListener(evtName.ToLower());
                }
            }
            else if (value is bool boolValue) {
                if (boolValue) {
                    Element.DocEl.SetAttribute(key, key);
                }
                else {
                    Element.DocEl.RemoveAttribute(key);
                }
            }
            else if (value is not null) {
                if (!string.IsNullOrEmpty(value.ToString())) Element.DocEl.SetAttribute(key, value.ToString());
                else Element.DocEl.RemoveAttribute(key);
            }
            else if (oldValue != null) {
                Element.DocEl.RemoveAttribute(key);
            }
        }

        internal void UpdateElement(Element element) {
            Element = WrappedElement.GetOrCreate(_docEl, element);

            // Trigger lifecycle action if defined
            if (_hasMounted && Props.TryGetValue("onUpdate", out var onUpdate)) {
                if (onUpdate is Action updateAction)
                    updateAction.Invoke();
                else if (onUpdate is LuaFunction updateLuaAction) {
                    updateLuaAction.Call();
                }
            }

            // Trigger onMount lifecycle if defined and has not been triggered yet
            if (!_hasMounted && Props.TryGetValue("onMount", out var onMount)) {
                if (onMount is Action mountAction) {
                    mountAction.Invoke();
                }
                else if (onMount is LuaFunction luaMountAction) {
                    luaMountAction.Call(luaMountAction);
                }
                _hasMounted = true; // Set the flag to true after mounting
            }

            // Add properties as attributes
            foreach (var prop in Props) {
                UpdateProp(prop.Key, prop.Value, null);
            }

            // Add text content if exists
            if (!string.IsNullOrEmpty(Text)) {
                element.SetInnerRml(Text);
            }

            // Recursively add children
            foreach (var child in Children) {
                var childEl = Element.DocEl.AppendChildTag(child.Type);
                child.UpdateElement(childEl);
            }
        }

        public override string ToString() {
            return $"<{Type}{(Props.Count > 0 ? " " : "")}{string.Join(" ", Props.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""))}>{Text}</{Type}>";
        }

        public void Dispose() {
            Element?.Dispose();
            foreach (var child in Children) {
                child.Dispose();
            }
            Children.Clear();
        }
    }
}
