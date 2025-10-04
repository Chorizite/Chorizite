using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Draw command for a rectangle outline (border)
    /// </summary>
    public struct DrawRectCommand : IDrawCommand {
        /// <inheritdoc/>
        public DrawCommandType Type => DrawCommandType.DrawRect;

        /// <summary>
        /// The rectangle to draw
        /// </summary>
        public Rectangle Rect;

        /// <summary>
        /// The color of the rectangle
        /// </summary>
        public ColorVec Color;

        /// <summary>
        /// The thickness of the rectangle border
        /// </summary>
        public int Thickness = 1;

        /// <summary>
        /// Create a new rectangle outline draw command
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="color"></param>
        /// <param name="thickness"></param>
        public DrawRectCommand(Rectangle rect, ColorVec color, int thickness = 1) {
            Rect = rect;
            Color = color;
            Thickness = thickness;
        }
    }
}
