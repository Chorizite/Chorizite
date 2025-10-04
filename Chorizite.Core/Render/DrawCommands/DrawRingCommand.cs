using Chorizite.Core.Render.Enums;
using Chorizite.Core.Render.Vertex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.DrawCommands {
    /// <summary>
    /// Draw command for a ring
    /// </summary>
    public struct DrawRingCommand : IDrawCommand {
        /// <inheritdoc/>
        public DrawCommandType Type => DrawCommandType.DrawRing;

        /// <summary>
        /// The center of the ring
        /// </summary>
        public Vector2 Center;

        /// <summary>
        /// The inner radius
        /// </summary>
        public float InnerRadius;

        /// <summary>
        /// The outer radius
        /// </summary>
        public float OuterRadius;

        /// <summary>
        /// The start angle
        /// </summary>
        public float StartAngle;

        /// <summary>
        /// The end angle
        /// </summary>
        public float EndAngle;

        /// <summary>
        /// The number of segments
        /// </summary>
        public int Segments;

        /// <summary>
        /// The color
        /// </summary>
        public ColorVec Color;

        /// <summary>
        /// Create a new ring draw command
        /// </summary>
        /// <param name="center">The center of the ring</param>
        /// <param name="innerRadius">The inner radius</param>
        /// <param name="outerRadius">The outer radius</param>
        /// <param name="startAngle">The start angle</param>
        /// <param name="endAngle">The end angle</param>
        /// <param name="segments">The number of segments</param>
        /// <param name="color">The color</param>
        public DrawRingCommand(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, ColorVec color) {
            Center = center;
            InnerRadius = innerRadius;
            OuterRadius = outerRadius;
            StartAngle = startAngle;
            EndAngle = endAngle;
            Segments = segments;
            Color = color;
        }
    }
}
