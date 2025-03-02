using Autofac;
using LauncherApp.Lib;
using LauncherApp.Render;
using Chorizite.Core;
using Chorizite.Core.Logging;
using Chorizite.Core.Plugins;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;
using Chorizite.Common.Enums;

namespace LauncherApp {
    internal static class Program {
        public static string AssemblyDirectory => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

        private static readonly string _pluginDirectory = Path.Combine(AssemblyDirectory, "plugins");
        private static readonly string _dataDirectory = Path.Combine(AssemblyDirectory, "data");
        private static readonly string _logDirectory = Path.Combine(_dataDirectory, "logs");
        private static readonly string _datDirectory = @"C:\Turbine\Asheron's Call\";
        private static bool _shouldExit;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public static ILogger Log { get; private set; }
        public static OpenGLRenderer Renderer { get; private set; }
        public static SDLInputManager Input { get; private set; }
        public static LaunchManager LaunchManager { get; private set; }
        public static ChoriziteConfig Config { get; private set; }
        public static Chorizite<LauncherChoriziteBackend> ChoriziteInstance { get; private set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

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