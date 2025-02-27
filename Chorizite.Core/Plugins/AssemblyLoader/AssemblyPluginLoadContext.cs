using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    public class AssemblyPluginLoadContext : AssemblyLoadContext, IDisposable {
        private readonly ILogger _log;
        private readonly string _pluginPath;
        private IPluginManager _manager;
        internal AssemblyDependencyResolver Resolver;

        public AssemblyDependencyResolver Resolver2 { get; }

        string _tempDirectory => Path.Combine(Path.GetTempPath(), "chorizite");
        Dictionary<string, IntPtr> _loadedLibraries = [];
        Dictionary<string, Assembly> _loadedAssemblies = [];

        public AssemblyPluginLoadContext(string pluginPath, IPluginManager manager, ILogger log) : base(pluginPath, true) {
            _log = log;
            _pluginPath = pluginPath;
            _manager = manager;
            Resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly? Load(AssemblyName assemblyName) {
            string? assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName);
            
            var assembly = assemblyPath != null ? LoadAssemblyWithoutLocking(assemblyPath) : null;

            if (assembly != null) {
                return assembly;
            }

            // TODO: this is used for plugins that reference other plugins. this should
            // only look through plugins that this plugin depends on
            return AppDomain.CurrentDomain.GetAssemblies().LastOrDefault(a => a.GetName().Name == assemblyName.Name);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string? libraryPath = Resolver?.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null) {
                return LoadUnmanagedDllFromTempPath(libraryPath);
            }
            var dllName = unmanagedDllName.ToLower().EndsWith(".dll") ? unmanagedDllName : unmanagedDllName + ".dll";
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_pluginPath)!, $"runtimes", "win-x86", "native", dllName);
            if (System.IO.File.Exists(path)) {
                return LoadUnmanagedDllFromTempPath(path);
            }

            return IntPtr.Zero;
        }

        internal Assembly LoadAssemblyWithoutLocking(string assemblyPath) {
            if (_loadedAssemblies.TryGetValue(assemblyPath, out var result)) {
                return result;
            }

            if (!File.Exists(assemblyPath)) {
                throw new FileNotFoundException($"Assembly not found: {assemblyPath}");
            }

            var pdbFile = Path.ChangeExtension(assemblyPath, ".pdb");
            using var dllStream = new MemoryStream(File.ReadAllBytes(assemblyPath));
            Assembly? loaded;
            if (!string.IsNullOrEmpty(pdbFile) && File.Exists(pdbFile)) {
                using var pdbStream = new MemoryStream(File.ReadAllBytes(pdbFile));
                loaded = LoadFromStream(dllStream, pdbStream);
            }
            else {
                loaded = LoadFromStream(dllStream);
            }
            if (loaded is not null) {
                _loadedAssemblies.Add(assemblyPath, loaded);
            }

            return loaded;
        }

        internal IntPtr LoadUnmanagedDllFromTempPath(string libraryPath) {
            if (_loadedLibraries.TryGetValue(libraryPath, out var result)) {
                return result;
            }

            if (!File.Exists(libraryPath)) {
                throw new FileNotFoundException($"Library not found: {libraryPath}");
            }

            if (!Directory.Exists(_tempDirectory)) {
                Directory.CreateDirectory(_tempDirectory);
            }

            string destinationPath = Path.Combine(_tempDirectory, libraryPath);

            try {
                File.Copy(libraryPath, destinationPath, true);
            }
            catch { }

            _loadedLibraries.Add(libraryPath, LoadUnmanagedDllFromPath(destinationPath));

            return _loadedLibraries[libraryPath];
        }


        public void Dispose() {
            _loadedAssemblies.Clear();
            _loadedLibraries.Clear();
            Unload();
            Resolver = null!;
        }
    }
}
