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
    public abstract class IChoriziteBackend {
        internal readonly Dictionary<string, object> _modules = [];

        /// <summary>
        /// Get the <see cref="IRenderInterface"/> being used for this backend.
        /// </summary>
        public abstract IRenderInterface Renderer { get; }

        /// <summary>
        /// Get the <see cref="IInputManager"/> being used for this backend.
        /// </summary>
        public abstract IInputManager Input { get; }

        /// <summary>
        /// Get the <see cref="ChoriziteEnvironment"/> being used for this backend.
        /// </summary>
        public abstract ChoriziteEnvironment Environment { get; }

        /// <summary>
        /// Fired when the backend logs a message.
        /// </summary>
        public abstract event EventHandler<LogMessageEventArgs> OnLogMessage;

        /// <summary>
        /// Handle a log message.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public abstract void HandleLogMessage(LogMessageEventArgs evt);

        /// <summary>
        /// Play a sound from the dats
        /// </summary>
        /// <param name="soundId"></param>
        public abstract void PlaySound(uint soundId);

        /// <summary>
        /// Set the cursor from the dats
        /// </summary>
        /// <param name="did"></param>
        /// <param name="hotX"></param>
        /// <param name="hotY"></param>
        /// <param name="makeDefault"></param>
        public abstract void SetCursorDid(uint did, int hotX = 0, int hotY = 0, bool makeDefault = false);

        /// <summary>
        /// Set the clipboard
        /// </summary>
        /// <param name="text"></param>
        public abstract void SetClipboardText(string text);

        /// <summary>
        /// Get the clipboard
        /// </summary>
        /// <returns></returns>
        public abstract string? GetClipboardText();

        /// <summary>
        /// Register a lua module
        /// </summary>
        /// <param name="name"></param>
        /// <param name="module"></param>
        public virtual bool RegisterLuaModule(string name, object module) {
            if (!_modules.TryAdd(name, module)) {
                ChoriziteStatics.Log.LogWarning($"Failed to register lua module: {name}. Already exists with value: {_modules[name]}");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Unregister a lua module
        /// </summary>
        /// <param name="name"></param>
        public virtual bool UnregisterLuaModule(string name) => _modules.Remove(name);
    }
}
