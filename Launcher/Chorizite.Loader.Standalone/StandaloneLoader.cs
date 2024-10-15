using AcClient;
using Autofac;
using Chorizite.Core;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Logging;
using Chorizite.Core.Net;
using Chorizite.Core.Render;
using Chorizite.Loader.Standalone.Hooks;
using Chorizite.Loader.Standalone.Input;
using Chorizite.Loader.Standalone.Render;
using Microsoft.Extensions.Logging;
using Reloaded.Memory.Pointers;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;

namespace Chorizite.Loader.Standalone {
    public static class StandaloneLoader {
        public static string AssemblyDirectory => System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(StandaloneLoader))!.Location)!;

        private static readonly string _pluginDirectory = System.IO.Path.Combine(AssemblyDirectory, "plugins");
        private static readonly string _dataDirectory = System.IO.Path.Combine(AssemblyDirectory, "data");
        private static readonly string _logDirectory = System.IO.Path.Combine(_dataDirectory, "logs");

        public static int UnmanagedD3DPtr { get; private set; }
        public static ChoriziteConfig Config { get; private set; }
        public static Core.Chorizite<ACChoriziteBackend> ChoriziteInstance { get; private set; }
        public static ACChoriziteBackend Backend { get; private set; }
        public static DX9RenderInterface Render { get; private set; }
        public static Win32InputManager Input { get; private set; }
        public static NetworkParser Net { get; private set; }
        public static ILogger Log { get; } = new ChoriziteLogger("StandaloneLoader", _logDirectory);

        public static unsafe int Init(IntPtr a, int b) {
            try {
                Log?.LogError($"Startup");
                
                /*
                while (!Debugger.IsAttached) {
                    Thread.Sleep(100);
                }
                */

                DirectXHooks.Init(a, b);
                NetHooks.Init();
                ACClientHooks.Init();
            }
            catch (Exception ex) { Log?.LogError(ex.ToString()); }
            return 0;
        }

        internal static void Startup(int _unmanagedD3DPtr) {
            try {
                UnmanagedD3DPtr = _unmanagedD3DPtr;
                Config = new ChoriziteConfig(ChoriziteEnvironment.Client, _pluginDirectory, _dataDirectory, _logDirectory, Environment.CurrentDirectory);
                ChoriziteInstance = new Chorizite<ACChoriziteBackend>(Config);

                Backend = (ChoriziteInstance.Backend as ACChoriziteBackend)!;
                Render = (ChoriziteInstance.Scope.Resolve<IRenderInterface>() as DX9RenderInterface)!;
                Input = (ChoriziteInstance.Scope.Resolve<IInputManager>() as Win32InputManager)!;
                Net = ChoriziteInstance.Scope.Resolve<NetworkParser>();
            }
            catch (Exception ex) {
                Log?.LogError(ex, $"Error during Startup: {ex.Message}");
            }
        }
    }
}
