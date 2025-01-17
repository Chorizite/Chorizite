using Chorizite.Core;
using Chorizite.Core.Logging;
using Chorizite.DocGen.LuaDefs.Lib;
using Chorizite.DocGen.LuaDefs.Lib.models;
using Microsoft.Win32;
using NuDoq;
using System;
using Autofac;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Autofac.Core;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Backend.Launcher;

namespace Chorizite.DocGen.LuaDefs {
    internal class LuaDefsGenerator {
        private  List<string> _namespaces = [];
        private readonly Chorizite<DocGenBackend> chorizite;
        private readonly ChoriziteLogger log;
        private readonly ScriptableTypeFinder typeFinder;
        private readonly string _outPath;
        private HttpClient _http;

        internal readonly static Dictionary<string, Def> UsedDefs = [];

        public LuaDefsGenerator(Chorizite<DocGenBackend> chorizite, ChoriziteLogger log, ScriptableTypeFinder typeFinder) {
            this.chorizite = chorizite;
            this.log = log;
            this.typeFinder = typeFinder;

            _outPath = Path.Combine(chorizite.Config.BaseDirectory, "Lua", "defs");
            if (!Directory.Exists(_outPath)) {
                Directory.CreateDirectory(_outPath);
            }
            GenerateCSDefs();
            GenerateCoreModuleDefs();
            GenerateCoreDefs();
            GeneratePluginDefs();

            Console.WriteLine($"Types: {UsedDefs.Count}");
        }

        private void GenerateCSDefs() {
            var _out = new StringBuilder();
            _out.AppendLine("---@meta _system");
            _out.AppendLine();
            _out.AppendLine("local _defs = {}");
            _out.AppendLine();

            _out.AppendLine(File.ReadAllText("cs.lua"));

            foreach (var e in typeFinder.SystemRegistry.Enums) {
                if (!IsWantedType(e.Value)) continue;
                WriteEnumDef(e.Value, _out, typeFinder.SystemRegistry);
            }

            foreach (var cls in typeFinder.SystemRegistry.Classes) {
                if (!IsWantedType(cls.Value)) continue;
                WriteClassDef(cls.Value, _out, typeFinder.SystemRegistry);
            }

            File.WriteAllText(Path.Combine(_outPath, "_system.lua"), _out.ToString());
        }

        private void GenerateCoreModuleDefs() {
            foreach (var kv in chorizite.Backend.LuaModules) {
                GenerateModuledefs(kv.Key, kv.Value.GetType());
            }

            GenerateModuledefs("ClientBackend", typeof(IClientBackend));
            GenerateModuledefs("LauncherBackend", typeof(ILauncherBackend));
            GenerateModuledefs("Backend", typeof(Chorizite.Core.Backend.IChoriziteBackend));
        }

        private void GenerateCoreDefs() {
            _namespaces = [];
            var _out = new StringBuilder();
            _out.AppendLine("---@meta _chorizite");
            _out.AppendLine();
            _out.AppendLine("local _defs = {}");
            _out.AppendLine();

            foreach (var e in typeFinder.CoreRegistry.Enums) {
                if (!IsWantedType(e.Value)) continue;
                WriteEnumDef(e.Value, _out, typeFinder.SystemRegistry);
            }

            foreach (var cls in typeFinder.CoreRegistry.Classes) {
                if (!IsWantedType(cls.Value)) continue;
                WriteClassDef(cls.Value, _out, typeFinder.SystemRegistry);
            }

            File.WriteAllText(Path.Combine(_outPath, "_chorizite.lua"), _out.ToString());
        }

        private void GenerateModuledefs(string key, Type type) {
            _namespaces = [];
            var cls = typeFinder.CoreRegistry.Classes.Values.Where(c => c.Type.Name == type.Name).FirstOrDefault();
            var interfaces = type.GetInterfaces()
                .Where(i => !i.Namespace.StartsWith("System")).ToList();
            if (interfaces.Count == 1) {
                cls = typeFinder.CoreRegistry.Classes.Values.Where(c => c.Type.Name == interfaces[0].Name).FirstOrDefault();
            }
            else if (interfaces.Count > 1) {
                Console.WriteLine($"\t Interfaces: {string.Join(", ", interfaces.Select(i => i.Name))} for {type.Name} for {key}");
                throw new System.Exception("Too many interfaces");
            }

            if (cls is null) {
                Console.WriteLine($"No module class found for {type.Name} ({key})");
                return;
            }

            Console.WriteLine($"Generating defs for {cls.Type.Name}: {key}");

            var luaModule = new LuaModuleDef(key, typeFinder.CoreRegistry, cls);

            WriteLuaModule(luaModule);
        }

