using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class EventDef : Def {
        public ClassDef Parent { get; set; }
        public EventInfo EventInfo { get; set; }
        public override string XMLDocId => $"E:{Parent.Type.FormatXMLDocIdType()}.{EventInfo.Name}";

        public EventDef(EventInfo evt, ClassDef classDef, TypeRegistry typeRegistry) : base(typeRegistry) {
            EventInfo = evt;
            Parent = classDef;
        }
    }
}