using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Draw command for a rectangle
    /// </summary>
    public struct DrawRectFilledCommand : IDrawCommand {
        /// <inheritdoc/>
        public DrawCommandType Type => DrawCommandType.DrawRectFilled;

        /// <summary>
        /// The rectangle to draw
        /// </summary>
        public Rectangle Rect;

        /// <summary>
        /// The color of the rectangle
        /// </summary>
        public ColorVec Color;

        /// <summary>
        /// Create a new filled rectangle draw command
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        public DrawRectFilledCommand(Rectangle rect, ColorVec color) {
            Rect = rect;
            Color = color;
        }
    }
}
