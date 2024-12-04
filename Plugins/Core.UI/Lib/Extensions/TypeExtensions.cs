using Core.UI.Lib.RmlUi.VDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UI.Lib.Extensions {
    internal static class TypeExtensions {
        public static IEnumerable<Type> GetBaseTypes(this Type type) {
            if (type.BaseType == null) return type.GetInterfaces();

            return new[] { type }.Concat(
                   Enumerable.Repeat(type.BaseType, 1)
                             .Concat(type.GetInterfaces())
                             .Concat(type.GetInterfaces().SelectMany<Type, Type>(GetBaseTypes))
                             .Concat(type.BaseType.GetBaseTypes()));
        }
    }
}
