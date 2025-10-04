using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Draw command for clipping
    /// </summary>
    public struct DrawClipCommand : IDrawCommand {
        /// <inheritdoc/>
        public DrawCommandType Type => DrawCommandType.Clip;

        /// <summary>
        /// Rectangle to clip to, null for no clipping
        /// </summary>
        public Rectangle? Clip;

        /// <summary>
        /// Create a new clip draw command
        /// </summary>
        /// <param name="clip"></param>
        public DrawClipCommand(Rectangle? clip) {
            Clip = clip;
        }
    }
}