        private void WriteLuaModule(LuaModuleDef luaModule) {
            _namespaces = [];
            var _out = new StringBuilder();
            _out.AppendLine($"---@meta {luaModule.Name}");
            _out.AppendLine();
            _out.AppendLine("local _defs = {}");
            _out.AppendLine();

            foreach (var cls in luaModule.Classes.Values) {
                if (!IsWantedType(cls)) continue;
                if (cls.Type.Namespace.StartsWith("Chorizite.Core") && !cls.Type.Namespace.StartsWith(luaModule.EntryClass.Type.Namespace)) continue;
                WriteClassDef(cls, _out, luaModule.TypeRegistry, cls == luaModule.EntryClass);
            }

            foreach (var e in luaModule.Enums.Values) {
                if (!IsWantedType(e)) continue;
                if (e.Type.Namespace.StartsWith("Chorizite.Core") && !e.Type.Namespace.StartsWith(luaModule.EntryClass.Type.Namespace)) continue;
                WriteEnumDef(e, _out, luaModule.TypeRegistry);
            }

            _out.AppendLine();
            _out.AppendLine($"return moduleInstance");

            File.WriteAllText(Path.Combine(_outPath, $"{luaModule.Name}.lua"), _out.ToString());
        }

        private void GeneratePluginDefs() {
            if (!Directory.Exists(Path.Combine(_outPath, "Plugins"))) {
                Directory.CreateDirectory(Path.Combine(_outPath, "Plugins"));
            }

            foreach (var r in typeFinder.PluginRegistry.Values) {
                _namespaces = [];

                GeneratePluginDef(r);
            }
        }

        private void GeneratePluginDef(PluginTypeRegistry r) {
            var _out = new StringBuilder();
            _out.AppendLine($"-- {r.PluginInstance.Name} (version {r.PluginInstance.Manifest.Version} by {r.PluginInstance.Manifest.Author})<br />");
            _out.AppendLine($"-- {r.PluginInstance.Manifest.Description}");
            _out.AppendLine($"---@meta Plugins.{r.PluginInstance.Name}");
            _out.AppendLine();
            _out.AppendLine("local _defs = {}");
            _out.AppendLine();

            foreach (var c in r.Classes) {
                if (!IsWantedType(c.Value)) continue;
                WriteClassDef(c.Value, _out, r, c.Value.Type.BaseType?.Name == "IPluginCore");
            }

            foreach (var e in r.Enums) {
                if (!IsWantedType(e.Value)) continue;
                WriteEnumDef(e.Value, _out, r);
            }

            _out.AppendLine($"return moduleInstance");

            File.WriteAllText(Path.Combine(_outPath, "Plugins", $"{r.PluginInstance.Name}.lua"), _out.ToString());
        }

        private void WriteClassDef(ClassDef value, StringBuilder _out, TypeRegistry r, bool isEntryClass = false) {
            UsedDefs.Add(value.XMLDocId, value);
            EnsureNamespace(_out, value.Type.Namespace);
            var name = MakeLuaType(r, value.Type);

            _out.AppendLine($"---@class {name}TypeWrapper : TypeWrapper");
            

            foreach (var prop in value.StaticProperties) {
                WriteClassProperty(prop, _out, r);
            }
            foreach (var field in value.StaticFields) {
                WriteClassField(field, _out, r);
            }

            foreach (var ctor in value.Constructors) {
                if (ctor.CTor.GetParameters().Any(p => p.ParameterType.Name.Contains("*"))) continue;
                _out.AppendLine($"---@overload fun({string.Join(", ", ctor.CTor
                    .GetParameters().Select(p => $"{p.Name}: {MakeLuaType(r, p.ParameterType)}"))}): {name}");
            }
            _out.AppendLine($"CS.{value.Type.Namespace}.{value.Type.Name} = {{}}");

            _out.AppendLine();


            if (value.BaseClass is not null) {
                _out.AppendLine($"---@class {name} : {MakeLuaType(r, value.BaseClass.Type)}");
            }
            else if (value.Type.IsClass && name != "CS.System.Object") {
                _out.AppendLine($"---@class {name} : CS.System.Object");
            }
            else {
                _out.AppendLine($"---@class {name}");
            }
            
            WriteSummary(_out, value);
            foreach (var prop in value.Properties.Concat(value.StaticProperties)) {
                WriteClassProperty(prop, _out, r);
            }
            foreach (var field in value.Fields.Concat(value.StaticFields)) {
                WriteClassField(field, _out, r);
            }

