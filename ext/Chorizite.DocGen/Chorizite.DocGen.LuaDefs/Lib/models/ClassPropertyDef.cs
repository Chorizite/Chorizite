using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class ClassPropertyDef : Def {
        public override string XMLDocId => $"P:{Parent.Type.FormatXMLDocIdType()}.{Property.Name}";

        public PropertyInfo Property { get; set; }
        public ClassDef Parent { get; }

        public ClassPropertyDef(PropertyInfo prop, ClassDef parent, TypeRegistry typeRegistry) : base(typeRegistry) {
            Property = prop;
            Parent = parent;
            Name = prop.Name;
        }
    }
}