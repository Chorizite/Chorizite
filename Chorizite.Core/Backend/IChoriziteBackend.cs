using Autofac;
using Chorizite.Common;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Backend {
    public interface IChoriziteBackend {
        /// <summary>
        /// Get the <see cref="IRenderInterface"/> being used for this backend.
        /// </summary>
        public IRenderInterface Renderer { get; }

        /// <summary>
        /// Get the <see cref="IInputManager"/> being used for this backend.
        /// </summary>
        public IInputManager Input { get; }

        /// <summary>
        /// Fired when the backend logs a message.
        /// </summary>
        public virtual event EventHandler<LogMessageEventArgs>? OnLogMessage {
            add { _OnLogMessage.Subscribe(value); }
            remove { _OnLogMessage.Unsubscribe(value); }
        }
        protected abstract WeakEvent<LogMessageEventArgs> _OnLogMessage { get; }

        /// <summary>
        /// Handle a log message.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public virtual void HandleLogMessage(LogLevel logLevel, string message) => _OnLogMessage.Invoke(this, new LogMessageEventArgs(logLevel, message));

        public virtual static IChoriziteBackend Create(IContainer container) => throw new NotImplementedException("You must implement IChoriziteBackend.Create static method.");

        void PlaySound(uint soundId);
    }
}
