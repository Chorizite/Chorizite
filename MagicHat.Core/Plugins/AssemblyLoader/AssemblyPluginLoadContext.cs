using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MagicHat.Core.Plugins.AssemblyLoader {
    public class AssemblyPluginLoadContext : AssemblyLoadContext {
        private readonly string _pluginPath;
        private IPluginManager _manager;
        internal AssemblyDependencyResolver Resolver;

        public AssemblyPluginLoadContext(string pluginPath, IPluginManager manager) : base(null, true) {
            _pluginPath = pluginPath;
            _manager = manager;
            Resolver = new AssemblyDependencyResolver(pluginPath);
        }

        protected override Assembly? Load(AssemblyName assemblyName) {
            string assemblyPath = Resolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null) {
                return LoadFromAssemblyPath(assemblyPath);
            }

            // TODO: this is used for plugins that reference other plugins. this should
            // only look through plugins that this plugin depends on
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                if (assembly.GetName().Name == assemblyName.Name) {
                    return assembly;
                }
            }

            return Default.LoadFromAssemblyName(assemblyName);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string libraryPath = Resolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null) {
                return LoadUnmanagedDllFromPath(libraryPath);
            }
            return IntPtr.Zero;
        }
    }
}
