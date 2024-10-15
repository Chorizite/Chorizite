using Autofac;
using Launcher.Render;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;

namespace Launcher.Lib {
    internal class LauncherChoriziteBackend : IChoriziteBackend, ILauncherBackend {
        public IRenderInterface Renderer { get; }
        public OpenGLRenderer GLRenderer { get; }

        public IInputManager Input { get; }
        public SDLInputManager SDLInput { get; }

        public static IChoriziteBackend Create(IContainer container) {
            var renderer = new OpenGLRenderer(container.Resolve<ILogger<OpenGLRenderer>>(), container.Resolve<IDatReaderInterface>());
            var input = new SDLInputManager(container.Resolve<ILogger<SDLInputManager>>());

            return new LauncherChoriziteBackend(renderer, input);
        }

        private LauncherChoriziteBackend(OpenGLRenderer renderer, SDLInputManager input) {
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