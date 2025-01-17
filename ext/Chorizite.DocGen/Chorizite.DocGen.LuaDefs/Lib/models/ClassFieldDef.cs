using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class ClassFieldDef : Def {
        public FieldInfo Field { get; set; }
        public ClassDef Parent { get; set; }

        public override string XMLDocId => $"F:{Parent.Type.FormatXMLDocIdType()}.{Field.Name}";

        public ClassFieldDef(FieldInfo field, ClassDef parent, TypeRegistry typeRegistry) : base(typeRegistry) {
            Field = field;
            Parent = parent;
        }
    }
}