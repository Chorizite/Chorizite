using Autofac;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Plugins.AssemblyLoader {
    public class AssemblyPluginInstance : PluginInstance<AssemblyPluginManifest> {
        private Type? _pluginType;
        private object? _pluginInstance;
        private readonly IPluginManager _manager;
        private readonly FileSystemWatcher _fw;

        public Assembly? Assembly { get; private set; }
        public IPluginCore? PluginInstance => (IPluginCore?)_pluginInstance;

        public AssemblyPluginInstance(IPluginManager manager, AssemblyPluginManifest manifest, ILifetimeScope serviceProvider) : base(manifest, serviceProvider) {
            _serviceProvider = serviceProvider;
            _manager = manager;

            _fw = new FileSystemWatcher();
            _fw.Path = Path.GetDirectoryName(manifest.ManifestFile);
            _fw.NotifyFilter = NotifyFilters.LastWrite;
            _fw.Filter = manifest.EntryFile;
            _fw.Changed += (s, e) => {
                WantsReload = true;
            };
            _fw.EnableRaisingEvents = true;
        }

        /// <inheritdoc cref="PluginInstance.Load()"/>
        public override bool Load() {
            if (!base.Load()) return false;

            try {
                LoadPluginAssembly();
                return true;
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin: {0}: {1}", Name, ex.Message);
                return false;
            }
        }

        /// <inheritdoc cref="PluginInstance.Unload()"/>
        public override bool Unload() {
            if (!base.Unload()) return false;

            try {
                UnloadPluginAssembly();
                return true;
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error unloading plugin: {0}: {1}", Name, ex.Message);
                return false;
            }
        }

        private void LoadPluginAssembly() {
            if (IsLoaded) {
                TriggerOnBeforeReload(this, EventArgs.Empty);
                UnloadPluginAssembly();
            }

            TriggerOnBeforeLoad(this, EventArgs.Empty);

            var dllPath = Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile), Manifest.EntryFile);

            _log?.LogDebug($"Loading plugin assembly: {Name} from {dllPath}");

            var symbolPath = dllPath.Replace(".dll", ".pdb");
            if (File.Exists(symbolPath)) {
                _log?.LogTrace($"Loading symbol file: {symbolPath}");
                Assembly = Assembly.Load(File.ReadAllBytes(dllPath), File.ReadAllBytes(symbolPath));
            }
            else {
                _log?.LogTrace($"NO symbol file: {symbolPath}");
                Assembly = Assembly.Load(File.ReadAllBytes(dllPath));
            }
            _pluginType = Assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(IPluginCore)));

            if (_pluginType == null) {
                var thiers = Assembly.GetTypes().FirstOrDefault(t => t?.BaseType?.Name == nameof(IPluginCore));
                throw new Exception($"Plugin did not contain a class that inherits from IPluginCore: {dllPath}");
            }

            _pluginInstance = InstantiatePlugin();

            if (_pluginInstance == null) {
                throw new Exception($"Unable to create plugin instance: {_pluginType.Namespace}.{_pluginType.Name} in assembly {dllPath}");
            }

            IsLoaded = true;
            TriggerOnLoad(this, EventArgs.Empty);
        }

        private object? InstantiatePlugin() {
            var constructors = _pluginType?.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            constructors ??= [];
            constructors.AddRange(_pluginType?.GetConstructors(BindingFlags.Public | BindingFlags.Instance).ToList());

            constructors.Sort((a, b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));

            if (constructors.Count == 0) {
                _log?.LogError($"Unable to find any constructors for plugin: {_pluginType?.Namespace}.{_pluginType?.Name} in assembly {_pluginType?.Assembly?.GetName().Name}");
                return null;
            }

            foreach (var ctor in constructors) {
                _log?.LogTrace($"Resolving ctor: {ctor} in plugin: {Name}");
                var parameters = new List<object>();

                foreach (var parameter in ctor.GetParameters()) {
                    object? resolved = null;
                    _log?.LogTrace($"Resolving parameter: {parameter.ParameterType} in plugin: {Name}");

                    if (parameter.ParameterType == typeof(PluginManifest) || parameter.ParameterType.IsSubclassOf(typeof(PluginManifest))) {
                        resolved = Manifest;
                    }

                    resolved ??= _serviceProvider.Resolve(parameter.ParameterType);
                    
                    if (resolved is null) {
                        _log?.LogWarning($"Unable to resolve ctor parameter: {parameter.ParameterType} in plugin: {Name}");
                        break;
                    }
                    parameters.Add(resolved);
                }

                if (parameters.Count == ctor.GetParameters().Length) {
                    _pluginInstance = ctor.Invoke(parameters.ToArray());
                    break;
                }
            }

            return _pluginInstance;
        }

        private void UnloadPluginAssembly() {
            if (_pluginInstance != null && _pluginType != null) {
                _log?.LogDebug($"Unloading plugin assembly: {Name}");
                TriggerOnBeforeUnload(this, EventArgs.Empty);

                MethodInfo shutdownMethod = _pluginType.GetMethod("Dispose", BindingFlags.NonPublic | BindingFlags.Instance);
                shutdownMethod ??= _pluginType.GetMethod("Dispose", BindingFlags.Public | BindingFlags.Instance);

                shutdownMethod?.Invoke(_pluginInstance, null);
                _pluginInstance = null;
                _pluginType = null;
                Assembly = null;
                IsLoaded = false;
                TriggerOnLoad(this, EventArgs.Empty);
            }
        }

        public override void Dispose() {
            _fw?.Dispose();
            base.Dispose();
        }
    }
}
