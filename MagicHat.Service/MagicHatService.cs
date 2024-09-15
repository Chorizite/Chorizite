using Autofac;
using Decal.Adapter;
using Decal.Interop.Core;
using MagicHat.Service.Lib;
using MagicHat.Service.Lib.Events;
using MagicHat.Service.Lib.Logging;
using MagicHat.Service.Lib.Plugins;
using MagicHat.Service.Lib.Plugins.AssemblyLoader;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace MagicHat.Service {
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("dcfb2961-ea07-43fa-4D61-676963486174")]
    [ProgId("MagicHat.Service")]
    [ComVisible(true)]
    [ComDefaultInterface(typeof(IDecalService))]
    internal sealed class MagicHatService : MarshalByRefObject, IDecalService, IDecalRender, IDecalWindowsMessageSink {
        private bool _hasServices = false;
        private bool _hasFilters = false;

        internal DecalCore? IDecal;
        private MagicHatLogger<MagicHatService> _log;
        private BackendProvider _backendProvider;
        private bool didInit;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal static MagicHatService Instance { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal static IContainer? Container { get; private set; }

        /// <summary>
        /// The absolute path to the magic hat service dll directory.
        /// </summary>
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetAssembly(typeof(MagicHatService)).Location);

        public MagicHatService() {
            Instance = this;

            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        private Assembly? CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            var name = new AssemblyName(args.Name);
            var localDllPath = Path.Combine(AssemblyDirectory, $"{name.Name}.dll");
            if (File.Exists(localDllPath)) {
                return Assembly.Load(File.ReadAllBytes(localDllPath));
            }

            if (Container?.Resolve<PluginManager>()?.TryResolvePluginAssembly(args, out var loadedAssembly) == true) {
                return loadedAssembly;
            }

            return null;
        }

        void IDecalService.Initialize(DecalCore pDecal) {
            try {
                IDecal = pDecal;
                IDecal.InitializeComplete += IDecal_InitializeComplete;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.Initialize: {ex.Message}");
            }
        }

        private void IDecal_InitializeComplete(eDecalComponentType Type) {
            try {
                if (Type == eDecalComponentType.eNetworkFilter) {
                    _hasFilters = true;
                }
                if (Type == eDecalComponentType.eService) {
                    _hasServices = true;
                }
                if (_hasServices && _hasFilters) {
                    IDecal!.InitializeComplete -= IDecal_InitializeComplete;
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecal_InitializeComplete: {ex.Message}");
            }
        }

        private void Startup() {
            var builder = new ContainerBuilder();
            _log = new MagicHatLogger<MagicHatService>(typeof(MagicHatService));
            _backendProvider = new BackendProvider();

            //builder.RegisterModule<LoggingModule>();
            builder.RegisterInstance<IBackendProvider>(_backendProvider);
            builder.RegisterGeneric(MakeGenericLogger).As(typeof(ILogger<>));
            builder.RegisterInstance(new PluginManager(_backendProvider));

            Container = builder.Build();

            var pluginManager = Container.Resolve<PluginManager>();

            pluginManager.Init(Container);
            pluginManager.LoadPlugins();
            pluginManager.Startup();
        }

        /// <summary>
        /// Make a logger using either the FriendlyNameAttribute or the name of the type. If the type inherits from
        /// IPluginCore it will use the name of the namespace since the class is likely to be named PluginCore.
        /// Otherwise it will use the name of the type with no namespace.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="types"></param>
        /// <returns></returns>
        private object MakeGenericLogger(IComponentContext context, Type[] types) {
            if (types.Length > 0) {
                var friendlyName = types[0].Name;

                if (friendlyName.EndsWith("Plugin")) {
                    friendlyName = friendlyName.Substring(0, friendlyName.Length - 6);
                }

                return Activator.CreateInstance(typeof(MagicHatLogger<>).MakeGenericType(types), new object[] {
                    friendlyName
                });
            }
            else {
                return _log;
            }
        }

        unsafe public bool WindowMessage(int HWND, short uMsg, int wParam, int lParam) {
            try {
                if (uMsg == 0x20/*setcursor*/ || uMsg == 0x84/*WM_NCHITTEST*/) {
                    return false;
                }

                var args = new Lib.Events.WindowMessageEventArgs(HWND, (WindowMessageType)uMsg, wParam, lParam);

                _backendProvider?.TriggerOnWindowMessage(this, args);

                return args.Eat;
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during WindowMessage: {ex.Message}");
            }
            return false;
        }

        void IDecalService.BeforePlugins() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.BeforePlugins: {ex.Message}");
            }
        }

        void IDecalService.AfterPlugins() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.AfterPlugins: {ex.Message}");
            }
        }

        void IDecalService.Terminate() {
            try {
                Container?.Resolve<PluginManager>()?.Dispose();
                Container?.Dispose();
                _log?.LogDebug("\n\n\n");
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during IDecalService.Terminate: {ex.Message}");
            }
        }

        public unsafe void ChangeDirectX() {
            try {
                if (!didInit) {
                    didInit = true;
                    Startup();
                }
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during ChangeDirectX: {ex.Message}");
            }
        }

        public void ChangeHWND() {
            try {
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during ChangeHWND: {ex.Message}");
            }
        }

        public void PreReset() {
            try {
                _backendProvider?.TriggerOnGraphicsPreReset(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during PreReset: {ex.Message}");
            }
        }

        public void PostReset() {
            try {
                _backendProvider?.TriggerOnGraphicsPostReset(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during PostReset: {ex.Message}");
            }
        }

        public void Render2D() {
            try {
                _backendProvider?.TriggerOnRender2D(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Render2D: {ex.Message}");
            }
        }

        public void Render3D() {
            try {
                //OnRender3D?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex) {
                _log?.LogError(ex, $"Error during Render3D: {ex.Message}");
            }
        }
    }
}
