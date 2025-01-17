using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class EnumDef : Def {
        public Type Type { get; set; }

        public List<EnumValueDef> Values { get; set; } = [];

        public override string XMLDocId => $"T:{Type.Namespace}.{Type.Name}";

        public EnumDef(Type type, TypeRegistry typeRegistry) : base(typeRegistry) {
            Type = type;
            Name = $"{type.Namespace}.{type.Name}";
            var names = Enum.GetNames(type);
            var values = Enum.GetValuesAsUnderlyingType(type);
            for (var i = 0; i < names.Length; i++) {
                var name = names[i];
                Values.Add(new EnumValueDef(this, name, $"0x{values.GetValue(i):X8}", TypeRegistry));
            }
        }
    }
}
