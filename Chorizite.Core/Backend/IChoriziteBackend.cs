using Autofac;
using Chorizite.Core.Input;
using Chorizite.Core.Render;
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

        public virtual static IChoriziteBackend Create(IContainer container) => throw new NotImplementedException("You must implement IChoriziteBackend.Create static method.");
    }
}
