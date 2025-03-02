using Autofac;
using Chorizite.Common.Enums;
using Chorizite.Core;
using Chorizite.Core.Backend;
using Chorizite.Core.Dats;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;

namespace Chorizite.DocGen.LuaDefs {
    public class DocGenBackend : IChoriziteBackend {
        public override IRenderInterface Renderer { get; } = new NullRenderInterface();

        public override IInputManager Input { get; } = new NullInputManager();

        public override ChoriziteEnvironment Environment => ChoriziteEnvironment.DocGen;

        public override event EventHandler<LogMessageEventArgs> OnLogMessage;

        public static IChoriziteBackend Create(IContainer container) {
            return new DocGenBackend();
        }

        public override string? GetClipboardText() {
            return null;
        }

        public override void HandleLogMessage(LogMessageEventArgs evt) {
            
        }

        public override void Invoke(Action action) {
            
        }

        public override void PlaySound(uint soundId) {
            
        }

        public override void SetClipboardText(string text) {
            
        }

        public override void SetCursorDid(uint did, int hotX = 0, int hotY = 0, bool makeDefault = false) {
            
        }
    }
}