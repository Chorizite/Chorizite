using AcClient;
using Autofac;
using MagicHat.Backends.ACBackend.Input;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Logging;
using MagicHat.Core.Net;
using MagicHat.Core.Render;
using MagicHat.Loader.Injected.Hooks;
using Microsoft.Extensions.Logging;
using Reloaded.Memory.Pointers;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MagicHat.Loader.Injected {
    public static class InjectedLoader {
        public static string AssemblyDirectory => System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(InjectedLoader))!.Location)!;

        public static int UnmanagedD3DPtr { get; private set; }
        public static MagicHatConfig Config { get; private set; }
        public static Core.MagicHat<ACMagicHatBackend> MagicHatInstance { get; private set; }
        public static ACMagicHatBackend Backend { get; private set; }
        public static DX9RenderInterface Render { get; private set; }
        public static Win32InputManager Input { get; private set; }
        public static NetworkParser Net { get; private set; }
        public static ILogger Log { get; } = new MagicHatLogger("InjectedLoader", AssemblyDirectory);

        public static unsafe int Init(IntPtr a, int b) {
            try {
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
                var pluginDirectory = System.IO.Path.Combine(AssemblyDirectory, "..", "plugins");
                var dataDirectory = System.IO.Path.Combine(AssemblyDirectory, "..", "data");
                Config = new MagicHatConfig(pluginDirectory, dataDirectory, AssemblyDirectory);
                MagicHatInstance = new MagicHat<ACMagicHatBackend>(Config);

                Backend = (MagicHatInstance.Backend as ACMagicHatBackend)!;
                Render = (MagicHatInstance.Scope.Resolve<IRenderInterface>() as DX9RenderInterface)!;
                Input = (MagicHatInstance.Scope.Resolve<IInputManager>() as Win32InputManager)!;
                Net = MagicHatInstance.Scope.Resolve<NetworkParser>();
            }
            catch (Exception ex) {
                Log?.LogError(ex, $"Error during Startup: {ex.Message}");
            }
        }
    }
}
