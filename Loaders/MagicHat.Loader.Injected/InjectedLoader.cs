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

                /*
                // Initialize the scanner.
                var thisProcess = Process.GetCurrentProcess();
                var baseAddress = thisProcess.MainModule.BaseAddress;
                var exeSize = thisProcess.MainModule.ModuleMemorySize;
                using var scanner = new Scanner((byte*)baseAddress, exeSize);
                InjectedLoader.Log?.LogError($"bad {baseAddress:X8} {exeSize:X8}");

                // Search for a given pattern
                // Note: If created signature using SigMaker, replace ? with ??.v
                var sig = "56 8B F1 8B 06 FF 50 08 8B 4C 24 0C 3B C8 72 29 83 F9 04 72 24 8B 44 24 08 8B 10 57 8B 7E 04 89";
                var result = scanner.FindPattern(sig);
                if (!result.Found)
                    InjectedLoader.Log?.LogError($"Failed to find signature: {sig}");

                // Address of `mov levelId, edx`
                var codeAddress = baseAddress + result.Offset;
                InjectedLoader.Log?.LogError($"OFFSET: {codeAddress:X8} vs 0x004117B0");
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
                Config = new MagicHatConfig(System.IO.Path.Combine(AssemblyDirectory, "plugins"), AssemblyDirectory);
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
