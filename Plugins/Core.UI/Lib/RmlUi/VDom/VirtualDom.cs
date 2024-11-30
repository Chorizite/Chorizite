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
                var oldProps = string.Join(",", oldNode.Props.Keys.Select(k => $"{k}:{oldNode.Props[k]}").ToArray());
                var newProps = string.Join(",", newNode.Props.Keys.Select(k => $"{k}:{newNode.Props[k]}").ToArray());
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

            var oldNodeChildren = oldNode.Children.ToList();
            var newNodeChildren = newNode.Children.ToList();

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
                       if (newProps is null || !newProps.ContainsKey(k)) return false;

                       return oldProps[k]?.Equals(newProps[k]) == true;
                   });
        }

        public static void Patch(PatchOperation patch) {
            var newNode = patch.NewNode;
            var oldNode = patch.OldNode;
            var parentNode = patch.Parent;

            CoreUIPlugin.Log.LogDebug($"Patch[{patch.Type}] Old:{oldNode?.ToString()} New:{newNode?.ToString()}");

            switch (patch.Type) {
                case PatchOperation.OperationType.Replace:
                    newNode.UpdateElement(oldNode.Element.GetParentNode().AppendChildTag(newNode.Type));
                    newNode.Element.GetParentNode().ReplaceChild(newNode.Element, oldNode.Element);
                    break;

                case PatchOperation.OperationType.UpdateProps:
                    if (newNode?.Props is not null) {
                        var toUpdate = new Dictionary<string, object>(newNode.Props);
                        var updated = new List<string>();
                        foreach (var prop in toUpdate) {
                            updated.Add(prop.Key);
                            if (prop.Value is Action<Event> action) {
                                var evtName = (prop.Key.StartsWith("on") ? prop.Key.Substring(2) : prop.Key).ToLower();
                                if (oldNode.Props?.TryGetValue(prop.Key, out var oldAction) == true && oldAction is Action<Event> oldActionEvt) {
                                    CoreUIPlugin.Log.LogDebug($"\t Removing event listener: {evtName} on {newNode.Type}({newNode.Text})");
                                    oldNode.Element.RemoveEventListener(evtName, oldActionEvt);
                                }
                                newNode.Element.AddEventListener(evtName, action);
                                CoreUIPlugin.Log.LogDebug($"\t Adding event listener: {evtName} on {newNode.Type}({newNode.Text})");
                            }
                            else {
                                var propValue = prop.Value?.ToString();
                                if (!string.IsNullOrEmpty(propValue)) {
                                    if (oldNode.Props?.TryGetValue(prop.Key, out var oldPropValue) == true && oldPropValue?.ToString() == propValue) continue;
                                    newNode.Element.SetAttribute(prop.Key, propValue);
                                }
                                else {
                                    newNode.Element.RemoveAttribute(prop.Key);
                                }
                            }
                        }

                        if (oldNode.Props?.Keys is not null) {
                            // Remove properties that no longer exist
                            foreach (var prop in oldNode.Props.Keys.Except(updated).ToArray()) {
                                newNode.Element.RemoveAttribute(prop);
                            }
                        }
                    }
                    break;

                case PatchOperation.OperationType.UpdateText:
                    newNode.Element.SetInnerRml(newNode.Text);
                    break;

                case PatchOperation.OperationType.Add:
                    newNode.UpdateElement(parentNode.Element.AppendChildTag(patch.NewNode.Type));
                    break;

                case PatchOperation.OperationType.Remove:
                    parentNode.Element.RemoveChild(oldNode.Element);
                    break;
            }
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
    }
}