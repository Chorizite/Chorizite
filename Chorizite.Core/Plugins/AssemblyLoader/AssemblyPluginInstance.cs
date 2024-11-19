using Autofac;
using Chorizite.Core.Backend;
using Chorizite.Core.Lib;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    public class AssemblyPluginInstance : PluginInstance<AssemblyPluginManifest> {
        private readonly IPluginManager _manager;
        private readonly FileWatcher _fileWatcher;
        private readonly Dictionary<string, string> _serializedState = [];
        private IPluginCore? _pluginInstance;

        public IPluginCore? PluginInstance => _pluginInstance;

        public AssemblyPluginLoadContext LoadContext { get; private set; }

        public AssemblyPluginInstance(IPluginManager manager, AssemblyPluginManifest manifest, ILifetimeScope serviceProvider) : base(manifest, serviceProvider) {
            _serviceProvider = serviceProvider;
            _manager = manager;

            _fileWatcher = new FileWatcher(Path.GetDirectoryName(Manifest.ManifestFile)!, Manifest.EntryFile, (file) => {
                WantsReload = true;
            });
        }

        public int CountLoadedAssemblies() {
            var count = 0;
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                if (assembly.GetName().Name == Name) {
                    count++;
                }
            }

            return count;
        }

        /// <inheritdoc cref="PluginInstance.Load()"/>
        [MethodImpl(MethodImplOptions.NoInlining)]
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
        [MethodImpl(MethodImplOptions.NoInlining)]
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

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void LoadPluginAssembly() {
            try {
                if (IsLoaded) {
                    TriggerOnBeforeReload(this, EventArgs.Empty);
                    UnloadPluginAssembly();
                }

                TriggerOnBeforeLoad(this, EventArgs.Empty);

                var dllFile = Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile), Manifest.EntryFile);
                LoadContext = new AssemblyPluginLoadContext(dllFile, _manager, _log);

                InitPlugin();

                IsLoaded = true;
                WantsReload = false;
                TriggerOnLoad(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin: {0}: {1}", Name, ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void InitPlugin() {
            var dllFile = Path.Combine(Path.GetDirectoryName(Manifest.ManifestFile), Manifest.EntryFile);
            var pdbFile = Path.ChangeExtension(dllFile, ".pdb");
            using var dllStream = File.OpenRead(dllFile);
            Assembly? loaded;
            if (!string.IsNullOrEmpty(pdbFile) && File.Exists(pdbFile)) {
                using var pdbStream = File.OpenRead(pdbFile);
                loaded = LoadContext.LoadFromStream(dllStream, pdbStream);
            }
            else {
                loaded = LoadContext.LoadFromStream(dllStream);
            }
            var pluginType = loaded.GetTypes().Where(t => {
                return typeof(IPluginCore).IsAssignableFrom(t) && !t.IsAbstract;
            }).FirstOrDefault();

            if (pluginType is null) {
                _log?.LogError($"Unable to find plugin type in assembly: {Name}");
                return;
            }

            _pluginInstance = InstantiatePlugin(pluginType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private IPluginCore? InstantiatePlugin(Type type) {
            IPluginCore? instance = null;
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
                    parameters.Add(ResolveParameter(type, parameter));
                }

                if (parameters.Count == ctor.GetParameters().Length) {
                    try {
                        instance = (IPluginCore)ctor.Invoke(parameters.ToArray());
                    }
                    catch (Exception ex) {
                        _log?.LogError(ex, "Error instantiating plugin: {0}: {1}", Name, ex.Message);
                        instance = null;
                    }
                    break;
                }
            }

            if (instance is null) {
                _log?.LogError($"Unable to instantiate plugin: {Name}");
            }
            else {
                TryDeserializeSettings(instance);
                TryDeserializeState(instance);
            }

            return instance;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private object? ResolveParameter(Type type, ParameterInfo parameter) {
            object? resolved = null;
            _log?.LogTrace($"Resolving parameter: {parameter.ParameterType} in plugin: {Name}");

            // special handling for this plugins PluginManifest
            if (parameter.ParameterType == typeof(PluginManifest) || parameter.ParameterType.IsSubclassOf(typeof(PluginManifest))) {
                resolved = Manifest;
            }

            //special logger handling
            if (parameter.ParameterType == typeof(ILogger)) {
                resolved = ChoriziteStatics.MakeLogger(type.Name);
            }

            if (parameter.ParameterType.IsAssignableTo(typeof(IClientBackend))) {
                if (_serviceProvider.IsRegistered<IClientBackend>()) {
                    resolved = _serviceProvider.Resolve<IClientBackend>();
                }
                return resolved;
            }

            if (parameter.ParameterType.IsAssignableTo(typeof(ILauncherBackend))) {
                if (_serviceProvider.IsRegistered<ILauncherBackend>()) {
                    resolved = _serviceProvider.Resolve<ILauncherBackend>();
                }
                return resolved;
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

            return resolved;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UnloadPluginAssembly() {
            if (IsLoaded) {
                _log?.LogTrace($"Unloading plugin assembly: {Name}");
                TriggerOnBeforeUnload(this, EventArgs.Empty);

                if (PluginInstance is not null) {
                    try {
                        TrySerializeSettings();
                        TrySerializeState();
                        PluginInstance?.GetType()?.GetMethod("Dispose", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(PluginInstance, []);
                    }
                    catch (Exception ex) {
                        _log?.LogError(ex, "Error unloading plugin: {0}: {1}", Name, ex.Message);
                    }
                }
                _pluginInstance = null;
                LoadContext.Unload();
                LoadContext.Dispose();
                LoadContext = null!;

                for (int i = 0; (i < 10); i++) {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                IsLoaded = false;
                TriggerOnUnload(this, EventArgs.Empty);
            }
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TryDeserializeType(IPluginCore instance, Type type, string? fileName = null) {
            if (instance is null) {
                return;
            }

            var stateSerializer = instance.GetType().GetInterfaces().FirstOrDefault(x =>
                 x.IsGenericType &&
                 x.GetGenericTypeDefinition() == type);

            if (stateSerializer is null) {
                return;
            }

            _log.LogTrace($"TryDeserializeState({type.Name}) for plugin: {Name}");
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var serializedType = stateSerializer.GetGenericArguments()[0];
            var jsonTypePropName = "TypeInfo";
            if (stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(instance) is not JsonTypeInfo jsonTypeInfo) {
                _log.LogError($"Unable to find JsonTypeInfo for plugin: {Name} ({jsonTypePropName}) ({serializedType.Name}): {stateSerializer.Name} / {stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(instance)}");
                return;
            }


            var serializedName = $"{serializedType.Namespace}.{serializedType.Name}_{type.Name}";

            string? jsonState = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName)) {
                jsonState = File.ReadAllText(fileName);
            }
            if (string.IsNullOrEmpty(jsonState)) {
                _serializedState.TryGetValue(serializedName, out jsonState);
            }

            object? serializedObj = null;
            if (!string.IsNullOrEmpty(jsonState)) {
                try {
                    serializedObj = JsonSerializer.Deserialize(jsonState, jsonTypeInfo);
                }
                catch (Exception ex) {
                    _log.LogError($"Unable to deserialize state for plugin: {Name} ({serializedType.Name}): {ex.Message}");
                }
            }

            _log.LogTrace($"Deserializing {type.Name} for plugin: {Name}: {serializedObj?.GetType().Name ?? "null"}");
            stateSerializer.GetMethod("DeserializeAfterLoad", flags)?.Invoke(instance, [serializedObj]);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TrySerializeType(Type type, string? fileName = null) {
            if (PluginInstance is null) {
                return;
            }

            var stateSerializer = PluginInstance.GetType().GetInterfaces().FirstOrDefault(x =>
                 x.IsGenericType &&
                 x.GetGenericTypeDefinition() == type);

            if (stateSerializer is null) {
                return;
            }

            _log.LogTrace($"TrySerialize({type.Name}) for plugin: {Name}");
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var stateType = stateSerializer.GetGenericArguments()[0];
            var stateObj = stateSerializer.GetMethod("SerializeBeforeUnload", flags)?.Invoke(PluginInstance, []);

            if (stateObj is null) {
                return;
            }

            _log.LogTrace($"Serializing {type.Name} for plugin: {Name}: {stateObj.GetType().Name}");

            var jsonTypePropName = "TypeInfo";
            if (stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(PluginInstance) is not JsonTypeInfo jsonTypeInfo) {
                _log.LogError($"Unable to find JsonTypeInfo for plugin: {Name} ({stateType.Name})");
                return;
            }

            var jsonState = JsonSerializer.Serialize(stateObj, jsonTypeInfo);

            if (!string.IsNullOrEmpty(fileName)) {
                File.WriteAllText(fileName, jsonState);
            }
            else {
                var stateName = $"{stateType.Namespace}.{stateType.Name}_{type.Name}";
                if (!_serializedState.TryAdd(stateName, jsonState)) {
                    _serializedState[stateName] = jsonState;
                }
            }
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TryDeserializeSettings(IPluginCore instance) {
            if (instance is null) return;

            TryDeserializeType(instance, typeof(ISerializeSettings<>), Path.Combine(instance.DataDirectory, "settings.json"));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TrySerializeSettings() {
            if (PluginInstance is null) return;

            if (!Directory.Exists(PluginInstance.DataDirectory)) {
                Directory.CreateDirectory(PluginInstance.DataDirectory);
            }

            TrySerializeType(typeof(ISerializeSettings<>), Path.Combine(PluginInstance.DataDirectory, "settings.json"));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TryDeserializeState(IPluginCore instance) {
            TryDeserializeType(instance, typeof(ISerializeState<>));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TrySerializeState() {
            TrySerializeType(typeof(ISerializeState<>));
        }

        public override void Dispose() {
            _fileWatcher?.Dispose();
            UnloadPluginAssembly();
            base.Dispose();
        }
    }
}
