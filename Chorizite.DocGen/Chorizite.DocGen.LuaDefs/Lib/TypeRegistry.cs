using Chorizite.Core;
using Chorizite.DocGen.LuaDefs.Lib.models;
using System.Reflection;
using System.Xml.Linq;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public abstract class TypeRegistry {
        public Dictionary<string, Def> Definitions { get; } = [];
        public Dictionary<string, ClassDef> Classes { get; } = [];
        public Dictionary<string, EnumDef> Enums { get; } = [];
        public Chorizite<DocGenBackend> Chorizite { get; }
        public ScriptableTypeFinder TypeFinder { get; }
        public abstract MetadataLoadContext LoadContext { get; }
        public abstract Assembly ChoriziteAssembly { get; }

        public Dictionary<string, XMLDocEntry> DocEntries { get; } = [];

        public TypeRegistry(Chorizite<DocGenBackend> chorizite, ScriptableTypeFinder scriptableTypeFinder) {
            Chorizite = chorizite;
            TypeFinder = scriptableTypeFinder;
        }

        protected void GenerateMemberDocs(string dllPath) {
            var assemblyXmlFile = dllPath.Replace(".dll", ".xml");
            if (!File.Exists(assemblyXmlFile) || !Path.GetExtension(assemblyXmlFile).Equals(".xml")) {
                return;
            }
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(File.ReadAllText(assemblyXmlFile));

            foreach (var e in xdoc.Descendants("member")) {
                if (string.IsNullOrEmpty(e.Attribute("name")?.Value)) continue;

                if (!DocEntries.ContainsKey(e.Attribute("name")!.Value)) {
                    DocEntries[e.Attribute("name")!.Value] = XMLDocEntry.FromMember(e);
                }
                else {
                    DocEntries.Add(e.Attribute("name")!.Value, XMLDocEntry.FromMember(e));
                }
            }

            foreach (var key in DocEntries.Keys) {
                var docs = DocEntries[key];
                if (docs.Summary?.StartsWith("inheritdoc|") == true) {
                    var id = docs.Summary.Split('|').Last();
                    if (DocEntries.TryGetValue(id, out var inheritedDocs)) {
                        DocEntries[key].Summary = inheritedDocs.Summary;
                    }
                }
            }
        }

        protected void LoadAssemblyTypes(Assembly assembly) {
            foreach (var type in assembly.GetTypes()) {
                if (!type.IsPublic) continue;

                if (type.IsEnum) {
                    var enumDef = new EnumDef(type, this);
                    Enums.Add(enumDef.XMLDocId, enumDef);
                    Definitions.Add(enumDef.XMLDocId, enumDef);
                }
                else if (type.IsClass || type.IsInterface) {
                    var classDef = new ClassDef(type, this);
                    Classes.Add(classDef.XMLDocId, classDef);
                    Definitions.Add(classDef.XMLDocId, classDef);
                }
            }

            // add base classes
            foreach (var cls in Classes.Values) {
                if (cls.Type.BaseType != null) {
                    cls.BaseClass = Classes.Values.FirstOrDefault(c => c.Type == cls.Type.BaseType);
                    cls.BaseClass ??= TypeFinder.CoreRegistry?.Classes.Values.FirstOrDefault(c => c.Type.FullName == cls.Type.BaseType.FullName);
                    cls.BaseClass ??= TypeFinder.SystemRegistry?.Classes.Values.FirstOrDefault(c => c.Type.FullName == cls.Type.BaseType.FullName);

                    if (cls.BaseClass?.Type.IsInterface == true) cls.BaseClass = null;

                    //if (cls.BaseClass == null) Console.WriteLine($"No base class for {cls.Type.Name}: {cls.Type.BaseType.Name}");
                }
            }
        }
    }
}