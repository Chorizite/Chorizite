using Chorizite.Core.Render.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chorizite.Core.Render.Vertex {
    /// <summary>
    /// Represents a vertex with position and color
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionColor : IVertex {
        private static readonly VertexFormat _format = new VertexFormat(
            new VertexAttribute(VertexAttributeName.Position, 3, VertexAttribType.Float, false, 0),
            new VertexAttribute(VertexAttributeName.Color, 3, VertexAttribType.Float, false, 12)
        );

        /// <summary>
        /// The size of the vertex, in bytes
        /// </summary>
        public static int Size => Marshal.SizeOf<VertexPositionTexture>();

        /// <summary>
        /// The vertex format for this vertex type
        /// </summary>
        public static VertexFormat Format => _format;

        /// <summary>
        /// The position
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// The color
        /// </summary>
        public ColorVec Color;

        /// <summary>
        /// Constructs a vertex
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color"></param>
        public VertexPositionColor(Vector3 position, ColorVec color) {
            Position = position;
            Color = color;
        }
    }
}
