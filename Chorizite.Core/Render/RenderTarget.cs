using Autofac;
using Chorizite.Core.Dats;
using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a render target for rendering to a texture or the screen.
    /// </summary>
    public class RenderTarget : IDisposable {
        private readonly IRenderer _renderer;
        private readonly ILogger _log;

        /// <summary>
        /// The framebuffer associated with this render target, or null for the default framebuffer.
        /// </summary>
        public IFramebuffer? Framebuffer { get; }

        /// <summary>
        /// The output texture
        /// </summary>
        public ITexture Texture { get; }

        /// <summary>
        /// The viewport for this render target.
        /// </summary>
        public Rectangle Viewport { get; set; }

        /// <summary>
        /// The draw list associated with this render target.
        /// </summary>
        public DrawList DrawList { get; }

        public RenderTarget(IRenderer renderer, ILogger log, int width, int height) {
            _renderer = renderer;
            _log = log;
            Viewport = new Rectangle(0, 0, width, height);
            //DrawList = new DrawList(_renderer, ChoriziteStatics.Scope.Resolve<IDatReaderInterface>(), _log);
            Texture = _renderer.GraphicsDevice.CreateTexture(TextureFormat.RGBA8, Viewport.Width, Viewport.Height, null);
            Framebuffer = _renderer.GraphicsDevice.CreateFramebuffer(Texture, Viewport.Width, Viewport.Height, true);
        }

        /// <summary>
        /// Clear the render target
        /// </summary>
        /// <param name="color">The color</param>
        /// <param name="flags">The clear flags</param>
        /// <param name="depth">The depth value</param>
        /// <param name="stencil">The stencil value</param>
        public void Clear(ColorVec color, ClearFlags flags = ClearFlags.Color | ClearFlags.Depth | ClearFlags.Stencil, float depth = 0, int stencil = 0) {
            _renderer.GraphicsDevice.Clear(color, flags, depth, stencil);
        }

        /// <summary>
        /// Binds the render target and prepares it for rendering.
        /// </summary>
        internal void Bind() {
            _renderer.GraphicsDevice.BindFramebuffer(Framebuffer);
        }

        /// <summary>
        /// Executes the draw calls associated with this render target.
        /// </summary>
        public void Flush() {
            DrawList.Flush();
        }

        /// <summary>
        /// Releases resources associated with this render target.
        /// </summary>
        public void Dispose() {
            Framebuffer?.Dispose();
            Texture?.Dispose();
            DrawList?.Dispose();
        }
    }
}
