using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Enums {
    /// <summary>
    /// Lock mode
    /// </summary>
    public enum LockMode {
        /// <summary>
        /// Read only
        /// </summary>
        ReadOnly,

        /// <summary>
        /// Write only
        /// </summary>
        WriteOnly,

        /// <summary>
        /// Read and write
        /// </summary>
        ReadWrite,

        /// <summary>
        /// Write and discard
        /// </summary>
        WriteDiscard
    }
}
