using Autofac;
using Launcher.Lib;
using Launcher.Render;
using Chorizite.Core;
using Chorizite.Core.Logging;
using Chorizite.Core.Plugins;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace Launcher {
    internal static class Program {
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        private static readonly string _pluginDirectory = Path.Combine(AssemblyDirectory, "plugins");
        private static readonly string _dataDirectory = Path.Combine(AssemblyDirectory, "data");
        private static readonly string _logDirectory = Path.Combine(_dataDirectory, "logs");
        private static readonly string _datDirectory = @"C:\Turbine\Asheron's Call\";
        private static bool _shouldExit;

        public static ILogger Log { get; private set; }
        public static OpenGLRenderer Renderer { get; private set; }
        public static SDLInputManager Input { get; private set; }
        public static LaunchManager LaunchManager { get; private set; }
        public static ChoriziteConfig Config { get; private set; }
        public static Chorizite<LauncherChoriziteBackend> ChoriziteInstance { get; private set; }

        static void Main() {
            Log = new ChoriziteLogger("Launcher", _logDirectory);

            Log.LogDebug($"Launcher version: {FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion}");

            LaunchManager = new LaunchManager(Log);

            Config = new ChoriziteConfig(ChoriziteEnvironment.Launcher, AssemblyDirectory, _datDirectory);
            ChoriziteInstance = new Chorizite<LauncherChoriziteBackend>(Config);

            Input = (ChoriziteInstance.Backend.Input as SDLInputManager)!;
            Renderer = (ChoriziteInstance.Backend.Renderer as OpenGLRenderer)!;

            var pluginManager = ChoriziteInstance.Scope.Resolve<IPluginManager>();

            while (!_shouldExit) {
                Input.Update();
                Renderer.Update();
                Renderer.Render();
                if (!Renderer.HasFocus) {
                    Thread.Sleep(20);
                }
            }

            Input?.HandleShutdown();
            System.Environment.Exit(0);
        }

        public static void Exit() {
            _shouldExit = true;
        }
    }
}