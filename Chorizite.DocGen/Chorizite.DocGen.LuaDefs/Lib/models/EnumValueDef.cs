using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class EnumValueDef : Def {
        public string Value { get; set; } = "";

        public override string XMLDocId => $"F:{Parent.Type.FormatXMLDocIdType()}.{Name}";

        public EnumDef Parent { get; set; }

        public EnumValueDef(EnumDef parent, string name, string value, TypeRegistry typeRegistry) : base(typeRegistry) {
            Parent = parent;
            Name = name;
            Value = value;
        }
    }
}