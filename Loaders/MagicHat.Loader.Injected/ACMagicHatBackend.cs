using Autofac;
using MagicHat.Backends.ACBackend.Input;
using MagicHat.Backends.ACBackend.Render;
using MagicHat.Core;
using MagicHat.Core.Backend;
using MagicHat.Core.Dats;
using MagicHat.Core.Input;
using MagicHat.Core.Render;
using Microsoft.Extensions.Logging;

namespace MagicHat.Loader.Injected {
    public class ACMagicHatBackend : IMagicHatBackend {
        public IRenderInterface Renderer { get; }
        public DX9RenderInterface DX9Renderer { get; }

        public IInputManager Input { get; }
        public Win32InputManager Win32Input { get; }

        public static IMagicHatBackend Create(IContainer container) {
            var renderer = new DX9RenderInterface(InjectedLoader.UnmanagedD3DPtr, container.Resolve<ILogger<DX9RenderInterface>>(), container.Resolve<IDatReaderInterface>());
            var input = new Win32InputManager(container.Resolve<ILogger<Win32InputManager>>());

            return new ACMagicHatBackend(renderer, input);
        }

        private ACMagicHatBackend(DX9RenderInterface renderer, Win32InputManager input) {
            DX9Renderer = renderer;
            Renderer = renderer;
            Win32Input = input;
            Input = input;
        }

        public void Dispose() {
            Renderer?.Dispose();
            Input?.Dispose();
        }
    }
}
