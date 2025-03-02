using Autofac;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Backend.Launcher;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace Chorizite.Core.Plugins.AssemblyLoader {
    /// <summary>
    /// A dotnet assembly based plugin
    /// </summary>
    public class AssemblyPluginInstance : PluginInstance<AssemblyPluginManifest> {
        private readonly IPluginManager _manager;
        private static readonly Dictionary<string, Dictionary<string, string>> _serializedStates = [];
        private IPluginCore? _pluginInstance;
        private WeakReference? _alc;
        internal string? AssemblyName;

        /// <inheritdoc />
        public IPluginCore? PluginInstance => _pluginInstance;

        /// <inheritdoc />
        public AssemblyPluginLoadContext? LoadContext => _alc?.Target as AssemblyPluginLoadContext;

        /// <inheritdoc />
        public override object? Instance => _pluginInstance;

        /// <summary>
        /// Creates a new AssemblyPluginInstance
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="manifest"></param>
        /// <param name="serviceProvider"></param>
        public AssemblyPluginInstance(IPluginManager manager, AssemblyPluginManifest manifest, ILifetimeScope serviceProvider) : base(manifest, serviceProvider) {
            _serviceProvider = serviceProvider;
            _manager = manager;
        }

        /// <inheritdoc cref="PluginInstance.Load()"/>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool Load() {
            if (!base.Load()) return false;

            try {
                if (IsLoaded) {
                    TriggerOnBeforeReload(this, EventArgs.Empty);
                    Unload(true);
                }

                TriggerOnBeforeLoad(this, EventArgs.Empty);

                var dllFile = Path.Combine(Manifest.BaseDirectory, Manifest.EntryFile);
                _alc = new WeakReference(new AssemblyPluginLoadContext(dllFile, _manager, _log), trackResurrection: true);

                InitPlugin();

                IsLoaded = true;
                WantsReload = false;
                TriggerOnLoad(this, EventArgs.Empty);
                return true;
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error loading plugin: {0}: {1}", DisplayName, ex.Message);
                return false;
            }
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.NoInlining)]
        public override bool Unload(bool isReloading) {
            if (!base.Unload(isReloading)) return false;

            try {
                UnloadPluginAssembly(isReloading);

                for (var i = 0; _alc?.IsAlive == true && i < 10; i++) {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }

                return true;
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error unloading plugin: {0}: {1}", DisplayName, ex.Message);
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UnloadPluginAssembly(bool isReloading) {
            if (IsLoaded) {
                _log?.LogInformation($"Unloading plugin assembly: {DisplayName}");
                TriggerOnBeforeUnload(this, EventArgs.Empty);

                if (PluginInstance is not null) {
                    try {
                        TrySerializeSettings();
                        TrySerializeState();
                        PluginInstance?.GetType()?.GetMethod("Dispose", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(PluginInstance, []);
                        PluginInstance?.GetType()?.GetMethod("Dispose", BindingFlags.Instance | BindingFlags.Public)?.Invoke(PluginInstance, []);
                    }
                    catch (Exception ex) {
                        _log?.LogError(ex, "Error unloading plugin: {0}: {1}", DisplayName, ex.Message);
                    }
                }
                _pluginInstance = null;
                LoadContext?.Unload();
                LoadContext?.Dispose();

                // this is a hack to clear out System.Text.Json caches...
                try {
                    var assembly = typeof(JsonSerializerOptions).Assembly;
                    var updateHandlerType = assembly.GetType("System.Text.Json.JsonSerializerOptionsUpdateHandler");
                    var clearCacheMethod = updateHandlerType?.GetMethod("ClearCache", BindingFlags.Static | BindingFlags.Public);
                    clearCacheMethod?.Invoke(null, new object?[] { null });
                }
                catch (Exception ex) { _log?.LogError(ex, $"Error clearing System.Text.Json cache"); }

                IsLoaded = false;
                TriggerOnUnload(this, EventArgs.Empty);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void InitPlugin() {
            var dllFile = Path.Combine(Manifest.BaseDirectory, Manifest.EntryFile);
            Assembly? loaded = LoadContext!.LoadAssemblyWithoutLocking(dllFile);

            AssemblyName = loaded.GetName().Name;

            var pluginType = loaded.GetTypes().Where(t => {
                return typeof(IPluginCore).IsAssignableFrom(t) && !t.IsAbstract;
            }).FirstOrDefault();

            if (pluginType is null) {
                _log?.LogError($"Unable to find plugin type in assembly: {DisplayName}");
                return;
            }

            if (_manager.Environment == ChoriziteEnvironment.DocGen) {
                return;
            }

            _pluginInstance = InstantiatePlugin(pluginType);
            if (PluginInstance is not null) {
                try {
                    PluginInstance.GetType().GetMethod("Initialize", BindingFlags.Instance | BindingFlags.NonPublic)?.Invoke(PluginInstance, []);
                }
                catch (Exception ex) {
                    _log?.LogError(ex, "Error initializing plugin: {0}: {1}", DisplayName, ex.Message);
                }
            }
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
                _log?.LogTrace($"Resolving ctor: {ctor} in plugin: {DisplayName}");
                var parameters = new List<object?>();

                foreach (var parameter in ctor.GetParameters()) {
                    parameters.Add(ResolveParameter(type, parameter));
                }

                if (parameters.Count == ctor.GetParameters().Length) {
                    try {
                        instance = (IPluginCore)ctor.Invoke(parameters.ToArray());
                    }
                    catch (Exception ex) {
                        _log?.LogError(ex, "Error instantiating plugin: {0}: {1}", DisplayName, ex.Message);
                        instance = null;
                    }
                    break;
                }
            }

            if (instance is null) {
                _log?.LogError($"Unable to instantiate plugin: {DisplayName}");
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
            _log?.LogTrace($"Resolving parameter: {parameter.ParameterType} in plugin: {DisplayName}");

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
                    throw new InvalidOperationException($"Unable to resolve parameter: {parameter.ParameterType} in plugin: {DisplayName}");
                }
            }

            resolved ??= _serviceProvider.Resolve(parameter.ParameterType);

            return resolved;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void TryDeserializeType(IPluginCore instance, Type type, string? fileName = null) {
            if (instance is null) {
                return;
            }
            _log.LogTrace($"TryDeserializeType({type.Name}) for plugin: {DisplayName} {instance.Id}");

            var stateSerializer = instance.GetType().GetInterfaces().LastOrDefault(x =>
                 x.IsGenericType &&
                 x.GetGenericTypeDefinition() == type);

            if (stateSerializer is null) {
                return;
            }

            _log.LogTrace($"TryDeserializeState({type.Name}) for plugin: {DisplayName}");
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var serializedType = stateSerializer.GetGenericArguments()[0];
            var jsonTypePropName = "TypeInfo";
            if (stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(instance) is not JsonTypeInfo jsonTypeInfo) {
                _log.LogError($"Unable to find JsonTypeInfo for plugin: {DisplayName} ({jsonTypePropName}) ({serializedType.Name}): {stateSerializer.Name} / {stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(instance)}");
                return;
            }


            var serializedName = $"{serializedType.Namespace}.{serializedType.Name}_{type.Name}";

            string? jsonState = null;
            if (!string.IsNullOrEmpty(fileName) && File.Exists(fileName)) {
                jsonState = File.ReadAllText(fileName);
            }
            if (string.IsNullOrEmpty(jsonState) && _serializedStates.TryGetValue(DisplayName, out var serializedState)) {
                serializedState.TryGetValue(serializedName, out jsonState);
            }

            object? serializedObj = null;
            if (!string.IsNullOrEmpty(jsonState)) {
                try {
                    serializedObj = JsonSerializer.Deserialize(jsonState, jsonTypeInfo);
                }
                catch (Exception ex) {
                    _log.LogError(ex, $"Unable to deserialize state for plugin: {DisplayName} ({serializedType.Name}): {ex.Message}");
                }
            }

            _log.LogTrace($"Deserializing {type.Name} for plugin: {DisplayName}: {serializedObj?.GetType().Name ?? "null"}");
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

            _log.LogTrace($"TrySerialize({type.Name}) for plugin: {DisplayName}");
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var stateType = stateSerializer.GetGenericArguments()[0];
            var stateObj = stateSerializer.GetMethod("SerializeBeforeUnload", flags)?.Invoke(PluginInstance, []);

            if (stateObj is null) {
                return;
            }

            _log.LogTrace($"Serializing {type.Name} for plugin: {DisplayName}: {stateObj.GetType().Name}");

            var jsonTypePropName = "TypeInfo";
            if (stateSerializer.GetProperty(jsonTypePropName, flags)?.GetValue(PluginInstance) is not JsonTypeInfo jsonTypeInfo) {
                _log.LogError($"Unable to find JsonTypeInfo for plugin: {DisplayName} ({stateType.Name})");
                return;
            }

            var jsonState = JsonSerializer.Serialize(stateObj, jsonTypeInfo);

            if (!string.IsNullOrEmpty(fileName)) {
                File.WriteAllText(fileName, jsonState);
            }
            else {
                var stateName = $"{stateType.Namespace}.{stateType.Name}_{type.Name}";
                if (!_serializedStates.ContainsKey(DisplayName)) {
                    _serializedStates.Add(DisplayName, new Dictionary<string, string>());
                }

                if (!_serializedStates[DisplayName].TryAdd(stateName, jsonState)) {
                    _serializedStates[DisplayName][stateName] = jsonState;
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

        internal override void UpdateManifest() {
            base.UpdateManifest();
            if (PluginManifest.TryLoadManifest<AssemblyPluginManifest>(Manifest.ManifestFile, out var manifest, out string? errors)) {
                Manifest = manifest!;
            }
        }

        /// <inheritdoc />
        public override void Dispose() {
            UnloadPluginAssembly(true);
            _pluginInstance = null;
            base.Dispose();
        }
    }
}
