using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    /// <summary>
    /// A plugin load context
    /// </summary>
    public class AssemblyPluginLoadContext : AssemblyLoadContext, IDisposable {
        private readonly ILogger _log;
        private readonly string _pluginPath;
        private IPluginManager _manager;
        internal AssemblyDependencyResolver Resolver;

        string _tempDirectory;
        public static Dictionary<string, IntPtr> LoadedNativeLibraries = [];
        Dictionary<string, Assembly> _loadedAssemblies = [];

        /// <summary>
        /// Creates a new plugin load context
        /// </summary>
        /// <param name="pluginPath"></param>
        /// <param name="manager"></param>
        /// <param name="log"></param>
        public AssemblyPluginLoadContext(string pluginPath, IPluginManager manager, ILogger log) : base(pluginPath, true) {
            _log = log;
            _pluginPath = pluginPath;
            _manager = manager;
            Resolver = new AssemblyDependencyResolver(pluginPath);
            _tempDirectory = Path.Combine(Path.GetTempPath(), "chorizite");

            foreach (var dir in Directory.GetDirectories(_tempDirectory)) {
                try {
                    Directory.Delete(dir, true);
                }
                catch {}
            }
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        protected unsafe override IntPtr LoadUnmanagedDll(string unmanagedDllName) {
            string? libraryPath = Resolver?.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null) {
                return LoadUnmanagedDllFromTempPath(libraryPath);
            }

            var dllName = unmanagedDllName.ToLower().EndsWith(".dll") ? unmanagedDllName : unmanagedDllName + ".dll";
            var target = sizeof(IntPtr) == 8 ? "x64" : "x86";
            var path = Path.Combine(Path.GetDirectoryName(_pluginPath)!, $"runtimes", $"win-{target}", "native", dllName);

            if (File.Exists(path)) {
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
            using var dllStream = new MemoryStream();
            using (var fileStream = new FileStream(assemblyPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                fileStream.CopyTo(dllStream);
            }

            Assembly? loaded;
            dllStream.Position = 0; // Reset stream position
            if (!string.IsNullOrEmpty(pdbFile) && File.Exists(pdbFile)) {
                using var pdbStream = new MemoryStream();
                using (var pdbFileStream = new FileStream(pdbFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                    pdbFileStream.CopyTo(pdbStream);
                }
                pdbStream.Position = 0;
                loaded = LoadFromStream(dllStream, pdbStream);
            }
            else {
                loaded = LoadFromStream(dllStream);
            }

            _loadedAssemblies.Add(assemblyPath, loaded);
            return loaded;
        }

        internal IntPtr LoadUnmanagedDllFromTempPath(string libraryPath) {
            if (LoadedNativeLibraries.TryGetValue(libraryPath, out var result)) {
                return result;
            }

            if (!File.Exists(libraryPath)) {
                _log.LogError("Library not found: {LibraryPath}", libraryPath);
                throw new FileNotFoundException($"Library not found: {libraryPath}");
            }
            _tempDirectory = Path.Combine(Path.GetTempPath(), "chorizite", Guid.NewGuid().ToString());

            if (!Directory.Exists(_tempDirectory)) {
                Directory.CreateDirectory(_tempDirectory);
            }

            // Use only the file name for the temporary path to avoid invalid paths
            string fileName = Path.GetFileName(libraryPath);
            string destinationPath = Path.Combine(_tempDirectory, fileName);

            try {
                // Copy the DLL to the temporary directory
                File.Copy(libraryPath, destinationPath, true);
                _log.LogDebug("Copied {LibraryPath} to {DestinationPath}", libraryPath, destinationPath);
            }
            catch (Exception ex) {
                _log.LogError(ex, "Failed to copy {LibraryPath} to {DestinationPath}", libraryPath, destinationPath);
                throw new IOException($"Failed to copy library to temporary path: {destinationPath}", ex);
            }

            if (!File.Exists(destinationPath)) {
                _log.LogError("Temporary library file does not exist: {DestinationPath}", destinationPath);
                throw new FileNotFoundException($"Temporary library file does not exist: {destinationPath}");
            }

            // Load the DLL from the temporary path
            IntPtr handle = LoadUnmanagedDllFromPath(destinationPath);
            if (handle == IntPtr.Zero) {
                _log.LogError("Failed to load library from {DestinationPath}", destinationPath);
                throw new InvalidOperationException($"Failed to load library from {destinationPath}");
            }

            LoadedNativeLibraries.Add(libraryPath, handle);
            return handle;
        }

        /// <summary>
        /// Disposes the load context
        /// </summary>
        public void Dispose() {
            _loadedAssemblies.Clear();
            Unload();
            Resolver = null!;
        }
    }
}
