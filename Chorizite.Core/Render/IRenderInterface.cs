using System;
using System.Collections.Generic;
using System.Numerics;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Legacy renderer interface kept for binary compatibility with released plugins.
    /// </summary>
    public interface IRenderInterface : IRenderer {
        /// <summary>
        /// Legacy viewport size property used by older plugins.
        /// </summary>
        Vector2 ViewportSize { get; }

        /// <summary>
        /// Legacy UI render callback used by older plugins.
        /// </summary>
        event EventHandler<EventArgs> OnRender2D;

        /// <summary>
        /// Legacy graphics-device pre-reset callback used by older plugins.
        /// </summary>
        event EventHandler<EventArgs> OnGraphicsPreReset;

        /// <summary>
        /// Legacy graphics-device post-reset callback used by older plugins.
        /// </summary>
        event EventHandler<EventArgs> OnGraphicsPostReset;

        /// <summary>
        /// Compile a geometry buffer for UI rendering.
        /// </summary>
        IntPtr CompileGeometry(IEnumerable<VertexPositionColorTexture> vertices, IEnumerable<int> indices);

        /// <summary>
        /// Render previously compiled geometry.
        /// </summary>
        void RenderGeometry(IntPtr geometry, Matrix4x4 transform, ITexture? texture);

        /// <summary>
        /// Release previously compiled geometry.
        /// </summary>
        void ReleaseGeometry(IntPtr geometry);

        /// <summary>
        /// Generate a texture from raw pixel data.
        /// </summary>
        ITexture GenerateTexture(byte[] source, Vector2 dimensions);

        /// <summary>
        /// Load a texture from a source path.
        /// </summary>
        ITexture? LoadTexture(string source, out Vector2 textureDimensions);

        /// <summary>
        /// Release a previously loaded texture.
        /// </summary>
        void ReleaseTexture(ITexture texture);

        /// <summary>
        /// Enable or disable the legacy scissor region.
        /// </summary>
        void EnableScissorRegion(bool enable);

        /// <summary>
        /// Set the legacy scissor region.
        /// </summary>
        void SetScissorRegion(int left, int top, int right, int bottom);

        /// <summary>
        /// Set the legacy world transform.
        /// </summary>
        void SetTransform(Matrix4x4 transform);
    }
}
