using Autofac;
using Launcher.Render;
using MagicHat.Core.Backend;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;

namespace Launcher.Lib {
    internal class LauncherMagicHatBackend : IMagicHatBackend, ILauncherBackend {
        public IRenderInterface Renderer { get; }
        public OpenGLRenderer GLRenderer { get; }

        public IInputManager Input { get; }
        public SDLInputManager SDLInput { get; }

        public static IMagicHatBackend Create(IContainer container) {
            var renderer = new OpenGLRenderer(container.Resolve<ILogger<OpenGLRenderer>>(), container.Resolve<IDatReaderInterface>());
            var input = new SDLInputManager(container.Resolve<ILogger<SDLInputManager>>());

            return new LauncherMagicHatBackend(renderer, input);
        }

        private LauncherMagicHatBackend(OpenGLRenderer renderer, SDLInputManager input) {
            GLRenderer = renderer;
            Renderer = renderer;
            SDLInput = input;
            Input = input;
        }

        public void SetWindowSize(int width, int height) {
            GLRenderer.Resize(width, height);
        }

        public void LaunchClient(string clientPath, string server, string username, string password) {
            Program.LaunchManager.Launch(clientPath, server, username, password);
        }

        public void Exit() {
            
        }

        public void Dispose() {
            
        }
    }
}