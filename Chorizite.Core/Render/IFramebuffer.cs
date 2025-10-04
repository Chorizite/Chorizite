using System;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a framebuffer object for rendering to a texture.
    /// </summary>
    public interface IFramebuffer : IDisposable {
        /// <summary>
        /// The texture attached to this framebuffer.
        /// </summary>
        ITexture Texture { get; }

        /// <summary>
        /// The native framebuffer handle.
        /// </summary>
        IntPtr NativeHandle { get; }
    }
}