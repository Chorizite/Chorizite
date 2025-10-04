using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Represents a blend factor
    /// </summary>
    public enum BlendFactor {
        /// <summary>
        /// One
        /// </summary>
        One,

        /// <summary>
        /// Source color
        /// </summary>
        SrcAlpha,

        /// <summary>
        /// One minus source color
        /// </summary>
        OneMinusSrcAlpha,

        /// <summary>
        /// Destination color
        /// </summary>
        DstAlpha,

        /// <summary>
        /// One minus destination color
        /// </summary>
        OneMinusDstAlpha
    }
}
