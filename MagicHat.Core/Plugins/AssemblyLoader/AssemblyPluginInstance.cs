using Autofac;
using McMaster.NETCore.Plugins;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core.Plugins.AssemblyLoader {
    public class AssemblyPluginInstance : PluginInstance<AssemblyPluginManifest> {
        private object? _pluginInstance;
        private PluginLoader _pluginLoader;
        private readonly IPluginManager _manager;

        public IPluginCore? PluginInstance => (IPluginCore?)_pluginInstance;

        public AssemblyPluginLoadContext LoadContext { get; private set; }

        public AssemblyPluginInstance(IPluginManager manager, AssemblyPluginManifest manifest, ILifetimeScope serviceProvider) : base(manifest, serviceProvider) {
            _serviceProvider = serviceProvider;
            _manager = manager;
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
            try {
                if (IsLoaded) {
                    TriggerOnBeforeReload(this, EventArgs.Empty);
                    UnloadPluginAssembly();
                }

                TriggerOnBeforeLoad(this, EventArgs.Empty);

                var dllFile = Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile), Manifest.EntryFile);
                LoadContext = new AssemblyPluginLoadContext(dllFile, _manager);
                _pluginLoader = PluginLoader.CreateFromAssemblyFile(dllFile, true, [], (cfg) => {
                    cfg.EnableHotReload = true;
                    cfg.LoadInMemory = true;
                    cfg.PreferSharedTypes = true;
                    cfg.IsUnloadable = false;
                    cfg.DefaultContext = LoadContext;
                });

                _pluginLoader.Reloaded += (s, e) => {
                    WantsReload = true;
                };

                InitPlugin();

                IsLoaded = true;
                TriggerOnLoad(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin: {0}: {1}", Name, ex.Message);
            }
        }

        private void InitPlugin() {
            var pluginType = _pluginLoader.LoadDefaultAssembly().GetTypes().Where(t => {
                return typeof(IPluginCore).IsAssignableFrom(t) && !t.IsAbstract;
            }).FirstOrDefault();

            if (pluginType is null) {
                _log?.LogError($"Unable to find plugin type in assembly: {Name}");
                return;
            }

            _pluginInstance = InstantiatePlugin(pluginType);
        }

        private object? InstantiatePlugin(Type type) {
            var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            constructors ??= [];
            constructors.AddRange(type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).ToList());

            constructors.Sort((a, b) => b.GetParameters().Length.CompareTo(a.GetParameters().Length));

            if (constructors.Count == 0) {
                _log?.LogError($"Unable to find any constructors for plugin: {type.Namespace}.{type.Name} in assembly {type.Assembly?.GetName().Name}");
                return null;
            }

            foreach (var ctor in constructors) {
                _log?.LogTrace($"Resolving ctor: {ctor} in plugin: {Name}");
                var parameters = new List<object>();

                foreach (var parameter in ctor.GetParameters()) {
                    object? resolved = null;
                    _log?.LogTrace($"Resolving parameter: {parameter.ParameterType} in plugin: {Name}");

                    // special handling for this plugins PluginManifest
                    if (parameter.ParameterType == typeof(PluginManifest) || parameter.ParameterType.IsSubclassOf(typeof(PluginManifest))) {
                        resolved = Manifest;
                    }

                    // handle other plugin instances
                    if (resolved is null && parameter.ParameterType.IsAssignableTo(typeof(IPluginCore))) {
                        resolved = _manager.Plugins
                            .Where(p => p is AssemblyPluginInstance)
                            .Cast<AssemblyPluginInstance>()
                            .FirstOrDefault(p => p.PluginInstance?.GetType() == parameter.ParameterType)?.PluginInstance;
                        if (resolved is null) {
                            throw new InvalidOperationException($"Unable to resolve parameter: {parameter.ParameterType} in plugin: {Name}");
                        }
                    }

                    resolved ??= _serviceProvider.Resolve(parameter.ParameterType);
                    
                    if (resolved is null) {
                        _log?.LogError($"Unable to resolve ctor parameter: {parameter.ParameterType} in plugin: {Name}");
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
            if (IsLoaded) {
                _log?.LogDebug($"Unloading plugin assembly: {Name}");
                TriggerOnBeforeUnload(this, EventArgs.Empty);

                PluginInstance?.Dispose();
                _pluginInstance = null;
                _pluginLoader.Dispose();

                IsLoaded = false;
                TriggerOnLoad(this, EventArgs.Empty);
            }
        }

        public override void Dispose() {
            UnloadPluginAssembly();
            base.Dispose();
        }
    }
}
