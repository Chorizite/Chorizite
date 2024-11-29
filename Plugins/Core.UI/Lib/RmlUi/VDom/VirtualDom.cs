using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Core.UI.Lib.RmlUi.VDom {
    // Virtual DOM diffing and patching
    public class VirtualDom {
        // Diff two virtual DOM trees and generate a list of patch operations
        public static List<PatchOperation> Diff(VirtualNode? oldTree, VirtualNode newTree) {
            var patches = new List<PatchOperation>();

            if (oldTree == null) {
                // If old tree is null, replace entire tree
                patches.Add(new PatchOperation(newTree.Id) {
                    Type = PatchOperation.OperationType.Replace,
                    NewNode = newTree,
                });
                return patches;
            }

            // Recursive diff
            DiffRecursive(oldTree, newTree, patches, 0);

            return patches;
        }

        private static void DiffRecursive(VirtualNode oldNode, VirtualNode newNode, List<PatchOperation> patches, int index) {
            // If nodes are completely different, replace
            if (!AreNodesCompatible(oldNode, newNode)) {
                patches.Add(new PatchOperation(oldNode.Id) {
                    Type = PatchOperation.OperationType.Replace,
                    NewNode = newNode,
                    Index = index
                });
                return;
            }

            // Check for prop changes
            if (!ArePropsEqual(oldNode.Props, newNode.Props)) {
                patches.Add(new PatchOperation(oldNode.Id) {
                    Type = PatchOperation.OperationType.UpdateProps,
                    NewNode = newNode,
                    Index = index
                });
            }

            // Check for text changes
            if (oldNode.Text != newNode.Text) {
                patches.Add(new PatchOperation(oldNode.Id) {
                    Type = PatchOperation.OperationType.UpdateText,
                    NewNode = newNode,
                    Index = index
                });
            }

            // Recursively diff children
            int childIndex = 0;
            int maxChildren = Math.Max(oldNode.Children.Count, newNode.Children.Count);

            for (int i = 0; i < maxChildren; i++) {
                if (i >= oldNode.Children.Count) {
                    // New child added
                    patches.Add(new PatchOperation(oldNode.Id) {
                        Type = PatchOperation.OperationType.Add,
                        NewNode = newNode.Children.ElementAt(i),
                        Index = index
                    });
                }
                else if (i >= newNode.Children.Count) {
                    // Child removed
                    patches.Add(new PatchOperation(oldNode.Children.ElementAt(i).Id) {
                        Type = PatchOperation.OperationType.Remove,
                        Index = index
                    });
                }
                else {
                    // Recursively diff children
                    DiffRecursive(oldNode.Children.ElementAt(i), newNode.Children.ElementAt(i), patches, childIndex);
                }

                childIndex++;
            }
        }

        internal static bool AreNodesCompatible(VirtualNode oldNode, VirtualNode newNode) {
            if (oldNode == null || newNode == null) return false;
            return oldNode.Type == newNode.Type;
        }

        internal static bool ArePropsEqual(IDictionary<string, object> oldProps, IDictionary<string, object> newProps) {
            if (oldProps == null && newProps == null) return true;
            if (oldProps == null || newProps == null) return false;

            return oldProps.Count == newProps.Count &&
                   oldProps.Keys.All(k => newProps.ContainsKey(k) && oldProps[k].Equals(newProps[k]));
        }

        public static void Patch(Element el, VirtualNode node, List<PatchOperation> patches) {
            if (patches == null || patches.Count == 0)
                return;

            // Apply patches
            ApplyPatchesRecursive(el, node, patches);
        }

        private static void ApplyPatchesRecursive(Element el, VirtualNode node, List<PatchOperation> patches) {
            // Find patches specifically for this node
            var nodePatches = patches
                .Where(p => IsNodeMatchForPatch(node, p))
                .ToList();
            CoreUIPlugin.Log.LogDebug($"Found {nodePatches.Count} patches for node {node?.Id}({node?.Type}) el({el?.TagName}) -> {node?.Element?.TagName}");

            // Apply node-level patches
            foreach (var patch in nodePatches) {
                switch (patch.Type) {
                    case PatchOperation.OperationType.Replace:
                        node.Element.GetParentNode().ReplaceChild(patch.NewNode.Element, el);
                        node.Parent.Children[node.GetIndexInParent()] = patch.NewNode;
                        break;

                    case PatchOperation.OperationType.UpdateProps:
                        if (patch.NewNode?.Props is not null) {
                            var toUpdate = new Dictionary<string, object>(patch.NewNode.Props);
                            var updated = new List<string>();
                            foreach (var prop in toUpdate) {
                                updated.Add(prop.Key);
                                CoreUIPlugin.Log.LogDebug($"UNHANDLED Updating property {prop.Key} to {prop.Value}");
                                // TODO: handle actions
                                if (prop.Value is Action<Event> action) {
                                    el.AddEventListener(prop.Key, action);
                                }
                                else {
                                    var propValue = prop.Value?.ToString();
                                    if (!string.IsNullOrEmpty(propValue)) {
                                        if (node.Props.ContainsKey(prop.Key)) {
                                            node.Props[prop.Key] = propValue;
                                        }
                                        else {
                                            node.Props.Add(prop.Key, propValue);
                                        }
                                        el.SetAttribute(prop.Key, propValue);
                                    }
                                }
                            }

                            if (node?.Props?.Keys is not null) {
                                // Remove properties that no longer exist
                                foreach (var prop in node.Props.Keys.Except(updated).ToArray()) {
                                    node.Props.Remove(prop);
                                    CoreUIPlugin.Log.LogDebug($"UNHANDLED Removing property {prop}");
                                    //el.SetAttributeValue(prop, null);
                                }
                            }
                        }
                        break;

                    case PatchOperation.OperationType.UpdateText:
                        CoreUIPlugin.Log.LogDebug($"UNHANDLED UpdateText {patch?.NewNode?.Text} on {el?.TagName}");
                        //el.SetInnerRml(patch.NewNode.Text);
                        //el.Value = patch.NewNode.Text;
                        break;

                    case PatchOperation.OperationType.Add:
                        node.Children.Add(patch.NewNode);
                        patch.NewNode.UpdateElement(el.AppendChildTag(patch.NewNode.Type));
                        break;

                    case PatchOperation.OperationType.Remove:
                        CoreUIPlugin.Log.LogDebug($"UNHANDLED Removing ");
                        int removeIndex = node.GetIndexInParent();
                        //el.Descendants().ElementAt(removeIndex).Remove();
                        break;
                }
            }

            // Recursively patch children
            for (int i = 0; i < node?.Children.Count; i++) {
                try {
                    ApplyPatchesRecursive(node.Children.ElementAt(i).Element, node.Children.ElementAt(i), patches);
                }
                catch(Exception ex) {
                    CoreUIPlugin.Log.LogDebug(ex.ToString());
                }
            }
        }

        // Helper method to determine if a patch applies to a specific node
        private static bool IsNodeMatchForPatch(VirtualNode node, PatchOperation patch) {
            return node?.Id == patch.NodeId || (node is null && patch.NodeId == 0);
        }

        // Helper method to find an element at a specific index
        private static XElement FindElementAtIndex(XElement root, int index) {
            if (index == 0) return root;

            var flattenedElements = root.Descendants().ToList();
            return index > 0 && index <= flattenedElements.Count
                ? flattenedElements[index - 1]
                : null;
        }

        // Deep clone a virtual node
        private static VirtualNode CloneNode(VirtualNode node) {
            return new VirtualNode(
                node.Type,
                new Dictionary<string, object>(node.Props),
                node.Children.Select(CloneNode).ToList(),
                node.Text
            );
        }

        // Helper method to convert XElement to VirtualNode
        public static VirtualNode VNodeFromXElement(XElement element) {
            var props = element.Attributes()
                .ToDictionary(attr => attr.Name.LocalName, attr => (object)attr.Value);

            var children = element.Elements()
                .Select(VNodeFromXElement)
                .ToList();

            return new VirtualNode(
                element.Name.LocalName,
                props,
                children,
                element.Value
            );
        }
    }
}