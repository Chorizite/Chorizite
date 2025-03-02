using Chorizite.Core.Plugins;
using Chorizite.Core;
using Chorizite.Core.Plugins.AssemblyLoader;
using System.Reflection;
using System.Runtime.InteropServices;
using Autofac;
using Chorizite.DocGen.LuaDefs.Lib.models;
using System.Xml.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Chorizite.DocGen.LuaDefs.Lib {
    public class PluginTypeRegistry : TypeRegistry {
        private MetadataLoadContext _loadContext;

        public Assembly Assembly { get; private set; }

        private Assembly _choriziteAssembly;
        public PluginManifest Manifest { get; set; }
        public string EntryAssemblyPath { get; }
        public List<string> AllAssemblyPaths { get; }

        public override MetadataLoadContext LoadContext => _loadContext;
        public override Assembly ChoriziteAssembly => _choriziteAssembly;

        public PluginTypeRegistry(ScriptableTypeFinder scriptableTypeFinder, Chorizite<DocGenBackend> chorizite, PluginManifest manifest) : base(chorizite, scriptableTypeFinder) {
            Manifest = manifest;

            EntryAssemblyPath = Path.Combine(Manifest.BaseDirectory, Manifest.EntryFile);

            AllAssemblyPaths = Directory.GetFiles(Manifest.BaseDirectory, "*.dll").ToList();
            Init([ EntryAssemblyPath ]);
        }

        private void Init(List<string> paths) {
            // Create the list of assembly paths consisting of runtime assemblies and the inspected assembly.
            paths.AddRange(Directory.GetFiles(RuntimeEnvironment.GetRuntimeDirectory(), "*.dll"));
            foreach (var file in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll")) {
                paths.Add(file);
            }

            var plugins = Chorizite.Scope.Resolve<IPluginManager>().Plugins;

            foreach (var plugin in plugins) {
                foreach (var file in Directory.GetFiles(plugin.Manifest.BaseDirectory, "*.dll")) {
                    if (!paths.Contains(file)) {
                        paths.Add(file);
                    }
                }
            }

            foreach (var path in paths) {
                try {
                    GenerateMemberDocs(path);
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error loading doc types for plugin: {Manifest.Id}: {path}");
                    Console.WriteLine(ex.ToString());
                }
            }

            // Create PathAssemblyResolver that can resolve assemblies using the created list.
            var resolver = new PathAssemblyResolver(paths);

            _loadContext = new MetadataLoadContext(resolver, "mscorlib");
            Assembly = LoadContext.LoadFromAssemblyPath(EntryAssemblyPath);
            _choriziteAssembly = LoadContext.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "Chorizite.Core.dll"));

            LoadAssemblyTypes(Assembly);

            foreach (var assemblyPath in AllAssemblyPaths) {
                if (assemblyPath == EntryAssemblyPath) continue;
                Console.WriteLine($"Loading doc types for plugin: {Manifest.Id}: {assemblyPath}");
                try {
                    LoadAssemblyTypes(LoadContext.LoadFromAssemblyPath(assemblyPath));
                }
                catch (Exception ex) {
                    Console.WriteLine($"Error loading doc types for plugin: {Manifest.Id}: {assemblyPath}");
                    Console.WriteLine(ex.ToString());
                }

            }
        }
    }
}