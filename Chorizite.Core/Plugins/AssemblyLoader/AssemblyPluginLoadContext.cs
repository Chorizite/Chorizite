using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public AssemblyPluginLoadContext(string pluginPath, IPluginManager manager, ILogger log) : base(pluginPath, true) {
            _log = log;
            _pluginPath = pluginPath;
            _manager = manager;
            Resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly? Load(AssemblyName assemblyName) {
            string? assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null) {
                return LoadFromAssemblyPath(assemblyPath);
            }

            // TODO: this is used for plugins that reference other plugins. this should
            // only look through plugins that this plugin depends on
            return AppDomain.CurrentDomain.GetAssemblies().LastOrDefault(a => a.GetName().Name == assemblyName.Name);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string? libraryPath = Resolver?.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null) {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            var dllName = unmanagedDllName.ToLower().EndsWith(".dll") ? unmanagedDllName : unmanagedDllName + ".dll";
            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(_pluginPath)!, $"runtimes", "win-x86", "native", dllName);
            if (System.IO.File.Exists(path)) {
                return LoadUnmanagedDllFromPath(path);
            }

            return IntPtr.Zero;
        }

        public void Dispose() {
            Unload();
            Resolver = null!;
        }
    }
}
