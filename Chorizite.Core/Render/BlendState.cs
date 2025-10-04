using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render {
    /// <summary>
    /// Represents a blend state configuration that can be used with both DirectX9 and OpenGL ES 3.
    /// </summary>
    public struct BlendState {
        /// <summary>
        /// Whether blending is enabled.
        /// </summary>
        public bool Enabled;

        /// <summary>
        /// The source blend factor.
        /// </summary>
        public BlendFactor SourceFactor;

        /// <summary>
        /// The destination blend factor.
        /// </summary>
        public BlendFactor DestinationFactor;

        /// <summary>
        /// Creates a custom blend state.
        /// </summary>
        /// <param name="enabled">Enable or disable blending.</param>
        /// <param name="srcFactor">Source blend factor.</param>
        /// <param name="dstFactor">Destination blend factor.</param>
        public BlendState(bool enabled, BlendFactor srcFactor, BlendFactor dstFactor) {
            Enabled = enabled;
            SourceFactor = srcFactor;
            DestinationFactor = dstFactor;
        }

        /// <summary>
        /// Blend disabled (opaque rendering).
        /// </summary>
        public static BlendState Opaque() {
            return new BlendState(false, BlendFactor.One, BlendFactor.One);
        }

        /// <summary>
        /// Alpha blending (common for transparent objects).
        /// </summary>
        public static BlendState AlphaBlend() {
            return new BlendState(true, BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);
        }

        /// <summary>
        /// Additive blending (used for glow or fire effects).
        /// </summary>
        public static BlendState Additive() {
            return new BlendState(true, BlendFactor.SrcAlpha, BlendFactor.One);
        }

        /// <summary>
        /// Premultiplied alpha blending.
        /// </summary>
        public static BlendState Premultiplied() {
            return new BlendState(true, BlendFactor.One, BlendFactor.OneMinusSrcAlpha);
        }
    }
}
