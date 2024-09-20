using Autofac;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Logging;
using MagicHat.Core.Plugins;
using MagicHat.Core.Plugins.AssemblyLoader;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagicHat.Core {
    /// <summary>
    /// MagicHat
    /// </summary>
    public class MagicHat : IDisposable {
        private IPluginManager _pluginManager;
        private ILogger<MagicHat> _log;

        /// <summary>
        /// The absolute path to the magic hat dll directory.
        /// </summary>
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetAssembly(typeof(MagicHat)).Location);
        public IContainer Container { get; }
        public IMagicHatConfig Config { get; }


        /// <summary>
        /// Create a new MagicHat instance and configure it.
        /// </summary>
        /// <param name="configure">A configuration callback that allows you to configure advanced options</param>
        public MagicHat(Func<ContainerBuilder, IMagicHatConfig?>? configure = null) {
            var builder = new ContainerBuilder();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            var config = configure?.Invoke(builder);
            var assemblyDir = Path.GetDirectoryName(Assembly.GetAssembly(GetType()).Location);
            Config = config ?? new MagicHatConfig(Path.Combine(assemblyDir, "plugins"), assemblyDir);

            builder.RegisterInstance(Config);
            builder.RegisterGeneric(MakeGenericLogger)
                .As(typeof(ILogger<>))
                .IfNotRegistered(typeof(ILogger<>));
            builder.Register(c => {
                var datReader = new FSDatReader(c.Resolve<ILogger<FSDatReader>>());
                datReader.Init("");
                return datReader;
            })
                .As<IDatReaderInterface>()
                .SingleInstance()
                .IfNotRegistered(typeof(IDatReaderInterface));
            builder.RegisterType<NullRenderInterface>()
                .As<IRenderInterface>()
                .SingleInstance()
                .IfNotRegistered(typeof(IRenderInterface));
            builder.RegisterType<PluginManager>()
                .As<IPluginManager>()
                .SingleInstance()
                .IfNotRegistered(typeof(IPluginManager));
            builder.RegisterType<AssemblyPluginLoader>()
                .SingleInstance();
            builder.Register(c => Container!)
                .As<IContainer>()
                .SingleInstance();

            Container = builder.Build();

            _log = Container.Resolve<ILogger<MagicHat>>();

            var renderInterface = Container.Resolve<IRenderInterface>();
            if (renderInterface is null) {
                throw new Exception("Failed to resolve IRenderInterface");
            }

            var inputManager = Container.Resolve<IInputManager>();
            if (inputManager is null) {
                throw new Exception("Failed to resolve IInputManager");
            }

            _pluginManager = Container.Resolve<IPluginManager>();

            _pluginManager.RegisterPluginLoader(Container.Resolve<AssemblyPluginLoader>());
            _pluginManager.LoadPluginManifests();

            _pluginManager.StartPlugins();
        }

        private Assembly? CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            var name = new AssemblyName(args.Name);
            var localDllPath = Path.Combine(AssemblyDirectory, $"{name.Name}.dll");
            if (File.Exists(localDllPath)) {
                return Assembly.Load(File.ReadAllBytes(localDllPath));
            }

            if (Container?.Resolve<AssemblyPluginLoader>()?.TryResolvePluginAssembly(args, out var loadedAssembly) == true) {
                return loadedAssembly;
            }

            return null;
        }

        private object MakeGenericLogger(IComponentContext context, Type[] types) {
            if (types.Length > 0) {
                var friendlyName = types[0].Name;

                if (friendlyName.EndsWith("Plugin")) {
                    friendlyName = friendlyName.Substring(0, friendlyName.Length - 6);
                }

                return Activator.CreateInstance(typeof(MagicHatLogger<>).MakeGenericType(types), new object[] {
                    friendlyName,
                    Config.LogDirectory
                });
            }
            else {
                return _log;
            }
        }


        public void Dispose() {
            AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            _pluginManager?.Dispose();
        }
    }
}
