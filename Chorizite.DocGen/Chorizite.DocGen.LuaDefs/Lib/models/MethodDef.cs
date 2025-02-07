using System.Reflection;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class MethodDef : Def {
        public override string XMLDocId => $"M:{Parent.Type.FormatXMLDocIdType()}.{Method.Name}{MakeParams()}";

        public MethodInfo Method { get; }
        public ClassDef Parent { get; }

        public MethodDef(MethodInfo method, ClassDef parent, TypeRegistry typeRegistry) : base(typeRegistry) {
            Method = method;
            Parent = parent;
            Name = method.Name;
        }

        private string MakeParams() {
            if (Method.GetParameters().Length == 0) return "";

            return $"({string.Join(",", Method.GetParameters().Select(p => p.ParameterType.FormatXMLDocIdType().Split(':').Last()))})";
        }
    }
}