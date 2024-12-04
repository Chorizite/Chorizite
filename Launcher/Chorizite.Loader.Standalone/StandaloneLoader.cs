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
using System;
using System.Reflection;
using System.Runtime.Loader;

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
                /*
                while (!System.Diagnostics.Debugger.IsAttached) {
                    System.Threading.Thread.Sleep(100);
                }
                //*/

                DirectXHooks.Init(a, b);
                NetHooks.Init();
                ACClientHooks.Init();
                ChatHooks.Init();
                UIHooks.Init();
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to initialize hooks");
            }
            return 0;
        }

        public static void Startup(int unmanagedD3DPtr) {
            try {
                UnmanagedD3DPtr = unmanagedD3DPtr;
                Config = new ChoriziteConfig(ChoriziteEnvironment.Client, _pluginDirectory, _dataDirectory, _logDirectory, Environment.CurrentDirectory);
                ChoriziteInstance = new Chorizite<ACChoriziteBackend>(Config);

                Backend = (ChoriziteInstance.Backend as ACChoriziteBackend)!;
                Render = (ChoriziteInstance.Scope.Resolve<IRenderInterface>() as DX9RenderInterface)!;
                Input = (ChoriziteInstance.Scope.Resolve<IInputManager>() as Win32InputManager)!;
                Net = ChoriziteInstance.Scope.Resolve<NetworkParser>();
            }
            catch (Exception ex) {
                Log.LogError(ex, "Failed to initialize Chorizite");
            }
        }
    }
}
