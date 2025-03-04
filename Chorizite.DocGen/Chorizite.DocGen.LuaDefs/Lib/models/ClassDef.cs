using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class ClassDef : Def {
        public Type Type { get; set; }

        public override string XMLDocId => $"T:{Type.FormatXMLDocIdType()}";

        public List<ClassPropertyDef> Properties { get; set; } = [];
        public List<ClassFieldDef> Fields { get; set; } = [];
        public List<EventDef> Events { get; set; } = [];
        public List<ConstructorDef> Constructors { get; set; } = [];
        public List<MethodDef> Methods { get; set; } = [];

        public List<ClassPropertyDef> StaticProperties { get; set; } = [];
        public List<ClassFieldDef> StaticFields { get; set; } = [];
        public List<MethodDef> StaticMethods { get; set; } = [];

        public ClassDef? BaseClass { get; set; }

        public bool HasPublicContructor => Type.GetConstructors().Any(c => c.IsPublic);

        public ClassDef(Type type, TypeRegistry typeRegistry) : base(typeRegistry) {
            Type = type;

            foreach (var prop in Type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
                Properties.Add(new ClassPropertyDef(prop, this, TypeRegistry));
            }

            foreach (var field in Type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
                Fields.Add(new ClassFieldDef(field, this, TypeRegistry));
            }

            foreach (var evt in Type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)) {
                Events.Add(new EventDef(evt, this, TypeRegistry));
            }

            foreach (var ctor in Type.GetConstructors(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)) {
                Constructors.Add(new ConstructorDef(ctor, this, TypeRegistry));
            }

            foreach (var method in Type.GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance)) {
                if (method.IsSpecialName) continue;
                Methods.Add(new MethodDef(method, this, TypeRegistry));
            }

            //statics

            foreach (var prop in Type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
                StaticProperties.Add(new ClassPropertyDef(prop, this, TypeRegistry));
            }

            foreach (var field in Type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
                StaticFields.Add(new ClassFieldDef(field, this, TypeRegistry));
            }

            foreach (var method in Type.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)) {
                StaticMethods.Add(new MethodDef(method, this, TypeRegistry));
            }
        }
    }
}