            var localName = "_defs." + name.Split('.').Last();
            _out.AppendLine($"{localName} = {{}}");
            _out.AppendLine();

            foreach (var method in value.Methods) {
                if (method.Method.Name.StartsWith("<")) continue;
                if (method.Method.Name.EndsWith("Async")) continue;
                if (method.Method.ReturnType.Name.Contains("*")) continue;
                if (method.Method.ReturnType.Name == "IAsyncResult") continue;
                if (method.Method.GetParameters().Any(p => p.ParameterType.Name.Contains("IAsyncResult"))) continue;
                if (method.Method.GetParameters().Any(p => p.ParameterType.Name.Contains("*"))) continue;
                if (method.Method.GetParameters().Any(p => p.ParameterType.Name.Contains("&"))) continue;
                if (method.Method.GetParameters().Any(p => p.ParameterType.ContainsGenericParameters)) continue;
                foreach (var param in method.Method.GetParameters()) {
                    _out.AppendLine($"---@param {FixParameterName(param.Name)} {MakeLuaType(r, param.ParameterType)}");
                }
                if (method.Method.ReturnType.Name != "Void") {
                    _out.AppendLine($"---@return {MakeLuaType(r, method.Method.ReturnType)}");
                }
                WriteSummary(_out, method);
                _out.AppendLine($"function {localName}:{method.Method.Name}({string.Join(", ", method.Method.GetParameters().Select(p => FixParameterName(p.Name)))}) end");
                _out.AppendLine();
            }

            if (isEntryClass) {
                _out.AppendLine($"local moduleInstance = {{}}");
            }

