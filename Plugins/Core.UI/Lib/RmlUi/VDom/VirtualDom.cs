using Core.UI.Lib.Extensions;
using Microsoft.Extensions.Logging;
using RmlUiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static RmlUiNet.Native.VariableDefinition;

namespace Core.UI.Lib.RmlUi.VDom {
    // Virtual DOM diffing and patching
    public class VirtualDom {
        // Diff two virtual DOM trees and generate a list of changed nodes
        public static List<PatchOperation> Diff(VirtualNode? oldTree, VirtualNode newTree) {
            var patches = new List<PatchOperation>();

            if (oldTree == null) {
                // If old tree is null, replace entire tree
                var patch = new PatchOperation() {
                    Type = PatchOperation.OperationType.Replace,
                    NewNode = newTree,
                };
                patches.Add(patch);
                return patches;
            }

            // Recursive diff
            DiffRecursive(oldTree, newTree, patches);

            return patches;
        }

        private static void DiffRecursive(VirtualNode oldNode, VirtualNode newNode, List<PatchOperation> patches) {
            newNode.Element = oldNode.Element;
            // If nodes are completely different, replace
            if (!AreNodesCompatible(oldNode, newNode)) {
                patches.Add(new PatchOperation() {
                    Type = PatchOperation.OperationType.Replace,
                    NewNode = newNode,
                    OldNode = oldNode
                });
                return;
            }

            // Check for prop changes
            if (!ArePropsEqual(oldNode.Props, newNode.Props)) {
                patches.Add(new PatchOperation() {
                    Type = PatchOperation.OperationType.UpdateProps,
                    NewNode = newNode,
                    OldNode = oldNode
                });
            }

            // Check for text changes
            if (oldNode.Text != newNode.Text) {
                patches.Add(new PatchOperation() {
                    Type = PatchOperation.OperationType.UpdateText,
                    NewNode = newNode,
                    OldNode = oldNode
                });
            }

            var oldNodeChildren = oldNode.Children;
            var newNodeChildren = newNode.Children;

            if (oldNodeChildren.FirstOrDefault()?.Props.ContainsKey("key") == true && newNodeChildren.FirstOrDefault()?.Props.ContainsKey("key") == true) {
                var oldNodeKeys = oldNodeChildren.ToDictionary(c => c.Props["key"]?.ToString() ?? "", c => c);
                var newNodeKeys = newNodeChildren.ToDictionary(c => c.Props["key"]?.ToString() ?? "", c => c);
                // remove children that were in the old node but not in the new node
                foreach (var child in oldNodeChildren) {
                    if (!newNodeKeys.ContainsKey(child.Props["key"].ToString())) {
                        patches.Add(new PatchOperation() {
                            Type = PatchOperation.OperationType.Remove,
                            NewNode = null,
                            OldNode = child,
                            Parent = oldNode
                        });
                    }
                }

                // Add children that are in the new node but not in the old node
                foreach (var addedChild in newNodeChildren) {
                    if (!oldNodeKeys.ContainsKey(addedChild.Props["key"].ToString())) {
                        patches.Add(new PatchOperation() {
                            Type = PatchOperation.OperationType.Add,
                            NewNode = addedChild,
                            OldNode = null,
                            Parent = oldNode
                        });
                    }
                }

                // compare children that are in both nodes
                foreach (var child in oldNodeChildren) {
                    if (newNodeKeys.TryGetValue(child.Props["key"].ToString(), out var matchingNode)) {
                        DiffRecursive(child, matchingNode, patches);
                    }
                }
            }
            else {
                var childCount = Math.Min(oldNodeChildren.Count, newNodeChildren.Count);

                foreach (var i in Enumerable.Range(0, childCount)) {
                    DiffRecursive(oldNodeChildren[i], newNodeChildren[i], patches);
                }

                // Remove children that were in the old node but not in the new node
                foreach (var removedChild in oldNodeChildren.Skip(childCount)) {
                    patches.Add(new PatchOperation() {
                        Type = PatchOperation.OperationType.Remove,
                        NewNode = null,
                        OldNode = removedChild,
                        Parent = oldNode
                    });
                }

                // Add children that are in the new node but not in the old node
                foreach (var addedChild in newNodeChildren.Skip(childCount)) {
                    patches.Add(new PatchOperation() {
                        Type = PatchOperation.OperationType.Add,
                        NewNode = addedChild,
                        OldNode = null,
                        Parent = oldNode
                    });
                }
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
                   oldProps.Keys.All(k => {
                       if (string.IsNullOrEmpty(k)) return false;
                       if (oldProps[k] is Action<Event> && newProps[k] is Action<Event>) return true;
                       if (newProps is null || !newProps.ContainsKey(k)) return false;

                       return oldProps[k]?.Equals(newProps[k]) == true;
                   });
        }

        public static void Patch(PatchOperation patch) {
            var newNode = patch.NewNode;
            var oldNode = patch.OldNode;
            var parentNode = patch.Parent;
            try {
                switch (patch.Type) {
                    case PatchOperation.OperationType.Replace:
                        newNode.UpdateElement(oldNode.Element.DocEl.GetParentNode().AppendChildTag(newNode.Type));
                        newNode.Element.DocEl.GetParentNode().ReplaceChild(newNode.Element.DocEl, oldNode.Element.DocEl);
                        break;

                    case PatchOperation.OperationType.UpdateProps:
                        if (newNode?.Props is not null) {
                            var toUpdate = new Dictionary<string, object>(newNode.Props);
                            var updated = new List<string>();
                            foreach (var prop in toUpdate) {
                                updated.Add(prop.Key);
                                oldNode.Props.TryGetValue(prop.Key, out var oldValue);
                                newNode.UpdateProp(prop.Key, prop.Value, oldValue);
                            }

                            if (oldNode.Props?.Keys is not null) {
                                // Remove properties that no longer exist
                                foreach (var prop in oldNode.Props.Keys.Except(updated).ToArray()) {
                                    newNode.UpdateProp(prop, null, oldNode.Props[prop]);
                                }
                            }
                        }
                        break;

                    case PatchOperation.OperationType.UpdateText:
                        newNode.Element.DocEl.SetInnerRml(newNode.Text);
                        break;

                    case PatchOperation.OperationType.Add:
                        newNode.UpdateElement(parentNode.Element.DocEl.AppendChildTag(patch.NewNode.Type));
                        break;

                    case PatchOperation.OperationType.Remove:
                        parentNode.Element.DocEl.RemoveChild(oldNode.Element.DocEl);
                        oldNode.Dispose();
                        break;
                }
            }
            catch (Exception ex) {
                CoreUIPlugin.Log.LogError($"Failed to run patch {patch.Type} on Old: {oldNode} New: {newNode} Parent: {parentNode} {ex}");
            }
        }
    }
}