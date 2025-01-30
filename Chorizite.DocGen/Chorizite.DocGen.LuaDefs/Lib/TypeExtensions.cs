using Chorizite.DocGen.LuaDefs.Lib.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.DocGen.LuaDefs.Lib {
    internal static class TypeExtensions {
        public static string GetXMLDocId(this Type type) {
            if (type.IsEnum) return $"T:{type.FormatXMLDocIdType()}";
            if (type.IsClass) return $"T:{type.FormatXMLDocIdType()}";

            return $"T:{type.FormatXMLDocIdType()}";
        }

        public static string FormatXMLDocIdType(this Type type) {
            if (type == null)
                return "null";
            if (type.IsGenericType) {
                var typeStr = $"{type.Name.Split('`').First()}";
                var genericTypeArgs = type.GetGenericArguments().Select(a => FormatXMLDocIdType(a));

                return $"{type.Namespace}.{typeStr}<{string.Join(", ", genericTypeArgs)}>";
            }

            return $"{type.Namespace}.{type.Name.Replace("&", "")}";
        }
    }
}
