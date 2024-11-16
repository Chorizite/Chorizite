using Autofac;
using Launcher.Render;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using Chorizite.Common;

namespace Launcher.Lib {
    internal class LauncherChoriziteBackend : IChoriziteBackend, ILauncherBackend {
        /// <inheritdoc/>
        public IRenderInterface Renderer { get; }

        /// <summary>
        /// The <see cref="OpenGLRenderer"/> used by this backend
        /// </summary>
        public OpenGLRenderer GLRenderer { get; }

        /// <inheritdoc/>
        public IInputManager Input { get; }

        /// <summary>
        /// The <see cref="SDLInputManager"/> used by this backend
        /// </summary>
        public SDLInputManager SDLInput { get; }

        WeakEvent<LogMessageEventArgs> IChoriziteBackend._OnLogMessage { get; } = new();

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
            Program.Exit();
        }

        public void Minimize() {
            Native.ShowWindow(GLRenderer.HWND, 2);
        }

        public void Dispose() {
            
        }
    }
}