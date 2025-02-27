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
            Resolver2 = new AssemblyDependencyResolver(Path.Combine(Path.GetDirectoryName(pluginPath), "..", "..", "Chorizite.Core.dll"));

            // check for all dlls in _tempDirectory and delete them
            if (Directory.Exists(_tempDirectory)) {
                foreach (var file in Directory.GetFiles(_tempDirectory)) {
                    try {
                        if (file.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)) File.Delete(file);
                    }
                    catch { }
                }
            }
        }

        protected override Assembly? Load(AssemblyName assemblyName) {
            string? assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName);
            
            var assembly = assemblyPath != null ? LoadAssemblyFromTempPath(assemblyPath) : null;

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

        internal Assembly LoadAssemblyFromTempPath(string assemblyPath) {
            if (_loadedAssemblies.TryGetValue(assemblyPath, out var result)) {
                return result;
            }

            if (!File.Exists(assemblyPath)) {
                throw new FileNotFoundException($"Assembly not found: {assemblyPath}");
            }

            if (!Directory.Exists(_tempDirectory)) {
                Directory.CreateDirectory(_tempDirectory);
            }

            string uniqueFileName = $"{Path.GetFileNameWithoutExtension(assemblyPath)}_{Guid.NewGuid().ToString("N")}{Path.GetExtension(assemblyPath)}";
            string destinationPath = Path.Combine(_tempDirectory, uniqueFileName);

            File.Copy(assemblyPath, destinationPath, true);

            var assembly = LoadFromAssemblyPath(destinationPath);

            _loadedAssemblies.Add(assemblyPath, assembly);

            return assembly;
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

            string uniqueFileName = $"{Path.GetFileNameWithoutExtension(libraryPath)}_{Guid.NewGuid().ToString("N")}{Path.GetExtension(libraryPath)}";
            string destinationPath = Path.Combine(_tempDirectory, uniqueFileName);

            File.Copy(libraryPath, destinationPath, true);

            _loadedLibraries.Add(libraryPath, LoadUnmanagedDllFromPath(destinationPath));

            return LoadUnmanagedDllFromPath(destinationPath);
        }


        public void Dispose() {
            _loadedAssemblies.Clear();
            _loadedLibraries.Clear();
            Unload();
            Resolver = null!;
        }
    }
}
