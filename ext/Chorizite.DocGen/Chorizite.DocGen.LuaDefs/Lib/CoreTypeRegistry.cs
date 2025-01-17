using Autofac;
using Chorizite.Core;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public class CoreTypeRegistry : TypeRegistry {
        private MetadataLoadContext _loadContext;
        private Assembly _choriziteAssembly;
        private Assembly _choriziteCommonAssembly;

        public override MetadataLoadContext LoadContext => _loadContext;
        public override Assembly ChoriziteAssembly => _choriziteAssembly;
        public Assembly ChoriziteCommonAssembly => _choriziteCommonAssembly;

        public CoreTypeRegistry(Chorizite<DocGenBackend> chorizite, ScriptableTypeFinder scriptableTypeFinder) : base(chorizite, scriptableTypeFinder) {
            Init();
        }

        private void Init() {
            List<string> paths = [];

            // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
            paths.AddRange(Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll"));
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll")) {
                paths.Add(file);
            }

            foreach (var path in paths) {
                GenerateMemberDocs(path);
            }

            // Create PathAssemblyResolver that can resolve assemblies using the created list.
            var resolver = new PathAssemblyResolver(paths);

            _loadContext = new MetadataLoadContext(resolver, "mscorlib");
            _choriziteAssembly = LoadContext.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "Chorizite.Core.dll"));
            _choriziteCommonAssembly = LoadContext.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "Chorizite.Common.dll"));

            LoadAssemblyTypes(_choriziteAssembly);
            LoadAssemblyTypes(_choriziteCommonAssembly);
            LoadAssemblyTypes(LoadContext.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "Chorizite.ACProtocol.dll")));
            LoadAssemblyTypes(LoadContext.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "DatReaderWriter.dll")));
        }
    }
}