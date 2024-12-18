using ImGuiNET;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Core.AC.Debugger {
    public class Inspector : IDisposable {
        private static uint _id = 0;
        private static int _pushId = 0;

        private Vector2 minWindowSize = new Vector2(500, 250);
        private Vector2 maxWindowSize = new Vector2(99999, 99999);
        private Vector4 iconTint = new Vector4(1, 1, 1, 1);
        private Vector2 iconSize = new Vector2(12, 12);

        private bool isDisposed = false;
        private int _ptr = 0;

        private string selectedId { get; set; }
        private InspectedObject _selected;
        private List<Inspector> inspectors = new List<Inspector>();

        public static object DRAG_SOURCE_OBJECT = null;
        private bool isOpen;

        /// <summary>
        /// An inspected object is an object wrapped with MemberInfo/Parent,
        /// so we can reflect against the parent to get the current value of
        /// primitives.
        /// </summary>
        public class InspectedObject {
            /// <summary>
            /// MemberInfo of an inspected object
            /// </summary>
            public MemberInfo MemberInfo = null;

            /// <summary>
            /// Parent object
            /// </summary>
            public object Parent = null;

            /// <summary>
            /// The type
            /// </summary>
            public Type Type {
                get {
                    switch (MemberInfo.MemberType) {
                        case MemberTypes.Property:
                            return (MemberInfo as PropertyInfo).PropertyType;
                        case MemberTypes.Field:
                            return (MemberInfo as FieldInfo).FieldType;
                        default:
                            return null;
                    }
                }
            }

            /// <summary>
            /// Value
            /// </summary>
            public object Value => GetMemberValue(Parent, MemberInfo);

            public InspectedObject(MemberInfo memberInfo, object parent) {
                MemberInfo = memberInfo;
                Parent = parent;
            }
        }

        public string Name { get; }

        /// <summary>
        /// The object being inspected.
        /// </summary>
        public object ToInspect { get; private set; }

        /// <summary>
        /// The object currently selected in the treeview
        /// </summary>
        public InspectedObject Selected {
            get => _selected;
            set {
                _selected = value;
            }
        }

        /// <summary>
        /// Wether to Dispose itself when the window is closed
        /// </summary>
        public bool DisposeOnClose { get; set; }

        /// <summary>
        /// Create a new Inspector window
        /// </summary>
        /// <param name="toInspect">The object to inspect</param>
        public Inspector(string name, object toInspect) {
            Name = name;
            ToInspect = toInspect;
            Selected = new InspectedObject(GetType().GetProperty("ToInspect", BindingFlags.Public | BindingFlags.Instance), this);
        }

        internal void Render() {
            try {
                ImGui.SetNextWindowSizeConstraints(minWindowSize, maxWindowSize);
                isOpen = true;
                if (ImGui.Begin(Name, ref isOpen)) {
                    _pushId = 0;
                    var pad = 15;
                    ImGui.BeginTable("InspectorTable", 2, ImGuiTableFlags.Resizable | ImGuiTableFlags.BordersInnerV | ImGuiTableFlags.NoSavedSettings);
                    {
                        ImGui.TableSetupColumn("ObjectTree", ImGuiTableColumnFlags.WidthFixed, 200);
                        ImGui.TableNextRow();
                        ImGui.TableSetColumnIndex(0);
                        ImGui.BeginChild("Object Tree", new Vector2(-1, ImGui.GetContentRegionAvail().Y - 4)); // object tree
                        try {
                            RenderObjectTree(Name, GetType().GetProperty("ToInspect", BindingFlags.Public | BindingFlags.Instance), this);
                        }
                        catch (Exception ex) { CoreACDebugger.Log.LogError(ex, "Failed to render object tree"); }
                        ImGui.EndChild(); // object tree
                        ImGui.TableSetColumnIndex(1);
                        ImGui.BeginChild("Object Info", new Vector2(-1, ImGui.GetContentRegionAvail().Y - 4)); // object info
                        try {
                            ImGui.PushID($"{Selected.GetHashCode()}.RenderDetails.{++_pushId}");
                            RenderDetails(Selected);
                            ImGui.PopID();
                        }
                        catch (Exception ex) { CoreACDebugger.Log.LogError(ex, "Failed to render object info"); }
                        ImGui.EndChild();
                    }
                    ImGui.EndTable();
                }
                ImGui.End();
                foreach (var inspector in inspectors.ToArray()) {
                    inspector.Render();
                    if (!inspector.isOpen) {
                        inspector.Dispose();
                        inspectors.Remove(inspector);
                    }
                }
            }
            catch (Exception ex) {
                CoreACDebugger.Log.LogError(ex, "Failed to render");
            }
        }

        private unsafe void RenderDetails(InspectedObject inspectedObject) {
            if (Selected.MemberInfo.MemberType == MemberTypes.Event) {
                var eventInfo = inspectedObject.MemberInfo as EventInfo;
                var eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

                if (eventField == null) {
                    ImGui.Text("null");
                    return;
                }

                ImGui.SameLine();
                ImGui.Text($"Event {TypeDisplayString(eventField.FieldType)} {eventField.Name}");
            }
            else {
                var type = Selected.Value == null ? Selected.Type : Selected.Value.GetType();
                ImGui.Text($"Type: {TypeDisplayString(type)}");
                if (ImGui.IsItemHovered()) {
                    ImGui.SetTooltip(TypeDisplayString(type, false));
                }

                if (inspectedObject.Value == null) {
                    ImGui.TextWrapped($"Value: null");
                }
                else if (inspectedObject.Type.IsPrimitive || inspectedObject.Type.IsEnum || inspectedObject.Type == typeof(string)) {
                    ImGui.TextWrapped($"Value: {DetailsDisplayString(inspectedObject.Value)}");
                }
                else {
                    ImGui.TextWrapped($"Value: {inspectedObject.Value}");

                    ImGui.Spacing();
                    ImGui.Separator();
                    ImGui.Spacing();

                    RenderEventsDetails(inspectedObject);
                    RenderPropertiesDetails(inspectedObject);
                    RenderFieldsDetails(inspectedObject);
                    RenderMethodsDetails(inspectedObject);

                    if (IsEnumerable(inspectedObject.Value)) {
                        RenderEnumerableChildrenDetails(inspectedObject);
                    }
                }
            }
        }

        private unsafe void RenderEnumerableChildrenDetails(InspectedObject inspectedObject) {
            var id = "EnumerableChildren" + Selected.GetHashCode().ToString();
            ImGui.Text($"Enumerable Contents:");
            if (ImGui.BeginTable(id, 2, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable)) {
                ImGui.TableSetupColumn("Key");
                ImGui.TableSetupColumn("Value");
                ImGui.TableHeadersRow();

                var enumerable = inspectedObject.Value as IEnumerable;

                var methodInfos = GetAllMethodInfos(inspectedObject.Value);
                var i = 0;
                foreach (var e in enumerable) {
                    ImGui.PushID($"enumerableItem.{++_pushId}");
                    if (e.GetType().IsGenericType && e.GetType().GetGenericTypeDefinition() == typeof(KeyValuePair<,>)) {
                        object kvpKey = e.GetType().GetProperty("Key").GetValue(e, null);
                        object kvpValue = e.GetType().GetProperty("Value").GetValue(e, null);
                        ImGui.TableNextColumn();
                        ImGui.Text(DetailsDisplayString(kvpKey));
                        ImGui.TableNextColumn();
                        RenderSimpleObjectDetails(kvpValue);
                    }
                    else {
                        ImGui.TableNextColumn();
                        ImGui.Text(i.ToString());
                        ImGui.TableNextColumn();
                        RenderSimpleObjectDetails(e);
                    }
                    ImGui.PopID();
                    i++;
                }

                ImGui.EndTable();
            }
            ImGui.Spacing();
            ImGui.Spacing();
        }

        private unsafe void RenderSimpleObjectDetails(object obj) {
            ImGui.PushID($"{Selected.GetHashCode()}.RenderSimpleObjectDetails.{++_pushId}");
            if (obj != null && !obj.GetType().IsEnum && !obj.GetType().IsPrimitive) {
                if (ImGui.Button("Inspect")) {
                    var inspector = new Inspector(DetailsDisplayString(obj), obj) {
                        DisposeOnClose = true
                    };
                    inspectors.Add(inspector);
                }
                ImGui.SameLine();
            }
            ImGui.Selectable(DetailsDisplayString(obj));
            if (ImGui.BeginDragDropSource(ImGuiDragDropFlags.None)) {
                DRAG_SOURCE_OBJECT = obj;
                int _ptr = 0;
                ImGui.SetDragDropPayload("OBJECT_INSTANCE", (nint)(&_ptr), sizeof(int));
                ImGui.Text(DetailsDisplayString(obj));
                ImGui.EndDragDropSource();
            }
            if (obj != null && ImGui.IsItemHovered()) {
                ImGui.SetTooltip(TypeDisplayString(obj.GetType(), false));
            }
            ImGui.PopID();
        }

        private unsafe void RenderMethodsDetails(InspectedObject inspectedObject) {
            var id = "Methods" + inspectedObject.Value.GetHashCode().ToString();
            ImGui.Text($"Methods:");
            if (ImGui.BeginTable(id, 3, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable)) {
                ImGui.TableSetupColumn("Name");
                ImGui.TableSetupColumn("Returns", ImGuiTableColumnFlags.WidthFixed, 140);
                ImGui.TableSetupColumn("Info", ImGuiTableColumnFlags.WidthFixed, 40);
                ImGui.TableHeadersRow();

                var methodInfos = GetAllMethodInfos(inspectedObject.Value);
                var i = 0;
                foreach (var method in methodInfos) {
                    var methodInfo = method as MethodInfo;
                    ImGui.PushID(i);
                    ImGui.TableNextColumn();
                    ImGui.Text(DetailsDisplayString(methodInfo));

                    if (ImGui.IsItemHovered()) {
                        var str = new StringBuilder();
                        str.AppendLine(GetMethodDisplayString(methodInfo, false));
                        ImGui.SetTooltip(str.ToString());
                    }
                    ImGui.TableNextColumn();
                    ImGui.Text(TypeDisplayString(methodInfo.ReturnType));
                    if (ImGui.IsItemHovered()) {
                        ImGui.SetTooltip(TypeDisplayString(methodInfo.ReturnType, false));
                    }
                    ImGui.TableNextColumn();
                    if (ImGui.Button("Inspect")) {
                        //methodInspectors.Add(new MethodInspector($"{TypeDisplayString(inspectedObject.Value.GetType())}.{GetMethodDisplayString(methodInfo)}", methodInfo, inspectedObject.Value));
                    }
                    ImGui.PopID();
                    i++;
                }

                ImGui.EndTable();
            }
            ImGui.Spacing();
            ImGui.Spacing();
        }

        private unsafe void RenderEventsDetails(InspectedObject inspectedObject) {
            var id = "Events" + inspectedObject.Value.GetHashCode().ToString();
            ImGui.Text($"Events:");
            if (ImGui.BeginTable(id, 4, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable)) {
                ImGui.TableSetupColumn("Event Name");
                ImGui.TableSetupColumn("EventArgs Type");
                ImGui.TableSetupColumn("Subscribers");
                ImGui.TableSetupColumn("Info");
                ImGui.TableHeadersRow();

                List<MemberInfo> members = GetAllEventInfos(inspectedObject.Value);

                foreach (var member in members) {
                    var eventInfo = member as EventInfo;
                    var eventInspectedObject = new InspectedObject(member, inspectedObject.Value);
                    Delegate[] delegates = GetEventDelegates(eventInspectedObject);
                    ImGui.TableNextColumn();
                    ImGui.Text($"{member.Name}");
                    ImGui.TableNextColumn();
                    ImGui.Text(TypeDisplayString(eventInfo.EventHandlerType.GetGenericArguments().FirstOrDefault()));
                    if (ImGui.IsItemHovered() && eventInfo.EventHandlerType.GetGenericArguments().Length > 0) {
                        ImGui.SetTooltip(TypeDisplayString(eventInfo.EventHandlerType.GetGenericArguments().First(), false));
                    }
                    ImGui.TableNextColumn();
                    ImGui.Text(delegates.Length.ToString());
                    if (delegates.Length > 0 && ImGui.IsItemHovered()) {
                        ImGui.BeginTooltip();
                        for (var i = 0; i < delegates.Length; i++) {
                            ImGui.Text($"#{i} {TypeDisplayString(delegates[i].Target.GetType(), false)}.{delegates[i].Method.Name}");
                        }
                        ImGui.EndTooltip();
                    }
                    ImGui.TableNextColumn();
                }

                ImGui.EndTable();
            }
            ImGui.Spacing();
            ImGui.Spacing();
        }

        private void RenderFieldsDetails(InspectedObject inspectedObject) {
            RenderMemberInfoDetailTable("Fields", "Field Name", inspectedObject, GetAllFieldInfos(inspectedObject.Value));
        }

        private unsafe void RenderPropertiesDetails(InspectedObject inspectedObject) {
            RenderMemberInfoDetailTable("Properties", "Property Name", inspectedObject, GetAllPropertyInfos(inspectedObject.Value));
        }

        private void RenderMemberInfoDetailTable(string headerText, string keyHeaderText, InspectedObject inspectedObject, List<MemberInfo> members) {
            var id = $"MemberInfoDetailTable.{headerText}";

            ImGui.Text(headerText);
            if (ImGui.BeginTable(id, 2, ImGuiTableFlags.Borders | ImGuiTableFlags.Resizable)) {
                ImGui.TableSetupColumn(keyHeaderText);
                ImGui.TableSetupColumn("Value");
                ImGui.TableHeadersRow();

                RenderMemberInfosDetailRows(inspectedObject, members);

                ImGui.EndTable();
            }
            ImGui.Spacing();
            ImGui.Spacing();
        }

        private void RenderMemberInfosDetailRows(InspectedObject inspectedObject, List<MemberInfo> members) {
            foreach (var member in members) {
                var inspectedMember = new InspectedObject(member, inspectedObject.Value);
                if (member is PropertyInfo propInfo && propInfo.GetIndexParameters().Any())
                    continue;
                ImGui.TableNextColumn();
                ImGui.Text($"{member.Name}");
                if (ImGui.IsItemHovered()) {
                    var str = new StringBuilder();
                    str.AppendLine(TypeDisplayString(inspectedMember.Type, false));
                    ImGui.SetTooltip(str.ToString());
                }
                ImGui.TableNextColumn();
                RenderSimpleObjectDetails(inspectedMember.Value);
            }
        }

        private void RenderObjectTree(string name, MemberInfo memberInfo, object parent, string history = "", uint depth = 0) {
            var toInspect = GetMemberValue(parent, memberInfo);
            var id = string.IsNullOrEmpty(history) ? name : $"{history}.{name}";
            List<MemberInfo> members = null;

            var showChildren = ShouldRenderTree(toInspect?.GetType());
            if (showChildren) {
                members = GetAllMemberInfos(toInspect);
                showChildren = showChildren && members.Count > 0;
            }

            var flags = ImGuiTreeNodeFlags.None | ImGuiTreeNodeFlags.OpenOnArrow | ImGuiTreeNodeFlags.OpenOnDoubleClick | ImGuiTreeNodeFlags.AllowOverlap;
            var isEnumerable = IsEnumerable(toInspect);
            if (toInspect != null && toInspect.GetType() == typeof(string))
                isEnumerable = false;
            var hasItems = isEnumerable && DoesEnumerableHaveChildren(toInspect);
            if (!showChildren || isEnumerable)
                flags |= ImGuiTreeNodeFlags.Leaf;
            if (id == selectedId)
                flags |= ImGuiTreeNodeFlags.Selected;

            var isExpanded = ImGui.TreeNodeEx(id, flags, name);
            if (ImGui.IsItemClicked()) {
                Selected = new InspectedObject(memberInfo, parent);
                selectedId = id;
            }

            if (isExpanded) {
                if (isEnumerable) {
                    /*
                    var enumerable = toInspect as IEnumerable;
                    var i = 0;
                    foreach (var x in enumerable) {
                        var eId = $"{id}.{i}";
                        ImGui.TreeNodeEx(id, ImGuiTreeNodeFlags.Leaf, $"#{i} {TypeDisplayString(x.GetType())}");
                        ImGui.TreePop();
                        i++;
                    }
                    */
                }
                else if (showChildren) {
                    foreach (var member in members) {
                        if (member is PropertyInfo propInfo && propInfo.GetIndexParameters().Any())
                            continue;
                        RenderObjectTree(member.Name, member, toInspect, id, depth + 1);
                    }
                }
                ImGui.TreePop();
            }
        }

        #region Static Helpers
        internal static bool DoesEnumerableHaveChildren(object toInspect) {
            if (toInspect.GetType().GetInterfaces().Any(x => x == typeof(IEnumerable))) {
                var i = toInspect as IEnumerable;
                if (i == null)
                    return false;
                var e = i.GetEnumerator();
                if (e == null)
                    return false;

                try {
                    return e.MoveNext();
                }
                catch { }
                return false;
            }

            return false;
        }

        internal static bool IsEnumerable(object toInspect) {
            if (toInspect == null) {
                return false;
            }
            if (toInspect.GetType().GetInterfaces().Any(x => x == typeof(IEnumerable))) {
                return true;
            }
            return false;
        }

        internal static object GetMemberValue(object toInspect, MemberInfo member) {
            try {
                if (member is PropertyInfo prop) {
                    if (prop.GetGetMethod(true) == null)
                        return null;
                    return prop.GetValue(toInspect, null);
                }
                else if (member is FieldInfo field) {
                    return field.GetValue(toInspect);
                }
            }
            catch (Exception ex) { CoreACDebugger.Log.LogError(ex, "GetMemberValue"); }
            return null;
        }

        internal static List<MemberInfo> GetAllMemberInfos(object toInspect) {
            if (toInspect == null)
                return new List<MemberInfo>();
            var members = new List<MemberInfo>();

            members.AddRange(GetAllPropertyInfos(toInspect));
            members.AddRange(GetAllFieldInfos(toInspect));
            //members.AddRange(GetAllEventInfos(toInspect));

            members.Sort((a, b) => a.Name.CompareTo(b.Name));

            return members;
        }

        internal static List<MemberInfo> GetAllEventInfos(object toInspect) {
            if (toInspect == null)
                return new List<MemberInfo>();
            var items = toInspect.GetType().GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Select(p => p as MemberInfo)
                .ToList();

            items.Sort((a, b) => a.Name.CompareTo(b.Name));
            return items;
        }

        internal static List<MemberInfo> GetAllFieldInfos(object toInspect) {
            if (toInspect == null)
                return new List<MemberInfo>();
            var items = toInspect.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance)
                //.Where(p => p.FieldType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() != typeof(EventHandler<>)) && ShouldRenderProp(p))
                .Select(p => p as MemberInfo)
                .ToList();

            items.Sort((a, b) => a.Name.CompareTo(b.Name));
            return items;
        }

        internal static List<MemberInfo> GetAllPropertyInfos(object toInspect) {
            if (toInspect == null)
                return new List<MemberInfo>();
            var items = toInspect.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => ShouldRenderProp(p)).Select(p => p as MemberInfo)
                .ToList();

            items.Sort((a, b) => a.Name.CompareTo(b.Name));
            return items;
        }

        internal static List<MemberInfo> GetAllMethodInfos(object toInspect) {
            if (toInspect == null)
                return new List<MemberInfo>();
            var items = toInspect.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(p => !p.IsSpecialName && p.DeclaringType == toInspect.GetType() && ShouldRenderProp(p)).Select(p => p as MemberInfo)
                .ToList();

            items.Sort((a, b) => a.Name.CompareTo(b.Name));
            return items;
        }

        internal static Delegate[] GetEventDelegates(InspectedObject inspectedObject) {
            Delegate[] delegates = new Delegate[] { };
            if (inspectedObject.MemberInfo is EventInfo eventInfo) {
                var eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);

                if (eventField == null) eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField);
                if (eventField == null) eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
                if (eventField == null) eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField);
                if (eventField == null) eventField = inspectedObject.Parent.GetType().GetField(eventInfo.Name, BindingFlags.GetField);

                if (eventField != null) {
                    var eDel = (Delegate)eventField.GetValue(inspectedObject.Parent);
                    if (eDel != null) {
                        delegates = eDel.GetInvocationList();
                    }
                }
            }
            return delegates;
        }

        internal static string DetailsDisplayString(object x) {
            if (x == null)
                return "null";
            else if (x.GetType() == typeof(ulong) || x.GetType() == typeof(long))
                return $"{x} (0x{x:X16})";
            else if (x.GetType() == typeof(uint) || x.GetType() == typeof(int))
                return $"{x} (0x{x:X8})";
            else if (x.GetType() == typeof(ushort) || x.GetType() == typeof(short))
                return $"{x} (0x{x:X4})";
            else if (x.GetType() == typeof(byte))
                return $"{x} (0x{x:X2})";
            else if (x.GetType().IsPrimitive)
                return x.ToString();
            else if (x.GetType() == typeof(string))
                return x.ToString();
            else if (x.GetType().IsEnum)
                return x.ToString();
            else if (x is MethodInfo methodInfo) {
                return GetMethodDisplayString(methodInfo);
            }
            else if (x is DateTime) {
                return x.ToString();
            }
            else if (x.GetType().GetMethods().Where(m => m.IsPublic && m.GetParameters().Length == 0 && m.Name == "ToString").Any()) {
                return x.ToString();
            }
            return TypeDisplayString(x.GetType());
        }

        internal static string GetMethodDisplayString(MethodInfo methodInfo, bool friendlyDisplay = true) {
            return $"{methodInfo.Name}{GetMethodInfoGenericTypeArgsDisplayString(methodInfo, friendlyDisplay)}({GetMethodArgumentsDisplayString(methodInfo, friendlyDisplay)})";
        }

        internal static object GetMethodArgumentsDisplayString(MethodInfo methodInfo, bool friendlyDisplay = true) {
            return string.Join(", ", methodInfo.GetParameters().Select(p => $"{TypeDisplayString(p.ParameterType, friendlyDisplay)} {p.Name}").ToArray());
        }

        internal static string GetMethodInfoGenericTypeArgsDisplayString(MethodInfo methodInfo, bool friendlyDisplay = true) {
            var genericArgs = methodInfo.GetGenericArguments();

            if (genericArgs.Length > 0) {
                return $"<{string.Join(", ", genericArgs.Select(a => TypeDisplayString(a, friendlyDisplay)).ToArray())}>";
            }
            return "";
        }

        internal static string TypeDisplayString(Type type, bool friendlyDisplay = true) {
            if (type == null)
                return "null";
            var name = $"{(friendlyDisplay ? "" : $"{type.Namespace}.")}{type.Name.Split('`').First()}";
            if (type.IsGenericType) {
                return $"{name}<{string.Join(", ", type.GetGenericArguments().Select(g => TypeDisplayString(g, friendlyDisplay)).ToArray())}>";
            }
            return name;
        }

        internal static string TreeDisplayString(object x) {
            if (x == null)
                return "null";
            if (x.GetType() == typeof(ulong) || x.GetType() == typeof(long))
                return $"{x} (0x{x:X16})";
            if (x.GetType() == typeof(uint) || x.GetType() == typeof(int))
                return $"{x} (0x{x:X8})";
            if (x.GetType() == typeof(ushort) || x.GetType() == typeof(short))
                return $"{x} (0x{x:X4})";
            if (x.GetType() == typeof(byte))
                return $"{x} (0x{x:X2})";
            if (x.GetType().IsPrimitive)
                return x.ToString();
            if (x.GetType() == typeof(string))
                return x.ToString();
            if (x.GetType().IsEnum)
                return $"{x.GetType().Name}.{x}";
            return x.GetType().Name;
        }

        internal static bool ShouldRenderProp(MemberInfo property) {
            return true;
        }

        internal static bool ShouldRenderTree(Type toInspect) {
            return toInspect != null &&
                !toInspect.IsPrimitive &&
                toInspect != typeof(string) &&
                !toInspect.IsEnum;
        }
        #endregion // Static Helpers

        public void Dispose() {
            if (!isDisposed) {
                inspectors.Clear();
                isDisposed = true;
            }
        }
    }
}
