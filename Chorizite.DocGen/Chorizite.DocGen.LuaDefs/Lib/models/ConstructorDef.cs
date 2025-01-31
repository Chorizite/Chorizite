using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class ConstructorDef : Def {
        public ConstructorInfo CTor { get; set; }
        public ClassDef Parent { get; set; }
        public override string XMLDocId => $"M:{Parent.Type.FormatXMLDocIdType()}.{CTor.Name}";

        public ConstructorDef(ConstructorInfo ctor, ClassDef classDef, TypeRegistry typeRegistry) : base(typeRegistry) {
            CTor = ctor;
            Parent = classDef;
            Name = ctor.Name;
        }
    }
}