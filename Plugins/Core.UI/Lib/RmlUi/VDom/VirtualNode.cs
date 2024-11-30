using Cortex.Net.Api;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.UI.Lib.RmlUi.VDom {
    // Represents a node in the Virtual DOM
    public class VirtualNode : IEquatable<VirtualNode> {
        private List<Action<Event>> _eventHandlers = [];

        public string Type { get; set; }
        public Dictionary<string, object> Props { get; set; } = new();
        public List<VirtualNode> Children { get; set; } = new();
        public string Text { get; set; }
        public VirtualNode Parent { get; set; }

        [Computed]
        public bool HasChildren => Children != null && Children.Count > 0;

        public Element? Element { get; internal set; }

        public VirtualNode(string type, Dictionary<string, object> props = null, List<VirtualNode> children = null, string text = null) {
            Type = type;
            Props = props ?? new Dictionary<string, object>();
            Children = children ?? new List<VirtualNode>();
            Text = text;
            
            // Set parent references for children
            foreach (var child in Children) {
                child.Parent = this;
            }
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

        internal void UpdateElement(Element element) {
            Element = element;

            // Add properties as attributes
            foreach (var prop in Props) {
                if (prop.Value is Action<Event> action) {
                    var evtName = prop.Key.StartsWith("on") ? prop.Key.Substring(2) : prop.Key;
                    element.AddEventListener(evtName.ToLower(), action);
                }
                else {
                    var val = prop.Value?.ToString();
                    if (!string.IsNullOrEmpty(val)) {
                        element.SetAttribute(prop.Key, val);
                    }
                }
            }

            // Add text content if exists
            if (!string.IsNullOrEmpty(Text)) {
                element.SetInnerRml(Text);
            }

            // Recursively add children
            foreach (var child in Children) {
                var childEl = Element.AppendChildTag(child.Type);
                child.UpdateElement(childEl);
            }
        }

        public override string ToString() {
            return $"<{Type} {string.Join(" ", Props.Select(kvp => $"{kvp.Key}=\"{kvp.Value}\""))}>{Text}</{Type}>";
        }
    }
}
