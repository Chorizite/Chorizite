using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Clear flags
    /// </summary>
    public enum ClearFlags {
        /// <summary>
        /// Color
        /// </summary>
        Color = 1,

        /// <summary>
        /// Depth
        /// </summary>
        Depth = 2,

        /// <summary>
        /// Stencil
        /// </summary>
        Stencil = 4
    }
}
