using Autofac;
using Chorizite.Common;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Lib;
using Chorizite.Core.Logging;
using Chorizite.Core.Lua;
using Chorizite.Core.Net;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core.Render;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Chorizite.Core {
    internal static class ChoriziteStatics {
        internal static ILogger Log { get; set; }
        internal static IChoriziteConfig Config { get; set; }
        internal static ILifetimeScope Scope { get; set; }
        internal static IChoriziteBackend Backend { get; set; }
        internal static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetAssembly(typeof(Chorizite<>))!.Location)!;

        internal static void HandleLogMessage(LogMessageEventArgs logMessageEvent) {
            Backend?.HandleLogMessage(logMessageEvent);
        }

        internal static ChoriziteLogger MakeLogger(string name) {
            return new ChoriziteLogger(name, Config.LogDirectory);
        }
    }

    /// <summary>
    /// Chorizite
    /// </summary>
    public class Chorizite<TBackend> : IDisposable where TBackend : IChoriziteBackend {
        private IPluginManager _pluginManager;
        private readonly IContainer _container;
        private ILogger _log;
        private IRenderInterface _renderInterface;
        private readonly IInputManager _inputManager;

        /// <summary>
        /// The absolute path to the magic hat dll directory.
        /// </summary>
        public static string AssemblyDirectory => ChoriziteStatics.AssemblyDirectory;

        /// <summary>
        /// The configuration being used
        /// </summary>
        public IChoriziteConfig Config => ChoriziteStatics.Config;
        public ILifetimeScope Scope => ChoriziteStatics.Scope;
        public IChoriziteBackend Backend => ChoriziteStatics.Backend;

        /// <summary>
        /// Create a new Chorizite instance and configure it.
        /// </summary>
        /// <param name="config">Configuration</param>
        public Chorizite(IChoriziteConfig config) {
            ChoriziteStatics.Config = config;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var builder = new ContainerBuilder();

            builder.RegisterGeneric(MakeGenericLogger)
                .As(typeof(ILogger<>))
                .IfNotRegistered(typeof(ILogger<>));

            WeakEvent.Log = ChoriziteStatics.MakeLogger("WeakEvent");

            builder.Register(c => {
                    var datReader = new FSDatReader(c.Resolve<ILogger<FSDatReader>>());
                    datReader.Init(Config.DatDirectory);
                    return datReader;
                })
                .As<IDatReaderInterface>()
                .SingleInstance()
                .IfNotRegistered(typeof(IDatReaderInterface));

            builder.RegisterInstance(Config)
                .As<IChoriziteConfig>()
                .SingleInstance();

            _container = builder.Build();

            var createBackend = typeof(TBackend).GetMethod("Create", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (createBackend is null) {
                ChoriziteStatics.Log.LogError($"Could not find Create method on {typeof(TBackend).Name}");
            }

            var backend = createBackend?.Invoke(null, [_container]) as IChoriziteBackend;
            if (backend is not null) {
                ChoriziteStatics.Backend = backend;
            }
            _log = new ChoriziteLogger("Chorizite", Config.LogDirectory);
            ChoriziteStatics.Log = _log;

            ChoriziteStatics.Scope = _container.BeginLifetimeScope(builder => {
                builder.RegisterInstance(Backend);
                builder.RegisterInstance(Backend.Renderer)
                    .As<IRenderInterface>()
                    .SingleInstance();
                builder.RegisterInstance(Backend.Input)
                    .As<IInputManager>()
                    .SingleInstance();
                builder.Register(c => Scope!)
                    .As<ILifetimeScope>()
                    .SingleInstance();

                if (Config.Environment.HasFlag(ChoriziteEnvironment.Client)) {
                    IClientBackend clientBackend;
                    if (Backend.GetType().IsAssignableTo(typeof(IClientBackend))) {
                        clientBackend = (IClientBackend)Backend;
                    }
                    else {
                        throw new Exception("Client environments must provide an IClientBackend");
                    }

                    builder.RegisterInstance(clientBackend)
                        .As<IClientBackend>();
                    builder.RegisterType<NetworkParser>()
                        .SingleInstance();
                }
                if (Config.Environment.HasFlag(ChoriziteEnvironment.Launcher)) {
                    ILauncherBackend launcherBackend;
                    if (Backend.GetType().IsAssignableTo(typeof(ILauncherBackend))) {
                        launcherBackend = (ILauncherBackend)Backend;
                    }
                    else {
                        throw new Exception("Launcher environments must provide an ILauncherBackend");
                    }

                    builder.RegisterInstance(launcherBackend)
                        .As<ILauncherBackend>();
                }

                builder.RegisterType<PluginManager>()
                    .As<IPluginManager>()
                    .SingleInstance()
                    .IfNotRegistered(typeof(IPluginManager));
                builder.RegisterType<AssemblyPluginLoader>()
                    .SingleInstance();
            });

            if (Config.Environment.HasFlag(ChoriziteEnvironment.Client)) {
                var networkParser = Scope.Resolve<NetworkParser>();
                networkParser.Init();
            }

            _renderInterface = Scope.Resolve<IRenderInterface>();
            if (_renderInterface is null) {
                throw new Exception("Failed to resolve IRenderInterface");
            }

            _inputManager = Scope.Resolve<IInputManager>();
            if (_inputManager is null) {
                throw new Exception("Failed to resolve IInputManager");
            }
            _inputManager.OnShutdown += InputManager_OnShutdown;

            var xluaPath = Path.Combine(AssemblyDirectory, "runtimes", (IntPtr.Size == 8) ? "win-x64" : "win-x86", "native", "xlua.dll");
            _log?.LogWarning($"Manually pre-loading {xluaPath}");
            Native.LoadLibrary(xluaPath);

            _pluginManager = Scope.Resolve<IPluginManager>();

            _pluginManager.RegisterPluginLoader(Scope.Resolve<AssemblyPluginLoader>());
            _pluginManager.LoadPluginManifests();

            _pluginManager.StartPlugins();

            Backend.Renderer.OnRender2D += OnRender2D;
        }

        private void OnRender2D(object? sender, EventArgs e) {
            try {
                LuaContext.UpdateAll();
            }
            catch (Exception ex) {
                _log?.LogError(ex, "Error in OnRender2D");
            }
        }

        private Assembly? CurrentDomain_AssemblyResolve(object? sender, ResolveEventArgs args) {
            var name = new AssemblyName(args.Name);
            Assembly? assembly = null;
            _log?.LogTrace($"CurrentDomain_AssemblyResolve {name.Name}");

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var loadedAssembly in loadedAssemblies) {
                if (loadedAssembly.GetName().Name == name.Name) {
                    assembly = loadedAssembly;
                }
            }

            if (assembly is not null) {
                _log?.LogTrace($"Resolved assembly {name.Name} from LOADED {assembly.Location}");
                return assembly;
            }

            var localDllPath = Path.Combine(AssemblyDirectory, $"{name.Name}.dll");
            if (File.Exists(localDllPath)) {
                _log?.LogTrace($"Resolved assembly {name.Name} from LOCAL {localDllPath}");
                return Assembly.Load(File.ReadAllBytes(localDllPath));
            }

            _log?.LogError($"Failed to resolve assembly {name.Name} @ {localDllPath}");

            return null;
        }

        private object MakeGenericLogger(IComponentContext context, Type[] types) {
            if (types.Length > 0) {
                var friendlyName = types[0].Name;

                if (friendlyName.EndsWith("Plugin")) {
                    friendlyName = friendlyName.Substring(0, friendlyName.Length - 6);
                }

                return Activator.CreateInstance(typeof(ChoriziteLogger<>).MakeGenericType(types), new object[] {
                    friendlyName,
                    Config.LogDirectory
                })!;
            }
            else {
                return _log;
            }
        }

        private void InputManager_OnShutdown(object? sender, EventArgs e) {
            Dispose();
        }


        public void Dispose() {
            Backend.Renderer.OnRender2D -= OnRender2D;
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            _pluginManager?.Dispose();
            _renderInterface?.Dispose();
            _inputManager?.Dispose();
            Scope?.Dispose();
            _container?.Dispose();
        }
    }
}
