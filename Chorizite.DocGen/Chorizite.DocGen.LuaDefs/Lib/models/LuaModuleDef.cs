using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    internal class LuaModuleDef : Def {
        public override string XMLDocId => $"Module:{Name}";

        public Dictionary<string, ClassDef> Classes { get; } = [];
        public Dictionary<string, EnumDef> Enums { get; } = [];

        public ClassDef EntryClass { get; private set; }

        public LuaModuleDef(string moduleName, TypeRegistry typeRegistry, ClassDef entryClass) : base(typeRegistry) {
            EntryClass = entryClass;
            Name = moduleName;

            AddClass(EntryClass);

            var luaNamespaceAttributes = EntryClass.Type.CustomAttributes.Where(a => a.AttributeType.Name == "LuaModuleNamespaceAttribute").ToArray();

            foreach (var attribute in luaNamespaceAttributes) {
                var args = attribute.ConstructorArguments.First().Value as ReadOnlyCollection<CustomAttributeTypedArgument>;
                Console.WriteLine($"Adding types from namespace {args}");
                if (args is not null) {
                    foreach (var arg in args) {
                        AddTypesFromNamespace(arg.Value as string);
                    }
                }
            }
        }

        private void AddTypesFromNamespace(string? ns) {
            if (ns is null) return;
            Console.WriteLine($"Adding types from namespace {ns}");
            foreach (var type in TypeRegistry.Classes.Values.Where(c => c.Type.Namespace?.StartsWith(ns) == true)) {
                AddType(type.Type);
            }
            foreach (var type in TypeRegistry.Enums.Values.Where(c => c.Type.Namespace?.StartsWith(ns) == true)) {
                AddType(type.Type);
            }
        }

        private void AddClass(ClassDef cls) {
            if (Classes.ContainsKey(cls.XMLDocId)) {
                return;
            }

            Classes.Add(cls.XMLDocId, cls);

            foreach (var prop in cls.Properties) {
                AddType(prop.Property.PropertyType);
            }
            foreach (var prop in cls.StaticProperties) {
                AddType(prop.Property.PropertyType);
            }
            foreach (var field in cls.Fields) {
                AddType(field.Field.FieldType);
            }
            foreach (var field in cls.StaticFields) {
                AddType(field.Field.FieldType);
            }
            foreach (var evt in cls.Events) {
                if (evt.EventInfo.EventHandlerType is null) continue;
                AddType(evt.EventInfo.EventHandlerType.GenericTypeArguments.First());
            }
            foreach (var ctor in cls.Constructors) {
                foreach (var param in ctor.CTor.GetParameters()) {
                    AddType(param.ParameterType);
                }
            }
            foreach (var method in cls.Methods) {
                foreach (var param in method.Method.GetParameters()) {
                    AddType(param.ParameterType);
                }
            }
        }

        private void AddType(Type type) {
            if (type.IsPrimitive || type.Name == "String") return;
            if (type.IsGenericType) {
                foreach (var arg in type.GetGenericArguments()) {
                    AddType(arg);
                }
                return;
            }
            Def? def = TypeRegistry.TypeFinder.GetTypeDef(type);
            if (def is null) {
                //Console.WriteLine($"No type for {type} ({type.GetXMLDocId()} // {Name})");
                return;
            }

            if (def is ClassDef classDef) {
                AddClass(classDef);
            }
            else if (def is EnumDef enumDef) {
                if (enumDef.XMLDocId.Contains("Chorizite.Common")) return;
                Enums.TryAdd(enumDef.Name, enumDef);
            }
        }
    }
}
