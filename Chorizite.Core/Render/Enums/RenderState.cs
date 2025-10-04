using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Represents a render state
    /// </summary>
    public enum RenderState {
        /// <summary>
        /// Alpha blending
        /// </summary>
        AlphaBlend,

        /// <summary>
        /// Depth testing
        /// </summary>
        DepthTest,

        /// <summary>
        /// Depth writing
        /// </summary>
        DepthWrite,

        /// <summary>
        /// Scissor testing
        /// </summary>
        ScissorTest,

        /// <summary>
        /// Lighting
        /// </summary>
        Lighting,

        /// <summary>
        /// Fog
        /// </summary>
        Fog
    }
}
