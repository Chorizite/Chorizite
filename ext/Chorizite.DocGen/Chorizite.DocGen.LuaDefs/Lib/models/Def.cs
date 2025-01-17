using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Chorizite.DocGen.LuaDefs.Lib.models {
    public abstract class Def {
        protected MetadataLoadContext _mlc => TypeRegistry.LoadContext;
        protected static Dictionary<Assembly, Dictionary<string, XMLDocEntry>> _docsCache = [];

        public TypeRegistry TypeRegistry { get; }
        public string Name { get; set; }
        public abstract string XMLDocId { get; }

        public Def(TypeRegistry typeRegistry) {
            TypeRegistry = typeRegistry;
        }

        internal string? GetSummary() {
            if (TypeRegistry.DocEntries.TryGetValue(XMLDocId, out var docs)) {
                return docs.Summary;
            }
            return null;
        }
    }
}