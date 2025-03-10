using Autofac;
using Chorizite.Common;
using Chorizite.Common.Enums;
using Chorizite.Core.Backend;
using Chorizite.Core.Backend.Client;
using Chorizite.Core.Backend.Launcher;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Lib;
using Chorizite.Core.Logging;
using Chorizite.Core.Net;
using Chorizite.Core.Plugins;
using Chorizite.Core.Plugins.AssemblyLoader;
using Chorizite.Core.Render;
using Chorizite.NativeClientBootstrapper.Lib;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;

namespace Chorizite.Core {
    internal static class ChoriziteStatics {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        internal static ILogger Log { get; set; }
        internal static IChoriziteConfig Config { get; set; }
        internal static ILifetimeScope Scope { get; set; }
        internal static IChoriziteBackend Backend { get; set; }
        internal static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetAssembly(typeof(Chorizite<>))!.Location)!;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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

        /// <summary>
        /// The current lifetime scope
        /// </summary>
        public ILifetimeScope Scope => ChoriziteStatics.Scope;

        /// <summary>
        /// The current backend
        /// </summary>
        public IChoriziteBackend Backend => ChoriziteStatics.Backend;

        /// <summary>
        /// Create a new Chorizite instance and configure it.
        /// </summary>
        /// <param name="config">Configuration</param>
        public Chorizite(IChoriziteConfig config) {
            SymbolResolver.RegisterWithNativeCrashHandler();
            ManagedCrashHandler.Instance.Initialize();
            ChoriziteStatics.Config = config;
            _log = new ChoriziteLogger("Chorizite", Config.LogDirectory);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var builder = new ContainerBuilder();

            builder.RegisterGeneric(MakeGenericLogger)
                .As(typeof(ILogger<>))
                .IfNotRegistered(typeof(ILogger<>));

            ChoriziteStatics.Log = _log;
            WeakEvent.Log = ChoriziteStatics.MakeLogger("WeakEvent");

            if (Directory.Exists(Config.DatDirectory)) {
                builder.Register(c => new FSDatReader(Config.DatDirectory, c.Resolve<ILogger<FSDatReader>>()))
                    .As<IDatReaderInterface>()
                    .SingleInstance()
                    .IfNotRegistered(typeof(IDatReaderInterface));
            }

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
                    IClientBackend? clientBackend = null;
                    if (Backend.GetType().IsAssignableTo(typeof(IClientBackend))) {
                        clientBackend = (IClientBackend)Backend;
                    }

                    if (Config.Environment != ChoriziteEnvironment.DocGen) {
                        if (clientBackend is null) {
                            throw new Exception("Client environments must provide an IClientBackend");
                        }

                        builder.RegisterInstance(clientBackend)
                            .As<IClientBackend>();

                        builder.RegisterInstance(new NetworkParser(clientBackend, _container.Resolve<ILogger<NetworkParser>>()));
                    }
                    else {
                        builder.RegisterInstance(new NetworkParser(_container.Resolve<ILogger<NetworkParser>>()));
                    }
                }
                if (Config.Environment.HasFlag(ChoriziteEnvironment.Launcher)) {
                    ILauncherBackend? launcherBackend = null;
                    if (Backend.GetType().IsAssignableTo(typeof(ILauncherBackend))) {
                        launcherBackend = (ILauncherBackend)Backend;
                    }

                    if (Config.Environment != ChoriziteEnvironment.DocGen) {
                        if (launcherBackend is null) {
                            throw new Exception("Launcher environments must provide an ILauncherBackend");
                        }
                        builder.RegisterInstance(launcherBackend)
                            .As<ILauncherBackend>();
                    }
                    else {
                    }
                }


                builder.RegisterInstance(new PluginManager(Config.Environment, Config.PluginDirectory, config.StorageDirectory, Scope, ChoriziteStatics.MakeLogger("PluginManager")))
                    .As<IPluginManager>()
                    .SingleInstance();

                builder.RegisterType<AssemblyPluginLoader>()
                    .SingleInstance();
            });

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
            _log.LogTrace($"Manually pre-loading {xluaPath}");
            Native.LoadLibrary(xluaPath);

            _pluginManager = Scope.Resolve<IPluginManager>();

            _pluginManager.RegisterPluginLoader(Scope.Resolve<AssemblyPluginLoader>());

            if (Config.Environment == ChoriziteEnvironment.Launcher || Config.Environment == ChoriziteEnvironment.Client) {
                _pluginManager.LoadPlugins();
                _renderInterface.OnRender2D += RenderInterface_OnRender2D;
            }
        }

        private void RenderInterface_OnRender2D(object? sender, EventArgs e) {
            try {
                _pluginManager.Update();
            }
            catch (Exception ex) {
                ChoriziteStatics.Log.LogError(ex, "Error in RenderInterface_OnRender2D");
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

            if (!localDllPath.EndsWith("RoyT.TrueType.resources.dll")) {
                _log?.LogError($"Failed to resolve assembly {name.Name} @ {localDllPath}");
            }

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

        /// <summary>
        /// Disposes the Chorizite instance
        /// </summary>
        public void Dispose() {
            try { SymbolResolver.UnregisterWithNativeCrashHandler(); } catch { }
            if (_renderInterface is not null) {
                _renderInterface.OnRender2D -= RenderInterface_OnRender2D;
            }
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            _pluginManager?.Dispose();
            _renderInterface?.Dispose();
            _inputManager?.Dispose();
            Scope?.Dispose();
            _container?.Dispose();
        }
    }
}
