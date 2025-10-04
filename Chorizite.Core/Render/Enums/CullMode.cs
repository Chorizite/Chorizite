using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Culling mode
    /// </summary>
    public enum CullMode {
        /// <summary>
        /// No culling
        /// </summary>
        None,

        /// <summary>
        /// Cull front faces
        /// </summary>
        Front,

        /// <summary>
        /// Cull back faces
        /// </summary>
        Back
    }
}
