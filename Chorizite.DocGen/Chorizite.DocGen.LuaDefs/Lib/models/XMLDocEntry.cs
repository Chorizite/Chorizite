using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public class XMLDocEntry {
        private static Regex trimRegex = new Regex("(^\\s+|\\s+$)", RegexOptions.Multiline | RegexOptions.Compiled);
        private static Regex seeRe = new Regex(@"<see cref=""[A-Z]:(.*?)"" />", RegexOptions.Multiline | RegexOptions.Compiled);
        private string _summary;

        public string Id { get; set; }
        public string Summary {
            get {
                return seeRe.Replace(trimRegex.Replace(_summary, string.Empty), "`CS.$1`")
                    .Replace("<summary>", "").Replace("</summary>", "");
            }
            set {
                _summary = value;
            }
        }

        internal static XMLDocEntry FromMember(XElement e) {
            string summary;
            if (e.Elements("inheritdoc").Count() > 0) {
                summary = $"inheritdoc|{e.Element("inheritdoc").Attribute("cref")?.Value}";
            }
            else {
                summary = e.Element("summary")?.Value ?? "";
            }
            summary = trimRegex.Replace(summary, string.Empty);

            /*
            foreach (var pEl in e.Elements("param")) {
                docs.Params.Add(pEl.Attribute("name").Value, trimRegex.Replace(pEl.Value ?? "", string.Empty));
            }
            
            docs.Returns = trimRegex.Replace(e.Element("returns")?.Value ?? "", string.Empty);
            */
            return new XMLDocEntry() {
                Summary = summary
            };
        }

        public static string MakeId(Def def) {
            if (def is ClassDef classDef) return classDef.Type.GetXMLDocId();
            if (def is EnumDef enumDef) return enumDef.Type.GetXMLDocId();

            return $"UnknownType:{def}";
            /*
            switch (ObjectType) {
                case ScriptObjectType.Struct:
                case ScriptObjectType.Class:
                case ScriptObjectType.Enum:
                    return $"T:{FormatType(Type)}";
                case ScriptObjectType.Property:
                    return $"P:{FormatType(ParentType)}.{Name}";
                case ScriptObjectType.EnumField:
                case ScriptObjectType.Field:
                    return $"F:{FormatType(ParentType)}.{Name}";
                case ScriptObjectType.Constructor:
                    return $"M:{FormatMethod(ParentType, MemberInfo as ConstructorInfo)}";
                case ScriptObjectType.Method:
                    return $"M:{FormatMethod(ParentType, MemberInfo as MethodInfo)}";
                case ScriptObjectType.Event:
                    return $"E:{FormatType(ParentType)}.{Name}";
                default:
                    return $"UnknownId:{Type.FullName}//{Name}";
            }
            */
        }
    }
}