            _out.AppendLine();
        }

        private string? FixParameterName(string? name) {
            if (name == "end") return "endValue";
            return name;
        }

        private void WriteClassField(ClassFieldDef field, StringBuilder _out, TypeRegistry r) {
            var summary = "";
            var tags = new List<string>();
            if (field.Field.IsInitOnly || field.Field.IsLiteral) {
                tags.Add("readonly");
            }
            if (field.Field.IsStatic == true) {
                tags.Add("static");
            }
            if (!string.IsNullOrEmpty(field.GetSummary())) {
                summary = $"{field.GetSummary().Replace("\n", "<br />")}";
            }
            if (tags.Count > 0) {
                summary = $"**[{string.Join(", ", tags)}]** {summary}";
            }

            var luaType = MakeLuaType(r, field.Field.FieldType);
            if (luaType.StartsWith("CS.System.Func")) return;
            if (luaType.StartsWith("CS.System.Globalization.CultureInfo")) return;
            if (luaType.StartsWith("CS.System.Threading.SynchronizationContext")) return;
            if (luaType.Contains("CS.RoyT.TrueType.Tables.Kern.KerningPair")) return;

            _out.AppendLine($"---@field {field.Field.Name} {luaType} {summary}");
        }

        private void WriteClassProperty(ClassPropertyDef prop, StringBuilder _out, TypeRegistry r) {
            var summary = "";
            if (!string.IsNullOrEmpty(prop.GetSummary())) {
                summary = $"{prop.GetSummary().Replace("\n", "<br />")}";
            }

            var tags = new List<string>();
            if (!prop.Property.CanWrite) {
                tags.Add("readonly");
            }
            if (prop.Property.GetGetMethod()?.IsStatic == true) {
                tags.Add("static");
            }
            if (tags.Count > 0) {
                summary = $"**[{string.Join(", ", tags)}]** {summary}";
            }

            var luaType = MakeLuaType(r, prop.Property.PropertyType);
            if (luaType.StartsWith("CS.System.Globalization.CultureInfo")) return;
            if (luaType.StartsWith("CS.System.Threading.SynchronizationContext")) return;
            if (luaType.Contains("CS.RoyT.TrueType.Tables.Kern.KerningPair")) return;

            _out.AppendLine($"---@field {prop.Property.Name} {luaType} {summary}");
        }

        private void WriteEnumDef(EnumDef value, StringBuilder _out, TypeRegistry r) {
            UsedDefs.Add(value.XMLDocId, value);
            
            _out.AppendLine($"---@enum {MakeLuaType(r, value.Type)}");
            
            WriteSummary(_out, value);
            _out.AppendLine($"CS.{value.Type.Namespace}.{value.Type.Name} = {{");

            foreach (var v in value.Values) {
                WriteSummary(_out, v, "\t");
                _out.AppendLine($"\t{v.Name} = {v.Value},");
            }

            _out.AppendLine("}");
            _out.AppendLine();
        }

        private void EnsureNamespace(StringBuilder _out, string? ns) {
            if (string.IsNullOrEmpty(ns)) return;

            if (!_namespaces.Contains("CS")) {
                _out.AppendLine($"CS = CS or {{}}");
                _namespaces.Add("CS");
            }

            var didAdd = false;
            var namespaces = ns.Split('.');
            for (var i = 0; i < namespaces.Length; i++) {
                var nspre = string.Join(".", namespaces.Take(i + 1).ToArray());

                if (!_namespaces.Contains(nspre)) {
                    _out.AppendLine($"CS.{nspre} = CS.{nspre} or {{}}");
                    _namespaces.Add(nspre);
                    didAdd = true;
                }
            }

            if (didAdd) {
                _out.AppendLine();
            }
        }

        private void WriteSummary(StringBuilder _out, Def value, string? indent=null) {
            var summary = value.GetSummary()?.Replace("\r", "").TrimEnd('\n');
            if (!string.IsNullOrEmpty(summary)) {
                _out.AppendLine($"{indent}-- {summary.Replace("\n", $"\n{indent}-- ")}");
            }
        }

        private bool IsWantedType(Def value) {
            if (UsedDefs.ContainsKey(value.XMLDocId)) return false;

            if (value is ClassDef classDef) {
                if (classDef.Type.IsGenericType) return false;
                if (!classDef.Type.IsPublic) return false;
                if (classDef.Type.Namespace.StartsWith("XLua")) return false;
                if (classDef.Type.CustomAttributes.Any(a => a.AttributeType.Name == "HideScriptingAttribute")) return false;
                return true;
            }
            if (value is EnumDef enumDef) {
                if (!enumDef.Type.IsPublic) return false;
                if (enumDef.Type.Namespace.StartsWith("XLua")) return false;
                if (enumDef.Type.CustomAttributes.Any(a => a.AttributeType.Name == "HideScriptingAttribute")) return false;
                return true;
            }
            return true;
        }

        private string MakeLuaType(TypeRegistry registry, Type propertyType) {
            if (propertyType.Name.StartsWith("Action`") || propertyType.Name.StartsWith("Func`")) {
                var numArgs = propertyType.GetGenericArguments().Length;
                return FormatType(registry, propertyType).Substring(10)
                    .Replace("Func<", $"Func{(numArgs > 1 ? numArgs.ToString() : "")}<")
                    .Replace("Action<", $"Action{(numArgs >= 1 ? numArgs.ToString() : "")}<")
                    .Replace("CS.System.Action", "Action");
            }

            var _mlc = registry.LoadContext;
            var fullName = $"{propertyType.Namespace}.{propertyType.Name}";
            var isArray = false;
            if (fullName.EndsWith("[]")) {
                fullName = fullName.Substring(0, fullName.Length - 2);
                isArray = true;
            }
            string type = "";

            if (fullName == "System.String") type = "string";
            if (fullName == "System.Byte") type = "number";
            if (fullName == "System.SByte") type = "number";
            if (fullName == "System.Decimal") type = "number";
            if (fullName == "System.Half") type = "number";
            if (fullName == "System.Int32") type = "number";
            if (fullName == "System.UInt32") type = "number";
            if (fullName == "System.Int16") type = "number";
            if (fullName == "System.UInt16") type = "number";
            if (fullName == "System.Int64") type = "number";
            if (fullName == "System.UInt64") type = "number";
            if (fullName == "System.Single") type = "number";
            if (fullName == "System.Double") type = "number";
            if (fullName == "System.Boolean") type = "boolean";
            if (fullName == "System.Char") type = "number";

            if (!string.IsNullOrEmpty(type)) {
                if (isArray) type += "[]";
                return type;
            }

            return FormatType(registry, propertyType);
        }

        public string FormatType(TypeRegistry registry, Type type) {
            if (type == null || type == typeof(void)) {
                return "void";
            }

            if (type.IsGenericType || type.IsGenericParameter || type.GetGenericArguments().Length > 0) {
                var typeStr = $"CS.{type.Namespace}.{type.Name.Split('`').First()}";
                var genericTypeArgs = type.GetGenericArguments().Select(a => MakeLuaType(registry, a));

                if (genericTypeArgs.Count() == 1 && typeStr == "CS.System.Nullable") {
                    return genericTypeArgs.First() + "?";
                }

                return $"{typeStr}<{string.Join(",", genericTypeArgs)}>";
            }

            return $"CS.{type.Namespace}.{type.Name.Split('`').First().Split('&').First()}";
        }
    }
}